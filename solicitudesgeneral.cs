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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class solicitudesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudesgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public solicitudesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbSolicitudesSubTipo = new GXCombobox();
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
         dynZonasID = new GXCombobox();
         chkSolicitudesOtros1 = new GXCheckbox();
         cmbSolicitudesHoraInstalacion = new GXCombobox();
         chkSolicitudServicioSolCoti = new GXCheckbox();
         chkSolicitudesCalComi = new GXCheckbox();
         cmbSolicitudServicioOrigenPago = new GXCombobox();
         dynMetodoPagosID = new GXCombobox();
         cmbSolicitudesPagado = new GXCombobox();
         cmbSolicitudesNotificacion = new GXCombobox();
         dynSolicitudesUsrAlta = new GXCombobox();
         dynSolicitudesUsrActualizacion = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "SolicitudesID");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A127SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A127SolicitudesID});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLADEPARTAMENTOID8B2( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLADEPARTAMENTOMUNICIPIOID8B2( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ZONASID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAZONASID8B2( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"METODOPAGOSID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLAMETODOPAGOSID8B2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "SolicitudesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SolicitudesID");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA8B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "SolicitudesGeneral";
               GXADEPARTAMENTOID_html8B2( ) ;
               /* Using cursor H008B2 */
               pr_default.execute(0, new Object[] {n112DepartamentoId, A112DepartamentoId});
               A116PaisID = H008B2_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               pr_default.close(0);
               GXADEPARTAMENTOMUNICIPIOID_html8B2( ) ;
               GXAZONASID_html8B2( ) ;
               GXAMETODOPAGOSID_html8B2( ) ;
               GetSolicitudesTotal( A127SolicitudesID) ;
               WS8B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor H008B3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( H008B3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H008B3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H008B3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H008B3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H008B3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])-(H008B3_A180SolicitudItemsComision[0]*H008B3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H008B3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H008B3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])+(H008B3_A180SolicitudItemsComision[0]*H008B3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H008B3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H008B3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])-((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])*(H008B3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H008B3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H008B3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])+((H008B3_A176SolicitudesItemsPrecioFinal[0]*H008B3_A177SolicitudesItemsCantidad[0])*(H008B3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            AssignAttri(sPrefix, false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Solicitudes General", "")) ;
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
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "solicitudesgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"SolicitudesGeneral");
         forbiddenHiddens.Add("EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("solicitudesgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA127SolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESCOSTOXZONA", StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Width", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autowidth", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autoheight", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Cls", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Title", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsible", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsed", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Iconposition", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autoscroll", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Width", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autowidth", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autoheight", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Cls", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Title", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsible", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsed", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Iconposition", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autoscroll", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Width", StringUtil.RTrim( Dvpanel_transactiondetail_data5_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autowidth", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autoheight", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Cls", StringUtil.RTrim( Dvpanel_transactiondetail_data5_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Title", StringUtil.RTrim( Dvpanel_transactiondetail_data5_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Collapsible", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Collapsed", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Iconposition", StringUtil.RTrim( Dvpanel_transactiondetail_data5_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autoscroll", StringUtil.BoolToStr( Dvpanel_transactiondetail_data5_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_transactiondetail_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_transactiondetail_tabs1_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_transactiondetail_tabs1_Historymanagement));
      }

      protected void RenderHtmlCloseForm8B2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "SolicitudesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitudes General", "") ;
      }

      protected void WB8B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "solicitudesgeneral.aspx");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_transactiondetail_tabs1.SetProperty("PageCount", Gxuitabspanel_transactiondetail_tabs1_Pagecount);
            ucGxuitabspanel_transactiondetail_tabs1.SetProperty("Class", Gxuitabspanel_transactiondetail_tabs1_Class);
            ucGxuitabspanel_transactiondetail_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_transactiondetail_tabs1_Historymanagement);
            ucGxuitabspanel_transactiondetail_tabs1.Render(context, "tab", Gxuitabspanel_transactiondetail_tabs1_Internalname, sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatosgenerales_title_Internalname, context.GetMessage( "Datos Generales", ""), "", "", lblDatosgenerales_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DatosGenerales") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tbdata1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_data1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesNombre_Internalname, StringUtil.RTrim( A171SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSolicitudesNombre_Link, "", "", "", edtSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSolicitudesTelefono_Internalname, context.GetMessage( "Cliente Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesTelefono_Internalname, StringUtil.RTrim( A172SolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( A172SolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "598 099 999999", edtSolicitudesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSolicitudesMail_Internalname, context.GetMessage( "Client Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesMail_Internalname, A206SolicitudesMail, StringUtil.RTrim( context.localUtil.Format( A206SolicitudesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A206SolicitudesMail, "", "", "", edtSolicitudesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtProveedorNombre_Link, "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_SolicitudesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombreAux_Internalname, StringUtil.RTrim( A533ProveedorNombreAux), StringUtil.RTrim( context.localUtil.Format( A533ProveedorNombreAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombreAux_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombreAux_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_data2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesSubTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbSolicitudesSubTipo_Internalname, context.GetMessage( "Sub Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesSubTipo, cmbSolicitudesSubTipo_Internalname, StringUtil.RTrim( A600SolicitudesSubTipo), 1, cmbSolicitudesSubTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesSubTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp(sPrefix, false, cmbSolicitudesSubTipo_Internalname, "Values", (string)(cmbSolicitudesSubTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadosSolNombre_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadosSolNombre_Internalname, StringUtil.RTrim( A132EstadosSolNombre), StringUtil.RTrim( context.localUtil.Format( A132EstadosSolNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEstadosSolNombre_Link, "", "", "", edtEstadosSolNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoMunicipioId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoMunicipioId_Internalname, context.GetMessage( "Municipio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynZonasID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynZonasID_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynZonasID, dynZonasID_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0)), 1, dynZonasID_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynZonasID.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
            AssignProp(sPrefix, false, dynZonasID_Internalname, "Values", (string)(dynZonasID.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesDireccion_Internalname, A173SolicitudesDireccion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", 0, 1, edtSolicitudesDireccion_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", context.GetMessage( "Calle, casa numero 1234...", ""), -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMudanzadireccionorigen_cell_Internalname, 1, 0, "px", 0, "px", divMudanzadireccionorigen_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtMudanzaDireccionOrigen_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaDireccionOrigen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMudanzaDireccionOrigen_Internalname, context.GetMessage( "Origen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMudanzaDireccionOrigen_Internalname, A740MudanzaDireccionOrigen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", 0, edtMudanzaDireccionOrigen_Visible, edtMudanzaDireccionOrigen_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMudanzadirecciondestino_cell_Internalname, 1, 0, "px", 0, "px", divMudanzadirecciondestino_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtMudanzaDireccionDestino_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMudanzaDireccionDestino_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMudanzaDireccionDestino_Internalname, context.GetMessage( "Destino", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMudanzaDireccionDestino_Internalname, A741MudanzaDireccionDestino, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", 0, edtMudanzaDireccionDestino_Visible, edtMudanzaDireccionDestino_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkSolicitudesOtros1_Internalname, context.GetMessage( "No aparecen en el listado los servicios que necesito.", ""), "col-sm-3 AttributeCheckNoBorderLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckNoBorder";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkSolicitudesOtros1_Internalname, A201SolicitudesOtros1, context.GetMessage( "No aparecen en el listado los servcios que necesito.", ""), context.GetMessage( "No aparecen en el listado los servicios que necesito.", ""), 1, chkSolicitudesOtros1.Enabled, "S", context.GetMessage( "¿No aparece en la lista los servicios que necesito?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'S', 'N',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesOtros2_Internalname, StringUtil.RTrim( A202SolicitudesOtros2), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", 0, 1, edtSolicitudesOtros2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesFechaInstalacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudesFechaInstalacion_Internalname, context.GetMessage( "Programar la instalación para la fecha", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaInstalacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaInstalacion_Internalname, context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"), context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaInstalacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaInstalacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtSolicitudesFechaInstalacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaInstalacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesHoraInstalacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbSolicitudesHoraInstalacion_Internalname, context.GetMessage( "Hora Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesHoraInstalacion, cmbSolicitudesHoraInstalacion_Internalname, StringUtil.RTrim( A183SolicitudesHoraInstalacion), 1, cmbSolicitudesHoraInstalacion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesHoraInstalacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            cmbSolicitudesHoraInstalacion.CurrentValue = StringUtil.RTrim( A183SolicitudesHoraInstalacion);
            AssignProp(sPrefix, false, cmbSolicitudesHoraInstalacion_Internalname, "Values", (string)(cmbSolicitudesHoraInstalacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Relaciones", ""), 1, 0, "px", 0, "px", grpUnnamedgroup3_Class, "", "HLP_SolicitudesGeneral.htm");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatosservicio_title_Internalname, context.GetMessage( "Datos del Servicio ", ""), "", "", lblDatosservicio_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DatosServicio") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tbdata2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableleaflevel_items_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_transactiondetail_data3.SetProperty("Width", Dvpanel_transactiondetail_data3_Width);
            ucDvpanel_transactiondetail_data3.SetProperty("AutoWidth", Dvpanel_transactiondetail_data3_Autowidth);
            ucDvpanel_transactiondetail_data3.SetProperty("AutoHeight", Dvpanel_transactiondetail_data3_Autoheight);
            ucDvpanel_transactiondetail_data3.SetProperty("Cls", Dvpanel_transactiondetail_data3_Cls);
            ucDvpanel_transactiondetail_data3.SetProperty("Title", Dvpanel_transactiondetail_data3_Title);
            ucDvpanel_transactiondetail_data3.SetProperty("Collapsible", Dvpanel_transactiondetail_data3_Collapsible);
            ucDvpanel_transactiondetail_data3.SetProperty("Collapsed", Dvpanel_transactiondetail_data3_Collapsed);
            ucDvpanel_transactiondetail_data3.SetProperty("ShowCollapseIcon", Dvpanel_transactiondetail_data3_Showcollapseicon);
            ucDvpanel_transactiondetail_data3.SetProperty("IconPosition", Dvpanel_transactiondetail_data3_Iconposition);
            ucDvpanel_transactiondetail_data3.SetProperty("AutoScroll", Dvpanel_transactiondetail_data3_Autoscroll);
            ucDvpanel_transactiondetail_data3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_transactiondetail_data3_Internalname, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3Container"+"TransactionDetail_DATA3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_data3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesTotal_Enabled!=0) ? context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTotal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, chkSolicitudServicioSolCoti_Internalname, context.GetMessage( "Solicitar cotización ", ""), "col-sm-3 AttributeCheckNoBorderLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckNoBorder";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkSolicitudServicioSolCoti_Internalname, A210SolicitudServicioSolCoti, "", context.GetMessage( "Solicitar cotización ", ""), 1, chkSolicitudServicioSolCoti.Enabled, "S", context.GetMessage( "¿Solicitó Cotización?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(133, this, 'S', 'N',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,133);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesCotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCotizacion_Enabled!=0) ? context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCotizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioPFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioPFinal_Enabled!=0) ? context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,143);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioPFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioPFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtSolicitudesComisionMetodoPago_Internalname, context.GetMessage( "Comisión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesComisionMetodoPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesComisionMetodoPago_Enabled!=0) ? context.localUtil.Format( A796SolicitudesComisionMetodoPago, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A796SolicitudesComisionMetodoPago, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,148);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesComisionMetodoPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesComisionMetodoPago_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDvpanel_transactiondetail_data4_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_transactiondetail_data4_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_transactiondetail_data4.SetProperty("Width", Dvpanel_transactiondetail_data4_Width);
            ucDvpanel_transactiondetail_data4.SetProperty("AutoWidth", Dvpanel_transactiondetail_data4_Autowidth);
            ucDvpanel_transactiondetail_data4.SetProperty("AutoHeight", Dvpanel_transactiondetail_data4_Autoheight);
            ucDvpanel_transactiondetail_data4.SetProperty("Cls", Dvpanel_transactiondetail_data4_Cls);
            ucDvpanel_transactiondetail_data4.SetProperty("Title", Dvpanel_transactiondetail_data4_Title);
            ucDvpanel_transactiondetail_data4.SetProperty("Collapsible", Dvpanel_transactiondetail_data4_Collapsible);
            ucDvpanel_transactiondetail_data4.SetProperty("Collapsed", Dvpanel_transactiondetail_data4_Collapsed);
            ucDvpanel_transactiondetail_data4.SetProperty("ShowCollapseIcon", Dvpanel_transactiondetail_data4_Showcollapseicon);
            ucDvpanel_transactiondetail_data4.SetProperty("IconPosition", Dvpanel_transactiondetail_data4_Iconposition);
            ucDvpanel_transactiondetail_data4.SetProperty("AutoScroll", Dvpanel_transactiondetail_data4_Autoscroll);
            ucDvpanel_transactiondetail_data4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_transactiondetail_data4_Internalname, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4Container"+"TransactionDetail_DATA4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_data4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProv_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudServicioComProv_Internalname, context.GetMessage( "Comisión Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProv_Internalname, StringUtil.LTrim( StringUtil.NToC( A527SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProv_Enabled!=0) ? context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,157);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProv_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProv_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProvP_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudServicioComProvP_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProvP_Internalname, StringUtil.LTrim( StringUtil.NToC( A528SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProvP_Enabled!=0) ? context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99") : context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,161);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProvP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProvP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComALM_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudServicioComALM_Internalname, context.GetMessage( "Almango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALM_Internalname, StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALM_Enabled!=0) ? context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,166);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALM_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALM_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComALMP_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALMP_Internalname, StringUtil.LTrim( StringUtil.NToC( A532SolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALMP_Enabled!=0) ? context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99") : context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,170);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALMP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALMP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComPro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudServicioComPro_Internalname, context.GetMessage( "Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComPro_Internalname, StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComPro_Enabled!=0) ? context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,175);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComPro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComPro_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudServicioComProP_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudServicioComProP_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProP_Internalname, StringUtil.LTrim( StringUtil.NToC( A531SolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProP_Enabled!=0) ? context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99") : context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,179);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_label_element( context, chkSolicitudesCalComi_Internalname, context.GetMessage( "Calcular Comisión", ""), "col-sm-3 AttributeColorBaseColorLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeColorBaseColor";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkSolicitudesCalComi_Internalname, StringUtil.BoolToStr( A672SolicitudesCalComi), "", context.GetMessage( "Calcular Comisión", ""), 1, chkSolicitudesCalComi.Enabled, "true", context.GetMessage( "Calcular Comisión de Forma Automática ", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            /* User Defined Control */
            ucDvpanel_transactiondetail_data5.SetProperty("Width", Dvpanel_transactiondetail_data5_Width);
            ucDvpanel_transactiondetail_data5.SetProperty("AutoWidth", Dvpanel_transactiondetail_data5_Autowidth);
            ucDvpanel_transactiondetail_data5.SetProperty("AutoHeight", Dvpanel_transactiondetail_data5_Autoheight);
            ucDvpanel_transactiondetail_data5.SetProperty("Cls", Dvpanel_transactiondetail_data5_Cls);
            ucDvpanel_transactiondetail_data5.SetProperty("Title", Dvpanel_transactiondetail_data5_Title);
            ucDvpanel_transactiondetail_data5.SetProperty("Collapsible", Dvpanel_transactiondetail_data5_Collapsible);
            ucDvpanel_transactiondetail_data5.SetProperty("Collapsed", Dvpanel_transactiondetail_data5_Collapsed);
            ucDvpanel_transactiondetail_data5.SetProperty("ShowCollapseIcon", Dvpanel_transactiondetail_data5_Showcollapseicon);
            ucDvpanel_transactiondetail_data5.SetProperty("IconPosition", Dvpanel_transactiondetail_data5_Iconposition);
            ucDvpanel_transactiondetail_data5.SetProperty("AutoScroll", Dvpanel_transactiondetail_data5_Autoscroll);
            ucDvpanel_transactiondetail_data5.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_transactiondetail_data5_Internalname, sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5Container"+"TransactionDetail_Data5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_data5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudServicioOrigenPago_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbSolicitudServicioOrigenPago_Internalname, context.GetMessage( "Origen del Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudServicioOrigenPago, cmbSolicitudServicioOrigenPago_Internalname, StringUtil.RTrim( A438SolicitudServicioOrigenPago), 1, cmbSolicitudServicioOrigenPago_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudServicioOrigenPago.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,193);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp(sPrefix, false, cmbSolicitudServicioOrigenPago_Internalname, "Values", (string)(cmbSolicitudServicioOrigenPago.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynMetodoPagosID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynMetodoPagosID_Internalname, context.GetMessage( "Modo de Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynMetodoPagosID, dynMetodoPagosID_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0)), 1, dynMetodoPagosID_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMetodoPagosID.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynMetodoPagosID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0));
            AssignProp(sPrefix, false, dynMetodoPagosID_Internalname, "Values", (string)(dynMetodoPagosID.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesPagado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbSolicitudesPagado_Internalname, context.GetMessage( "Pagado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesPagado, cmbSolicitudesPagado_Internalname, StringUtil.RTrim( A441SolicitudesPagado), 1, cmbSolicitudesPagado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesPagado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
            AssignProp(sPrefix, false, cmbSolicitudesPagado_Internalname, "Values", (string)(cmbSolicitudesPagado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Costos", ""), 1, 0, "px", 0, "px", grpUnnamedgroup2_Class, "", "HLP_SolicitudesGeneral.htm");
            wb_table1_206_8B2( true) ;
         }
         else
         {
            wb_table1_206_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_206_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInformacion_title_Internalname, context.GetMessage( "Información Complementaria", ""), "", "", lblInformacion_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Informacion") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tbdata3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesOtros3_Internalname, StringUtil.RTrim( A203SolicitudesOtros3), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,219);\"", 0, 1, edtSolicitudesOtros3_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesComentario_Internalname, A205SolicitudesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,224);\"", 0, 1, edtSolicitudesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesNota_Internalname, StringUtil.RTrim( A261SolicitudesNota), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,229);\"", 0, 1, edtSolicitudesNota_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSolicitudesNotificacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbSolicitudesNotificacion_Internalname, context.GetMessage( "¿Se notifico al cliente?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesNotificacion, cmbSolicitudesNotificacion_Internalname, StringUtil.RTrim( A262SolicitudesNotificacion), 1, cmbSolicitudesNotificacion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesNotificacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,234);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            cmbSolicitudesNotificacion.CurrentValue = StringUtil.RTrim( A262SolicitudesNotificacion);
            AssignProp(sPrefix, false, cmbSolicitudesNotificacion_Internalname, "Values", (string)(cmbSolicitudesNotificacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Datos de Auditoría", ""), 1, 0, "px", 0, "px", grpUnnamedgroup1_Class, "", "HLP_SolicitudesGeneral.htm");
            wb_table2_238_8B2( true) ;
         }
         else
         {
            wb_table2_238_8B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_238_8B2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtSolicitudesAutoEnumerar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A194SolicitudesAutoEnumerar), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesAutoEnumerar_Jsonclick, 0, "Attribute", "", "", "", "", edtSolicitudesAutoEnumerar_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaAlta_Internalname, context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"), context.localUtil.Format( A182SolicitudesFechaAlta, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtSolicitudesFechaAlta_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtSolicitudesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtSolicitudesFechaAlta_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEstadosSolTipo_Internalname, StringUtil.RTrim( A130EstadosSolTipo), StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosSolTipo_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesGeneral.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 265,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesid_Internalname, StringUtil.RTrim( AV16ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,265);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavProfesionalesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesid_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", edtPaisID_Visible, 0, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Solicitudes General", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP8B0( ) ;
            }
         }
      }

      protected void WS8B2( )
      {
         START8B2( ) ;
         EVT8B2( ) ;
      }

      protected void EVT8B2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E128B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E138B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E148B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavProfesionalesid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE8B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8B2( ) ;
            }
         }
      }

      protected void PA8B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudesgeneral.aspx")), "solicitudesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudesgeneral.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "SolicitudesID");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavProfesionalesid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLASOLICITUDESUSRACTUALIZACION8B1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASOLICITUDESUSRACTUALIZACION_data8B1( ) ;
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

      protected void GXASOLICITUDESUSRACTUALIZACION_html8B1( )
      {
         long gxdynajaxvalue;
         GXDLASOLICITUDESUSRACTUALIZACION_data8B1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSolicitudesUsrActualizacion.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynSolicitudesUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynSolicitudesUsrActualizacion.ItemCount > 0 )
         {
            A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n598SolicitudesUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
         }
      }

      protected void GXDLASOLICITUDESUSRACTUALIZACION_data8B1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H008B4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B4_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(H008B4_A587SecUserFullName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLASOLICITUDESUSRALTA8B1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASOLICITUDESUSRALTA_data8B1( ) ;
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

      protected void GXASOLICITUDESUSRALTA_html8B1( )
      {
         long gxdynajaxvalue;
         GXDLASOLICITUDESUSRALTA_data8B1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSolicitudesUsrAlta.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynSolicitudesUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynSolicitudesUsrAlta.ItemCount > 0 )
         {
            A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n597SolicitudesUsrAlta = false;
            AssignAttri(sPrefix, false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
         }
      }

      protected void GXDLASOLICITUDESUSRALTA_data8B1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H008B5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B5_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(H008B5_A587SecUserFullName[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void GXDLADEPARTAMENTOID8B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_data8B2( ) ;
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

      protected void GXADEPARTAMENTOID_html8B2( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_data8B2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLADEPARTAMENTOID_data8B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H008B6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B6_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H008B6_A113DepartamentoDepartamento[0]));
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID8B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data8B2( ) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html8B2( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data8B2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoMunicipioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoMunicipioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data8B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H008B7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B7_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H008B7_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void GXDLAZONASID8B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAZONASID_data8B2( ) ;
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

      protected void GXAZONASID_html8B2( )
      {
         long gxdynajaxvalue;
         GXDLAZONASID_data8B2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynZonasID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynZonasID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAZONASID_data8B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H008B8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B8_A110ZonasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H008B8_A111ZonasNombre[0]));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void GXDLAMETODOPAGOSID8B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMETODOPAGOSID_data8B2( ) ;
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

      protected void GXAMETODOPAGOSID_html8B2( )
      {
         long gxdynajaxvalue;
         GXDLAMETODOPAGOSID_data8B2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMetodoPagosID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMetodoPagosID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynMetodoPagosID.ItemCount > 0 )
         {
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( dynMetodoPagosID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
      }

      protected void GXDLAMETODOPAGOSID_data8B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H008B9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H008B9_A128MetodoPagosID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H008B9_A129MetodoPagosNombre[0]));
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXADEPARTAMENTOID_html8B2( ) ;
            GXADEPARTAMENTOMUNICIPIOID_html8B2( ) ;
            GXAZONASID_html8B2( ) ;
            GXAMETODOPAGOSID_html8B2( ) ;
            dynSolicitudesUsrActualizacion.Name = "SOLICITUDESUSRACTUALIZACION";
            dynSolicitudesUsrActualizacion.WebTags = "";
            dynSolicitudesUsrActualizacion.removeAllItems();
            /* Using cursor H008B10 */
            pr_default.execute(8);
            while ( (pr_default.getStatus(8) != 101) )
            {
               dynSolicitudesUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H008B10_A18SecUserId[0]), 10, 0)), H008B10_A587SecUserFullName[0], 0);
               pr_default.readNext(8);
            }
            pr_default.close(8);
            if ( dynSolicitudesUsrActualizacion.ItemCount > 0 )
            {
               A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
               n598SolicitudesUsrActualizacion = false;
               AssignAttri(sPrefix, false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            }
            dynSolicitudesUsrAlta.Name = "SOLICITUDESUSRALTA";
            dynSolicitudesUsrAlta.WebTags = "";
            dynSolicitudesUsrAlta.removeAllItems();
            /* Using cursor H008B11 */
            pr_default.execute(9);
            while ( (pr_default.getStatus(9) != 101) )
            {
               dynSolicitudesUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H008B11_A18SecUserId[0]), 10, 0)), H008B11_A587SecUserFullName[0], 0);
               pr_default.readNext(9);
            }
            pr_default.close(9);
            if ( dynSolicitudesUsrAlta.ItemCount > 0 )
            {
               A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
               n597SolicitudesUsrAlta = false;
               AssignAttri(sPrefix, false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbSolicitudesSubTipo.ItemCount > 0 )
         {
            A600SolicitudesSubTipo = cmbSolicitudesSubTipo.getValidValue(A600SolicitudesSubTipo);
            n600SolicitudesSubTipo = false;
            AssignAttri(sPrefix, false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp(sPrefix, false, cmbSolicitudesSubTipo_Internalname, "Values", cmbSolicitudesSubTipo.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         }
         if ( dynZonasID.ItemCount > 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
            AssignProp(sPrefix, false, dynZonasID_Internalname, "Values", dynZonasID.ToJavascriptSource(), true);
         }
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         AssignAttri(sPrefix, false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         if ( cmbSolicitudesHoraInstalacion.ItemCount > 0 )
         {
            A183SolicitudesHoraInstalacion = cmbSolicitudesHoraInstalacion.getValidValue(A183SolicitudesHoraInstalacion);
            AssignAttri(sPrefix, false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesHoraInstalacion.CurrentValue = StringUtil.RTrim( A183SolicitudesHoraInstalacion);
            AssignProp(sPrefix, false, cmbSolicitudesHoraInstalacion_Internalname, "Values", cmbSolicitudesHoraInstalacion.ToJavascriptSource(), true);
         }
         A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(StringUtil.RTrim( A210SolicitudServicioSolCoti), "S")==0) ? "S" : "N");
         AssignAttri(sPrefix, false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
         A672SolicitudesCalComi = StringUtil.StrToBool( StringUtil.BoolToStr( A672SolicitudesCalComi));
         AssignAttri(sPrefix, false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
            A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
            n438SolicitudServicioOrigenPago = false;
            AssignAttri(sPrefix, false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp(sPrefix, false, cmbSolicitudServicioOrigenPago_Internalname, "Values", cmbSolicitudServicioOrigenPago.ToJavascriptSource(), true);
         }
         if ( dynMetodoPagosID.ItemCount > 0 )
         {
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( dynMetodoPagosID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMetodoPagosID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0));
            AssignProp(sPrefix, false, dynMetodoPagosID_Internalname, "Values", dynMetodoPagosID.ToJavascriptSource(), true);
         }
         if ( cmbSolicitudesPagado.ItemCount > 0 )
         {
            A441SolicitudesPagado = cmbSolicitudesPagado.getValidValue(A441SolicitudesPagado);
            n441SolicitudesPagado = false;
            AssignAttri(sPrefix, false, "A441SolicitudesPagado", A441SolicitudesPagado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
            AssignProp(sPrefix, false, cmbSolicitudesPagado_Internalname, "Values", cmbSolicitudesPagado.ToJavascriptSource(), true);
         }
         if ( cmbSolicitudesNotificacion.ItemCount > 0 )
         {
            A262SolicitudesNotificacion = cmbSolicitudesNotificacion.getValidValue(A262SolicitudesNotificacion);
            AssignAttri(sPrefix, false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesNotificacion.CurrentValue = StringUtil.RTrim( A262SolicitudesNotificacion);
            AssignProp(sPrefix, false, cmbSolicitudesNotificacion_Internalname, "Values", cmbSolicitudesNotificacion.ToJavascriptSource(), true);
         }
         if ( dynSolicitudesUsrAlta.ItemCount > 0 )
         {
            A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n597SolicitudesUsrAlta = false;
            AssignAttri(sPrefix, false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSolicitudesUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            AssignProp(sPrefix, false, dynSolicitudesUsrAlta_Internalname, "Values", dynSolicitudesUsrAlta.ToJavascriptSource(), true);
         }
         if ( dynSolicitudesUsrActualizacion.ItemCount > 0 )
         {
            A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n598SolicitudesUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSolicitudesUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            AssignProp(sPrefix, false, dynSolicitudesUsrActualizacion_Internalname, "Values", dynSolicitudesUsrActualizacion.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "SolicitudesGeneral";
      }

      protected void RF8B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H008B12 */
            pr_default.execute(10, new Object[] {A127SolicitudesID});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A131EstadosSolId = H008B12_A131EstadosSolId[0];
               A133ProveedorID = H008B12_A133ProveedorID[0];
               A735MudanzaId = H008B12_A735MudanzaId[0];
               n735MudanzaId = H008B12_n735MudanzaId[0];
               A116PaisID = H008B12_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               A130EstadosSolTipo = H008B12_A130EstadosSolTipo[0];
               AssignAttri(sPrefix, false, "A130EstadosSolTipo", A130EstadosSolTipo);
               A182SolicitudesFechaAlta = H008B12_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = H008B12_n182SolicitudesFechaAlta[0];
               AssignAttri(sPrefix, false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
               A194SolicitudesAutoEnumerar = H008B12_A194SolicitudesAutoEnumerar[0];
               AssignAttri(sPrefix, false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
               A598SolicitudesUsrActualizacion = H008B12_A598SolicitudesUsrActualizacion[0];
               n598SolicitudesUsrActualizacion = H008B12_n598SolicitudesUsrActualizacion[0];
               AssignAttri(sPrefix, false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
               A204SolicitudesFechaActualizacion = H008B12_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = H008B12_n204SolicitudesFechaActualizacion[0];
               AssignAttri(sPrefix, false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A597SolicitudesUsrAlta = H008B12_A597SolicitudesUsrAlta[0];
               n597SolicitudesUsrAlta = H008B12_n597SolicitudesUsrAlta[0];
               AssignAttri(sPrefix, false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
               A262SolicitudesNotificacion = H008B12_A262SolicitudesNotificacion[0];
               AssignAttri(sPrefix, false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
               A261SolicitudesNota = H008B12_A261SolicitudesNota[0];
               AssignAttri(sPrefix, false, "A261SolicitudesNota", A261SolicitudesNota);
               A205SolicitudesComentario = H008B12_A205SolicitudesComentario[0];
               AssignAttri(sPrefix, false, "A205SolicitudesComentario", A205SolicitudesComentario);
               A203SolicitudesOtros3 = H008B12_A203SolicitudesOtros3[0];
               AssignAttri(sPrefix, false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
               A441SolicitudesPagado = H008B12_A441SolicitudesPagado[0];
               n441SolicitudesPagado = H008B12_n441SolicitudesPagado[0];
               AssignAttri(sPrefix, false, "A441SolicitudesPagado", A441SolicitudesPagado);
               A128MetodoPagosID = H008B12_A128MetodoPagosID[0];
               AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               A438SolicitudServicioOrigenPago = H008B12_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H008B12_n438SolicitudServicioOrigenPago[0];
               AssignAttri(sPrefix, false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
               A672SolicitudesCalComi = H008B12_A672SolicitudesCalComi[0];
               AssignAttri(sPrefix, false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
               A210SolicitudServicioSolCoti = H008B12_A210SolicitudServicioSolCoti[0];
               AssignAttri(sPrefix, false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
               A183SolicitudesHoraInstalacion = H008B12_A183SolicitudesHoraInstalacion[0];
               AssignAttri(sPrefix, false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
               A184SolicitudesFechaInstalacion = H008B12_A184SolicitudesFechaInstalacion[0];
               AssignAttri(sPrefix, false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
               A202SolicitudesOtros2 = H008B12_A202SolicitudesOtros2[0];
               AssignAttri(sPrefix, false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
               A201SolicitudesOtros1 = H008B12_A201SolicitudesOtros1[0];
               AssignAttri(sPrefix, false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
               A741MudanzaDireccionDestino = H008B12_A741MudanzaDireccionDestino[0];
               AssignAttri(sPrefix, false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
               A740MudanzaDireccionOrigen = H008B12_A740MudanzaDireccionOrigen[0];
               AssignAttri(sPrefix, false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
               A173SolicitudesDireccion = H008B12_A173SolicitudesDireccion[0];
               AssignAttri(sPrefix, false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
               A110ZonasID = H008B12_A110ZonasID[0];
               n110ZonasID = H008B12_n110ZonasID[0];
               AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               A114DepartamentoMunicipioId = H008B12_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = H008B12_n114DepartamentoMunicipioId[0];
               AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               A112DepartamentoId = H008B12_A112DepartamentoId[0];
               n112DepartamentoId = H008B12_n112DepartamentoId[0];
               AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               A132EstadosSolNombre = H008B12_A132EstadosSolNombre[0];
               AssignAttri(sPrefix, false, "A132EstadosSolNombre", A132EstadosSolNombre);
               A600SolicitudesSubTipo = H008B12_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = H008B12_n600SolicitudesSubTipo[0];
               AssignAttri(sPrefix, false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
               A533ProveedorNombreAux = H008B12_A533ProveedorNombreAux[0];
               n533ProveedorNombreAux = H008B12_n533ProveedorNombreAux[0];
               AssignAttri(sPrefix, false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
               A282ProveedorNombre = H008B12_A282ProveedorNombre[0];
               AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
               A206SolicitudesMail = H008B12_A206SolicitudesMail[0];
               n206SolicitudesMail = H008B12_n206SolicitudesMail[0];
               AssignAttri(sPrefix, false, "A206SolicitudesMail", A206SolicitudesMail);
               A172SolicitudesTelefono = H008B12_A172SolicitudesTelefono[0];
               AssignAttri(sPrefix, false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
               A171SolicitudesNombre = H008B12_A171SolicitudesNombre[0];
               AssignAttri(sPrefix, false, "A171SolicitudesNombre", A171SolicitudesNombre);
               A796SolicitudesComisionMetodoPago = H008B12_A796SolicitudesComisionMetodoPago[0];
               AssignAttri(sPrefix, false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
               A212SolicitudesCotizacion = H008B12_A212SolicitudesCotizacion[0];
               AssignAttri(sPrefix, false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
               A1016SolicitudesDescuentoCupon = H008B12_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H008B12_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H008B12_n897SolicitudesDescuento[0];
               A527SolicitudServicioComProv = H008B12_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H008B12_n527SolicitudServicioComProv[0];
               AssignAttri(sPrefix, false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
               A530SolicitudServicioComALM = H008B12_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H008B12_n530SolicitudServicioComALM[0];
               AssignAttri(sPrefix, false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
               A864SolicitudesCostoXZona = H008B12_A864SolicitudesCostoXZona[0];
               A532SolicitudServicioComALMP = H008B12_A532SolicitudServicioComALMP[0];
               n532SolicitudServicioComALMP = H008B12_n532SolicitudServicioComALMP[0];
               AssignAttri(sPrefix, false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
               A528SolicitudServicioComProvP = H008B12_A528SolicitudServicioComProvP[0];
               n528SolicitudServicioComProvP = H008B12_n528SolicitudServicioComProvP[0];
               AssignAttri(sPrefix, false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
               A282ProveedorNombre = H008B12_A282ProveedorNombre[0];
               AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
               A741MudanzaDireccionDestino = H008B12_A741MudanzaDireccionDestino[0];
               AssignAttri(sPrefix, false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
               A740MudanzaDireccionOrigen = H008B12_A740MudanzaDireccionOrigen[0];
               AssignAttri(sPrefix, false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
               A132EstadosSolNombre = H008B12_A132EstadosSolNombre[0];
               AssignAttri(sPrefix, false, "A132EstadosSolNombre", A132EstadosSolNombre);
               A116PaisID = H008B12_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               GXADEPARTAMENTOID_html8B2( ) ;
               GXADEPARTAMENTOMUNICIPIOID_html8B2( ) ;
               GXAZONASID_html8B2( ) ;
               GXAMETODOPAGOSID_html8B2( ) ;
               if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  AssignAttri(sPrefix, false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
                     AssignAttri(sPrefix, false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
                  }
                  else
                  {
                     if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                     {
                        A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                        AssignAttri(sPrefix, false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
                     }
                     else
                     {
                        A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                        AssignAttri(sPrefix, false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
                     }
                  }
               }
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                        AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                           AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                        }
                        else
                        {
                           A211SolicitudServicioPFinal = 0;
                           AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
                        }
                     }
                  }
               }
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                  AssignAttri(sPrefix, false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                     AssignAttri(sPrefix, false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        AssignAttri(sPrefix, false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
                     }
                     else
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        AssignAttri(sPrefix, false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
                     }
                  }
               }
               /* Execute user event: Load */
               E128B2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
            WB8B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8B2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "SolicitudesGeneral";
         GXADEPARTAMENTOID_html8B2( ) ;
         /* Using cursor H008B13 */
         pr_default.execute(11, new Object[] {n112DepartamentoId, A112DepartamentoId});
         A116PaisID = H008B13_A116PaisID[0];
         AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
         pr_default.close(11);
         GXADEPARTAMENTOMUNICIPIOID_html8B2( ) ;
         GXAZONASID_html8B2( ) ;
         GXAMETODOPAGOSID_html8B2( ) ;
         GetSolicitudesTotal( A127SolicitudesID) ;
         edtSolicitudesID_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         edtSolicitudesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTelefono_Enabled), 5, 0), true);
         edtSolicitudesMail_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesMail_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorNombreAux_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorNombreAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombreAux_Enabled), 5, 0), true);
         cmbSolicitudesSubTipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbSolicitudesSubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesSubTipo.Enabled), 5, 0), true);
         edtEstadosSolNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosSolNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolNombre_Enabled), 5, 0), true);
         dynDepartamentoId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         dynZonasID.Enabled = 0;
         AssignProp(sPrefix, false, dynZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynZonasID.Enabled), 5, 0), true);
         edtSolicitudesDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesDireccion_Enabled), 5, 0), true);
         edtMudanzaDireccionOrigen_Enabled = 0;
         AssignProp(sPrefix, false, edtMudanzaDireccionOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Enabled), 5, 0), true);
         edtMudanzaDireccionDestino_Enabled = 0;
         AssignProp(sPrefix, false, edtMudanzaDireccionDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionDestino_Enabled), 5, 0), true);
         chkSolicitudesOtros1.Enabled = 0;
         AssignProp(sPrefix, false, chkSolicitudesOtros1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudesOtros1.Enabled), 5, 0), true);
         edtSolicitudesOtros2_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesOtros2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros2_Enabled), 5, 0), true);
         edtSolicitudesFechaInstalacion_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesFechaInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaInstalacion_Enabled), 5, 0), true);
         cmbSolicitudesHoraInstalacion.Enabled = 0;
         AssignProp(sPrefix, false, cmbSolicitudesHoraInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesHoraInstalacion.Enabled), 5, 0), true);
         edtSolicitudesTotal_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTotal_Enabled), 5, 0), true);
         chkSolicitudServicioSolCoti.Enabled = 0;
         AssignProp(sPrefix, false, chkSolicitudServicioSolCoti_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudServicioSolCoti.Enabled), 5, 0), true);
         edtSolicitudesCotizacion_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesCotizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCotizacion_Enabled), 5, 0), true);
         edtSolicitudServicioPFinal_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioPFinal_Enabled), 5, 0), true);
         edtSolicitudesComisionMetodoPago_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesComisionMetodoPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesComisionMetodoPago_Enabled), 5, 0), true);
         edtSolicitudServicioComProv_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProv_Enabled), 5, 0), true);
         edtSolicitudServicioComProvP_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComProvP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProvP_Enabled), 5, 0), true);
         edtSolicitudServicioComALM_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComALM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALM_Enabled), 5, 0), true);
         edtSolicitudServicioComALMP_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComALMP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALMP_Enabled), 5, 0), true);
         edtSolicitudServicioComPro_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComPro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComPro_Enabled), 5, 0), true);
         edtSolicitudServicioComProP_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudServicioComProP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProP_Enabled), 5, 0), true);
         chkSolicitudesCalComi.Enabled = 0;
         AssignProp(sPrefix, false, chkSolicitudesCalComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudesCalComi.Enabled), 5, 0), true);
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         AssignProp(sPrefix, false, cmbSolicitudServicioOrigenPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudServicioOrigenPago.Enabled), 5, 0), true);
         dynMetodoPagosID.Enabled = 0;
         AssignProp(sPrefix, false, dynMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMetodoPagosID.Enabled), 5, 0), true);
         cmbSolicitudesPagado.Enabled = 0;
         AssignProp(sPrefix, false, cmbSolicitudesPagado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesPagado.Enabled), 5, 0), true);
         edtSolicitudesOtros3_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesOtros3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros3_Enabled), 5, 0), true);
         edtSolicitudesComentario_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesComentario_Enabled), 5, 0), true);
         edtSolicitudesNota_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesNota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNota_Enabled), 5, 0), true);
         cmbSolicitudesNotificacion.Enabled = 0;
         AssignProp(sPrefix, false, cmbSolicitudesNotificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesNotificacion.Enabled), 5, 0), true);
         dynSolicitudesUsrAlta.Enabled = 0;
         AssignProp(sPrefix, false, dynSolicitudesUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSolicitudesUsrAlta.Enabled), 5, 0), true);
         edtSolicitudesFechaActualizacion_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaActualizacion_Enabled), 5, 0), true);
         dynSolicitudesUsrActualizacion.Enabled = 0;
         AssignProp(sPrefix, false, dynSolicitudesUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSolicitudesUsrActualizacion.Enabled), 5, 0), true);
         edtSolicitudesAutoEnumerar_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesAutoEnumerar_Enabled), 5, 0), true);
         edtSolicitudesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtSolicitudesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaAlta_Enabled), 5, 0), true);
         edtEstadosSolTipo_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA127SolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_transactiondetail_data3_Width = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Width");
            Dvpanel_transactiondetail_data3_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autowidth"));
            Dvpanel_transactiondetail_data3_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autoheight"));
            Dvpanel_transactiondetail_data3_Cls = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Cls");
            Dvpanel_transactiondetail_data3_Title = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Title");
            Dvpanel_transactiondetail_data3_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsible"));
            Dvpanel_transactiondetail_data3_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsed"));
            Dvpanel_transactiondetail_data3_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Showcollapseicon"));
            Dvpanel_transactiondetail_data3_Iconposition = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Iconposition");
            Dvpanel_transactiondetail_data3_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3_Autoscroll"));
            Dvpanel_transactiondetail_data4_Width = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Width");
            Dvpanel_transactiondetail_data4_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autowidth"));
            Dvpanel_transactiondetail_data4_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autoheight"));
            Dvpanel_transactiondetail_data4_Cls = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Cls");
            Dvpanel_transactiondetail_data4_Title = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Title");
            Dvpanel_transactiondetail_data4_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsible"));
            Dvpanel_transactiondetail_data4_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsed"));
            Dvpanel_transactiondetail_data4_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Showcollapseicon"));
            Dvpanel_transactiondetail_data4_Iconposition = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Iconposition");
            Dvpanel_transactiondetail_data4_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_Autoscroll"));
            Dvpanel_transactiondetail_data5_Width = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Width");
            Dvpanel_transactiondetail_data5_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autowidth"));
            Dvpanel_transactiondetail_data5_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autoheight"));
            Dvpanel_transactiondetail_data5_Cls = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Cls");
            Dvpanel_transactiondetail_data5_Title = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Title");
            Dvpanel_transactiondetail_data5_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Collapsible"));
            Dvpanel_transactiondetail_data5_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Collapsed"));
            Dvpanel_transactiondetail_data5_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Showcollapseicon"));
            Dvpanel_transactiondetail_data5_Iconposition = cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Iconposition");
            Dvpanel_transactiondetail_data5_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5_Autoscroll"));
            Gxuitabspanel_transactiondetail_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_transactiondetail_tabs1_Class = cgiGet( sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Class");
            Gxuitabspanel_transactiondetail_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Historymanagement"));
            /* Read variables values. */
            A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
            AssignAttri(sPrefix, false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
            A206SolicitudesMail = cgiGet( edtSolicitudesMail_Internalname);
            n206SolicitudesMail = false;
            AssignAttri(sPrefix, false, "A206SolicitudesMail", A206SolicitudesMail);
            A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
            AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
            A533ProveedorNombreAux = cgiGet( edtProveedorNombreAux_Internalname);
            n533ProveedorNombreAux = false;
            AssignAttri(sPrefix, false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
            cmbSolicitudesSubTipo.CurrentValue = cgiGet( cmbSolicitudesSubTipo_Internalname);
            A600SolicitudesSubTipo = cgiGet( cmbSolicitudesSubTipo_Internalname);
            n600SolicitudesSubTipo = false;
            AssignAttri(sPrefix, false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
            A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
            AssignAttri(sPrefix, false, "A132EstadosSolNombre", A132EstadosSolNombre);
            dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            dynZonasID.CurrentValue = cgiGet( dynZonasID_Internalname);
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynZonasID_Internalname), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A173SolicitudesDireccion = cgiGet( edtSolicitudesDireccion_Internalname);
            AssignAttri(sPrefix, false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
            A740MudanzaDireccionOrigen = cgiGet( edtMudanzaDireccionOrigen_Internalname);
            AssignAttri(sPrefix, false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
            A741MudanzaDireccionDestino = cgiGet( edtMudanzaDireccionDestino_Internalname);
            AssignAttri(sPrefix, false, "A741MudanzaDireccionDestino", A741MudanzaDireccionDestino);
            A201SolicitudesOtros1 = ((StringUtil.StrCmp(cgiGet( chkSolicitudesOtros1_Internalname), "S")==0) ? "S" : "N");
            AssignAttri(sPrefix, false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
            A202SolicitudesOtros2 = cgiGet( edtSolicitudesOtros2_Internalname);
            AssignAttri(sPrefix, false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
            A184SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( edtSolicitudesFechaInstalacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
            cmbSolicitudesHoraInstalacion.CurrentValue = cgiGet( cmbSolicitudesHoraInstalacion_Internalname);
            A183SolicitudesHoraInstalacion = cgiGet( cmbSolicitudesHoraInstalacion_Internalname);
            AssignAttri(sPrefix, false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
            A174SolicitudesTotal = context.localUtil.CToN( cgiGet( edtSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
            A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(cgiGet( chkSolicitudServicioSolCoti_Internalname), "S")==0) ? "S" : "N");
            AssignAttri(sPrefix, false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
            A212SolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
            A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
            A796SolicitudesComisionMetodoPago = context.localUtil.CToN( cgiGet( edtSolicitudesComisionMetodoPago_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A796SolicitudesComisionMetodoPago", StringUtil.LTrimStr( A796SolicitudesComisionMetodoPago, 18, 2));
            A527SolicitudServicioComProv = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n527SolicitudServicioComProv = false;
            AssignAttri(sPrefix, false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
            A528SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n528SolicitudServicioComProvP = false;
            AssignAttri(sPrefix, false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
            A530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n530SolicitudServicioComALM = false;
            AssignAttri(sPrefix, false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
            A532SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n532SolicitudServicioComALMP = false;
            AssignAttri(sPrefix, false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
            A529SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtSolicitudServicioComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
            A531SolicitudServicioComProP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
            A672SolicitudesCalComi = StringUtil.StrToBool( cgiGet( chkSolicitudesCalComi_Internalname));
            AssignAttri(sPrefix, false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
            cmbSolicitudServicioOrigenPago.CurrentValue = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
            A438SolicitudServicioOrigenPago = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
            n438SolicitudServicioOrigenPago = false;
            AssignAttri(sPrefix, false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
            dynMetodoPagosID.CurrentValue = cgiGet( dynMetodoPagosID_Internalname);
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMetodoPagosID_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            cmbSolicitudesPagado.CurrentValue = cgiGet( cmbSolicitudesPagado_Internalname);
            A441SolicitudesPagado = cgiGet( cmbSolicitudesPagado_Internalname);
            n441SolicitudesPagado = false;
            AssignAttri(sPrefix, false, "A441SolicitudesPagado", A441SolicitudesPagado);
            A203SolicitudesOtros3 = cgiGet( edtSolicitudesOtros3_Internalname);
            AssignAttri(sPrefix, false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
            A205SolicitudesComentario = cgiGet( edtSolicitudesComentario_Internalname);
            AssignAttri(sPrefix, false, "A205SolicitudesComentario", A205SolicitudesComentario);
            A261SolicitudesNota = cgiGet( edtSolicitudesNota_Internalname);
            AssignAttri(sPrefix, false, "A261SolicitudesNota", A261SolicitudesNota);
            cmbSolicitudesNotificacion.CurrentValue = cgiGet( cmbSolicitudesNotificacion_Internalname);
            A262SolicitudesNotificacion = cgiGet( cmbSolicitudesNotificacion_Internalname);
            AssignAttri(sPrefix, false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
            dynSolicitudesUsrAlta.CurrentValue = cgiGet( dynSolicitudesUsrAlta_Internalname);
            A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynSolicitudesUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
            n597SolicitudesUsrAlta = false;
            AssignAttri(sPrefix, false, "A597SolicitudesUsrAlta", StringUtil.LTrimStr( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            A204SolicitudesFechaActualizacion = context.localUtil.CToT( cgiGet( edtSolicitudesFechaActualizacion_Internalname));
            n204SolicitudesFechaActualizacion = false;
            AssignAttri(sPrefix, false, "A204SolicitudesFechaActualizacion", context.localUtil.TToC( A204SolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            dynSolicitudesUsrActualizacion.CurrentValue = cgiGet( dynSolicitudesUsrActualizacion_Internalname);
            A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( cgiGet( dynSolicitudesUsrActualizacion_Internalname), "."), 18, MidpointRounding.ToEven));
            n598SolicitudesUsrActualizacion = false;
            AssignAttri(sPrefix, false, "A598SolicitudesUsrActualizacion", StringUtil.LTrimStr( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            A194SolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A194SolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A194SolicitudesAutoEnumerar), 4, 0));
            A182SolicitudesFechaAlta = context.localUtil.CToD( cgiGet( edtSolicitudesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            n182SolicitudesFechaAlta = false;
            AssignAttri(sPrefix, false, "A182SolicitudesFechaAlta", context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"));
            A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
            AssignAttri(sPrefix, false, "A130EstadosSolTipo", A130EstadosSolTipo);
            AV16ProfesionalesId = cgiGet( edtavProfesionalesid_Internalname);
            AssignAttri(sPrefix, false, "AV16ProfesionalesId", AV16ProfesionalesId);
            A116PaisID = cgiGet( edtPaisID_Internalname);
            AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"SolicitudesGeneral");
            A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
            AssignAttri(sPrefix, false, "A130EstadosSolTipo", A130EstadosSolTipo);
            forbiddenHiddens.Add("EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("solicitudesgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXADEPARTAMENTOID_html8B2( ) ;
            GXADEPARTAMENTOMUNICIPIOID_html8B2( ) ;
            GXAZONASID_html8B2( ) ;
            GXAMETODOPAGOSID_html8B2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E118B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E118B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E128B2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A130EstadosSolTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A131EstadosSolId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtEstadosSolNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtEstadosSolNombre_Internalname, "Link", edtEstadosSolNombre_Link, true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "solicitudesrelacionview.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSolicitudesNombre_Link = formatLink("solicitudesrelacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtSolicitudesNombre_Internalname, "Link", edtSolicitudesNombre_Link, true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtProveedorNombre_Internalname, "Link", edtProveedorNombre_Link, true);
         }
         edtSolicitudesAutoEnumerar_Visible = 0;
         AssignProp(sPrefix, false, edtSolicitudesAutoEnumerar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesAutoEnumerar_Visible), 5, 0), true);
         edtSolicitudesFechaAlta_Visible = 0;
         AssignProp(sPrefix, false, edtSolicitudesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaAlta_Visible), 5, 0), true);
         edtEstadosSolTipo_Visible = 0;
         AssignProp(sPrefix, false, edtEstadosSolTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Visible), 5, 0), true);
         edtavProfesionalesid_Visible = 0;
         AssignProp(sPrefix, false, edtavProfesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesid_Visible), 5, 0), true);
         edtPaisID_Visible = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         if ( ! ( ! (0==A735MudanzaId) ) )
         {
            edtMudanzaDireccionOrigen_Visible = 0;
            AssignProp(sPrefix, false, edtMudanzaDireccionOrigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Visible), 5, 0), true);
            divMudanzadireccionorigen_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divMudanzadireccionorigen_cell_Internalname, "Class", divMudanzadireccionorigen_cell_Class, true);
         }
         else
         {
            edtMudanzaDireccionOrigen_Visible = 1;
            AssignProp(sPrefix, false, edtMudanzaDireccionOrigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Visible), 5, 0), true);
            divMudanzadireccionorigen_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp(sPrefix, false, divMudanzadireccionorigen_cell_Internalname, "Class", divMudanzadireccionorigen_cell_Class, true);
         }
         if ( ! ( ! (0==A735MudanzaId) ) )
         {
            edtMudanzaDireccionDestino_Visible = 0;
            AssignProp(sPrefix, false, edtMudanzaDireccionDestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionDestino_Visible), 5, 0), true);
            divMudanzadirecciondestino_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divMudanzadirecciondestino_cell_Internalname, "Class", divMudanzadirecciondestino_cell_Class, true);
         }
         else
         {
            edtMudanzaDireccionDestino_Visible = 1;
            AssignProp(sPrefix, false, edtMudanzaDireccionDestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionDestino_Visible), 5, 0), true);
            divMudanzadirecciondestino_cell_Class = "col-xs-12 col-sm-6 DataContentCellFL";
            AssignProp(sPrefix, false, divMudanzadirecciondestino_cell_Internalname, "Class", divMudanzadirecciondestino_cell_Class, true);
         }
         if ( ! ( ( AV15Administrar ) ) )
         {
            grpUnnamedgroup1_Class = "Invisible";
            AssignProp(sPrefix, false, grpUnnamedgroup1_Internalname, "Class", grpUnnamedgroup1_Class, true);
         }
         else
         {
            grpUnnamedgroup1_Class = "Group";
            AssignProp(sPrefix, false, grpUnnamedgroup1_Internalname, "Class", grpUnnamedgroup1_Class, true);
         }
         if ( ! ( ( AV15Administrar ) ) )
         {
            divDvpanel_transactiondetail_data4_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divDvpanel_transactiondetail_data4_cell_Internalname, "Class", divDvpanel_transactiondetail_data4_cell_Class, true);
         }
         else
         {
            divDvpanel_transactiondetail_data4_cell_Class = "col-xs-12 col-sm-6";
            AssignProp(sPrefix, false, divDvpanel_transactiondetail_data4_cell_Internalname, "Class", divDvpanel_transactiondetail_data4_cell_Class, true);
         }
         if ( ! ( ( AV15Administrar ) ) )
         {
            grpUnnamedgroup2_Class = "Invisible";
            AssignProp(sPrefix, false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
         else
         {
            grpUnnamedgroup2_Class = "Group";
            AssignProp(sPrefix, false, grpUnnamedgroup2_Internalname, "Class", grpUnnamedgroup2_Class, true);
         }
         if ( ! ( ( AV15Administrar ) ) )
         {
            grpUnnamedgroup3_Class = "Invisible";
            AssignProp(sPrefix, false, grpUnnamedgroup3_Internalname, "Class", grpUnnamedgroup3_Class, true);
         }
         else
         {
            grpUnnamedgroup3_Class = "Group";
            AssignProp(sPrefix, false, grpUnnamedgroup3_Internalname, "Class", grpUnnamedgroup3_Class, true);
         }
      }

      protected void E138B2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
         CallWebObject(formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E148B2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
         CallWebObject(formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Solicitudes";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table2_238_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTransactiondetail_auditoria_Internalname, tblTransactiondetail_auditoria_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynSolicitudesUsrAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynSolicitudesUsrAlta_Internalname, context.GetMessage( "Usuario de Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 243,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynSolicitudesUsrAlta, dynSolicitudesUsrAlta_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0)), 1, dynSolicitudesUsrAlta_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSolicitudesUsrAlta.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,243);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynSolicitudesUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            AssignProp(sPrefix, false, dynSolicitudesUsrAlta_Internalname, "Values", (string)(dynSolicitudesUsrAlta.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesFechaActualizacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudesFechaActualizacion_Internalname, context.GetMessage( "Actualizacion Fecha", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 247,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaActualizacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaActualizacion_Internalname, context.localUtil.TToC( A204SolicitudesFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A204SolicitudesFechaActualizacion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,247);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaActualizacion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtSolicitudesFechaActualizacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaActualizacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynSolicitudesUsrActualizacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynSolicitudesUsrActualizacion_Internalname, context.GetMessage( "Usuario Actualizacion", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynSolicitudesUsrActualizacion, dynSolicitudesUsrActualizacion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0)), 1, dynSolicitudesUsrActualizacion_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSolicitudesUsrActualizacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "", true, 0, "HLP_SolicitudesGeneral.htm");
            dynSolicitudesUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A598SolicitudesUsrActualizacion), 10, 0));
            AssignProp(sPrefix, false, dynSolicitudesUsrActualizacion_Internalname, "Values", (string)(dynSolicitudesUsrActualizacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_238_8B2e( true) ;
         }
         else
         {
            wb_table2_238_8B2e( false) ;
         }
      }

      protected void wb_table1_206_8B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTransactiondetail_costos_Internalname, tblTransactiondetail_costos_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock1_Internalname, context.GetMessage( "NOTA: Para asignar costos de forma correcta, es necesario haber guardado los cambios que pudiera haber realizado sobre la solicitud, del caso contrario estos no serán tomados en cuenta.", ""), "", "", lblTransactiondetail_textblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockAIExamples", 0, "", 1, 1, 0, 0, "HLP_SolicitudesGeneral.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_206_8B2e( true) ;
         }
         else
         {
            wb_table1_206_8B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A127SolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA8B2( ) ;
         WS8B2( ) ;
         WE8B2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA127SolicitudesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA8B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "solicitudesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A127SolicitudesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
         wcpOA127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA127SolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A127SolicitudesID != wcpOA127SolicitudesID ) ) )
         {
            setjustcreated();
         }
         wcpOA127SolicitudesID = A127SolicitudesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA127SolicitudesID = cgiGet( sPrefix+"A127SolicitudesID_CTRL");
         if ( StringUtil.Len( sCtrlA127SolicitudesID) > 0 )
         {
            A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA127SolicitudesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
         }
         else
         {
            A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A127SolicitudesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA8B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS8B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A127SolicitudesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA127SolicitudesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A127SolicitudesID_CTRL", StringUtil.RTrim( sCtrlA127SolicitudesID));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE8B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026980391343", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("solicitudesgeneral.js", "?2026980391344", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
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

      protected void init_web_controls( )
      {
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
         }
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
         dynZonasID.Name = "ZONASID";
         dynZonasID.WebTags = "";
         chkSolicitudesOtros1.Name = "SOLICITUDESOTROS1";
         chkSolicitudesOtros1.WebTags = "";
         chkSolicitudesOtros1.Caption = context.GetMessage( "No aparecen en el listado los servicios que necesito.", "");
         AssignProp(sPrefix, false, chkSolicitudesOtros1_Internalname, "TitleCaption", chkSolicitudesOtros1.Caption, true);
         chkSolicitudesOtros1.CheckedValue = "N";
         cmbSolicitudesHoraInstalacion.Name = "SOLICITUDESHORAINSTALACION";
         cmbSolicitudesHoraInstalacion.WebTags = "";
         cmbSolicitudesHoraInstalacion.addItem("1", context.GetMessage( "Turno 1, 8:00-12:00", ""), 0);
         cmbSolicitudesHoraInstalacion.addItem("2", context.GetMessage( "Turno 2, 12:00-16:00", ""), 0);
         cmbSolicitudesHoraInstalacion.addItem("3", context.GetMessage( "Turno 3, 16:00-20:00", ""), 0);
         if ( cmbSolicitudesHoraInstalacion.ItemCount > 0 )
         {
         }
         chkSolicitudServicioSolCoti.Name = "SOLICITUDSERVICIOSOLCOTI";
         chkSolicitudServicioSolCoti.WebTags = "";
         chkSolicitudServicioSolCoti.Caption = context.GetMessage( "Solicitar cotización ", "");
         AssignProp(sPrefix, false, chkSolicitudServicioSolCoti_Internalname, "TitleCaption", chkSolicitudServicioSolCoti.Caption, true);
         chkSolicitudServicioSolCoti.CheckedValue = "N";
         chkSolicitudesCalComi.Name = "SOLICITUDESCALCOMI";
         chkSolicitudesCalComi.WebTags = "";
         chkSolicitudesCalComi.Caption = context.GetMessage( "Calcular Comisión", "");
         AssignProp(sPrefix, false, chkSolicitudesCalComi_Internalname, "TitleCaption", chkSolicitudesCalComi.Caption, true);
         chkSolicitudesCalComi.CheckedValue = "false";
         cmbSolicitudServicioOrigenPago.Name = "SOLICITUDSERVICIOORIGENPAGO";
         cmbSolicitudServicioOrigenPago.WebTags = "";
         cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
         }
         dynMetodoPagosID.Name = "METODOPAGOSID";
         dynMetodoPagosID.WebTags = "";
         cmbSolicitudesPagado.Name = "SOLICITUDESPAGADO";
         cmbSolicitudesPagado.WebTags = "";
         cmbSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbSolicitudesPagado.ItemCount > 0 )
         {
         }
         cmbSolicitudesNotificacion.Name = "SOLICITUDESNOTIFICACION";
         cmbSolicitudesNotificacion.WebTags = "";
         cmbSolicitudesNotificacion.addItem("S", context.GetMessage( "Si", ""), 0);
         cmbSolicitudesNotificacion.addItem("N", context.GetMessage( "No", ""), 0);
         if ( cmbSolicitudesNotificacion.ItemCount > 0 )
         {
         }
         dynSolicitudesUsrAlta.Name = "SOLICITUDESUSRALTA";
         dynSolicitudesUsrAlta.WebTags = "";
         dynSolicitudesUsrAlta.removeAllItems();
         /* Using cursor H008B14 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            dynSolicitudesUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H008B14_A18SecUserId[0]), 10, 0)), H008B14_A587SecUserFullName[0], 0);
            pr_default.readNext(12);
         }
         pr_default.close(12);
         if ( dynSolicitudesUsrAlta.ItemCount > 0 )
         {
         }
         dynSolicitudesUsrActualizacion.Name = "SOLICITUDESUSRACTUALIZACION";
         dynSolicitudesUsrActualizacion.WebTags = "";
         dynSolicitudesUsrActualizacion.removeAllItems();
         /* Using cursor H008B15 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            dynSolicitudesUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H008B15_A18SecUserId[0]), 10, 0)), H008B15_A587SecUserFullName[0], 0);
            pr_default.readNext(13);
         }
         pr_default.close(13);
         if ( dynSolicitudesUsrActualizacion.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblDatosgenerales_title_Internalname = sPrefix+"DATOSGENERALES_TITLE";
         edtSolicitudesID_Internalname = sPrefix+"SOLICITUDESID";
         edtSolicitudesNombre_Internalname = sPrefix+"SOLICITUDESNOMBRE";
         edtSolicitudesTelefono_Internalname = sPrefix+"SOLICITUDESTELEFONO";
         edtSolicitudesMail_Internalname = sPrefix+"SOLICITUDESMAIL";
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE";
         edtProveedorNombreAux_Internalname = sPrefix+"PROVEEDORNOMBREAUX";
         divTransactiondetail_data1_Internalname = sPrefix+"TRANSACTIONDETAIL_DATA1";
         cmbSolicitudesSubTipo_Internalname = sPrefix+"SOLICITUDESSUBTIPO";
         edtEstadosSolNombre_Internalname = sPrefix+"ESTADOSSOLNOMBRE";
         dynDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID";
         dynZonasID_Internalname = sPrefix+"ZONASID";
         edtSolicitudesDireccion_Internalname = sPrefix+"SOLICITUDESDIRECCION";
         edtMudanzaDireccionOrigen_Internalname = sPrefix+"MUDANZADIRECCIONORIGEN";
         divMudanzadireccionorigen_cell_Internalname = sPrefix+"MUDANZADIRECCIONORIGEN_CELL";
         edtMudanzaDireccionDestino_Internalname = sPrefix+"MUDANZADIRECCIONDESTINO";
         divMudanzadirecciondestino_cell_Internalname = sPrefix+"MUDANZADIRECCIONDESTINO_CELL";
         divTransactiondetail_data2_Internalname = sPrefix+"TRANSACTIONDETAIL_DATA2";
         chkSolicitudesOtros1_Internalname = sPrefix+"SOLICITUDESOTROS1";
         edtSolicitudesOtros2_Internalname = sPrefix+"SOLICITUDESOTROS2";
         edtSolicitudesFechaInstalacion_Internalname = sPrefix+"SOLICITUDESFECHAINSTALACION";
         cmbSolicitudesHoraInstalacion_Internalname = sPrefix+"SOLICITUDESHORAINSTALACION";
         grpUnnamedgroup3_Internalname = sPrefix+"UNNAMEDGROUP3";
         divTransactiondetail_tbdata1_Internalname = sPrefix+"TRANSACTIONDETAIL_TBDATA1";
         lblDatosservicio_title_Internalname = sPrefix+"DATOSSERVICIO_TITLE";
         divTransactiondetail_tableleaflevel_items_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLELEAFLEVEL_ITEMS";
         edtSolicitudesTotal_Internalname = sPrefix+"SOLICITUDESTOTAL";
         chkSolicitudServicioSolCoti_Internalname = sPrefix+"SOLICITUDSERVICIOSOLCOTI";
         edtSolicitudesCotizacion_Internalname = sPrefix+"SOLICITUDESCOTIZACION";
         edtSolicitudServicioPFinal_Internalname = sPrefix+"SOLICITUDSERVICIOPFINAL";
         edtSolicitudesComisionMetodoPago_Internalname = sPrefix+"SOLICITUDESCOMISIONMETODOPAGO";
         divTransactiondetail_data3_Internalname = sPrefix+"TRANSACTIONDETAIL_DATA3";
         Dvpanel_transactiondetail_data3_Internalname = sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA3";
         edtSolicitudServicioComProv_Internalname = sPrefix+"SOLICITUDSERVICIOCOMPROV";
         edtSolicitudServicioComProvP_Internalname = sPrefix+"SOLICITUDSERVICIOCOMPROVP";
         edtSolicitudServicioComALM_Internalname = sPrefix+"SOLICITUDSERVICIOCOMALM";
         edtSolicitudServicioComALMP_Internalname = sPrefix+"SOLICITUDSERVICIOCOMALMP";
         edtSolicitudServicioComPro_Internalname = sPrefix+"SOLICITUDSERVICIOCOMPRO";
         edtSolicitudServicioComProP_Internalname = sPrefix+"SOLICITUDSERVICIOCOMPROP";
         chkSolicitudesCalComi_Internalname = sPrefix+"SOLICITUDESCALCOMI";
         divTransactiondetail_data4_Internalname = sPrefix+"TRANSACTIONDETAIL_DATA4";
         Dvpanel_transactiondetail_data4_Internalname = sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4";
         divDvpanel_transactiondetail_data4_cell_Internalname = sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA4_CELL";
         cmbSolicitudServicioOrigenPago_Internalname = sPrefix+"SOLICITUDSERVICIOORIGENPAGO";
         dynMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID";
         cmbSolicitudesPagado_Internalname = sPrefix+"SOLICITUDESPAGADO";
         divTransactiondetail_data5_Internalname = sPrefix+"TRANSACTIONDETAIL_DATA5";
         Dvpanel_transactiondetail_data5_Internalname = sPrefix+"DVPANEL_TRANSACTIONDETAIL_DATA5";
         lblTransactiondetail_textblock1_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK1";
         tblTransactiondetail_costos_Internalname = sPrefix+"TRANSACTIONDETAIL_COSTOS";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         divTransactiondetail_tbdata2_Internalname = sPrefix+"TRANSACTIONDETAIL_TBDATA2";
         lblInformacion_title_Internalname = sPrefix+"INFORMACION_TITLE";
         edtSolicitudesOtros3_Internalname = sPrefix+"SOLICITUDESOTROS3";
         edtSolicitudesComentario_Internalname = sPrefix+"SOLICITUDESCOMENTARIO";
         edtSolicitudesNota_Internalname = sPrefix+"SOLICITUDESNOTA";
         cmbSolicitudesNotificacion_Internalname = sPrefix+"SOLICITUDESNOTIFICACION";
         dynSolicitudesUsrAlta_Internalname = sPrefix+"SOLICITUDESUSRALTA";
         edtSolicitudesFechaActualizacion_Internalname = sPrefix+"SOLICITUDESFECHAACTUALIZACION";
         dynSolicitudesUsrActualizacion_Internalname = sPrefix+"SOLICITUDESUSRACTUALIZACION";
         tblTransactiondetail_auditoria_Internalname = sPrefix+"TRANSACTIONDETAIL_AUDITORIA";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTransactiondetail_tbdata3_Internalname = sPrefix+"TRANSACTIONDETAIL_TBDATA3";
         Gxuitabspanel_transactiondetail_tabs1_Internalname = sPrefix+"GXUITABSPANEL_TRANSACTIONDETAIL_TABS1";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtSolicitudesAutoEnumerar_Internalname = sPrefix+"SOLICITUDESAUTOENUMERAR";
         edtSolicitudesFechaAlta_Internalname = sPrefix+"SOLICITUDESFECHAALTA";
         edtEstadosSolTipo_Internalname = sPrefix+"ESTADOSSOLTIPO";
         edtavProfesionalesid_Internalname = sPrefix+"vPROFESIONALESID";
         edtPaisID_Internalname = sPrefix+"PAISID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkSolicitudesCalComi.Caption = context.GetMessage( "Calcular Comisión", "");
         chkSolicitudServicioSolCoti.Caption = context.GetMessage( "Solicitar cotización ", "");
         chkSolicitudesOtros1.Caption = context.GetMessage( "No aparecen en el listado los servicios que necesito.", "");
         dynSolicitudesUsrActualizacion_Jsonclick = "";
         edtSolicitudesFechaActualizacion_Jsonclick = "";
         dynSolicitudesUsrAlta_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtSolicitudesFechaAlta_Enabled = 0;
         edtSolicitudesAutoEnumerar_Enabled = 0;
         dynSolicitudesUsrActualizacion.Enabled = 0;
         edtSolicitudesFechaActualizacion_Enabled = 0;
         dynSolicitudesUsrAlta.Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Visible = 1;
         edtavProfesionalesid_Jsonclick = "";
         edtavProfesionalesid_Visible = 1;
         edtEstadosSolTipo_Jsonclick = "";
         edtEstadosSolTipo_Visible = 1;
         edtSolicitudesFechaAlta_Jsonclick = "";
         edtSolicitudesFechaAlta_Visible = 1;
         edtSolicitudesAutoEnumerar_Jsonclick = "";
         edtSolicitudesAutoEnumerar_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         grpUnnamedgroup1_Class = "Group";
         cmbSolicitudesNotificacion_Jsonclick = "";
         cmbSolicitudesNotificacion.Enabled = 0;
         edtSolicitudesNota_Enabled = 0;
         edtSolicitudesComentario_Enabled = 0;
         edtSolicitudesOtros3_Enabled = 0;
         grpUnnamedgroup2_Class = "Group";
         cmbSolicitudesPagado_Jsonclick = "";
         cmbSolicitudesPagado.Enabled = 0;
         dynMetodoPagosID_Jsonclick = "";
         dynMetodoPagosID.Enabled = 0;
         cmbSolicitudServicioOrigenPago_Jsonclick = "";
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         chkSolicitudesCalComi.Enabled = 0;
         edtSolicitudServicioComProP_Jsonclick = "";
         edtSolicitudServicioComProP_Enabled = 0;
         edtSolicitudServicioComPro_Jsonclick = "";
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudServicioComALMP_Jsonclick = "";
         edtSolicitudServicioComALMP_Enabled = 0;
         edtSolicitudServicioComALM_Jsonclick = "";
         edtSolicitudServicioComALM_Enabled = 0;
         edtSolicitudServicioComProvP_Jsonclick = "";
         edtSolicitudServicioComProvP_Enabled = 0;
         edtSolicitudServicioComProv_Jsonclick = "";
         edtSolicitudServicioComProv_Enabled = 0;
         divDvpanel_transactiondetail_data4_cell_Class = "col-xs-12 col-sm-6";
         edtSolicitudesComisionMetodoPago_Jsonclick = "";
         edtSolicitudesComisionMetodoPago_Enabled = 0;
         edtSolicitudServicioPFinal_Jsonclick = "";
         edtSolicitudServicioPFinal_Enabled = 0;
         edtSolicitudesCotizacion_Jsonclick = "";
         edtSolicitudesCotizacion_Enabled = 0;
         chkSolicitudServicioSolCoti.Enabled = 0;
         edtSolicitudesTotal_Jsonclick = "";
         edtSolicitudesTotal_Enabled = 0;
         grpUnnamedgroup3_Class = "Group";
         cmbSolicitudesHoraInstalacion_Jsonclick = "";
         cmbSolicitudesHoraInstalacion.Enabled = 0;
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtSolicitudesOtros2_Enabled = 0;
         chkSolicitudesOtros1.Enabled = 0;
         edtMudanzaDireccionDestino_Enabled = 0;
         edtMudanzaDireccionDestino_Visible = 1;
         divMudanzadirecciondestino_cell_Class = "col-xs-12 col-sm-6";
         edtMudanzaDireccionOrigen_Enabled = 0;
         edtMudanzaDireccionOrigen_Visible = 1;
         divMudanzadireccionorigen_cell_Class = "col-xs-12 col-sm-6";
         edtSolicitudesDireccion_Enabled = 0;
         dynZonasID_Jsonclick = "";
         dynZonasID.Enabled = 0;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 0;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 0;
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolNombre_Link = "";
         edtEstadosSolNombre_Enabled = 0;
         cmbSolicitudesSubTipo_Jsonclick = "";
         cmbSolicitudesSubTipo.Enabled = 0;
         edtProveedorNombreAux_Jsonclick = "";
         edtProveedorNombreAux_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedorNombre_Enabled = 0;
         edtSolicitudesMail_Jsonclick = "";
         edtSolicitudesMail_Enabled = 0;
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Link = "";
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesID_Jsonclick = "";
         edtSolicitudesID_Enabled = 0;
         Gxuitabspanel_transactiondetail_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_transactiondetail_tabs1_Class = "Tab";
         Gxuitabspanel_transactiondetail_tabs1_Pagecount = 3;
         Dvpanel_transactiondetail_data5_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data5_Iconposition = "Right";
         Dvpanel_transactiondetail_data5_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data5_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data5_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data5_Title = context.GetMessage( "Datos del Pago", "");
         Dvpanel_transactiondetail_data5_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_transactiondetail_data5_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data5_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data5_Width = "100%";
         Dvpanel_transactiondetail_data4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data4_Iconposition = "Right";
         Dvpanel_transactiondetail_data4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data4_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data4_Title = context.GetMessage( "Comisiones Generadas", "");
         Dvpanel_transactiondetail_data4_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_transactiondetail_data4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data4_Width = "100%";
         Dvpanel_transactiondetail_data3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data3_Iconposition = "Right";
         Dvpanel_transactiondetail_data3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data3_Title = context.GetMessage( "Valor del Servicio", "");
         Dvpanel_transactiondetail_data3_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_transactiondetail_data3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_transactiondetail_data3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_transactiondetail_data3_Width = "100%";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMetodoPagosID'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynSolicitudesUsrActualizacion'},{av:'A598SolicitudesUsrActualizacion',fld:'SOLICITUDESUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynSolicitudesUsrAlta'},{av:'A597SolicitudesUsrAlta',fld:'SOLICITUDESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'A672SolicitudesCalComi',fld:'SOLICITUDESCALCOMI',pic:'',type:'boolean'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E138B2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E148B2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESTOTAL","{handler:'Valid_Solicitudestotal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESTOTAL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION","{handler:'Valid_Solicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL","{handler:'Valid_Solicitudserviciopfinal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOMISIONMETODOPAGO","{handler:'Valid_Solicitudescomisionmetodopago',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOMISIONMETODOPAGO",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV","{handler:'Valid_Solicitudserviciocomprov',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP","{handler:'Valid_Solicitudserviciocomprovp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM","{handler:'Valid_Solicitudserviciocomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP","{handler:'Valid_Solicitudserviciocomalmp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[]}");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17Pgmname = "";
         H008B2_A116PaisID = new string[] {""} ;
         A116PaisID = "";
         H008B3_A127SolicitudesID = new long[1] ;
         H008B3_A134SolicitudesItemsID = new short[1] ;
         H008B3_A180SolicitudItemsComision = new decimal[1] ;
         H008B3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H008B3_A178SolicitudItemsSR = new string[] {""} ;
         H008B3_A177SolicitudesItemsCantidad = new short[1] ;
         H008B3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H008B3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         A130EstadosSolTipo = "";
         GX_FocusControl = "";
         ucGxuitabspanel_transactiondetail_tabs1 = new GXUserControl();
         lblDatosgenerales_title_Jsonclick = "";
         TempTags = "";
         A171SolicitudesNombre = "";
         gxphoneLink = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A282ProveedorNombre = "";
         A533ProveedorNombreAux = "";
         A600SolicitudesSubTipo = "";
         A132EstadosSolNombre = "";
         ClassString = "";
         StyleString = "";
         A173SolicitudesDireccion = "";
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A201SolicitudesOtros1 = "";
         A202SolicitudesOtros2 = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         lblDatosservicio_title_Jsonclick = "";
         ucDvpanel_transactiondetail_data3 = new GXUserControl();
         A210SolicitudServicioSolCoti = "";
         ucDvpanel_transactiondetail_data4 = new GXUserControl();
         ucDvpanel_transactiondetail_data5 = new GXUserControl();
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         lblInformacion_title_Jsonclick = "";
         A203SolicitudesOtros3 = "";
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         AV16ProfesionalesId = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H008B4_A18SecUserId = new long[1] ;
         H008B4_A587SecUserFullName = new string[] {""} ;
         H008B5_A18SecUserId = new long[1] ;
         H008B5_A587SecUserFullName = new string[] {""} ;
         H008B6_A112DepartamentoId = new long[1] ;
         H008B6_n112DepartamentoId = new bool[] {false} ;
         H008B6_A113DepartamentoDepartamento = new string[] {""} ;
         H008B7_A112DepartamentoId = new long[1] ;
         H008B7_n112DepartamentoId = new bool[] {false} ;
         H008B7_A114DepartamentoMunicipioId = new long[1] ;
         H008B7_n114DepartamentoMunicipioId = new bool[] {false} ;
         H008B7_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H008B8_A112DepartamentoId = new long[1] ;
         H008B8_n112DepartamentoId = new bool[] {false} ;
         H008B8_A114DepartamentoMunicipioId = new long[1] ;
         H008B8_n114DepartamentoMunicipioId = new bool[] {false} ;
         H008B8_A110ZonasID = new long[1] ;
         H008B8_n110ZonasID = new bool[] {false} ;
         H008B8_A111ZonasNombre = new string[] {""} ;
         H008B9_A128MetodoPagosID = new long[1] ;
         H008B9_A129MetodoPagosNombre = new string[] {""} ;
         H008B9_A108EstadosGenericosId = new int[1] ;
         H008B10_A18SecUserId = new long[1] ;
         H008B10_A587SecUserFullName = new string[] {""} ;
         H008B11_A18SecUserId = new long[1] ;
         H008B11_A587SecUserFullName = new string[] {""} ;
         H008B12_A127SolicitudesID = new long[1] ;
         H008B12_A131EstadosSolId = new int[1] ;
         H008B12_A133ProveedorID = new long[1] ;
         H008B12_A735MudanzaId = new long[1] ;
         H008B12_n735MudanzaId = new bool[] {false} ;
         H008B12_A116PaisID = new string[] {""} ;
         H008B12_A130EstadosSolTipo = new string[] {""} ;
         H008B12_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H008B12_n182SolicitudesFechaAlta = new bool[] {false} ;
         H008B12_A194SolicitudesAutoEnumerar = new short[1] ;
         H008B12_A598SolicitudesUsrActualizacion = new long[1] ;
         H008B12_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         H008B12_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H008B12_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         H008B12_A597SolicitudesUsrAlta = new long[1] ;
         H008B12_n597SolicitudesUsrAlta = new bool[] {false} ;
         H008B12_A262SolicitudesNotificacion = new string[] {""} ;
         H008B12_A261SolicitudesNota = new string[] {""} ;
         H008B12_A205SolicitudesComentario = new string[] {""} ;
         H008B12_A203SolicitudesOtros3 = new string[] {""} ;
         H008B12_A441SolicitudesPagado = new string[] {""} ;
         H008B12_n441SolicitudesPagado = new bool[] {false} ;
         H008B12_A128MetodoPagosID = new long[1] ;
         H008B12_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H008B12_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H008B12_A672SolicitudesCalComi = new bool[] {false} ;
         H008B12_A210SolicitudServicioSolCoti = new string[] {""} ;
         H008B12_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H008B12_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H008B12_A202SolicitudesOtros2 = new string[] {""} ;
         H008B12_A201SolicitudesOtros1 = new string[] {""} ;
         H008B12_A741MudanzaDireccionDestino = new string[] {""} ;
         H008B12_A740MudanzaDireccionOrigen = new string[] {""} ;
         H008B12_A173SolicitudesDireccion = new string[] {""} ;
         H008B12_A110ZonasID = new long[1] ;
         H008B12_n110ZonasID = new bool[] {false} ;
         H008B12_A114DepartamentoMunicipioId = new long[1] ;
         H008B12_n114DepartamentoMunicipioId = new bool[] {false} ;
         H008B12_A112DepartamentoId = new long[1] ;
         H008B12_n112DepartamentoId = new bool[] {false} ;
         H008B12_A132EstadosSolNombre = new string[] {""} ;
         H008B12_A600SolicitudesSubTipo = new string[] {""} ;
         H008B12_n600SolicitudesSubTipo = new bool[] {false} ;
         H008B12_A533ProveedorNombreAux = new string[] {""} ;
         H008B12_n533ProveedorNombreAux = new bool[] {false} ;
         H008B12_A282ProveedorNombre = new string[] {""} ;
         H008B12_A206SolicitudesMail = new string[] {""} ;
         H008B12_n206SolicitudesMail = new bool[] {false} ;
         H008B12_A172SolicitudesTelefono = new string[] {""} ;
         H008B12_A171SolicitudesNombre = new string[] {""} ;
         H008B12_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H008B12_A212SolicitudesCotizacion = new decimal[1] ;
         H008B12_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H008B12_A897SolicitudesDescuento = new decimal[1] ;
         H008B12_n897SolicitudesDescuento = new bool[] {false} ;
         H008B12_A527SolicitudServicioComProv = new decimal[1] ;
         H008B12_n527SolicitudServicioComProv = new bool[] {false} ;
         H008B12_A530SolicitudServicioComALM = new decimal[1] ;
         H008B12_n530SolicitudServicioComALM = new bool[] {false} ;
         H008B12_A864SolicitudesCostoXZona = new decimal[1] ;
         H008B12_A532SolicitudServicioComALMP = new decimal[1] ;
         H008B12_n532SolicitudServicioComALMP = new bool[] {false} ;
         H008B12_A528SolicitudServicioComProvP = new decimal[1] ;
         H008B12_n528SolicitudServicioComProvP = new bool[] {false} ;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         H008B13_A116PaisID = new string[] {""} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         sStyleString = "";
         lblTransactiondetail_textblock1_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA127SolicitudesID = "";
         H008B14_A18SecUserId = new long[1] ;
         H008B14_A587SecUserFullName = new string[] {""} ;
         H008B15_A18SecUserId = new long[1] ;
         H008B15_A587SecUserFullName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesgeneral__default(),
            new Object[][] {
                new Object[] {
               H008B2_A116PaisID
               }
               , new Object[] {
               H008B3_A127SolicitudesID, H008B3_A134SolicitudesItemsID, H008B3_A180SolicitudItemsComision, H008B3_A179SolicitudItemsComisionTipo, H008B3_A178SolicitudItemsSR, H008B3_A177SolicitudesItemsCantidad, H008B3_A176SolicitudesItemsPrecioFinal, H008B3_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H008B4_A18SecUserId, H008B4_A587SecUserFullName
               }
               , new Object[] {
               H008B5_A18SecUserId, H008B5_A587SecUserFullName
               }
               , new Object[] {
               H008B6_A112DepartamentoId, H008B6_A113DepartamentoDepartamento
               }
               , new Object[] {
               H008B7_A112DepartamentoId, H008B7_A114DepartamentoMunicipioId, H008B7_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               H008B8_A112DepartamentoId, H008B8_A114DepartamentoMunicipioId, H008B8_A110ZonasID, H008B8_A111ZonasNombre
               }
               , new Object[] {
               H008B9_A128MetodoPagosID, H008B9_A129MetodoPagosNombre, H008B9_A108EstadosGenericosId
               }
               , new Object[] {
               H008B10_A18SecUserId, H008B10_A587SecUserFullName
               }
               , new Object[] {
               H008B11_A18SecUserId, H008B11_A587SecUserFullName
               }
               , new Object[] {
               H008B12_A127SolicitudesID, H008B12_A131EstadosSolId, H008B12_A133ProveedorID, H008B12_A735MudanzaId, H008B12_n735MudanzaId, H008B12_A116PaisID, H008B12_A130EstadosSolTipo, H008B12_A182SolicitudesFechaAlta, H008B12_n182SolicitudesFechaAlta, H008B12_A194SolicitudesAutoEnumerar,
               H008B12_A598SolicitudesUsrActualizacion, H008B12_n598SolicitudesUsrActualizacion, H008B12_A204SolicitudesFechaActualizacion, H008B12_n204SolicitudesFechaActualizacion, H008B12_A597SolicitudesUsrAlta, H008B12_n597SolicitudesUsrAlta, H008B12_A262SolicitudesNotificacion, H008B12_A261SolicitudesNota, H008B12_A205SolicitudesComentario, H008B12_A203SolicitudesOtros3,
               H008B12_A441SolicitudesPagado, H008B12_n441SolicitudesPagado, H008B12_A128MetodoPagosID, H008B12_A438SolicitudServicioOrigenPago, H008B12_n438SolicitudServicioOrigenPago, H008B12_A672SolicitudesCalComi, H008B12_A210SolicitudServicioSolCoti, H008B12_A183SolicitudesHoraInstalacion, H008B12_A184SolicitudesFechaInstalacion, H008B12_A202SolicitudesOtros2,
               H008B12_A201SolicitudesOtros1, H008B12_A741MudanzaDireccionDestino, H008B12_A740MudanzaDireccionOrigen, H008B12_A173SolicitudesDireccion, H008B12_A110ZonasID, H008B12_n110ZonasID, H008B12_A114DepartamentoMunicipioId, H008B12_n114DepartamentoMunicipioId, H008B12_A112DepartamentoId, H008B12_n112DepartamentoId,
               H008B12_A132EstadosSolNombre, H008B12_A600SolicitudesSubTipo, H008B12_n600SolicitudesSubTipo, H008B12_A533ProveedorNombreAux, H008B12_n533ProveedorNombreAux, H008B12_A282ProveedorNombre, H008B12_A206SolicitudesMail, H008B12_n206SolicitudesMail, H008B12_A172SolicitudesTelefono, H008B12_A171SolicitudesNombre,
               H008B12_A796SolicitudesComisionMetodoPago, H008B12_A212SolicitudesCotizacion, H008B12_A1016SolicitudesDescuentoCupon, H008B12_A897SolicitudesDescuento, H008B12_n897SolicitudesDescuento, H008B12_A527SolicitudServicioComProv, H008B12_n527SolicitudServicioComProv, H008B12_A530SolicitudServicioComALM, H008B12_n530SolicitudServicioComALM, H008B12_A864SolicitudesCostoXZona,
               H008B12_A532SolicitudServicioComALMP, H008B12_n532SolicitudServicioComALMP, H008B12_A528SolicitudServicioComProvP, H008B12_n528SolicitudServicioComProvP
               }
               , new Object[] {
               H008B13_A116PaisID
               }
               , new Object[] {
               H008B14_A18SecUserId, H008B14_A587SecUserFullName
               }
               , new Object[] {
               H008B15_A18SecUserId, H008B15_A587SecUserFullName
               }
            }
         );
         AV17Pgmname = "SolicitudesGeneral";
         /* GeneXus formulas. */
         AV17Pgmname = "SolicitudesGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A194SolicitudesAutoEnumerar ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int Gxuitabspanel_transactiondetail_tabs1_Pagecount ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesMail_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorNombreAux_Enabled ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtSolicitudesDireccion_Enabled ;
      private int edtMudanzaDireccionOrigen_Visible ;
      private int edtMudanzaDireccionOrigen_Enabled ;
      private int edtMudanzaDireccionDestino_Visible ;
      private int edtMudanzaDireccionDestino_Enabled ;
      private int edtSolicitudesOtros2_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtSolicitudesTotal_Enabled ;
      private int edtSolicitudesCotizacion_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtSolicitudesComisionMetodoPago_Enabled ;
      private int edtSolicitudServicioComProv_Enabled ;
      private int edtSolicitudServicioComProvP_Enabled ;
      private int edtSolicitudServicioComALM_Enabled ;
      private int edtSolicitudServicioComALMP_Enabled ;
      private int edtSolicitudServicioComPro_Enabled ;
      private int edtSolicitudServicioComProP_Enabled ;
      private int edtSolicitudesOtros3_Enabled ;
      private int edtSolicitudesComentario_Enabled ;
      private int edtSolicitudesNota_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtSolicitudesAutoEnumerar_Visible ;
      private int edtSolicitudesFechaAlta_Visible ;
      private int edtEstadosSolTipo_Visible ;
      private int edtavProfesionalesid_Visible ;
      private int edtPaisID_Visible ;
      private int gxdynajaxindex ;
      private int A131EstadosSolId ;
      private int edtSolicitudesFechaActualizacion_Enabled ;
      private int edtSolicitudesAutoEnumerar_Enabled ;
      private int edtSolicitudesFechaAlta_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtPaisID_Enabled ;
      private int idxLst ;
      private long A127SolicitudesID ;
      private long wcpOA127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A598SolicitudesUsrActualizacion ;
      private long A597SolicitudesUsrAlta ;
      private long A133ProveedorID ;
      private long A735MudanzaId ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A897SolicitudesDescuento ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A531SolicitudServicioComProP ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV17Pgmname ;
      private string A116PaisID ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A130EstadosSolTipo ;
      private string Dvpanel_transactiondetail_data3_Width ;
      private string Dvpanel_transactiondetail_data3_Cls ;
      private string Dvpanel_transactiondetail_data3_Title ;
      private string Dvpanel_transactiondetail_data3_Iconposition ;
      private string Dvpanel_transactiondetail_data4_Width ;
      private string Dvpanel_transactiondetail_data4_Cls ;
      private string Dvpanel_transactiondetail_data4_Title ;
      private string Dvpanel_transactiondetail_data4_Iconposition ;
      private string Dvpanel_transactiondetail_data5_Width ;
      private string Dvpanel_transactiondetail_data5_Cls ;
      private string Dvpanel_transactiondetail_data5_Title ;
      private string Dvpanel_transactiondetail_data5_Iconposition ;
      private string Gxuitabspanel_transactiondetail_tabs1_Class ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string Gxuitabspanel_transactiondetail_tabs1_Internalname ;
      private string lblDatosgenerales_title_Internalname ;
      private string lblDatosgenerales_title_Jsonclick ;
      private string divTransactiondetail_tbdata1_Internalname ;
      private string divTransactiondetail_data1_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string TempTags ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtSolicitudesNombre_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Link ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string edtSolicitudesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesMail_Internalname ;
      private string edtSolicitudesMail_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Link ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorNombreAux_Internalname ;
      private string A533ProveedorNombreAux ;
      private string edtProveedorNombreAux_Jsonclick ;
      private string divTransactiondetail_data2_Internalname ;
      private string cmbSolicitudesSubTipo_Internalname ;
      private string A600SolicitudesSubTipo ;
      private string cmbSolicitudesSubTipo_Jsonclick ;
      private string edtEstadosSolNombre_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Link ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string dynZonasID_Internalname ;
      private string dynZonasID_Jsonclick ;
      private string edtSolicitudesDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divMudanzadireccionorigen_cell_Internalname ;
      private string divMudanzadireccionorigen_cell_Class ;
      private string edtMudanzaDireccionOrigen_Internalname ;
      private string divMudanzadirecciondestino_cell_Internalname ;
      private string divMudanzadirecciondestino_cell_Class ;
      private string edtMudanzaDireccionDestino_Internalname ;
      private string chkSolicitudesOtros1_Internalname ;
      private string A201SolicitudesOtros1 ;
      private string edtSolicitudesOtros2_Internalname ;
      private string A202SolicitudesOtros2 ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string cmbSolicitudesHoraInstalacion_Internalname ;
      private string A183SolicitudesHoraInstalacion ;
      private string cmbSolicitudesHoraInstalacion_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string grpUnnamedgroup3_Class ;
      private string lblDatosservicio_title_Internalname ;
      private string lblDatosservicio_title_Jsonclick ;
      private string divTransactiondetail_tbdata2_Internalname ;
      private string divTransactiondetail_tableleaflevel_items_Internalname ;
      private string Dvpanel_transactiondetail_data3_Internalname ;
      private string divTransactiondetail_data3_Internalname ;
      private string edtSolicitudesTotal_Internalname ;
      private string edtSolicitudesTotal_Jsonclick ;
      private string chkSolicitudServicioSolCoti_Internalname ;
      private string A210SolicitudServicioSolCoti ;
      private string edtSolicitudesCotizacion_Internalname ;
      private string edtSolicitudesCotizacion_Jsonclick ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string edtSolicitudesComisionMetodoPago_Internalname ;
      private string edtSolicitudesComisionMetodoPago_Jsonclick ;
      private string divDvpanel_transactiondetail_data4_cell_Internalname ;
      private string divDvpanel_transactiondetail_data4_cell_Class ;
      private string Dvpanel_transactiondetail_data4_Internalname ;
      private string divTransactiondetail_data4_Internalname ;
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
      private string Dvpanel_transactiondetail_data5_Internalname ;
      private string divTransactiondetail_data5_Internalname ;
      private string cmbSolicitudServicioOrigenPago_Internalname ;
      private string A438SolicitudServicioOrigenPago ;
      private string cmbSolicitudServicioOrigenPago_Jsonclick ;
      private string dynMetodoPagosID_Internalname ;
      private string dynMetodoPagosID_Jsonclick ;
      private string cmbSolicitudesPagado_Internalname ;
      private string A441SolicitudesPagado ;
      private string cmbSolicitudesPagado_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string grpUnnamedgroup2_Class ;
      private string lblInformacion_title_Internalname ;
      private string lblInformacion_title_Jsonclick ;
      private string divTransactiondetail_tbdata3_Internalname ;
      private string edtSolicitudesOtros3_Internalname ;
      private string A203SolicitudesOtros3 ;
      private string edtSolicitudesComentario_Internalname ;
      private string edtSolicitudesNota_Internalname ;
      private string A261SolicitudesNota ;
      private string cmbSolicitudesNotificacion_Internalname ;
      private string A262SolicitudesNotificacion ;
      private string cmbSolicitudesNotificacion_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string grpUnnamedgroup1_Class ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtSolicitudesAutoEnumerar_Internalname ;
      private string edtSolicitudesAutoEnumerar_Jsonclick ;
      private string edtSolicitudesFechaAlta_Internalname ;
      private string edtSolicitudesFechaAlta_Jsonclick ;
      private string edtEstadosSolTipo_Internalname ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtavProfesionalesid_Internalname ;
      private string AV16ProfesionalesId ;
      private string edtavProfesionalesid_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string edtPaisID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string dynSolicitudesUsrAlta_Internalname ;
      private string dynSolicitudesUsrActualizacion_Internalname ;
      private string edtSolicitudesFechaActualizacion_Internalname ;
      private string hsh ;
      private string sStyleString ;
      private string tblTransactiondetail_auditoria_Internalname ;
      private string dynSolicitudesUsrAlta_Jsonclick ;
      private string edtSolicitudesFechaActualizacion_Jsonclick ;
      private string dynSolicitudesUsrActualizacion_Jsonclick ;
      private string tblTransactiondetail_costos_Internalname ;
      private string lblTransactiondetail_textblock1_Internalname ;
      private string lblTransactiondetail_textblock1_Jsonclick ;
      private string sCtrlA127SolicitudesID ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112DepartamentoId ;
      private bool Dvpanel_transactiondetail_data3_Autowidth ;
      private bool Dvpanel_transactiondetail_data3_Autoheight ;
      private bool Dvpanel_transactiondetail_data3_Collapsible ;
      private bool Dvpanel_transactiondetail_data3_Collapsed ;
      private bool Dvpanel_transactiondetail_data3_Showcollapseicon ;
      private bool Dvpanel_transactiondetail_data3_Autoscroll ;
      private bool Dvpanel_transactiondetail_data4_Autowidth ;
      private bool Dvpanel_transactiondetail_data4_Autoheight ;
      private bool Dvpanel_transactiondetail_data4_Collapsible ;
      private bool Dvpanel_transactiondetail_data4_Collapsed ;
      private bool Dvpanel_transactiondetail_data4_Showcollapseicon ;
      private bool Dvpanel_transactiondetail_data4_Autoscroll ;
      private bool Dvpanel_transactiondetail_data5_Autowidth ;
      private bool Dvpanel_transactiondetail_data5_Autoheight ;
      private bool Dvpanel_transactiondetail_data5_Collapsible ;
      private bool Dvpanel_transactiondetail_data5_Collapsed ;
      private bool Dvpanel_transactiondetail_data5_Showcollapseicon ;
      private bool Dvpanel_transactiondetail_data5_Autoscroll ;
      private bool Gxuitabspanel_transactiondetail_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool A672SolicitudesCalComi ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n597SolicitudesUsrAlta ;
      private bool n114DepartamentoMunicipioId ;
      private bool n600SolicitudesSubTipo ;
      private bool n110ZonasID ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n735MudanzaId ;
      private bool n182SolicitudesFechaAlta ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n533ProveedorNombreAux ;
      private bool n206SolicitudesMail ;
      private bool n897SolicitudesDescuento ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n528SolicitudServicioComProvP ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private bool AV15Administrar ;
      private string A205SolicitudesComentario ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucGxuitabspanel_transactiondetail_tabs1 ;
      private GXUserControl ucDvpanel_transactiondetail_data3 ;
      private GXUserControl ucDvpanel_transactiondetail_data4 ;
      private GXUserControl ucDvpanel_transactiondetail_data5 ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSolicitudesSubTipo ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GXCombobox dynZonasID ;
      private GXCheckbox chkSolicitudesOtros1 ;
      private GXCombobox cmbSolicitudesHoraInstalacion ;
      private GXCheckbox chkSolicitudServicioSolCoti ;
      private GXCheckbox chkSolicitudesCalComi ;
      private GXCombobox cmbSolicitudServicioOrigenPago ;
      private GXCombobox dynMetodoPagosID ;
      private GXCombobox cmbSolicitudesPagado ;
      private GXCombobox cmbSolicitudesNotificacion ;
      private GXCombobox dynSolicitudesUsrAlta ;
      private GXCombobox dynSolicitudesUsrActualizacion ;
      private IDataStoreProvider pr_default ;
      private string[] H008B2_A116PaisID ;
      private long[] H008B3_A127SolicitudesID ;
      private short[] H008B3_A134SolicitudesItemsID ;
      private decimal[] H008B3_A180SolicitudItemsComision ;
      private string[] H008B3_A179SolicitudItemsComisionTipo ;
      private string[] H008B3_A178SolicitudItemsSR ;
      private short[] H008B3_A177SolicitudesItemsCantidad ;
      private decimal[] H008B3_A176SolicitudesItemsPrecioFinal ;
      private bool[] H008B3_n176SolicitudesItemsPrecioFinal ;
      private long[] H008B4_A18SecUserId ;
      private string[] H008B4_A587SecUserFullName ;
      private long[] H008B5_A18SecUserId ;
      private string[] H008B5_A587SecUserFullName ;
      private long[] H008B6_A112DepartamentoId ;
      private bool[] H008B6_n112DepartamentoId ;
      private string[] H008B6_A113DepartamentoDepartamento ;
      private long[] H008B7_A112DepartamentoId ;
      private bool[] H008B7_n112DepartamentoId ;
      private long[] H008B7_A114DepartamentoMunicipioId ;
      private bool[] H008B7_n114DepartamentoMunicipioId ;
      private string[] H008B7_A115DepartamentoMunicipioNombre ;
      private long[] H008B8_A112DepartamentoId ;
      private bool[] H008B8_n112DepartamentoId ;
      private long[] H008B8_A114DepartamentoMunicipioId ;
      private bool[] H008B8_n114DepartamentoMunicipioId ;
      private long[] H008B8_A110ZonasID ;
      private bool[] H008B8_n110ZonasID ;
      private string[] H008B8_A111ZonasNombre ;
      private long[] H008B9_A128MetodoPagosID ;
      private string[] H008B9_A129MetodoPagosNombre ;
      private int[] H008B9_A108EstadosGenericosId ;
      private long[] H008B10_A18SecUserId ;
      private string[] H008B10_A587SecUserFullName ;
      private long[] H008B11_A18SecUserId ;
      private string[] H008B11_A587SecUserFullName ;
      private long[] H008B12_A127SolicitudesID ;
      private int[] H008B12_A131EstadosSolId ;
      private long[] H008B12_A133ProveedorID ;
      private long[] H008B12_A735MudanzaId ;
      private bool[] H008B12_n735MudanzaId ;
      private string[] H008B12_A116PaisID ;
      private string[] H008B12_A130EstadosSolTipo ;
      private DateTime[] H008B12_A182SolicitudesFechaAlta ;
      private bool[] H008B12_n182SolicitudesFechaAlta ;
      private short[] H008B12_A194SolicitudesAutoEnumerar ;
      private long[] H008B12_A598SolicitudesUsrActualizacion ;
      private bool[] H008B12_n598SolicitudesUsrActualizacion ;
      private DateTime[] H008B12_A204SolicitudesFechaActualizacion ;
      private bool[] H008B12_n204SolicitudesFechaActualizacion ;
      private long[] H008B12_A597SolicitudesUsrAlta ;
      private bool[] H008B12_n597SolicitudesUsrAlta ;
      private string[] H008B12_A262SolicitudesNotificacion ;
      private string[] H008B12_A261SolicitudesNota ;
      private string[] H008B12_A205SolicitudesComentario ;
      private string[] H008B12_A203SolicitudesOtros3 ;
      private string[] H008B12_A441SolicitudesPagado ;
      private bool[] H008B12_n441SolicitudesPagado ;
      private long[] H008B12_A128MetodoPagosID ;
      private string[] H008B12_A438SolicitudServicioOrigenPago ;
      private bool[] H008B12_n438SolicitudServicioOrigenPago ;
      private bool[] H008B12_A672SolicitudesCalComi ;
      private string[] H008B12_A210SolicitudServicioSolCoti ;
      private string[] H008B12_A183SolicitudesHoraInstalacion ;
      private DateTime[] H008B12_A184SolicitudesFechaInstalacion ;
      private string[] H008B12_A202SolicitudesOtros2 ;
      private string[] H008B12_A201SolicitudesOtros1 ;
      private string[] H008B12_A741MudanzaDireccionDestino ;
      private string[] H008B12_A740MudanzaDireccionOrigen ;
      private string[] H008B12_A173SolicitudesDireccion ;
      private long[] H008B12_A110ZonasID ;
      private bool[] H008B12_n110ZonasID ;
      private long[] H008B12_A114DepartamentoMunicipioId ;
      private bool[] H008B12_n114DepartamentoMunicipioId ;
      private long[] H008B12_A112DepartamentoId ;
      private bool[] H008B12_n112DepartamentoId ;
      private string[] H008B12_A132EstadosSolNombre ;
      private string[] H008B12_A600SolicitudesSubTipo ;
      private bool[] H008B12_n600SolicitudesSubTipo ;
      private string[] H008B12_A533ProveedorNombreAux ;
      private bool[] H008B12_n533ProveedorNombreAux ;
      private string[] H008B12_A282ProveedorNombre ;
      private string[] H008B12_A206SolicitudesMail ;
      private bool[] H008B12_n206SolicitudesMail ;
      private string[] H008B12_A172SolicitudesTelefono ;
      private string[] H008B12_A171SolicitudesNombre ;
      private decimal[] H008B12_A796SolicitudesComisionMetodoPago ;
      private decimal[] H008B12_A212SolicitudesCotizacion ;
      private decimal[] H008B12_A1016SolicitudesDescuentoCupon ;
      private decimal[] H008B12_A897SolicitudesDescuento ;
      private bool[] H008B12_n897SolicitudesDescuento ;
      private decimal[] H008B12_A527SolicitudServicioComProv ;
      private bool[] H008B12_n527SolicitudServicioComProv ;
      private decimal[] H008B12_A530SolicitudServicioComALM ;
      private bool[] H008B12_n530SolicitudServicioComALM ;
      private decimal[] H008B12_A864SolicitudesCostoXZona ;
      private decimal[] H008B12_A532SolicitudServicioComALMP ;
      private bool[] H008B12_n532SolicitudServicioComALMP ;
      private decimal[] H008B12_A528SolicitudServicioComProvP ;
      private bool[] H008B12_n528SolicitudServicioComProvP ;
      private string[] H008B13_A116PaisID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H008B14_A18SecUserId ;
      private string[] H008B14_A587SecUserFullName ;
      private long[] H008B15_A18SecUserId ;
      private string[] H008B15_A587SecUserFullName ;
   }

   public class solicitudesgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH008B2;
          prmH008B2 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH008B3;
          prmH008B3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH008B4;
          prmH008B4 = new Object[] {
          };
          Object[] prmH008B5;
          prmH008B5 = new Object[] {
          };
          Object[] prmH008B6;
          prmH008B6 = new Object[] {
          };
          Object[] prmH008B7;
          prmH008B7 = new Object[] {
          };
          Object[] prmH008B8;
          prmH008B8 = new Object[] {
          };
          Object[] prmH008B9;
          prmH008B9 = new Object[] {
          };
          Object[] prmH008B10;
          prmH008B10 = new Object[] {
          };
          Object[] prmH008B11;
          prmH008B11 = new Object[] {
          };
          Object[] prmH008B12;
          prmH008B12 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH008B13;
          prmH008B13 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH008B14;
          prmH008B14 = new Object[] {
          };
          Object[] prmH008B15;
          prmH008B15 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H008B2", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H008B3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B4", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B5", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B6", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B7", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoMunicipioId] < 9999 ORDER BY [DepartamentoMunicipioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B8", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [ZonasNombre] FROM [Zonas] WHERE [ZonasID] < 9999 ORDER BY [ZonasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B9", "SELECT [MetodoPagosID], [MetodoPagosNombre], [EstadosGenericosId] FROM [MetodoPagos] WHERE [EstadosGenericosId] = 1 ORDER BY [MetodoPagosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B10", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B10,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B11", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B11,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B12", "SELECT T1.[SolicitudesID], T1.[EstadosSolId] AS EstadosSolId, T1.[ProveedorID], T1.[MudanzaId], T5.[PaisID], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesFechaAlta], T1.[SolicitudesAutoEnumerar], T1.[SolicitudesUsrActualizacion], T1.[SolicitudesFechaActualizacion], T1.[SolicitudesUsrAlta], T1.[SolicitudesNotificacion], T1.[SolicitudesNota], T1.[SolicitudesComentario], T1.[SolicitudesOtros3], T1.[SolicitudesPagado], T1.[MetodoPagosID], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesCalComi], T1.[SolicitudServicioSolCoti], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesOtros2], T1.[SolicitudesOtros1], T3.[MudanzaDireccionDestino], T3.[MudanzaDireccionOrigen], T1.[SolicitudesDireccion], T1.[ZonasID], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T4.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesSubTipo], T1.[ProveedorNombreAux], T2.[ProveedorNombre], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudesCostoXZona], T1.[SolicitudServicioComALMP], T1.[SolicitudServicioComProvP] FROM (((([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Mudanza] T3 ON T3.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [EstadosGenericos] T4 ON T4.[EstadosTipo] = T1.[EstadosSolTipo] AND T4.[EstadosGenericosId] = T1.[EstadosSolId]) LEFT JOIN [Departamento] T5 ON T5.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[SolicitudesID] = @SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H008B13", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B14", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B14,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008B15", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008B15,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 2);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 1);
                ((string[]) buf[17])[0] = rslt.getString(13, 500);
                ((string[]) buf[18])[0] = rslt.getLongVarchar(14);
                ((string[]) buf[19])[0] = rslt.getString(15, 500);
                ((string[]) buf[20])[0] = rslt.getString(16, 1);
                ((bool[]) buf[21])[0] = rslt.wasNull(16);
                ((long[]) buf[22])[0] = rslt.getLong(17);
                ((string[]) buf[23])[0] = rslt.getString(18, 1);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((bool[]) buf[25])[0] = rslt.getBool(19);
                ((string[]) buf[26])[0] = rslt.getString(20, 1);
                ((string[]) buf[27])[0] = rslt.getString(21, 1);
                ((DateTime[]) buf[28])[0] = rslt.getGXDate(22);
                ((string[]) buf[29])[0] = rslt.getString(23, 1000);
                ((string[]) buf[30])[0] = rslt.getString(24, 1);
                ((string[]) buf[31])[0] = rslt.getVarchar(25);
                ((string[]) buf[32])[0] = rslt.getVarchar(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((long[]) buf[34])[0] = rslt.getLong(28);
                ((bool[]) buf[35])[0] = rslt.wasNull(28);
                ((long[]) buf[36])[0] = rslt.getLong(29);
                ((bool[]) buf[37])[0] = rslt.wasNull(29);
                ((long[]) buf[38])[0] = rslt.getLong(30);
                ((bool[]) buf[39])[0] = rslt.wasNull(30);
                ((string[]) buf[40])[0] = rslt.getString(31, 80);
                ((string[]) buf[41])[0] = rslt.getString(32, 1);
                ((bool[]) buf[42])[0] = rslt.wasNull(32);
                ((string[]) buf[43])[0] = rslt.getString(33, 80);
                ((bool[]) buf[44])[0] = rslt.wasNull(33);
                ((string[]) buf[45])[0] = rslt.getString(34, 80);
                ((string[]) buf[46])[0] = rslt.getVarchar(35);
                ((bool[]) buf[47])[0] = rslt.wasNull(35);
                ((string[]) buf[48])[0] = rslt.getString(36, 20);
                ((string[]) buf[49])[0] = rslt.getString(37, 100);
                ((decimal[]) buf[50])[0] = rslt.getDecimal(38);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
                ((decimal[]) buf[52])[0] = rslt.getDecimal(40);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(41);
                ((bool[]) buf[54])[0] = rslt.wasNull(41);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(42);
                ((bool[]) buf[56])[0] = rslt.wasNull(42);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(43);
                ((bool[]) buf[58])[0] = rslt.wasNull(43);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(44);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(45);
                ((bool[]) buf[61])[0] = rslt.wasNull(45);
                ((decimal[]) buf[62])[0] = rslt.getDecimal(46);
                ((bool[]) buf[63])[0] = rslt.wasNull(46);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
