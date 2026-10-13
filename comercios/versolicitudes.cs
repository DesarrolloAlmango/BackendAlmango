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
namespace GeneXus.Programs.comercios {
   public class versolicitudes : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public versolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public versolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         ExecutePrivate();
         aP0_SolicitudesID=this.A127SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
         dynZonasID = new GXCombobox();
         chkSolicitudesOtros1 = new GXCheckbox();
         cmbSolicitudesHoraInstalacion = new GXCombobox();
         dynRubrosId = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
         cmbSolicitudItemsSR = new GXCombobox();
         chkSolicitudServicioSolCoti = new GXCheckbox();
         cmbSolicitudServicioOrigenPago = new GXCombobox();
         dynMetodoPagosID = new GXCombobox();
         cmbSolicitudesPagado = new GXCombobox();
         cmbSolicitudesNotificacion = new GXCombobox();
         cmbSolicitudesSubTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLADEPARTAMENTOIDDX2( ) ;
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
               GXDLADEPARTAMENTOMUNICIPIOIDDX2( ) ;
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
               GXDLAZONASIDDX2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"RUBROSID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLARUBROSIDDX2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAMEDIDASIDDX2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAINVENTARIOIDDX2( ) ;
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
               GXDLAMETODOPAGOSIDDX2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_105 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_105"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_105_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_105_idx = GetPar( "sGXsfl_105_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         A127SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
         dynDepartamentoId.FromJSonString( GetNextPar( ));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
         n112DepartamentoId = false;
         dynDepartamentoMunicipioId.FromJSonString( GetNextPar( ));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         n114DepartamentoMunicipioId = false;
         dynZonasID.FromJSonString( GetNextPar( ));
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         dynMetodoPagosID.FromJSonString( GetNextPar( ));
         A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
         A201SolicitudesOtros1 = GetPar( "SolicitudesOtros1");
         A210SolicitudServicioSolCoti = GetPar( "SolicitudServicioSolCoti");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor H00DX2 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H00DX2_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H00DX2_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H00DX2_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H00DX2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00DX2_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])-(H00DX2_A180SolicitudItemsComision[0]*H00DX2_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H00DX2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00DX2_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])+(H00DX2_A180SolicitudItemsComision[0]*H00DX2_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H00DX2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00DX2_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])-((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])*(H00DX2_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H00DX2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00DX2_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])+((H00DX2_A176SolicitudesItemsPrecioFinal[0]*H00DX2_A177SolicitudesItemsCantidad[0])*(H00DX2_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public override short ExecuteStartEvent( )
      {
         PADX2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTDX2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "comercios.versolicitudes.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comercios.versolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_105", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_105), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV18GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOSTOXZONA", StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOMISIONMETODOPAGO", StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Width", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Autowidth", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Autoheight", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Cls", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Title", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsible", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsed", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Iconposition", StringUtil.RTrim( Dvpanel_transactiondetail_data3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA3_Autoscroll", StringUtil.BoolToStr( Dvpanel_transactiondetail_data3_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Width", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Autowidth", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Autoheight", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Cls", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Title", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsible", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsed", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Iconposition", StringUtil.RTrim( Dvpanel_transactiondetail_data4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TRANSACTIONDETAIL_DATA4_Autoscroll", StringUtil.BoolToStr( Dvpanel_transactiondetail_data4_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEDX2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTDX2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comercios.versolicitudes.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
         return formatLink("comercios.versolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Comercios.VerSolicitudes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Ver Solicitudes", "") ;
      }

      protected void WBDX0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1.SetProperty("PageCount", Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Pagecount);
            ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1.SetProperty("Class", Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Class);
            ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Historymanagement);
            ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1.Render(context, "tab", Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Internalname, "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatosgenerales_title_Internalname, context.GetMessage( "Datos Generales", ""), "", "", lblDatosgenerales_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comercios/VerSolicitudes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DatosGenerales") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesNombre_Internalname, StringUtil.RTrim( A171SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesTelefono_Internalname, StringUtil.RTrim( A172SolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( A172SolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "598 099 999999", edtSolicitudesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesMail_Internalname, A206SolicitudesMail, StringUtil.RTrim( context.localUtil.Format( A206SolicitudesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A206SolicitudesMail, "", "", "", edtSolicitudesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombreAux_Internalname, StringUtil.RTrim( A533ProveedorNombreAux), StringUtil.RTrim( context.localUtil.Format( A533ProveedorNombreAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombreAux_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombreAux_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Comercios/VerSolicitudes.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp("", false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynZonasID, dynZonasID_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0)), 1, dynZonasID_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynZonasID.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
            AssignProp("", false, dynZonasID_Internalname, "Values", (string)(dynZonasID.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesDireccion_Internalname, A173SolicitudesDireccion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", 0, 1, edtSolicitudesDireccion_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "1024", 1, 0, "", context.GetMessage( "Calle, casa numero 1234...", ""), -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorder";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkSolicitudesOtros1_Internalname, A201SolicitudesOtros1, context.GetMessage( "No aparecen en el listado los servcios que necesito.", ""), context.GetMessage( "No aparecen en el listado los servicios que necesito.", ""), 1, chkSolicitudesOtros1.Enabled, "S", context.GetMessage( "¿No aparece en la lista los servicios que necesito?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesOtros2_Internalname, StringUtil.RTrim( A202SolicitudesOtros2), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", 0, 1, edtSolicitudesOtros2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_105_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtSolicitudesFechaInstalacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtSolicitudesFechaInstalacion_Internalname, context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"), context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesFechaInstalacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesFechaInstalacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
            GxWebStd.gx_bitmap( context, edtSolicitudesFechaInstalacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSolicitudesFechaInstalacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comercios/VerSolicitudes.htm");
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
            GxWebStd.gx_label_element( context, cmbSolicitudesHoraInstalacion_Internalname, context.GetMessage( "Hora", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesHoraInstalacion, cmbSolicitudesHoraInstalacion_Internalname, StringUtil.RTrim( A183SolicitudesHoraInstalacion), 1, cmbSolicitudesHoraInstalacion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesHoraInstalacion.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            cmbSolicitudesHoraInstalacion.CurrentValue = StringUtil.RTrim( A183SolicitudesHoraInstalacion);
            AssignProp("", false, cmbSolicitudesHoraInstalacion_Internalname, "Values", (string)(cmbSolicitudesHoraInstalacion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatosservicio_title_Internalname, context.GetMessage( "Datos del Servicio ", ""), "", "", lblDatosservicio_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comercios/VerSolicitudes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DatosServicio") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tbdata2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableleaflevel_items_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl105( ) ;
         }
         if ( wbEnd == 105 )
         {
            wbEnd = 0;
            nRC_GXsfl_105 = (int)(nGXsfl_105_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV16GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV17GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV18GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            ucDvpanel_transactiondetail_data3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_transactiondetail_data3_Internalname, "DVPANEL_TRANSACTIONDETAIL_DATA3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TRANSACTIONDETAIL_DATA3Container"+"TransactionDetail_DATA3"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesTotal_Enabled!=0) ? context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesTotal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeCheckNoBorder";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkSolicitudServicioSolCoti_Internalname, A210SolicitudServicioSolCoti, "", context.GetMessage( "Solicitar cotización ", ""), 1, chkSolicitudServicioSolCoti.Enabled, "S", context.GetMessage( "¿Solicitó Cotización?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesCotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesCotizacion_Enabled!=0) ? context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCotizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesCotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioPFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioPFinal_Enabled!=0) ? context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioPFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioPFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDvpanel_transactiondetail_data4_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
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
            ucDvpanel_transactiondetail_data4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_transactiondetail_data4_Internalname, "DVPANEL_TRANSACTIONDETAIL_DATA4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TRANSACTIONDETAIL_DATA4Container"+"TransactionDetail_DATA4"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProv_Internalname, StringUtil.LTrim( StringUtil.NToC( A527SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProv_Enabled!=0) ? context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProv_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProv_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProvP_Internalname, StringUtil.LTrim( StringUtil.NToC( A528SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProvP_Enabled!=0) ? context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99") : context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProvP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProvP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALM_Internalname, StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALM_Enabled!=0) ? context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALM_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALM_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Comision", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComALMP_Internalname, StringUtil.LTrim( StringUtil.NToC( A532SolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComALMP_Enabled!=0) ? context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99") : context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComALMP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComALMP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComPro_Internalname, StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComPro_Enabled!=0) ? context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComPro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComPro_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudServicioComProP_Internalname, StringUtil.LTrim( StringUtil.NToC( A531SolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudServicioComProP_Enabled!=0) ? context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99") : context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudServicioComProP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudServicioComProP_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Porcentaje", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudServicioOrigenPago, cmbSolicitudServicioOrigenPago_Internalname, StringUtil.RTrim( A438SolicitudServicioOrigenPago), 1, cmbSolicitudServicioOrigenPago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudServicioOrigenPago.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Values", (string)(cmbSolicitudServicioOrigenPago.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynMetodoPagosID, dynMetodoPagosID_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0)), 1, dynMetodoPagosID_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMetodoPagosID.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            dynMetodoPagosID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0));
            AssignProp("", false, dynMetodoPagosID_Internalname, "Values", (string)(dynMetodoPagosID.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesPagado, cmbSolicitudesPagado_Internalname, StringUtil.RTrim( A441SolicitudesPagado), 1, cmbSolicitudesPagado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesPagado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,200);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
            AssignProp("", false, cmbSolicitudesPagado_Internalname, "Values", (string)(cmbSolicitudesPagado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInformacion_title_Internalname, context.GetMessage( "Información Complementaria", ""), "", "", lblInformacion_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Comercios/VerSolicitudes.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Informacion") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1Container"+"panel3"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesOtros3_Internalname, StringUtil.RTrim( A203SolicitudesOtros3), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,210);\"", 0, 1, edtSolicitudesOtros3_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesComentario_Internalname, A205SolicitudesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,215);\"", 0, 1, edtSolicitudesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'',false,'" + sGXsfl_105_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtSolicitudesNota_Internalname, StringUtil.RTrim( A261SolicitudesNota), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,220);\"", 0, 1, edtSolicitudesNota_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Comercios/VerSolicitudes.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesNotificacion, cmbSolicitudesNotificacion_Internalname, StringUtil.RTrim( A262SolicitudesNotificacion), 1, cmbSolicitudesNotificacion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbSolicitudesNotificacion.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,225);\"", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            cmbSolicitudesNotificacion.CurrentValue = StringUtil.RTrim( A262SolicitudesNotificacion);
            AssignProp("", false, cmbSolicitudesNotificacion_Internalname, "Values", (string)(cmbSolicitudesNotificacion.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridcurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16GridCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridcurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridcurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSolicitudesCalComi_Internalname, StringUtil.BoolToStr( A672SolicitudesCalComi), StringUtil.BoolToStr( A672SolicitudesCalComi), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesCalComi_Jsonclick, 0, "Attribute", "", "", "", "", edtSolicitudesCalComi_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbSolicitudesSubTipo, cmbSolicitudesSubTipo_Internalname, StringUtil.RTrim( A600SolicitudesSubTipo), 1, cmbSolicitudesSubTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbSolicitudesSubTipo.Visible, 0, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_Comercios/VerSolicitudes.htm");
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Values", (string)(cmbSolicitudesSubTipo.ToJavascriptSource()), true);
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEstadosSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolId_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosSolId_Visible, 0, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/VerSolicitudes.htm");
            /* User Defined Control */
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, "GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 105 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTDX2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Ver Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPDX0( ) ;
      }

      protected void WSDX2( )
      {
         STARTDX2( ) ;
         EVTDX2( ) ;
      }

      protected void EVTDX2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E11DX2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12DX2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
                              SubsflControlProps_1052( ) ;
                              A134SolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              dynRubrosId.Name = dynRubrosId_Internalname;
                              dynRubrosId.CurrentValue = cgiGet( dynRubrosId_Internalname);
                              A121RubrosId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynRubrosId_Internalname), "."), 18, MidpointRounding.ToEven));
                              A168RubrosImagen = cgiGet( edtRubrosImagen_Internalname);
                              AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
                              AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
                              dynMedidasID.Name = dynMedidasID_Internalname;
                              dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
                              A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
                              dynInventarioId.Name = dynInventarioId_Internalname;
                              dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
                              A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
                              A189InventarioImagen = cgiGet( edtInventarioImagen_Internalname);
                              AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
                              AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
                              A176SolicitudesItemsPrecioFinal = context.localUtil.CToN( cgiGet( edtSolicitudesItemsPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n176SolicitudesItemsPrecioFinal = false;
                              A177SolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A175SolicitudesItemsPrecioInstalac = context.localUtil.CToN( cgiGet( edtSolicitudesItemsPrecioInstalac_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A180SolicitudItemsComision = context.localUtil.CToN( cgiGet( edtSolicitudItemsComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbSolicitudItemsSR.Name = cmbSolicitudItemsSR_Internalname;
                              cmbSolicitudItemsSR.CurrentValue = cgiGet( cmbSolicitudItemsSR_Internalname);
                              A178SolicitudItemsSR = cgiGet( cmbSolicitudItemsSR_Internalname);
                              A179SolicitudItemsComisionTipo = cgiGet( edtSolicitudItemsComisionTipo_Internalname);
                              A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
                              A521SolicitudesItemsComiProv = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n521SolicitudesItemsComiProv = false;
                              A524SolicitudesItemsComiProvP = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n524SolicitudesItemsComiProvP = false;
                              A523SolicitudesItemsComiALM = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n523SolicitudesItemsComiALM = false;
                              A526SolicitudesItemsComiALMP = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n526SolicitudesItemsComiALMP = false;
                              A522SolicitudesItemsComiProf = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A525SolicitudesItemsComiProfP = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProfP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13DX2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E14DX2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E15DX2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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
      }

      protected void WEDX2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PADX2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comercios.versolicitudes.aspx")), "comercios.versolicitudes.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comercios.versolicitudes.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "SolicitudesID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     A127SolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGridcurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLADEPARTAMENTOIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_dataDX2( ) ;
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

      protected void GXADEPARTAMENTOID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_dataDX2( ) ;
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

      protected void GXDLADEPARTAMENTOID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00DX3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX3_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX3_A113DepartamentoDepartamento[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_dataDX2( ) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_dataDX2( ) ;
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
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00DX4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX4_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX4_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLAZONASIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAZONASID_dataDX2( ) ;
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

      protected void GXAZONASID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLAZONASID_dataDX2( ) ;
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

      protected void GXDLAZONASID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00DX5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX5_A110ZonasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX5_A111ZonasNombre[0]));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void GXDLARUBROSIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_dataDX2( ) ;
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

      protected void GXARUBROSID_htmlDX2( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_dataDX2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynRubrosId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynRubrosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLARUBROSID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00DX6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX6_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX6_A122RubrosNombre[0]));
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GXDLAMEDIDASIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_dataDX2( ) ;
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

      protected void GXAMEDIDASID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_dataDX2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMedidasID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMedidasID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAMEDIDASID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00DX7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX7_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX7_A138MedidasNombre[0]));
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void GXDLAINVENTARIOIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_dataDX2( ) ;
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

      protected void GXAINVENTARIOID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_dataDX2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynInventarioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynInventarioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAINVENTARIOID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00DX8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX8_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX8_A136InventarioNombre[0]));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void GXDLAMETODOPAGOSIDDX2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMETODOPAGOSID_dataDX2( ) ;
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

      protected void GXAMETODOPAGOSID_htmlDX2( )
      {
         long gxdynajaxvalue;
         GXDLAMETODOPAGOSID_dataDX2( ) ;
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
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
      }

      protected void GXDLAMETODOPAGOSID_dataDX2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00DX9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00DX9_A128MetodoPagosID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00DX9_A129MetodoPagosNombre[0]));
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1052( ) ;
         while ( nGXsfl_105_idx <= nRC_GXsfl_105 )
         {
            sendrow_1052( ) ;
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       long A127SolicitudesID ,
                                       long A112DepartamentoId ,
                                       long A114DepartamentoMunicipioId ,
                                       long A110ZonasID ,
                                       long A128MetodoPagosID ,
                                       string A201SolicitudesOtros1 ,
                                       string A210SolicitudServicioSolCoti )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFDX2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXADEPARTAMENTOID_htmlDX2( ) ;
            GXADEPARTAMENTOMUNICIPIOID_htmlDX2( ) ;
            GXAZONASID_htmlDX2( ) ;
            GXAMETODOPAGOSID_htmlDX2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp("", false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         }
         if ( dynZonasID.ItemCount > 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
            AssignProp("", false, dynZonasID_Internalname, "Values", dynZonasID.ToJavascriptSource(), true);
         }
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         if ( cmbSolicitudesHoraInstalacion.ItemCount > 0 )
         {
            A183SolicitudesHoraInstalacion = cmbSolicitudesHoraInstalacion.getValidValue(A183SolicitudesHoraInstalacion);
            AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSolicitudesHoraInstalacion.CurrentValue = StringUtil.RTrim( A183SolicitudesHoraInstalacion);
            AssignProp("", false, cmbSolicitudesHoraInstalacion_Internalname, "Values", cmbSolicitudesHoraInstalacion.ToJavascriptSource(), true);
         }
         A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(StringUtil.RTrim( A210SolicitudServicioSolCoti), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
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
         if ( dynMetodoPagosID.ItemCount > 0 )
         {
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( dynMetodoPagosID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMetodoPagosID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0));
            AssignProp("", false, dynMetodoPagosID_Internalname, "Values", dynMetodoPagosID.ToJavascriptSource(), true);
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

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFDX2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
         GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
         /* Using cursor H00DX10 */
         pr_default.execute(8, new Object[] {A127SolicitudesID, GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A40001InventarioImagen_GXI = H00DX10_A40001InventarioImagen_GXI[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            A135InventarioId = H00DX10_A135InventarioId[0];
            A137MedidasID = H00DX10_A137MedidasID[0];
            A40002RubrosImagen_GXI = H00DX10_A40002RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A121RubrosId = H00DX10_A121RubrosId[0];
            A134SolicitudesItemsID = H00DX10_A134SolicitudesItemsID[0];
            A523SolicitudesItemsComiALM = H00DX10_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = H00DX10_n523SolicitudesItemsComiALM[0];
            A521SolicitudesItemsComiProv = H00DX10_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = H00DX10_n521SolicitudesItemsComiProv[0];
            A526SolicitudesItemsComiALMP = H00DX10_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = H00DX10_n526SolicitudesItemsComiALMP[0];
            A524SolicitudesItemsComiProvP = H00DX10_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = H00DX10_n524SolicitudesItemsComiProvP[0];
            A180SolicitudItemsComision = H00DX10_A180SolicitudItemsComision[0];
            A179SolicitudItemsComisionTipo = H00DX10_A179SolicitudItemsComisionTipo[0];
            A178SolicitudItemsSR = H00DX10_A178SolicitudItemsSR[0];
            A177SolicitudesItemsCantidad = H00DX10_A177SolicitudesItemsCantidad[0];
            A176SolicitudesItemsPrecioFinal = H00DX10_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = H00DX10_n176SolicitudesItemsPrecioFinal[0];
            A189InventarioImagen = H00DX10_A189InventarioImagen[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            A168RubrosImagen = H00DX10_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A40002RubrosImagen_GXI = H00DX10_A40002RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A168RubrosImagen = H00DX10_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A40001InventarioImagen_GXI = H00DX10_A40001InventarioImagen_GXI[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            A189InventarioImagen = H00DX10_A189InventarioImagen[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A522SolicitudesItemsComiProf = (decimal)(A175SolicitudesItemsPrecioInstalac-(A521SolicitudesItemsComiProv+A523SolicitudesItemsComiALM));
            A525SolicitudesItemsComiProfP = (decimal)(100-(A524SolicitudesItemsComiProvP+A526SolicitudesItemsComiALMP));
            GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            pr_default.readNext(8);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(8) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(8);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFDX2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 105;
         /* Execute user event: Refresh */
         E14DX2 ();
         nGXsfl_105_idx = 1;
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         bGXsfl_105_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1052( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H00DX11 */
            pr_default.execute(9, new Object[] {A127SolicitudesID, GXPagingFrom2, GXPagingTo2});
            nGXsfl_105_idx = 1;
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
            while ( ( (pr_default.getStatus(9) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A40001InventarioImagen_GXI = H00DX11_A40001InventarioImagen_GXI[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               A135InventarioId = H00DX11_A135InventarioId[0];
               A137MedidasID = H00DX11_A137MedidasID[0];
               A40002RubrosImagen_GXI = H00DX11_A40002RubrosImagen_GXI[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A121RubrosId = H00DX11_A121RubrosId[0];
               A134SolicitudesItemsID = H00DX11_A134SolicitudesItemsID[0];
               A523SolicitudesItemsComiALM = H00DX11_A523SolicitudesItemsComiALM[0];
               n523SolicitudesItemsComiALM = H00DX11_n523SolicitudesItemsComiALM[0];
               A521SolicitudesItemsComiProv = H00DX11_A521SolicitudesItemsComiProv[0];
               n521SolicitudesItemsComiProv = H00DX11_n521SolicitudesItemsComiProv[0];
               A526SolicitudesItemsComiALMP = H00DX11_A526SolicitudesItemsComiALMP[0];
               n526SolicitudesItemsComiALMP = H00DX11_n526SolicitudesItemsComiALMP[0];
               A524SolicitudesItemsComiProvP = H00DX11_A524SolicitudesItemsComiProvP[0];
               n524SolicitudesItemsComiProvP = H00DX11_n524SolicitudesItemsComiProvP[0];
               A180SolicitudItemsComision = H00DX11_A180SolicitudItemsComision[0];
               A179SolicitudItemsComisionTipo = H00DX11_A179SolicitudItemsComisionTipo[0];
               A178SolicitudItemsSR = H00DX11_A178SolicitudItemsSR[0];
               A177SolicitudesItemsCantidad = H00DX11_A177SolicitudesItemsCantidad[0];
               A176SolicitudesItemsPrecioFinal = H00DX11_A176SolicitudesItemsPrecioFinal[0];
               n176SolicitudesItemsPrecioFinal = H00DX11_n176SolicitudesItemsPrecioFinal[0];
               A189InventarioImagen = H00DX11_A189InventarioImagen[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               A168RubrosImagen = H00DX11_A168RubrosImagen[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A40002RubrosImagen_GXI = H00DX11_A40002RubrosImagen_GXI[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A168RubrosImagen = H00DX11_A168RubrosImagen[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A40001InventarioImagen_GXI = H00DX11_A40001InventarioImagen_GXI[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               A189InventarioImagen = H00DX11_A189InventarioImagen[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_105_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                        }
                        else
                        {
                           if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                           {
                              A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                           }
                           else
                           {
                              A175SolicitudesItemsPrecioInstalac = 0;
                           }
                        }
                     }
                  }
               }
               A522SolicitudesItemsComiProf = (decimal)(A175SolicitudesItemsPrecioInstalac-(A521SolicitudesItemsComiProv+A523SolicitudesItemsComiALM));
               A525SolicitudesItemsComiProfP = (decimal)(100-(A524SolicitudesItemsComiProvP+A526SolicitudesItemsComiALMP));
               /* Execute user event: Grid.Load */
               E15DX2 ();
               pr_default.readNext(9);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(9) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(9);
            wbEnd = 105;
            WBDX0( ) ;
         }
         bGXsfl_105_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesDX2( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, A127SolicitudesID, A112DepartamentoId, A114DepartamentoMunicipioId, A110ZonasID, A128MetodoPagosID, A201SolicitudesOtros1, A210SolicitudServicioSolCoti) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         GXADEPARTAMENTOID_htmlDX2( ) ;
         /* Using cursor H00DX12 */
         pr_default.execute(10, new Object[] {n112DepartamentoId, A112DepartamentoId});
         A116PaisID = H00DX12_A116PaisID[0];
         pr_default.close(10);
         GXADEPARTAMENTOMUNICIPIOID_htmlDX2( ) ;
         GXAZONASID_htmlDX2( ) ;
         GXARUBROSID_htmlDX2( ) ;
         /* Using cursor H00DX13 */
         pr_default.execute(11, new Object[] {A121RubrosId});
         A40002RubrosImagen_GXI = H00DX13_A40002RubrosImagen_GXI[0];
         A168RubrosImagen = H00DX13_A168RubrosImagen[0];
         pr_default.close(11);
         GXAMEDIDASID_htmlDX2( ) ;
         /* Using cursor H00DX14 */
         pr_default.execute(12, new Object[] {A121RubrosId, A137MedidasID});
         pr_default.close(12);
         GXAINVENTARIOID_htmlDX2( ) ;
         /* Using cursor H00DX15 */
         pr_default.execute(13, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         A40001InventarioImagen_GXI = H00DX15_A40001InventarioImagen_GXI[0];
         A189InventarioImagen = H00DX15_A189InventarioImagen[0];
         pr_default.close(13);
         GXAMETODOPAGOSID_htmlDX2( ) ;
         /* Using cursor H00DX16 */
         pr_default.execute(14, new Object[] {A127SolicitudesID});
         A669STMonedasId = H00DX16_A669STMonedasId[0];
         n669STMonedasId = H00DX16_n669STMonedasId[0];
         A133ProveedorID = H00DX16_A133ProveedorID[0];
         A171SolicitudesNombre = H00DX16_A171SolicitudesNombre[0];
         AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
         A172SolicitudesTelefono = H00DX16_A172SolicitudesTelefono[0];
         AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
         A206SolicitudesMail = H00DX16_A206SolicitudesMail[0];
         n206SolicitudesMail = H00DX16_n206SolicitudesMail[0];
         AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
         A533ProveedorNombreAux = H00DX16_A533ProveedorNombreAux[0];
         n533ProveedorNombreAux = H00DX16_n533ProveedorNombreAux[0];
         AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
         A112DepartamentoId = H00DX16_A112DepartamentoId[0];
         n112DepartamentoId = H00DX16_n112DepartamentoId[0];
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         A114DepartamentoMunicipioId = H00DX16_A114DepartamentoMunicipioId[0];
         n114DepartamentoMunicipioId = H00DX16_n114DepartamentoMunicipioId[0];
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         A110ZonasID = H00DX16_A110ZonasID[0];
         n110ZonasID = H00DX16_n110ZonasID[0];
         AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         A173SolicitudesDireccion = H00DX16_A173SolicitudesDireccion[0];
         AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
         A201SolicitudesOtros1 = H00DX16_A201SolicitudesOtros1[0];
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         A202SolicitudesOtros2 = H00DX16_A202SolicitudesOtros2[0];
         AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
         A184SolicitudesFechaInstalacion = H00DX16_A184SolicitudesFechaInstalacion[0];
         AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
         A183SolicitudesHoraInstalacion = H00DX16_A183SolicitudesHoraInstalacion[0];
         AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
         A210SolicitudServicioSolCoti = H00DX16_A210SolicitudServicioSolCoti[0];
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
         A438SolicitudServicioOrigenPago = H00DX16_A438SolicitudServicioOrigenPago[0];
         n438SolicitudServicioOrigenPago = H00DX16_n438SolicitudServicioOrigenPago[0];
         AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
         A128MetodoPagosID = H00DX16_A128MetodoPagosID[0];
         AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         A441SolicitudesPagado = H00DX16_A441SolicitudesPagado[0];
         n441SolicitudesPagado = H00DX16_n441SolicitudesPagado[0];
         AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
         A203SolicitudesOtros3 = H00DX16_A203SolicitudesOtros3[0];
         AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
         A205SolicitudesComentario = H00DX16_A205SolicitudesComentario[0];
         AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
         A261SolicitudesNota = H00DX16_A261SolicitudesNota[0];
         AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
         A262SolicitudesNotificacion = H00DX16_A262SolicitudesNotificacion[0];
         AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         A672SolicitudesCalComi = H00DX16_A672SolicitudesCalComi[0];
         AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
         A600SolicitudesSubTipo = H00DX16_A600SolicitudesSubTipo[0];
         n600SolicitudesSubTipo = H00DX16_n600SolicitudesSubTipo[0];
         AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
         A131EstadosSolId = H00DX16_A131EstadosSolId[0];
         AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
         A532SolicitudServicioComALMP = H00DX16_A532SolicitudServicioComALMP[0];
         n532SolicitudServicioComALMP = H00DX16_n532SolicitudServicioComALMP[0];
         AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
         A528SolicitudServicioComProvP = H00DX16_A528SolicitudServicioComProvP[0];
         n528SolicitudServicioComProvP = H00DX16_n528SolicitudServicioComProvP[0];
         AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
         A527SolicitudServicioComProv = H00DX16_A527SolicitudServicioComProv[0];
         n527SolicitudServicioComProv = H00DX16_n527SolicitudServicioComProv[0];
         AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
         A530SolicitudServicioComALM = H00DX16_A530SolicitudServicioComALM[0];
         n530SolicitudServicioComALM = H00DX16_n530SolicitudServicioComALM[0];
         AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
         A796SolicitudesComisionMetodoPago = H00DX16_A796SolicitudesComisionMetodoPago[0];
         A212SolicitudesCotizacion = H00DX16_A212SolicitudesCotizacion[0];
         AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
         A1016SolicitudesDescuentoCupon = H00DX16_A1016SolicitudesDescuentoCupon[0];
         A897SolicitudesDescuento = H00DX16_A897SolicitudesDescuento[0];
         n897SolicitudesDescuento = H00DX16_n897SolicitudesDescuento[0];
         A864SolicitudesCostoXZona = H00DX16_A864SolicitudesCostoXZona[0];
         pr_default.close(14);
         /* Using cursor H00DX17 */
         pr_default.execute(15, new Object[] {A116PaisID, n669STMonedasId, A669STMonedasId});
         pr_default.close(15);
         /* Using cursor H00DX18 */
         pr_default.execute(16, new Object[] {A133ProveedorID});
         A282ProveedorNombre = H00DX18_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         pr_default.close(16);
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
         edtSolicitudesID_Enabled = 0;
         AssignProp("", false, edtSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Enabled), 5, 0), true);
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         edtSolicitudesTelefono_Enabled = 0;
         AssignProp("", false, edtSolicitudesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTelefono_Enabled), 5, 0), true);
         edtSolicitudesMail_Enabled = 0;
         AssignProp("", false, edtSolicitudesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesMail_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorNombreAux_Enabled = 0;
         AssignProp("", false, edtProveedorNombreAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombreAux_Enabled), 5, 0), true);
         dynDepartamentoId.Enabled = 0;
         AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         dynZonasID.Enabled = 0;
         AssignProp("", false, dynZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynZonasID.Enabled), 5, 0), true);
         edtSolicitudesDireccion_Enabled = 0;
         AssignProp("", false, edtSolicitudesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesDireccion_Enabled), 5, 0), true);
         chkSolicitudesOtros1.Enabled = 0;
         AssignProp("", false, chkSolicitudesOtros1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudesOtros1.Enabled), 5, 0), true);
         edtSolicitudesOtros2_Enabled = 0;
         AssignProp("", false, edtSolicitudesOtros2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros2_Enabled), 5, 0), true);
         edtSolicitudesFechaInstalacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesFechaInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaInstalacion_Enabled), 5, 0), true);
         cmbSolicitudesHoraInstalacion.Enabled = 0;
         AssignProp("", false, cmbSolicitudesHoraInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesHoraInstalacion.Enabled), 5, 0), true);
         edtSolicitudesItemsID_Enabled = 0;
         dynRubrosId.Enabled = 0;
         edtRubrosImagen_Enabled = 0;
         dynMedidasID.Enabled = 0;
         dynInventarioId.Enabled = 0;
         edtInventarioImagen_Enabled = 0;
         edtSolicitudesItemsPrecioFinal_Enabled = 0;
         edtSolicitudesItemsCantidad_Enabled = 0;
         edtSolicitudesItemsPrecioInstalac_Enabled = 0;
         edtSolicitudItemsComision_Enabled = 0;
         cmbSolicitudItemsSR.Enabled = 0;
         edtSolicitudItemsComisionTipo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtSolicitudesItemsComiProv_Enabled = 0;
         edtSolicitudesItemsComiProvP_Enabled = 0;
         edtSolicitudesItemsComiALM_Enabled = 0;
         edtSolicitudesItemsComiALMP_Enabled = 0;
         edtSolicitudesItemsComiProf_Enabled = 0;
         edtSolicitudesItemsComiProfP_Enabled = 0;
         edtSolicitudesTotal_Enabled = 0;
         AssignProp("", false, edtSolicitudesTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesTotal_Enabled), 5, 0), true);
         chkSolicitudServicioSolCoti.Enabled = 0;
         AssignProp("", false, chkSolicitudServicioSolCoti_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSolicitudServicioSolCoti.Enabled), 5, 0), true);
         edtSolicitudesCotizacion_Enabled = 0;
         AssignProp("", false, edtSolicitudesCotizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCotizacion_Enabled), 5, 0), true);
         edtSolicitudServicioPFinal_Enabled = 0;
         AssignProp("", false, edtSolicitudServicioPFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioPFinal_Enabled), 5, 0), true);
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
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudServicioOrigenPago.Enabled), 5, 0), true);
         dynMetodoPagosID.Enabled = 0;
         AssignProp("", false, dynMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMetodoPagosID.Enabled), 5, 0), true);
         cmbSolicitudesPagado.Enabled = 0;
         AssignProp("", false, cmbSolicitudesPagado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesPagado.Enabled), 5, 0), true);
         edtSolicitudesOtros3_Enabled = 0;
         AssignProp("", false, edtSolicitudesOtros3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros3_Enabled), 5, 0), true);
         edtSolicitudesComentario_Enabled = 0;
         AssignProp("", false, edtSolicitudesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesComentario_Enabled), 5, 0), true);
         edtSolicitudesNota_Enabled = 0;
         AssignProp("", false, edtSolicitudesNota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNota_Enabled), 5, 0), true);
         cmbSolicitudesNotificacion.Enabled = 0;
         AssignProp("", false, cmbSolicitudesNotificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesNotificacion.Enabled), 5, 0), true);
         edtSolicitudesCalComi_Enabled = 0;
         AssignProp("", false, edtSolicitudesCalComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesCalComi_Enabled), 5, 0), true);
         cmbSolicitudesSubTipo.Enabled = 0;
         AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSolicitudesSubTipo.Enabled), 5, 0), true);
         edtEstadosSolId_Enabled = 0;
         AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDX0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13DX2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_105 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_105"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
            AV18GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Dvpanel_transactiondetail_data3_Width = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Width");
            Dvpanel_transactiondetail_data3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Autowidth"));
            Dvpanel_transactiondetail_data3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Autoheight"));
            Dvpanel_transactiondetail_data3_Cls = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Cls");
            Dvpanel_transactiondetail_data3_Title = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Title");
            Dvpanel_transactiondetail_data3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsible"));
            Dvpanel_transactiondetail_data3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Collapsed"));
            Dvpanel_transactiondetail_data3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Showcollapseicon"));
            Dvpanel_transactiondetail_data3_Iconposition = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Iconposition");
            Dvpanel_transactiondetail_data3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA3_Autoscroll"));
            Dvpanel_transactiondetail_data4_Width = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Width");
            Dvpanel_transactiondetail_data4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Autowidth"));
            Dvpanel_transactiondetail_data4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Autoheight"));
            Dvpanel_transactiondetail_data4_Cls = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Cls");
            Dvpanel_transactiondetail_data4_Title = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Title");
            Dvpanel_transactiondetail_data4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsible"));
            Dvpanel_transactiondetail_data4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Collapsed"));
            Dvpanel_transactiondetail_data4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Showcollapseicon"));
            Dvpanel_transactiondetail_data4_Iconposition = cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Iconposition");
            Dvpanel_transactiondetail_data4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TRANSACTIONDETAIL_DATA4_Autoscroll"));
            Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Class = cgiGet( "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Class");
            Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1_Historymanagement"));
            Grid_titlescategories_Gridinternalname = cgiGet( "GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( "GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascategories"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
            AssignAttri("", false, "A172SolicitudesTelefono", A172SolicitudesTelefono);
            A206SolicitudesMail = cgiGet( edtSolicitudesMail_Internalname);
            n206SolicitudesMail = false;
            AssignAttri("", false, "A206SolicitudesMail", A206SolicitudesMail);
            A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A533ProveedorNombreAux = cgiGet( edtProveedorNombreAux_Internalname);
            n533ProveedorNombreAux = false;
            AssignAttri("", false, "A533ProveedorNombreAux", A533ProveedorNombreAux);
            dynDepartamentoId.Name = dynDepartamentoId_Internalname;
            dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            dynDepartamentoMunicipioId.Name = dynDepartamentoMunicipioId_Internalname;
            dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            dynZonasID.Name = dynZonasID_Internalname;
            dynZonasID.CurrentValue = cgiGet( dynZonasID_Internalname);
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynZonasID_Internalname), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A173SolicitudesDireccion = cgiGet( edtSolicitudesDireccion_Internalname);
            AssignAttri("", false, "A173SolicitudesDireccion", A173SolicitudesDireccion);
            A201SolicitudesOtros1 = ((StringUtil.StrCmp(cgiGet( chkSolicitudesOtros1_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
            A202SolicitudesOtros2 = cgiGet( edtSolicitudesOtros2_Internalname);
            AssignAttri("", false, "A202SolicitudesOtros2", A202SolicitudesOtros2);
            A184SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( edtSolicitudesFechaInstalacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri("", false, "A184SolicitudesFechaInstalacion", context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"));
            cmbSolicitudesHoraInstalacion.Name = cmbSolicitudesHoraInstalacion_Internalname;
            cmbSolicitudesHoraInstalacion.CurrentValue = cgiGet( cmbSolicitudesHoraInstalacion_Internalname);
            A183SolicitudesHoraInstalacion = cgiGet( cmbSolicitudesHoraInstalacion_Internalname);
            AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
            A174SolicitudesTotal = context.localUtil.CToN( cgiGet( edtSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "A174SolicitudesTotal", StringUtil.LTrimStr( A174SolicitudesTotal, 18, 2));
            A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(cgiGet( chkSolicitudServicioSolCoti_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
            A212SolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "A212SolicitudesCotizacion", StringUtil.LTrimStr( A212SolicitudesCotizacion, 18, 2));
            A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "A211SolicitudServicioPFinal", StringUtil.LTrimStr( A211SolicitudServicioPFinal, 18, 2));
            A527SolicitudServicioComProv = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n527SolicitudServicioComProv = false;
            AssignAttri("", false, "A527SolicitudServicioComProv", StringUtil.LTrimStr( A527SolicitudServicioComProv, 18, 2));
            A528SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n528SolicitudServicioComProvP = false;
            AssignAttri("", false, "A528SolicitudServicioComProvP", StringUtil.LTrimStr( A528SolicitudServicioComProvP, 6, 2));
            A530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n530SolicitudServicioComALM = false;
            AssignAttri("", false, "A530SolicitudServicioComALM", StringUtil.LTrimStr( A530SolicitudServicioComALM, 18, 2));
            A532SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n532SolicitudServicioComALMP = false;
            AssignAttri("", false, "A532SolicitudServicioComALMP", StringUtil.LTrimStr( A532SolicitudServicioComALMP, 6, 2));
            A529SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtSolicitudServicioComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "A529SolicitudServicioComPro", StringUtil.LTrimStr( A529SolicitudServicioComPro, 18, 2));
            A531SolicitudServicioComProP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "A531SolicitudServicioComProP", StringUtil.LTrimStr( A531SolicitudServicioComProP, 6, 2));
            cmbSolicitudServicioOrigenPago.Name = cmbSolicitudServicioOrigenPago_Internalname;
            cmbSolicitudServicioOrigenPago.CurrentValue = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
            A438SolicitudServicioOrigenPago = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
            n438SolicitudServicioOrigenPago = false;
            AssignAttri("", false, "A438SolicitudServicioOrigenPago", A438SolicitudServicioOrigenPago);
            dynMetodoPagosID.Name = dynMetodoPagosID_Internalname;
            dynMetodoPagosID.CurrentValue = cgiGet( dynMetodoPagosID_Internalname);
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMetodoPagosID_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            cmbSolicitudesPagado.Name = cmbSolicitudesPagado_Internalname;
            cmbSolicitudesPagado.CurrentValue = cgiGet( cmbSolicitudesPagado_Internalname);
            A441SolicitudesPagado = cgiGet( cmbSolicitudesPagado_Internalname);
            n441SolicitudesPagado = false;
            AssignAttri("", false, "A441SolicitudesPagado", A441SolicitudesPagado);
            A203SolicitudesOtros3 = cgiGet( edtSolicitudesOtros3_Internalname);
            AssignAttri("", false, "A203SolicitudesOtros3", A203SolicitudesOtros3);
            A205SolicitudesComentario = cgiGet( edtSolicitudesComentario_Internalname);
            AssignAttri("", false, "A205SolicitudesComentario", A205SolicitudesComentario);
            A261SolicitudesNota = cgiGet( edtSolicitudesNota_Internalname);
            AssignAttri("", false, "A261SolicitudesNota", A261SolicitudesNota);
            cmbSolicitudesNotificacion.Name = cmbSolicitudesNotificacion_Internalname;
            cmbSolicitudesNotificacion.CurrentValue = cgiGet( cmbSolicitudesNotificacion_Internalname);
            A262SolicitudesNotificacion = cgiGet( cmbSolicitudesNotificacion_Internalname);
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDCURRENTPAGE");
               GX_FocusControl = edtavGridcurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16GridCurrentPage = 0;
               AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
            }
            else
            {
               AV16GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
            }
            A672SolicitudesCalComi = StringUtil.StrToBool( cgiGet( edtSolicitudesCalComi_Internalname));
            AssignAttri("", false, "A672SolicitudesCalComi", A672SolicitudesCalComi);
            cmbSolicitudesSubTipo.Name = cmbSolicitudesSubTipo_Internalname;
            cmbSolicitudesSubTipo.CurrentValue = cgiGet( cmbSolicitudesSubTipo_Internalname);
            A600SolicitudesSubTipo = cgiGet( cmbSolicitudesSubTipo_Internalname);
            n600SolicitudesSubTipo = false;
            AssignAttri("", false, "A600SolicitudesSubTipo", A600SolicitudesSubTipo);
            A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13DX2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13DX2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtSolicitudesCalComi_Visible = 0;
         AssignProp("", false, edtSolicitudesCalComi_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCalComi_Visible), 5, 0), true);
         cmbSolicitudesSubTipo.Visible = 0;
         AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSolicitudesSubTipo.Visible), 5, 0), true);
         edtEstadosSolId_Visible = 0;
         AssignProp("", false, edtEstadosSolId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Visible), 5, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         Grid_titlescategories_Gridtitlescategories = StringUtil.Format( "%1;%1;%1;%1;%1;%1;%2;%2;%2;%2;%2;%2;%2;%2;%3;%3;%3;%3;%3;%3", context.GetMessage( "SERVICIO", ""), context.GetMessage( "PRECIO", ""), context.GetMessage( "Comisiones", ""), "", "", "", "", "", "");
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
         AV16GridCurrentPage = 1;
         AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
         edtavGridcurrentpage_Visible = 0;
         AssignProp("", false, edtavGridcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridcurrentpage_Visible), 5, 0), true);
         AV17GridPageCount = -1;
         AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E14DX2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E15DX2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 105;
         }
         sendrow_1052( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_105_Refreshing )
         {
            context.DoAjaxLoad(105, GridRow);
         }
      }

      protected void E11DX2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV16GridCurrentPage = (long)(AV16GridCurrentPage-1);
            AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV16GridCurrentPage = (long)(AV16GridCurrentPage+1);
            AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
            subgrid_nextpage( ) ;
         }
         else
         {
            AV15PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV16GridCurrentPage = AV15PageToGo;
            AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
            subgrid_gotopage( AV15PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E12DX2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV16GridCurrentPage = 1;
         AssignAttri("", false, "AV16GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV16GridCurrentPage), 10, 0));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A127SolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "A127SolicitudesID", StringUtil.LTrimStr( (decimal)(A127SolicitudesID), 18, 0));
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
         PADX2( ) ;
         WSDX2( ) ;
         WEDX2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026980405476", true, true, false);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true, false);
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
            context.AddJavascriptSource("comercios/versolicitudes.js", "?2026980405476", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
            context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
            context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1052( )
      {
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID_"+sGXsfl_105_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_105_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_105_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_105_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_105_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_105_idx;
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL_"+sGXsfl_105_idx;
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD_"+sGXsfl_105_idx;
         edtSolicitudesItemsPrecioInstalac_Internalname = "SOLICITUDESITEMSPRECIOINSTALAC_"+sGXsfl_105_idx;
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION_"+sGXsfl_105_idx;
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR_"+sGXsfl_105_idx;
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO_"+sGXsfl_105_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_105_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiProf_Internalname = "SOLICITUDESITEMSCOMIPROF_"+sGXsfl_105_idx;
         edtSolicitudesItemsComiProfP_Internalname = "SOLICITUDESITEMSCOMIPROFP_"+sGXsfl_105_idx;
      }

      protected void SubsflControlProps_fel_1052( )
      {
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID_"+sGXsfl_105_fel_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_105_fel_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_105_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_105_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_105_fel_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsPrecioInstalac_Internalname = "SOLICITUDESITEMSPRECIOINSTALAC_"+sGXsfl_105_fel_idx;
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION_"+sGXsfl_105_fel_idx;
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR_"+sGXsfl_105_fel_idx;
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO_"+sGXsfl_105_fel_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_105_fel_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiProf_Internalname = "SOLICITUDESITEMSCOMIPROF_"+sGXsfl_105_fel_idx;
         edtSolicitudesItemsComiProfP_Internalname = "SOLICITUDESITEMSCOMIPROFP_"+sGXsfl_105_fel_idx;
      }

      protected void sendrow_1052( )
      {
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         WBDX0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_105_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_105_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_105_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A134SolicitudesItemsID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GXARUBROSID_htmlDX2( ) ;
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynRubrosId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RUBROSID_" + sGXsfl_105_idx;
               dynRubrosId.Name = GXCCtl;
               dynRubrosId.WebTags = "";
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynRubrosId,(string)dynRubrosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)),(short)1,(string)dynRubrosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
            AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), !bGXsfl_105_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A168RubrosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            GXAMEDIDASID_htmlDX2( ) ;
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_105_idx;
               dynMedidasID.Name = GXCCtl;
               dynMedidasID.WebTags = "";
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_105_Refreshing);
            GXAINVENTARIOID_htmlDX2( ) ;
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_105_idx;
               dynInventarioId.Name = GXCCtl;
               dynInventarioId.WebTags = "";
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
            AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_105_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A189InventarioImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001InventarioImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.PathToRelativeUrl( A189InventarioImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A189InventarioImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A176SolicitudesItemsPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A176SolicitudesItemsPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A177SolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A177SolicitudesItemsCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsPrecioInstalac_Internalname,StringUtil.LTrim( StringUtil.NToC( A175SolicitudesItemsPrecioInstalac, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A175SolicitudesItemsPrecioInstalac, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsPrecioInstalac_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudItemsComision_Internalname,StringUtil.LTrim( StringUtil.NToC( A180SolicitudItemsComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A180SolicitudItemsComision, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudItemsComision_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbSolicitudItemsSR.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDITEMSSR_" + sGXsfl_105_idx;
               cmbSolicitudItemsSR.Name = GXCCtl;
               cmbSolicitudItemsSR.WebTags = "";
               cmbSolicitudItemsSR.addItem("S", context.GetMessage( "Suma", ""), 0);
               cmbSolicitudItemsSR.addItem("R", context.GetMessage( "Resta", ""), 0);
               if ( cmbSolicitudItemsSR.ItemCount > 0 )
               {
                  A178SolicitudItemsSR = cmbSolicitudItemsSR.getValidValue(A178SolicitudItemsSR);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudItemsSR,(string)cmbSolicitudItemsSR_Internalname,StringUtil.RTrim( A178SolicitudItemsSR),(short)1,(string)cmbSolicitudItemsSR_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudItemsSR.CurrentValue = StringUtil.RTrim( A178SolicitudItemsSR);
            AssignProp("", false, cmbSolicitudItemsSR_Internalname, "Values", (string)(cmbSolicitudItemsSR.ToJavascriptSource()), !bGXsfl_105_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudItemsComisionTipo_Internalname,StringUtil.RTrim( A179SolicitudItemsComisionTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudItemsComisionTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaISOSimbolo_Internalname,StringUtil.RTrim( A119MonedaISOSimbolo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaISOSimbolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProv_Internalname,StringUtil.LTrim( StringUtil.NToC( A521SolicitudesItemsComiProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A521SolicitudesItemsComiProv, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProvP_Internalname,StringUtil.LTrim( StringUtil.NToC( A524SolicitudesItemsComiProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A524SolicitudesItemsComiProvP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProvP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A523SolicitudesItemsComiALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A523SolicitudesItemsComiALM, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiALMP_Internalname,StringUtil.LTrim( StringUtil.NToC( A526SolicitudesItemsComiALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A526SolicitudesItemsComiALMP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiALMP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProf_Internalname,StringUtil.LTrim( StringUtil.NToC( A522SolicitudesItemsComiProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A522SolicitudesItemsComiProf, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProf_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProfP_Internalname,StringUtil.LTrim( StringUtil.NToC( A525SolicitudesItemsComiProfP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A525SolicitudesItemsComiProfP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProfP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesDX2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
         }
         /* End function sendrow_1052 */
      }

      protected void init_web_controls( )
      {
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
         dynZonasID.Name = "ZONASID";
         dynZonasID.WebTags = "";
         chkSolicitudesOtros1.Name = "SOLICITUDESOTROS1";
         chkSolicitudesOtros1.WebTags = "";
         chkSolicitudesOtros1.Caption = context.GetMessage( "No aparecen en el listado los servicios que necesito.", "");
         AssignProp("", false, chkSolicitudesOtros1_Internalname, "TitleCaption", chkSolicitudesOtros1.Caption, true);
         chkSolicitudesOtros1.CheckedValue = "N";
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A201SolicitudesOtros1", A201SolicitudesOtros1);
         cmbSolicitudesHoraInstalacion.Name = "SOLICITUDESHORAINSTALACION";
         cmbSolicitudesHoraInstalacion.WebTags = "";
         cmbSolicitudesHoraInstalacion.addItem("1", context.GetMessage( "Turno 1, 8:00-12:00", ""), 0);
         cmbSolicitudesHoraInstalacion.addItem("2", context.GetMessage( "Turno 2, 12:00-16:00", ""), 0);
         cmbSolicitudesHoraInstalacion.addItem("3", context.GetMessage( "Turno 3, 16:00-20:00", ""), 0);
         if ( cmbSolicitudesHoraInstalacion.ItemCount > 0 )
         {
            A183SolicitudesHoraInstalacion = cmbSolicitudesHoraInstalacion.getValidValue(A183SolicitudesHoraInstalacion);
            AssignAttri("", false, "A183SolicitudesHoraInstalacion", A183SolicitudesHoraInstalacion);
         }
         GXCCtl = "RUBROSID_" + sGXsfl_105_idx;
         dynRubrosId.Name = GXCCtl;
         dynRubrosId.WebTags = "";
         GXCCtl = "MEDIDASID_" + sGXsfl_105_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_105_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         GXCCtl = "SOLICITUDITEMSSR_" + sGXsfl_105_idx;
         cmbSolicitudItemsSR.Name = GXCCtl;
         cmbSolicitudItemsSR.WebTags = "";
         cmbSolicitudItemsSR.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbSolicitudItemsSR.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbSolicitudItemsSR.ItemCount > 0 )
         {
            A178SolicitudItemsSR = cmbSolicitudItemsSR.getValidValue(A178SolicitudItemsSR);
         }
         chkSolicitudServicioSolCoti.Name = "SOLICITUDSERVICIOSOLCOTI";
         chkSolicitudServicioSolCoti.WebTags = "";
         chkSolicitudServicioSolCoti.Caption = context.GetMessage( "Solicitar cotización ", "");
         AssignProp("", false, chkSolicitudServicioSolCoti_Internalname, "TitleCaption", chkSolicitudServicioSolCoti.Caption, true);
         chkSolicitudServicioSolCoti.CheckedValue = "N";
         A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(StringUtil.RTrim( A210SolicitudServicioSolCoti), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A210SolicitudServicioSolCoti", A210SolicitudServicioSolCoti);
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
         dynMetodoPagosID.Name = "METODOPAGOSID";
         dynMetodoPagosID.WebTags = "";
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
         cmbSolicitudesNotificacion.Name = "SOLICITUDESNOTIFICACION";
         cmbSolicitudesNotificacion.WebTags = "";
         cmbSolicitudesNotificacion.addItem("S", context.GetMessage( "Si", ""), 0);
         cmbSolicitudesNotificacion.addItem("N", context.GetMessage( "No", ""), 0);
         if ( cmbSolicitudesNotificacion.ItemCount > 0 )
         {
            A262SolicitudesNotificacion = cmbSolicitudesNotificacion.getValidValue(A262SolicitudesNotificacion);
            AssignAttri("", false, "A262SolicitudesNotificacion", A262SolicitudesNotificacion);
         }
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

      protected void StartGridControl105( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"105\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "No.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Item", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comision", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Accion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "%") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Almango", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "%") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "%") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A168RubrosImagen));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A189InventarioImagen));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A176SolicitudesItemsPrecioFinal, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A177SolicitudesItemsCantidad), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A175SolicitudesItemsPrecioInstalac, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A180SolicitudItemsComision, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A178SolicitudItemsSR)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A179SolicitudItemsComisionTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A119MonedaISOSimbolo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A521SolicitudesItemsComiProv, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A524SolicitudesItemsComiProvP, 6, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A523SolicitudesItemsComiALM, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A526SolicitudesItemsComiALMP, 6, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A522SolicitudesItemsComiProf, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A525SolicitudesItemsComiProfP, 6, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblDatosgenerales_title_Internalname = "DATOSGENERALES_TITLE";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO";
         edtSolicitudesMail_Internalname = "SOLICITUDESMAIL";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorNombreAux_Internalname = "PROVEEDORNOMBREAUX";
         divTransactiondetail_data1_Internalname = "TRANSACTIONDETAIL_DATA1";
         dynDepartamentoId_Internalname = "DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         dynZonasID_Internalname = "ZONASID";
         edtSolicitudesDireccion_Internalname = "SOLICITUDESDIRECCION";
         divTransactiondetail_data2_Internalname = "TRANSACTIONDETAIL_DATA2";
         chkSolicitudesOtros1_Internalname = "SOLICITUDESOTROS1";
         edtSolicitudesOtros2_Internalname = "SOLICITUDESOTROS2";
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION";
         cmbSolicitudesHoraInstalacion_Internalname = "SOLICITUDESHORAINSTALACION";
         divTransactiondetail_tbdata1_Internalname = "TRANSACTIONDETAIL_TBDATA1";
         lblDatosservicio_title_Internalname = "DATOSSERVICIO_TITLE";
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID";
         dynRubrosId_Internalname = "RUBROSID";
         edtRubrosImagen_Internalname = "RUBROSIMAGEN";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN";
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL";
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD";
         edtSolicitudesItemsPrecioInstalac_Internalname = "SOLICITUDESITEMSPRECIOINSTALAC";
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION";
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR";
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO";
         edtMonedaId_Internalname = "MONEDAID";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV";
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP";
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM";
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP";
         edtSolicitudesItemsComiProf_Internalname = "SOLICITUDESITEMSCOMIPROF";
         edtSolicitudesItemsComiProfP_Internalname = "SOLICITUDESITEMSCOMIPROFP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTransactiondetail_tableleaflevel_items_Internalname = "TRANSACTIONDETAIL_TABLELEAFLEVEL_ITEMS";
         edtSolicitudesTotal_Internalname = "SOLICITUDESTOTAL";
         chkSolicitudServicioSolCoti_Internalname = "SOLICITUDSERVICIOSOLCOTI";
         edtSolicitudesCotizacion_Internalname = "SOLICITUDESCOTIZACION";
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL";
         divTransactiondetail_data3_Internalname = "TRANSACTIONDETAIL_DATA3";
         Dvpanel_transactiondetail_data3_Internalname = "DVPANEL_TRANSACTIONDETAIL_DATA3";
         edtSolicitudServicioComProv_Internalname = "SOLICITUDSERVICIOCOMPROV";
         edtSolicitudServicioComProvP_Internalname = "SOLICITUDSERVICIOCOMPROVP";
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM";
         edtSolicitudServicioComALMP_Internalname = "SOLICITUDSERVICIOCOMALMP";
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO";
         edtSolicitudServicioComProP_Internalname = "SOLICITUDSERVICIOCOMPROP";
         divTransactiondetail_data4_Internalname = "TRANSACTIONDETAIL_DATA4";
         Dvpanel_transactiondetail_data4_Internalname = "DVPANEL_TRANSACTIONDETAIL_DATA4";
         divDvpanel_transactiondetail_data4_cell_Internalname = "DVPANEL_TRANSACTIONDETAIL_DATA4_CELL";
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO";
         dynMetodoPagosID_Internalname = "METODOPAGOSID";
         cmbSolicitudesPagado_Internalname = "SOLICITUDESPAGADO";
         divTransactiondetail_data5_Internalname = "TRANSACTIONDETAIL_DATA5";
         divTransactiondetail_tbdata2_Internalname = "TRANSACTIONDETAIL_TBDATA2";
         lblInformacion_title_Internalname = "INFORMACION_TITLE";
         edtSolicitudesOtros3_Internalname = "SOLICITUDESOTROS3";
         edtSolicitudesComentario_Internalname = "SOLICITUDESCOMENTARIO";
         edtSolicitudesNota_Internalname = "SOLICITUDESNOTA";
         cmbSolicitudesNotificacion_Internalname = "SOLICITUDESNOTIFICACION";
         divTransactiondetail_tbdata3_Internalname = "TRANSACTIONDETAIL_TBDATA3";
         Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Internalname = "GXUITABSPANEL_GXUITABSPANEL_TRANSACTIONDETAIL_TABS1";
         divTransactiondetail_tableattributes_Internalname = "TRANSACTIONDETAIL_TABLEATTRIBUTES";
         divTable_Internalname = "TABLE";
         edtavGridcurrentpage_Internalname = "vGRIDCURRENTPAGE";
         edtSolicitudesCalComi_Internalname = "SOLICITUDESCALCOMI";
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         Grid_titlescategories_Internalname = "GRID_TITLESCATEGORIES";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkSolicitudServicioSolCoti.Caption = context.GetMessage( "Solicitar cotización ", "");
         chkSolicitudesOtros1.Caption = context.GetMessage( "No aparecen en el listado los servicios que necesito.", "");
         edtSolicitudesItemsComiProfP_Jsonclick = "";
         edtSolicitudesItemsComiProf_Jsonclick = "";
         edtSolicitudesItemsComiALMP_Jsonclick = "";
         edtSolicitudesItemsComiALM_Jsonclick = "";
         edtSolicitudesItemsComiProvP_Jsonclick = "";
         edtSolicitudesItemsComiProv_Jsonclick = "";
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaId_Jsonclick = "";
         edtSolicitudItemsComisionTipo_Jsonclick = "";
         cmbSolicitudItemsSR_Jsonclick = "";
         edtSolicitudItemsComision_Jsonclick = "";
         edtSolicitudesItemsPrecioInstalac_Jsonclick = "";
         edtSolicitudesItemsCantidad_Jsonclick = "";
         edtSolicitudesItemsPrecioFinal_Jsonclick = "";
         dynInventarioId_Jsonclick = "";
         dynMedidasID_Jsonclick = "";
         dynRubrosId_Jsonclick = "";
         edtSolicitudesItemsID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtEstadosSolId_Enabled = 0;
         cmbSolicitudesSubTipo.Enabled = 0;
         edtSolicitudesCalComi_Enabled = 0;
         edtSolicitudesItemsComiProfP_Enabled = 0;
         edtSolicitudesItemsComiProf_Enabled = 0;
         edtSolicitudesItemsComiALMP_Enabled = 0;
         edtSolicitudesItemsComiALM_Enabled = 0;
         edtSolicitudesItemsComiProvP_Enabled = 0;
         edtSolicitudesItemsComiProv_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtSolicitudItemsComisionTipo_Enabled = 0;
         cmbSolicitudItemsSR.Enabled = 0;
         edtSolicitudItemsComision_Enabled = 0;
         edtSolicitudesItemsPrecioInstalac_Enabled = 0;
         edtSolicitudesItemsCantidad_Enabled = 0;
         edtSolicitudesItemsPrecioFinal_Enabled = 0;
         edtInventarioImagen_Enabled = 0;
         dynInventarioId.Enabled = 0;
         dynMedidasID.Enabled = 0;
         edtRubrosImagen_Enabled = 0;
         dynRubrosId.Enabled = 0;
         edtSolicitudesItemsID_Enabled = 0;
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolId_Visible = 1;
         cmbSolicitudesSubTipo_Jsonclick = "";
         cmbSolicitudesSubTipo.Visible = 1;
         edtSolicitudesCalComi_Jsonclick = "";
         edtSolicitudesCalComi_Visible = 1;
         edtavGridcurrentpage_Jsonclick = "";
         edtavGridcurrentpage_Visible = 1;
         cmbSolicitudesNotificacion_Jsonclick = "";
         cmbSolicitudesNotificacion.Enabled = 0;
         edtSolicitudesNota_Enabled = 0;
         edtSolicitudesComentario_Enabled = 0;
         edtSolicitudesOtros3_Enabled = 0;
         cmbSolicitudesPagado_Jsonclick = "";
         cmbSolicitudesPagado.Enabled = 0;
         dynMetodoPagosID_Jsonclick = "";
         dynMetodoPagosID.Enabled = 0;
         cmbSolicitudServicioOrigenPago_Jsonclick = "";
         cmbSolicitudServicioOrigenPago.Enabled = 0;
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
         edtSolicitudServicioPFinal_Jsonclick = "";
         edtSolicitudServicioPFinal_Enabled = 0;
         edtSolicitudesCotizacion_Jsonclick = "";
         edtSolicitudesCotizacion_Enabled = 0;
         chkSolicitudServicioSolCoti.Enabled = 0;
         edtSolicitudesTotal_Jsonclick = "";
         edtSolicitudesTotal_Enabled = 0;
         cmbSolicitudesHoraInstalacion_Jsonclick = "";
         cmbSolicitudesHoraInstalacion.Enabled = 0;
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtSolicitudesOtros2_Enabled = 0;
         chkSolicitudesOtros1.Enabled = 0;
         edtSolicitudesDireccion_Enabled = 0;
         dynZonasID_Jsonclick = "";
         dynZonasID.Enabled = 0;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 0;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 0;
         edtProveedorNombreAux_Jsonclick = "";
         edtProveedorNombreAux_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtSolicitudesMail_Jsonclick = "";
         edtSolicitudesMail_Enabled = 0;
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesID_Jsonclick = "";
         edtSolicitudesID_Enabled = 0;
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = "";
         Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Class = "Tab";
         Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Pagecount = 3;
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
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Ver Solicitudes", "");
         subGrid_Rows = 0;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Valid_Monedaid( )
      {
         n112DepartamentoId = false;
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n112DepartamentoId = false;
         n114DepartamentoMunicipioId = false;
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n114DepartamentoMunicipioId = false;
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( dynMetodoPagosID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor H00DX19 */
         pr_default.execute(17, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_inex", new   object[]  {" T12"}), 1, "MONEDAID");
         }
         A119MonedaISOSimbolo = H00DX19_A119MonedaISOSimbolo[0];
         pr_default.close(17);
         /* Using cursor H00DX20 */
         pr_default.execute(18, new Object[] {A116PaisID, A118MonedaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_inex", new   object[]  {"Moneda"}), 1, "MONEDAID");
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A119MonedaISOSimbolo", StringUtil.RTrim( A119MonedaISOSimbolo));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMetodoPagosID'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E15DX2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11DX2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMetodoPagosID'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12DX2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMetodoPagosID'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A201SolicitudesOtros1',fld:'SOLICITUDESOTROS1',pic:'',type:'char'},{av:'A210SolicitudServicioSolCoti',fld:'SOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
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
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV","{handler:'Valid_Solicitudserviciocomprov',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP","{handler:'Valid_Solicitudserviciocomprovp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM","{handler:'Valid_Solicitudserviciocomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP","{handler:'Valid_Solicitudserviciocomalmp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSPRECIOFINAL","{handler:'Valid_Solicitudesitemspreciofinal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSCANTIDAD","{handler:'Valid_Solicitudesitemscantidad',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSCANTIDAD",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSPRECIOINSTALAC","{handler:'Valid_Solicitudesitemsprecioinstalac',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSPRECIOINSTALAC",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDITEMSCOMISION","{handler:'Valid_Solicituditemscomision',iparms:[]");
         setEventMetadata("VALID_SOLICITUDITEMSCOMISION",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDITEMSSR","{handler:'Valid_Solicituditemssr',iparms:[]");
         setEventMetadata("VALID_SOLICITUDITEMSSR",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDITEMSCOMISIONTIPO","{handler:'Valid_Solicituditemscomisiontipo',iparms:[]");
         setEventMetadata("VALID_SOLICITUDITEMSCOMISIONTIPO",",oparms:[]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMetodoPagosID'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'A119MonedaISOSimbolo',fld:'MONEDAISOSIMBOLO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIPROV","{handler:'Valid_Solicitudesitemscomiprov',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIPROV",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIPROVP","{handler:'Valid_Solicitudesitemscomiprovp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIPROVP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIALM","{handler:'Valid_Solicitudesitemscomialm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIALMP","{handler:'Valid_Solicitudesitemscomialmp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESITEMSCOMIALMP",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudesitemscomiprofp',iparms:[]");
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
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A201SolicitudesOtros1 = "";
         A210SolicitudServicioSolCoti = "";
         H00DX2_A127SolicitudesID = new long[1] ;
         H00DX2_A134SolicitudesItemsID = new short[1] ;
         H00DX2_A180SolicitudItemsComision = new decimal[1] ;
         H00DX2_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00DX2_A178SolicitudItemsSR = new string[] {""} ;
         H00DX2_A177SolicitudesItemsCantidad = new short[1] ;
         H00DX2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00DX2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18GridAppliedFilters = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1 = new GXUserControl();
         lblDatosgenerales_title_Jsonclick = "";
         TempTags = "";
         A171SolicitudesNombre = "";
         gxphoneLink = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A282ProveedorNombre = "";
         A533ProveedorNombreAux = "";
         ClassString = "";
         StyleString = "";
         A173SolicitudesDireccion = "";
         A202SolicitudesOtros2 = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         lblDatosservicio_title_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDvpanel_transactiondetail_data3 = new GXUserControl();
         ucDvpanel_transactiondetail_data4 = new GXUserControl();
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         lblInformacion_title_Jsonclick = "";
         A203SolicitudesOtros3 = "";
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A600SolicitudesSubTipo = "";
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A168RubrosImagen = "";
         A40002RubrosImagen_GXI = "";
         A189InventarioImagen = "";
         A40001InventarioImagen_GXI = "";
         A178SolicitudItemsSR = "";
         A179SolicitudItemsComisionTipo = "";
         A119MonedaISOSimbolo = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00DX3_A112DepartamentoId = new long[1] ;
         H00DX3_n112DepartamentoId = new bool[] {false} ;
         H00DX3_A113DepartamentoDepartamento = new string[] {""} ;
         H00DX4_A112DepartamentoId = new long[1] ;
         H00DX4_n112DepartamentoId = new bool[] {false} ;
         H00DX4_A114DepartamentoMunicipioId = new long[1] ;
         H00DX4_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DX4_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H00DX5_A112DepartamentoId = new long[1] ;
         H00DX5_n112DepartamentoId = new bool[] {false} ;
         H00DX5_A114DepartamentoMunicipioId = new long[1] ;
         H00DX5_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DX5_A110ZonasID = new long[1] ;
         H00DX5_n110ZonasID = new bool[] {false} ;
         H00DX5_A111ZonasNombre = new string[] {""} ;
         H00DX6_A121RubrosId = new short[1] ;
         H00DX6_A122RubrosNombre = new string[] {""} ;
         H00DX6_A123RubrosEstado = new string[] {""} ;
         H00DX6_n123RubrosEstado = new bool[] {false} ;
         H00DX7_A121RubrosId = new short[1] ;
         H00DX7_A137MedidasID = new long[1] ;
         H00DX7_A138MedidasNombre = new string[] {""} ;
         H00DX7_A139MedidasEstado = new string[] {""} ;
         H00DX7_n139MedidasEstado = new bool[] {false} ;
         H00DX8_A121RubrosId = new short[1] ;
         H00DX8_A137MedidasID = new long[1] ;
         H00DX8_A135InventarioId = new long[1] ;
         H00DX8_A136InventarioNombre = new string[] {""} ;
         H00DX8_A107EstadosTipo = new string[] {""} ;
         H00DX8_A108EstadosGenericosId = new int[1] ;
         H00DX9_A128MetodoPagosID = new long[1] ;
         H00DX9_A129MetodoPagosNombre = new string[] {""} ;
         H00DX9_A108EstadosGenericosId = new int[1] ;
         H00DX10_A116PaisID = new string[] {""} ;
         H00DX10_A669STMonedasId = new short[1] ;
         H00DX10_n669STMonedasId = new bool[] {false} ;
         H00DX10_A133ProveedorID = new long[1] ;
         H00DX10_A127SolicitudesID = new long[1] ;
         H00DX10_A171SolicitudesNombre = new string[] {""} ;
         H00DX10_A172SolicitudesTelefono = new string[] {""} ;
         H00DX10_A206SolicitudesMail = new string[] {""} ;
         H00DX10_n206SolicitudesMail = new bool[] {false} ;
         H00DX10_A282ProveedorNombre = new string[] {""} ;
         H00DX10_A533ProveedorNombreAux = new string[] {""} ;
         H00DX10_n533ProveedorNombreAux = new bool[] {false} ;
         H00DX10_A112DepartamentoId = new long[1] ;
         H00DX10_n112DepartamentoId = new bool[] {false} ;
         H00DX10_A114DepartamentoMunicipioId = new long[1] ;
         H00DX10_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DX10_A110ZonasID = new long[1] ;
         H00DX10_n110ZonasID = new bool[] {false} ;
         H00DX10_A173SolicitudesDireccion = new string[] {""} ;
         H00DX10_A201SolicitudesOtros1 = new string[] {""} ;
         H00DX10_A202SolicitudesOtros2 = new string[] {""} ;
         H00DX10_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00DX10_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H00DX10_A210SolicitudServicioSolCoti = new string[] {""} ;
         H00DX10_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00DX10_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00DX10_A128MetodoPagosID = new long[1] ;
         H00DX10_A441SolicitudesPagado = new string[] {""} ;
         H00DX10_n441SolicitudesPagado = new bool[] {false} ;
         H00DX10_A203SolicitudesOtros3 = new string[] {""} ;
         H00DX10_A205SolicitudesComentario = new string[] {""} ;
         H00DX10_A261SolicitudesNota = new string[] {""} ;
         H00DX10_A262SolicitudesNotificacion = new string[] {""} ;
         H00DX10_A672SolicitudesCalComi = new bool[] {false} ;
         H00DX10_A600SolicitudesSubTipo = new string[] {""} ;
         H00DX10_n600SolicitudesSubTipo = new bool[] {false} ;
         H00DX10_A131EstadosSolId = new int[1] ;
         H00DX10_A40001InventarioImagen_GXI = new string[] {""} ;
         H00DX10_A135InventarioId = new long[1] ;
         H00DX10_A137MedidasID = new long[1] ;
         H00DX10_A40002RubrosImagen_GXI = new string[] {""} ;
         H00DX10_A121RubrosId = new short[1] ;
         H00DX10_A134SolicitudesItemsID = new short[1] ;
         H00DX10_A523SolicitudesItemsComiALM = new decimal[1] ;
         H00DX10_n523SolicitudesItemsComiALM = new bool[] {false} ;
         H00DX10_A521SolicitudesItemsComiProv = new decimal[1] ;
         H00DX10_n521SolicitudesItemsComiProv = new bool[] {false} ;
         H00DX10_A526SolicitudesItemsComiALMP = new decimal[1] ;
         H00DX10_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         H00DX10_A524SolicitudesItemsComiProvP = new decimal[1] ;
         H00DX10_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         H00DX10_A532SolicitudServicioComALMP = new decimal[1] ;
         H00DX10_n532SolicitudServicioComALMP = new bool[] {false} ;
         H00DX10_A528SolicitudServicioComProvP = new decimal[1] ;
         H00DX10_n528SolicitudServicioComProvP = new bool[] {false} ;
         H00DX10_A527SolicitudServicioComProv = new decimal[1] ;
         H00DX10_n527SolicitudServicioComProv = new bool[] {false} ;
         H00DX10_A530SolicitudServicioComALM = new decimal[1] ;
         H00DX10_n530SolicitudServicioComALM = new bool[] {false} ;
         H00DX10_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00DX10_A212SolicitudesCotizacion = new decimal[1] ;
         H00DX10_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00DX10_A897SolicitudesDescuento = new decimal[1] ;
         H00DX10_n897SolicitudesDescuento = new bool[] {false} ;
         H00DX10_A864SolicitudesCostoXZona = new decimal[1] ;
         H00DX10_A180SolicitudItemsComision = new decimal[1] ;
         H00DX10_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00DX10_A178SolicitudItemsSR = new string[] {""} ;
         H00DX10_A177SolicitudesItemsCantidad = new short[1] ;
         H00DX10_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00DX10_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         H00DX10_A189InventarioImagen = new string[] {""} ;
         H00DX10_A168RubrosImagen = new string[] {""} ;
         H00DX11_A116PaisID = new string[] {""} ;
         H00DX11_A669STMonedasId = new short[1] ;
         H00DX11_n669STMonedasId = new bool[] {false} ;
         H00DX11_A133ProveedorID = new long[1] ;
         H00DX11_A127SolicitudesID = new long[1] ;
         H00DX11_A171SolicitudesNombre = new string[] {""} ;
         H00DX11_A172SolicitudesTelefono = new string[] {""} ;
         H00DX11_A206SolicitudesMail = new string[] {""} ;
         H00DX11_n206SolicitudesMail = new bool[] {false} ;
         H00DX11_A282ProveedorNombre = new string[] {""} ;
         H00DX11_A533ProveedorNombreAux = new string[] {""} ;
         H00DX11_n533ProveedorNombreAux = new bool[] {false} ;
         H00DX11_A112DepartamentoId = new long[1] ;
         H00DX11_n112DepartamentoId = new bool[] {false} ;
         H00DX11_A114DepartamentoMunicipioId = new long[1] ;
         H00DX11_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DX11_A110ZonasID = new long[1] ;
         H00DX11_n110ZonasID = new bool[] {false} ;
         H00DX11_A173SolicitudesDireccion = new string[] {""} ;
         H00DX11_A201SolicitudesOtros1 = new string[] {""} ;
         H00DX11_A202SolicitudesOtros2 = new string[] {""} ;
         H00DX11_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00DX11_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H00DX11_A210SolicitudServicioSolCoti = new string[] {""} ;
         H00DX11_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00DX11_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00DX11_A128MetodoPagosID = new long[1] ;
         H00DX11_A441SolicitudesPagado = new string[] {""} ;
         H00DX11_n441SolicitudesPagado = new bool[] {false} ;
         H00DX11_A203SolicitudesOtros3 = new string[] {""} ;
         H00DX11_A205SolicitudesComentario = new string[] {""} ;
         H00DX11_A261SolicitudesNota = new string[] {""} ;
         H00DX11_A262SolicitudesNotificacion = new string[] {""} ;
         H00DX11_A672SolicitudesCalComi = new bool[] {false} ;
         H00DX11_A600SolicitudesSubTipo = new string[] {""} ;
         H00DX11_n600SolicitudesSubTipo = new bool[] {false} ;
         H00DX11_A131EstadosSolId = new int[1] ;
         H00DX11_A40001InventarioImagen_GXI = new string[] {""} ;
         H00DX11_A135InventarioId = new long[1] ;
         H00DX11_A137MedidasID = new long[1] ;
         H00DX11_A40002RubrosImagen_GXI = new string[] {""} ;
         H00DX11_A121RubrosId = new short[1] ;
         H00DX11_A134SolicitudesItemsID = new short[1] ;
         H00DX11_A523SolicitudesItemsComiALM = new decimal[1] ;
         H00DX11_n523SolicitudesItemsComiALM = new bool[] {false} ;
         H00DX11_A521SolicitudesItemsComiProv = new decimal[1] ;
         H00DX11_n521SolicitudesItemsComiProv = new bool[] {false} ;
         H00DX11_A526SolicitudesItemsComiALMP = new decimal[1] ;
         H00DX11_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         H00DX11_A524SolicitudesItemsComiProvP = new decimal[1] ;
         H00DX11_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         H00DX11_A532SolicitudServicioComALMP = new decimal[1] ;
         H00DX11_n532SolicitudServicioComALMP = new bool[] {false} ;
         H00DX11_A528SolicitudServicioComProvP = new decimal[1] ;
         H00DX11_n528SolicitudServicioComProvP = new bool[] {false} ;
         H00DX11_A527SolicitudServicioComProv = new decimal[1] ;
         H00DX11_n527SolicitudServicioComProv = new bool[] {false} ;
         H00DX11_A530SolicitudServicioComALM = new decimal[1] ;
         H00DX11_n530SolicitudServicioComALM = new bool[] {false} ;
         H00DX11_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00DX11_A212SolicitudesCotizacion = new decimal[1] ;
         H00DX11_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00DX11_A897SolicitudesDescuento = new decimal[1] ;
         H00DX11_n897SolicitudesDescuento = new bool[] {false} ;
         H00DX11_A864SolicitudesCostoXZona = new decimal[1] ;
         H00DX11_A180SolicitudItemsComision = new decimal[1] ;
         H00DX11_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00DX11_A178SolicitudItemsSR = new string[] {""} ;
         H00DX11_A177SolicitudesItemsCantidad = new short[1] ;
         H00DX11_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00DX11_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         H00DX11_A189InventarioImagen = new string[] {""} ;
         H00DX11_A168RubrosImagen = new string[] {""} ;
         H00DX12_A116PaisID = new string[] {""} ;
         A116PaisID = "";
         H00DX13_A40002RubrosImagen_GXI = new string[] {""} ;
         H00DX13_A168RubrosImagen = new string[] {""} ;
         H00DX14_A121RubrosId = new short[1] ;
         H00DX15_A40001InventarioImagen_GXI = new string[] {""} ;
         H00DX15_A189InventarioImagen = new string[] {""} ;
         H00DX16_A669STMonedasId = new short[1] ;
         H00DX16_n669STMonedasId = new bool[] {false} ;
         H00DX16_A133ProveedorID = new long[1] ;
         H00DX16_A171SolicitudesNombre = new string[] {""} ;
         H00DX16_A172SolicitudesTelefono = new string[] {""} ;
         H00DX16_A206SolicitudesMail = new string[] {""} ;
         H00DX16_n206SolicitudesMail = new bool[] {false} ;
         H00DX16_A533ProveedorNombreAux = new string[] {""} ;
         H00DX16_n533ProveedorNombreAux = new bool[] {false} ;
         H00DX16_A112DepartamentoId = new long[1] ;
         H00DX16_n112DepartamentoId = new bool[] {false} ;
         H00DX16_A114DepartamentoMunicipioId = new long[1] ;
         H00DX16_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00DX16_A110ZonasID = new long[1] ;
         H00DX16_n110ZonasID = new bool[] {false} ;
         H00DX16_A173SolicitudesDireccion = new string[] {""} ;
         H00DX16_A201SolicitudesOtros1 = new string[] {""} ;
         H00DX16_A202SolicitudesOtros2 = new string[] {""} ;
         H00DX16_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00DX16_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H00DX16_A210SolicitudServicioSolCoti = new string[] {""} ;
         H00DX16_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00DX16_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00DX16_A128MetodoPagosID = new long[1] ;
         H00DX16_A441SolicitudesPagado = new string[] {""} ;
         H00DX16_n441SolicitudesPagado = new bool[] {false} ;
         H00DX16_A203SolicitudesOtros3 = new string[] {""} ;
         H00DX16_A205SolicitudesComentario = new string[] {""} ;
         H00DX16_A261SolicitudesNota = new string[] {""} ;
         H00DX16_A262SolicitudesNotificacion = new string[] {""} ;
         H00DX16_A672SolicitudesCalComi = new bool[] {false} ;
         H00DX16_A600SolicitudesSubTipo = new string[] {""} ;
         H00DX16_n600SolicitudesSubTipo = new bool[] {false} ;
         H00DX16_A131EstadosSolId = new int[1] ;
         H00DX16_A532SolicitudServicioComALMP = new decimal[1] ;
         H00DX16_n532SolicitudServicioComALMP = new bool[] {false} ;
         H00DX16_A528SolicitudServicioComProvP = new decimal[1] ;
         H00DX16_n528SolicitudServicioComProvP = new bool[] {false} ;
         H00DX16_A527SolicitudServicioComProv = new decimal[1] ;
         H00DX16_n527SolicitudServicioComProv = new bool[] {false} ;
         H00DX16_A530SolicitudServicioComALM = new decimal[1] ;
         H00DX16_n530SolicitudServicioComALM = new bool[] {false} ;
         H00DX16_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00DX16_A212SolicitudesCotizacion = new decimal[1] ;
         H00DX16_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00DX16_A897SolicitudesDescuento = new decimal[1] ;
         H00DX16_n897SolicitudesDescuento = new bool[] {false} ;
         H00DX16_A864SolicitudesCostoXZona = new decimal[1] ;
         H00DX17_A116PaisID = new string[] {""} ;
         H00DX18_A282ProveedorNombre = new string[] {""} ;
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         H00DX19_A119MonedaISOSimbolo = new string[] {""} ;
         H00DX20_A118MonedaId = new short[1] ;
         Z119MonedaISOSimbolo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercios.versolicitudes__default(),
            new Object[][] {
                new Object[] {
               H00DX2_A127SolicitudesID, H00DX2_A134SolicitudesItemsID, H00DX2_A180SolicitudItemsComision, H00DX2_A179SolicitudItemsComisionTipo, H00DX2_A178SolicitudItemsSR, H00DX2_A177SolicitudesItemsCantidad, H00DX2_A176SolicitudesItemsPrecioFinal, H00DX2_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H00DX3_A112DepartamentoId, H00DX3_A113DepartamentoDepartamento
               }
               , new Object[] {
               H00DX4_A112DepartamentoId, H00DX4_A114DepartamentoMunicipioId, H00DX4_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               H00DX5_A112DepartamentoId, H00DX5_A114DepartamentoMunicipioId, H00DX5_A110ZonasID, H00DX5_A111ZonasNombre
               }
               , new Object[] {
               H00DX6_A121RubrosId, H00DX6_A122RubrosNombre, H00DX6_A123RubrosEstado, H00DX6_n123RubrosEstado
               }
               , new Object[] {
               H00DX7_A121RubrosId, H00DX7_A137MedidasID, H00DX7_A138MedidasNombre, H00DX7_A139MedidasEstado, H00DX7_n139MedidasEstado
               }
               , new Object[] {
               H00DX8_A121RubrosId, H00DX8_A137MedidasID, H00DX8_A135InventarioId, H00DX8_A136InventarioNombre, H00DX8_A107EstadosTipo, H00DX8_A108EstadosGenericosId
               }
               , new Object[] {
               H00DX9_A128MetodoPagosID, H00DX9_A129MetodoPagosNombre, H00DX9_A108EstadosGenericosId
               }
               , new Object[] {
               H00DX10_A116PaisID, H00DX10_A669STMonedasId, H00DX10_n669STMonedasId, H00DX10_A133ProveedorID, H00DX10_A127SolicitudesID, H00DX10_A171SolicitudesNombre, H00DX10_A172SolicitudesTelefono, H00DX10_A206SolicitudesMail, H00DX10_n206SolicitudesMail, H00DX10_A282ProveedorNombre,
               H00DX10_A533ProveedorNombreAux, H00DX10_n533ProveedorNombreAux, H00DX10_A112DepartamentoId, H00DX10_n112DepartamentoId, H00DX10_A114DepartamentoMunicipioId, H00DX10_n114DepartamentoMunicipioId, H00DX10_A110ZonasID, H00DX10_n110ZonasID, H00DX10_A173SolicitudesDireccion, H00DX10_A201SolicitudesOtros1,
               H00DX10_A202SolicitudesOtros2, H00DX10_A184SolicitudesFechaInstalacion, H00DX10_A183SolicitudesHoraInstalacion, H00DX10_A210SolicitudServicioSolCoti, H00DX10_A438SolicitudServicioOrigenPago, H00DX10_n438SolicitudServicioOrigenPago, H00DX10_A128MetodoPagosID, H00DX10_A441SolicitudesPagado, H00DX10_n441SolicitudesPagado, H00DX10_A203SolicitudesOtros3,
               H00DX10_A205SolicitudesComentario, H00DX10_A261SolicitudesNota, H00DX10_A262SolicitudesNotificacion, H00DX10_A672SolicitudesCalComi, H00DX10_A600SolicitudesSubTipo, H00DX10_n600SolicitudesSubTipo, H00DX10_A131EstadosSolId, H00DX10_A40001InventarioImagen_GXI, H00DX10_A135InventarioId, H00DX10_A137MedidasID,
               H00DX10_A40002RubrosImagen_GXI, H00DX10_A121RubrosId, H00DX10_A134SolicitudesItemsID, H00DX10_A523SolicitudesItemsComiALM, H00DX10_n523SolicitudesItemsComiALM, H00DX10_A521SolicitudesItemsComiProv, H00DX10_n521SolicitudesItemsComiProv, H00DX10_A526SolicitudesItemsComiALMP, H00DX10_n526SolicitudesItemsComiALMP, H00DX10_A524SolicitudesItemsComiProvP,
               H00DX10_n524SolicitudesItemsComiProvP, H00DX10_A532SolicitudServicioComALMP, H00DX10_n532SolicitudServicioComALMP, H00DX10_A528SolicitudServicioComProvP, H00DX10_n528SolicitudServicioComProvP, H00DX10_A527SolicitudServicioComProv, H00DX10_n527SolicitudServicioComProv, H00DX10_A530SolicitudServicioComALM, H00DX10_n530SolicitudServicioComALM, H00DX10_A796SolicitudesComisionMetodoPago,
               H00DX10_A212SolicitudesCotizacion, H00DX10_A1016SolicitudesDescuentoCupon, H00DX10_A897SolicitudesDescuento, H00DX10_n897SolicitudesDescuento, H00DX10_A864SolicitudesCostoXZona, H00DX10_A180SolicitudItemsComision, H00DX10_A179SolicitudItemsComisionTipo, H00DX10_A178SolicitudItemsSR, H00DX10_A177SolicitudesItemsCantidad, H00DX10_A176SolicitudesItemsPrecioFinal,
               H00DX10_n176SolicitudesItemsPrecioFinal, H00DX10_A189InventarioImagen, H00DX10_A168RubrosImagen
               }
               , new Object[] {
               H00DX11_A116PaisID, H00DX11_A669STMonedasId, H00DX11_n669STMonedasId, H00DX11_A133ProveedorID, H00DX11_A127SolicitudesID, H00DX11_A171SolicitudesNombre, H00DX11_A172SolicitudesTelefono, H00DX11_A206SolicitudesMail, H00DX11_n206SolicitudesMail, H00DX11_A282ProveedorNombre,
               H00DX11_A533ProveedorNombreAux, H00DX11_n533ProveedorNombreAux, H00DX11_A112DepartamentoId, H00DX11_n112DepartamentoId, H00DX11_A114DepartamentoMunicipioId, H00DX11_n114DepartamentoMunicipioId, H00DX11_A110ZonasID, H00DX11_n110ZonasID, H00DX11_A173SolicitudesDireccion, H00DX11_A201SolicitudesOtros1,
               H00DX11_A202SolicitudesOtros2, H00DX11_A184SolicitudesFechaInstalacion, H00DX11_A183SolicitudesHoraInstalacion, H00DX11_A210SolicitudServicioSolCoti, H00DX11_A438SolicitudServicioOrigenPago, H00DX11_n438SolicitudServicioOrigenPago, H00DX11_A128MetodoPagosID, H00DX11_A441SolicitudesPagado, H00DX11_n441SolicitudesPagado, H00DX11_A203SolicitudesOtros3,
               H00DX11_A205SolicitudesComentario, H00DX11_A261SolicitudesNota, H00DX11_A262SolicitudesNotificacion, H00DX11_A672SolicitudesCalComi, H00DX11_A600SolicitudesSubTipo, H00DX11_n600SolicitudesSubTipo, H00DX11_A131EstadosSolId, H00DX11_A40001InventarioImagen_GXI, H00DX11_A135InventarioId, H00DX11_A137MedidasID,
               H00DX11_A40002RubrosImagen_GXI, H00DX11_A121RubrosId, H00DX11_A134SolicitudesItemsID, H00DX11_A523SolicitudesItemsComiALM, H00DX11_n523SolicitudesItemsComiALM, H00DX11_A521SolicitudesItemsComiProv, H00DX11_n521SolicitudesItemsComiProv, H00DX11_A526SolicitudesItemsComiALMP, H00DX11_n526SolicitudesItemsComiALMP, H00DX11_A524SolicitudesItemsComiProvP,
               H00DX11_n524SolicitudesItemsComiProvP, H00DX11_A532SolicitudServicioComALMP, H00DX11_n532SolicitudServicioComALMP, H00DX11_A528SolicitudServicioComProvP, H00DX11_n528SolicitudServicioComProvP, H00DX11_A527SolicitudServicioComProv, H00DX11_n527SolicitudServicioComProv, H00DX11_A530SolicitudServicioComALM, H00DX11_n530SolicitudServicioComALM, H00DX11_A796SolicitudesComisionMetodoPago,
               H00DX11_A212SolicitudesCotizacion, H00DX11_A1016SolicitudesDescuentoCupon, H00DX11_A897SolicitudesDescuento, H00DX11_n897SolicitudesDescuento, H00DX11_A864SolicitudesCostoXZona, H00DX11_A180SolicitudItemsComision, H00DX11_A179SolicitudItemsComisionTipo, H00DX11_A178SolicitudItemsSR, H00DX11_A177SolicitudesItemsCantidad, H00DX11_A176SolicitudesItemsPrecioFinal,
               H00DX11_n176SolicitudesItemsPrecioFinal, H00DX11_A189InventarioImagen, H00DX11_A168RubrosImagen
               }
               , new Object[] {
               H00DX12_A116PaisID
               }
               , new Object[] {
               H00DX13_A40002RubrosImagen_GXI, H00DX13_A168RubrosImagen
               }
               , new Object[] {
               H00DX14_A121RubrosId
               }
               , new Object[] {
               H00DX15_A40001InventarioImagen_GXI, H00DX15_A189InventarioImagen
               }
               , new Object[] {
               H00DX16_A669STMonedasId, H00DX16_n669STMonedasId, H00DX16_A133ProveedorID, H00DX16_A171SolicitudesNombre, H00DX16_A172SolicitudesTelefono, H00DX16_A206SolicitudesMail, H00DX16_n206SolicitudesMail, H00DX16_A533ProveedorNombreAux, H00DX16_n533ProveedorNombreAux, H00DX16_A112DepartamentoId,
               H00DX16_n112DepartamentoId, H00DX16_A114DepartamentoMunicipioId, H00DX16_n114DepartamentoMunicipioId, H00DX16_A110ZonasID, H00DX16_n110ZonasID, H00DX16_A173SolicitudesDireccion, H00DX16_A201SolicitudesOtros1, H00DX16_A202SolicitudesOtros2, H00DX16_A184SolicitudesFechaInstalacion, H00DX16_A183SolicitudesHoraInstalacion,
               H00DX16_A210SolicitudServicioSolCoti, H00DX16_A438SolicitudServicioOrigenPago, H00DX16_n438SolicitudServicioOrigenPago, H00DX16_A128MetodoPagosID, H00DX16_A441SolicitudesPagado, H00DX16_n441SolicitudesPagado, H00DX16_A203SolicitudesOtros3, H00DX16_A205SolicitudesComentario, H00DX16_A261SolicitudesNota, H00DX16_A262SolicitudesNotificacion,
               H00DX16_A672SolicitudesCalComi, H00DX16_A600SolicitudesSubTipo, H00DX16_n600SolicitudesSubTipo, H00DX16_A131EstadosSolId, H00DX16_A532SolicitudServicioComALMP, H00DX16_n532SolicitudServicioComALMP, H00DX16_A528SolicitudServicioComProvP, H00DX16_n528SolicitudServicioComProvP, H00DX16_A527SolicitudServicioComProv, H00DX16_n527SolicitudServicioComProv,
               H00DX16_A530SolicitudServicioComALM, H00DX16_n530SolicitudServicioComALM, H00DX16_A796SolicitudesComisionMetodoPago, H00DX16_A212SolicitudesCotizacion, H00DX16_A1016SolicitudesDescuentoCupon, H00DX16_A897SolicitudesDescuento, H00DX16_n897SolicitudesDescuento, H00DX16_A864SolicitudesCostoXZona
               }
               , new Object[] {
               H00DX17_A116PaisID
               }
               , new Object[] {
               H00DX18_A282ProveedorNombre
               }
               , new Object[] {
               H00DX19_A119MonedaISOSimbolo
               }
               , new Object[] {
               H00DX20_A118MonedaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A134SolicitudesItemsID ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private short A118MonedaId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short A669STMonedasId ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_105 ;
      private int subGrid_Rows ;
      private int nGXsfl_105_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Pagecount ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesMail_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorNombreAux_Enabled ;
      private int edtSolicitudesDireccion_Enabled ;
      private int edtSolicitudesOtros2_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtSolicitudesTotal_Enabled ;
      private int edtSolicitudesCotizacion_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtSolicitudServicioComProv_Enabled ;
      private int edtSolicitudServicioComProvP_Enabled ;
      private int edtSolicitudServicioComALM_Enabled ;
      private int edtSolicitudServicioComALMP_Enabled ;
      private int edtSolicitudServicioComPro_Enabled ;
      private int edtSolicitudServicioComProP_Enabled ;
      private int edtSolicitudesOtros3_Enabled ;
      private int edtSolicitudesComentario_Enabled ;
      private int edtSolicitudesNota_Enabled ;
      private int edtavGridcurrentpage_Visible ;
      private int edtSolicitudesCalComi_Visible ;
      private int A131EstadosSolId ;
      private int edtEstadosSolId_Visible ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSolicitudesItemsID_Enabled ;
      private int edtRubrosImagen_Enabled ;
      private int edtInventarioImagen_Enabled ;
      private int edtSolicitudesItemsPrecioFinal_Enabled ;
      private int edtSolicitudesItemsCantidad_Enabled ;
      private int edtSolicitudesItemsPrecioInstalac_Enabled ;
      private int edtSolicitudItemsComision_Enabled ;
      private int edtSolicitudItemsComisionTipo_Enabled ;
      private int edtMonedaId_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int edtSolicitudesItemsComiProv_Enabled ;
      private int edtSolicitudesItemsComiProvP_Enabled ;
      private int edtSolicitudesItemsComiALM_Enabled ;
      private int edtSolicitudesItemsComiALMP_Enabled ;
      private int edtSolicitudesItemsComiProf_Enabled ;
      private int edtSolicitudesItemsComiProfP_Enabled ;
      private int edtSolicitudesCalComi_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int AV15PageToGo ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long A127SolicitudesID ;
      private long wcpOA127SolicitudesID ;
      private long GRID_nFirstRecordOnPage ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long AV17GridPageCount ;
      private long AV16GridCurrentPage ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long A133ProveedorID ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A897SolicitudesDescuento ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A531SolicitudServicioComProP ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal A180SolicitudItemsComision ;
      private decimal A521SolicitudesItemsComiProv ;
      private decimal A524SolicitudesItemsComiProvP ;
      private decimal A523SolicitudesItemsComiALM ;
      private decimal A526SolicitudesItemsComiALMP ;
      private decimal A522SolicitudesItemsComiProf ;
      private decimal A525SolicitudesItemsComiProfP ;
      private string Gridpaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_105_idx="0001" ;
      private string A201SolicitudesOtros1 ;
      private string A210SolicitudServicioSolCoti ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Dvpanel_transactiondetail_data3_Width ;
      private string Dvpanel_transactiondetail_data3_Cls ;
      private string Dvpanel_transactiondetail_data3_Title ;
      private string Dvpanel_transactiondetail_data3_Iconposition ;
      private string Dvpanel_transactiondetail_data4_Width ;
      private string Dvpanel_transactiondetail_data4_Cls ;
      private string Dvpanel_transactiondetail_data4_Title ;
      private string Dvpanel_transactiondetail_data4_Iconposition ;
      private string Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Class ;
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Internalname ;
      private string lblDatosgenerales_title_Internalname ;
      private string lblDatosgenerales_title_Jsonclick ;
      private string divTransactiondetail_tbdata1_Internalname ;
      private string divTransactiondetail_data1_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string TempTags ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtSolicitudesNombre_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string edtSolicitudesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesMail_Internalname ;
      private string edtSolicitudesMail_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorNombreAux_Internalname ;
      private string A533ProveedorNombreAux ;
      private string edtProveedorNombreAux_Jsonclick ;
      private string divTransactiondetail_data2_Internalname ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string dynZonasID_Internalname ;
      private string dynZonasID_Jsonclick ;
      private string edtSolicitudesDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string chkSolicitudesOtros1_Internalname ;
      private string edtSolicitudesOtros2_Internalname ;
      private string A202SolicitudesOtros2 ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string cmbSolicitudesHoraInstalacion_Internalname ;
      private string A183SolicitudesHoraInstalacion ;
      private string cmbSolicitudesHoraInstalacion_Jsonclick ;
      private string lblDatosservicio_title_Internalname ;
      private string lblDatosservicio_title_Jsonclick ;
      private string divTransactiondetail_tbdata2_Internalname ;
      private string divTransactiondetail_tableleaflevel_items_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string Dvpanel_transactiondetail_data3_Internalname ;
      private string divTransactiondetail_data3_Internalname ;
      private string edtSolicitudesTotal_Internalname ;
      private string edtSolicitudesTotal_Jsonclick ;
      private string chkSolicitudServicioSolCoti_Internalname ;
      private string edtSolicitudesCotizacion_Internalname ;
      private string edtSolicitudesCotizacion_Jsonclick ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string divDvpanel_transactiondetail_data4_cell_Internalname ;
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
      private string divTransactiondetail_data5_Internalname ;
      private string cmbSolicitudServicioOrigenPago_Internalname ;
      private string A438SolicitudServicioOrigenPago ;
      private string cmbSolicitudServicioOrigenPago_Jsonclick ;
      private string dynMetodoPagosID_Internalname ;
      private string dynMetodoPagosID_Jsonclick ;
      private string cmbSolicitudesPagado_Internalname ;
      private string A441SolicitudesPagado ;
      private string cmbSolicitudesPagado_Jsonclick ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGridcurrentpage_Internalname ;
      private string edtavGridcurrentpage_Jsonclick ;
      private string edtSolicitudesCalComi_Internalname ;
      private string edtSolicitudesCalComi_Jsonclick ;
      private string cmbSolicitudesSubTipo_Internalname ;
      private string A600SolicitudesSubTipo ;
      private string cmbSolicitudesSubTipo_Jsonclick ;
      private string edtEstadosSolId_Internalname ;
      private string edtEstadosSolId_Jsonclick ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSolicitudesItemsID_Internalname ;
      private string dynRubrosId_Internalname ;
      private string edtRubrosImagen_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string edtInventarioImagen_Internalname ;
      private string edtSolicitudesItemsPrecioFinal_Internalname ;
      private string edtSolicitudesItemsCantidad_Internalname ;
      private string edtSolicitudesItemsPrecioInstalac_Internalname ;
      private string edtSolicitudItemsComision_Internalname ;
      private string cmbSolicitudItemsSR_Internalname ;
      private string A178SolicitudItemsSR ;
      private string A179SolicitudItemsComisionTipo ;
      private string edtSolicitudItemsComisionTipo_Internalname ;
      private string edtMonedaId_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string edtSolicitudesItemsComiProv_Internalname ;
      private string edtSolicitudesItemsComiProvP_Internalname ;
      private string edtSolicitudesItemsComiALM_Internalname ;
      private string edtSolicitudesItemsComiALMP_Internalname ;
      private string edtSolicitudesItemsComiProf_Internalname ;
      private string edtSolicitudesItemsComiProfP_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string A116PaisID ;
      private string sGXsfl_105_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSolicitudesItemsID_Jsonclick ;
      private string GXCCtl ;
      private string dynRubrosId_Jsonclick ;
      private string sImgUrl ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string edtSolicitudesItemsPrecioFinal_Jsonclick ;
      private string edtSolicitudesItemsCantidad_Jsonclick ;
      private string edtSolicitudesItemsPrecioInstalac_Jsonclick ;
      private string edtSolicitudItemsComision_Jsonclick ;
      private string cmbSolicitudItemsSR_Jsonclick ;
      private string edtSolicitudItemsComisionTipo_Jsonclick ;
      private string edtMonedaId_Jsonclick ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string edtSolicitudesItemsComiProv_Jsonclick ;
      private string edtSolicitudesItemsComiProvP_Jsonclick ;
      private string edtSolicitudesItemsComiALM_Jsonclick ;
      private string edtSolicitudesItemsComiALMP_Jsonclick ;
      private string edtSolicitudesItemsComiProf_Jsonclick ;
      private string edtSolicitudesItemsComiProfP_Jsonclick ;
      private string subGrid_Header ;
      private string Z119MonedaISOSimbolo ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
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
      private bool Gxuitabspanel_gxuitabspanel_transactiondetail_tabs1_Historymanagement ;
      private bool Grid_empowerer_Hascategories ;
      private bool wbLoad ;
      private bool A672SolicitudesCalComi ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_105_Refreshing=false ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private bool n521SolicitudesItemsComiProv ;
      private bool n524SolicitudesItemsComiProvP ;
      private bool n523SolicitudesItemsComiALM ;
      private bool n526SolicitudesItemsComiALMP ;
      private bool gxdyncontrolsrefreshing ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n600SolicitudesSubTipo ;
      private bool n669STMonedasId ;
      private bool n206SolicitudesMail ;
      private bool n533ProveedorNombreAux ;
      private bool n532SolicitudServicioComALMP ;
      private bool n528SolicitudServicioComProvP ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A168RubrosImagen_IsBlob ;
      private bool A189InventarioImagen_IsBlob ;
      private string A205SolicitudesComentario ;
      private string AV18GridAppliedFilters ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string A40002RubrosImagen_GXI ;
      private string A40001InventarioImagen_GXI ;
      private string A168RubrosImagen ;
      private string A189InventarioImagen ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGxuitabspanel_gxuitabspanel_transactiondetail_tabs1 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDvpanel_transactiondetail_data3 ;
      private GXUserControl ucDvpanel_transactiondetail_data4 ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_SolicitudesID ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GXCombobox dynZonasID ;
      private GXCheckbox chkSolicitudesOtros1 ;
      private GXCombobox cmbSolicitudesHoraInstalacion ;
      private GXCombobox dynRubrosId ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private GXCombobox cmbSolicitudItemsSR ;
      private GXCheckbox chkSolicitudServicioSolCoti ;
      private GXCombobox cmbSolicitudServicioOrigenPago ;
      private GXCombobox dynMetodoPagosID ;
      private GXCombobox cmbSolicitudesPagado ;
      private GXCombobox cmbSolicitudesNotificacion ;
      private GXCombobox cmbSolicitudesSubTipo ;
      private IDataStoreProvider pr_default ;
      private long[] H00DX2_A127SolicitudesID ;
      private short[] H00DX2_A134SolicitudesItemsID ;
      private decimal[] H00DX2_A180SolicitudItemsComision ;
      private string[] H00DX2_A179SolicitudItemsComisionTipo ;
      private string[] H00DX2_A178SolicitudItemsSR ;
      private short[] H00DX2_A177SolicitudesItemsCantidad ;
      private decimal[] H00DX2_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00DX2_n176SolicitudesItemsPrecioFinal ;
      private long[] H00DX3_A112DepartamentoId ;
      private bool[] H00DX3_n112DepartamentoId ;
      private string[] H00DX3_A113DepartamentoDepartamento ;
      private long[] H00DX4_A112DepartamentoId ;
      private bool[] H00DX4_n112DepartamentoId ;
      private long[] H00DX4_A114DepartamentoMunicipioId ;
      private bool[] H00DX4_n114DepartamentoMunicipioId ;
      private string[] H00DX4_A115DepartamentoMunicipioNombre ;
      private long[] H00DX5_A112DepartamentoId ;
      private bool[] H00DX5_n112DepartamentoId ;
      private long[] H00DX5_A114DepartamentoMunicipioId ;
      private bool[] H00DX5_n114DepartamentoMunicipioId ;
      private long[] H00DX5_A110ZonasID ;
      private bool[] H00DX5_n110ZonasID ;
      private string[] H00DX5_A111ZonasNombre ;
      private short[] H00DX6_A121RubrosId ;
      private string[] H00DX6_A122RubrosNombre ;
      private string[] H00DX6_A123RubrosEstado ;
      private bool[] H00DX6_n123RubrosEstado ;
      private short[] H00DX7_A121RubrosId ;
      private long[] H00DX7_A137MedidasID ;
      private string[] H00DX7_A138MedidasNombre ;
      private string[] H00DX7_A139MedidasEstado ;
      private bool[] H00DX7_n139MedidasEstado ;
      private short[] H00DX8_A121RubrosId ;
      private long[] H00DX8_A137MedidasID ;
      private long[] H00DX8_A135InventarioId ;
      private string[] H00DX8_A136InventarioNombre ;
      private string[] H00DX8_A107EstadosTipo ;
      private int[] H00DX8_A108EstadosGenericosId ;
      private long[] H00DX9_A128MetodoPagosID ;
      private string[] H00DX9_A129MetodoPagosNombre ;
      private int[] H00DX9_A108EstadosGenericosId ;
      private string[] H00DX10_A116PaisID ;
      private short[] H00DX10_A669STMonedasId ;
      private bool[] H00DX10_n669STMonedasId ;
      private long[] H00DX10_A133ProveedorID ;
      private long[] H00DX10_A127SolicitudesID ;
      private string[] H00DX10_A171SolicitudesNombre ;
      private string[] H00DX10_A172SolicitudesTelefono ;
      private string[] H00DX10_A206SolicitudesMail ;
      private bool[] H00DX10_n206SolicitudesMail ;
      private string[] H00DX10_A282ProveedorNombre ;
      private string[] H00DX10_A533ProveedorNombreAux ;
      private bool[] H00DX10_n533ProveedorNombreAux ;
      private long[] H00DX10_A112DepartamentoId ;
      private bool[] H00DX10_n112DepartamentoId ;
      private long[] H00DX10_A114DepartamentoMunicipioId ;
      private bool[] H00DX10_n114DepartamentoMunicipioId ;
      private long[] H00DX10_A110ZonasID ;
      private bool[] H00DX10_n110ZonasID ;
      private string[] H00DX10_A173SolicitudesDireccion ;
      private string[] H00DX10_A201SolicitudesOtros1 ;
      private string[] H00DX10_A202SolicitudesOtros2 ;
      private DateTime[] H00DX10_A184SolicitudesFechaInstalacion ;
      private string[] H00DX10_A183SolicitudesHoraInstalacion ;
      private string[] H00DX10_A210SolicitudServicioSolCoti ;
      private string[] H00DX10_A438SolicitudServicioOrigenPago ;
      private bool[] H00DX10_n438SolicitudServicioOrigenPago ;
      private long[] H00DX10_A128MetodoPagosID ;
      private string[] H00DX10_A441SolicitudesPagado ;
      private bool[] H00DX10_n441SolicitudesPagado ;
      private string[] H00DX10_A203SolicitudesOtros3 ;
      private string[] H00DX10_A205SolicitudesComentario ;
      private string[] H00DX10_A261SolicitudesNota ;
      private string[] H00DX10_A262SolicitudesNotificacion ;
      private bool[] H00DX10_A672SolicitudesCalComi ;
      private string[] H00DX10_A600SolicitudesSubTipo ;
      private bool[] H00DX10_n600SolicitudesSubTipo ;
      private int[] H00DX10_A131EstadosSolId ;
      private string[] H00DX10_A40001InventarioImagen_GXI ;
      private long[] H00DX10_A135InventarioId ;
      private long[] H00DX10_A137MedidasID ;
      private string[] H00DX10_A40002RubrosImagen_GXI ;
      private short[] H00DX10_A121RubrosId ;
      private short[] H00DX10_A134SolicitudesItemsID ;
      private decimal[] H00DX10_A523SolicitudesItemsComiALM ;
      private bool[] H00DX10_n523SolicitudesItemsComiALM ;
      private decimal[] H00DX10_A521SolicitudesItemsComiProv ;
      private bool[] H00DX10_n521SolicitudesItemsComiProv ;
      private decimal[] H00DX10_A526SolicitudesItemsComiALMP ;
      private bool[] H00DX10_n526SolicitudesItemsComiALMP ;
      private decimal[] H00DX10_A524SolicitudesItemsComiProvP ;
      private bool[] H00DX10_n524SolicitudesItemsComiProvP ;
      private decimal[] H00DX10_A532SolicitudServicioComALMP ;
      private bool[] H00DX10_n532SolicitudServicioComALMP ;
      private decimal[] H00DX10_A528SolicitudServicioComProvP ;
      private bool[] H00DX10_n528SolicitudServicioComProvP ;
      private decimal[] H00DX10_A527SolicitudServicioComProv ;
      private bool[] H00DX10_n527SolicitudServicioComProv ;
      private decimal[] H00DX10_A530SolicitudServicioComALM ;
      private bool[] H00DX10_n530SolicitudServicioComALM ;
      private decimal[] H00DX10_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00DX10_A212SolicitudesCotizacion ;
      private decimal[] H00DX10_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00DX10_A897SolicitudesDescuento ;
      private bool[] H00DX10_n897SolicitudesDescuento ;
      private decimal[] H00DX10_A864SolicitudesCostoXZona ;
      private decimal[] H00DX10_A180SolicitudItemsComision ;
      private string[] H00DX10_A179SolicitudItemsComisionTipo ;
      private string[] H00DX10_A178SolicitudItemsSR ;
      private short[] H00DX10_A177SolicitudesItemsCantidad ;
      private decimal[] H00DX10_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00DX10_n176SolicitudesItemsPrecioFinal ;
      private string[] H00DX10_A189InventarioImagen ;
      private string[] H00DX10_A168RubrosImagen ;
      private string[] H00DX11_A116PaisID ;
      private short[] H00DX11_A669STMonedasId ;
      private bool[] H00DX11_n669STMonedasId ;
      private long[] H00DX11_A133ProveedorID ;
      private long[] H00DX11_A127SolicitudesID ;
      private string[] H00DX11_A171SolicitudesNombre ;
      private string[] H00DX11_A172SolicitudesTelefono ;
      private string[] H00DX11_A206SolicitudesMail ;
      private bool[] H00DX11_n206SolicitudesMail ;
      private string[] H00DX11_A282ProveedorNombre ;
      private string[] H00DX11_A533ProveedorNombreAux ;
      private bool[] H00DX11_n533ProveedorNombreAux ;
      private long[] H00DX11_A112DepartamentoId ;
      private bool[] H00DX11_n112DepartamentoId ;
      private long[] H00DX11_A114DepartamentoMunicipioId ;
      private bool[] H00DX11_n114DepartamentoMunicipioId ;
      private long[] H00DX11_A110ZonasID ;
      private bool[] H00DX11_n110ZonasID ;
      private string[] H00DX11_A173SolicitudesDireccion ;
      private string[] H00DX11_A201SolicitudesOtros1 ;
      private string[] H00DX11_A202SolicitudesOtros2 ;
      private DateTime[] H00DX11_A184SolicitudesFechaInstalacion ;
      private string[] H00DX11_A183SolicitudesHoraInstalacion ;
      private string[] H00DX11_A210SolicitudServicioSolCoti ;
      private string[] H00DX11_A438SolicitudServicioOrigenPago ;
      private bool[] H00DX11_n438SolicitudServicioOrigenPago ;
      private long[] H00DX11_A128MetodoPagosID ;
      private string[] H00DX11_A441SolicitudesPagado ;
      private bool[] H00DX11_n441SolicitudesPagado ;
      private string[] H00DX11_A203SolicitudesOtros3 ;
      private string[] H00DX11_A205SolicitudesComentario ;
      private string[] H00DX11_A261SolicitudesNota ;
      private string[] H00DX11_A262SolicitudesNotificacion ;
      private bool[] H00DX11_A672SolicitudesCalComi ;
      private string[] H00DX11_A600SolicitudesSubTipo ;
      private bool[] H00DX11_n600SolicitudesSubTipo ;
      private int[] H00DX11_A131EstadosSolId ;
      private string[] H00DX11_A40001InventarioImagen_GXI ;
      private long[] H00DX11_A135InventarioId ;
      private long[] H00DX11_A137MedidasID ;
      private string[] H00DX11_A40002RubrosImagen_GXI ;
      private short[] H00DX11_A121RubrosId ;
      private short[] H00DX11_A134SolicitudesItemsID ;
      private decimal[] H00DX11_A523SolicitudesItemsComiALM ;
      private bool[] H00DX11_n523SolicitudesItemsComiALM ;
      private decimal[] H00DX11_A521SolicitudesItemsComiProv ;
      private bool[] H00DX11_n521SolicitudesItemsComiProv ;
      private decimal[] H00DX11_A526SolicitudesItemsComiALMP ;
      private bool[] H00DX11_n526SolicitudesItemsComiALMP ;
      private decimal[] H00DX11_A524SolicitudesItemsComiProvP ;
      private bool[] H00DX11_n524SolicitudesItemsComiProvP ;
      private decimal[] H00DX11_A532SolicitudServicioComALMP ;
      private bool[] H00DX11_n532SolicitudServicioComALMP ;
      private decimal[] H00DX11_A528SolicitudServicioComProvP ;
      private bool[] H00DX11_n528SolicitudServicioComProvP ;
      private decimal[] H00DX11_A527SolicitudServicioComProv ;
      private bool[] H00DX11_n527SolicitudServicioComProv ;
      private decimal[] H00DX11_A530SolicitudServicioComALM ;
      private bool[] H00DX11_n530SolicitudServicioComALM ;
      private decimal[] H00DX11_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00DX11_A212SolicitudesCotizacion ;
      private decimal[] H00DX11_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00DX11_A897SolicitudesDescuento ;
      private bool[] H00DX11_n897SolicitudesDescuento ;
      private decimal[] H00DX11_A864SolicitudesCostoXZona ;
      private decimal[] H00DX11_A180SolicitudItemsComision ;
      private string[] H00DX11_A179SolicitudItemsComisionTipo ;
      private string[] H00DX11_A178SolicitudItemsSR ;
      private short[] H00DX11_A177SolicitudesItemsCantidad ;
      private decimal[] H00DX11_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00DX11_n176SolicitudesItemsPrecioFinal ;
      private string[] H00DX11_A189InventarioImagen ;
      private string[] H00DX11_A168RubrosImagen ;
      private string[] H00DX12_A116PaisID ;
      private string[] H00DX13_A40002RubrosImagen_GXI ;
      private string[] H00DX13_A168RubrosImagen ;
      private short[] H00DX14_A121RubrosId ;
      private string[] H00DX15_A40001InventarioImagen_GXI ;
      private string[] H00DX15_A189InventarioImagen ;
      private short[] H00DX16_A669STMonedasId ;
      private bool[] H00DX16_n669STMonedasId ;
      private long[] H00DX16_A133ProveedorID ;
      private string[] H00DX16_A171SolicitudesNombre ;
      private string[] H00DX16_A172SolicitudesTelefono ;
      private string[] H00DX16_A206SolicitudesMail ;
      private bool[] H00DX16_n206SolicitudesMail ;
      private string[] H00DX16_A533ProveedorNombreAux ;
      private bool[] H00DX16_n533ProveedorNombreAux ;
      private long[] H00DX16_A112DepartamentoId ;
      private bool[] H00DX16_n112DepartamentoId ;
      private long[] H00DX16_A114DepartamentoMunicipioId ;
      private bool[] H00DX16_n114DepartamentoMunicipioId ;
      private long[] H00DX16_A110ZonasID ;
      private bool[] H00DX16_n110ZonasID ;
      private string[] H00DX16_A173SolicitudesDireccion ;
      private string[] H00DX16_A201SolicitudesOtros1 ;
      private string[] H00DX16_A202SolicitudesOtros2 ;
      private DateTime[] H00DX16_A184SolicitudesFechaInstalacion ;
      private string[] H00DX16_A183SolicitudesHoraInstalacion ;
      private string[] H00DX16_A210SolicitudServicioSolCoti ;
      private string[] H00DX16_A438SolicitudServicioOrigenPago ;
      private bool[] H00DX16_n438SolicitudServicioOrigenPago ;
      private long[] H00DX16_A128MetodoPagosID ;
      private string[] H00DX16_A441SolicitudesPagado ;
      private bool[] H00DX16_n441SolicitudesPagado ;
      private string[] H00DX16_A203SolicitudesOtros3 ;
      private string[] H00DX16_A205SolicitudesComentario ;
      private string[] H00DX16_A261SolicitudesNota ;
      private string[] H00DX16_A262SolicitudesNotificacion ;
      private bool[] H00DX16_A672SolicitudesCalComi ;
      private string[] H00DX16_A600SolicitudesSubTipo ;
      private bool[] H00DX16_n600SolicitudesSubTipo ;
      private int[] H00DX16_A131EstadosSolId ;
      private decimal[] H00DX16_A532SolicitudServicioComALMP ;
      private bool[] H00DX16_n532SolicitudServicioComALMP ;
      private decimal[] H00DX16_A528SolicitudServicioComProvP ;
      private bool[] H00DX16_n528SolicitudServicioComProvP ;
      private decimal[] H00DX16_A527SolicitudServicioComProv ;
      private bool[] H00DX16_n527SolicitudServicioComProv ;
      private decimal[] H00DX16_A530SolicitudServicioComALM ;
      private bool[] H00DX16_n530SolicitudServicioComALM ;
      private decimal[] H00DX16_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00DX16_A212SolicitudesCotizacion ;
      private decimal[] H00DX16_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00DX16_A897SolicitudesDescuento ;
      private bool[] H00DX16_n897SolicitudesDescuento ;
      private decimal[] H00DX16_A864SolicitudesCostoXZona ;
      private string[] H00DX17_A116PaisID ;
      private string[] H00DX18_A282ProveedorNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] H00DX19_A119MonedaISOSimbolo ;
      private short[] H00DX20_A118MonedaId ;
   }

   public class versolicitudes__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00DX2;
          prmH00DX2 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00DX3;
          prmH00DX3 = new Object[] {
          };
          Object[] prmH00DX4;
          prmH00DX4 = new Object[] {
          };
          Object[] prmH00DX5;
          prmH00DX5 = new Object[] {
          };
          Object[] prmH00DX6;
          prmH00DX6 = new Object[] {
          };
          Object[] prmH00DX7;
          prmH00DX7 = new Object[] {
          };
          Object[] prmH00DX8;
          prmH00DX8 = new Object[] {
          };
          Object[] prmH00DX9;
          prmH00DX9 = new Object[] {
          };
          Object[] prmH00DX10;
          prmH00DX10 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          string cmdBufferH00DX10;
          cmdBufferH00DX10=" SELECT T7.[PaisID], T5.[STMonedasId], T5.[ProveedorID], T1.[SolicitudesID], T5.[SolicitudesNombre], T5.[SolicitudesTelefono], T5.[SolicitudesMail], T6.[ProveedorNombre], T5.[ProveedorNombreAux], T5.[DepartamentoId], T5.[DepartamentoMunicipioId], T5.[ZonasID], T5.[SolicitudesDireccion], T5.[SolicitudesOtros1], T5.[SolicitudesOtros2], T5.[SolicitudesFechaInstalacion], T5.[SolicitudesHoraInstalacion], T5.[SolicitudServicioSolCoti], T5.[SolicitudServicioOrigenPago], T5.[MetodoPagosID], T5.[SolicitudesPagado], T5.[SolicitudesOtros3], T5.[SolicitudesComentario], T5.[SolicitudesNota], T5.[SolicitudesNotificacion], T5.[SolicitudesCalComi], T5.[SolicitudesSubTipo], T5.[EstadosSolId], T4.[InventarioImagen_GXI], T1.[InventarioId], T1.[MedidasID], T2.[RubrosImagen_GXI], T1.[RubrosId], T1.[SolicitudesItemsID], T1.[SolicitudesItemsComiALM], T1.[SolicitudesItemsComiProv], T1.[SolicitudesItemsComiALMP], T1.[SolicitudesItemsComiProvP], T5.[SolicitudServicioComALMP], T5.[SolicitudServicioComProvP], T5.[SolicitudServicioComProv], T5.[SolicitudServicioComALM], T5.[SolicitudesComisionMetodoPago], T5.[SolicitudesCotizacion], T5.[SolicitudesDescuentoCupon], T5.[SolicitudesDescuento], T5.[SolicitudesCostoXZona], T1.[SolicitudItemsComision], T1.[SolicitudItemsComisionTipo], T1.[SolicitudItemsSR], T1.[SolicitudesItemsCantidad], T1.[SolicitudesItemsPrecioFinal], T4.[InventarioImagen], T2.[RubrosImagen] FROM (((((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) INNER JOIN [Solicitudes] T5 ON T5.[SolicitudesID] = T1.[SolicitudesID]) INNER "
          + " JOIN [Proveedor] T6 ON T6.[ProveedorID] = T5.[ProveedorID]) LEFT JOIN [Departamento] T7 ON T7.[DepartamentoId] = T5.[DepartamentoId]) WHERE T1.[SolicitudesID] = @SolicitudesID ORDER BY T1.[SolicitudesID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY" ;
          Object[] prmH00DX11;
          prmH00DX11 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          string cmdBufferH00DX11;
          cmdBufferH00DX11=" SELECT T7.[PaisID], T5.[STMonedasId], T5.[ProveedorID], T1.[SolicitudesID], T5.[SolicitudesNombre], T5.[SolicitudesTelefono], T5.[SolicitudesMail], T6.[ProveedorNombre], T5.[ProveedorNombreAux], T5.[DepartamentoId], T5.[DepartamentoMunicipioId], T5.[ZonasID], T5.[SolicitudesDireccion], T5.[SolicitudesOtros1], T5.[SolicitudesOtros2], T5.[SolicitudesFechaInstalacion], T5.[SolicitudesHoraInstalacion], T5.[SolicitudServicioSolCoti], T5.[SolicitudServicioOrigenPago], T5.[MetodoPagosID], T5.[SolicitudesPagado], T5.[SolicitudesOtros3], T5.[SolicitudesComentario], T5.[SolicitudesNota], T5.[SolicitudesNotificacion], T5.[SolicitudesCalComi], T5.[SolicitudesSubTipo], T5.[EstadosSolId], T4.[InventarioImagen_GXI], T1.[InventarioId], T1.[MedidasID], T2.[RubrosImagen_GXI], T1.[RubrosId], T1.[SolicitudesItemsID], T1.[SolicitudesItemsComiALM], T1.[SolicitudesItemsComiProv], T1.[SolicitudesItemsComiALMP], T1.[SolicitudesItemsComiProvP], T5.[SolicitudServicioComALMP], T5.[SolicitudServicioComProvP], T5.[SolicitudServicioComProv], T5.[SolicitudServicioComALM], T5.[SolicitudesComisionMetodoPago], T5.[SolicitudesCotizacion], T5.[SolicitudesDescuentoCupon], T5.[SolicitudesDescuento], T5.[SolicitudesCostoXZona], T1.[SolicitudItemsComision], T1.[SolicitudItemsComisionTipo], T1.[SolicitudItemsSR], T1.[SolicitudesItemsCantidad], T1.[SolicitudesItemsPrecioFinal], T4.[InventarioImagen], T2.[RubrosImagen] FROM (((((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) INNER JOIN [Solicitudes] T5 ON T5.[SolicitudesID] = T1.[SolicitudesID]) INNER "
          + " JOIN [Proveedor] T6 ON T6.[ProveedorID] = T5.[ProveedorID]) LEFT JOIN [Departamento] T7 ON T7.[DepartamentoId] = T5.[DepartamentoId]) WHERE T1.[SolicitudesID] = @SolicitudesID ORDER BY T1.[SolicitudesID]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY" ;
          Object[] prmH00DX12;
          prmH00DX12 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH00DX13;
          prmH00DX13 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0)
          };
          Object[] prmH00DX14;
          prmH00DX14 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@MedidasID",GXType.Decimal,18,0)
          };
          Object[] prmH00DX15;
          prmH00DX15 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@InventarioId",GXType.Decimal,18,0)
          };
          Object[] prmH00DX16;
          prmH00DX16 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00DX17;
          prmH00DX17 = new Object[] {
          new ParDef("@PaisID",GXType.NChar,2,0) ,
          new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmH00DX18;
          prmH00DX18 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmH00DX19;
          prmH00DX19 = new Object[] {
          new ParDef("@MonedaId",GXType.Int16,4,0)
          };
          Object[] prmH00DX20;
          prmH00DX20 = new Object[] {
          new ParDef("@PaisID",GXType.NChar,2,0) ,
          new ParDef("@MonedaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00DX2", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX3", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX4", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoMunicipioId] < 9999 ORDER BY [DepartamentoMunicipioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX5", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [ZonasNombre] FROM [Zonas] WHERE [ZonasID] < 9999 ORDER BY [ZonasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX6", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] <> 'DES' ORDER BY [RubrosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX7", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [MedidasEstado] <> 'DES' ORDER BY [MedidasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX8", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [EstadosGenericosId] = 1 ORDER BY [InventarioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX9", "SELECT [MetodoPagosID], [MetodoPagosNombre], [EstadosGenericosId] FROM [MetodoPagos] WHERE [EstadosGenericosId] = 1 ORDER BY [MetodoPagosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX9,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX10", cmdBufferH00DX10,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX10,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX11", cmdBufferH00DX11,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX11,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX12", "SELECT [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX13", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX14", "SELECT [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX15", "SELECT [InventarioImagen_GXI], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX16", "SELECT [STMonedasId], [ProveedorID], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [ProveedorNombreAux], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [SolicitudesDireccion], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudServicioSolCoti], [SolicitudServicioOrigenPago], [MetodoPagosID], [SolicitudesPagado], [SolicitudesOtros3], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudesCalComi], [SolicitudesSubTipo], [EstadosSolId], [SolicitudServicioComALMP], [SolicitudServicioComProvP], [SolicitudServicioComProv], [SolicitudServicioComALM], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @SolicitudesID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX17", "SELECT [PaisID] FROM [PaisMoneda] WHERE [PaisID] = @PaisID AND [MonedaId] = @STMonedasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX18", "SELECT [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX19", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00DX20", "SELECT [MonedaId] FROM [PaisMoneda] WHERE [PaisID] = @PaisID AND [MonedaId] = @MonedaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DX20,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 80);
                ((string[]) buf[10])[0] = rslt.getString(9, 80);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((long[]) buf[16])[0] = rslt.getLong(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((string[]) buf[19])[0] = rslt.getString(14, 1);
                ((string[]) buf[20])[0] = rslt.getString(15, 1000);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(16);
                ((string[]) buf[22])[0] = rslt.getString(17, 1);
                ((string[]) buf[23])[0] = rslt.getString(18, 1);
                ((string[]) buf[24])[0] = rslt.getString(19, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(19);
                ((long[]) buf[26])[0] = rslt.getLong(20);
                ((string[]) buf[27])[0] = rslt.getString(21, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 500);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(23);
                ((string[]) buf[31])[0] = rslt.getString(24, 500);
                ((string[]) buf[32])[0] = rslt.getString(25, 1);
                ((bool[]) buf[33])[0] = rslt.getBool(26);
                ((string[]) buf[34])[0] = rslt.getString(27, 1);
                ((bool[]) buf[35])[0] = rslt.wasNull(27);
                ((int[]) buf[36])[0] = rslt.getInt(28);
                ((string[]) buf[37])[0] = rslt.getMultimediaUri(29);
                ((long[]) buf[38])[0] = rslt.getLong(30);
                ((long[]) buf[39])[0] = rslt.getLong(31);
                ((string[]) buf[40])[0] = rslt.getMultimediaUri(32);
                ((short[]) buf[41])[0] = rslt.getShort(33);
                ((short[]) buf[42])[0] = rslt.getShort(34);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(35);
                ((bool[]) buf[44])[0] = rslt.wasNull(35);
                ((decimal[]) buf[45])[0] = rslt.getDecimal(36);
                ((bool[]) buf[46])[0] = rslt.wasNull(36);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
                ((bool[]) buf[48])[0] = rslt.wasNull(37);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
                ((bool[]) buf[50])[0] = rslt.wasNull(38);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
                ((bool[]) buf[52])[0] = rslt.wasNull(39);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
                ((bool[]) buf[54])[0] = rslt.wasNull(40);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(41);
                ((bool[]) buf[56])[0] = rslt.wasNull(41);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(42);
                ((bool[]) buf[58])[0] = rslt.wasNull(42);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(43);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(44);
                ((decimal[]) buf[61])[0] = rslt.getDecimal(45);
                ((decimal[]) buf[62])[0] = rslt.getDecimal(46);
                ((bool[]) buf[63])[0] = rslt.wasNull(46);
                ((decimal[]) buf[64])[0] = rslt.getDecimal(47);
                ((decimal[]) buf[65])[0] = rslt.getDecimal(48);
                ((string[]) buf[66])[0] = rslt.getString(49, 1);
                ((string[]) buf[67])[0] = rslt.getString(50, 1);
                ((short[]) buf[68])[0] = rslt.getShort(51);
                ((decimal[]) buf[69])[0] = rslt.getDecimal(52);
                ((bool[]) buf[70])[0] = rslt.wasNull(52);
                ((string[]) buf[71])[0] = rslt.getMultimediaFile(53, rslt.getVarchar(29));
                ((string[]) buf[72])[0] = rslt.getMultimediaFile(54, rslt.getVarchar(32));
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 80);
                ((string[]) buf[10])[0] = rslt.getString(9, 80);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((long[]) buf[16])[0] = rslt.getLong(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((string[]) buf[19])[0] = rslt.getString(14, 1);
                ((string[]) buf[20])[0] = rslt.getString(15, 1000);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(16);
                ((string[]) buf[22])[0] = rslt.getString(17, 1);
                ((string[]) buf[23])[0] = rslt.getString(18, 1);
                ((string[]) buf[24])[0] = rslt.getString(19, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(19);
                ((long[]) buf[26])[0] = rslt.getLong(20);
                ((string[]) buf[27])[0] = rslt.getString(21, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 500);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(23);
                ((string[]) buf[31])[0] = rslt.getString(24, 500);
                ((string[]) buf[32])[0] = rslt.getString(25, 1);
                ((bool[]) buf[33])[0] = rslt.getBool(26);
                ((string[]) buf[34])[0] = rslt.getString(27, 1);
                ((bool[]) buf[35])[0] = rslt.wasNull(27);
                ((int[]) buf[36])[0] = rslt.getInt(28);
                ((string[]) buf[37])[0] = rslt.getMultimediaUri(29);
                ((long[]) buf[38])[0] = rslt.getLong(30);
                ((long[]) buf[39])[0] = rslt.getLong(31);
                ((string[]) buf[40])[0] = rslt.getMultimediaUri(32);
                ((short[]) buf[41])[0] = rslt.getShort(33);
                ((short[]) buf[42])[0] = rslt.getShort(34);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(35);
                ((bool[]) buf[44])[0] = rslt.wasNull(35);
                ((decimal[]) buf[45])[0] = rslt.getDecimal(36);
                ((bool[]) buf[46])[0] = rslt.wasNull(36);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
                ((bool[]) buf[48])[0] = rslt.wasNull(37);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(38);
                ((bool[]) buf[50])[0] = rslt.wasNull(38);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(39);
                ((bool[]) buf[52])[0] = rslt.wasNull(39);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(40);
                ((bool[]) buf[54])[0] = rslt.wasNull(40);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(41);
                ((bool[]) buf[56])[0] = rslt.wasNull(41);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(42);
                ((bool[]) buf[58])[0] = rslt.wasNull(42);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(43);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(44);
                ((decimal[]) buf[61])[0] = rslt.getDecimal(45);
                ((decimal[]) buf[62])[0] = rslt.getDecimal(46);
                ((bool[]) buf[63])[0] = rslt.wasNull(46);
                ((decimal[]) buf[64])[0] = rslt.getDecimal(47);
                ((decimal[]) buf[65])[0] = rslt.getDecimal(48);
                ((string[]) buf[66])[0] = rslt.getString(49, 1);
                ((string[]) buf[67])[0] = rslt.getString(50, 1);
                ((short[]) buf[68])[0] = rslt.getShort(51);
                ((decimal[]) buf[69])[0] = rslt.getDecimal(52);
                ((bool[]) buf[70])[0] = rslt.wasNull(52);
                ((string[]) buf[71])[0] = rslt.getMultimediaFile(53, rslt.getVarchar(29));
                ((string[]) buf[72])[0] = rslt.getMultimediaFile(54, rslt.getVarchar(32));
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 80);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((long[]) buf[11])[0] = rslt.getLong(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((long[]) buf[13])[0] = rslt.getLong(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((string[]) buf[16])[0] = rslt.getString(11, 1);
                ((string[]) buf[17])[0] = rslt.getString(12, 1000);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
                ((string[]) buf[19])[0] = rslt.getString(14, 1);
                ((string[]) buf[20])[0] = rslt.getString(15, 1);
                ((string[]) buf[21])[0] = rslt.getString(16, 1);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((long[]) buf[23])[0] = rslt.getLong(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 500);
                ((string[]) buf[27])[0] = rslt.getLongVarchar(20);
                ((string[]) buf[28])[0] = rslt.getString(21, 500);
                ((string[]) buf[29])[0] = rslt.getString(22, 1);
                ((bool[]) buf[30])[0] = rslt.getBool(23);
                ((string[]) buf[31])[0] = rslt.getString(24, 1);
                ((bool[]) buf[32])[0] = rslt.wasNull(24);
                ((int[]) buf[33])[0] = rslt.getInt(25);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(26);
                ((bool[]) buf[35])[0] = rslt.wasNull(26);
                ((decimal[]) buf[36])[0] = rslt.getDecimal(27);
                ((bool[]) buf[37])[0] = rslt.wasNull(27);
                ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
                ((bool[]) buf[39])[0] = rslt.wasNull(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((bool[]) buf[41])[0] = rslt.wasNull(29);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[45])[0] = rslt.getDecimal(33);
                ((bool[]) buf[46])[0] = rslt.wasNull(33);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(34);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
