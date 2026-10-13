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
   public class solicitudesreporteww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudesreporteww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesreporteww( IGxContext context )
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
         cmbSolicitudesSubTipo = new GXCombobox();
         cmbSolicitudServicioOrigenPago = new GXCombobox();
         cmbSolicitudesPagado = new GXCombobox();
         chkSolicitudesOtros1 = new GXCheckbox();
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         AV204SolicitudesFechaInstalacion = context.localUtil.ParseDateParm( GetPar( "SolicitudesFechaInstalacion"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV50ColumnsSelector);
         AV212Pgmname = GetPar( "Pgmname");
         AV205SolicitudesFechaInstalacion_To = context.localUtil.ParseDateParm( GetPar( "SolicitudesFechaInstalacion_To"));
         AV56TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV57TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSolicitudesID_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV133TFSolicitudesSubTipo_Sels);
         AV139TFEstadosSolNombre = GetPar( "TFEstadosSolNombre");
         AV140TFEstadosSolNombre_Sel = GetPar( "TFEstadosSolNombre_Sel");
         AV64TFProveedorNombre = GetPar( "TFProveedorNombre");
         AV65TFProveedorNombre_Sel = GetPar( "TFProveedorNombre_Sel");
         AV58TFSolicitudesNombre = GetPar( "TFSolicitudesNombre");
         AV59TFSolicitudesNombre_Sel = GetPar( "TFSolicitudesNombre_Sel");
         AV90TFSolicitudesTelefono = GetPar( "TFSolicitudesTelefono");
         AV91TFSolicitudesTelefono_Sel = GetPar( "TFSolicitudesTelefono_Sel");
         AV92TFSolicitudesMail = GetPar( "TFSolicitudesMail");
         AV93TFSolicitudesMail_Sel = GetPar( "TFSolicitudesMail_Sel");
         AV94TFPaisID = GetPar( "TFPaisID");
         AV95TFPaisID_Sel = GetPar( "TFPaisID_Sel");
         AV98TFDepartamentoDepartamento = GetPar( "TFDepartamentoDepartamento");
         AV99TFDepartamentoDepartamento_Sel = GetPar( "TFDepartamentoDepartamento_Sel");
         AV102TFDepartamentoMunicipioNombre = GetPar( "TFDepartamentoMunicipioNombre");
         AV103TFDepartamentoMunicipioNombre_Sel = GetPar( "TFDepartamentoMunicipioNombre_Sel");
         AV106TFSolicitudesDireccion = GetPar( "TFSolicitudesDireccion");
         AV107TFSolicitudesDireccion_Sel = GetPar( "TFSolicitudesDireccion_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV142TFSolicitudServicioOrigenPago_Sels);
         AV143TFMetodoPagosNombre = GetPar( "TFMetodoPagosNombre");
         AV144TFMetodoPagosNombre_Sel = GetPar( "TFMetodoPagosNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV146TFSolicitudesPagado_Sels);
         AV147TFSolicitudServicioPFinal = NumberUtil.Val( GetPar( "TFSolicitudServicioPFinal"), ".");
         AV148TFSolicitudServicioPFinal_To = NumberUtil.Val( GetPar( "TFSolicitudServicioPFinal_To"), ".");
         AV149TFSolicitudesCotizacion = NumberUtil.Val( GetPar( "TFSolicitudesCotizacion"), ".");
         AV150TFSolicitudesCotizacion_To = NumberUtil.Val( GetPar( "TFSolicitudesCotizacion_To"), ".");
         AV151TFSolicitudesDescuento = NumberUtil.Val( GetPar( "TFSolicitudesDescuento"), ".");
         AV152TFSolicitudesDescuento_To = NumberUtil.Val( GetPar( "TFSolicitudesDescuento_To"), ".");
         AV153TFSolicitudServicioComALM = NumberUtil.Val( GetPar( "TFSolicitudServicioComALM"), ".");
         AV154TFSolicitudServicioComALM_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComALM_To"), ".");
         AV155TFSolicitudServicioComALMP = NumberUtil.Val( GetPar( "TFSolicitudServicioComALMP"), ".");
         AV156TFSolicitudServicioComALMP_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComALMP_To"), ".");
         AV157TFSolicitudServicioComPro = NumberUtil.Val( GetPar( "TFSolicitudServicioComPro"), ".");
         AV158TFSolicitudServicioComPro_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComPro_To"), ".");
         AV159TFSolicitudServicioComProP = NumberUtil.Val( GetPar( "TFSolicitudServicioComProP"), ".");
         AV160TFSolicitudServicioComProP_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComProP_To"), ".");
         AV161TFSolicitudServicioComProv = NumberUtil.Val( GetPar( "TFSolicitudServicioComProv"), ".");
         AV162TFSolicitudServicioComProv_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComProv_To"), ".");
         AV163TFSolicitudServicioComProvP = NumberUtil.Val( GetPar( "TFSolicitudServicioComProvP"), ".");
         AV164TFSolicitudServicioComProvP_To = NumberUtil.Val( GetPar( "TFSolicitudServicioComProvP_To"), ".");
         AV165TFSolicitudesCostoXZComAlm = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComAlm"), ".");
         AV166TFSolicitudesCostoXZComAlm_To = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComAlm_To"), ".");
         AV167TFSolicitudesCostoXZComAlmP = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComAlmP"), ".");
         AV168TFSolicitudesCostoXZComAlmP_To = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComAlmP_To"), ".");
         AV169TFSolicitudesCostoXZComProf = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComProf"), ".");
         AV170TFSolicitudesCostoXZComProf_To = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComProf_To"), ".");
         AV171TFSolicitudesCostoXZComProfP = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComProfP"), ".");
         AV172TFSolicitudesCostoXZComProfP_To = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZComProfP_To"), ".");
         AV173TFSolicitudesCostoXZona = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZona"), ".");
         AV174TFSolicitudesCostoXZona_To = NumberUtil.Val( GetPar( "TFSolicitudesCostoXZona_To"), ".");
         AV210TFCancelacionTipificacionDescripcion = GetPar( "TFCancelacionTipificacionDescripcion");
         AV211TFCancelacionTipificacionDescripcion_Sel = GetPar( "TFCancelacionTipificacionDescripcion_Sel");
         AV175TFSolicitudesNota = GetPar( "TFSolicitudesNota");
         AV176TFSolicitudesNota_Sel = GetPar( "TFSolicitudesNota_Sel");
         AV177TFSolicitudesComentario = GetPar( "TFSolicitudesComentario");
         AV178TFSolicitudesComentario_Sel = GetPar( "TFSolicitudesComentario_Sel");
         AV179TFSolicitudesOtros2 = GetPar( "TFSolicitudesOtros2");
         AV180TFSolicitudesOtros2_Sel = GetPar( "TFSolicitudesOtros2_Sel");
         AV181TFSolicitudesOtros3 = GetPar( "TFSolicitudesOtros3");
         AV182TFSolicitudesOtros3_Sel = GetPar( "TFSolicitudesOtros3_Sel");
         AV183TFSolicitudesFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFSolicitudesFechaAlta"));
         AV184TFSolicitudesFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFSolicitudesFechaAlta_To"));
         AV188TFSolicitudesFechaActualizacion = context.localUtil.ParseDTimeParm( GetPar( "TFSolicitudesFechaActualizacion"));
         AV189TFSolicitudesFechaActualizacion_To = context.localUtil.ParseDTimeParm( GetPar( "TFSolicitudesFechaActualizacion_To"));
         AV193IsAuthorized_EstadosSolNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosSolNombre"));
         AV124IsAuthorized_DepartamentoDepartamento = StringUtil.StrToBool( GetPar( "IsAuthorized_DepartamentoDepartamento"));
         AV194IsAuthorized_MetodoPagosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_MetodoPagosNombre"));
         A18SecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
         A26SecUserName = GetPar( "SecUserName");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
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
         /* Using cursor H00JW2 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H00JW2_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H00JW2_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H00JW2_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H00JW2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00JW2_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])-(H00JW2_A180SolicitudItemsComision[0]*H00JW2_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H00JW2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H00JW2_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])+(H00JW2_A180SolicitudItemsComision[0]*H00JW2_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H00JW2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00JW2_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])-((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])*(H00JW2_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H00JW2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H00JW2_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])+((H00JW2_A176SolicitudesItemsPrecioFinal[0]*H00JW2_A177SolicitudesItemsCantidad[0])*(H00JW2_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         PAJW2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJW2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudesreporteww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV212Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV212Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV193IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV193IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", AV124IsAuthorized_DepartamentoDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", GetSecureSignedToken( "", AV124IsAuthorized_DepartamentoDepartamento, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_METODOPAGOSNOMBRE", AV194IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( "", AV194IsAuthorized_MetodoPagosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vSOLICITUDESFECHAINSTALACION", context.localUtil.Format(AV204SolicitudesFechaInstalacion, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV115GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV116GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV125AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV125AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESFECHAINSTALACION_TO", context.localUtil.DToC( AV205SolicitudesFechaInstalacion_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV112DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV112DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV50ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV50ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_SOLICITUDESFECHAALTAAUXDATETO", context.localUtil.DToC( AV186DDO_SolicitudesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATETO", context.localUtil.DToC( AV191DDO_SolicitudesFechaActualizacionAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV212Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV212Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57TFSolicitudesID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSOLICITUDESSUBTIPO_SELS", AV133TFSolicitudesSubTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSOLICITUDESSUBTIPO_SELS", AV133TFSolicitudesSubTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFESTADOSSOLNOMBRE", StringUtil.RTrim( AV139TFEstadosSolNombre));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSSOLNOMBRE_SEL", StringUtil.RTrim( AV140TFEstadosSolNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE", StringUtil.RTrim( AV64TFProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV65TFProveedorNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESNOMBRE", StringUtil.RTrim( AV58TFSolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESNOMBRE_SEL", StringUtil.RTrim( AV59TFSolicitudesNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESTELEFONO", StringUtil.RTrim( AV90TFSolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESTELEFONO_SEL", StringUtil.RTrim( AV91TFSolicitudesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESMAIL", AV92TFSolicitudesMail);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESMAIL_SEL", AV93TFSolicitudesMail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPAISID", StringUtil.RTrim( AV94TFPaisID));
         GxWebStd.gx_hidden_field( context, "vTFPAISID_SEL", StringUtil.RTrim( AV95TFPaisID_Sel));
         GxWebStd.gx_hidden_field( context, "vTFDEPARTAMENTODEPARTAMENTO", StringUtil.RTrim( AV98TFDepartamentoDepartamento));
         GxWebStd.gx_hidden_field( context, "vTFDEPARTAMENTODEPARTAMENTO_SEL", StringUtil.RTrim( AV99TFDepartamentoDepartamento_Sel));
         GxWebStd.gx_hidden_field( context, "vTFDEPARTAMENTOMUNICIPIONOMBRE", StringUtil.RTrim( AV102TFDepartamentoMunicipioNombre));
         GxWebStd.gx_hidden_field( context, "vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL", StringUtil.RTrim( AV103TFDepartamentoMunicipioNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESDIRECCION", AV106TFSolicitudesDireccion);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESDIRECCION_SEL", AV107TFSolicitudesDireccion_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSOLICITUDSERVICIOORIGENPAGO_SELS", AV142TFSolicitudServicioOrigenPago_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSOLICITUDSERVICIOORIGENPAGO_SELS", AV142TFSolicitudServicioOrigenPago_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMETODOPAGOSNOMBRE", StringUtil.RTrim( AV143TFMetodoPagosNombre));
         GxWebStd.gx_hidden_field( context, "vTFMETODOPAGOSNOMBRE_SEL", StringUtil.RTrim( AV144TFMetodoPagosNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSOLICITUDESPAGADO_SELS", AV146TFSolicitudesPagado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSOLICITUDESPAGADO_SELS", AV146TFSolicitudesPagado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOPFINAL", StringUtil.LTrim( StringUtil.NToC( AV147TFSolicitudServicioPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOPFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV148TFSolicitudServicioPFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOTIZACION", StringUtil.LTrim( StringUtil.NToC( AV149TFSolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOTIZACION_TO", StringUtil.LTrim( StringUtil.NToC( AV150TFSolicitudesCotizacion_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESDESCUENTO", StringUtil.LTrim( StringUtil.NToC( AV151TFSolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESDESCUENTO_TO", StringUtil.LTrim( StringUtil.NToC( AV152TFSolicitudesDescuento_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMALM", StringUtil.LTrim( StringUtil.NToC( AV153TFSolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMALM_TO", StringUtil.LTrim( StringUtil.NToC( AV154TFSolicitudServicioComALM_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMALMP", StringUtil.LTrim( StringUtil.NToC( AV155TFSolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMALMP_TO", StringUtil.LTrim( StringUtil.NToC( AV156TFSolicitudServicioComALMP_To, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPRO", StringUtil.LTrim( StringUtil.NToC( AV157TFSolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPRO_TO", StringUtil.LTrim( StringUtil.NToC( AV158TFSolicitudServicioComPro_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROP", StringUtil.LTrim( StringUtil.NToC( AV159TFSolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROP_TO", StringUtil.LTrim( StringUtil.NToC( AV160TFSolicitudServicioComProP_To, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROV", StringUtil.LTrim( StringUtil.NToC( AV161TFSolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROV_TO", StringUtil.LTrim( StringUtil.NToC( AV162TFSolicitudServicioComProv_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROVP", StringUtil.LTrim( StringUtil.NToC( AV163TFSolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOCOMPROVP_TO", StringUtil.LTrim( StringUtil.NToC( AV164TFSolicitudServicioComProvP_To, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMALM", StringUtil.LTrim( StringUtil.NToC( AV165TFSolicitudesCostoXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMALM_TO", StringUtil.LTrim( StringUtil.NToC( AV166TFSolicitudesCostoXZComAlm_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMALMP", StringUtil.LTrim( StringUtil.NToC( AV167TFSolicitudesCostoXZComAlmP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMALMP_TO", StringUtil.LTrim( StringUtil.NToC( AV168TFSolicitudesCostoXZComAlmP_To, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMPROF", StringUtil.LTrim( StringUtil.NToC( AV169TFSolicitudesCostoXZComProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMPROF_TO", StringUtil.LTrim( StringUtil.NToC( AV170TFSolicitudesCostoXZComProf_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMPROFP", StringUtil.LTrim( StringUtil.NToC( AV171TFSolicitudesCostoXZComProfP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZCOMPROFP_TO", StringUtil.LTrim( StringUtil.NToC( AV172TFSolicitudesCostoXZComProfP_To, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZONA", StringUtil.LTrim( StringUtil.NToC( AV173TFSolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOSTOXZONA_TO", StringUtil.LTrim( StringUtil.NToC( AV174TFSolicitudesCostoXZona_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCANCELACIONTIPIFICACIONDESCRIPCION", StringUtil.RTrim( AV210TFCancelacionTipificacionDescripcion));
         GxWebStd.gx_hidden_field( context, "vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL", StringUtil.RTrim( AV211TFCancelacionTipificacionDescripcion_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESNOTA", StringUtil.RTrim( AV175TFSolicitudesNota));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESNOTA_SEL", StringUtil.RTrim( AV176TFSolicitudesNota_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOMENTARIO", AV177TFSolicitudesComentario);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESCOMENTARIO_SEL", AV178TFSolicitudesComentario_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESOTROS2", StringUtil.RTrim( AV179TFSolicitudesOtros2));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESOTROS2_SEL", StringUtil.RTrim( AV180TFSolicitudesOtros2_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESOTROS3", StringUtil.RTrim( AV181TFSolicitudesOtros3));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESOTROS3_SEL", StringUtil.RTrim( AV182TFSolicitudesOtros3_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESFECHAALTA", context.localUtil.DToC( AV183TFSolicitudesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESFECHAALTA_TO", context.localUtil.DToC( AV184TFSolicitudesFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESFECHAACTUALIZACION", context.localUtil.TToC( AV188TFSolicitudesFechaActualizacion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESFECHAACTUALIZACION_TO", context.localUtil.TToC( AV189TFSolicitudesFechaActualizacion_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV193IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV193IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_hidden_field( context, "ESTADOSSOLTIPO", StringUtil.RTrim( A130EstadosSolTipo));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", AV124IsAuthorized_DepartamentoDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", GetSecureSignedToken( "", AV124IsAuthorized_DepartamentoDepartamento, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_METODOPAGOSNOMBRE", AV194IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( "", AV194IsAuthorized_MetodoPagosNombre, context));
         GxWebStd.gx_hidden_field( context, "METODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SECUSERNAME", A26SecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESSUBTIPO_SELSJSON", AV132TFSolicitudesSubTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDSERVICIOORIGENPAGO_SELSJSON", AV141TFSolicitudServicioOrigenPago_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFSOLICITUDESPAGADO_SELSJSON", AV145TFSolicitudesPagado_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESTOTAL", StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESCOMISIONMETODOPAGO", StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESFECHAINSTALACION", context.localUtil.DToC( AV204SolicitudesFechaInstalacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_SOLICITUDESFECHAALTAAUXDATE", context.localUtil.DToC( AV185DDO_SolicitudesFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATE", context.localUtil.DToC( AV190DDO_SolicitudesFechaActualizacionAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WEJW2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJW2( ) ;
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
         return formatLink("solicitudesreporteww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SolicitudesReporteWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Solicitudes Reporte", "") ;
      }

      protected void WBJW0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_21_JW2( true) ;
         }
         else
         {
            wb_table1_21_JW2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_JW2e( bool wbgen )
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
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV114GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV115GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV116GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV125AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucSolicitudesfechainstalacion_rangepicker.SetProperty("Start Date", AV204SolicitudesFechaInstalacion);
            ucSolicitudesfechainstalacion_rangepicker.SetProperty("End Date", AV205SolicitudesFechaInstalacion_To);
            ucSolicitudesfechainstalacion_rangepicker.Render(context, "wwp.daterangepicker", Solicitudesfechainstalacion_rangepicker_Internalname, "SOLICITUDESFECHAINSTALACION_RANGEPICKERContainer");
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV112DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV112DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV50ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_39_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechaini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechaini_Internalname, context.localUtil.Format(AV198FechaIni, "99/99/99"), context.localUtil.Format( AV198FechaIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechaini_Jsonclick, 0, "Attribute", "", "", "", "", edtavFechaini_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_bitmap( context, edtavFechaini_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavFechaini_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporteWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_39_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechafin_Internalname, context.localUtil.Format(AV199FechaFin, "99/99/99"), context.localUtil.Format( AV199FechaFin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechafin_Jsonclick, 0, "Attribute", "", "", "", "", edtavFechafin_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_bitmap( context, edtavFechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavFechafin_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporteWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_39_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFecharef_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFecharef_Internalname, context.localUtil.Format(AV207FechaRef, "99/99/99"), context.localUtil.Format( AV207FechaRef, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFecharef_Jsonclick, 0, "Attribute", "", "", "", "", edtavFecharef_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_bitmap( context, edtavFecharef_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavFecharef_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudesReporteWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_solicitudesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_solicitudesfechaaltaauxdatetext_Internalname, AV187DDO_SolicitudesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV187DDO_SolicitudesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_solicitudesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporteWW.htm");
            /* User Defined Control */
            ucTfsolicitudesfechaalta_rangepicker.SetProperty("Start Date", AV185DDO_SolicitudesFechaAltaAuxDate);
            ucTfsolicitudesfechaalta_rangepicker.SetProperty("End Date", AV186DDO_SolicitudesFechaAltaAuxDateTo);
            ucTfsolicitudesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfsolicitudesfechaalta_rangepicker_Internalname, "TFSOLICITUDESFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_solicitudesfechaactualizacionauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_solicitudesfechaactualizacionauxdatetext_Internalname, AV192DDO_SolicitudesFechaActualizacionAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV192DDO_SolicitudesFechaActualizacionAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_solicitudesfechaactualizacionauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporteWW.htm");
            /* User Defined Control */
            ucTfsolicitudesfechaactualizacion_rangepicker.SetProperty("Start Date", AV190DDO_SolicitudesFechaActualizacionAuxDate);
            ucTfsolicitudesfechaactualizacion_rangepicker.SetProperty("End Date", AV191DDO_SolicitudesFechaActualizacionAuxDateTo);
            ucTfsolicitudesfechaactualizacion_rangepicker.Render(context, "wwp.daterangepicker", Tfsolicitudesfechaactualizacion_rangepicker_Internalname, "TFSOLICITUDESFECHAACTUALIZACION_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 39 )
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

      protected void STARTJW2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Solicitudes Reporte", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJW0( ) ;
      }

      protected void WSJW2( )
      {
         STARTJW2( ) ;
         EVTJW2( ) ;
      }

      protected void EVTJW2( )
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
                              E11JW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12JW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E13JW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SOLICITUDESFECHAINSTALACION_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Solicitudesfechainstalacion_rangepicker.Daterangechanged */
                              E14JW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15JW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E16JW2 ();
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
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              AV200ProfesionalId = cgiGet( edtavProfesionalid_Internalname);
                              AssignAttri("", false, edtavProfesionalid_Internalname, AV200ProfesionalId);
                              AV201Profesional = cgiGet( edtavProfesional_Internalname);
                              AssignAttri("", false, edtavProfesional_Internalname, AV201Profesional);
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbSolicitudesSubTipo.Name = cmbSolicitudesSubTipo_Internalname;
                              cmbSolicitudesSubTipo.CurrentValue = cgiGet( cmbSolicitudesSubTipo_Internalname);
                              A600SolicitudesSubTipo = cgiGet( cmbSolicitudesSubTipo_Internalname);
                              n600SolicitudesSubTipo = false;
                              A184SolicitudesFechaInstalacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSolicitudesFechaInstalacion_Internalname), 0));
                              AV128HoraInstalacion = cgiGet( edtavHorainstalacion_Internalname);
                              AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
                              AV129Dia = cgiGet( edtavDia_Internalname);
                              AssignAttri("", false, edtavDia_Internalname, AV129Dia);
                              A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
                              A140RelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
                              A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
                              A206SolicitudesMail = cgiGet( edtSolicitudesMail_Internalname);
                              n206SolicitudesMail = false;
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n112DepartamentoId = false;
                              A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
                              A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n114DepartamentoMunicipioId = false;
                              A115DepartamentoMunicipioNombre = cgiGet( edtDepartamentoMunicipioNombre_Internalname);
                              A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n110ZonasID = false;
                              A173SolicitudesDireccion = cgiGet( edtSolicitudesDireccion_Internalname);
                              A194SolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbSolicitudServicioOrigenPago.Name = cmbSolicitudServicioOrigenPago_Internalname;
                              cmbSolicitudServicioOrigenPago.CurrentValue = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
                              A438SolicitudServicioOrigenPago = cgiGet( cmbSolicitudServicioOrigenPago_Internalname);
                              n438SolicitudServicioOrigenPago = false;
                              A129MetodoPagosNombre = cgiGet( edtMetodoPagosNombre_Internalname);
                              cmbSolicitudesPagado.Name = cmbSolicitudesPagado_Internalname;
                              cmbSolicitudesPagado.CurrentValue = cgiGet( cmbSolicitudesPagado_Internalname);
                              A441SolicitudesPagado = cgiGet( cmbSolicitudesPagado_Internalname);
                              n441SolicitudesPagado = false;
                              A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A212SolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A897SolicitudesDescuento = context.localUtil.CToN( cgiGet( edtSolicitudesDescuento_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n897SolicitudesDescuento = false;
                              A530SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n530SolicitudServicioComALM = false;
                              A532SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n532SolicitudServicioComALMP = false;
                              A529SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtSolicitudServicioComPro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A531SolicitudServicioComProP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A527SolicitudServicioComProv = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n527SolicitudServicioComProv = false;
                              A528SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( edtSolicitudServicioComProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n528SolicitudServicioComProvP = false;
                              A865SolicitudesCostoXZComAlm = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n865SolicitudesCostoXZComAlm = false;
                              A866SolicitudesCostoXZComAlmP = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComAlmP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n866SolicitudesCostoXZComAlmP = false;
                              A867SolicitudesCostoXZComProf = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComProf_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A868SolicitudesCostoXZComProfP = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZComProfP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A864SolicitudesCostoXZona = context.localUtil.CToN( cgiGet( edtSolicitudesCostoXZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A997CancelacionTipificacionDescrip = cgiGet( edtCancelacionTipificacionDescrip_Internalname);
                              A261SolicitudesNota = cgiGet( edtSolicitudesNota_Internalname);
                              A205SolicitudesComentario = cgiGet( edtSolicitudesComentario_Internalname);
                              A183SolicitudesHoraInstalacion = cgiGet( edtSolicitudesHoraInstalacion_Internalname);
                              A201SolicitudesOtros1 = ((StringUtil.StrCmp(cgiGet( chkSolicitudesOtros1_Internalname), "S")==0) ? "S" : "N");
                              A202SolicitudesOtros2 = cgiGet( edtSolicitudesOtros2_Internalname);
                              A203SolicitudesOtros3 = cgiGet( edtSolicitudesOtros3_Internalname);
                              A598SolicitudesUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n598SolicitudesUsrActualizacion = false;
                              A597SolicitudesUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n597SolicitudesUsrAlta = false;
                              AV130UserAlta = cgiGet( edtavUseralta_Internalname);
                              AssignAttri("", false, edtavUseralta_Internalname, AV130UserAlta);
                              AV131UserUPD = cgiGet( edtavUserupd_Internalname);
                              AssignAttri("", false, edtavUserupd_Internalname, AV131UserUPD);
                              A182SolicitudesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSolicitudesFechaAlta_Internalname), 0));
                              n182SolicitudesFechaAlta = false;
                              A204SolicitudesFechaActualizacion = context.localUtil.CToT( cgiGet( edtSolicitudesFechaActualizacion_Internalname), 0);
                              n204SolicitudesFechaActualizacion = false;
                              AV202Existe = cgiGet( edtavExiste_Internalname);
                              AssignAttri("", false, edtavExiste_Internalname, AV202Existe);
                              A996CancelacionTipificacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCancelacionTipificacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17JW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18JW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19JW2 ();
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
                                       /* Set Refresh If Solicitudesfechainstalacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vSOLICITUDESFECHAINSTALACION"), 0) != AV204SolicitudesFechaInstalacion )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEJW2( )
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

      protected void PAJW2( )
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
               GX_FocusControl = edtavSolicitudesfechainstalacion_rangetext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       DateTime AV204SolicitudesFechaInstalacion ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV50ColumnsSelector ,
                                       string AV212Pgmname ,
                                       DateTime AV205SolicitudesFechaInstalacion_To ,
                                       long AV56TFSolicitudesID ,
                                       long AV57TFSolicitudesID_To ,
                                       GxSimpleCollection<string> AV133TFSolicitudesSubTipo_Sels ,
                                       string AV139TFEstadosSolNombre ,
                                       string AV140TFEstadosSolNombre_Sel ,
                                       string AV64TFProveedorNombre ,
                                       string AV65TFProveedorNombre_Sel ,
                                       string AV58TFSolicitudesNombre ,
                                       string AV59TFSolicitudesNombre_Sel ,
                                       string AV90TFSolicitudesTelefono ,
                                       string AV91TFSolicitudesTelefono_Sel ,
                                       string AV92TFSolicitudesMail ,
                                       string AV93TFSolicitudesMail_Sel ,
                                       string AV94TFPaisID ,
                                       string AV95TFPaisID_Sel ,
                                       string AV98TFDepartamentoDepartamento ,
                                       string AV99TFDepartamentoDepartamento_Sel ,
                                       string AV102TFDepartamentoMunicipioNombre ,
                                       string AV103TFDepartamentoMunicipioNombre_Sel ,
                                       string AV106TFSolicitudesDireccion ,
                                       string AV107TFSolicitudesDireccion_Sel ,
                                       GxSimpleCollection<string> AV142TFSolicitudServicioOrigenPago_Sels ,
                                       string AV143TFMetodoPagosNombre ,
                                       string AV144TFMetodoPagosNombre_Sel ,
                                       GxSimpleCollection<string> AV146TFSolicitudesPagado_Sels ,
                                       decimal AV147TFSolicitudServicioPFinal ,
                                       decimal AV148TFSolicitudServicioPFinal_To ,
                                       decimal AV149TFSolicitudesCotizacion ,
                                       decimal AV150TFSolicitudesCotizacion_To ,
                                       decimal AV151TFSolicitudesDescuento ,
                                       decimal AV152TFSolicitudesDescuento_To ,
                                       decimal AV153TFSolicitudServicioComALM ,
                                       decimal AV154TFSolicitudServicioComALM_To ,
                                       decimal AV155TFSolicitudServicioComALMP ,
                                       decimal AV156TFSolicitudServicioComALMP_To ,
                                       decimal AV157TFSolicitudServicioComPro ,
                                       decimal AV158TFSolicitudServicioComPro_To ,
                                       decimal AV159TFSolicitudServicioComProP ,
                                       decimal AV160TFSolicitudServicioComProP_To ,
                                       decimal AV161TFSolicitudServicioComProv ,
                                       decimal AV162TFSolicitudServicioComProv_To ,
                                       decimal AV163TFSolicitudServicioComProvP ,
                                       decimal AV164TFSolicitudServicioComProvP_To ,
                                       decimal AV165TFSolicitudesCostoXZComAlm ,
                                       decimal AV166TFSolicitudesCostoXZComAlm_To ,
                                       decimal AV167TFSolicitudesCostoXZComAlmP ,
                                       decimal AV168TFSolicitudesCostoXZComAlmP_To ,
                                       decimal AV169TFSolicitudesCostoXZComProf ,
                                       decimal AV170TFSolicitudesCostoXZComProf_To ,
                                       decimal AV171TFSolicitudesCostoXZComProfP ,
                                       decimal AV172TFSolicitudesCostoXZComProfP_To ,
                                       decimal AV173TFSolicitudesCostoXZona ,
                                       decimal AV174TFSolicitudesCostoXZona_To ,
                                       string AV210TFCancelacionTipificacionDescripcion ,
                                       string AV211TFCancelacionTipificacionDescripcion_Sel ,
                                       string AV175TFSolicitudesNota ,
                                       string AV176TFSolicitudesNota_Sel ,
                                       string AV177TFSolicitudesComentario ,
                                       string AV178TFSolicitudesComentario_Sel ,
                                       string AV179TFSolicitudesOtros2 ,
                                       string AV180TFSolicitudesOtros2_Sel ,
                                       string AV181TFSolicitudesOtros3 ,
                                       string AV182TFSolicitudesOtros3_Sel ,
                                       DateTime AV183TFSolicitudesFechaAlta ,
                                       DateTime AV184TFSolicitudesFechaAlta_To ,
                                       DateTime AV188TFSolicitudesFechaActualizacion ,
                                       DateTime AV189TFSolicitudesFechaActualizacion_To ,
                                       bool AV193IsAuthorized_EstadosSolNombre ,
                                       bool AV124IsAuthorized_DepartamentoDepartamento ,
                                       bool AV194IsAuthorized_MetodoPagosNombre ,
                                       long A18SecUserId ,
                                       string A26SecUserName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFJW2( ) ;
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
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFJW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV212Pgmname = "SolicitudesReporteWW";
         edtavProfesionalid_Enabled = 0;
         edtavProfesional_Enabled = 0;
         edtavHorainstalacion_Enabled = 0;
         edtavDia_Enabled = 0;
         edtavUseralta_Enabled = 0;
         edtavUserupd_Enabled = 0;
         edtavExiste_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
         GRID_nRecordCount = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A600SolicitudesSubTipo ,
                                              AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                              A441SolicitudesPagado ,
                                              AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                              AV213Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                              AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                              AV215Solicitudesreportewwds_3_tfsolicitudesid ,
                                              AV216Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                              AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels.Count ,
                                              AV219Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                              AV218Solicitudesreportewwds_6_tfestadossolnombre ,
                                              AV221Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                              AV220Solicitudesreportewwds_8_tfproveedornombre ,
                                              AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                              AV222Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                              AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                              AV224Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                              AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                              AV226Solicitudesreportewwds_14_tfsolicitudesmail ,
                                              AV229Solicitudesreportewwds_17_tfpaisid_sel ,
                                              AV228Solicitudesreportewwds_16_tfpaisid ,
                                              AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                              AV230Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                              AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                              AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                              AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                              AV234Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                              AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                              AV237Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                              AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels.Count ,
                                              AV242Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                              AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                              AV244Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                              AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                              AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                              AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                              AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                              AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                              AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                              AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                              AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                              AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                              AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                              AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                              AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                              AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                              AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                              AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                              AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                              AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                              AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                              AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                              AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                              AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                              AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                              AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                              AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                              AV270Solicitudesreportewwds_58_tfsolicitudesnota ,
                                              AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                              AV272Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                              AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                              AV274Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                              AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                              AV276Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                              AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                              AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                              AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                              AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                              A184SolicitudesFechaInstalacion ,
                                              A127SolicitudesID ,
                                              A132EstadosSolNombre ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A116PaisID ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre ,
                                              A173SolicitudesDireccion ,
                                              A129MetodoPagosNombre ,
                                              A212SolicitudesCotizacion ,
                                              A897SolicitudesDescuento ,
                                              A530SolicitudServicioComALM ,
                                              A532SolicitudServicioComALMP ,
                                              A528SolicitudServicioComProvP ,
                                              A527SolicitudServicioComProv ,
                                              A865SolicitudesCostoXZComAlm ,
                                              A866SolicitudesCostoXZComAlmP ,
                                              A864SolicitudesCostoXZona ,
                                              A997CancelacionTipificacionDescrip ,
                                              A261SolicitudesNota ,
                                              A205SolicitudesComentario ,
                                              A202SolicitudesOtros2 ,
                                              A203SolicitudesOtros3 ,
                                              A182SolicitudesFechaAlta ,
                                              A204SolicitudesFechaActualizacion ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                              AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                              A529SolicitudServicioComPro ,
                                              AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV218Solicitudesreportewwds_6_tfestadossolnombre = StringUtil.PadR( StringUtil.RTrim( AV218Solicitudesreportewwds_6_tfestadossolnombre), 80, "%");
         lV220Solicitudesreportewwds_8_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV220Solicitudesreportewwds_8_tfproveedornombre), 80, "%");
         lV222Solicitudesreportewwds_10_tfsolicitudesnombre = StringUtil.PadR( StringUtil.RTrim( AV222Solicitudesreportewwds_10_tfsolicitudesnombre), 100, "%");
         lV224Solicitudesreportewwds_12_tfsolicitudestelefono = StringUtil.PadR( StringUtil.RTrim( AV224Solicitudesreportewwds_12_tfsolicitudestelefono), 20, "%");
         lV226Solicitudesreportewwds_14_tfsolicitudesmail = StringUtil.Concat( StringUtil.RTrim( AV226Solicitudesreportewwds_14_tfsolicitudesmail), "%", "");
         lV228Solicitudesreportewwds_16_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV228Solicitudesreportewwds_16_tfpaisid), 2, "%");
         lV230Solicitudesreportewwds_18_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV230Solicitudesreportewwds_18_tfdepartamentodepartamento), 80, "%");
         lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre), 120, "%");
         lV234Solicitudesreportewwds_22_tfsolicitudesdireccion = StringUtil.Concat( StringUtil.RTrim( AV234Solicitudesreportewwds_22_tfsolicitudesdireccion), "%", "");
         lV237Solicitudesreportewwds_25_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV237Solicitudesreportewwds_25_tfmetodopagosnombre), 80, "%");
         lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = StringUtil.PadR( StringUtil.RTrim( AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion), 250, "%");
         lV270Solicitudesreportewwds_58_tfsolicitudesnota = StringUtil.PadR( StringUtil.RTrim( AV270Solicitudesreportewwds_58_tfsolicitudesnota), 500, "%");
         lV272Solicitudesreportewwds_60_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV272Solicitudesreportewwds_60_tfsolicitudescomentario), "%", "");
         lV274Solicitudesreportewwds_62_tfsolicitudesotros2 = StringUtil.PadR( StringUtil.RTrim( AV274Solicitudesreportewwds_62_tfsolicitudesotros2), 1000, "%");
         lV276Solicitudesreportewwds_64_tfsolicitudesotros3 = StringUtil.PadR( StringUtil.RTrim( AV276Solicitudesreportewwds_64_tfsolicitudesotros3), 500, "%");
         /* Using cursor H00JW3 */
         pr_default.execute(1, new Object[] {AV213Solicitudesreportewwds_1_solicitudesfechainstalacion, AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to, AV215Solicitudesreportewwds_3_tfsolicitudesid, AV216Solicitudesreportewwds_4_tfsolicitudesid_to, lV218Solicitudesreportewwds_6_tfestadossolnombre, AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, lV220Solicitudesreportewwds_8_tfproveedornombre, AV221Solicitudesreportewwds_9_tfproveedornombre_sel, lV222Solicitudesreportewwds_10_tfsolicitudesnombre, AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, lV224Solicitudesreportewwds_12_tfsolicitudestelefono, AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, lV226Solicitudesreportewwds_14_tfsolicitudesmail, AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, lV228Solicitudesreportewwds_16_tfpaisid, AV229Solicitudesreportewwds_17_tfpaisid_sel, lV230Solicitudesreportewwds_18_tfdepartamentodepartamento, AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre, AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, lV234Solicitudesreportewwds_22_tfsolicitudesdireccion, AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, lV237Solicitudesreportewwds_25_tfmetodopagosnombre, AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, AV242Solicitudesreportewwds_30_tfsolicitudescotizacion, AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to, AV244Solicitudesreportewwds_32_tfsolicitudesdescuento, AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to, AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm, AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to, AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp, AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to, AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop, AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to, AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov, AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to, AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp, AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to, AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm, AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to, AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp, AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to, AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof, AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to, AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp, AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to, AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona, AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to, lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion, AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, lV270Solicitudesreportewwds_58_tfsolicitudesnota, AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, lV272Solicitudesreportewwds_60_tfsolicitudescomentario, AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, lV274Solicitudesreportewwds_62_tfsolicitudesotros2, AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, lV276Solicitudesreportewwds_64_tfsolicitudesotros3, AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta, AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to, AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion, AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A598SolicitudesUsrActualizacion = H00JW3_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = H00JW3_n598SolicitudesUsrActualizacion[0];
            A597SolicitudesUsrAlta = H00JW3_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = H00JW3_n597SolicitudesUsrAlta[0];
            A130EstadosSolTipo = H00JW3_A130EstadosSolTipo[0];
            A128MetodoPagosID = H00JW3_A128MetodoPagosID[0];
            A996CancelacionTipificacionId = H00JW3_A996CancelacionTipificacionId[0];
            A204SolicitudesFechaActualizacion = H00JW3_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = H00JW3_n204SolicitudesFechaActualizacion[0];
            A182SolicitudesFechaAlta = H00JW3_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = H00JW3_n182SolicitudesFechaAlta[0];
            A203SolicitudesOtros3 = H00JW3_A203SolicitudesOtros3[0];
            A202SolicitudesOtros2 = H00JW3_A202SolicitudesOtros2[0];
            A201SolicitudesOtros1 = H00JW3_A201SolicitudesOtros1[0];
            A183SolicitudesHoraInstalacion = H00JW3_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = H00JW3_A205SolicitudesComentario[0];
            A261SolicitudesNota = H00JW3_A261SolicitudesNota[0];
            A997CancelacionTipificacionDescrip = H00JW3_A997CancelacionTipificacionDescrip[0];
            A441SolicitudesPagado = H00JW3_A441SolicitudesPagado[0];
            n441SolicitudesPagado = H00JW3_n441SolicitudesPagado[0];
            A129MetodoPagosNombre = H00JW3_A129MetodoPagosNombre[0];
            A438SolicitudServicioOrigenPago = H00JW3_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = H00JW3_n438SolicitudServicioOrigenPago[0];
            A194SolicitudesAutoEnumerar = H00JW3_A194SolicitudesAutoEnumerar[0];
            A173SolicitudesDireccion = H00JW3_A173SolicitudesDireccion[0];
            A110ZonasID = H00JW3_A110ZonasID[0];
            n110ZonasID = H00JW3_n110ZonasID[0];
            A115DepartamentoMunicipioNombre = H00JW3_A115DepartamentoMunicipioNombre[0];
            A114DepartamentoMunicipioId = H00JW3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = H00JW3_n114DepartamentoMunicipioId[0];
            A113DepartamentoDepartamento = H00JW3_A113DepartamentoDepartamento[0];
            A112DepartamentoId = H00JW3_A112DepartamentoId[0];
            n112DepartamentoId = H00JW3_n112DepartamentoId[0];
            A116PaisID = H00JW3_A116PaisID[0];
            A206SolicitudesMail = H00JW3_A206SolicitudesMail[0];
            n206SolicitudesMail = H00JW3_n206SolicitudesMail[0];
            A172SolicitudesTelefono = H00JW3_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = H00JW3_A171SolicitudesNombre[0];
            A282ProveedorNombre = H00JW3_A282ProveedorNombre[0];
            A133ProveedorID = H00JW3_A133ProveedorID[0];
            A132EstadosSolNombre = H00JW3_A132EstadosSolNombre[0];
            A131EstadosSolId = H00JW3_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = H00JW3_A184SolicitudesFechaInstalacion[0];
            A600SolicitudesSubTipo = H00JW3_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = H00JW3_n600SolicitudesSubTipo[0];
            A127SolicitudesID = H00JW3_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = H00JW3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = H00JW3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = H00JW3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = H00JW3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = H00JW3_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = H00JW3_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = H00JW3_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = H00JW3_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = H00JW3_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = H00JW3_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = H00JW3_n532SolicitudServicioComALMP[0];
            A528SolicitudServicioComProvP = H00JW3_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = H00JW3_n528SolicitudServicioComProvP[0];
            A865SolicitudesCostoXZComAlm = H00JW3_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = H00JW3_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = H00JW3_A864SolicitudesCostoXZona[0];
            A866SolicitudesCostoXZComAlmP = H00JW3_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = H00JW3_n866SolicitudesCostoXZComAlmP[0];
            A129MetodoPagosNombre = H00JW3_A129MetodoPagosNombre[0];
            A997CancelacionTipificacionDescrip = H00JW3_A997CancelacionTipificacionDescrip[0];
            A113DepartamentoDepartamento = H00JW3_A113DepartamentoDepartamento[0];
            A116PaisID = H00JW3_A116PaisID[0];
            A115DepartamentoMunicipioNombre = H00JW3_A115DepartamentoMunicipioNombre[0];
            A282ProveedorNombre = H00JW3_A282ProveedorNombre[0];
            A132EstadosSolNombre = H00JW3_A132EstadosSolNombre[0];
            if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
            {
               A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
            }
            else
            {
               if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
               }
               else
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               }
            }
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            }
            if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
            {
               A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
            }
            else
            {
               if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                  }
                  else
                  {
                     A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                  }
               }
            }
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
            if ( (Convert.ToDecimal(0)==AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ) ) )
               {
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                        else
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                     }
                  }
                  if ( (Convert.ToDecimal(0)==AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro) || ( ( A529SolicitudServicioComPro >= AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ) ) )
                  {
                     if ( (Convert.ToDecimal(0)==AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to) || ( ( A529SolicitudServicioComPro <= AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to ) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFJW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E18JW2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_392( ) ;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A600SolicitudesSubTipo ,
                                                 AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                                 A438SolicitudServicioOrigenPago ,
                                                 AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                                 A441SolicitudesPagado ,
                                                 AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                                 AV213Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                                 AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                                 AV215Solicitudesreportewwds_3_tfsolicitudesid ,
                                                 AV216Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                                 AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels.Count ,
                                                 AV219Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                                 AV218Solicitudesreportewwds_6_tfestadossolnombre ,
                                                 AV221Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                                 AV220Solicitudesreportewwds_8_tfproveedornombre ,
                                                 AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                                 AV222Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                                 AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                                 AV224Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                                 AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                                 AV226Solicitudesreportewwds_14_tfsolicitudesmail ,
                                                 AV229Solicitudesreportewwds_17_tfpaisid_sel ,
                                                 AV228Solicitudesreportewwds_16_tfpaisid ,
                                                 AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                                 AV230Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                                 AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                                 AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                                 AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                                 AV234Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                                 AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels.Count ,
                                                 AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                                 AV237Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                                 AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels.Count ,
                                                 AV242Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                                 AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                                 AV244Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                                 AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                                 AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                                 AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                                 AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                                 AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                                 AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                                 AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                                 AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                                 AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                                 AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                                 AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                                 AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                                 AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                                 AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                                 AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                                 AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                                 AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                                 AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                                 AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                                 AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                                 AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                                 AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                                 AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                                 AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                                 AV270Solicitudesreportewwds_58_tfsolicitudesnota ,
                                                 AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                                 AV272Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                                 AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                                 AV274Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                                 AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                                 AV276Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                                 AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                                 AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                                 AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                                 AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 A127SolicitudesID ,
                                                 A132EstadosSolNombre ,
                                                 A282ProveedorNombre ,
                                                 A171SolicitudesNombre ,
                                                 A172SolicitudesTelefono ,
                                                 A206SolicitudesMail ,
                                                 A116PaisID ,
                                                 A113DepartamentoDepartamento ,
                                                 A115DepartamentoMunicipioNombre ,
                                                 A173SolicitudesDireccion ,
                                                 A129MetodoPagosNombre ,
                                                 A212SolicitudesCotizacion ,
                                                 A897SolicitudesDescuento ,
                                                 A530SolicitudServicioComALM ,
                                                 A532SolicitudServicioComALMP ,
                                                 A528SolicitudServicioComProvP ,
                                                 A527SolicitudServicioComProv ,
                                                 A865SolicitudesCostoXZComAlm ,
                                                 A866SolicitudesCostoXZComAlmP ,
                                                 A864SolicitudesCostoXZona ,
                                                 A997CancelacionTipificacionDescrip ,
                                                 A261SolicitudesNota ,
                                                 A205SolicitudesComentario ,
                                                 A202SolicitudesOtros2 ,
                                                 A203SolicitudesOtros3 ,
                                                 A182SolicitudesFechaAlta ,
                                                 A204SolicitudesFechaActualizacion ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                                 A211SolicitudServicioPFinal ,
                                                 AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                                 AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                                 A529SolicitudServicioComPro ,
                                                 AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                                 }
            });
            lV218Solicitudesreportewwds_6_tfestadossolnombre = StringUtil.PadR( StringUtil.RTrim( AV218Solicitudesreportewwds_6_tfestadossolnombre), 80, "%");
            lV220Solicitudesreportewwds_8_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV220Solicitudesreportewwds_8_tfproveedornombre), 80, "%");
            lV222Solicitudesreportewwds_10_tfsolicitudesnombre = StringUtil.PadR( StringUtil.RTrim( AV222Solicitudesreportewwds_10_tfsolicitudesnombre), 100, "%");
            lV224Solicitudesreportewwds_12_tfsolicitudestelefono = StringUtil.PadR( StringUtil.RTrim( AV224Solicitudesreportewwds_12_tfsolicitudestelefono), 20, "%");
            lV226Solicitudesreportewwds_14_tfsolicitudesmail = StringUtil.Concat( StringUtil.RTrim( AV226Solicitudesreportewwds_14_tfsolicitudesmail), "%", "");
            lV228Solicitudesreportewwds_16_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV228Solicitudesreportewwds_16_tfpaisid), 2, "%");
            lV230Solicitudesreportewwds_18_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV230Solicitudesreportewwds_18_tfdepartamentodepartamento), 80, "%");
            lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre), 120, "%");
            lV234Solicitudesreportewwds_22_tfsolicitudesdireccion = StringUtil.Concat( StringUtil.RTrim( AV234Solicitudesreportewwds_22_tfsolicitudesdireccion), "%", "");
            lV237Solicitudesreportewwds_25_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV237Solicitudesreportewwds_25_tfmetodopagosnombre), 80, "%");
            lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = StringUtil.PadR( StringUtil.RTrim( AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion), 250, "%");
            lV270Solicitudesreportewwds_58_tfsolicitudesnota = StringUtil.PadR( StringUtil.RTrim( AV270Solicitudesreportewwds_58_tfsolicitudesnota), 500, "%");
            lV272Solicitudesreportewwds_60_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV272Solicitudesreportewwds_60_tfsolicitudescomentario), "%", "");
            lV274Solicitudesreportewwds_62_tfsolicitudesotros2 = StringUtil.PadR( StringUtil.RTrim( AV274Solicitudesreportewwds_62_tfsolicitudesotros2), 1000, "%");
            lV276Solicitudesreportewwds_64_tfsolicitudesotros3 = StringUtil.PadR( StringUtil.RTrim( AV276Solicitudesreportewwds_64_tfsolicitudesotros3), 500, "%");
            /* Using cursor H00JW4 */
            pr_default.execute(2, new Object[] {AV213Solicitudesreportewwds_1_solicitudesfechainstalacion, AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to, AV215Solicitudesreportewwds_3_tfsolicitudesid, AV216Solicitudesreportewwds_4_tfsolicitudesid_to, lV218Solicitudesreportewwds_6_tfestadossolnombre, AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, lV220Solicitudesreportewwds_8_tfproveedornombre, AV221Solicitudesreportewwds_9_tfproveedornombre_sel, lV222Solicitudesreportewwds_10_tfsolicitudesnombre, AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, lV224Solicitudesreportewwds_12_tfsolicitudestelefono, AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, lV226Solicitudesreportewwds_14_tfsolicitudesmail, AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, lV228Solicitudesreportewwds_16_tfpaisid, AV229Solicitudesreportewwds_17_tfpaisid_sel, lV230Solicitudesreportewwds_18_tfdepartamentodepartamento, AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre, AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, lV234Solicitudesreportewwds_22_tfsolicitudesdireccion, AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, lV237Solicitudesreportewwds_25_tfmetodopagosnombre, AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, AV242Solicitudesreportewwds_30_tfsolicitudescotizacion, AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to, AV244Solicitudesreportewwds_32_tfsolicitudesdescuento, AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to, AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm, AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to, AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp, AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to, AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop, AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to, AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov, AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to, AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp, AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to, AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm, AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to, AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp, AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to, AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof, AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to, AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp, AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to, AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona, AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to, lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion, AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, lV270Solicitudesreportewwds_58_tfsolicitudesnota, AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, lV272Solicitudesreportewwds_60_tfsolicitudescomentario, AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, lV274Solicitudesreportewwds_62_tfsolicitudesotros2, AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, lV276Solicitudesreportewwds_64_tfsolicitudesotros3, AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta, AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to, AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion, AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A598SolicitudesUsrActualizacion = H00JW4_A598SolicitudesUsrActualizacion[0];
               n598SolicitudesUsrActualizacion = H00JW4_n598SolicitudesUsrActualizacion[0];
               A597SolicitudesUsrAlta = H00JW4_A597SolicitudesUsrAlta[0];
               n597SolicitudesUsrAlta = H00JW4_n597SolicitudesUsrAlta[0];
               A130EstadosSolTipo = H00JW4_A130EstadosSolTipo[0];
               A128MetodoPagosID = H00JW4_A128MetodoPagosID[0];
               A996CancelacionTipificacionId = H00JW4_A996CancelacionTipificacionId[0];
               A204SolicitudesFechaActualizacion = H00JW4_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = H00JW4_n204SolicitudesFechaActualizacion[0];
               A182SolicitudesFechaAlta = H00JW4_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = H00JW4_n182SolicitudesFechaAlta[0];
               A203SolicitudesOtros3 = H00JW4_A203SolicitudesOtros3[0];
               A202SolicitudesOtros2 = H00JW4_A202SolicitudesOtros2[0];
               A201SolicitudesOtros1 = H00JW4_A201SolicitudesOtros1[0];
               A183SolicitudesHoraInstalacion = H00JW4_A183SolicitudesHoraInstalacion[0];
               A205SolicitudesComentario = H00JW4_A205SolicitudesComentario[0];
               A261SolicitudesNota = H00JW4_A261SolicitudesNota[0];
               A997CancelacionTipificacionDescrip = H00JW4_A997CancelacionTipificacionDescrip[0];
               A441SolicitudesPagado = H00JW4_A441SolicitudesPagado[0];
               n441SolicitudesPagado = H00JW4_n441SolicitudesPagado[0];
               A129MetodoPagosNombre = H00JW4_A129MetodoPagosNombre[0];
               A438SolicitudServicioOrigenPago = H00JW4_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = H00JW4_n438SolicitudServicioOrigenPago[0];
               A194SolicitudesAutoEnumerar = H00JW4_A194SolicitudesAutoEnumerar[0];
               A173SolicitudesDireccion = H00JW4_A173SolicitudesDireccion[0];
               A110ZonasID = H00JW4_A110ZonasID[0];
               n110ZonasID = H00JW4_n110ZonasID[0];
               A115DepartamentoMunicipioNombre = H00JW4_A115DepartamentoMunicipioNombre[0];
               A114DepartamentoMunicipioId = H00JW4_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = H00JW4_n114DepartamentoMunicipioId[0];
               A113DepartamentoDepartamento = H00JW4_A113DepartamentoDepartamento[0];
               A112DepartamentoId = H00JW4_A112DepartamentoId[0];
               n112DepartamentoId = H00JW4_n112DepartamentoId[0];
               A116PaisID = H00JW4_A116PaisID[0];
               A206SolicitudesMail = H00JW4_A206SolicitudesMail[0];
               n206SolicitudesMail = H00JW4_n206SolicitudesMail[0];
               A172SolicitudesTelefono = H00JW4_A172SolicitudesTelefono[0];
               A171SolicitudesNombre = H00JW4_A171SolicitudesNombre[0];
               A282ProveedorNombre = H00JW4_A282ProveedorNombre[0];
               A133ProveedorID = H00JW4_A133ProveedorID[0];
               A132EstadosSolNombre = H00JW4_A132EstadosSolNombre[0];
               A131EstadosSolId = H00JW4_A131EstadosSolId[0];
               A184SolicitudesFechaInstalacion = H00JW4_A184SolicitudesFechaInstalacion[0];
               A600SolicitudesSubTipo = H00JW4_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = H00JW4_n600SolicitudesSubTipo[0];
               A127SolicitudesID = H00JW4_A127SolicitudesID[0];
               A796SolicitudesComisionMetodoPago = H00JW4_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H00JW4_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H00JW4_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H00JW4_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H00JW4_n897SolicitudesDescuento[0];
               A527SolicitudServicioComProv = H00JW4_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = H00JW4_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = H00JW4_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = H00JW4_n530SolicitudServicioComALM[0];
               A532SolicitudServicioComALMP = H00JW4_A532SolicitudServicioComALMP[0];
               n532SolicitudServicioComALMP = H00JW4_n532SolicitudServicioComALMP[0];
               A528SolicitudServicioComProvP = H00JW4_A528SolicitudServicioComProvP[0];
               n528SolicitudServicioComProvP = H00JW4_n528SolicitudServicioComProvP[0];
               A865SolicitudesCostoXZComAlm = H00JW4_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = H00JW4_n865SolicitudesCostoXZComAlm[0];
               A864SolicitudesCostoXZona = H00JW4_A864SolicitudesCostoXZona[0];
               A866SolicitudesCostoXZComAlmP = H00JW4_A866SolicitudesCostoXZComAlmP[0];
               n866SolicitudesCostoXZComAlmP = H00JW4_n866SolicitudesCostoXZComAlmP[0];
               A129MetodoPagosNombre = H00JW4_A129MetodoPagosNombre[0];
               A997CancelacionTipificacionDescrip = H00JW4_A997CancelacionTipificacionDescrip[0];
               A113DepartamentoDepartamento = H00JW4_A113DepartamentoDepartamento[0];
               A116PaisID = H00JW4_A116PaisID[0];
               A115DepartamentoMunicipioNombre = H00JW4_A115DepartamentoMunicipioNombre[0];
               A282ProveedorNombre = H00JW4_A282ProveedorNombre[0];
               A132EstadosSolNombre = H00JW4_A132EstadosSolNombre[0];
               if ( ( A866SolicitudesCostoXZComAlmP >= Convert.ToDecimal( 0 )) )
               {
                  A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
               }
               else
               {
                  if ( ( A866SolicitudesCostoXZComAlmP < Convert.ToDecimal( 0 )) )
                  {
                     A868SolicitudesCostoXZComProfP = (decimal)(100+(A866SolicitudesCostoXZComAlmP*-1));
                  }
                  else
                  {
                     A868SolicitudesCostoXZComProfP = (decimal)(100-(A866SolicitudesCostoXZComAlmP));
                  }
               }
               if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
               {
                  A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
               }
               else
               {
                  A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
               }
               if ( ( A532SolicitudServicioComALMP >= Convert.ToDecimal( 0 )) )
               {
                  A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
               }
               else
               {
                  if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP >= Convert.ToDecimal( 0 )) )
                  {
                     A531SolicitudServicioComProP = (decimal)((100-A528SolicitudServicioComProvP)+(A532SolicitudServicioComALMP*-1));
                  }
                  else
                  {
                     if ( ( A532SolicitudServicioComALMP < Convert.ToDecimal( 0 )) && ( A528SolicitudServicioComProvP < Convert.ToDecimal( 0 )) )
                     {
                        A531SolicitudServicioComProP = (decimal)(100+((A528SolicitudServicioComProvP+A532SolicitudServicioComALMP)*-1));
                     }
                     else
                     {
                        A531SolicitudServicioComProP = (decimal)(100-(A528SolicitudServicioComProvP+A532SolicitudServicioComALMP));
                     }
                  }
               }
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
               if ( (Convert.ToDecimal(0)==AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ) ) )
                  {
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                        }
                        else
                        {
                           if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                           else
                           {
                              A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                           }
                        }
                     }
                     if ( (Convert.ToDecimal(0)==AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro) || ( ( A529SolicitudServicioComPro >= AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ) ) )
                     {
                        if ( (Convert.ToDecimal(0)==AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to) || ( ( A529SolicitudServicioComPro <= AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to ) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E19JW2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 39;
            WBJW0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJW2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV212Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV212Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSSOLNOMBRE", AV193IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV193IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", AV124IsAuthorized_DepartamentoDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", GetSecureSignedToken( "", AV124IsAuthorized_DepartamentoDepartamento, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_METODOPAGOSNOMBRE", AV194IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( "", AV194IsAuthorized_MetodoPagosNombre, context));
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
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV212Pgmname = "SolicitudesReporteWW";
         edtavProfesionalid_Enabled = 0;
         edtavProfesional_Enabled = 0;
         edtavHorainstalacion_Enabled = 0;
         edtavDia_Enabled = 0;
         edtavUseralta_Enabled = 0;
         edtavUserupd_Enabled = 0;
         edtavExiste_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         cmbSolicitudesSubTipo.Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtRelacionesId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesMail_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoMunicipioNombre_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtSolicitudesDireccion_Enabled = 0;
         edtSolicitudesAutoEnumerar_Enabled = 0;
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         edtMetodoPagosNombre_Enabled = 0;
         cmbSolicitudesPagado.Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         edtSolicitudesCotizacion_Enabled = 0;
         edtSolicitudesDescuento_Enabled = 0;
         edtSolicitudServicioComALM_Enabled = 0;
         edtSolicitudServicioComALMP_Enabled = 0;
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudServicioComProP_Enabled = 0;
         edtSolicitudServicioComProv_Enabled = 0;
         edtSolicitudServicioComProvP_Enabled = 0;
         edtSolicitudesCostoXZComAlm_Enabled = 0;
         edtSolicitudesCostoXZComAlmP_Enabled = 0;
         edtSolicitudesCostoXZComProf_Enabled = 0;
         edtSolicitudesCostoXZComProfP_Enabled = 0;
         edtSolicitudesCostoXZona_Enabled = 0;
         edtCancelacionTipificacionDescrip_Enabled = 0;
         edtSolicitudesNota_Enabled = 0;
         edtSolicitudesComentario_Enabled = 0;
         edtSolicitudesHoraInstalacion_Enabled = 0;
         chkSolicitudesOtros1.Enabled = 0;
         edtSolicitudesOtros2_Enabled = 0;
         edtSolicitudesOtros3_Enabled = 0;
         edtSolicitudesUsrActualizacion_Enabled = 0;
         edtSolicitudesUsrAlta_Enabled = 0;
         edtSolicitudesFechaAlta_Enabled = 0;
         edtSolicitudesFechaActualizacion_Enabled = 0;
         edtCancelacionTipificacionId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17JW2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV125AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV112DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV50ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV114GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV115GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV116GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV204SolicitudesFechaInstalacion = context.localUtil.CToD( cgiGet( "vSOLICITUDESFECHAINSTALACION"), 0);
            AssignAttri("", false, "AV204SolicitudesFechaInstalacion", context.localUtil.Format(AV204SolicitudesFechaInstalacion, "99/99/99"));
            AV205SolicitudesFechaInstalacion_To = context.localUtil.CToD( cgiGet( "vSOLICITUDESFECHAINSTALACION_TO"), 0);
            AssignAttri("", false, "AV205SolicitudesFechaInstalacion_To", context.localUtil.Format(AV205SolicitudesFechaInstalacion_To, "99/99/99"));
            AV185DDO_SolicitudesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_SOLICITUDESFECHAALTAAUXDATE"), 0);
            AV186DDO_SolicitudesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_SOLICITUDESFECHAALTAAUXDATETO"), 0);
            AV190DDO_SolicitudesFechaActualizacionAuxDate = context.localUtil.CToD( cgiGet( "vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATE"), 0);
            AssignAttri("", false, "AV190DDO_SolicitudesFechaActualizacionAuxDate", context.localUtil.Format(AV190DDO_SolicitudesFechaActualizacionAuxDate, "99/99/99"));
            AV191DDO_SolicitudesFechaActualizacionAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATETO"), 0);
            AssignAttri("", false, "AV191DDO_SolicitudesFechaActualizacionAuxDateTo", context.localUtil.Format(AV191DDO_SolicitudesFechaActualizacionAuxDateTo, "99/99/99"));
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
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV206SolicitudesFechaInstalacion_RangeText = cgiGet( edtavSolicitudesfechainstalacion_rangetext_Internalname);
            AssignAttri("", false, "AV206SolicitudesFechaInstalacion_RangeText", AV206SolicitudesFechaInstalacion_RangeText);
            if ( context.localUtil.VCDate( cgiGet( edtavFechaini_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ini", "")}), 1, "vFECHAINI");
               GX_FocusControl = edtavFechaini_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV198FechaIni = DateTime.MinValue;
               AssignAttri("", false, "AV198FechaIni", context.localUtil.Format(AV198FechaIni, "99/99/99"));
            }
            else
            {
               AV198FechaIni = context.localUtil.CToD( cgiGet( edtavFechaini_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV198FechaIni", context.localUtil.Format(AV198FechaIni, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechafin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Fin", "")}), 1, "vFECHAFIN");
               GX_FocusControl = edtavFechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV199FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV199FechaFin", context.localUtil.Format(AV199FechaFin, "99/99/99"));
            }
            else
            {
               AV199FechaFin = context.localUtil.CToD( cgiGet( edtavFechafin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV199FechaFin", context.localUtil.Format(AV199FechaFin, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFecharef_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ref", "")}), 1, "vFECHAREF");
               GX_FocusControl = edtavFecharef_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV207FechaRef = DateTime.MinValue;
               AssignAttri("", false, "AV207FechaRef", context.localUtil.Format(AV207FechaRef, "99/99/99"));
            }
            else
            {
               AV207FechaRef = context.localUtil.CToD( cgiGet( edtavFecharef_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV207FechaRef", context.localUtil.Format(AV207FechaRef, "99/99/99"));
            }
            AV187DDO_SolicitudesFechaAltaAuxDateText = cgiGet( edtavDdo_solicitudesfechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV187DDO_SolicitudesFechaAltaAuxDateText", AV187DDO_SolicitudesFechaAltaAuxDateText);
            AV192DDO_SolicitudesFechaActualizacionAuxDateText = cgiGet( edtavDdo_solicitudesfechaactualizacionauxdatetext_Internalname);
            AssignAttri("", false, "AV192DDO_SolicitudesFechaActualizacionAuxDateText", AV192DDO_SolicitudesFechaActualizacionAuxDateText);
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
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vSOLICITUDESFECHAINSTALACION"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV204SolicitudesFechaInstalacion ) )
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
         E17JW2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17JW2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV199FechaFin = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV199FechaFin", context.localUtil.Format(AV199FechaFin, "99/99/99"));
         AV198FechaIni = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV198FechaIni", context.localUtil.Format(AV198FechaIni, "99/99/99"));
         AV199FechaFin = DateTimeUtil.DAdd(AV199FechaFin,+((int)(15)));
         AssignAttri("", false, "AV199FechaFin", context.localUtil.Format(AV199FechaFin, "99/99/99"));
         AV198FechaIni = DateTimeUtil.DAdd(AV198FechaIni,-((int)(30)));
         AssignAttri("", false, "AV198FechaIni", context.localUtil.Format(AV198FechaIni, "99/99/99"));
         AV208FechaFinText = context.localUtil.DToC( AV199FechaFin, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
         AV209FechaIniText = context.localUtil.DToC( AV198FechaIni, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
         AV134TFSolicitudesFechaInstalacion = context.localUtil.CToD( AV209FechaIniText, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         AV135TFSolicitudesFechaInstalacion_To = context.localUtil.CToD( AV208FechaFinText, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         this.executeUsercontrolMethod("", false, "TFSOLICITUDESFECHAACTUALIZACION_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_solicitudesfechaactualizacionauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFSOLICITUDESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_solicitudesfechaaltaauxdatetext_Internalname});
         edtavFechaini_Visible = 0;
         AssignProp("", false, edtavFechaini_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechaini_Visible), 5, 0), true);
         edtavFechafin_Visible = 0;
         AssignProp("", false, edtavFechafin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFechafin_Visible), 5, 0), true);
         edtavFecharef_Visible = 0;
         AssignProp("", false, edtavFecharef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFecharef_Visible), 5, 0), true);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV125AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV126AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV126AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV126AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV126AGExportDataItem.gxTpr_Eventkey = "Export";
         AV126AGExportDataItem.gxTpr_Isdivider = false;
         AV125AGExportData.Add(AV126AGExportDataItem, 0);
         GXt_boolean1 = AV193IsAuthorized_EstadosSolNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV193IsAuthorized_EstadosSolNombre = GXt_boolean1;
         AssignAttri("", false, "AV193IsAuthorized_EstadosSolNombre", AV193IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( "", AV193IsAuthorized_EstadosSolNombre, context));
         GXt_boolean1 = AV124IsAuthorized_DepartamentoDepartamento;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento", out  GXt_boolean1) ;
         AV124IsAuthorized_DepartamentoDepartamento = GXt_boolean1;
         AssignAttri("", false, "AV124IsAuthorized_DepartamentoDepartamento", AV124IsAuthorized_DepartamentoDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO", GetSecureSignedToken( "", AV124IsAuthorized_DepartamentoDepartamento, context));
         GXt_boolean1 = AV194IsAuthorized_MetodoPagosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
         AV194IsAuthorized_MetodoPagosNombre = GXt_boolean1;
         AssignAttri("", false, "AV194IsAuthorized_MetodoPagosNombre", AV194IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( "", AV194IsAuthorized_MetodoPagosNombre, context));
         this.executeUsercontrolMethod("", false, "SOLICITUDESFECHAINSTALACION_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavSolicitudesfechainstalacion_rangetext_Internalname});
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Solicitudes Reporte", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV112DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV112DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18JW2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV52Session.Get("SolicitudesReporteWWColumnsSelector"), "") != 0 )
         {
            AV48ColumnsSelectorXML = AV52Session.Get("SolicitudesReporteWWColumnsSelector");
            AV50ColumnsSelector.FromXml(AV48ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtavProfesionalid_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavProfesionalid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalid_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavProfesional_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavProfesional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesional_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesID_Visible), 5, 0), !bGXsfl_39_Refreshing);
         cmbSolicitudesSubTipo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSolicitudesSubTipo.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesFechaInstalacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesFechaInstalacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaInstalacion_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavHorainstalacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavHorainstalacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHorainstalacion_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavDia_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDia_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtEstadosSolNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosSolNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosSolNombre_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtProveedorNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesTelefono_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesMail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesMail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesMail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtPaisID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDepartamentoDepartamento_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(14)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDepartamentoDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDepartamentoDepartamento_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtDepartamentoMunicipioNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(15)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDepartamentoMunicipioNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioNombre_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesDireccion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(16)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesDireccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesDireccion_Visible), 5, 0), !bGXsfl_39_Refreshing);
         cmbSolicitudServicioOrigenPago.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(17)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSolicitudServicioOrigenPago.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtMetodoPagosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(18)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMetodoPagosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMetodoPagosNombre_Visible), 5, 0), !bGXsfl_39_Refreshing);
         cmbSolicitudesPagado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(19)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbSolicitudesPagado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSolicitudesPagado.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioPFinal_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(20)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioPFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioPFinal_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCotizacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(21)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCotizacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCotizacion_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesDescuento_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(22)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesDescuento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesDescuento_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComALM_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(23)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComALM_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALM_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComALMP_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(24)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComALMP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComALMP_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComPro_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(25)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComPro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComPro_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComProP_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(26)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComProP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProP_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComProv_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(27)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComProv_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProv_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudServicioComProvP_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(28)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudServicioComProvP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudServicioComProvP_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCostoXZComAlm_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(29)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCostoXZComAlm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComAlm_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCostoXZComAlmP_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(30)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCostoXZComAlmP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComAlmP_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCostoXZComProf_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(31)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCostoXZComProf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComProf_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCostoXZComProfP_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(32)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCostoXZComProfP_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZComProfP_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesCostoXZona_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(33)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesCostoXZona_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesCostoXZona_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtCancelacionTipificacionDescrip_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(34)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCancelacionTipificacionDescrip_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCancelacionTipificacionDescrip_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesNota_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(35)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesNota_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesNota_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesComentario_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(36)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesComentario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesComentario_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesOtros2_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(37)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesOtros2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros2_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesOtros3_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(38)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesOtros3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesOtros3_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavUseralta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(39)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavUseralta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseralta_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavUserupd_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(40)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavUserupd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserupd_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(41)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaAlta_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSolicitudesFechaActualizacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV50ColumnsSelector.gxTpr_Columns.Item(42)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSolicitudesFechaActualizacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSolicitudesFechaActualizacion_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV114GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV114GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV114GridCurrentPage), 10, 0));
         AV115GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV115GridPageCount", StringUtil.LTrimStr( (decimal)(AV115GridPageCount), 10, 0));
         GXt_char3 = AV116GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV212Pgmname, out  GXt_char3) ;
         AV116GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV116GridAppliedFilters", AV116GridAppliedFilters);
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = AV204SolicitudesFechaInstalacion;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = AV205SolicitudesFechaInstalacion_To;
         AV215Solicitudesreportewwds_3_tfsolicitudesid = AV56TFSolicitudesID;
         AV216Solicitudesreportewwds_4_tfsolicitudesid_to = AV57TFSolicitudesID_To;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = AV133TFSolicitudesSubTipo_Sels;
         AV218Solicitudesreportewwds_6_tfestadossolnombre = AV139TFEstadosSolNombre;
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = AV140TFEstadosSolNombre_Sel;
         AV220Solicitudesreportewwds_8_tfproveedornombre = AV64TFProveedorNombre;
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = AV65TFProveedorNombre_Sel;
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = AV58TFSolicitudesNombre;
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = AV59TFSolicitudesNombre_Sel;
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = AV90TFSolicitudesTelefono;
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = AV91TFSolicitudesTelefono_Sel;
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = AV92TFSolicitudesMail;
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = AV93TFSolicitudesMail_Sel;
         AV228Solicitudesreportewwds_16_tfpaisid = AV94TFPaisID;
         AV229Solicitudesreportewwds_17_tfpaisid_sel = AV95TFPaisID_Sel;
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = AV98TFDepartamentoDepartamento;
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = AV99TFDepartamentoDepartamento_Sel;
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = AV102TFDepartamentoMunicipioNombre;
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = AV103TFDepartamentoMunicipioNombre_Sel;
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = AV106TFSolicitudesDireccion;
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = AV107TFSolicitudesDireccion_Sel;
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = AV142TFSolicitudServicioOrigenPago_Sels;
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = AV143TFMetodoPagosNombre;
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = AV144TFMetodoPagosNombre_Sel;
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = AV146TFSolicitudesPagado_Sels;
         AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal = AV147TFSolicitudServicioPFinal;
         AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to = AV148TFSolicitudServicioPFinal_To;
         AV242Solicitudesreportewwds_30_tfsolicitudescotizacion = AV149TFSolicitudesCotizacion;
         AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to = AV150TFSolicitudesCotizacion_To;
         AV244Solicitudesreportewwds_32_tfsolicitudesdescuento = AV151TFSolicitudesDescuento;
         AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to = AV152TFSolicitudesDescuento_To;
         AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm = AV153TFSolicitudServicioComALM;
         AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to = AV154TFSolicitudServicioComALM_To;
         AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp = AV155TFSolicitudServicioComALMP;
         AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to = AV156TFSolicitudServicioComALMP_To;
         AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro = AV157TFSolicitudServicioComPro;
         AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to = AV158TFSolicitudServicioComPro_To;
         AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop = AV159TFSolicitudServicioComProP;
         AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to = AV160TFSolicitudServicioComProP_To;
         AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov = AV161TFSolicitudServicioComProv;
         AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to = AV162TFSolicitudServicioComProv_To;
         AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp = AV163TFSolicitudServicioComProvP;
         AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to = AV164TFSolicitudServicioComProvP_To;
         AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm = AV165TFSolicitudesCostoXZComAlm;
         AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to = AV166TFSolicitudesCostoXZComAlm_To;
         AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp = AV167TFSolicitudesCostoXZComAlmP;
         AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to = AV168TFSolicitudesCostoXZComAlmP_To;
         AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof = AV169TFSolicitudesCostoXZComProf;
         AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to = AV170TFSolicitudesCostoXZComProf_To;
         AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp = AV171TFSolicitudesCostoXZComProfP;
         AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to = AV172TFSolicitudesCostoXZComProfP_To;
         AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona = AV173TFSolicitudesCostoXZona;
         AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to = AV174TFSolicitudesCostoXZona_To;
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = AV210TFCancelacionTipificacionDescripcion;
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = AV211TFCancelacionTipificacionDescripcion_Sel;
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = AV175TFSolicitudesNota;
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = AV176TFSolicitudesNota_Sel;
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = AV177TFSolicitudesComentario;
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = AV178TFSolicitudesComentario_Sel;
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = AV179TFSolicitudesOtros2;
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = AV180TFSolicitudesOtros2_Sel;
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = AV181TFSolicitudesOtros3;
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = AV182TFSolicitudesOtros3_Sel;
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = AV183TFSolicitudesFechaAlta;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = AV184TFSolicitudesFechaAlta_To;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = AV188TFSolicitudesFechaActualizacion;
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = AV189TFSolicitudesFechaActualizacion_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ColumnsSelector", AV50ColumnsSelector);
      }

      protected void E11JW2( )
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
            AV113PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV113PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ColumnsSelector", AV50ColumnsSelector);
      }

      protected void E12JW2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15JW2( )
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesID") == 0 )
            {
               AV56TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFSolicitudesID", StringUtil.LTrimStr( (decimal)(AV56TFSolicitudesID), 18, 0));
               AV57TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFSolicitudesID_To", StringUtil.LTrimStr( (decimal)(AV57TFSolicitudesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesSubTipo") == 0 )
            {
               AV132TFSolicitudesSubTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV132TFSolicitudesSubTipo_SelsJson", AV132TFSolicitudesSubTipo_SelsJson);
               AV133TFSolicitudesSubTipo_Sels.FromJSonString(AV132TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosSolNombre") == 0 )
            {
               AV139TFEstadosSolNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV139TFEstadosSolNombre", AV139TFEstadosSolNombre);
               AV140TFEstadosSolNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV140TFEstadosSolNombre_Sel", AV140TFEstadosSolNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorNombre") == 0 )
            {
               AV64TFProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFProveedorNombre", AV64TFProveedorNombre);
               AV65TFProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFProveedorNombre_Sel", AV65TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesNombre") == 0 )
            {
               AV58TFSolicitudesNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFSolicitudesNombre", AV58TFSolicitudesNombre);
               AV59TFSolicitudesNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFSolicitudesNombre_Sel", AV59TFSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesTelefono") == 0 )
            {
               AV90TFSolicitudesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV90TFSolicitudesTelefono", AV90TFSolicitudesTelefono);
               AV91TFSolicitudesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV91TFSolicitudesTelefono_Sel", AV91TFSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesMail") == 0 )
            {
               AV92TFSolicitudesMail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV92TFSolicitudesMail", AV92TFSolicitudesMail);
               AV93TFSolicitudesMail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV93TFSolicitudesMail_Sel", AV93TFSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PaisID") == 0 )
            {
               AV94TFPaisID = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV94TFPaisID", AV94TFPaisID);
               AV95TFPaisID_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV95TFPaisID_Sel", AV95TFPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DepartamentoDepartamento") == 0 )
            {
               AV98TFDepartamentoDepartamento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV98TFDepartamentoDepartamento", AV98TFDepartamentoDepartamento);
               AV99TFDepartamentoDepartamento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV99TFDepartamentoDepartamento_Sel", AV99TFDepartamentoDepartamento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DepartamentoMunicipioNombre") == 0 )
            {
               AV102TFDepartamentoMunicipioNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV102TFDepartamentoMunicipioNombre", AV102TFDepartamentoMunicipioNombre);
               AV103TFDepartamentoMunicipioNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV103TFDepartamentoMunicipioNombre_Sel", AV103TFDepartamentoMunicipioNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesDireccion") == 0 )
            {
               AV106TFSolicitudesDireccion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV106TFSolicitudesDireccion", AV106TFSolicitudesDireccion);
               AV107TFSolicitudesDireccion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV107TFSolicitudesDireccion_Sel", AV107TFSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioOrigenPago") == 0 )
            {
               AV141TFSolicitudServicioOrigenPago_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV141TFSolicitudServicioOrigenPago_SelsJson", AV141TFSolicitudServicioOrigenPago_SelsJson);
               AV142TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV141TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MetodoPagosNombre") == 0 )
            {
               AV143TFMetodoPagosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV143TFMetodoPagosNombre", AV143TFMetodoPagosNombre);
               AV144TFMetodoPagosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV144TFMetodoPagosNombre_Sel", AV144TFMetodoPagosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesPagado") == 0 )
            {
               AV145TFSolicitudesPagado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV145TFSolicitudesPagado_SelsJson", AV145TFSolicitudesPagado_SelsJson);
               AV146TFSolicitudesPagado_Sels.FromJSonString(AV145TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioPFinal") == 0 )
            {
               AV147TFSolicitudServicioPFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV147TFSolicitudServicioPFinal", StringUtil.LTrimStr( AV147TFSolicitudServicioPFinal, 18, 2));
               AV148TFSolicitudServicioPFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV148TFSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV148TFSolicitudServicioPFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCotizacion") == 0 )
            {
               AV149TFSolicitudesCotizacion = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV149TFSolicitudesCotizacion", StringUtil.LTrimStr( AV149TFSolicitudesCotizacion, 18, 2));
               AV150TFSolicitudesCotizacion_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV150TFSolicitudesCotizacion_To", StringUtil.LTrimStr( AV150TFSolicitudesCotizacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesDescuento") == 0 )
            {
               AV151TFSolicitudesDescuento = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV151TFSolicitudesDescuento", StringUtil.LTrimStr( AV151TFSolicitudesDescuento, 18, 2));
               AV152TFSolicitudesDescuento_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV152TFSolicitudesDescuento_To", StringUtil.LTrimStr( AV152TFSolicitudesDescuento_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComALM") == 0 )
            {
               AV153TFSolicitudServicioComALM = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV153TFSolicitudServicioComALM", StringUtil.LTrimStr( AV153TFSolicitudServicioComALM, 18, 2));
               AV154TFSolicitudServicioComALM_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV154TFSolicitudServicioComALM_To", StringUtil.LTrimStr( AV154TFSolicitudServicioComALM_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComALMP") == 0 )
            {
               AV155TFSolicitudServicioComALMP = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV155TFSolicitudServicioComALMP", StringUtil.LTrimStr( AV155TFSolicitudServicioComALMP, 6, 2));
               AV156TFSolicitudServicioComALMP_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV156TFSolicitudServicioComALMP_To", StringUtil.LTrimStr( AV156TFSolicitudServicioComALMP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComPro") == 0 )
            {
               AV157TFSolicitudServicioComPro = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV157TFSolicitudServicioComPro", StringUtil.LTrimStr( AV157TFSolicitudServicioComPro, 18, 2));
               AV158TFSolicitudServicioComPro_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV158TFSolicitudServicioComPro_To", StringUtil.LTrimStr( AV158TFSolicitudServicioComPro_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComProP") == 0 )
            {
               AV159TFSolicitudServicioComProP = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV159TFSolicitudServicioComProP", StringUtil.LTrimStr( AV159TFSolicitudServicioComProP, 6, 2));
               AV160TFSolicitudServicioComProP_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV160TFSolicitudServicioComProP_To", StringUtil.LTrimStr( AV160TFSolicitudServicioComProP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComProv") == 0 )
            {
               AV161TFSolicitudServicioComProv = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV161TFSolicitudServicioComProv", StringUtil.LTrimStr( AV161TFSolicitudServicioComProv, 18, 2));
               AV162TFSolicitudServicioComProv_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV162TFSolicitudServicioComProv_To", StringUtil.LTrimStr( AV162TFSolicitudServicioComProv_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioComProvP") == 0 )
            {
               AV163TFSolicitudServicioComProvP = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV163TFSolicitudServicioComProvP", StringUtil.LTrimStr( AV163TFSolicitudServicioComProvP, 6, 2));
               AV164TFSolicitudServicioComProvP_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV164TFSolicitudServicioComProvP_To", StringUtil.LTrimStr( AV164TFSolicitudServicioComProvP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCostoXZComAlm") == 0 )
            {
               AV165TFSolicitudesCostoXZComAlm = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV165TFSolicitudesCostoXZComAlm", StringUtil.LTrimStr( AV165TFSolicitudesCostoXZComAlm, 18, 2));
               AV166TFSolicitudesCostoXZComAlm_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV166TFSolicitudesCostoXZComAlm_To", StringUtil.LTrimStr( AV166TFSolicitudesCostoXZComAlm_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCostoXZComAlmP") == 0 )
            {
               AV167TFSolicitudesCostoXZComAlmP = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV167TFSolicitudesCostoXZComAlmP", StringUtil.LTrimStr( AV167TFSolicitudesCostoXZComAlmP, 6, 2));
               AV168TFSolicitudesCostoXZComAlmP_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV168TFSolicitudesCostoXZComAlmP_To", StringUtil.LTrimStr( AV168TFSolicitudesCostoXZComAlmP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCostoXZComProf") == 0 )
            {
               AV169TFSolicitudesCostoXZComProf = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV169TFSolicitudesCostoXZComProf", StringUtil.LTrimStr( AV169TFSolicitudesCostoXZComProf, 18, 2));
               AV170TFSolicitudesCostoXZComProf_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV170TFSolicitudesCostoXZComProf_To", StringUtil.LTrimStr( AV170TFSolicitudesCostoXZComProf_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCostoXZComProfP") == 0 )
            {
               AV171TFSolicitudesCostoXZComProfP = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV171TFSolicitudesCostoXZComProfP", StringUtil.LTrimStr( AV171TFSolicitudesCostoXZComProfP, 6, 2));
               AV172TFSolicitudesCostoXZComProfP_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV172TFSolicitudesCostoXZComProfP_To", StringUtil.LTrimStr( AV172TFSolicitudesCostoXZComProfP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesCostoXZona") == 0 )
            {
               AV173TFSolicitudesCostoXZona = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV173TFSolicitudesCostoXZona", StringUtil.LTrimStr( AV173TFSolicitudesCostoXZona, 18, 2));
               AV174TFSolicitudesCostoXZona_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV174TFSolicitudesCostoXZona_To", StringUtil.LTrimStr( AV174TFSolicitudesCostoXZona_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CancelacionTipificacionDescripcion") == 0 )
            {
               AV210TFCancelacionTipificacionDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV210TFCancelacionTipificacionDescripcion", AV210TFCancelacionTipificacionDescripcion);
               AV211TFCancelacionTipificacionDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV211TFCancelacionTipificacionDescripcion_Sel", AV211TFCancelacionTipificacionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesNota") == 0 )
            {
               AV175TFSolicitudesNota = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV175TFSolicitudesNota", AV175TFSolicitudesNota);
               AV176TFSolicitudesNota_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV176TFSolicitudesNota_Sel", AV176TFSolicitudesNota_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesComentario") == 0 )
            {
               AV177TFSolicitudesComentario = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV177TFSolicitudesComentario", AV177TFSolicitudesComentario);
               AV178TFSolicitudesComentario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV178TFSolicitudesComentario_Sel", AV178TFSolicitudesComentario_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesOtros2") == 0 )
            {
               AV179TFSolicitudesOtros2 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV179TFSolicitudesOtros2", AV179TFSolicitudesOtros2);
               AV180TFSolicitudesOtros2_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV180TFSolicitudesOtros2_Sel", AV180TFSolicitudesOtros2_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesOtros3") == 0 )
            {
               AV181TFSolicitudesOtros3 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV181TFSolicitudesOtros3", AV181TFSolicitudesOtros3);
               AV182TFSolicitudesOtros3_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV182TFSolicitudesOtros3_Sel", AV182TFSolicitudesOtros3_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesFechaAlta") == 0 )
            {
               AV183TFSolicitudesFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV183TFSolicitudesFechaAlta", context.localUtil.Format(AV183TFSolicitudesFechaAlta, "99/99/9999"));
               AV184TFSolicitudesFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV184TFSolicitudesFechaAlta_To", context.localUtil.Format(AV184TFSolicitudesFechaAlta_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesFechaActualizacion") == 0 )
            {
               AV188TFSolicitudesFechaActualizacion = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV188TFSolicitudesFechaActualizacion", context.localUtil.TToC( AV188TFSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV189TFSolicitudesFechaActualizacion_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV189TFSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV189TFSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV189TFSolicitudesFechaActualizacion_To) )
               {
                  AV189TFSolicitudesFechaActualizacion_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV189TFSolicitudesFechaActualizacion_To)), (short)(DateTimeUtil.Month( AV189TFSolicitudesFechaActualizacion_To)), (short)(DateTimeUtil.Day( AV189TFSolicitudesFechaActualizacion_To)), 23, 59, 59);
                  AssignAttri("", false, "AV189TFSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV189TFSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV146TFSolicitudesPagado_Sels", AV146TFSolicitudesPagado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV142TFSolicitudServicioOrigenPago_Sels", AV142TFSolicitudServicioOrigenPago_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV133TFSolicitudesSubTipo_Sels", AV133TFSolicitudesSubTipo_Sels);
      }

      private void E19JW2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( AV193IsAuthorized_EstadosSolNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A130EstadosSolTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A131EstadosSolId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtEstadosSolNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV124IsAuthorized_DepartamentoDepartamento )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "departamentoview.aspx"+UrlEncode(StringUtil.LTrimStr(A112DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtDepartamentoDepartamento_Link = formatLink("departamentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV194IsAuthorized_MetodoPagosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "metodopagosview.aspx"+UrlEncode(StringUtil.LTrimStr(A128MetodoPagosID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtMetodoPagosNombre_Link = formatLink("metodopagosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            new orelnom(context ).execute(  A127SolicitudesID, out  AV200ProfesionalId, out  AV201Profesional, out  AV202Existe) ;
            AssignAttri("", false, edtavProfesionalid_Internalname, AV200ProfesionalId);
            AssignAttri("", false, edtavProfesional_Internalname, AV201Profesional);
            AssignAttri("", false, edtavExiste_Internalname, AV202Existe);
            new orelnom(context ).execute(  A127SolicitudesID, out  AV200ProfesionalId, out  AV201Profesional, out  AV202Existe) ;
            AssignAttri("", false, edtavProfesionalid_Internalname, AV200ProfesionalId);
            AssignAttri("", false, edtavProfesional_Internalname, AV201Profesional);
            AssignAttri("", false, edtavExiste_Internalname, AV202Existe);
            if ( StringUtil.StrCmp(DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( )), context.GetMessage( "Sábado", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
               {
                  AV128HoraInstalacion = "08 - 14";
                  AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
               }
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
               {
                  AV128HoraInstalacion = "14 - 20";
                  AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
               {
                  AV128HoraInstalacion = "08 - 12";
                  AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
               }
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
               {
                  AV128HoraInstalacion = "12 - 16";
                  AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
               }
               if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
               {
                  AV128HoraInstalacion = "16 - 20";
                  AssignAttri("", false, edtavHorainstalacion_Internalname, AV128HoraInstalacion);
               }
            }
            AV129Dia = DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( ));
            AssignAttri("", false, edtavDia_Internalname, AV129Dia);
            /* Using cursor H00JW5 */
            pr_default.execute(3, new Object[] {n597SolicitudesUsrAlta, A597SolicitudesUsrAlta});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A18SecUserId = H00JW5_A18SecUserId[0];
               A26SecUserName = H00JW5_A26SecUserName[0];
               AV130UserAlta = A26SecUserName;
               AssignAttri("", false, edtavUseralta_Internalname, AV130UserAlta);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            /* Using cursor H00JW6 */
            pr_default.execute(4, new Object[] {n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A18SecUserId = H00JW6_A18SecUserId[0];
               A26SecUserName = H00JW6_A26SecUserName[0];
               AV131UserUPD = A26SecUserName;
               AssignAttri("", false, edtavUserupd_Internalname, AV131UserUPD);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 39;
            }
            sendrow_392( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            context.DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E16JW2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV48ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV50ColumnsSelector.FromJSonString(AV48ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "SolicitudesReporteWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV48ColumnsSelectorXML)) ? "" : AV50ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ColumnsSelector", AV50ColumnsSelector);
      }

      protected void E13JW2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV146TFSolicitudesPagado_Sels", AV146TFSolicitudesPagado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV142TFSolicitudServicioOrigenPago_Sels", AV142TFSolicitudServicioOrigenPago_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV133TFSolicitudesSubTipo_Sels", AV133TFSolicitudesSubTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ColumnsSelector", AV50ColumnsSelector);
      }

      protected void E14JW2( )
      {
         /* Solicitudesfechainstalacion_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV204SolicitudesFechaInstalacion", context.localUtil.Format(AV204SolicitudesFechaInstalacion, "99/99/99"));
         AssignAttri("", false, "AV205SolicitudesFechaInstalacion_To", context.localUtil.Format(AV205SolicitudesFechaInstalacion_To, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV204SolicitudesFechaInstalacion, AV50ColumnsSelector, AV212Pgmname, AV205SolicitudesFechaInstalacion_To, AV56TFSolicitudesID, AV57TFSolicitudesID_To, AV133TFSolicitudesSubTipo_Sels, AV139TFEstadosSolNombre, AV140TFEstadosSolNombre_Sel, AV64TFProveedorNombre, AV65TFProveedorNombre_Sel, AV58TFSolicitudesNombre, AV59TFSolicitudesNombre_Sel, AV90TFSolicitudesTelefono, AV91TFSolicitudesTelefono_Sel, AV92TFSolicitudesMail, AV93TFSolicitudesMail_Sel, AV94TFPaisID, AV95TFPaisID_Sel, AV98TFDepartamentoDepartamento, AV99TFDepartamentoDepartamento_Sel, AV102TFDepartamentoMunicipioNombre, AV103TFDepartamentoMunicipioNombre_Sel, AV106TFSolicitudesDireccion, AV107TFSolicitudesDireccion_Sel, AV142TFSolicitudServicioOrigenPago_Sels, AV143TFMetodoPagosNombre, AV144TFMetodoPagosNombre_Sel, AV146TFSolicitudesPagado_Sels, AV147TFSolicitudServicioPFinal, AV148TFSolicitudServicioPFinal_To, AV149TFSolicitudesCotizacion, AV150TFSolicitudesCotizacion_To, AV151TFSolicitudesDescuento, AV152TFSolicitudesDescuento_To, AV153TFSolicitudServicioComALM, AV154TFSolicitudServicioComALM_To, AV155TFSolicitudServicioComALMP, AV156TFSolicitudServicioComALMP_To, AV157TFSolicitudServicioComPro, AV158TFSolicitudServicioComPro_To, AV159TFSolicitudServicioComProP, AV160TFSolicitudServicioComProP_To, AV161TFSolicitudServicioComProv, AV162TFSolicitudServicioComProv_To, AV163TFSolicitudServicioComProvP, AV164TFSolicitudServicioComProvP_To, AV165TFSolicitudesCostoXZComAlm, AV166TFSolicitudesCostoXZComAlm_To, AV167TFSolicitudesCostoXZComAlmP, AV168TFSolicitudesCostoXZComAlmP_To, AV169TFSolicitudesCostoXZComProf, AV170TFSolicitudesCostoXZComProf_To, AV171TFSolicitudesCostoXZComProfP, AV172TFSolicitudesCostoXZComProfP_To, AV173TFSolicitudesCostoXZona, AV174TFSolicitudesCostoXZona_To, AV210TFCancelacionTipificacionDescripcion, AV211TFCancelacionTipificacionDescripcion_Sel, AV175TFSolicitudesNota, AV176TFSolicitudesNota_Sel, AV177TFSolicitudesComentario, AV178TFSolicitudesComentario_Sel, AV179TFSolicitudesOtros2, AV180TFSolicitudesOtros2_Sel, AV181TFSolicitudesOtros3, AV182TFSolicitudesOtros3_Sel, AV183TFSolicitudesFechaAlta, AV184TFSolicitudesFechaAlta_To, AV188TFSolicitudesFechaActualizacion, AV189TFSolicitudesFechaActualizacion_To, AV193IsAuthorized_EstadosSolNombre, AV124IsAuthorized_DepartamentoDepartamento, AV194IsAuthorized_MetodoPagosNombre, A18SecUserId, A26SecUserName) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV50ColumnsSelector", AV50ColumnsSelector);
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV50ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&ProfesionalId",  "",  "ProfesionalId",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&Profesional",  "",  "Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesID",  "",  "Solicitud",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesSubTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesFechaInstalacion",  "",  "Fecha de instalación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&HoraInstalacion",  "",  "Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&Dia",  "",  "Día",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "EstadosSolNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "ProveedorNombre",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesNombre",  "",  "Cliente Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "PaisID",  "",  "Pais",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "DepartamentoDepartamento",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "DepartamentoMunicipioNombre",  "",  "Municipio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioOrigenPago",  "",  "Origen de Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "MetodoPagosNombre",  "",  "Metodo de Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesPagado",  "",  "¿Pagado?",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioPFinal",  "",  "Precio Final",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCotizacion",  "",  "Cotización",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesDescuento",  "",  "Solicitud Descuento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComALM",  "",  "Comisión Almango",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComALMP",  "",  "% Comisión Almango",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComPro",  "",  "Comisión Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComProP",  "",  "% Comisión Profesional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComProv",  "",  "Comisión Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudServicioComProvP",  "",  "% Comisión Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCostoXZComAlm",  "",  "Almango xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCostoXZComAlmP",  "",  "% Almango xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCostoXZComProf",  "",  "Profesional xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCostoXZComProfP",  "",  "% Profesional xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesCostoXZona",  "",  "Total xZona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "CancelacionTipificacionDescripcion",  "",  "Tipo Cancelación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesNota",  "",  "Nota",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesComentario",  "",  "Comentario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesOtros2",  "",  "Otros2",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesOtros3",  "",  "Otros3",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&UserAlta",  "",  "Usuario Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "&UserUPD",  "",  "Usuario Modificación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV50ColumnsSelector,  "SolicitudesFechaActualizacion",  "",  "Fecha Modificación",  true,  "") ;
         GXt_char3 = AV49UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "SolicitudesReporteWWColumnsSelector", out  GXt_char3) ;
         AV49UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49UserCustomValue)) ) )
         {
            AV51ColumnsSelectorAux.FromXml(AV49UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV51ColumnsSelectorAux, ref  AV50ColumnsSelector) ;
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52Session.Get(AV212Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV212Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV52Session.Get(AV212Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV284GXV1 = 1;
         while ( AV284GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV284GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "SOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV204SolicitudesFechaInstalacion = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV204SolicitudesFechaInstalacion", context.localUtil.Format(AV204SolicitudesFechaInstalacion, "99/99/99"));
               AV205SolicitudesFechaInstalacion_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV205SolicitudesFechaInstalacion_To", context.localUtil.Format(AV205SolicitudesFechaInstalacion_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV56TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFSolicitudesID", StringUtil.LTrimStr( (decimal)(AV56TFSolicitudesID), 18, 0));
               AV57TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFSolicitudesID_To", StringUtil.LTrimStr( (decimal)(AV57TFSolicitudesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESSUBTIPO_SEL") == 0 )
            {
               AV132TFSolicitudesSubTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV132TFSolicitudesSubTipo_SelsJson", AV132TFSolicitudesSubTipo_SelsJson);
               AV133TFSolicitudesSubTipo_Sels.FromJSonString(AV132TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE") == 0 )
            {
               AV139TFEstadosSolNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV139TFEstadosSolNombre", AV139TFEstadosSolNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE_SEL") == 0 )
            {
               AV140TFEstadosSolNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV140TFEstadosSolNombre_Sel", AV140TFEstadosSolNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV64TFProveedorNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFProveedorNombre", AV64TFProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV65TFProveedorNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFProveedorNombre_Sel", AV65TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE") == 0 )
            {
               AV58TFSolicitudesNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFSolicitudesNombre", AV58TFSolicitudesNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV59TFSolicitudesNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFSolicitudesNombre_Sel", AV59TFSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO") == 0 )
            {
               AV90TFSolicitudesTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV90TFSolicitudesTelefono", AV90TFSolicitudesTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO_SEL") == 0 )
            {
               AV91TFSolicitudesTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV91TFSolicitudesTelefono_Sel", AV91TFSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL") == 0 )
            {
               AV92TFSolicitudesMail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV92TFSolicitudesMail", AV92TFSolicitudesMail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL_SEL") == 0 )
            {
               AV93TFSolicitudesMail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV93TFSolicitudesMail_Sel", AV93TFSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV94TFPaisID = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV94TFPaisID", AV94TFPaisID);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV95TFPaisID_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV95TFPaisID_Sel", AV95TFPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV98TFDepartamentoDepartamento = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV98TFDepartamentoDepartamento", AV98TFDepartamentoDepartamento);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV99TFDepartamentoDepartamento_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV99TFDepartamentoDepartamento_Sel", AV99TFDepartamentoDepartamento_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV102TFDepartamentoMunicipioNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV102TFDepartamentoMunicipioNombre", AV102TFDepartamentoMunicipioNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV103TFDepartamentoMunicipioNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV103TFDepartamentoMunicipioNombre_Sel", AV103TFDepartamentoMunicipioNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION") == 0 )
            {
               AV106TFSolicitudesDireccion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV106TFSolicitudesDireccion", AV106TFSolicitudesDireccion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION_SEL") == 0 )
            {
               AV107TFSolicitudesDireccion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV107TFSolicitudesDireccion_Sel", AV107TFSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOORIGENPAGO_SEL") == 0 )
            {
               AV141TFSolicitudServicioOrigenPago_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV141TFSolicitudServicioOrigenPago_SelsJson", AV141TFSolicitudServicioOrigenPago_SelsJson);
               AV142TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV141TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV143TFMetodoPagosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV143TFMetodoPagosNombre", AV143TFMetodoPagosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV144TFMetodoPagosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV144TFMetodoPagosNombre_Sel", AV144TFMetodoPagosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV145TFSolicitudesPagado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV145TFSolicitudesPagado_SelsJson", AV145TFSolicitudesPagado_SelsJson);
               AV146TFSolicitudesPagado_Sels.FromJSonString(AV145TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV147TFSolicitudServicioPFinal = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV147TFSolicitudServicioPFinal", StringUtil.LTrimStr( AV147TFSolicitudServicioPFinal, 18, 2));
               AV148TFSolicitudServicioPFinal_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV148TFSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV148TFSolicitudServicioPFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOTIZACION") == 0 )
            {
               AV149TFSolicitudesCotizacion = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV149TFSolicitudesCotizacion", StringUtil.LTrimStr( AV149TFSolicitudesCotizacion, 18, 2));
               AV150TFSolicitudesCotizacion_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV150TFSolicitudesCotizacion_To", StringUtil.LTrimStr( AV150TFSolicitudesCotizacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDESCUENTO") == 0 )
            {
               AV151TFSolicitudesDescuento = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV151TFSolicitudesDescuento", StringUtil.LTrimStr( AV151TFSolicitudesDescuento, 18, 2));
               AV152TFSolicitudesDescuento_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV152TFSolicitudesDescuento_To", StringUtil.LTrimStr( AV152TFSolicitudesDescuento_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMALM") == 0 )
            {
               AV153TFSolicitudServicioComALM = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV153TFSolicitudServicioComALM", StringUtil.LTrimStr( AV153TFSolicitudServicioComALM, 18, 2));
               AV154TFSolicitudServicioComALM_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV154TFSolicitudServicioComALM_To", StringUtil.LTrimStr( AV154TFSolicitudServicioComALM_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMALMP") == 0 )
            {
               AV155TFSolicitudServicioComALMP = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV155TFSolicitudServicioComALMP", StringUtil.LTrimStr( AV155TFSolicitudServicioComALMP, 6, 2));
               AV156TFSolicitudServicioComALMP_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV156TFSolicitudServicioComALMP_To", StringUtil.LTrimStr( AV156TFSolicitudServicioComALMP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPRO") == 0 )
            {
               AV157TFSolicitudServicioComPro = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV157TFSolicitudServicioComPro", StringUtil.LTrimStr( AV157TFSolicitudServicioComPro, 18, 2));
               AV158TFSolicitudServicioComPro_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV158TFSolicitudServicioComPro_To", StringUtil.LTrimStr( AV158TFSolicitudServicioComPro_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROP") == 0 )
            {
               AV159TFSolicitudServicioComProP = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV159TFSolicitudServicioComProP", StringUtil.LTrimStr( AV159TFSolicitudServicioComProP, 6, 2));
               AV160TFSolicitudServicioComProP_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV160TFSolicitudServicioComProP_To", StringUtil.LTrimStr( AV160TFSolicitudServicioComProP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROV") == 0 )
            {
               AV161TFSolicitudServicioComProv = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV161TFSolicitudServicioComProv", StringUtil.LTrimStr( AV161TFSolicitudServicioComProv, 18, 2));
               AV162TFSolicitudServicioComProv_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV162TFSolicitudServicioComProv_To", StringUtil.LTrimStr( AV162TFSolicitudServicioComProv_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOCOMPROVP") == 0 )
            {
               AV163TFSolicitudServicioComProvP = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV163TFSolicitudServicioComProvP", StringUtil.LTrimStr( AV163TFSolicitudServicioComProvP, 6, 2));
               AV164TFSolicitudServicioComProvP_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV164TFSolicitudServicioComProvP_To", StringUtil.LTrimStr( AV164TFSolicitudServicioComProvP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMALM") == 0 )
            {
               AV165TFSolicitudesCostoXZComAlm = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV165TFSolicitudesCostoXZComAlm", StringUtil.LTrimStr( AV165TFSolicitudesCostoXZComAlm, 18, 2));
               AV166TFSolicitudesCostoXZComAlm_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV166TFSolicitudesCostoXZComAlm_To", StringUtil.LTrimStr( AV166TFSolicitudesCostoXZComAlm_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMALMP") == 0 )
            {
               AV167TFSolicitudesCostoXZComAlmP = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV167TFSolicitudesCostoXZComAlmP", StringUtil.LTrimStr( AV167TFSolicitudesCostoXZComAlmP, 6, 2));
               AV168TFSolicitudesCostoXZComAlmP_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV168TFSolicitudesCostoXZComAlmP_To", StringUtil.LTrimStr( AV168TFSolicitudesCostoXZComAlmP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMPROF") == 0 )
            {
               AV169TFSolicitudesCostoXZComProf = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV169TFSolicitudesCostoXZComProf", StringUtil.LTrimStr( AV169TFSolicitudesCostoXZComProf, 18, 2));
               AV170TFSolicitudesCostoXZComProf_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV170TFSolicitudesCostoXZComProf_To", StringUtil.LTrimStr( AV170TFSolicitudesCostoXZComProf_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZCOMPROFP") == 0 )
            {
               AV171TFSolicitudesCostoXZComProfP = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV171TFSolicitudesCostoXZComProfP", StringUtil.LTrimStr( AV171TFSolicitudesCostoXZComProfP, 6, 2));
               AV172TFSolicitudesCostoXZComProfP_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV172TFSolicitudesCostoXZComProfP_To", StringUtil.LTrimStr( AV172TFSolicitudesCostoXZComProfP_To, 6, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOSTOXZONA") == 0 )
            {
               AV173TFSolicitudesCostoXZona = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV173TFSolicitudesCostoXZona", StringUtil.LTrimStr( AV173TFSolicitudesCostoXZona, 18, 2));
               AV174TFSolicitudesCostoXZona_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV174TFSolicitudesCostoXZona_To", StringUtil.LTrimStr( AV174TFSolicitudesCostoXZona_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCANCELACIONTIPIFICACIONDESCRIPCION") == 0 )
            {
               AV210TFCancelacionTipificacionDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV210TFCancelacionTipificacionDescripcion", AV210TFCancelacionTipificacionDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCANCELACIONTIPIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV211TFCancelacionTipificacionDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV211TFCancelacionTipificacionDescripcion_Sel", AV211TFCancelacionTipificacionDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOTA") == 0 )
            {
               AV175TFSolicitudesNota = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV175TFSolicitudesNota", AV175TFSolicitudesNota);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOTA_SEL") == 0 )
            {
               AV176TFSolicitudesNota_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV176TFSolicitudesNota_Sel", AV176TFSolicitudesNota_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO") == 0 )
            {
               AV177TFSolicitudesComentario = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV177TFSolicitudesComentario", AV177TFSolicitudesComentario);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV178TFSolicitudesComentario_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV178TFSolicitudesComentario_Sel", AV178TFSolicitudesComentario_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS2") == 0 )
            {
               AV179TFSolicitudesOtros2 = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV179TFSolicitudesOtros2", AV179TFSolicitudesOtros2);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS2_SEL") == 0 )
            {
               AV180TFSolicitudesOtros2_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV180TFSolicitudesOtros2_Sel", AV180TFSolicitudesOtros2_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS3") == 0 )
            {
               AV181TFSolicitudesOtros3 = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV181TFSolicitudesOtros3", AV181TFSolicitudesOtros3);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESOTROS3_SEL") == 0 )
            {
               AV182TFSolicitudesOtros3_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV182TFSolicitudesOtros3_Sel", AV182TFSolicitudesOtros3_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAALTA") == 0 )
            {
               AV183TFSolicitudesFechaAlta = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV183TFSolicitudesFechaAlta", context.localUtil.Format(AV183TFSolicitudesFechaAlta, "99/99/9999"));
               AV184TFSolicitudesFechaAlta_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV184TFSolicitudesFechaAlta_To", context.localUtil.Format(AV184TFSolicitudesFechaAlta_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAACTUALIZACION") == 0 )
            {
               AV188TFSolicitudesFechaActualizacion = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV188TFSolicitudesFechaActualizacion", context.localUtil.TToC( AV188TFSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV189TFSolicitudesFechaActualizacion_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV189TFSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV189TFSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV190DDO_SolicitudesFechaActualizacionAuxDate = DateTimeUtil.ResetTime(AV188TFSolicitudesFechaActualizacion);
               AssignAttri("", false, "AV190DDO_SolicitudesFechaActualizacionAuxDate", context.localUtil.Format(AV190DDO_SolicitudesFechaActualizacionAuxDate, "99/99/99"));
               AV191DDO_SolicitudesFechaActualizacionAuxDateTo = DateTimeUtil.ResetTime(AV189TFSolicitudesFechaActualizacion_To);
               AssignAttri("", false, "AV191DDO_SolicitudesFechaActualizacionAuxDateTo", context.localUtil.Format(AV191DDO_SolicitudesFechaActualizacionAuxDateTo, "99/99/99"));
            }
            AV284GXV1 = (int)(AV284GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV133TFSolicitudesSubTipo_Sels.Count==0),  AV132TFSolicitudesSubTipo_SelsJson, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV140TFEstadosSolNombre_Sel)),  AV140TFEstadosSolNombre_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFProveedorNombre_Sel)),  AV65TFProveedorNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFSolicitudesNombre_Sel)),  AV59TFSolicitudesNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV91TFSolicitudesTelefono_Sel)),  AV91TFSolicitudesTelefono_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV93TFSolicitudesMail_Sel)),  AV93TFSolicitudesMail_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV95TFPaisID_Sel)),  AV95TFPaisID_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDepartamentoDepartamento_Sel)),  AV99TFDepartamentoDepartamento_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV103TFDepartamentoMunicipioNombre_Sel)),  AV103TFDepartamentoMunicipioNombre_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV107TFSolicitudesDireccion_Sel)),  AV107TFSolicitudesDireccion_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV142TFSolicitudServicioOrigenPago_Sels.Count==0),  AV141TFSolicitudServicioOrigenPago_SelsJson, out  GXt_char13) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV144TFMetodoPagosNombre_Sel)),  AV144TFMetodoPagosNombre_Sel, out  GXt_char14) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV146TFSolicitudesPagado_Sels.Count==0),  AV145TFSolicitudesPagado_SelsJson, out  GXt_char15) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV211TFCancelacionTipificacionDescripcion_Sel)),  AV211TFCancelacionTipificacionDescripcion_Sel, out  GXt_char16) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV176TFSolicitudesNota_Sel)),  AV176TFSolicitudesNota_Sel, out  GXt_char17) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV178TFSolicitudesComentario_Sel)),  AV178TFSolicitudesComentario_Sel, out  GXt_char18) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV180TFSolicitudesOtros2_Sel)),  AV180TFSolicitudesOtros2_Sel, out  GXt_char19) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV182TFSolicitudesOtros3_Sel)),  AV182TFSolicitudesOtros3_Sel, out  GXt_char20) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char3+"||||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"|"+GXt_char13+"|"+GXt_char14+"|"+GXt_char15+"|||||||||||||||"+GXt_char16+"|"+GXt_char17+"|"+GXt_char18+"|"+GXt_char19+"|"+GXt_char20+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV139TFEstadosSolNombre)),  AV139TFEstadosSolNombre, out  GXt_char20) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProveedorNombre)),  AV64TFProveedorNombre, out  GXt_char19) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFSolicitudesNombre)),  AV58TFSolicitudesNombre, out  GXt_char18) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV90TFSolicitudesTelefono)),  AV90TFSolicitudesTelefono, out  GXt_char17) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV92TFSolicitudesMail)),  AV92TFSolicitudesMail, out  GXt_char16) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV94TFPaisID)),  AV94TFPaisID, out  GXt_char15) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV98TFDepartamentoDepartamento)),  AV98TFDepartamentoDepartamento, out  GXt_char14) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV102TFDepartamentoMunicipioNombre)),  AV102TFDepartamentoMunicipioNombre, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV106TFSolicitudesDireccion)),  AV106TFSolicitudesDireccion, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV143TFMetodoPagosNombre)),  AV143TFMetodoPagosNombre, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV210TFCancelacionTipificacionDescripcion)),  AV210TFCancelacionTipificacionDescripcion, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV175TFSolicitudesNota)),  AV175TFSolicitudesNota, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV177TFSolicitudesComentario)),  AV177TFSolicitudesComentario, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV179TFSolicitudesOtros2)),  AV179TFSolicitudesOtros2, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV181TFSolicitudesOtros3)),  AV181TFSolicitudesOtros3, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "||"+((0==AV56TFSolicitudesID) ? "" : StringUtil.Str( (decimal)(AV56TFSolicitudesID), 18, 0))+"|||||"+GXt_char20+"|"+GXt_char19+"|"+GXt_char18+"|"+GXt_char17+"|"+GXt_char16+"|"+GXt_char15+"|"+GXt_char14+"|"+GXt_char13+"|"+GXt_char12+"||"+GXt_char11+"||"+((Convert.ToDecimal(0)==AV147TFSolicitudServicioPFinal) ? "" : StringUtil.Str( AV147TFSolicitudServicioPFinal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV149TFSolicitudesCotizacion) ? "" : StringUtil.Str( AV149TFSolicitudesCotizacion, 18, 2))+"|"+((Convert.ToDecimal(0)==AV151TFSolicitudesDescuento) ? "" : StringUtil.Str( AV151TFSolicitudesDescuento, 18, 2))+"|"+((Convert.ToDecimal(0)==AV153TFSolicitudServicioComALM) ? "" : StringUtil.Str( AV153TFSolicitudServicioComALM, 18, 2))+"|"+((Convert.ToDecimal(0)==AV155TFSolicitudServicioComALMP) ? "" : StringUtil.Str( AV155TFSolicitudServicioComALMP, 6, 2))+"|"+((Convert.ToDecimal(0)==AV157TFSolicitudServicioComPro) ? "" : StringUtil.Str( AV157TFSolicitudServicioComPro, 18, 2))+"|"+((Convert.ToDecimal(0)==AV159TFSolicitudServicioComProP) ? "" : StringUtil.Str( AV159TFSolicitudServicioComProP, 6, 2))+"|"+((Convert.ToDecimal(0)==AV161TFSolicitudServicioComProv) ? "" : StringUtil.Str( AV161TFSolicitudServicioComProv, 18, 2))+"|"+((Convert.ToDecimal(0)==AV163TFSolicitudServicioComProvP) ? "" : StringUtil.Str( AV163TFSolicitudServicioComProvP, 6, 2))+"|"+((Convert.ToDecimal(0)==AV165TFSolicitudesCostoXZComAlm) ? "" : StringUtil.Str( AV165TFSolicitudesCostoXZComAlm, 18, 2))+"|"+((Convert.ToDecimal(0)==AV167TFSolicitudesCostoXZComAlmP) ? "" : StringUtil.Str( AV167TFSolicitudesCostoXZComAlmP, 6, 2))+"|"+((Convert.ToDecimal(0)==AV169TFSolicitudesCostoXZComProf) ? "" : StringUtil.Str( AV169TFSolicitudesCostoXZComProf, 18, 2))+"|"+((Convert.ToDecimal(0)==AV171TFSolicitudesCostoXZComProfP) ? "" : StringUtil.Str( AV171TFSolicitudesCostoXZComProfP, 6, 2))+"|"+((Convert.ToDecimal(0)==AV173TFSolicitudesCostoXZona) ? "" : StringUtil.Str( AV173TFSolicitudesCostoXZona, 18, 2))+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|||"+((DateTime.MinValue==AV183TFSolicitudesFechaAlta) ? "" : context.localUtil.DToC( AV183TFSolicitudesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV188TFSolicitudesFechaActualizacion) ? "" : context.localUtil.DToC( AV190DDO_SolicitudesFechaActualizacionAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV57TFSolicitudesID_To) ? "" : StringUtil.Str( (decimal)(AV57TFSolicitudesID_To), 18, 0))+"|||||||||||||||||"+((Convert.ToDecimal(0)==AV148TFSolicitudServicioPFinal_To) ? "" : StringUtil.Str( AV148TFSolicitudServicioPFinal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV150TFSolicitudesCotizacion_To) ? "" : StringUtil.Str( AV150TFSolicitudesCotizacion_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV152TFSolicitudesDescuento_To) ? "" : StringUtil.Str( AV152TFSolicitudesDescuento_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV154TFSolicitudServicioComALM_To) ? "" : StringUtil.Str( AV154TFSolicitudServicioComALM_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV156TFSolicitudServicioComALMP_To) ? "" : StringUtil.Str( AV156TFSolicitudServicioComALMP_To, 6, 2))+"|"+((Convert.ToDecimal(0)==AV158TFSolicitudServicioComPro_To) ? "" : StringUtil.Str( AV158TFSolicitudServicioComPro_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV160TFSolicitudServicioComProP_To) ? "" : StringUtil.Str( AV160TFSolicitudServicioComProP_To, 6, 2))+"|"+((Convert.ToDecimal(0)==AV162TFSolicitudServicioComProv_To) ? "" : StringUtil.Str( AV162TFSolicitudServicioComProv_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV164TFSolicitudServicioComProvP_To) ? "" : StringUtil.Str( AV164TFSolicitudServicioComProvP_To, 6, 2))+"|"+((Convert.ToDecimal(0)==AV166TFSolicitudesCostoXZComAlm_To) ? "" : StringUtil.Str( AV166TFSolicitudesCostoXZComAlm_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV168TFSolicitudesCostoXZComAlmP_To) ? "" : StringUtil.Str( AV168TFSolicitudesCostoXZComAlmP_To, 6, 2))+"|"+((Convert.ToDecimal(0)==AV170TFSolicitudesCostoXZComProf_To) ? "" : StringUtil.Str( AV170TFSolicitudesCostoXZComProf_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV172TFSolicitudesCostoXZComProfP_To) ? "" : StringUtil.Str( AV172TFSolicitudesCostoXZComProfP_To, 6, 2))+"|"+((Convert.ToDecimal(0)==AV174TFSolicitudesCostoXZona_To) ? "" : StringUtil.Str( AV174TFSolicitudesCostoXZona_To, 18, 2))+"||||||||"+((DateTime.MinValue==AV184TFSolicitudesFechaAlta_To) ? "" : context.localUtil.DToC( AV184TFSolicitudesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV189TFSolicitudesFechaActualizacion_To) ? "" : context.localUtil.DToC( AV191DDO_SolicitudesFechaActualizacionAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV52Session.Get(AV212Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "SOLICITUDESFECHAINSTALACION",  context.GetMessage( "Fecha Instalación", ""),  !((DateTime.MinValue==AV204SolicitudesFechaInstalacion)&&(DateTime.MinValue==AV205SolicitudesFechaInstalacion_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV204SolicitudesFechaInstalacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV205SolicitudesFechaInstalacion_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESID",  context.GetMessage( "Solicitud", ""),  !((0==AV56TFSolicitudesID)&&(0==AV57TFSolicitudesID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFSolicitudesID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV57TFSolicitudesID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESSUBTIPO_SEL",  context.GetMessage( "Tipo", ""),  !(AV133TFSolicitudesSubTipo_Sels.Count==0),  0,  AV133TFSolicitudesSubTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFESTADOSSOLNOMBRE",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV139TFEstadosSolNombre)),  0,  AV139TFEstadosSolNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV140TFEstadosSolNombre_Sel)),  AV140TFEstadosSolNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORNOMBRE",  context.GetMessage( "Comercio", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProveedorNombre)),  0,  AV64TFProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFProveedorNombre_Sel)),  AV65TFProveedorNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESNOMBRE",  context.GetMessage( "Cliente Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFSolicitudesNombre)),  0,  AV58TFSolicitudesNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFSolicitudesNombre_Sel)),  AV59TFSolicitudesNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV90TFSolicitudesTelefono)),  0,  AV90TFSolicitudesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV91TFSolicitudesTelefono_Sel)),  AV91TFSolicitudesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESMAIL",  context.GetMessage( "Mail", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV92TFSolicitudesMail)),  0,  AV92TFSolicitudesMail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV93TFSolicitudesMail_Sel)),  AV93TFSolicitudesMail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAISID",  context.GetMessage( "Pais", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV94TFPaisID)),  0,  AV94TFPaisID,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV95TFPaisID_Sel)),  AV95TFPaisID_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDEPARTAMENTODEPARTAMENTO",  context.GetMessage( "Departamento", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV98TFDepartamentoDepartamento)),  0,  AV98TFDepartamentoDepartamento,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDepartamentoDepartamento_Sel)),  AV99TFDepartamentoDepartamento_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDEPARTAMENTOMUNICIPIONOMBRE",  context.GetMessage( "Municipio", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV102TFDepartamentoMunicipioNombre)),  0,  AV102TFDepartamentoMunicipioNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV103TFDepartamentoMunicipioNombre_Sel)),  AV103TFDepartamentoMunicipioNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESDIRECCION",  context.GetMessage( "Dirección", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV106TFSolicitudesDireccion)),  0,  AV106TFSolicitudesDireccion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV107TFSolicitudesDireccion_Sel)),  AV107TFSolicitudesDireccion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOORIGENPAGO_SEL",  context.GetMessage( "Origen de Pago", ""),  !(AV142TFSolicitudServicioOrigenPago_Sels.Count==0),  0,  AV142TFSolicitudServicioOrigenPago_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMETODOPAGOSNOMBRE",  context.GetMessage( "Metodo de Pago", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV143TFMetodoPagosNombre)),  0,  AV143TFMetodoPagosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV144TFMetodoPagosNombre_Sel)),  AV144TFMetodoPagosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESPAGADO_SEL",  context.GetMessage( "¿Pagado?", ""),  !(AV146TFSolicitudesPagado_Sels.Count==0),  0,  AV146TFSolicitudesPagado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOPFINAL",  context.GetMessage( "Precio Final", ""),  !((Convert.ToDecimal(0)==AV147TFSolicitudServicioPFinal)&&(Convert.ToDecimal(0)==AV148TFSolicitudServicioPFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV147TFSolicitudServicioPFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV148TFSolicitudServicioPFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOTIZACION",  context.GetMessage( "Cotización", ""),  !((Convert.ToDecimal(0)==AV149TFSolicitudesCotizacion)&&(Convert.ToDecimal(0)==AV150TFSolicitudesCotizacion_To)),  0,  StringUtil.Trim( StringUtil.Str( AV149TFSolicitudesCotizacion, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV150TFSolicitudesCotizacion_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESDESCUENTO",  context.GetMessage( "Solicitud Descuento", ""),  !((Convert.ToDecimal(0)==AV151TFSolicitudesDescuento)&&(Convert.ToDecimal(0)==AV152TFSolicitudesDescuento_To)),  0,  StringUtil.Trim( StringUtil.Str( AV151TFSolicitudesDescuento, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV152TFSolicitudesDescuento_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMALM",  context.GetMessage( "Comisión Almango", ""),  !((Convert.ToDecimal(0)==AV153TFSolicitudServicioComALM)&&(Convert.ToDecimal(0)==AV154TFSolicitudServicioComALM_To)),  0,  StringUtil.Trim( StringUtil.Str( AV153TFSolicitudServicioComALM, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV154TFSolicitudServicioComALM_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMALMP",  context.GetMessage( "% Comisión Almango", ""),  !((Convert.ToDecimal(0)==AV155TFSolicitudServicioComALMP)&&(Convert.ToDecimal(0)==AV156TFSolicitudServicioComALMP_To)),  0,  StringUtil.Trim( StringUtil.Str( AV155TFSolicitudServicioComALMP, 6, 2)),  StringUtil.Trim( StringUtil.Str( AV156TFSolicitudServicioComALMP_To, 6, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMPRO",  context.GetMessage( "Comisión Profesional", ""),  !((Convert.ToDecimal(0)==AV157TFSolicitudServicioComPro)&&(Convert.ToDecimal(0)==AV158TFSolicitudServicioComPro_To)),  0,  StringUtil.Trim( StringUtil.Str( AV157TFSolicitudServicioComPro, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV158TFSolicitudServicioComPro_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMPROP",  context.GetMessage( "% Comisión Profesional", ""),  !((Convert.ToDecimal(0)==AV159TFSolicitudServicioComProP)&&(Convert.ToDecimal(0)==AV160TFSolicitudServicioComProP_To)),  0,  StringUtil.Trim( StringUtil.Str( AV159TFSolicitudServicioComProP, 6, 2)),  StringUtil.Trim( StringUtil.Str( AV160TFSolicitudServicioComProP_To, 6, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMPROV",  context.GetMessage( "Comisión Comercio", ""),  !((Convert.ToDecimal(0)==AV161TFSolicitudServicioComProv)&&(Convert.ToDecimal(0)==AV162TFSolicitudServicioComProv_To)),  0,  StringUtil.Trim( StringUtil.Str( AV161TFSolicitudServicioComProv, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV162TFSolicitudServicioComProv_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDSERVICIOCOMPROVP",  context.GetMessage( "% Comisión Comercio", ""),  !((Convert.ToDecimal(0)==AV163TFSolicitudServicioComProvP)&&(Convert.ToDecimal(0)==AV164TFSolicitudServicioComProvP_To)),  0,  StringUtil.Trim( StringUtil.Str( AV163TFSolicitudServicioComProvP, 6, 2)),  StringUtil.Trim( StringUtil.Str( AV164TFSolicitudServicioComProvP_To, 6, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOSTOXZCOMALM",  context.GetMessage( "Almango xZona", ""),  !((Convert.ToDecimal(0)==AV165TFSolicitudesCostoXZComAlm)&&(Convert.ToDecimal(0)==AV166TFSolicitudesCostoXZComAlm_To)),  0,  StringUtil.Trim( StringUtil.Str( AV165TFSolicitudesCostoXZComAlm, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV166TFSolicitudesCostoXZComAlm_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOSTOXZCOMALMP",  context.GetMessage( "% Almango xZona", ""),  !((Convert.ToDecimal(0)==AV167TFSolicitudesCostoXZComAlmP)&&(Convert.ToDecimal(0)==AV168TFSolicitudesCostoXZComAlmP_To)),  0,  StringUtil.Trim( StringUtil.Str( AV167TFSolicitudesCostoXZComAlmP, 6, 2)),  StringUtil.Trim( StringUtil.Str( AV168TFSolicitudesCostoXZComAlmP_To, 6, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOSTOXZCOMPROF",  context.GetMessage( "Profesional xZona", ""),  !((Convert.ToDecimal(0)==AV169TFSolicitudesCostoXZComProf)&&(Convert.ToDecimal(0)==AV170TFSolicitudesCostoXZComProf_To)),  0,  StringUtil.Trim( StringUtil.Str( AV169TFSolicitudesCostoXZComProf, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV170TFSolicitudesCostoXZComProf_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOSTOXZCOMPROFP",  context.GetMessage( "% Profesional xZona", ""),  !((Convert.ToDecimal(0)==AV171TFSolicitudesCostoXZComProfP)&&(Convert.ToDecimal(0)==AV172TFSolicitudesCostoXZComProfP_To)),  0,  StringUtil.Trim( StringUtil.Str( AV171TFSolicitudesCostoXZComProfP, 6, 2)),  StringUtil.Trim( StringUtil.Str( AV172TFSolicitudesCostoXZComProfP_To, 6, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOSTOXZONA",  context.GetMessage( "Total xZona", ""),  !((Convert.ToDecimal(0)==AV173TFSolicitudesCostoXZona)&&(Convert.ToDecimal(0)==AV174TFSolicitudesCostoXZona_To)),  0,  StringUtil.Trim( StringUtil.Str( AV173TFSolicitudesCostoXZona, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV174TFSolicitudesCostoXZona_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCANCELACIONTIPIFICACIONDESCRIPCION",  context.GetMessage( "Tipo Cancelación", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV210TFCancelacionTipificacionDescripcion)),  0,  AV210TFCancelacionTipificacionDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV211TFCancelacionTipificacionDescripcion_Sel)),  AV211TFCancelacionTipificacionDescripcion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESNOTA",  context.GetMessage( "Nota", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV175TFSolicitudesNota)),  0,  AV175TFSolicitudesNota,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV176TFSolicitudesNota_Sel)),  AV176TFSolicitudesNota_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESCOMENTARIO",  context.GetMessage( "Comentario", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV177TFSolicitudesComentario)),  0,  AV177TFSolicitudesComentario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV178TFSolicitudesComentario_Sel)),  AV178TFSolicitudesComentario_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESOTROS2",  context.GetMessage( "Otros2", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV179TFSolicitudesOtros2)),  0,  AV179TFSolicitudesOtros2,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV180TFSolicitudesOtros2_Sel)),  AV180TFSolicitudesOtros2_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSOLICITUDESOTROS3",  context.GetMessage( "Otros3", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV181TFSolicitudesOtros3)),  0,  AV181TFSolicitudesOtros3,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV182TFSolicitudesOtros3_Sel)),  AV182TFSolicitudesOtros3_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESFECHAALTA",  context.GetMessage( "Fecha Alta", ""),  !((DateTime.MinValue==AV183TFSolicitudesFechaAlta)&&(DateTime.MinValue==AV184TFSolicitudesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV183TFSolicitudesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV184TFSolicitudesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSOLICITUDESFECHAACTUALIZACION",  context.GetMessage( "Fecha Modificación", ""),  !((DateTime.MinValue==AV188TFSolicitudesFechaActualizacion)&&(DateTime.MinValue==AV189TFSolicitudesFechaActualizacion_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV188TFSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV189TFSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV212Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV212Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "SolicitudesReporte";
         AV52Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S162( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new solicitudesreportewwexport(context ).execute( out  AV46ExcelFilename, out  AV47ErrorMessage) ;
         if ( StringUtil.StrCmp(AV46ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV46ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV47ErrorMessage);
         }
      }

      protected void wb_table1_21_JW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudesfechainstalacion_rangetext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudesfechainstalacion_rangetext_Internalname, context.GetMessage( "Fecha Instalación", ""), "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudesfechainstalacion_rangetext_Internalname, AV206SolicitudesFechaInstalacion_RangeText, StringUtil.RTrim( context.localUtil.Format( AV206SolicitudesFechaInstalacion_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudesfechainstalacion_rangetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSolicitudesfechainstalacion_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesReporteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_JW2e( true) ;
         }
         else
         {
            wb_table1_21_JW2e( false) ;
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
         PAJW2( ) ;
         WSJW2( ) ;
         WEJW2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026980414550", true, true, false);
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
         context.AddJavascriptSource("solicitudesreporteww.js", "?2026980414550", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtavProfesionalid_Internalname = "vPROFESIONALID_"+sGXsfl_39_idx;
         edtavProfesional_Internalname = "vPROFESIONAL_"+sGXsfl_39_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_39_idx;
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO_"+sGXsfl_39_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_39_idx;
         edtavHorainstalacion_Internalname = "vHORAINSTALACION_"+sGXsfl_39_idx;
         edtavDia_Internalname = "vDIA_"+sGXsfl_39_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_39_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_39_idx;
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_39_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_39_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_39_idx;
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE_"+sGXsfl_39_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_39_idx;
         edtSolicitudesMail_Internalname = "SOLICITUDESMAIL_"+sGXsfl_39_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_39_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_39_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_39_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_39_idx;
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_39_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_39_idx;
         edtSolicitudesDireccion_Internalname = "SOLICITUDESDIRECCION_"+sGXsfl_39_idx;
         edtSolicitudesAutoEnumerar_Internalname = "SOLICITUDESAUTOENUMERAR_"+sGXsfl_39_idx;
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO_"+sGXsfl_39_idx;
         edtMetodoPagosNombre_Internalname = "METODOPAGOSNOMBRE_"+sGXsfl_39_idx;
         cmbSolicitudesPagado_Internalname = "SOLICITUDESPAGADO_"+sGXsfl_39_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_39_idx;
         edtSolicitudesCotizacion_Internalname = "SOLICITUDESCOTIZACION_"+sGXsfl_39_idx;
         edtSolicitudesDescuento_Internalname = "SOLICITUDESDESCUENTO_"+sGXsfl_39_idx;
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM_"+sGXsfl_39_idx;
         edtSolicitudServicioComALMP_Internalname = "SOLICITUDSERVICIOCOMALMP_"+sGXsfl_39_idx;
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO_"+sGXsfl_39_idx;
         edtSolicitudServicioComProP_Internalname = "SOLICITUDSERVICIOCOMPROP_"+sGXsfl_39_idx;
         edtSolicitudServicioComProv_Internalname = "SOLICITUDSERVICIOCOMPROV_"+sGXsfl_39_idx;
         edtSolicitudServicioComProvP_Internalname = "SOLICITUDSERVICIOCOMPROVP_"+sGXsfl_39_idx;
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM_"+sGXsfl_39_idx;
         edtSolicitudesCostoXZComAlmP_Internalname = "SOLICITUDESCOSTOXZCOMALMP_"+sGXsfl_39_idx;
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF_"+sGXsfl_39_idx;
         edtSolicitudesCostoXZComProfP_Internalname = "SOLICITUDESCOSTOXZCOMPROFP_"+sGXsfl_39_idx;
         edtSolicitudesCostoXZona_Internalname = "SOLICITUDESCOSTOXZONA_"+sGXsfl_39_idx;
         edtCancelacionTipificacionDescrip_Internalname = "CANCELACIONTIPIFICACIONDESCRIP_"+sGXsfl_39_idx;
         edtSolicitudesNota_Internalname = "SOLICITUDESNOTA_"+sGXsfl_39_idx;
         edtSolicitudesComentario_Internalname = "SOLICITUDESCOMENTARIO_"+sGXsfl_39_idx;
         edtSolicitudesHoraInstalacion_Internalname = "SOLICITUDESHORAINSTALACION_"+sGXsfl_39_idx;
         chkSolicitudesOtros1_Internalname = "SOLICITUDESOTROS1_"+sGXsfl_39_idx;
         edtSolicitudesOtros2_Internalname = "SOLICITUDESOTROS2_"+sGXsfl_39_idx;
         edtSolicitudesOtros3_Internalname = "SOLICITUDESOTROS3_"+sGXsfl_39_idx;
         edtSolicitudesUsrActualizacion_Internalname = "SOLICITUDESUSRACTUALIZACION_"+sGXsfl_39_idx;
         edtSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA_"+sGXsfl_39_idx;
         edtavUseralta_Internalname = "vUSERALTA_"+sGXsfl_39_idx;
         edtavUserupd_Internalname = "vUSERUPD_"+sGXsfl_39_idx;
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA_"+sGXsfl_39_idx;
         edtSolicitudesFechaActualizacion_Internalname = "SOLICITUDESFECHAACTUALIZACION_"+sGXsfl_39_idx;
         edtavExiste_Internalname = "vEXISTE_"+sGXsfl_39_idx;
         edtCancelacionTipificacionId_Internalname = "CANCELACIONTIPIFICACIONID_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtavProfesionalid_Internalname = "vPROFESIONALID_"+sGXsfl_39_fel_idx;
         edtavProfesional_Internalname = "vPROFESIONAL_"+sGXsfl_39_fel_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_39_fel_idx;
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO_"+sGXsfl_39_fel_idx;
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION_"+sGXsfl_39_fel_idx;
         edtavHorainstalacion_Internalname = "vHORAINSTALACION_"+sGXsfl_39_fel_idx;
         edtavDia_Internalname = "vDIA_"+sGXsfl_39_fel_idx;
         edtEstadosSolId_Internalname = "ESTADOSSOLID_"+sGXsfl_39_fel_idx;
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE_"+sGXsfl_39_fel_idx;
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_39_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_39_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_39_fel_idx;
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE_"+sGXsfl_39_fel_idx;
         edtSolicitudesTelefono_Internalname = "SOLICITUDESTELEFONO_"+sGXsfl_39_fel_idx;
         edtSolicitudesMail_Internalname = "SOLICITUDESMAIL_"+sGXsfl_39_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_39_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_39_fel_idx;
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO_"+sGXsfl_39_fel_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_39_fel_idx;
         edtDepartamentoMunicipioNombre_Internalname = "DEPARTAMENTOMUNICIPIONOMBRE_"+sGXsfl_39_fel_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_39_fel_idx;
         edtSolicitudesDireccion_Internalname = "SOLICITUDESDIRECCION_"+sGXsfl_39_fel_idx;
         edtSolicitudesAutoEnumerar_Internalname = "SOLICITUDESAUTOENUMERAR_"+sGXsfl_39_fel_idx;
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO_"+sGXsfl_39_fel_idx;
         edtMetodoPagosNombre_Internalname = "METODOPAGOSNOMBRE_"+sGXsfl_39_fel_idx;
         cmbSolicitudesPagado_Internalname = "SOLICITUDESPAGADO_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL_"+sGXsfl_39_fel_idx;
         edtSolicitudesCotizacion_Internalname = "SOLICITUDESCOTIZACION_"+sGXsfl_39_fel_idx;
         edtSolicitudesDescuento_Internalname = "SOLICITUDESDESCUENTO_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComALMP_Internalname = "SOLICITUDSERVICIOCOMALMP_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComProP_Internalname = "SOLICITUDSERVICIOCOMPROP_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComProv_Internalname = "SOLICITUDSERVICIOCOMPROV_"+sGXsfl_39_fel_idx;
         edtSolicitudServicioComProvP_Internalname = "SOLICITUDSERVICIOCOMPROVP_"+sGXsfl_39_fel_idx;
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM_"+sGXsfl_39_fel_idx;
         edtSolicitudesCostoXZComAlmP_Internalname = "SOLICITUDESCOSTOXZCOMALMP_"+sGXsfl_39_fel_idx;
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF_"+sGXsfl_39_fel_idx;
         edtSolicitudesCostoXZComProfP_Internalname = "SOLICITUDESCOSTOXZCOMPROFP_"+sGXsfl_39_fel_idx;
         edtSolicitudesCostoXZona_Internalname = "SOLICITUDESCOSTOXZONA_"+sGXsfl_39_fel_idx;
         edtCancelacionTipificacionDescrip_Internalname = "CANCELACIONTIPIFICACIONDESCRIP_"+sGXsfl_39_fel_idx;
         edtSolicitudesNota_Internalname = "SOLICITUDESNOTA_"+sGXsfl_39_fel_idx;
         edtSolicitudesComentario_Internalname = "SOLICITUDESCOMENTARIO_"+sGXsfl_39_fel_idx;
         edtSolicitudesHoraInstalacion_Internalname = "SOLICITUDESHORAINSTALACION_"+sGXsfl_39_fel_idx;
         chkSolicitudesOtros1_Internalname = "SOLICITUDESOTROS1_"+sGXsfl_39_fel_idx;
         edtSolicitudesOtros2_Internalname = "SOLICITUDESOTROS2_"+sGXsfl_39_fel_idx;
         edtSolicitudesOtros3_Internalname = "SOLICITUDESOTROS3_"+sGXsfl_39_fel_idx;
         edtSolicitudesUsrActualizacion_Internalname = "SOLICITUDESUSRACTUALIZACION_"+sGXsfl_39_fel_idx;
         edtSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA_"+sGXsfl_39_fel_idx;
         edtavUseralta_Internalname = "vUSERALTA_"+sGXsfl_39_fel_idx;
         edtavUserupd_Internalname = "vUSERUPD_"+sGXsfl_39_fel_idx;
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA_"+sGXsfl_39_fel_idx;
         edtSolicitudesFechaActualizacion_Internalname = "SOLICITUDESFECHAACTUALIZACION_"+sGXsfl_39_fel_idx;
         edtavExiste_Internalname = "vEXISTE_"+sGXsfl_39_fel_idx;
         edtCancelacionTipificacionId_Internalname = "CANCELACIONTIPIFICACIONID_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WBJW0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavProfesionalid_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProfesionalid_Internalname,StringUtil.RTrim( AV200ProfesionalId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProfesionalid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavProfesionalid_Visible,(int)edtavProfesionalid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavProfesional_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProfesional_Internalname,(string)AV201Profesional,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProfesional_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnColorInfo",(string)"",(int)edtavProfesional_Visible,(int)edtavProfesional_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnColorInfo ColumnWeightBold",(string)"",(int)edtSolicitudesID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbSolicitudesSubTipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbSolicitudesSubTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDESSUBTIPO_" + sGXsfl_39_idx;
               cmbSolicitudesSubTipo.Name = GXCCtl;
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
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudesSubTipo,(string)cmbSolicitudesSubTipo_Internalname,StringUtil.RTrim( A600SolicitudesSubTipo),(short)1,(string)cmbSolicitudesSubTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbSolicitudesSubTipo.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudesSubTipo.CurrentValue = StringUtil.RTrim( A600SolicitudesSubTipo);
            AssignProp("", false, cmbSolicitudesSubTipo_Internalname, "Values", (string)(cmbSolicitudesSubTipo.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesFechaInstalacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaInstalacion_Internalname,context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99"),context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaInstalacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesFechaInstalacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavHorainstalacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHorainstalacion_Internalname,(string)AV128HoraInstalacion,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHorainstalacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavHorainstalacion_Visible,(int)edtavHorainstalacion_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDia_Internalname,(string)AV129Dia,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDia_Visible,(int)edtavDia_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadosSolNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolNombre_Internalname,StringUtil.RTrim( A132EstadosSolNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadosSolNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosSolNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadosSolNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A140RelacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnColorBaseColor ColumnWeightBold hidden-xs",(string)"",(int)edtProveedorNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesNombre_Internalname,StringUtil.RTrim( A171SolicitudesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesTelefono_Internalname,StringUtil.RTrim( A172SolicitudesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"598 099 999999",(string)edtSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesMail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesMail_Internalname,(string)A206SolicitudesMail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A206SolicitudesMail,(string)"",(string)"",(string)"",(string)edtSolicitudesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesMail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtPaisID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtPaisID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDepartamentoDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoDepartamento_Internalname,StringUtil.RTrim( A113DepartamentoDepartamento),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDepartamentoDepartamento_Link,(string)"",(string)"",(string)"",(string)edtDepartamentoDepartamento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDepartamentoDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDepartamentoMunicipioNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioNombre_Internalname,StringUtil.RTrim( A115DepartamentoMunicipioNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtDepartamentoMunicipioNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtZonasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Seleccione su Zona", ""),(string)edtZonasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesDireccion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesDireccion_Internalname,(string)A173SolicitudesDireccion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Calle, casa numero 1234...", ""),(string)edtSolicitudesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesDireccion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesAutoEnumerar_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A194SolicitudesAutoEnumerar), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesAutoEnumerar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbSolicitudServicioOrigenPago.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbSolicitudServicioOrigenPago.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDSERVICIOORIGENPAGO_" + sGXsfl_39_idx;
               cmbSolicitudServicioOrigenPago.Name = GXCCtl;
               cmbSolicitudServicioOrigenPago.WebTags = "";
               cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
               cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
               cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
               if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
               {
                  A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
                  n438SolicitudServicioOrigenPago = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudServicioOrigenPago,(string)cmbSolicitudServicioOrigenPago_Internalname,StringUtil.RTrim( A438SolicitudServicioOrigenPago),(short)1,(string)cmbSolicitudServicioOrigenPago_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbSolicitudServicioOrigenPago.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudServicioOrigenPago.CurrentValue = StringUtil.RTrim( A438SolicitudServicioOrigenPago);
            AssignProp("", false, cmbSolicitudServicioOrigenPago_Internalname, "Values", (string)(cmbSolicitudServicioOrigenPago.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMetodoPagosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMetodoPagosNombre_Internalname,StringUtil.RTrim( A129MetodoPagosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMetodoPagosNombre_Link,(string)"",(string)"",(string)"",(string)edtMetodoPagosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMetodoPagosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbSolicitudesPagado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbSolicitudesPagado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDESPAGADO_" + sGXsfl_39_idx;
               cmbSolicitudesPagado.Name = GXCCtl;
               cmbSolicitudesPagado.WebTags = "";
               cmbSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
               cmbSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
               if ( cmbSolicitudesPagado.ItemCount > 0 )
               {
                  A441SolicitudesPagado = cmbSolicitudesPagado.getValidValue(A441SolicitudesPagado);
                  n441SolicitudesPagado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudesPagado,(string)cmbSolicitudesPagado_Internalname,StringUtil.RTrim( A441SolicitudesPagado),(short)1,(string)cmbSolicitudesPagado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbSolicitudesPagado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudesPagado.CurrentValue = StringUtil.RTrim( A441SolicitudesPagado);
            AssignProp("", false, cmbSolicitudesPagado_Internalname, "Values", (string)(cmbSolicitudesPagado.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioPFinal_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSolicitudServicioPFinal_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCotizacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCotizacion_Internalname,StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A212SolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCotizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSolicitudesCotizacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesDescuento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesDescuento_Internalname,StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A897SolicitudesDescuento, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesDescuento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtSolicitudesDescuento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComALM_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A530SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComALM_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComALMP_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComALMP_Internalname,StringUtil.LTrim( StringUtil.NToC( A532SolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A532SolicitudServicioComALMP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComALMP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComALMP_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComPro_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComPro_Internalname,StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A529SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComPro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComPro_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComProP_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComProP_Internalname,StringUtil.LTrim( StringUtil.NToC( A531SolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A531SolicitudServicioComProP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComProP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComProP_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComProv_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComProv_Internalname,StringUtil.LTrim( StringUtil.NToC( A527SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A527SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComProv_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudServicioComProvP_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioComProvP_Internalname,StringUtil.LTrim( StringUtil.NToC( A528SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A528SolicitudServicioComProvP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioComProvP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudServicioComProvP_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCostoXZComAlm_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComAlm_Internalname,StringUtil.LTrim( StringUtil.NToC( A865SolicitudesCostoXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A865SolicitudesCostoXZComAlm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComAlm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesCostoXZComAlm_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCostoXZComAlmP_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComAlmP_Internalname,StringUtil.LTrim( StringUtil.NToC( A866SolicitudesCostoXZComAlmP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A866SolicitudesCostoXZComAlmP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComAlmP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesCostoXZComAlmP_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCostoXZComProf_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComProf_Internalname,StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A867SolicitudesCostoXZComProf, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComProf_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesCostoXZComProf_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCostoXZComProfP_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZComProfP_Internalname,StringUtil.LTrim( StringUtil.NToC( A868SolicitudesCostoXZComProfP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A868SolicitudesCostoXZComProfP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZComProfP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesCostoXZComProfP_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesCostoXZona_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesCostoXZona_Internalname,StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A864SolicitudesCostoXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesCostoXZona_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesCostoXZona_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCancelacionTipificacionDescrip_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCancelacionTipificacionDescrip_Internalname,StringUtil.RTrim( A997CancelacionTipificacionDescrip),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCancelacionTipificacionDescrip_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCancelacionTipificacionDescrip_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)250,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesNota_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesNota_Internalname,StringUtil.RTrim( A261SolicitudesNota),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesNota_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesNota_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesComentario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesComentario_Internalname,(string)A205SolicitudesComentario,(string)A205SolicitudesComentario,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesComentario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesComentario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)39,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesHoraInstalacion_Internalname,StringUtil.RTrim( A183SolicitudesHoraInstalacion),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesHoraInstalacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SOLICITUDESOTROS1_" + sGXsfl_39_idx;
            chkSolicitudesOtros1.Name = GXCCtl;
            chkSolicitudesOtros1.WebTags = "";
            chkSolicitudesOtros1.Caption = "";
            AssignProp("", false, chkSolicitudesOtros1_Internalname, "TitleCaption", chkSolicitudesOtros1.Caption, !bGXsfl_39_Refreshing);
            chkSolicitudesOtros1.CheckedValue = "N";
            A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSolicitudesOtros1_Internalname,(string)A201SolicitudesOtros1,context.GetMessage( "No aparecen en el listado los servcios que necesito.", ""),(string)"",(short)0,(short)0,(string)"S",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesOtros2_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesOtros2_Internalname,StringUtil.RTrim( A202SolicitudesOtros2),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesOtros2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesOtros2_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSolicitudesOtros3_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesOtros3_Internalname,StringUtil.RTrim( A203SolicitudesOtros3),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesOtros3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesOtros3_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesUsrActualizacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A598SolicitudesUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A598SolicitudesUsrActualizacion), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesUsrActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesUsrAlta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A597SolicitudesUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A597SolicitudesUsrAlta), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUseralta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseralta_Internalname,(string)AV130UserAlta,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseralta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavUseralta_Visible,(int)edtavUseralta_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUserupd_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserupd_Internalname,(string)AV131UserUPD,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUserupd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavUserupd_Visible,(int)edtavUserupd_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaAlta_Internalname,context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999"),context.localUtil.Format( A182SolicitudesFechaAlta, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSolicitudesFechaActualizacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesFechaActualizacion_Internalname,context.localUtil.TToC( A204SolicitudesFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A204SolicitudesFechaActualizacion, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesFechaActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSolicitudesFechaActualizacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExiste_Internalname,StringUtil.RTrim( AV202Existe),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExiste_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavExiste_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCancelacionTipificacionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A996CancelacionTipificacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A996CancelacionTipificacionId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCancelacionTipificacionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesJW2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SOLICITUDESSUBTIPO_" + sGXsfl_39_idx;
         cmbSolicitudesSubTipo.Name = GXCCtl;
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
         }
         GXCCtl = "SOLICITUDSERVICIOORIGENPAGO_" + sGXsfl_39_idx;
         cmbSolicitudServicioOrigenPago.Name = GXCCtl;
         cmbSolicitudServicioOrigenPago.WebTags = "";
         cmbSolicitudServicioOrigenPago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbSolicitudServicioOrigenPago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbSolicitudServicioOrigenPago.ItemCount > 0 )
         {
            A438SolicitudServicioOrigenPago = cmbSolicitudServicioOrigenPago.getValidValue(A438SolicitudServicioOrigenPago);
            n438SolicitudServicioOrigenPago = false;
         }
         GXCCtl = "SOLICITUDESPAGADO_" + sGXsfl_39_idx;
         cmbSolicitudesPagado.Name = GXCCtl;
         cmbSolicitudesPagado.WebTags = "";
         cmbSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbSolicitudesPagado.ItemCount > 0 )
         {
            A441SolicitudesPagado = cmbSolicitudesPagado.getValidValue(A441SolicitudesPagado);
            n441SolicitudesPagado = false;
         }
         GXCCtl = "SOLICITUDESOTROS1_" + sGXsfl_39_idx;
         chkSolicitudesOtros1.Name = GXCCtl;
         chkSolicitudesOtros1.WebTags = "";
         chkSolicitudesOtros1.Caption = "";
         AssignProp("", false, chkSolicitudesOtros1_Internalname, "TitleCaption", chkSolicitudesOtros1.Caption, !bGXsfl_39_Refreshing);
         chkSolicitudesOtros1.CheckedValue = "N";
         A201SolicitudesOtros1 = ((StringUtil.StrCmp(StringUtil.RTrim( A201SolicitudesOtros1), "S")==0) ? "S" : "N");
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavProfesionalid_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ProfesionalId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavProfesional_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbSolicitudesSubTipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesFechaInstalacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha de instalación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavHorainstalacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Día", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosSolNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cliente Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesMail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtPaisID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pais", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDepartamentoDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDepartamentoMunicipioNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Municipio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesDireccion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbSolicitudServicioOrigenPago.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen de Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMetodoPagosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Metodo de Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbSolicitudesPagado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "¿Pagado?", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioPFinal_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCotizacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cotización", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesDescuento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud Descuento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComALM_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión Almango", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComALMP_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "% Comisión Almango", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComPro_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComProP_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "% Comisión Profesional", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComProv_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudServicioComProvP_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "% Comisión Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCostoXZComAlm_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Almango xZona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCostoXZComAlmP_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "% Almango xZona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCostoXZComProf_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Profesional xZona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCostoXZComProfP_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "% Profesional xZona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesCostoXZona_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total xZona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCancelacionTipificacionDescrip_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Cancelación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesNota_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nota", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesComentario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comentario", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesOtros2_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Otros2", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesOtros3_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Otros3", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUseralta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUserupd_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario Modificación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSolicitudesFechaActualizacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Modificación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV200ProfesionalId)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProfesionalid_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProfesionalid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV201Profesional));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProfesional_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavProfesional_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A600SolicitudesSubTipo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSolicitudesSubTipo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A184SolicitudesFechaInstalacion, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesFechaInstalacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV128HoraInstalacion));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHorainstalacion_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHorainstalacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV129Dia));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDia_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDia_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132EstadosSolNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosSolNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosSolNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A171SolicitudesNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A172SolicitudesTelefono)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A206SolicitudesMail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesMail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaisID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A113DepartamentoDepartamento)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDepartamentoDepartamento_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoDepartamento_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A115DepartamentoMunicipioNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A173SolicitudesDireccion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesDireccion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A438SolicitudServicioOrigenPago)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSolicitudServicioOrigenPago.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A129MetodoPagosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMetodoPagosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMetodoPagosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A441SolicitudesPagado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSolicitudesPagado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioPFinal_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCotizacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesDescuento_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A530SolicitudServicioComALM, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComALM_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A532SolicitudServicioComALMP, 6, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComALMP_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A529SolicitudServicioComPro, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComPro_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A531SolicitudServicioComProP, 6, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComProP_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A527SolicitudServicioComProv, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComProv_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A528SolicitudServicioComProvP, 6, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudServicioComProvP_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A865SolicitudesCostoXZComAlm, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCostoXZComAlm_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A866SolicitudesCostoXZComAlmP, 6, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCostoXZComAlmP_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A867SolicitudesCostoXZComProf, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCostoXZComProf_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A868SolicitudesCostoXZComProfP, 6, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCostoXZComProfP_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesCostoXZona_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A997CancelacionTipificacionDescrip)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCancelacionTipificacionDescrip_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A261SolicitudesNota)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesNota_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A205SolicitudesComentario));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesComentario_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A183SolicitudesHoraInstalacion)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A201SolicitudesOtros1)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A202SolicitudesOtros2)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesOtros2_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A203SolicitudesOtros3)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesOtros3_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A598SolicitudesUsrActualizacion), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A597SolicitudesUsrAlta), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV130UserAlta));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseralta_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseralta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV131UserUPD));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUserupd_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUserupd_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A182SolicitudesFechaAlta, "99/99/9999")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A204SolicitudesFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSolicitudesFechaActualizacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV202Existe)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExiste_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A996CancelacionTipificacionId), 18, 0, ".", ""))));
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
         divTableactions_Internalname = "TABLEACTIONS";
         edtavSolicitudesfechainstalacion_rangetext_Internalname = "vSOLICITUDESFECHAINSTALACION_RANGETEXT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavProfesionalid_Internalname = "vPROFESIONALID";
         edtavProfesional_Internalname = "vPROFESIONAL";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         cmbSolicitudesSubTipo_Internalname = "SOLICITUDESSUBTIPO";
         edtSolicitudesFechaInstalacion_Internalname = "SOLICITUDESFECHAINSTALACION";
         edtavHorainstalacion_Internalname = "vHORAINSTALACION";
         edtavDia_Internalname = "vDIA";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtEstadosSolNombre_Internalname = "ESTADOSSOLNOMBRE";
         edtRelacionesId_Internalname = "RELACIONESID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
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
         cmbSolicitudServicioOrigenPago_Internalname = "SOLICITUDSERVICIOORIGENPAGO";
         edtMetodoPagosNombre_Internalname = "METODOPAGOSNOMBRE";
         cmbSolicitudesPagado_Internalname = "SOLICITUDESPAGADO";
         edtSolicitudServicioPFinal_Internalname = "SOLICITUDSERVICIOPFINAL";
         edtSolicitudesCotizacion_Internalname = "SOLICITUDESCOTIZACION";
         edtSolicitudesDescuento_Internalname = "SOLICITUDESDESCUENTO";
         edtSolicitudServicioComALM_Internalname = "SOLICITUDSERVICIOCOMALM";
         edtSolicitudServicioComALMP_Internalname = "SOLICITUDSERVICIOCOMALMP";
         edtSolicitudServicioComPro_Internalname = "SOLICITUDSERVICIOCOMPRO";
         edtSolicitudServicioComProP_Internalname = "SOLICITUDSERVICIOCOMPROP";
         edtSolicitudServicioComProv_Internalname = "SOLICITUDSERVICIOCOMPROV";
         edtSolicitudServicioComProvP_Internalname = "SOLICITUDSERVICIOCOMPROVP";
         edtSolicitudesCostoXZComAlm_Internalname = "SOLICITUDESCOSTOXZCOMALM";
         edtSolicitudesCostoXZComAlmP_Internalname = "SOLICITUDESCOSTOXZCOMALMP";
         edtSolicitudesCostoXZComProf_Internalname = "SOLICITUDESCOSTOXZCOMPROF";
         edtSolicitudesCostoXZComProfP_Internalname = "SOLICITUDESCOSTOXZCOMPROFP";
         edtSolicitudesCostoXZona_Internalname = "SOLICITUDESCOSTOXZONA";
         edtCancelacionTipificacionDescrip_Internalname = "CANCELACIONTIPIFICACIONDESCRIP";
         edtSolicitudesNota_Internalname = "SOLICITUDESNOTA";
         edtSolicitudesComentario_Internalname = "SOLICITUDESCOMENTARIO";
         edtSolicitudesHoraInstalacion_Internalname = "SOLICITUDESHORAINSTALACION";
         chkSolicitudesOtros1_Internalname = "SOLICITUDESOTROS1";
         edtSolicitudesOtros2_Internalname = "SOLICITUDESOTROS2";
         edtSolicitudesOtros3_Internalname = "SOLICITUDESOTROS3";
         edtSolicitudesUsrActualizacion_Internalname = "SOLICITUDESUSRACTUALIZACION";
         edtSolicitudesUsrAlta_Internalname = "SOLICITUDESUSRALTA";
         edtavUseralta_Internalname = "vUSERALTA";
         edtavUserupd_Internalname = "vUSERUPD";
         edtSolicitudesFechaAlta_Internalname = "SOLICITUDESFECHAALTA";
         edtSolicitudesFechaActualizacion_Internalname = "SOLICITUDESFECHAACTUALIZACION";
         edtavExiste_Internalname = "vEXISTE";
         edtCancelacionTipificacionId_Internalname = "CANCELACIONTIPIFICACIONID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Solicitudesfechainstalacion_rangepicker_Internalname = "SOLICITUDESFECHAINSTALACION_RANGEPICKER";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         edtavFechaini_Internalname = "vFECHAINI";
         edtavFechafin_Internalname = "vFECHAFIN";
         edtavFecharef_Internalname = "vFECHAREF";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_solicitudesfechaaltaauxdatetext_Internalname = "vDDO_SOLICITUDESFECHAALTAAUXDATETEXT";
         Tfsolicitudesfechaalta_rangepicker_Internalname = "TFSOLICITUDESFECHAALTA_RANGEPICKER";
         divDdo_solicitudesfechaaltaauxdates_Internalname = "DDO_SOLICITUDESFECHAALTAAUXDATES";
         edtavDdo_solicitudesfechaactualizacionauxdatetext_Internalname = "vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATETEXT";
         Tfsolicitudesfechaactualizacion_rangepicker_Internalname = "TFSOLICITUDESFECHAACTUALIZACION_RANGEPICKER";
         divDdo_solicitudesfechaactualizacionauxdates_Internalname = "DDO_SOLICITUDESFECHAACTUALIZACIONAUXDATES";
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
         edtCancelacionTipificacionId_Jsonclick = "";
         edtavExiste_Jsonclick = "";
         edtavExiste_Enabled = 0;
         edtSolicitudesFechaActualizacion_Jsonclick = "";
         edtSolicitudesFechaAlta_Jsonclick = "";
         edtavUserupd_Jsonclick = "";
         edtavUserupd_Enabled = 0;
         edtavUseralta_Jsonclick = "";
         edtavUseralta_Enabled = 0;
         edtSolicitudesUsrAlta_Jsonclick = "";
         edtSolicitudesUsrActualizacion_Jsonclick = "";
         edtSolicitudesOtros3_Jsonclick = "";
         edtSolicitudesOtros2_Jsonclick = "";
         chkSolicitudesOtros1.Caption = "";
         edtSolicitudesHoraInstalacion_Jsonclick = "";
         edtSolicitudesComentario_Jsonclick = "";
         edtSolicitudesNota_Jsonclick = "";
         edtCancelacionTipificacionDescrip_Jsonclick = "";
         edtSolicitudesCostoXZona_Jsonclick = "";
         edtSolicitudesCostoXZComProfP_Jsonclick = "";
         edtSolicitudesCostoXZComProf_Jsonclick = "";
         edtSolicitudesCostoXZComAlmP_Jsonclick = "";
         edtSolicitudesCostoXZComAlm_Jsonclick = "";
         edtSolicitudServicioComProvP_Jsonclick = "";
         edtSolicitudServicioComProv_Jsonclick = "";
         edtSolicitudServicioComProP_Jsonclick = "";
         edtSolicitudServicioComPro_Jsonclick = "";
         edtSolicitudServicioComALMP_Jsonclick = "";
         edtSolicitudServicioComALM_Jsonclick = "";
         edtSolicitudesDescuento_Jsonclick = "";
         edtSolicitudesCotizacion_Jsonclick = "";
         edtSolicitudServicioPFinal_Jsonclick = "";
         cmbSolicitudesPagado_Jsonclick = "";
         edtMetodoPagosNombre_Jsonclick = "";
         edtMetodoPagosNombre_Link = "";
         cmbSolicitudServicioOrigenPago_Jsonclick = "";
         edtSolicitudesAutoEnumerar_Jsonclick = "";
         edtSolicitudesDireccion_Jsonclick = "";
         edtZonasID_Jsonclick = "";
         edtDepartamentoMunicipioNombre_Jsonclick = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoDepartamento_Jsonclick = "";
         edtDepartamentoDepartamento_Link = "";
         edtDepartamentoId_Jsonclick = "";
         edtPaisID_Jsonclick = "";
         edtSolicitudesMail_Jsonclick = "";
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesNombre_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         edtRelacionesId_Jsonclick = "";
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolNombre_Link = "";
         edtEstadosSolId_Jsonclick = "";
         edtavDia_Jsonclick = "";
         edtavDia_Enabled = 0;
         edtavHorainstalacion_Jsonclick = "";
         edtavHorainstalacion_Enabled = 0;
         edtSolicitudesFechaInstalacion_Jsonclick = "";
         cmbSolicitudesSubTipo_Jsonclick = "";
         edtSolicitudesID_Jsonclick = "";
         edtavProfesional_Jsonclick = "";
         edtavProfesional_Enabled = 0;
         edtavProfesionalid_Jsonclick = "";
         edtavProfesionalid_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSolicitudesfechainstalacion_rangetext_Jsonclick = "";
         edtavSolicitudesfechainstalacion_rangetext_Enabled = 1;
         edtSolicitudesFechaActualizacion_Visible = -1;
         edtSolicitudesFechaAlta_Visible = -1;
         edtavUserupd_Visible = -1;
         edtavUseralta_Visible = -1;
         edtSolicitudesOtros3_Visible = -1;
         edtSolicitudesOtros2_Visible = -1;
         edtSolicitudesComentario_Visible = -1;
         edtSolicitudesNota_Visible = -1;
         edtCancelacionTipificacionDescrip_Visible = -1;
         edtSolicitudesCostoXZona_Visible = -1;
         edtSolicitudesCostoXZComProfP_Visible = -1;
         edtSolicitudesCostoXZComProf_Visible = -1;
         edtSolicitudesCostoXZComAlmP_Visible = -1;
         edtSolicitudesCostoXZComAlm_Visible = -1;
         edtSolicitudServicioComProvP_Visible = -1;
         edtSolicitudServicioComProv_Visible = -1;
         edtSolicitudServicioComProP_Visible = -1;
         edtSolicitudServicioComPro_Visible = -1;
         edtSolicitudServicioComALMP_Visible = -1;
         edtSolicitudServicioComALM_Visible = -1;
         edtSolicitudesDescuento_Visible = -1;
         edtSolicitudesCotizacion_Visible = -1;
         edtSolicitudServicioPFinal_Visible = -1;
         cmbSolicitudesPagado.Visible = -1;
         edtMetodoPagosNombre_Visible = -1;
         cmbSolicitudServicioOrigenPago.Visible = -1;
         edtSolicitudesDireccion_Visible = -1;
         edtDepartamentoMunicipioNombre_Visible = -1;
         edtDepartamentoDepartamento_Visible = -1;
         edtPaisID_Visible = -1;
         edtSolicitudesMail_Visible = -1;
         edtSolicitudesTelefono_Visible = -1;
         edtSolicitudesNombre_Visible = -1;
         edtProveedorNombre_Visible = -1;
         edtEstadosSolNombre_Visible = -1;
         edtavDia_Visible = -1;
         edtavHorainstalacion_Visible = -1;
         edtSolicitudesFechaInstalacion_Visible = -1;
         cmbSolicitudesSubTipo.Visible = -1;
         edtSolicitudesID_Visible = -1;
         edtavProfesional_Visible = -1;
         edtavProfesionalid_Visible = -1;
         edtCancelacionTipificacionId_Enabled = 0;
         edtSolicitudesFechaActualizacion_Enabled = 0;
         edtSolicitudesFechaAlta_Enabled = 0;
         edtSolicitudesUsrAlta_Enabled = 0;
         edtSolicitudesUsrActualizacion_Enabled = 0;
         edtSolicitudesOtros3_Enabled = 0;
         edtSolicitudesOtros2_Enabled = 0;
         chkSolicitudesOtros1.Enabled = 0;
         edtSolicitudesHoraInstalacion_Enabled = 0;
         edtSolicitudesComentario_Enabled = 0;
         edtSolicitudesNota_Enabled = 0;
         edtCancelacionTipificacionDescrip_Enabled = 0;
         edtSolicitudesCostoXZona_Enabled = 0;
         edtSolicitudesCostoXZComProfP_Enabled = 0;
         edtSolicitudesCostoXZComProf_Enabled = 0;
         edtSolicitudesCostoXZComAlmP_Enabled = 0;
         edtSolicitudesCostoXZComAlm_Enabled = 0;
         edtSolicitudServicioComProvP_Enabled = 0;
         edtSolicitudServicioComProv_Enabled = 0;
         edtSolicitudServicioComProP_Enabled = 0;
         edtSolicitudServicioComPro_Enabled = 0;
         edtSolicitudServicioComALMP_Enabled = 0;
         edtSolicitudServicioComALM_Enabled = 0;
         edtSolicitudesDescuento_Enabled = 0;
         edtSolicitudesCotizacion_Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         cmbSolicitudesPagado.Enabled = 0;
         edtMetodoPagosNombre_Enabled = 0;
         cmbSolicitudServicioOrigenPago.Enabled = 0;
         edtSolicitudesAutoEnumerar_Enabled = 0;
         edtSolicitudesDireccion_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtDepartamentoMunicipioNombre_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoDepartamento_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtSolicitudesMail_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtRelacionesId_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtSolicitudesFechaInstalacion_Enabled = 0;
         cmbSolicitudesSubTipo.Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_solicitudesfechaactualizacionauxdatetext_Jsonclick = "";
         edtavDdo_solicitudesfechaaltaauxdatetext_Jsonclick = "";
         edtavFecharef_Jsonclick = "";
         edtavFecharef_Visible = 1;
         edtavFechafin_Jsonclick = "";
         edtavFechafin_Visible = 1;
         edtavFechaini_Jsonclick = "";
         edtavFechaini_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||18.0|||||||||||||||||-18.2|-18.2|-18.2|18.2|6.2|-18.2|6.2|18.2|6.2|-18.2|6.2|-18.2|6.2|-18.2|||||||||";
         Ddo_grid_Datalistproc = "SolicitudesReporteWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||T:Trabajo Registrado,E:Ecommerce,G:Garantia,M:Mudanza,A:Obra,O:Otros,Z:Postulacion,S:Subasta Web,P:Postulacion Web|||||||||||||F:Cobro Directo,T:Cobro Prepago Comercio,O:Cobro Prepago Almango||S:Pagado,N:Pendiente de Pago|||||||||||||||||||||||";
         Ddo_grid_Allowmultipleselection = "|||T|||||||||||||T||T|||||||||||||||||||||||";
         Ddo_grid_Datalisttype = "|||FixedValues||||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic|FixedValues|||||||||||||||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||||";
         Ddo_grid_Includedatalist = "|||T||||T|T|T|T|T|T|T|T|T|T|T|T|||||||||||||||T|T|T|T|T||||";
         Ddo_grid_Filterisrange = "||T|||||||||||||||||T|T|T|T|T|T|T|T|T|T|T|T|T|T||||||||P|P";
         Ddo_grid_Filtertype = "||Numeric|||||Character|Character|Character|Character|Character|Character|Character|Character|Character||Character||Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Numeric|Character|Character|Character|Character|Character|||Date|Date";
         Ddo_grid_Includefilter = "||T|||||T|T|T|T|T|T|T|T|T||T||T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|||T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "||T|T|T|||T|T|T|T|T|T|T|T|T|T|T|T||T|T|T|T|||T|T|T|T|||T|T|T|T|T|T|||T|T";
         Ddo_grid_Columnssortvalues = "||1|2|3|||4|5|6|7|8|9|10|11|12|13|14|15||16|17|18|19|||20|21|22|23|||24|25|26|27|28|29|||30|31";
         Ddo_grid_Columnids = "0:ProfesionalId|1:Profesional|2:SolicitudesID|3:SolicitudesSubTipo|4:SolicitudesFechaInstalacion|5:HoraInstalacion|6:Dia|8:EstadosSolNombre|11:ProveedorNombre|12:SolicitudesNombre|13:SolicitudesTelefono|14:SolicitudesMail|15:PaisID|17:DepartamentoDepartamento|19:DepartamentoMunicipioNombre|21:SolicitudesDireccion|23:SolicitudServicioOrigenPago|24:MetodoPagosNombre|25:SolicitudesPagado|26:SolicitudServicioPFinal|27:SolicitudesCotizacion|28:SolicitudesDescuento|29:SolicitudServicioComALM|30:SolicitudServicioComALMP|31:SolicitudServicioComPro|32:SolicitudServicioComProP|33:SolicitudServicioComProv|34:SolicitudServicioComProvP|35:SolicitudesCostoXZComAlm|36:SolicitudesCostoXZComAlmP|37:SolicitudesCostoXZComProf|38:SolicitudesCostoXZComProfP|39:SolicitudesCostoXZona|40:CancelacionTipificacionDescripcion|41:SolicitudesNota|42:SolicitudesComentario|45:SolicitudesOtros2|46:SolicitudesOtros3|49:UserAlta|50:UserUPD|51:SolicitudesFechaAlta|52:SolicitudesFechaActualizacion";
         Ddo_grid_Gridinternalname = "";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Solicitudes Reporte", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavProfesionalid_Visible',ctrl:'vPROFESIONALID',prop:'Visible'},{av:'edtavProfesional_Visible',ctrl:'vPROFESIONAL',prop:'Visible'},{av:'edtSolicitudesID_Visible',ctrl:'SOLICITUDESID',prop:'Visible'},{av:'cmbSolicitudesSubTipo'},{av:'edtSolicitudesFechaInstalacion_Visible',ctrl:'SOLICITUDESFECHAINSTALACION',prop:'Visible'},{av:'edtavHorainstalacion_Visible',ctrl:'vHORAINSTALACION',prop:'Visible'},{av:'edtavDia_Visible',ctrl:'vDIA',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtSolicitudesNombre_Visible',ctrl:'SOLICITUDESNOMBRE',prop:'Visible'},{av:'edtSolicitudesTelefono_Visible',ctrl:'SOLICITUDESTELEFONO',prop:'Visible'},{av:'edtSolicitudesMail_Visible',ctrl:'SOLICITUDESMAIL',prop:'Visible'},{av:'edtPaisID_Visible',ctrl:'PAISID',prop:'Visible'},{av:'edtDepartamentoDepartamento_Visible',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoMunicipioNombre_Visible',ctrl:'DEPARTAMENTOMUNICIPIONOMBRE',prop:'Visible'},{av:'edtSolicitudesDireccion_Visible',ctrl:'SOLICITUDESDIRECCION',prop:'Visible'},{av:'cmbSolicitudServicioOrigenPago'},{av:'edtMetodoPagosNombre_Visible',ctrl:'METODOPAGOSNOMBRE',prop:'Visible'},{av:'cmbSolicitudesPagado'},{av:'edtSolicitudServicioPFinal_Visible',ctrl:'SOLICITUDSERVICIOPFINAL',prop:'Visible'},{av:'edtSolicitudesCotizacion_Visible',ctrl:'SOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtSolicitudesDescuento_Visible',ctrl:'SOLICITUDESDESCUENTO',prop:'Visible'},{av:'edtSolicitudServicioComALM_Visible',ctrl:'SOLICITUDSERVICIOCOMALM',prop:'Visible'},{av:'edtSolicitudServicioComALMP_Visible',ctrl:'SOLICITUDSERVICIOCOMALMP',prop:'Visible'},{av:'edtSolicitudServicioComPro_Visible',ctrl:'SOLICITUDSERVICIOCOMPRO',prop:'Visible'},{av:'edtSolicitudServicioComProP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROP',prop:'Visible'},{av:'edtSolicitudServicioComProv_Visible',ctrl:'SOLICITUDSERVICIOCOMPROV',prop:'Visible'},{av:'edtSolicitudServicioComProvP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROVP',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlm_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALM',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlmP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALMP',prop:'Visible'},{av:'edtSolicitudesCostoXZComProf_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROF',prop:'Visible'},{av:'edtSolicitudesCostoXZComProfP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROFP',prop:'Visible'},{av:'edtSolicitudesCostoXZona_Visible',ctrl:'SOLICITUDESCOSTOXZONA',prop:'Visible'},{av:'edtCancelacionTipificacionDescrip_Visible',ctrl:'CANCELACIONTIPIFICACIONDESCRIP',prop:'Visible'},{av:'edtSolicitudesNota_Visible',ctrl:'SOLICITUDESNOTA',prop:'Visible'},{av:'edtSolicitudesComentario_Visible',ctrl:'SOLICITUDESCOMENTARIO',prop:'Visible'},{av:'edtSolicitudesOtros2_Visible',ctrl:'SOLICITUDESOTROS2',prop:'Visible'},{av:'edtSolicitudesOtros3_Visible',ctrl:'SOLICITUDESOTROS3',prop:'Visible'},{av:'edtavUseralta_Visible',ctrl:'vUSERALTA',prop:'Visible'},{av:'edtavUserupd_Visible',ctrl:'vUSERUPD',prop:'Visible'},{av:'edtSolicitudesFechaAlta_Visible',ctrl:'SOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtSolicitudesFechaActualizacion_Visible',ctrl:'SOLICITUDESFECHAACTUALIZACION',prop:'Visible'},{av:'AV114GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV115GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV116GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11JW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavProfesionalid_Visible',ctrl:'vPROFESIONALID',prop:'Visible'},{av:'edtavProfesional_Visible',ctrl:'vPROFESIONAL',prop:'Visible'},{av:'edtSolicitudesID_Visible',ctrl:'SOLICITUDESID',prop:'Visible'},{av:'cmbSolicitudesSubTipo'},{av:'edtSolicitudesFechaInstalacion_Visible',ctrl:'SOLICITUDESFECHAINSTALACION',prop:'Visible'},{av:'edtavHorainstalacion_Visible',ctrl:'vHORAINSTALACION',prop:'Visible'},{av:'edtavDia_Visible',ctrl:'vDIA',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtSolicitudesNombre_Visible',ctrl:'SOLICITUDESNOMBRE',prop:'Visible'},{av:'edtSolicitudesTelefono_Visible',ctrl:'SOLICITUDESTELEFONO',prop:'Visible'},{av:'edtSolicitudesMail_Visible',ctrl:'SOLICITUDESMAIL',prop:'Visible'},{av:'edtPaisID_Visible',ctrl:'PAISID',prop:'Visible'},{av:'edtDepartamentoDepartamento_Visible',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoMunicipioNombre_Visible',ctrl:'DEPARTAMENTOMUNICIPIONOMBRE',prop:'Visible'},{av:'edtSolicitudesDireccion_Visible',ctrl:'SOLICITUDESDIRECCION',prop:'Visible'},{av:'cmbSolicitudServicioOrigenPago'},{av:'edtMetodoPagosNombre_Visible',ctrl:'METODOPAGOSNOMBRE',prop:'Visible'},{av:'cmbSolicitudesPagado'},{av:'edtSolicitudServicioPFinal_Visible',ctrl:'SOLICITUDSERVICIOPFINAL',prop:'Visible'},{av:'edtSolicitudesCotizacion_Visible',ctrl:'SOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtSolicitudesDescuento_Visible',ctrl:'SOLICITUDESDESCUENTO',prop:'Visible'},{av:'edtSolicitudServicioComALM_Visible',ctrl:'SOLICITUDSERVICIOCOMALM',prop:'Visible'},{av:'edtSolicitudServicioComALMP_Visible',ctrl:'SOLICITUDSERVICIOCOMALMP',prop:'Visible'},{av:'edtSolicitudServicioComPro_Visible',ctrl:'SOLICITUDSERVICIOCOMPRO',prop:'Visible'},{av:'edtSolicitudServicioComProP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROP',prop:'Visible'},{av:'edtSolicitudServicioComProv_Visible',ctrl:'SOLICITUDSERVICIOCOMPROV',prop:'Visible'},{av:'edtSolicitudServicioComProvP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROVP',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlm_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALM',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlmP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALMP',prop:'Visible'},{av:'edtSolicitudesCostoXZComProf_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROF',prop:'Visible'},{av:'edtSolicitudesCostoXZComProfP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROFP',prop:'Visible'},{av:'edtSolicitudesCostoXZona_Visible',ctrl:'SOLICITUDESCOSTOXZONA',prop:'Visible'},{av:'edtCancelacionTipificacionDescrip_Visible',ctrl:'CANCELACIONTIPIFICACIONDESCRIP',prop:'Visible'},{av:'edtSolicitudesNota_Visible',ctrl:'SOLICITUDESNOTA',prop:'Visible'},{av:'edtSolicitudesComentario_Visible',ctrl:'SOLICITUDESCOMENTARIO',prop:'Visible'},{av:'edtSolicitudesOtros2_Visible',ctrl:'SOLICITUDESOTROS2',prop:'Visible'},{av:'edtSolicitudesOtros3_Visible',ctrl:'SOLICITUDESOTROS3',prop:'Visible'},{av:'edtavUseralta_Visible',ctrl:'vUSERALTA',prop:'Visible'},{av:'edtavUserupd_Visible',ctrl:'vUSERUPD',prop:'Visible'},{av:'edtSolicitudesFechaAlta_Visible',ctrl:'SOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtSolicitudesFechaActualizacion_Visible',ctrl:'SOLICITUDESFECHAACTUALIZACION',prop:'Visible'},{av:'AV114GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV115GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV116GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12JW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E15JW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV145TFSolicitudesPagado_SelsJson',fld:'vTFSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV141TFSolicitudServicioOrigenPago_SelsJson',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELSJSON',pic:'',type:'vchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV132TFSolicitudesSubTipo_SelsJson',fld:'vTFSOLICITUDESSUBTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E19JW2',iparms:[{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A184SolicitudesFechaInstalacion',fld:'SOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'A183SolicitudesHoraInstalacion',fld:'SOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A597SolicitudesUsrAlta',fld:'SOLICITUDESUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'A598SolicitudesUsrActualizacion',fld:'SOLICITUDESUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtEstadosSolNombre_Link',ctrl:'ESTADOSSOLNOMBRE',prop:'Link'},{av:'edtDepartamentoDepartamento_Link',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Link'},{av:'edtMetodoPagosNombre_Link',ctrl:'METODOPAGOSNOMBRE',prop:'Link'},{av:'AV202Existe',fld:'vEXISTE',pic:'',type:'char'},{av:'AV201Profesional',fld:'vPROFESIONAL',pic:'',type:'svchar'},{av:'AV200ProfesionalId',fld:'vPROFESIONALID',pic:'',type:'char'},{av:'AV128HoraInstalacion',fld:'vHORAINSTALACION',pic:'',type:'svchar'},{av:'AV129Dia',fld:'vDIA',pic:'',type:'svchar'},{av:'AV130UserAlta',fld:'vUSERALTA',pic:'',type:'svchar'},{av:'AV131UserUPD',fld:'vUSERUPD',pic:'',type:'svchar'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E16JW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavProfesionalid_Visible',ctrl:'vPROFESIONALID',prop:'Visible'},{av:'edtavProfesional_Visible',ctrl:'vPROFESIONAL',prop:'Visible'},{av:'edtSolicitudesID_Visible',ctrl:'SOLICITUDESID',prop:'Visible'},{av:'cmbSolicitudesSubTipo'},{av:'edtSolicitudesFechaInstalacion_Visible',ctrl:'SOLICITUDESFECHAINSTALACION',prop:'Visible'},{av:'edtavHorainstalacion_Visible',ctrl:'vHORAINSTALACION',prop:'Visible'},{av:'edtavDia_Visible',ctrl:'vDIA',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtSolicitudesNombre_Visible',ctrl:'SOLICITUDESNOMBRE',prop:'Visible'},{av:'edtSolicitudesTelefono_Visible',ctrl:'SOLICITUDESTELEFONO',prop:'Visible'},{av:'edtSolicitudesMail_Visible',ctrl:'SOLICITUDESMAIL',prop:'Visible'},{av:'edtPaisID_Visible',ctrl:'PAISID',prop:'Visible'},{av:'edtDepartamentoDepartamento_Visible',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoMunicipioNombre_Visible',ctrl:'DEPARTAMENTOMUNICIPIONOMBRE',prop:'Visible'},{av:'edtSolicitudesDireccion_Visible',ctrl:'SOLICITUDESDIRECCION',prop:'Visible'},{av:'cmbSolicitudServicioOrigenPago'},{av:'edtMetodoPagosNombre_Visible',ctrl:'METODOPAGOSNOMBRE',prop:'Visible'},{av:'cmbSolicitudesPagado'},{av:'edtSolicitudServicioPFinal_Visible',ctrl:'SOLICITUDSERVICIOPFINAL',prop:'Visible'},{av:'edtSolicitudesCotizacion_Visible',ctrl:'SOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtSolicitudesDescuento_Visible',ctrl:'SOLICITUDESDESCUENTO',prop:'Visible'},{av:'edtSolicitudServicioComALM_Visible',ctrl:'SOLICITUDSERVICIOCOMALM',prop:'Visible'},{av:'edtSolicitudServicioComALMP_Visible',ctrl:'SOLICITUDSERVICIOCOMALMP',prop:'Visible'},{av:'edtSolicitudServicioComPro_Visible',ctrl:'SOLICITUDSERVICIOCOMPRO',prop:'Visible'},{av:'edtSolicitudServicioComProP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROP',prop:'Visible'},{av:'edtSolicitudServicioComProv_Visible',ctrl:'SOLICITUDSERVICIOCOMPROV',prop:'Visible'},{av:'edtSolicitudServicioComProvP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROVP',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlm_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALM',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlmP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALMP',prop:'Visible'},{av:'edtSolicitudesCostoXZComProf_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROF',prop:'Visible'},{av:'edtSolicitudesCostoXZComProfP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROFP',prop:'Visible'},{av:'edtSolicitudesCostoXZona_Visible',ctrl:'SOLICITUDESCOSTOXZONA',prop:'Visible'},{av:'edtCancelacionTipificacionDescrip_Visible',ctrl:'CANCELACIONTIPIFICACIONDESCRIP',prop:'Visible'},{av:'edtSolicitudesNota_Visible',ctrl:'SOLICITUDESNOTA',prop:'Visible'},{av:'edtSolicitudesComentario_Visible',ctrl:'SOLICITUDESCOMENTARIO',prop:'Visible'},{av:'edtSolicitudesOtros2_Visible',ctrl:'SOLICITUDESOTROS2',prop:'Visible'},{av:'edtSolicitudesOtros3_Visible',ctrl:'SOLICITUDESOTROS3',prop:'Visible'},{av:'edtavUseralta_Visible',ctrl:'vUSERALTA',prop:'Visible'},{av:'edtavUserupd_Visible',ctrl:'vUSERUPD',prop:'Visible'},{av:'edtSolicitudesFechaAlta_Visible',ctrl:'SOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtSolicitudesFechaActualizacion_Visible',ctrl:'SOLICITUDESFECHAACTUALIZACION',prop:'Visible'},{av:'AV114GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV115GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV116GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13JW2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV132TFSolicitudesSubTipo_SelsJson',fld:'vTFSOLICITUDESSUBTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV141TFSolicitudServicioOrigenPago_SelsJson',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELSJSON',pic:'',type:'vchar'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV145TFSolicitudesPagado_SelsJson',fld:'vTFSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV190DDO_SolicitudesFechaActualizacionAuxDate',fld:'vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATE',pic:'',type:'date'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV191DDO_SolicitudesFechaActualizacionAuxDateTo',fld:'vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATETO',pic:'',type:'date'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV190DDO_SolicitudesFechaActualizacionAuxDate',fld:'vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATE',pic:'',type:'date'},{av:'AV191DDO_SolicitudesFechaActualizacionAuxDateTo',fld:'vDDO_SOLICITUDESFECHAACTUALIZACIONAUXDATETO',pic:'',type:'date'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV145TFSolicitudesPagado_SelsJson',fld:'vTFSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV141TFSolicitudServicioOrigenPago_SelsJson',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELSJSON',pic:'',type:'vchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV132TFSolicitudesSubTipo_SelsJson',fld:'vTFSOLICITUDESSUBTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'edtavProfesionalid_Visible',ctrl:'vPROFESIONALID',prop:'Visible'},{av:'edtavProfesional_Visible',ctrl:'vPROFESIONAL',prop:'Visible'},{av:'edtSolicitudesID_Visible',ctrl:'SOLICITUDESID',prop:'Visible'},{av:'cmbSolicitudesSubTipo'},{av:'edtSolicitudesFechaInstalacion_Visible',ctrl:'SOLICITUDESFECHAINSTALACION',prop:'Visible'},{av:'edtavHorainstalacion_Visible',ctrl:'vHORAINSTALACION',prop:'Visible'},{av:'edtavDia_Visible',ctrl:'vDIA',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtSolicitudesNombre_Visible',ctrl:'SOLICITUDESNOMBRE',prop:'Visible'},{av:'edtSolicitudesTelefono_Visible',ctrl:'SOLICITUDESTELEFONO',prop:'Visible'},{av:'edtSolicitudesMail_Visible',ctrl:'SOLICITUDESMAIL',prop:'Visible'},{av:'edtPaisID_Visible',ctrl:'PAISID',prop:'Visible'},{av:'edtDepartamentoDepartamento_Visible',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoMunicipioNombre_Visible',ctrl:'DEPARTAMENTOMUNICIPIONOMBRE',prop:'Visible'},{av:'edtSolicitudesDireccion_Visible',ctrl:'SOLICITUDESDIRECCION',prop:'Visible'},{av:'cmbSolicitudServicioOrigenPago'},{av:'edtMetodoPagosNombre_Visible',ctrl:'METODOPAGOSNOMBRE',prop:'Visible'},{av:'cmbSolicitudesPagado'},{av:'edtSolicitudServicioPFinal_Visible',ctrl:'SOLICITUDSERVICIOPFINAL',prop:'Visible'},{av:'edtSolicitudesCotizacion_Visible',ctrl:'SOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtSolicitudesDescuento_Visible',ctrl:'SOLICITUDESDESCUENTO',prop:'Visible'},{av:'edtSolicitudServicioComALM_Visible',ctrl:'SOLICITUDSERVICIOCOMALM',prop:'Visible'},{av:'edtSolicitudServicioComALMP_Visible',ctrl:'SOLICITUDSERVICIOCOMALMP',prop:'Visible'},{av:'edtSolicitudServicioComPro_Visible',ctrl:'SOLICITUDSERVICIOCOMPRO',prop:'Visible'},{av:'edtSolicitudServicioComProP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROP',prop:'Visible'},{av:'edtSolicitudServicioComProv_Visible',ctrl:'SOLICITUDSERVICIOCOMPROV',prop:'Visible'},{av:'edtSolicitudServicioComProvP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROVP',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlm_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALM',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlmP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALMP',prop:'Visible'},{av:'edtSolicitudesCostoXZComProf_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROF',prop:'Visible'},{av:'edtSolicitudesCostoXZComProfP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROFP',prop:'Visible'},{av:'edtSolicitudesCostoXZona_Visible',ctrl:'SOLICITUDESCOSTOXZONA',prop:'Visible'},{av:'edtCancelacionTipificacionDescrip_Visible',ctrl:'CANCELACIONTIPIFICACIONDESCRIP',prop:'Visible'},{av:'edtSolicitudesNota_Visible',ctrl:'SOLICITUDESNOTA',prop:'Visible'},{av:'edtSolicitudesComentario_Visible',ctrl:'SOLICITUDESCOMENTARIO',prop:'Visible'},{av:'edtSolicitudesOtros2_Visible',ctrl:'SOLICITUDESOTROS2',prop:'Visible'},{av:'edtSolicitudesOtros3_Visible',ctrl:'SOLICITUDESOTROS3',prop:'Visible'},{av:'edtavUseralta_Visible',ctrl:'vUSERALTA',prop:'Visible'},{av:'edtavUserupd_Visible',ctrl:'vUSERUPD',prop:'Visible'},{av:'edtSolicitudesFechaAlta_Visible',ctrl:'SOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtSolicitudesFechaActualizacion_Visible',ctrl:'SOLICITUDESFECHAACTUALIZACION',prop:'Visible'},{av:'AV114GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV115GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV116GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("SOLICITUDESFECHAINSTALACION_RANGEPICKER.DATERANGECHANGED","{handler:'E14JW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV212Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV56TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV133TFSolicitudesSubTipo_Sels',fld:'vTFSOLICITUDESSUBTIPO_SELS',pic:''},{av:'AV139TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV140TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV64TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV65TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV58TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV59TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV90TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV91TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV92TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV93TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV94TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV95TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV98TFDepartamentoDepartamento',fld:'vTFDEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'AV99TFDepartamentoDepartamento_Sel',fld:'vTFDEPARTAMENTODEPARTAMENTO_SEL',pic:'',type:'char'},{av:'AV102TFDepartamentoMunicipioNombre',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE',pic:'',type:'char'},{av:'AV103TFDepartamentoMunicipioNombre_Sel',fld:'vTFDEPARTAMENTOMUNICIPIONOMBRE_SEL',pic:'',type:'char'},{av:'AV106TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV107TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV142TFSolicitudServicioOrigenPago_Sels',fld:'vTFSOLICITUDSERVICIOORIGENPAGO_SELS',pic:''},{av:'AV143TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV144TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV146TFSolicitudesPagado_Sels',fld:'vTFSOLICITUDESPAGADO_SELS',pic:''},{av:'AV147TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV148TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV149TFSolicitudesCotizacion',fld:'vTFSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV150TFSolicitudesCotizacion_To',fld:'vTFSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV151TFSolicitudesDescuento',fld:'vTFSOLICITUDESDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV152TFSolicitudesDescuento_To',fld:'vTFSOLICITUDESDESCUENTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV153TFSolicitudServicioComALM',fld:'vTFSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV154TFSolicitudServicioComALM_To',fld:'vTFSOLICITUDSERVICIOCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV155TFSolicitudServicioComALMP',fld:'vTFSOLICITUDSERVICIOCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV156TFSolicitudServicioComALMP_To',fld:'vTFSOLICITUDSERVICIOCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV157TFSolicitudServicioComPro',fld:'vTFSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV158TFSolicitudServicioComPro_To',fld:'vTFSOLICITUDSERVICIOCOMPRO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV159TFSolicitudServicioComProP',fld:'vTFSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV160TFSolicitudServicioComProP_To',fld:'vTFSOLICITUDSERVICIOCOMPROP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV161TFSolicitudServicioComProv',fld:'vTFSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV162TFSolicitudServicioComProv_To',fld:'vTFSOLICITUDSERVICIOCOMPROV_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV163TFSolicitudServicioComProvP',fld:'vTFSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV164TFSolicitudServicioComProvP_To',fld:'vTFSOLICITUDSERVICIOCOMPROVP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV165TFSolicitudesCostoXZComAlm',fld:'vTFSOLICITUDESCOSTOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV166TFSolicitudesCostoXZComAlm_To',fld:'vTFSOLICITUDESCOSTOXZCOMALM_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV167TFSolicitudesCostoXZComAlmP',fld:'vTFSOLICITUDESCOSTOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV168TFSolicitudesCostoXZComAlmP_To',fld:'vTFSOLICITUDESCOSTOXZCOMALMP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV169TFSolicitudesCostoXZComProf',fld:'vTFSOLICITUDESCOSTOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV170TFSolicitudesCostoXZComProf_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROF_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV171TFSolicitudesCostoXZComProfP',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'},{av:'AV172TFSolicitudesCostoXZComProfP_To',fld:'vTFSOLICITUDESCOSTOXZCOMPROFP_TO',pic:'ZZ9.99',type:'decimal'},{av:'AV173TFSolicitudesCostoXZona',fld:'vTFSOLICITUDESCOSTOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV174TFSolicitudesCostoXZona_To',fld:'vTFSOLICITUDESCOSTOXZONA_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV210TFCancelacionTipificacionDescripcion',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION',pic:'',type:'char'},{av:'AV211TFCancelacionTipificacionDescripcion_Sel',fld:'vTFCANCELACIONTIPIFICACIONDESCRIPCION_SEL',pic:'',type:'char'},{av:'AV175TFSolicitudesNota',fld:'vTFSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV176TFSolicitudesNota_Sel',fld:'vTFSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV177TFSolicitudesComentario',fld:'vTFSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV178TFSolicitudesComentario_Sel',fld:'vTFSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV179TFSolicitudesOtros2',fld:'vTFSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV180TFSolicitudesOtros2_Sel',fld:'vTFSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV181TFSolicitudesOtros3',fld:'vTFSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV182TFSolicitudesOtros3_Sel',fld:'vTFSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV183TFSolicitudesFechaAlta',fld:'vTFSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV184TFSolicitudesFechaAlta_To',fld:'vTFSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV188TFSolicitudesFechaActualizacion',fld:'vTFSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV189TFSolicitudesFechaActualizacion_To',fld:'vTFSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV193IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV124IsAuthorized_DepartamentoDepartamento',fld:'vISAUTHORIZED_DEPARTAMENTODEPARTAMENTO',pic:'',hsh:true,type:'boolean'},{av:'AV194IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'A26SecUserName',fld:'SECUSERNAME',pic:'',type:'svchar'}]");
         setEventMetadata("SOLICITUDESFECHAINSTALACION_RANGEPICKER.DATERANGECHANGED",",oparms:[{av:'AV204SolicitudesFechaInstalacion',fld:'vSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV205SolicitudesFechaInstalacion_To',fld:'vSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV50ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavProfesionalid_Visible',ctrl:'vPROFESIONALID',prop:'Visible'},{av:'edtavProfesional_Visible',ctrl:'vPROFESIONAL',prop:'Visible'},{av:'edtSolicitudesID_Visible',ctrl:'SOLICITUDESID',prop:'Visible'},{av:'cmbSolicitudesSubTipo'},{av:'edtSolicitudesFechaInstalacion_Visible',ctrl:'SOLICITUDESFECHAINSTALACION',prop:'Visible'},{av:'edtavHorainstalacion_Visible',ctrl:'vHORAINSTALACION',prop:'Visible'},{av:'edtavDia_Visible',ctrl:'vDIA',prop:'Visible'},{av:'edtEstadosSolNombre_Visible',ctrl:'ESTADOSSOLNOMBRE',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtSolicitudesNombre_Visible',ctrl:'SOLICITUDESNOMBRE',prop:'Visible'},{av:'edtSolicitudesTelefono_Visible',ctrl:'SOLICITUDESTELEFONO',prop:'Visible'},{av:'edtSolicitudesMail_Visible',ctrl:'SOLICITUDESMAIL',prop:'Visible'},{av:'edtPaisID_Visible',ctrl:'PAISID',prop:'Visible'},{av:'edtDepartamentoDepartamento_Visible',ctrl:'DEPARTAMENTODEPARTAMENTO',prop:'Visible'},{av:'edtDepartamentoMunicipioNombre_Visible',ctrl:'DEPARTAMENTOMUNICIPIONOMBRE',prop:'Visible'},{av:'edtSolicitudesDireccion_Visible',ctrl:'SOLICITUDESDIRECCION',prop:'Visible'},{av:'cmbSolicitudServicioOrigenPago'},{av:'edtMetodoPagosNombre_Visible',ctrl:'METODOPAGOSNOMBRE',prop:'Visible'},{av:'cmbSolicitudesPagado'},{av:'edtSolicitudServicioPFinal_Visible',ctrl:'SOLICITUDSERVICIOPFINAL',prop:'Visible'},{av:'edtSolicitudesCotizacion_Visible',ctrl:'SOLICITUDESCOTIZACION',prop:'Visible'},{av:'edtSolicitudesDescuento_Visible',ctrl:'SOLICITUDESDESCUENTO',prop:'Visible'},{av:'edtSolicitudServicioComALM_Visible',ctrl:'SOLICITUDSERVICIOCOMALM',prop:'Visible'},{av:'edtSolicitudServicioComALMP_Visible',ctrl:'SOLICITUDSERVICIOCOMALMP',prop:'Visible'},{av:'edtSolicitudServicioComPro_Visible',ctrl:'SOLICITUDSERVICIOCOMPRO',prop:'Visible'},{av:'edtSolicitudServicioComProP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROP',prop:'Visible'},{av:'edtSolicitudServicioComProv_Visible',ctrl:'SOLICITUDSERVICIOCOMPROV',prop:'Visible'},{av:'edtSolicitudServicioComProvP_Visible',ctrl:'SOLICITUDSERVICIOCOMPROVP',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlm_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALM',prop:'Visible'},{av:'edtSolicitudesCostoXZComAlmP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMALMP',prop:'Visible'},{av:'edtSolicitudesCostoXZComProf_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROF',prop:'Visible'},{av:'edtSolicitudesCostoXZComProfP_Visible',ctrl:'SOLICITUDESCOSTOXZCOMPROFP',prop:'Visible'},{av:'edtSolicitudesCostoXZona_Visible',ctrl:'SOLICITUDESCOSTOXZONA',prop:'Visible'},{av:'edtCancelacionTipificacionDescrip_Visible',ctrl:'CANCELACIONTIPIFICACIONDESCRIP',prop:'Visible'},{av:'edtSolicitudesNota_Visible',ctrl:'SOLICITUDESNOTA',prop:'Visible'},{av:'edtSolicitudesComentario_Visible',ctrl:'SOLICITUDESCOMENTARIO',prop:'Visible'},{av:'edtSolicitudesOtros2_Visible',ctrl:'SOLICITUDESOTROS2',prop:'Visible'},{av:'edtSolicitudesOtros3_Visible',ctrl:'SOLICITUDESOTROS3',prop:'Visible'},{av:'edtavUseralta_Visible',ctrl:'vUSERALTA',prop:'Visible'},{av:'edtavUserupd_Visible',ctrl:'vUSERUPD',prop:'Visible'},{av:'edtSolicitudesFechaAlta_Visible',ctrl:'SOLICITUDESFECHAALTA',prop:'Visible'},{av:'edtSolicitudesFechaActualizacion_Visible',ctrl:'SOLICITUDESFECHAACTUALIZACION',prop:'Visible'},{av:'AV114GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV115GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV116GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("VALIDV_FECHAINI","{handler:'Validv_Fechaini',iparms:[]");
         setEventMetadata("VALIDV_FECHAINI",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAFIN","{handler:'Validv_Fechafin',iparms:[]");
         setEventMetadata("VALIDV_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAREF","{handler:'Validv_Fecharef',iparms:[]");
         setEventMetadata("VALIDV_FECHAREF",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL","{handler:'Valid_Solicitudserviciopfinal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION","{handler:'Valid_Solicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESDESCUENTO","{handler:'Valid_Solicitudesdescuento',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESDESCUENTO",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM","{handler:'Valid_Solicitudserviciocomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP","{handler:'Valid_Solicitudserviciocomalmp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMALMP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPRO","{handler:'Valid_Solicitudserviciocompro',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPRO",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV","{handler:'Valid_Solicitudserviciocomprov',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROV",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP","{handler:'Valid_Solicitudserviciocomprovp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOCOMPROVP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM","{handler:'Valid_Solicitudescostoxzcomalm',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALM",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALMP","{handler:'Valid_Solicitudescostoxzcomalmp',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZCOMALMP",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZONA","{handler:'Valid_Solicitudescostoxzona',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESCOSTOXZONA",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESUSRACTUALIZACION","{handler:'Valid_Solicitudesusractualizacion',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESUSRACTUALIZACION",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESUSRALTA","{handler:'Valid_Solicitudesusralta',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESUSRALTA",",oparms:[]}");
         setEventMetadata("VALID_CANCELACIONTIPIFICACIONID","{handler:'Valid_Cancelaciontipificacionid',iparms:[]");
         setEventMetadata("VALID_CANCELACIONTIPIFICACIONID",",oparms:[]}");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV204SolicitudesFechaInstalacion = DateTime.MinValue;
         AV50ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV212Pgmname = "";
         AV205SolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV133TFSolicitudesSubTipo_Sels = new GxSimpleCollection<string>();
         AV139TFEstadosSolNombre = "";
         AV140TFEstadosSolNombre_Sel = "";
         AV64TFProveedorNombre = "";
         AV65TFProveedorNombre_Sel = "";
         AV58TFSolicitudesNombre = "";
         AV59TFSolicitudesNombre_Sel = "";
         AV90TFSolicitudesTelefono = "";
         AV91TFSolicitudesTelefono_Sel = "";
         AV92TFSolicitudesMail = "";
         AV93TFSolicitudesMail_Sel = "";
         AV94TFPaisID = "";
         AV95TFPaisID_Sel = "";
         AV98TFDepartamentoDepartamento = "";
         AV99TFDepartamentoDepartamento_Sel = "";
         AV102TFDepartamentoMunicipioNombre = "";
         AV103TFDepartamentoMunicipioNombre_Sel = "";
         AV106TFSolicitudesDireccion = "";
         AV107TFSolicitudesDireccion_Sel = "";
         AV142TFSolicitudServicioOrigenPago_Sels = new GxSimpleCollection<string>();
         AV143TFMetodoPagosNombre = "";
         AV144TFMetodoPagosNombre_Sel = "";
         AV146TFSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         AV210TFCancelacionTipificacionDescripcion = "";
         AV211TFCancelacionTipificacionDescripcion_Sel = "";
         AV175TFSolicitudesNota = "";
         AV176TFSolicitudesNota_Sel = "";
         AV177TFSolicitudesComentario = "";
         AV178TFSolicitudesComentario_Sel = "";
         AV179TFSolicitudesOtros2 = "";
         AV180TFSolicitudesOtros2_Sel = "";
         AV181TFSolicitudesOtros3 = "";
         AV182TFSolicitudesOtros3_Sel = "";
         AV183TFSolicitudesFechaAlta = DateTime.MinValue;
         AV184TFSolicitudesFechaAlta_To = DateTime.MinValue;
         AV188TFSolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV189TFSolicitudesFechaActualizacion_To = (DateTime)(DateTime.MinValue);
         A26SecUserName = "";
         H00JW2_A127SolicitudesID = new long[1] ;
         H00JW2_A134SolicitudesItemsID = new short[1] ;
         H00JW2_A180SolicitudItemsComision = new decimal[1] ;
         H00JW2_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00JW2_A178SolicitudItemsSR = new string[] {""} ;
         H00JW2_A177SolicitudesItemsCantidad = new short[1] ;
         H00JW2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00JW2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV116GridAppliedFilters = "";
         AV125AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV112DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV186DDO_SolicitudesFechaAltaAuxDateTo = DateTime.MinValue;
         AV191DDO_SolicitudesFechaActualizacionAuxDateTo = DateTime.MinValue;
         A130EstadosSolTipo = "";
         AV132TFSolicitudesSubTipo_SelsJson = "";
         AV141TFSolicitudServicioOrigenPago_SelsJson = "";
         AV145TFSolicitudesPagado_SelsJson = "";
         AV185DDO_SolicitudesFechaAltaAuxDate = DateTime.MinValue;
         AV190DDO_SolicitudesFechaActualizacionAuxDate = DateTime.MinValue;
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucSolicitudesfechainstalacion_rangepicker = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         AV198FechaIni = DateTime.MinValue;
         AV199FechaFin = DateTime.MinValue;
         AV207FechaRef = DateTime.MinValue;
         ucGrid_empowerer = new GXUserControl();
         AV187DDO_SolicitudesFechaAltaAuxDateText = "";
         ucTfsolicitudesfechaalta_rangepicker = new GXUserControl();
         AV192DDO_SolicitudesFechaActualizacionAuxDateText = "";
         ucTfsolicitudesfechaactualizacion_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV200ProfesionalId = "";
         AV201Profesional = "";
         A600SolicitudesSubTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         AV128HoraInstalacion = "";
         AV129Dia = "";
         A132EstadosSolNombre = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A116PaisID = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         A173SolicitudesDireccion = "";
         A438SolicitudServicioOrigenPago = "";
         A129MetodoPagosNombre = "";
         A441SolicitudesPagado = "";
         A997CancelacionTipificacionDescrip = "";
         A261SolicitudesNota = "";
         A205SolicitudesComentario = "";
         A183SolicitudesHoraInstalacion = "";
         A201SolicitudesOtros1 = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         AV130UserAlta = "";
         AV131UserUPD = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV202Existe = "";
         AV213Solicitudesreportewwds_1_solicitudesfechainstalacion = DateTime.MinValue;
         AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to = DateTime.MinValue;
         AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels = new GxSimpleCollection<string>();
         AV218Solicitudesreportewwds_6_tfestadossolnombre = "";
         AV219Solicitudesreportewwds_7_tfestadossolnombre_sel = "";
         AV220Solicitudesreportewwds_8_tfproveedornombre = "";
         AV221Solicitudesreportewwds_9_tfproveedornombre_sel = "";
         AV222Solicitudesreportewwds_10_tfsolicitudesnombre = "";
         AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel = "";
         AV224Solicitudesreportewwds_12_tfsolicitudestelefono = "";
         AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel = "";
         AV226Solicitudesreportewwds_14_tfsolicitudesmail = "";
         AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel = "";
         AV228Solicitudesreportewwds_16_tfpaisid = "";
         AV229Solicitudesreportewwds_17_tfpaisid_sel = "";
         AV230Solicitudesreportewwds_18_tfdepartamentodepartamento = "";
         AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel = "";
         AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = "";
         AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel = "";
         AV234Solicitudesreportewwds_22_tfsolicitudesdireccion = "";
         AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel = "";
         AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels = new GxSimpleCollection<string>();
         AV237Solicitudesreportewwds_25_tfmetodopagosnombre = "";
         AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel = "";
         AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels = new GxSimpleCollection<string>();
         AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = "";
         AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel = "";
         AV270Solicitudesreportewwds_58_tfsolicitudesnota = "";
         AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel = "";
         AV272Solicitudesreportewwds_60_tfsolicitudescomentario = "";
         AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel = "";
         AV274Solicitudesreportewwds_62_tfsolicitudesotros2 = "";
         AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel = "";
         AV276Solicitudesreportewwds_64_tfsolicitudesotros3 = "";
         AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel = "";
         AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta = DateTime.MinValue;
         AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to = DateTime.MinValue;
         AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);
         AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to = (DateTime)(DateTime.MinValue);
         lV218Solicitudesreportewwds_6_tfestadossolnombre = "";
         lV220Solicitudesreportewwds_8_tfproveedornombre = "";
         lV222Solicitudesreportewwds_10_tfsolicitudesnombre = "";
         lV224Solicitudesreportewwds_12_tfsolicitudestelefono = "";
         lV226Solicitudesreportewwds_14_tfsolicitudesmail = "";
         lV228Solicitudesreportewwds_16_tfpaisid = "";
         lV230Solicitudesreportewwds_18_tfdepartamentodepartamento = "";
         lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre = "";
         lV234Solicitudesreportewwds_22_tfsolicitudesdireccion = "";
         lV237Solicitudesreportewwds_25_tfmetodopagosnombre = "";
         lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion = "";
         lV270Solicitudesreportewwds_58_tfsolicitudesnota = "";
         lV272Solicitudesreportewwds_60_tfsolicitudescomentario = "";
         lV274Solicitudesreportewwds_62_tfsolicitudesotros2 = "";
         lV276Solicitudesreportewwds_64_tfsolicitudesotros3 = "";
         H00JW3_A598SolicitudesUsrActualizacion = new long[1] ;
         H00JW3_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         H00JW3_A597SolicitudesUsrAlta = new long[1] ;
         H00JW3_n597SolicitudesUsrAlta = new bool[] {false} ;
         H00JW3_A130EstadosSolTipo = new string[] {""} ;
         H00JW3_A128MetodoPagosID = new long[1] ;
         H00JW3_A996CancelacionTipificacionId = new long[1] ;
         H00JW3_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00JW3_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         H00JW3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00JW3_n182SolicitudesFechaAlta = new bool[] {false} ;
         H00JW3_A203SolicitudesOtros3 = new string[] {""} ;
         H00JW3_A202SolicitudesOtros2 = new string[] {""} ;
         H00JW3_A201SolicitudesOtros1 = new string[] {""} ;
         H00JW3_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H00JW3_A205SolicitudesComentario = new string[] {""} ;
         H00JW3_A261SolicitudesNota = new string[] {""} ;
         H00JW3_A997CancelacionTipificacionDescrip = new string[] {""} ;
         H00JW3_A441SolicitudesPagado = new string[] {""} ;
         H00JW3_n441SolicitudesPagado = new bool[] {false} ;
         H00JW3_A129MetodoPagosNombre = new string[] {""} ;
         H00JW3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00JW3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00JW3_A194SolicitudesAutoEnumerar = new short[1] ;
         H00JW3_A173SolicitudesDireccion = new string[] {""} ;
         H00JW3_A110ZonasID = new long[1] ;
         H00JW3_n110ZonasID = new bool[] {false} ;
         H00JW3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H00JW3_A114DepartamentoMunicipioId = new long[1] ;
         H00JW3_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00JW3_A113DepartamentoDepartamento = new string[] {""} ;
         H00JW3_A112DepartamentoId = new long[1] ;
         H00JW3_n112DepartamentoId = new bool[] {false} ;
         H00JW3_A116PaisID = new string[] {""} ;
         H00JW3_A206SolicitudesMail = new string[] {""} ;
         H00JW3_n206SolicitudesMail = new bool[] {false} ;
         H00JW3_A172SolicitudesTelefono = new string[] {""} ;
         H00JW3_A171SolicitudesNombre = new string[] {""} ;
         H00JW3_A282ProveedorNombre = new string[] {""} ;
         H00JW3_A133ProveedorID = new long[1] ;
         H00JW3_A132EstadosSolNombre = new string[] {""} ;
         H00JW3_A131EstadosSolId = new int[1] ;
         H00JW3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00JW3_A600SolicitudesSubTipo = new string[] {""} ;
         H00JW3_n600SolicitudesSubTipo = new bool[] {false} ;
         H00JW3_A127SolicitudesID = new long[1] ;
         H00JW3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00JW3_A212SolicitudesCotizacion = new decimal[1] ;
         H00JW3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00JW3_A897SolicitudesDescuento = new decimal[1] ;
         H00JW3_n897SolicitudesDescuento = new bool[] {false} ;
         H00JW3_A527SolicitudServicioComProv = new decimal[1] ;
         H00JW3_n527SolicitudServicioComProv = new bool[] {false} ;
         H00JW3_A530SolicitudServicioComALM = new decimal[1] ;
         H00JW3_n530SolicitudServicioComALM = new bool[] {false} ;
         H00JW3_A532SolicitudServicioComALMP = new decimal[1] ;
         H00JW3_n532SolicitudServicioComALMP = new bool[] {false} ;
         H00JW3_A528SolicitudServicioComProvP = new decimal[1] ;
         H00JW3_n528SolicitudServicioComProvP = new bool[] {false} ;
         H00JW3_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         H00JW3_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         H00JW3_A864SolicitudesCostoXZona = new decimal[1] ;
         H00JW3_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         H00JW3_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         H00JW4_A598SolicitudesUsrActualizacion = new long[1] ;
         H00JW4_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         H00JW4_A597SolicitudesUsrAlta = new long[1] ;
         H00JW4_n597SolicitudesUsrAlta = new bool[] {false} ;
         H00JW4_A130EstadosSolTipo = new string[] {""} ;
         H00JW4_A128MetodoPagosID = new long[1] ;
         H00JW4_A996CancelacionTipificacionId = new long[1] ;
         H00JW4_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00JW4_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         H00JW4_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00JW4_n182SolicitudesFechaAlta = new bool[] {false} ;
         H00JW4_A203SolicitudesOtros3 = new string[] {""} ;
         H00JW4_A202SolicitudesOtros2 = new string[] {""} ;
         H00JW4_A201SolicitudesOtros1 = new string[] {""} ;
         H00JW4_A183SolicitudesHoraInstalacion = new string[] {""} ;
         H00JW4_A205SolicitudesComentario = new string[] {""} ;
         H00JW4_A261SolicitudesNota = new string[] {""} ;
         H00JW4_A997CancelacionTipificacionDescrip = new string[] {""} ;
         H00JW4_A441SolicitudesPagado = new string[] {""} ;
         H00JW4_n441SolicitudesPagado = new bool[] {false} ;
         H00JW4_A129MetodoPagosNombre = new string[] {""} ;
         H00JW4_A438SolicitudServicioOrigenPago = new string[] {""} ;
         H00JW4_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         H00JW4_A194SolicitudesAutoEnumerar = new short[1] ;
         H00JW4_A173SolicitudesDireccion = new string[] {""} ;
         H00JW4_A110ZonasID = new long[1] ;
         H00JW4_n110ZonasID = new bool[] {false} ;
         H00JW4_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H00JW4_A114DepartamentoMunicipioId = new long[1] ;
         H00JW4_n114DepartamentoMunicipioId = new bool[] {false} ;
         H00JW4_A113DepartamentoDepartamento = new string[] {""} ;
         H00JW4_A112DepartamentoId = new long[1] ;
         H00JW4_n112DepartamentoId = new bool[] {false} ;
         H00JW4_A116PaisID = new string[] {""} ;
         H00JW4_A206SolicitudesMail = new string[] {""} ;
         H00JW4_n206SolicitudesMail = new bool[] {false} ;
         H00JW4_A172SolicitudesTelefono = new string[] {""} ;
         H00JW4_A171SolicitudesNombre = new string[] {""} ;
         H00JW4_A282ProveedorNombre = new string[] {""} ;
         H00JW4_A133ProveedorID = new long[1] ;
         H00JW4_A132EstadosSolNombre = new string[] {""} ;
         H00JW4_A131EstadosSolId = new int[1] ;
         H00JW4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         H00JW4_A600SolicitudesSubTipo = new string[] {""} ;
         H00JW4_n600SolicitudesSubTipo = new bool[] {false} ;
         H00JW4_A127SolicitudesID = new long[1] ;
         H00JW4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H00JW4_A212SolicitudesCotizacion = new decimal[1] ;
         H00JW4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H00JW4_A897SolicitudesDescuento = new decimal[1] ;
         H00JW4_n897SolicitudesDescuento = new bool[] {false} ;
         H00JW4_A527SolicitudServicioComProv = new decimal[1] ;
         H00JW4_n527SolicitudServicioComProv = new bool[] {false} ;
         H00JW4_A530SolicitudServicioComALM = new decimal[1] ;
         H00JW4_n530SolicitudServicioComALM = new bool[] {false} ;
         H00JW4_A532SolicitudServicioComALMP = new decimal[1] ;
         H00JW4_n532SolicitudServicioComALMP = new bool[] {false} ;
         H00JW4_A528SolicitudServicioComProvP = new decimal[1] ;
         H00JW4_n528SolicitudServicioComProvP = new bool[] {false} ;
         H00JW4_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         H00JW4_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         H00JW4_A864SolicitudesCostoXZona = new decimal[1] ;
         H00JW4_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         H00JW4_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         AV206SolicitudesFechaInstalacion_RangeText = "";
         AV208FechaFinText = "";
         AV209FechaIniText = "";
         AV134TFSolicitudesFechaInstalacion = DateTime.MinValue;
         AV135TFSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV126AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV52Session = context.GetSession();
         AV48ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         H00JW5_A18SecUserId = new long[1] ;
         H00JW5_A26SecUserName = new string[] {""} ;
         H00JW6_A18SecUserId = new long[1] ;
         H00JW6_A26SecUserName = new string[] {""} ;
         GridRow = new GXWebRow();
         AV49UserCustomValue = "";
         AV51ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char4 = "";
         GXt_char5 = "";
         GXt_char20 = "";
         GXt_char19 = "";
         GXt_char18 = "";
         GXt_char17 = "";
         GXt_char16 = "";
         GXt_char15 = "";
         GXt_char14 = "";
         GXt_char13 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV46ExcelFilename = "";
         AV47ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesreporteww__default(),
            new Object[][] {
                new Object[] {
               H00JW2_A127SolicitudesID, H00JW2_A134SolicitudesItemsID, H00JW2_A180SolicitudItemsComision, H00JW2_A179SolicitudItemsComisionTipo, H00JW2_A178SolicitudItemsSR, H00JW2_A177SolicitudesItemsCantidad, H00JW2_A176SolicitudesItemsPrecioFinal, H00JW2_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H00JW3_A598SolicitudesUsrActualizacion, H00JW3_n598SolicitudesUsrActualizacion, H00JW3_A597SolicitudesUsrAlta, H00JW3_n597SolicitudesUsrAlta, H00JW3_A130EstadosSolTipo, H00JW3_A128MetodoPagosID, H00JW3_A996CancelacionTipificacionId, H00JW3_A204SolicitudesFechaActualizacion, H00JW3_n204SolicitudesFechaActualizacion, H00JW3_A182SolicitudesFechaAlta,
               H00JW3_n182SolicitudesFechaAlta, H00JW3_A203SolicitudesOtros3, H00JW3_A202SolicitudesOtros2, H00JW3_A201SolicitudesOtros1, H00JW3_A183SolicitudesHoraInstalacion, H00JW3_A205SolicitudesComentario, H00JW3_A261SolicitudesNota, H00JW3_A997CancelacionTipificacionDescrip, H00JW3_A441SolicitudesPagado, H00JW3_n441SolicitudesPagado,
               H00JW3_A129MetodoPagosNombre, H00JW3_A438SolicitudServicioOrigenPago, H00JW3_n438SolicitudServicioOrigenPago, H00JW3_A194SolicitudesAutoEnumerar, H00JW3_A173SolicitudesDireccion, H00JW3_A110ZonasID, H00JW3_n110ZonasID, H00JW3_A115DepartamentoMunicipioNombre, H00JW3_A114DepartamentoMunicipioId, H00JW3_n114DepartamentoMunicipioId,
               H00JW3_A113DepartamentoDepartamento, H00JW3_A112DepartamentoId, H00JW3_n112DepartamentoId, H00JW3_A116PaisID, H00JW3_A206SolicitudesMail, H00JW3_n206SolicitudesMail, H00JW3_A172SolicitudesTelefono, H00JW3_A171SolicitudesNombre, H00JW3_A282ProveedorNombre, H00JW3_A133ProveedorID,
               H00JW3_A132EstadosSolNombre, H00JW3_A131EstadosSolId, H00JW3_A184SolicitudesFechaInstalacion, H00JW3_A600SolicitudesSubTipo, H00JW3_n600SolicitudesSubTipo, H00JW3_A127SolicitudesID, H00JW3_A796SolicitudesComisionMetodoPago, H00JW3_A212SolicitudesCotizacion, H00JW3_A1016SolicitudesDescuentoCupon, H00JW3_A897SolicitudesDescuento,
               H00JW3_n897SolicitudesDescuento, H00JW3_A527SolicitudServicioComProv, H00JW3_n527SolicitudServicioComProv, H00JW3_A530SolicitudServicioComALM, H00JW3_n530SolicitudServicioComALM, H00JW3_A532SolicitudServicioComALMP, H00JW3_n532SolicitudServicioComALMP, H00JW3_A528SolicitudServicioComProvP, H00JW3_n528SolicitudServicioComProvP, H00JW3_A865SolicitudesCostoXZComAlm,
               H00JW3_n865SolicitudesCostoXZComAlm, H00JW3_A864SolicitudesCostoXZona, H00JW3_A866SolicitudesCostoXZComAlmP, H00JW3_n866SolicitudesCostoXZComAlmP
               }
               , new Object[] {
               H00JW4_A598SolicitudesUsrActualizacion, H00JW4_n598SolicitudesUsrActualizacion, H00JW4_A597SolicitudesUsrAlta, H00JW4_n597SolicitudesUsrAlta, H00JW4_A130EstadosSolTipo, H00JW4_A128MetodoPagosID, H00JW4_A996CancelacionTipificacionId, H00JW4_A204SolicitudesFechaActualizacion, H00JW4_n204SolicitudesFechaActualizacion, H00JW4_A182SolicitudesFechaAlta,
               H00JW4_n182SolicitudesFechaAlta, H00JW4_A203SolicitudesOtros3, H00JW4_A202SolicitudesOtros2, H00JW4_A201SolicitudesOtros1, H00JW4_A183SolicitudesHoraInstalacion, H00JW4_A205SolicitudesComentario, H00JW4_A261SolicitudesNota, H00JW4_A997CancelacionTipificacionDescrip, H00JW4_A441SolicitudesPagado, H00JW4_n441SolicitudesPagado,
               H00JW4_A129MetodoPagosNombre, H00JW4_A438SolicitudServicioOrigenPago, H00JW4_n438SolicitudServicioOrigenPago, H00JW4_A194SolicitudesAutoEnumerar, H00JW4_A173SolicitudesDireccion, H00JW4_A110ZonasID, H00JW4_n110ZonasID, H00JW4_A115DepartamentoMunicipioNombre, H00JW4_A114DepartamentoMunicipioId, H00JW4_n114DepartamentoMunicipioId,
               H00JW4_A113DepartamentoDepartamento, H00JW4_A112DepartamentoId, H00JW4_n112DepartamentoId, H00JW4_A116PaisID, H00JW4_A206SolicitudesMail, H00JW4_n206SolicitudesMail, H00JW4_A172SolicitudesTelefono, H00JW4_A171SolicitudesNombre, H00JW4_A282ProveedorNombre, H00JW4_A133ProveedorID,
               H00JW4_A132EstadosSolNombre, H00JW4_A131EstadosSolId, H00JW4_A184SolicitudesFechaInstalacion, H00JW4_A600SolicitudesSubTipo, H00JW4_n600SolicitudesSubTipo, H00JW4_A127SolicitudesID, H00JW4_A796SolicitudesComisionMetodoPago, H00JW4_A212SolicitudesCotizacion, H00JW4_A1016SolicitudesDescuentoCupon, H00JW4_A897SolicitudesDescuento,
               H00JW4_n897SolicitudesDescuento, H00JW4_A527SolicitudServicioComProv, H00JW4_n527SolicitudServicioComProv, H00JW4_A530SolicitudServicioComALM, H00JW4_n530SolicitudServicioComALM, H00JW4_A532SolicitudServicioComALMP, H00JW4_n532SolicitudServicioComALMP, H00JW4_A528SolicitudServicioComProvP, H00JW4_n528SolicitudServicioComProvP, H00JW4_A865SolicitudesCostoXZComAlm,
               H00JW4_n865SolicitudesCostoXZComAlm, H00JW4_A864SolicitudesCostoXZona, H00JW4_A866SolicitudesCostoXZComAlmP, H00JW4_n866SolicitudesCostoXZComAlmP
               }
               , new Object[] {
               H00JW5_A18SecUserId, H00JW5_A26SecUserName
               }
               , new Object[] {
               H00JW6_A18SecUserId, H00JW6_A26SecUserName
               }
            }
         );
         AV212Pgmname = "SolicitudesReporteWW";
         /* GeneXus formulas. */
         AV212Pgmname = "SolicitudesReporteWW";
         edtavProfesionalid_Enabled = 0;
         edtavProfesional_Enabled = 0;
         edtavHorainstalacion_Enabled = 0;
         edtavDia_Enabled = 0;
         edtavUseralta_Enabled = 0;
         edtavUserupd_Enabled = 0;
         edtavExiste_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A194SolicitudesAutoEnumerar ;
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
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFechaini_Visible ;
      private int edtavFechafin_Visible ;
      private int edtavFecharef_Visible ;
      private int A131EstadosSolId ;
      private int subGrid_Islastpage ;
      private int edtavProfesionalid_Enabled ;
      private int edtavProfesional_Enabled ;
      private int edtavHorainstalacion_Enabled ;
      private int edtavDia_Enabled ;
      private int edtavUseralta_Enabled ;
      private int edtavUserupd_Enabled ;
      private int edtavExiste_Enabled ;
      private int AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count ;
      private int AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count ;
      private int AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesFechaInstalacion_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtRelacionesId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesMail_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtDepartamentoMunicipioNombre_Enabled ;
      private int edtZonasID_Enabled ;
      private int edtSolicitudesDireccion_Enabled ;
      private int edtSolicitudesAutoEnumerar_Enabled ;
      private int edtMetodoPagosNombre_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtSolicitudesCotizacion_Enabled ;
      private int edtSolicitudesDescuento_Enabled ;
      private int edtSolicitudServicioComALM_Enabled ;
      private int edtSolicitudServicioComALMP_Enabled ;
      private int edtSolicitudServicioComPro_Enabled ;
      private int edtSolicitudServicioComProP_Enabled ;
      private int edtSolicitudServicioComProv_Enabled ;
      private int edtSolicitudServicioComProvP_Enabled ;
      private int edtSolicitudesCostoXZComAlm_Enabled ;
      private int edtSolicitudesCostoXZComAlmP_Enabled ;
      private int edtSolicitudesCostoXZComProf_Enabled ;
      private int edtSolicitudesCostoXZComProfP_Enabled ;
      private int edtSolicitudesCostoXZona_Enabled ;
      private int edtCancelacionTipificacionDescrip_Enabled ;
      private int edtSolicitudesNota_Enabled ;
      private int edtSolicitudesComentario_Enabled ;
      private int edtSolicitudesHoraInstalacion_Enabled ;
      private int edtSolicitudesOtros2_Enabled ;
      private int edtSolicitudesOtros3_Enabled ;
      private int edtSolicitudesUsrActualizacion_Enabled ;
      private int edtSolicitudesUsrAlta_Enabled ;
      private int edtSolicitudesFechaAlta_Enabled ;
      private int edtSolicitudesFechaActualizacion_Enabled ;
      private int edtCancelacionTipificacionId_Enabled ;
      private int edtavProfesionalid_Visible ;
      private int edtavProfesional_Visible ;
      private int edtSolicitudesID_Visible ;
      private int edtSolicitudesFechaInstalacion_Visible ;
      private int edtavHorainstalacion_Visible ;
      private int edtavDia_Visible ;
      private int edtEstadosSolNombre_Visible ;
      private int edtProveedorNombre_Visible ;
      private int edtSolicitudesNombre_Visible ;
      private int edtSolicitudesTelefono_Visible ;
      private int edtSolicitudesMail_Visible ;
      private int edtPaisID_Visible ;
      private int edtDepartamentoDepartamento_Visible ;
      private int edtDepartamentoMunicipioNombre_Visible ;
      private int edtSolicitudesDireccion_Visible ;
      private int edtMetodoPagosNombre_Visible ;
      private int edtSolicitudServicioPFinal_Visible ;
      private int edtSolicitudesCotizacion_Visible ;
      private int edtSolicitudesDescuento_Visible ;
      private int edtSolicitudServicioComALM_Visible ;
      private int edtSolicitudServicioComALMP_Visible ;
      private int edtSolicitudServicioComPro_Visible ;
      private int edtSolicitudServicioComProP_Visible ;
      private int edtSolicitudServicioComProv_Visible ;
      private int edtSolicitudServicioComProvP_Visible ;
      private int edtSolicitudesCostoXZComAlm_Visible ;
      private int edtSolicitudesCostoXZComAlmP_Visible ;
      private int edtSolicitudesCostoXZComProf_Visible ;
      private int edtSolicitudesCostoXZComProfP_Visible ;
      private int edtSolicitudesCostoXZona_Visible ;
      private int edtCancelacionTipificacionDescrip_Visible ;
      private int edtSolicitudesNota_Visible ;
      private int edtSolicitudesComentario_Visible ;
      private int edtSolicitudesOtros2_Visible ;
      private int edtSolicitudesOtros3_Visible ;
      private int edtavUseralta_Visible ;
      private int edtavUserupd_Visible ;
      private int edtSolicitudesFechaAlta_Visible ;
      private int edtSolicitudesFechaActualizacion_Visible ;
      private int AV113PageToGo ;
      private int AV284GXV1 ;
      private int edtavSolicitudesfechainstalacion_rangetext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV56TFSolicitudesID ;
      private long AV57TFSolicitudesID_To ;
      private long A18SecUserId ;
      private long A127SolicitudesID ;
      private long AV114GridCurrentPage ;
      private long AV115GridPageCount ;
      private long A128MetodoPagosID ;
      private long A140RelacionesId ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A598SolicitudesUsrActualizacion ;
      private long A597SolicitudesUsrAlta ;
      private long A996CancelacionTipificacionId ;
      private long GRID_nCurrentRecord ;
      private long AV215Solicitudesreportewwds_3_tfsolicitudesid ;
      private long AV216Solicitudesreportewwds_4_tfsolicitudesid_to ;
      private long GRID_nRecordCount ;
      private decimal AV147TFSolicitudServicioPFinal ;
      private decimal AV148TFSolicitudServicioPFinal_To ;
      private decimal AV149TFSolicitudesCotizacion ;
      private decimal AV150TFSolicitudesCotizacion_To ;
      private decimal AV151TFSolicitudesDescuento ;
      private decimal AV152TFSolicitudesDescuento_To ;
      private decimal AV153TFSolicitudServicioComALM ;
      private decimal AV154TFSolicitudServicioComALM_To ;
      private decimal AV155TFSolicitudServicioComALMP ;
      private decimal AV156TFSolicitudServicioComALMP_To ;
      private decimal AV157TFSolicitudServicioComPro ;
      private decimal AV158TFSolicitudServicioComPro_To ;
      private decimal AV159TFSolicitudServicioComProP ;
      private decimal AV160TFSolicitudServicioComProP_To ;
      private decimal AV161TFSolicitudServicioComProv ;
      private decimal AV162TFSolicitudServicioComProv_To ;
      private decimal AV163TFSolicitudServicioComProvP ;
      private decimal AV164TFSolicitudServicioComProvP_To ;
      private decimal AV165TFSolicitudesCostoXZComAlm ;
      private decimal AV166TFSolicitudesCostoXZComAlm_To ;
      private decimal AV167TFSolicitudesCostoXZComAlmP ;
      private decimal AV168TFSolicitudesCostoXZComAlmP_To ;
      private decimal AV169TFSolicitudesCostoXZComProf ;
      private decimal AV170TFSolicitudesCostoXZComProf_To ;
      private decimal AV171TFSolicitudesCostoXZComProfP ;
      private decimal AV172TFSolicitudesCostoXZComProfP_To ;
      private decimal AV173TFSolicitudesCostoXZona ;
      private decimal AV174TFSolicitudesCostoXZona_To ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A897SolicitudesDescuento ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A531SolicitudServicioComProP ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A866SolicitudesCostoXZComAlmP ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A868SolicitudesCostoXZComProfP ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ;
      private decimal AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ;
      private decimal AV242Solicitudesreportewwds_30_tfsolicitudescotizacion ;
      private decimal AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to ;
      private decimal AV244Solicitudesreportewwds_32_tfsolicitudesdescuento ;
      private decimal AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to ;
      private decimal AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm ;
      private decimal AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ;
      private decimal AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ;
      private decimal AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ;
      private decimal AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ;
      private decimal AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to ;
      private decimal AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop ;
      private decimal AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ;
      private decimal AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov ;
      private decimal AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ;
      private decimal AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ;
      private decimal AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ;
      private decimal AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ;
      private decimal AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ;
      private decimal AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ;
      private decimal AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ;
      private decimal AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ;
      private decimal AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ;
      private decimal AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ;
      private decimal AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ;
      private decimal AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona ;
      private decimal AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV212Pgmname ;
      private string AV139TFEstadosSolNombre ;
      private string AV140TFEstadosSolNombre_Sel ;
      private string AV64TFProveedorNombre ;
      private string AV65TFProveedorNombre_Sel ;
      private string AV58TFSolicitudesNombre ;
      private string AV59TFSolicitudesNombre_Sel ;
      private string AV90TFSolicitudesTelefono ;
      private string AV91TFSolicitudesTelefono_Sel ;
      private string AV94TFPaisID ;
      private string AV95TFPaisID_Sel ;
      private string AV98TFDepartamentoDepartamento ;
      private string AV99TFDepartamentoDepartamento_Sel ;
      private string AV102TFDepartamentoMunicipioNombre ;
      private string AV103TFDepartamentoMunicipioNombre_Sel ;
      private string AV143TFMetodoPagosNombre ;
      private string AV144TFMetodoPagosNombre_Sel ;
      private string AV210TFCancelacionTipificacionDescripcion ;
      private string AV211TFCancelacionTipificacionDescripcion_Sel ;
      private string AV175TFSolicitudesNota ;
      private string AV176TFSolicitudesNota_Sel ;
      private string AV179TFSolicitudesOtros2 ;
      private string AV180TFSolicitudesOtros2_Sel ;
      private string AV181TFSolicitudesOtros3 ;
      private string AV182TFSolicitudesOtros3_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A130EstadosSolTipo ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Solicitudesfechainstalacion_rangepicker_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string edtavFechaini_Internalname ;
      private string edtavFechaini_Jsonclick ;
      private string edtavFechafin_Internalname ;
      private string edtavFechafin_Jsonclick ;
      private string edtavFecharef_Internalname ;
      private string edtavFecharef_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_solicitudesfechaaltaauxdates_Internalname ;
      private string edtavDdo_solicitudesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_solicitudesfechaaltaauxdatetext_Jsonclick ;
      private string Tfsolicitudesfechaalta_rangepicker_Internalname ;
      private string divDdo_solicitudesfechaactualizacionauxdates_Internalname ;
      private string edtavDdo_solicitudesfechaactualizacionauxdatetext_Internalname ;
      private string edtavDdo_solicitudesfechaactualizacionauxdatetext_Jsonclick ;
      private string Tfsolicitudesfechaactualizacion_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV200ProfesionalId ;
      private string edtavProfesionalid_Internalname ;
      private string edtavProfesional_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string cmbSolicitudesSubTipo_Internalname ;
      private string A600SolicitudesSubTipo ;
      private string edtSolicitudesFechaInstalacion_Internalname ;
      private string edtavHorainstalacion_Internalname ;
      private string edtavDia_Internalname ;
      private string edtEstadosSolId_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Internalname ;
      private string edtRelacionesId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Internalname ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Internalname ;
      private string edtSolicitudesMail_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string A115DepartamentoMunicipioNombre ;
      private string edtDepartamentoMunicipioNombre_Internalname ;
      private string edtZonasID_Internalname ;
      private string edtSolicitudesDireccion_Internalname ;
      private string edtSolicitudesAutoEnumerar_Internalname ;
      private string cmbSolicitudServicioOrigenPago_Internalname ;
      private string A438SolicitudServicioOrigenPago ;
      private string A129MetodoPagosNombre ;
      private string edtMetodoPagosNombre_Internalname ;
      private string cmbSolicitudesPagado_Internalname ;
      private string A441SolicitudesPagado ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string edtSolicitudesCotizacion_Internalname ;
      private string edtSolicitudesDescuento_Internalname ;
      private string edtSolicitudServicioComALM_Internalname ;
      private string edtSolicitudServicioComALMP_Internalname ;
      private string edtSolicitudServicioComPro_Internalname ;
      private string edtSolicitudServicioComProP_Internalname ;
      private string edtSolicitudServicioComProv_Internalname ;
      private string edtSolicitudServicioComProvP_Internalname ;
      private string edtSolicitudesCostoXZComAlm_Internalname ;
      private string edtSolicitudesCostoXZComAlmP_Internalname ;
      private string edtSolicitudesCostoXZComProf_Internalname ;
      private string edtSolicitudesCostoXZComProfP_Internalname ;
      private string edtSolicitudesCostoXZona_Internalname ;
      private string A997CancelacionTipificacionDescrip ;
      private string edtCancelacionTipificacionDescrip_Internalname ;
      private string A261SolicitudesNota ;
      private string edtSolicitudesNota_Internalname ;
      private string edtSolicitudesComentario_Internalname ;
      private string A183SolicitudesHoraInstalacion ;
      private string edtSolicitudesHoraInstalacion_Internalname ;
      private string A201SolicitudesOtros1 ;
      private string chkSolicitudesOtros1_Internalname ;
      private string A202SolicitudesOtros2 ;
      private string edtSolicitudesOtros2_Internalname ;
      private string A203SolicitudesOtros3 ;
      private string edtSolicitudesOtros3_Internalname ;
      private string edtSolicitudesUsrActualizacion_Internalname ;
      private string edtSolicitudesUsrAlta_Internalname ;
      private string edtavUseralta_Internalname ;
      private string edtavUserupd_Internalname ;
      private string edtSolicitudesFechaAlta_Internalname ;
      private string edtSolicitudesFechaActualizacion_Internalname ;
      private string AV202Existe ;
      private string edtavExiste_Internalname ;
      private string edtCancelacionTipificacionId_Internalname ;
      private string edtavSolicitudesfechainstalacion_rangetext_Internalname ;
      private string AV218Solicitudesreportewwds_6_tfestadossolnombre ;
      private string AV219Solicitudesreportewwds_7_tfestadossolnombre_sel ;
      private string AV220Solicitudesreportewwds_8_tfproveedornombre ;
      private string AV221Solicitudesreportewwds_9_tfproveedornombre_sel ;
      private string AV222Solicitudesreportewwds_10_tfsolicitudesnombre ;
      private string AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel ;
      private string AV224Solicitudesreportewwds_12_tfsolicitudestelefono ;
      private string AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel ;
      private string AV228Solicitudesreportewwds_16_tfpaisid ;
      private string AV229Solicitudesreportewwds_17_tfpaisid_sel ;
      private string AV230Solicitudesreportewwds_18_tfdepartamentodepartamento ;
      private string AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ;
      private string AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ;
      private string AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ;
      private string AV237Solicitudesreportewwds_25_tfmetodopagosnombre ;
      private string AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel ;
      private string AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ;
      private string AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ;
      private string AV270Solicitudesreportewwds_58_tfsolicitudesnota ;
      private string AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel ;
      private string AV274Solicitudesreportewwds_62_tfsolicitudesotros2 ;
      private string AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel ;
      private string AV276Solicitudesreportewwds_64_tfsolicitudesotros3 ;
      private string AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel ;
      private string lV218Solicitudesreportewwds_6_tfestadossolnombre ;
      private string lV220Solicitudesreportewwds_8_tfproveedornombre ;
      private string lV222Solicitudesreportewwds_10_tfsolicitudesnombre ;
      private string lV224Solicitudesreportewwds_12_tfsolicitudestelefono ;
      private string lV228Solicitudesreportewwds_16_tfpaisid ;
      private string lV230Solicitudesreportewwds_18_tfdepartamentodepartamento ;
      private string lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ;
      private string lV237Solicitudesreportewwds_25_tfmetodopagosnombre ;
      private string lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ;
      private string lV270Solicitudesreportewwds_58_tfsolicitudesnota ;
      private string lV274Solicitudesreportewwds_62_tfsolicitudesotros2 ;
      private string lV276Solicitudesreportewwds_64_tfsolicitudesotros3 ;
      private string edtEstadosSolNombre_Link ;
      private string GXEncryptionTmp ;
      private string edtDepartamentoDepartamento_Link ;
      private string edtMetodoPagosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string GXt_char5 ;
      private string GXt_char20 ;
      private string GXt_char19 ;
      private string GXt_char18 ;
      private string GXt_char17 ;
      private string GXt_char16 ;
      private string GXt_char15 ;
      private string GXt_char14 ;
      private string GXt_char13 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTablerightheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavSolicitudesfechainstalacion_rangetext_Jsonclick ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavProfesionalid_Jsonclick ;
      private string edtavProfesional_Jsonclick ;
      private string edtSolicitudesID_Jsonclick ;
      private string GXCCtl ;
      private string cmbSolicitudesSubTipo_Jsonclick ;
      private string edtSolicitudesFechaInstalacion_Jsonclick ;
      private string edtavHorainstalacion_Jsonclick ;
      private string edtavDia_Jsonclick ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string edtRelacionesId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesMail_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string edtDepartamentoMunicipioNombre_Jsonclick ;
      private string edtZonasID_Jsonclick ;
      private string edtSolicitudesDireccion_Jsonclick ;
      private string edtSolicitudesAutoEnumerar_Jsonclick ;
      private string cmbSolicitudServicioOrigenPago_Jsonclick ;
      private string edtMetodoPagosNombre_Jsonclick ;
      private string cmbSolicitudesPagado_Jsonclick ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string edtSolicitudesCotizacion_Jsonclick ;
      private string edtSolicitudesDescuento_Jsonclick ;
      private string edtSolicitudServicioComALM_Jsonclick ;
      private string edtSolicitudServicioComALMP_Jsonclick ;
      private string edtSolicitudServicioComPro_Jsonclick ;
      private string edtSolicitudServicioComProP_Jsonclick ;
      private string edtSolicitudServicioComProv_Jsonclick ;
      private string edtSolicitudServicioComProvP_Jsonclick ;
      private string edtSolicitudesCostoXZComAlm_Jsonclick ;
      private string edtSolicitudesCostoXZComAlmP_Jsonclick ;
      private string edtSolicitudesCostoXZComProf_Jsonclick ;
      private string edtSolicitudesCostoXZComProfP_Jsonclick ;
      private string edtSolicitudesCostoXZona_Jsonclick ;
      private string edtCancelacionTipificacionDescrip_Jsonclick ;
      private string edtSolicitudesNota_Jsonclick ;
      private string edtSolicitudesComentario_Jsonclick ;
      private string edtSolicitudesHoraInstalacion_Jsonclick ;
      private string edtSolicitudesOtros2_Jsonclick ;
      private string edtSolicitudesOtros3_Jsonclick ;
      private string edtSolicitudesUsrActualizacion_Jsonclick ;
      private string edtSolicitudesUsrAlta_Jsonclick ;
      private string edtavUseralta_Jsonclick ;
      private string edtavUserupd_Jsonclick ;
      private string edtSolicitudesFechaAlta_Jsonclick ;
      private string edtSolicitudesFechaActualizacion_Jsonclick ;
      private string edtavExiste_Jsonclick ;
      private string edtCancelacionTipificacionId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV188TFSolicitudesFechaActualizacion ;
      private DateTime AV189TFSolicitudesFechaActualizacion_To ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ;
      private DateTime AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ;
      private DateTime AV204SolicitudesFechaInstalacion ;
      private DateTime AV205SolicitudesFechaInstalacion_To ;
      private DateTime AV183TFSolicitudesFechaAlta ;
      private DateTime AV184TFSolicitudesFechaAlta_To ;
      private DateTime AV186DDO_SolicitudesFechaAltaAuxDateTo ;
      private DateTime AV191DDO_SolicitudesFechaActualizacionAuxDateTo ;
      private DateTime AV185DDO_SolicitudesFechaAltaAuxDate ;
      private DateTime AV190DDO_SolicitudesFechaActualizacionAuxDate ;
      private DateTime AV198FechaIni ;
      private DateTime AV199FechaFin ;
      private DateTime AV207FechaRef ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV213Solicitudesreportewwds_1_solicitudesfechainstalacion ;
      private DateTime AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to ;
      private DateTime AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta ;
      private DateTime AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ;
      private DateTime AV134TFSolicitudesFechaInstalacion ;
      private DateTime AV135TFSolicitudesFechaInstalacion_To ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV193IsAuthorized_EstadosSolNombre ;
      private bool AV124IsAuthorized_DepartamentoDepartamento ;
      private bool AV194IsAuthorized_MetodoPagosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n600SolicitudesSubTipo ;
      private bool n206SolicitudesMail ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n897SolicitudesDescuento ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n527SolicitudServicioComProv ;
      private bool n528SolicitudServicioComProvP ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n866SolicitudesCostoXZComAlmP ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n597SolicitudesUsrAlta ;
      private bool n182SolicitudesFechaAlta ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV132TFSolicitudesSubTipo_SelsJson ;
      private string AV141TFSolicitudServicioOrigenPago_SelsJson ;
      private string AV145TFSolicitudesPagado_SelsJson ;
      private string A205SolicitudesComentario ;
      private string AV48ColumnsSelectorXML ;
      private string AV49UserCustomValue ;
      private string AV92TFSolicitudesMail ;
      private string AV93TFSolicitudesMail_Sel ;
      private string AV106TFSolicitudesDireccion ;
      private string AV107TFSolicitudesDireccion_Sel ;
      private string AV177TFSolicitudesComentario ;
      private string AV178TFSolicitudesComentario_Sel ;
      private string A26SecUserName ;
      private string AV116GridAppliedFilters ;
      private string AV187DDO_SolicitudesFechaAltaAuxDateText ;
      private string AV192DDO_SolicitudesFechaActualizacionAuxDateText ;
      private string AV201Profesional ;
      private string AV128HoraInstalacion ;
      private string AV129Dia ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string AV130UserAlta ;
      private string AV131UserUPD ;
      private string AV226Solicitudesreportewwds_14_tfsolicitudesmail ;
      private string AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel ;
      private string AV234Solicitudesreportewwds_22_tfsolicitudesdireccion ;
      private string AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ;
      private string AV272Solicitudesreportewwds_60_tfsolicitudescomentario ;
      private string AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel ;
      private string lV226Solicitudesreportewwds_14_tfsolicitudesmail ;
      private string lV234Solicitudesreportewwds_22_tfsolicitudesdireccion ;
      private string lV272Solicitudesreportewwds_60_tfsolicitudescomentario ;
      private string AV206SolicitudesFechaInstalacion_RangeText ;
      private string AV208FechaFinText ;
      private string AV209FechaIniText ;
      private string AV46ExcelFilename ;
      private string AV47ErrorMessage ;
      private IGxSession AV52Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucSolicitudesfechainstalacion_rangepicker ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfsolicitudesfechaalta_rangepicker ;
      private GXUserControl ucTfsolicitudesfechaactualizacion_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSolicitudesSubTipo ;
      private GXCombobox cmbSolicitudServicioOrigenPago ;
      private GXCombobox cmbSolicitudesPagado ;
      private GXCheckbox chkSolicitudesOtros1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV50ColumnsSelector ;
      private GxSimpleCollection<string> AV133TFSolicitudesSubTipo_Sels ;
      private GxSimpleCollection<string> AV142TFSolicitudServicioOrigenPago_Sels ;
      private GxSimpleCollection<string> AV146TFSolicitudesPagado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] H00JW2_A127SolicitudesID ;
      private short[] H00JW2_A134SolicitudesItemsID ;
      private decimal[] H00JW2_A180SolicitudItemsComision ;
      private string[] H00JW2_A179SolicitudItemsComisionTipo ;
      private string[] H00JW2_A178SolicitudItemsSR ;
      private short[] H00JW2_A177SolicitudesItemsCantidad ;
      private decimal[] H00JW2_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00JW2_n176SolicitudesItemsPrecioFinal ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV125AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV112DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ;
      private GxSimpleCollection<string> AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ;
      private GxSimpleCollection<string> AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels ;
      private long[] H00JW3_A598SolicitudesUsrActualizacion ;
      private bool[] H00JW3_n598SolicitudesUsrActualizacion ;
      private long[] H00JW3_A597SolicitudesUsrAlta ;
      private bool[] H00JW3_n597SolicitudesUsrAlta ;
      private string[] H00JW3_A130EstadosSolTipo ;
      private long[] H00JW3_A128MetodoPagosID ;
      private long[] H00JW3_A996CancelacionTipificacionId ;
      private DateTime[] H00JW3_A204SolicitudesFechaActualizacion ;
      private bool[] H00JW3_n204SolicitudesFechaActualizacion ;
      private DateTime[] H00JW3_A182SolicitudesFechaAlta ;
      private bool[] H00JW3_n182SolicitudesFechaAlta ;
      private string[] H00JW3_A203SolicitudesOtros3 ;
      private string[] H00JW3_A202SolicitudesOtros2 ;
      private string[] H00JW3_A201SolicitudesOtros1 ;
      private string[] H00JW3_A183SolicitudesHoraInstalacion ;
      private string[] H00JW3_A205SolicitudesComentario ;
      private string[] H00JW3_A261SolicitudesNota ;
      private string[] H00JW3_A997CancelacionTipificacionDescrip ;
      private string[] H00JW3_A441SolicitudesPagado ;
      private bool[] H00JW3_n441SolicitudesPagado ;
      private string[] H00JW3_A129MetodoPagosNombre ;
      private string[] H00JW3_A438SolicitudServicioOrigenPago ;
      private bool[] H00JW3_n438SolicitudServicioOrigenPago ;
      private short[] H00JW3_A194SolicitudesAutoEnumerar ;
      private string[] H00JW3_A173SolicitudesDireccion ;
      private long[] H00JW3_A110ZonasID ;
      private bool[] H00JW3_n110ZonasID ;
      private string[] H00JW3_A115DepartamentoMunicipioNombre ;
      private long[] H00JW3_A114DepartamentoMunicipioId ;
      private bool[] H00JW3_n114DepartamentoMunicipioId ;
      private string[] H00JW3_A113DepartamentoDepartamento ;
      private long[] H00JW3_A112DepartamentoId ;
      private bool[] H00JW3_n112DepartamentoId ;
      private string[] H00JW3_A116PaisID ;
      private string[] H00JW3_A206SolicitudesMail ;
      private bool[] H00JW3_n206SolicitudesMail ;
      private string[] H00JW3_A172SolicitudesTelefono ;
      private string[] H00JW3_A171SolicitudesNombre ;
      private string[] H00JW3_A282ProveedorNombre ;
      private long[] H00JW3_A133ProveedorID ;
      private string[] H00JW3_A132EstadosSolNombre ;
      private int[] H00JW3_A131EstadosSolId ;
      private DateTime[] H00JW3_A184SolicitudesFechaInstalacion ;
      private string[] H00JW3_A600SolicitudesSubTipo ;
      private bool[] H00JW3_n600SolicitudesSubTipo ;
      private long[] H00JW3_A127SolicitudesID ;
      private decimal[] H00JW3_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00JW3_A212SolicitudesCotizacion ;
      private decimal[] H00JW3_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00JW3_A897SolicitudesDescuento ;
      private bool[] H00JW3_n897SolicitudesDescuento ;
      private decimal[] H00JW3_A527SolicitudServicioComProv ;
      private bool[] H00JW3_n527SolicitudServicioComProv ;
      private decimal[] H00JW3_A530SolicitudServicioComALM ;
      private bool[] H00JW3_n530SolicitudServicioComALM ;
      private decimal[] H00JW3_A532SolicitudServicioComALMP ;
      private bool[] H00JW3_n532SolicitudServicioComALMP ;
      private decimal[] H00JW3_A528SolicitudServicioComProvP ;
      private bool[] H00JW3_n528SolicitudServicioComProvP ;
      private decimal[] H00JW3_A865SolicitudesCostoXZComAlm ;
      private bool[] H00JW3_n865SolicitudesCostoXZComAlm ;
      private decimal[] H00JW3_A864SolicitudesCostoXZona ;
      private decimal[] H00JW3_A866SolicitudesCostoXZComAlmP ;
      private bool[] H00JW3_n866SolicitudesCostoXZComAlmP ;
      private long[] H00JW4_A598SolicitudesUsrActualizacion ;
      private bool[] H00JW4_n598SolicitudesUsrActualizacion ;
      private long[] H00JW4_A597SolicitudesUsrAlta ;
      private bool[] H00JW4_n597SolicitudesUsrAlta ;
      private string[] H00JW4_A130EstadosSolTipo ;
      private long[] H00JW4_A128MetodoPagosID ;
      private long[] H00JW4_A996CancelacionTipificacionId ;
      private DateTime[] H00JW4_A204SolicitudesFechaActualizacion ;
      private bool[] H00JW4_n204SolicitudesFechaActualizacion ;
      private DateTime[] H00JW4_A182SolicitudesFechaAlta ;
      private bool[] H00JW4_n182SolicitudesFechaAlta ;
      private string[] H00JW4_A203SolicitudesOtros3 ;
      private string[] H00JW4_A202SolicitudesOtros2 ;
      private string[] H00JW4_A201SolicitudesOtros1 ;
      private string[] H00JW4_A183SolicitudesHoraInstalacion ;
      private string[] H00JW4_A205SolicitudesComentario ;
      private string[] H00JW4_A261SolicitudesNota ;
      private string[] H00JW4_A997CancelacionTipificacionDescrip ;
      private string[] H00JW4_A441SolicitudesPagado ;
      private bool[] H00JW4_n441SolicitudesPagado ;
      private string[] H00JW4_A129MetodoPagosNombre ;
      private string[] H00JW4_A438SolicitudServicioOrigenPago ;
      private bool[] H00JW4_n438SolicitudServicioOrigenPago ;
      private short[] H00JW4_A194SolicitudesAutoEnumerar ;
      private string[] H00JW4_A173SolicitudesDireccion ;
      private long[] H00JW4_A110ZonasID ;
      private bool[] H00JW4_n110ZonasID ;
      private string[] H00JW4_A115DepartamentoMunicipioNombre ;
      private long[] H00JW4_A114DepartamentoMunicipioId ;
      private bool[] H00JW4_n114DepartamentoMunicipioId ;
      private string[] H00JW4_A113DepartamentoDepartamento ;
      private long[] H00JW4_A112DepartamentoId ;
      private bool[] H00JW4_n112DepartamentoId ;
      private string[] H00JW4_A116PaisID ;
      private string[] H00JW4_A206SolicitudesMail ;
      private bool[] H00JW4_n206SolicitudesMail ;
      private string[] H00JW4_A172SolicitudesTelefono ;
      private string[] H00JW4_A171SolicitudesNombre ;
      private string[] H00JW4_A282ProveedorNombre ;
      private long[] H00JW4_A133ProveedorID ;
      private string[] H00JW4_A132EstadosSolNombre ;
      private int[] H00JW4_A131EstadosSolId ;
      private DateTime[] H00JW4_A184SolicitudesFechaInstalacion ;
      private string[] H00JW4_A600SolicitudesSubTipo ;
      private bool[] H00JW4_n600SolicitudesSubTipo ;
      private long[] H00JW4_A127SolicitudesID ;
      private decimal[] H00JW4_A796SolicitudesComisionMetodoPago ;
      private decimal[] H00JW4_A212SolicitudesCotizacion ;
      private decimal[] H00JW4_A1016SolicitudesDescuentoCupon ;
      private decimal[] H00JW4_A897SolicitudesDescuento ;
      private bool[] H00JW4_n897SolicitudesDescuento ;
      private decimal[] H00JW4_A527SolicitudServicioComProv ;
      private bool[] H00JW4_n527SolicitudServicioComProv ;
      private decimal[] H00JW4_A530SolicitudServicioComALM ;
      private bool[] H00JW4_n530SolicitudServicioComALM ;
      private decimal[] H00JW4_A532SolicitudServicioComALMP ;
      private bool[] H00JW4_n532SolicitudServicioComALMP ;
      private decimal[] H00JW4_A528SolicitudServicioComProvP ;
      private bool[] H00JW4_n528SolicitudServicioComProvP ;
      private decimal[] H00JW4_A865SolicitudesCostoXZComAlm ;
      private bool[] H00JW4_n865SolicitudesCostoXZComAlm ;
      private decimal[] H00JW4_A864SolicitudesCostoXZona ;
      private decimal[] H00JW4_A866SolicitudesCostoXZComAlmP ;
      private bool[] H00JW4_n866SolicitudesCostoXZComAlmP ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV126AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private long[] H00JW5_A18SecUserId ;
      private string[] H00JW5_A26SecUserName ;
      private long[] H00JW6_A18SecUserId ;
      private string[] H00JW6_A26SecUserName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV51ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class solicitudesreporteww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00JW3( IGxContext context ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                             DateTime AV213Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                             DateTime AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                             long AV215Solicitudesreportewwds_3_tfsolicitudesid ,
                                             long AV216Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                             int AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count ,
                                             string AV219Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                             string AV218Solicitudesreportewwds_6_tfestadossolnombre ,
                                             string AV221Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                             string AV220Solicitudesreportewwds_8_tfproveedornombre ,
                                             string AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                             string AV222Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                             string AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                             string AV224Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                             string AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                             string AV226Solicitudesreportewwds_14_tfsolicitudesmail ,
                                             string AV229Solicitudesreportewwds_17_tfpaisid_sel ,
                                             string AV228Solicitudesreportewwds_16_tfpaisid ,
                                             string AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                             string AV230Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                             string AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                             string AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                             string AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                             string AV234Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                             int AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count ,
                                             string AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                             string AV237Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                             int AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count ,
                                             decimal AV242Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                             decimal AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                             decimal AV244Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                             decimal AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                             decimal AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                             decimal AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                             decimal AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                             decimal AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                             decimal AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                             decimal AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                             decimal AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                             decimal AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                             decimal AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                             decimal AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                             decimal AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                             decimal AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                             decimal AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                             decimal AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                             decimal AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                             decimal AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                             decimal AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                             decimal AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                             decimal AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                             decimal AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                             string AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                             string AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                             string AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                             string AV270Solicitudesreportewwds_58_tfsolicitudesnota ,
                                             string AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                             string AV272Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                             string AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                             string AV274Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                             string AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                             string AV276Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                             DateTime AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                             DateTime AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                             DateTime AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                             DateTime AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             long A127SolicitudesID ,
                                             string A132EstadosSolNombre ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             string A116PaisID ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre ,
                                             string A173SolicitudesDireccion ,
                                             string A129MetodoPagosNombre ,
                                             decimal A212SolicitudesCotizacion ,
                                             decimal A897SolicitudesDescuento ,
                                             decimal A530SolicitudServicioComALM ,
                                             decimal A532SolicitudServicioComALMP ,
                                             decimal A528SolicitudServicioComProvP ,
                                             decimal A527SolicitudServicioComProv ,
                                             decimal A865SolicitudesCostoXZComAlm ,
                                             decimal A866SolicitudesCostoXZComAlmP ,
                                             decimal A864SolicitudesCostoXZona ,
                                             string A997CancelacionTipificacionDescrip ,
                                             string A261SolicitudesNota ,
                                             string A205SolicitudesComentario ,
                                             string A202SolicitudesOtros2 ,
                                             string A203SolicitudesOtros3 ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             DateTime A204SolicitudesFechaActualizacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             decimal AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                             decimal AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                             decimal A529SolicitudServicioComPro ,
                                             decimal AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int21 = new short[62];
         Object[] GXv_Object22 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesUsrActualizacion], T1.[SolicitudesUsrAlta], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[MetodoPagosID], T1.[CancelacionTipificacionId], T1.[SolicitudesFechaActualizacion], T1.[SolicitudesFechaAlta], T1.[SolicitudesOtros3], T1.[SolicitudesOtros2], T1.[SolicitudesOtros1], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesComentario], T1.[SolicitudesNota], T3.[CancelacionTipificacionDescrip], T1.[SolicitudesPagado], T2.[MetodoPagosNombre], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesAutoEnumerar], T1.[SolicitudesDireccion], T1.[ZonasID], T5.[DepartamentoMunicipioNombre], T1.[DepartamentoMunicipioId], T4.[DepartamentoDepartamento], T1.[DepartamentoId], T4.[PaisID], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T6.[ProveedorNombre], T1.[ProveedorID], T7.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesFechaInstalacion], T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudServicioComALMP], T1.[SolicitudServicioComProvP], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudesCostoXZona], T1.[SolicitudesCostoXZComAlmP] FROM (((((([Solicitudes] T1 INNER JOIN [MetodoPagos] T2 ON T2.[MetodoPagosID] = T1.[MetodoPagosID]) INNER JOIN [CancelacionTipificacion] T3 ON T3.[CancelacionTipificacionId] = T1.[CancelacionTipificacionId]) LEFT JOIN [Departamento] T4 ON T4.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T5 ON T5.[DepartamentoId] = T1.[DepartamentoId] AND T5.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) INNER JOIN [Proveedor] T6 ON T6.[ProveedorID] = T1.[ProveedorID])";
         scmdbuf += " INNER JOIN [EstadosGenericos] T7 ON T7.[EstadosTipo] = T1.[EstadosSolTipo] AND T7.[EstadosGenericosId] = T1.[EstadosSolId])";
         if ( ! (DateTime.MinValue==AV213Solicitudesreportewwds_1_solicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV213Solicitudesreportewwds_1_solicitudesfechainstalacion)");
         }
         else
         {
            GXv_int21[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int21[1] = 1;
         }
         if ( ! (0==AV215Solicitudesreportewwds_3_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV215Solicitudesreportewwds_3_tfsolicitudesid)");
         }
         else
         {
            GXv_int21[2] = 1;
         }
         if ( ! (0==AV216Solicitudesreportewwds_4_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV216Solicitudesreportewwds_4_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int21[3] = 1;
         }
         if ( AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudesreportewwds_6_tfestadossolnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T7.[EstadosGenericosNombre]) like UPPER(@lV218Solicitudesreportewwds_6_tfestadossolnombre))");
         }
         else
         {
            GXv_int21[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ! ( StringUtil.StrCmp(AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.[EstadosGenericosNombre] = @AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)");
         }
         else
         {
            GXv_int21[5] = 1;
         }
         if ( StringUtil.StrCmp(AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T7.[EstadosGenericosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV221Solicitudesreportewwds_9_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV220Solicitudesreportewwds_8_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T6.[ProveedorNombre]) like UPPER(@lV220Solicitudesreportewwds_8_tfproveedornombre))");
         }
         else
         {
            GXv_int21[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV221Solicitudesreportewwds_9_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV221Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.[ProveedorNombre] = @AV221Solicitudesreportewwds_9_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int21[7] = 1;
         }
         if ( StringUtil.StrCmp(AV221Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T6.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV222Solicitudesreportewwds_10_tfsolicitudesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNombre]) like UPPER(@lV222Solicitudesreportewwds_10_tfsolicitudesnombre))");
         }
         else
         {
            GXv_int21[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ! ( StringUtil.StrCmp(AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNombre] = @AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)");
         }
         else
         {
            GXv_int21[9] = 1;
         }
         if ( StringUtil.StrCmp(AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV224Solicitudesreportewwds_12_tfsolicitudestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesTelefono]) like UPPER(@lV224Solicitudesreportewwds_12_tfsolicitudestelefono))");
         }
         else
         {
            GXv_int21[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ! ( StringUtil.StrCmp(AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesTelefono] = @AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)");
         }
         else
         {
            GXv_int21[11] = 1;
         }
         if ( StringUtil.StrCmp(AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV226Solicitudesreportewwds_14_tfsolicitudesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesMail]) like UPPER(@lV226Solicitudesreportewwds_14_tfsolicitudesmail))");
         }
         else
         {
            GXv_int21[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ! ( StringUtil.StrCmp(AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] = @AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)");
         }
         else
         {
            GXv_int21[13] = 1;
         }
         if ( StringUtil.StrCmp(AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] IS NULL or (T1.[SolicitudesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV229Solicitudesreportewwds_17_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV228Solicitudesreportewwds_16_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[PaisID]) like UPPER(@lV228Solicitudesreportewwds_16_tfpaisid))");
         }
         else
         {
            GXv_int21[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV229Solicitudesreportewwds_17_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV229Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[PaisID] = @AV229Solicitudesreportewwds_17_tfpaisid_sel)");
         }
         else
         {
            GXv_int21[15] = 1;
         }
         if ( StringUtil.StrCmp(AV229Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV230Solicitudesreportewwds_18_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[DepartamentoDepartamento]) like UPPER(@lV230Solicitudesreportewwds_18_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int21[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[DepartamentoDepartamento] = @AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int21[17] = 1;
         }
         if ( StringUtil.StrCmp(AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[DepartamentoMunicipioNombre]) like UPPER(@lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int21[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[DepartamentoMunicipioNombre] = @AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int21[19] = 1;
         }
         if ( StringUtil.StrCmp(AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T5.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV234Solicitudesreportewwds_22_tfsolicitudesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesDireccion]) like UPPER(@lV234Solicitudesreportewwds_22_tfsolicitudesdireccion))");
         }
         else
         {
            GXv_int21[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ! ( StringUtil.StrCmp(AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] = @AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)");
         }
         else
         {
            GXv_int21[21] = 1;
         }
         if ( StringUtil.StrCmp(AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesDireccion] = ''))");
         }
         if ( AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV237Solicitudesreportewwds_25_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MetodoPagosNombre]) like UPPER(@lV237Solicitudesreportewwds_25_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int21[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MetodoPagosNombre] = @AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int21[23] = 1;
         }
         if ( StringUtil.StrCmp(AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MetodoPagosNombre] = ''))");
         }
         if ( AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV242Solicitudesreportewwds_30_tfsolicitudescotizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] >= @AV242Solicitudesreportewwds_30_tfsolicitudescotizacion)");
         }
         else
         {
            GXv_int21[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] <= @AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to)");
         }
         else
         {
            GXv_int21[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV244Solicitudesreportewwds_32_tfsolicitudesdescuento) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] >= @AV244Solicitudesreportewwds_32_tfsolicitudesdescuento)");
         }
         else
         {
            GXv_int21[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] <= @AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to)");
         }
         else
         {
            GXv_int21[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] >= @AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm)");
         }
         else
         {
            GXv_int21[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] <= @AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to)");
         }
         else
         {
            GXv_int21[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] >= @AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp)");
         }
         else
         {
            GXv_int21[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] <= @AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to)");
         }
         else
         {
            GXv_int21[31] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) >= @AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop)");
         }
         else
         {
            GXv_int21[32] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) <= @AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to)");
         }
         else
         {
            GXv_int21[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] >= @AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov)");
         }
         else
         {
            GXv_int21[34] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] <= @AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to)");
         }
         else
         {
            GXv_int21[35] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] >= @AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp)");
         }
         else
         {
            GXv_int21[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] <= @AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to)");
         }
         else
         {
            GXv_int21[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] >= @AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm)");
         }
         else
         {
            GXv_int21[38] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] <= @AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to)");
         }
         else
         {
            GXv_int21[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] >= @AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp)");
         }
         else
         {
            GXv_int21[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] <= @AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to)");
         }
         else
         {
            GXv_int21[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) >= @AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof)");
         }
         else
         {
            GXv_int21[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) <= @AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to)");
         }
         else
         {
            GXv_int21[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) >= @AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp)");
         }
         else
         {
            GXv_int21[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) <= @AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to)");
         }
         else
         {
            GXv_int21[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] >= @AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona)");
         }
         else
         {
            GXv_int21[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] <= @AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to)");
         }
         else
         {
            GXv_int21[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[CancelacionTipificacionDescrip]) like UPPER(@lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion))");
         }
         else
         {
            GXv_int21[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ! ( StringUtil.StrCmp(AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[CancelacionTipificacionDescrip] = @AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)");
         }
         else
         {
            GXv_int21[49] = 1;
         }
         if ( StringUtil.StrCmp(AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[CancelacionTipificacionDescrip] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV270Solicitudesreportewwds_58_tfsolicitudesnota)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNota]) like UPPER(@lV270Solicitudesreportewwds_58_tfsolicitudesnota))");
         }
         else
         {
            GXv_int21[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ! ( StringUtil.StrCmp(AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNota] = @AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)");
         }
         else
         {
            GXv_int21[51] = 1;
         }
         if ( StringUtil.StrCmp(AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNota] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV272Solicitudesreportewwds_60_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV272Solicitudesreportewwds_60_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int21[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int21[53] = 1;
         }
         if ( StringUtil.StrCmp(AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV274Solicitudesreportewwds_62_tfsolicitudesotros2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros2]) like UPPER(@lV274Solicitudesreportewwds_62_tfsolicitudesotros2))");
         }
         else
         {
            GXv_int21[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ! ( StringUtil.StrCmp(AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros2] = @AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)");
         }
         else
         {
            GXv_int21[55] = 1;
         }
         if ( StringUtil.StrCmp(AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros2] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV276Solicitudesreportewwds_64_tfsolicitudesotros3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros3]) like UPPER(@lV276Solicitudesreportewwds_64_tfsolicitudesotros3))");
         }
         else
         {
            GXv_int21[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ! ( StringUtil.StrCmp(AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros3] = @AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)");
         }
         else
         {
            GXv_int21[57] = 1;
         }
         if ( StringUtil.StrCmp(AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros3] = ''))");
         }
         if ( ! (DateTime.MinValue==AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int21[58] = 1;
         }
         if ( ! (DateTime.MinValue==AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int21[59] = 1;
         }
         if ( ! (DateTime.MinValue==AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] >= @AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion)");
         }
         else
         {
            GXv_int21[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] <= @AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to)");
         }
         else
         {
            GXv_int21[61] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[PaisID]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[PaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[DepartamentoDepartamento]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[DepartamentoMunicipioNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MetodoPagosNombre]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP] DESC";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm]";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm] DESC";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP]";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP] DESC";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona]";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona] DESC";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[CancelacionTipificacionDescrip]";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[CancelacionTipificacionDescrip] DESC";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota]";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota] DESC";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario] DESC";
         }
         else if ( ( AV14OrderedBy == 28 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2]";
         }
         else if ( ( AV14OrderedBy == 28 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2] DESC";
         }
         else if ( ( AV14OrderedBy == 29 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3]";
         }
         else if ( ( AV14OrderedBy == 29 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3] DESC";
         }
         else if ( ( AV14OrderedBy == 30 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 30 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 31 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 31 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion] DESC";
         }
         GXv_Object22[0] = scmdbuf;
         GXv_Object22[1] = GXv_int21;
         return GXv_Object22 ;
      }

      protected Object[] conditional_H00JW4( IGxContext context ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels ,
                                             DateTime AV213Solicitudesreportewwds_1_solicitudesfechainstalacion ,
                                             DateTime AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to ,
                                             long AV215Solicitudesreportewwds_3_tfsolicitudesid ,
                                             long AV216Solicitudesreportewwds_4_tfsolicitudesid_to ,
                                             int AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count ,
                                             string AV219Solicitudesreportewwds_7_tfestadossolnombre_sel ,
                                             string AV218Solicitudesreportewwds_6_tfestadossolnombre ,
                                             string AV221Solicitudesreportewwds_9_tfproveedornombre_sel ,
                                             string AV220Solicitudesreportewwds_8_tfproveedornombre ,
                                             string AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel ,
                                             string AV222Solicitudesreportewwds_10_tfsolicitudesnombre ,
                                             string AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel ,
                                             string AV224Solicitudesreportewwds_12_tfsolicitudestelefono ,
                                             string AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel ,
                                             string AV226Solicitudesreportewwds_14_tfsolicitudesmail ,
                                             string AV229Solicitudesreportewwds_17_tfpaisid_sel ,
                                             string AV228Solicitudesreportewwds_16_tfpaisid ,
                                             string AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel ,
                                             string AV230Solicitudesreportewwds_18_tfdepartamentodepartamento ,
                                             string AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel ,
                                             string AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre ,
                                             string AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel ,
                                             string AV234Solicitudesreportewwds_22_tfsolicitudesdireccion ,
                                             int AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count ,
                                             string AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel ,
                                             string AV237Solicitudesreportewwds_25_tfmetodopagosnombre ,
                                             int AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count ,
                                             decimal AV242Solicitudesreportewwds_30_tfsolicitudescotizacion ,
                                             decimal AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to ,
                                             decimal AV244Solicitudesreportewwds_32_tfsolicitudesdescuento ,
                                             decimal AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to ,
                                             decimal AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm ,
                                             decimal AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to ,
                                             decimal AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp ,
                                             decimal AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to ,
                                             decimal AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop ,
                                             decimal AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to ,
                                             decimal AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov ,
                                             decimal AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to ,
                                             decimal AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp ,
                                             decimal AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to ,
                                             decimal AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm ,
                                             decimal AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to ,
                                             decimal AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp ,
                                             decimal AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to ,
                                             decimal AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof ,
                                             decimal AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to ,
                                             decimal AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp ,
                                             decimal AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to ,
                                             decimal AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona ,
                                             decimal AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to ,
                                             string AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel ,
                                             string AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion ,
                                             string AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel ,
                                             string AV270Solicitudesreportewwds_58_tfsolicitudesnota ,
                                             string AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel ,
                                             string AV272Solicitudesreportewwds_60_tfsolicitudescomentario ,
                                             string AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel ,
                                             string AV274Solicitudesreportewwds_62_tfsolicitudesotros2 ,
                                             string AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel ,
                                             string AV276Solicitudesreportewwds_64_tfsolicitudesotros3 ,
                                             DateTime AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta ,
                                             DateTime AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to ,
                                             DateTime AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion ,
                                             DateTime AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             long A127SolicitudesID ,
                                             string A132EstadosSolNombre ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             string A116PaisID ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre ,
                                             string A173SolicitudesDireccion ,
                                             string A129MetodoPagosNombre ,
                                             decimal A212SolicitudesCotizacion ,
                                             decimal A897SolicitudesDescuento ,
                                             decimal A530SolicitudServicioComALM ,
                                             decimal A532SolicitudServicioComALMP ,
                                             decimal A528SolicitudServicioComProvP ,
                                             decimal A527SolicitudServicioComProv ,
                                             decimal A865SolicitudesCostoXZComAlm ,
                                             decimal A866SolicitudesCostoXZComAlmP ,
                                             decimal A864SolicitudesCostoXZona ,
                                             string A997CancelacionTipificacionDescrip ,
                                             string A261SolicitudesNota ,
                                             string A205SolicitudesComentario ,
                                             string A202SolicitudesOtros2 ,
                                             string A203SolicitudesOtros3 ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             DateTime A204SolicitudesFechaActualizacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             decimal AV240Solicitudesreportewwds_28_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV241Solicitudesreportewwds_29_tfsolicitudserviciopfinal_to ,
                                             decimal AV250Solicitudesreportewwds_38_tfsolicitudserviciocompro ,
                                             decimal A529SolicitudServicioComPro ,
                                             decimal AV251Solicitudesreportewwds_39_tfsolicitudserviciocompro_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int23 = new short[62];
         Object[] GXv_Object24 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesUsrActualizacion], T1.[SolicitudesUsrAlta], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[MetodoPagosID], T1.[CancelacionTipificacionId], T1.[SolicitudesFechaActualizacion], T1.[SolicitudesFechaAlta], T1.[SolicitudesOtros3], T1.[SolicitudesOtros2], T1.[SolicitudesOtros1], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesComentario], T1.[SolicitudesNota], T3.[CancelacionTipificacionDescrip], T1.[SolicitudesPagado], T2.[MetodoPagosNombre], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesAutoEnumerar], T1.[SolicitudesDireccion], T1.[ZonasID], T5.[DepartamentoMunicipioNombre], T1.[DepartamentoMunicipioId], T4.[DepartamentoDepartamento], T1.[DepartamentoId], T4.[PaisID], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T6.[ProveedorNombre], T1.[ProveedorID], T7.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesFechaInstalacion], T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudServicioComALMP], T1.[SolicitudServicioComProvP], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudesCostoXZona], T1.[SolicitudesCostoXZComAlmP] FROM (((((([Solicitudes] T1 INNER JOIN [MetodoPagos] T2 ON T2.[MetodoPagosID] = T1.[MetodoPagosID]) INNER JOIN [CancelacionTipificacion] T3 ON T3.[CancelacionTipificacionId] = T1.[CancelacionTipificacionId]) LEFT JOIN [Departamento] T4 ON T4.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T5 ON T5.[DepartamentoId] = T1.[DepartamentoId] AND T5.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) INNER JOIN [Proveedor] T6 ON T6.[ProveedorID] = T1.[ProveedorID])";
         scmdbuf += " INNER JOIN [EstadosGenericos] T7 ON T7.[EstadosTipo] = T1.[EstadosSolTipo] AND T7.[EstadosGenericosId] = T1.[EstadosSolId])";
         if ( ! (DateTime.MinValue==AV213Solicitudesreportewwds_1_solicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV213Solicitudesreportewwds_1_solicitudesfechainstalacion)");
         }
         else
         {
            GXv_int23[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int23[1] = 1;
         }
         if ( ! (0==AV215Solicitudesreportewwds_3_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV215Solicitudesreportewwds_3_tfsolicitudesid)");
         }
         else
         {
            GXv_int23[2] = 1;
         }
         if ( ! (0==AV216Solicitudesreportewwds_4_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV216Solicitudesreportewwds_4_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int23[3] = 1;
         }
         if ( AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV217Solicitudesreportewwds_5_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudesreportewwds_6_tfestadossolnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T7.[EstadosGenericosNombre]) like UPPER(@lV218Solicitudesreportewwds_6_tfestadossolnombre))");
         }
         else
         {
            GXv_int23[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)) && ! ( StringUtil.StrCmp(AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T7.[EstadosGenericosNombre] = @AV219Solicitudesreportewwds_7_tfestadossolnombre_sel)");
         }
         else
         {
            GXv_int23[5] = 1;
         }
         if ( StringUtil.StrCmp(AV219Solicitudesreportewwds_7_tfestadossolnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T7.[EstadosGenericosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV221Solicitudesreportewwds_9_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV220Solicitudesreportewwds_8_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T6.[ProveedorNombre]) like UPPER(@lV220Solicitudesreportewwds_8_tfproveedornombre))");
         }
         else
         {
            GXv_int23[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV221Solicitudesreportewwds_9_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV221Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.[ProveedorNombre] = @AV221Solicitudesreportewwds_9_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int23[7] = 1;
         }
         if ( StringUtil.StrCmp(AV221Solicitudesreportewwds_9_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T6.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV222Solicitudesreportewwds_10_tfsolicitudesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNombre]) like UPPER(@lV222Solicitudesreportewwds_10_tfsolicitudesnombre))");
         }
         else
         {
            GXv_int23[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)) && ! ( StringUtil.StrCmp(AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNombre] = @AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel)");
         }
         else
         {
            GXv_int23[9] = 1;
         }
         if ( StringUtil.StrCmp(AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV224Solicitudesreportewwds_12_tfsolicitudestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesTelefono]) like UPPER(@lV224Solicitudesreportewwds_12_tfsolicitudestelefono))");
         }
         else
         {
            GXv_int23[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)) && ! ( StringUtil.StrCmp(AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesTelefono] = @AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel)");
         }
         else
         {
            GXv_int23[11] = 1;
         }
         if ( StringUtil.StrCmp(AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV226Solicitudesreportewwds_14_tfsolicitudesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesMail]) like UPPER(@lV226Solicitudesreportewwds_14_tfsolicitudesmail))");
         }
         else
         {
            GXv_int23[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)) && ! ( StringUtil.StrCmp(AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] = @AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel)");
         }
         else
         {
            GXv_int23[13] = 1;
         }
         if ( StringUtil.StrCmp(AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] IS NULL or (T1.[SolicitudesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV229Solicitudesreportewwds_17_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV228Solicitudesreportewwds_16_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[PaisID]) like UPPER(@lV228Solicitudesreportewwds_16_tfpaisid))");
         }
         else
         {
            GXv_int23[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV229Solicitudesreportewwds_17_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV229Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[PaisID] = @AV229Solicitudesreportewwds_17_tfpaisid_sel)");
         }
         else
         {
            GXv_int23[15] = 1;
         }
         if ( StringUtil.StrCmp(AV229Solicitudesreportewwds_17_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV230Solicitudesreportewwds_18_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[DepartamentoDepartamento]) like UPPER(@lV230Solicitudesreportewwds_18_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int23[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[DepartamentoDepartamento] = @AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int23[17] = 1;
         }
         if ( StringUtil.StrCmp(AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[DepartamentoMunicipioNombre]) like UPPER(@lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int23[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[DepartamentoMunicipioNombre] = @AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int23[19] = 1;
         }
         if ( StringUtil.StrCmp(AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T5.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV234Solicitudesreportewwds_22_tfsolicitudesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesDireccion]) like UPPER(@lV234Solicitudesreportewwds_22_tfsolicitudesdireccion))");
         }
         else
         {
            GXv_int23[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)) && ! ( StringUtil.StrCmp(AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] = @AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel)");
         }
         else
         {
            GXv_int23[21] = 1;
         }
         if ( StringUtil.StrCmp(AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesDireccion] = ''))");
         }
         if ( AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV236Solicitudesreportewwds_24_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV237Solicitudesreportewwds_25_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MetodoPagosNombre]) like UPPER(@lV237Solicitudesreportewwds_25_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int23[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MetodoPagosNombre] = @AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int23[23] = 1;
         }
         if ( StringUtil.StrCmp(AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MetodoPagosNombre] = ''))");
         }
         if ( AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV239Solicitudesreportewwds_27_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV242Solicitudesreportewwds_30_tfsolicitudescotizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] >= @AV242Solicitudesreportewwds_30_tfsolicitudescotizacion)");
         }
         else
         {
            GXv_int23[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCotizacion] <= @AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to)");
         }
         else
         {
            GXv_int23[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV244Solicitudesreportewwds_32_tfsolicitudesdescuento) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] >= @AV244Solicitudesreportewwds_32_tfsolicitudesdescuento)");
         }
         else
         {
            GXv_int23[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDescuento] <= @AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to)");
         }
         else
         {
            GXv_int23[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] >= @AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm)");
         }
         else
         {
            GXv_int23[28] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALM] <= @AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to)");
         }
         else
         {
            GXv_int23[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] >= @AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp)");
         }
         else
         {
            GXv_int23[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComALMP] <= @AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to)");
         }
         else
         {
            GXv_int23[31] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) >= @AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop)");
         }
         else
         {
            GXv_int23[32] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudServicioComALMP] >= 0 THEN 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] >= 0 THEN ( 100 - T1.[SolicitudServicioComProvP]) + ( T1.[SolicitudServicioComALMP] * CAST(-1 AS decimal( 16, 10))) WHEN T1.[SolicitudServicioComALMP] < 0 and T1.[SolicitudServicioComProvP] < 0 THEN 100 + ( ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudServicioComProvP] + T1.[SolicitudServicioComALMP]) END) <= @AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to)");
         }
         else
         {
            GXv_int23[33] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] >= @AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov)");
         }
         else
         {
            GXv_int23[34] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProv] <= @AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to)");
         }
         else
         {
            GXv_int23[35] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] >= @AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp)");
         }
         else
         {
            GXv_int23[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioComProvP] <= @AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to)");
         }
         else
         {
            GXv_int23[37] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] >= @AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm)");
         }
         else
         {
            GXv_int23[38] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlm] <= @AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to)");
         }
         else
         {
            GXv_int23[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] >= @AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp)");
         }
         else
         {
            GXv_int23[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZComAlmP] <= @AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to)");
         }
         else
         {
            GXv_int23[41] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) >= @AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof)");
         }
         else
         {
            GXv_int23[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlm] < 0 THEN T1.[SolicitudesCostoXZona] + ( T1.[SolicitudesCostoXZComAlm] * CAST(-1 AS decimal( 28, 10))) ELSE T1.[SolicitudesCostoXZona] - ( T1.[SolicitudesCostoXZComAlm]) END) <= @AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to)");
         }
         else
         {
            GXv_int23[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) >= @AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp)");
         }
         else
         {
            GXv_int23[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T1.[SolicitudesCostoXZComAlmP] >= 0 THEN 100 - ( T1.[SolicitudesCostoXZComAlmP]) WHEN T1.[SolicitudesCostoXZComAlmP] < 0 THEN 100 + ( T1.[SolicitudesCostoXZComAlmP] * CAST(-1 AS decimal( 16, 10))) ELSE 100 - ( T1.[SolicitudesCostoXZComAlmP]) END) <= @AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to)");
         }
         else
         {
            GXv_int23[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] >= @AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona)");
         }
         else
         {
            GXv_int23[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesCostoXZona] <= @AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to)");
         }
         else
         {
            GXv_int23[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[CancelacionTipificacionDescrip]) like UPPER(@lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion))");
         }
         else
         {
            GXv_int23[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)) && ! ( StringUtil.StrCmp(AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[CancelacionTipificacionDescrip] = @AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel)");
         }
         else
         {
            GXv_int23[49] = 1;
         }
         if ( StringUtil.StrCmp(AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[CancelacionTipificacionDescrip] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV270Solicitudesreportewwds_58_tfsolicitudesnota)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNota]) like UPPER(@lV270Solicitudesreportewwds_58_tfsolicitudesnota))");
         }
         else
         {
            GXv_int23[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)) && ! ( StringUtil.StrCmp(AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNota] = @AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel)");
         }
         else
         {
            GXv_int23[51] = 1;
         }
         if ( StringUtil.StrCmp(AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNota] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV272Solicitudesreportewwds_60_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV272Solicitudesreportewwds_60_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int23[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int23[53] = 1;
         }
         if ( StringUtil.StrCmp(AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV274Solicitudesreportewwds_62_tfsolicitudesotros2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros2]) like UPPER(@lV274Solicitudesreportewwds_62_tfsolicitudesotros2))");
         }
         else
         {
            GXv_int23[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)) && ! ( StringUtil.StrCmp(AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros2] = @AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel)");
         }
         else
         {
            GXv_int23[55] = 1;
         }
         if ( StringUtil.StrCmp(AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros2] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV276Solicitudesreportewwds_64_tfsolicitudesotros3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesOtros3]) like UPPER(@lV276Solicitudesreportewwds_64_tfsolicitudesotros3))");
         }
         else
         {
            GXv_int23[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)) && ! ( StringUtil.StrCmp(AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesOtros3] = @AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel)");
         }
         else
         {
            GXv_int23[57] = 1;
         }
         if ( StringUtil.StrCmp(AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesOtros3] = ''))");
         }
         if ( ! (DateTime.MinValue==AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int23[58] = 1;
         }
         if ( ! (DateTime.MinValue==AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int23[59] = 1;
         }
         if ( ! (DateTime.MinValue==AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] >= @AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion)");
         }
         else
         {
            GXv_int23[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaActualizacion] <= @AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to)");
         }
         else
         {
            GXv_int23[61] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[PaisID]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[PaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[DepartamentoDepartamento]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[DepartamentoMunicipioNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MetodoPagosNombre]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDescuento] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALM] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComALMP] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProv] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioComProvP] DESC";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm]";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlm] DESC";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP]";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZComAlmP] DESC";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona]";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesCostoXZona] DESC";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[CancelacionTipificacionDescrip]";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[CancelacionTipificacionDescrip] DESC";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota]";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNota] DESC";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario] DESC";
         }
         else if ( ( AV14OrderedBy == 28 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2]";
         }
         else if ( ( AV14OrderedBy == 28 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros2] DESC";
         }
         else if ( ( AV14OrderedBy == 29 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3]";
         }
         else if ( ( AV14OrderedBy == 29 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesOtros3] DESC";
         }
         else if ( ( AV14OrderedBy == 30 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 30 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 31 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 31 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaActualizacion] DESC";
         }
         GXv_Object24[0] = scmdbuf;
         GXv_Object24[1] = GXv_int23;
         return GXv_Object24 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00JW3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] , (decimal)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (DateTime)dynConstraints[67] , (DateTime)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (DateTime)dynConstraints[71] , (long)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (decimal)dynConstraints[86] , (decimal)dynConstraints[87] , (decimal)dynConstraints[88] , (decimal)dynConstraints[89] , (decimal)dynConstraints[90] , (decimal)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (DateTime)dynConstraints[97] , (DateTime)dynConstraints[98] , (short)dynConstraints[99] , (bool)dynConstraints[100] , (decimal)dynConstraints[101] , (decimal)dynConstraints[102] , (decimal)dynConstraints[103] , (decimal)dynConstraints[104] , (decimal)dynConstraints[105] , (decimal)dynConstraints[106] );
               case 2 :
                     return conditional_H00JW4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (decimal)dynConstraints[47] , (decimal)dynConstraints[48] , (decimal)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (decimal)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (DateTime)dynConstraints[67] , (DateTime)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (DateTime)dynConstraints[71] , (long)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (decimal)dynConstraints[86] , (decimal)dynConstraints[87] , (decimal)dynConstraints[88] , (decimal)dynConstraints[89] , (decimal)dynConstraints[90] , (decimal)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (DateTime)dynConstraints[97] , (DateTime)dynConstraints[98] , (short)dynConstraints[99] , (bool)dynConstraints[100] , (decimal)dynConstraints[101] , (decimal)dynConstraints[102] , (decimal)dynConstraints[103] , (decimal)dynConstraints[104] , (decimal)dynConstraints[105] , (decimal)dynConstraints[106] );
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
          Object[] prmH00JW2;
          prmH00JW2 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH00JW5;
          prmH00JW5 = new Object[] {
          new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true}
          };
          Object[] prmH00JW6;
          prmH00JW6 = new Object[] {
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true}
          };
          Object[] prmH00JW3;
          prmH00JW3 = new Object[] {
          new ParDef("@AV213Solicitudesreportewwds_1_solicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV215Solicitudesreportewwds_3_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV216Solicitudesreportewwds_4_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV218Solicitudesreportewwds_6_tfestadossolnombre",GXType.Char,80,0) ,
          new ParDef("@AV219Solicitudesreportewwds_7_tfestadossolnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV220Solicitudesreportewwds_8_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV221Solicitudesreportewwds_9_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV222Solicitudesreportewwds_10_tfsolicitudesnombre",GXType.Char,100,0) ,
          new ParDef("@AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV224Solicitudesreportewwds_12_tfsolicitudestelefono",GXType.Char,20,0) ,
          new ParDef("@AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV226Solicitudesreportewwds_14_tfsolicitudesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV228Solicitudesreportewwds_16_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV229Solicitudesreportewwds_17_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV230Solicitudesreportewwds_18_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV234Solicitudesreportewwds_22_tfsolicitudesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV237Solicitudesreportewwds_25_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV242Solicitudesreportewwds_30_tfsolicitudescotizacion",GXType.Decimal,18,2) ,
          new ParDef("@AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to",GXType.Decimal,18,2) ,
          new ParDef("@AV244Solicitudesreportewwds_32_tfsolicitudesdescuento",GXType.Decimal,18,2) ,
          new ParDef("@AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to",GXType.Decimal,18,2) ,
          new ParDef("@AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop",GXType.Decimal,6,2) ,
          new ParDef("@AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to",GXType.Decimal,6,2) ,
          new ParDef("@AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov",GXType.Decimal,18,2) ,
          new ParDef("@AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to",GXType.Decimal,18,2) ,
          new ParDef("@AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp",GXType.Decimal,6,2) ,
          new ParDef("@AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof",GXType.Decimal,18,2) ,
          new ParDef("@AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to",GXType.Decimal,18,2) ,
          new ParDef("@AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp",GXType.Decimal,6,2) ,
          new ParDef("@AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona",GXType.Decimal,18,2) ,
          new ParDef("@AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to",GXType.Decimal,18,2) ,
          new ParDef("@lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion",GXType.Char,250,0) ,
          new ParDef("@AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@lV270Solicitudesreportewwds_58_tfsolicitudesnota",GXType.Char,500,0) ,
          new ParDef("@AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel",GXType.NChar,500,0) ,
          new ParDef("@lV272Solicitudesreportewwds_60_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV274Solicitudesreportewwds_62_tfsolicitudesotros2",GXType.Char,1000,0) ,
          new ParDef("@AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel",GXType.NChar,1000,0) ,
          new ParDef("@lV276Solicitudesreportewwds_64_tfsolicitudesotros3",GXType.Char,500,0) ,
          new ParDef("@AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel",GXType.NChar,500,0) ,
          new ParDef("@AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion",GXType.DateTime,8,5) ,
          new ParDef("@AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to",GXType.DateTime,8,5)
          };
          Object[] prmH00JW4;
          prmH00JW4 = new Object[] {
          new ParDef("@AV213Solicitudesreportewwds_1_solicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV214Solicitudesreportewwds_2_solicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV215Solicitudesreportewwds_3_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV216Solicitudesreportewwds_4_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV218Solicitudesreportewwds_6_tfestadossolnombre",GXType.Char,80,0) ,
          new ParDef("@AV219Solicitudesreportewwds_7_tfestadossolnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV220Solicitudesreportewwds_8_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV221Solicitudesreportewwds_9_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV222Solicitudesreportewwds_10_tfsolicitudesnombre",GXType.Char,100,0) ,
          new ParDef("@AV223Solicitudesreportewwds_11_tfsolicitudesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV224Solicitudesreportewwds_12_tfsolicitudestelefono",GXType.Char,20,0) ,
          new ParDef("@AV225Solicitudesreportewwds_13_tfsolicitudestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV226Solicitudesreportewwds_14_tfsolicitudesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV227Solicitudesreportewwds_15_tfsolicitudesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV228Solicitudesreportewwds_16_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV229Solicitudesreportewwds_17_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV230Solicitudesreportewwds_18_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV231Solicitudesreportewwds_19_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV232Solicitudesreportewwds_20_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV233Solicitudesreportewwds_21_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV234Solicitudesreportewwds_22_tfsolicitudesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV235Solicitudesreportewwds_23_tfsolicitudesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV237Solicitudesreportewwds_25_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV238Solicitudesreportewwds_26_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV242Solicitudesreportewwds_30_tfsolicitudescotizacion",GXType.Decimal,18,2) ,
          new ParDef("@AV243Solicitudesreportewwds_31_tfsolicitudescotizacion_to",GXType.Decimal,18,2) ,
          new ParDef("@AV244Solicitudesreportewwds_32_tfsolicitudesdescuento",GXType.Decimal,18,2) ,
          new ParDef("@AV245Solicitudesreportewwds_33_tfsolicitudesdescuento_to",GXType.Decimal,18,2) ,
          new ParDef("@AV246Solicitudesreportewwds_34_tfsolicitudserviciocomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV247Solicitudesreportewwds_35_tfsolicitudserviciocomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV248Solicitudesreportewwds_36_tfsolicitudserviciocomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV249Solicitudesreportewwds_37_tfsolicitudserviciocomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV252Solicitudesreportewwds_40_tfsolicitudserviciocomprop",GXType.Decimal,6,2) ,
          new ParDef("@AV253Solicitudesreportewwds_41_tfsolicitudserviciocomprop_to",GXType.Decimal,6,2) ,
          new ParDef("@AV254Solicitudesreportewwds_42_tfsolicitudserviciocomprov",GXType.Decimal,18,2) ,
          new ParDef("@AV255Solicitudesreportewwds_43_tfsolicitudserviciocomprov_to",GXType.Decimal,18,2) ,
          new ParDef("@AV256Solicitudesreportewwds_44_tfsolicitudserviciocomprovp",GXType.Decimal,6,2) ,
          new ParDef("@AV257Solicitudesreportewwds_45_tfsolicitudserviciocomprovp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV258Solicitudesreportewwds_46_tfsolicitudescostoxzcomalm",GXType.Decimal,18,2) ,
          new ParDef("@AV259Solicitudesreportewwds_47_tfsolicitudescostoxzcomalm_to",GXType.Decimal,18,2) ,
          new ParDef("@AV260Solicitudesreportewwds_48_tfsolicitudescostoxzcomalmp",GXType.Decimal,6,2) ,
          new ParDef("@AV261Solicitudesreportewwds_49_tfsolicitudescostoxzcomalmp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV262Solicitudesreportewwds_50_tfsolicitudescostoxzcomprof",GXType.Decimal,18,2) ,
          new ParDef("@AV263Solicitudesreportewwds_51_tfsolicitudescostoxzcomprof_to",GXType.Decimal,18,2) ,
          new ParDef("@AV264Solicitudesreportewwds_52_tfsolicitudescostoxzcomprofp",GXType.Decimal,6,2) ,
          new ParDef("@AV265Solicitudesreportewwds_53_tfsolicitudescostoxzcomprofp_to",GXType.Decimal,6,2) ,
          new ParDef("@AV266Solicitudesreportewwds_54_tfsolicitudescostoxzona",GXType.Decimal,18,2) ,
          new ParDef("@AV267Solicitudesreportewwds_55_tfsolicitudescostoxzona_to",GXType.Decimal,18,2) ,
          new ParDef("@lV268Solicitudesreportewwds_56_tfcancelaciontipificaciondescripcion",GXType.Char,250,0) ,
          new ParDef("@AV269Solicitudesreportewwds_57_tfcancelaciontipificaciondescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@lV270Solicitudesreportewwds_58_tfsolicitudesnota",GXType.Char,500,0) ,
          new ParDef("@AV271Solicitudesreportewwds_59_tfsolicitudesnota_sel",GXType.NChar,500,0) ,
          new ParDef("@lV272Solicitudesreportewwds_60_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV273Solicitudesreportewwds_61_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV274Solicitudesreportewwds_62_tfsolicitudesotros2",GXType.Char,1000,0) ,
          new ParDef("@AV275Solicitudesreportewwds_63_tfsolicitudesotros2_sel",GXType.NChar,1000,0) ,
          new ParDef("@lV276Solicitudesreportewwds_64_tfsolicitudesotros3",GXType.Char,500,0) ,
          new ParDef("@AV277Solicitudesreportewwds_65_tfsolicitudesotros3_sel",GXType.NChar,500,0) ,
          new ParDef("@AV278Solicitudesreportewwds_66_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV279Solicitudesreportewwds_67_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV280Solicitudesreportewwds_68_tfsolicitudesfechaactualizacion",GXType.DateTime,8,5) ,
          new ParDef("@AV281Solicitudesreportewwds_69_tfsolicitudesfechaactualizacion_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00JW2", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JW2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JW3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JW3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JW4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JW4,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JW5", "SELECT [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @SolicitudesUsrAlta ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JW5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00JW6", "SELECT [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @SolicitudesUsrActualizacion ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JW6,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 500);
                ((string[]) buf[12])[0] = rslt.getString(9, 1000);
                ((string[]) buf[13])[0] = rslt.getString(10, 1);
                ((string[]) buf[14])[0] = rslt.getString(11, 1);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 500);
                ((string[]) buf[17])[0] = rslt.getString(14, 250);
                ((string[]) buf[18])[0] = rslt.getString(15, 1);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 80);
                ((string[]) buf[21])[0] = rslt.getString(17, 1);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((short[]) buf[23])[0] = rslt.getShort(18);
                ((string[]) buf[24])[0] = rslt.getVarchar(19);
                ((long[]) buf[25])[0] = rslt.getLong(20);
                ((bool[]) buf[26])[0] = rslt.wasNull(20);
                ((string[]) buf[27])[0] = rslt.getString(21, 120);
                ((long[]) buf[28])[0] = rslt.getLong(22);
                ((bool[]) buf[29])[0] = rslt.wasNull(22);
                ((string[]) buf[30])[0] = rslt.getString(23, 80);
                ((long[]) buf[31])[0] = rslt.getLong(24);
                ((bool[]) buf[32])[0] = rslt.wasNull(24);
                ((string[]) buf[33])[0] = rslt.getString(25, 2);
                ((string[]) buf[34])[0] = rslt.getVarchar(26);
                ((bool[]) buf[35])[0] = rslt.wasNull(26);
                ((string[]) buf[36])[0] = rslt.getString(27, 20);
                ((string[]) buf[37])[0] = rslt.getString(28, 100);
                ((string[]) buf[38])[0] = rslt.getString(29, 80);
                ((long[]) buf[39])[0] = rslt.getLong(30);
                ((string[]) buf[40])[0] = rslt.getString(31, 80);
                ((int[]) buf[41])[0] = rslt.getInt(32);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(33);
                ((string[]) buf[43])[0] = rslt.getString(34, 1);
                ((bool[]) buf[44])[0] = rslt.wasNull(34);
                ((long[]) buf[45])[0] = rslt.getLong(35);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(36);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
                ((decimal[]) buf[48])[0] = rslt.getDecimal(38);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(39);
                ((bool[]) buf[50])[0] = rslt.wasNull(39);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(40);
                ((bool[]) buf[52])[0] = rslt.wasNull(40);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(41);
                ((bool[]) buf[54])[0] = rslt.wasNull(41);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(42);
                ((bool[]) buf[56])[0] = rslt.wasNull(42);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(43);
                ((bool[]) buf[58])[0] = rslt.wasNull(43);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(44);
                ((bool[]) buf[60])[0] = rslt.wasNull(44);
                ((decimal[]) buf[61])[0] = rslt.getDecimal(45);
                ((decimal[]) buf[62])[0] = rslt.getDecimal(46);
                ((bool[]) buf[63])[0] = rslt.wasNull(46);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 500);
                ((string[]) buf[12])[0] = rslt.getString(9, 1000);
                ((string[]) buf[13])[0] = rslt.getString(10, 1);
                ((string[]) buf[14])[0] = rslt.getString(11, 1);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 500);
                ((string[]) buf[17])[0] = rslt.getString(14, 250);
                ((string[]) buf[18])[0] = rslt.getString(15, 1);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 80);
                ((string[]) buf[21])[0] = rslt.getString(17, 1);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((short[]) buf[23])[0] = rslt.getShort(18);
                ((string[]) buf[24])[0] = rslt.getVarchar(19);
                ((long[]) buf[25])[0] = rslt.getLong(20);
                ((bool[]) buf[26])[0] = rslt.wasNull(20);
                ((string[]) buf[27])[0] = rslt.getString(21, 120);
                ((long[]) buf[28])[0] = rslt.getLong(22);
                ((bool[]) buf[29])[0] = rslt.wasNull(22);
                ((string[]) buf[30])[0] = rslt.getString(23, 80);
                ((long[]) buf[31])[0] = rslt.getLong(24);
                ((bool[]) buf[32])[0] = rslt.wasNull(24);
                ((string[]) buf[33])[0] = rslt.getString(25, 2);
                ((string[]) buf[34])[0] = rslt.getVarchar(26);
                ((bool[]) buf[35])[0] = rslt.wasNull(26);
                ((string[]) buf[36])[0] = rslt.getString(27, 20);
                ((string[]) buf[37])[0] = rslt.getString(28, 100);
                ((string[]) buf[38])[0] = rslt.getString(29, 80);
                ((long[]) buf[39])[0] = rslt.getLong(30);
                ((string[]) buf[40])[0] = rslt.getString(31, 80);
                ((int[]) buf[41])[0] = rslt.getInt(32);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(33);
                ((string[]) buf[43])[0] = rslt.getString(34, 1);
                ((bool[]) buf[44])[0] = rslt.wasNull(34);
                ((long[]) buf[45])[0] = rslt.getLong(35);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(36);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(37);
                ((decimal[]) buf[48])[0] = rslt.getDecimal(38);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(39);
                ((bool[]) buf[50])[0] = rslt.wasNull(39);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(40);
                ((bool[]) buf[52])[0] = rslt.wasNull(40);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(41);
                ((bool[]) buf[54])[0] = rslt.wasNull(41);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(42);
                ((bool[]) buf[56])[0] = rslt.wasNull(42);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(43);
                ((bool[]) buf[58])[0] = rslt.wasNull(43);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(44);
                ((bool[]) buf[60])[0] = rslt.wasNull(44);
                ((decimal[]) buf[61])[0] = rslt.getDecimal(45);
                ((decimal[]) buf[62])[0] = rslt.getDecimal(46);
                ((bool[]) buf[63])[0] = rslt.wasNull(46);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
