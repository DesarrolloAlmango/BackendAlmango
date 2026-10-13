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
   public class solicitudesreporte : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_51( A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_58") == 0 )
         {
            A669STMonedasId = (short)(Math.Round(NumberUtil.Val( GetPar( "STMonedasId"), "."), 18, MidpointRounding.ToEven));
            n669STMonedasId = false;
            AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_58( A669STMonedasId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A130EstadosSolTipo = GetPar( "EstadosSolTipo");
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosSolId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A130EstadosSolTipo, A131EstadosSolId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A128MetodoPagosID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
         {
            A919STComerciosID = (long)(Math.Round(NumberUtil.Val( GetPar( "STComerciosID"), "."), 18, MidpointRounding.ToEven));
            n919STComerciosID = false;
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_56( A919STComerciosID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
         {
            A735MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
            n735MudanzaId = false;
            AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_54( A735MudanzaId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudesreporte.aspx")), "solicitudesreporte.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudesreporte.aspx")))) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Solicitudes Reporte", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSolicitudesNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public solicitudesreporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesreporte( IGxContext context )
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
         chkSolicitudServicioSolCoti = new GXCheckbox();
         chkSolicitudesOtros1 = new GXCheckbox();
         cmbSolicitudesNotificacion = new GXCombobox();
         cmbProveedorPagoDefault = new GXCombobox();
         cmbSTComerciosEstado = new GXCombobox();
         cmbSolicitudServicioOrigenPago = new GXCombobox();
         cmbSolicitudesPagado = new GXCombobox();
         chkSolicitudesCalComi = new GXCheckbox();
         cmbSolicitudesSubTipo = new GXCombobox();
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
         A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(StringUtil.RTrim( A210SolicitudServicioSolCoti), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         if ( cmbSolicitudesNotificacion.ItemCount > 0 )
         {
            A262SolicitudesNotificacion = cmbSolicitudesNotificacion.getValidValue(A262SolicitudesNotificacion);
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesNotificacion.CurrentValue = StringUtil.RTrim( A262SolicitudesNotificacion);
            AssignProp("", false, cmbSolicitudesNotificacion_Internalname, "Values", cmbSolicitudesNotificacion.ToJavascriptSource(), true);
         }
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", cmbProveedorPagoDefault.ToJavascriptSource(), true);
         }
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
            AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", cmbSTComerciosEstado.ToJavascriptSource(), true);
         }
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
            A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
            n438SolicitudServicioOrigenPago = false;
            AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Values", cmbSolicitudServicioOrigenPago.ToJavascriptSource(), true);
         }
         if ( cmbSolicitudesPagado.ItemCount > 0 )
         {
            A441SolicitudesPagado = cmbSolicitudesPagado.getValidValue(A441SolicitudesPagado);
            n441SolicitudesPagado = false;
            AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
            AssignProp("", false, cmbSolicitudesPagado_Internalname, "Values", cmbSolicitudesPagado.ToJavascriptSource(), true);
         }
         A672SolicitudesCalComi = StringUtil.StrToBool( StringUtil.BoolToStr( A672SolicitudesCalComi));
         AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
         if ( cmbSolicitudesSubTipo.ItemCount > 0 )
         {
            A600SolicitudesSubTipo = cmbSolicitudesSubTipo.getValidValue(A600SolicitudesSubTipo);
            n600SolicitudesSubTipo = false;
            AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Values", cmbSolicitudesSubTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesID_Internalname, context.GetMessage( "Solicitud No:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSolicitudesNombre_Internalname, StringUtil.RTrim( A171SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_133_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_133_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_133_Internalname, sImgUrl, imgprompt_133_Link, "", "", context.GetTheme( ), imgprompt_133_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombreAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombreAux_Internalname, context.GetMessage( "Nombre Aux", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombreAux_Internalname, StringUtil.RTrim( A533ProveedorNombreAux), StringUtil.RTrim( context.localUtil.Format( A533ProveedorNombreAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombreAux_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombreAux_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesTelefono_Internalname, StringUtil.RTrim( A172SolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( A172SolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "598 099 999999", edtSolicitudesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesMail_Internalname, context.GetMessage( "Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesMail_Internalname, A206SolicitudesMail, StringUtil.RTrim( context.localUtil.Format( A206SolicitudesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A206SolicitudesMail, "", "", "", edtSolicitudesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_SolicitudesReporte.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_112_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_112_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_112_Internalname, sImgUrl, imgprompt_112_Link, "", "", context.GetTheme( ), imgprompt_112_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoDepartamento_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoDepartamento_Internalname, StringUtil.RTrim( A113DepartamentoDepartamento), StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoDepartamento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoDepartamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoMunicipioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoMunicipioId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoMunicipioId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoMunicipioId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_114_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_114_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_114_Internalname, sImgUrl, imgprompt_114_Link, "", "", context.GetTheme( ), imgprompt_114_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoMunicipioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoMunicipioNombre_Internalname, context.GetMessage( "Municipio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoMunicipioNombre_Internalname, StringUtil.RTrim( A115DepartamentoMunicipioNombre), StringUtil.RTrim( context.localUtil.Format( A115DepartamentoMunicipioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoMunicipioNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDepartamentoMunicipioNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtZonasID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZonasID_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Seleccione su Zona", ""), edtZonasID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtZonasID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_110_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_110_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_110_Internalname, sImgUrl, imgprompt_110_Link, "", "", context.GetTheme( ), imgprompt_110_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSolicitudesDireccion_Internalname, A173SolicitudesDireccion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", 0, 1, edtSolicitudesDireccion_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", context.GetMessage( "Calle, casa numero 1234...", ""), -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesAutoEnumerar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesAutoEnumerar_Internalname, context.GetMessage( "Auto Enumerar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesAutoEnumerar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesAutoEnumerar_Enabled!=0) ? context.localUtil.Format( (decimal)(A194SolicitudesAutoEnumerar), "ZZZ9") : context.localUtil.Format( (decimal)(A194SolicitudesAutoEnumerar), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesAutoEnumerar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesAutoEnumerar_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTMonedasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTMonedasId_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTMonedasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A669STMonedasId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A669STMonedasId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTMonedasId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTMonedasId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_669_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_669_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_669_Internalname, sImgUrl, imgprompt_669_Link, "", "", context.GetTheme( ), imgprompt_669_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTMonedasISO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTMonedasISO_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTMonedasISO_Internalname, StringUtil.RTrim( A671STMonedasISO), StringUtil.RTrim( context.localUtil.Format( A671STMonedasISO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTMonedasISO_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTMonedasISO_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "MonISO", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesLiqProf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesLiqProf_Internalname, context.GetMessage( "del Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesLiqProf_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A688SolicitudesLiqProf), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesLiqProf_Enabled!=0) ? context.localUtil.Format( (decimal)(A688SolicitudesLiqProf), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A688SolicitudesLiqProf), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesLiqProf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesLiqProf_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesLiqProv_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesLiqProv_Internalname, context.GetMessage( "del Comercio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesLiqProv_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A689SolicitudesLiqProv), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesLiqProv_Enabled!=0) ? context.localUtil.Format( (decimal)(A689SolicitudesLiqProv), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A689SolicitudesLiqProv), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesLiqProv_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesLiqProv_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCotizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCotizacion_Internalname, context.GetMessage( "Cotización:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCotizacion_Enabled!=0) ? context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCotizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesTotal_Internalname, context.GetMessage( "Total Instalación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesTotal_Enabled!=0) ? context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTotal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSolicitudServicioSolCoti_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSolicitudServicioSolCoti_Internalname, context.GetMessage( "Solicitar cotización ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSolicitudServicioSolCoti_Internalname, A210SolicitudServicioSolCoti, "", context.GetMessage( "Solicitar cotización ", ""), 1, chkSolicitudServicioSolCoti.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioPFinal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioPFinal_Internalname, context.GetMessage( "Precio Final", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioPFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioPFinal_Enabled!=0) ? context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioPFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioPFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesDescuento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesDescuento_Internalname, context.GetMessage( "Descuento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesDescuento_Internalname, StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesDescuento_Enabled!=0) ? context.localUtil.Format( A897SolicitudesDescuento, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A897SolicitudesDescuento, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesDescuento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesDescuento_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesComisionMetodoPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesComisionMetodoPago_Internalname, context.GetMessage( "Comisión del Metodo de Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesComisionMetodoPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesComisionMetodoPago_Enabled!=0) ? context.localUtil.Format( A796SolicitudesComisionMetodoPago, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A796SolicitudesComisionMetodoPago, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesComisionMetodoPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesComisionMetodoPago_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosSolTipo_Internalname, context.GetMessage( "Sol Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosSolTipo_Internalname, StringUtil.RTrim( A130EstadosSolTipo), StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosSolId_Internalname, context.GetMessage( "Sol Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolId_Enabled, 1, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_130_131_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_130_131_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_130_131_Internalname, sImgUrl, imgprompt_130_131_Link, "", "", context.GetTheme( ), imgprompt_130_131_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosSolNombre_Internalname, context.GetMessage( "Sol Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosSolNombre_Internalname, StringUtil.RTrim( A132EstadosSolNombre), StringUtil.RTrim( context.localUtil.Format( A132EstadosSolNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSolicitudesOtros1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSolicitudesOtros1_Internalname, context.GetMessage( "No aparecen en el listado los servicios que necesito.", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSolicitudesOtros1_Internalname, A201SolicitudesOtros1, context.GetMessage( "No aparecen en el listado los servcios que necesito.", ""), context.GetMessage( "No aparecen en el listado los servicios que necesito.", ""), 1, chkSolicitudesOtros1.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(162, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,162);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesOtros2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesOtros2_Internalname, context.GetMessage( "Ingrese los servicios que necesita:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSolicitudesOtros2_Internalname, StringUtil.RTrim( A202SolicitudesOtros2), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", 0, 1, edtSolicitudesOtros2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesOtros3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesOtros3_Internalname, context.GetMessage( "Otros", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSolicitudesOtros3_Internalname, StringUtil.RTrim( A203SolicitudesOtros3), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", 0, 1, edtSolicitudesOtros3_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesUsrAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesUsrAlta_Internalname, context.GetMessage( "Usr Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesUsrAlta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A597SolicitudesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesUsrAlta_Enabled!=0) ? context.localUtil.Format( (decimal)(A597SolicitudesUsrAlta), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A597SolicitudesUsrAlta), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesUsrAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesUsrAlta_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "UserID", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesUsrActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesUsrActualizacion_Internalname, context.GetMessage( "Usr Actualizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesUsrActualizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A598SolicitudesUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesUsrActualizacion_Enabled!=0) ? context.localUtil.Format( (decimal)(A598SolicitudesUsrActualizacion), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A598SolicitudesUsrActualizacion), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesUsrActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesUsrActualizacion_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "UserID", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesFechaAlta_Internalname, context.GetMessage( "Fecha de Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaAlta_Internalname, context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"), context.localUtil.Format( A182SolicitudesFechaAlta, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,187);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaAlta_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_bitmap( context, edtSolicitudesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporte.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesFechaActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesFechaActualizacion_Internalname, context.GetMessage( "Actualizado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaActualizacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaActualizacion_Internalname, context.localUtil.TToC( A204SolicitudesFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A204SolicitudesFechaActualizacion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,192);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaActualizacion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_bitmap( context, edtSolicitudesFechaActualizacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaActualizacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporte.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesFechaInstalacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesFechaInstalacion_Internalname, context.GetMessage( "Programar la instalación para la fecha", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaInstalacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaInstalacion_Internalname, context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"), context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,197);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaInstalacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaInstalacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_bitmap( context, edtSolicitudesFechaInstalacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaInstalacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporte.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesHoraInstalacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesHoraInstalacion_Internalname, context.GetMessage( "Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesHoraInstalacion_Internalname, StringUtil.RTrim( A183SolicitudesHoraInstalacion), StringUtil.RTrim( context.localUtil.Format( A183SolicitudesHoraInstalacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesHoraInstalacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesHoraInstalacion_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSolicitudesComentario_Internalname, A205SolicitudesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,207);\"", 0, 1, edtSolicitudesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetodoPagosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,212);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_128_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_128_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_128_Internalname, sImgUrl, imgprompt_128_Link, "", "", context.GetTheme( ), imgprompt_128_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetodoPagosNombre_Internalname, StringUtil.RTrim( A129MetodoPagosNombre), StringUtil.RTrim( context.localUtil.Format( A129MetodoPagosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,217);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesNota_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesNota_Internalname, context.GetMessage( "NOTA:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSolicitudesNota_Internalname, StringUtil.RTrim( A261SolicitudesNota), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,222);\"", 0, 1, edtSolicitudesNota_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesNotificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSolicitudesNotificacion_Internalname, context.GetMessage( "¿Se notifico al cliente?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 227,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesNotificacion, cmbSolicitudesNotificacion_Internalname, StringUtil.RTrim( A262SolicitudesNotificacion), 1, cmbSolicitudesNotificacion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesNotificacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,227);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbSolicitudesNotificacion.CurrentValue = StringUtil.RTrim( A262SolicitudesNotificacion);
         AssignProp("", false, cmbSolicitudesNotificacion_Internalname, "Values", (string)(cmbSolicitudesNotificacion.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorPagoDefault_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorPagoDefault_Internalname, context.GetMessage( "Pago por Default", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 232,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorPagoDefault, cmbProveedorPagoDefault_Internalname, StringUtil.RTrim( A440ProveedorPagoDefault), 1, cmbProveedorPagoDefault_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorPagoDefault.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,232);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", (string)(cmbProveedorPagoDefault.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTComerciosID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTComerciosID_Internalname, context.GetMessage( "Comercio (Convenio)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 237,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTComerciosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A919STComerciosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,237);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTComerciosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTComerciosID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_919_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_919_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_919_Internalname, sImgUrl, imgprompt_919_Link, "", "", context.GetTheme( ), imgprompt_919_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSTComerciosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSTComerciosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 242,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSTComerciosNombre_Internalname, StringUtil.RTrim( A923STComerciosNombre), StringUtil.RTrim( context.localUtil.Format( A923STComerciosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,242);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSTComerciosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSTComerciosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSTComerciosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSTComerciosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 247,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSTComerciosEstado, cmbSTComerciosEstado_Internalname, StringUtil.RTrim( A924STComerciosEstado), 1, cmbSTComerciosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSTComerciosEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,247);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", (string)(cmbSTComerciosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudServicioOrigenPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSolicitudServicioOrigenPago_Internalname, context.GetMessage( "Origen del Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudServicioOrigenPago, cmbSolicitudServicioOrigenPago_Internalname, StringUtil.RTrim( A438SolicitudServicioOrigenPago), 1, cmbSolicitudServicioOrigenPago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudServicioOrigenPago.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,252);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
         AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Values", (string)(cmbSolicitudServicioOrigenPago.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesPagado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSolicitudesPagado_Internalname, context.GetMessage( "Pagado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesPagado, cmbSolicitudesPagado_Internalname, StringUtil.RTrim( A441SolicitudesPagado), 1, cmbSolicitudesPagado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesPagado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,257);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
         AssignProp("", false, cmbSolicitudesPagado_Internalname, "Values", (string)(cmbSolicitudesPagado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProv_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioComProv_Internalname, context.GetMessage( "Comisión Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 262,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProv_Internalname, StringUtil.LTrim( StringUtil.NToC( A527SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProv_Enabled!=0) ? context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,262);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProv_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProv_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProvP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioComProvP_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 267,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProvP_Internalname, StringUtil.LTrim( StringUtil.NToC( A528SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProvP_Enabled!=0) ? context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99") : context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,267);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProvP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProvP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComALM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioComALM_Internalname, context.GetMessage( "Almango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 272,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALM_Internalname, StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALM_Enabled!=0) ? context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,272);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALM_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALM_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComALMP_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 277,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALMP_Internalname, StringUtil.LTrim( StringUtil.NToC( A532SolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALMP_Enabled!=0) ? context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99") : context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,277);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALMP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALMP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComPro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioComPro_Internalname, context.GetMessage( "Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 282,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComPro_Internalname, StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComPro_Enabled!=0) ? context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,282);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComPro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComPro_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudServicioComProP_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 287,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProP_Internalname, StringUtil.LTrim( StringUtil.NToC( A531SolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProP_Enabled!=0) ? context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99") : context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,287);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSolicitudesCalComi_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSolicitudesCalComi_Internalname, context.GetMessage( "Calcular Comisión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 292,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSolicitudesCalComi_Internalname, StringUtil.BoolToStr( A672SolicitudesCalComi), "", context.GetMessage( "Calcular Comisión", ""), 1, chkSolicitudesCalComi.Enabled, "true", context.GetMessage( "Calcular Comisión", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(292, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,292);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesSubTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSolicitudesSubTipo_Internalname, context.GetMessage( "Sub Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 297,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesSubTipo, cmbSolicitudesSubTipo_Internalname, StringUtil.RTrim( A600SolicitudesSubTipo), 1, cmbSolicitudesSubTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesSubTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,297);\"", "", true, 0, "HLP_SolicitudesReporte.htm");
         cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
         AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Values", (string)(cmbSolicitudesSubTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCostoXZona_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCostoXZona_Internalname, context.GetMessage( "por Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCostoXZona_Internalname, StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCostoXZona_Enabled!=0) ? context.localUtil.Format( A864SolicitudesCostoXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A864SolicitudesCostoXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,302);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCostoXZona_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCostoXZona_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCostoXZComAlm_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCostoXZComAlm_Internalname, context.GetMessage( "Almango XZona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 307,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCostoXZComAlm_Internalname, StringUtil.LTrim( StringUtil.NToC( A865SolicitudesCostoXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCostoXZComAlm_Enabled!=0) ? context.localUtil.Format( A865SolicitudesCostoXZComAlm, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A865SolicitudesCostoXZComAlm, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,307);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCostoXZComAlm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCostoXZComAlm_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCostoXZComAlmP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCostoXZComAlmP_Internalname, context.GetMessage( "XZona P", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 312,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCostoXZComAlmP_Internalname, StringUtil.LTrim( StringUtil.NToC( A866SolicitudesCostoXZComAlmP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCostoXZComAlmP_Enabled!=0) ? context.localUtil.Format( A866SolicitudesCostoXZComAlmP, "ZZ9.99") : context.localUtil.Format( A866SolicitudesCostoXZComAlmP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,312);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCostoXZComAlmP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCostoXZComAlmP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCostoXZComProf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCostoXZComProf_Internalname, context.GetMessage( "Profesional XZona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 317,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCostoXZComProf_Internalname, StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCostoXZComProf_Enabled!=0) ? context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,317);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCostoXZComProf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCostoXZComProf_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesCostoXZComProfP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesCostoXZComProfP_Internalname, context.GetMessage( "XZona P", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 322,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesCostoXZComProfP_Internalname, StringUtil.LTrim( StringUtil.NToC( A868SolicitudesCostoXZComProfP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCostoXZComProfP_Enabled!=0) ? context.localUtil.Format( A868SolicitudesCostoXZComProfP, "ZZ9.99") : context.localUtil.Format( A868SolicitudesCostoXZComProfP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,322);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCostoXZComProfP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCostoXZComProfP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMudanzaId_Internalname, context.GetMessage( "Mudanza Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 327,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMudanzaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,327);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMudanzaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMudanzaId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SolicitudesReporte.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_735_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_735_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_735_Internalname, sImgUrl, imgprompt_735_Link, "", "", context.GetTheme( ), imgprompt_735_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaFechaServicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMudanzaFechaServicio_Internalname, context.GetMessage( "Mudanza Fecha Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 332,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMudanzaFechaServicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMudanzaFechaServicio_Internalname, context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"), context.localUtil.Format( A738MudanzaFechaServicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,332);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMudanzaFechaServicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMudanzaFechaServicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_bitmap( context, edtMudanzaFechaServicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMudanzaFechaServicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporte.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaDireccionOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMudanzaDireccionOrigen_Internalname, context.GetMessage( "Mudanza Direccion Origen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 337,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMudanzaDireccionOrigen_Internalname, A740MudanzaDireccionOrigen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,337);\"", 0, 1, edtMudanzaDireccionOrigen_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaDireccionDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMudanzaDireccionDestino_Internalname, context.GetMessage( "Mudanza Direccion Destino", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 342,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMudanzaDireccionDestino_Internalname, A741MudanzaDireccionDestino, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,342);\"", 0, 1, edtMudanzaDireccionDestino_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesReporte.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 347,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 349,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesReporte.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 351,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesReporte.htm");
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
         E112W2 ();
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
               Z533ProveedorNombreAux = cgiGet( "Z533ProveedorNombreAux");
               n533ProveedorNombreAux = (String.IsNullOrEmpty(StringUtil.RTrim( A533ProveedorNombreAux)) ? true : false);
               Z172SolicitudesTelefono = cgiGet( "Z172SolicitudesTelefono");
               Z206SolicitudesMail = cgiGet( "Z206SolicitudesMail");
               n206SolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ? true : false);
               Z173SolicitudesDireccion = cgiGet( "Z173SolicitudesDireccion");
               Z194SolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z194SolicitudesAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z688SolicitudesLiqProf = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z688SolicitudesLiqProf"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
               Z689SolicitudesLiqProv = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z689SolicitudesLiqProv"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n689SolicitudesLiqProv = ((0==A689SolicitudesLiqProv) ? true : false);
               Z212SolicitudesCotizacion = context.localUtil.CToN( cgiGet( "Z212SolicitudesCotizacion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z210SolicitudServicioSolCoti = cgiGet( "Z210SolicitudServicioSolCoti");
               Z897SolicitudesDescuento = context.localUtil.CToN( cgiGet( "Z897SolicitudesDescuento"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n897SolicitudesDescuento = ((Convert.ToDecimal(0)==A897SolicitudesDescuento) ? true : false);
               Z796SolicitudesComisionMetodoPago = context.localUtil.CToN( cgiGet( "Z796SolicitudesComisionMetodoPago"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z201SolicitudesOtros1 = cgiGet( "Z201SolicitudesOtros1");
               Z202SolicitudesOtros2 = cgiGet( "Z202SolicitudesOtros2");
               Z203SolicitudesOtros3 = cgiGet( "Z203SolicitudesOtros3");
               Z597SolicitudesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z597SolicitudesUsrAlta"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n597SolicitudesUsrAlta = ((0==A597SolicitudesUsrAlta) ? true : false);
               Z598SolicitudesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z598SolicitudesUsrActualizacion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n598SolicitudesUsrActualizacion = ((0==A598SolicitudesUsrActualizacion) ? true : false);
               Z182SolicitudesFechaAlta = context.localUtil.CToD( cgiGet( "Z182SolicitudesFechaAlta"), 0);
               n182SolicitudesFechaAlta = ((DateTime.MinValue==A182SolicitudesFechaAlta) ? true : false);
               Z204SolicitudesFechaActualizacion = context.localUtil.CToT( cgiGet( "Z204SolicitudesFechaActualizacion"), 0);
               n204SolicitudesFechaActualizacion = ((DateTime.MinValue==A204SolicitudesFechaActualizacion) ? true : false);
               Z184SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( "Z184SolicitudesFechaInstalacion"), 0);
               Z183SolicitudesHoraInstalacion = cgiGet( "Z183SolicitudesHoraInstalacion");
               Z261SolicitudesNota = cgiGet( "Z261SolicitudesNota");
               Z262SolicitudesNotificacion = cgiGet( "Z262SolicitudesNotificacion");
               Z438SolicitudServicioOrigenPago = cgiGet( "Z438SolicitudServicioOrigenPago");
               n438SolicitudServicioOrigenPago = (String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) ? true : false);
               Z441SolicitudesPagado = cgiGet( "Z441SolicitudesPagado");
               n441SolicitudesPagado = (String.IsNullOrEmpty(StringUtil.RTrim( A441SolicitudesPagado)) ? true : false);
               Z527SolicitudServicioComProv = context.localUtil.CToN( cgiGet( "Z527SolicitudServicioComProv"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n527SolicitudServicioComProv = ((Convert.ToDecimal(0)==A527SolicitudServicioComProv) ? true : false);
               Z528SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( "Z528SolicitudServicioComProvP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n528SolicitudServicioComProvP = ((Convert.ToDecimal(0)==A528SolicitudServicioComProvP) ? true : false);
               Z530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( "Z530SolicitudServicioComALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n530SolicitudServicioComALM = ((Convert.ToDecimal(0)==A530SolicitudServicioComALM) ? true : false);
               Z532SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( "Z532SolicitudServicioComALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n532SolicitudServicioComALMP = ((Convert.ToDecimal(0)==A532SolicitudServicioComALMP) ? true : false);
               Z672SolicitudesCalComi = StringUtil.StrToBool( cgiGet( "Z672SolicitudesCalComi"));
               Z600SolicitudesSubTipo = cgiGet( "Z600SolicitudesSubTipo");
               n600SolicitudesSubTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) ? true : false);
               Z864SolicitudesCostoXZona = context.localUtil.CToN( cgiGet( "Z864SolicitudesCostoXZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z865SolicitudesCostoXZComAlm = context.localUtil.CToN( cgiGet( "Z865SolicitudesCostoXZComAlm"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n865SolicitudesCostoXZComAlm = ((Convert.ToDecimal(0)==A865SolicitudesCostoXZComAlm) ? true : false);
               Z866SolicitudesCostoXZComAlmP = context.localUtil.CToN( cgiGet( "Z866SolicitudesCostoXZComAlmP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n866SolicitudesCostoXZComAlmP = ((Convert.ToDecimal(0)==A866SolicitudesCostoXZComAlmP) ? true : false);
               Z1016SolicitudesDescuentoCupon = context.localUtil.CToN( cgiGet( "Z1016SolicitudesDescuentoCupon"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n112DepartamentoId = ((0==A112DepartamentoId) ? true : false);
               Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n114DepartamentoMunicipioId = ((0==A114DepartamentoMunicipioId) ? true : false);
               Z110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z110ZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n110ZonasID = ((0==A110ZonasID) ? true : false);
               Z128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z735MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n735MudanzaId = ((0==A735MudanzaId) ? true : false);
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z919STComerciosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               Z996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z996CancelacionTipificacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1013CuponId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               Z130EstadosSolTipo = cgiGet( "Z130EstadosSolTipo");
               Z131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z131EstadosSolId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z669STMonedasId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z669STMonedasId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n669STMonedasId = ((0==A669STMonedasId) ? true : false);
               A1016SolicitudesDescuentoCupon = context.localUtil.CToN( cgiGet( "Z1016SolicitudesDescuentoCupon"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z996CancelacionTipificacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1013CuponId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = false;
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n112DepartamentoId = ((0==A112DepartamentoId) ? true : false);
               N114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n114DepartamentoMunicipioId = ((0==A114DepartamentoMunicipioId) ? true : false);
               N110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N110ZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n110ZonasID = ((0==A110ZonasID) ? true : false);
               N669STMonedasId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N669STMonedasId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n669STMonedasId = ((0==A669STMonedasId) ? true : false);
               N130EstadosSolTipo = cgiGet( "N130EstadosSolTipo");
               N131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N131EstadosSolId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N128MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N919STComerciosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               N735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N735MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n735MudanzaId = ((0==A735MudanzaId) ? true : false);
               A1016SolicitudesDescuentoCupon = context.localUtil.CToN( cgiGet( "SOLICITUDESDESCUENTOCUPON"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AV7SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV18Insert_ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV18Insert_ProveedorID), 18, 0));
               AV19Insert_DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19Insert_DepartamentoId", StringUtil.LTrimStr( (decimal)(AV19Insert_DepartamentoId), 18, 0));
               AV20Insert_DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20Insert_DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV20Insert_DepartamentoMunicipioId), 18, 0));
               AV21Insert_ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ZONASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21Insert_ZonasID", StringUtil.LTrimStr( (decimal)(AV21Insert_ZonasID), 18, 0));
               AV22Insert_STMonedasId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_STMONEDASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_STMonedasId", StringUtil.LTrimStr( (decimal)(AV22Insert_STMonedasId), 4, 0));
               AV23Insert_EstadosSolTipo = cgiGet( "vINSERT_ESTADOSSOLTIPO");
               AssignAttri("", false, "AV23Insert_EstadosSolTipo", AV23Insert_EstadosSolTipo);
               AV24Insert_EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESTADOSSOLID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_EstadosSolId", StringUtil.LTrimStr( (decimal)(AV24Insert_EstadosSolId), 5, 0));
               AV25Insert_MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_METODOPAGOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25Insert_MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV25Insert_MetodoPagosID), 18, 0));
               AV26Insert_STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_STCOMERCIOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26Insert_STComerciosID", StringUtil.LTrimStr( (decimal)(AV26Insert_STComerciosID), 18, 0));
               AV27Insert_MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27Insert_MudanzaId", StringUtil.LTrimStr( (decimal)(AV27Insert_MudanzaId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A1013CuponId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CUPONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n1013CuponId = ((0==A1013CuponId) ? true : false);
               A996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CANCELACIONTIPIFICACIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV28Pgmname = cgiGet( "vPGMNAME");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A133ProveedorID = 0;
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               }
               else
               {
                  A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               }
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               A533ProveedorNombreAux = cgiGet( edtProveedorNombreAux_Internalname);
               n533ProveedorNombreAux = false;
               AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
               n533ProveedorNombreAux = (String.IsNullOrEmpty(StringUtil.RTrim( A533ProveedorNombreAux)) ? true : false);
               A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
               AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
               A206SolicitudesMail = cgiGet( edtSolicitudesMail_Internalname);
               n206SolicitudesMail = false;
               AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
               n206SolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ? true : false);
               A116PaisID = cgiGet( edtPaisID_Internalname);
               AssignAttri("", false, "A116PaisID", A116PaisID);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A112DepartamentoId = 0;
                  n112DepartamentoId = false;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               }
               else
               {
                  A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n112DepartamentoId = false;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               }
               n112DepartamentoId = ((0==A112DepartamentoId) ? true : false);
               A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
               AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOMUNICIPIOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoMunicipioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A114DepartamentoMunicipioId = 0;
                  n114DepartamentoMunicipioId = false;
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               }
               else
               {
                  A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n114DepartamentoMunicipioId = false;
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               }
               n114DepartamentoMunicipioId = ((0==A114DepartamentoMunicipioId) ? true : false);
               A115DepartamentoMunicipioNombre = cgiGet( edtDepartamentoMunicipioNombre_Internalname);
               AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ZONASID");
                  AnyError = 1;
                  GX_FocusControl = edtZonasID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A110ZonasID = 0;
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               }
               else
               {
                  A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               }
               n110ZonasID = ((0==A110ZonasID) ? true : false);
               A173SolicitudesDireccion = cgiGet( edtSolicitudesDireccion_Internalname);
               AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESAUTOENUMERAR");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesAutoEnumerar_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A194SolicitudesAutoEnumerar = 0;
                  AssignAttri("", false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
               }
               else
               {
                  A194SolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSTMonedasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSTMonedasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STMONEDASID");
                  AnyError = 1;
                  GX_FocusControl = edtSTMonedasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A669STMonedasId = 0;
                  n669STMonedasId = false;
                  AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
               }
               else
               {
                  A669STMonedasId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSTMonedasId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n669STMonedasId = false;
                  AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
               }
               n669STMonedasId = ((0==A669STMonedasId) ? true : false);
               A671STMonedasISO = cgiGet( edtSTMonedasISO_Internalname);
               AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesLiqProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesLiqProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESLIQPROF");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesLiqProf_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A688SolicitudesLiqProf = 0;
                  n688SolicitudesLiqProf = false;
                  AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
               }
               else
               {
                  A688SolicitudesLiqProf = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesLiqProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n688SolicitudesLiqProf = false;
                  AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
               }
               n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesLiqProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesLiqProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESLIQPROV");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesLiqProv_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A689SolicitudesLiqProv = 0;
                  n689SolicitudesLiqProv = false;
                  AssignAttri("", false, "A689SolicitudesLiqProv", StringUtil.LTrimStr( (decimal)(A689SolicitudesLiqProv), 18, 0));
               }
               else
               {
                  A689SolicitudesLiqProv = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesLiqProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n689SolicitudesLiqProv = false;
                  AssignAttri("", false, "A689SolicitudesLiqProv", StringUtil.LTrimStr( (decimal)(A689SolicitudesLiqProv), 18, 0));
               }
               n689SolicitudesLiqProv = ((0==A689SolicitudesLiqProv) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESCOTIZACION");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesCotizacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A212SolicitudesCotizacion = 0;
                  AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
               }
               else
               {
                  A212SolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
               }
               A174SolicitudesTotal = context.localUtil.CToN( cgiGet( edtSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
               A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(cgiGet( chkSolicitudServicioSolCoti_Internalname), "S")==0) ? "S" : "N");
               AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
               A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesDescuento_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesDescuento_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESDESCUENTO");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesDescuento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A897SolicitudesDescuento = 0;
                  n897SolicitudesDescuento = false;
                  AssignAttri("", false, "A897SolicitudesDescuento", StringUtil.LTrimStr( A897SolicitudesDescuento, 18, 2));
               }
               else
               {
                  A897SolicitudesDescuento = context.localUtil.CToN( cgiGet( edtSolicitudesDescuento_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n897SolicitudesDescuento = false;
                  AssignAttri("", false, "A897SolicitudesDescuento", StringUtil.LTrimStr( A897SolicitudesDescuento, 18, 2));
               }
               n897SolicitudesDescuento = ((Convert.ToDecimal(0)==A897SolicitudesDescuento) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesComisionMetodoPago_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesComisionMetodoPago_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESCOMISIONMETODOPAGO");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesComisionMetodoPago_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A796SolicitudesComisionMetodoPago = 0;
                  AssignAttri("", false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
               }
               else
               {
                  A796SolicitudesComisionMetodoPago = context.localUtil.CToN( cgiGet( edtSolicitudesComisionMetodoPago_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
               }
               A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
               AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOSSOLID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadosSolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A131EstadosSolId = 0;
                  AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
               }
               else
               {
                  A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
               }
               A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
               AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
               A201SolicitudesOtros1 = ((StringUtil.StrCmp(cgiGet( chkSolicitudesOtros1_Internalname), "S")==0) ? "S" : "N");
               AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
               A202SolicitudesOtros2 = cgiGet( edtSolicitudesOtros2_Internalname);
               AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
               A203SolicitudesOtros3 = cgiGet( edtSolicitudesOtros3_Internalname);
               AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESUSRALTA");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesUsrAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A597SolicitudesUsrAlta = 0;
                  n597SolicitudesUsrAlta = false;
                  AssignAttri("", false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
               }
               else
               {
                  A597SolicitudesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n597SolicitudesUsrAlta = false;
                  AssignAttri("", false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
               }
               n597SolicitudesUsrAlta = ((0==A597SolicitudesUsrAlta) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESUSRACTUALIZACION");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesUsrActualizacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A598SolicitudesUsrActualizacion = 0;
                  n598SolicitudesUsrActualizacion = false;
                  AssignAttri("", false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
               }
               else
               {
                  A598SolicitudesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n598SolicitudesUsrActualizacion = false;
                  AssignAttri("", false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
               }
               n598SolicitudesUsrActualizacion = ((0==A598SolicitudesUsrActualizacion) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtSolicitudesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "FechaAlta", "")}), 1, "SOLICITUDESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A182SolicitudesFechaAlta = DateTime.MinValue;
                  n182SolicitudesFechaAlta = false;
                  AssignAttri("", false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
               }
               else
               {
                  A182SolicitudesFechaAlta = context.localUtil.CToD( cgiGet( edtSolicitudesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  n182SolicitudesFechaAlta = false;
                  AssignAttri("", false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
               }
               n182SolicitudesFechaAlta = ((DateTime.MinValue==A182SolicitudesFechaAlta) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtSolicitudesFechaActualizacion_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Actualizado", "")}), 1, "SOLICITUDESFECHAACTUALIZACION");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesFechaActualizacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
                  n204SolicitudesFechaActualizacion = false;
                  AssignAttri("", false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A204SolicitudesFechaActualizacion = context.localUtil.CToT( cgiGet( edtSolicitudesFechaActualizacion_Internalname));
                  n204SolicitudesFechaActualizacion = false;
                  AssignAttri("", false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               n204SolicitudesFechaActualizacion = ((DateTime.MinValue==A204SolicitudesFechaActualizacion) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtSolicitudesFechaInstalacion_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha de instalación", "")}), 1, "SOLICITUDESFECHAINSTALACION");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesFechaInstalacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A184SolicitudesFechaInstalacion = DateTime.MinValue;
                  AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
               }
               else
               {
                  A184SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( edtSolicitudesFechaInstalacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
               }
               A183SolicitudesHoraInstalacion = cgiGet( edtSolicitudesHoraInstalacion_Internalname);
               AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
               A205SolicitudesComentario = cgiGet( edtSolicitudesComentario_Internalname);
               AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
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
               A261SolicitudesNota = cgiGet( edtSolicitudesNota_Internalname);
               AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
               cmbSolicitudesNotificacion.CurrentValue = cgiGet( cmbSolicitudesNotificacion_Internalname);
               A262SolicitudesNotificacion = cgiGet( cmbSolicitudesNotificacion_Internalname);
               AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
               cmbProveedorPagoDefault.CurrentValue = cgiGet( cmbProveedorPagoDefault_Internalname);
               A440ProveedorPagoDefault = cgiGet( cmbProveedorPagoDefault_Internalname);
               AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STCOMERCIOSID");
                  AnyError = 1;
                  GX_FocusControl = edtSTComerciosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A919STComerciosID = 0;
                  n919STComerciosID = false;
                  AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
               }
               else
               {
                  A919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n919STComerciosID = false;
                  AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
               }
               n919STComerciosID = ((0==A919STComerciosID) ? true : false);
               A923STComerciosNombre = cgiGet( edtSTComerciosNombre_Internalname);
               AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
               cmbSTComerciosEstado.CurrentValue = cgiGet( cmbSTComerciosEstado_Internalname);
               A924STComerciosEstado = cgiGet( cmbSTComerciosEstado_Internalname);
               AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
               cmbSolicitudServicioOrigenPago.CurrentValue = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
               A438SolicitudServicioOrigenPago = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
               n438SolicitudServicioOrigenPago = false;
               AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
               n438SolicitudServicioOrigenPago = (String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) ? true : false);
               cmbSolicitudesPagado.CurrentValue = cgiGet( cmbSolicitudesPagado_Internalname);
               A441SolicitudesPagado = cgiGet( cmbSolicitudesPagado_Internalname);
               n441SolicitudesPagado = false;
               AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
               n441SolicitudesPagado = (String.IsNullOrEmpty(StringUtil.RTrim( A441SolicitudesPagado)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDSERVICIOCOMPROV");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudServicioComProv_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A527SolicitudServicioComProv = 0;
                  n527SolicitudServicioComProv = false;
                  AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
               }
               else
               {
                  A527SolicitudServicioComProv = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n527SolicitudServicioComProv = false;
                  AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
               }
               n527SolicitudServicioComProv = ((Convert.ToDecimal(0)==A527SolicitudServicioComProv) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDSERVICIOCOMPROVP");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudServicioComProvP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A528SolicitudServicioComProvP = 0;
                  n528SolicitudServicioComProvP = false;
                  AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
               }
               else
               {
                  A528SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n528SolicitudServicioComProvP = false;
                  AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
               }
               n528SolicitudServicioComProvP = ((Convert.ToDecimal(0)==A528SolicitudServicioComProvP) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDSERVICIOCOMALM");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudServicioComALM_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A530SolicitudServicioComALM = 0;
                  n530SolicitudServicioComALM = false;
                  AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
               }
               else
               {
                  A530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n530SolicitudServicioComALM = false;
                  AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
               }
               n530SolicitudServicioComALM = ((Convert.ToDecimal(0)==A530SolicitudServicioComALM) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDSERVICIOCOMALMP");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudServicioComALMP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A532SolicitudServicioComALMP = 0;
                  n532SolicitudServicioComALMP = false;
                  AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
               }
               else
               {
                  A532SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n532SolicitudServicioComALMP = false;
                  AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
               }
               n532SolicitudServicioComALMP = ((Convert.ToDecimal(0)==A532SolicitudServicioComALMP) ? true : false);
               A529SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtSolicitudServicioComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               A531SolicitudServicioComProP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               A672SolicitudesCalComi = StringUtil.StrToBool( cgiGet( chkSolicitudesCalComi_Internalname));
               AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
               cmbSolicitudesSubTipo.CurrentValue = cgiGet( cmbSolicitudesSubTipo_Internalname);
               A600SolicitudesSubTipo = cgiGet( cmbSolicitudesSubTipo_Internalname);
               n600SolicitudesSubTipo = false;
               AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
               n600SolicitudesSubTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESCOSTOXZONA");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesCostoXZona_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A864SolicitudesCostoXZona = 0;
                  AssignAttri("", false, "A864SolicitudesCostoXZona", StringUtil.LTrimStr( A864SolicitudesCostoXZona, 18, 2));
               }
               else
               {
                  A864SolicitudesCostoXZona = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A864SolicitudesCostoXZona", StringUtil.LTrimStr( A864SolicitudesCostoXZona, 18, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESCOSTOXZCOMALM");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesCostoXZComAlm_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A865SolicitudesCostoXZComAlm = 0;
                  n865SolicitudesCostoXZComAlm = false;
                  AssignAttri("", false, "A865SolicitudesCostoXZComAlm", StringUtil.LTrimStr( A865SolicitudesCostoXZComAlm, 18, 2));
               }
               else
               {
                  A865SolicitudesCostoXZComAlm = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n865SolicitudesCostoXZComAlm = false;
                  AssignAttri("", false, "A865SolicitudesCostoXZComAlm", StringUtil.LTrimStr( A865SolicitudesCostoXZComAlm, 18, 2));
               }
               n865SolicitudesCostoXZComAlm = ((Convert.ToDecimal(0)==A865SolicitudesCostoXZComAlm) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlmP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlmP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESCOSTOXZCOMALMP");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesCostoXZComAlmP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A866SolicitudesCostoXZComAlmP = 0;
                  n866SolicitudesCostoXZComAlmP = false;
                  AssignAttri("", false, "A866SolicitudesCostoXZComAlmP", StringUtil.LTrimStr( A866SolicitudesCostoXZComAlmP, 6, 2));
               }
               else
               {
                  A866SolicitudesCostoXZComAlmP = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlmP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  n866SolicitudesCostoXZComAlmP = false;
                  AssignAttri("", false, "A866SolicitudesCostoXZComAlmP", StringUtil.LTrimStr( A866SolicitudesCostoXZComAlmP, 6, 2));
               }
               n866SolicitudesCostoXZComAlmP = ((Convert.ToDecimal(0)==A866SolicitudesCostoXZComAlmP) ? true : false);
               A867SolicitudesCostoXZComProf = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
               A868SolicitudesCostoXZComProfP = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComProfP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
               if ( ( ( context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZAID");
                  AnyError = 1;
                  GX_FocusControl = edtMudanzaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A735MudanzaId = 0;
                  n735MudanzaId = false;
                  AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
               }
               else
               {
                  A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n735MudanzaId = false;
                  AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
               }
               n735MudanzaId = ((0==A735MudanzaId) ? true : false);
               A738MudanzaFechaServicio = context.localUtil.CToD( cgiGet( edtMudanzaFechaServicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
               A740MudanzaDireccionOrigen = cgiGet( edtMudanzaDireccionOrigen_Internalname);
               AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
               A741MudanzaDireccionDestino = cgiGet( edtMudanzaDireccionDestino_Internalname);
               AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesReporte");
               A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               forbiddenHiddens.Add("SolicitudesID", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV18Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DepartamentoId", context.localUtil.Format( (decimal)(AV19Insert_DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DepartamentoMunicipioId", context.localUtil.Format( (decimal)(AV20Insert_DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ZonasID", context.localUtil.Format( (decimal)(AV21Insert_ZonasID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_STMonedasId", context.localUtil.Format( (decimal)(AV22Insert_STMonedasId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( AV23Insert_EstadosSolTipo, "")));
               forbiddenHiddens.Add("Insert_EstadosSolId", context.localUtil.Format( (decimal)(AV24Insert_EstadosSolId), "ZZZZ9"));
               forbiddenHiddens.Add("Insert_MetodoPagosID", context.localUtil.Format( (decimal)(AV25Insert_MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_STComerciosID", context.localUtil.Format( (decimal)(AV26Insert_STComerciosID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_MudanzaId", context.localUtil.Format( (decimal)(AV27Insert_MudanzaId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("CancelacionTipificacionId", context.localUtil.Format( (decimal)(A996CancelacionTipificacionId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("SolicitudesDescuentoCupon", context.localUtil.Format( A1016SolicitudesDescuentoCupon, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A127SolicitudesID != Z127SolicitudesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("solicitudesreporte:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_2W0( ) ;
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
                           E112W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122W2 ();
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
            E122W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2W30( ) ;
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
            DisableAttributes2W30( ) ;
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

      protected void CONFIRM_2W0( )
      {
         BeforeValidate2W30( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2W30( ) ;
            }
            else
            {
               CheckExtendedTable2W30( ) ;
               CloseExtendedTableCursors2W30( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2W0( )
      {
      }

      protected void E112W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10IsAuthorized = true;
         AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesReporte_Insert", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesReporte_Update", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesReporte_Delete", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( ! AV10IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV28Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            while ( AV29GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ProveedorID") == 0 )
               {
                  AV18Insert_ProveedorID = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18Insert_ProveedorID", StringUtil.LTrimStr( (decimal)(AV18Insert_ProveedorID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "DepartamentoId") == 0 )
               {
                  AV19Insert_DepartamentoId = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV19Insert_DepartamentoId", StringUtil.LTrimStr( (decimal)(AV19Insert_DepartamentoId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "DepartamentoMunicipioId") == 0 )
               {
                  AV20Insert_DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV20Insert_DepartamentoMunicipioId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "ZonasID") == 0 )
               {
                  AV21Insert_ZonasID = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV21Insert_ZonasID", StringUtil.LTrimStr( (decimal)(AV21Insert_ZonasID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "STMonedasId") == 0 )
               {
                  AV22Insert_STMonedasId = (short)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_STMonedasId", StringUtil.LTrimStr( (decimal)(AV22Insert_STMonedasId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "EstadosSolTipo") == 0 )
               {
                  AV23Insert_EstadosSolTipo = AV17TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV23Insert_EstadosSolTipo", AV23Insert_EstadosSolTipo);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "EstadosSolId") == 0 )
               {
                  AV24Insert_EstadosSolId = (int)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_EstadosSolId", StringUtil.LTrimStr( (decimal)(AV24Insert_EstadosSolId), 5, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MetodoPagosID") == 0 )
               {
                  AV25Insert_MetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25Insert_MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV25Insert_MetodoPagosID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "STComerciosID") == 0 )
               {
                  AV26Insert_STComerciosID = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV26Insert_STComerciosID", StringUtil.LTrimStr( (decimal)(AV26Insert_STComerciosID), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "MudanzaId") == 0 )
               {
                  AV27Insert_MudanzaId = (long)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV27Insert_MudanzaId", StringUtil.LTrimStr( (decimal)(AV27Insert_MudanzaId), 18, 0));
               }
               AV29GXV1 = (int)(AV29GXV1+1);
               AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            }
         }
      }

      protected void E122W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("solicitudesreporteww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2W30( short GX_JID )
      {
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z171SolicitudesNombre = T002W3_A171SolicitudesNombre[0];
               Z533ProveedorNombreAux = T002W3_A533ProveedorNombreAux[0];
               Z172SolicitudesTelefono = T002W3_A172SolicitudesTelefono[0];
               Z206SolicitudesMail = T002W3_A206SolicitudesMail[0];
               Z173SolicitudesDireccion = T002W3_A173SolicitudesDireccion[0];
               Z194SolicitudesAutoEnumerar = T002W3_A194SolicitudesAutoEnumerar[0];
               Z688SolicitudesLiqProf = T002W3_A688SolicitudesLiqProf[0];
               Z689SolicitudesLiqProv = T002W3_A689SolicitudesLiqProv[0];
               Z212SolicitudesCotizacion = T002W3_A212SolicitudesCotizacion[0];
               Z210SolicitudServicioSolCoti = T002W3_A210SolicitudServicioSolCoti[0];
               Z897SolicitudesDescuento = T002W3_A897SolicitudesDescuento[0];
               Z796SolicitudesComisionMetodoPago = T002W3_A796SolicitudesComisionMetodoPago[0];
               Z201SolicitudesOtros1 = T002W3_A201SolicitudesOtros1[0];
               Z202SolicitudesOtros2 = T002W3_A202SolicitudesOtros2[0];
               Z203SolicitudesOtros3 = T002W3_A203SolicitudesOtros3[0];
               Z597SolicitudesUsrAlta = T002W3_A597SolicitudesUsrAlta[0];
               Z598SolicitudesUsrActualizacion = T002W3_A598SolicitudesUsrActualizacion[0];
               Z182SolicitudesFechaAlta = T002W3_A182SolicitudesFechaAlta[0];
               Z204SolicitudesFechaActualizacion = T002W3_A204SolicitudesFechaActualizacion[0];
               Z184SolicitudesFechaInstalacion = T002W3_A184SolicitudesFechaInstalacion[0];
               Z183SolicitudesHoraInstalacion = T002W3_A183SolicitudesHoraInstalacion[0];
               Z261SolicitudesNota = T002W3_A261SolicitudesNota[0];
               Z262SolicitudesNotificacion = T002W3_A262SolicitudesNotificacion[0];
               Z438SolicitudServicioOrigenPago = T002W3_A438SolicitudServicioOrigenPago[0];
               Z441SolicitudesPagado = T002W3_A441SolicitudesPagado[0];
               Z527SolicitudServicioComProv = T002W3_A527SolicitudServicioComProv[0];
               Z528SolicitudServicioComProvP = T002W3_A528SolicitudServicioComProvP[0];
               Z530SolicitudServicioComALM = T002W3_A530SolicitudServicioComALM[0];
               Z532SolicitudServicioComALMP = T002W3_A532SolicitudServicioComALMP[0];
               Z672SolicitudesCalComi = T002W3_A672SolicitudesCalComi[0];
               Z600SolicitudesSubTipo = T002W3_A600SolicitudesSubTipo[0];
               Z864SolicitudesCostoXZona = T002W3_A864SolicitudesCostoXZona[0];
               Z865SolicitudesCostoXZComAlm = T002W3_A865SolicitudesCostoXZComAlm[0];
               Z866SolicitudesCostoXZComAlmP = T002W3_A866SolicitudesCostoXZComAlmP[0];
               Z1016SolicitudesDescuentoCupon = T002W3_A1016SolicitudesDescuentoCupon[0];
               Z112DepartamentoId = T002W3_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T002W3_A114DepartamentoMunicipioId[0];
               Z110ZonasID = T002W3_A110ZonasID[0];
               Z128MetodoPagosID = T002W3_A128MetodoPagosID[0];
               Z735MudanzaId = T002W3_A735MudanzaId[0];
               Z133ProveedorID = T002W3_A133ProveedorID[0];
               Z919STComerciosID = T002W3_A919STComerciosID[0];
               Z996CancelacionTipificacionId = T002W3_A996CancelacionTipificacionId[0];
               Z1013CuponId = T002W3_A1013CuponId[0];
               Z130EstadosSolTipo = T002W3_A130EstadosSolTipo[0];
               Z131EstadosSolId = T002W3_A131EstadosSolId[0];
               Z669STMonedasId = T002W3_A669STMonedasId[0];
            }
            else
            {
               Z171SolicitudesNombre = A171SolicitudesNombre;
               Z533ProveedorNombreAux = A533ProveedorNombreAux;
               Z172SolicitudesTelefono = A172SolicitudesTelefono;
               Z206SolicitudesMail = A206SolicitudesMail;
               Z173SolicitudesDireccion = A173SolicitudesDireccion;
               Z194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
               Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
               Z689SolicitudesLiqProv = A689SolicitudesLiqProv;
               Z212SolicitudesCotizacion = A212SolicitudesCotizacion;
               Z210SolicitudServicioSolCoti = A210SolicitudServicioSolCoti;
               Z897SolicitudesDescuento = A897SolicitudesDescuento;
               Z796SolicitudesComisionMetodoPago = A796SolicitudesComisionMetodoPago;
               Z201SolicitudesOtros1 = A201SolicitudesOtros1;
               Z202SolicitudesOtros2 = A202SolicitudesOtros2;
               Z203SolicitudesOtros3 = A203SolicitudesOtros3;
               Z597SolicitudesUsrAlta = A597SolicitudesUsrAlta;
               Z598SolicitudesUsrActualizacion = A598SolicitudesUsrActualizacion;
               Z182SolicitudesFechaAlta = A182SolicitudesFechaAlta;
               Z204SolicitudesFechaActualizacion = A204SolicitudesFechaActualizacion;
               Z184SolicitudesFechaInstalacion = A184SolicitudesFechaInstalacion;
               Z183SolicitudesHoraInstalacion = A183SolicitudesHoraInstalacion;
               Z261SolicitudesNota = A261SolicitudesNota;
               Z262SolicitudesNotificacion = A262SolicitudesNotificacion;
               Z438SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
               Z441SolicitudesPagado = A441SolicitudesPagado;
               Z527SolicitudServicioComProv = A527SolicitudServicioComProv;
               Z528SolicitudServicioComProvP = A528SolicitudServicioComProvP;
               Z530SolicitudServicioComALM = A530SolicitudServicioComALM;
               Z532SolicitudServicioComALMP = A532SolicitudServicioComALMP;
               Z672SolicitudesCalComi = A672SolicitudesCalComi;
               Z600SolicitudesSubTipo = A600SolicitudesSubTipo;
               Z864SolicitudesCostoXZona = A864SolicitudesCostoXZona;
               Z865SolicitudesCostoXZComAlm = A865SolicitudesCostoXZComAlm;
               Z866SolicitudesCostoXZComAlmP = A866SolicitudesCostoXZComAlmP;
               Z1016SolicitudesDescuentoCupon = A1016SolicitudesDescuentoCupon;
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
               Z110ZonasID = A110ZonasID;
               Z128MetodoPagosID = A128MetodoPagosID;
               Z735MudanzaId = A735MudanzaId;
               Z133ProveedorID = A133ProveedorID;
               Z919STComerciosID = A919STComerciosID;
               Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
               Z1013CuponId = A1013CuponId;
               Z130EstadosSolTipo = A130EstadosSolTipo;
               Z131EstadosSolId = A131EstadosSolId;
               Z669STMonedasId = A669STMonedasId;
            }
         }
         if ( GX_JID == -49 )
         {
            Z127SolicitudesID = A127SolicitudesID;
            Z171SolicitudesNombre = A171SolicitudesNombre;
            Z533ProveedorNombreAux = A533ProveedorNombreAux;
            Z172SolicitudesTelefono = A172SolicitudesTelefono;
            Z206SolicitudesMail = A206SolicitudesMail;
            Z173SolicitudesDireccion = A173SolicitudesDireccion;
            Z194SolicitudesAutoEnumerar = A194SolicitudesAutoEnumerar;
            Z688SolicitudesLiqProf = A688SolicitudesLiqProf;
            Z689SolicitudesLiqProv = A689SolicitudesLiqProv;
            Z212SolicitudesCotizacion = A212SolicitudesCotizacion;
            Z210SolicitudServicioSolCoti = A210SolicitudServicioSolCoti;
            Z897SolicitudesDescuento = A897SolicitudesDescuento;
            Z796SolicitudesComisionMetodoPago = A796SolicitudesComisionMetodoPago;
            Z201SolicitudesOtros1 = A201SolicitudesOtros1;
            Z202SolicitudesOtros2 = A202SolicitudesOtros2;
            Z203SolicitudesOtros3 = A203SolicitudesOtros3;
            Z597SolicitudesUsrAlta = A597SolicitudesUsrAlta;
            Z598SolicitudesUsrActualizacion = A598SolicitudesUsrActualizacion;
            Z182SolicitudesFechaAlta = A182SolicitudesFechaAlta;
            Z204SolicitudesFechaActualizacion = A204SolicitudesFechaActualizacion;
            Z184SolicitudesFechaInstalacion = A184SolicitudesFechaInstalacion;
            Z183SolicitudesHoraInstalacion = A183SolicitudesHoraInstalacion;
            Z205SolicitudesComentario = A205SolicitudesComentario;
            Z261SolicitudesNota = A261SolicitudesNota;
            Z262SolicitudesNotificacion = A262SolicitudesNotificacion;
            Z438SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
            Z441SolicitudesPagado = A441SolicitudesPagado;
            Z527SolicitudServicioComProv = A527SolicitudServicioComProv;
            Z528SolicitudServicioComProvP = A528SolicitudServicioComProvP;
            Z530SolicitudServicioComALM = A530SolicitudServicioComALM;
            Z532SolicitudServicioComALMP = A532SolicitudServicioComALMP;
            Z672SolicitudesCalComi = A672SolicitudesCalComi;
            Z600SolicitudesSubTipo = A600SolicitudesSubTipo;
            Z864SolicitudesCostoXZona = A864SolicitudesCostoXZona;
            Z865SolicitudesCostoXZComAlm = A865SolicitudesCostoXZComAlm;
            Z866SolicitudesCostoXZComAlmP = A866SolicitudesCostoXZComAlmP;
            Z1016SolicitudesDescuentoCupon = A1016SolicitudesDescuentoCupon;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z128MetodoPagosID = A128MetodoPagosID;
            Z735MudanzaId = A735MudanzaId;
            Z133ProveedorID = A133ProveedorID;
            Z919STComerciosID = A919STComerciosID;
            Z996CancelacionTipificacionId = A996CancelacionTipificacionId;
            Z1013CuponId = A1013CuponId;
            Z130EstadosSolTipo = A130EstadosSolTipo;
            Z131EstadosSolId = A131EstadosSolId;
            Z669STMonedasId = A669STMonedasId;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z116PaisID = A116PaisID;
            Z115DepartamentoMunicipioNombre = A115DepartamentoMunicipioNombre;
            Z671STMonedasISO = A671STMonedasISO;
            Z132EstadosSolNombre = A132EstadosSolNombre;
            Z129MetodoPagosNombre = A129MetodoPagosNombre;
            Z923STComerciosNombre = A923STComerciosNombre;
            Z924STComerciosEstado = A924STComerciosEstado;
            Z738MudanzaFechaServicio = A738MudanzaFechaServicio;
            Z740MudanzaDireccionOrigen = A740MudanzaDireccionOrigen;
            Z741MudanzaDireccionDestino = A741MudanzaDireccionDestino;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_133_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID"+"'), id:'"+"PROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROVEEDORNOMBRE"+"'), id:'"+"PROVEEDORNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_112_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_114_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00m1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID"+"'), id:'"+"DEPARTAMENTOMUNICIPIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_110_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0121_2.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ZONASID"+"'), id:'"+"ZONASID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID"+"'), id:'"+"DEPARTAMENTOMUNICIPIOID"+"'"+",IOType:'in'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_669_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00x0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"STMONEDASID"+"'), id:'"+"STMONEDASID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_130_131_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"estadosgenericosprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESTADOSSOLTIPO"+"'), id:'"+"ESTADOSSOLTIPO"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"ESTADOSSOLID"+"'), id:'"+"ESTADOSSOLID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"ESTADOSSOLNOMBRE"+"'), id:'"+"ESTADOSSOLNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_128_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0150.aspx"+"',["+"{Ctrl:gx.dom.el('"+"METODOPAGOSID"+"'), id:'"+"METODOPAGOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_919_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"STCOMERCIOSID"+"'), id:'"+"STCOMERCIOSID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"STCOMERCIOSNOMBRE"+"'), id:'"+"STCOMERCIOSNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_735_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx03b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MUDANZAID"+"'), id:'"+"MUDANZAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SolicitudesID) )
         {
            A127SolicitudesID = AV7SolicitudesID;
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_ProveedorID) )
         {
            edtProveedorID_Enabled = 0;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         }
         else
         {
            edtProveedorID_Enabled = 1;
            AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_DepartamentoId) )
         {
            edtDepartamentoId_Enabled = 0;
            AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDepartamentoId_Enabled = 1;
            AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_DepartamentoMunicipioId) )
         {
            edtDepartamentoMunicipioId_Enabled = 0;
            AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), true);
         }
         else
         {
            edtDepartamentoMunicipioId_Enabled = 1;
            AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ZonasID) )
         {
            edtZonasID_Enabled = 0;
            AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         }
         else
         {
            edtZonasID_Enabled = 1;
            AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_STMonedasId) )
         {
            edtSTMonedasId_Enabled = 0;
            AssignProp("", false, edtSTMonedasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTMonedasId_Enabled), 5, 0), true);
         }
         else
         {
            edtSTMonedasId_Enabled = 1;
            AssignProp("", false, edtSTMonedasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTMonedasId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23Insert_EstadosSolTipo)) )
         {
            edtEstadosSolTipo_Enabled = 0;
            AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosSolTipo_Enabled = 1;
            AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_EstadosSolId) )
         {
            edtEstadosSolId_Enabled = 0;
            AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosSolId_Enabled = 1;
            AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_MetodoPagosID) )
         {
            edtMetodoPagosID_Enabled = 0;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         else
         {
            edtMetodoPagosID_Enabled = 1;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_STComerciosID) )
         {
            edtSTComerciosID_Enabled = 0;
            AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         }
         else
         {
            edtSTComerciosID_Enabled = 1;
            AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_MudanzaId) )
         {
            edtMudanzaId_Enabled = 0;
            AssignProp("", false, edtMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaId_Enabled), 5, 0), true);
         }
         else
         {
            edtMudanzaId_Enabled = 1;
            AssignProp("", false, edtMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_MudanzaId) )
         {
            A735MudanzaId = AV27Insert_MudanzaId;
            n735MudanzaId = false;
            AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_STComerciosID) )
         {
            A919STComerciosID = AV26Insert_STComerciosID;
            n919STComerciosID = false;
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_MetodoPagosID) )
         {
            A128MetodoPagosID = AV25Insert_MetodoPagosID;
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_EstadosSolId) )
         {
            A131EstadosSolId = AV24Insert_EstadosSolId;
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23Insert_EstadosSolTipo)) )
         {
            A130EstadosSolTipo = AV23Insert_EstadosSolTipo;
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_STMonedasId) )
         {
            A669STMonedasId = AV22Insert_STMonedasId;
            n669STMonedasId = false;
            AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ZonasID) )
         {
            A110ZonasID = AV21Insert_ZonasID;
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_DepartamentoMunicipioId) )
         {
            A114DepartamentoMunicipioId = AV20Insert_DepartamentoMunicipioId;
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_DepartamentoId) )
         {
            A112DepartamentoId = AV19Insert_DepartamentoId;
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_ProveedorID) )
         {
            A133ProveedorID = AV18Insert_ProveedorID;
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
            GetSolicitudesTotal( A127SolicitudesID) ;
            AV28Pgmname = "SolicitudesReporte";
            AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
            /* Using cursor T002W8 */
            pr_default.execute(6, new Object[] {n735MudanzaId, A735MudanzaId});
            A738MudanzaFechaServicio = T002W8_A738MudanzaFechaServicio[0];
            AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
            A740MudanzaDireccionOrigen = T002W8_A740MudanzaDireccionOrigen[0];
            AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
            A741MudanzaDireccionDestino = T002W8_A741MudanzaDireccionDestino[0];
            AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
            pr_default.close(6);
            /* Using cursor T002W10 */
            pr_default.execute(8, new Object[] {n919STComerciosID, A919STComerciosID});
            A923STComerciosNombre = T002W10_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002W10_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            pr_default.close(8);
            /* Using cursor T002W7 */
            pr_default.execute(5, new Object[] {A128MetodoPagosID});
            A129MetodoPagosNombre = T002W7_A129MetodoPagosNombre[0];
            AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
            pr_default.close(5);
            /* Using cursor T002W11 */
            pr_default.execute(9, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = T002W11_A132EstadosSolNombre[0];
            AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
            pr_default.close(9);
            /* Using cursor T002W12 */
            pr_default.execute(10, new Object[] {n669STMonedasId, A669STMonedasId});
            A671STMonedasISO = T002W12_A671STMonedasISO[0];
            AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
            pr_default.close(10);
            /* Using cursor T002W4 */
            pr_default.execute(2, new Object[] {n112DepartamentoId, A112DepartamentoId});
            A113DepartamentoDepartamento = T002W4_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A116PaisID = T002W4_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(2);
            /* Using cursor T002W5 */
            pr_default.execute(3, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
            A115DepartamentoMunicipioNombre = T002W5_A115DepartamentoMunicipioNombre[0];
            AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
            pr_default.close(3);
            /* Using cursor T002W9 */
            pr_default.execute(7, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T002W9_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A440ProveedorPagoDefault = T002W9_A440ProveedorPagoDefault[0];
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            pr_default.close(7);
         }
      }

      protected void Load2W30( )
      {
         /* Using cursor T002W13 */
         pr_default.execute(11, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound30 = 1;
            A171SolicitudesNombre = T002W13_A171SolicitudesNombre[0];
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A282ProveedorNombre = T002W13_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A533ProveedorNombreAux = T002W13_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = T002W13_n533ProveedorNombreAux[0];
            AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
            A172SolicitudesTelefono = T002W13_A172SolicitudesTelefono[0];
            AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
            A206SolicitudesMail = T002W13_A206SolicitudesMail[0];
            n206SolicitudesMail = T002W13_n206SolicitudesMail[0];
            AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
            A113DepartamentoDepartamento = T002W13_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A115DepartamentoMunicipioNombre = T002W13_A115DepartamentoMunicipioNombre[0];
            AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
            A173SolicitudesDireccion = T002W13_A173SolicitudesDireccion[0];
            AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
            A194SolicitudesAutoEnumerar = T002W13_A194SolicitudesAutoEnumerar[0];
            AssignAttri("", false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
            A671STMonedasISO = T002W13_A671STMonedasISO[0];
            AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
            A688SolicitudesLiqProf = T002W13_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = T002W13_n688SolicitudesLiqProf[0];
            AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
            A689SolicitudesLiqProv = T002W13_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = T002W13_n689SolicitudesLiqProv[0];
            AssignAttri("", false, "A689SolicitudesLiqProv", StringUtil.LTrimStr( (decimal)(A689SolicitudesLiqProv), 18, 0));
            A212SolicitudesCotizacion = T002W13_A212SolicitudesCotizacion[0];
            AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
            A210SolicitudServicioSolCoti = T002W13_A210SolicitudServicioSolCoti[0];
            AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
            A897SolicitudesDescuento = T002W13_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = T002W13_n897SolicitudesDescuento[0];
            AssignAttri("", false, "A897SolicitudesDescuento", StringUtil.LTrimStr( A897SolicitudesDescuento, 18, 2));
            A796SolicitudesComisionMetodoPago = T002W13_A796SolicitudesComisionMetodoPago[0];
            AssignAttri("", false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
            A132EstadosSolNombre = T002W13_A132EstadosSolNombre[0];
            AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
            A201SolicitudesOtros1 = T002W13_A201SolicitudesOtros1[0];
            AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
            A202SolicitudesOtros2 = T002W13_A202SolicitudesOtros2[0];
            AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
            A203SolicitudesOtros3 = T002W13_A203SolicitudesOtros3[0];
            AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
            A597SolicitudesUsrAlta = T002W13_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = T002W13_n597SolicitudesUsrAlta[0];
            AssignAttri("", false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            A598SolicitudesUsrActualizacion = T002W13_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = T002W13_n598SolicitudesUsrActualizacion[0];
            AssignAttri("", false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            A182SolicitudesFechaAlta = T002W13_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = T002W13_n182SolicitudesFechaAlta[0];
            AssignAttri("", false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
            A204SolicitudesFechaActualizacion = T002W13_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = T002W13_n204SolicitudesFechaActualizacion[0];
            AssignAttri("", false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A184SolicitudesFechaInstalacion = T002W13_A184SolicitudesFechaInstalacion[0];
            AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
            A183SolicitudesHoraInstalacion = T002W13_A183SolicitudesHoraInstalacion[0];
            AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
            A205SolicitudesComentario = T002W13_A205SolicitudesComentario[0];
            AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
            A129MetodoPagosNombre = T002W13_A129MetodoPagosNombre[0];
            AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
            A261SolicitudesNota = T002W13_A261SolicitudesNota[0];
            AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
            A262SolicitudesNotificacion = T002W13_A262SolicitudesNotificacion[0];
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
            A440ProveedorPagoDefault = T002W13_A440ProveedorPagoDefault[0];
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            A923STComerciosNombre = T002W13_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002W13_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            A438SolicitudServicioOrigenPago = T002W13_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = T002W13_n438SolicitudServicioOrigenPago[0];
            AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
            A441SolicitudesPagado = T002W13_A441SolicitudesPagado[0];
            n441SolicitudesPagado = T002W13_n441SolicitudesPagado[0];
            AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
            A527SolicitudServicioComProv = T002W13_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = T002W13_n527SolicitudServicioComProv[0];
            AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
            A528SolicitudServicioComProvP = T002W13_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = T002W13_n528SolicitudServicioComProvP[0];
            AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
            A530SolicitudServicioComALM = T002W13_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = T002W13_n530SolicitudServicioComALM[0];
            AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
            A532SolicitudServicioComALMP = T002W13_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = T002W13_n532SolicitudServicioComALMP[0];
            AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
            A672SolicitudesCalComi = T002W13_A672SolicitudesCalComi[0];
            AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
            A600SolicitudesSubTipo = T002W13_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = T002W13_n600SolicitudesSubTipo[0];
            AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
            A864SolicitudesCostoXZona = T002W13_A864SolicitudesCostoXZona[0];
            AssignAttri("", false, "A864SolicitudesCostoXZona", StringUtil.LTrimStr( A864SolicitudesCostoXZona, 18, 2));
            A865SolicitudesCostoXZComAlm = T002W13_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = T002W13_n865SolicitudesCostoXZComAlm[0];
            AssignAttri("", false, "A865SolicitudesCostoXZComAlm", StringUtil.LTrimStr( A865SolicitudesCostoXZComAlm, 18, 2));
            A866SolicitudesCostoXZComAlmP = T002W13_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = T002W13_n866SolicitudesCostoXZComAlmP[0];
            AssignAttri("", false, "A866SolicitudesCostoXZComAlmP", StringUtil.LTrimStr( A866SolicitudesCostoXZComAlmP, 6, 2));
            A738MudanzaFechaServicio = T002W13_A738MudanzaFechaServicio[0];
            AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
            A740MudanzaDireccionOrigen = T002W13_A740MudanzaDireccionOrigen[0];
            AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
            A741MudanzaDireccionDestino = T002W13_A741MudanzaDireccionDestino[0];
            AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
            A1016SolicitudesDescuentoCupon = T002W13_A1016SolicitudesDescuentoCupon[0];
            A112DepartamentoId = T002W13_A112DepartamentoId[0];
            n112DepartamentoId = T002W13_n112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T002W13_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = T002W13_n114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A110ZonasID = T002W13_A110ZonasID[0];
            n110ZonasID = T002W13_n110ZonasID[0];
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A128MetodoPagosID = T002W13_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A735MudanzaId = T002W13_A735MudanzaId[0];
            n735MudanzaId = T002W13_n735MudanzaId[0];
            AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
            A133ProveedorID = T002W13_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A919STComerciosID = T002W13_A919STComerciosID[0];
            n919STComerciosID = T002W13_n919STComerciosID[0];
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            A996CancelacionTipificacionId = T002W13_A996CancelacionTipificacionId[0];
            A1013CuponId = T002W13_A1013CuponId[0];
            n1013CuponId = T002W13_n1013CuponId[0];
            A130EstadosSolTipo = T002W13_A130EstadosSolTipo[0];
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = T002W13_A131EstadosSolId[0];
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            A669STMonedasId = T002W13_A669STMonedasId[0];
            n669STMonedasId = T002W13_n669STMonedasId[0];
            AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
            A116PaisID = T002W13_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            ZM2W30( -49) ;
         }
         pr_default.close(11);
         OnLoadActions2W30( ) ;
      }

      protected void OnLoadActions2W30( )
      {
         AV28Pgmname = "SolicitudesReporte";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
         GetSolicitudesTotal( A127SolicitudesID) ;
         if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
         {
            A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
         }
         else
         {
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
            }
            else
            {
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
                  else
                  {
                     A211SolicitudServicioPFinal = 0;
                     AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
               }
            }
         }
         if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
         {
            A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
            AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
         }
         else
         {
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
               AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
               else
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
            }
         }
         if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
         {
            A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
            AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
         }
         else
         {
            if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
               AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                  AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
               else
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
            }
         }
         if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
         }
         else
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
         }
         if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
         {
            A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
         }
         else
         {
            if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
            }
            else
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
            }
         }
      }

      protected void CheckExtendedTable2W30( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV28Pgmname = "SolicitudesReporte";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
         GetSolicitudesTotal( A127SolicitudesID) ;
         if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
         {
            A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
         }
         else
         {
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
            }
            else
            {
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
                  else
                  {
                     A211SolicitudServicioPFinal = 0;
                     AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
               }
            }
         }
         if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
         {
            A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
            AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
         }
         else
         {
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
               AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
               else
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                  AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
            }
         }
         /* Using cursor T002W9 */
         pr_default.execute(7, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T002W9_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A440ProveedorPagoDefault = T002W9_A440ProveedorPagoDefault[0];
         AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         pr_default.close(7);
         if ( ! ( GxRegex.IsMatch(A206SolicitudesMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "ClientMail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDESMAIL");
            AnyError = 1;
            GX_FocusControl = edtSolicitudesMail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002W4 */
         pr_default.execute(2, new Object[] {n112DepartamentoId, A112DepartamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A113DepartamentoDepartamento = T002W4_A113DepartamentoDepartamento[0];
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A116PaisID = T002W4_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         pr_default.close(2);
         /* Using cursor T002W5 */
         pr_default.execute(3, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A115DepartamentoMunicipioNombre = T002W5_A115DepartamentoMunicipioNombre[0];
         AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
         pr_default.close(3);
         /* Using cursor T002W6 */
         pr_default.execute(4, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T002W12 */
         pr_default.execute(10, new Object[] {n669STMonedasId, A669STMonedasId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A669STMonedasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "STMonedas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STMONEDASID");
               AnyError = 1;
               GX_FocusControl = edtSTMonedasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A671STMonedasISO = T002W12_A671STMonedasISO[0];
         AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
         pr_default.close(10);
         /* Using cursor T002W11 */
         pr_default.execute(9, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A132EstadosSolNombre = T002W11_A132EstadosSolNombre[0];
         AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
         pr_default.close(9);
         if ( ! ( (DateTime.MinValue==A182SolicitudesFechaAlta) || ( DateTimeUtil.ResetTime ( A182SolicitudesFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "FechaAlta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtSolicitudesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A204SolicitudesFechaActualizacion) || ( A204SolicitudesFechaActualizacion >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Actualizado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDESFECHAACTUALIZACION");
            AnyError = 1;
            GX_FocusControl = edtSolicitudesFechaActualizacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A184SolicitudesFechaInstalacion) || ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de instalación", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDESFECHAINSTALACION");
            AnyError = 1;
            GX_FocusControl = edtSolicitudesFechaInstalacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002W7 */
         pr_default.execute(5, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A129MetodoPagosNombre = T002W7_A129MetodoPagosNombre[0];
         AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
         pr_default.close(5);
         /* Using cursor T002W10 */
         pr_default.execute(8, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A923STComerciosNombre = T002W10_A923STComerciosNombre[0];
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = T002W10_A924STComerciosEstado[0];
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         pr_default.close(8);
         if ( ! ( ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "F") == 0 ) || ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "T") == 0 ) || ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "O") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Origen del Pago", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDSERVICIOORIGENPAGO");
            AnyError = 1;
            GX_FocusControl = cmbSolicitudServicioOrigenPago_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
         {
            A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
            AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
         }
         else
         {
            if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
               AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                  AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
               else
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
            }
         }
         if ( ! ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "T") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "E") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "G") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "M") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "A") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "O") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "Z") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "S") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "P") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Sub Tipo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "SOLICITUDESSUBTIPO");
            AnyError = 1;
            GX_FocusControl = cmbSolicitudesSubTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
         }
         else
         {
            A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
         }
         if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
         {
            A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
         }
         else
         {
            if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
            }
            else
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
            }
         }
         /* Using cursor T002W8 */
         pr_default.execute(6, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A735MudanzaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mudanza", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MUDANZAID");
               AnyError = 1;
               GX_FocusControl = edtMudanzaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A738MudanzaFechaServicio = T002W8_A738MudanzaFechaServicio[0];
         AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
         A740MudanzaDireccionOrigen = T002W8_A740MudanzaDireccionOrigen[0];
         AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
         A741MudanzaDireccionDestino = T002W8_A741MudanzaDireccionDestino[0];
         AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors2W30( )
      {
         pr_default.close(7);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(10);
         pr_default.close(9);
         pr_default.close(5);
         pr_default.close(8);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_55( long A133ProveedorID )
      {
         /* Using cursor T002W14 */
         pr_default.execute(12, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A282ProveedorNombre = T002W14_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A440ProveedorPagoDefault = T002W14_A440ProveedorPagoDefault[0];
         AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A440ProveedorPagoDefault))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_50( long A112DepartamentoId )
      {
         /* Using cursor T002W15 */
         pr_default.execute(13, new Object[] {n112DepartamentoId, A112DepartamentoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A113DepartamentoDepartamento = T002W15_A113DepartamentoDepartamento[0];
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A116PaisID = T002W15_A116PaisID[0];
         AssignAttri("", false, "A116PaisID", A116PaisID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A113DepartamentoDepartamento))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A116PaisID))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_51( long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T002W16 */
         pr_default.execute(14, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A115DepartamentoMunicipioNombre = T002W16_A115DepartamentoMunicipioNombre[0];
         AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A115DepartamentoMunicipioNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_52( long A110ZonasID ,
                                long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T002W17 */
         pr_default.execute(15, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_58( short A669STMonedasId )
      {
         /* Using cursor T002W18 */
         pr_default.execute(16, new Object[] {n669STMonedasId, A669STMonedasId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A669STMonedasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "STMonedas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STMONEDASID");
               AnyError = 1;
               GX_FocusControl = edtSTMonedasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A671STMonedasISO = T002W18_A671STMonedasISO[0];
         AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A671STMonedasISO))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_57( string A130EstadosSolTipo ,
                                int A131EstadosSolId )
      {
         /* Using cursor T002W19 */
         pr_default.execute(17, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A132EstadosSolNombre = T002W19_A132EstadosSolNombre[0];
         AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A132EstadosSolNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_53( long A128MetodoPagosID )
      {
         /* Using cursor T002W20 */
         pr_default.execute(18, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A129MetodoPagosNombre = T002W20_A129MetodoPagosNombre[0];
         AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A129MetodoPagosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_56( long A919STComerciosID )
      {
         /* Using cursor T002W21 */
         pr_default.execute(19, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A923STComerciosNombre = T002W21_A923STComerciosNombre[0];
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = T002W21_A924STComerciosEstado[0];
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A923STComerciosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A924STComerciosEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_54( long A735MudanzaId )
      {
         /* Using cursor T002W22 */
         pr_default.execute(20, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A735MudanzaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mudanza", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MUDANZAID");
               AnyError = 1;
               GX_FocusControl = edtMudanzaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A738MudanzaFechaServicio = T002W22_A738MudanzaFechaServicio[0];
         AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
         A740MudanzaDireccionOrigen = T002W22_A740MudanzaDireccionOrigen[0];
         AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
         A741MudanzaDireccionDestino = T002W22_A741MudanzaDireccionDestino[0];
         AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( A740MudanzaDireccionOrigen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A741MudanzaDireccionDestino)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey2W30( )
      {
         /* Using cursor T002W23 */
         pr_default.execute(21, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002W3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2W30( 49) ;
            RcdFound30 = 1;
            A127SolicitudesID = T002W3_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
            A171SolicitudesNombre = T002W3_A171SolicitudesNombre[0];
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A533ProveedorNombreAux = T002W3_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = T002W3_n533ProveedorNombreAux[0];
            AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
            A172SolicitudesTelefono = T002W3_A172SolicitudesTelefono[0];
            AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
            A206SolicitudesMail = T002W3_A206SolicitudesMail[0];
            n206SolicitudesMail = T002W3_n206SolicitudesMail[0];
            AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
            A173SolicitudesDireccion = T002W3_A173SolicitudesDireccion[0];
            AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
            A194SolicitudesAutoEnumerar = T002W3_A194SolicitudesAutoEnumerar[0];
            AssignAttri("", false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
            A688SolicitudesLiqProf = T002W3_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = T002W3_n688SolicitudesLiqProf[0];
            AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
            A689SolicitudesLiqProv = T002W3_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = T002W3_n689SolicitudesLiqProv[0];
            AssignAttri("", false, "A689SolicitudesLiqProv", StringUtil.LTrimStr( (decimal)(A689SolicitudesLiqProv), 18, 0));
            A212SolicitudesCotizacion = T002W3_A212SolicitudesCotizacion[0];
            AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
            A210SolicitudServicioSolCoti = T002W3_A210SolicitudServicioSolCoti[0];
            AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
            A897SolicitudesDescuento = T002W3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = T002W3_n897SolicitudesDescuento[0];
            AssignAttri("", false, "A897SolicitudesDescuento", StringUtil.LTrimStr( A897SolicitudesDescuento, 18, 2));
            A796SolicitudesComisionMetodoPago = T002W3_A796SolicitudesComisionMetodoPago[0];
            AssignAttri("", false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
            A201SolicitudesOtros1 = T002W3_A201SolicitudesOtros1[0];
            AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
            A202SolicitudesOtros2 = T002W3_A202SolicitudesOtros2[0];
            AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
            A203SolicitudesOtros3 = T002W3_A203SolicitudesOtros3[0];
            AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
            A597SolicitudesUsrAlta = T002W3_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = T002W3_n597SolicitudesUsrAlta[0];
            AssignAttri("", false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            A598SolicitudesUsrActualizacion = T002W3_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = T002W3_n598SolicitudesUsrActualizacion[0];
            AssignAttri("", false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            A182SolicitudesFechaAlta = T002W3_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = T002W3_n182SolicitudesFechaAlta[0];
            AssignAttri("", false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
            A204SolicitudesFechaActualizacion = T002W3_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = T002W3_n204SolicitudesFechaActualizacion[0];
            AssignAttri("", false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A184SolicitudesFechaInstalacion = T002W3_A184SolicitudesFechaInstalacion[0];
            AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
            A183SolicitudesHoraInstalacion = T002W3_A183SolicitudesHoraInstalacion[0];
            AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
            A205SolicitudesComentario = T002W3_A205SolicitudesComentario[0];
            AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
            A261SolicitudesNota = T002W3_A261SolicitudesNota[0];
            AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
            A262SolicitudesNotificacion = T002W3_A262SolicitudesNotificacion[0];
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
            A438SolicitudServicioOrigenPago = T002W3_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = T002W3_n438SolicitudServicioOrigenPago[0];
            AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
            A441SolicitudesPagado = T002W3_A441SolicitudesPagado[0];
            n441SolicitudesPagado = T002W3_n441SolicitudesPagado[0];
            AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
            A527SolicitudServicioComProv = T002W3_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = T002W3_n527SolicitudServicioComProv[0];
            AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
            A528SolicitudServicioComProvP = T002W3_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = T002W3_n528SolicitudServicioComProvP[0];
            AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
            A530SolicitudServicioComALM = T002W3_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = T002W3_n530SolicitudServicioComALM[0];
            AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
            A532SolicitudServicioComALMP = T002W3_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = T002W3_n532SolicitudServicioComALMP[0];
            AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
            A672SolicitudesCalComi = T002W3_A672SolicitudesCalComi[0];
            AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
            A600SolicitudesSubTipo = T002W3_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = T002W3_n600SolicitudesSubTipo[0];
            AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
            A864SolicitudesCostoXZona = T002W3_A864SolicitudesCostoXZona[0];
            AssignAttri("", false, "A864SolicitudesCostoXZona", StringUtil.LTrimStr( A864SolicitudesCostoXZona, 18, 2));
            A865SolicitudesCostoXZComAlm = T002W3_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = T002W3_n865SolicitudesCostoXZComAlm[0];
            AssignAttri("", false, "A865SolicitudesCostoXZComAlm", StringUtil.LTrimStr( A865SolicitudesCostoXZComAlm, 18, 2));
            A866SolicitudesCostoXZComAlmP = T002W3_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = T002W3_n866SolicitudesCostoXZComAlmP[0];
            AssignAttri("", false, "A866SolicitudesCostoXZComAlmP", StringUtil.LTrimStr( A866SolicitudesCostoXZComAlmP, 6, 2));
            A1016SolicitudesDescuentoCupon = T002W3_A1016SolicitudesDescuentoCupon[0];
            A112DepartamentoId = T002W3_A112DepartamentoId[0];
            n112DepartamentoId = T002W3_n112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T002W3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = T002W3_n114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A110ZonasID = T002W3_A110ZonasID[0];
            n110ZonasID = T002W3_n110ZonasID[0];
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A128MetodoPagosID = T002W3_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A735MudanzaId = T002W3_A735MudanzaId[0];
            n735MudanzaId = T002W3_n735MudanzaId[0];
            AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
            A133ProveedorID = T002W3_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A919STComerciosID = T002W3_A919STComerciosID[0];
            n919STComerciosID = T002W3_n919STComerciosID[0];
            AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
            A996CancelacionTipificacionId = T002W3_A996CancelacionTipificacionId[0];
            A1013CuponId = T002W3_A1013CuponId[0];
            n1013CuponId = T002W3_n1013CuponId[0];
            A130EstadosSolTipo = T002W3_A130EstadosSolTipo[0];
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = T002W3_A131EstadosSolId[0];
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            A669STMonedasId = T002W3_A669STMonedasId[0];
            n669STMonedasId = T002W3_n669STMonedasId[0];
            AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
            Z127SolicitudesID = A127SolicitudesID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2W30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey2W30( ) ;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey2W30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2W30( ) ;
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
         /* Using cursor T002W24 */
         pr_default.execute(22, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T002W24_A127SolicitudesID[0] < A127SolicitudesID ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T002W24_A127SolicitudesID[0] > A127SolicitudesID ) ) )
            {
               A127SolicitudesID = T002W24_A127SolicitudesID[0];
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound30 = 0;
         /* Using cursor T002W25 */
         pr_default.execute(23, new Object[] {A127SolicitudesID});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T002W25_A127SolicitudesID[0] > A127SolicitudesID ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T002W25_A127SolicitudesID[0] < A127SolicitudesID ) ) )
            {
               A127SolicitudesID = T002W25_A127SolicitudesID[0];
               AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
               RcdFound30 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2W30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSolicitudesNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2W30( ) ;
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
                  GX_FocusControl = edtSolicitudesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2W30( ) ;
                  GX_FocusControl = edtSolicitudesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A127SolicitudesID != Z127SolicitudesID )
               {
                  /* Insert record */
                  GX_FocusControl = edtSolicitudesNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2W30( ) ;
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
                     GX_FocusControl = edtSolicitudesNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2W30( ) ;
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
            GX_FocusControl = edtSolicitudesNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2W30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002W2 */
            pr_default.execute(0, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z171SolicitudesNombre, T002W2_A171SolicitudesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z533ProveedorNombreAux, T002W2_A533ProveedorNombreAux[0]) != 0 ) || ( StringUtil.StrCmp(Z172SolicitudesTelefono, T002W2_A172SolicitudesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z206SolicitudesMail, T002W2_A206SolicitudesMail[0]) != 0 ) || ( StringUtil.StrCmp(Z173SolicitudesDireccion, T002W2_A173SolicitudesDireccion[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z194SolicitudesAutoEnumerar != T002W2_A194SolicitudesAutoEnumerar[0] ) || ( Z688SolicitudesLiqProf != T002W2_A688SolicitudesLiqProf[0] ) || ( Z689SolicitudesLiqProv != T002W2_A689SolicitudesLiqProv[0] ) || ( Z212SolicitudesCotizacion != T002W2_A212SolicitudesCotizacion[0] ) || ( StringUtil.StrCmp(Z210SolicitudServicioSolCoti, T002W2_A210SolicitudServicioSolCoti[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z897SolicitudesDescuento != T002W2_A897SolicitudesDescuento[0] ) || ( Z796SolicitudesComisionMetodoPago != T002W2_A796SolicitudesComisionMetodoPago[0] ) || ( StringUtil.StrCmp(Z201SolicitudesOtros1, T002W2_A201SolicitudesOtros1[0]) != 0 ) || ( StringUtil.StrCmp(Z202SolicitudesOtros2, T002W2_A202SolicitudesOtros2[0]) != 0 ) || ( StringUtil.StrCmp(Z203SolicitudesOtros3, T002W2_A203SolicitudesOtros3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z597SolicitudesUsrAlta != T002W2_A597SolicitudesUsrAlta[0] ) || ( Z598SolicitudesUsrActualizacion != T002W2_A598SolicitudesUsrActualizacion[0] ) || ( DateTimeUtil.ResetTime ( Z182SolicitudesFechaAlta ) != DateTimeUtil.ResetTime ( T002W2_A182SolicitudesFechaAlta[0] ) ) || ( Z204SolicitudesFechaActualizacion != T002W2_A204SolicitudesFechaActualizacion[0] ) || ( DateTimeUtil.ResetTime ( Z184SolicitudesFechaInstalacion ) != DateTimeUtil.ResetTime ( T002W2_A184SolicitudesFechaInstalacion[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z183SolicitudesHoraInstalacion, T002W2_A183SolicitudesHoraInstalacion[0]) != 0 ) || ( StringUtil.StrCmp(Z261SolicitudesNota, T002W2_A261SolicitudesNota[0]) != 0 ) || ( StringUtil.StrCmp(Z262SolicitudesNotificacion, T002W2_A262SolicitudesNotificacion[0]) != 0 ) || ( StringUtil.StrCmp(Z438SolicitudServicioOrigenPago, T002W2_A438SolicitudServicioOrigenPago[0]) != 0 ) || ( StringUtil.StrCmp(Z441SolicitudesPagado, T002W2_A441SolicitudesPagado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z527SolicitudServicioComProv != T002W2_A527SolicitudServicioComProv[0] ) || ( Z528SolicitudServicioComProvP != T002W2_A528SolicitudServicioComProvP[0] ) || ( Z530SolicitudServicioComALM != T002W2_A530SolicitudServicioComALM[0] ) || ( Z532SolicitudServicioComALMP != T002W2_A532SolicitudServicioComALMP[0] ) || ( Z672SolicitudesCalComi != T002W2_A672SolicitudesCalComi[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z600SolicitudesSubTipo, T002W2_A600SolicitudesSubTipo[0]) != 0 ) || ( Z864SolicitudesCostoXZona != T002W2_A864SolicitudesCostoXZona[0] ) || ( Z865SolicitudesCostoXZComAlm != T002W2_A865SolicitudesCostoXZComAlm[0] ) || ( Z866SolicitudesCostoXZComAlmP != T002W2_A866SolicitudesCostoXZComAlmP[0] ) || ( Z1016SolicitudesDescuentoCupon != T002W2_A1016SolicitudesDescuentoCupon[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z112DepartamentoId != T002W2_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T002W2_A114DepartamentoMunicipioId[0] ) || ( Z110ZonasID != T002W2_A110ZonasID[0] ) || ( Z128MetodoPagosID != T002W2_A128MetodoPagosID[0] ) || ( Z735MudanzaId != T002W2_A735MudanzaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z133ProveedorID != T002W2_A133ProveedorID[0] ) || ( Z919STComerciosID != T002W2_A919STComerciosID[0] ) || ( Z996CancelacionTipificacionId != T002W2_A996CancelacionTipificacionId[0] ) || ( Z1013CuponId != T002W2_A1013CuponId[0] ) || ( StringUtil.StrCmp(Z130EstadosSolTipo, T002W2_A130EstadosSolTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z131EstadosSolId != T002W2_A131EstadosSolId[0] ) || ( Z669STMonedasId != T002W2_A669STMonedasId[0] ) )
            {
               if ( StringUtil.StrCmp(Z171SolicitudesNombre, T002W2_A171SolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z171SolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A171SolicitudesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z533ProveedorNombreAux, T002W2_A533ProveedorNombreAux[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"ProveedorNombreAux");
                  GXUtil.WriteLogRaw("Old: ",Z533ProveedorNombreAux);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A533ProveedorNombreAux[0]);
               }
               if ( StringUtil.StrCmp(Z172SolicitudesTelefono, T002W2_A172SolicitudesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z172SolicitudesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A172SolicitudesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z206SolicitudesMail, T002W2_A206SolicitudesMail[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesMail");
                  GXUtil.WriteLogRaw("Old: ",Z206SolicitudesMail);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A206SolicitudesMail[0]);
               }
               if ( StringUtil.StrCmp(Z173SolicitudesDireccion, T002W2_A173SolicitudesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z173SolicitudesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A173SolicitudesDireccion[0]);
               }
               if ( Z194SolicitudesAutoEnumerar != T002W2_A194SolicitudesAutoEnumerar[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesAutoEnumerar");
                  GXUtil.WriteLogRaw("Old: ",Z194SolicitudesAutoEnumerar);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A194SolicitudesAutoEnumerar[0]);
               }
               if ( Z688SolicitudesLiqProf != T002W2_A688SolicitudesLiqProf[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesLiqProf");
                  GXUtil.WriteLogRaw("Old: ",Z688SolicitudesLiqProf);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A688SolicitudesLiqProf[0]);
               }
               if ( Z689SolicitudesLiqProv != T002W2_A689SolicitudesLiqProv[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesLiqProv");
                  GXUtil.WriteLogRaw("Old: ",Z689SolicitudesLiqProv);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A689SolicitudesLiqProv[0]);
               }
               if ( Z212SolicitudesCotizacion != T002W2_A212SolicitudesCotizacion[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesCotizacion");
                  GXUtil.WriteLogRaw("Old: ",Z212SolicitudesCotizacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A212SolicitudesCotizacion[0]);
               }
               if ( StringUtil.StrCmp(Z210SolicitudServicioSolCoti, T002W2_A210SolicitudServicioSolCoti[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioSolCoti");
                  GXUtil.WriteLogRaw("Old: ",Z210SolicitudServicioSolCoti);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A210SolicitudServicioSolCoti[0]);
               }
               if ( Z897SolicitudesDescuento != T002W2_A897SolicitudesDescuento[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesDescuento");
                  GXUtil.WriteLogRaw("Old: ",Z897SolicitudesDescuento);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A897SolicitudesDescuento[0]);
               }
               if ( Z796SolicitudesComisionMetodoPago != T002W2_A796SolicitudesComisionMetodoPago[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesComisionMetodoPago");
                  GXUtil.WriteLogRaw("Old: ",Z796SolicitudesComisionMetodoPago);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A796SolicitudesComisionMetodoPago[0]);
               }
               if ( StringUtil.StrCmp(Z201SolicitudesOtros1, T002W2_A201SolicitudesOtros1[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesOtros1");
                  GXUtil.WriteLogRaw("Old: ",Z201SolicitudesOtros1);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A201SolicitudesOtros1[0]);
               }
               if ( StringUtil.StrCmp(Z202SolicitudesOtros2, T002W2_A202SolicitudesOtros2[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesOtros2");
                  GXUtil.WriteLogRaw("Old: ",Z202SolicitudesOtros2);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A202SolicitudesOtros2[0]);
               }
               if ( StringUtil.StrCmp(Z203SolicitudesOtros3, T002W2_A203SolicitudesOtros3[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesOtros3");
                  GXUtil.WriteLogRaw("Old: ",Z203SolicitudesOtros3);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A203SolicitudesOtros3[0]);
               }
               if ( Z597SolicitudesUsrAlta != T002W2_A597SolicitudesUsrAlta[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z597SolicitudesUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A597SolicitudesUsrAlta[0]);
               }
               if ( Z598SolicitudesUsrActualizacion != T002W2_A598SolicitudesUsrActualizacion[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesUsrActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z598SolicitudesUsrActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A598SolicitudesUsrActualizacion[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z182SolicitudesFechaAlta ) != DateTimeUtil.ResetTime ( T002W2_A182SolicitudesFechaAlta[0] ) )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z182SolicitudesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A182SolicitudesFechaAlta[0]);
               }
               if ( Z204SolicitudesFechaActualizacion != T002W2_A204SolicitudesFechaActualizacion[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesFechaActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z204SolicitudesFechaActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A204SolicitudesFechaActualizacion[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z184SolicitudesFechaInstalacion ) != DateTimeUtil.ResetTime ( T002W2_A184SolicitudesFechaInstalacion[0] ) )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesFechaInstalacion");
                  GXUtil.WriteLogRaw("Old: ",Z184SolicitudesFechaInstalacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A184SolicitudesFechaInstalacion[0]);
               }
               if ( StringUtil.StrCmp(Z183SolicitudesHoraInstalacion, T002W2_A183SolicitudesHoraInstalacion[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesHoraInstalacion");
                  GXUtil.WriteLogRaw("Old: ",Z183SolicitudesHoraInstalacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A183SolicitudesHoraInstalacion[0]);
               }
               if ( StringUtil.StrCmp(Z261SolicitudesNota, T002W2_A261SolicitudesNota[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesNota");
                  GXUtil.WriteLogRaw("Old: ",Z261SolicitudesNota);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A261SolicitudesNota[0]);
               }
               if ( StringUtil.StrCmp(Z262SolicitudesNotificacion, T002W2_A262SolicitudesNotificacion[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesNotificacion");
                  GXUtil.WriteLogRaw("Old: ",Z262SolicitudesNotificacion);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A262SolicitudesNotificacion[0]);
               }
               if ( StringUtil.StrCmp(Z438SolicitudServicioOrigenPago, T002W2_A438SolicitudServicioOrigenPago[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioOrigenPago");
                  GXUtil.WriteLogRaw("Old: ",Z438SolicitudServicioOrigenPago);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A438SolicitudServicioOrigenPago[0]);
               }
               if ( StringUtil.StrCmp(Z441SolicitudesPagado, T002W2_A441SolicitudesPagado[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesPagado");
                  GXUtil.WriteLogRaw("Old: ",Z441SolicitudesPagado);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A441SolicitudesPagado[0]);
               }
               if ( Z527SolicitudServicioComProv != T002W2_A527SolicitudServicioComProv[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioComProv");
                  GXUtil.WriteLogRaw("Old: ",Z527SolicitudServicioComProv);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A527SolicitudServicioComProv[0]);
               }
               if ( Z528SolicitudServicioComProvP != T002W2_A528SolicitudServicioComProvP[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioComProvP");
                  GXUtil.WriteLogRaw("Old: ",Z528SolicitudServicioComProvP);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A528SolicitudServicioComProvP[0]);
               }
               if ( Z530SolicitudServicioComALM != T002W2_A530SolicitudServicioComALM[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioComALM");
                  GXUtil.WriteLogRaw("Old: ",Z530SolicitudServicioComALM);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A530SolicitudServicioComALM[0]);
               }
               if ( Z532SolicitudServicioComALMP != T002W2_A532SolicitudServicioComALMP[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudServicioComALMP");
                  GXUtil.WriteLogRaw("Old: ",Z532SolicitudServicioComALMP);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A532SolicitudServicioComALMP[0]);
               }
               if ( Z672SolicitudesCalComi != T002W2_A672SolicitudesCalComi[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesCalComi");
                  GXUtil.WriteLogRaw("Old: ",Z672SolicitudesCalComi);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A672SolicitudesCalComi[0]);
               }
               if ( StringUtil.StrCmp(Z600SolicitudesSubTipo, T002W2_A600SolicitudesSubTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesSubTipo");
                  GXUtil.WriteLogRaw("Old: ",Z600SolicitudesSubTipo);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A600SolicitudesSubTipo[0]);
               }
               if ( Z864SolicitudesCostoXZona != T002W2_A864SolicitudesCostoXZona[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesCostoXZona");
                  GXUtil.WriteLogRaw("Old: ",Z864SolicitudesCostoXZona);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A864SolicitudesCostoXZona[0]);
               }
               if ( Z865SolicitudesCostoXZComAlm != T002W2_A865SolicitudesCostoXZComAlm[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesCostoXZComAlm");
                  GXUtil.WriteLogRaw("Old: ",Z865SolicitudesCostoXZComAlm);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A865SolicitudesCostoXZComAlm[0]);
               }
               if ( Z866SolicitudesCostoXZComAlmP != T002W2_A866SolicitudesCostoXZComAlmP[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesCostoXZComAlmP");
                  GXUtil.WriteLogRaw("Old: ",Z866SolicitudesCostoXZComAlmP);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A866SolicitudesCostoXZComAlmP[0]);
               }
               if ( Z1016SolicitudesDescuentoCupon != T002W2_A1016SolicitudesDescuentoCupon[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"SolicitudesDescuentoCupon");
                  GXUtil.WriteLogRaw("Old: ",Z1016SolicitudesDescuentoCupon);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A1016SolicitudesDescuentoCupon[0]);
               }
               if ( Z112DepartamentoId != T002W2_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T002W2_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A114DepartamentoMunicipioId[0]);
               }
               if ( Z110ZonasID != T002W2_A110ZonasID[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"ZonasID");
                  GXUtil.WriteLogRaw("Old: ",Z110ZonasID);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A110ZonasID[0]);
               }
               if ( Z128MetodoPagosID != T002W2_A128MetodoPagosID[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"MetodoPagosID");
                  GXUtil.WriteLogRaw("Old: ",Z128MetodoPagosID);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A128MetodoPagosID[0]);
               }
               if ( Z735MudanzaId != T002W2_A735MudanzaId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"MudanzaId");
                  GXUtil.WriteLogRaw("Old: ",Z735MudanzaId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A735MudanzaId[0]);
               }
               if ( Z133ProveedorID != T002W2_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A133ProveedorID[0]);
               }
               if ( Z919STComerciosID != T002W2_A919STComerciosID[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"STComerciosID");
                  GXUtil.WriteLogRaw("Old: ",Z919STComerciosID);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A919STComerciosID[0]);
               }
               if ( Z996CancelacionTipificacionId != T002W2_A996CancelacionTipificacionId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"CancelacionTipificacionId");
                  GXUtil.WriteLogRaw("Old: ",Z996CancelacionTipificacionId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A996CancelacionTipificacionId[0]);
               }
               if ( Z1013CuponId != T002W2_A1013CuponId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"CuponId");
                  GXUtil.WriteLogRaw("Old: ",Z1013CuponId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A1013CuponId[0]);
               }
               if ( StringUtil.StrCmp(Z130EstadosSolTipo, T002W2_A130EstadosSolTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"EstadosSolTipo");
                  GXUtil.WriteLogRaw("Old: ",Z130EstadosSolTipo);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A130EstadosSolTipo[0]);
               }
               if ( Z131EstadosSolId != T002W2_A131EstadosSolId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"EstadosSolId");
                  GXUtil.WriteLogRaw("Old: ",Z131EstadosSolId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A131EstadosSolId[0]);
               }
               if ( Z669STMonedasId != T002W2_A669STMonedasId[0] )
               {
                  GXUtil.WriteLog("solicitudesreporte:[seudo value changed for attri]"+"STMonedasId");
                  GXUtil.WriteLogRaw("Old: ",Z669STMonedasId);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A669STMonedasId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Solicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2W30( )
      {
         BeforeValidate2W30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2W30( 0) ;
            CheckOptimisticConcurrency2W30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2W30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W26 */
                     pr_default.execute(24, new Object[] {A171SolicitudesNombre, n533ProveedorNombreAux, A533ProveedorNombreAux, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, A173SolicitudesDireccion, A194SolicitudesAutoEnumerar, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, A212SolicitudesCotizacion, A210SolicitudServicioSolCoti, n897SolicitudesDescuento, A897SolicitudesDescuento, A796SolicitudesComisionMetodoPago, A201SolicitudesOtros1, A202SolicitudesOtros2, A203SolicitudesOtros3, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A261SolicitudesNota, A262SolicitudesNotificacion, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n441SolicitudesPagado, A441SolicitudesPagado, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, A672SolicitudesCalComi, n600SolicitudesSubTipo, A600SolicitudesSubTipo, A864SolicitudesCostoXZona, n865SolicitudesCostoXZComAlm, A865SolicitudesCostoXZComAlm, n866SolicitudesCostoXZComAlmP, A866SolicitudesCostoXZComAlmP, A1016SolicitudesDescuentoCupon, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A128MetodoPagosID, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId, A130EstadosSolTipo, A131EstadosSolId, n669STMonedasId, A669STMonedasId});
                     A127SolicitudesID = T002W26_A127SolicitudesID[0];
                     AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2W0( ) ;
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
               Load2W30( ) ;
            }
            EndLevel2W30( ) ;
         }
         CloseExtendedTableCursors2W30( ) ;
      }

      protected void Update2W30( )
      {
         BeforeValidate2W30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2W30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W27 */
                     pr_default.execute(25, new Object[] {A171SolicitudesNombre, n533ProveedorNombreAux, A533ProveedorNombreAux, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, A173SolicitudesDireccion, A194SolicitudesAutoEnumerar, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, A212SolicitudesCotizacion, A210SolicitudServicioSolCoti, n897SolicitudesDescuento, A897SolicitudesDescuento, A796SolicitudesComisionMetodoPago, A201SolicitudesOtros1, A202SolicitudesOtros2, A203SolicitudesOtros3, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A261SolicitudesNota, A262SolicitudesNotificacion, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n441SolicitudesPagado, A441SolicitudesPagado, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, A672SolicitudesCalComi, n600SolicitudesSubTipo, A600SolicitudesSubTipo, A864SolicitudesCostoXZona, n865SolicitudesCostoXZComAlm, A865SolicitudesCostoXZComAlm, n866SolicitudesCostoXZComAlmP, A866SolicitudesCostoXZComAlmP, A1016SolicitudesDescuentoCupon, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A128MetodoPagosID, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId, A130EstadosSolTipo, A131EstadosSolId, n669STMonedasId, A669STMonedasId, A127SolicitudesID});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Solicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2W30( ) ;
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
            EndLevel2W30( ) ;
         }
         CloseExtendedTableCursors2W30( ) ;
      }

      protected void DeferredUpdate2W30( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2W30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2W30( ) ;
            AfterConfirm2W30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2W30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002W28 */
                  pr_default.execute(26, new Object[] {A127SolicitudesID});
                  pr_default.close(26);
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2W30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2W30( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV28Pgmname = "SolicitudesReporte";
            AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
            GetSolicitudesTotal( A127SolicitudesID) ;
            /* Using cursor T002W29 */
            pr_default.execute(27, new Object[] {A133ProveedorID});
            A282ProveedorNombre = T002W29_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A440ProveedorPagoDefault = T002W29_A440ProveedorPagoDefault[0];
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            pr_default.close(27);
            /* Using cursor T002W30 */
            pr_default.execute(28, new Object[] {n112DepartamentoId, A112DepartamentoId});
            A113DepartamentoDepartamento = T002W30_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A116PaisID = T002W30_A116PaisID[0];
            AssignAttri("", false, "A116PaisID", A116PaisID);
            pr_default.close(28);
            /* Using cursor T002W31 */
            pr_default.execute(29, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
            A115DepartamentoMunicipioNombre = T002W31_A115DepartamentoMunicipioNombre[0];
            AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
            pr_default.close(29);
            /* Using cursor T002W32 */
            pr_default.execute(30, new Object[] {n669STMonedasId, A669STMonedasId});
            A671STMonedasISO = T002W32_A671STMonedasISO[0];
            AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
            pr_default.close(30);
            /* Using cursor T002W33 */
            pr_default.execute(31, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = T002W33_A132EstadosSolNombre[0];
            AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
            pr_default.close(31);
            /* Using cursor T002W34 */
            pr_default.execute(32, new Object[] {A128MetodoPagosID});
            A129MetodoPagosNombre = T002W34_A129MetodoPagosNombre[0];
            AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
            pr_default.close(32);
            /* Using cursor T002W35 */
            pr_default.execute(33, new Object[] {n919STComerciosID, A919STComerciosID});
            A923STComerciosNombre = T002W35_A923STComerciosNombre[0];
            AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
            A924STComerciosEstado = T002W35_A924STComerciosEstado[0];
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
            pr_default.close(33);
            if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
               AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
                  AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                     AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
                  }
                  else
                  {
                     A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                     AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
                  }
               }
            }
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
               AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
               AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
            }
            if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
            }
            else
            {
               if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
                  AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
               }
               else
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
                  AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
               }
            }
            /* Using cursor T002W36 */
            pr_default.execute(34, new Object[] {n735MudanzaId, A735MudanzaId});
            A738MudanzaFechaServicio = T002W36_A738MudanzaFechaServicio[0];
            AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
            A740MudanzaDireccionOrigen = T002W36_A740MudanzaDireccionOrigen[0];
            AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
            A741MudanzaDireccionDestino = T002W36_A741MudanzaDireccionDestino[0];
            AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
            pr_default.close(34);
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                     AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                        AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                        AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                     }
                  }
               }
            }
            if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
            {
               A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
               AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
            }
            else
            {
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                  AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                     AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
                  }
                  else
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                     AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
                  }
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002W37 */
            pr_default.execute(35, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Archivo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T002W38 */
            pr_default.execute(36, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T002W39 */
            pr_default.execute(37, new Object[] {A127SolicitudesID});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Items", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
         }
      }

      protected void EndLevel2W30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2W30( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(32);
            pr_default.close(34);
            pr_default.close(27);
            pr_default.close(33);
            pr_default.close(31);
            pr_default.close(30);
            context.CommitDataStores("solicitudesreporte",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(32);
            pr_default.close(34);
            pr_default.close(27);
            pr_default.close(33);
            pr_default.close(31);
            pr_default.close(30);
            context.RollbackDataStores("solicitudesreporte",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2W30( )
      {
         /* Scan By routine */
         /* Using cursor T002W40 */
         pr_default.execute(38);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = T002W40_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2W30( )
      {
         /* Scan next routine */
         pr_default.readNext(38);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound30 = 1;
            A127SolicitudesID = T002W40_A127SolicitudesID[0];
            AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
      }

      protected void ScanEnd2W30( )
      {
         pr_default.close(38);
      }

      protected void AfterConfirm2W30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2W30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2W30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2W30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2W30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2W30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2W30( )
      {
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorNombreAux_Enabled = 0;
         AssignProp("", false, edtProveedorNombreAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombreAux_Enabled), 5, 0), true);
         edtSolicitudesTelefono_Enabled = 0;
         AssignProp("", false, edtSolicitudesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTelefono_Enabled), 5, 0), true);
         edtSolicitudesMail_Enabled = 0;
         AssignProp("", false, edtSolicitudesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesMail_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoDepartamento_Enabled = 0;
         AssignProp("", false, edtDepartamentoDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoDepartamento_Enabled), 5, 0), true);
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), true);
         edtDepartamentoMunicipioNombre_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioNombre_Enabled), 5, 0), true);
         edtZonasID_Enabled = 0;
         AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         edtSolicitudesDireccion_Enabled = 0;
         AssignProp("", false, edtSolicitudesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesDireccion_Enabled), 5, 0), true);
         edtSolicitudesAutoEnumerar_Enabled = 0;
         AssignProp("", false, edtSolicitudesAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesAutoEnumerar_Enabled), 5, 0), true);
         edtSTMonedasId_Enabled = 0;
         AssignProp("", false, edtSTMonedasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTMonedasId_Enabled), 5, 0), true);
         edtSTMonedasISO_Enabled = 0;
         AssignProp("", false, edtSTMonedasISO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTMonedasISO_Enabled), 5, 0), true);
         edtSolicitudesLiqProf_Enabled = 0;
         AssignProp("", false, edtSolicitudesLiqProf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesLiqProf_Enabled), 5, 0), true);
         edtSolicitudesLiqProv_Enabled = 0;
         AssignProp("", false, edtSolicitudesLiqProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesLiqProv_Enabled), 5, 0), true);
         edtSolicitudesCotizacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesCotizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCotizacion_Enabled), 5, 0), true);
         edtSolicitudesTotal_Enabled = 0;
         AssignProp("", false, edtSolicitudesTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTotal_Enabled), 5, 0), true);
         chkSolicitudServicioSolCoti.Enabled = 0;
         AssignProp("", false, chkSolicitudServicioSolCoti_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudServicioSolCoti.Enabled), 5, 0), true);
         edtSolicitudServicioPFinal_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioPFinal_Enabled), 5, 0), true);
         edtSolicitudesDescuento_Enabled = 0;
         AssignProp("", false, edtSolicitudesDescuento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesDescuento_Enabled), 5, 0), true);
         edtSolicitudesComisionMetodoPago_Enabled = 0;
         AssignProp("", false, edtSolicitudesComisionMetodoPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesComisionMetodoPago_Enabled), 5, 0), true);
         edtEstadosSolTipo_Enabled = 0;
         AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         edtEstadosSolId_Enabled = 0;
         AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         edtEstadosSolNombre_Enabled = 0;
         AssignProp("", false, edtEstadosSolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolNombre_Enabled), 5, 0), true);
         chkSolicitudesOtros1.Enabled = 0;
         AssignProp("", false, chkSolicitudesOtros1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudesOtros1.Enabled), 5, 0), true);
         edtSolicitudesOtros2_Enabled = 0;
         AssignProp("", false, edtSolicitudesOtros2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros2_Enabled), 5, 0), true);
         edtSolicitudesOtros3_Enabled = 0;
         AssignProp("", false, edtSolicitudesOtros3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros3_Enabled), 5, 0), true);
         edtSolicitudesUsrAlta_Enabled = 0;
         AssignProp("", false, edtSolicitudesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesUsrAlta_Enabled), 5, 0), true);
         edtSolicitudesUsrActualizacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesUsrActualizacion_Enabled), 5, 0), true);
         edtSolicitudesFechaAlta_Enabled = 0;
         AssignProp("", false, edtSolicitudesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaAlta_Enabled), 5, 0), true);
         edtSolicitudesFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaActualizacion_Enabled), 5, 0), true);
         edtSolicitudesFechaInstalacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesFechaInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaInstalacion_Enabled), 5, 0), true);
         edtSolicitudesHoraInstalacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesHoraInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesHoraInstalacion_Enabled), 5, 0), true);
         edtSolicitudesComentario_Enabled = 0;
         AssignProp("", false, edtSolicitudesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesComentario_Enabled), 5, 0), true);
         edtMetodoPagosID_Enabled = 0;
         AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         edtMetodoPagosNombre_Enabled = 0;
         AssignProp("", false, edtMetodoPagosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosNombre_Enabled), 5, 0), true);
         edtSolicitudesNota_Enabled = 0;
         AssignProp("", false, edtSolicitudesNota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNota_Enabled), 5, 0), true);
         cmbSolicitudesNotificacion.Enabled = 0;
         AssignProp("", false, cmbSolicitudesNotificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesNotificacion.Enabled), 5, 0), true);
         cmbProveedorPagoDefault.Enabled = 0;
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorPagoDefault.Enabled), 5, 0), true);
         edtSTComerciosID_Enabled = 0;
         AssignProp("", false, edtSTComerciosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Enabled), 5, 0), true);
         edtSTComerciosNombre_Enabled = 0;
         AssignProp("", false, edtSTComerciosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSTComerciosNombre_Enabled), 5, 0), true);
         cmbSTComerciosEstado.Enabled = 0;
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSTComerciosEstado.Enabled), 5, 0), true);
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudServicioOrigenPago.Enabled), 5, 0), true);
         cmbSolicitudesPagado.Enabled = 0;
         AssignProp("", false, cmbSolicitudesPagado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesPagado.Enabled), 5, 0), true);
         edtSolicitudServicioComProv_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProv_Enabled), 5, 0), true);
         edtSolicitudServicioComProvP_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComProvP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProvP_Enabled), 5, 0), true);
         edtSolicitudServicioComALM_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALM_Enabled), 5, 0), true);
         edtSolicitudServicioComALMP_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComALMP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALMP_Enabled), 5, 0), true);
         edtSolicitudServicioComPro_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComPro_Enabled), 5, 0), true);
         edtSolicitudServicioComProP_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioComProP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProP_Enabled), 5, 0), true);
         chkSolicitudesCalComi.Enabled = 0;
         AssignProp("", false, chkSolicitudesCalComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudesCalComi.Enabled), 5, 0), true);
         cmbSolicitudesSubTipo.Enabled = 0;
         AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesSubTipo.Enabled), 5, 0), true);
         edtSolicitudesCostoXZona_Enabled = 0;
         AssignProp("", false, edtSolicitudesCostoXZona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZona_Enabled), 5, 0), true);
         edtSolicitudesCostoXZComAlm_Enabled = 0;
         AssignProp("", false, edtSolicitudesCostoXZComAlm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComAlm_Enabled), 5, 0), true);
         edtSolicitudesCostoXZComAlmP_Enabled = 0;
         AssignProp("", false, edtSolicitudesCostoXZComAlmP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComAlmP_Enabled), 5, 0), true);
         edtSolicitudesCostoXZComProf_Enabled = 0;
         AssignProp("", false, edtSolicitudesCostoXZComProf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComProf_Enabled), 5, 0), true);
         edtSolicitudesCostoXZComProfP_Enabled = 0;
         AssignProp("", false, edtSolicitudesCostoXZComProfP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComProfP_Enabled), 5, 0), true);
         edtMudanzaId_Enabled = 0;
         AssignProp("", false, edtMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaId_Enabled), 5, 0), true);
         edtMudanzaFechaServicio_Enabled = 0;
         AssignProp("", false, edtMudanzaFechaServicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaFechaServicio_Enabled), 5, 0), true);
         edtMudanzaDireccionOrigen_Enabled = 0;
         AssignProp("", false, edtMudanzaDireccionOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Enabled), 5, 0), true);
         edtMudanzaDireccionDestino_Enabled = 0;
         AssignProp("", false, edtMudanzaDireccionDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionDestino_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2W30( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2W0( )
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
         GXEncryptionTmp = "solicitudesreporte.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudesreporte.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesReporte");
         forbiddenHiddens.Add("SolicitudesID", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProveedorID", context.localUtil.Format( (decimal)(AV18Insert_ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DepartamentoId", context.localUtil.Format( (decimal)(AV19Insert_DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DepartamentoMunicipioId", context.localUtil.Format( (decimal)(AV20Insert_DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ZonasID", context.localUtil.Format( (decimal)(AV21Insert_ZonasID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_STMonedasId", context.localUtil.Format( (decimal)(AV22Insert_STMonedasId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( AV23Insert_EstadosSolTipo, "")));
         forbiddenHiddens.Add("Insert_EstadosSolId", context.localUtil.Format( (decimal)(AV24Insert_EstadosSolId), "ZZZZ9"));
         forbiddenHiddens.Add("Insert_MetodoPagosID", context.localUtil.Format( (decimal)(AV25Insert_MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_STComerciosID", context.localUtil.Format( (decimal)(AV26Insert_STComerciosID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_MudanzaId", context.localUtil.Format( (decimal)(AV27Insert_MudanzaId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("CuponId", context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CancelacionTipificacionId", context.localUtil.Format( (decimal)(A996CancelacionTipificacionId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("SolicitudesDescuentoCupon", context.localUtil.Format( A1016SolicitudesDescuentoCupon, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("solicitudesreporte:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z127SolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z171SolicitudesNombre", StringUtil.RTrim( Z171SolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "Z533ProveedorNombreAux", StringUtil.RTrim( Z533ProveedorNombreAux));
         GxWebStd.gx_hidden_field( context, "Z172SolicitudesTelefono", StringUtil.RTrim( Z172SolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, "Z206SolicitudesMail", Z206SolicitudesMail);
         GxWebStd.gx_hidden_field( context, "Z173SolicitudesDireccion", Z173SolicitudesDireccion);
         GxWebStd.gx_hidden_field( context, "Z194SolicitudesAutoEnumerar", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z194SolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z688SolicitudesLiqProf", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z688SolicitudesLiqProf), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z689SolicitudesLiqProv", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z689SolicitudesLiqProv), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z212SolicitudesCotizacion", StringUtil.LTrim( StringUtil.NToC( Z212SolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z210SolicitudServicioSolCoti", StringUtil.RTrim( Z210SolicitudServicioSolCoti));
         GxWebStd.gx_hidden_field( context, "Z897SolicitudesDescuento", StringUtil.LTrim( StringUtil.NToC( Z897SolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z796SolicitudesComisionMetodoPago", StringUtil.LTrim( StringUtil.NToC( Z796SolicitudesComisionMetodoPago, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z201SolicitudesOtros1", StringUtil.RTrim( Z201SolicitudesOtros1));
         GxWebStd.gx_hidden_field( context, "Z202SolicitudesOtros2", StringUtil.RTrim( Z202SolicitudesOtros2));
         GxWebStd.gx_hidden_field( context, "Z203SolicitudesOtros3", StringUtil.RTrim( Z203SolicitudesOtros3));
         GxWebStd.gx_hidden_field( context, "Z597SolicitudesUsrAlta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z597SolicitudesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z598SolicitudesUsrActualizacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z598SolicitudesUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z182SolicitudesFechaAlta", context.localUtil.DToC( Z182SolicitudesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z204SolicitudesFechaActualizacion", context.localUtil.TToC( Z204SolicitudesFechaActualizacion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z184SolicitudesFechaInstalacion", context.localUtil.DToC( Z184SolicitudesFechaInstalacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z183SolicitudesHoraInstalacion", StringUtil.RTrim( Z183SolicitudesHoraInstalacion));
         GxWebStd.gx_hidden_field( context, "Z261SolicitudesNota", StringUtil.RTrim( Z261SolicitudesNota));
         GxWebStd.gx_hidden_field( context, "Z262SolicitudesNotificacion", StringUtil.RTrim( Z262SolicitudesNotificacion));
         GxWebStd.gx_hidden_field( context, "Z438SolicitudServicioOrigenPago", StringUtil.RTrim( Z438SolicitudServicioOrigenPago));
         GxWebStd.gx_hidden_field( context, "Z441SolicitudesPagado", StringUtil.RTrim( Z441SolicitudesPagado));
         GxWebStd.gx_hidden_field( context, "Z527SolicitudServicioComProv", StringUtil.LTrim( StringUtil.NToC( Z527SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z528SolicitudServicioComProvP", StringUtil.LTrim( StringUtil.NToC( Z528SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z530SolicitudServicioComALM", StringUtil.LTrim( StringUtil.NToC( Z530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z532SolicitudServicioComALMP", StringUtil.LTrim( StringUtil.NToC( Z532SolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z672SolicitudesCalComi", Z672SolicitudesCalComi);
         GxWebStd.gx_hidden_field( context, "Z600SolicitudesSubTipo", StringUtil.RTrim( Z600SolicitudesSubTipo));
         GxWebStd.gx_hidden_field( context, "Z864SolicitudesCostoXZona", StringUtil.LTrim( StringUtil.NToC( Z864SolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z865SolicitudesCostoXZComAlm", StringUtil.LTrim( StringUtil.NToC( Z865SolicitudesCostoXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z866SolicitudesCostoXZComAlmP", StringUtil.LTrim( StringUtil.NToC( Z866SolicitudesCostoXZComAlmP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1016SolicitudesDescuentoCupon", StringUtil.LTrim( StringUtil.NToC( Z1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z128MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z735MudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z919STComerciosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z996CancelacionTipificacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z996CancelacionTipificacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z1013CuponId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z130EstadosSolTipo", StringUtil.RTrim( Z130EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "Z131EstadosSolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z669STMonedasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z669STMonedasId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N669STMonedasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A669STMonedasId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N130EstadosSolTipo", StringUtil.RTrim( A130EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "N131EstadosSolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N128MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N919STComerciosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N735MudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Insert_ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_STMONEDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_STMonedasId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSSOLTIPO", StringUtil.RTrim( AV23Insert_EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSSOLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_METODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_STCOMERCIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Insert_MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CUPONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1013CuponId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CANCELACIONTIPIFICACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A996CancelacionTipificacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
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
         GXEncryptionTmp = "solicitudesreporte.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0));
         return formatLink("solicitudesreporte.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SolicitudesReporte" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitudes Reporte", "") ;
      }

      protected void InitializeNonKey2W30( )
      {
         A133ProveedorID = 0;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         A112DepartamentoId = 0;
         n112DepartamentoId = false;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         n112DepartamentoId = ((0==A112DepartamentoId) ? true : false);
         A114DepartamentoMunicipioId = 0;
         n114DepartamentoMunicipioId = false;
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         n114DepartamentoMunicipioId = ((0==A114DepartamentoMunicipioId) ? true : false);
         A110ZonasID = 0;
         n110ZonasID = false;
         AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         n110ZonasID = ((0==A110ZonasID) ? true : false);
         A669STMonedasId = 0;
         n669STMonedasId = false;
         AssignAttri("", false, "A669STMonedasId", StringUtil.LTrimStr( (decimal)(A669STMonedasId), 4, 0));
         n669STMonedasId = ((0==A669STMonedasId) ? true : false);
         A130EstadosSolTipo = "";
         AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
         A131EstadosSolId = 0;
         AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
         A128MetodoPagosID = 0;
         AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         A919STComerciosID = 0;
         n919STComerciosID = false;
         AssignAttri("", false, "A919STComerciosID", StringUtil.LTrimStr( (decimal)(A919STComerciosID), 18, 0));
         n919STComerciosID = ((0==A919STComerciosID) ? true : false);
         A735MudanzaId = 0;
         n735MudanzaId = false;
         AssignAttri("", false, "A735MudanzaId", StringUtil.LTrimStr( (decimal)(A735MudanzaId), 18, 0));
         n735MudanzaId = ((0==A735MudanzaId) ? true : false);
         A868SolicitudesCostoXZComProfP = 0;
         AssignAttri("", false, "A868SolicitudesCostoXZComProfP", StringUtil.LTrimStr( A868SolicitudesCostoXZComProfP, 6, 2));
         A867SolicitudesCostoXZComProf = 0;
         AssignAttri("", false, "A867SolicitudesCostoXZComProf", StringUtil.LTrimStr( A867SolicitudesCostoXZComProf, 18, 2));
         A531SolicitudServicioComProP = 0;
         AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
         A529SolicitudServicioComPro = 0;
         AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
         A211SolicitudServicioPFinal = 0;
         AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
         A171SolicitudesNombre = "";
         AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A533ProveedorNombreAux = "";
         n533ProveedorNombreAux = false;
         AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
         n533ProveedorNombreAux = (String.IsNullOrEmpty(StringUtil.RTrim( A533ProveedorNombreAux)) ? true : false);
         A172SolicitudesTelefono = "";
         AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
         A206SolicitudesMail = "";
         n206SolicitudesMail = false;
         AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
         n206SolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ? true : false);
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A113DepartamentoDepartamento = "";
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A115DepartamentoMunicipioNombre = "";
         AssignAttri("", false, "A115DepartamentoMunicipioNombre", A115DepartamentoMunicipioNombre);
         A173SolicitudesDireccion = "";
         AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
         A194SolicitudesAutoEnumerar = 0;
         AssignAttri("", false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
         A671STMonedasISO = "";
         AssignAttri("", false, "A671STMonedasISO", A671STMonedasISO);
         A688SolicitudesLiqProf = 0;
         n688SolicitudesLiqProf = false;
         AssignAttri("", false, "A688SolicitudesLiqProf", StringUtil.LTrimStr( (decimal)(A688SolicitudesLiqProf), 18, 0));
         n688SolicitudesLiqProf = ((0==A688SolicitudesLiqProf) ? true : false);
         A689SolicitudesLiqProv = 0;
         n689SolicitudesLiqProv = false;
         AssignAttri("", false, "A689SolicitudesLiqProv", StringUtil.LTrimStr( (decimal)(A689SolicitudesLiqProv), 18, 0));
         n689SolicitudesLiqProv = ((0==A689SolicitudesLiqProv) ? true : false);
         A212SolicitudesCotizacion = 0;
         AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
         A174SolicitudesTotal = 0;
         AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
         A210SolicitudServicioSolCoti = "";
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
         A897SolicitudesDescuento = 0;
         n897SolicitudesDescuento = false;
         AssignAttri("", false, "A897SolicitudesDescuento", StringUtil.LTrimStr( A897SolicitudesDescuento, 18, 2));
         n897SolicitudesDescuento = ((Convert.ToDecimal(0)==A897SolicitudesDescuento) ? true : false);
         A796SolicitudesComisionMetodoPago = 0;
         AssignAttri("", false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
         A132EstadosSolNombre = "";
         AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
         A201SolicitudesOtros1 = "";
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         A202SolicitudesOtros2 = "";
         AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
         A203SolicitudesOtros3 = "";
         AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
         A597SolicitudesUsrAlta = 0;
         n597SolicitudesUsrAlta = false;
         AssignAttri("", false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
         n597SolicitudesUsrAlta = ((0==A597SolicitudesUsrAlta) ? true : false);
         A598SolicitudesUsrActualizacion = 0;
         n598SolicitudesUsrActualizacion = false;
         AssignAttri("", false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
         n598SolicitudesUsrActualizacion = ((0==A598SolicitudesUsrActualizacion) ? true : false);
         A182SolicitudesFechaAlta = DateTime.MinValue;
         n182SolicitudesFechaAlta = false;
         AssignAttri("", false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
         n182SolicitudesFechaAlta = ((DateTime.MinValue==A182SolicitudesFechaAlta) ? true : false);
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         n204SolicitudesFechaActualizacion = false;
         AssignAttri("", false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n204SolicitudesFechaActualizacion = ((DateTime.MinValue==A204SolicitudesFechaActualizacion) ? true : false);
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
         A183SolicitudesHoraInstalacion = "";
         AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
         A205SolicitudesComentario = "";
         AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
         A129MetodoPagosNombre = "";
         AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
         A261SolicitudesNota = "";
         AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
         A262SolicitudesNotificacion = "";
         AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         A440ProveedorPagoDefault = "";
         AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         A923STComerciosNombre = "";
         AssignAttri("", false, "A923STComerciosNombre", A923STComerciosNombre);
         A924STComerciosEstado = "";
         AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         A438SolicitudServicioOrigenPago = "";
         n438SolicitudServicioOrigenPago = false;
         AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
         n438SolicitudServicioOrigenPago = (String.IsNullOrEmpty(StringUtil.RTrim( A438SolicitudServicioOrigenPago)) ? true : false);
         A441SolicitudesPagado = "";
         n441SolicitudesPagado = false;
         AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
         n441SolicitudesPagado = (String.IsNullOrEmpty(StringUtil.RTrim( A441SolicitudesPagado)) ? true : false);
         A527SolicitudServicioComProv = 0;
         n527SolicitudServicioComProv = false;
         AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
         n527SolicitudServicioComProv = ((Convert.ToDecimal(0)==A527SolicitudServicioComProv) ? true : false);
         A528SolicitudServicioComProvP = 0;
         n528SolicitudServicioComProvP = false;
         AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
         n528SolicitudServicioComProvP = ((Convert.ToDecimal(0)==A528SolicitudServicioComProvP) ? true : false);
         A530SolicitudServicioComALM = 0;
         n530SolicitudServicioComALM = false;
         AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
         n530SolicitudServicioComALM = ((Convert.ToDecimal(0)==A530SolicitudServicioComALM) ? true : false);
         A532SolicitudServicioComALMP = 0;
         n532SolicitudServicioComALMP = false;
         AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
         n532SolicitudServicioComALMP = ((Convert.ToDecimal(0)==A532SolicitudServicioComALMP) ? true : false);
         A672SolicitudesCalComi = false;
         AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
         A600SolicitudesSubTipo = "";
         n600SolicitudesSubTipo = false;
         AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
         n600SolicitudesSubTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A600SolicitudesSubTipo)) ? true : false);
         A864SolicitudesCostoXZona = 0;
         AssignAttri("", false, "A864SolicitudesCostoXZona", StringUtil.LTrimStr( A864SolicitudesCostoXZona, 18, 2));
         A865SolicitudesCostoXZComAlm = 0;
         n865SolicitudesCostoXZComAlm = false;
         AssignAttri("", false, "A865SolicitudesCostoXZComAlm", StringUtil.LTrimStr( A865SolicitudesCostoXZComAlm, 18, 2));
         n865SolicitudesCostoXZComAlm = ((Convert.ToDecimal(0)==A865SolicitudesCostoXZComAlm) ? true : false);
         A866SolicitudesCostoXZComAlmP = 0;
         n866SolicitudesCostoXZComAlmP = false;
         AssignAttri("", false, "A866SolicitudesCostoXZComAlmP", StringUtil.LTrimStr( A866SolicitudesCostoXZComAlmP, 6, 2));
         n866SolicitudesCostoXZComAlmP = ((Convert.ToDecimal(0)==A866SolicitudesCostoXZComAlmP) ? true : false);
         A738MudanzaFechaServicio = DateTime.MinValue;
         AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
         A740MudanzaDireccionOrigen = "";
         AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
         A741MudanzaDireccionDestino = "";
         AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
         A1016SolicitudesDescuentoCupon = 0;
         AssignAttri("", false, "A1016SolicitudesDescuentoCupon", StringUtil.LTrimStr( A1016SolicitudesDescuentoCupon, 18, 2));
         A1013CuponId = 1234;
         n1013CuponId = false;
         AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         A996CancelacionTipificacionId = 0;
         AssignAttri("", false, "A996CancelacionTipificacionId", StringUtil.LTrimStr( (decimal)(A996CancelacionTipificacionId), 18, 0));
         Z171SolicitudesNombre = "";
         Z533ProveedorNombreAux = "";
         Z172SolicitudesTelefono = "";
         Z206SolicitudesMail = "";
         Z173SolicitudesDireccion = "";
         Z194SolicitudesAutoEnumerar = 0;
         Z688SolicitudesLiqProf = 0;
         Z689SolicitudesLiqProv = 0;
         Z212SolicitudesCotizacion = 0;
         Z210SolicitudServicioSolCoti = "";
         Z897SolicitudesDescuento = 0;
         Z796SolicitudesComisionMetodoPago = 0;
         Z201SolicitudesOtros1 = "";
         Z202SolicitudesOtros2 = "";
         Z203SolicitudesOtros3 = "";
         Z597SolicitudesUsrAlta = 0;
         Z598SolicitudesUsrActualizacion = 0;
         Z182SolicitudesFechaAlta = DateTime.MinValue;
         Z204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z184SolicitudesFechaInstalacion = DateTime.MinValue;
         Z183SolicitudesHoraInstalacion = "";
         Z261SolicitudesNota = "";
         Z262SolicitudesNotificacion = "";
         Z438SolicitudServicioOrigenPago = "";
         Z441SolicitudesPagado = "";
         Z527SolicitudServicioComProv = 0;
         Z528SolicitudServicioComProvP = 0;
         Z530SolicitudServicioComALM = 0;
         Z532SolicitudServicioComALMP = 0;
         Z672SolicitudesCalComi = false;
         Z600SolicitudesSubTipo = "";
         Z864SolicitudesCostoXZona = 0;
         Z865SolicitudesCostoXZComAlm = 0;
         Z866SolicitudesCostoXZComAlmP = 0;
         Z1016SolicitudesDescuentoCupon = 0;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z110ZonasID = 0;
         Z128MetodoPagosID = 0;
         Z735MudanzaId = 0;
         Z133ProveedorID = 0;
         Z919STComerciosID = 0;
         Z996CancelacionTipificacionId = 0;
         Z1013CuponId = 0;
         Z130EstadosSolTipo = "";
         Z131EstadosSolId = 0;
         Z669STMonedasId = 0;
      }

      protected void InitAll2W30( )
      {
         A127SolicitudesID = 0;
         AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         InitializeNonKey2W30( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1013CuponId = i1013CuponId;
         n1013CuponId = false;
         AssignAttri("", false, "A1013CuponId", StringUtil.LTrimStr( (decimal)(A1013CuponId), 18, 0));
         A996CancelacionTipificacionId = i996CancelacionTipificacionId;
         AssignAttri("", false, "A996CancelacionTipificacionId", StringUtil.LTrimStr( (decimal)(A996CancelacionTipificacionId), 18, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269212337195", true, true, false);
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
         context.AddJavascriptSource("solicitudesreporte.js", "?20269212337196", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorNombreAux_Internalname = "PROVEEDORNOMBREAUX";
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO";
         edtSolicitudesMail_Internalname = "SOLICITUDESMAIL";
         edtPaisID_Internalname = "PAISID";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE";
         edtZonasID_Internalname = "ZONASID";
         edtSolicitudesDireccion_Internalname = "SOLICITUDESDIRECCION";
         edtSolicitudesAutoEnumerar_Internalname = "SOLICITUDESAUTOENUMERAR";
         edtSTMonedasId_Internalname = "STMONEDASID";
         edtSTMonedasISO_Internalname = "STMONEDASISO";
         edtSolicitudesLiqProf_Internalname = "SOLICITUDESLIQPROF";
         edtSolicitudesLiqProv_Internalname = "SOLICITUDESLIQPROV";
         edtSolicitudesCotizacion_Internalname = "SOLICITUDESCOTIZACION";
         edtSolicitudesTotal_Internalname = "SOLICITUDESTOTAL";
         chkSolicitudServicioSolCoti_Internalname = "SOLICITUDSERVICIOSOLCOTI";
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL";
         edtSolicitudesDescuento_Internalname = "SOLICITUDESDESCUENTO";
         edtSolicitudesComisionMetodoPago_Internalname = "SOLICITUDESCOMISIONMETODOPAGO";
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE";
         chkSolicitudesOtros1_Internalname = "SOLICITUDESOTROS1";
         edtSolicitudesOtros2_Internalname = "SOLICITUDESOTROS2";
         edtSolicitudesOtros3_Internalname = "SOLICITUDESOTROS3";
         edtSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA";
         edtSolicitudesUsrActualizacion_Internalname = "SOLICITUDESUSRACTUALIZACION";
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA";
         edtSolicitudesFechaActualizacion_Internalname = "SOLICITUDESFECHAACTUALIZACION";
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION";
         edtSolicitudesHoraInstalacion_Internalname = "SOLICITUDESHORAINSTALACION";
         edtSolicitudesComentario_Internalname = "SOLICITUDESCOMENTARIO";
         edtMetodoPagosID_Internalname = "METODOPAGOSID";
         edtMetodoPagosNombre_Internalname = "METODOPAGOSNOMBRE";
         edtSolicitudesNota_Internalname = "SOLICITUDESNOTA";
         cmbSolicitudesNotificacion_Internalname = "SOLICITUDESNOTIFICACION";
         cmbProveedorPagoDefault_Internalname = "PROVEEDORPAGODEFAULT";
         edtSTComerciosID_Internalname = "STCOMERCIOSID";
         edtSTComerciosNombre_Internalname = "STCOMERCIOSNOMBRE";
         cmbSTComerciosEstado_Internalname = "STCOMERCIOSESTADO";
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO";
         cmbSolicitudesPagado_Internalname = "SOLICITUDESPAGADO";
         edtSolicitudServicioComProv_Internalname = "SOLICITUDSERVICIOCOMPROV";
         edtSolicitudServicioComProvP_Internalname = "SOLICITUDSERVICIOCOMPROVP";
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM";
         edtSolicitudServicioComALMP_Internalname = "SOLICITUDSERVICIOCOMALMP";
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO";
         edtSolicitudServicioComProP_Internalname = "SOLICITUDSERVICIOCOMPROP";
         chkSolicitudesCalComi_Internalname = "SOLICITUDESCALCOMI";
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO";
         edtSolicitudesCostoXZona_Internalname = "SOLICITUDESCOSTOXZONA";
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM";
         edtSolicitudesCostoXZComAlmP_Internalname = "SOLICITUDESCOSTOXZCOMALMP";
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF";
         edtSolicitudesCostoXZComProfP_Internalname = "SOLICITUDESCOSTOXZCOMPROFP";
         edtMudanzaId_Internalname = "MUDANZAID";
         edtMudanzaFechaServicio_Internalname = "MUDANZAFECHASERVICIO";
         edtMudanzaDireccionOrigen_Internalname = "MUDANZADIRECCIONORIGEN";
         edtMudanzaDireccionDestino_Internalname = "MUDANZADIRECCIONDESTINO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_133_Internalname = "PROMPT_133";
         imgprompt_112_Internalname = "PROMPT_112";
         imgprompt_114_Internalname = "PROMPT_114";
         imgprompt_110_Internalname = "PROMPT_110";
         imgprompt_669_Internalname = "PROMPT_669";
         imgprompt_130_131_Internalname = "PROMPT_130_131";
         imgprompt_128_Internalname = "PROMPT_128";
         imgprompt_919_Internalname = "PROMPT_919";
         imgprompt_735_Internalname = "PROMPT_735";
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
         Form.Caption = context.GetMessage( "Solicitudes Reporte", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMudanzaDireccionDestino_Enabled = 0;
         edtMudanzaDireccionOrigen_Enabled = 0;
         edtMudanzaFechaServicio_Jsonclick = "";
         edtMudanzaFechaServicio_Enabled = 0;
         imgprompt_735_Visible = 1;
         imgprompt_735_Link = "";
         edtMudanzaId_Jsonclick = "";
         edtMudanzaId_Enabled = 1;
         edtSolicitudesCostoXZComProfP_Jsonclick = "";
         edtSolicitudesCostoXZComProfP_Enabled = 0;
         edtSolicitudesCostoXZComProf_Jsonclick = "";
         edtSolicitudesCostoXZComProf_Enabled = 0;
         edtSolicitudesCostoXZComAlmP_Jsonclick = "";
         edtSolicitudesCostoXZComAlmP_Enabled = 1;
         edtSolicitudesCostoXZComAlm_Jsonclick = "";
         edtSolicitudesCostoXZComAlm_Enabled = 1;
         edtSolicitudesCostoXZona_Jsonclick = "";
         edtSolicitudesCostoXZona_Enabled = 1;
         cmbSolicitudesSubTipo_Jsonclick = "";
         cmbSolicitudesSubTipo.Enabled = 1;
         chkSolicitudesCalComi.Enabled = 1;
         edtSolicitudServicioComProP_Jsonclick = "";
         edtSolicitudServicioComProP_Enabled = 0;
         edtSolicitudServicioComPro_Jsonclick = "";
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudServicioComALMP_Jsonclick = "";
         edtSolicitudServicioComALMP_Enabled = 1;
         edtSolicitudServicioComALM_Jsonclick = "";
         edtSolicitudServicioComALM_Enabled = 1;
         edtSolicitudServicioComProvP_Jsonclick = "";
         edtSolicitudServicioComProvP_Enabled = 1;
         edtSolicitudServicioComProv_Jsonclick = "";
         edtSolicitudServicioComProv_Enabled = 1;
         cmbSolicitudesPagado_Jsonclick = "";
         cmbSolicitudesPagado.Enabled = 1;
         cmbSolicitudServicioOrigenPago_Jsonclick = "";
         cmbSolicitudServicioOrigenPago.Enabled = 1;
         cmbSTComerciosEstado_Jsonclick = "";
         cmbSTComerciosEstado.Enabled = 0;
         edtSTComerciosNombre_Jsonclick = "";
         edtSTComerciosNombre_Enabled = 0;
         imgprompt_919_Visible = 1;
         imgprompt_919_Link = "";
         edtSTComerciosID_Jsonclick = "";
         edtSTComerciosID_Enabled = 1;
         cmbProveedorPagoDefault_Jsonclick = "";
         cmbProveedorPagoDefault.Enabled = 0;
         cmbSolicitudesNotificacion_Jsonclick = "";
         cmbSolicitudesNotificacion.Enabled = 1;
         edtSolicitudesNota_Enabled = 1;
         edtMetodoPagosNombre_Jsonclick = "";
         edtMetodoPagosNombre_Enabled = 0;
         imgprompt_128_Visible = 1;
         imgprompt_128_Link = "";
         edtMetodoPagosID_Jsonclick = "";
         edtMetodoPagosID_Enabled = 1;
         edtSolicitudesComentario_Enabled = 1;
         edtSolicitudesHoraInstalacion_Jsonclick = "";
         edtSolicitudesHoraInstalacion_Enabled = 1;
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         edtSolicitudesFechaInstalacion_Enabled = 1;
         edtSolicitudesFechaActualizacion_Jsonclick = "";
         edtSolicitudesFechaActualizacion_Enabled = 1;
         edtSolicitudesFechaAlta_Jsonclick = "";
         edtSolicitudesFechaAlta_Enabled = 1;
         edtSolicitudesUsrActualizacion_Jsonclick = "";
         edtSolicitudesUsrActualizacion_Enabled = 1;
         edtSolicitudesUsrAlta_Jsonclick = "";
         edtSolicitudesUsrAlta_Enabled = 1;
         edtSolicitudesOtros3_Enabled = 1;
         edtSolicitudesOtros2_Enabled = 1;
         chkSolicitudesOtros1.Enabled = 1;
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolNombre_Enabled = 0;
         imgprompt_130_131_Visible = 1;
         imgprompt_130_131_Link = "";
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolId_Enabled = 1;
         edtEstadosSolTipo_Jsonclick = "";
         edtEstadosSolTipo_Enabled = 1;
         edtSolicitudesComisionMetodoPago_Jsonclick = "";
         edtSolicitudesComisionMetodoPago_Enabled = 1;
         edtSolicitudesDescuento_Jsonclick = "";
         edtSolicitudesDescuento_Enabled = 1;
         edtSolicitudServicioPFinal_Jsonclick = "";
         edtSolicitudServicioPFinal_Enabled = 0;
         chkSolicitudServicioSolCoti.Enabled = 1;
         edtSolicitudesTotal_Jsonclick = "";
         edtSolicitudesTotal_Enabled = 0;
         edtSolicitudesCotizacion_Jsonclick = "";
         edtSolicitudesCotizacion_Enabled = 1;
         edtSolicitudesLiqProv_Jsonclick = "";
         edtSolicitudesLiqProv_Enabled = 1;
         edtSolicitudesLiqProf_Jsonclick = "";
         edtSolicitudesLiqProf_Enabled = 1;
         edtSTMonedasISO_Jsonclick = "";
         edtSTMonedasISO_Enabled = 0;
         imgprompt_669_Visible = 1;
         imgprompt_669_Link = "";
         edtSTMonedasId_Jsonclick = "";
         edtSTMonedasId_Enabled = 1;
         edtSolicitudesAutoEnumerar_Jsonclick = "";
         edtSolicitudesAutoEnumerar_Enabled = 1;
         edtSolicitudesDireccion_Enabled = 1;
         imgprompt_110_Visible = 1;
         imgprompt_110_Link = "";
         edtZonasID_Jsonclick = "";
         edtZonasID_Enabled = 1;
         edtDepartamentoMunicipioNombre_Jsonclick = "";
         edtDepartamentoMunicipioNombre_Enabled = 0;
         imgprompt_114_Visible = 1;
         imgprompt_114_Link = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoMunicipioId_Enabled = 1;
         edtDepartamentoDepartamento_Jsonclick = "";
         edtDepartamentoDepartamento_Enabled = 0;
         imgprompt_112_Visible = 1;
         imgprompt_112_Link = "";
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtSolicitudesMail_Jsonclick = "";
         edtSolicitudesMail_Enabled = 1;
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesTelefono_Enabled = 1;
         edtProveedorNombreAux_Jsonclick = "";
         edtProveedorNombreAux_Enabled = 1;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         imgprompt_133_Visible = 1;
         imgprompt_133_Link = "";
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 1;
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Enabled = 1;
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

      protected void init_web_controls( )
      {
         chkSolicitudServicioSolCoti.Name = "SOLICITUDSERVICIOSOLCOTI";
         chkSolicitudServicioSolCoti.WebTags = "";
         chkSolicitudServicioSolCoti.Caption = context.GetMessage( "Solicitar cotización ", "");
         AssignProp("", false, chkSolicitudServicioSolCoti_Internalname, "TitleCaption", chkSolicitudServicioSolCoti.Caption, true);
         chkSolicitudServicioSolCoti.CheckedValue = "N";
         A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(StringUtil.RTrim( A210SolicitudServicioSolCoti), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
         chkSolicitudesOtros1.Name = "SOLICITUDESOTROS1";
         chkSolicitudesOtros1.WebTags = "";
         chkSolicitudesOtros1.Caption = context.GetMessage( "No aparecen en el listado los servicios que necesito.", "");
         AssignProp("", false, chkSolicitudesOtros1_Internalname, "TitleCaption", chkSolicitudesOtros1.Caption, true);
         chkSolicitudesOtros1.CheckedValue = "N";
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         cmbSolicitudesNotificacion.Name = "SOLICITUDESNOTIFICACION";
         cmbSolicitudesNotificacion.WebTags = "";
         cmbSolicitudesNotificacion.addItem("S", context.GetMessage( "Si", ""), 0);
         cmbSolicitudesNotificacion.addItem("N", context.GetMessage( "No", ""), 0);
         if ( cmbSolicitudesNotificacion.ItemCount > 0 )
         {
            A262SolicitudesNotificacion = cmbSolicitudesNotificacion.getValidValue(A262SolicitudesNotificacion);
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         }
         cmbProveedorPagoDefault.Name = "PROVEEDORPAGODEFAULT";
         cmbProveedorPagoDefault.WebTags = "";
         cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         }
         cmbSTComerciosEstado.Name = "STCOMERCIOSESTADO";
         cmbSTComerciosEstado.WebTags = "";
         cmbSTComerciosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSTComerciosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSTComerciosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSTComerciosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            AssignAttri("", false, "A924STComerciosEstado", A924STComerciosEstado);
         }
         cmbSolicitudServicioOrigenPago.Name = "SOLICITUDSERVICIOORIGENPAGO";
         cmbSolicitudServicioOrigenPago.WebTags = "";
         cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
            A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
            n438SolicitudServicioOrigenPago = false;
            AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
         }
         cmbSolicitudesPagado.Name = "SOLICITUDESPAGADO";
         cmbSolicitudesPagado.WebTags = "";
         cmbSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbSolicitudesPagado.ItemCount > 0 )
         {
            A441SolicitudesPagado = cmbSolicitudesPagado.getValidValue(A441SolicitudesPagado);
            n441SolicitudesPagado = false;
            AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
         }
         chkSolicitudesCalComi.Name = "SOLICITUDESCALCOMI";
         chkSolicitudesCalComi.WebTags = "";
         chkSolicitudesCalComi.Caption = context.GetMessage( "Calcular Comisión", "");
         AssignProp("", false, chkSolicitudesCalComi_Internalname, "TitleCaption", chkSolicitudesCalComi.Caption, true);
         chkSolicitudesCalComi.CheckedValue = "false";
         A672SolicitudesCalComi = StringUtil.StrToBool( StringUtil.BoolToStr( A672SolicitudesCalComi));
         AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
         cmbSolicitudesSubTipo.Name = "SOLICITUDESSUBTIPO";
         cmbSolicitudesSubTipo.WebTags = "";
         cmbSolicitudesSubTipo.addItem("T", context.GetMessage( "Trabajo Registrado", ""), 0);
         cmbSolicitudesSubTipo.addItem("E", context.GetMessage( "Ecommerce", ""), 0);
         cmbSolicitudesSubTipo.addItem("G", context.GetMessage( "Garantia", ""), 0);
         cmbSolicitudesSubTipo.addItem("M", context.GetMessage( "Mudanza", ""), 0);
         cmbSolicitudesSubTipo.addItem("A", context.GetMessage( "Obra", ""), 0);
         cmbSolicitudesSubTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         cmbSolicitudesSubTipo.addItem("Z", context.GetMessage( "Postulacion", ""), 0);
         cmbSolicitudesSubTipo.addItem("S", context.GetMessage( "Subasta Web", ""), 0);
         cmbSolicitudesSubTipo.addItem("P", context.GetMessage( "Postulacion Web", ""), 0);
         if ( cmbSolicitudesSubTipo.ItemCount > 0 )
         {
            A600SolicitudesSubTipo = cmbSolicitudesSubTipo.getValidValue(A600SolicitudesSubTipo);
            n600SolicitudesSubTipo = false;
            AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
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

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor T002W41 */
         pr_default.execute(39, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(39) != 101) && ( T002W41_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( T002W41_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(T002W41_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(T002W41_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(T002W41_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])-(T002W41_A180SolicitudItemsComision[0]*T002W41_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(T002W41_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(T002W41_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])+(T002W41_A180SolicitudItemsComision[0]*T002W41_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(T002W41_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(T002W41_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])-((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])*(T002W41_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(T002W41_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(T002W41_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])+((T002W41_A176SolicitudesItemsPrecioFinal[0]*T002W41_A177SolicitudesItemsCantidad[0])*(T002W41_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
            pr_default.readNext(39);
         }
         pr_default.close(39);
      }

      public void Valid_Solicitudesid( )
      {
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 18, 2, ".", "")));
      }

      public void Valid_Proveedorid( )
      {
         A440ProveedorPagoDefault = cmbProveedorPagoDefault.CurrentValue;
         cmbProveedorPagoDefault.CurrentValue = A440ProveedorPagoDefault;
         /* Using cursor T002W29 */
         pr_default.execute(27, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
         }
         A282ProveedorNombre = T002W29_A282ProveedorNombre[0];
         A440ProveedorPagoDefault = T002W29_A440ProveedorPagoDefault[0];
         cmbProveedorPagoDefault.CurrentValue = A440ProveedorPagoDefault;
         pr_default.close(27);
         dynload_actions( ) ;
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
            cmbProveedorPagoDefault.CurrentValue = A440ProveedorPagoDefault;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A440ProveedorPagoDefault", StringUtil.RTrim( A440ProveedorPagoDefault));
         cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", cmbProveedorPagoDefault.ToJavascriptSource(), true);
      }

      public void Valid_Departamentoid( )
      {
         n112DepartamentoId = false;
         /* Using cursor T002W30 */
         pr_default.execute(28, new Object[] {n112DepartamentoId, A112DepartamentoId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
            }
         }
         A113DepartamentoDepartamento = T002W30_A113DepartamentoDepartamento[0];
         A116PaisID = T002W30_A116PaisID[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A113DepartamentoDepartamento", StringUtil.RTrim( A113DepartamentoDepartamento));
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
      }

      public void Valid_Departamentomunicipioid( )
      {
         n112DepartamentoId = false;
         n114DepartamentoMunicipioId = false;
         /* Using cursor T002W31 */
         pr_default.execute(29, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
            }
         }
         A115DepartamentoMunicipioNombre = T002W31_A115DepartamentoMunicipioNombre[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A115DepartamentoMunicipioNombre", StringUtil.RTrim( A115DepartamentoMunicipioNombre));
      }

      public void Valid_Zonasid( )
      {
         n110ZonasID = false;
         n112DepartamentoId = false;
         n114DepartamentoMunicipioId = false;
         /* Using cursor T002W42 */
         pr_default.execute(40, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(40) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
            }
         }
         pr_default.close(40);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Stmonedasid( )
      {
         n669STMonedasId = false;
         /* Using cursor T002W32 */
         pr_default.execute(30, new Object[] {n669STMonedasId, A669STMonedasId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( (0==A669STMonedasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "STMonedas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STMONEDASID");
               AnyError = 1;
               GX_FocusControl = edtSTMonedasId_Internalname;
            }
         }
         A671STMonedasISO = T002W32_A671STMonedasISO[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A671STMonedasISO", StringUtil.RTrim( A671STMonedasISO));
      }

      public void Valid_Estadossolid( )
      {
         /* Using cursor T002W33 */
         pr_default.execute(31, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
         }
         A132EstadosSolNombre = T002W33_A132EstadosSolNombre[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A132EstadosSolNombre", StringUtil.RTrim( A132EstadosSolNombre));
      }

      public void Valid_Metodopagosid( )
      {
         /* Using cursor T002W34 */
         pr_default.execute(32, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
         }
         A129MetodoPagosNombre = T002W34_A129MetodoPagosNombre[0];
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A129MetodoPagosNombre", StringUtil.RTrim( A129MetodoPagosNombre));
      }

      public void Valid_Stcomerciosid( )
      {
         n919STComerciosID = false;
         A924STComerciosEstado = cmbSTComerciosEstado.CurrentValue;
         cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         /* Using cursor T002W35 */
         pr_default.execute(33, new Object[] {n919STComerciosID, A919STComerciosID});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( (0==A919STComerciosID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Comercios SubTipo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "STCOMERCIOSID");
               AnyError = 1;
               GX_FocusControl = edtSTComerciosID_Internalname;
            }
         }
         A923STComerciosNombre = T002W35_A923STComerciosNombre[0];
         A924STComerciosEstado = T002W35_A924STComerciosEstado[0];
         cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         pr_default.close(33);
         dynload_actions( ) ;
         if ( cmbSTComerciosEstado.ItemCount > 0 )
         {
            A924STComerciosEstado = cmbSTComerciosEstado.getValidValue(A924STComerciosEstado);
            cmbSTComerciosEstado.CurrentValue = A924STComerciosEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A923STComerciosNombre", StringUtil.RTrim( A923STComerciosNombre));
         AssignAttri("", false, "A924STComerciosEstado", StringUtil.RTrim( A924STComerciosEstado));
         cmbSTComerciosEstado.CurrentValue = StringUtil.RTrim( A924STComerciosEstado);
         AssignProp("", false, cmbSTComerciosEstado_Internalname, "Values", cmbSTComerciosEstado.ToJavascriptSource(), true);
      }

      public void Valid_Mudanzaid( )
      {
         n735MudanzaId = false;
         /* Using cursor T002W36 */
         pr_default.execute(34, new Object[] {n735MudanzaId, A735MudanzaId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A735MudanzaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Mudanza", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MUDANZAID");
               AnyError = 1;
               GX_FocusControl = edtMudanzaId_Internalname;
            }
         }
         A738MudanzaFechaServicio = T002W36_A738MudanzaFechaServicio[0];
         A740MudanzaDireccionOrigen = T002W36_A740MudanzaDireccionOrigen[0];
         A741MudanzaDireccionDestino = T002W36_A741MudanzaDireccionDestino[0];
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A738MudanzaFechaServicio", context.localUtil.Format(A738MudanzaFechaServicio, "99/99/99"));
         AssignAttri("", false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
         AssignAttri("", false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV18Insert_ProveedorID',fld:'vINSERT_PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19Insert_DepartamentoId',fld:'vINSERT_DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20Insert_DepartamentoMunicipioId',fld:'vINSERT_DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21Insert_ZonasID',fld:'vINSERT_ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Insert_STMonedasId',fld:'vINSERT_STMONEDASID',pic:'ZZZ9',type:'int'},{av:'AV23Insert_EstadosSolTipo',fld:'vINSERT_ESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV24Insert_EstadosSolId',fld:'vINSERT_ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'AV25Insert_MetodoPagosID',fld:'vINSERT_METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26Insert_STComerciosID',fld:'vINSERT_STCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27Insert_MudanzaId',fld:'vINSERT_MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1013CuponId',fld:'CUPONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A996CancelacionTipificacionId',fld:'CANCELACIONTIPIFICACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A1016SolicitudesDescuentoCupon',fld:'SOLICITUDESDESCUENTOCUPON',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E122W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A174SolicitudesTotal',fld:'SOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[{av:'A174SolicitudesTotal',fld:'SOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorPagoDefault'},{av:'A440ProveedorPagoDefault',fld:'PROVEEDORPAGODEFAULT',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorPagoDefault'},{av:'A440ProveedorPagoDefault',fld:'PROVEEDORPAGODEFAULT',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESMAIL","{handler:'Valid_Solicitudesmail',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESMAIL",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A115DepartamentoMunicipioNombre',fld:'DEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[{av:'A115DepartamentoMunicipioNombre',fld:'DEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ZONASID",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_STMONEDASID","{handler:'Valid_Stmonedasid',iparms:[{av:'A669STMonedasId',fld:'STMONEDASID',pic:'ZZZ9',type:'int'},{av:'A671STMonedasISO',fld:'STMONEDASISO',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_STMONEDASID",",oparms:[{av:'A671STMonedasISO',fld:'STMONEDASISO',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION","{handler:'Valid_Solicitudescotizacion',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESTOTAL","{handler:'Valid_Solicitudestotal',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESTOTAL",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL","{handler:'Valid_Solicitudserviciopfinal',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESDESCUENTO","{handler:'Valid_Solicitudesdescuento',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESDESCUENTO",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESCOMISIONMETODOPAGO","{handler:'Valid_Solicitudescomisionmetodopago',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESCOMISIONMETODOPAGO",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A132EstadosSolNombre',fld:'ESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[{av:'A132EstadosSolNombre',fld:'ESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESFECHAALTA","{handler:'Valid_Solicitudesfechaalta',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESFECHAALTA",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESFECHAACTUALIZACION","{handler:'Valid_Solicitudesfechaactualizacion',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESFECHAACTUALIZACION",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESFECHAINSTALACION","{handler:'Valid_Solicitudesfechainstalacion',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESFECHAINSTALACION",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_METODOPAGOSID","{handler:'Valid_Metodopagosid',iparms:[{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A129MetodoPagosNombre',fld:'METODOPAGOSNOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_METODOPAGOSID",",oparms:[{av:'A129MetodoPagosNombre',fld:'METODOPAGOSNOMBRE',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_STCOMERCIOSID","{handler:'Valid_Stcomerciosid',iparms:[{av:'A919STComerciosID',fld:'STCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A923STComerciosNombre',fld:'STCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'cmbSTComerciosEstado'},{av:'A924STComerciosEstado',fld:'STCOMERCIOSESTADO',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_STCOMERCIOSID",",oparms:[{av:'A923STComerciosNombre',fld:'STCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'cmbSTComerciosEstado'},{av:'A924STComerciosEstado',fld:'STCOMERCIOSESTADO',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOORIGENPAGO","{handler:'Valid_Solicitudservicioorigenpago',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOORIGENPAGO",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV","{handler:'Valid_Solicitudserviciocomprov',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP","{handler:'Valid_Solicitudserviciocomprovp',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM","{handler:'Valid_Solicitudserviciocomalm',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP","{handler:'Valid_Solicitudserviciocomalmp',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESSUBTIPO","{handler:'Valid_Solicitudessubtipo',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESSUBTIPO",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZONA","{handler:'Valid_Solicitudescostoxzona',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZONA",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM","{handler:'Valid_Solicitudescostoxzcomalm',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALMP","{handler:'Valid_Solicitudescostoxzcomalmp',iparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALMP",",oparms:[{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_MUDANZAID","{handler:'Valid_Mudanzaid',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A738MudanzaFechaServicio',fld:'MUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'A740MudanzaDireccionOrigen',fld:'MUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'A741MudanzaDireccionDestino',fld:'MUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_MUDANZAID",",oparms:[{av:'A738MudanzaFechaServicio',fld:'MUDANZAFECHASERVICIO',pic:'',type:'date'},{av:'A740MudanzaDireccionOrigen',fld:'MUDANZADIRECCIONORIGEN',pic:'',type:'svchar'},{av:'A741MudanzaDireccionDestino',fld:'MUDANZADIRECCIONDESTINO',pic:'',type:'svchar'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'}]}");
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
         pr_default.close(28);
         pr_default.close(29);
         pr_default.close(40);
         pr_default.close(32);
         pr_default.close(34);
         pr_default.close(27);
         pr_default.close(33);
         pr_default.close(31);
         pr_default.close(30);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z171SolicitudesNombre = "";
         Z533ProveedorNombreAux = "";
         Z172SolicitudesTelefono = "";
         Z206SolicitudesMail = "";
         Z173SolicitudesDireccion = "";
         Z210SolicitudServicioSolCoti = "";
         Z201SolicitudesOtros1 = "";
         Z202SolicitudesOtros2 = "";
         Z203SolicitudesOtros3 = "";
         Z182SolicitudesFechaAlta = DateTime.MinValue;
         Z204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z184SolicitudesFechaInstalacion = DateTime.MinValue;
         Z183SolicitudesHoraInstalacion = "";
         Z261SolicitudesNota = "";
         Z262SolicitudesNotificacion = "";
         Z438SolicitudServicioOrigenPago = "";
         Z441SolicitudesPagado = "";
         Z600SolicitudesSubTipo = "";
         Z130EstadosSolTipo = "";
         N130EstadosSolTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A130EstadosSolTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A210SolicitudServicioSolCoti = "";
         A201SolicitudesOtros1 = "";
         A262SolicitudesNotificacion = "";
         A440ProveedorPagoDefault = "";
         A924STComerciosEstado = "";
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         A600SolicitudesSubTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A171SolicitudesNombre = "";
         imgprompt_133_gximage = "";
         sImgUrl = "";
         A282ProveedorNombre = "";
         A533ProveedorNombreAux = "";
         gxphoneLink = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A116PaisID = "";
         imgprompt_112_gximage = "";
         A113DepartamentoDepartamento = "";
         imgprompt_114_gximage = "";
         A115DepartamentoMunicipioNombre = "";
         imgprompt_110_gximage = "";
         A173SolicitudesDireccion = "";
         imgprompt_669_gximage = "";
         A671STMonedasISO = "";
         imgprompt_130_131_gximage = "";
         A132EstadosSolNombre = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A205SolicitudesComentario = "";
         imgprompt_128_gximage = "";
         A129MetodoPagosNombre = "";
         A261SolicitudesNota = "";
         imgprompt_919_gximage = "";
         A923STComerciosNombre = "";
         imgprompt_735_gximage = "";
         A738MudanzaFechaServicio = DateTime.MinValue;
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23Insert_EstadosSolTipo = "";
         AV28Pgmname = "";
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
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z205SolicitudesComentario = "";
         Z282ProveedorNombre = "";
         Z440ProveedorPagoDefault = "";
         Z113DepartamentoDepartamento = "";
         Z116PaisID = "";
         Z115DepartamentoMunicipioNombre = "";
         Z671STMonedasISO = "";
         Z132EstadosSolNombre = "";
         Z129MetodoPagosNombre = "";
         Z923STComerciosNombre = "";
         Z924STComerciosEstado = "";
         Z738MudanzaFechaServicio = DateTime.MinValue;
         Z740MudanzaDireccionOrigen = "";
         Z741MudanzaDireccionDestino = "";
         T002W8_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         T002W8_A740MudanzaDireccionOrigen = new string[] {""} ;
         T002W8_A741MudanzaDireccionDestino = new string[] {""} ;
         T002W10_A923STComerciosNombre = new string[] {""} ;
         T002W10_A924STComerciosEstado = new string[] {""} ;
         T002W7_A129MetodoPagosNombre = new string[] {""} ;
         T002W11_A132EstadosSolNombre = new string[] {""} ;
         T002W12_A671STMonedasISO = new string[] {""} ;
         T002W4_A113DepartamentoDepartamento = new string[] {""} ;
         T002W4_A116PaisID = new string[] {""} ;
         T002W5_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T002W9_A282ProveedorNombre = new string[] {""} ;
         T002W9_A440ProveedorPagoDefault = new string[] {""} ;
         T002W13_A127SolicitudesID = new long[1] ;
         T002W13_A171SolicitudesNombre = new string[] {""} ;
         T002W13_A282ProveedorNombre = new string[] {""} ;
         T002W13_A533ProveedorNombreAux = new string[] {""} ;
         T002W13_n533ProveedorNombreAux = new bool[] {false} ;
         T002W13_A172SolicitudesTelefono = new string[] {""} ;
         T002W13_A206SolicitudesMail = new string[] {""} ;
         T002W13_n206SolicitudesMail = new bool[] {false} ;
         T002W13_A113DepartamentoDepartamento = new string[] {""} ;
         T002W13_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T002W13_A173SolicitudesDireccion = new string[] {""} ;
         T002W13_A194SolicitudesAutoEnumerar = new short[1] ;
         T002W13_A671STMonedasISO = new string[] {""} ;
         T002W13_A688SolicitudesLiqProf = new long[1] ;
         T002W13_n688SolicitudesLiqProf = new bool[] {false} ;
         T002W13_A689SolicitudesLiqProv = new long[1] ;
         T002W13_n689SolicitudesLiqProv = new bool[] {false} ;
         T002W13_A212SolicitudesCotizacion = new decimal[1] ;
         T002W13_A210SolicitudServicioSolCoti = new string[] {""} ;
         T002W13_A897SolicitudesDescuento = new decimal[1] ;
         T002W13_n897SolicitudesDescuento = new bool[] {false} ;
         T002W13_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         T002W13_A132EstadosSolNombre = new string[] {""} ;
         T002W13_A201SolicitudesOtros1 = new string[] {""} ;
         T002W13_A202SolicitudesOtros2 = new string[] {""} ;
         T002W13_A203SolicitudesOtros3 = new string[] {""} ;
         T002W13_A597SolicitudesUsrAlta = new long[1] ;
         T002W13_n597SolicitudesUsrAlta = new bool[] {false} ;
         T002W13_A598SolicitudesUsrActualizacion = new long[1] ;
         T002W13_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         T002W13_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002W13_n182SolicitudesFechaAlta = new bool[] {false} ;
         T002W13_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T002W13_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         T002W13_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         T002W13_A183SolicitudesHoraInstalacion = new string[] {""} ;
         T002W13_A205SolicitudesComentario = new string[] {""} ;
         T002W13_A129MetodoPagosNombre = new string[] {""} ;
         T002W13_A261SolicitudesNota = new string[] {""} ;
         T002W13_A262SolicitudesNotificacion = new string[] {""} ;
         T002W13_A440ProveedorPagoDefault = new string[] {""} ;
         T002W13_A923STComerciosNombre = new string[] {""} ;
         T002W13_A924STComerciosEstado = new string[] {""} ;
         T002W13_A438SolicitudServicioOrigenPago = new string[] {""} ;
         T002W13_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         T002W13_A441SolicitudesPagado = new string[] {""} ;
         T002W13_n441SolicitudesPagado = new bool[] {false} ;
         T002W13_A527SolicitudServicioComProv = new decimal[1] ;
         T002W13_n527SolicitudServicioComProv = new bool[] {false} ;
         T002W13_A528SolicitudServicioComProvP = new decimal[1] ;
         T002W13_n528SolicitudServicioComProvP = new bool[] {false} ;
         T002W13_A530SolicitudServicioComALM = new decimal[1] ;
         T002W13_n530SolicitudServicioComALM = new bool[] {false} ;
         T002W13_A532SolicitudServicioComALMP = new decimal[1] ;
         T002W13_n532SolicitudServicioComALMP = new bool[] {false} ;
         T002W13_A672SolicitudesCalComi = new bool[] {false} ;
         T002W13_A600SolicitudesSubTipo = new string[] {""} ;
         T002W13_n600SolicitudesSubTipo = new bool[] {false} ;
         T002W13_A864SolicitudesCostoXZona = new decimal[1] ;
         T002W13_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         T002W13_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         T002W13_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         T002W13_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         T002W13_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         T002W13_A740MudanzaDireccionOrigen = new string[] {""} ;
         T002W13_A741MudanzaDireccionDestino = new string[] {""} ;
         T002W13_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         T002W13_A112DepartamentoId = new long[1] ;
         T002W13_n112DepartamentoId = new bool[] {false} ;
         T002W13_A114DepartamentoMunicipioId = new long[1] ;
         T002W13_n114DepartamentoMunicipioId = new bool[] {false} ;
         T002W13_A110ZonasID = new long[1] ;
         T002W13_n110ZonasID = new bool[] {false} ;
         T002W13_A128MetodoPagosID = new long[1] ;
         T002W13_A735MudanzaId = new long[1] ;
         T002W13_n735MudanzaId = new bool[] {false} ;
         T002W13_A133ProveedorID = new long[1] ;
         T002W13_A919STComerciosID = new long[1] ;
         T002W13_n919STComerciosID = new bool[] {false} ;
         T002W13_A996CancelacionTipificacionId = new long[1] ;
         T002W13_A1013CuponId = new long[1] ;
         T002W13_n1013CuponId = new bool[] {false} ;
         T002W13_A130EstadosSolTipo = new string[] {""} ;
         T002W13_A131EstadosSolId = new int[1] ;
         T002W13_A669STMonedasId = new short[1] ;
         T002W13_n669STMonedasId = new bool[] {false} ;
         T002W13_A116PaisID = new string[] {""} ;
         T002W6_A110ZonasID = new long[1] ;
         T002W6_n110ZonasID = new bool[] {false} ;
         T002W14_A282ProveedorNombre = new string[] {""} ;
         T002W14_A440ProveedorPagoDefault = new string[] {""} ;
         T002W15_A113DepartamentoDepartamento = new string[] {""} ;
         T002W15_A116PaisID = new string[] {""} ;
         T002W16_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T002W17_A110ZonasID = new long[1] ;
         T002W17_n110ZonasID = new bool[] {false} ;
         T002W18_A671STMonedasISO = new string[] {""} ;
         T002W19_A132EstadosSolNombre = new string[] {""} ;
         T002W20_A129MetodoPagosNombre = new string[] {""} ;
         T002W21_A923STComerciosNombre = new string[] {""} ;
         T002W21_A924STComerciosEstado = new string[] {""} ;
         T002W22_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         T002W22_A740MudanzaDireccionOrigen = new string[] {""} ;
         T002W22_A741MudanzaDireccionDestino = new string[] {""} ;
         T002W23_A127SolicitudesID = new long[1] ;
         T002W3_A127SolicitudesID = new long[1] ;
         T002W3_A171SolicitudesNombre = new string[] {""} ;
         T002W3_A533ProveedorNombreAux = new string[] {""} ;
         T002W3_n533ProveedorNombreAux = new bool[] {false} ;
         T002W3_A172SolicitudesTelefono = new string[] {""} ;
         T002W3_A206SolicitudesMail = new string[] {""} ;
         T002W3_n206SolicitudesMail = new bool[] {false} ;
         T002W3_A173SolicitudesDireccion = new string[] {""} ;
         T002W3_A194SolicitudesAutoEnumerar = new short[1] ;
         T002W3_A688SolicitudesLiqProf = new long[1] ;
         T002W3_n688SolicitudesLiqProf = new bool[] {false} ;
         T002W3_A689SolicitudesLiqProv = new long[1] ;
         T002W3_n689SolicitudesLiqProv = new bool[] {false} ;
         T002W3_A212SolicitudesCotizacion = new decimal[1] ;
         T002W3_A210SolicitudServicioSolCoti = new string[] {""} ;
         T002W3_A897SolicitudesDescuento = new decimal[1] ;
         T002W3_n897SolicitudesDescuento = new bool[] {false} ;
         T002W3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         T002W3_A201SolicitudesOtros1 = new string[] {""} ;
         T002W3_A202SolicitudesOtros2 = new string[] {""} ;
         T002W3_A203SolicitudesOtros3 = new string[] {""} ;
         T002W3_A597SolicitudesUsrAlta = new long[1] ;
         T002W3_n597SolicitudesUsrAlta = new bool[] {false} ;
         T002W3_A598SolicitudesUsrActualizacion = new long[1] ;
         T002W3_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         T002W3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002W3_n182SolicitudesFechaAlta = new bool[] {false} ;
         T002W3_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T002W3_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         T002W3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         T002W3_A183SolicitudesHoraInstalacion = new string[] {""} ;
         T002W3_A205SolicitudesComentario = new string[] {""} ;
         T002W3_A261SolicitudesNota = new string[] {""} ;
         T002W3_A262SolicitudesNotificacion = new string[] {""} ;
         T002W3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         T002W3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         T002W3_A441SolicitudesPagado = new string[] {""} ;
         T002W3_n441SolicitudesPagado = new bool[] {false} ;
         T002W3_A527SolicitudServicioComProv = new decimal[1] ;
         T002W3_n527SolicitudServicioComProv = new bool[] {false} ;
         T002W3_A528SolicitudServicioComProvP = new decimal[1] ;
         T002W3_n528SolicitudServicioComProvP = new bool[] {false} ;
         T002W3_A530SolicitudServicioComALM = new decimal[1] ;
         T002W3_n530SolicitudServicioComALM = new bool[] {false} ;
         T002W3_A532SolicitudServicioComALMP = new decimal[1] ;
         T002W3_n532SolicitudServicioComALMP = new bool[] {false} ;
         T002W3_A672SolicitudesCalComi = new bool[] {false} ;
         T002W3_A600SolicitudesSubTipo = new string[] {""} ;
         T002W3_n600SolicitudesSubTipo = new bool[] {false} ;
         T002W3_A864SolicitudesCostoXZona = new decimal[1] ;
         T002W3_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         T002W3_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         T002W3_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         T002W3_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         T002W3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         T002W3_A112DepartamentoId = new long[1] ;
         T002W3_n112DepartamentoId = new bool[] {false} ;
         T002W3_A114DepartamentoMunicipioId = new long[1] ;
         T002W3_n114DepartamentoMunicipioId = new bool[] {false} ;
         T002W3_A110ZonasID = new long[1] ;
         T002W3_n110ZonasID = new bool[] {false} ;
         T002W3_A128MetodoPagosID = new long[1] ;
         T002W3_A735MudanzaId = new long[1] ;
         T002W3_n735MudanzaId = new bool[] {false} ;
         T002W3_A133ProveedorID = new long[1] ;
         T002W3_A919STComerciosID = new long[1] ;
         T002W3_n919STComerciosID = new bool[] {false} ;
         T002W3_A996CancelacionTipificacionId = new long[1] ;
         T002W3_A1013CuponId = new long[1] ;
         T002W3_n1013CuponId = new bool[] {false} ;
         T002W3_A130EstadosSolTipo = new string[] {""} ;
         T002W3_A131EstadosSolId = new int[1] ;
         T002W3_A669STMonedasId = new short[1] ;
         T002W3_n669STMonedasId = new bool[] {false} ;
         T002W24_A127SolicitudesID = new long[1] ;
         T002W25_A127SolicitudesID = new long[1] ;
         T002W2_A127SolicitudesID = new long[1] ;
         T002W2_A171SolicitudesNombre = new string[] {""} ;
         T002W2_A533ProveedorNombreAux = new string[] {""} ;
         T002W2_n533ProveedorNombreAux = new bool[] {false} ;
         T002W2_A172SolicitudesTelefono = new string[] {""} ;
         T002W2_A206SolicitudesMail = new string[] {""} ;
         T002W2_n206SolicitudesMail = new bool[] {false} ;
         T002W2_A173SolicitudesDireccion = new string[] {""} ;
         T002W2_A194SolicitudesAutoEnumerar = new short[1] ;
         T002W2_A688SolicitudesLiqProf = new long[1] ;
         T002W2_n688SolicitudesLiqProf = new bool[] {false} ;
         T002W2_A689SolicitudesLiqProv = new long[1] ;
         T002W2_n689SolicitudesLiqProv = new bool[] {false} ;
         T002W2_A212SolicitudesCotizacion = new decimal[1] ;
         T002W2_A210SolicitudServicioSolCoti = new string[] {""} ;
         T002W2_A897SolicitudesDescuento = new decimal[1] ;
         T002W2_n897SolicitudesDescuento = new bool[] {false} ;
         T002W2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         T002W2_A201SolicitudesOtros1 = new string[] {""} ;
         T002W2_A202SolicitudesOtros2 = new string[] {""} ;
         T002W2_A203SolicitudesOtros3 = new string[] {""} ;
         T002W2_A597SolicitudesUsrAlta = new long[1] ;
         T002W2_n597SolicitudesUsrAlta = new bool[] {false} ;
         T002W2_A598SolicitudesUsrActualizacion = new long[1] ;
         T002W2_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         T002W2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T002W2_n182SolicitudesFechaAlta = new bool[] {false} ;
         T002W2_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T002W2_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         T002W2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         T002W2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         T002W2_A205SolicitudesComentario = new string[] {""} ;
         T002W2_A261SolicitudesNota = new string[] {""} ;
         T002W2_A262SolicitudesNotificacion = new string[] {""} ;
         T002W2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         T002W2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         T002W2_A441SolicitudesPagado = new string[] {""} ;
         T002W2_n441SolicitudesPagado = new bool[] {false} ;
         T002W2_A527SolicitudServicioComProv = new decimal[1] ;
         T002W2_n527SolicitudServicioComProv = new bool[] {false} ;
         T002W2_A528SolicitudServicioComProvP = new decimal[1] ;
         T002W2_n528SolicitudServicioComProvP = new bool[] {false} ;
         T002W2_A530SolicitudServicioComALM = new decimal[1] ;
         T002W2_n530SolicitudServicioComALM = new bool[] {false} ;
         T002W2_A532SolicitudServicioComALMP = new decimal[1] ;
         T002W2_n532SolicitudServicioComALMP = new bool[] {false} ;
         T002W2_A672SolicitudesCalComi = new bool[] {false} ;
         T002W2_A600SolicitudesSubTipo = new string[] {""} ;
         T002W2_n600SolicitudesSubTipo = new bool[] {false} ;
         T002W2_A864SolicitudesCostoXZona = new decimal[1] ;
         T002W2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         T002W2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         T002W2_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         T002W2_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         T002W2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         T002W2_A112DepartamentoId = new long[1] ;
         T002W2_n112DepartamentoId = new bool[] {false} ;
         T002W2_A114DepartamentoMunicipioId = new long[1] ;
         T002W2_n114DepartamentoMunicipioId = new bool[] {false} ;
         T002W2_A110ZonasID = new long[1] ;
         T002W2_n110ZonasID = new bool[] {false} ;
         T002W2_A128MetodoPagosID = new long[1] ;
         T002W2_A735MudanzaId = new long[1] ;
         T002W2_n735MudanzaId = new bool[] {false} ;
         T002W2_A133ProveedorID = new long[1] ;
         T002W2_A919STComerciosID = new long[1] ;
         T002W2_n919STComerciosID = new bool[] {false} ;
         T002W2_A996CancelacionTipificacionId = new long[1] ;
         T002W2_A1013CuponId = new long[1] ;
         T002W2_n1013CuponId = new bool[] {false} ;
         T002W2_A130EstadosSolTipo = new string[] {""} ;
         T002W2_A131EstadosSolId = new int[1] ;
         T002W2_A669STMonedasId = new short[1] ;
         T002W2_n669STMonedasId = new bool[] {false} ;
         T002W26_A127SolicitudesID = new long[1] ;
         T002W29_A282ProveedorNombre = new string[] {""} ;
         T002W29_A440ProveedorPagoDefault = new string[] {""} ;
         T002W30_A113DepartamentoDepartamento = new string[] {""} ;
         T002W30_A116PaisID = new string[] {""} ;
         T002W31_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T002W32_A671STMonedasISO = new string[] {""} ;
         T002W33_A132EstadosSolNombre = new string[] {""} ;
         T002W34_A129MetodoPagosNombre = new string[] {""} ;
         T002W35_A923STComerciosNombre = new string[] {""} ;
         T002W35_A924STComerciosEstado = new string[] {""} ;
         T002W36_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         T002W36_A740MudanzaDireccionOrigen = new string[] {""} ;
         T002W36_A741MudanzaDireccionDestino = new string[] {""} ;
         T002W37_A127SolicitudesID = new long[1] ;
         T002W37_A988ArchivoId = new long[1] ;
         T002W38_A127SolicitudesID = new long[1] ;
         T002W38_A140RelacionesId = new long[1] ;
         T002W39_A127SolicitudesID = new long[1] ;
         T002W39_A134SolicitudesItemsID = new short[1] ;
         T002W40_A127SolicitudesID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002W41_A127SolicitudesID = new long[1] ;
         T002W41_A134SolicitudesItemsID = new short[1] ;
         T002W41_A180SolicitudItemsComision = new decimal[1] ;
         T002W41_A179SolicitudItemsComisionTipo = new string[] {""} ;
         T002W41_A178SolicitudItemsSR = new string[] {""} ;
         T002W41_A177SolicitudesItemsCantidad = new short[1] ;
         T002W41_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         T002W41_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         T002W42_A110ZonasID = new long[1] ;
         T002W42_n110ZonasID = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.solicitudesreporte__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesreporte__default(),
            new Object[][] {
                new Object[] {
               T002W2_A127SolicitudesID, T002W2_A171SolicitudesNombre, T002W2_A533ProveedorNombreAux, T002W2_n533ProveedorNombreAux, T002W2_A172SolicitudesTelefono, T002W2_A206SolicitudesMail, T002W2_n206SolicitudesMail, T002W2_A173SolicitudesDireccion, T002W2_A194SolicitudesAutoEnumerar, T002W2_A688SolicitudesLiqProf,
               T002W2_n688SolicitudesLiqProf, T002W2_A689SolicitudesLiqProv, T002W2_n689SolicitudesLiqProv, T002W2_A212SolicitudesCotizacion, T002W2_A210SolicitudServicioSolCoti, T002W2_A897SolicitudesDescuento, T002W2_n897SolicitudesDescuento, T002W2_A796SolicitudesComisionMetodoPago, T002W2_A201SolicitudesOtros1, T002W2_A202SolicitudesOtros2,
               T002W2_A203SolicitudesOtros3, T002W2_A597SolicitudesUsrAlta, T002W2_n597SolicitudesUsrAlta, T002W2_A598SolicitudesUsrActualizacion, T002W2_n598SolicitudesUsrActualizacion, T002W2_A182SolicitudesFechaAlta, T002W2_n182SolicitudesFechaAlta, T002W2_A204SolicitudesFechaActualizacion, T002W2_n204SolicitudesFechaActualizacion, T002W2_A184SolicitudesFechaInstalacion,
               T002W2_A183SolicitudesHoraInstalacion, T002W2_A205SolicitudesComentario, T002W2_A261SolicitudesNota, T002W2_A262SolicitudesNotificacion, T002W2_A438SolicitudServicioOrigenPago, T002W2_n438SolicitudServicioOrigenPago, T002W2_A441SolicitudesPagado, T002W2_n441SolicitudesPagado, T002W2_A527SolicitudServicioComProv, T002W2_n527SolicitudServicioComProv,
               T002W2_A528SolicitudServicioComProvP, T002W2_n528SolicitudServicioComProvP, T002W2_A530SolicitudServicioComALM, T002W2_n530SolicitudServicioComALM, T002W2_A532SolicitudServicioComALMP, T002W2_n532SolicitudServicioComALMP, T002W2_A672SolicitudesCalComi, T002W2_A600SolicitudesSubTipo, T002W2_n600SolicitudesSubTipo, T002W2_A864SolicitudesCostoXZona,
               T002W2_A865SolicitudesCostoXZComAlm, T002W2_n865SolicitudesCostoXZComAlm, T002W2_A866SolicitudesCostoXZComAlmP, T002W2_n866SolicitudesCostoXZComAlmP, T002W2_A1016SolicitudesDescuentoCupon, T002W2_A112DepartamentoId, T002W2_n112DepartamentoId, T002W2_A114DepartamentoMunicipioId, T002W2_n114DepartamentoMunicipioId, T002W2_A110ZonasID,
               T002W2_n110ZonasID, T002W2_A128MetodoPagosID, T002W2_A735MudanzaId, T002W2_n735MudanzaId, T002W2_A133ProveedorID, T002W2_A919STComerciosID, T002W2_n919STComerciosID, T002W2_A996CancelacionTipificacionId, T002W2_A1013CuponId, T002W2_n1013CuponId,
               T002W2_A130EstadosSolTipo, T002W2_A131EstadosSolId, T002W2_A669STMonedasId, T002W2_n669STMonedasId
               }
               , new Object[] {
               T002W3_A127SolicitudesID, T002W3_A171SolicitudesNombre, T002W3_A533ProveedorNombreAux, T002W3_n533ProveedorNombreAux, T002W3_A172SolicitudesTelefono, T002W3_A206SolicitudesMail, T002W3_n206SolicitudesMail, T002W3_A173SolicitudesDireccion, T002W3_A194SolicitudesAutoEnumerar, T002W3_A688SolicitudesLiqProf,
               T002W3_n688SolicitudesLiqProf, T002W3_A689SolicitudesLiqProv, T002W3_n689SolicitudesLiqProv, T002W3_A212SolicitudesCotizacion, T002W3_A210SolicitudServicioSolCoti, T002W3_A897SolicitudesDescuento, T002W3_n897SolicitudesDescuento, T002W3_A796SolicitudesComisionMetodoPago, T002W3_A201SolicitudesOtros1, T002W3_A202SolicitudesOtros2,
               T002W3_A203SolicitudesOtros3, T002W3_A597SolicitudesUsrAlta, T002W3_n597SolicitudesUsrAlta, T002W3_A598SolicitudesUsrActualizacion, T002W3_n598SolicitudesUsrActualizacion, T002W3_A182SolicitudesFechaAlta, T002W3_n182SolicitudesFechaAlta, T002W3_A204SolicitudesFechaActualizacion, T002W3_n204SolicitudesFechaActualizacion, T002W3_A184SolicitudesFechaInstalacion,
               T002W3_A183SolicitudesHoraInstalacion, T002W3_A205SolicitudesComentario, T002W3_A261SolicitudesNota, T002W3_A262SolicitudesNotificacion, T002W3_A438SolicitudServicioOrigenPago, T002W3_n438SolicitudServicioOrigenPago, T002W3_A441SolicitudesPagado, T002W3_n441SolicitudesPagado, T002W3_A527SolicitudServicioComProv, T002W3_n527SolicitudServicioComProv,
               T002W3_A528SolicitudServicioComProvP, T002W3_n528SolicitudServicioComProvP, T002W3_A530SolicitudServicioComALM, T002W3_n530SolicitudServicioComALM, T002W3_A532SolicitudServicioComALMP, T002W3_n532SolicitudServicioComALMP, T002W3_A672SolicitudesCalComi, T002W3_A600SolicitudesSubTipo, T002W3_n600SolicitudesSubTipo, T002W3_A864SolicitudesCostoXZona,
               T002W3_A865SolicitudesCostoXZComAlm, T002W3_n865SolicitudesCostoXZComAlm, T002W3_A866SolicitudesCostoXZComAlmP, T002W3_n866SolicitudesCostoXZComAlmP, T002W3_A1016SolicitudesDescuentoCupon, T002W3_A112DepartamentoId, T002W3_n112DepartamentoId, T002W3_A114DepartamentoMunicipioId, T002W3_n114DepartamentoMunicipioId, T002W3_A110ZonasID,
               T002W3_n110ZonasID, T002W3_A128MetodoPagosID, T002W3_A735MudanzaId, T002W3_n735MudanzaId, T002W3_A133ProveedorID, T002W3_A919STComerciosID, T002W3_n919STComerciosID, T002W3_A996CancelacionTipificacionId, T002W3_A1013CuponId, T002W3_n1013CuponId,
               T002W3_A130EstadosSolTipo, T002W3_A131EstadosSolId, T002W3_A669STMonedasId, T002W3_n669STMonedasId
               }
               , new Object[] {
               T002W4_A113DepartamentoDepartamento, T002W4_A116PaisID
               }
               , new Object[] {
               T002W5_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T002W6_A110ZonasID
               }
               , new Object[] {
               T002W7_A129MetodoPagosNombre
               }
               , new Object[] {
               T002W8_A738MudanzaFechaServicio, T002W8_A740MudanzaDireccionOrigen, T002W8_A741MudanzaDireccionDestino
               }
               , new Object[] {
               T002W9_A282ProveedorNombre, T002W9_A440ProveedorPagoDefault
               }
               , new Object[] {
               T002W10_A923STComerciosNombre, T002W10_A924STComerciosEstado
               }
               , new Object[] {
               T002W11_A132EstadosSolNombre
               }
               , new Object[] {
               T002W12_A671STMonedasISO
               }
               , new Object[] {
               T002W13_A127SolicitudesID, T002W13_A171SolicitudesNombre, T002W13_A282ProveedorNombre, T002W13_A533ProveedorNombreAux, T002W13_n533ProveedorNombreAux, T002W13_A172SolicitudesTelefono, T002W13_A206SolicitudesMail, T002W13_n206SolicitudesMail, T002W13_A113DepartamentoDepartamento, T002W13_A115DepartamentoMunicipioNombre,
               T002W13_A173SolicitudesDireccion, T002W13_A194SolicitudesAutoEnumerar, T002W13_A671STMonedasISO, T002W13_A688SolicitudesLiqProf, T002W13_n688SolicitudesLiqProf, T002W13_A689SolicitudesLiqProv, T002W13_n689SolicitudesLiqProv, T002W13_A212SolicitudesCotizacion, T002W13_A210SolicitudServicioSolCoti, T002W13_A897SolicitudesDescuento,
               T002W13_n897SolicitudesDescuento, T002W13_A796SolicitudesComisionMetodoPago, T002W13_A132EstadosSolNombre, T002W13_A201SolicitudesOtros1, T002W13_A202SolicitudesOtros2, T002W13_A203SolicitudesOtros3, T002W13_A597SolicitudesUsrAlta, T002W13_n597SolicitudesUsrAlta, T002W13_A598SolicitudesUsrActualizacion, T002W13_n598SolicitudesUsrActualizacion,
               T002W13_A182SolicitudesFechaAlta, T002W13_n182SolicitudesFechaAlta, T002W13_A204SolicitudesFechaActualizacion, T002W13_n204SolicitudesFechaActualizacion, T002W13_A184SolicitudesFechaInstalacion, T002W13_A183SolicitudesHoraInstalacion, T002W13_A205SolicitudesComentario, T002W13_A129MetodoPagosNombre, T002W13_A261SolicitudesNota, T002W13_A262SolicitudesNotificacion,
               T002W13_A440ProveedorPagoDefault, T002W13_A923STComerciosNombre, T002W13_A924STComerciosEstado, T002W13_A438SolicitudServicioOrigenPago, T002W13_n438SolicitudServicioOrigenPago, T002W13_A441SolicitudesPagado, T002W13_n441SolicitudesPagado, T002W13_A527SolicitudServicioComProv, T002W13_n527SolicitudServicioComProv, T002W13_A528SolicitudServicioComProvP,
               T002W13_n528SolicitudServicioComProvP, T002W13_A530SolicitudServicioComALM, T002W13_n530SolicitudServicioComALM, T002W13_A532SolicitudServicioComALMP, T002W13_n532SolicitudServicioComALMP, T002W13_A672SolicitudesCalComi, T002W13_A600SolicitudesSubTipo, T002W13_n600SolicitudesSubTipo, T002W13_A864SolicitudesCostoXZona, T002W13_A865SolicitudesCostoXZComAlm,
               T002W13_n865SolicitudesCostoXZComAlm, T002W13_A866SolicitudesCostoXZComAlmP, T002W13_n866SolicitudesCostoXZComAlmP, T002W13_A738MudanzaFechaServicio, T002W13_A740MudanzaDireccionOrigen, T002W13_A741MudanzaDireccionDestino, T002W13_A1016SolicitudesDescuentoCupon, T002W13_A112DepartamentoId, T002W13_n112DepartamentoId, T002W13_A114DepartamentoMunicipioId,
               T002W13_n114DepartamentoMunicipioId, T002W13_A110ZonasID, T002W13_n110ZonasID, T002W13_A128MetodoPagosID, T002W13_A735MudanzaId, T002W13_n735MudanzaId, T002W13_A133ProveedorID, T002W13_A919STComerciosID, T002W13_n919STComerciosID, T002W13_A996CancelacionTipificacionId,
               T002W13_A1013CuponId, T002W13_n1013CuponId, T002W13_A130EstadosSolTipo, T002W13_A131EstadosSolId, T002W13_A669STMonedasId, T002W13_n669STMonedasId, T002W13_A116PaisID
               }
               , new Object[] {
               T002W14_A282ProveedorNombre, T002W14_A440ProveedorPagoDefault
               }
               , new Object[] {
               T002W15_A113DepartamentoDepartamento, T002W15_A116PaisID
               }
               , new Object[] {
               T002W16_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T002W17_A110ZonasID
               }
               , new Object[] {
               T002W18_A671STMonedasISO
               }
               , new Object[] {
               T002W19_A132EstadosSolNombre
               }
               , new Object[] {
               T002W20_A129MetodoPagosNombre
               }
               , new Object[] {
               T002W21_A923STComerciosNombre, T002W21_A924STComerciosEstado
               }
               , new Object[] {
               T002W22_A738MudanzaFechaServicio, T002W22_A740MudanzaDireccionOrigen, T002W22_A741MudanzaDireccionDestino
               }
               , new Object[] {
               T002W23_A127SolicitudesID
               }
               , new Object[] {
               T002W24_A127SolicitudesID
               }
               , new Object[] {
               T002W25_A127SolicitudesID
               }
               , new Object[] {
               T002W26_A127SolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002W29_A282ProveedorNombre, T002W29_A440ProveedorPagoDefault
               }
               , new Object[] {
               T002W30_A113DepartamentoDepartamento, T002W30_A116PaisID
               }
               , new Object[] {
               T002W31_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T002W32_A671STMonedasISO
               }
               , new Object[] {
               T002W33_A132EstadosSolNombre
               }
               , new Object[] {
               T002W34_A129MetodoPagosNombre
               }
               , new Object[] {
               T002W35_A923STComerciosNombre, T002W35_A924STComerciosEstado
               }
               , new Object[] {
               T002W36_A738MudanzaFechaServicio, T002W36_A740MudanzaDireccionOrigen, T002W36_A741MudanzaDireccionDestino
               }
               , new Object[] {
               T002W37_A127SolicitudesID, T002W37_A988ArchivoId
               }
               , new Object[] {
               T002W38_A127SolicitudesID, T002W38_A140RelacionesId
               }
               , new Object[] {
               T002W39_A127SolicitudesID, T002W39_A134SolicitudesItemsID
               }
               , new Object[] {
               T002W40_A127SolicitudesID
               }
               , new Object[] {
               T002W41_A127SolicitudesID, T002W41_A134SolicitudesItemsID, T002W41_A180SolicitudItemsComision, T002W41_A179SolicitudItemsComisionTipo, T002W41_A178SolicitudItemsSR, T002W41_A177SolicitudesItemsCantidad, T002W41_A176SolicitudesItemsPrecioFinal, T002W41_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               T002W42_A110ZonasID
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
         AV28Pgmname = "SolicitudesReporte";
      }

      private short Z194SolicitudesAutoEnumerar ;
      private short Z669STMonedasId ;
      private short N669STMonedasId ;
      private short GxWebError ;
      private short A669STMonedasId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A194SolicitudesAutoEnumerar ;
      private short AV22Insert_STMonedasId ;
      private short Gx_BScreen ;
      private short RcdFound30 ;
      private short gxajaxcallmode ;
      private int Z131EstadosSolId ;
      private int N131EstadosSolId ;
      private int A131EstadosSolId ;
      private int trnEnded ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtProveedorID_Enabled ;
      private int imgprompt_133_Visible ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorNombreAux_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesMail_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int imgprompt_112_Visible ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int imgprompt_114_Visible ;
      private int edtDepartamentoMunicipioNombre_Enabled ;
      private int edtZonasID_Enabled ;
      private int imgprompt_110_Visible ;
      private int edtSolicitudesDireccion_Enabled ;
      private int edtSolicitudesAutoEnumerar_Enabled ;
      private int edtSTMonedasId_Enabled ;
      private int imgprompt_669_Visible ;
      private int edtSTMonedasISO_Enabled ;
      private int edtSolicitudesLiqProf_Enabled ;
      private int edtSolicitudesLiqProv_Enabled ;
      private int edtSolicitudesCotizacion_Enabled ;
      private int edtSolicitudesTotal_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtSolicitudesDescuento_Enabled ;
      private int edtSolicitudesComisionMetodoPago_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int imgprompt_130_131_Visible ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtSolicitudesOtros2_Enabled ;
      private int edtSolicitudesOtros3_Enabled ;
      private int edtSolicitudesUsrAlta_Enabled ;
      private int edtSolicitudesUsrActualizacion_Enabled ;
      private int edtSolicitudesFechaAlta_Enabled ;
      private int edtSolicitudesFechaActualizacion_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtSolicitudesHoraInstalacion_Enabled ;
      private int edtSolicitudesComentario_Enabled ;
      private int edtMetodoPagosID_Enabled ;
      private int imgprompt_128_Visible ;
      private int edtMetodoPagosNombre_Enabled ;
      private int edtSolicitudesNota_Enabled ;
      private int edtSTComerciosID_Enabled ;
      private int imgprompt_919_Visible ;
      private int edtSTComerciosNombre_Enabled ;
      private int edtSolicitudServicioComProv_Enabled ;
      private int edtSolicitudServicioComProvP_Enabled ;
      private int edtSolicitudServicioComALM_Enabled ;
      private int edtSolicitudServicioComALMP_Enabled ;
      private int edtSolicitudServicioComPro_Enabled ;
      private int edtSolicitudServicioComProP_Enabled ;
      private int edtSolicitudesCostoXZona_Enabled ;
      private int edtSolicitudesCostoXZComAlm_Enabled ;
      private int edtSolicitudesCostoXZComAlmP_Enabled ;
      private int edtSolicitudesCostoXZComProf_Enabled ;
      private int edtSolicitudesCostoXZComProfP_Enabled ;
      private int edtMudanzaId_Enabled ;
      private int imgprompt_735_Visible ;
      private int edtMudanzaFechaServicio_Enabled ;
      private int edtMudanzaDireccionOrigen_Enabled ;
      private int edtMudanzaDireccionDestino_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV24Insert_EstadosSolId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV29GXV1 ;
      private int idxLst ;
      private long wcpOAV7SolicitudesID ;
      private long Z127SolicitudesID ;
      private long Z688SolicitudesLiqProf ;
      private long Z689SolicitudesLiqProv ;
      private long Z597SolicitudesUsrAlta ;
      private long Z598SolicitudesUsrActualizacion ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long Z110ZonasID ;
      private long Z128MetodoPagosID ;
      private long Z735MudanzaId ;
      private long Z133ProveedorID ;
      private long Z919STComerciosID ;
      private long Z996CancelacionTipificacionId ;
      private long Z1013CuponId ;
      private long N133ProveedorID ;
      private long N112DepartamentoId ;
      private long N114DepartamentoMunicipioId ;
      private long N110ZonasID ;
      private long N128MetodoPagosID ;
      private long N919STComerciosID ;
      private long N735MudanzaId ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A919STComerciosID ;
      private long A735MudanzaId ;
      private long AV7SolicitudesID ;
      private long A127SolicitudesID ;
      private long A688SolicitudesLiqProf ;
      private long A689SolicitudesLiqProv ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A1013CuponId ;
      private long A996CancelacionTipificacionId ;
      private long AV18Insert_ProveedorID ;
      private long AV19Insert_DepartamentoId ;
      private long AV20Insert_DepartamentoMunicipioId ;
      private long AV21Insert_ZonasID ;
      private long AV25Insert_MetodoPagosID ;
      private long AV26Insert_STComerciosID ;
      private long AV27Insert_MudanzaId ;
      private long i1013CuponId ;
      private long i996CancelacionTipificacionId ;
      private decimal Z212SolicitudesCotizacion ;
      private decimal Z897SolicitudesDescuento ;
      private decimal Z796SolicitudesComisionMetodoPago ;
      private decimal Z527SolicitudServicioComProv ;
      private decimal Z528SolicitudServicioComProvP ;
      private decimal Z530SolicitudServicioComALM ;
      private decimal Z532SolicitudServicioComALMP ;
      private decimal Z864SolicitudesCostoXZona ;
      private decimal Z865SolicitudesCostoXZComAlm ;
      private decimal Z866SolicitudesCostoXZComAlmP ;
      private decimal Z1016SolicitudesDescuentoCupon ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A174SolicitudesTotal ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A897SolicitudesDescuento ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A531SolicitudServicioComProP ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A866SolicitudesCostoXZComAlmP ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A868SolicitudesCostoXZComProfP ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal Z174SolicitudesTotal ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z171SolicitudesNombre ;
      private string Z533ProveedorNombreAux ;
      private string Z172SolicitudesTelefono ;
      private string Z210SolicitudServicioSolCoti ;
      private string Z201SolicitudesOtros1 ;
      private string Z202SolicitudesOtros2 ;
      private string Z203SolicitudesOtros3 ;
      private string Z183SolicitudesHoraInstalacion ;
      private string Z261SolicitudesNota ;
      private string Z262SolicitudesNotificacion ;
      private string Z438SolicitudServicioOrigenPago ;
      private string Z441SolicitudesPagado ;
      private string Z600SolicitudesSubTipo ;
      private string Z130EstadosSolTipo ;
      private string N130EstadosSolTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A130EstadosSolTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSolicitudesNombre_Internalname ;
      private string A210SolicitudServicioSolCoti ;
      private string A201SolicitudesOtros1 ;
      private string A262SolicitudesNotificacion ;
      private string cmbSolicitudesNotificacion_Internalname ;
      private string A440ProveedorPagoDefault ;
      private string cmbProveedorPagoDefault_Internalname ;
      private string A924STComerciosEstado ;
      private string cmbSTComerciosEstado_Internalname ;
      private string A438SolicitudServicioOrigenPago ;
      private string cmbSolicitudServicioOrigenPago_Internalname ;
      private string A441SolicitudesPagado ;
      private string cmbSolicitudesPagado_Internalname ;
      private string A600SolicitudesSubTipo ;
      private string cmbSolicitudesSubTipo_Internalname ;
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
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string edtProveedorID_Internalname ;
      private string edtProveedorID_Jsonclick ;
      private string imgprompt_133_gximage ;
      private string sImgUrl ;
      private string imgprompt_133_Internalname ;
      private string imgprompt_133_Link ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorNombreAux_Internalname ;
      private string A533ProveedorNombreAux ;
      private string edtProveedorNombreAux_Jsonclick ;
      private string edtSolicitudesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesMail_Internalname ;
      private string edtSolicitudesMail_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string imgprompt_112_gximage ;
      private string imgprompt_112_Internalname ;
      private string imgprompt_112_Link ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string imgprompt_114_gximage ;
      private string imgprompt_114_Internalname ;
      private string imgprompt_114_Link ;
      private string edtDepartamentoMunicipioNombre_Internalname ;
      private string A115DepartamentoMunicipioNombre ;
      private string edtDepartamentoMunicipioNombre_Jsonclick ;
      private string edtZonasID_Internalname ;
      private string edtZonasID_Jsonclick ;
      private string imgprompt_110_gximage ;
      private string imgprompt_110_Internalname ;
      private string imgprompt_110_Link ;
      private string edtSolicitudesDireccion_Internalname ;
      private string edtSolicitudesAutoEnumerar_Internalname ;
      private string edtSolicitudesAutoEnumerar_Jsonclick ;
      private string edtSTMonedasId_Internalname ;
      private string edtSTMonedasId_Jsonclick ;
      private string imgprompt_669_gximage ;
      private string imgprompt_669_Internalname ;
      private string imgprompt_669_Link ;
      private string edtSTMonedasISO_Internalname ;
      private string A671STMonedasISO ;
      private string edtSTMonedasISO_Jsonclick ;
      private string edtSolicitudesLiqProf_Internalname ;
      private string edtSolicitudesLiqProf_Jsonclick ;
      private string edtSolicitudesLiqProv_Internalname ;
      private string edtSolicitudesLiqProv_Jsonclick ;
      private string edtSolicitudesCotizacion_Internalname ;
      private string edtSolicitudesCotizacion_Jsonclick ;
      private string edtSolicitudesTotal_Internalname ;
      private string edtSolicitudesTotal_Jsonclick ;
      private string chkSolicitudServicioSolCoti_Internalname ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string edtSolicitudesDescuento_Internalname ;
      private string edtSolicitudesDescuento_Jsonclick ;
      private string edtSolicitudesComisionMetodoPago_Internalname ;
      private string edtSolicitudesComisionMetodoPago_Jsonclick ;
      private string edtEstadosSolTipo_Internalname ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolId_Internalname ;
      private string edtEstadosSolId_Jsonclick ;
      private string imgprompt_130_131_gximage ;
      private string imgprompt_130_131_Internalname ;
      private string imgprompt_130_131_Link ;
      private string edtEstadosSolNombre_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string chkSolicitudesOtros1_Internalname ;
      private string edtSolicitudesOtros2_Internalname ;
      private string A202SolicitudesOtros2 ;
      private string edtSolicitudesOtros3_Internalname ;
      private string A203SolicitudesOtros3 ;
      private string edtSolicitudesUsrAlta_Internalname ;
      private string edtSolicitudesUsrAlta_Jsonclick ;
      private string edtSolicitudesUsrActualizacion_Internalname ;
      private string edtSolicitudesUsrActualizacion_Jsonclick ;
      private string edtSolicitudesFechaAlta_Internalname ;
      private string edtSolicitudesFechaAlta_Jsonclick ;
      private string edtSolicitudesFechaActualizacion_Internalname ;
      private string edtSolicitudesFechaActualizacion_Jsonclick ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string edtSolicitudesHoraInstalacion_Internalname ;
      private string A183SolicitudesHoraInstalacion ;
      private string edtSolicitudesHoraInstalacion_Jsonclick ;
      private string edtSolicitudesComentario_Internalname ;
      private string edtMetodoPagosID_Internalname ;
      private string edtMetodoPagosID_Jsonclick ;
      private string imgprompt_128_gximage ;
      private string imgprompt_128_Internalname ;
      private string imgprompt_128_Link ;
      private string edtMetodoPagosNombre_Internalname ;
      private string A129MetodoPagosNombre ;
      private string edtMetodoPagosNombre_Jsonclick ;
      private string edtSolicitudesNota_Internalname ;
      private string A261SolicitudesNota ;
      private string cmbSolicitudesNotificacion_Jsonclick ;
      private string cmbProveedorPagoDefault_Jsonclick ;
      private string edtSTComerciosID_Internalname ;
      private string edtSTComerciosID_Jsonclick ;
      private string imgprompt_919_gximage ;
      private string imgprompt_919_Internalname ;
      private string imgprompt_919_Link ;
      private string edtSTComerciosNombre_Internalname ;
      private string A923STComerciosNombre ;
      private string edtSTComerciosNombre_Jsonclick ;
      private string cmbSTComerciosEstado_Jsonclick ;
      private string cmbSolicitudServicioOrigenPago_Jsonclick ;
      private string cmbSolicitudesPagado_Jsonclick ;
      private string edtSolicitudServicioComProv_Internalname ;
      private string edtSolicitudServicioComProv_Jsonclick ;
      private string edtSolicitudServicioComProvP_Internalname ;
      private string edtSolicitudServicioComProvP_Jsonclick ;
      private string edtSolicitudServicioComALM_Internalname ;
      private string edtSolicitudServicioComALM_Jsonclick ;
      private string edtSolicitudServicioComALMP_Internalname ;
      private string edtSolicitudServicioComALMP_Jsonclick ;
      private string edtSolicitudServicioComPro_Internalname ;
      private string edtSolicitudServicioComPro_Jsonclick ;
      private string edtSolicitudServicioComProP_Internalname ;
      private string edtSolicitudServicioComProP_Jsonclick ;
      private string chkSolicitudesCalComi_Internalname ;
      private string cmbSolicitudesSubTipo_Jsonclick ;
      private string edtSolicitudesCostoXZona_Internalname ;
      private string edtSolicitudesCostoXZona_Jsonclick ;
      private string edtSolicitudesCostoXZComAlm_Internalname ;
      private string edtSolicitudesCostoXZComAlm_Jsonclick ;
      private string edtSolicitudesCostoXZComAlmP_Internalname ;
      private string edtSolicitudesCostoXZComAlmP_Jsonclick ;
      private string edtSolicitudesCostoXZComProf_Internalname ;
      private string edtSolicitudesCostoXZComProf_Jsonclick ;
      private string edtSolicitudesCostoXZComProfP_Internalname ;
      private string edtSolicitudesCostoXZComProfP_Jsonclick ;
      private string edtMudanzaId_Internalname ;
      private string edtMudanzaId_Jsonclick ;
      private string imgprompt_735_gximage ;
      private string imgprompt_735_Internalname ;
      private string imgprompt_735_Link ;
      private string edtMudanzaFechaServicio_Internalname ;
      private string edtMudanzaFechaServicio_Jsonclick ;
      private string edtMudanzaDireccionOrigen_Internalname ;
      private string edtMudanzaDireccionDestino_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV23Insert_EstadosSolTipo ;
      private string AV28Pgmname ;
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
      private string GXEncryptionTmp ;
      private string Z282ProveedorNombre ;
      private string Z440ProveedorPagoDefault ;
      private string Z113DepartamentoDepartamento ;
      private string Z116PaisID ;
      private string Z115DepartamentoMunicipioNombre ;
      private string Z671STMonedasISO ;
      private string Z132EstadosSolNombre ;
      private string Z129MetodoPagosNombre ;
      private string Z923STComerciosNombre ;
      private string Z924STComerciosEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z204SolicitudesFechaActualizacion ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime Z182SolicitudesFechaAlta ;
      private DateTime Z184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A738MudanzaFechaServicio ;
      private DateTime Z738MudanzaFechaServicio ;
      private bool Z672SolicitudesCalComi ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n669STMonedasId ;
      private bool n919STComerciosID ;
      private bool n735MudanzaId ;
      private bool wbErr ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool A672SolicitudesCalComi ;
      private bool n600SolicitudesSubTipo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n533ProveedorNombreAux ;
      private bool n206SolicitudesMail ;
      private bool n688SolicitudesLiqProf ;
      private bool n689SolicitudesLiqProv ;
      private bool n897SolicitudesDescuento ;
      private bool n597SolicitudesUsrAlta ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n182SolicitudesFechaAlta ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n527SolicitudServicioComProv ;
      private bool n528SolicitudServicioComProvP ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n866SolicitudesCostoXZComAlmP ;
      private bool n1013CuponId ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string A205SolicitudesComentario ;
      private string Z205SolicitudesComentario ;
      private string Z206SolicitudesMail ;
      private string Z173SolicitudesDireccion ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string Z740MudanzaDireccionOrigen ;
      private string Z741MudanzaDireccionDestino ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSolicitudServicioSolCoti ;
      private GXCheckbox chkSolicitudesOtros1 ;
      private GXCombobox cmbSolicitudesNotificacion ;
      private GXCombobox cmbProveedorPagoDefault ;
      private GXCombobox cmbSTComerciosEstado ;
      private GXCombobox cmbSolicitudServicioOrigenPago ;
      private GXCombobox cmbSolicitudesPagado ;
      private GXCheckbox chkSolicitudesCalComi ;
      private GXCombobox cmbSolicitudesSubTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T002W8_A738MudanzaFechaServicio ;
      private string[] T002W8_A740MudanzaDireccionOrigen ;
      private string[] T002W8_A741MudanzaDireccionDestino ;
      private string[] T002W10_A923STComerciosNombre ;
      private string[] T002W10_A924STComerciosEstado ;
      private string[] T002W7_A129MetodoPagosNombre ;
      private string[] T002W11_A132EstadosSolNombre ;
      private string[] T002W12_A671STMonedasISO ;
      private string[] T002W4_A113DepartamentoDepartamento ;
      private string[] T002W4_A116PaisID ;
      private string[] T002W5_A115DepartamentoMunicipioNombre ;
      private string[] T002W9_A282ProveedorNombre ;
      private string[] T002W9_A440ProveedorPagoDefault ;
      private long[] T002W13_A127SolicitudesID ;
      private string[] T002W13_A171SolicitudesNombre ;
      private string[] T002W13_A282ProveedorNombre ;
      private string[] T002W13_A533ProveedorNombreAux ;
      private bool[] T002W13_n533ProveedorNombreAux ;
      private string[] T002W13_A172SolicitudesTelefono ;
      private string[] T002W13_A206SolicitudesMail ;
      private bool[] T002W13_n206SolicitudesMail ;
      private string[] T002W13_A113DepartamentoDepartamento ;
      private string[] T002W13_A115DepartamentoMunicipioNombre ;
      private string[] T002W13_A173SolicitudesDireccion ;
      private short[] T002W13_A194SolicitudesAutoEnumerar ;
      private string[] T002W13_A671STMonedasISO ;
      private long[] T002W13_A688SolicitudesLiqProf ;
      private bool[] T002W13_n688SolicitudesLiqProf ;
      private long[] T002W13_A689SolicitudesLiqProv ;
      private bool[] T002W13_n689SolicitudesLiqProv ;
      private decimal[] T002W13_A212SolicitudesCotizacion ;
      private string[] T002W13_A210SolicitudServicioSolCoti ;
      private decimal[] T002W13_A897SolicitudesDescuento ;
      private bool[] T002W13_n897SolicitudesDescuento ;
      private decimal[] T002W13_A796SolicitudesComisionMetodoPago ;
      private string[] T002W13_A132EstadosSolNombre ;
      private string[] T002W13_A201SolicitudesOtros1 ;
      private string[] T002W13_A202SolicitudesOtros2 ;
      private string[] T002W13_A203SolicitudesOtros3 ;
      private long[] T002W13_A597SolicitudesUsrAlta ;
      private bool[] T002W13_n597SolicitudesUsrAlta ;
      private long[] T002W13_A598SolicitudesUsrActualizacion ;
      private bool[] T002W13_n598SolicitudesUsrActualizacion ;
      private DateTime[] T002W13_A182SolicitudesFechaAlta ;
      private bool[] T002W13_n182SolicitudesFechaAlta ;
      private DateTime[] T002W13_A204SolicitudesFechaActualizacion ;
      private bool[] T002W13_n204SolicitudesFechaActualizacion ;
      private DateTime[] T002W13_A184SolicitudesFechaInstalacion ;
      private string[] T002W13_A183SolicitudesHoraInstalacion ;
      private string[] T002W13_A205SolicitudesComentario ;
      private string[] T002W13_A129MetodoPagosNombre ;
      private string[] T002W13_A261SolicitudesNota ;
      private string[] T002W13_A262SolicitudesNotificacion ;
      private string[] T002W13_A440ProveedorPagoDefault ;
      private string[] T002W13_A923STComerciosNombre ;
      private string[] T002W13_A924STComerciosEstado ;
      private string[] T002W13_A438SolicitudServicioOrigenPago ;
      private bool[] T002W13_n438SolicitudServicioOrigenPago ;
      private string[] T002W13_A441SolicitudesPagado ;
      private bool[] T002W13_n441SolicitudesPagado ;
      private decimal[] T002W13_A527SolicitudServicioComProv ;
      private bool[] T002W13_n527SolicitudServicioComProv ;
      private decimal[] T002W13_A528SolicitudServicioComProvP ;
      private bool[] T002W13_n528SolicitudServicioComProvP ;
      private decimal[] T002W13_A530SolicitudServicioComALM ;
      private bool[] T002W13_n530SolicitudServicioComALM ;
      private decimal[] T002W13_A532SolicitudServicioComALMP ;
      private bool[] T002W13_n532SolicitudServicioComALMP ;
      private bool[] T002W13_A672SolicitudesCalComi ;
      private string[] T002W13_A600SolicitudesSubTipo ;
      private bool[] T002W13_n600SolicitudesSubTipo ;
      private decimal[] T002W13_A864SolicitudesCostoXZona ;
      private decimal[] T002W13_A865SolicitudesCostoXZComAlm ;
      private bool[] T002W13_n865SolicitudesCostoXZComAlm ;
      private decimal[] T002W13_A866SolicitudesCostoXZComAlmP ;
      private bool[] T002W13_n866SolicitudesCostoXZComAlmP ;
      private DateTime[] T002W13_A738MudanzaFechaServicio ;
      private string[] T002W13_A740MudanzaDireccionOrigen ;
      private string[] T002W13_A741MudanzaDireccionDestino ;
      private decimal[] T002W13_A1016SolicitudesDescuentoCupon ;
      private long[] T002W13_A112DepartamentoId ;
      private bool[] T002W13_n112DepartamentoId ;
      private long[] T002W13_A114DepartamentoMunicipioId ;
      private bool[] T002W13_n114DepartamentoMunicipioId ;
      private long[] T002W13_A110ZonasID ;
      private bool[] T002W13_n110ZonasID ;
      private long[] T002W13_A128MetodoPagosID ;
      private long[] T002W13_A735MudanzaId ;
      private bool[] T002W13_n735MudanzaId ;
      private long[] T002W13_A133ProveedorID ;
      private long[] T002W13_A919STComerciosID ;
      private bool[] T002W13_n919STComerciosID ;
      private long[] T002W13_A996CancelacionTipificacionId ;
      private long[] T002W13_A1013CuponId ;
      private bool[] T002W13_n1013CuponId ;
      private string[] T002W13_A130EstadosSolTipo ;
      private int[] T002W13_A131EstadosSolId ;
      private short[] T002W13_A669STMonedasId ;
      private bool[] T002W13_n669STMonedasId ;
      private string[] T002W13_A116PaisID ;
      private long[] T002W6_A110ZonasID ;
      private bool[] T002W6_n110ZonasID ;
      private string[] T002W14_A282ProveedorNombre ;
      private string[] T002W14_A440ProveedorPagoDefault ;
      private string[] T002W15_A113DepartamentoDepartamento ;
      private string[] T002W15_A116PaisID ;
      private string[] T002W16_A115DepartamentoMunicipioNombre ;
      private long[] T002W17_A110ZonasID ;
      private bool[] T002W17_n110ZonasID ;
      private string[] T002W18_A671STMonedasISO ;
      private string[] T002W19_A132EstadosSolNombre ;
      private string[] T002W20_A129MetodoPagosNombre ;
      private string[] T002W21_A923STComerciosNombre ;
      private string[] T002W21_A924STComerciosEstado ;
      private DateTime[] T002W22_A738MudanzaFechaServicio ;
      private string[] T002W22_A740MudanzaDireccionOrigen ;
      private string[] T002W22_A741MudanzaDireccionDestino ;
      private long[] T002W23_A127SolicitudesID ;
      private long[] T002W3_A127SolicitudesID ;
      private string[] T002W3_A171SolicitudesNombre ;
      private string[] T002W3_A533ProveedorNombreAux ;
      private bool[] T002W3_n533ProveedorNombreAux ;
      private string[] T002W3_A172SolicitudesTelefono ;
      private string[] T002W3_A206SolicitudesMail ;
      private bool[] T002W3_n206SolicitudesMail ;
      private string[] T002W3_A173SolicitudesDireccion ;
      private short[] T002W3_A194SolicitudesAutoEnumerar ;
      private long[] T002W3_A688SolicitudesLiqProf ;
      private bool[] T002W3_n688SolicitudesLiqProf ;
      private long[] T002W3_A689SolicitudesLiqProv ;
      private bool[] T002W3_n689SolicitudesLiqProv ;
      private decimal[] T002W3_A212SolicitudesCotizacion ;
      private string[] T002W3_A210SolicitudServicioSolCoti ;
      private decimal[] T002W3_A897SolicitudesDescuento ;
      private bool[] T002W3_n897SolicitudesDescuento ;
      private decimal[] T002W3_A796SolicitudesComisionMetodoPago ;
      private string[] T002W3_A201SolicitudesOtros1 ;
      private string[] T002W3_A202SolicitudesOtros2 ;
      private string[] T002W3_A203SolicitudesOtros3 ;
      private long[] T002W3_A597SolicitudesUsrAlta ;
      private bool[] T002W3_n597SolicitudesUsrAlta ;
      private long[] T002W3_A598SolicitudesUsrActualizacion ;
      private bool[] T002W3_n598SolicitudesUsrActualizacion ;
      private DateTime[] T002W3_A182SolicitudesFechaAlta ;
      private bool[] T002W3_n182SolicitudesFechaAlta ;
      private DateTime[] T002W3_A204SolicitudesFechaActualizacion ;
      private bool[] T002W3_n204SolicitudesFechaActualizacion ;
      private DateTime[] T002W3_A184SolicitudesFechaInstalacion ;
      private string[] T002W3_A183SolicitudesHoraInstalacion ;
      private string[] T002W3_A205SolicitudesComentario ;
      private string[] T002W3_A261SolicitudesNota ;
      private string[] T002W3_A262SolicitudesNotificacion ;
      private string[] T002W3_A438SolicitudServicioOrigenPago ;
      private bool[] T002W3_n438SolicitudServicioOrigenPago ;
      private string[] T002W3_A441SolicitudesPagado ;
      private bool[] T002W3_n441SolicitudesPagado ;
      private decimal[] T002W3_A527SolicitudServicioComProv ;
      private bool[] T002W3_n527SolicitudServicioComProv ;
      private decimal[] T002W3_A528SolicitudServicioComProvP ;
      private bool[] T002W3_n528SolicitudServicioComProvP ;
      private decimal[] T002W3_A530SolicitudServicioComALM ;
      private bool[] T002W3_n530SolicitudServicioComALM ;
      private decimal[] T002W3_A532SolicitudServicioComALMP ;
      private bool[] T002W3_n532SolicitudServicioComALMP ;
      private bool[] T002W3_A672SolicitudesCalComi ;
      private string[] T002W3_A600SolicitudesSubTipo ;
      private bool[] T002W3_n600SolicitudesSubTipo ;
      private decimal[] T002W3_A864SolicitudesCostoXZona ;
      private decimal[] T002W3_A865SolicitudesCostoXZComAlm ;
      private bool[] T002W3_n865SolicitudesCostoXZComAlm ;
      private decimal[] T002W3_A866SolicitudesCostoXZComAlmP ;
      private bool[] T002W3_n866SolicitudesCostoXZComAlmP ;
      private decimal[] T002W3_A1016SolicitudesDescuentoCupon ;
      private long[] T002W3_A112DepartamentoId ;
      private bool[] T002W3_n112DepartamentoId ;
      private long[] T002W3_A114DepartamentoMunicipioId ;
      private bool[] T002W3_n114DepartamentoMunicipioId ;
      private long[] T002W3_A110ZonasID ;
      private bool[] T002W3_n110ZonasID ;
      private long[] T002W3_A128MetodoPagosID ;
      private long[] T002W3_A735MudanzaId ;
      private bool[] T002W3_n735MudanzaId ;
      private long[] T002W3_A133ProveedorID ;
      private long[] T002W3_A919STComerciosID ;
      private bool[] T002W3_n919STComerciosID ;
      private long[] T002W3_A996CancelacionTipificacionId ;
      private long[] T002W3_A1013CuponId ;
      private bool[] T002W3_n1013CuponId ;
      private string[] T002W3_A130EstadosSolTipo ;
      private int[] T002W3_A131EstadosSolId ;
      private short[] T002W3_A669STMonedasId ;
      private bool[] T002W3_n669STMonedasId ;
      private long[] T002W24_A127SolicitudesID ;
      private long[] T002W25_A127SolicitudesID ;
      private long[] T002W2_A127SolicitudesID ;
      private string[] T002W2_A171SolicitudesNombre ;
      private string[] T002W2_A533ProveedorNombreAux ;
      private bool[] T002W2_n533ProveedorNombreAux ;
      private string[] T002W2_A172SolicitudesTelefono ;
      private string[] T002W2_A206SolicitudesMail ;
      private bool[] T002W2_n206SolicitudesMail ;
      private string[] T002W2_A173SolicitudesDireccion ;
      private short[] T002W2_A194SolicitudesAutoEnumerar ;
      private long[] T002W2_A688SolicitudesLiqProf ;
      private bool[] T002W2_n688SolicitudesLiqProf ;
      private long[] T002W2_A689SolicitudesLiqProv ;
      private bool[] T002W2_n689SolicitudesLiqProv ;
      private decimal[] T002W2_A212SolicitudesCotizacion ;
      private string[] T002W2_A210SolicitudServicioSolCoti ;
      private decimal[] T002W2_A897SolicitudesDescuento ;
      private bool[] T002W2_n897SolicitudesDescuento ;
      private decimal[] T002W2_A796SolicitudesComisionMetodoPago ;
      private string[] T002W2_A201SolicitudesOtros1 ;
      private string[] T002W2_A202SolicitudesOtros2 ;
      private string[] T002W2_A203SolicitudesOtros3 ;
      private long[] T002W2_A597SolicitudesUsrAlta ;
      private bool[] T002W2_n597SolicitudesUsrAlta ;
      private long[] T002W2_A598SolicitudesUsrActualizacion ;
      private bool[] T002W2_n598SolicitudesUsrActualizacion ;
      private DateTime[] T002W2_A182SolicitudesFechaAlta ;
      private bool[] T002W2_n182SolicitudesFechaAlta ;
      private DateTime[] T002W2_A204SolicitudesFechaActualizacion ;
      private bool[] T002W2_n204SolicitudesFechaActualizacion ;
      private DateTime[] T002W2_A184SolicitudesFechaInstalacion ;
      private string[] T002W2_A183SolicitudesHoraInstalacion ;
      private string[] T002W2_A205SolicitudesComentario ;
      private string[] T002W2_A261SolicitudesNota ;
      private string[] T002W2_A262SolicitudesNotificacion ;
      private string[] T002W2_A438SolicitudServicioOrigenPago ;
      private bool[] T002W2_n438SolicitudServicioOrigenPago ;
      private string[] T002W2_A441SolicitudesPagado ;
      private bool[] T002W2_n441SolicitudesPagado ;
      private decimal[] T002W2_A527SolicitudServicioComProv ;
      private bool[] T002W2_n527SolicitudServicioComProv ;
      private decimal[] T002W2_A528SolicitudServicioComProvP ;
      private bool[] T002W2_n528SolicitudServicioComProvP ;
      private decimal[] T002W2_A530SolicitudServicioComALM ;
      private bool[] T002W2_n530SolicitudServicioComALM ;
      private decimal[] T002W2_A532SolicitudServicioComALMP ;
      private bool[] T002W2_n532SolicitudServicioComALMP ;
      private bool[] T002W2_A672SolicitudesCalComi ;
      private string[] T002W2_A600SolicitudesSubTipo ;
      private bool[] T002W2_n600SolicitudesSubTipo ;
      private decimal[] T002W2_A864SolicitudesCostoXZona ;
      private decimal[] T002W2_A865SolicitudesCostoXZComAlm ;
      private bool[] T002W2_n865SolicitudesCostoXZComAlm ;
      private decimal[] T002W2_A866SolicitudesCostoXZComAlmP ;
      private bool[] T002W2_n866SolicitudesCostoXZComAlmP ;
      private decimal[] T002W2_A1016SolicitudesDescuentoCupon ;
      private long[] T002W2_A112DepartamentoId ;
      private bool[] T002W2_n112DepartamentoId ;
      private long[] T002W2_A114DepartamentoMunicipioId ;
      private bool[] T002W2_n114DepartamentoMunicipioId ;
      private long[] T002W2_A110ZonasID ;
      private bool[] T002W2_n110ZonasID ;
      private long[] T002W2_A128MetodoPagosID ;
      private long[] T002W2_A735MudanzaId ;
      private bool[] T002W2_n735MudanzaId ;
      private long[] T002W2_A133ProveedorID ;
      private long[] T002W2_A919STComerciosID ;
      private bool[] T002W2_n919STComerciosID ;
      private long[] T002W2_A996CancelacionTipificacionId ;
      private long[] T002W2_A1013CuponId ;
      private bool[] T002W2_n1013CuponId ;
      private string[] T002W2_A130EstadosSolTipo ;
      private int[] T002W2_A131EstadosSolId ;
      private short[] T002W2_A669STMonedasId ;
      private bool[] T002W2_n669STMonedasId ;
      private long[] T002W26_A127SolicitudesID ;
      private string[] T002W29_A282ProveedorNombre ;
      private string[] T002W29_A440ProveedorPagoDefault ;
      private string[] T002W30_A113DepartamentoDepartamento ;
      private string[] T002W30_A116PaisID ;
      private string[] T002W31_A115DepartamentoMunicipioNombre ;
      private string[] T002W32_A671STMonedasISO ;
      private string[] T002W33_A132EstadosSolNombre ;
      private string[] T002W34_A129MetodoPagosNombre ;
      private string[] T002W35_A923STComerciosNombre ;
      private string[] T002W35_A924STComerciosEstado ;
      private DateTime[] T002W36_A738MudanzaFechaServicio ;
      private string[] T002W36_A740MudanzaDireccionOrigen ;
      private string[] T002W36_A741MudanzaDireccionDestino ;
      private long[] T002W37_A127SolicitudesID ;
      private long[] T002W37_A988ArchivoId ;
      private long[] T002W38_A127SolicitudesID ;
      private long[] T002W38_A140RelacionesId ;
      private long[] T002W39_A127SolicitudesID ;
      private short[] T002W39_A134SolicitudesItemsID ;
      private long[] T002W40_A127SolicitudesID ;
      private long[] T002W41_A127SolicitudesID ;
      private short[] T002W41_A134SolicitudesItemsID ;
      private decimal[] T002W41_A180SolicitudItemsComision ;
      private string[] T002W41_A179SolicitudItemsComisionTipo ;
      private string[] T002W41_A178SolicitudItemsSR ;
      private short[] T002W41_A177SolicitudesItemsCantidad ;
      private decimal[] T002W41_A176SolicitudesItemsPrecioFinal ;
      private bool[] T002W41_n176SolicitudesItemsPrecioFinal ;
      private long[] T002W42_A110ZonasID ;
      private bool[] T002W42_n110ZonasID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class solicitudesreporte__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class solicitudesreporte__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002W2;
        prmT002W2 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W3;
        prmT002W3 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W4;
        prmT002W4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W5;
        prmT002W5 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W6;
        prmT002W6 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W7;
        prmT002W7 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT002W8;
        prmT002W8 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W9;
        prmT002W9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002W10;
        prmT002W10 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W11;
        prmT002W11 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT002W12;
        prmT002W12 = new Object[] {
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002W13;
        prmT002W13 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferT002W13;
        cmdBufferT002W13=" SELECT TM1.[SolicitudesID], TM1.[SolicitudesNombre], T2.[ProveedorNombre], TM1.[ProveedorNombreAux], TM1.[SolicitudesTelefono], TM1.[SolicitudesMail], T3.[DepartamentoDepartamento], T4.[DepartamentoMunicipioNombre], TM1.[SolicitudesDireccion], TM1.[SolicitudesAutoEnumerar], T5.[MonedaISOSimbolo] AS STMonedasISO, TM1.[SolicitudesLiqProf], TM1.[SolicitudesLiqProv], TM1.[SolicitudesCotizacion], TM1.[SolicitudServicioSolCoti], TM1.[SolicitudesDescuento], TM1.[SolicitudesComisionMetodoPago], T6.[EstadosGenericosNombre] AS EstadosSolNombre, TM1.[SolicitudesOtros1], TM1.[SolicitudesOtros2], TM1.[SolicitudesOtros3], TM1.[SolicitudesUsrAlta], TM1.[SolicitudesUsrActualizacion], TM1.[SolicitudesFechaAlta], TM1.[SolicitudesFechaActualizacion], TM1.[SolicitudesFechaInstalacion], TM1.[SolicitudesHoraInstalacion], TM1.[SolicitudesComentario], T7.[MetodoPagosNombre], TM1.[SolicitudesNota], TM1.[SolicitudesNotificacion], T2.[ProveedorPagoDefault], T8.[ProveedorNombre] AS STComerciosNombre, T8.[ProveedorEstado] AS STComerciosEstado, TM1.[SolicitudServicioOrigenPago], TM1.[SolicitudesPagado], TM1.[SolicitudServicioComProv], TM1.[SolicitudServicioComProvP], TM1.[SolicitudServicioComALM], TM1.[SolicitudServicioComALMP], TM1.[SolicitudesCalComi], TM1.[SolicitudesSubTipo], TM1.[SolicitudesCostoXZona], TM1.[SolicitudesCostoXZComAlm], TM1.[SolicitudesCostoXZComAlmP], T9.[MudanzaFechaServicio], T9.[MudanzaDireccionOrigen], T9.[MudanzaDireccionDestino], TM1.[SolicitudesDescuentoCupon], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[ZonasID], TM1.[MetodoPagosID], TM1.[MudanzaId], TM1.[ProveedorID], TM1.[STComerciosID] AS STComerciosID, TM1.[CancelacionTipificacionId], TM1.[CuponId], TM1.[EstadosSolTipo] AS EstadosSolTipo, TM1.[EstadosSolId] AS EstadosSolId, TM1.[STMonedasId] AS STMonedasId, "
        + " T3.[PaisID] FROM (((((((([Solicitudes] TM1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Departamento] T3 ON T3.[DepartamentoId] = TM1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T4 ON T4.[DepartamentoId] = TM1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = TM1.[DepartamentoMunicipioId]) LEFT JOIN [Moneda] T5 ON T5.[MonedaId] = TM1.[STMonedasId]) INNER JOIN [EstadosGenericos] T6 ON T6.[EstadosTipo] = TM1.[EstadosSolTipo] AND T6.[EstadosGenericosId] = TM1.[EstadosSolId]) INNER JOIN [MetodoPagos] T7 ON T7.[MetodoPagosID] = TM1.[MetodoPagosID]) LEFT JOIN [Proveedor] T8 ON T8.[ProveedorID] = TM1.[STComerciosID]) LEFT JOIN [Mudanza] T9 ON T9.[MudanzaId] = TM1.[MudanzaId]) WHERE TM1.[SolicitudesID] = @SolicitudesID ORDER BY TM1.[SolicitudesID]  OPTION (FAST 100)" ;
        Object[] prmT002W14;
        prmT002W14 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002W15;
        prmT002W15 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W16;
        prmT002W16 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W17;
        prmT002W17 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W18;
        prmT002W18 = new Object[] {
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002W19;
        prmT002W19 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT002W20;
        prmT002W20 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT002W21;
        prmT002W21 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W22;
        prmT002W22 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W23;
        prmT002W23 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W24;
        prmT002W24 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W25;
        prmT002W25 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W26;
        prmT002W26 = new Object[] {
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@ProveedorNombreAux",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@SolicitudesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudServicioSolCoti",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesDescuento",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesComisionMetodoPago",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@SolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
        new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@SolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesNotificacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCalComi",GXType.Boolean,4,0) ,
        new ParDef("@SolicitudesSubTipo",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZona",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesCostoXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlmP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesDescuentoCupon",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        string cmdBufferT002W26;
        cmdBufferT002W26=" INSERT INTO [Solicitudes]([SolicitudesNombre], [ProveedorNombreAux], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuentoCupon], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID], [CancelacionTipificacionId], [CuponId], [EstadosSolTipo], [EstadosSolId], [STMonedasId], [PostulacionesId], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [TicketId]) VALUES(@SolicitudesNombre, @ProveedorNombreAux, @SolicitudesTelefono, @SolicitudesMail, @SolicitudesDireccion, @SolicitudesAutoEnumerar, @SolicitudesLiqProf, @SolicitudesLiqProv, @SolicitudesCotizacion, @SolicitudServicioSolCoti, @SolicitudesDescuento, @SolicitudesComisionMetodoPago, @SolicitudesOtros1, @SolicitudesOtros2, @SolicitudesOtros3, @SolicitudesUsrAlta, @SolicitudesUsrActualizacion, @SolicitudesFechaAlta, @SolicitudesFechaActualizacion, @SolicitudesFechaInstalacion, @SolicitudesHoraInstalacion, @SolicitudesComentario, "
        + " @SolicitudesNota, @SolicitudesNotificacion, @SolicitudServicioOrigenPago, @SolicitudesPagado, @SolicitudServicioComProv, @SolicitudServicioComProvP, @SolicitudServicioComALM, @SolicitudServicioComALMP, @SolicitudesCalComi, @SolicitudesSubTipo, @SolicitudesCostoXZona, @SolicitudesCostoXZComAlm, @SolicitudesCostoXZComAlmP, @SolicitudesDescuentoCupon, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID, @MetodoPagosID, @MudanzaId, @ProveedorID, @STComerciosID, @CancelacionTipificacionId, @CuponId, @EstadosSolTipo, @EstadosSolId, @STMonedasId, convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0)); SELECT SCOPE_IDENTITY()" ;
        Object[] prmT002W27;
        prmT002W27 = new Object[] {
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@ProveedorNombreAux",GXType.NChar,80,0){Nullable=true} ,
        new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@SolicitudesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudServicioSolCoti",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesDescuento",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesComisionMetodoPago",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@SolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
        new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@SolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesNotificacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCalComi",GXType.Boolean,4,0) ,
        new ParDef("@SolicitudesSubTipo",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZona",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesCostoXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlmP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesDescuentoCupon",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferT002W27;
        cmdBufferT002W27=" UPDATE [Solicitudes] SET [SolicitudesNombre]=@SolicitudesNombre, [ProveedorNombreAux]=@ProveedorNombreAux, [SolicitudesTelefono]=@SolicitudesTelefono, [SolicitudesMail]=@SolicitudesMail, [SolicitudesDireccion]=@SolicitudesDireccion, [SolicitudesAutoEnumerar]=@SolicitudesAutoEnumerar, [SolicitudesLiqProf]=@SolicitudesLiqProf, [SolicitudesLiqProv]=@SolicitudesLiqProv, [SolicitudesCotizacion]=@SolicitudesCotizacion, [SolicitudServicioSolCoti]=@SolicitudServicioSolCoti, [SolicitudesDescuento]=@SolicitudesDescuento, [SolicitudesComisionMetodoPago]=@SolicitudesComisionMetodoPago, [SolicitudesOtros1]=@SolicitudesOtros1, [SolicitudesOtros2]=@SolicitudesOtros2, [SolicitudesOtros3]=@SolicitudesOtros3, [SolicitudesUsrAlta]=@SolicitudesUsrAlta, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion, [SolicitudesFechaAlta]=@SolicitudesFechaAlta, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesHoraInstalacion]=@SolicitudesHoraInstalacion, [SolicitudesComentario]=@SolicitudesComentario, [SolicitudesNota]=@SolicitudesNota, [SolicitudesNotificacion]=@SolicitudesNotificacion, [SolicitudServicioOrigenPago]=@SolicitudServicioOrigenPago, [SolicitudesPagado]=@SolicitudesPagado, [SolicitudServicioComProv]=@SolicitudServicioComProv, [SolicitudServicioComProvP]=@SolicitudServicioComProvP, [SolicitudServicioComALM]=@SolicitudServicioComALM, [SolicitudServicioComALMP]=@SolicitudServicioComALMP, [SolicitudesCalComi]=@SolicitudesCalComi, [SolicitudesSubTipo]=@SolicitudesSubTipo, [SolicitudesCostoXZona]=@SolicitudesCostoXZona, [SolicitudesCostoXZComAlm]=@SolicitudesCostoXZComAlm, [SolicitudesCostoXZComAlmP]=@SolicitudesCostoXZComAlmP, [SolicitudesDescuentoCupon]=@SolicitudesDescuentoCupon, [DepartamentoId]=@DepartamentoId, "
        + " [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [ZonasID]=@ZonasID, [MetodoPagosID]=@MetodoPagosID, [MudanzaId]=@MudanzaId, [ProveedorID]=@ProveedorID, [STComerciosID]=@STComerciosID, [CancelacionTipificacionId]=@CancelacionTipificacionId, [CuponId]=@CuponId, [EstadosSolTipo]=@EstadosSolTipo, [EstadosSolId]=@EstadosSolId, [STMonedasId]=@STMonedasId  WHERE [SolicitudesID] = @SolicitudesID" ;
        Object[] prmT002W28;
        prmT002W28 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W29;
        prmT002W29 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT002W30;
        prmT002W30 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W31;
        prmT002W31 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W32;
        prmT002W32 = new Object[] {
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT002W33;
        prmT002W33 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT002W34;
        prmT002W34 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT002W35;
        prmT002W35 = new Object[] {
        new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W36;
        prmT002W36 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002W37;
        prmT002W37 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W38;
        prmT002W38 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W39;
        prmT002W39 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W40;
        prmT002W40 = new Object[] {
        };
        Object[] prmT002W41;
        prmT002W41 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT002W42;
        prmT002W42 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002W2", "SELECT [SolicitudesID], [SolicitudesNombre], [ProveedorNombreAux], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuentoCupon], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID] AS STComerciosID, [CancelacionTipificacionId], [CuponId], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId, [STMonedasId] AS STMonedasId FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W3", "SELECT [SolicitudesID], [SolicitudesNombre], [ProveedorNombreAux], [SolicitudesTelefono], [SolicitudesMail], [SolicitudesDireccion], [SolicitudesAutoEnumerar], [SolicitudesLiqProf], [SolicitudesLiqProv], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [SolicitudesDescuento], [SolicitudesComisionMetodoPago], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCalComi], [SolicitudesSubTipo], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuentoCupon], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [MetodoPagosID], [MudanzaId], [ProveedorID], [STComerciosID] AS STComerciosID, [CancelacionTipificacionId], [CuponId], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId, [STMonedasId] AS STMonedasId FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W4", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W5", "SELECT [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W6", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W7", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W8", "SELECT [MudanzaFechaServicio], [MudanzaDireccionOrigen], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W9", "SELECT [ProveedorNombre], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W10", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W11", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W12", "SELECT [MonedaISOSimbolo] AS STMonedasISO FROM [Moneda] WHERE [MonedaId] = @STMonedasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W13", cmdBufferT002W13,true, GxErrorMask.GX_NOMASK, false, this,prmT002W13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W14", "SELECT [ProveedorNombre], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W15", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W16", "SELECT [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W17", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W18", "SELECT [MonedaISOSimbolo] AS STMonedasISO FROM [Moneda] WHERE [MonedaId] = @STMonedasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W19", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W20", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W21", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W22", "SELECT [MudanzaFechaServicio], [MudanzaDireccionOrigen], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W23", "SELECT [SolicitudesID] FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W24", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE ( [SolicitudesID] > @SolicitudesID) ORDER BY [SolicitudesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W25", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE ( [SolicitudesID] < @SolicitudesID) ORDER BY [SolicitudesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W26", cmdBufferT002W26,true, GxErrorMask.GX_NOMASK, false, this,prmT002W26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W27", cmdBufferT002W27, GxErrorMask.GX_NOMASK,prmT002W27)
           ,new CursorDef("T002W28", "DELETE FROM [Solicitudes]  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK,prmT002W28)
           ,new CursorDef("T002W29", "SELECT [ProveedorNombre], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W30", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W31", "SELECT [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W32", "SELECT [MonedaISOSimbolo] AS STMonedasISO FROM [Moneda] WHERE [MonedaId] = @STMonedasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W33", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W34", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W35", "SELECT [ProveedorNombre] AS STComerciosNombre, [ProveedorEstado] AS STComerciosEstado FROM [Proveedor] WHERE [ProveedorID] = @STComerciosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W36", "SELECT [MudanzaFechaServicio], [MudanzaDireccionOrigen], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @MudanzaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W37", "SELECT TOP 1 [SolicitudesID], [ArchivoId] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W38", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W39", "SELECT TOP 1 [SolicitudesID], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W40", "SELECT [SolicitudesID] FROM [Solicitudes] ORDER BY [SolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W40,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W41", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W41,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W42", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W42,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((long[]) buf[11])[0] = rslt.getLong(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 1);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 1);
              ((string[]) buf[19])[0] = rslt.getString(15, 1000);
              ((string[]) buf[20])[0] = rslt.getString(16, 500);
              ((long[]) buf[21])[0] = rslt.getLong(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((long[]) buf[23])[0] = rslt.getLong(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[25])[0] = rslt.getGXDate(19);
              ((bool[]) buf[26])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(20);
              ((bool[]) buf[28])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[29])[0] = rslt.getGXDate(21);
              ((string[]) buf[30])[0] = rslt.getString(22, 1);
              ((string[]) buf[31])[0] = rslt.getLongVarchar(23);
              ((string[]) buf[32])[0] = rslt.getString(24, 500);
              ((string[]) buf[33])[0] = rslt.getString(25, 1);
              ((string[]) buf[34])[0] = rslt.getString(26, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(26);
              ((string[]) buf[36])[0] = rslt.getString(27, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(27);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
              ((bool[]) buf[39])[0] = rslt.wasNull(28);
              ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
              ((bool[]) buf[41])[0] = rslt.wasNull(29);
              ((decimal[]) buf[42])[0] = rslt.getDecimal(30);
              ((bool[]) buf[43])[0] = rslt.wasNull(30);
              ((decimal[]) buf[44])[0] = rslt.getDecimal(31);
              ((bool[]) buf[45])[0] = rslt.wasNull(31);
              ((bool[]) buf[46])[0] = rslt.getBool(32);
              ((string[]) buf[47])[0] = rslt.getString(33, 1);
              ((bool[]) buf[48])[0] = rslt.wasNull(33);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(34);
              ((decimal[]) buf[50])[0] = rslt.getDecimal(35);
              ((bool[]) buf[51])[0] = rslt.wasNull(35);
              ((decimal[]) buf[52])[0] = rslt.getDecimal(36);
              ((bool[]) buf[53])[0] = rslt.wasNull(36);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(37);
              ((long[]) buf[55])[0] = rslt.getLong(38);
              ((bool[]) buf[56])[0] = rslt.wasNull(38);
              ((long[]) buf[57])[0] = rslt.getLong(39);
              ((bool[]) buf[58])[0] = rslt.wasNull(39);
              ((long[]) buf[59])[0] = rslt.getLong(40);
              ((bool[]) buf[60])[0] = rslt.wasNull(40);
              ((long[]) buf[61])[0] = rslt.getLong(41);
              ((long[]) buf[62])[0] = rslt.getLong(42);
              ((bool[]) buf[63])[0] = rslt.wasNull(42);
              ((long[]) buf[64])[0] = rslt.getLong(43);
              ((long[]) buf[65])[0] = rslt.getLong(44);
              ((bool[]) buf[66])[0] = rslt.wasNull(44);
              ((long[]) buf[67])[0] = rslt.getLong(45);
              ((long[]) buf[68])[0] = rslt.getLong(46);
              ((bool[]) buf[69])[0] = rslt.wasNull(46);
              ((string[]) buf[70])[0] = rslt.getString(47, 3);
              ((int[]) buf[71])[0] = rslt.getInt(48);
              ((short[]) buf[72])[0] = rslt.getShort(49);
              ((bool[]) buf[73])[0] = rslt.wasNull(49);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((long[]) buf[11])[0] = rslt.getLong(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 1);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 1);
              ((string[]) buf[19])[0] = rslt.getString(15, 1000);
              ((string[]) buf[20])[0] = rslt.getString(16, 500);
              ((long[]) buf[21])[0] = rslt.getLong(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((long[]) buf[23])[0] = rslt.getLong(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[25])[0] = rslt.getGXDate(19);
              ((bool[]) buf[26])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(20);
              ((bool[]) buf[28])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[29])[0] = rslt.getGXDate(21);
              ((string[]) buf[30])[0] = rslt.getString(22, 1);
              ((string[]) buf[31])[0] = rslt.getLongVarchar(23);
              ((string[]) buf[32])[0] = rslt.getString(24, 500);
              ((string[]) buf[33])[0] = rslt.getString(25, 1);
              ((string[]) buf[34])[0] = rslt.getString(26, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(26);
              ((string[]) buf[36])[0] = rslt.getString(27, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(27);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
              ((bool[]) buf[39])[0] = rslt.wasNull(28);
              ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
              ((bool[]) buf[41])[0] = rslt.wasNull(29);
              ((decimal[]) buf[42])[0] = rslt.getDecimal(30);
              ((bool[]) buf[43])[0] = rslt.wasNull(30);
              ((decimal[]) buf[44])[0] = rslt.getDecimal(31);
              ((bool[]) buf[45])[0] = rslt.wasNull(31);
              ((bool[]) buf[46])[0] = rslt.getBool(32);
              ((string[]) buf[47])[0] = rslt.getString(33, 1);
              ((bool[]) buf[48])[0] = rslt.wasNull(33);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(34);
              ((decimal[]) buf[50])[0] = rslt.getDecimal(35);
              ((bool[]) buf[51])[0] = rslt.wasNull(35);
              ((decimal[]) buf[52])[0] = rslt.getDecimal(36);
              ((bool[]) buf[53])[0] = rslt.wasNull(36);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(37);
              ((long[]) buf[55])[0] = rslt.getLong(38);
              ((bool[]) buf[56])[0] = rslt.wasNull(38);
              ((long[]) buf[57])[0] = rslt.getLong(39);
              ((bool[]) buf[58])[0] = rslt.wasNull(39);
              ((long[]) buf[59])[0] = rslt.getLong(40);
              ((bool[]) buf[60])[0] = rslt.wasNull(40);
              ((long[]) buf[61])[0] = rslt.getLong(41);
              ((long[]) buf[62])[0] = rslt.getLong(42);
              ((bool[]) buf[63])[0] = rslt.wasNull(42);
              ((long[]) buf[64])[0] = rslt.getLong(43);
              ((long[]) buf[65])[0] = rslt.getLong(44);
              ((bool[]) buf[66])[0] = rslt.wasNull(44);
              ((long[]) buf[67])[0] = rslt.getLong(45);
              ((long[]) buf[68])[0] = rslt.getLong(46);
              ((bool[]) buf[69])[0] = rslt.wasNull(46);
              ((string[]) buf[70])[0] = rslt.getString(47, 3);
              ((int[]) buf[71])[0] = rslt.getInt(48);
              ((short[]) buf[72])[0] = rslt.getShort(49);
              ((bool[]) buf[73])[0] = rslt.wasNull(49);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 80);
              ((string[]) buf[9])[0] = rslt.getString(8, 120);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 3);
              ((long[]) buf[13])[0] = rslt.getLong(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
              ((string[]) buf[18])[0] = rslt.getString(15, 1);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
              ((bool[]) buf[20])[0] = rslt.wasNull(16);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
              ((string[]) buf[22])[0] = rslt.getString(18, 80);
              ((string[]) buf[23])[0] = rslt.getString(19, 1);
              ((string[]) buf[24])[0] = rslt.getString(20, 1000);
              ((string[]) buf[25])[0] = rslt.getString(21, 500);
              ((long[]) buf[26])[0] = rslt.getLong(22);
              ((bool[]) buf[27])[0] = rslt.wasNull(22);
              ((long[]) buf[28])[0] = rslt.getLong(23);
              ((bool[]) buf[29])[0] = rslt.wasNull(23);
              ((DateTime[]) buf[30])[0] = rslt.getGXDate(24);
              ((bool[]) buf[31])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(25);
              ((bool[]) buf[33])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(26);
              ((string[]) buf[35])[0] = rslt.getString(27, 1);
              ((string[]) buf[36])[0] = rslt.getLongVarchar(28);
              ((string[]) buf[37])[0] = rslt.getString(29, 80);
              ((string[]) buf[38])[0] = rslt.getString(30, 500);
              ((string[]) buf[39])[0] = rslt.getString(31, 1);
              ((string[]) buf[40])[0] = rslt.getString(32, 1);
              ((string[]) buf[41])[0] = rslt.getString(33, 80);
              ((string[]) buf[42])[0] = rslt.getString(34, 3);
              ((string[]) buf[43])[0] = rslt.getString(35, 1);
              ((bool[]) buf[44])[0] = rslt.wasNull(35);
              ((string[]) buf[45])[0] = rslt.getString(36, 1);
              ((bool[]) buf[46])[0] = rslt.wasNull(36);
              ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
              ((bool[]) buf[48])[0] = rslt.wasNull(37);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
              ((bool[]) buf[50])[0] = rslt.wasNull(38);
              ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
              ((bool[]) buf[52])[0] = rslt.wasNull(39);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
              ((bool[]) buf[54])[0] = rslt.wasNull(40);
              ((bool[]) buf[55])[0] = rslt.getBool(41);
              ((string[]) buf[56])[0] = rslt.getString(42, 1);
              ((bool[]) buf[57])[0] = rslt.wasNull(42);
              ((decimal[]) buf[58])[0] = rslt.getDecimal(43);
              ((decimal[]) buf[59])[0] = rslt.getDecimal(44);
              ((bool[]) buf[60])[0] = rslt.wasNull(44);
              ((decimal[]) buf[61])[0] = rslt.getDecimal(45);
              ((bool[]) buf[62])[0] = rslt.wasNull(45);
              ((DateTime[]) buf[63])[0] = rslt.getGXDate(46);
              ((string[]) buf[64])[0] = rslt.getVarchar(47);
              ((string[]) buf[65])[0] = rslt.getVarchar(48);
              ((decimal[]) buf[66])[0] = rslt.getDecimal(49);
              ((long[]) buf[67])[0] = rslt.getLong(50);
              ((bool[]) buf[68])[0] = rslt.wasNull(50);
              ((long[]) buf[69])[0] = rslt.getLong(51);
              ((bool[]) buf[70])[0] = rslt.wasNull(51);
              ((long[]) buf[71])[0] = rslt.getLong(52);
              ((bool[]) buf[72])[0] = rslt.wasNull(52);
              ((long[]) buf[73])[0] = rslt.getLong(53);
              ((long[]) buf[74])[0] = rslt.getLong(54);
              ((bool[]) buf[75])[0] = rslt.wasNull(54);
              ((long[]) buf[76])[0] = rslt.getLong(55);
              ((long[]) buf[77])[0] = rslt.getLong(56);
              ((bool[]) buf[78])[0] = rslt.wasNull(56);
              ((long[]) buf[79])[0] = rslt.getLong(57);
              ((long[]) buf[80])[0] = rslt.getLong(58);
              ((bool[]) buf[81])[0] = rslt.wasNull(58);
              ((string[]) buf[82])[0] = rslt.getString(59, 3);
              ((int[]) buf[83])[0] = rslt.getInt(60);
              ((short[]) buf[84])[0] = rslt.getShort(61);
              ((bool[]) buf[85])[0] = rslt.wasNull(61);
              ((string[]) buf[86])[0] = rslt.getString(62, 2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 20 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 34 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 37 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 38 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 39 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 40 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
