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
   public class dashboardcom : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public dashboardcom( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dashboardcom( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_inProveedorID )
      {
         this.AV66inProveedorID = aP0_inProveedorID;
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
         dynSolicitudesUsrAlta = new GXCombobox();
         cmbListaTipo = new GXCombobox();
         cmbAgrupacionEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "inProveedorID");
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
               GXDLVvESTADOSGENERICOSIDBV2( ) ;
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
               gxfirstwebparm = GetFirstPar( "inProveedorID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "inProveedorID");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridprofesionales") == 0 )
            {
               gxnrGridprofesionales_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridprofesionales") == 0 )
            {
               gxgrGridprofesionales_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlista") == 0 )
            {
               gxnrGridlista_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlista") == 0 )
            {
               gxgrGridlista_refresh_invoke( ) ;
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
         nRC_GXsfl_139 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_139"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_139_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_139_idx = GetPar( "sGXsfl_139_idx");
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
         subGridlista_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlista_Rows"), "."), 18, MidpointRounding.ToEven));
         AV49FechaIni = context.localUtil.ParseDateParm( GetPar( "FechaIni"));
         AV50FechaFin = context.localUtil.ParseDateParm( GetPar( "FechaFin"));
         dynavEstadosgenericosid.FromJSonString( GetNextPar( ));
         AV51EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosID"), "."), 18, MidpointRounding.ToEven));
         AV52Buscar = GetPar( "Buscar");
         AV5ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV40WWPContext);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV75SDTFeedBack);
         AV66inProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "inProveedorID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected void gxnrGridprofesionales_newrow_invoke( )
      {
         nRC_GXsfl_259 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_259"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_259_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_259_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_259_idx = GetPar( "sGXsfl_259_idx");
         edtavFechaalta_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavFechaalta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechaalta_Visible), 5, 0), !bGXsfl_259_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridprofesionales_newrow( ) ;
         /* End function gxnrGridprofesionales_newrow_invoke */
      }

      protected void gxgrGridprofesionales_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridlista_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlista_Rows"), "."), 18, MidpointRounding.ToEven));
         AV49FechaIni = context.localUtil.ParseDateParm( GetPar( "FechaIni"));
         AV50FechaFin = context.localUtil.ParseDateParm( GetPar( "FechaFin"));
         dynavEstadosgenericosid.FromJSonString( GetNextPar( ));
         AV51EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosID"), "."), 18, MidpointRounding.ToEven));
         AV52Buscar = GetPar( "Buscar");
         edtavFechaalta_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavFechaalta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechaalta_Visible), 5, 0), !bGXsfl_259_Refreshing);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV75SDTFeedBack);
         AV5ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV40WWPContext);
         AV66inProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "inProveedorID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridprofesionales_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV75SDTFeedBack, AV5ProveedorID, AV40WWPContext, AV66inProveedorID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridprofesionales_refresh_invoke */
      }

      protected void gxnrGridlista_newrow_invoke( )
      {
         nRC_GXsfl_294 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_294"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_294_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_294_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_294_idx = GetPar( "sGXsfl_294_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlista_newrow( ) ;
         /* End function gxnrGridlista_newrow_invoke */
      }

      protected void gxgrGridlista_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridlista_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlista_Rows"), "."), 18, MidpointRounding.ToEven));
         AV49FechaIni = context.localUtil.ParseDateParm( GetPar( "FechaIni"));
         AV50FechaFin = context.localUtil.ParseDateParm( GetPar( "FechaFin"));
         dynavEstadosgenericosid.FromJSonString( GetNextPar( ));
         AV51EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosID"), "."), 18, MidpointRounding.ToEven));
         AV52Buscar = GetPar( "Buscar");
         AV5ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV40WWPContext);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV75SDTFeedBack);
         AV66inProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "inProveedorID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlista_refresh_invoke */
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
         /* Using cursor H00BV2 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H00BV2_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H00BV2_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H00BV2_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H00BV2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00BV2_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])-(H00BV2_A180SolicitudItemsComision[0]*H00BV2_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H00BV2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00BV2_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])+(H00BV2_A180SolicitudItemsComision[0]*H00BV2_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H00BV2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00BV2_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])-((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])*(H00BV2_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H00BV2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00BV2_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])+((H00BV2_A176SolicitudesItemsPrecioFinal[0]*H00BV2_A177SolicitudesItemsCantidad[0])*(H00BV2_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         PABV2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBV2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
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
            GXEncryptionTmp = "comercios.dashboardcom.aspx"+UrlEncode(StringUtil.LTrimStr(AV66inProveedorID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comercios.dashboardcom.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV40WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV40WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV40WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTFEEDBACK", AV75SDTFeedBack);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTFEEDBACK", AV75SDTFeedBack);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTFEEDBACK", GetSecureSignedToken( "", AV75SDTFeedBack, context));
         GxWebStd.gx_hidden_field( context, "vINPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66inProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66inProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAINI", context.localUtil.Format(AV49FechaIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAFIN", context.localUtil.Format(AV50FechaFin, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51EstadosGenericosID), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBUSCAR", StringUtil.RTrim( AV52Buscar));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_139", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_139), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_259", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_259), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_294", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_294), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV47GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV40WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV40WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV40WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTFEEDBACK", AV75SDTFeedBack);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTFEEDBACK", AV75SDTFeedBack);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTFEEDBACK", GetSecureSignedToken( "", AV75SDTFeedBack, context));
         GxWebStd.gx_hidden_field( context, "vINPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66inProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66inProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLINKMUDANZA", AV89LinkMudanza);
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vLINK", StringUtil.RTrim( AV57Link));
         GxWebStd.gx_hidden_field( context, "vUSRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56UsrId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "subGridprofesionales_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Recordcount), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESTOTAL", StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOSTOXZONA", StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOTIZACION", StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOMISIONMETODOPAGO", StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Caption", StringUtil.RTrim( Card2_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Cls", StringUtil.RTrim( Card2_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card2_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Caption", StringUtil.RTrim( Card1_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Cls", StringUtil.RTrim( Card1_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card1_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card1_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Caption", StringUtil.RTrim( Card3_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Cls", StringUtil.RTrim( Card3_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card3_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Caption", StringUtil.RTrim( Card4_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Cls", StringUtil.RTrim( Card4_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card4_progress_Percentage), 9, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT1_PROGRESS_Type", StringUtil.RTrim( Cardright1_progress_Type));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT1_PROGRESS_Caption", StringUtil.RTrim( Cardright1_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT1_PROGRESS_Cls", StringUtil.RTrim( Cardright1_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT1_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Cardright1_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT2_PROGRESS_Type", StringUtil.RTrim( Cardright2_progress_Type));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT2_PROGRESS_Caption", StringUtil.RTrim( Cardright2_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT2_PROGRESS_Cls", StringUtil.RTrim( Cardright2_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT2_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Cardright2_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT3_PROGRESS_Type", StringUtil.RTrim( Cardright3_progress_Type));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT3_PROGRESS_Caption", StringUtil.RTrim( Cardright3_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT3_PROGRESS_Cls", StringUtil.RTrim( Cardright3_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT3_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Cardright3_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT4_PROGRESS_Type", StringUtil.RTrim( Cardright4_progress_Type));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT4_PROGRESS_Caption", StringUtil.RTrim( Cardright4_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT4_PROGRESS_Cls", StringUtil.RTrim( Cardright4_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARDRIGHT4_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Cardright4_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Width", StringUtil.RTrim( Innewwindow_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Height", StringUtil.RTrim( Innewwindow_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW_Target", StringUtil.RTrim( Innewwindow_Target));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Gridlista_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Gridlista_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlista_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_EMPOWERER_Hascategories", StringUtil.BoolToStr( Gridlista_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDPROFESIONALES_Class", StringUtil.RTrim( subGridprofesionales_Class));
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
            WEBV2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBV2( ) ;
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
         GXEncryptionTmp = "comercios.dashboardcom.aspx"+UrlEncode(StringUtil.LTrimStr(AV66inProveedorID,18,0));
         return formatLink("comercios.dashboardcom.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Comercios.DashboardCOM" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estadísticas del Comercio", "") ;
      }

      protected void WBBV0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUsuariosimagen_cell_Internalname, 1, 0, "px", 0, "px", divUsuariosimagen_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 StepImageUnSelectedLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "StepImageUnSelected" + " " + ((StringUtil.StrCmp(imgavUsuariosimagen_gximage, "")==0) ? "" : "GX_Image_"+imgavUsuariosimagen_gximage+"_Class");
            StyleString = "";
            AV72usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV90Usuariosimagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen)) ? AV90Usuariosimagen_GXI : context.PathToRelativeUrl( AV72usuariosImagen));
            GxWebStd.gx_bitmap( context, imgavUsuariosimagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavUsuariosimagen_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV72usuariosImagen_IsBlob, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulo_Internalname, context.GetMessage( "Titulo", ""), "col-sm-3 AttributeTitleWWPLabel AttributeColorBaseColorLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulo_Internalname, StringUtil.RTrim( AV73Titulo), StringUtil.RTrim( context.localUtil.Format( AV73Titulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Empresa", ""), edtavTitulo_Jsonclick, 0, "AttributeTitleWWP AttributeColorBaseColor", "", "", "", "", 1, edtavTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
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
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-lg-3 CellMarginTop", "start", "top", "", "", "div");
            wb_table1_22_BV2( true) ;
         }
         else
         {
            wb_table1_22_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-lg-3 CellMarginTop", "start", "top", "", "", "div");
            wb_table2_40_BV2( true) ;
         }
         else
         {
            wb_table2_40_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table2_40_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-lg-3 CellMarginTop", "start", "top", "", "", "div");
            wb_table3_58_BV2( true) ;
         }
         else
         {
            wb_table3_58_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table3_58_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-lg-3 CellMarginTop", "start", "top", "", "", "div");
            wb_table4_76_BV2( true) ;
         }
         else
         {
            wb_table4_76_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table4_76_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaltasolicitud_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(139), 3, 0)+","+"null"+");", context.GetMessage( "Nueva Solicitud", ""), bttBtnaltasolicitud_Jsonclick, 7, context.GetMessage( "Nueva Solicitud", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11bv1_client"+"'", TempTags, "", 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmudanza_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(139), 3, 0)+","+"null"+");", context.GetMessage( "Nueva Mudanza", ""), bttBtnmudanza_Jsonclick, 7, context.GetMessage( "Nueva Mudanza", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12bv1_client"+"'", TempTags, "", 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechaini_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechaini_Internalname, context.GetMessage( "Rango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_139_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechaini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechaini_Internalname, context.localUtil.Format(AV49FechaIni, "99/99/99"), context.localUtil.Format( AV49FechaIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechaini_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechaini_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_bitmap( context, edtavFechaini_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechaini_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comercios/DashboardCOM.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_139_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechafin_Internalname, context.localUtil.Format(AV50FechaFin, "99/99/99"), context.localUtil.Format( AV50FechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechafin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_bitmap( context, edtavFechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comercios/DashboardCOM.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_139_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEstadosgenericosid, dynavEstadosgenericosid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV51EstadosGenericosID), 5, 0)), 1, dynavEstadosgenericosid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEstadosgenericosid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_Comercios/DashboardCOM.htm");
            dynavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51EstadosGenericosID), 5, 0));
            AssignProp("", false, dynavEstadosgenericosid_Internalname, "Values", (string)(dynavEstadosgenericosid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            wb_table5_121_BV2( true) ;
         }
         else
         {
            wb_table5_121_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table5_121_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl139( ) ;
         }
         if ( wbEnd == 139 )
         {
            wbEnd = 0;
            nRC_GXsfl_139 = (int)(nGXsfl_139_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV45GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV46GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV47GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            wb_table6_166_BV2( true) ;
         }
         else
         {
            wb_table6_166_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table6_166_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            wb_table7_188_BV2( true) ;
         }
         else
         {
            wb_table7_188_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table7_188_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            wb_table8_210_BV2( true) ;
         }
         else
         {
            wb_table8_210_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table8_210_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            wb_table9_232_BV2( true) ;
         }
         else
         {
            wb_table9_232_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table9_232_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-9 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridprofesionalesContainer.SetIsFreestyle(true);
            GridprofesionalesContainer.SetWrapped(nGXWrapped);
            StartGridControl259( ) ;
         }
         if ( wbEnd == 259 )
         {
            wbEnd = 0;
            nRC_GXsfl_259 = (int)(nGXsfl_259_idx-1);
            if ( GridprofesionalesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridprofesionalesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprofesionales", GridprofesionalesContainer, subGridprofesionales_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridprofesionalesContainerData", GridprofesionalesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridprofesionalesContainerData"+"V", GridprofesionalesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridprofesionalesContainerData"+"V"+"\" value='"+GridprofesionalesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm col-md-3 hidden-md CellMarginTop GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridlistaContainer.SetWrapped(nGXWrapped);
            StartGridControl294( ) ;
         }
         if ( wbEnd == 294 )
         {
            wbEnd = 0;
            nRC_GXsfl_294 = (int)(nGXsfl_294_idx-1);
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridlistaContainer.AddObjectProperty("GRIDLISTA_nEOF", GRIDLISTA_nEOF);
               GridlistaContainer.AddObjectProperty("GRIDLISTA_nFirstRecordOnPage", GRIDLISTA_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridlistaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlista", GridlistaContainer, subGridlista_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridlistaContainerData", GridlistaContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridlistaContainerData"+"V", GridlistaContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridlistaContainerData"+"V"+"\" value='"+GridlistaContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow.Render(context, "innewwindow", Innewwindow_Internalname, "INNEWWINDOWContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucNewwindow.Render(context, "innewwindow", Newwindow_Internalname, "NEWWINDOWContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridcurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45GridCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,311);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridcurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridcurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            /* User Defined Control */
            ucGridlista_titlescategories.Render(context, "dvelop.gridtitlescategories", Gridlista_titlescategories_Internalname, "GRIDLISTA_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGridlista_empowerer.SetProperty("HasCategories", Gridlista_empowerer_Hascategories);
            ucGridlista_empowerer.Render(context, "wwp.gridempowerer", Gridlista_empowerer_Internalname, "GRIDLISTA_EMPOWERERContainer");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 139 )
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
         if ( wbEnd == 259 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridprofesionalesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridprofesionalesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprofesionales", GridprofesionalesContainer, subGridprofesionales_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridprofesionalesContainerData", GridprofesionalesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridprofesionalesContainerData"+"V", GridprofesionalesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridprofesionalesContainerData"+"V"+"\" value='"+GridprofesionalesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 294 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridlistaContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridlistaContainer.AddObjectProperty("GRIDLISTA_nEOF", GRIDLISTA_nEOF);
                  GridlistaContainer.AddObjectProperty("GRIDLISTA_nFirstRecordOnPage", GRIDLISTA_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridlistaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlista", GridlistaContainer, subGridlista_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridlistaContainerData", GridlistaContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridlistaContainerData"+"V", GridlistaContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridlistaContainerData"+"V"+"\" value='"+GridlistaContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBV2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Estadísticas del Comercio", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBV0( ) ;
      }

      protected void WSBV2( )
      {
         STARTBV2( ) ;
         EVTBV2( ) ;
      }

      protected void EVTBV2( )
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
                              E13BV2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E14BV2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLISTAPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDLISTAPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridlista_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridlista_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridlista_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridlista_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
                              SubsflControlProps_1392( ) ;
                              AV48GridBadge = cgiGet( edtavGridbadge_Internalname);
                              AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
                              A182SolicitudesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSolicitudesFechaAlta_Internalname), 0));
                              n182SolicitudesFechaAlta = false;
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
                              A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
                              A184SolicitudesFechaInstalacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSolicitudesFechaInstalacion_Internalname), 0));
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n112DepartamentoId = false;
                              A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n114DepartamentoMunicipioId = false;
                              A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n110ZonasID = false;
                              A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
                              A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
                              A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
                              AV68Relacionado = cgiGet( edtavRelacionado_Internalname);
                              AssignAttri("", false, edtavRelacionado_Internalname, AV68Relacionado);
                              dynSolicitudesUsrAlta.Name = dynSolicitudesUsrAlta_Internalname;
                              dynSolicitudesUsrAlta.CurrentValue = cgiGet( dynSolicitudesUsrAlta_Internalname);
                              A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynSolicitudesUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
                              n597SolicitudesUsrAlta = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15BV2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16BV2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17BV2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Fechaini Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAINI"), 0) != AV49FechaIni )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAFIN"), 0) != AV50FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Estadosgenericosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV51EstadosGenericosID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Buscar Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBUSCAR"), AV52Buscar) != 0 )
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPROFESIONALES.LOAD") == 0 )
                           {
                              nGXsfl_259_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_259_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_259_idx), 4, 0), 4, "0");
                              SubsflControlProps_2594( ) ;
                              GXCCtl = "FEDDBACKNUM_Enabled_" + sGXsfl_259_idx;
                              Feddbacknum_Enabled = StringUtil.StrToBool( cgiGet( GXCCtl));
                              AssignProp("", false, Feddbacknum_Internalname, "Enabled", StringUtil.BoolToStr( Feddbacknum_Enabled), true);
                              GXCCtl = "FEDDBACKNUM_Captionclass_" + sGXsfl_259_idx;
                              Feddbacknum_Captionclass = cgiGet( GXCCtl);
                              AssignProp("", false, Feddbacknum_Internalname, "CaptionClass", Feddbacknum_Captionclass, true);
                              GXCCtl = "FEDDBACKNUM_Captionstyle_" + sGXsfl_259_idx;
                              Feddbacknum_Captionstyle = cgiGet( GXCCtl);
                              AssignProp("", false, Feddbacknum_Internalname, "CaptionStyle", Feddbacknum_Captionstyle, true);
                              GXCCtl = "FEDDBACKNUM_Captionposition_" + sGXsfl_259_idx;
                              Feddbacknum_Captionposition = cgiGet( GXCCtl);
                              AssignProp("", false, Feddbacknum_Internalname, "CaptionPosition", Feddbacknum_Captionposition, true);
                              GXCCtl = "FEDDBACKNUM_Enabled_" + sGXsfl_259_idx;
                              Feddbacknum_Enabled = StringUtil.StrToBool( cgiGet( GXCCtl));
                              AssignProp("", false, Feddbacknum_Internalname, "Enabled", StringUtil.BoolToStr( Feddbacknum_Enabled), true);
                              AV82Imagen = cgiGet( edtavImagen_Internalname);
                              AssignProp("", false, edtavImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV82Imagen)) ? AV92Imagen_GXI : context.convertURL( context.PathToRelativeUrl( AV82Imagen))), !bGXsfl_259_Refreshing);
                              AssignProp("", false, edtavImagen_Internalname, "SrcSet", context.GetImageSrcSet( AV82Imagen), true);
                              AV76FBSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavFbsolicitudid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, edtavFbsolicitudid_Internalname, StringUtil.LTrimStr( (decimal)(AV76FBSolicitudId), 18, 0));
                              AV86FBProfesionalNombre = cgiGet( edtavFbprofesionalnombre_Internalname);
                              AssignAttri("", false, edtavFbprofesionalnombre_Internalname, AV86FBProfesionalNombre);
                              AV79Comentario = cgiGet( edtavComentario_Internalname);
                              AssignAttri("", false, edtavComentario_Internalname, AV79Comentario);
                              AV80FechaAlta = context.localUtil.CToT( cgiGet( edtavFechaalta_Internalname), 0);
                              AssignAttri("", false, edtavFechaalta_Internalname, context.localUtil.TToC( AV80FechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                              GXCCtl = "vFEDDBACKNUM_" + sGXsfl_259_idx;
                              AV78FeddBackNum = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDPROFESIONALES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridprofesionales.Load */
                                    E18BV4 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "GRIDLISTA.LOAD") == 0 )
                           {
                              nGXsfl_294_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
                              SubsflControlProps_2943( ) ;
                              AV58Visor = cgiGet( edtavVisor_Internalname);
                              AssignAttri("", false, edtavVisor_Internalname, AV58Visor);
                              A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbListaTipo.Name = cmbListaTipo_Internalname;
                              cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
                              A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              cmbAgrupacionEstado.Name = cmbAgrupacionEstado_Internalname;
                              cmbAgrupacionEstado.CurrentValue = cgiGet( cmbAgrupacionEstado_Internalname);
                              A588AgrupacionEstado = cgiGet( cmbAgrupacionEstado_Internalname);
                              AV60GridListaBadge = cgiGet( edtavGridlistabadge_Internalname);
                              AssignAttri("", false, edtavGridlistabadge_Internalname, AV60GridListaBadge);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDLISTA.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlista.Load */
                                    E19BV3 ();
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

      protected void WEBV2( )
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

      protected void PABV2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comercios.dashboardcom.aspx")), "comercios.dashboardcom.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comercios.dashboardcom.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "inProveedorID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV66inProveedorID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV66inProveedorID", StringUtil.LTrimStr( (decimal)(AV66inProveedorID), 18, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vINPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66inProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
               GX_FocusControl = edtavTitulo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvESTADOSGENERICOSIDBV2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESTADOSGENERICOSID_dataBV2( ) ;
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

      protected void GXVvESTADOSGENERICOSID_htmlBV2( )
      {
         int gxdynajaxvalue;
         GXDLVvESTADOSGENERICOSID_dataBV2( ) ;
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

      protected void GXDLVvESTADOSGENERICOSID_dataBV2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Todos", ""));
         /* Using cursor H00BV3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            if ( StringUtil.StrCmp(H00BV3_A107EstadosTipo[0], context.GetMessage( "SOL", "")) == 0 )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00BV3_A108EstadosGenericosId[0]), 5, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( H00BV3_A109EstadosGenericosNombre[0]));
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1392( ) ;
         while ( nGXsfl_139_idx <= nRC_GXsfl_139 )
         {
            sendrow_1392( ) ;
            nGXsfl_139_idx = ((subGrid_Islastpage==1)&&(nGXsfl_139_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxnrGridlista_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2943( ) ;
         while ( nGXsfl_294_idx <= nRC_GXsfl_294 )
         {
            sendrow_2943( ) ;
            nGXsfl_294_idx = ((subGridlista_Islastpage==1)&&(nGXsfl_294_idx+1>subGridlista_fnc_Recordsperpage( )) ? 1 : nGXsfl_294_idx+1);
            sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
            SubsflControlProps_2943( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridlistaContainer)) ;
         /* End function gxnrGridlista_newrow */
      }

      protected void gxnrGridprofesionales_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2594( ) ;
         while ( nGXsfl_259_idx <= nRC_GXsfl_259 )
         {
            sendrow_2594( ) ;
            nGXsfl_259_idx = ((subGridprofesionales_Islastpage==1)&&(nGXsfl_259_idx+1>subGridprofesionales_fnc_Recordsperpage( )) ? 1 : nGXsfl_259_idx+1);
            sGXsfl_259_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_259_idx), 4, 0), 4, "0");
            SubsflControlProps_2594( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridprofesionalesContainer)) ;
         /* End function gxnrGridprofesionales_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int subGridlista_Rows ,
                                       DateTime AV49FechaIni ,
                                       DateTime AV50FechaFin ,
                                       int AV51EstadosGenericosID ,
                                       string AV52Buscar ,
                                       long AV5ProveedorID ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ,
                                       GXBaseCollection<SdtSDTFeedBack_Items> AV75SDTFeedBack ,
                                       long AV66inProveedorID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBV2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void gxgrGridprofesionales_refresh( int subGrid_Rows ,
                                                    int subGridlista_Rows ,
                                                    DateTime AV49FechaIni ,
                                                    DateTime AV50FechaFin ,
                                                    int AV51EstadosGenericosID ,
                                                    string AV52Buscar ,
                                                    GXBaseCollection<SdtSDTFeedBack_Items> AV75SDTFeedBack ,
                                                    long AV5ProveedorID ,
                                                    GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ,
                                                    long AV66inProveedorID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPROFESIONALES_nCurrentRecord = 0;
         RFBV4( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridprofesionales_refresh */
      }

      protected void gxgrGridlista_refresh( int subGrid_Rows ,
                                            int subGridlista_Rows ,
                                            DateTime AV49FechaIni ,
                                            DateTime AV50FechaFin ,
                                            int AV51EstadosGenericosID ,
                                            string AV52Buscar ,
                                            long AV5ProveedorID ,
                                            GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ,
                                            GXBaseCollection<SdtSDTFeedBack_Items> AV75SDTFeedBack ,
                                            long AV66inProveedorID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLISTA_nCurrentRecord = 0;
         RFBV3( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridlista_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvESTADOSGENERICOSID_htmlBV2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEstadosgenericosid.ItemCount > 0 )
         {
            AV51EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( dynavEstadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51EstadosGenericosID), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV51EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV51EstadosGenericosID), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51EstadosGenericosID), 5, 0));
            AssignProp("", false, dynavEstadosgenericosid_Internalname, "Values", dynavEstadosgenericosid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBV2( ) ;
         RFBV4( ) ;
         RFBV3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavTitulo_Enabled = 0;
         AssignProp("", false, edtavTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulo_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavGridbadge_Enabled = 0;
         edtavRelacionado_Enabled = 0;
         edtavCardright1_value_Enabled = 0;
         AssignProp("", false, edtavCardright1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright1_value_Enabled), 5, 0), true);
         edtavCardright1_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright1_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright1_additionaldata_Enabled), 5, 0), true);
         edtavCardright2_value_Enabled = 0;
         AssignProp("", false, edtavCardright2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright2_value_Enabled), 5, 0), true);
         edtavCardright2_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright2_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright2_additionaldata_Enabled), 5, 0), true);
         edtavCardright3_value_Enabled = 0;
         AssignProp("", false, edtavCardright3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright3_value_Enabled), 5, 0), true);
         edtavCardright3_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright3_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright3_additionaldata_Enabled), 5, 0), true);
         edtavCardright4_value_Enabled = 0;
         AssignProp("", false, edtavCardright4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright4_value_Enabled), 5, 0), true);
         edtavCardright4_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright4_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright4_additionaldata_Enabled), 5, 0), true);
         edtavFbsolicitudid_Enabled = 0;
         edtavFbprofesionalnombre_Enabled = 0;
         edtavComentario_Enabled = 0;
         edtavVisor_Enabled = 0;
         edtavGridlistabadge_Enabled = 0;
      }

      protected void RFBV2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 139;
         /* Execute user event: Refresh */
         E16BV2 ();
         nGXsfl_139_idx = 1;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1392( ) ;
         bGXsfl_139_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV51EstadosGenericosID ,
                                                 AV5ProveedorID ,
                                                 AV52Buscar ,
                                                 A131EstadosSolId ,
                                                 A133ProveedorID ,
                                                 A171SolicitudesNombre ,
                                                 A172SolicitudesTelefono ,
                                                 A127SolicitudesID ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 AV49FechaIni ,
                                                 AV50FechaFin } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
            lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
            lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
            /* Using cursor H00BV4 */
            pr_default.execute(2, new Object[] {AV5ProveedorID, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV5ProveedorID, lV52Buscar, lV52Buscar, lV52Buscar, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_139_idx = 1;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A597SolicitudesUsrAlta = H00BV4_A597SolicitudesUsrAlta[0];
               n597SolicitudesUsrAlta = H00BV4_n597SolicitudesUsrAlta[0];
               A132EstadosSolNombre = H00BV4_A132EstadosSolNombre[0];
               A131EstadosSolId = H00BV4_A131EstadosSolId[0];
               A130EstadosSolTipo = H00BV4_A130EstadosSolTipo[0];
               A113DepartamentoDepartamento = H00BV4_A113DepartamentoDepartamento[0];
               A110ZonasID = H00BV4_A110ZonasID[0];
               n110ZonasID = H00BV4_n110ZonasID[0];
               A114DepartamentoMunicipioId = H00BV4_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = H00BV4_n114DepartamentoMunicipioId[0];
               A112DepartamentoId = H00BV4_A112DepartamentoId[0];
               n112DepartamentoId = H00BV4_n112DepartamentoId[0];
               A116PaisID = H00BV4_A116PaisID[0];
               A184SolicitudesFechaInstalacion = H00BV4_A184SolicitudesFechaInstalacion[0];
               A172SolicitudesTelefono = H00BV4_A172SolicitudesTelefono[0];
               A171SolicitudesNombre = H00BV4_A171SolicitudesNombre[0];
               A282ProveedorNombre = H00BV4_A282ProveedorNombre[0];
               A133ProveedorID = H00BV4_A133ProveedorID[0];
               A127SolicitudesID = H00BV4_A127SolicitudesID[0];
               A182SolicitudesFechaAlta = H00BV4_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = H00BV4_n182SolicitudesFechaAlta[0];
               A796SolicitudesComisionMetodoPago = H00BV4_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00BV4_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00BV4_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00BV4_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00BV4_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = H00BV4_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = H00BV4_A132EstadosSolNombre[0];
               A113DepartamentoDepartamento = H00BV4_A113DepartamentoDepartamento[0];
               A116PaisID = H00BV4_A116PaisID[0];
               A282ProveedorNombre = H00BV4_A282ProveedorNombre[0];
               GetSolicitudesTotal( A127SolicitudesID) ;
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                        }
                        else
                        {
                           A211SolicitudServicioPFinal = 0;
                        }
                     }
                  }
               }
               /* Execute user event: Grid.Load */
               E17BV2 ();
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 139;
            WBBV0( ) ;
         }
         bGXsfl_139_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBV2( )
      {
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV40WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV40WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV40WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTFEEDBACK", AV75SDTFeedBack);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTFEEDBACK", AV75SDTFeedBack);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTFEEDBACK", GetSecureSignedToken( "", AV75SDTFeedBack, context));
      }

      protected void RFBV3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridlistaContainer.ClearRows();
         }
         wbStart = 294;
         /* Execute user event: Refresh */
         E16BV2 ();
         nGXsfl_294_idx = 1;
         sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
         SubsflControlProps_2943( ) ;
         bGXsfl_294_Refreshing = true;
         GridlistaContainer.AddObjectProperty("GridName", "Gridlista");
         GridlistaContainer.AddObjectProperty("CmpContext", "");
         GridlistaContainer.AddObjectProperty("InMasterPage", "false");
         GridlistaContainer.AddObjectProperty("Class", "WorkWith");
         GridlistaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridlistaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridlistaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Backcolorstyle), 1, 0, ".", "")));
         GridlistaContainer.PageSize = subGridlista_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2943( ) ;
            /* Using cursor H00BV5 */
            pr_default.execute(3);
            nGXsfl_294_idx = 1;
            sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
            SubsflControlProps_2943( ) ;
            GRIDLISTA_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRIDLISTA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ( subGridlista_Rows == 0 ) || ( GRIDLISTA_nCurrentRecord < GRIDLISTA_nFirstRecordOnPage + subGridlista_fnc_Recordsperpage( ) ) ) ) )
            {
               A133ProveedorID = H00BV5_A133ProveedorID[0];
               A282ProveedorNombre = H00BV5_A282ProveedorNombre[0];
               A588AgrupacionEstado = H00BV5_A588AgrupacionEstado[0];
               A166ProfesionalesPrimerNombre = H00BV5_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = H00BV5_A167ProfesionalesApellidoPrimero[0];
               A120ProfesionalesId = H00BV5_A120ProfesionalesId[0];
               A591ListaTipo = H00BV5_A591ListaTipo[0];
               A590Listaid = H00BV5_A590Listaid[0];
               A282ProveedorNombre = H00BV5_A282ProveedorNombre[0];
               A166ProfesionalesPrimerNombre = H00BV5_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = H00BV5_A167ProfesionalesApellidoPrimero[0];
               A591ListaTipo = H00BV5_A591ListaTipo[0];
               /* Execute user event: Gridlista.Load */
               E19BV3 ();
               pr_default.readNext(3);
            }
            GRIDLISTA_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLISTA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 294;
            WBBV0( ) ;
         }
         bGXsfl_294_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBV3( )
      {
      }

      protected void RFBV4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridprofesionalesContainer.ClearRows();
         }
         wbStart = 259;
         /* Execute user event: Refresh */
         E16BV2 ();
         nGXsfl_259_idx = 1;
         sGXsfl_259_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_259_idx), 4, 0), 4, "0");
         SubsflControlProps_2594( ) ;
         bGXsfl_259_Refreshing = true;
         GridprofesionalesContainer.AddObjectProperty("GridName", "Gridprofesionales");
         GridprofesionalesContainer.AddObjectProperty("CmpContext", "");
         GridprofesionalesContainer.AddObjectProperty("InMasterPage", "false");
         GridprofesionalesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridprofesionalesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridprofesionalesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridprofesionalesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridprofesionalesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Backcolorstyle), 1, 0, ".", "")));
         GridprofesionalesContainer.PageSize = subGridprofesionales_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2594( ) ;
            /* Execute user event: Gridprofesionales.Load */
            E18BV4 ();
            wbEnd = 259;
            WBBV0( ) ;
         }
         bGXsfl_259_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBV4( )
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
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV51EstadosGenericosID ,
                                              AV5ProveedorID ,
                                              AV52Buscar ,
                                              A131EstadosSolId ,
                                              A133ProveedorID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A127SolicitudesID ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV49FechaIni ,
                                              AV50FechaFin } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
         lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
         lV52Buscar = StringUtil.PadR( StringUtil.RTrim( AV52Buscar), 60, "%");
         /* Using cursor H00BV6 */
         pr_default.execute(4, new Object[] {AV5ProveedorID, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV5ProveedorID, lV52Buscar, lV52Buscar, lV52Buscar});
         GRID_nRecordCount = H00BV6_AGRID_nRecordCount[0];
         pr_default.close(4);
         return (int)(GRID_nRecordCount) ;
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
            gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
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
            gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
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
            gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
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
            gxgrGrid_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridlista_fnc_Pagecount( )
      {
         GRIDLISTA_nRecordCount = subGridlista_fnc_Recordcount( );
         if ( ((long)((GRIDLISTA_nRecordCount) % (subGridlista_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLISTA_nRecordCount/ (decimal)(subGridlista_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLISTA_nRecordCount/ (decimal)(subGridlista_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridlista_fnc_Recordcount( )
      {
         /* Using cursor H00BV7 */
         pr_default.execute(5);
         GRIDLISTA_nRecordCount = H00BV7_AGRIDLISTA_nRecordCount[0];
         pr_default.close(5);
         return (int)(GRIDLISTA_nRecordCount) ;
      }

      protected int subGridlista_fnc_Recordsperpage( )
      {
         if ( subGridlista_Rows > 0 )
         {
            return subGridlista_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlista_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLISTA_nFirstRecordOnPage/ (decimal)(subGridlista_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridlista_firstpage( )
      {
         GRIDLISTA_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlista_nextpage( )
      {
         GRIDLISTA_nRecordCount = subGridlista_fnc_Recordcount( );
         if ( ( GRIDLISTA_nRecordCount >= subGridlista_fnc_Recordsperpage( ) ) && ( GRIDLISTA_nEOF == 0 ) )
         {
            GRIDLISTA_nFirstRecordOnPage = (long)(GRIDLISTA_nFirstRecordOnPage+subGridlista_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, ".", "")));
         GridlistaContainer.AddObjectProperty("GRIDLISTA_nFirstRecordOnPage", GRIDLISTA_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLISTA_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlista_previouspage( )
      {
         if ( GRIDLISTA_nFirstRecordOnPage >= subGridlista_fnc_Recordsperpage( ) )
         {
            GRIDLISTA_nFirstRecordOnPage = (long)(GRIDLISTA_nFirstRecordOnPage-subGridlista_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlista_lastpage( )
      {
         GRIDLISTA_nRecordCount = subGridlista_fnc_Recordcount( );
         if ( GRIDLISTA_nRecordCount > subGridlista_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDLISTA_nRecordCount) % (subGridlista_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDLISTA_nFirstRecordOnPage = (long)(GRIDLISTA_nRecordCount-subGridlista_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDLISTA_nFirstRecordOnPage = (long)(GRIDLISTA_nRecordCount-((long)((GRIDLISTA_nRecordCount) % (subGridlista_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDLISTA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlista_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLISTA_nFirstRecordOnPage = (long)(subGridlista_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLISTA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLISTA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlista_refresh( subGrid_Rows, subGridlista_Rows, AV49FechaIni, AV50FechaFin, AV51EstadosGenericosID, AV52Buscar, AV5ProveedorID, AV40WWPContext, AV75SDTFeedBack, AV66inProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridprofesionales_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridprofesionales_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridprofesionales_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridprofesionales_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavTitulo_Enabled = 0;
         AssignProp("", false, edtavTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulo_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavGridbadge_Enabled = 0;
         edtavRelacionado_Enabled = 0;
         edtavCardright1_value_Enabled = 0;
         AssignProp("", false, edtavCardright1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright1_value_Enabled), 5, 0), true);
         edtavCardright1_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright1_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright1_additionaldata_Enabled), 5, 0), true);
         edtavCardright2_value_Enabled = 0;
         AssignProp("", false, edtavCardright2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright2_value_Enabled), 5, 0), true);
         edtavCardright2_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright2_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright2_additionaldata_Enabled), 5, 0), true);
         edtavCardright3_value_Enabled = 0;
         AssignProp("", false, edtavCardright3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright3_value_Enabled), 5, 0), true);
         edtavCardright3_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright3_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright3_additionaldata_Enabled), 5, 0), true);
         edtavCardright4_value_Enabled = 0;
         AssignProp("", false, edtavCardright4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright4_value_Enabled), 5, 0), true);
         edtavCardright4_additionaldata_Enabled = 0;
         AssignProp("", false, edtavCardright4_additionaldata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCardright4_additionaldata_Enabled), 5, 0), true);
         edtavFbsolicitudid_Enabled = 0;
         edtavFbprofesionalnombre_Enabled = 0;
         edtavComentario_Enabled = 0;
         edtavVisor_Enabled = 0;
         edtavGridlistabadge_Enabled = 0;
         GXVvESTADOSGENERICOSID_htmlBV2( ) ;
         edtSolicitudesFechaAlta_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         dynSolicitudesUsrAlta.Enabled = 0;
         edtListaid_Enabled = 0;
         cmbListaTipo.Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         cmbAgrupacionEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBV0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15BV2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vWWPCONTEXT"), AV40WWPContext);
            /* Read saved values. */
            nRC_GXsfl_139 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_139"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_259 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_259"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_294 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_294"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
            AV47GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV5ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5ProveedorID", StringUtil.LTrimStr( (decimal)(AV5ProveedorID), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
            AV89LinkMudanza = cgiGet( "vLINKMUDANZA");
            AV87SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSECUSERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV57Link = cgiGet( "vLINK");
            AV56UsrId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vUSRID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLISTA_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLISTA_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLISTA_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLISTA_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridprofesionales_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridprofesionales_Recordcount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGridlista_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLISTA_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLISTA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Rows), 6, 0, ".", "")));
            Card2_progress_Caption = cgiGet( "CARD2_PROGRESS_Caption");
            Card2_progress_Cls = cgiGet( "CARD2_PROGRESS_Cls");
            Card2_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD2_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Card1_progress_Caption = cgiGet( "CARD1_PROGRESS_Caption");
            Card1_progress_Cls = cgiGet( "CARD1_PROGRESS_Cls");
            Card1_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD1_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Card1_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD1_PROGRESS_Circlewidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Card3_progress_Caption = cgiGet( "CARD3_PROGRESS_Caption");
            Card3_progress_Cls = cgiGet( "CARD3_PROGRESS_Cls");
            Card3_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD3_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Card4_progress_Caption = cgiGet( "CARD4_PROGRESS_Caption");
            Card4_progress_Cls = cgiGet( "CARD4_PROGRESS_Cls");
            Card4_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD4_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Cardright1_progress_Type = cgiGet( "CARDRIGHT1_PROGRESS_Type");
            Cardright1_progress_Caption = cgiGet( "CARDRIGHT1_PROGRESS_Caption");
            Cardright1_progress_Cls = cgiGet( "CARDRIGHT1_PROGRESS_Cls");
            Cardright1_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARDRIGHT1_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Cardright2_progress_Type = cgiGet( "CARDRIGHT2_PROGRESS_Type");
            Cardright2_progress_Caption = cgiGet( "CARDRIGHT2_PROGRESS_Caption");
            Cardright2_progress_Cls = cgiGet( "CARDRIGHT2_PROGRESS_Cls");
            Cardright2_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARDRIGHT2_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Cardright3_progress_Type = cgiGet( "CARDRIGHT3_PROGRESS_Type");
            Cardright3_progress_Caption = cgiGet( "CARDRIGHT3_PROGRESS_Caption");
            Cardright3_progress_Cls = cgiGet( "CARDRIGHT3_PROGRESS_Cls");
            Cardright3_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARDRIGHT3_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Cardright4_progress_Type = cgiGet( "CARDRIGHT4_PROGRESS_Type");
            Cardright4_progress_Caption = cgiGet( "CARDRIGHT4_PROGRESS_Caption");
            Cardright4_progress_Cls = cgiGet( "CARDRIGHT4_PROGRESS_Cls");
            Cardright4_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARDRIGHT4_PROGRESS_Percentage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Innewwindow_Width = cgiGet( "INNEWWINDOW_Width");
            Innewwindow_Height = cgiGet( "INNEWWINDOW_Height");
            Innewwindow_Target = cgiGet( "INNEWWINDOW_Target");
            Gridlista_titlescategories_Gridinternalname = cgiGet( "GRIDLISTA_TITLESCATEGORIES_Gridinternalname");
            Gridlista_titlescategories_Gridtitlescategories = cgiGet( "GRIDLISTA_TITLESCATEGORIES_Gridtitlescategories");
            Gridlista_empowerer_Gridinternalname = cgiGet( "GRIDLISTA_EMPOWERER_Gridinternalname");
            Gridlista_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRIDLISTA_EMPOWERER_Hascategories"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGridprofesionales_Class = cgiGet( "GRIDPROFESIONALES_Class");
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV72usuariosImagen = cgiGet( imgavUsuariosimagen_Internalname);
            AV73Titulo = cgiGet( edtavTitulo_Internalname);
            AssignAttri("", false, "AV73Titulo", AV73Titulo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD2_VALUE");
               GX_FocusControl = edtavCard2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27Card2_Value = 0;
               AssignAttri("", false, "AV27Card2_Value", StringUtil.LTrimStr( (decimal)(AV27Card2_Value), 8, 0));
            }
            else
            {
               AV27Card2_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27Card2_Value", StringUtil.LTrimStr( (decimal)(AV27Card2_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD1_VALUE");
               GX_FocusControl = edtavCard1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28Card1_Value = 0;
               AssignAttri("", false, "AV28Card1_Value", StringUtil.LTrimStr( (decimal)(AV28Card1_Value), 8, 0));
            }
            else
            {
               AV28Card1_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28Card1_Value", StringUtil.LTrimStr( (decimal)(AV28Card1_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD3_VALUE");
               GX_FocusControl = edtavCard3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26Card3_Value = 0;
               AssignAttri("", false, "AV26Card3_Value", StringUtil.LTrimStr( (decimal)(AV26Card3_Value), 8, 0));
            }
            else
            {
               AV26Card3_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26Card3_Value", StringUtil.LTrimStr( (decimal)(AV26Card3_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD4_VALUE");
               GX_FocusControl = edtavCard4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25Card4_Value = 0;
               AssignAttri("", false, "AV25Card4_Value", StringUtil.LTrimStr( (decimal)(AV25Card4_Value), 8, 0));
            }
            else
            {
               AV25Card4_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25Card4_Value", StringUtil.LTrimStr( (decimal)(AV25Card4_Value), 8, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechaini_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ini", "")}), 1, "vFECHAINI");
               GX_FocusControl = edtavFechaini_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV49FechaIni = DateTime.MinValue;
               AssignAttri("", false, "AV49FechaIni", context.localUtil.Format(AV49FechaIni, "99/99/99"));
            }
            else
            {
               AV49FechaIni = context.localUtil.CToD( cgiGet( edtavFechaini_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV49FechaIni", context.localUtil.Format(AV49FechaIni, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechafin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Fin", "")}), 1, "vFECHAFIN");
               GX_FocusControl = edtavFechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV50FechaFin", context.localUtil.Format(AV50FechaFin, "99/99/99"));
            }
            else
            {
               AV50FechaFin = context.localUtil.CToD( cgiGet( edtavFechafin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV50FechaFin", context.localUtil.Format(AV50FechaFin, "99/99/99"));
            }
            dynavEstadosgenericosid.Name = dynavEstadosgenericosid_Internalname;
            dynavEstadosgenericosid.CurrentValue = cgiGet( dynavEstadosgenericosid_Internalname);
            AV51EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavEstadosgenericosid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV51EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV51EstadosGenericosID), 5, 0));
            AV52Buscar = cgiGet( edtavBuscar_Internalname);
            AssignAttri("", false, "AV52Buscar", AV52Buscar);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardright1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardright1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDRIGHT1_VALUE");
               GX_FocusControl = edtavCardright1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23CardRight1_Value = 0;
               AssignAttri("", false, "AV23CardRight1_Value", StringUtil.LTrimStr( (decimal)(AV23CardRight1_Value), 8, 0));
            }
            else
            {
               AV23CardRight1_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardright1_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23CardRight1_Value", StringUtil.LTrimStr( (decimal)(AV23CardRight1_Value), 8, 0));
            }
            AV24CardRight1_AdditionalData = cgiGet( edtavCardright1_additionaldata_Internalname);
            AssignAttri("", false, "AV24CardRight1_AdditionalData", AV24CardRight1_AdditionalData);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardright2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardright2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDRIGHT2_VALUE");
               GX_FocusControl = edtavCardright2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21CardRight2_Value = 0;
               AssignAttri("", false, "AV21CardRight2_Value", StringUtil.LTrimStr( (decimal)(AV21CardRight2_Value), 8, 0));
            }
            else
            {
               AV21CardRight2_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardright2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21CardRight2_Value", StringUtil.LTrimStr( (decimal)(AV21CardRight2_Value), 8, 0));
            }
            AV22CardRight2_AdditionalData = cgiGet( edtavCardright2_additionaldata_Internalname);
            AssignAttri("", false, "AV22CardRight2_AdditionalData", AV22CardRight2_AdditionalData);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardright3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardright3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDRIGHT3_VALUE");
               GX_FocusControl = edtavCardright3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19CardRight3_Value = 0;
               AssignAttri("", false, "AV19CardRight3_Value", StringUtil.LTrimStr( (decimal)(AV19CardRight3_Value), 8, 0));
            }
            else
            {
               AV19CardRight3_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardright3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19CardRight3_Value", StringUtil.LTrimStr( (decimal)(AV19CardRight3_Value), 8, 0));
            }
            AV20CardRight3_AdditionalData = cgiGet( edtavCardright3_additionaldata_Internalname);
            AssignAttri("", false, "AV20CardRight3_AdditionalData", AV20CardRight3_AdditionalData);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCardright4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCardright4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARDRIGHT4_VALUE");
               GX_FocusControl = edtavCardright4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17CardRight4_Value = 0;
               AssignAttri("", false, "AV17CardRight4_Value", StringUtil.LTrimStr( (decimal)(AV17CardRight4_Value), 8, 0));
            }
            else
            {
               AV17CardRight4_Value = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCardright4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17CardRight4_Value", StringUtil.LTrimStr( (decimal)(AV17CardRight4_Value), 8, 0));
            }
            AV18CardRight4_AdditionalData = cgiGet( edtavCardright4_additionaldata_Internalname);
            AssignAttri("", false, "AV18CardRight4_AdditionalData", AV18CardRight4_AdditionalData);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDCURRENTPAGE");
               GX_FocusControl = edtavGridcurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45GridCurrentPage = 0;
               AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
            }
            else
            {
               AV45GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridcurrentpage_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
            }
            /* Read subfile selected row values. */
            nGXsfl_139_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
            if ( nGXsfl_139_idx > 0 )
            {
               AV48GridBadge = cgiGet( edtavGridbadge_Internalname);
               AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
               A182SolicitudesFechaAlta = context.localUtil.CToD( cgiGet( edtSolicitudesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               n182SolicitudesFechaAlta = false;
               A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
               A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
               A184SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( edtSolicitudesFechaInstalacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               A116PaisID = cgiGet( edtPaisID_Internalname);
               A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n112DepartamentoId = false;
               A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n114DepartamentoMunicipioId = false;
               A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n110ZonasID = false;
               A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
               A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
               A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
               AV68Relacionado = cgiGet( edtavRelacionado_Internalname);
               AssignAttri("", false, edtavRelacionado_Internalname, AV68Relacionado);
               dynSolicitudesUsrAlta.Name = dynSolicitudesUsrAlta_Internalname;
               dynSolicitudesUsrAlta.CurrentValue = cgiGet( dynSolicitudesUsrAlta_Internalname);
               A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynSolicitudesUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
               n597SolicitudesUsrAlta = false;
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHAINI"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV49FechaIni ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFECHAFIN"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV50FechaFin ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV51EstadosGenericosID )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBUSCAR"), AV52Buscar) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
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
         E15BV2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15BV2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV40WWPContext) ;
         if ( AV40WWPContext.gxTpr_Proveedorid > 0 )
         {
            AV5ProveedorID = AV40WWPContext.gxTpr_Proveedorid;
            AssignAttri("", false, "AV5ProveedorID", StringUtil.LTrimStr( (decimal)(AV5ProveedorID), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
            AV72usuariosImagen = AV40WWPContext.gxTpr_Usuariosimagen;
            AssignProp("", false, imgavUsuariosimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen)) ? AV90Usuariosimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV72usuariosImagen))), true);
            AssignProp("", false, imgavUsuariosimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV72usuariosImagen), true);
            AV90Usuariosimagen_GXI = AV40WWPContext.gxTpr_Usuariosimagen_gxi;
            AssignProp("", false, imgavUsuariosimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen)) ? AV90Usuariosimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV72usuariosImagen))), true);
            AssignProp("", false, imgavUsuariosimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV72usuariosImagen), true);
            AV73Titulo = AV40WWPContext.gxTpr_Usuariosnombre;
            AssignAttri("", false, "AV73Titulo", AV73Titulo);
         }
         else
         {
            AV5ProveedorID = AV66inProveedorID;
            AssignAttri("", false, "AV5ProveedorID", StringUtil.LTrimStr( (decimal)(AV5ProveedorID), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
            if ( AV66inProveedorID == 0 )
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
            }
         }
         AV51EstadosGenericosID = 1;
         AssignAttri("", false, "AV51EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV51EstadosGenericosID), 5, 0));
         AV50FechaFin = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV50FechaFin", context.localUtil.Format(AV50FechaFin, "99/99/99"));
         AV49FechaIni = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV49FechaIni", context.localUtil.Format(AV49FechaIni, "99/99/99"));
         AV50FechaFin = DateTimeUtil.DAdd(AV50FechaFin,+((int)(15)));
         AssignAttri("", false, "AV50FechaFin", context.localUtil.Format(AV50FechaFin, "99/99/99"));
         AV49FechaIni = DateTimeUtil.DAdd(AV49FechaIni,-((int)(30)));
         AssignAttri("", false, "AV49FechaIni", context.localUtil.Format(AV49FechaIni, "99/99/99"));
         GXt_objcol_SdtSDTFeedBack_Items1 = AV75SDTFeedBack;
         new ofeedbackxpro(context ).execute(  AV5ProveedorID, out  GXt_objcol_SdtSDTFeedBack_Items1) ;
         AV75SDTFeedBack = GXt_objcol_SdtSDTFeedBack_Items1;
         GXt_SdtSDTCantSol2 = AV62SDTCantSol;
         new GeneXus.Programs.comercios.ocantsolicitudes(context ).execute(  AV5ProveedorID, out  GXt_SdtSDTCantSol2) ;
         AV62SDTCantSol = GXt_SdtSDTCantSol2;
         /* Execute user subroutine: 'CARGAR TAGS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         divTablechart1_Height = 355;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         lblReload_Caption = StringUtil.Format( "<i class='AttributeColorBaseColor fas fa-rotate' title='%1' style='font-size: 20px'></i>", context.GetMessage( "Refrescar Datos", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, lblReload_Internalname, "Caption", lblReload_Caption, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Gridlista_empowerer_Gridinternalname = subGridlista_Internalname;
         ucGridlista_empowerer.SendProperty(context, "", false, Gridlista_empowerer_Internalname, "GridInternalName", Gridlista_empowerer_Gridinternalname);
         subGridlista_Rows = 12;
         GxWebStd.gx_hidden_field( context, "GRIDLISTA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Rows), 6, 0, ".", "")));
         Gridlista_titlescategories_Gridinternalname = subGridlista_Internalname;
         ucGridlista_titlescategories.SendProperty(context, "", false, Gridlista_titlescategories_Internalname, "GridInternalName", Gridlista_titlescategories_Gridinternalname);
         Gridlista_titlescategories_Gridtitlescategories = StringUtil.Format( ";%1;%1;%1;%1;%1;%1;", context.GetMessage( "Lista Negra", ""), "", "", "", "", "", "", "", "");
         ucGridlista_titlescategories.SendProperty(context, "", false, Gridlista_titlescategories_Internalname, "GridTitlesCategories", Gridlista_titlescategories_Gridtitlescategories);
         edtavFechaalta_Visible = 0;
         AssignProp("", false, edtavFechaalta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechaalta_Visible), 5, 0), !bGXsfl_259_Refreshing);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV45GridCurrentPage = 1;
         AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         edtavGridcurrentpage_Visible = 0;
         AssignProp("", false, edtavGridcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridcurrentpage_Visible), 5, 0), true);
         AV46GridPageCount = -1;
         AssignAttri("", false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Cardright1_progress_Percentage = (int)(Math.Round(AV9CardRight1_ProgressValue, 18, MidpointRounding.ToEven));
         ucCardright1_progress.SendProperty(context, "", false, Cardright1_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Cardright1_progress_Percentage), 9, 0));
         Cardright1_progress_Caption = context.localUtil.Format( AV9CardRight1_ProgressValue, "Z9%");
         ucCardright1_progress.SendProperty(context, "", false, Cardright1_progress_Internalname, "Caption", Cardright1_progress_Caption);
         Cardright2_progress_Percentage = (int)(Math.Round(AV10CardRight2_ProgressValue, 18, MidpointRounding.ToEven));
         ucCardright2_progress.SendProperty(context, "", false, Cardright2_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Cardright2_progress_Percentage), 9, 0));
         Cardright2_progress_Caption = context.localUtil.Format( AV10CardRight2_ProgressValue, "Z9%");
         ucCardright2_progress.SendProperty(context, "", false, Cardright2_progress_Internalname, "Caption", Cardright2_progress_Caption);
         Cardright3_progress_Percentage = (int)(Math.Round(AV11CardRight3_ProgressValue, 18, MidpointRounding.ToEven));
         ucCardright3_progress.SendProperty(context, "", false, Cardright3_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Cardright3_progress_Percentage), 9, 0));
         Cardright3_progress_Caption = context.localUtil.Format( AV11CardRight3_ProgressValue, "Z9%");
         ucCardright3_progress.SendProperty(context, "", false, Cardright3_progress_Internalname, "Caption", Cardright3_progress_Caption);
         Cardright4_progress_Percentage = (int)(Math.Round(AV12CardRight4_ProgressValue, 18, MidpointRounding.ToEven));
         ucCardright4_progress.SendProperty(context, "", false, Cardright4_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Cardright4_progress_Percentage), 9, 0));
         Cardright4_progress_Caption = context.localUtil.Format( AV12CardRight4_ProgressValue, "Z9%");
         ucCardright4_progress.SendProperty(context, "", false, Cardright4_progress_Internalname, "Caption", Cardright4_progress_Caption);
         Card2_progress_Percentage = (int)(Math.Round(AV14Card2_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard2_progress.SendProperty(context, "", false, Card2_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card2_progress_Percentage), 9, 0));
         Card2_progress_Caption = context.localUtil.Format( AV14Card2_ProgressValue, "Z9%");
         ucCard2_progress.SendProperty(context, "", false, Card2_progress_Internalname, "Caption", Card2_progress_Caption);
         Card1_progress_Percentage = (int)(Math.Round(AV13Card1_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard1_progress.SendProperty(context, "", false, Card1_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card1_progress_Percentage), 9, 0));
         Card1_progress_Caption = context.localUtil.Format( AV13Card1_ProgressValue, "Z9%");
         ucCard1_progress.SendProperty(context, "", false, Card1_progress_Internalname, "Caption", Card1_progress_Caption);
         Card3_progress_Percentage = (int)(Math.Round(AV15Card3_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard3_progress.SendProperty(context, "", false, Card3_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card3_progress_Percentage), 9, 0));
         Card3_progress_Caption = context.localUtil.Format( AV15Card3_ProgressValue, "Z9%");
         ucCard3_progress.SendProperty(context, "", false, Card3_progress_Internalname, "Caption", Card3_progress_Caption);
         Card4_progress_Percentage = (int)(Math.Round(AV16Card4_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard4_progress.SendProperty(context, "", false, Card4_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card4_progress_Percentage), 9, 0));
         Card4_progress_Caption = context.localUtil.Format( AV16Card4_ProgressValue, "Z9%");
         ucCard4_progress.SendProperty(context, "", false, Card4_progress_Internalname, "Caption", Card4_progress_Caption);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV45GridCurrentPage = 1;
         AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         edtavGridcurrentpage_Visible = 0;
         AssignProp("", false, edtavGridcurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridcurrentpage_Visible), 5, 0), true);
         AV46GridPageCount = -1;
         AssignAttri("", false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         new oparametros(context ).execute(  context.GetMessage( "LIKSOLICITUDES", ""), out  AV53ParametrosValor, out  AV54ParametrosNumerico, out  AV55ParametrosEstado) ;
      }

      protected void E16BV2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E17BV2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         new orelnom(context ).execute(  A127SolicitudesID, out  AV69RelelacionadID, out  AV68Relacionado, out  AV67Existe) ;
         AssignAttri("", false, edtavRelacionado_Internalname, AV68Relacionado);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comercios.versolicitudes.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
         edtSolicitudesID_Link = formatLink("comercios.versolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( A131EstadosSolId == 1 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-check-circle FontColorIconSuccess	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Procesado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 2 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-shopping-bag FontColorIconInfoLight BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Delegado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 3 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-times-circle FontColorIconDanger BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Cancelado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 4 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-exclamation-circle FontColorIconDanger	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Rechazado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 5 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-tasks FontColorIconInfo BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Aceptada", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 6 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='far fa-star FontColorIconWarning	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Finalizado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else if ( A131EstadosSolId == 7 )
         {
            AV48GridBadge = StringUtil.Format( "<i class='fa fa-star-half-alt FontColorIconWarning BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Calificado", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         else
         {
            AV48GridBadge = "";
            AssignAttri("", false, edtavGridbadge_Internalname, AV48GridBadge);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 139;
         }
         sendrow_1392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_139_Refreshing )
         {
            context.DoAjaxLoad(139, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E13BV2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV45GridCurrentPage = (long)(AV45GridCurrentPage-1);
            AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            AV45GridCurrentPage = (long)(AV45GridCurrentPage+1);
            AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
            subgrid_nextpage( ) ;
         }
         else
         {
            AV44PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV45GridCurrentPage = AV44PageToGo;
            AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
            subgrid_gotopage( AV44PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E14BV2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV45GridCurrentPage = 1;
         AssignAttri("", false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72usuariosImagen)) && String.IsNullOrEmpty(StringUtil.RTrim( AV90Usuariosimagen_GXI)) ) ) )
         {
            imgavUsuariosimagen_Visible = 0;
            AssignProp("", false, imgavUsuariosimagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUsuariosimagen_Visible), 5, 0), true);
            divUsuariosimagen_cell_Class = "Invisible";
            AssignProp("", false, divUsuariosimagen_cell_Internalname, "Class", divUsuariosimagen_cell_Class, true);
         }
         else
         {
            imgavUsuariosimagen_Visible = 1;
            AssignProp("", false, imgavUsuariosimagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUsuariosimagen_Visible), 5, 0), true);
            divUsuariosimagen_cell_Class = "col-xs-12 col-sm-2";
            AssignProp("", false, divUsuariosimagen_cell_Internalname, "Class", divUsuariosimagen_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'CARGAR TAGS' Routine */
         returnInSub = false;
         AV28Card1_Value = (int)(AV62SDTCantSol.gxTpr_Procesadas);
         AssignAttri("", false, "AV28Card1_Value", StringUtil.LTrimStr( (decimal)(AV28Card1_Value), 8, 0));
         AV27Card2_Value = (int)(AV62SDTCantSol.gxTpr_Delegadas+AV62SDTCantSol.gxTpr_Habilitadas+AV62SDTCantSol.gxTpr_Rechazadas+AV62SDTCantSol.gxTpr_Aceptadas);
         AssignAttri("", false, "AV27Card2_Value", StringUtil.LTrimStr( (decimal)(AV27Card2_Value), 8, 0));
         AV26Card3_Value = (int)(AV62SDTCantSol.gxTpr_Finalizadas+AV62SDTCantSol.gxTpr_Calificadas);
         AssignAttri("", false, "AV26Card3_Value", StringUtil.LTrimStr( (decimal)(AV26Card3_Value), 8, 0));
         AV25Card4_Value = (int)(AV62SDTCantSol.gxTpr_Canceladas);
         AssignAttri("", false, "AV25Card4_Value", StringUtil.LTrimStr( (decimal)(AV25Card4_Value), 8, 0));
         AV23CardRight1_Value = (int)(AV62SDTCantSol.gxTpr_Total);
         AssignAttri("", false, "AV23CardRight1_Value", StringUtil.LTrimStr( (decimal)(AV23CardRight1_Value), 8, 0));
         if ( AV62SDTCantSol.gxTpr_Total > 0 )
         {
            AV13Card1_ProgressValue = (decimal)((AV28Card1_Value*100)/ (decimal)(AV62SDTCantSol.gxTpr_Total));
            AssignAttri("", false, "AV13Card1_ProgressValue", StringUtil.LTrimStr( AV13Card1_ProgressValue, 5, 2));
            AV13Card1_ProgressValue = NumberUtil.Round( AV13Card1_ProgressValue, 0);
            AssignAttri("", false, "AV13Card1_ProgressValue", StringUtil.LTrimStr( AV13Card1_ProgressValue, 5, 2));
            AV14Card2_ProgressValue = (decimal)((AV27Card2_Value*100)/ (decimal)(AV62SDTCantSol.gxTpr_Total));
            AssignAttri("", false, "AV14Card2_ProgressValue", StringUtil.LTrimStr( AV14Card2_ProgressValue, 5, 2));
            AV14Card2_ProgressValue = NumberUtil.Round( AV14Card2_ProgressValue, 0);
            AssignAttri("", false, "AV14Card2_ProgressValue", StringUtil.LTrimStr( AV14Card2_ProgressValue, 5, 2));
            AV15Card3_ProgressValue = (decimal)((AV26Card3_Value*100)/ (decimal)(AV62SDTCantSol.gxTpr_Total));
            AssignAttri("", false, "AV15Card3_ProgressValue", StringUtil.LTrimStr( AV15Card3_ProgressValue, 5, 2));
            AV15Card3_ProgressValue = NumberUtil.Round( AV15Card3_ProgressValue, 0);
            AssignAttri("", false, "AV15Card3_ProgressValue", StringUtil.LTrimStr( AV15Card3_ProgressValue, 5, 2));
            AV16Card4_ProgressValue = (decimal)((AV25Card4_Value*100)/ (decimal)(AV62SDTCantSol.gxTpr_Total));
            AssignAttri("", false, "AV16Card4_ProgressValue", StringUtil.LTrimStr( AV16Card4_ProgressValue, 5, 2));
            AV16Card4_ProgressValue = NumberUtil.Round( AV16Card4_ProgressValue, 0);
            AssignAttri("", false, "AV16Card4_ProgressValue", StringUtil.LTrimStr( AV16Card4_ProgressValue, 5, 2));
         }
         AV9CardRight1_ProgressValue = (decimal)(100);
         AssignAttri("", false, "AV9CardRight1_ProgressValue", StringUtil.LTrimStr( AV9CardRight1_ProgressValue, 5, 2));
         AV21CardRight2_Value = (int)(Math.Round(AV62SDTCantSol.gxTpr_Totalgenerado, 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21CardRight2_Value", StringUtil.LTrimStr( (decimal)(AV21CardRight2_Value), 8, 0));
         AV10CardRight2_ProgressValue = (decimal)(100);
         AssignAttri("", false, "AV10CardRight2_ProgressValue", StringUtil.LTrimStr( AV10CardRight2_ProgressValue, 5, 2));
         AV19CardRight3_Value = (int)(Math.Round(AV62SDTCantSol.gxTpr_Mesanterior, 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19CardRight3_Value", StringUtil.LTrimStr( (decimal)(AV19CardRight3_Value), 8, 0));
         AV11CardRight3_ProgressValue = (decimal)(95);
         AssignAttri("", false, "AV11CardRight3_ProgressValue", StringUtil.LTrimStr( AV11CardRight3_ProgressValue, 5, 2));
         AV17CardRight4_Value = (int)(Math.Round(AV62SDTCantSol.gxTpr_Mesactual, 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV17CardRight4_Value", StringUtil.LTrimStr( (decimal)(AV17CardRight4_Value), 8, 0));
         AV12CardRight4_ProgressValue = (decimal)(50);
         AssignAttri("", false, "AV12CardRight4_ProgressValue", StringUtil.LTrimStr( AV12CardRight4_ProgressValue, 5, 2));
      }

      private void E19BV3( )
      {
         /* Gridlista_Load Routine */
         returnInSub = false;
         if ( A133ProveedorID == AV5ProveedorID )
         {
            AV73Titulo = ((AV40WWPContext.gxTpr_Proveedorid==0) ? A282ProveedorNombre : AV40WWPContext.gxTpr_Usuariosnombre);
            AssignAttri("", false, "AV73Titulo", AV73Titulo);
            AV58Visor = "<i class=\"fas fa-book-open-reader\"></i>";
            AssignAttri("", false, edtavVisor_Internalname, AV58Visor);
            edtavVisor_Link = formatLink("comercios.listanegracom.aspx") ;
            if ( StringUtil.StrCmp(A588AgrupacionEstado, "PEN") == 0 )
            {
               AV60GridListaBadge = StringUtil.Format( "<i class='fa fa-hourglass-start FontColorIcon	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Pendiente", ""), "", "", "", "", "", "", "", "");
               AssignAttri("", false, edtavGridlistabadge_Internalname, AV60GridListaBadge);
            }
            else if ( StringUtil.StrCmp(A588AgrupacionEstado, "VIN") == 0 )
            {
               AV60GridListaBadge = StringUtil.Format( "<i class='fa fa-exclamation-circle FontColorIconDanger	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Denunciado", ""), "", "", "", "", "", "", "", "");
               AssignAttri("", false, edtavGridlistabadge_Internalname, AV60GridListaBadge);
            }
            else
            {
               AV60GridListaBadge = "";
               AssignAttri("", false, edtavGridlistabadge_Internalname, AV60GridListaBadge);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 294;
            }
            if ( ( subGridlista_Islastpage == 1 ) || ( subGridlista_Rows == 0 ) || ( ( GRIDLISTA_nCurrentRecord >= GRIDLISTA_nFirstRecordOnPage ) && ( GRIDLISTA_nCurrentRecord < GRIDLISTA_nFirstRecordOnPage + subGridlista_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_2943( ) ;
            }
            GRIDLISTA_nCurrentRecord = (long)(GRIDLISTA_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_294_Refreshing )
            {
               context.DoAjaxLoad(294, GridlistaRow);
            }
         }
         /*  Sending Event outputs  */
      }

      private void E18BV4( )
      {
         /* Gridprofesionales_Load Routine */
         returnInSub = false;
         AV91GXV1 = 1;
         while ( AV91GXV1 <= AV75SDTFeedBack.Count )
         {
            AV81Item = ((SdtSDTFeedBack_Items)AV75SDTFeedBack.Item(AV91GXV1));
            AV82Imagen = AV81Item.gxTpr_Imagen;
            AssignAttri("", false, edtavImagen_Internalname, AV82Imagen);
            AV92Imagen_GXI = AV81Item.gxTpr_Imagen_gxi;
            AV86FBProfesionalNombre = AV81Item.gxTpr_Profesionalnombre;
            AssignAttri("", false, edtavFbprofesionalnombre_Internalname, AV86FBProfesionalNombre);
            AV76FBSolicitudId = AV81Item.gxTpr_Feedbacksolicitudid;
            AssignAttri("", false, edtavFbsolicitudid_Internalname, StringUtil.LTrimStr( (decimal)(AV76FBSolicitudId), 18, 0));
            AV79Comentario = AV81Item.gxTpr_Feedbackcomentario;
            AssignAttri("", false, edtavComentario_Internalname, AV79Comentario);
            AV80FechaAlta = DateTimeUtil.ResetTime( AV81Item.gxTpr_Feedbackfechaalta ) ;
            AssignAttri("", false, edtavFechaalta_Internalname, context.localUtil.TToC( AV80FechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV78FeddBackNum = AV81Item.gxTpr_Feedbacknum;
            AssignAttri("", false, "AV78FeddBackNum", StringUtil.LTrimStr( (decimal)(AV78FeddBackNum), 10, 0));
            AV82Imagen = AV81Item.gxTpr_Imagen;
            AssignAttri("", false, edtavImagen_Internalname, AV82Imagen);
            AV92Imagen_GXI = AV81Item.gxTpr_Imagen_gxi;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 259;
            }
            sendrow_2594( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_259_Refreshing )
            {
               context.DoAjaxLoad(259, GridprofesionalesRow);
            }
            AV91GXV1 = (int)(AV91GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table9_232_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardright4_maintable_Internalname, tblCardright4_maintable_Internalname, "", "TableCardProgressAdminInfo", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCellIcon'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright4_icon_Internalname, context.GetMessage( "<i class='ProgressAdminCardIcon fas fa-piggy-bank' style='font-size: 45px'></i>", ""), "", "", lblCardright4_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardright4_tableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright4_description_Internalname, context.GetMessage( "Actual Mes", ""), "", "", lblCardright4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressAdminCardTitle", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright4_value_Internalname, context.GetMessage( "Card Right4_Value", ""), "col-sm-3 ProgressAdminCardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17CardRight4_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardright4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17CardRight4_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV17CardRight4_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright4_value_Jsonclick, 0, "ProgressAdminCardNumber", "", "", "", "", 1, edtavCardright4_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCardright4_progress.SetProperty("Type", Cardright4_progress_Type);
            ucCardright4_progress.SetProperty("Caption", Cardright4_progress_Caption);
            ucCardright4_progress.SetProperty("Cls", Cardright4_progress_Cls);
            ucCardright4_progress.SetProperty("Percentage", Cardright4_progress_Percentage);
            ucCardright4_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Cardright4_progress_Internalname, "CARDRIGHT4_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright4_additionaldata_Internalname, context.GetMessage( "Card Right4_Additional Data", ""), "col-sm-3 ProgressAdminCardDescriptionLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright4_additionaldata_Internalname, AV18CardRight4_AdditionalData, StringUtil.RTrim( context.localUtil.Format( AV18CardRight4_AdditionalData, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright4_additionaldata_Jsonclick, 0, "ProgressAdminCardDescription", "", "", "", "", 1, edtavCardright4_additionaldata_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_232_BV2e( true) ;
         }
         else
         {
            wb_table9_232_BV2e( false) ;
         }
      }

      protected void wb_table8_210_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardright3_maintable_Internalname, tblCardright3_maintable_Internalname, "", "TableCardProgressAdminInfo", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCellIcon'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright3_icon_Internalname, context.GetMessage( "<i class='ProgressAdminCardIcon fas fa-coins' style='font-size: 45px'></i>", ""), "", "", lblCardright3_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardright3_tableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright3_description_Internalname, context.GetMessage( "Ultimo Mes", ""), "", "", lblCardright3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressAdminCardTitle", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright3_value_Internalname, context.GetMessage( "Card Right3_Value", ""), "col-sm-3 ProgressAdminCardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19CardRight3_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardright3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19CardRight3_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV19CardRight3_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,222);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright3_value_Jsonclick, 0, "ProgressAdminCardNumber", "", "", "", "", 1, edtavCardright3_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCardright3_progress.SetProperty("Type", Cardright3_progress_Type);
            ucCardright3_progress.SetProperty("Caption", Cardright3_progress_Caption);
            ucCardright3_progress.SetProperty("Cls", Cardright3_progress_Cls);
            ucCardright3_progress.SetProperty("Percentage", Cardright3_progress_Percentage);
            ucCardright3_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Cardright3_progress_Internalname, "CARDRIGHT3_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright3_additionaldata_Internalname, context.GetMessage( "Card Right3_Additional Data", ""), "col-sm-3 ProgressAdminCardDescriptionLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright3_additionaldata_Internalname, AV20CardRight3_AdditionalData, StringUtil.RTrim( context.localUtil.Format( AV20CardRight3_AdditionalData, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright3_additionaldata_Jsonclick, 0, "ProgressAdminCardDescription", "", "", "", "", 1, edtavCardright3_additionaldata_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_210_BV2e( true) ;
         }
         else
         {
            wb_table8_210_BV2e( false) ;
         }
      }

      protected void wb_table7_188_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardright2_maintable_Internalname, tblCardright2_maintable_Internalname, "", "TableCardProgressAdminInfo", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCellIcon'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright2_icon_Internalname, context.GetMessage( "<i class='ProgressAdminCardIcon fas fa-building-columns' style='font-size: 45px'></i>", ""), "", "", lblCardright2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardright2_tableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright2_description_Internalname, context.GetMessage( "Total Generado", ""), "", "", lblCardright2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressAdminCardTitle", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright2_value_Internalname, context.GetMessage( "Card Right2_Value", ""), "col-sm-3 ProgressAdminCardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21CardRight2_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardright2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21CardRight2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV21CardRight2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,200);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright2_value_Jsonclick, 0, "ProgressAdminCardNumber", "", "", "", "", 1, edtavCardright2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCardright2_progress.SetProperty("Type", Cardright2_progress_Type);
            ucCardright2_progress.SetProperty("Caption", Cardright2_progress_Caption);
            ucCardright2_progress.SetProperty("Cls", Cardright2_progress_Cls);
            ucCardright2_progress.SetProperty("Percentage", Cardright2_progress_Percentage);
            ucCardright2_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Cardright2_progress_Internalname, "CARDRIGHT2_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright2_additionaldata_Internalname, context.GetMessage( "Card Right2_Additional Data", ""), "col-sm-3 ProgressAdminCardDescriptionLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright2_additionaldata_Internalname, AV22CardRight2_AdditionalData, StringUtil.RTrim( context.localUtil.Format( AV22CardRight2_AdditionalData, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright2_additionaldata_Jsonclick, 0, "ProgressAdminCardDescription", "", "", "", "", 1, edtavCardright2_additionaldata_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_188_BV2e( true) ;
         }
         else
         {
            wb_table7_188_BV2e( false) ;
         }
      }

      protected void wb_table6_166_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCardright1_maintable_Internalname, tblCardright1_maintable_Internalname, "", "TableCardProgressAdminBaseColor", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCellIcon'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright1_icon_Internalname, context.GetMessage( "<i class='ProgressAdminCardIcon fas fa-bell-concierge' style='font-size: 45px'></i>", ""), "", "", lblCardright1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressAdminCardCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCardright1_tableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCardright1_description_Internalname, context.GetMessage( "TOTAL SOLICITUDES", ""), "", "", lblCardright1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "ProgressAdminCardTitle", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright1_value_Internalname, context.GetMessage( "Card Right1_Value", ""), "col-sm-3 ProgressAdminCardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23CardRight1_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCardright1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23CardRight1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV23CardRight1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright1_value_Jsonclick, 0, "ProgressAdminCardNumber", "", "", "", "", 1, edtavCardright1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCardright1_progress.SetProperty("Type", Cardright1_progress_Type);
            ucCardright1_progress.SetProperty("Caption", Cardright1_progress_Caption);
            ucCardright1_progress.SetProperty("Cls", Cardright1_progress_Cls);
            ucCardright1_progress.SetProperty("Percentage", Cardright1_progress_Percentage);
            ucCardright1_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Cardright1_progress_Internalname, "CARDRIGHT1_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCardright1_additionaldata_Internalname, context.GetMessage( "Card Right1_Additional Data", ""), "col-sm-3 ProgressAdminCardDescriptionLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCardright1_additionaldata_Internalname, AV24CardRight1_AdditionalData, StringUtil.RTrim( context.localUtil.Format( AV24CardRight1_AdditionalData, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCardright1_additionaldata_Jsonclick, 0, "ProgressAdminCardDescription", "", "", "", "", 1, edtavCardright1_additionaldata_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_166_BV2e( true) ;
         }
         else
         {
            wb_table6_166_BV2e( false) ;
         }
      }

      protected void wb_table5_121_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table10_124_BV2( true) ;
         }
         else
         {
            wb_table10_124_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table10_124_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_121_BV2e( true) ;
         }
         else
         {
            wb_table5_121_BV2e( false) ;
         }
      }

      protected void wb_table10_124_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtablefilters_Internalname, tblTablemergedtablefilters_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            wb_table11_127_BV2( true) ;
         }
         else
         {
            wb_table11_127_BV2( false) ;
         }
         return  ;
      }

      protected void wb_table11_127_BV2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblReload_Internalname, lblReload_Caption, "", "", lblReload_Jsonclick, "'"+""+"'"+",false,"+"'"+"e20bv1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_124_BV2e( true) ;
         }
         else
         {
            wb_table10_124_BV2e( false) ;
         }
      }

      protected void wb_table11_127_BV2( bool wbgen )
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
            GxWebStd.gx_label_element( context, edtavBuscar_Internalname, context.GetMessage( "Buscar", ""), "gx-form-item AttributeSearchResultImageLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBuscar_Internalname, StringUtil.RTrim( AV52Buscar), StringUtil.RTrim( context.localUtil.Format( AV52Buscar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Buscar Solicitud", ""), edtavBuscar_Jsonclick, 0, "AttributeSearchResultImage", "", "", "", "", 1, edtavBuscar_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table11_127_BV2e( true) ;
         }
         else
         {
            wb_table11_127_BV2e( false) ;
         }
      }

      protected void wb_table4_76_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard4_maintable_Internalname, tblCard4_maintable_Internalname, "", "TableCardProgressAdminDanger", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressCardCell'>") ;
            /* User Defined Control */
            ucCard4_progress.SetProperty("Caption", Card4_progress_Caption);
            ucCard4_progress.SetProperty("Cls", Card4_progress_Cls);
            ucCard4_progress.SetProperty("Percentage", Card4_progress_Percentage);
            ucCard4_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card4_progress_Internalname, "CARD4_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressCardContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_tablep_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_tablepcontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard4_value_Internalname, context.GetMessage( "Card4_Value", ""), "col-sm-3 DashboardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Card4_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCard4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25Card4_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV25Card4_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard4_value_Jsonclick, 0, "DashboardNumber", "", "", "", "", 1, edtavCard4_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_description_Internalname, context.GetMessage( "Solicitudes Canceladas", ""), "", "", lblCard4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescription", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-plane-slash' style='font-size: 19px'></i>", ""), "", "", lblCard4_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_76_BV2e( true) ;
         }
         else
         {
            wb_table4_76_BV2e( false) ;
         }
      }

      protected void wb_table3_58_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard3_maintable_Internalname, tblCard3_maintable_Internalname, "", "TableCardProgressAdminWarning", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressCardCell'>") ;
            /* User Defined Control */
            ucCard3_progress.SetProperty("Caption", Card3_progress_Caption);
            ucCard3_progress.SetProperty("Cls", Card3_progress_Cls);
            ucCard3_progress.SetProperty("Percentage", Card3_progress_Percentage);
            ucCard3_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card3_progress_Internalname, "CARD3_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressCardContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_tablep_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_tablepcontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard3_value_Internalname, context.GetMessage( "Card3_Value", ""), "col-sm-3 DashboardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Card3_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCard3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26Card3_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV26Card3_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard3_value_Jsonclick, 0, "DashboardNumber", "", "", "", "", 1, edtavCard3_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_description_Internalname, context.GetMessage( "Trabajos Finalizados", ""), "", "", lblCard3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescription", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-star' style='font-size: 19px'></i>", ""), "", "", lblCard3_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_58_BV2e( true) ;
         }
         else
         {
            wb_table3_58_BV2e( false) ;
         }
      }

      protected void wb_table2_40_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard1_maintable_Internalname, tblCard1_maintable_Internalname, "", "TableCardProgressAdminInfo", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressCardCell'>") ;
            /* User Defined Control */
            ucCard1_progress.SetProperty("Caption", Card1_progress_Caption);
            ucCard1_progress.SetProperty("Cls", Card1_progress_Cls);
            ucCard1_progress.SetProperty("Percentage", Card1_progress_Percentage);
            ucCard1_progress.SetProperty("CircleWidth", Card1_progress_Circlewidth);
            ucCard1_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card1_progress_Internalname, "CARD1_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressCardContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_tablep_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_tablepcontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard1_value_Internalname, context.GetMessage( "Card1_Value", ""), "col-sm-3 DashboardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Card1_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCard1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28Card1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV28Card1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard1_value_Jsonclick, 0, "DashboardNumber", "", "", "", "", 1, edtavCard1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_description_Internalname, context.GetMessage( "Pendientes de Procesar", ""), "", "", lblCard1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescription", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_icon_Internalname, context.GetMessage( "<i class='AttributeColorInfo fas fa-bell-concierge' style='font-size: 19px'></i>", ""), "", "", lblCard1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_40_BV2e( true) ;
         }
         else
         {
            wb_table2_40_BV2e( false) ;
         }
      }

      protected void wb_table1_22_BV2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard2_maintable_Internalname, tblCard2_maintable_Internalname, "", "TableCardProgressAdminSuccess", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='ProgressCardCell'>") ;
            /* User Defined Control */
            ucCard2_progress.SetProperty("Caption", Card2_progress_Caption);
            ucCard2_progress.SetProperty("Cls", Card2_progress_Cls);
            ucCard2_progress.SetProperty("Percentage", Card2_progress_Percentage);
            ucCard2_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card2_progress_Internalname, "CARD2_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='ProgressCardContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_tablep_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_tablepcontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard2_value_Internalname, context.GetMessage( "Card2_Value", ""), "col-sm-3 DashboardNumberLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Card2_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCard2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27Card2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV27Card2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard2_value_Jsonclick, 0, "DashboardNumber", "", "", "", "", 1, edtavCard2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "end", false, "", "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_description_Internalname, context.GetMessage( "Trabajo en Curso", ""), "", "", lblCard2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescription", 0, "", 1, 1, 0, 0, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-house-laptop' style='font-size: 19px'></i>", ""), "", "", lblCard2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Comercios/DashboardCOM.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_BV2e( true) ;
         }
         else
         {
            wb_table1_22_BV2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV66inProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV66inProveedorID", StringUtil.LTrimStr( (decimal)(AV66inProveedorID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vINPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66inProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PABV2( ) ;
         WSBV2( ) ;
         WEBV2( ) ;
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
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("Rating/rating.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026980412144", true, true, false);
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
            context.AddJavascriptSource("comercios/dashboardcom.js", "?2026980412145", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
            context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
            context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
            context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
            context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1392( )
      {
         edtavGridbadge_Internalname = "vGRIDBADGE_"+sGXsfl_139_idx;
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA_"+sGXsfl_139_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_139_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_139_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_139_idx;
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE_"+sGXsfl_139_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_139_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_139_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_139_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_139_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_139_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_139_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_139_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_139_idx;
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO_"+sGXsfl_139_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_139_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_139_idx;
         edtavRelacionado_Internalname = "vRELACIONADO_"+sGXsfl_139_idx;
         dynSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA_"+sGXsfl_139_idx;
      }

      protected void SubsflControlProps_fel_1392( )
      {
         edtavGridbadge_Internalname = "vGRIDBADGE_"+sGXsfl_139_fel_idx;
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA_"+sGXsfl_139_fel_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_139_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_139_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_139_fel_idx;
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE_"+sGXsfl_139_fel_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_139_fel_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_139_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_139_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_139_fel_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_139_fel_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_139_fel_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_139_fel_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_139_fel_idx;
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO_"+sGXsfl_139_fel_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_139_fel_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_139_fel_idx;
         edtavRelacionado_Internalname = "vRELACIONADO_"+sGXsfl_139_fel_idx;
         dynSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA_"+sGXsfl_139_fel_idx;
      }

      protected void sendrow_1392( )
      {
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1392( ) ;
         WBBV0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_139_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_139_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_139_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_139_idx + "',139)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridbadge_Internalname,(string)AV48GridBadge,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridbadge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TagColumn",(string)"",(short)-1,(int)edtavGridbadge_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)1,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaAlta_Internalname,context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"),context.localUtil.Format( A182SolicitudesFechaAlta, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSolicitudesID_Link,(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesNombre_Internalname,StringUtil.RTrim( A171SolicitudesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesTelefono_Internalname,StringUtil.RTrim( A172SolicitudesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"598 099 999999",(string)edtSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaInstalacion_Internalname,context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"),context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaInstalacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtZonasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Seleccione su Zona", ""),(string)edtZonasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoDepartamento_Internalname,StringUtil.RTrim( A113DepartamentoDepartamento),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoDepartamento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolTipo_Internalname,StringUtil.RTrim( A130EstadosSolTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolNombre_Internalname,StringUtil.RTrim( A132EstadosSolNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_139_idx + "',139)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRelacionado_Internalname,StringUtil.RTrim( AV68Relacionado),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRelacionado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavRelacionado_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynSolicitudesUsrAlta.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDESUSRALTA_" + sGXsfl_139_idx;
               dynSolicitudesUsrAlta.Name = GXCCtl;
               dynSolicitudesUsrAlta.WebTags = "";
               dynSolicitudesUsrAlta.removeAllItems();
               /* Using cursor H00BV8 */
               pr_default.execute(6);
               while ( (pr_default.getStatus(6) != 101) )
               {
                  dynSolicitudesUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BV8_A18SecUserId[0]), 10, 0)), H00BV8_A26SecUserName[0], 0);
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               if ( dynSolicitudesUsrAlta.ItemCount > 0 )
               {
                  A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
                  n597SolicitudesUsrAlta = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynSolicitudesUsrAlta,(string)dynSolicitudesUsrAlta_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0)),(short)1,(string)dynSolicitudesUsrAlta_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynSolicitudesUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0));
            AssignProp("", false, dynSolicitudesUsrAlta_Internalname, "Values", (string)(dynSolicitudesUsrAlta.ToJavascriptSource()), !bGXsfl_139_Refreshing);
            send_integrity_lvl_hashesBV2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_139_idx = ((subGrid_Islastpage==1)&&(nGXsfl_139_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
         }
         /* End function sendrow_1392 */
      }

      protected void SubsflControlProps_2594( )
      {
         edtavImagen_Internalname = "vIMAGEN_"+sGXsfl_259_idx;
         edtavFbsolicitudid_Internalname = "vFBSOLICITUDID_"+sGXsfl_259_idx;
         edtavFbprofesionalnombre_Internalname = "vFBPROFESIONALNOMBRE_"+sGXsfl_259_idx;
         edtavComentario_Internalname = "vCOMENTARIO_"+sGXsfl_259_idx;
         Feddbacknum_Internalname = "FEDDBACKNUM_"+sGXsfl_259_idx;
         edtavFechaalta_Internalname = "vFECHAALTA_"+sGXsfl_259_idx;
      }

      protected void SubsflControlProps_fel_2594( )
      {
         edtavImagen_Internalname = "vIMAGEN_"+sGXsfl_259_fel_idx;
         edtavFbsolicitudid_Internalname = "vFBSOLICITUDID_"+sGXsfl_259_fel_idx;
         edtavFbprofesionalnombre_Internalname = "vFBPROFESIONALNOMBRE_"+sGXsfl_259_fel_idx;
         edtavComentario_Internalname = "vCOMENTARIO_"+sGXsfl_259_fel_idx;
         Feddbacknum_Internalname = "FEDDBACKNUM_"+sGXsfl_259_fel_idx;
         edtavFechaalta_Internalname = "vFECHAALTA_"+sGXsfl_259_fel_idx;
      }

      protected void sendrow_2594( )
      {
         sGXsfl_259_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_259_idx), 4, 0), 4, "0");
         SubsflControlProps_2594( ) ;
         WBBV0( ) ;
         GridprofesionalesRow = GXWebRow.GetNew(context,GridprofesionalesContainer);
         if ( subGridprofesionales_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridprofesionales_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridprofesionales_Class, "") != 0 )
            {
               subGridprofesionales_Linesclass = subGridprofesionales_Class+"Odd";
            }
         }
         else if ( subGridprofesionales_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridprofesionales_Backstyle = 0;
            subGridprofesionales_Backcolor = subGridprofesionales_Allbackcolor;
            if ( StringUtil.StrCmp(subGridprofesionales_Class, "") != 0 )
            {
               subGridprofesionales_Linesclass = subGridprofesionales_Class+"Uniform";
            }
         }
         else if ( subGridprofesionales_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridprofesionales_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridprofesionales_Class, "") != 0 )
            {
               subGridprofesionales_Linesclass = subGridprofesionales_Class+"Odd";
            }
            subGridprofesionales_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridprofesionales_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridprofesionales_Backstyle = 1;
            if ( ((int)((nGXsfl_259_idx) % (2))) == 0 )
            {
               subGridprofesionales_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridprofesionales_Class, "") != 0 )
               {
                  subGridprofesionales_Linesclass = subGridprofesionales_Class+"Even";
               }
            }
            else
            {
               subGridprofesionales_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridprofesionales_Class, "") != 0 )
               {
                  subGridprofesionales_Linesclass = subGridprofesionales_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridprofesionales_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_259_idx+"\">") ;
         }
         /* Table start */
         GridprofesionalesRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblGridprofesionaleslayouttable_Internalname+"_"+sGXsfl_259_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_259_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Attribute/Variable Label */
         GridprofesionalesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",context.GetMessage( "Imagen", ""),(string)"col-sm-3 RoundedImageLabel StepImageUnSelectedLabel",(short)0,(bool)true,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Static Bitmap Variable */
         ClassString = "RoundedImage StepImageUnSelected" + " " + ((StringUtil.StrCmp(edtavImagen_gximage, "")==0) ? "" : "GX_Image_"+edtavImagen_gximage+"_Class");
         StyleString = "";
         AV82Imagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV82Imagen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV92Imagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV82Imagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV82Imagen)) ? AV92Imagen_GXI : context.PathToRelativeUrl( AV82Imagen));
         GridprofesionalesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV82Imagen_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Attribute/Variable Label */
         GridprofesionalesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavFbsolicitudid_Internalname,context.GetMessage( "FBSolicitud Id", ""),(string)"col-sm-3 ActionAttributeLabel",(short)0,(bool)true,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'',false,'" + sGXsfl_259_idx + "',259)\"";
         ROClassString = "ActionAttribute";
         GridprofesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFbsolicitudid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76FBSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavFbsolicitudid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV76FBSolicitudId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV76FBSolicitudId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,271);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFbsolicitudid_Jsonclick,(short)0,(string)"ActionAttribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavFbsolicitudid_Enabled,(short)0,(string)"text",(string)"1",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)259,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("cell");
         }
         GridprofesionalesRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable3_Internalname+"_"+sGXsfl_259_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Attribute/Variable Label */
         GridprofesionalesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavFbprofesionalnombre_Internalname,context.GetMessage( "FBProfesional Nombre", ""),(string)"col-sm-3 AttributeSizeLargeLabel",(short)0,(bool)true,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 277,'',false,'" + sGXsfl_259_idx + "',259)\"";
         ROClassString = "AttributeSizeLarge";
         GridprofesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFbprofesionalnombre_Internalname,StringUtil.RTrim( AV86FBProfesionalNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,277);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFbprofesionalnombre_Jsonclick,(short)0,(string)"AttributeSizeLarge",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavFbprofesionalnombre_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)259,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Attribute/Variable Label */
         GridprofesionalesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavComentario_Internalname,context.GetMessage( "Comentario", ""),(string)"col-sm-3 ReadonlyAttributeLabel",(short)0,(bool)true,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'" + sGXsfl_259_idx + "',259)\"";
         ClassString = "ReadonlyAttribute";
         StyleString = "";
         ClassString = "ReadonlyAttribute";
         StyleString = "";
         GridprofesionalesRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavComentario_Internalname,(string)AV79Comentario,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,281);\"",(short)0,(short)1,(int)edtavComentario_Enabled,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* User Defined Control */
         GridprofesionalesRow.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)"FEDDBACKNUMContainer"+"_"+sGXsfl_259_idx,(short)-1});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("cell");
         }
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("row");
         }
         GridprofesionalesRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)"Invisible"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Table start */
         GridprofesionalesRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridprofesionales_Internalname+"_"+sGXsfl_259_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         sendrow_259430( ) ;
      }

      protected void sendrow_259430( )
      {
         /* Div Control */
         GridprofesionalesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Attribute/Variable Label */
         GridprofesionalesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavFechaalta_Internalname,context.GetMessage( "Fecha Alta", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         GridprofesionalesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFechaalta_Internalname,context.localUtil.TToC( AV80FechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( AV80FechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFechaalta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtavFechaalta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)259,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         GridprofesionalesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridprofesionalesRow.AddRenderProperties(GridprofesionalesColumn);
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("cell");
         }
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("row");
         }
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("table");
         }
         /* End of table */
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("cell");
         }
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("row");
         }
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            GridprofesionalesContainer.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashesBV4( ) ;
         GXCCtl = "vFEDDBACKNUM_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78FeddBackNum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "FEDDBACKNUM_Enabled_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Feddbacknum_Enabled));
         GXCCtl = "FEDDBACKNUM_Captionclass_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Feddbacknum_Captionclass));
         GXCCtl = "FEDDBACKNUM_Captionstyle_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Feddbacknum_Captionstyle));
         GXCCtl = "FEDDBACKNUM_Captionposition_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Feddbacknum_Captionposition));
         GXCCtl = "FEDDBACKNUM_Enabled_" + sGXsfl_259_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.BoolToStr( Feddbacknum_Enabled));
         /* End of Columns property logic. */
         GridprofesionalesContainer.AddRow(GridprofesionalesRow);
         nGXsfl_259_idx = ((subGridprofesionales_Islastpage==1)&&(nGXsfl_259_idx+1>subGridprofesionales_fnc_Recordsperpage( )) ? 1 : nGXsfl_259_idx+1);
         sGXsfl_259_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_259_idx), 4, 0), 4, "0");
         SubsflControlProps_2594( ) ;
         /* End function sendrow_2594 */
      }

      protected void SubsflControlProps_2943( )
      {
         edtavVisor_Internalname = "vVISOR_"+sGXsfl_294_idx;
         edtListaid_Internalname = "LISTAID_"+sGXsfl_294_idx;
         cmbListaTipo_Internalname = "LISTATIPO_"+sGXsfl_294_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_294_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_294_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_294_idx;
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO_"+sGXsfl_294_idx;
         edtavGridlistabadge_Internalname = "vGRIDLISTABADGE_"+sGXsfl_294_idx;
      }

      protected void SubsflControlProps_fel_2943( )
      {
         edtavVisor_Internalname = "vVISOR_"+sGXsfl_294_fel_idx;
         edtListaid_Internalname = "LISTAID_"+sGXsfl_294_fel_idx;
         cmbListaTipo_Internalname = "LISTATIPO_"+sGXsfl_294_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_294_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_294_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_294_fel_idx;
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO_"+sGXsfl_294_fel_idx;
         edtavGridlistabadge_Internalname = "vGRIDLISTABADGE_"+sGXsfl_294_fel_idx;
      }

      protected void sendrow_2943( )
      {
         sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
         SubsflControlProps_2943( ) ;
         WBBV0( ) ;
         if ( ( subGridlista_Rows * 1 == 0 ) || ( nGXsfl_294_idx <= subGridlista_fnc_Recordsperpage( ) * 1 ) )
         {
            GridlistaRow = GXWebRow.GetNew(context,GridlistaContainer);
            if ( subGridlista_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlista_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlista_Class, "") != 0 )
               {
                  subGridlista_Linesclass = subGridlista_Class+"Odd";
               }
            }
            else if ( subGridlista_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlista_Backstyle = 0;
               subGridlista_Backcolor = subGridlista_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlista_Class, "") != 0 )
               {
                  subGridlista_Linesclass = subGridlista_Class+"Uniform";
               }
            }
            else if ( subGridlista_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlista_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlista_Class, "") != 0 )
               {
                  subGridlista_Linesclass = subGridlista_Class+"Odd";
               }
               subGridlista_Backcolor = (int)(0x0);
            }
            else if ( subGridlista_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlista_Backstyle = 1;
               if ( ((int)((nGXsfl_294_idx) % (2))) == 0 )
               {
                  subGridlista_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlista_Class, "") != 0 )
                  {
                     subGridlista_Linesclass = subGridlista_Class+"Even";
                  }
               }
               else
               {
                  subGridlista_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlista_Class, "") != 0 )
                  {
                     subGridlista_Linesclass = subGridlista_Class+"Odd";
                  }
               }
            }
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_294_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 295,'',false,'" + sGXsfl_294_idx + "',294)\"";
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVisor_Internalname,StringUtil.RTrim( AV58Visor),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,295);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavVisor_Link,(string)"",(string)"",(string)"",(string)edtavVisor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavVisor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)294,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)294,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "LISTATIPO_" + sGXsfl_294_idx;
            cmbListaTipo.Name = GXCCtl;
            cmbListaTipo.WebTags = "";
            cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
            cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
            cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
            cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
            if ( cmbListaTipo.ItemCount > 0 )
            {
               A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            }
            /* ComboBox */
            GridlistaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbListaTipo,(string)cmbListaTipo_Internalname,StringUtil.RTrim( A591ListaTipo),(short)1,(string)cmbListaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)false,(short)0});
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp("", false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), !bGXsfl_294_Refreshing);
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)294,(short)0,(short)-1,(short)-1,(bool)false,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)294,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)294,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbAgrupacionEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_294_idx;
               cmbAgrupacionEstado.Name = GXCCtl;
               cmbAgrupacionEstado.WebTags = "";
               cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
               cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
               cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
               if ( cmbAgrupacionEstado.ItemCount > 0 )
               {
                  A588AgrupacionEstado = cmbAgrupacionEstado.getValidValue(A588AgrupacionEstado);
               }
            }
            /* ComboBox */
            GridlistaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAgrupacionEstado,(string)cmbAgrupacionEstado_Internalname,StringUtil.RTrim( A588AgrupacionEstado),(short)1,(string)cmbAgrupacionEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)false,(short)0});
            cmbAgrupacionEstado.CurrentValue = StringUtil.RTrim( A588AgrupacionEstado);
            AssignProp("", false, cmbAgrupacionEstado_Internalname, "Values", (string)(cmbAgrupacionEstado.ToJavascriptSource()), !bGXsfl_294_Refreshing);
            /* Subfile cell */
            if ( GridlistaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'" + sGXsfl_294_idx + "',294)\"";
            ROClassString = "Attribute";
            GridlistaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridlistabadge_Internalname,(string)AV60GridListaBadge,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,302);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridlistabadge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TagColumn",(string)"",(short)-1,(int)edtavGridlistabadge_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)1,(short)294,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesBV3( ) ;
            GridlistaContainer.AddRow(GridlistaRow);
            nGXsfl_294_idx = ((subGridlista_Islastpage==1)&&(nGXsfl_294_idx+1>subGridlista_fnc_Recordsperpage( )) ? 1 : nGXsfl_294_idx+1);
            sGXsfl_294_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_294_idx), 4, 0), 4, "0");
            SubsflControlProps_2943( ) ;
         }
         /* End function sendrow_2943 */
      }

      protected void init_web_controls( )
      {
         dynavEstadosgenericosid.Name = "vESTADOSGENERICOSID";
         dynavEstadosgenericosid.WebTags = "";
         GXCCtl = "SOLICITUDESUSRALTA_" + sGXsfl_139_idx;
         dynSolicitudesUsrAlta.Name = GXCCtl;
         dynSolicitudesUsrAlta.WebTags = "";
         dynSolicitudesUsrAlta.removeAllItems();
         /* Using cursor H00BV9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            dynSolicitudesUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00BV9_A18SecUserId[0]), 10, 0)), H00BV9_A26SecUserName[0], 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( dynSolicitudesUsrAlta.ItemCount > 0 )
         {
            A597SolicitudesUsrAlta = (long)(Math.Round(NumberUtil.Val( dynSolicitudesUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A597SolicitudesUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n597SolicitudesUsrAlta = false;
         }
         GXCCtl = "LISTATIPO_" + sGXsfl_294_idx;
         cmbListaTipo.Name = GXCCtl;
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
         }
         GXCCtl = "AGRUPACIONESTADO_" + sGXsfl_294_idx;
         cmbAgrupacionEstado.Name = GXCCtl;
         cmbAgrupacionEstado.WebTags = "";
         cmbAgrupacionEstado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbAgrupacionEstado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbAgrupacionEstado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbAgrupacionEstado.ItemCount > 0 )
         {
            A588AgrupacionEstado = cmbAgrupacionEstado.getValidValue(A588AgrupacionEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl139( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"139\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ingresado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contacto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Programado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "PaisId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Realizado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV48GridBadge));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridbadge_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSolicitudesID_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A171SolicitudesNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A172SolicitudesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A113DepartamentoDepartamento)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A130EstadosSolTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132EstadosSolNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV68Relacionado)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRelacionado_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A597SolicitudesUsrAlta), 10, 0, ".", ""))));
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

      protected void StartGridControl259( )
      {
         if ( GridprofesionalesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridprofesionalesContainer"+"DivS\" data-gxgridid=\"259\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridprofesionales_Internalname, subGridprofesionales_Internalname, " "+"sdsmartgrid_scrolldirection=\"horizontal\""+" ", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridprofesionalesContainer.AddObjectProperty("GridName", "Gridprofesionales");
         }
         else
         {
            GridprofesionalesContainer.AddObjectProperty("GridName", "Gridprofesionales");
            GridprofesionalesContainer.AddObjectProperty("Header", subGridprofesionales_Header);
            GridprofesionalesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridprofesionalesContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridprofesionalesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Backcolorstyle), 1, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("CmpContext", "");
            GridprofesionalesContainer.AddObjectProperty("InMasterPage", "false");
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesColumn.AddObjectProperty("Value", context.convertURL( AV82Imagen));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76FBSolicitudId), 18, 0, ".", ""))));
            GridprofesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFbsolicitudid_Enabled), 5, 0, ".", "")));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV86FBProfesionalNombre)));
            GridprofesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFbprofesionalnombre_Enabled), 5, 0, ".", "")));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV79Comentario));
            GridprofesionalesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavComentario_Enabled), 5, 0, ".", "")));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( AV80FechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridprofesionalesColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFechaalta_Visible), 5, 0, ".", "")));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridprofesionalesContainer.AddColumnProperties(GridprofesionalesColumn);
            GridprofesionalesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Selectedindex), 4, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Allowselection), 1, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Selectioncolor), 9, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Allowhovering), 1, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Hoveringcolor), 9, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Allowcollapsing), 1, 0, ".", "")));
            GridprofesionalesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionales_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl294( )
      {
         if ( GridlistaContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridlistaContainer"+"DivS\" data-gxgridid=\"294\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlista_Internalname, subGridlista_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlista_Backcolorstyle == 0 )
            {
               subGridlista_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlista_Class) > 0 )
               {
                  subGridlista_Linesclass = subGridlista_Class+"Title";
               }
            }
            else
            {
               subGridlista_Titlebackstyle = 1;
               if ( subGridlista_Backcolorstyle == 1 )
               {
                  subGridlista_Titlebackcolor = subGridlista_Allbackcolor;
                  if ( StringUtil.Len( subGridlista_Class) > 0 )
                  {
                     subGridlista_Linesclass = subGridlista_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlista_Class) > 0 )
                  {
                     subGridlista_Linesclass = subGridlista_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Listaid", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Lista Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Apellido", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridlistaContainer.AddObjectProperty("GridName", "Gridlista");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridlistaContainer = new GXWebGrid( context);
            }
            else
            {
               GridlistaContainer.Clear();
            }
            GridlistaContainer.SetWrapped(nGXWrapped);
            GridlistaContainer.AddObjectProperty("GridName", "Gridlista");
            GridlistaContainer.AddObjectProperty("Header", subGridlista_Header);
            GridlistaContainer.AddObjectProperty("Class", "WorkWith");
            GridlistaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Backcolorstyle), 1, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("CmpContext", "");
            GridlistaContainer.AddObjectProperty("InMasterPage", "false");
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58Visor)));
            GridlistaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVisor_Enabled), 5, 0, ".", "")));
            GridlistaColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavVisor_Link));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, ".", ""))));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A591ListaTipo)));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A588AgrupacionEstado)));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlistaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV60GridListaBadge));
            GridlistaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridlistabadge_Enabled), 5, 0, ".", "")));
            GridlistaContainer.AddColumnProperties(GridlistaColumn);
            GridlistaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Selectedindex), 4, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Allowselection), 1, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Selectioncolor), 9, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Allowhovering), 1, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Hoveringcolor), 9, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Allowcollapsing), 1, 0, ".", "")));
            GridlistaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlista_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         imgavUsuariosimagen_Internalname = "vUSUARIOSIMAGEN";
         divUsuariosimagen_cell_Internalname = "USUARIOSIMAGEN_CELL";
         edtavTitulo_Internalname = "vTITULO";
         divHeader_Internalname = "HEADER";
         Card2_progress_Internalname = "CARD2_PROGRESS";
         edtavCard2_value_Internalname = "vCARD2_VALUE";
         lblCard2_description_Internalname = "CARD2_DESCRIPTION";
         divCard2_tablepcontent_Internalname = "CARD2_TABLEPCONTENT";
         lblCard2_icon_Internalname = "CARD2_ICON";
         divCard2_tablep_Internalname = "CARD2_TABLEP";
         tblCard2_maintable_Internalname = "CARD2_MAINTABLE";
         Card1_progress_Internalname = "CARD1_PROGRESS";
         edtavCard1_value_Internalname = "vCARD1_VALUE";
         lblCard1_description_Internalname = "CARD1_DESCRIPTION";
         divCard1_tablepcontent_Internalname = "CARD1_TABLEPCONTENT";
         lblCard1_icon_Internalname = "CARD1_ICON";
         divCard1_tablep_Internalname = "CARD1_TABLEP";
         tblCard1_maintable_Internalname = "CARD1_MAINTABLE";
         Card3_progress_Internalname = "CARD3_PROGRESS";
         edtavCard3_value_Internalname = "vCARD3_VALUE";
         lblCard3_description_Internalname = "CARD3_DESCRIPTION";
         divCard3_tablepcontent_Internalname = "CARD3_TABLEPCONTENT";
         lblCard3_icon_Internalname = "CARD3_ICON";
         divCard3_tablep_Internalname = "CARD3_TABLEP";
         tblCard3_maintable_Internalname = "CARD3_MAINTABLE";
         Card4_progress_Internalname = "CARD4_PROGRESS";
         edtavCard4_value_Internalname = "vCARD4_VALUE";
         lblCard4_description_Internalname = "CARD4_DESCRIPTION";
         divCard4_tablepcontent_Internalname = "CARD4_TABLEPCONTENT";
         lblCard4_icon_Internalname = "CARD4_ICON";
         divCard4_tablep_Internalname = "CARD4_TABLEP";
         tblCard4_maintable_Internalname = "CARD4_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         bttBtnaltasolicitud_Internalname = "BTNALTASOLICITUD";
         bttBtnmudanza_Internalname = "BTNMUDANZA";
         edtavFechaini_Internalname = "vFECHAINI";
         edtavFechafin_Internalname = "vFECHAFIN";
         dynavEstadosgenericosid_Internalname = "vESTADOSGENERICOSID";
         edtavBuscar_Internalname = "vBUSCAR";
         tblTablefilters_Internalname = "TABLEFILTERS";
         lblReload_Internalname = "RELOAD";
         tblTablemergedtablefilters_Internalname = "TABLEMERGEDTABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         edtavGridbadge_Internalname = "vGRIDBADGE";
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO";
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION";
         edtPaisID_Internalname = "PAISID";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtZonasID_Internalname = "ZONASID";
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO";
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL";
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE";
         edtavRelacionado_Internalname = "vRELACIONADO";
         dynSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         lblCardright1_icon_Internalname = "CARDRIGHT1_ICON";
         lblCardright1_description_Internalname = "CARDRIGHT1_DESCRIPTION";
         edtavCardright1_value_Internalname = "vCARDRIGHT1_VALUE";
         Cardright1_progress_Internalname = "CARDRIGHT1_PROGRESS";
         edtavCardright1_additionaldata_Internalname = "vCARDRIGHT1_ADDITIONALDATA";
         divCardright1_tableinfo_Internalname = "CARDRIGHT1_TABLEINFO";
         tblCardright1_maintable_Internalname = "CARDRIGHT1_MAINTABLE";
         lblCardright2_icon_Internalname = "CARDRIGHT2_ICON";
         lblCardright2_description_Internalname = "CARDRIGHT2_DESCRIPTION";
         edtavCardright2_value_Internalname = "vCARDRIGHT2_VALUE";
         Cardright2_progress_Internalname = "CARDRIGHT2_PROGRESS";
         edtavCardright2_additionaldata_Internalname = "vCARDRIGHT2_ADDITIONALDATA";
         divCardright2_tableinfo_Internalname = "CARDRIGHT2_TABLEINFO";
         tblCardright2_maintable_Internalname = "CARDRIGHT2_MAINTABLE";
         lblCardright3_icon_Internalname = "CARDRIGHT3_ICON";
         lblCardright3_description_Internalname = "CARDRIGHT3_DESCRIPTION";
         edtavCardright3_value_Internalname = "vCARDRIGHT3_VALUE";
         Cardright3_progress_Internalname = "CARDRIGHT3_PROGRESS";
         edtavCardright3_additionaldata_Internalname = "vCARDRIGHT3_ADDITIONALDATA";
         divCardright3_tableinfo_Internalname = "CARDRIGHT3_TABLEINFO";
         tblCardright3_maintable_Internalname = "CARDRIGHT3_MAINTABLE";
         lblCardright4_icon_Internalname = "CARDRIGHT4_ICON";
         lblCardright4_description_Internalname = "CARDRIGHT4_DESCRIPTION";
         edtavCardright4_value_Internalname = "vCARDRIGHT4_VALUE";
         Cardright4_progress_Internalname = "CARDRIGHT4_PROGRESS";
         edtavCardright4_additionaldata_Internalname = "vCARDRIGHT4_ADDITIONALDATA";
         divCardright4_tableinfo_Internalname = "CARDRIGHT4_TABLEINFO";
         tblCardright4_maintable_Internalname = "CARDRIGHT4_MAINTABLE";
         divTablecards2_Internalname = "TABLECARDS2";
         edtavImagen_Internalname = "vIMAGEN";
         edtavFbsolicitudid_Internalname = "vFBSOLICITUDID";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtavFbprofesionalnombre_Internalname = "vFBPROFESIONALNOMBRE";
         edtavComentario_Internalname = "vCOMENTARIO";
         Feddbacknum_Internalname = "FEDDBACKNUM";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         edtavFechaalta_Internalname = "vFECHAALTA";
         tblUnnamedtablecontentfsgridprofesionales_Internalname = "UNNAMEDTABLECONTENTFSGRIDPROFESIONALES";
         tblGridprofesionaleslayouttable_Internalname = "GRIDPROFESIONALESLAYOUTTABLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         edtavVisor_Internalname = "vVISOR";
         edtListaid_Internalname = "LISTAID";
         cmbListaTipo_Internalname = "LISTATIPO";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         cmbAgrupacionEstado_Internalname = "AGRUPACIONESTADO";
         edtavGridlistabadge_Internalname = "vGRIDLISTABADGE";
         Innewwindow_Internalname = "INNEWWINDOW";
         Newwindow_Internalname = "NEWWINDOW";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGridcurrentpage_Internalname = "vGRIDCURRENTPAGE";
         Gridlista_titlescategories_Internalname = "GRIDLISTA_TITLESCATEGORIES";
         Gridlista_empowerer_Internalname = "GRIDLISTA_EMPOWERER";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
         subGridprofesionales_Internalname = "GRIDPROFESIONALES";
         subGridlista_Internalname = "GRIDLISTA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlista_Allowcollapsing = 0;
         subGridlista_Allowselection = 0;
         subGridlista_Header = "";
         subGridprofesionales_Allowcollapsing = 0;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         edtavGridlistabadge_Jsonclick = "";
         edtavGridlistabadge_Enabled = 0;
         cmbAgrupacionEstado_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         cmbListaTipo_Jsonclick = "";
         edtListaid_Jsonclick = "";
         edtavVisor_Jsonclick = "";
         edtavVisor_Link = "";
         edtavVisor_Enabled = 0;
         subGridlista_Class = "WorkWith";
         subGridlista_Backcolorstyle = 0;
         edtavFechaalta_Jsonclick = "";
         Feddbacknum_Enabled = Convert.ToBoolean( 1);
         edtavComentario_Enabled = 0;
         edtavFbprofesionalnombre_Jsonclick = "";
         edtavFbprofesionalnombre_Enabled = 0;
         edtavFbsolicitudid_Jsonclick = "";
         edtavFbsolicitudid_Enabled = 0;
         edtavImagen_gximage = "";
         dynSolicitudesUsrAlta_Jsonclick = "";
         edtavRelacionado_Jsonclick = "";
         edtavRelacionado_Enabled = 0;
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolTipo_Jsonclick = "";
         edtSolicitudServicioPFinal_Jsonclick = "";
         edtDepartamentoDepartamento_Jsonclick = "";
         edtZonasID_Jsonclick = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtPaisID_Jsonclick = "";
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesNombre_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         edtSolicitudesID_Jsonclick = "";
         edtSolicitudesID_Link = "";
         edtSolicitudesFechaAlta_Jsonclick = "";
         edtavGridbadge_Jsonclick = "";
         edtavGridbadge_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavCard2_value_Jsonclick = "";
         edtavCard2_value_Enabled = 1;
         edtavCard1_value_Jsonclick = "";
         edtavCard1_value_Enabled = 1;
         edtavCard3_value_Jsonclick = "";
         edtavCard3_value_Enabled = 1;
         edtavCard4_value_Jsonclick = "";
         edtavCard4_value_Enabled = 1;
         edtavBuscar_Jsonclick = "";
         edtavBuscar_Enabled = 1;
         edtavCardright1_additionaldata_Jsonclick = "";
         edtavCardright1_additionaldata_Enabled = 1;
         edtavCardright1_value_Jsonclick = "";
         edtavCardright1_value_Enabled = 1;
         edtavCardright2_additionaldata_Jsonclick = "";
         edtavCardright2_additionaldata_Enabled = 1;
         edtavCardright2_value_Jsonclick = "";
         edtavCardright2_value_Enabled = 1;
         edtavCardright3_additionaldata_Jsonclick = "";
         edtavCardright3_additionaldata_Enabled = 1;
         edtavCardright3_value_Jsonclick = "";
         edtavCardright3_value_Enabled = 1;
         edtavCardright4_additionaldata_Jsonclick = "";
         edtavCardright4_additionaldata_Enabled = 1;
         edtavCardright4_value_Jsonclick = "";
         edtavCardright4_value_Enabled = 1;
         lblReload_Caption = context.GetMessage( "<i class='AttributeColorBaseColor fas fa-rotate' title='Refrescar Datos' style='font-size: 20px'></i>", "");
         cmbAgrupacionEstado.Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         cmbListaTipo.Enabled = 0;
         edtListaid_Enabled = 0;
         dynSolicitudesUsrAlta.Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtSolicitudesFechaAlta_Enabled = 0;
         subGridprofesionales_Backcolorstyle = 0;
         Feddbacknum_Captionposition = "None";
         Feddbacknum_Captionstyle = "";
         Feddbacknum_Captionclass = "col-sm-3 ReadonlyAttributeLabel";
         edtavGridcurrentpage_Jsonclick = "";
         edtavGridcurrentpage_Visible = 1;
         dynavEstadosgenericosid_Jsonclick = "";
         dynavEstadosgenericosid.Enabled = 1;
         edtavFechafin_Jsonclick = "";
         edtavFechafin_Enabled = 1;
         edtavFechaini_Jsonclick = "";
         edtavFechaini_Enabled = 1;
         divTablechart1_Height = 0;
         edtavTitulo_Jsonclick = "";
         edtavTitulo_Enabled = 1;
         imgavUsuariosimagen_gximage = "";
         imgavUsuariosimagen_Visible = 1;
         divUsuariosimagen_cell_Class = "col-xs-12 col-sm-2";
         subGridprofesionales_Class = "FreeStyleGrid";
         Gridlista_empowerer_Hascategories = Convert.ToBoolean( -1);
         Gridlista_titlescategories_Gridtitlescategories = "";
         Innewwindow_Target = "";
         Innewwindow_Height = "50";
         Innewwindow_Width = "50";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = context.GetMessage( "Últimos Trabajos Realizados", "");
         Dvpanel_unnamedtable1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Cardright4_progress_Percentage = 50;
         Cardright4_progress_Cls = "ProgressBarAdminCard";
         Cardright4_progress_Caption = "";
         Cardright4_progress_Type = "Bar";
         Cardright3_progress_Percentage = 50;
         Cardright3_progress_Cls = "ProgressBarAdminCard";
         Cardright3_progress_Caption = "";
         Cardright3_progress_Type = "Bar";
         Cardright2_progress_Percentage = 50;
         Cardright2_progress_Cls = "ProgressBarAdminCard";
         Cardright2_progress_Caption = "";
         Cardright2_progress_Type = "Bar";
         Cardright1_progress_Percentage = 100;
         Cardright1_progress_Cls = "ProgressBarAdminCard";
         Cardright1_progress_Caption = "";
         Cardright1_progress_Type = "Bar";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = context.GetMessage( "Lista de Solicitudes", "");
         Dvpanel_tablechart1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "GridSolicitud";
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
         Card4_progress_Percentage = 50;
         Card4_progress_Cls = "ProgressWhite";
         Card4_progress_Caption = "50%";
         Card3_progress_Percentage = 50;
         Card3_progress_Cls = "ProgressWhite";
         Card3_progress_Caption = "50%";
         Card1_progress_Circlewidth = 70;
         Card1_progress_Percentage = 50;
         Card1_progress_Cls = "ProgressWhite";
         Card1_progress_Caption = "50";
         Card2_progress_Percentage = 50;
         Card2_progress_Cls = "ProgressWhite";
         Card2_progress_Caption = "50%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Estadísticas del Comercio", "");
         edtavFechaalta_Visible = 1;
         subGridlista_Rows = 0;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'GRIDPROFESIONALES_nFirstRecordOnPage',type:'int'},{av:'GRIDPROFESIONALES_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'edtavFechaalta_Visible',ctrl:'vFECHAALTA',prop:'Visible'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDLISTA.LOAD","{handler:'E19BV3',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbAgrupacionEstado'},{av:'A588AgrupacionEstado',fld:'AGRUPACIONESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRIDLISTA.LOAD",",oparms:[{av:'AV73Titulo',fld:'vTITULO',pic:'',type:'char'},{av:'AV58Visor',fld:'vVISOR',pic:'',type:'char'},{av:'edtavVisor_Link',ctrl:'vVISOR',prop:'Link'},{av:'AV60GridListaBadge',fld:'vGRIDLISTABADGE',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPROFESIONALES.LOAD","{handler:'E18BV4',iparms:[{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true}]");
         setEventMetadata("GRIDPROFESIONALES.LOAD",",oparms:[{av:'AV82Imagen',fld:'vIMAGEN',pic:'',type:'bits'},{av:'AV86FBProfesionalNombre',fld:'vFBPROFESIONALNOMBRE',pic:'',type:'char'},{av:'AV76FBSolicitudId',fld:'vFBSOLICITUDID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV79Comentario',fld:'vCOMENTARIO',pic:'',type:'vchar'},{av:'AV80FechaAlta',fld:'vFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV78FeddBackNum',fld:'vFEDDBACKNUM',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E17BV2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV68Relacionado',fld:'vRELACIONADO',pic:'',type:'char'},{av:'edtSolicitudesID_Link',ctrl:'SOLICITUDESID',prop:'Link'},{av:'AV48GridBadge',fld:'vGRIDBADGE',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E13BV2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'GRIDPROFESIONALES_nFirstRecordOnPage',type:'int'},{av:'GRIDPROFESIONALES_nEOF',type:'int'},{av:'edtavFechaalta_Visible',ctrl:'vFECHAALTA',prop:'Visible'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E14BV2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOALTASOLICITUD'","{handler:'E11BV1',iparms:[{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOALTASOLICITUD'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'},{av:'Innewwindow_Height',ctrl:'INNEWWINDOW',prop:'Height'},{av:'Innewwindow_Width',ctrl:'INNEWWINDOW',prop:'Width'}]}");
         setEventMetadata("'DOMUDANZA'","{handler:'E12BV1',iparms:[{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOMUDANZA'",",oparms:[{av:'Innewwindow_Target',ctrl:'INNEWWINDOW',prop:'Target'}]}");
         setEventMetadata("RELOAD.CLICK","{handler:'E20BV1',iparms:[{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'GRIDPROFESIONALES_nFirstRecordOnPage',type:'int'},{av:'GRIDPROFESIONALES_nEOF',type:'int'},{av:'edtavFechaalta_Visible',ctrl:'vFECHAALTA',prop:'Visible'}]");
         setEventMetadata("RELOAD.CLICK",",oparms:[]}");
         setEventMetadata("GRIDLISTA_FIRSTPAGE","{handler:'subgridlista_firstpage',iparms:[{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRIDLISTA_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDLISTA_PREVPAGE","{handler:'subgridlista_previouspage',iparms:[{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRIDLISTA_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDLISTA_NEXTPAGE","{handler:'subgridlista_nextpage',iparms:[{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRIDLISTA_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDLISTA_LASTPAGE","{handler:'subgridlista_lastpage',iparms:[{av:'GRIDLISTA_nFirstRecordOnPage',type:'int'},{av:'GRIDLISTA_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridlista_Rows',ctrl:'GRIDLISTA',prop:'Rows'},{av:'AV49FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV50FechaFin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'AV52Buscar',fld:'vBUSCAR',pic:'',type:'char'},{av:'AV5ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV40WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV75SDTFeedBack',fld:'vSDTFEEDBACK',pic:'',hsh:true},{av:'AV66inProveedorID',fld:'vINPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynavEstadosgenericosid'},{av:'AV51EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRIDLISTA_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAINI","{handler:'Validv_Fechaini',iparms:[]");
         setEventMetadata("VALIDV_FECHAINI",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAFIN","{handler:'Validv_Fechafin',iparms:[]");
         setEventMetadata("VALIDV_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudesusralta',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAALTA","{handler:'Validv_Fechaalta',iparms:[]");
         setEventMetadata("VALIDV_FECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[]");
         setEventMetadata("VALID_LISTAID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gridlistabadge',iparms:[]");
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

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV49FechaIni = DateTime.MinValue;
         AV50FechaFin = DateTime.MinValue;
         AV52Buscar = "";
         AV40WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV75SDTFeedBack = new GXBaseCollection<SdtSDTFeedBack_Items>( context, "Items", "AlmangoX");
         H00BV2_A127SolicitudesID = new long[1] ;
         H00BV2_A134SolicitudesItemsID = new short[1] ;
         H00BV2_A180SolicitudItemsComision = new decimal[1] ;
         H00BV2_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00BV2_A178SolicitudItemsSR = new string[] {""} ;
         H00BV2_A177SolicitudesItemsCantidad = new short[1] ;
         H00BV2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00BV2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV47GridAppliedFilters = "";
         AV89LinkMudanza = "";
         AV57Link = "";
         Gridlista_titlescategories_Gridinternalname = "";
         Gridlista_empowerer_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         AV72usuariosImagen = "";
         AV90Usuariosimagen_GXI = "";
         sImgUrl = "";
         TempTags = "";
         AV73Titulo = "";
         ucDvpanel_tablechart1 = new GXUserControl();
         bttBtnaltasolicitud_Jsonclick = "";
         bttBtnmudanza_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDvpanel_unnamedtable1 = new GXUserControl();
         GridprofesionalesContainer = new GXWebGrid( context);
         GridlistaContainer = new GXWebGrid( context);
         ucInnewwindow = new GXUserControl();
         ucNewwindow = new GXUserControl();
         ucGridlista_titlescategories = new GXUserControl();
         ucGridlista_empowerer = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV48GridBadge = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A116PaisID = "";
         A113DepartamentoDepartamento = "";
         A130EstadosSolTipo = "";
         A132EstadosSolNombre = "";
         AV68Relacionado = "";
         GXCCtl = "";
         AV82Imagen = "";
         AV92Imagen_GXI = "";
         AV86FBProfesionalNombre = "";
         AV79Comentario = "";
         AV80FechaAlta = (DateTime)(DateTime.MinValue);
         AV58Visor = "";
         A591ListaTipo = "";
         A120ProfesionalesId = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A588AgrupacionEstado = "";
         AV60GridListaBadge = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00BV3_A108EstadosGenericosId = new int[1] ;
         H00BV3_A109EstadosGenericosNombre = new string[] {""} ;
         H00BV3_A107EstadosTipo = new string[] {""} ;
         lV52Buscar = "";
         H00BV4_A597SolicitudesUsrAlta = new long[1] ;
         H00BV4_n597SolicitudesUsrAlta = new bool[] {false} ;
         H00BV4_A132EstadosSolNombre = new string[] {""} ;
         H00BV4_A131EstadosSolId = new int[1] ;
         H00BV4_A130EstadosSolTipo = new string[] {""} ;
         H00BV4_A113DepartamentoDepartamento = new string[] {""} ;
         H00BV4_A110ZonasID = new long[1] ;
         H00BV4_n110ZonasID = new bool[] {false} ;
         H00BV4_A114DepartamentoMunicipioId = new long[1] ;
         H00BV4_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00BV4_A112DepartamentoId = new long[1] ;
         H00BV4_n112DepartamentoId = new bool[] {false} ;
         H00BV4_A116PaisID = new string[] {""} ;
         H00BV4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00BV4_A172SolicitudesTelefono = new string[] {""} ;
         H00BV4_A171SolicitudesNombre = new string[] {""} ;
         H00BV4_A282ProveedorNombre = new string[] {""} ;
         H00BV4_A133ProveedorID = new long[1] ;
         H00BV4_A127SolicitudesID = new long[1] ;
         H00BV4_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00BV4_n182SolicitudesFechaAlta = new bool[] {false} ;
         H00BV4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00BV4_A212SolicitudesCotizacion = new decimal[1] ;
         H00BV4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00BV4_A897SolicitudesDescuento = new decimal[1] ;
         H00BV4_n897SolicitudesDescuento = new bool[] {false} ;
         H00BV4_A864SolicitudesCostoXZona = new decimal[1] ;
         H00BV5_A133ProveedorID = new long[1] ;
         H00BV5_A282ProveedorNombre = new string[] {""} ;
         H00BV5_A588AgrupacionEstado = new string[] {""} ;
         H00BV5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00BV5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00BV5_A120ProfesionalesId = new string[] {""} ;
         H00BV5_A591ListaTipo = new string[] {""} ;
         H00BV5_A590Listaid = new long[1] ;
         H00BV6_AGRID_nRecordCount = new long[1] ;
         H00BV7_AGRIDLISTA_nRecordCount = new long[1] ;
         AV24CardRight1_AdditionalData = "";
         AV22CardRight2_AdditionalData = "";
         AV20CardRight3_AdditionalData = "";
         AV18CardRight4_AdditionalData = "";
         GXt_objcol_SdtSDTFeedBack_Items1 = new GXBaseCollection<SdtSDTFeedBack_Items>( context, "Items", "AlmangoX");
         AV62SDTCantSol = new SdtSDTCantSol(context);
         GXt_SdtSDTCantSol2 = new SdtSDTCantSol(context);
         ucCardright1_progress = new GXUserControl();
         ucCardright2_progress = new GXUserControl();
         ucCardright3_progress = new GXUserControl();
         ucCardright4_progress = new GXUserControl();
         ucCard2_progress = new GXUserControl();
         ucCard1_progress = new GXUserControl();
         ucCard3_progress = new GXUserControl();
         ucCard4_progress = new GXUserControl();
         AV53ParametrosValor = "";
         AV55ParametrosEstado = "";
         AV69RelelacionadID = "";
         AV67Existe = "";
         GridRow = new GXWebRow();
         GridlistaRow = new GXWebRow();
         AV81Item = new SdtSDTFeedBack_Items(context);
         GridprofesionalesRow = new GXWebRow();
         lblCardright4_icon_Jsonclick = "";
         lblCardright4_description_Jsonclick = "";
         lblCardright3_icon_Jsonclick = "";
         lblCardright3_description_Jsonclick = "";
         lblCardright2_icon_Jsonclick = "";
         lblCardright2_description_Jsonclick = "";
         lblCardright1_icon_Jsonclick = "";
         lblCardright1_description_Jsonclick = "";
         lblReload_Jsonclick = "";
         lblCard4_description_Jsonclick = "";
         lblCard4_icon_Jsonclick = "";
         lblCard3_description_Jsonclick = "";
         lblCard3_icon_Jsonclick = "";
         lblCard1_description_Jsonclick = "";
         lblCard1_icon_Jsonclick = "";
         lblCard2_description_Jsonclick = "";
         lblCard2_icon_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         H00BV8_A18SecUserId = new long[1] ;
         H00BV8_A26SecUserName = new string[] {""} ;
         subGridprofesionales_Linesclass = "";
         GridprofesionalesColumn = new GXWebColumn();
         subGridlista_Linesclass = "";
         H00BV9_A18SecUserId = new long[1] ;
         H00BV9_A26SecUserName = new string[] {""} ;
         GridColumn = new GXWebColumn();
         subGridprofesionales_Header = "";
         GridlistaColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercios.dashboardcom__default(),
            new Object[][] {
                new Object[] {
               H00BV2_A127SolicitudesID, H00BV2_A134SolicitudesItemsID, H00BV2_A180SolicitudItemsComision, H00BV2_A179SolicitudItemsComisionTipo, H00BV2_A178SolicitudItemsSR, H00BV2_A177SolicitudesItemsCantidad, H00BV2_A176SolicitudesItemsPrecioFinal, H00BV2_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H00BV3_A108EstadosGenericosId, H00BV3_A109EstadosGenericosNombre, H00BV3_A107EstadosTipo
               }
               , new Object[] {
               H00BV4_A597SolicitudesUsrAlta, H00BV4_n597SolicitudesUsrAlta, H00BV4_A132EstadosSolNombre, H00BV4_A131EstadosSolId, H00BV4_A130EstadosSolTipo, H00BV4_A113DepartamentoDepartamento, H00BV4_A110ZonasID, H00BV4_n110ZonasID, H00BV4_A114DepartamentoMunicipioId, H00BV4_n114DepartamentoMunicipioId,
               H00BV4_A112DepartamentoId, H00BV4_n112DepartamentoId, H00BV4_A116PaisID, H00BV4_A184SolicitudesFechaInstalacion, H00BV4_A172SolicitudesTelefono, H00BV4_A171SolicitudesNombre, H00BV4_A282ProveedorNombre, H00BV4_A133ProveedorID, H00BV4_A127SolicitudesID, H00BV4_A182SolicitudesFechaAlta,
               H00BV4_n182SolicitudesFechaAlta, H00BV4_A796SolicitudesComisionMetodoPago, H00BV4_A212SolicitudesCotizacion, H00BV4_A1016SolicitudesDescuentoCupon, H00BV4_A897SolicitudesDescuento, H00BV4_n897SolicitudesDescuento, H00BV4_A864SolicitudesCostoXZona
               }
               , new Object[] {
               H00BV5_A133ProveedorID, H00BV5_A282ProveedorNombre, H00BV5_A588AgrupacionEstado, H00BV5_A166ProfesionalesPrimerNombre, H00BV5_A167ProfesionalesApellidoPrimero, H00BV5_A120ProfesionalesId, H00BV5_A591ListaTipo, H00BV5_A590Listaid
               }
               , new Object[] {
               H00BV6_AGRID_nRecordCount
               }
               , new Object[] {
               H00BV7_AGRIDLISTA_nRecordCount
               }
               , new Object[] {
               H00BV8_A18SecUserId, H00BV8_A26SecUserName
               }
               , new Object[] {
               H00BV9_A18SecUserId, H00BV9_A26SecUserName
               }
            }
         );
         /* GeneXus formulas. */
         edtavTitulo_Enabled = 0;
         edtavCard2_value_Enabled = 0;
         edtavCard1_value_Enabled = 0;
         edtavCard3_value_Enabled = 0;
         edtavCard4_value_Enabled = 0;
         edtavGridbadge_Enabled = 0;
         edtavRelacionado_Enabled = 0;
         edtavCardright1_value_Enabled = 0;
         edtavCardright1_additionaldata_Enabled = 0;
         edtavCardright2_value_Enabled = 0;
         edtavCardright2_additionaldata_Enabled = 0;
         edtavCardright3_value_Enabled = 0;
         edtavCardright3_additionaldata_Enabled = 0;
         edtavCardright4_value_Enabled = 0;
         edtavCardright4_additionaldata_Enabled = 0;
         edtavFbsolicitudid_Enabled = 0;
         edtavFbprofesionalnombre_Enabled = 0;
         edtavComentario_Enabled = 0;
         edtavVisor_Enabled = 0;
         edtavGridlistabadge_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short GRIDLISTA_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGridlista_Backcolorstyle ;
      private short subGridprofesionales_Backcolorstyle ;
      private short GRIDPROFESIONALES_nEOF ;
      private short subGrid_Backstyle ;
      private short subGridprofesionales_Backstyle ;
      private short subGridlista_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGridprofesionales_Allowselection ;
      private short subGridprofesionales_Allowhovering ;
      private short subGridprofesionales_Allowcollapsing ;
      private short subGridprofesionales_Collapsed ;
      private short subGridlista_Titlebackstyle ;
      private short subGridlista_Allowselection ;
      private short subGridlista_Allowhovering ;
      private short subGridlista_Allowcollapsing ;
      private short subGridlista_Collapsed ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_139 ;
      private int nRC_GXsfl_259 ;
      private int nRC_GXsfl_294 ;
      private int subGridprofesionales_Recordcount ;
      private int subGrid_Rows ;
      private int subGridlista_Rows ;
      private int nGXsfl_139_idx=1 ;
      private int AV51EstadosGenericosID ;
      private int nGXsfl_259_idx=1 ;
      private int edtavFechaalta_Visible ;
      private int nGXsfl_294_idx=1 ;
      private int Card2_progress_Percentage ;
      private int Card1_progress_Percentage ;
      private int Card1_progress_Circlewidth ;
      private int Card3_progress_Percentage ;
      private int Card4_progress_Percentage ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Cardright1_progress_Percentage ;
      private int Cardright2_progress_Percentage ;
      private int Cardright3_progress_Percentage ;
      private int Cardright4_progress_Percentage ;
      private int imgavUsuariosimagen_Visible ;
      private int edtavTitulo_Enabled ;
      private int divTablechart1_Height ;
      private int edtavFechaini_Enabled ;
      private int edtavFechafin_Enabled ;
      private int edtavGridcurrentpage_Visible ;
      private int A131EstadosSolId ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int subGridlista_Islastpage ;
      private int subGridprofesionales_Islastpage ;
      private int edtavCard2_value_Enabled ;
      private int edtavCard1_value_Enabled ;
      private int edtavCard3_value_Enabled ;
      private int edtavCard4_value_Enabled ;
      private int edtavGridbadge_Enabled ;
      private int edtavRelacionado_Enabled ;
      private int edtavCardright1_value_Enabled ;
      private int edtavCardright1_additionaldata_Enabled ;
      private int edtavCardright2_value_Enabled ;
      private int edtavCardright2_additionaldata_Enabled ;
      private int edtavCardright3_value_Enabled ;
      private int edtavCardright3_additionaldata_Enabled ;
      private int edtavCardright4_value_Enabled ;
      private int edtavCardright4_additionaldata_Enabled ;
      private int edtavFbsolicitudid_Enabled ;
      private int edtavFbprofesionalnombre_Enabled ;
      private int edtavComentario_Enabled ;
      private int edtavVisor_Enabled ;
      private int edtavGridlistabadge_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSolicitudesFechaAlta_Enabled ;
      private int edtSolicitudesID_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtZonasID_Enabled ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtListaid_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int AV27Card2_Value ;
      private int AV28Card1_Value ;
      private int AV26Card3_Value ;
      private int AV25Card4_Value ;
      private int AV23CardRight1_Value ;
      private int AV21CardRight2_Value ;
      private int AV19CardRight3_Value ;
      private int AV17CardRight4_Value ;
      private int AV54ParametrosNumerico ;
      private int AV44PageToGo ;
      private int AV91GXV1 ;
      private int edtavBuscar_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGridprofesionales_Backcolor ;
      private int subGridprofesionales_Allbackcolor ;
      private int subGridlista_Backcolor ;
      private int subGridlista_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGridprofesionales_Selectedindex ;
      private int subGridprofesionales_Selectioncolor ;
      private int subGridprofesionales_Hoveringcolor ;
      private int subGridlista_Titlebackcolor ;
      private int subGridlista_Selectedindex ;
      private int subGridlista_Selectioncolor ;
      private int subGridlista_Hoveringcolor ;
      private long AV66inProveedorID ;
      private long wcpOAV66inProveedorID ;
      private long GRID_nFirstRecordOnPage ;
      private long GRIDLISTA_nFirstRecordOnPage ;
      private long AV5ProveedorID ;
      private long A127SolicitudesID ;
      private long AV46GridPageCount ;
      private long AV87SecUserId ;
      private long AV56UsrId ;
      private long AV45GridCurrentPage ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A597SolicitudesUsrAlta ;
      private long AV76FBSolicitudId ;
      private long AV78FeddBackNum ;
      private long A590Listaid ;
      private long GRID_nCurrentRecord ;
      private long GRIDPROFESIONALES_nCurrentRecord ;
      private long GRIDLISTA_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long GRIDLISTA_nRecordCount ;
      private long GRIDPROFESIONALES_nFirstRecordOnPage ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A897SolicitudesDescuento ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal AV9CardRight1_ProgressValue ;
      private decimal AV10CardRight2_ProgressValue ;
      private decimal AV11CardRight3_ProgressValue ;
      private decimal AV12CardRight4_ProgressValue ;
      private decimal AV14Card2_ProgressValue ;
      private decimal AV13Card1_ProgressValue ;
      private decimal AV15Card3_ProgressValue ;
      private decimal AV16Card4_ProgressValue ;
      private string Gridpaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_139_idx="0001" ;
      private string AV52Buscar ;
      private string sGXsfl_259_idx="0001" ;
      private string edtavFechaalta_Internalname ;
      private string sGXsfl_294_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV57Link ;
      private string Card2_progress_Caption ;
      private string Card2_progress_Cls ;
      private string Card1_progress_Caption ;
      private string Card1_progress_Cls ;
      private string Card3_progress_Caption ;
      private string Card3_progress_Cls ;
      private string Card4_progress_Caption ;
      private string Card4_progress_Cls ;
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
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Cardright1_progress_Type ;
      private string Cardright1_progress_Caption ;
      private string Cardright1_progress_Cls ;
      private string Cardright2_progress_Type ;
      private string Cardright2_progress_Caption ;
      private string Cardright2_progress_Cls ;
      private string Cardright3_progress_Type ;
      private string Cardright3_progress_Caption ;
      private string Cardright3_progress_Cls ;
      private string Cardright4_progress_Type ;
      private string Cardright4_progress_Caption ;
      private string Cardright4_progress_Cls ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Innewwindow_Width ;
      private string Innewwindow_Height ;
      private string Innewwindow_Target ;
      private string Gridlista_titlescategories_Gridinternalname ;
      private string Gridlista_titlescategories_Gridtitlescategories ;
      private string Gridlista_empowerer_Gridinternalname ;
      private string Grid_empowerer_Gridinternalname ;
      private string subGridprofesionales_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divHeader_Internalname ;
      private string divUsuariosimagen_cell_Internalname ;
      private string divUsuariosimagen_cell_Class ;
      private string ClassString ;
      private string imgavUsuariosimagen_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgavUsuariosimagen_Internalname ;
      private string edtavTitulo_Internalname ;
      private string TempTags ;
      private string AV73Titulo ;
      private string edtavTitulo_Jsonclick ;
      private string divTablecards_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string bttBtnaltasolicitud_Internalname ;
      private string bttBtnaltasolicitud_Jsonclick ;
      private string bttBtnmudanza_Internalname ;
      private string bttBtnmudanza_Jsonclick ;
      private string edtavFechaini_Internalname ;
      private string edtavFechaini_Jsonclick ;
      private string edtavFechafin_Internalname ;
      private string edtavFechafin_Jsonclick ;
      private string dynavEstadosgenericosid_Internalname ;
      private string dynavEstadosgenericosid_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divTablecards2_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string subGridprofesionales_Internalname ;
      private string subGridlista_Internalname ;
      private string Innewwindow_Internalname ;
      private string Newwindow_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGridcurrentpage_Internalname ;
      private string edtavGridcurrentpage_Jsonclick ;
      private string Gridlista_titlescategories_Internalname ;
      private string Gridlista_empowerer_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavGridbadge_Internalname ;
      private string edtSolicitudesFechaAlta_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Internalname ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Internalname ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtZonasID_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string A130EstadosSolTipo ;
      private string edtEstadosSolTipo_Internalname ;
      private string edtEstadosSolId_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Internalname ;
      private string AV68Relacionado ;
      private string edtavRelacionado_Internalname ;
      private string dynSolicitudesUsrAlta_Internalname ;
      private string GXCCtl ;
      private string Feddbacknum_Internalname ;
      private string Feddbacknum_Captionclass ;
      private string Feddbacknum_Captionstyle ;
      private string Feddbacknum_Captionposition ;
      private string edtavImagen_Internalname ;
      private string edtavFbsolicitudid_Internalname ;
      private string AV86FBProfesionalNombre ;
      private string edtavFbprofesionalnombre_Internalname ;
      private string edtavComentario_Internalname ;
      private string AV58Visor ;
      private string edtavVisor_Internalname ;
      private string edtListaid_Internalname ;
      private string cmbListaTipo_Internalname ;
      private string A591ListaTipo ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string cmbAgrupacionEstado_Internalname ;
      private string A588AgrupacionEstado ;
      private string edtavGridlistabadge_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string edtavCard2_value_Internalname ;
      private string edtavCard1_value_Internalname ;
      private string edtavCard3_value_Internalname ;
      private string edtavCard4_value_Internalname ;
      private string edtavCardright1_value_Internalname ;
      private string edtavCardright1_additionaldata_Internalname ;
      private string edtavCardright2_value_Internalname ;
      private string edtavCardright2_additionaldata_Internalname ;
      private string edtavCardright3_value_Internalname ;
      private string edtavCardright3_additionaldata_Internalname ;
      private string edtavCardright4_value_Internalname ;
      private string edtavCardright4_additionaldata_Internalname ;
      private string lV52Buscar ;
      private string edtavBuscar_Internalname ;
      private string lblReload_Caption ;
      private string lblReload_Internalname ;
      private string Cardright1_progress_Internalname ;
      private string Cardright2_progress_Internalname ;
      private string Cardright3_progress_Internalname ;
      private string Cardright4_progress_Internalname ;
      private string Card2_progress_Internalname ;
      private string Card1_progress_Internalname ;
      private string Card3_progress_Internalname ;
      private string Card4_progress_Internalname ;
      private string AV55ParametrosEstado ;
      private string AV69RelelacionadID ;
      private string AV67Existe ;
      private string edtSolicitudesID_Link ;
      private string edtavVisor_Link ;
      private string tblCardright4_maintable_Internalname ;
      private string lblCardright4_icon_Internalname ;
      private string lblCardright4_icon_Jsonclick ;
      private string divCardright4_tableinfo_Internalname ;
      private string lblCardright4_description_Internalname ;
      private string lblCardright4_description_Jsonclick ;
      private string edtavCardright4_value_Jsonclick ;
      private string edtavCardright4_additionaldata_Jsonclick ;
      private string tblCardright3_maintable_Internalname ;
      private string lblCardright3_icon_Internalname ;
      private string lblCardright3_icon_Jsonclick ;
      private string divCardright3_tableinfo_Internalname ;
      private string lblCardright3_description_Internalname ;
      private string lblCardright3_description_Jsonclick ;
      private string edtavCardright3_value_Jsonclick ;
      private string edtavCardright3_additionaldata_Jsonclick ;
      private string tblCardright2_maintable_Internalname ;
      private string lblCardright2_icon_Internalname ;
      private string lblCardright2_icon_Jsonclick ;
      private string divCardright2_tableinfo_Internalname ;
      private string lblCardright2_description_Internalname ;
      private string lblCardright2_description_Jsonclick ;
      private string edtavCardright2_value_Jsonclick ;
      private string edtavCardright2_additionaldata_Jsonclick ;
      private string tblCardright1_maintable_Internalname ;
      private string lblCardright1_icon_Internalname ;
      private string lblCardright1_icon_Jsonclick ;
      private string divCardright1_tableinfo_Internalname ;
      private string lblCardright1_description_Internalname ;
      private string lblCardright1_description_Jsonclick ;
      private string edtavCardright1_value_Jsonclick ;
      private string edtavCardright1_additionaldata_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string tblTablemergedtablefilters_Internalname ;
      private string lblReload_Jsonclick ;
      private string tblTablefilters_Internalname ;
      private string edtavBuscar_Jsonclick ;
      private string tblCard4_maintable_Internalname ;
      private string divCard4_tablep_Internalname ;
      private string divCard4_tablepcontent_Internalname ;
      private string edtavCard4_value_Jsonclick ;
      private string lblCard4_description_Internalname ;
      private string lblCard4_description_Jsonclick ;
      private string lblCard4_icon_Internalname ;
      private string lblCard4_icon_Jsonclick ;
      private string tblCard3_maintable_Internalname ;
      private string divCard3_tablep_Internalname ;
      private string divCard3_tablepcontent_Internalname ;
      private string edtavCard3_value_Jsonclick ;
      private string lblCard3_description_Internalname ;
      private string lblCard3_description_Jsonclick ;
      private string lblCard3_icon_Internalname ;
      private string lblCard3_icon_Jsonclick ;
      private string tblCard1_maintable_Internalname ;
      private string divCard1_tablep_Internalname ;
      private string divCard1_tablepcontent_Internalname ;
      private string edtavCard1_value_Jsonclick ;
      private string lblCard1_description_Internalname ;
      private string lblCard1_description_Jsonclick ;
      private string lblCard1_icon_Internalname ;
      private string lblCard1_icon_Jsonclick ;
      private string tblCard2_maintable_Internalname ;
      private string divCard2_tablep_Internalname ;
      private string divCard2_tablepcontent_Internalname ;
      private string edtavCard2_value_Jsonclick ;
      private string lblCard2_description_Internalname ;
      private string lblCard2_description_Jsonclick ;
      private string lblCard2_icon_Internalname ;
      private string lblCard2_icon_Jsonclick ;
      private string sGXsfl_139_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavGridbadge_Jsonclick ;
      private string edtSolicitudesFechaAlta_Jsonclick ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string edtZonasID_Jsonclick ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string edtavRelacionado_Jsonclick ;
      private string dynSolicitudesUsrAlta_Jsonclick ;
      private string sGXsfl_259_fel_idx="0001" ;
      private string subGridprofesionales_Linesclass ;
      private string tblGridprofesionaleslayouttable_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavImagen_gximage ;
      private string edtavFbsolicitudid_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavFbprofesionalnombre_Jsonclick ;
      private string tblUnnamedtablecontentfsgridprofesionales_Internalname ;
      private string edtavFechaalta_Jsonclick ;
      private string sGXsfl_294_fel_idx="0001" ;
      private string subGridlista_Class ;
      private string subGridlista_Linesclass ;
      private string edtavVisor_Jsonclick ;
      private string edtListaid_Jsonclick ;
      private string cmbListaTipo_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string cmbAgrupacionEstado_Jsonclick ;
      private string edtavGridlistabadge_Jsonclick ;
      private string subGrid_Header ;
      private string subGridprofesionales_Header ;
      private string subGridlista_Header ;
      private DateTime AV80FechaAlta ;
      private DateTime AV49FechaIni ;
      private DateTime AV50FechaFin ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_259_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Gridlista_empowerer_Hascategories ;
      private bool wbLoad ;
      private bool AV72usuariosImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n182SolicitudesFechaAlta ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n597SolicitudesUsrAlta ;
      private bool Feddbacknum_Enabled ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_139_Refreshing=false ;
      private bool n897SolicitudesDescuento ;
      private bool bGXsfl_294_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV82Imagen_IsBlob ;
      private string AV79Comentario ;
      private string AV47GridAppliedFilters ;
      private string AV89LinkMudanza ;
      private string AV90Usuariosimagen_GXI ;
      private string AV48GridBadge ;
      private string AV92Imagen_GXI ;
      private string AV60GridListaBadge ;
      private string AV24CardRight1_AdditionalData ;
      private string AV22CardRight2_AdditionalData ;
      private string AV20CardRight3_AdditionalData ;
      private string AV18CardRight4_AdditionalData ;
      private string AV53ParametrosValor ;
      private string AV72usuariosImagen ;
      private string AV82Imagen ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebGrid GridprofesionalesContainer ;
      private GXWebGrid GridlistaContainer ;
      private GXWebRow GridRow ;
      private GXWebRow GridlistaRow ;
      private GXWebRow GridprofesionalesRow ;
      private GXWebColumn GridprofesionalesColumn ;
      private GXWebColumn GridColumn ;
      private GXWebColumn GridlistaColumn ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucInnewwindow ;
      private GXUserControl ucNewwindow ;
      private GXUserControl ucGridlista_titlescategories ;
      private GXUserControl ucGridlista_empowerer ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucCardright1_progress ;
      private GXUserControl ucCardright2_progress ;
      private GXUserControl ucCardright3_progress ;
      private GXUserControl ucCardright4_progress ;
      private GXUserControl ucCard2_progress ;
      private GXUserControl ucCard1_progress ;
      private GXUserControl ucCard3_progress ;
      private GXUserControl ucCard4_progress ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEstadosgenericosid ;
      private GXCombobox dynSolicitudesUsrAlta ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbAgrupacionEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ;
      private GXBaseCollection<SdtSDTFeedBack_Items> AV75SDTFeedBack ;
      private IDataStoreProvider pr_default ;
      private long[] H00BV2_A127SolicitudesID ;
      private short[] H00BV2_A134SolicitudesItemsID ;
      private decimal[] H00BV2_A180SolicitudItemsComision ;
      private string[] H00BV2_A179SolicitudItemsComisionTipo ;
      private string[] H00BV2_A178SolicitudItemsSR ;
      private short[] H00BV2_A177SolicitudesItemsCantidad ;
      private decimal[] H00BV2_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00BV2_n176SolicitudesItemsPrecioFinal ;
      private int[] H00BV3_A108EstadosGenericosId ;
      private string[] H00BV3_A109EstadosGenericosNombre ;
      private string[] H00BV3_A107EstadosTipo ;
      private long[] H00BV4_A597SolicitudesUsrAlta ;
      private bool[] H00BV4_n597SolicitudesUsrAlta ;
      private string[] H00BV4_A132EstadosSolNombre ;
      private int[] H00BV4_A131EstadosSolId ;
      private string[] H00BV4_A130EstadosSolTipo ;
      private string[] H00BV4_A113DepartamentoDepartamento ;
      private long[] H00BV4_A110ZonasID ;
      private bool[] H00BV4_n110ZonasID ;
      private long[] H00BV4_A114DepartamentoMunicipioId ;
      private bool[] H00BV4_n114DepartamentoMunicipioId ;
      private long[] H00BV4_A112DepartamentoId ;
      private bool[] H00BV4_n112DepartamentoId ;
      private string[] H00BV4_A116PaisID ;
      private DateTime[] H00BV4_A184SolicitudesFechaInstalacion ;
      private string[] H00BV4_A172SolicitudesTelefono ;
      private string[] H00BV4_A171SolicitudesNombre ;
      private string[] H00BV4_A282ProveedorNombre ;
      private long[] H00BV4_A133ProveedorID ;
      private long[] H00BV4_A127SolicitudesID ;
      private DateTime[] H00BV4_A182SolicitudesFechaAlta ;
      private bool[] H00BV4_n182SolicitudesFechaAlta ;
      private decimal[] H00BV4_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00BV4_A212SolicitudesCotizacion ;
      private decimal[] H00BV4_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00BV4_A897SolicitudesDescuento ;
      private bool[] H00BV4_n897SolicitudesDescuento ;
      private decimal[] H00BV4_A864SolicitudesCostoXZona ;
      private long[] H00BV5_A133ProveedorID ;
      private string[] H00BV5_A282ProveedorNombre ;
      private string[] H00BV5_A588AgrupacionEstado ;
      private string[] H00BV5_A166ProfesionalesPrimerNombre ;
      private string[] H00BV5_A167ProfesionalesApellidoPrimero ;
      private string[] H00BV5_A120ProfesionalesId ;
      private string[] H00BV5_A591ListaTipo ;
      private long[] H00BV5_A590Listaid ;
      private long[] H00BV6_AGRID_nRecordCount ;
      private long[] H00BV7_AGRIDLISTA_nRecordCount ;
      private GXBaseCollection<SdtSDTFeedBack_Items> GXt_objcol_SdtSDTFeedBack_Items1 ;
      private SdtSDTCantSol AV62SDTCantSol ;
      private SdtSDTCantSol GXt_SdtSDTCantSol2 ;
      private SdtSDTFeedBack_Items AV81Item ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00BV8_A18SecUserId ;
      private string[] H00BV8_A26SecUserName ;
      private long[] H00BV9_A18SecUserId ;
      private string[] H00BV9_A26SecUserName ;
   }

   public class dashboardcom__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BV4( IGxContext context ,
                                             int AV51EstadosGenericosID ,
                                             long AV5ProveedorID ,
                                             string AV52Buscar ,
                                             int A131EstadosSolId ,
                                             long A133ProveedorID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             long A127SolicitudesID ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV49FechaIni ,
                                             DateTime AV50FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SolicitudesUsrAlta], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T3.[DepartamentoDepartamento], T1.[ZonasID], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T3.[PaisID], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T4.[ProveedorNombre], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesFechaAlta], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona]";
         sFromString = " FROM ((([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) LEFT JOIN [Departamento] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV5ProveedorID)");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV49FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV50FechaFin)");
         if ( ! ( AV51EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV51EstadosGenericosID)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV5ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV5ProveedorID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Buscar)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[SolicitudesNombre])) like RTRIM(LTRIM(@lV52Buscar)) or RTRIM(LTRIM(T1.[SolicitudesTelefono])) like RTRIM(LTRIM(@lV52Buscar)) or ( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like @lV52Buscar))");
         }
         else
         {
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         sOrderString += " ORDER BY T1.[ProveedorID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00BV6( IGxContext context ,
                                             int AV51EstadosGenericosID ,
                                             long AV5ProveedorID ,
                                             string AV52Buscar ,
                                             int A131EstadosSolId ,
                                             long A133ProveedorID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             long A127SolicitudesID ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV49FechaIni ,
                                             DateTime AV50FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[8];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Solicitudes] T1 INNER JOIN [EstadosGenericos] T4 ON T4.[EstadosTipo] = T1.[EstadosSolTipo] AND T4.[EstadosGenericosId] = T1.[EstadosSolId]) LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[ProveedorID])";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV5ProveedorID)");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV49FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV50FechaFin)");
         if ( ! ( AV51EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV51EstadosGenericosID)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV5ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV5ProveedorID)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Buscar)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[SolicitudesNombre])) like RTRIM(LTRIM(@lV52Buscar)) or RTRIM(LTRIM(T1.[SolicitudesTelefono])) like RTRIM(LTRIM(@lV52Buscar)) or ( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like @lV52Buscar))");
         }
         else
         {
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H00BV4(context, (int)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
               case 4 :
                     return conditional_H00BV6(context, (int)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00BV2;
          prmH00BV2 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00BV3;
          prmH00BV3 = new Object[] {
          };
          Object[] prmH00BV5;
          prmH00BV5 = new Object[] {
          };
          Object[] prmH00BV7;
          prmH00BV7 = new Object[] {
          };
          Object[] prmH00BV8;
          prmH00BV8 = new Object[] {
          };
          Object[] prmH00BV9;
          prmH00BV9 = new Object[] {
          };
          Object[] prmH00BV4;
          prmH00BV4 = new Object[] {
          new ParDef("@AV5ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV49FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV50FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV51EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV5ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00BV6;
          prmH00BV6 = new Object[] {
          new ParDef("@AV5ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV49FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV50FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV51EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV5ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0) ,
          new ParDef("@lV52Buscar",GXType.Char,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BV2", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BV3", "SELECT [EstadosGenericosId], [EstadosGenericosNombre], [EstadosTipo] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BV4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV4,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BV5", "SELECT T1.[ProveedorID], T2.[ProveedorNombre], T1.[AgrupacionEstado], T3.[ProfesionalesPrimerNombre], T3.[ProfesionalesApellidoPrimero], T1.[ProfesionalesId], T4.[ListaTipo], T1.[Listaid] FROM ((([ListaAgrupacion] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Lista] T4 ON T4.[Listaid] = T1.[Listaid]) ORDER BY T1.[Listaid], T1.[ProveedorID], T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV5,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00BV6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BV7", "SELECT COUNT(*) FROM ((([ListaAgrupacion] T1 INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Profesionales] T4 ON T4.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV7,1, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00BV8", "SELECT [SecUserId], [SecUserName] FROM [SecUser] ORDER BY [SecUserName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV8,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BV9", "SELECT [SecUserId], [SecUserName] FROM [SecUser] ORDER BY [SecUserName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BV9,0, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 2);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((string[]) buf[15])[0] = rslt.getString(12, 100);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((long[]) buf[17])[0] = rslt.getLong(14);
                ((long[]) buf[18])[0] = rslt.getLong(15);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(21);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
