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
   public class historicosolicitudesww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public historicosolicitudesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudesww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavEstadosgenericosid = new GXCombobox();
         dynavProveedorid = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbHistoricoSolicitudesPagado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vESTADOSGENERICOSID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvESTADOSGENERICOSID2I2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPROVEEDORID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPROVEEDORID2I2( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         nRC_GXsfl_61 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_61"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_61_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_61_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_61_idx = GetPar( "sGXsfl_61_idx");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV83FechaIni = context.localUtil.ParseDateParm( GetPar( "FechaIni"));
         AV82FechaFin = context.localUtil.ParseDateParm( GetPar( "FechaFin"));
         dynavEstadosgenericosid.FromJSonString( GetNextPar( ));
         AV81EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosID"), "."), 18, MidpointRounding.ToEven));
         dynavProveedorid.FromJSonString( GetNextPar( ));
         AV84ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV46ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41ColumnsSelector);
         AV100Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV95TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesProvID"), "."), 18, MidpointRounding.ToEven));
         AV96TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesProvID_To"), "."), 18, MidpointRounding.ToEven));
         AV97TFHistoricoSolicitudesProvNombre = GetPar( "TFHistoricoSolicitudesProvNombre");
         AV98TFHistoricoSolicitudesProvNombre_Sel = GetPar( "TFHistoricoSolicitudesProvNombre_Sel");
         AV99IsAuthorized_EstadosSolNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosSolNombre"));
         AV90IsAuthorized_HistoricoSolicitudesNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_HistoricoSolicitudesNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor H002I2 */
         pr_default.execute(0, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H002I2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H002I2_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(H002I2_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(H002I2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002I2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])-(H002I2_A298HistoricoSolicitudesItemsComis[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H002I2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002I2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])+(H002I2_A298HistoricoSolicitudesItemsComis[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H002I2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002I2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])-((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])*(H002I2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H002I2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002I2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])+((H002I2_A295HItemsInventarioPrecioFinal[0]*H002I2_A293HItemsSolicitudesItemsCantidad[0])*(H002I2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public override short ExecuteStartEvent( )
      {
         PA2I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2I2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicosolicitudesww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", AV90IsAuthorized_HistoricoSolicitudesNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", GetSecureSignedToken( "", AV90IsAuthorized_HistoricoSolicitudesNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAINI", context.localUtil.Format(AV83FechaIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAFIN", context.localUtil.Format(AV82FechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV81EstadosGenericosID), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_61", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_61), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV71GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV76AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV76AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV67DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV67DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFHISTORICOSOLICITUDESPROVID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFHISTORICOSOLICITUDESPROVID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFHISTORICOSOLICITUDESPROVNOMBRE", StringUtil.RTrim( AV97TFHistoricoSolicitudesProvNombre));
         GxWebStd.gx_hidden_field( context, "vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL", StringUtil.RTrim( AV98TFHistoricoSolicitudesProvNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", AV90IsAuthorized_HistoricoSolicitudesNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", GetSecureSignedToken( "", AV90IsAuthorized_HistoricoSolicitudesNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESTOTAL", StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
            WE2I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2I2( ) ;
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
         return formatLink("historicosolicitudesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "HistoricoSolicitudesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Solicitudes", "") ;
      }

      protected void WB2I0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(61), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_2I2( true) ;
         }
         else
         {
            wb_table1_23_2I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_2I2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl61( ) ;
         }
         if ( wbEnd == 61 )
         {
            wbEnd = 0;
            nRC_GXsfl_61 = (int)(nGXsfl_61_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV69GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV70GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV71GridAppliedFilters);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV76AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV67DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV67DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV41ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0091"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0091"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_61_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0091"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 61 )
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

      protected void START2I2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Historico Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2I0( ) ;
      }

      protected void WS2I2( )
      {
         START2I2( ) ;
         EVT2I2( ) ;
      }

      protected void EVT2I2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E112I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E142I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E152I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E162I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E172I2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_61_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
                              SubsflControlProps_612( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV72GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
                              A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
                              A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
                              A288HistoricoSolicitudesNombre = cgiGet( edtHistoricoSolicitudesNombre_Internalname);
                              A289HistoricoSolicitudesTelefono = cgiGet( edtHistoricoSolicitudesTelefono_Internalname);
                              A290HistoricoSolicitudesMail = cgiGet( edtHistoricoSolicitudesMail_Internalname);
                              n290HistoricoSolicitudesMail = false;
                              A291HistoricoSolicitudesDireccion = cgiGet( edtHistoricoSolicitudesDireccion_Internalname);
                              A299HistoricoSolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A302HistoricoSolicitudServicioPFin = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudServicioPFin_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A306HistoricoSolicitudesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaAlta_Internalname), 0));
                              A439HistoricoSolicitudesOrigenPago = cgiGet( edtHistoricoSolicitudesOrigenPago_Internalname);
                              cmbHistoricoSolicitudesPagado.Name = cmbHistoricoSolicitudesPagado_Internalname;
                              cmbHistoricoSolicitudesPagado.CurrentValue = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
                              A442HistoricoSolicitudesPagado = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
                              A633HistoricoSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesProvID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A634HistoricoSolicitudesProvNombre = cgiGet( edtHistoricoSolicitudesProvNombre_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E202I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fechaini Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAINI"), 0) != AV83FechaIni )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAFIN"), 0) != AV82FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Estadosgenericosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV81EstadosGenericosID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV84ProveedorID )) )
                                       {
                                          Rfr0gs = true;
                                       }
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 91 )
                        {
                           OldWwpaux_wc = cgiGet( "W0091");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0091", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2I2( )
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

      protected void PA2I2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvESTADOSGENERICOSID2I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESTADOSGENERICOSID_data2I2( ) ;
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

      protected void GXVvESTADOSGENERICOSID_html2I2( )
      {
         int gxdynajaxvalue;
         GXDLVvESTADOSGENERICOSID_data2I2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEstadosgenericosid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEstadosgenericosid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvESTADOSGENERICOSID_data2I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Todos", ""));
         /* Using cursor H002I3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            if ( StringUtil.StrCmp(H002I3_A107EstadosTipo[0], context.GetMessage( "SOL", "")) == 0 )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002I3_A108EstadosGenericosId[0]), 5, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( H002I3_A109EstadosGenericosNombre[0]));
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvPROVEEDORID2I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPROVEEDORID_data2I2( ) ;
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

      protected void GXVvPROVEEDORID_html2I2( )
      {
         long gxdynajaxvalue;
         GXDLVvPROVEEDORID_data2I2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProveedorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavProveedorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPROVEEDORID_data2I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Todos", ""));
         /* Using cursor H002I4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002I4_A133ProveedorID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H002I4_A282ProveedorNombre[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_612( ) ;
         while ( nGXsfl_61_idx <= nRC_GXsfl_61 )
         {
            sendrow_612( ) ;
            nGXsfl_61_idx = ((subGrid_Islastpage==1)&&(nGXsfl_61_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_61_idx+1);
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       DateTime AV83FechaIni ,
                                       DateTime AV82FechaFin ,
                                       int AV81EstadosGenericosID ,
                                       long AV84ProveedorID ,
                                       short AV46ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ,
                                       string AV100Pgmname ,
                                       string AV17FilterFullText ,
                                       long AV95TFHistoricoSolicitudesProvID ,
                                       long AV96TFHistoricoSolicitudesProvID_To ,
                                       string AV97TFHistoricoSolicitudesProvNombre ,
                                       string AV98TFHistoricoSolicitudesProvNombre_Sel ,
                                       bool AV99IsAuthorized_EstadosSolNombre ,
                                       bool AV90IsAuthorized_HistoricoSolicitudesNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2I2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICOSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvESTADOSGENERICOSID_html2I2( ) ;
            GXVvPROVEEDORID_html2I2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEstadosgenericosid.ItemCount > 0 )
         {
            AV81EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( dynavEstadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV81EstadosGenericosID), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV81EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV81EstadosGenericosID), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV81EstadosGenericosID), 5, 0));
            AssignProp("", false, dynavEstadosgenericosid_Internalname, "Values", dynavEstadosgenericosid.ToJavascriptSource(), true);
         }
         if ( dynavProveedorid.ItemCount > 0 )
         {
            AV84ProveedorID = (long)(Math.Round(NumberUtil.Val( dynavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV84ProveedorID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV84ProveedorID", StringUtil.LTrimStr( (decimal)(AV84ProveedorID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV84ProveedorID), 18, 0));
            AssignProp("", false, dynavProveedorid_Internalname, "Values", dynavProveedorid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV100Pgmname = "HistoricoSolicitudesWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                              AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                              AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                              AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                              AV81EstadosGenericosID ,
                                              AV84ProveedorID ,
                                              A633HistoricoSolicitudesProvID ,
                                              A634HistoricoSolicitudesProvNombre ,
                                              A131EstadosSolId ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV101Historicosolicitudeswwds_1_filterfulltext ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A289HistoricoSolicitudesTelefono ,
                                              A290HistoricoSolicitudesMail ,
                                              A291HistoricoSolicitudesDireccion ,
                                              A302HistoricoSolicitudServicioPFin ,
                                              A306HistoricoSolicitudesFechaAlta ,
                                              AV83FechaIni ,
                                              AV82FechaFin } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = StringUtil.PadR( StringUtil.RTrim( AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre), 120, "%");
         /* Using cursor H002I5 */
         pr_default.execute(3, new Object[] {AV83FechaIni, AV82FechaFin, AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid, AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to, lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre, AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, AV81EstadosGenericosID, AV84ProveedorID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A634HistoricoSolicitudesProvNombre = H002I5_A634HistoricoSolicitudesProvNombre[0];
            A633HistoricoSolicitudesProvID = H002I5_A633HistoricoSolicitudesProvID[0];
            A442HistoricoSolicitudesPagado = H002I5_A442HistoricoSolicitudesPagado[0];
            A439HistoricoSolicitudesOrigenPago = H002I5_A439HistoricoSolicitudesOrigenPago[0];
            A306HistoricoSolicitudesFechaAlta = H002I5_A306HistoricoSolicitudesFechaAlta[0];
            A291HistoricoSolicitudesDireccion = H002I5_A291HistoricoSolicitudesDireccion[0];
            A290HistoricoSolicitudesMail = H002I5_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = H002I5_n290HistoricoSolicitudesMail[0];
            A289HistoricoSolicitudesTelefono = H002I5_A289HistoricoSolicitudesTelefono[0];
            A288HistoricoSolicitudesNombre = H002I5_A288HistoricoSolicitudesNombre[0];
            A132EstadosSolNombre = H002I5_A132EstadosSolNombre[0];
            A130EstadosSolTipo = H002I5_A130EstadosSolTipo[0];
            A131EstadosSolId = H002I5_A131EstadosSolId[0];
            A153HistoricoSolicitudesID = H002I5_A153HistoricoSolicitudesID[0];
            A299HistoricoSolicitudesCotizacion = H002I5_A299HistoricoSolicitudesCotizacion[0];
            A132EstadosSolNombre = H002I5_A132EstadosSolNombre[0];
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Historicosolicitudeswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A153HistoricoSolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV101Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV101Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A634HistoricoSolicitudesProvNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(3);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(3);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF2I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 61;
         /* Execute user event: Refresh */
         E192I2 ();
         nGXsfl_61_idx = 1;
         sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
         SubsflControlProps_612( ) ;
         bGXsfl_61_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_612( ) ;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                                 AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                                 AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                                 AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                                 AV81EstadosGenericosID ,
                                                 AV84ProveedorID ,
                                                 A633HistoricoSolicitudesProvID ,
                                                 A634HistoricoSolicitudesProvNombre ,
                                                 A131EstadosSolId ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV101Historicosolicitudeswwds_1_filterfulltext ,
                                                 A153HistoricoSolicitudesID ,
                                                 A288HistoricoSolicitudesNombre ,
                                                 A289HistoricoSolicitudesTelefono ,
                                                 A290HistoricoSolicitudesMail ,
                                                 A291HistoricoSolicitudesDireccion ,
                                                 A302HistoricoSolicitudServicioPFin ,
                                                 A306HistoricoSolicitudesFechaAlta ,
                                                 AV83FechaIni ,
                                                 AV82FechaFin } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = StringUtil.PadR( StringUtil.RTrim( AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre), 120, "%");
            /* Using cursor H002I6 */
            pr_default.execute(4, new Object[] {AV83FechaIni, AV82FechaFin, AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid, AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to, lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre, AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, AV81EstadosGenericosID, AV84ProveedorID});
            nGXsfl_61_idx = 1;
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(4) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A634HistoricoSolicitudesProvNombre = H002I6_A634HistoricoSolicitudesProvNombre[0];
               A633HistoricoSolicitudesProvID = H002I6_A633HistoricoSolicitudesProvID[0];
               A442HistoricoSolicitudesPagado = H002I6_A442HistoricoSolicitudesPagado[0];
               A439HistoricoSolicitudesOrigenPago = H002I6_A439HistoricoSolicitudesOrigenPago[0];
               A306HistoricoSolicitudesFechaAlta = H002I6_A306HistoricoSolicitudesFechaAlta[0];
               A291HistoricoSolicitudesDireccion = H002I6_A291HistoricoSolicitudesDireccion[0];
               A290HistoricoSolicitudesMail = H002I6_A290HistoricoSolicitudesMail[0];
               n290HistoricoSolicitudesMail = H002I6_n290HistoricoSolicitudesMail[0];
               A289HistoricoSolicitudesTelefono = H002I6_A289HistoricoSolicitudesTelefono[0];
               A288HistoricoSolicitudesNombre = H002I6_A288HistoricoSolicitudesNombre[0];
               A132EstadosSolNombre = H002I6_A132EstadosSolNombre[0];
               A130EstadosSolTipo = H002I6_A130EstadosSolTipo[0];
               A131EstadosSolId = H002I6_A131EstadosSolId[0];
               A153HistoricoSolicitudesID = H002I6_A153HistoricoSolicitudesID[0];
               A299HistoricoSolicitudesCotizacion = H002I6_A299HistoricoSolicitudesCotizacion[0];
               A132EstadosSolNombre = H002I6_A132EstadosSolNombre[0];
               GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
               if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
               }
               else
               {
                  if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
                  {
                     A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
                  }
                  else
                  {
                     A302HistoricoSolicitudServicioPFin = 0;
                  }
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Historicosolicitudeswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A153HistoricoSolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV101Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV101Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A634HistoricoSolicitudesProvNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV101Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E202I2 ();
               }
               pr_default.readNext(4);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(4) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(4);
            wbEnd = 61;
            WB2I0( ) ;
         }
         bGXsfl_61_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2I2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", AV90IsAuthorized_HistoricoSolicitudesNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", GetSecureSignedToken( "", AV90IsAuthorized_HistoricoSolicitudesNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICOSOLICITUDESID"+"_"+sGXsfl_61_idx, GetSecureSignedToken( sGXsfl_61_idx, context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV83FechaIni, AV82FechaFin, AV81EstadosGenericosID, AV84ProveedorID, AV46ManageFiltersExecutionStep, AV41ColumnsSelector, AV100Pgmname, AV17FilterFullText, AV95TFHistoricoSolicitudesProvID, AV96TFHistoricoSolicitudesProvID_To, AV97TFHistoricoSolicitudesProvNombre, AV98TFHistoricoSolicitudesProvNombre_Sel, AV99IsAuthorized_EstadosSolNombre, AV90IsAuthorized_HistoricoSolicitudesNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV100Pgmname = "HistoricoSolicitudesWW";
         GXVvESTADOSGENERICOSID_html2I2( ) ;
         GXVvPROVEEDORID_html2I2( ) ;
         edtHistoricoSolicitudesID_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtHistoricoSolicitudesNombre_Enabled = 0;
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         edtHistoricoSolicitudesMail_Enabled = 0;
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         edtHistoricoSolicitudesProvID_Enabled = 0;
         edtHistoricoSolicitudesProvNombre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV44ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV76AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV67DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV41ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_61 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_61"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV69GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV71GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
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
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            if ( context.localUtil.VCDate( cgiGet( edtavFechaini_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ini", "")}), 1, "vFECHAINI");
               GX_FocusControl = edtavFechaini_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV83FechaIni = DateTime.MinValue;
               AssignAttri("", false, "AV83FechaIni", context.localUtil.Format(AV83FechaIni, "99/99/99"));
            }
            else
            {
               AV83FechaIni = context.localUtil.CToD( cgiGet( edtavFechaini_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV83FechaIni", context.localUtil.Format(AV83FechaIni, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechafin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Fin", "")}), 1, "vFECHAFIN");
               GX_FocusControl = edtavFechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV82FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV82FechaFin", context.localUtil.Format(AV82FechaFin, "99/99/99"));
            }
            else
            {
               AV82FechaFin = context.localUtil.CToD( cgiGet( edtavFechafin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV82FechaFin", context.localUtil.Format(AV82FechaFin, "99/99/99"));
            }
            dynavEstadosgenericosid.Name = dynavEstadosgenericosid_Internalname;
            dynavEstadosgenericosid.CurrentValue = cgiGet( dynavEstadosgenericosid_Internalname);
            AV81EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavEstadosgenericosid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV81EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV81EstadosGenericosID), 5, 0));
            dynavProveedorid.Name = dynavProveedorid_Internalname;
            dynavProveedorid.CurrentValue = cgiGet( dynavProveedorid_Internalname);
            AV84ProveedorID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavProveedorid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV84ProveedorID", StringUtil.LTrimStr( (decimal)(AV84ProveedorID), 18, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHAINI"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV83FechaIni ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHAFIN"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV82FechaFin ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV81EstadosGenericosID )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV84ProveedorID )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E182I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182I2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "Export";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV99IsAuthorized_EstadosSolNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV99IsAuthorized_EstadosSolNombre = GXt_boolean1;
         AssignAttri("", false, "AV99IsAuthorized_EstadosSolNombre", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV99IsAuthorized_EstadosSolNombre, context));
         GXt_boolean1 = AV90IsAuthorized_HistoricoSolicitudesNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones", out  GXt_boolean1) ;
         AV90IsAuthorized_HistoricoSolicitudesNombre = GXt_boolean1;
         AssignAttri("", false, "AV90IsAuthorized_HistoricoSolicitudesNombre", AV90IsAuthorized_HistoricoSolicitudesNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE", GetSecureSignedToken( "", AV90IsAuthorized_HistoricoSolicitudesNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Historico Solicitudes", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = true;
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV67DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV67DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV81EstadosGenericosID = 6;
         AssignAttri("", false, "AV81EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV81EstadosGenericosID), 5, 0));
         AV82FechaFin = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV82FechaFin", context.localUtil.Format(AV82FechaFin, "99/99/99"));
         AV83FechaIni = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV83FechaIni", context.localUtil.Format(AV83FechaIni, "99/99/99"));
         AV82FechaFin = DateTimeUtil.DAdd(AV82FechaFin,+((int)(15)));
         AssignAttri("", false, "AV82FechaFin", context.localUtil.Format(AV82FechaFin, "99/99/99"));
         AV83FechaIni = DateTimeUtil.DAdd(AV83FechaIni,-((int)(120)));
         AssignAttri("", false, "AV83FechaIni", context.localUtil.Format(AV83FechaIni, "99/99/99"));
      }

      protected void E192I2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV46ManageFiltersExecutionStep == 1 )
         {
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV46ManageFiltersExecutionStep == 2 )
         {
            AV46ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV43Session.Get("HistoricoSolicitudesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV43Session.Get("HistoricoSolicitudesWWColumnsSelector");
            AV41ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtHistoricoSolicitudesID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtEstadosSolNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosSolNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosSolNombre_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNombre_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesTelefono_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesMail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesMail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesMail_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesDireccion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesDireccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesDireccion_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesCotizacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesCotizacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesCotizacion_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudServicioPFin_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudServicioPFin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudServicioPFin_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaAlta_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesOrigenPago_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesOrigenPago_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOrigenPago_Visible), 5, 0), !bGXsfl_61_Refreshing);
         cmbHistoricoSolicitudesPagado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbHistoricoSolicitudesPagado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbHistoricoSolicitudesPagado.Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesProvID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesProvID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesProvID_Visible), 5, 0), !bGXsfl_61_Refreshing);
         edtHistoricoSolicitudesProvNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtHistoricoSolicitudesProvNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesProvNombre_Visible), 5, 0), !bGXsfl_61_Refreshing);
         AV69GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV69GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV69GridCurrentPage), 10, 0));
         AV70GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV70GridPageCount", StringUtil.LTrimStr( (decimal)(AV70GridPageCount), 10, 0));
         GXt_char3 = AV71GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV100Pgmname, out  GXt_char3) ;
         AV71GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV71GridAppliedFilters", AV71GridAppliedFilters);
         AV101Historicosolicitudeswwds_1_filterfulltext = AV17FilterFullText;
         AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E122I2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV68PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV68PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E132I2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E162I2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesProvID") == 0 )
            {
               AV95TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV95TFHistoricoSolicitudesProvID", StringUtil.LTrimStr( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0));
               AV96TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV96TFHistoricoSolicitudesProvID_To", StringUtil.LTrimStr( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesProvNombre") == 0 )
            {
               AV97TFHistoricoSolicitudesProvNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV97TFHistoricoSolicitudesProvNombre", AV97TFHistoricoSolicitudesProvNombre);
               AV98TFHistoricoSolicitudesProvNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV98TFHistoricoSolicitudesProvNombre_Sel", AV98TFHistoricoSolicitudesProvNombre_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E202I2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Relación", ""), "fa fa-link", "", "", "", "", "", "", ""), 0);
            if ( AV99IsAuthorized_EstadosSolNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A130EstadosSolTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A131EstadosSolId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtEstadosSolNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV90IsAuthorized_HistoricoSolicitudesNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "historicorelacionesview.aspx"+UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtHistoricoSolicitudesNombre_Link = formatLink("historicorelacionesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 61;
            }
            sendrow_612( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_61_Refreshing )
         {
            context.DoAjaxLoad(61, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
      }

      protected void E172I2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV39ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV41ColumnsSelector.FromJSonString(AV39ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "HistoricoSolicitudesWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV39ColumnsSelectorXML)) ? "" : AV41ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E112I2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("HistoricoSolicitudesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV100Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("HistoricoSolicitudesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV45ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "HistoricoSolicitudesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV45ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV45ManageFiltersXml) ;
               AV11GridState.FromXml(AV45ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E212I2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV72GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72GridActions == 2 )
         {
            /* Execute user subroutine: 'DO RELACION' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV72GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E142I2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E152I2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0091",(string)"",(string)"HistoricoSolicitudes",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0091"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesID",  "",  "Solicitudes ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "EstadosSolNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesNombre",  "",  "Nombre | Contacto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesTelefono",  "",  "Telefono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesDireccion",  "",  "Direccion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesCotizacion",  "",  "Cotizacion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudServicioPFinal",  "",  "Servicio PFinal",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesOrigenPago",  "",  "Origen Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesPagado",  "",  "Pagado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesProvID",  "",  "Proveedor Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "HistoricoSolicitudesProvNombre",  "",  "Nombre del Comercio",  true,  "") ;
         GXt_char3 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "HistoricoSolicitudesWWColumnsSelector", out  GXt_char3) ;
         AV40UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV42ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV42ColumnsSelectorAux, ref  AV41ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV78TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV78TempBoolean = GXt_boolean1;
         if ( ! ( AV78TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "HistoricoSolicitudes",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV44ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "HistoricoSolicitudesWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV44ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV95TFHistoricoSolicitudesProvID = 0;
         AssignAttri("", false, "AV95TFHistoricoSolicitudesProvID", StringUtil.LTrimStr( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0));
         AV96TFHistoricoSolicitudesProvID_To = 0;
         AssignAttri("", false, "AV96TFHistoricoSolicitudesProvID_To", StringUtil.LTrimStr( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0));
         AV97TFHistoricoSolicitudesProvNombre = "";
         AssignAttri("", false, "AV97TFHistoricoSolicitudesProvNombre", AV97TFHistoricoSolicitudesProvNombre);
         AV98TFHistoricoSolicitudesProvNombre_Sel = "";
         AssignAttri("", false, "AV98TFHistoricoSolicitudesProvNombre_Sel", AV98TFHistoricoSolicitudesProvNombre_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "historicosolicitudes.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0));
         CallWebObject(formatLink("historicosolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO RELACION' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "historicorelaciones.aspx"+UrlEncode(StringUtil.RTrim(context.GetMessage( "DSP", ""))) + "," + UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0));
         CallWebObject(formatLink("historicorelaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get(AV100Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV100Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV43Session.Get(AV100Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV106GXV1 = 1;
         while ( AV106GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV106GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVID") == 0 )
            {
               AV95TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV95TFHistoricoSolicitudesProvID", StringUtil.LTrimStr( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0));
               AV96TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV96TFHistoricoSolicitudesProvID_To", StringUtil.LTrimStr( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE") == 0 )
            {
               AV97TFHistoricoSolicitudesProvNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV97TFHistoricoSolicitudesProvNombre", AV97TFHistoricoSolicitudesProvNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE_SEL") == 0 )
            {
               AV98TFHistoricoSolicitudesProvNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV98TFHistoricoSolicitudesProvNombre_Sel", AV98TFHistoricoSolicitudesProvNombre_Sel);
            }
            AV106GXV1 = (int)(AV106GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV98TFHistoricoSolicitudesProvNombre_Sel)),  AV98TFHistoricoSolicitudesProvNombre_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = "||||||||||||"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV97TFHistoricoSolicitudesProvNombre)),  AV97TFHistoricoSolicitudesProvNombre, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = "|||||||||||"+((0==AV95TFHistoricoSolicitudesProvID) ? "" : StringUtil.Str( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0))+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||||||||"+((0==AV96TFHistoricoSolicitudesProvID_To) ? "" : StringUtil.Str( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV43Session.Get(AV100Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFHISTORICOSOLICITUDESPROVID",  context.GetMessage( "Proveedor Id", ""),  !((0==AV95TFHistoricoSolicitudesProvID)&&(0==AV96TFHistoricoSolicitudesProvID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV95TFHistoricoSolicitudesProvID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV96TFHistoricoSolicitudesProvID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFHISTORICOSOLICITUDESPROVNOMBRE",  context.GetMessage( "Nombre del Comercio", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV97TFHistoricoSolicitudesProvNombre)),  0,  AV97TFHistoricoSolicitudesProvNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV98TFHistoricoSolicitudesProvNombre_Sel)),  AV98TFHistoricoSolicitudesProvNombre_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV100Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "HistoricoSolicitudes";
         AV43Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S222( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new historicosolicitudeswwexport(context ).execute( out  AV37ExcelFilename, out  AV38ErrorMessage) ;
         if ( StringUtil.StrCmp(AV37ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV37ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV38ErrorMessage);
         }
      }

      protected void S232( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("historicosolicitudeswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_23_2I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV44ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_28_2I2( true) ;
         }
         else
         {
            wb_table2_28_2I2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_2I2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechaini_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechaini_Internalname, context.GetMessage( "Rango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_61_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechaini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechaini_Internalname, context.localUtil.Format(AV83FechaIni, "99/99/99"), context.localUtil.Format( AV83FechaIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechaini_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechaini_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_bitmap( context, edtavFechaini_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechaini_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechafin_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_61_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechafin_Internalname, context.localUtil.Format(AV82FechaFin, "99/99/99"), context.localUtil.Format( AV82FechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechafin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_bitmap( context, edtavFechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavEstadosgenericosid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEstadosgenericosid_Internalname, context.GetMessage( "Visualizar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_61_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEstadosgenericosid, dynavEstadosgenericosid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV81EstadosGenericosID), 5, 0)), 1, dynavEstadosgenericosid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEstadosgenericosid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_HistoricoSolicitudesWW.htm");
            dynavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV81EstadosGenericosID), 5, 0));
            AssignProp("", false, dynavEstadosgenericosid_Internalname, "Values", (string)(dynavEstadosgenericosid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavProveedorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProveedorid_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_61_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProveedorid, dynavProveedorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV84ProveedorID), 18, 0)), 1, dynavProveedorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProveedorid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_HistoricoSolicitudesWW.htm");
            dynavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV84ProveedorID), 18, 0));
            AssignProp("", false, dynavProveedorid_Internalname, "Values", (string)(dynavProveedorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_2I2e( true) ;
         }
         else
         {
            wb_table1_23_2I2e( false) ;
         }
      }

      protected void wb_table2_28_2I2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_61_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_HistoricoSolicitudesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_2I2e( true) ;
         }
         else
         {
            wb_table2_28_2I2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2I2( ) ;
         WS2I2( ) ;
         WE2I2( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320131637", true, true, false);
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
         context.AddJavascriptSource("historicosolicitudesww.js", "?20269320131638", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_612( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_61_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_61_idx;
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO_"+sGXsfl_61_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesNombre_Internalname = "HISTORICOSOLICITUDESNOMBRE_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesTelefono_Internalname = "HISTORICOSOLICITUDESTELEFONO_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesMail_Internalname = "HISTORICOSOLICITUDESMAIL_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesDireccion_Internalname = "HISTORICOSOLICITUDESDIRECCION_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesCotizacion_Internalname = "HISTORICOSOLICITUDESCOTIZACION_"+sGXsfl_61_idx;
         edtHistoricoSolicitudServicioPFin_Internalname = "HISTORICOSOLICITUDSERVICIOPFIN_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesFechaAlta_Internalname = "HISTORICOSOLICITUDESFECHAALTA_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesOrigenPago_Internalname = "HISTORICOSOLICITUDESORIGENPAGO_"+sGXsfl_61_idx;
         cmbHistoricoSolicitudesPagado_Internalname = "HISTORICOSOLICITUDESPAGADO_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesProvID_Internalname = "HISTORICOSOLICITUDESPROVID_"+sGXsfl_61_idx;
         edtHistoricoSolicitudesProvNombre_Internalname = "HISTORICOSOLICITUDESPROVNOMBRE_"+sGXsfl_61_idx;
      }

      protected void SubsflControlProps_fel_612( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_61_fel_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_61_fel_idx;
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO_"+sGXsfl_61_fel_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesNombre_Internalname = "HISTORICOSOLICITUDESNOMBRE_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesTelefono_Internalname = "HISTORICOSOLICITUDESTELEFONO_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesMail_Internalname = "HISTORICOSOLICITUDESMAIL_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesDireccion_Internalname = "HISTORICOSOLICITUDESDIRECCION_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesCotizacion_Internalname = "HISTORICOSOLICITUDESCOTIZACION_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudServicioPFin_Internalname = "HISTORICOSOLICITUDSERVICIOPFIN_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesFechaAlta_Internalname = "HISTORICOSOLICITUDESFECHAALTA_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesOrigenPago_Internalname = "HISTORICOSOLICITUDESORIGENPAGO_"+sGXsfl_61_fel_idx;
         cmbHistoricoSolicitudesPagado_Internalname = "HISTORICOSOLICITUDESPAGADO_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesProvID_Internalname = "HISTORICOSOLICITUDESPROVID_"+sGXsfl_61_fel_idx;
         edtHistoricoSolicitudesProvNombre_Internalname = "HISTORICOSOLICITUDESPROVNOMBRE_"+sGXsfl_61_fel_idx;
      }

      protected void sendrow_612( )
      {
         sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
         SubsflControlProps_612( ) ;
         WB2I0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_61_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_61_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_61_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_61_idx + "',61)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_61_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV72GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_61_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_61_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtHistoricoSolicitudesID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolTipo_Internalname,StringUtil.RTrim( A130EstadosSolTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadosSolNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolNombre_Internalname,StringUtil.RTrim( A132EstadosSolNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadosSolNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosSolNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadosSolNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesNombre_Internalname,StringUtil.RTrim( A288HistoricoSolicitudesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHistoricoSolicitudesNombre_Link,(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A289HistoricoSolicitudesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesTelefono_Internalname,StringUtil.RTrim( A289HistoricoSolicitudesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesMail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesMail_Internalname,(string)A290HistoricoSolicitudesMail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A290HistoricoSolicitudesMail,(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesMail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesDireccion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesDireccion_Internalname,(string)A291HistoricoSolicitudesDireccion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesDireccion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtHistoricoSolicitudesCotizacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesCotizacion_Internalname,StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesCotizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesCotizacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtHistoricoSolicitudServicioPFin_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudServicioPFin_Internalname,StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudServicioPFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudServicioPFin_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtHistoricoSolicitudesFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesFechaAlta_Internalname,context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"),context.localUtil.Format( A306HistoricoSolicitudesFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesOrigenPago_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesOrigenPago_Internalname,StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesOrigenPago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesOrigenPago_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbHistoricoSolicitudesPagado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbHistoricoSolicitudesPagado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "HISTORICOSOLICITUDESPAGADO_" + sGXsfl_61_idx;
               cmbHistoricoSolicitudesPagado.Name = GXCCtl;
               cmbHistoricoSolicitudesPagado.WebTags = "";
               cmbHistoricoSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
               cmbHistoricoSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
               if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
               {
                  A442HistoricoSolicitudesPagado = cmbHistoricoSolicitudesPagado.getValidValue(A442HistoricoSolicitudesPagado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbHistoricoSolicitudesPagado,(string)cmbHistoricoSolicitudesPagado_Internalname,StringUtil.RTrim( A442HistoricoSolicitudesPagado),(short)1,(string)cmbHistoricoSolicitudesPagado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbHistoricoSolicitudesPagado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
            AssignProp("", false, cmbHistoricoSolicitudesPagado_Internalname, "Values", (string)(cmbHistoricoSolicitudesPagado.ToJavascriptSource()), !bGXsfl_61_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtHistoricoSolicitudesProvID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesProvID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A633HistoricoSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A633HistoricoSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesProvID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesProvID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtHistoricoSolicitudesProvNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesProvNombre_Internalname,StringUtil.RTrim( A634HistoricoSolicitudesProvNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesProvNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtHistoricoSolicitudesProvNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)61,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2I2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_61_idx = ((subGrid_Islastpage==1)&&(nGXsfl_61_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_61_idx+1);
            sGXsfl_61_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_61_idx), 4, 0), 4, "0");
            SubsflControlProps_612( ) ;
         }
         /* End function sendrow_612 */
      }

      protected void init_web_controls( )
      {
         dynavEstadosgenericosid.Name = "vESTADOSGENERICOSID";
         dynavEstadosgenericosid.WebTags = "";
         dynavProveedorid.Name = "vPROVEEDORID";
         dynavProveedorid.WebTags = "";
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_61_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV72GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV72GridActions), 4, 0));
         }
         GXCCtl = "HISTORICOSOLICITUDESPAGADO_" + sGXsfl_61_idx;
         cmbHistoricoSolicitudesPagado.Name = GXCCtl;
         cmbHistoricoSolicitudesPagado.WebTags = "";
         cmbHistoricoSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbHistoricoSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
            A442HistoricoSolicitudesPagado = cmbHistoricoSolicitudesPagado.getValidValue(A442HistoricoSolicitudesPagado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl61( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"61\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosSolNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre | Contacto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Telefono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesMail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesDireccion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Direccion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesCotizacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cotizacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudServicioPFin_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Servicio PFinal", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesOrigenPago_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbHistoricoSolicitudesPagado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pagado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesProvID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtHistoricoSolicitudesProvNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre del Comercio", "")) ;
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
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A130EstadosSolTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132EstadosSolNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosSolNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosSolNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A288HistoricoSolicitudesNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtHistoricoSolicitudesNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A289HistoricoSolicitudesTelefono)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A290HistoricoSolicitudesMail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesMail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A291HistoricoSolicitudesDireccion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesDireccion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesCotizacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudServicioPFin_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesOrigenPago_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A442HistoricoSolicitudesPagado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbHistoricoSolicitudesPagado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A633HistoricoSolicitudesProvID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesProvID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A634HistoricoSolicitudesProvNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesProvNombre_Visible), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         edtavFechaini_Internalname = "vFECHAINI";
         edtavFechafin_Internalname = "vFECHAFIN";
         dynavEstadosgenericosid_Internalname = "vESTADOSGENERICOSID";
         dynavProveedorid_Internalname = "vPROVEEDORID";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO";
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE";
         edtHistoricoSolicitudesNombre_Internalname = "HISTORICOSOLICITUDESNOMBRE";
         edtHistoricoSolicitudesTelefono_Internalname = "HISTORICOSOLICITUDESTELEFONO";
         edtHistoricoSolicitudesMail_Internalname = "HISTORICOSOLICITUDESMAIL";
         edtHistoricoSolicitudesDireccion_Internalname = "HISTORICOSOLICITUDESDIRECCION";
         edtHistoricoSolicitudesCotizacion_Internalname = "HISTORICOSOLICITUDESCOTIZACION";
         edtHistoricoSolicitudServicioPFin_Internalname = "HISTORICOSOLICITUDSERVICIOPFIN";
         edtHistoricoSolicitudesFechaAlta_Internalname = "HISTORICOSOLICITUDESFECHAALTA";
         edtHistoricoSolicitudesOrigenPago_Internalname = "HISTORICOSOLICITUDESORIGENPAGO";
         cmbHistoricoSolicitudesPagado_Internalname = "HISTORICOSOLICITUDESPAGADO";
         edtHistoricoSolicitudesProvID_Internalname = "HISTORICOSOLICITUDESPROVID";
         edtHistoricoSolicitudesProvNombre_Internalname = "HISTORICOSOLICITUDESPROVNOMBRE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         edtHistoricoSolicitudesProvNombre_Jsonclick = "";
         edtHistoricoSolicitudesProvID_Jsonclick = "";
         cmbHistoricoSolicitudesPagado_Jsonclick = "";
         edtHistoricoSolicitudesOrigenPago_Jsonclick = "";
         edtHistoricoSolicitudesFechaAlta_Jsonclick = "";
         edtHistoricoSolicitudServicioPFin_Jsonclick = "";
         edtHistoricoSolicitudesCotizacion_Jsonclick = "";
         edtHistoricoSolicitudesDireccion_Jsonclick = "";
         edtHistoricoSolicitudesMail_Jsonclick = "";
         edtHistoricoSolicitudesTelefono_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Link = "";
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolNombre_Link = "";
         edtEstadosSolTipo_Jsonclick = "";
         edtEstadosSolId_Jsonclick = "";
         edtHistoricoSolicitudesID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         dynavProveedorid_Jsonclick = "";
         dynavProveedorid.Enabled = 1;
         dynavEstadosgenericosid_Jsonclick = "";
         dynavEstadosgenericosid.Enabled = 1;
         edtavFechafin_Jsonclick = "";
         edtavFechafin_Enabled = 1;
         edtavFechaini_Jsonclick = "";
         edtavFechaini_Enabled = 1;
         edtHistoricoSolicitudesProvNombre_Visible = -1;
         edtHistoricoSolicitudesProvID_Visible = -1;
         cmbHistoricoSolicitudesPagado.Visible = -1;
         edtHistoricoSolicitudesOrigenPago_Visible = -1;
         edtHistoricoSolicitudesFechaAlta_Visible = -1;
         edtHistoricoSolicitudServicioPFin_Visible = -1;
         edtHistoricoSolicitudesCotizacion_Visible = -1;
         edtHistoricoSolicitudesDireccion_Visible = -1;
         edtHistoricoSolicitudesMail_Visible = -1;
         edtHistoricoSolicitudesTelefono_Visible = -1;
         edtHistoricoSolicitudesNombre_Visible = -1;
         edtEstadosSolNombre_Visible = -1;
         edtHistoricoSolicitudesID_Visible = -1;
         edtHistoricoSolicitudesProvNombre_Enabled = 0;
         edtHistoricoSolicitudesProvID_Enabled = 0;
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         edtHistoricoSolicitudesMail_Enabled = 0;
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         edtHistoricoSolicitudesNombre_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         subGrid_Sortable = 0;
         bttBtnsubscriptions_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "|||||||||||18.0|";
         Ddo_grid_Datalistproc = "HistoricoSolicitudesWWGetFilterData";
         Ddo_grid_Datalisttype = "||||||||||||Dynamic";
         Ddo_grid_Includedatalist = "||||||||||||T";
         Ddo_grid_Filterisrange = "|||||||||||T|";
         Ddo_grid_Filtertype = "|||||||||||Numeric|Character";
         Ddo_grid_Includefilter = "|||||||||||T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T||T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7||8|9|10|11|12";
         Ddo_grid_Columnids = "1:HistoricoSolicitudesID|4:EstadosSolNombre|5:HistoricoSolicitudesNombre|6:HistoricoSolicitudesTelefono|7:HistoricoSolicitudesMail|8:HistoricoSolicitudesDireccion|9:HistoricoSolicitudesCotizacion|10:HistoricoSolicitudServicioPFinal|11:HistoricoSolicitudesFechaAlta|12:HistoricoSolicitudesOrigenPago|13:HistoricoSolicitudesPagado|14:HistoricoSolicitudesProvID|15:HistoricoSolicitudesProvNombre";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Historico Solicitudes", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtHistoricoSolicitudesID_Visible',ctrl:'HISTORICOSOLICITUDESID',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesNombre_Visible',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesTelefono_Visible',ctrl:'HISTORICOSOLICITUDESTELEFONO',prop:'Visible'},{av:'edtHistoricoSolicitudesMail_Visible',ctrl:'HISTORICOSOLICITUDESMAIL',prop:'Visible'},{av:'edtHistoricoSolicitudesDireccion_Visible',ctrl:'HISTORICOSOLICITUDESDIRECCION',prop:'Visible'},{av:'edtHistoricoSolicitudesCotizacion_Visible',ctrl:'HISTORICOSOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtHistoricoSolicitudServicioPFin_Visible',ctrl:'HISTORICOSOLICITUDSERVICIOPFIN',prop:'Visible'},{av:'edtHistoricoSolicitudesFechaAlta_Visible',ctrl:'HISTORICOSOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtHistoricoSolicitudesOrigenPago_Visible',ctrl:'HISTORICOSOLICITUDESORIGENPAGO',prop:'Visible'},{av:'cmbHistoricoSolicitudesPagado'},{av:'edtHistoricoSolicitudesProvID_Visible',ctrl:'HISTORICOSOLICITUDESPROVID',prop:'Visible'},{av:'edtHistoricoSolicitudesProvNombre_Visible',ctrl:'HISTORICOSOLICITUDESPROVNOMBRE',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E122I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtHistoricoSolicitudesID_Visible',ctrl:'HISTORICOSOLICITUDESID',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesNombre_Visible',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesTelefono_Visible',ctrl:'HISTORICOSOLICITUDESTELEFONO',prop:'Visible'},{av:'edtHistoricoSolicitudesMail_Visible',ctrl:'HISTORICOSOLICITUDESMAIL',prop:'Visible'},{av:'edtHistoricoSolicitudesDireccion_Visible',ctrl:'HISTORICOSOLICITUDESDIRECCION',prop:'Visible'},{av:'edtHistoricoSolicitudesCotizacion_Visible',ctrl:'HISTORICOSOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtHistoricoSolicitudServicioPFin_Visible',ctrl:'HISTORICOSOLICITUDSERVICIOPFIN',prop:'Visible'},{av:'edtHistoricoSolicitudesFechaAlta_Visible',ctrl:'HISTORICOSOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtHistoricoSolicitudesOrigenPago_Visible',ctrl:'HISTORICOSOLICITUDESORIGENPAGO',prop:'Visible'},{av:'cmbHistoricoSolicitudesPagado'},{av:'edtHistoricoSolicitudesProvID_Visible',ctrl:'HISTORICOSOLICITUDESPROVID',prop:'Visible'},{av:'edtHistoricoSolicitudesProvNombre_Visible',ctrl:'HISTORICOSOLICITUDESPROVNOMBRE',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E162I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E202I2',iparms:[{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV72GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtEstadosSolNombre_Link',ctrl:'ESTADOSSOLNOMBRE',prop:'Link'},{av:'edtHistoricoSolicitudesNombre_Link',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E172I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtHistoricoSolicitudesID_Visible',ctrl:'HISTORICOSOLICITUDESID',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesNombre_Visible',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesTelefono_Visible',ctrl:'HISTORICOSOLICITUDESTELEFONO',prop:'Visible'},{av:'edtHistoricoSolicitudesMail_Visible',ctrl:'HISTORICOSOLICITUDESMAIL',prop:'Visible'},{av:'edtHistoricoSolicitudesDireccion_Visible',ctrl:'HISTORICOSOLICITUDESDIRECCION',prop:'Visible'},{av:'edtHistoricoSolicitudesCotizacion_Visible',ctrl:'HISTORICOSOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtHistoricoSolicitudServicioPFin_Visible',ctrl:'HISTORICOSOLICITUDSERVICIOPFIN',prop:'Visible'},{av:'edtHistoricoSolicitudesFechaAlta_Visible',ctrl:'HISTORICOSOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtHistoricoSolicitudesOrigenPago_Visible',ctrl:'HISTORICOSOLICITUDESORIGENPAGO',prop:'Visible'},{av:'cmbHistoricoSolicitudesPagado'},{av:'edtHistoricoSolicitudesProvID_Visible',ctrl:'HISTORICOSOLICITUDESPROVID',prop:'Visible'},{av:'edtHistoricoSolicitudesProvNombre_Visible',ctrl:'HISTORICOSOLICITUDESPROVNOMBRE',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E112I2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtHistoricoSolicitudesID_Visible',ctrl:'HISTORICOSOLICITUDESID',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesNombre_Visible',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesTelefono_Visible',ctrl:'HISTORICOSOLICITUDESTELEFONO',prop:'Visible'},{av:'edtHistoricoSolicitudesMail_Visible',ctrl:'HISTORICOSOLICITUDESMAIL',prop:'Visible'},{av:'edtHistoricoSolicitudesDireccion_Visible',ctrl:'HISTORICOSOLICITUDESDIRECCION',prop:'Visible'},{av:'edtHistoricoSolicitudesCotizacion_Visible',ctrl:'HISTORICOSOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtHistoricoSolicitudServicioPFin_Visible',ctrl:'HISTORICOSOLICITUDSERVICIOPFIN',prop:'Visible'},{av:'edtHistoricoSolicitudesFechaAlta_Visible',ctrl:'HISTORICOSOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtHistoricoSolicitudesOrigenPago_Visible',ctrl:'HISTORICOSOLICITUDESORIGENPAGO',prop:'Visible'},{av:'cmbHistoricoSolicitudesPagado'},{av:'edtHistoricoSolicitudesProvID_Visible',ctrl:'HISTORICOSOLICITUDESPROVID',prop:'Visible'},{av:'edtHistoricoSolicitudesProvNombre_Visible',ctrl:'HISTORICOSOLICITUDESPROVNOMBRE',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E212I2',iparms:[{av:'cmbavGridactions'},{av:'AV72GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV72GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E142I2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV83FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV82FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV81EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynavProveedorid'},{av:'AV84ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV95TFHistoricoSolicitudesProvID',fld:'vTFHISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV96TFHistoricoSolicitudesProvID_To',fld:'vTFHISTORICOSOLICITUDESPROVID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV97TFHistoricoSolicitudesProvNombre',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'},{av:'AV98TFHistoricoSolicitudesProvNombre_Sel',fld:'vTFHISTORICOSOLICITUDESPROVNOMBRE_SEL',pic:'',type:'char'},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV90IsAuthorized_HistoricoSolicitudesNombre',fld:'vISAUTHORIZED_HISTORICOSOLICITUDESNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'edtHistoricoSolicitudesID_Visible',ctrl:'HISTORICOSOLICITUDESID',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesNombre_Visible',ctrl:'HISTORICOSOLICITUDESNOMBRE',prop:'Visible'},{av:'edtHistoricoSolicitudesTelefono_Visible',ctrl:'HISTORICOSOLICITUDESTELEFONO',prop:'Visible'},{av:'edtHistoricoSolicitudesMail_Visible',ctrl:'HISTORICOSOLICITUDESMAIL',prop:'Visible'},{av:'edtHistoricoSolicitudesDireccion_Visible',ctrl:'HISTORICOSOLICITUDESDIRECCION',prop:'Visible'},{av:'edtHistoricoSolicitudesCotizacion_Visible',ctrl:'HISTORICOSOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtHistoricoSolicitudServicioPFin_Visible',ctrl:'HISTORICOSOLICITUDSERVICIOPFIN',prop:'Visible'},{av:'edtHistoricoSolicitudesFechaAlta_Visible',ctrl:'HISTORICOSOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtHistoricoSolicitudesOrigenPago_Visible',ctrl:'HISTORICOSOLICITUDESORIGENPAGO',prop:'Visible'},{av:'cmbHistoricoSolicitudesPagado'},{av:'edtHistoricoSolicitudesProvID_Visible',ctrl:'HISTORICOSOLICITUDESPROVID',prop:'Visible'},{av:'edtHistoricoSolicitudesProvNombre_Visible',ctrl:'HISTORICOSOLICITUDESPROVNOMBRE',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E152I2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_FECHAINI","{handler:'Validv_Fechaini',iparms:[]");
         setEventMetadata("VALIDV_FECHAINI",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAFIN","{handler:'Validv_Fechafin',iparms:[]");
         setEventMetadata("VALIDV_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID","{handler:'Valid_Historicosolicitudesid',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOMBRE","{handler:'Valid_Historicosolicitudesnombre',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTELEFONO","{handler:'Valid_Historicosolicitudestelefono',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL","{handler:'Valid_Historicosolicitudesmail',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESDIRECCION","{handler:'Valid_Historicosolicitudesdireccion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION","{handler:'Valid_Historicosolicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN","{handler:'Valid_Historicosolicitudserviciopfin',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESPROVNOMBRE","{handler:'Valid_Historicosolicitudesprovnombre',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESPROVNOMBRE",",oparms:[]}");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV83FechaIni = DateTime.MinValue;
         AV82FechaFin = DateTime.MinValue;
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV100Pgmname = "";
         AV17FilterFullText = "";
         AV97TFHistoricoSolicitudesProvNombre = "";
         AV98TFHistoricoSolicitudesProvNombre_Sel = "";
         H002I2_A153HistoricoSolicitudesID = new long[1] ;
         H002I2_A154HistoricoSolicitudesItemsID = new short[1] ;
         H002I2_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         H002I2_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         H002I2_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         H002I2_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         H002I2_A295HItemsInventarioPrecioFinal = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV71GridAppliedFilters = "";
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV67DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A130EstadosSolTipo = "";
         A132EstadosSolNombre = "";
         A288HistoricoSolicitudesNombre = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A291HistoricoSolicitudesDireccion = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         A439HistoricoSolicitudesOrigenPago = "";
         A442HistoricoSolicitudesPagado = "";
         A634HistoricoSolicitudesProvNombre = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H002I3_A108EstadosGenericosId = new int[1] ;
         H002I3_A109EstadosGenericosNombre = new string[] {""} ;
         H002I3_A107EstadosTipo = new string[] {""} ;
         H002I4_A133ProveedorID = new long[1] ;
         H002I4_A282ProveedorNombre = new string[] {""} ;
         AV101Historicosolicitudeswwds_1_filterfulltext = "";
         AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = "";
         lV101Historicosolicitudeswwds_1_filterfulltext = "";
         lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         H002I5_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         H002I5_A633HistoricoSolicitudesProvID = new long[1] ;
         H002I5_A442HistoricoSolicitudesPagado = new string[] {""} ;
         H002I5_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         H002I5_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002I5_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         H002I5_A290HistoricoSolicitudesMail = new string[] {""} ;
         H002I5_n290HistoricoSolicitudesMail = new bool[] {false} ;
         H002I5_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         H002I5_A288HistoricoSolicitudesNombre = new string[] {""} ;
         H002I5_A132EstadosSolNombre = new string[] {""} ;
         H002I5_A130EstadosSolTipo = new string[] {""} ;
         H002I5_A131EstadosSolId = new int[1] ;
         H002I5_A153HistoricoSolicitudesID = new long[1] ;
         H002I5_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         H002I6_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         H002I6_A633HistoricoSolicitudesProvID = new long[1] ;
         H002I6_A442HistoricoSolicitudesPagado = new string[] {""} ;
         H002I6_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         H002I6_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002I6_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         H002I6_A290HistoricoSolicitudesMail = new string[] {""} ;
         H002I6_n290HistoricoSolicitudesMail = new bool[] {false} ;
         H002I6_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         H002I6_A288HistoricoSolicitudesNombre = new string[] {""} ;
         H002I6_A132EstadosSolNombre = new string[] {""} ;
         H002I6_A130EstadosSolTipo = new string[] {""} ;
         H002I6_A131EstadosSolId = new int[1] ;
         H002I6_A153HistoricoSolicitudesID = new long[1] ;
         H002I6_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV45ManageFiltersXml = "";
         AV40UserCustomValue = "";
         AV42ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV37ExcelFilename = "";
         AV38ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudesww__default(),
            new Object[][] {
                new Object[] {
               H002I2_A153HistoricoSolicitudesID, H002I2_A154HistoricoSolicitudesItemsID, H002I2_A298HistoricoSolicitudesItemsComis, H002I2_A297HistoricoSolicitudesItemsCT, H002I2_A296HistoricoSolicitudesItemsSR, H002I2_A293HItemsSolicitudesItemsCantidad, H002I2_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               H002I3_A108EstadosGenericosId, H002I3_A109EstadosGenericosNombre, H002I3_A107EstadosTipo
               }
               , new Object[] {
               H002I4_A133ProveedorID, H002I4_A282ProveedorNombre
               }
               , new Object[] {
               H002I5_A634HistoricoSolicitudesProvNombre, H002I5_A633HistoricoSolicitudesProvID, H002I5_A442HistoricoSolicitudesPagado, H002I5_A439HistoricoSolicitudesOrigenPago, H002I5_A306HistoricoSolicitudesFechaAlta, H002I5_A291HistoricoSolicitudesDireccion, H002I5_A290HistoricoSolicitudesMail, H002I5_n290HistoricoSolicitudesMail, H002I5_A289HistoricoSolicitudesTelefono, H002I5_A288HistoricoSolicitudesNombre,
               H002I5_A132EstadosSolNombre, H002I5_A130EstadosSolTipo, H002I5_A131EstadosSolId, H002I5_A153HistoricoSolicitudesID, H002I5_A299HistoricoSolicitudesCotizacion
               }
               , new Object[] {
               H002I6_A634HistoricoSolicitudesProvNombre, H002I6_A633HistoricoSolicitudesProvID, H002I6_A442HistoricoSolicitudesPagado, H002I6_A439HistoricoSolicitudesOrigenPago, H002I6_A306HistoricoSolicitudesFechaAlta, H002I6_A291HistoricoSolicitudesDireccion, H002I6_A290HistoricoSolicitudesMail, H002I6_n290HistoricoSolicitudesMail, H002I6_A289HistoricoSolicitudesTelefono, H002I6_A288HistoricoSolicitudesNombre,
               H002I6_A132EstadosSolNombre, H002I6_A130EstadosSolTipo, H002I6_A131EstadosSolId, H002I6_A153HistoricoSolicitudesID, H002I6_A299HistoricoSolicitudesCotizacion
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV100Pgmname = "HistoricoSolicitudesWW";
         /* GeneXus formulas. */
         AV100Pgmname = "HistoricoSolicitudesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV46ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV72GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_61 ;
      private int nGXsfl_61_idx=1 ;
      private int AV81EstadosGenericosID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnsubscriptions_Visible ;
      private int A131EstadosSolId ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtHistoricoSolicitudesNombre_Enabled ;
      private int edtHistoricoSolicitudesTelefono_Enabled ;
      private int edtHistoricoSolicitudesMail_Enabled ;
      private int edtHistoricoSolicitudesDireccion_Enabled ;
      private int edtHistoricoSolicitudesCotizacion_Enabled ;
      private int edtHistoricoSolicitudServicioPFin_Enabled ;
      private int edtHistoricoSolicitudesFechaAlta_Enabled ;
      private int edtHistoricoSolicitudesOrigenPago_Enabled ;
      private int edtHistoricoSolicitudesProvID_Enabled ;
      private int edtHistoricoSolicitudesProvNombre_Enabled ;
      private int edtHistoricoSolicitudesID_Visible ;
      private int edtEstadosSolNombre_Visible ;
      private int edtHistoricoSolicitudesNombre_Visible ;
      private int edtHistoricoSolicitudesTelefono_Visible ;
      private int edtHistoricoSolicitudesMail_Visible ;
      private int edtHistoricoSolicitudesDireccion_Visible ;
      private int edtHistoricoSolicitudesCotizacion_Visible ;
      private int edtHistoricoSolicitudServicioPFin_Visible ;
      private int edtHistoricoSolicitudesFechaAlta_Visible ;
      private int edtHistoricoSolicitudesOrigenPago_Visible ;
      private int edtHistoricoSolicitudesProvID_Visible ;
      private int edtHistoricoSolicitudesProvNombre_Visible ;
      private int AV68PageToGo ;
      private int AV106GXV1 ;
      private int edtavFechaini_Enabled ;
      private int edtavFechafin_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV84ProveedorID ;
      private long AV95TFHistoricoSolicitudesProvID ;
      private long AV96TFHistoricoSolicitudesProvID_To ;
      private long A153HistoricoSolicitudesID ;
      private long AV69GridCurrentPage ;
      private long AV70GridPageCount ;
      private long A633HistoricoSolicitudesProvID ;
      private long GRID_nCurrentRecord ;
      private long AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ;
      private long AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ;
      private long GRID_nRecordCount ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_61_idx="0001" ;
      private string AV100Pgmname ;
      private string AV97TFHistoricoSolicitudesProvNombre ;
      private string AV98TFHistoricoSolicitudesProvNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
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
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string edtEstadosSolId_Internalname ;
      private string A130EstadosSolTipo ;
      private string edtEstadosSolTipo_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Internalname ;
      private string A288HistoricoSolicitudesNombre ;
      private string edtHistoricoSolicitudesNombre_Internalname ;
      private string A289HistoricoSolicitudesTelefono ;
      private string edtHistoricoSolicitudesTelefono_Internalname ;
      private string edtHistoricoSolicitudesMail_Internalname ;
      private string edtHistoricoSolicitudesDireccion_Internalname ;
      private string edtHistoricoSolicitudesCotizacion_Internalname ;
      private string edtHistoricoSolicitudServicioPFin_Internalname ;
      private string edtHistoricoSolicitudesFechaAlta_Internalname ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string edtHistoricoSolicitudesOrigenPago_Internalname ;
      private string cmbHistoricoSolicitudesPagado_Internalname ;
      private string A442HistoricoSolicitudesPagado ;
      private string edtHistoricoSolicitudesProvID_Internalname ;
      private string A634HistoricoSolicitudesProvNombre ;
      private string edtHistoricoSolicitudesProvNombre_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string gxwrpcisep ;
      private string dynavEstadosgenericosid_Internalname ;
      private string dynavProveedorid_Internalname ;
      private string AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ;
      private string lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string edtavFechaini_Internalname ;
      private string edtavFechafin_Internalname ;
      private string edtEstadosSolNombre_Link ;
      private string GXEncryptionTmp ;
      private string edtHistoricoSolicitudesNombre_Link ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavFechaini_Jsonclick ;
      private string edtavFechafin_Jsonclick ;
      private string dynavEstadosgenericosid_Jsonclick ;
      private string dynavProveedorid_Jsonclick ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_61_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string edtHistoricoSolicitudesNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtHistoricoSolicitudesTelefono_Jsonclick ;
      private string edtHistoricoSolicitudesMail_Jsonclick ;
      private string edtHistoricoSolicitudesDireccion_Jsonclick ;
      private string edtHistoricoSolicitudesCotizacion_Jsonclick ;
      private string edtHistoricoSolicitudServicioPFin_Jsonclick ;
      private string edtHistoricoSolicitudesFechaAlta_Jsonclick ;
      private string edtHistoricoSolicitudesOrigenPago_Jsonclick ;
      private string cmbHistoricoSolicitudesPagado_Jsonclick ;
      private string edtHistoricoSolicitudesProvID_Jsonclick ;
      private string edtHistoricoSolicitudesProvNombre_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV83FechaIni ;
      private DateTime AV82FechaFin ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV99IsAuthorized_EstadosSolNombre ;
      private bool AV90IsAuthorized_HistoricoSolicitudesNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_61_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n290HistoricoSolicitudesMail ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV78TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV39ColumnsSelectorXML ;
      private string AV45ManageFiltersXml ;
      private string AV40UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV71GridAppliedFilters ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private string AV101Historicosolicitudeswwds_1_filterfulltext ;
      private string lV101Historicosolicitudeswwds_1_filterfulltext ;
      private string AV37ExcelFilename ;
      private string AV38ErrorMessage ;
      private IGxSession AV43Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEstadosgenericosid ;
      private GXCombobox dynavProveedorid ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbHistoricoSolicitudesPagado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ;
      private IDataStoreProvider pr_default ;
      private long[] H002I2_A153HistoricoSolicitudesID ;
      private short[] H002I2_A154HistoricoSolicitudesItemsID ;
      private decimal[] H002I2_A298HistoricoSolicitudesItemsComis ;
      private string[] H002I2_A297HistoricoSolicitudesItemsCT ;
      private string[] H002I2_A296HistoricoSolicitudesItemsSR ;
      private short[] H002I2_A293HItemsSolicitudesItemsCantidad ;
      private short[] H002I2_A295HItemsInventarioPrecioFinal ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV44ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV76AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV67DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private int[] H002I3_A108EstadosGenericosId ;
      private string[] H002I3_A109EstadosGenericosNombre ;
      private string[] H002I3_A107EstadosTipo ;
      private long[] H002I4_A133ProveedorID ;
      private string[] H002I4_A282ProveedorNombre ;
      private string[] H002I5_A634HistoricoSolicitudesProvNombre ;
      private long[] H002I5_A633HistoricoSolicitudesProvID ;
      private string[] H002I5_A442HistoricoSolicitudesPagado ;
      private string[] H002I5_A439HistoricoSolicitudesOrigenPago ;
      private DateTime[] H002I5_A306HistoricoSolicitudesFechaAlta ;
      private string[] H002I5_A291HistoricoSolicitudesDireccion ;
      private string[] H002I5_A290HistoricoSolicitudesMail ;
      private bool[] H002I5_n290HistoricoSolicitudesMail ;
      private string[] H002I5_A289HistoricoSolicitudesTelefono ;
      private string[] H002I5_A288HistoricoSolicitudesNombre ;
      private string[] H002I5_A132EstadosSolNombre ;
      private string[] H002I5_A130EstadosSolTipo ;
      private int[] H002I5_A131EstadosSolId ;
      private long[] H002I5_A153HistoricoSolicitudesID ;
      private decimal[] H002I5_A299HistoricoSolicitudesCotizacion ;
      private string[] H002I6_A634HistoricoSolicitudesProvNombre ;
      private long[] H002I6_A633HistoricoSolicitudesProvID ;
      private string[] H002I6_A442HistoricoSolicitudesPagado ;
      private string[] H002I6_A439HistoricoSolicitudesOrigenPago ;
      private DateTime[] H002I6_A306HistoricoSolicitudesFechaAlta ;
      private string[] H002I6_A291HistoricoSolicitudesDireccion ;
      private string[] H002I6_A290HistoricoSolicitudesMail ;
      private bool[] H002I6_n290HistoricoSolicitudesMail ;
      private string[] H002I6_A289HistoricoSolicitudesTelefono ;
      private string[] H002I6_A288HistoricoSolicitudesNombre ;
      private string[] H002I6_A132EstadosSolNombre ;
      private string[] H002I6_A130EstadosSolTipo ;
      private int[] H002I6_A131EstadosSolId ;
      private long[] H002I6_A153HistoricoSolicitudesID ;
      private decimal[] H002I6_A299HistoricoSolicitudesCotizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV77AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV42ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historicosolicitudesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002I5( IGxContext context ,
                                             long AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                             long AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                             string AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                             string AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                             int AV81EstadosGenericosID ,
                                             long AV84ProveedorID ,
                                             long A633HistoricoSolicitudesProvID ,
                                             string A634HistoricoSolicitudesProvNombre ,
                                             int A131EstadosSolId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV101Historicosolicitudeswwds_1_filterfulltext ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime AV83FechaIni ,
                                             DateTime AV82FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[8];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesProvNombre], T1.[HistoricoSolicitudesProvID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T1.[HistoricoSolicitudesFechaAlta], T1.[HistoricoSolicitudesDireccion], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadosSolId] AS EstadosSolId, T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesCotizacion] FROM ([HistoricoSolicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV83FechaIni and T1.[HistoricoSolicitudesFechaAlta] <= @AV82FechaFin)");
         if ( ! (0==AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] >= @AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] <= @AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesProvNombre]) like UPPER(@lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ! ( StringUtil.StrCmp(AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvNombre] = @AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesProvNombre] = ''))");
         }
         if ( ! ( AV81EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV81EstadosGenericosID)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV84ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] = @AV84ProveedorID)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002I6( IGxContext context ,
                                             long AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                             long AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                             string AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                             string AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                             int AV81EstadosGenericosID ,
                                             long AV84ProveedorID ,
                                             long A633HistoricoSolicitudesProvID ,
                                             string A634HistoricoSolicitudesProvNombre ,
                                             int A131EstadosSolId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV101Historicosolicitudeswwds_1_filterfulltext ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime AV83FechaIni ,
                                             DateTime AV82FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[8];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesProvNombre], T1.[HistoricoSolicitudesProvID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T1.[HistoricoSolicitudesFechaAlta], T1.[HistoricoSolicitudesDireccion], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadosSolId] AS EstadosSolId, T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesCotizacion] FROM ([HistoricoSolicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV83FechaIni and T1.[HistoricoSolicitudesFechaAlta] <= @AV82FechaFin)");
         if ( ! (0==AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] >= @AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] <= @AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesProvNombre]) like UPPER(@lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ! ( StringUtil.StrCmp(AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvNombre] = @AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesProvNombre] = ''))");
         }
         if ( ! ( AV81EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV81EstadosGenericosID)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV84ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] = @AV84ProveedorID)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002I5(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] );
               case 4 :
                     return conditional_H002I6(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002I2;
          prmH002I2 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH002I3;
          prmH002I3 = new Object[] {
          };
          Object[] prmH002I4;
          prmH002I4 = new Object[] {
          };
          Object[] prmH002I5;
          prmH002I5 = new Object[] {
          new ParDef("@AV83FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV82FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid",GXType.Decimal,18,0) ,
          new ParDef("@AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre",GXType.Char,120,0) ,
          new ParDef("@AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@AV81EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV84ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmH002I6;
          prmH002I6 = new Object[] {
          new ParDef("@AV83FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV82FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV102Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid",GXType.Decimal,18,0) ,
          new ParDef("@AV103Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV104Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre",GXType.Char,120,0) ,
          new ParDef("@AV105Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@AV81EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV84ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002I2", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I3", "SELECT [EstadosGenericosId], [EstadosGenericosNombre], [EstadosTipo] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I4", "SELECT [ProveedorID], [ProveedorNombre] FROM [Proveedor] ORDER BY [ProveedorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I6,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((long[]) buf[13])[0] = rslt.getLong(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                return;
       }
    }

 }

}
