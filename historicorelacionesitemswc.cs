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
   public class historicorelacionesitemswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public historicorelacionesitemswc( )
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

      public historicorelacionesitemswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_HistoricoSolicitudesID )
      {
         this.AV8HistoricoSolicitudesID = aP0_HistoricoSolicitudesID;
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
         cmbHistoricoSolicitudesPagado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
                  AV8HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8HistoricoSolicitudesID});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_33 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_33_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV100Pgmname = GetPar( "Pgmname");
         AV21TFHistoricoSolicitudesNombre = GetPar( "TFHistoricoSolicitudesNombre");
         AV22TFHistoricoSolicitudesNombre_Sel = GetPar( "TFHistoricoSolicitudesNombre_Sel");
         AV23TFHistoricoSolicitudesTelefono = GetPar( "TFHistoricoSolicitudesTelefono");
         AV24TFHistoricoSolicitudesTelefono_Sel = GetPar( "TFHistoricoSolicitudesTelefono_Sel");
         AV25TFHistoricoSolicitudesMail = GetPar( "TFHistoricoSolicitudesMail");
         AV26TFHistoricoSolicitudesMail_Sel = GetPar( "TFHistoricoSolicitudesMail_Sel");
         AV27TFHistoricoPaisID = GetPar( "TFHistoricoPaisID");
         AV28TFHistoricoPaisID_Sel = GetPar( "TFHistoricoPaisID_Sel");
         AV29TFHistoricoDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV30TFHistoricoDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoDepartamentoId_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFHistoricoDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         AV32TFHistoricoDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoDepartamentoMunicipioId_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFHistoricoZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoZonasID"), "."), 18, MidpointRounding.ToEven));
         AV34TFHistoricoZonasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoZonasID_To"), "."), 18, MidpointRounding.ToEven));
         AV35TFHistoricoSolicitudesDireccion = GetPar( "TFHistoricoSolicitudesDireccion");
         AV36TFHistoricoSolicitudesDireccion_Sel = GetPar( "TFHistoricoSolicitudesDireccion_Sel");
         AV37TFHistoricoSolicitudesAutoEnumerar = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesAutoEnumerar"), "."), 18, MidpointRounding.ToEven));
         AV38TFHistoricoSolicitudesAutoEnumerar_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFHistoricoSolicitudesAutoEnumerar_To"), "."), 18, MidpointRounding.ToEven));
         AV39TFHistoricoSolicitudesCotizacion = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesCotizacion"), ".");
         AV40TFHistoricoSolicitudesCotizacion_To = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesCotizacion_To"), ".");
         AV41TFHistoricoSolicitudesTotal = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesTotal"), ".");
         AV42TFHistoricoSolicitudesTotal_To = NumberUtil.Val( GetPar( "TFHistoricoSolicitudesTotal_To"), ".");
         AV43TFHistoricoSolicitudServicioSolCoti = GetPar( "TFHistoricoSolicitudServicioSolCoti");
         AV44TFHistoricoSolicitudServicioSolCoti_Sel = GetPar( "TFHistoricoSolicitudServicioSolCoti_Sel");
         AV45TFHistoricoSolicitudServicioPFinal = NumberUtil.Val( GetPar( "TFHistoricoSolicitudServicioPFinal"), ".");
         AV46TFHistoricoSolicitudServicioPFinal_To = NumberUtil.Val( GetPar( "TFHistoricoSolicitudServicioPFinal_To"), ".");
         AV47TFEstadosSolTipo = GetPar( "TFEstadosSolTipo");
         AV48TFEstadosSolTipo_Sel = GetPar( "TFEstadosSolTipo_Sel");
         AV49TFEstadosSolNombre = GetPar( "TFEstadosSolNombre");
         AV50TFEstadosSolNombre_Sel = GetPar( "TFEstadosSolNombre_Sel");
         AV51TFHistoricoSolicitudesOtros1 = GetPar( "TFHistoricoSolicitudesOtros1");
         AV52TFHistoricoSolicitudesOtros1_Sel = GetPar( "TFHistoricoSolicitudesOtros1_Sel");
         AV53TFHistoricoSolicitudesOtros2 = GetPar( "TFHistoricoSolicitudesOtros2");
         AV54TFHistoricoSolicitudesOtros2_Sel = GetPar( "TFHistoricoSolicitudesOtros2_Sel");
         AV55TFHistoricoSolicitudesOtros3 = GetPar( "TFHistoricoSolicitudesOtros3");
         AV56TFHistoricoSolicitudesOtros3_Sel = GetPar( "TFHistoricoSolicitudesOtros3_Sel");
         AV57TFHistoricoSolicitudesFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFHistoricoSolicitudesFechaAlta"));
         AV58TFHistoricoSolicitudesFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFHistoricoSolicitudesFechaAlta_To"));
         AV62TFHistoricoSolicitudesFechaActualizacion = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoSolicitudesFechaActualizacion"));
         AV63TFHistoricoSolicitudesFechaActualizacion_To = context.localUtil.ParseDTimeParm( GetPar( "TFHistoricoSolicitudesFechaActualizacion_To"));
         AV67TFHistoricoSolicitudesFechaInstalacion = context.localUtil.ParseDateParm( GetPar( "TFHistoricoSolicitudesFechaInstalacion"));
         AV68TFHistoricoSolicitudesFechaInstalacion_To = context.localUtil.ParseDateParm( GetPar( "TFHistoricoSolicitudesFechaInstalacion_To"));
         AV72TFHistoricoSolicitudesHoraInstalacion = GetPar( "TFHistoricoSolicitudesHoraInstalacion");
         AV73TFHistoricoSolicitudesHoraInstalacion_Sel = GetPar( "TFHistoricoSolicitudesHoraInstalacion_Sel");
         AV74TFHistoricoSolicitudesComentario = GetPar( "TFHistoricoSolicitudesComentario");
         AV75TFHistoricoSolicitudesComentario_Sel = GetPar( "TFHistoricoSolicitudesComentario_Sel");
         AV76TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMetodoPagosID"), "."), 18, MidpointRounding.ToEven));
         AV77TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMetodoPagosID_To"), "."), 18, MidpointRounding.ToEven));
         AV78TFMetodoPagosNombre = GetPar( "TFMetodoPagosNombre");
         AV79TFMetodoPagosNombre_Sel = GetPar( "TFMetodoPagosNombre_Sel");
         AV80TFHistoricoSolicitudesNota = GetPar( "TFHistoricoSolicitudesNota");
         AV81TFHistoricoSolicitudesNota_Sel = GetPar( "TFHistoricoSolicitudesNota_Sel");
         AV82TFHistoricoSolicitudesNotificacion = GetPar( "TFHistoricoSolicitudesNotificacion");
         AV83TFHistoricoSolicitudesNotificacion_Sel = GetPar( "TFHistoricoSolicitudesNotificacion_Sel");
         AV84TFHistoricoSolicitudesOrigenPago = GetPar( "TFHistoricoSolicitudesOrigenPago");
         AV85TFHistoricoSolicitudesOrigenPago_Sel = GetPar( "TFHistoricoSolicitudesOrigenPago_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV87TFHistoricoSolicitudesPagado_Sels);
         AV99IsAuthorized_EstadosSolNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosSolNombre"));
         AV97IsAuthorized_MetodoPagosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_MetodoPagosNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA2Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV100Pgmname = "HistoricoRelacionesItemsWC";
               WS2Q2( ) ;
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor H002Q2 */
         pr_default.execute(0, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H002Q2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H002Q2_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(H002Q2_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(H002Q2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002Q2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])-(H002Q2_A298HistoricoSolicitudesItemsComis[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H002Q2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002Q2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])+(H002Q2_A298HistoricoSolicitudesItemsComis[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H002Q2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002Q2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])-((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])*(H002Q2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H002Q2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002Q2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])+((H002Q2_A295HItemsInventarioPrecioFinal[0]*H002Q2_A293HItemsSolicitudesItemsCantidad[0])*(H002Q2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
            context.SendWebValue( context.GetMessage( "Historico Relaciones Items WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GXEncryptionTmp = "historicorelacionesitemswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8HistoricoSolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicorelacionesitemswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( sPrefix, AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_METODOPAGOSNOMBRE", AV97IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( sPrefix, AV97IsAuthorized_MetodoPagosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_33), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV93GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV88DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV88DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAALTAAUXDATETO", context.localUtil.DToC( AV60DDO_HistoricoSolicitudesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATETO", context.localUtil.DToC( AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATETO", context.localUtil.DToC( AV70DDO_HistoricoSolicitudesFechaInstalacionAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOMBRE", StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOMBRE_SEL", StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESTELEFONO", StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESTELEFONO_SEL", StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESMAIL", AV25TFHistoricoSolicitudesMail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESMAIL_SEL", AV26TFHistoricoSolicitudesMail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOPAISID", StringUtil.RTrim( AV27TFHistoricoPaisID));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOPAISID_SEL", StringUtil.RTrim( AV28TFHistoricoPaisID_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICODEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICODEPARTAMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICODEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFHistoricoZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOZONASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFHistoricoZonasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESDIRECCION", AV35TFHistoricoSolicitudesDireccion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESDIRECCION_SEL", AV36TFHistoricoSolicitudesDireccion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESAUTOENUMERAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESCOTIZACION", StringUtil.LTrim( StringUtil.NToC( AV39TFHistoricoSolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESCOTIZACION_TO", StringUtil.LTrim( StringUtil.NToC( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESTOTAL", StringUtil.LTrim( StringUtil.NToC( AV41TFHistoricoSolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESTOTAL_TO", StringUtil.LTrim( StringUtil.NToC( AV42TFHistoricoSolicitudesTotal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDSERVICIOSOLCOTI", StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL", StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDSERVICIOPFINAL", StringUtil.LTrim( StringUtil.NToC( AV45TFHistoricoSolicitudServicioPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSSOLTIPO", StringUtil.RTrim( AV47TFEstadosSolTipo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSSOLTIPO_SEL", StringUtil.RTrim( AV48TFEstadosSolTipo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSSOLNOMBRE", StringUtil.RTrim( AV49TFEstadosSolNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSSOLNOMBRE_SEL", StringUtil.RTrim( AV50TFEstadosSolNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS1", StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS1_SEL", StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS2", StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS2_SEL", StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS3", StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESOTROS3_SEL", StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAALTA", context.localUtil.DToC( AV57TFHistoricoSolicitudesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAALTA_TO", context.localUtil.DToC( AV58TFHistoricoSolicitudesFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAACTUALIZACION", context.localUtil.TToC( AV62TFHistoricoSolicitudesFechaActualizacion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO", context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAINSTALACION", context.localUtil.DToC( AV67TFHistoricoSolicitudesFechaInstalacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO", context.localUtil.DToC( AV68TFHistoricoSolicitudesFechaInstalacion_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESHORAINSTALACION", StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL", StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESCOMENTARIO", AV74TFHistoricoSolicitudesComentario);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESCOMENTARIO_SEL", AV75TFHistoricoSolicitudesComentario_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMETODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV76TFMetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMETODOPAGOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77TFMetodoPagosID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMETODOPAGOSNOMBRE", StringUtil.RTrim( AV78TFMetodoPagosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFMETODOPAGOSNOMBRE_SEL", StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOTA", StringUtil.RTrim( AV80TFHistoricoSolicitudesNota));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOTA_SEL", StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOTIFICACION", StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESNOTIFICACION_SEL", StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESORIGENPAGO", StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESORIGENPAGO_SEL", StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFHISTORICOSOLICITUDESPAGADO_SELS", AV87TFHistoricoSolicitudesPagado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFHISTORICOSOLICITUDESPAGADO_SELS", AV87TFHistoricoSolicitudesPagado_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( sPrefix, AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_METODOPAGOSNOMBRE", AV97IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( sPrefix, AV97IsAuthorized_MetodoPagosNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFHISTORICOSOLICITUDESPAGADO_SELSJSON", AV86TFHistoricoSolicitudesPagado_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAALTAAUXDATE", context.localUtil.DToC( AV59DDO_HistoricoSolicitudesFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATE", context.localUtil.DToC( AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATE", context.localUtil.DToC( AV69DDO_HistoricoSolicitudesFechaInstalacionAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2Q2( )
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
         return "HistoricoRelacionesItemsWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Relaciones Items WC", "") ;
      }

      protected void WB2Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "historicorelacionesitemswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_18_2Q2( true) ;
         }
         else
         {
            wb_table1_18_2Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_18_2Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl33( ) ;
         }
         if ( wbEnd == 33 )
         {
            wbEnd = 0;
            nRC_GXsfl_33 = (int)(nGXsfl_33_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV91GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV92GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV93GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV88DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "Attribute", "", "", "", "", edtHistoricoSolicitudesID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoRelacionesItemsWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_historicosolicitudesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_historicosolicitudesfechaaltaauxdatetext_Internalname, AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_historicosolicitudesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelacionesItemsWC.htm");
            /* User Defined Control */
            ucTfhistoricosolicitudesfechaalta_rangepicker.SetProperty("Start Date", AV59DDO_HistoricoSolicitudesFechaAltaAuxDate);
            ucTfhistoricosolicitudesfechaalta_rangepicker.SetProperty("End Date", AV60DDO_HistoricoSolicitudesFechaAltaAuxDateTo);
            ucTfhistoricosolicitudesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfhistoricosolicitudesfechaalta_rangepicker_Internalname, sPrefix+"TFHISTORICOSOLICITUDESFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_historicosolicitudesfechaactualizacionauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Internalname, AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelacionesItemsWC.htm");
            /* User Defined Control */
            ucTfhistoricosolicitudesfechaactualizacion_rangepicker.SetProperty("Start Date", AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate);
            ucTfhistoricosolicitudesfechaactualizacion_rangepicker.SetProperty("End Date", AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo);
            ucTfhistoricosolicitudesfechaactualizacion_rangepicker.Render(context, "wwp.daterangepicker", Tfhistoricosolicitudesfechaactualizacion_rangepicker_Internalname, sPrefix+"TFHISTORICOSOLICITUDESFECHAACTUALIZACION_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_historicosolicitudesfechainstalacionauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Internalname, AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoRelacionesItemsWC.htm");
            /* User Defined Control */
            ucTfhistoricosolicitudesfechainstalacion_rangepicker.SetProperty("Start Date", AV69DDO_HistoricoSolicitudesFechaInstalacionAuxDate);
            ucTfhistoricosolicitudesfechainstalacion_rangepicker.SetProperty("End Date", AV70DDO_HistoricoSolicitudesFechaInstalacionAuxDateTo);
            ucTfhistoricosolicitudesfechainstalacion_rangepicker.Render(context, "wwp.daterangepicker", Tfhistoricosolicitudesfechainstalacion_rangepicker_Internalname, sPrefix+"TFHISTORICOSOLICITUDESFECHAINSTALACION_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 33 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Historico Relaciones Items WC", ""), 0) ;
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
               STRUP2Q0( ) ;
            }
         }
      }

      protected void WS2Q2( )
      {
         START2Q2( ) ;
         EVT2Q2( ) ;
      }

      protected void EVT2Q2( )
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
                                 STRUP2Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E112Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E122Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E132Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E142Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
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
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Q0( ) ;
                              }
                              nGXsfl_33_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
                              SubsflControlProps_332( ) ;
                              A288HistoricoSolicitudesNombre = cgiGet( edtHistoricoSolicitudesNombre_Internalname);
                              A289HistoricoSolicitudesTelefono = cgiGet( edtHistoricoSolicitudesTelefono_Internalname);
                              A290HistoricoSolicitudesMail = cgiGet( edtHistoricoSolicitudesMail_Internalname);
                              n290HistoricoSolicitudesMail = false;
                              A315HistoricoPaisID = cgiGet( edtHistoricoPaisID_Internalname);
                              A316HistoricoDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A317HistoricoDepartamentoMunicipio = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoMunicipio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A318HistoricoZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n318HistoricoZonasID = false;
                              A291HistoricoSolicitudesDireccion = cgiGet( edtHistoricoSolicitudesDireccion_Internalname);
                              A292HistoricoSolicitudesAutoEnumer = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesAutoEnumer_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A299HistoricoSolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A300HistoricoSolicitudesTotal = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A301HistoricoSolicitudServicioSolC = cgiGet( edtHistoricoSolicitudServicioSolC_Internalname);
                              A302HistoricoSolicitudServicioPFin = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudServicioPFin_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
                              A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A132EstadosSolNombre = cgiGet( edtEstadosSolNombre_Internalname);
                              A303HistoricoSolicitudesOtros1 = cgiGet( edtHistoricoSolicitudesOtros1_Internalname);
                              A304HistoricoSolicitudesOtros2 = cgiGet( edtHistoricoSolicitudesOtros2_Internalname);
                              A305HistoricoSolicitudesOtros3 = cgiGet( edtHistoricoSolicitudesOtros3_Internalname);
                              A306HistoricoSolicitudesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaAlta_Internalname), 0));
                              A307HistoricoSolicitudesFechaActua = context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaActua_Internalname), 0);
                              A308HistoricoSolicitudesFechaInsta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaInsta_Internalname), 0));
                              A309HistoricoSolicitudesHoraInstal = cgiGet( edtHistoricoSolicitudesHoraInstal_Internalname);
                              A310HistoricoSolicitudesComentario = cgiGet( edtHistoricoSolicitudesComentario_Internalname);
                              A128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A129MetodoPagosNombre = cgiGet( edtMetodoPagosNombre_Internalname);
                              A311HistoricoSolicitudesNota = cgiGet( edtHistoricoSolicitudesNota_Internalname);
                              A312HistoricoSolicitudesNotificaci = cgiGet( edtHistoricoSolicitudesNotificaci_Internalname);
                              A439HistoricoSolicitudesOrigenPago = cgiGet( edtHistoricoSolicitudesOrigenPago_Internalname);
                              cmbHistoricoSolicitudesPagado.Name = cmbHistoricoSolicitudesPagado_Internalname;
                              cmbHistoricoSolicitudesPagado.CurrentValue = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
                              A442HistoricoSolicitudesPagado = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E152Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E162Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E172Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP2Q0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE2Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Q2( ) ;
            }
         }
      }

      protected void PA2Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicorelacionesitemswc.aspx")), "historicorelacionesitemswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicorelacionesitemswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_332( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            sendrow_332( ) ;
            nGXsfl_33_idx = ((subGrid_Islastpage==1)&&(nGXsfl_33_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       long AV8HistoricoSolicitudesID ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV100Pgmname ,
                                       string AV21TFHistoricoSolicitudesNombre ,
                                       string AV22TFHistoricoSolicitudesNombre_Sel ,
                                       string AV23TFHistoricoSolicitudesTelefono ,
                                       string AV24TFHistoricoSolicitudesTelefono_Sel ,
                                       string AV25TFHistoricoSolicitudesMail ,
                                       string AV26TFHistoricoSolicitudesMail_Sel ,
                                       string AV27TFHistoricoPaisID ,
                                       string AV28TFHistoricoPaisID_Sel ,
                                       long AV29TFHistoricoDepartamentoId ,
                                       long AV30TFHistoricoDepartamentoId_To ,
                                       long AV31TFHistoricoDepartamentoMunicipioId ,
                                       long AV32TFHistoricoDepartamentoMunicipioId_To ,
                                       long AV33TFHistoricoZonasID ,
                                       long AV34TFHistoricoZonasID_To ,
                                       string AV35TFHistoricoSolicitudesDireccion ,
                                       string AV36TFHistoricoSolicitudesDireccion_Sel ,
                                       short AV37TFHistoricoSolicitudesAutoEnumerar ,
                                       short AV38TFHistoricoSolicitudesAutoEnumerar_To ,
                                       decimal AV39TFHistoricoSolicitudesCotizacion ,
                                       decimal AV40TFHistoricoSolicitudesCotizacion_To ,
                                       decimal AV41TFHistoricoSolicitudesTotal ,
                                       decimal AV42TFHistoricoSolicitudesTotal_To ,
                                       string AV43TFHistoricoSolicitudServicioSolCoti ,
                                       string AV44TFHistoricoSolicitudServicioSolCoti_Sel ,
                                       decimal AV45TFHistoricoSolicitudServicioPFinal ,
                                       decimal AV46TFHistoricoSolicitudServicioPFinal_To ,
                                       string AV47TFEstadosSolTipo ,
                                       string AV48TFEstadosSolTipo_Sel ,
                                       string AV49TFEstadosSolNombre ,
                                       string AV50TFEstadosSolNombre_Sel ,
                                       string AV51TFHistoricoSolicitudesOtros1 ,
                                       string AV52TFHistoricoSolicitudesOtros1_Sel ,
                                       string AV53TFHistoricoSolicitudesOtros2 ,
                                       string AV54TFHistoricoSolicitudesOtros2_Sel ,
                                       string AV55TFHistoricoSolicitudesOtros3 ,
                                       string AV56TFHistoricoSolicitudesOtros3_Sel ,
                                       DateTime AV57TFHistoricoSolicitudesFechaAlta ,
                                       DateTime AV58TFHistoricoSolicitudesFechaAlta_To ,
                                       DateTime AV62TFHistoricoSolicitudesFechaActualizacion ,
                                       DateTime AV63TFHistoricoSolicitudesFechaActualizacion_To ,
                                       DateTime AV67TFHistoricoSolicitudesFechaInstalacion ,
                                       DateTime AV68TFHistoricoSolicitudesFechaInstalacion_To ,
                                       string AV72TFHistoricoSolicitudesHoraInstalacion ,
                                       string AV73TFHistoricoSolicitudesHoraInstalacion_Sel ,
                                       string AV74TFHistoricoSolicitudesComentario ,
                                       string AV75TFHistoricoSolicitudesComentario_Sel ,
                                       long AV76TFMetodoPagosID ,
                                       long AV77TFMetodoPagosID_To ,
                                       string AV78TFMetodoPagosNombre ,
                                       string AV79TFMetodoPagosNombre_Sel ,
                                       string AV80TFHistoricoSolicitudesNota ,
                                       string AV81TFHistoricoSolicitudesNota_Sel ,
                                       string AV82TFHistoricoSolicitudesNotificacion ,
                                       string AV83TFHistoricoSolicitudesNotificacion_Sel ,
                                       string AV84TFHistoricoSolicitudesOrigenPago ,
                                       string AV85TFHistoricoSolicitudesOrigenPago_Sel ,
                                       GxSimpleCollection<string> AV87TFHistoricoSolicitudesPagado_Sels ,
                                       bool AV99IsAuthorized_EstadosSolNombre ,
                                       bool AV97IsAuthorized_MetodoPagosNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2Q2( ) ;
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
         RF2Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV100Pgmname = "HistoricoRelacionesItemsWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A442HistoricoSolicitudesPagado ,
                                              AV87TFHistoricoSolicitudesPagado_Sels ,
                                              AV22TFHistoricoSolicitudesNombre_Sel ,
                                              AV21TFHistoricoSolicitudesNombre ,
                                              AV24TFHistoricoSolicitudesTelefono_Sel ,
                                              AV23TFHistoricoSolicitudesTelefono ,
                                              AV26TFHistoricoSolicitudesMail_Sel ,
                                              AV25TFHistoricoSolicitudesMail ,
                                              AV28TFHistoricoPaisID_Sel ,
                                              AV27TFHistoricoPaisID ,
                                              AV29TFHistoricoDepartamentoId ,
                                              AV30TFHistoricoDepartamentoId_To ,
                                              AV31TFHistoricoDepartamentoMunicipioId ,
                                              AV32TFHistoricoDepartamentoMunicipioId_To ,
                                              AV33TFHistoricoZonasID ,
                                              AV34TFHistoricoZonasID_To ,
                                              AV36TFHistoricoSolicitudesDireccion_Sel ,
                                              AV35TFHistoricoSolicitudesDireccion ,
                                              AV37TFHistoricoSolicitudesAutoEnumerar ,
                                              AV38TFHistoricoSolicitudesAutoEnumerar_To ,
                                              AV39TFHistoricoSolicitudesCotizacion ,
                                              AV40TFHistoricoSolicitudesCotizacion_To ,
                                              AV41TFHistoricoSolicitudesTotal ,
                                              AV42TFHistoricoSolicitudesTotal_To ,
                                              AV44TFHistoricoSolicitudServicioSolCoti_Sel ,
                                              AV43TFHistoricoSolicitudServicioSolCoti ,
                                              AV48TFEstadosSolTipo_Sel ,
                                              AV47TFEstadosSolTipo ,
                                              AV50TFEstadosSolNombre_Sel ,
                                              AV49TFEstadosSolNombre ,
                                              AV52TFHistoricoSolicitudesOtros1_Sel ,
                                              AV51TFHistoricoSolicitudesOtros1 ,
                                              AV54TFHistoricoSolicitudesOtros2_Sel ,
                                              AV53TFHistoricoSolicitudesOtros2 ,
                                              AV56TFHistoricoSolicitudesOtros3_Sel ,
                                              AV55TFHistoricoSolicitudesOtros3 ,
                                              AV57TFHistoricoSolicitudesFechaAlta ,
                                              AV58TFHistoricoSolicitudesFechaAlta_To ,
                                              AV62TFHistoricoSolicitudesFechaActualizacion ,
                                              AV63TFHistoricoSolicitudesFechaActualizacion_To ,
                                              AV67TFHistoricoSolicitudesFechaInstalacion ,
                                              AV68TFHistoricoSolicitudesFechaInstalacion_To ,
                                              AV73TFHistoricoSolicitudesHoraInstalacion_Sel ,
                                              AV72TFHistoricoSolicitudesHoraInstalacion ,
                                              AV75TFHistoricoSolicitudesComentario_Sel ,
                                              AV74TFHistoricoSolicitudesComentario ,
                                              AV76TFMetodoPagosID ,
                                              AV77TFMetodoPagosID_To ,
                                              AV79TFMetodoPagosNombre_Sel ,
                                              AV78TFMetodoPagosNombre ,
                                              AV81TFHistoricoSolicitudesNota_Sel ,
                                              AV80TFHistoricoSolicitudesNota ,
                                              AV83TFHistoricoSolicitudesNotificacion_Sel ,
                                              AV82TFHistoricoSolicitudesNotificacion ,
                                              AV85TFHistoricoSolicitudesOrigenPago_Sel ,
                                              AV84TFHistoricoSolicitudesOrigenPago ,
                                              AV87TFHistoricoSolicitudesPagado_Sels.Count ,
                                              A288HistoricoSolicitudesNombre ,
                                              A289HistoricoSolicitudesTelefono ,
                                              A290HistoricoSolicitudesMail ,
                                              A315HistoricoPaisID ,
                                              A316HistoricoDepartamentoId ,
                                              A317HistoricoDepartamentoMunicipio ,
                                              A318HistoricoZonasID ,
                                              A291HistoricoSolicitudesDireccion ,
                                              A292HistoricoSolicitudesAutoEnumer ,
                                              A299HistoricoSolicitudesCotizacion ,
                                              A300HistoricoSolicitudesTotal ,
                                              A301HistoricoSolicitudServicioSolC ,
                                              A130EstadosSolTipo ,
                                              A132EstadosSolNombre ,
                                              A303HistoricoSolicitudesOtros1 ,
                                              A304HistoricoSolicitudesOtros2 ,
                                              A305HistoricoSolicitudesOtros3 ,
                                              A306HistoricoSolicitudesFechaAlta ,
                                              A307HistoricoSolicitudesFechaActua ,
                                              A308HistoricoSolicitudesFechaInsta ,
                                              A309HistoricoSolicitudesHoraInstal ,
                                              A310HistoricoSolicitudesComentario ,
                                              A128MetodoPagosID ,
                                              A129MetodoPagosNombre ,
                                              A311HistoricoSolicitudesNota ,
                                              A312HistoricoSolicitudesNotificaci ,
                                              A439HistoricoSolicitudesOrigenPago ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              A302HistoricoSolicitudServicioPFin ,
                                              AV45TFHistoricoSolicitudServicioPFinal ,
                                              AV46TFHistoricoSolicitudServicioPFinal_To ,
                                              AV8HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV21TFHistoricoSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre), 100, "%");
         lV23TFHistoricoSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono), 20, "%");
         lV25TFHistoricoSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV25TFHistoricoSolicitudesMail), "%", "");
         lV27TFHistoricoPaisID = StringUtil.PadR( StringUtil.RTrim( AV27TFHistoricoPaisID), 2, "%");
         lV35TFHistoricoSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion), "%", "");
         lV43TFHistoricoSolicitudServicioSolCoti = StringUtil.PadR( StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti), 1, "%");
         lV47TFEstadosSolTipo = StringUtil.PadR( StringUtil.RTrim( AV47TFEstadosSolTipo), 3, "%");
         lV49TFEstadosSolNombre = StringUtil.PadR( StringUtil.RTrim( AV49TFEstadosSolNombre), 80, "%");
         lV51TFHistoricoSolicitudesOtros1 = StringUtil.PadR( StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1), 1, "%");
         lV53TFHistoricoSolicitudesOtros2 = StringUtil.PadR( StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2), 1000, "%");
         lV55TFHistoricoSolicitudesOtros3 = StringUtil.PadR( StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3), 500, "%");
         lV72TFHistoricoSolicitudesHoraInstalacion = StringUtil.PadR( StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion), 1, "%");
         lV74TFHistoricoSolicitudesComentario = StringUtil.Concat( StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario), "%", "");
         lV78TFMetodoPagosNombre = StringUtil.PadR( StringUtil.RTrim( AV78TFMetodoPagosNombre), 80, "%");
         lV80TFHistoricoSolicitudesNota = StringUtil.PadR( StringUtil.RTrim( AV80TFHistoricoSolicitudesNota), 500, "%");
         lV82TFHistoricoSolicitudesNotificacion = StringUtil.PadR( StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion), 1, "%");
         lV84TFHistoricoSolicitudesOrigenPago = StringUtil.PadR( StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago), 1, "%");
         /* Using cursor H002Q3 */
         pr_default.execute(1, new Object[] {AV8HistoricoSolicitudesID, lV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, lV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, lV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, lV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, lV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, lV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, lV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, lV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, lV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, lV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, lV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, lV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, lV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, lV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, lV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, lV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, lV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A153HistoricoSolicitudesID = H002Q3_A153HistoricoSolicitudesID[0];
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            A442HistoricoSolicitudesPagado = H002Q3_A442HistoricoSolicitudesPagado[0];
            A439HistoricoSolicitudesOrigenPago = H002Q3_A439HistoricoSolicitudesOrigenPago[0];
            A312HistoricoSolicitudesNotificaci = H002Q3_A312HistoricoSolicitudesNotificaci[0];
            A311HistoricoSolicitudesNota = H002Q3_A311HistoricoSolicitudesNota[0];
            A129MetodoPagosNombre = H002Q3_A129MetodoPagosNombre[0];
            A128MetodoPagosID = H002Q3_A128MetodoPagosID[0];
            A310HistoricoSolicitudesComentario = H002Q3_A310HistoricoSolicitudesComentario[0];
            A309HistoricoSolicitudesHoraInstal = H002Q3_A309HistoricoSolicitudesHoraInstal[0];
            A308HistoricoSolicitudesFechaInsta = H002Q3_A308HistoricoSolicitudesFechaInsta[0];
            A307HistoricoSolicitudesFechaActua = H002Q3_A307HistoricoSolicitudesFechaActua[0];
            A306HistoricoSolicitudesFechaAlta = H002Q3_A306HistoricoSolicitudesFechaAlta[0];
            A305HistoricoSolicitudesOtros3 = H002Q3_A305HistoricoSolicitudesOtros3[0];
            A304HistoricoSolicitudesOtros2 = H002Q3_A304HistoricoSolicitudesOtros2[0];
            A303HistoricoSolicitudesOtros1 = H002Q3_A303HistoricoSolicitudesOtros1[0];
            A132EstadosSolNombre = H002Q3_A132EstadosSolNombre[0];
            A131EstadosSolId = H002Q3_A131EstadosSolId[0];
            A130EstadosSolTipo = H002Q3_A130EstadosSolTipo[0];
            A301HistoricoSolicitudServicioSolC = H002Q3_A301HistoricoSolicitudServicioSolC[0];
            A292HistoricoSolicitudesAutoEnumer = H002Q3_A292HistoricoSolicitudesAutoEnumer[0];
            A291HistoricoSolicitudesDireccion = H002Q3_A291HistoricoSolicitudesDireccion[0];
            A318HistoricoZonasID = H002Q3_A318HistoricoZonasID[0];
            n318HistoricoZonasID = H002Q3_n318HistoricoZonasID[0];
            A317HistoricoDepartamentoMunicipio = H002Q3_A317HistoricoDepartamentoMunicipio[0];
            A316HistoricoDepartamentoId = H002Q3_A316HistoricoDepartamentoId[0];
            A315HistoricoPaisID = H002Q3_A315HistoricoPaisID[0];
            A290HistoricoSolicitudesMail = H002Q3_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = H002Q3_n290HistoricoSolicitudesMail[0];
            A289HistoricoSolicitudesTelefono = H002Q3_A289HistoricoSolicitudesTelefono[0];
            A288HistoricoSolicitudesNombre = H002Q3_A288HistoricoSolicitudesNombre[0];
            A299HistoricoSolicitudesCotizacion = H002Q3_A299HistoricoSolicitudesCotizacion[0];
            A129MetodoPagosNombre = H002Q3_A129MetodoPagosNombre[0];
            A132EstadosSolNombre = H002Q3_A132EstadosSolNombre[0];
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A315HistoricoPaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A316HistoricoDepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A318HistoricoZonasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A299HistoricoSolicitudesCotizacion, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A300HistoricoSolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A301HistoricoSolicitudServicioSolC) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A130EstadosSolTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A132EstadosSolNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A303HistoricoSolicitudesOtros1) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A304HistoricoSolicitudesOtros2) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A305HistoricoSolicitudesOtros3) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A309HistoricoSolicitudesHoraInstal) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A310HistoricoSolicitudesComentario) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A129MetodoPagosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A311HistoricoSolicitudesNota) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A312HistoricoSolicitudesNotificaci) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A439HistoricoSolicitudesOrigenPago) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "pagado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A442HistoricoSolicitudesPagado, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente de pago", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A442HistoricoSolicitudesPagado, "N") == 0 ) ) )
            )
            {
               if ( (Convert.ToDecimal(0)==AV45TFHistoricoSolicitudServicioPFinal) || ( ( A302HistoricoSolicitudServicioPFin >= AV45TFHistoricoSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV46TFHistoricoSolicitudServicioPFinal_To) || ( ( A302HistoricoSolicitudServicioPFin <= AV46TFHistoricoSolicitudServicioPFinal_To ) ) )
                  {
                     GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF2Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 33;
         /* Execute user event: Refresh */
         E162Q2 ();
         nGXsfl_33_idx = 1;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_332( ) ;
         bGXsfl_33_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_332( ) ;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A442HistoricoSolicitudesPagado ,
                                                 AV87TFHistoricoSolicitudesPagado_Sels ,
                                                 AV22TFHistoricoSolicitudesNombre_Sel ,
                                                 AV21TFHistoricoSolicitudesNombre ,
                                                 AV24TFHistoricoSolicitudesTelefono_Sel ,
                                                 AV23TFHistoricoSolicitudesTelefono ,
                                                 AV26TFHistoricoSolicitudesMail_Sel ,
                                                 AV25TFHistoricoSolicitudesMail ,
                                                 AV28TFHistoricoPaisID_Sel ,
                                                 AV27TFHistoricoPaisID ,
                                                 AV29TFHistoricoDepartamentoId ,
                                                 AV30TFHistoricoDepartamentoId_To ,
                                                 AV31TFHistoricoDepartamentoMunicipioId ,
                                                 AV32TFHistoricoDepartamentoMunicipioId_To ,
                                                 AV33TFHistoricoZonasID ,
                                                 AV34TFHistoricoZonasID_To ,
                                                 AV36TFHistoricoSolicitudesDireccion_Sel ,
                                                 AV35TFHistoricoSolicitudesDireccion ,
                                                 AV37TFHistoricoSolicitudesAutoEnumerar ,
                                                 AV38TFHistoricoSolicitudesAutoEnumerar_To ,
                                                 AV39TFHistoricoSolicitudesCotizacion ,
                                                 AV40TFHistoricoSolicitudesCotizacion_To ,
                                                 AV41TFHistoricoSolicitudesTotal ,
                                                 AV42TFHistoricoSolicitudesTotal_To ,
                                                 AV44TFHistoricoSolicitudServicioSolCoti_Sel ,
                                                 AV43TFHistoricoSolicitudServicioSolCoti ,
                                                 AV48TFEstadosSolTipo_Sel ,
                                                 AV47TFEstadosSolTipo ,
                                                 AV50TFEstadosSolNombre_Sel ,
                                                 AV49TFEstadosSolNombre ,
                                                 AV52TFHistoricoSolicitudesOtros1_Sel ,
                                                 AV51TFHistoricoSolicitudesOtros1 ,
                                                 AV54TFHistoricoSolicitudesOtros2_Sel ,
                                                 AV53TFHistoricoSolicitudesOtros2 ,
                                                 AV56TFHistoricoSolicitudesOtros3_Sel ,
                                                 AV55TFHistoricoSolicitudesOtros3 ,
                                                 AV57TFHistoricoSolicitudesFechaAlta ,
                                                 AV58TFHistoricoSolicitudesFechaAlta_To ,
                                                 AV62TFHistoricoSolicitudesFechaActualizacion ,
                                                 AV63TFHistoricoSolicitudesFechaActualizacion_To ,
                                                 AV67TFHistoricoSolicitudesFechaInstalacion ,
                                                 AV68TFHistoricoSolicitudesFechaInstalacion_To ,
                                                 AV73TFHistoricoSolicitudesHoraInstalacion_Sel ,
                                                 AV72TFHistoricoSolicitudesHoraInstalacion ,
                                                 AV75TFHistoricoSolicitudesComentario_Sel ,
                                                 AV74TFHistoricoSolicitudesComentario ,
                                                 AV76TFMetodoPagosID ,
                                                 AV77TFMetodoPagosID_To ,
                                                 AV79TFMetodoPagosNombre_Sel ,
                                                 AV78TFMetodoPagosNombre ,
                                                 AV81TFHistoricoSolicitudesNota_Sel ,
                                                 AV80TFHistoricoSolicitudesNota ,
                                                 AV83TFHistoricoSolicitudesNotificacion_Sel ,
                                                 AV82TFHistoricoSolicitudesNotificacion ,
                                                 AV85TFHistoricoSolicitudesOrigenPago_Sel ,
                                                 AV84TFHistoricoSolicitudesOrigenPago ,
                                                 AV87TFHistoricoSolicitudesPagado_Sels.Count ,
                                                 A288HistoricoSolicitudesNombre ,
                                                 A289HistoricoSolicitudesTelefono ,
                                                 A290HistoricoSolicitudesMail ,
                                                 A315HistoricoPaisID ,
                                                 A316HistoricoDepartamentoId ,
                                                 A317HistoricoDepartamentoMunicipio ,
                                                 A318HistoricoZonasID ,
                                                 A291HistoricoSolicitudesDireccion ,
                                                 A292HistoricoSolicitudesAutoEnumer ,
                                                 A299HistoricoSolicitudesCotizacion ,
                                                 A300HistoricoSolicitudesTotal ,
                                                 A301HistoricoSolicitudServicioSolC ,
                                                 A130EstadosSolTipo ,
                                                 A132EstadosSolNombre ,
                                                 A303HistoricoSolicitudesOtros1 ,
                                                 A304HistoricoSolicitudesOtros2 ,
                                                 A305HistoricoSolicitudesOtros3 ,
                                                 A306HistoricoSolicitudesFechaAlta ,
                                                 A307HistoricoSolicitudesFechaActua ,
                                                 A308HistoricoSolicitudesFechaInsta ,
                                                 A309HistoricoSolicitudesHoraInstal ,
                                                 A310HistoricoSolicitudesComentario ,
                                                 A128MetodoPagosID ,
                                                 A129MetodoPagosNombre ,
                                                 A311HistoricoSolicitudesNota ,
                                                 A312HistoricoSolicitudesNotificaci ,
                                                 A439HistoricoSolicitudesOrigenPago ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 A302HistoricoSolicitudServicioPFin ,
                                                 AV45TFHistoricoSolicitudServicioPFinal ,
                                                 AV46TFHistoricoSolicitudServicioPFinal_To ,
                                                 AV8HistoricoSolicitudesID ,
                                                 A153HistoricoSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV21TFHistoricoSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre), 100, "%");
            lV23TFHistoricoSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono), 20, "%");
            lV25TFHistoricoSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV25TFHistoricoSolicitudesMail), "%", "");
            lV27TFHistoricoPaisID = StringUtil.PadR( StringUtil.RTrim( AV27TFHistoricoPaisID), 2, "%");
            lV35TFHistoricoSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion), "%", "");
            lV43TFHistoricoSolicitudServicioSolCoti = StringUtil.PadR( StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti), 1, "%");
            lV47TFEstadosSolTipo = StringUtil.PadR( StringUtil.RTrim( AV47TFEstadosSolTipo), 3, "%");
            lV49TFEstadosSolNombre = StringUtil.PadR( StringUtil.RTrim( AV49TFEstadosSolNombre), 80, "%");
            lV51TFHistoricoSolicitudesOtros1 = StringUtil.PadR( StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1), 1, "%");
            lV53TFHistoricoSolicitudesOtros2 = StringUtil.PadR( StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2), 1000, "%");
            lV55TFHistoricoSolicitudesOtros3 = StringUtil.PadR( StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3), 500, "%");
            lV72TFHistoricoSolicitudesHoraInstalacion = StringUtil.PadR( StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion), 1, "%");
            lV74TFHistoricoSolicitudesComentario = StringUtil.Concat( StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario), "%", "");
            lV78TFMetodoPagosNombre = StringUtil.PadR( StringUtil.RTrim( AV78TFMetodoPagosNombre), 80, "%");
            lV80TFHistoricoSolicitudesNota = StringUtil.PadR( StringUtil.RTrim( AV80TFHistoricoSolicitudesNota), 500, "%");
            lV82TFHistoricoSolicitudesNotificacion = StringUtil.PadR( StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion), 1, "%");
            lV84TFHistoricoSolicitudesOrigenPago = StringUtil.PadR( StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago), 1, "%");
            /* Using cursor H002Q4 */
            pr_default.execute(2, new Object[] {AV8HistoricoSolicitudesID, lV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, lV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, lV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, lV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, lV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, lV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, lV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, lV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, lV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, lV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, lV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, lV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, lV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, lV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, lV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, lV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, lV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel});
            nGXsfl_33_idx = 1;
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A153HistoricoSolicitudesID = H002Q4_A153HistoricoSolicitudesID[0];
               AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               A442HistoricoSolicitudesPagado = H002Q4_A442HistoricoSolicitudesPagado[0];
               A439HistoricoSolicitudesOrigenPago = H002Q4_A439HistoricoSolicitudesOrigenPago[0];
               A312HistoricoSolicitudesNotificaci = H002Q4_A312HistoricoSolicitudesNotificaci[0];
               A311HistoricoSolicitudesNota = H002Q4_A311HistoricoSolicitudesNota[0];
               A129MetodoPagosNombre = H002Q4_A129MetodoPagosNombre[0];
               A128MetodoPagosID = H002Q4_A128MetodoPagosID[0];
               A310HistoricoSolicitudesComentario = H002Q4_A310HistoricoSolicitudesComentario[0];
               A309HistoricoSolicitudesHoraInstal = H002Q4_A309HistoricoSolicitudesHoraInstal[0];
               A308HistoricoSolicitudesFechaInsta = H002Q4_A308HistoricoSolicitudesFechaInsta[0];
               A307HistoricoSolicitudesFechaActua = H002Q4_A307HistoricoSolicitudesFechaActua[0];
               A306HistoricoSolicitudesFechaAlta = H002Q4_A306HistoricoSolicitudesFechaAlta[0];
               A305HistoricoSolicitudesOtros3 = H002Q4_A305HistoricoSolicitudesOtros3[0];
               A304HistoricoSolicitudesOtros2 = H002Q4_A304HistoricoSolicitudesOtros2[0];
               A303HistoricoSolicitudesOtros1 = H002Q4_A303HistoricoSolicitudesOtros1[0];
               A132EstadosSolNombre = H002Q4_A132EstadosSolNombre[0];
               A131EstadosSolId = H002Q4_A131EstadosSolId[0];
               A130EstadosSolTipo = H002Q4_A130EstadosSolTipo[0];
               A301HistoricoSolicitudServicioSolC = H002Q4_A301HistoricoSolicitudServicioSolC[0];
               A292HistoricoSolicitudesAutoEnumer = H002Q4_A292HistoricoSolicitudesAutoEnumer[0];
               A291HistoricoSolicitudesDireccion = H002Q4_A291HistoricoSolicitudesDireccion[0];
               A318HistoricoZonasID = H002Q4_A318HistoricoZonasID[0];
               n318HistoricoZonasID = H002Q4_n318HistoricoZonasID[0];
               A317HistoricoDepartamentoMunicipio = H002Q4_A317HistoricoDepartamentoMunicipio[0];
               A316HistoricoDepartamentoId = H002Q4_A316HistoricoDepartamentoId[0];
               A315HistoricoPaisID = H002Q4_A315HistoricoPaisID[0];
               A290HistoricoSolicitudesMail = H002Q4_A290HistoricoSolicitudesMail[0];
               n290HistoricoSolicitudesMail = H002Q4_n290HistoricoSolicitudesMail[0];
               A289HistoricoSolicitudesTelefono = H002Q4_A289HistoricoSolicitudesTelefono[0];
               A288HistoricoSolicitudesNombre = H002Q4_A288HistoricoSolicitudesNombre[0];
               A299HistoricoSolicitudesCotizacion = H002Q4_A299HistoricoSolicitudesCotizacion[0];
               A129MetodoPagosNombre = H002Q4_A129MetodoPagosNombre[0];
               A132EstadosSolNombre = H002Q4_A132EstadosSolNombre[0];
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
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A315HistoricoPaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A316HistoricoDepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A318HistoricoZonasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A299HistoricoSolicitudesCotizacion, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A300HistoricoSolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A301HistoricoSolicitudServicioSolC) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A130EstadosSolTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A132EstadosSolNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A303HistoricoSolicitudesOtros1) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A304HistoricoSolicitudesOtros2) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A305HistoricoSolicitudesOtros3) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A309HistoricoSolicitudesHoraInstal) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A310HistoricoSolicitudesComentario) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A128MetodoPagosID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A129MetodoPagosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A311HistoricoSolicitudesNota) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A312HistoricoSolicitudesNotificaci) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A439HistoricoSolicitudesOrigenPago) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "pagado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A442HistoricoSolicitudesPagado, "S") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente de pago", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A442HistoricoSolicitudesPagado, "N") == 0 ) ) )
               )
               {
                  if ( (Convert.ToDecimal(0)==AV45TFHistoricoSolicitudServicioPFinal) || ( ( A302HistoricoSolicitudServicioPFin >= AV45TFHistoricoSolicitudServicioPFinal ) ) )
                  {
                     if ( (Convert.ToDecimal(0)==AV46TFHistoricoSolicitudServicioPFinal_To) || ( ( A302HistoricoSolicitudServicioPFin <= AV46TFHistoricoSolicitudServicioPFinal_To ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E172Q2 ();
                     }
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 33;
            WB2Q0( ) ;
         }
         bGXsfl_33_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Q2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV100Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV100Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSSOLNOMBRE", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( sPrefix, AV99IsAuthorized_EstadosSolNombre, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_METODOPAGOSNOMBRE", AV97IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( sPrefix, AV97IsAuthorized_MetodoPagosNombre, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8HistoricoSolicitudesID, AV20ManageFiltersExecutionStep, AV100Pgmname, AV21TFHistoricoSolicitudesNombre, AV22TFHistoricoSolicitudesNombre_Sel, AV23TFHistoricoSolicitudesTelefono, AV24TFHistoricoSolicitudesTelefono_Sel, AV25TFHistoricoSolicitudesMail, AV26TFHistoricoSolicitudesMail_Sel, AV27TFHistoricoPaisID, AV28TFHistoricoPaisID_Sel, AV29TFHistoricoDepartamentoId, AV30TFHistoricoDepartamentoId_To, AV31TFHistoricoDepartamentoMunicipioId, AV32TFHistoricoDepartamentoMunicipioId_To, AV33TFHistoricoZonasID, AV34TFHistoricoZonasID_To, AV35TFHistoricoSolicitudesDireccion, AV36TFHistoricoSolicitudesDireccion_Sel, AV37TFHistoricoSolicitudesAutoEnumerar, AV38TFHistoricoSolicitudesAutoEnumerar_To, AV39TFHistoricoSolicitudesCotizacion, AV40TFHistoricoSolicitudesCotizacion_To, AV41TFHistoricoSolicitudesTotal, AV42TFHistoricoSolicitudesTotal_To, AV43TFHistoricoSolicitudServicioSolCoti, AV44TFHistoricoSolicitudServicioSolCoti_Sel, AV45TFHistoricoSolicitudServicioPFinal, AV46TFHistoricoSolicitudServicioPFinal_To, AV47TFEstadosSolTipo, AV48TFEstadosSolTipo_Sel, AV49TFEstadosSolNombre, AV50TFEstadosSolNombre_Sel, AV51TFHistoricoSolicitudesOtros1, AV52TFHistoricoSolicitudesOtros1_Sel, AV53TFHistoricoSolicitudesOtros2, AV54TFHistoricoSolicitudesOtros2_Sel, AV55TFHistoricoSolicitudesOtros3, AV56TFHistoricoSolicitudesOtros3_Sel, AV57TFHistoricoSolicitudesFechaAlta, AV58TFHistoricoSolicitudesFechaAlta_To, AV62TFHistoricoSolicitudesFechaActualizacion, AV63TFHistoricoSolicitudesFechaActualizacion_To, AV67TFHistoricoSolicitudesFechaInstalacion, AV68TFHistoricoSolicitudesFechaInstalacion_To, AV72TFHistoricoSolicitudesHoraInstalacion, AV73TFHistoricoSolicitudesHoraInstalacion_Sel, AV74TFHistoricoSolicitudesComentario, AV75TFHistoricoSolicitudesComentario_Sel, AV76TFMetodoPagosID, AV77TFMetodoPagosID_To, AV78TFMetodoPagosNombre, AV79TFMetodoPagosNombre_Sel, AV80TFHistoricoSolicitudesNota, AV81TFHistoricoSolicitudesNota_Sel, AV82TFHistoricoSolicitudesNotificacion, AV83TFHistoricoSolicitudesNotificacion_Sel, AV84TFHistoricoSolicitudesOrigenPago, AV85TFHistoricoSolicitudesOrigenPago_Sel, AV87TFHistoricoSolicitudesPagado_Sels, AV99IsAuthorized_EstadosSolNombre, AV97IsAuthorized_MetodoPagosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV100Pgmname = "HistoricoRelacionesItemsWC";
         edtHistoricoSolicitudesNombre_Enabled = 0;
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         edtHistoricoSolicitudesMail_Enabled = 0;
         edtHistoricoPaisID_Enabled = 0;
         edtHistoricoDepartamentoId_Enabled = 0;
         edtHistoricoDepartamentoMunicipio_Enabled = 0;
         edtHistoricoZonasID_Enabled = 0;
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         edtHistoricoSolicitudesAutoEnumer_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         edtHistoricoSolicitudesTotal_Enabled = 0;
         edtHistoricoSolicitudServicioSolC_Enabled = 0;
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtHistoricoSolicitudesOtros1_Enabled = 0;
         edtHistoricoSolicitudesOtros2_Enabled = 0;
         edtHistoricoSolicitudesOtros3_Enabled = 0;
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         edtHistoricoSolicitudesFechaActua_Enabled = 0;
         edtHistoricoSolicitudesFechaInsta_Enabled = 0;
         edtHistoricoSolicitudesHoraInstal_Enabled = 0;
         edtHistoricoSolicitudesComentario_Enabled = 0;
         edtMetodoPagosID_Enabled = 0;
         edtMetodoPagosNombre_Enabled = 0;
         edtHistoricoSolicitudesNota_Enabled = 0;
         edtHistoricoSolicitudesNotificaci_Enabled = 0;
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E152Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV88DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_33 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_33"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV91GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV92GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV93GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV59DDO_HistoricoSolicitudesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAALTAAUXDATE"), 0);
            AV60DDO_HistoricoSolicitudesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAALTAAUXDATETO"), 0);
            AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate", context.localUtil.Format(AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate, "99/99/99"));
            AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo", context.localUtil.Format(AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo, "99/99/99"));
            AV69DDO_HistoricoSolicitudesFechaInstalacionAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATE"), 0);
            AV70DDO_HistoricoSolicitudesFechaInstalacionAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATETO"), 0);
            wcpOAV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText = cgiGet( edtavDdo_historicosolicitudesfechaaltaauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText", AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText);
            AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText = cgiGet( edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText", AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText);
            AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText = cgiGet( edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText", AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E152Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E152Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFHISTORICOSOLICITUDESFECHAINSTALACION_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFHISTORICOSOLICITUDESFECHAACTUALIZACION_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFHISTORICOSOLICITUDESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_historicosolicitudesfechaaltaauxdatetext_Internalname});
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean1 = AV99IsAuthorized_EstadosSolNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV99IsAuthorized_EstadosSolNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV99IsAuthorized_EstadosSolNombre", AV99IsAuthorized_EstadosSolNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSSOLNOMBRE", GetSecureSignedToken( sPrefix, AV99IsAuthorized_EstadosSolNombre, context));
         GXt_boolean1 = AV97IsAuthorized_MetodoPagosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
         AV97IsAuthorized_MetodoPagosNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV97IsAuthorized_MetodoPagosNombre", AV97IsAuthorized_MetodoPagosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_METODOPAGOSNOMBRE", GetSecureSignedToken( sPrefix, AV97IsAuthorized_MetodoPagosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtHistoricoSolicitudesID_Visible = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Visible), 5, 0), true);
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
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV88DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV88DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E162Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV91GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV91GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV91GridCurrentPage), 10, 0));
         AV92GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV92GridPageCount", StringUtil.LTrimStr( (decimal)(AV92GridPageCount), 10, 0));
         GXt_char3 = AV93GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV100Pgmname, out  GXt_char3) ;
         AV93GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV93GridAppliedFilters", AV93GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E122Q2( )
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
            AV90PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV90PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E132Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142Q2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesNombre") == 0 )
            {
               AV21TFHistoricoSolicitudesNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFHistoricoSolicitudesNombre", AV21TFHistoricoSolicitudesNombre);
               AV22TFHistoricoSolicitudesNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFHistoricoSolicitudesNombre_Sel", AV22TFHistoricoSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesTelefono") == 0 )
            {
               AV23TFHistoricoSolicitudesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFHistoricoSolicitudesTelefono", AV23TFHistoricoSolicitudesTelefono);
               AV24TFHistoricoSolicitudesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFHistoricoSolicitudesTelefono_Sel", AV24TFHistoricoSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesMail") == 0 )
            {
               AV25TFHistoricoSolicitudesMail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFHistoricoSolicitudesMail", AV25TFHistoricoSolicitudesMail);
               AV26TFHistoricoSolicitudesMail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFHistoricoSolicitudesMail_Sel", AV26TFHistoricoSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoPaisID") == 0 )
            {
               AV27TFHistoricoPaisID = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFHistoricoPaisID", AV27TFHistoricoPaisID);
               AV28TFHistoricoPaisID_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFHistoricoPaisID_Sel", AV28TFHistoricoPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoDepartamentoId") == 0 )
            {
               AV29TFHistoricoDepartamentoId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFHistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0));
               AV30TFHistoricoDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFHistoricoDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoDepartamentoMunicipioId") == 0 )
            {
               AV31TFHistoricoDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFHistoricoDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0));
               AV32TFHistoricoDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFHistoricoDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoZonasID") == 0 )
            {
               AV33TFHistoricoZonasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFHistoricoZonasID", StringUtil.LTrimStr( (decimal)(AV33TFHistoricoZonasID), 18, 0));
               AV34TFHistoricoZonasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFHistoricoZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFHistoricoZonasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesDireccion") == 0 )
            {
               AV35TFHistoricoSolicitudesDireccion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFHistoricoSolicitudesDireccion", AV35TFHistoricoSolicitudesDireccion);
               AV36TFHistoricoSolicitudesDireccion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFHistoricoSolicitudesDireccion_Sel", AV36TFHistoricoSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesAutoEnumerar") == 0 )
            {
               AV37TFHistoricoSolicitudesAutoEnumerar = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFHistoricoSolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0));
               AV38TFHistoricoSolicitudesAutoEnumerar_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV38TFHistoricoSolicitudesAutoEnumerar_To", StringUtil.LTrimStr( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesCotizacion") == 0 )
            {
               AV39TFHistoricoSolicitudesCotizacion = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV39TFHistoricoSolicitudesCotizacion", StringUtil.LTrimStr( AV39TFHistoricoSolicitudesCotizacion, 18, 2));
               AV40TFHistoricoSolicitudesCotizacion_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV40TFHistoricoSolicitudesCotizacion_To", StringUtil.LTrimStr( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesTotal") == 0 )
            {
               AV41TFHistoricoSolicitudesTotal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV41TFHistoricoSolicitudesTotal", StringUtil.LTrimStr( AV41TFHistoricoSolicitudesTotal, 18, 2));
               AV42TFHistoricoSolicitudesTotal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV42TFHistoricoSolicitudesTotal_To", StringUtil.LTrimStr( AV42TFHistoricoSolicitudesTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudServicioSolCoti") == 0 )
            {
               AV43TFHistoricoSolicitudServicioSolCoti = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV43TFHistoricoSolicitudServicioSolCoti", AV43TFHistoricoSolicitudServicioSolCoti);
               AV44TFHistoricoSolicitudServicioSolCoti_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV44TFHistoricoSolicitudServicioSolCoti_Sel", AV44TFHistoricoSolicitudServicioSolCoti_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudServicioPFinal") == 0 )
            {
               AV45TFHistoricoSolicitudServicioPFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV45TFHistoricoSolicitudServicioPFinal", StringUtil.LTrimStr( AV45TFHistoricoSolicitudServicioPFinal, 18, 2));
               AV46TFHistoricoSolicitudServicioPFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV46TFHistoricoSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosSolTipo") == 0 )
            {
               AV47TFEstadosSolTipo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV47TFEstadosSolTipo", AV47TFEstadosSolTipo);
               AV48TFEstadosSolTipo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV48TFEstadosSolTipo_Sel", AV48TFEstadosSolTipo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosSolNombre") == 0 )
            {
               AV49TFEstadosSolNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV49TFEstadosSolNombre", AV49TFEstadosSolNombre);
               AV50TFEstadosSolNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV50TFEstadosSolNombre_Sel", AV50TFEstadosSolNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesOtros1") == 0 )
            {
               AV51TFHistoricoSolicitudesOtros1 = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV51TFHistoricoSolicitudesOtros1", AV51TFHistoricoSolicitudesOtros1);
               AV52TFHistoricoSolicitudesOtros1_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV52TFHistoricoSolicitudesOtros1_Sel", AV52TFHistoricoSolicitudesOtros1_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesOtros2") == 0 )
            {
               AV53TFHistoricoSolicitudesOtros2 = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV53TFHistoricoSolicitudesOtros2", AV53TFHistoricoSolicitudesOtros2);
               AV54TFHistoricoSolicitudesOtros2_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV54TFHistoricoSolicitudesOtros2_Sel", AV54TFHistoricoSolicitudesOtros2_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesOtros3") == 0 )
            {
               AV55TFHistoricoSolicitudesOtros3 = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV55TFHistoricoSolicitudesOtros3", AV55TFHistoricoSolicitudesOtros3);
               AV56TFHistoricoSolicitudesOtros3_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV56TFHistoricoSolicitudesOtros3_Sel", AV56TFHistoricoSolicitudesOtros3_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesFechaAlta") == 0 )
            {
               AV57TFHistoricoSolicitudesFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV57TFHistoricoSolicitudesFechaAlta", context.localUtil.Format(AV57TFHistoricoSolicitudesFechaAlta, "99/99/99"));
               AV58TFHistoricoSolicitudesFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV58TFHistoricoSolicitudesFechaAlta_To", context.localUtil.Format(AV58TFHistoricoSolicitudesFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesFechaActualizacion") == 0 )
            {
               AV62TFHistoricoSolicitudesFechaActualizacion = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV62TFHistoricoSolicitudesFechaActualizacion", context.localUtil.TToC( AV62TFHistoricoSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV63TFHistoricoSolicitudesFechaActualizacion_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV63TFHistoricoSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV63TFHistoricoSolicitudesFechaActualizacion_To) )
               {
                  AV63TFHistoricoSolicitudesFechaActualizacion_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV63TFHistoricoSolicitudesFechaActualizacion_To)), (short)(DateTimeUtil.Month( AV63TFHistoricoSolicitudesFechaActualizacion_To)), (short)(DateTimeUtil.Day( AV63TFHistoricoSolicitudesFechaActualizacion_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV63TFHistoricoSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesFechaInstalacion") == 0 )
            {
               AV67TFHistoricoSolicitudesFechaInstalacion = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV67TFHistoricoSolicitudesFechaInstalacion", context.localUtil.Format(AV67TFHistoricoSolicitudesFechaInstalacion, "99/99/99"));
               AV68TFHistoricoSolicitudesFechaInstalacion_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV68TFHistoricoSolicitudesFechaInstalacion_To", context.localUtil.Format(AV68TFHistoricoSolicitudesFechaInstalacion_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesHoraInstalacion") == 0 )
            {
               AV72TFHistoricoSolicitudesHoraInstalacion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV72TFHistoricoSolicitudesHoraInstalacion", AV72TFHistoricoSolicitudesHoraInstalacion);
               AV73TFHistoricoSolicitudesHoraInstalacion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV73TFHistoricoSolicitudesHoraInstalacion_Sel", AV73TFHistoricoSolicitudesHoraInstalacion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesComentario") == 0 )
            {
               AV74TFHistoricoSolicitudesComentario = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV74TFHistoricoSolicitudesComentario", AV74TFHistoricoSolicitudesComentario);
               AV75TFHistoricoSolicitudesComentario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV75TFHistoricoSolicitudesComentario_Sel", AV75TFHistoricoSolicitudesComentario_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MetodoPagosID") == 0 )
            {
               AV76TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV76TFMetodoPagosID", StringUtil.LTrimStr( (decimal)(AV76TFMetodoPagosID), 18, 0));
               AV77TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV77TFMetodoPagosID_To", StringUtil.LTrimStr( (decimal)(AV77TFMetodoPagosID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MetodoPagosNombre") == 0 )
            {
               AV78TFMetodoPagosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV78TFMetodoPagosNombre", AV78TFMetodoPagosNombre);
               AV79TFMetodoPagosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV79TFMetodoPagosNombre_Sel", AV79TFMetodoPagosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesNota") == 0 )
            {
               AV80TFHistoricoSolicitudesNota = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV80TFHistoricoSolicitudesNota", AV80TFHistoricoSolicitudesNota);
               AV81TFHistoricoSolicitudesNota_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV81TFHistoricoSolicitudesNota_Sel", AV81TFHistoricoSolicitudesNota_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesNotificacion") == 0 )
            {
               AV82TFHistoricoSolicitudesNotificacion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV82TFHistoricoSolicitudesNotificacion", AV82TFHistoricoSolicitudesNotificacion);
               AV83TFHistoricoSolicitudesNotificacion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV83TFHistoricoSolicitudesNotificacion_Sel", AV83TFHistoricoSolicitudesNotificacion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesOrigenPago") == 0 )
            {
               AV84TFHistoricoSolicitudesOrigenPago = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV84TFHistoricoSolicitudesOrigenPago", AV84TFHistoricoSolicitudesOrigenPago);
               AV85TFHistoricoSolicitudesOrigenPago_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV85TFHistoricoSolicitudesOrigenPago_Sel", AV85TFHistoricoSolicitudesOrigenPago_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "HistoricoSolicitudesPagado") == 0 )
            {
               AV86TFHistoricoSolicitudesPagado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV86TFHistoricoSolicitudesPagado_SelsJson", AV86TFHistoricoSolicitudesPagado_SelsJson);
               AV87TFHistoricoSolicitudesPagado_Sels.FromJSonString(AV86TFHistoricoSolicitudesPagado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV87TFHistoricoSolicitudesPagado_Sels", AV87TFHistoricoSolicitudesPagado_Sels);
      }

      private void E172Q2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( AV99IsAuthorized_EstadosSolNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A130EstadosSolTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A131EstadosSolId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtEstadosSolNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV97IsAuthorized_MetodoPagosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "metodopagosview.aspx"+UrlEncode(StringUtil.LTrimStr(A128MetodoPagosID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtMetodoPagosNombre_Link = formatLink("metodopagosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 33;
            }
            sendrow_332( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_33_Refreshing )
         {
            context.DoAjaxLoad(33, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112Q2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
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
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("HistoricoRelacionesItemsWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV100Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("HistoricoRelacionesItemsWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "HistoricoRelacionesItemsWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV19ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV87TFHistoricoSolicitudesPagado_Sels", AV87TFHistoricoSolicitudesPagado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "HistoricoRelacionesItemsWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFHistoricoSolicitudesNombre = "";
         AssignAttri(sPrefix, false, "AV21TFHistoricoSolicitudesNombre", AV21TFHistoricoSolicitudesNombre);
         AV22TFHistoricoSolicitudesNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV22TFHistoricoSolicitudesNombre_Sel", AV22TFHistoricoSolicitudesNombre_Sel);
         AV23TFHistoricoSolicitudesTelefono = "";
         AssignAttri(sPrefix, false, "AV23TFHistoricoSolicitudesTelefono", AV23TFHistoricoSolicitudesTelefono);
         AV24TFHistoricoSolicitudesTelefono_Sel = "";
         AssignAttri(sPrefix, false, "AV24TFHistoricoSolicitudesTelefono_Sel", AV24TFHistoricoSolicitudesTelefono_Sel);
         AV25TFHistoricoSolicitudesMail = "";
         AssignAttri(sPrefix, false, "AV25TFHistoricoSolicitudesMail", AV25TFHistoricoSolicitudesMail);
         AV26TFHistoricoSolicitudesMail_Sel = "";
         AssignAttri(sPrefix, false, "AV26TFHistoricoSolicitudesMail_Sel", AV26TFHistoricoSolicitudesMail_Sel);
         AV27TFHistoricoPaisID = "";
         AssignAttri(sPrefix, false, "AV27TFHistoricoPaisID", AV27TFHistoricoPaisID);
         AV28TFHistoricoPaisID_Sel = "";
         AssignAttri(sPrefix, false, "AV28TFHistoricoPaisID_Sel", AV28TFHistoricoPaisID_Sel);
         AV29TFHistoricoDepartamentoId = 0;
         AssignAttri(sPrefix, false, "AV29TFHistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0));
         AV30TFHistoricoDepartamentoId_To = 0;
         AssignAttri(sPrefix, false, "AV30TFHistoricoDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0));
         AV31TFHistoricoDepartamentoMunicipioId = 0;
         AssignAttri(sPrefix, false, "AV31TFHistoricoDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0));
         AV32TFHistoricoDepartamentoMunicipioId_To = 0;
         AssignAttri(sPrefix, false, "AV32TFHistoricoDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0));
         AV33TFHistoricoZonasID = 0;
         AssignAttri(sPrefix, false, "AV33TFHistoricoZonasID", StringUtil.LTrimStr( (decimal)(AV33TFHistoricoZonasID), 18, 0));
         AV34TFHistoricoZonasID_To = 0;
         AssignAttri(sPrefix, false, "AV34TFHistoricoZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFHistoricoZonasID_To), 18, 0));
         AV35TFHistoricoSolicitudesDireccion = "";
         AssignAttri(sPrefix, false, "AV35TFHistoricoSolicitudesDireccion", AV35TFHistoricoSolicitudesDireccion);
         AV36TFHistoricoSolicitudesDireccion_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFHistoricoSolicitudesDireccion_Sel", AV36TFHistoricoSolicitudesDireccion_Sel);
         AV37TFHistoricoSolicitudesAutoEnumerar = 0;
         AssignAttri(sPrefix, false, "AV37TFHistoricoSolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0));
         AV38TFHistoricoSolicitudesAutoEnumerar_To = 0;
         AssignAttri(sPrefix, false, "AV38TFHistoricoSolicitudesAutoEnumerar_To", StringUtil.LTrimStr( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0));
         AV39TFHistoricoSolicitudesCotizacion = 0;
         AssignAttri(sPrefix, false, "AV39TFHistoricoSolicitudesCotizacion", StringUtil.LTrimStr( AV39TFHistoricoSolicitudesCotizacion, 18, 2));
         AV40TFHistoricoSolicitudesCotizacion_To = 0;
         AssignAttri(sPrefix, false, "AV40TFHistoricoSolicitudesCotizacion_To", StringUtil.LTrimStr( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2));
         AV41TFHistoricoSolicitudesTotal = 0;
         AssignAttri(sPrefix, false, "AV41TFHistoricoSolicitudesTotal", StringUtil.LTrimStr( AV41TFHistoricoSolicitudesTotal, 18, 2));
         AV42TFHistoricoSolicitudesTotal_To = 0;
         AssignAttri(sPrefix, false, "AV42TFHistoricoSolicitudesTotal_To", StringUtil.LTrimStr( AV42TFHistoricoSolicitudesTotal_To, 18, 2));
         AV43TFHistoricoSolicitudServicioSolCoti = "";
         AssignAttri(sPrefix, false, "AV43TFHistoricoSolicitudServicioSolCoti", AV43TFHistoricoSolicitudServicioSolCoti);
         AV44TFHistoricoSolicitudServicioSolCoti_Sel = "";
         AssignAttri(sPrefix, false, "AV44TFHistoricoSolicitudServicioSolCoti_Sel", AV44TFHistoricoSolicitudServicioSolCoti_Sel);
         AV45TFHistoricoSolicitudServicioPFinal = 0;
         AssignAttri(sPrefix, false, "AV45TFHistoricoSolicitudServicioPFinal", StringUtil.LTrimStr( AV45TFHistoricoSolicitudServicioPFinal, 18, 2));
         AV46TFHistoricoSolicitudServicioPFinal_To = 0;
         AssignAttri(sPrefix, false, "AV46TFHistoricoSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2));
         AV47TFEstadosSolTipo = "";
         AssignAttri(sPrefix, false, "AV47TFEstadosSolTipo", AV47TFEstadosSolTipo);
         AV48TFEstadosSolTipo_Sel = "";
         AssignAttri(sPrefix, false, "AV48TFEstadosSolTipo_Sel", AV48TFEstadosSolTipo_Sel);
         AV49TFEstadosSolNombre = "";
         AssignAttri(sPrefix, false, "AV49TFEstadosSolNombre", AV49TFEstadosSolNombre);
         AV50TFEstadosSolNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV50TFEstadosSolNombre_Sel", AV50TFEstadosSolNombre_Sel);
         AV51TFHistoricoSolicitudesOtros1 = "";
         AssignAttri(sPrefix, false, "AV51TFHistoricoSolicitudesOtros1", AV51TFHistoricoSolicitudesOtros1);
         AV52TFHistoricoSolicitudesOtros1_Sel = "";
         AssignAttri(sPrefix, false, "AV52TFHistoricoSolicitudesOtros1_Sel", AV52TFHistoricoSolicitudesOtros1_Sel);
         AV53TFHistoricoSolicitudesOtros2 = "";
         AssignAttri(sPrefix, false, "AV53TFHistoricoSolicitudesOtros2", AV53TFHistoricoSolicitudesOtros2);
         AV54TFHistoricoSolicitudesOtros2_Sel = "";
         AssignAttri(sPrefix, false, "AV54TFHistoricoSolicitudesOtros2_Sel", AV54TFHistoricoSolicitudesOtros2_Sel);
         AV55TFHistoricoSolicitudesOtros3 = "";
         AssignAttri(sPrefix, false, "AV55TFHistoricoSolicitudesOtros3", AV55TFHistoricoSolicitudesOtros3);
         AV56TFHistoricoSolicitudesOtros3_Sel = "";
         AssignAttri(sPrefix, false, "AV56TFHistoricoSolicitudesOtros3_Sel", AV56TFHistoricoSolicitudesOtros3_Sel);
         AV57TFHistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV57TFHistoricoSolicitudesFechaAlta", context.localUtil.Format(AV57TFHistoricoSolicitudesFechaAlta, "99/99/99"));
         AV58TFHistoricoSolicitudesFechaAlta_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV58TFHistoricoSolicitudesFechaAlta_To", context.localUtil.Format(AV58TFHistoricoSolicitudesFechaAlta_To, "99/99/99"));
         AV62TFHistoricoSolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV62TFHistoricoSolicitudesFechaActualizacion", context.localUtil.TToC( AV62TFHistoricoSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV63TFHistoricoSolicitudesFechaActualizacion_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV63TFHistoricoSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV67TFHistoricoSolicitudesFechaInstalacion = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV67TFHistoricoSolicitudesFechaInstalacion", context.localUtil.Format(AV67TFHistoricoSolicitudesFechaInstalacion, "99/99/99"));
         AV68TFHistoricoSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV68TFHistoricoSolicitudesFechaInstalacion_To", context.localUtil.Format(AV68TFHistoricoSolicitudesFechaInstalacion_To, "99/99/99"));
         AV72TFHistoricoSolicitudesHoraInstalacion = "";
         AssignAttri(sPrefix, false, "AV72TFHistoricoSolicitudesHoraInstalacion", AV72TFHistoricoSolicitudesHoraInstalacion);
         AV73TFHistoricoSolicitudesHoraInstalacion_Sel = "";
         AssignAttri(sPrefix, false, "AV73TFHistoricoSolicitudesHoraInstalacion_Sel", AV73TFHistoricoSolicitudesHoraInstalacion_Sel);
         AV74TFHistoricoSolicitudesComentario = "";
         AssignAttri(sPrefix, false, "AV74TFHistoricoSolicitudesComentario", AV74TFHistoricoSolicitudesComentario);
         AV75TFHistoricoSolicitudesComentario_Sel = "";
         AssignAttri(sPrefix, false, "AV75TFHistoricoSolicitudesComentario_Sel", AV75TFHistoricoSolicitudesComentario_Sel);
         AV76TFMetodoPagosID = 0;
         AssignAttri(sPrefix, false, "AV76TFMetodoPagosID", StringUtil.LTrimStr( (decimal)(AV76TFMetodoPagosID), 18, 0));
         AV77TFMetodoPagosID_To = 0;
         AssignAttri(sPrefix, false, "AV77TFMetodoPagosID_To", StringUtil.LTrimStr( (decimal)(AV77TFMetodoPagosID_To), 18, 0));
         AV78TFMetodoPagosNombre = "";
         AssignAttri(sPrefix, false, "AV78TFMetodoPagosNombre", AV78TFMetodoPagosNombre);
         AV79TFMetodoPagosNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV79TFMetodoPagosNombre_Sel", AV79TFMetodoPagosNombre_Sel);
         AV80TFHistoricoSolicitudesNota = "";
         AssignAttri(sPrefix, false, "AV80TFHistoricoSolicitudesNota", AV80TFHistoricoSolicitudesNota);
         AV81TFHistoricoSolicitudesNota_Sel = "";
         AssignAttri(sPrefix, false, "AV81TFHistoricoSolicitudesNota_Sel", AV81TFHistoricoSolicitudesNota_Sel);
         AV82TFHistoricoSolicitudesNotificacion = "";
         AssignAttri(sPrefix, false, "AV82TFHistoricoSolicitudesNotificacion", AV82TFHistoricoSolicitudesNotificacion);
         AV83TFHistoricoSolicitudesNotificacion_Sel = "";
         AssignAttri(sPrefix, false, "AV83TFHistoricoSolicitudesNotificacion_Sel", AV83TFHistoricoSolicitudesNotificacion_Sel);
         AV84TFHistoricoSolicitudesOrigenPago = "";
         AssignAttri(sPrefix, false, "AV84TFHistoricoSolicitudesOrigenPago", AV84TFHistoricoSolicitudesOrigenPago);
         AV85TFHistoricoSolicitudesOrigenPago_Sel = "";
         AssignAttri(sPrefix, false, "AV85TFHistoricoSolicitudesOrigenPago_Sel", AV85TFHistoricoSolicitudesOrigenPago_Sel);
         AV87TFHistoricoSolicitudesPagado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV100Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV100Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV100Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV101GXV1 = 1;
         while ( AV101GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV101GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOMBRE") == 0 )
            {
               AV21TFHistoricoSolicitudesNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFHistoricoSolicitudesNombre", AV21TFHistoricoSolicitudesNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV22TFHistoricoSolicitudesNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFHistoricoSolicitudesNombre_Sel", AV22TFHistoricoSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESTELEFONO") == 0 )
            {
               AV23TFHistoricoSolicitudesTelefono = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFHistoricoSolicitudesTelefono", AV23TFHistoricoSolicitudesTelefono);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESTELEFONO_SEL") == 0 )
            {
               AV24TFHistoricoSolicitudesTelefono_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFHistoricoSolicitudesTelefono_Sel", AV24TFHistoricoSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESMAIL") == 0 )
            {
               AV25TFHistoricoSolicitudesMail = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFHistoricoSolicitudesMail", AV25TFHistoricoSolicitudesMail);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESMAIL_SEL") == 0 )
            {
               AV26TFHistoricoSolicitudesMail_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFHistoricoSolicitudesMail_Sel", AV26TFHistoricoSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOPAISID") == 0 )
            {
               AV27TFHistoricoPaisID = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFHistoricoPaisID", AV27TFHistoricoPaisID);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOPAISID_SEL") == 0 )
            {
               AV28TFHistoricoPaisID_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFHistoricoPaisID_Sel", AV28TFHistoricoPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICODEPARTAMENTOID") == 0 )
            {
               AV29TFHistoricoDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFHistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0));
               AV30TFHistoricoDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFHistoricoDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICODEPARTAMENTOMUNICIPIOID") == 0 )
            {
               AV31TFHistoricoDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFHistoricoDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0));
               AV32TFHistoricoDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFHistoricoDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOZONASID") == 0 )
            {
               AV33TFHistoricoZonasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFHistoricoZonasID", StringUtil.LTrimStr( (decimal)(AV33TFHistoricoZonasID), 18, 0));
               AV34TFHistoricoZonasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFHistoricoZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFHistoricoZonasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESDIRECCION") == 0 )
            {
               AV35TFHistoricoSolicitudesDireccion = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFHistoricoSolicitudesDireccion", AV35TFHistoricoSolicitudesDireccion);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESDIRECCION_SEL") == 0 )
            {
               AV36TFHistoricoSolicitudesDireccion_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFHistoricoSolicitudesDireccion_Sel", AV36TFHistoricoSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESAUTOENUMERAR") == 0 )
            {
               AV37TFHistoricoSolicitudesAutoEnumerar = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFHistoricoSolicitudesAutoEnumerar", StringUtil.LTrimStr( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0));
               AV38TFHistoricoSolicitudesAutoEnumerar_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV38TFHistoricoSolicitudesAutoEnumerar_To", StringUtil.LTrimStr( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESCOTIZACION") == 0 )
            {
               AV39TFHistoricoSolicitudesCotizacion = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV39TFHistoricoSolicitudesCotizacion", StringUtil.LTrimStr( AV39TFHistoricoSolicitudesCotizacion, 18, 2));
               AV40TFHistoricoSolicitudesCotizacion_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV40TFHistoricoSolicitudesCotizacion_To", StringUtil.LTrimStr( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESTOTAL") == 0 )
            {
               AV41TFHistoricoSolicitudesTotal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV41TFHistoricoSolicitudesTotal", StringUtil.LTrimStr( AV41TFHistoricoSolicitudesTotal, 18, 2));
               AV42TFHistoricoSolicitudesTotal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV42TFHistoricoSolicitudesTotal_To", StringUtil.LTrimStr( AV42TFHistoricoSolicitudesTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDSERVICIOSOLCOTI") == 0 )
            {
               AV43TFHistoricoSolicitudServicioSolCoti = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43TFHistoricoSolicitudServicioSolCoti", AV43TFHistoricoSolicitudServicioSolCoti);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL") == 0 )
            {
               AV44TFHistoricoSolicitudServicioSolCoti_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV44TFHistoricoSolicitudServicioSolCoti_Sel", AV44TFHistoricoSolicitudServicioSolCoti_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV45TFHistoricoSolicitudServicioPFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV45TFHistoricoSolicitudServicioPFinal", StringUtil.LTrimStr( AV45TFHistoricoSolicitudServicioPFinal, 18, 2));
               AV46TFHistoricoSolicitudServicioPFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV46TFHistoricoSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLTIPO") == 0 )
            {
               AV47TFEstadosSolTipo = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV47TFEstadosSolTipo", AV47TFEstadosSolTipo);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLTIPO_SEL") == 0 )
            {
               AV48TFEstadosSolTipo_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV48TFEstadosSolTipo_Sel", AV48TFEstadosSolTipo_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE") == 0 )
            {
               AV49TFEstadosSolNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV49TFEstadosSolNombre", AV49TFEstadosSolNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSSOLNOMBRE_SEL") == 0 )
            {
               AV50TFEstadosSolNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV50TFEstadosSolNombre_Sel", AV50TFEstadosSolNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS1") == 0 )
            {
               AV51TFHistoricoSolicitudesOtros1 = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV51TFHistoricoSolicitudesOtros1", AV51TFHistoricoSolicitudesOtros1);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS1_SEL") == 0 )
            {
               AV52TFHistoricoSolicitudesOtros1_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV52TFHistoricoSolicitudesOtros1_Sel", AV52TFHistoricoSolicitudesOtros1_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS2") == 0 )
            {
               AV53TFHistoricoSolicitudesOtros2 = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV53TFHistoricoSolicitudesOtros2", AV53TFHistoricoSolicitudesOtros2);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS2_SEL") == 0 )
            {
               AV54TFHistoricoSolicitudesOtros2_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV54TFHistoricoSolicitudesOtros2_Sel", AV54TFHistoricoSolicitudesOtros2_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS3") == 0 )
            {
               AV55TFHistoricoSolicitudesOtros3 = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV55TFHistoricoSolicitudesOtros3", AV55TFHistoricoSolicitudesOtros3);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESOTROS3_SEL") == 0 )
            {
               AV56TFHistoricoSolicitudesOtros3_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV56TFHistoricoSolicitudesOtros3_Sel", AV56TFHistoricoSolicitudesOtros3_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESFECHAALTA") == 0 )
            {
               AV57TFHistoricoSolicitudesFechaAlta = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV57TFHistoricoSolicitudesFechaAlta", context.localUtil.Format(AV57TFHistoricoSolicitudesFechaAlta, "99/99/99"));
               AV58TFHistoricoSolicitudesFechaAlta_To = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV58TFHistoricoSolicitudesFechaAlta_To", context.localUtil.Format(AV58TFHistoricoSolicitudesFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESFECHAACTUALIZACION") == 0 )
            {
               AV62TFHistoricoSolicitudesFechaActualizacion = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV62TFHistoricoSolicitudesFechaActualizacion", context.localUtil.TToC( AV62TFHistoricoSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV63TFHistoricoSolicitudesFechaActualizacion_To = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV63TFHistoricoSolicitudesFechaActualizacion_To", context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate = DateTimeUtil.ResetTime(AV62TFHistoricoSolicitudesFechaActualizacion);
               AssignAttri(sPrefix, false, "AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate", context.localUtil.Format(AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate, "99/99/99"));
               AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo = DateTimeUtil.ResetTime(AV63TFHistoricoSolicitudesFechaActualizacion_To);
               AssignAttri(sPrefix, false, "AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo", context.localUtil.Format(AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV67TFHistoricoSolicitudesFechaInstalacion = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV67TFHistoricoSolicitudesFechaInstalacion", context.localUtil.Format(AV67TFHistoricoSolicitudesFechaInstalacion, "99/99/99"));
               AV68TFHistoricoSolicitudesFechaInstalacion_To = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV68TFHistoricoSolicitudesFechaInstalacion_To", context.localUtil.Format(AV68TFHistoricoSolicitudesFechaInstalacion_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESHORAINSTALACION") == 0 )
            {
               AV72TFHistoricoSolicitudesHoraInstalacion = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV72TFHistoricoSolicitudesHoraInstalacion", AV72TFHistoricoSolicitudesHoraInstalacion);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESHORAINSTALACION_SEL") == 0 )
            {
               AV73TFHistoricoSolicitudesHoraInstalacion_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV73TFHistoricoSolicitudesHoraInstalacion_Sel", AV73TFHistoricoSolicitudesHoraInstalacion_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESCOMENTARIO") == 0 )
            {
               AV74TFHistoricoSolicitudesComentario = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV74TFHistoricoSolicitudesComentario", AV74TFHistoricoSolicitudesComentario);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV75TFHistoricoSolicitudesComentario_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV75TFHistoricoSolicitudesComentario_Sel", AV75TFHistoricoSolicitudesComentario_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSID") == 0 )
            {
               AV76TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV76TFMetodoPagosID", StringUtil.LTrimStr( (decimal)(AV76TFMetodoPagosID), 18, 0));
               AV77TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV77TFMetodoPagosID_To", StringUtil.LTrimStr( (decimal)(AV77TFMetodoPagosID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV78TFMetodoPagosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV78TFMetodoPagosNombre", AV78TFMetodoPagosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV79TFMetodoPagosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV79TFMetodoPagosNombre_Sel", AV79TFMetodoPagosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOTA") == 0 )
            {
               AV80TFHistoricoSolicitudesNota = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV80TFHistoricoSolicitudesNota", AV80TFHistoricoSolicitudesNota);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOTA_SEL") == 0 )
            {
               AV81TFHistoricoSolicitudesNota_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV81TFHistoricoSolicitudesNota_Sel", AV81TFHistoricoSolicitudesNota_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOTIFICACION") == 0 )
            {
               AV82TFHistoricoSolicitudesNotificacion = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV82TFHistoricoSolicitudesNotificacion", AV82TFHistoricoSolicitudesNotificacion);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOTIFICACION_SEL") == 0 )
            {
               AV83TFHistoricoSolicitudesNotificacion_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV83TFHistoricoSolicitudesNotificacion_Sel", AV83TFHistoricoSolicitudesNotificacion_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESORIGENPAGO") == 0 )
            {
               AV84TFHistoricoSolicitudesOrigenPago = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV84TFHistoricoSolicitudesOrigenPago", AV84TFHistoricoSolicitudesOrigenPago);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESORIGENPAGO_SEL") == 0 )
            {
               AV85TFHistoricoSolicitudesOrigenPago_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV85TFHistoricoSolicitudesOrigenPago_Sel", AV85TFHistoricoSolicitudesOrigenPago_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV86TFHistoricoSolicitudesPagado_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV86TFHistoricoSolicitudesPagado_SelsJson", AV86TFHistoricoSolicitudesPagado_SelsJson);
               AV87TFHistoricoSolicitudesPagado_Sels.FromJSonString(AV86TFHistoricoSolicitudesPagado_SelsJson, null);
            }
            AV101GXV1 = (int)(AV101GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)),  AV22TFHistoricoSolicitudesNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)),  AV24TFHistoricoSolicitudesTelefono_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)),  AV26TFHistoricoSolicitudesMail_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)),  AV28TFHistoricoPaisID_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)),  AV36TFHistoricoSolicitudesDireccion_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)),  AV44TFHistoricoSolicitudServicioSolCoti_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)),  AV48TFEstadosSolTipo_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)),  AV50TFEstadosSolNombre_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)),  AV52TFHistoricoSolicitudesOtros1_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)),  AV54TFHistoricoSolicitudesOtros2_Sel, out  GXt_char13) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)),  AV56TFHistoricoSolicitudesOtros3_Sel, out  GXt_char14) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)),  AV73TFHistoricoSolicitudesHoraInstalacion_Sel, out  GXt_char15) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)),  AV75TFHistoricoSolicitudesComentario_Sel, out  GXt_char16) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)),  AV79TFMetodoPagosNombre_Sel, out  GXt_char17) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)),  AV81TFHistoricoSolicitudesNota_Sel, out  GXt_char18) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)),  AV83TFHistoricoSolicitudesNotificacion_Sel, out  GXt_char19) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)),  AV85TFHistoricoSolicitudesOrigenPago_Sel, out  GXt_char20) ;
         GXt_char21 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV87TFHistoricoSolicitudesPagado_Sels.Count==0),  AV86TFHistoricoSolicitudesPagado_SelsJson, out  GXt_char21) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"||||"+GXt_char8+"||||"+GXt_char9+"||"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"|"+GXt_char13+"|"+GXt_char14+"||||"+GXt_char15+"|"+GXt_char16+"||"+GXt_char17+"|"+GXt_char18+"|"+GXt_char19+"|"+GXt_char20+"|"+GXt_char21;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char21 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre)),  AV21TFHistoricoSolicitudesNombre, out  GXt_char21) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono)),  AV23TFHistoricoSolicitudesTelefono, out  GXt_char20) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFHistoricoSolicitudesMail)),  AV25TFHistoricoSolicitudesMail, out  GXt_char19) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHistoricoPaisID)),  AV27TFHistoricoPaisID, out  GXt_char18) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion)),  AV35TFHistoricoSolicitudesDireccion, out  GXt_char17) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti)),  AV43TFHistoricoSolicitudServicioSolCoti, out  GXt_char16) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEstadosSolTipo)),  AV47TFEstadosSolTipo, out  GXt_char15) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEstadosSolNombre)),  AV49TFEstadosSolNombre, out  GXt_char14) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1)),  AV51TFHistoricoSolicitudesOtros1, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2)),  AV53TFHistoricoSolicitudesOtros2, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3)),  AV55TFHistoricoSolicitudesOtros3, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion)),  AV72TFHistoricoSolicitudesHoraInstalacion, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario)),  AV74TFHistoricoSolicitudesComentario, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFMetodoPagosNombre)),  AV78TFMetodoPagosNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFHistoricoSolicitudesNota)),  AV80TFHistoricoSolicitudesNota, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion)),  AV82TFHistoricoSolicitudesNotificacion, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago)),  AV84TFHistoricoSolicitudesOrigenPago, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char21+"|"+GXt_char20+"|"+GXt_char19+"|"+GXt_char18+"|"+((0==AV29TFHistoricoDepartamentoId) ? "" : StringUtil.Str( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0))+"|"+((0==AV31TFHistoricoDepartamentoMunicipioId) ? "" : StringUtil.Str( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0))+"|"+((0==AV33TFHistoricoZonasID) ? "" : StringUtil.Str( (decimal)(AV33TFHistoricoZonasID), 18, 0))+"|"+GXt_char17+"|"+((0==AV37TFHistoricoSolicitudesAutoEnumerar) ? "" : StringUtil.Str( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0))+"|"+((Convert.ToDecimal(0)==AV39TFHistoricoSolicitudesCotizacion) ? "" : StringUtil.Str( AV39TFHistoricoSolicitudesCotizacion, 18, 2))+"|"+((Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesTotal) ? "" : StringUtil.Str( AV41TFHistoricoSolicitudesTotal, 18, 2))+"|"+GXt_char16+"|"+((Convert.ToDecimal(0)==AV45TFHistoricoSolicitudServicioPFinal) ? "" : StringUtil.Str( AV45TFHistoricoSolicitudServicioPFinal, 18, 2))+"|"+GXt_char15+"|"+GXt_char14+"|"+GXt_char13+"|"+GXt_char12+"|"+GXt_char11+"|"+((DateTime.MinValue==AV57TFHistoricoSolicitudesFechaAlta) ? "" : context.localUtil.DToC( AV57TFHistoricoSolicitudesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV62TFHistoricoSolicitudesFechaActualizacion) ? "" : context.localUtil.DToC( AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV67TFHistoricoSolicitudesFechaInstalacion) ? "" : context.localUtil.DToC( AV67TFHistoricoSolicitudesFechaInstalacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char10+"|"+GXt_char9+"|"+((0==AV76TFMetodoPagosID) ? "" : StringUtil.Str( (decimal)(AV76TFMetodoPagosID), 18, 0))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||"+((0==AV30TFHistoricoDepartamentoId_To) ? "" : StringUtil.Str( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0))+"|"+((0==AV32TFHistoricoDepartamentoMunicipioId_To) ? "" : StringUtil.Str( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0))+"|"+((0==AV34TFHistoricoZonasID_To) ? "" : StringUtil.Str( (decimal)(AV34TFHistoricoZonasID_To), 18, 0))+"||"+((0==AV38TFHistoricoSolicitudesAutoEnumerar_To) ? "" : StringUtil.Str( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0))+"|"+((Convert.ToDecimal(0)==AV40TFHistoricoSolicitudesCotizacion_To) ? "" : StringUtil.Str( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesTotal_To) ? "" : StringUtil.Str( AV42TFHistoricoSolicitudesTotal_To, 18, 2))+"||"+((Convert.ToDecimal(0)==AV46TFHistoricoSolicitudServicioPFinal_To) ? "" : StringUtil.Str( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2))+"||||||"+((DateTime.MinValue==AV58TFHistoricoSolicitudesFechaAlta_To) ? "" : context.localUtil.DToC( AV58TFHistoricoSolicitudesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV63TFHistoricoSolicitudesFechaActualizacion_To) ? "" : context.localUtil.DToC( AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV68TFHistoricoSolicitudesFechaInstalacion_To) ? "" : context.localUtil.DToC( AV68TFHistoricoSolicitudesFechaInstalacion_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|||"+((0==AV77TFMetodoPagosID_To) ? "" : StringUtil.Str( (decimal)(AV77TFMetodoPagosID_To), 18, 0))+"|||||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV100Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESNOMBRE",  context.GetMessage( "Solicitudes Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre)),  0,  AV21TFHistoricoSolicitudesNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)),  AV22TFHistoricoSolicitudesNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESTELEFONO",  context.GetMessage( "Solicitudes Telefono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono)),  0,  AV23TFHistoricoSolicitudesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)),  AV24TFHistoricoSolicitudesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESMAIL",  context.GetMessage( "Solicitudes Mail", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFHistoricoSolicitudesMail)),  0,  AV25TFHistoricoSolicitudesMail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)),  AV26TFHistoricoSolicitudesMail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOPAISID",  context.GetMessage( "Pais ID", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHistoricoPaisID)),  0,  AV27TFHistoricoPaisID,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)),  AV28TFHistoricoPaisID_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICODEPARTAMENTOID",  context.GetMessage( "Departamento Id", ""),  !((0==AV29TFHistoricoDepartamentoId)&&(0==AV30TFHistoricoDepartamentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFHistoricoDepartamentoId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFHistoricoDepartamentoId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICODEPARTAMENTOMUNICIPIOID",  context.GetMessage( "Municipio Id", ""),  !((0==AV31TFHistoricoDepartamentoMunicipioId)&&(0==AV32TFHistoricoDepartamentoMunicipioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFHistoricoDepartamentoMunicipioId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFHistoricoDepartamentoMunicipioId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOZONASID",  context.GetMessage( "Zonas ID", ""),  !((0==AV33TFHistoricoZonasID)&&(0==AV34TFHistoricoZonasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFHistoricoZonasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFHistoricoZonasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESDIRECCION",  context.GetMessage( "Solicitudes Direccion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion)),  0,  AV35TFHistoricoSolicitudesDireccion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)),  AV36TFHistoricoSolicitudesDireccion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESAUTOENUMERAR",  context.GetMessage( "Auto Enumerar", ""),  !((0==AV37TFHistoricoSolicitudesAutoEnumerar)&&(0==AV38TFHistoricoSolicitudesAutoEnumerar_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFHistoricoSolicitudesAutoEnumerar), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFHistoricoSolicitudesAutoEnumerar_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESCOTIZACION",  context.GetMessage( "Solicitudes Cotizacion", ""),  !((Convert.ToDecimal(0)==AV39TFHistoricoSolicitudesCotizacion)&&(Convert.ToDecimal(0)==AV40TFHistoricoSolicitudesCotizacion_To)),  0,  StringUtil.Trim( StringUtil.Str( AV39TFHistoricoSolicitudesCotizacion, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV40TFHistoricoSolicitudesCotizacion_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESTOTAL",  context.GetMessage( "Solicitudes Total", ""),  !((Convert.ToDecimal(0)==AV41TFHistoricoSolicitudesTotal)&&(Convert.ToDecimal(0)==AV42TFHistoricoSolicitudesTotal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV41TFHistoricoSolicitudesTotal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV42TFHistoricoSolicitudesTotal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDSERVICIOSOLCOTI",  context.GetMessage( "Sol Coti", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti)),  0,  AV43TFHistoricoSolicitudServicioSolCoti,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)),  AV44TFHistoricoSolicitudServicioSolCoti_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDSERVICIOPFINAL",  context.GetMessage( "Servicio PFinal", ""),  !((Convert.ToDecimal(0)==AV45TFHistoricoSolicitudServicioPFinal)&&(Convert.ToDecimal(0)==AV46TFHistoricoSolicitudServicioPFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV45TFHistoricoSolicitudServicioPFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV46TFHistoricoSolicitudServicioPFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSSOLTIPO",  context.GetMessage( "Sol Tipo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEstadosSolTipo)),  0,  AV47TFEstadosSolTipo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)),  AV48TFEstadosSolTipo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSSOLNOMBRE",  context.GetMessage( "Sol Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEstadosSolNombre)),  0,  AV49TFEstadosSolNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)),  AV50TFEstadosSolNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESOTROS1",  context.GetMessage( "Solicitudes Otros1", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1)),  0,  AV51TFHistoricoSolicitudesOtros1,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)),  AV52TFHistoricoSolicitudesOtros1_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESOTROS2",  context.GetMessage( "Solicitudes Otros2", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2)),  0,  AV53TFHistoricoSolicitudesOtros2,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)),  AV54TFHistoricoSolicitudesOtros2_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESOTROS3",  context.GetMessage( "Solicitudes Otros3", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3)),  0,  AV55TFHistoricoSolicitudesOtros3,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)),  AV56TFHistoricoSolicitudesOtros3_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESFECHAALTA",  context.GetMessage( "Fecha Alta", ""),  !((DateTime.MinValue==AV57TFHistoricoSolicitudesFechaAlta)&&(DateTime.MinValue==AV58TFHistoricoSolicitudesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV57TFHistoricoSolicitudesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV58TFHistoricoSolicitudesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESFECHAACTUALIZACION",  context.GetMessage( "Fecha Actualizacion", ""),  !((DateTime.MinValue==AV62TFHistoricoSolicitudesFechaActualizacion)&&(DateTime.MinValue==AV63TFHistoricoSolicitudesFechaActualizacion_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV62TFHistoricoSolicitudesFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV63TFHistoricoSolicitudesFechaActualizacion_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESFECHAINSTALACION",  context.GetMessage( "Fecha Instalacion", ""),  !((DateTime.MinValue==AV67TFHistoricoSolicitudesFechaInstalacion)&&(DateTime.MinValue==AV68TFHistoricoSolicitudesFechaInstalacion_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV67TFHistoricoSolicitudesFechaInstalacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV68TFHistoricoSolicitudesFechaInstalacion_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESHORAINSTALACION",  context.GetMessage( "Hora Instalacion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion)),  0,  AV72TFHistoricoSolicitudesHoraInstalacion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)),  AV73TFHistoricoSolicitudesHoraInstalacion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESCOMENTARIO",  context.GetMessage( "Solicitudes Comentario", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario)),  0,  AV74TFHistoricoSolicitudesComentario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)),  AV75TFHistoricoSolicitudesComentario_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFMETODOPAGOSID",  context.GetMessage( "Id", ""),  !((0==AV76TFMetodoPagosID)&&(0==AV77TFMetodoPagosID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV76TFMetodoPagosID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV77TFMetodoPagosID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFMETODOPAGOSNOMBRE",  context.GetMessage( "Metodo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFMetodoPagosNombre)),  0,  AV78TFMetodoPagosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)),  AV79TFMetodoPagosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESNOTA",  context.GetMessage( "Solicitudes Nota", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFHistoricoSolicitudesNota)),  0,  AV80TFHistoricoSolicitudesNota,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)),  AV81TFHistoricoSolicitudesNota_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESNOTIFICACION",  context.GetMessage( "Solicitudes Notificacion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion)),  0,  AV82TFHistoricoSolicitudesNotificacion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)),  AV83TFHistoricoSolicitudesNotificacion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESORIGENPAGO",  context.GetMessage( "Origen Pago", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago)),  0,  AV84TFHistoricoSolicitudesOrigenPago,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)),  AV85TFHistoricoSolicitudesOrigenPago_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFHISTORICOSOLICITUDESPAGADO_SEL",  context.GetMessage( "Solicitudes Pagado", ""),  !(AV87TFHistoricoSolicitudesPagado_Sels.Count==0),  0,  AV87TFHistoricoSolicitudesPagado_Sels.ToJSonString(false),  "") ;
         if ( ! (0==AV8HistoricoSolicitudesID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&HISTORICOSOLICITUDESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8HistoricoSolicitudesID), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV100Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV100Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "HistoricoSolicitudes";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "HistoricoSolicitudesID";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8HistoricoSolicitudesID), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_18_2Q2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_23_2Q2( true) ;
         }
         else
         {
            wb_table2_23_2Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_23_2Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_18_2Q2e( true) ;
         }
         else
         {
            wb_table1_18_2Q2e( false) ;
         }
      }

      protected void wb_table2_23_2Q2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'" + sGXsfl_33_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_HistoricoRelacionesItemsWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_23_2Q2e( true) ;
         }
         else
         {
            wb_table2_23_2Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
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
         PA2Q2( ) ;
         WS2Q2( ) ;
         WE2Q2( ) ;
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
         sCtrlAV8HistoricoSolicitudesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "historicorelacionesitemswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Q2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
         }
         wcpOAV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8HistoricoSolicitudesID != wcpOAV8HistoricoSolicitudesID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8HistoricoSolicitudesID = AV8HistoricoSolicitudesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8HistoricoSolicitudesID = cgiGet( sPrefix+"AV8HistoricoSolicitudesID_CTRL");
         if ( StringUtil.Len( sCtrlAV8HistoricoSolicitudesID) > 0 )
         {
            AV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8HistoricoSolicitudesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV8HistoricoSolicitudesID), 18, 0));
         }
         else
         {
            AV8HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8HistoricoSolicitudesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA2Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Q2( ) ;
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
         WS2Q2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8HistoricoSolicitudesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8HistoricoSolicitudesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8HistoricoSolicitudesID_CTRL", StringUtil.RTrim( sCtrlAV8HistoricoSolicitudesID));
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
         WE2Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622211548", true, true, false);
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
         context.AddJavascriptSource("historicorelacionesitemswc.js", "?20268622211548", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_332( )
      {
         edtHistoricoSolicitudesNombre_Internalname = sPrefix+"HISTORICOSOLICITUDESNOMBRE_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesTelefono_Internalname = sPrefix+"HISTORICOSOLICITUDESTELEFONO_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesMail_Internalname = sPrefix+"HISTORICOSOLICITUDESMAIL_"+sGXsfl_33_idx;
         edtHistoricoPaisID_Internalname = sPrefix+"HISTORICOPAISID_"+sGXsfl_33_idx;
         edtHistoricoDepartamentoId_Internalname = sPrefix+"HISTORICODEPARTAMENTOID_"+sGXsfl_33_idx;
         edtHistoricoDepartamentoMunicipio_Internalname = sPrefix+"HISTORICODEPARTAMENTOMUNICIPIO_"+sGXsfl_33_idx;
         edtHistoricoZonasID_Internalname = sPrefix+"HISTORICOZONASID_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesDireccion_Internalname = sPrefix+"HISTORICOSOLICITUDESDIRECCION_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesAutoEnumer_Internalname = sPrefix+"HISTORICOSOLICITUDESAUTOENUMER_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesCotizacion_Internalname = sPrefix+"HISTORICOSOLICITUDESCOTIZACION_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesTotal_Internalname = sPrefix+"HISTORICOSOLICITUDESTOTAL_"+sGXsfl_33_idx;
         edtHistoricoSolicitudServicioSolC_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOSOLC_"+sGXsfl_33_idx;
         edtHistoricoSolicitudServicioPFin_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOPFIN_"+sGXsfl_33_idx;
         edtEstadosSolTipo_Internalname = sPrefix+"ESTADOSSOLTIPO_"+sGXsfl_33_idx;
         edtEstadosSolId_Internalname = sPrefix+"ESTADOSSOLID_"+sGXsfl_33_idx;
         edtEstadosSolNombre_Internalname = sPrefix+"ESTADOSSOLNOMBRE_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesOtros1_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS1_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesOtros2_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS2_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesOtros3_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS3_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesFechaAlta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAALTA_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesFechaActua_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAACTUA_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesFechaInsta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAINSTA_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesHoraInstal_Internalname = sPrefix+"HISTORICOSOLICITUDESHORAINSTAL_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesComentario_Internalname = sPrefix+"HISTORICOSOLICITUDESCOMENTARIO_"+sGXsfl_33_idx;
         edtMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID_"+sGXsfl_33_idx;
         edtMetodoPagosNombre_Internalname = sPrefix+"METODOPAGOSNOMBRE_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesNota_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTA_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesNotificaci_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTIFICACI_"+sGXsfl_33_idx;
         edtHistoricoSolicitudesOrigenPago_Internalname = sPrefix+"HISTORICOSOLICITUDESORIGENPAGO_"+sGXsfl_33_idx;
         cmbHistoricoSolicitudesPagado_Internalname = sPrefix+"HISTORICOSOLICITUDESPAGADO_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_332( )
      {
         edtHistoricoSolicitudesNombre_Internalname = sPrefix+"HISTORICOSOLICITUDESNOMBRE_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesTelefono_Internalname = sPrefix+"HISTORICOSOLICITUDESTELEFONO_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesMail_Internalname = sPrefix+"HISTORICOSOLICITUDESMAIL_"+sGXsfl_33_fel_idx;
         edtHistoricoPaisID_Internalname = sPrefix+"HISTORICOPAISID_"+sGXsfl_33_fel_idx;
         edtHistoricoDepartamentoId_Internalname = sPrefix+"HISTORICODEPARTAMENTOID_"+sGXsfl_33_fel_idx;
         edtHistoricoDepartamentoMunicipio_Internalname = sPrefix+"HISTORICODEPARTAMENTOMUNICIPIO_"+sGXsfl_33_fel_idx;
         edtHistoricoZonasID_Internalname = sPrefix+"HISTORICOZONASID_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesDireccion_Internalname = sPrefix+"HISTORICOSOLICITUDESDIRECCION_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesAutoEnumer_Internalname = sPrefix+"HISTORICOSOLICITUDESAUTOENUMER_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesCotizacion_Internalname = sPrefix+"HISTORICOSOLICITUDESCOTIZACION_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesTotal_Internalname = sPrefix+"HISTORICOSOLICITUDESTOTAL_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudServicioSolC_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOSOLC_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudServicioPFin_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOPFIN_"+sGXsfl_33_fel_idx;
         edtEstadosSolTipo_Internalname = sPrefix+"ESTADOSSOLTIPO_"+sGXsfl_33_fel_idx;
         edtEstadosSolId_Internalname = sPrefix+"ESTADOSSOLID_"+sGXsfl_33_fel_idx;
         edtEstadosSolNombre_Internalname = sPrefix+"ESTADOSSOLNOMBRE_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesOtros1_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS1_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesOtros2_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS2_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesOtros3_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS3_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesFechaAlta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAALTA_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesFechaActua_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAACTUA_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesFechaInsta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAINSTA_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesHoraInstal_Internalname = sPrefix+"HISTORICOSOLICITUDESHORAINSTAL_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesComentario_Internalname = sPrefix+"HISTORICOSOLICITUDESCOMENTARIO_"+sGXsfl_33_fel_idx;
         edtMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID_"+sGXsfl_33_fel_idx;
         edtMetodoPagosNombre_Internalname = sPrefix+"METODOPAGOSNOMBRE_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesNota_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTA_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesNotificaci_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTIFICACI_"+sGXsfl_33_fel_idx;
         edtHistoricoSolicitudesOrigenPago_Internalname = sPrefix+"HISTORICOSOLICITUDESORIGENPAGO_"+sGXsfl_33_fel_idx;
         cmbHistoricoSolicitudesPagado_Internalname = sPrefix+"HISTORICOSOLICITUDESPAGADO_"+sGXsfl_33_fel_idx;
      }

      protected void sendrow_332( )
      {
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_332( ) ;
         WB2Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_33_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_33_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesNombre_Internalname,StringUtil.RTrim( A288HistoricoSolicitudesNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A289HistoricoSolicitudesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesTelefono_Internalname,StringUtil.RTrim( A289HistoricoSolicitudesTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesMail_Internalname,(string)A290HistoricoSolicitudesMail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A290HistoricoSolicitudesMail,(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoPaisID_Internalname,StringUtil.RTrim( A315HistoricoPaisID),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A316HistoricoDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A316HistoricoDepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoDepartamentoMunicipio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A317HistoricoDepartamentoMunicipio), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoDepartamentoMunicipio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoZonasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A318HistoricoZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A318HistoricoZonasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoZonasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesDireccion_Internalname,(string)A291HistoricoSolicitudesDireccion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesAutoEnumer_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A292HistoricoSolicitudesAutoEnumer), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesAutoEnumer_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesCotizacion_Internalname,StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesCotizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A300HistoricoSolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudServicioSolC_Internalname,StringUtil.RTrim( A301HistoricoSolicitudServicioSolC),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudServicioSolC_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudServicioPFin_Internalname,StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudServicioPFin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolTipo_Internalname,StringUtil.RTrim( A130EstadosSolTipo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosSolNombre_Internalname,StringUtil.RTrim( A132EstadosSolNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtEstadosSolNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosSolNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesOtros1_Internalname,StringUtil.RTrim( A303HistoricoSolicitudesOtros1),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesOtros1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesOtros2_Internalname,StringUtil.RTrim( A304HistoricoSolicitudesOtros2),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesOtros2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesOtros3_Internalname,StringUtil.RTrim( A305HistoricoSolicitudesOtros3),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesOtros3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesFechaAlta_Internalname,context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"),context.localUtil.Format( A306HistoricoSolicitudesFechaAlta, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesFechaActua_Internalname,context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A307HistoricoSolicitudesFechaActua, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesFechaActua_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesFechaInsta_Internalname,context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"),context.localUtil.Format( A308HistoricoSolicitudesFechaInsta, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesFechaInsta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesHoraInstal_Internalname,StringUtil.RTrim( A309HistoricoSolicitudesHoraInstal),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesHoraInstal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesComentario_Internalname,(string)A310HistoricoSolicitudesComentario,(string)A310HistoricoSolicitudesComentario,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesComentario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)33,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMetodoPagosID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMetodoPagosID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMetodoPagosNombre_Internalname,StringUtil.RTrim( A129MetodoPagosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtMetodoPagosNombre_Link,(string)"",(string)"",(string)"",(string)edtMetodoPagosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesNota_Internalname,StringUtil.RTrim( A311HistoricoSolicitudesNota),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesNota_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesNotificaci_Internalname,StringUtil.RTrim( A312HistoricoSolicitudesNotificaci),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesNotificaci_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesOrigenPago_Internalname,StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesOrigenPago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbHistoricoSolicitudesPagado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "HISTORICOSOLICITUDESPAGADO_" + sGXsfl_33_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbHistoricoSolicitudesPagado,(string)cmbHistoricoSolicitudesPagado_Internalname,StringUtil.RTrim( A442HistoricoSolicitudesPagado),(short)1,(string)cmbHistoricoSolicitudesPagado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
            AssignProp(sPrefix, false, cmbHistoricoSolicitudesPagado_Internalname, "Values", (string)(cmbHistoricoSolicitudesPagado.ToJavascriptSource()), !bGXsfl_33_Refreshing);
            send_integrity_lvl_hashes2Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_33_idx = ((subGrid_Islastpage==1)&&(nGXsfl_33_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_332( ) ;
         }
         /* End function sendrow_332 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "HISTORICOSOLICITUDESPAGADO_" + sGXsfl_33_idx;
         cmbHistoricoSolicitudesPagado.Name = GXCCtl;
         cmbHistoricoSolicitudesPagado.WebTags = "";
         cmbHistoricoSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbHistoricoSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl33( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"33\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Telefono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pais ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Municipio Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Zonas ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Direccion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Auto Enumerar", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Cotizacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Total", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Coti", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Servicio PFinal", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Sol Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Otros1", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Otros2", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Otros3", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Actualizacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Instalacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora Instalacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Comentario", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Metodo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Nota", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Notificacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Pagado", "")) ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A288HistoricoSolicitudesNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A289HistoricoSolicitudesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A290HistoricoSolicitudesMail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A315HistoricoPaisID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A316HistoricoDepartamentoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A318HistoricoZonasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A291HistoricoSolicitudesDireccion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A301HistoricoSolicitudServicioSolC)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A130EstadosSolTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132EstadosSolNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosSolNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A303HistoricoSolicitudesOtros1)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A304HistoricoSolicitudesOtros2)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A305HistoricoSolicitudesOtros3)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A309HistoricoSolicitudesHoraInstal)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A310HistoricoSolicitudesComentario));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A129MetodoPagosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMetodoPagosNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A311HistoricoSolicitudesNota)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A312HistoricoSolicitudesNotificaci)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A442HistoricoSolicitudesPagado)));
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
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         tblTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         tblTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtHistoricoSolicitudesNombre_Internalname = sPrefix+"HISTORICOSOLICITUDESNOMBRE";
         edtHistoricoSolicitudesTelefono_Internalname = sPrefix+"HISTORICOSOLICITUDESTELEFONO";
         edtHistoricoSolicitudesMail_Internalname = sPrefix+"HISTORICOSOLICITUDESMAIL";
         edtHistoricoPaisID_Internalname = sPrefix+"HISTORICOPAISID";
         edtHistoricoDepartamentoId_Internalname = sPrefix+"HISTORICODEPARTAMENTOID";
         edtHistoricoDepartamentoMunicipio_Internalname = sPrefix+"HISTORICODEPARTAMENTOMUNICIPIO";
         edtHistoricoZonasID_Internalname = sPrefix+"HISTORICOZONASID";
         edtHistoricoSolicitudesDireccion_Internalname = sPrefix+"HISTORICOSOLICITUDESDIRECCION";
         edtHistoricoSolicitudesAutoEnumer_Internalname = sPrefix+"HISTORICOSOLICITUDESAUTOENUMER";
         edtHistoricoSolicitudesCotizacion_Internalname = sPrefix+"HISTORICOSOLICITUDESCOTIZACION";
         edtHistoricoSolicitudesTotal_Internalname = sPrefix+"HISTORICOSOLICITUDESTOTAL";
         edtHistoricoSolicitudServicioSolC_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOSOLC";
         edtHistoricoSolicitudServicioPFin_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOPFIN";
         edtEstadosSolTipo_Internalname = sPrefix+"ESTADOSSOLTIPO";
         edtEstadosSolId_Internalname = sPrefix+"ESTADOSSOLID";
         edtEstadosSolNombre_Internalname = sPrefix+"ESTADOSSOLNOMBRE";
         edtHistoricoSolicitudesOtros1_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS1";
         edtHistoricoSolicitudesOtros2_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS2";
         edtHistoricoSolicitudesOtros3_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS3";
         edtHistoricoSolicitudesFechaAlta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAALTA";
         edtHistoricoSolicitudesFechaActua_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAACTUA";
         edtHistoricoSolicitudesFechaInsta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAINSTA";
         edtHistoricoSolicitudesHoraInstal_Internalname = sPrefix+"HISTORICOSOLICITUDESHORAINSTAL";
         edtHistoricoSolicitudesComentario_Internalname = sPrefix+"HISTORICOSOLICITUDESCOMENTARIO";
         edtMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID";
         edtMetodoPagosNombre_Internalname = sPrefix+"METODOPAGOSNOMBRE";
         edtHistoricoSolicitudesNota_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTA";
         edtHistoricoSolicitudesNotificaci_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTIFICACI";
         edtHistoricoSolicitudesOrigenPago_Internalname = sPrefix+"HISTORICOSOLICITUDESORIGENPAGO";
         cmbHistoricoSolicitudesPagado_Internalname = sPrefix+"HISTORICOSOLICITUDESPAGADO";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtHistoricoSolicitudesID_Internalname = sPrefix+"HISTORICOSOLICITUDESID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_historicosolicitudesfechaaltaauxdatetext_Internalname = sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAALTAAUXDATETEXT";
         Tfhistoricosolicitudesfechaalta_rangepicker_Internalname = sPrefix+"TFHISTORICOSOLICITUDESFECHAALTA_RANGEPICKER";
         divDdo_historicosolicitudesfechaaltaauxdates_Internalname = sPrefix+"DDO_HISTORICOSOLICITUDESFECHAALTAAUXDATES";
         edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Internalname = sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATETEXT";
         Tfhistoricosolicitudesfechaactualizacion_rangepicker_Internalname = sPrefix+"TFHISTORICOSOLICITUDESFECHAACTUALIZACION_RANGEPICKER";
         divDdo_historicosolicitudesfechaactualizacionauxdates_Internalname = sPrefix+"DDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATES";
         edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Internalname = sPrefix+"vDDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATETEXT";
         Tfhistoricosolicitudesfechainstalacion_rangepicker_Internalname = sPrefix+"TFHISTORICOSOLICITUDESFECHAINSTALACION_RANGEPICKER";
         divDdo_historicosolicitudesfechainstalacionauxdates_Internalname = sPrefix+"DDO_HISTORICOSOLICITUDESFECHAINSTALACIONAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         cmbHistoricoSolicitudesPagado_Jsonclick = "";
         edtHistoricoSolicitudesOrigenPago_Jsonclick = "";
         edtHistoricoSolicitudesNotificaci_Jsonclick = "";
         edtHistoricoSolicitudesNota_Jsonclick = "";
         edtMetodoPagosNombre_Jsonclick = "";
         edtMetodoPagosNombre_Link = "";
         edtMetodoPagosID_Jsonclick = "";
         edtHistoricoSolicitudesComentario_Jsonclick = "";
         edtHistoricoSolicitudesHoraInstal_Jsonclick = "";
         edtHistoricoSolicitudesFechaInsta_Jsonclick = "";
         edtHistoricoSolicitudesFechaActua_Jsonclick = "";
         edtHistoricoSolicitudesFechaAlta_Jsonclick = "";
         edtHistoricoSolicitudesOtros3_Jsonclick = "";
         edtHistoricoSolicitudesOtros2_Jsonclick = "";
         edtHistoricoSolicitudesOtros1_Jsonclick = "";
         edtEstadosSolNombre_Jsonclick = "";
         edtEstadosSolNombre_Link = "";
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolTipo_Jsonclick = "";
         edtHistoricoSolicitudServicioPFin_Jsonclick = "";
         edtHistoricoSolicitudServicioSolC_Jsonclick = "";
         edtHistoricoSolicitudesTotal_Jsonclick = "";
         edtHistoricoSolicitudesCotizacion_Jsonclick = "";
         edtHistoricoSolicitudesAutoEnumer_Jsonclick = "";
         edtHistoricoSolicitudesDireccion_Jsonclick = "";
         edtHistoricoZonasID_Jsonclick = "";
         edtHistoricoDepartamentoMunicipio_Jsonclick = "";
         edtHistoricoDepartamentoId_Jsonclick = "";
         edtHistoricoPaisID_Jsonclick = "";
         edtHistoricoSolicitudesMail_Jsonclick = "";
         edtHistoricoSolicitudesTelefono_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtHistoricoSolicitudesID_Enabled = 0;
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         edtHistoricoSolicitudesNotificaci_Enabled = 0;
         edtHistoricoSolicitudesNota_Enabled = 0;
         edtMetodoPagosNombre_Enabled = 0;
         edtMetodoPagosID_Enabled = 0;
         edtHistoricoSolicitudesComentario_Enabled = 0;
         edtHistoricoSolicitudesHoraInstal_Enabled = 0;
         edtHistoricoSolicitudesFechaInsta_Enabled = 0;
         edtHistoricoSolicitudesFechaActua_Enabled = 0;
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         edtHistoricoSolicitudesOtros3_Enabled = 0;
         edtHistoricoSolicitudesOtros2_Enabled = 0;
         edtHistoricoSolicitudesOtros1_Enabled = 0;
         edtEstadosSolNombre_Enabled = 0;
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolTipo_Enabled = 0;
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtHistoricoSolicitudServicioSolC_Enabled = 0;
         edtHistoricoSolicitudesTotal_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         edtHistoricoSolicitudesAutoEnumer_Enabled = 0;
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         edtHistoricoZonasID_Enabled = 0;
         edtHistoricoDepartamentoMunicipio_Enabled = 0;
         edtHistoricoDepartamentoId_Enabled = 0;
         edtHistoricoPaisID_Enabled = 0;
         edtHistoricoSolicitudesMail_Enabled = 0;
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         edtHistoricoSolicitudesNombre_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Jsonclick = "";
         edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Jsonclick = "";
         edtavDdo_historicosolicitudesfechaaltaauxdatetext_Jsonclick = "";
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||||18.0|18.0|18.0||4.0|-18.2|-18.2||18.2|||||||||||18.0|||||";
         Ddo_grid_Datalistproc = "HistoricoRelacionesItemsWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||||||||||||||||||||||||S:Pagado,N:Pendiente de Pago";
         Ddo_grid_Allowmultipleselection = "||||||||||||||||||||||||||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic||||Dynamic||||Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||||Dynamic|Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T|T|T|T||||T||||T||T|T|T|T|T||||T|T||T|T|T|T|T";
         Ddo_grid_Filterisrange = "||||T|T|T||T|T|T||T||||||P|P|P|||T|||||";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Numeric|Numeric|Numeric|Character|Numeric|Numeric|Numeric|Character|Numeric|Character|Character|Character|Character|Character|Date|Date|Date|Character|Character|Numeric|Character|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|T|T|T||T||T|T|T|T|T|T|T|T|T|T|T|T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10||11||12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27";
         Ddo_grid_Columnids = "0:HistoricoSolicitudesNombre|1:HistoricoSolicitudesTelefono|2:HistoricoSolicitudesMail|3:HistoricoPaisID|4:HistoricoDepartamentoId|5:HistoricoDepartamentoMunicipioId|6:HistoricoZonasID|7:HistoricoSolicitudesDireccion|8:HistoricoSolicitudesAutoEnumerar|9:HistoricoSolicitudesCotizacion|10:HistoricoSolicitudesTotal|11:HistoricoSolicitudServicioSolCoti|12:HistoricoSolicitudServicioPFinal|13:EstadosSolTipo|15:EstadosSolNombre|16:HistoricoSolicitudesOtros1|17:HistoricoSolicitudesOtros2|18:HistoricoSolicitudesOtros3|19:HistoricoSolicitudesFechaAlta|20:HistoricoSolicitudesFechaActualizacion|21:HistoricoSolicitudesFechaInstalacion|22:HistoricoSolicitudesHoraInstalacion|23:HistoricoSolicitudesComentario|24:MetodoPagosID|25:MetodoPagosNombre|26:HistoricoSolicitudesNota|27:HistoricoSolicitudesNotificacion|28:HistoricoSolicitudesOrigenPago|29:HistoricoSolicitudesPagado";
         Ddo_grid_Gridinternalname = "";
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
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV91GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV92GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E122Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV91GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV92GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV86TFHistoricoSolicitudesPagado_SelsJson',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E172Q2',iparms:[{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtEstadosSolNombre_Link',ctrl:'ESTADOSSOLNOMBRE',prop:'Link'},{av:'edtMetodoPagosNombre_Link',ctrl:'METODOPAGOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E112Q2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV100Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'AV99IsAuthorized_EstadosSolNombre',fld:'vISAUTHORIZED_ESTADOSSOLNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV97IsAuthorized_MetodoPagosNombre',fld:'vISAUTHORIZED_METODOPAGOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV86TFHistoricoSolicitudesPagado_SelsJson',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate',fld:'vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATE',pic:'',type:'date'},{av:'AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo',fld:'vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATETO',pic:'',type:'date'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFHistoricoSolicitudesNombre',fld:'vTFHISTORICOSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV22TFHistoricoSolicitudesNombre_Sel',fld:'vTFHISTORICOSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFHistoricoSolicitudesTelefono',fld:'vTFHISTORICOSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV24TFHistoricoSolicitudesTelefono_Sel',fld:'vTFHISTORICOSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV25TFHistoricoSolicitudesMail',fld:'vTFHISTORICOSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV26TFHistoricoSolicitudesMail_Sel',fld:'vTFHISTORICOSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV27TFHistoricoPaisID',fld:'vTFHISTORICOPAISID',pic:'',type:'char'},{av:'AV28TFHistoricoPaisID_Sel',fld:'vTFHISTORICOPAISID_SEL',pic:'',type:'char'},{av:'AV29TFHistoricoDepartamentoId',fld:'vTFHISTORICODEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFHistoricoDepartamentoId_To',fld:'vTFHISTORICODEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFHistoricoDepartamentoMunicipioId',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFHistoricoDepartamentoMunicipioId_To',fld:'vTFHISTORICODEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFHistoricoZonasID',fld:'vTFHISTORICOZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFHistoricoZonasID_To',fld:'vTFHISTORICOZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFHistoricoSolicitudesDireccion',fld:'vTFHISTORICOSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFHistoricoSolicitudesDireccion_Sel',fld:'vTFHISTORICOSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFHistoricoSolicitudesAutoEnumerar',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'AV38TFHistoricoSolicitudesAutoEnumerar_To',fld:'vTFHISTORICOSOLICITUDESAUTOENUMERAR_TO',pic:'ZZZ9',type:'int'},{av:'AV39TFHistoricoSolicitudesCotizacion',fld:'vTFHISTORICOSOLICITUDESCOTIZACION',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV40TFHistoricoSolicitudesCotizacion_To',fld:'vTFHISTORICOSOLICITUDESCOTIZACION_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFHistoricoSolicitudesTotal',fld:'vTFHISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFHistoricoSolicitudesTotal_To',fld:'vTFHISTORICOSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV43TFHistoricoSolicitudServicioSolCoti',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI',pic:'',type:'char'},{av:'AV44TFHistoricoSolicitudServicioSolCoti_Sel',fld:'vTFHISTORICOSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV45TFHistoricoSolicitudServicioPFinal',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV46TFHistoricoSolicitudServicioPFinal_To',fld:'vTFHISTORICOSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFEstadosSolTipo',fld:'vTFESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV48TFEstadosSolTipo_Sel',fld:'vTFESTADOSSOLTIPO_SEL',pic:'',type:'char'},{av:'AV49TFEstadosSolNombre',fld:'vTFESTADOSSOLNOMBRE',pic:'',type:'char'},{av:'AV50TFEstadosSolNombre_Sel',fld:'vTFESTADOSSOLNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFHistoricoSolicitudesOtros1',fld:'vTFHISTORICOSOLICITUDESOTROS1',pic:'',type:'char'},{av:'AV52TFHistoricoSolicitudesOtros1_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS1_SEL',pic:'',type:'char'},{av:'AV53TFHistoricoSolicitudesOtros2',fld:'vTFHISTORICOSOLICITUDESOTROS2',pic:'',type:'char'},{av:'AV54TFHistoricoSolicitudesOtros2_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS2_SEL',pic:'',type:'char'},{av:'AV55TFHistoricoSolicitudesOtros3',fld:'vTFHISTORICOSOLICITUDESOTROS3',pic:'',type:'char'},{av:'AV56TFHistoricoSolicitudesOtros3_Sel',fld:'vTFHISTORICOSOLICITUDESOTROS3_SEL',pic:'',type:'char'},{av:'AV57TFHistoricoSolicitudesFechaAlta',fld:'vTFHISTORICOSOLICITUDESFECHAALTA',pic:'',type:'date'},{av:'AV58TFHistoricoSolicitudesFechaAlta_To',fld:'vTFHISTORICOSOLICITUDESFECHAALTA_TO',pic:'',type:'date'},{av:'AV62TFHistoricoSolicitudesFechaActualizacion',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV63TFHistoricoSolicitudesFechaActualizacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAACTUALIZACION_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV67TFHistoricoSolicitudesFechaInstalacion',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION',pic:'',type:'date'},{av:'AV68TFHistoricoSolicitudesFechaInstalacion_To',fld:'vTFHISTORICOSOLICITUDESFECHAINSTALACION_TO',pic:'',type:'date'},{av:'AV72TFHistoricoSolicitudesHoraInstalacion',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION',pic:'',type:'char'},{av:'AV73TFHistoricoSolicitudesHoraInstalacion_Sel',fld:'vTFHISTORICOSOLICITUDESHORAINSTALACION_SEL',pic:'',type:'char'},{av:'AV74TFHistoricoSolicitudesComentario',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO',pic:'',type:'svchar'},{av:'AV75TFHistoricoSolicitudesComentario_Sel',fld:'vTFHISTORICOSOLICITUDESCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV76TFMetodoPagosID',fld:'vTFMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV77TFMetodoPagosID_To',fld:'vTFMETODOPAGOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV78TFMetodoPagosNombre',fld:'vTFMETODOPAGOSNOMBRE',pic:'',type:'char'},{av:'AV79TFMetodoPagosNombre_Sel',fld:'vTFMETODOPAGOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV80TFHistoricoSolicitudesNota',fld:'vTFHISTORICOSOLICITUDESNOTA',pic:'',type:'char'},{av:'AV81TFHistoricoSolicitudesNota_Sel',fld:'vTFHISTORICOSOLICITUDESNOTA_SEL',pic:'',type:'char'},{av:'AV82TFHistoricoSolicitudesNotificacion',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION',pic:'',type:'char'},{av:'AV83TFHistoricoSolicitudesNotificacion_Sel',fld:'vTFHISTORICOSOLICITUDESNOTIFICACION_SEL',pic:'',type:'char'},{av:'AV84TFHistoricoSolicitudesOrigenPago',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO',pic:'',type:'char'},{av:'AV85TFHistoricoSolicitudesOrigenPago_Sel',fld:'vTFHISTORICOSOLICITUDESORIGENPAGO_SEL',pic:'',type:'char'},{av:'AV87TFHistoricoSolicitudesPagado_Sels',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV86TFHistoricoSolicitudesPagado_SelsJson',fld:'vTFHISTORICOSOLICITUDESPAGADO_SELSJSON',pic:'',type:'vchar'},{av:'AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate',fld:'vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATE',pic:'',type:'date'},{av:'AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo',fld:'vDDO_HISTORICOSOLICITUDESFECHAACTUALIZACIONAUXDATETO',pic:'',type:'date'},{av:'AV91GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV92GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV93GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID","{handler:'Valid_Historicosolicitudesid',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOMBRE","{handler:'Valid_Historicosolicitudesnombre',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTELEFONO","{handler:'Valid_Historicosolicitudestelefono',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL","{handler:'Valid_Historicosolicitudesmail',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOPAISID","{handler:'Valid_Historicopaisid',iparms:[]");
         setEventMetadata("VALID_HISTORICOPAISID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICODEPARTAMENTOID","{handler:'Valid_Historicodepartamentoid',iparms:[]");
         setEventMetadata("VALID_HISTORICODEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICODEPARTAMENTOMUNICIPIO","{handler:'Valid_Historicodepartamentomunicipio',iparms:[]");
         setEventMetadata("VALID_HISTORICODEPARTAMENTOMUNICIPIO",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOZONASID","{handler:'Valid_Historicozonasid',iparms:[]");
         setEventMetadata("VALID_HISTORICOZONASID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESDIRECCION","{handler:'Valid_Historicosolicitudesdireccion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESAUTOENUMER","{handler:'Valid_Historicosolicitudesautoenumer',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESAUTOENUMER",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION","{handler:'Valid_Historicosolicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL","{handler:'Valid_Historicosolicitudestotal',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOSOLC","{handler:'Valid_Historicosolicitudserviciosolc',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOSOLC",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN","{handler:'Valid_Historicosolicitudserviciopfin',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLNOMBRE","{handler:'Valid_Estadossolnombre',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS1","{handler:'Valid_Historicosolicitudesotros1',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS1",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS2","{handler:'Valid_Historicosolicitudesotros2',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS2",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS3","{handler:'Valid_Historicosolicitudesotros3',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESOTROS3",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESHORAINSTAL","{handler:'Valid_Historicosolicitudeshorainstal',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESHORAINSTAL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOMENTARIO","{handler:'Valid_Historicosolicitudescomentario',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOMENTARIO",",oparms:[]}");
         setEventMetadata("VALID_METODOPAGOSID","{handler:'Valid_Metodopagosid',iparms:[]");
         setEventMetadata("VALID_METODOPAGOSID",",oparms:[]}");
         setEventMetadata("VALID_METODOPAGOSNOMBRE","{handler:'Valid_Metodopagosnombre',iparms:[]");
         setEventMetadata("VALID_METODOPAGOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOTA","{handler:'Valid_Historicosolicitudesnota',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOTA",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOTIFICACI","{handler:'Valid_Historicosolicitudesnotificaci',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESNOTIFICACI",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESORIGENPAGO","{handler:'Valid_Historicosolicitudesorigenpago',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESORIGENPAGO",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESPAGADO","{handler:'Valid_Historicosolicitudespagado',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESPAGADO",",oparms:[]}");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV100Pgmname = "";
         AV21TFHistoricoSolicitudesNombre = "";
         AV22TFHistoricoSolicitudesNombre_Sel = "";
         AV23TFHistoricoSolicitudesTelefono = "";
         AV24TFHistoricoSolicitudesTelefono_Sel = "";
         AV25TFHistoricoSolicitudesMail = "";
         AV26TFHistoricoSolicitudesMail_Sel = "";
         AV27TFHistoricoPaisID = "";
         AV28TFHistoricoPaisID_Sel = "";
         AV35TFHistoricoSolicitudesDireccion = "";
         AV36TFHistoricoSolicitudesDireccion_Sel = "";
         AV43TFHistoricoSolicitudServicioSolCoti = "";
         AV44TFHistoricoSolicitudServicioSolCoti_Sel = "";
         AV47TFEstadosSolTipo = "";
         AV48TFEstadosSolTipo_Sel = "";
         AV49TFEstadosSolNombre = "";
         AV50TFEstadosSolNombre_Sel = "";
         AV51TFHistoricoSolicitudesOtros1 = "";
         AV52TFHistoricoSolicitudesOtros1_Sel = "";
         AV53TFHistoricoSolicitudesOtros2 = "";
         AV54TFHistoricoSolicitudesOtros2_Sel = "";
         AV55TFHistoricoSolicitudesOtros3 = "";
         AV56TFHistoricoSolicitudesOtros3_Sel = "";
         AV57TFHistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AV58TFHistoricoSolicitudesFechaAlta_To = DateTime.MinValue;
         AV62TFHistoricoSolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV63TFHistoricoSolicitudesFechaActualizacion_To = (DateTime)(DateTime.MinValue);
         AV67TFHistoricoSolicitudesFechaInstalacion = DateTime.MinValue;
         AV68TFHistoricoSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV72TFHistoricoSolicitudesHoraInstalacion = "";
         AV73TFHistoricoSolicitudesHoraInstalacion_Sel = "";
         AV74TFHistoricoSolicitudesComentario = "";
         AV75TFHistoricoSolicitudesComentario_Sel = "";
         AV78TFMetodoPagosNombre = "";
         AV79TFMetodoPagosNombre_Sel = "";
         AV80TFHistoricoSolicitudesNota = "";
         AV81TFHistoricoSolicitudesNota_Sel = "";
         AV82TFHistoricoSolicitudesNotificacion = "";
         AV83TFHistoricoSolicitudesNotificacion_Sel = "";
         AV84TFHistoricoSolicitudesOrigenPago = "";
         AV85TFHistoricoSolicitudesOrigenPago_Sel = "";
         AV87TFHistoricoSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         H002Q2_A153HistoricoSolicitudesID = new long[1] ;
         H002Q2_A154HistoricoSolicitudesItemsID = new short[1] ;
         H002Q2_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         H002Q2_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         H002Q2_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         H002Q2_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         H002Q2_A295HItemsInventarioPrecioFinal = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV93GridAppliedFilters = "";
         AV88DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV60DDO_HistoricoSolicitudesFechaAltaAuxDateTo = DateTime.MinValue;
         AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo = DateTime.MinValue;
         AV70DDO_HistoricoSolicitudesFechaInstalacionAuxDateTo = DateTime.MinValue;
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV86TFHistoricoSolicitudesPagado_SelsJson = "";
         AV59DDO_HistoricoSolicitudesFechaAltaAuxDate = DateTime.MinValue;
         AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate = DateTime.MinValue;
         AV69DDO_HistoricoSolicitudesFechaInstalacionAuxDate = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText = "";
         ucTfhistoricosolicitudesfechaalta_rangepicker = new GXUserControl();
         AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText = "";
         ucTfhistoricosolicitudesfechaactualizacion_rangepicker = new GXUserControl();
         AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText = "";
         ucTfhistoricosolicitudesfechainstalacion_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A288HistoricoSolicitudesNombre = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A315HistoricoPaisID = "";
         A291HistoricoSolicitudesDireccion = "";
         A301HistoricoSolicitudServicioSolC = "";
         A130EstadosSolTipo = "";
         A132EstadosSolNombre = "";
         A303HistoricoSolicitudesOtros1 = "";
         A304HistoricoSolicitudesOtros2 = "";
         A305HistoricoSolicitudesOtros3 = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         A307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         A308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         A309HistoricoSolicitudesHoraInstal = "";
         A310HistoricoSolicitudesComentario = "";
         A129MetodoPagosNombre = "";
         A311HistoricoSolicitudesNota = "";
         A312HistoricoSolicitudesNotificaci = "";
         A439HistoricoSolicitudesOrigenPago = "";
         A442HistoricoSolicitudesPagado = "";
         GXDecQS = "";
         lV21TFHistoricoSolicitudesNombre = "";
         lV23TFHistoricoSolicitudesTelefono = "";
         lV25TFHistoricoSolicitudesMail = "";
         lV27TFHistoricoPaisID = "";
         lV35TFHistoricoSolicitudesDireccion = "";
         lV43TFHistoricoSolicitudServicioSolCoti = "";
         lV47TFEstadosSolTipo = "";
         lV49TFEstadosSolNombre = "";
         lV51TFHistoricoSolicitudesOtros1 = "";
         lV53TFHistoricoSolicitudesOtros2 = "";
         lV55TFHistoricoSolicitudesOtros3 = "";
         lV72TFHistoricoSolicitudesHoraInstalacion = "";
         lV74TFHistoricoSolicitudesComentario = "";
         lV78TFMetodoPagosNombre = "";
         lV80TFHistoricoSolicitudesNota = "";
         lV82TFHistoricoSolicitudesNotificacion = "";
         lV84TFHistoricoSolicitudesOrigenPago = "";
         H002Q3_A153HistoricoSolicitudesID = new long[1] ;
         H002Q3_A442HistoricoSolicitudesPagado = new string[] {""} ;
         H002Q3_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         H002Q3_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         H002Q3_A311HistoricoSolicitudesNota = new string[] {""} ;
         H002Q3_A129MetodoPagosNombre = new string[] {""} ;
         H002Q3_A128MetodoPagosID = new long[1] ;
         H002Q3_A310HistoricoSolicitudesComentario = new string[] {""} ;
         H002Q3_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         H002Q3_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         H002Q3_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         H002Q3_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002Q3_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         H002Q3_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         H002Q3_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         H002Q3_A132EstadosSolNombre = new string[] {""} ;
         H002Q3_A131EstadosSolId = new int[1] ;
         H002Q3_A130EstadosSolTipo = new string[] {""} ;
         H002Q3_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         H002Q3_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         H002Q3_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         H002Q3_A318HistoricoZonasID = new long[1] ;
         H002Q3_n318HistoricoZonasID = new bool[] {false} ;
         H002Q3_A317HistoricoDepartamentoMunicipio = new long[1] ;
         H002Q3_A316HistoricoDepartamentoId = new long[1] ;
         H002Q3_A315HistoricoPaisID = new string[] {""} ;
         H002Q3_A290HistoricoSolicitudesMail = new string[] {""} ;
         H002Q3_n290HistoricoSolicitudesMail = new bool[] {false} ;
         H002Q3_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         H002Q3_A288HistoricoSolicitudesNombre = new string[] {""} ;
         H002Q3_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         H002Q4_A153HistoricoSolicitudesID = new long[1] ;
         H002Q4_A442HistoricoSolicitudesPagado = new string[] {""} ;
         H002Q4_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         H002Q4_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         H002Q4_A311HistoricoSolicitudesNota = new string[] {""} ;
         H002Q4_A129MetodoPagosNombre = new string[] {""} ;
         H002Q4_A128MetodoPagosID = new long[1] ;
         H002Q4_A310HistoricoSolicitudesComentario = new string[] {""} ;
         H002Q4_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         H002Q4_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         H002Q4_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         H002Q4_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002Q4_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         H002Q4_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         H002Q4_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         H002Q4_A132EstadosSolNombre = new string[] {""} ;
         H002Q4_A131EstadosSolId = new int[1] ;
         H002Q4_A130EstadosSolTipo = new string[] {""} ;
         H002Q4_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         H002Q4_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         H002Q4_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         H002Q4_A318HistoricoZonasID = new long[1] ;
         H002Q4_n318HistoricoZonasID = new bool[] {false} ;
         H002Q4_A317HistoricoDepartamentoMunicipio = new long[1] ;
         H002Q4_A316HistoricoDepartamentoId = new long[1] ;
         H002Q4_A315HistoricoPaisID = new string[] {""} ;
         H002Q4_A290HistoricoSolicitudesMail = new string[] {""} ;
         H002Q4_n290HistoricoSolicitudesMail = new bool[] {false} ;
         H002Q4_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         H002Q4_A288HistoricoSolicitudesNombre = new string[] {""} ;
         H002Q4_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char21 = "";
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
         GXt_char5 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8HistoricoSolicitudesID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicorelacionesitemswc__default(),
            new Object[][] {
                new Object[] {
               H002Q2_A153HistoricoSolicitudesID, H002Q2_A154HistoricoSolicitudesItemsID, H002Q2_A298HistoricoSolicitudesItemsComis, H002Q2_A297HistoricoSolicitudesItemsCT, H002Q2_A296HistoricoSolicitudesItemsSR, H002Q2_A293HItemsSolicitudesItemsCantidad, H002Q2_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               H002Q3_A153HistoricoSolicitudesID, H002Q3_A442HistoricoSolicitudesPagado, H002Q3_A439HistoricoSolicitudesOrigenPago, H002Q3_A312HistoricoSolicitudesNotificaci, H002Q3_A311HistoricoSolicitudesNota, H002Q3_A129MetodoPagosNombre, H002Q3_A128MetodoPagosID, H002Q3_A310HistoricoSolicitudesComentario, H002Q3_A309HistoricoSolicitudesHoraInstal, H002Q3_A308HistoricoSolicitudesFechaInsta,
               H002Q3_A307HistoricoSolicitudesFechaActua, H002Q3_A306HistoricoSolicitudesFechaAlta, H002Q3_A305HistoricoSolicitudesOtros3, H002Q3_A304HistoricoSolicitudesOtros2, H002Q3_A303HistoricoSolicitudesOtros1, H002Q3_A132EstadosSolNombre, H002Q3_A131EstadosSolId, H002Q3_A130EstadosSolTipo, H002Q3_A301HistoricoSolicitudServicioSolC, H002Q3_A292HistoricoSolicitudesAutoEnumer,
               H002Q3_A291HistoricoSolicitudesDireccion, H002Q3_A318HistoricoZonasID, H002Q3_n318HistoricoZonasID, H002Q3_A317HistoricoDepartamentoMunicipio, H002Q3_A316HistoricoDepartamentoId, H002Q3_A315HistoricoPaisID, H002Q3_A290HistoricoSolicitudesMail, H002Q3_n290HistoricoSolicitudesMail, H002Q3_A289HistoricoSolicitudesTelefono, H002Q3_A288HistoricoSolicitudesNombre,
               H002Q3_A299HistoricoSolicitudesCotizacion
               }
               , new Object[] {
               H002Q4_A153HistoricoSolicitudesID, H002Q4_A442HistoricoSolicitudesPagado, H002Q4_A439HistoricoSolicitudesOrigenPago, H002Q4_A312HistoricoSolicitudesNotificaci, H002Q4_A311HistoricoSolicitudesNota, H002Q4_A129MetodoPagosNombre, H002Q4_A128MetodoPagosID, H002Q4_A310HistoricoSolicitudesComentario, H002Q4_A309HistoricoSolicitudesHoraInstal, H002Q4_A308HistoricoSolicitudesFechaInsta,
               H002Q4_A307HistoricoSolicitudesFechaActua, H002Q4_A306HistoricoSolicitudesFechaAlta, H002Q4_A305HistoricoSolicitudesOtros3, H002Q4_A304HistoricoSolicitudesOtros2, H002Q4_A303HistoricoSolicitudesOtros1, H002Q4_A132EstadosSolNombre, H002Q4_A131EstadosSolId, H002Q4_A130EstadosSolTipo, H002Q4_A301HistoricoSolicitudServicioSolC, H002Q4_A292HistoricoSolicitudesAutoEnumer,
               H002Q4_A291HistoricoSolicitudesDireccion, H002Q4_A318HistoricoZonasID, H002Q4_n318HistoricoZonasID, H002Q4_A317HistoricoDepartamentoMunicipio, H002Q4_A316HistoricoDepartamentoId, H002Q4_A315HistoricoPaisID, H002Q4_A290HistoricoSolicitudesMail, H002Q4_n290HistoricoSolicitudesMail, H002Q4_A289HistoricoSolicitudesTelefono, H002Q4_A288HistoricoSolicitudesNombre,
               H002Q4_A299HistoricoSolicitudesCotizacion
               }
            }
         );
         AV100Pgmname = "HistoricoRelacionesItemsWC";
         /* GeneXus formulas. */
         AV100Pgmname = "HistoricoRelacionesItemsWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short AV37TFHistoricoSolicitudesAutoEnumerar ;
      private short AV38TFHistoricoSolicitudesAutoEnumerar_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A292HistoricoSolicitudesAutoEnumer ;
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
      private int nRC_GXsfl_33 ;
      private int nGXsfl_33_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtHistoricoSolicitudesID_Visible ;
      private int A131EstadosSolId ;
      private int subGrid_Islastpage ;
      private int AV87TFHistoricoSolicitudesPagado_Sels_Count ;
      private int edtHistoricoSolicitudesNombre_Enabled ;
      private int edtHistoricoSolicitudesTelefono_Enabled ;
      private int edtHistoricoSolicitudesMail_Enabled ;
      private int edtHistoricoPaisID_Enabled ;
      private int edtHistoricoDepartamentoId_Enabled ;
      private int edtHistoricoDepartamentoMunicipio_Enabled ;
      private int edtHistoricoZonasID_Enabled ;
      private int edtHistoricoSolicitudesDireccion_Enabled ;
      private int edtHistoricoSolicitudesAutoEnumer_Enabled ;
      private int edtHistoricoSolicitudesCotizacion_Enabled ;
      private int edtHistoricoSolicitudesTotal_Enabled ;
      private int edtHistoricoSolicitudServicioSolC_Enabled ;
      private int edtHistoricoSolicitudServicioPFin_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int edtEstadosSolNombre_Enabled ;
      private int edtHistoricoSolicitudesOtros1_Enabled ;
      private int edtHistoricoSolicitudesOtros2_Enabled ;
      private int edtHistoricoSolicitudesOtros3_Enabled ;
      private int edtHistoricoSolicitudesFechaAlta_Enabled ;
      private int edtHistoricoSolicitudesFechaActua_Enabled ;
      private int edtHistoricoSolicitudesFechaInsta_Enabled ;
      private int edtHistoricoSolicitudesHoraInstal_Enabled ;
      private int edtHistoricoSolicitudesComentario_Enabled ;
      private int edtMetodoPagosID_Enabled ;
      private int edtMetodoPagosNombre_Enabled ;
      private int edtHistoricoSolicitudesNota_Enabled ;
      private int edtHistoricoSolicitudesNotificaci_Enabled ;
      private int edtHistoricoSolicitudesOrigenPago_Enabled ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int AV90PageToGo ;
      private int AV101GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8HistoricoSolicitudesID ;
      private long wcpOAV8HistoricoSolicitudesID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV29TFHistoricoDepartamentoId ;
      private long AV30TFHistoricoDepartamentoId_To ;
      private long AV31TFHistoricoDepartamentoMunicipioId ;
      private long AV32TFHistoricoDepartamentoMunicipioId_To ;
      private long AV33TFHistoricoZonasID ;
      private long AV34TFHistoricoZonasID_To ;
      private long AV76TFMetodoPagosID ;
      private long AV77TFMetodoPagosID_To ;
      private long A153HistoricoSolicitudesID ;
      private long AV91GridCurrentPage ;
      private long AV92GridPageCount ;
      private long A316HistoricoDepartamentoId ;
      private long A317HistoricoDepartamentoMunicipio ;
      private long A318HistoricoZonasID ;
      private long A128MetodoPagosID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV39TFHistoricoSolicitudesCotizacion ;
      private decimal AV40TFHistoricoSolicitudesCotizacion_To ;
      private decimal AV41TFHistoricoSolicitudesTotal ;
      private decimal AV42TFHistoricoSolicitudesTotal_To ;
      private decimal AV45TFHistoricoSolicitudServicioPFinal ;
      private decimal AV46TFHistoricoSolicitudServicioPFinal_To ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_33_idx="0001" ;
      private string AV100Pgmname ;
      private string AV21TFHistoricoSolicitudesNombre ;
      private string AV22TFHistoricoSolicitudesNombre_Sel ;
      private string AV23TFHistoricoSolicitudesTelefono ;
      private string AV24TFHistoricoSolicitudesTelefono_Sel ;
      private string AV27TFHistoricoPaisID ;
      private string AV28TFHistoricoPaisID_Sel ;
      private string AV43TFHistoricoSolicitudServicioSolCoti ;
      private string AV44TFHistoricoSolicitudServicioSolCoti_Sel ;
      private string AV47TFEstadosSolTipo ;
      private string AV48TFEstadosSolTipo_Sel ;
      private string AV49TFEstadosSolNombre ;
      private string AV50TFEstadosSolNombre_Sel ;
      private string AV51TFHistoricoSolicitudesOtros1 ;
      private string AV52TFHistoricoSolicitudesOtros1_Sel ;
      private string AV53TFHistoricoSolicitudesOtros2 ;
      private string AV54TFHistoricoSolicitudesOtros2_Sel ;
      private string AV55TFHistoricoSolicitudesOtros3 ;
      private string AV56TFHistoricoSolicitudesOtros3_Sel ;
      private string AV72TFHistoricoSolicitudesHoraInstalacion ;
      private string AV73TFHistoricoSolicitudesHoraInstalacion_Sel ;
      private string AV78TFMetodoPagosNombre ;
      private string AV79TFMetodoPagosNombre_Sel ;
      private string AV80TFHistoricoSolicitudesNota ;
      private string AV81TFHistoricoSolicitudesNota_Sel ;
      private string AV82TFHistoricoSolicitudesNotificacion ;
      private string AV83TFHistoricoSolicitudesNotificacion_Sel ;
      private string AV84TFHistoricoSolicitudesOrigenPago ;
      private string AV85TFHistoricoSolicitudesOrigenPago_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_historicosolicitudesfechaaltaauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_historicosolicitudesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_historicosolicitudesfechaaltaauxdatetext_Jsonclick ;
      private string Tfhistoricosolicitudesfechaalta_rangepicker_Internalname ;
      private string divDdo_historicosolicitudesfechaactualizacionauxdates_Internalname ;
      private string edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Internalname ;
      private string edtavDdo_historicosolicitudesfechaactualizacionauxdatetext_Jsonclick ;
      private string Tfhistoricosolicitudesfechaactualizacion_rangepicker_Internalname ;
      private string divDdo_historicosolicitudesfechainstalacionauxdates_Internalname ;
      private string edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Internalname ;
      private string edtavDdo_historicosolicitudesfechainstalacionauxdatetext_Jsonclick ;
      private string Tfhistoricosolicitudesfechainstalacion_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavFilterfulltext_Internalname ;
      private string A288HistoricoSolicitudesNombre ;
      private string edtHistoricoSolicitudesNombre_Internalname ;
      private string A289HistoricoSolicitudesTelefono ;
      private string edtHistoricoSolicitudesTelefono_Internalname ;
      private string edtHistoricoSolicitudesMail_Internalname ;
      private string A315HistoricoPaisID ;
      private string edtHistoricoPaisID_Internalname ;
      private string edtHistoricoDepartamentoId_Internalname ;
      private string edtHistoricoDepartamentoMunicipio_Internalname ;
      private string edtHistoricoZonasID_Internalname ;
      private string edtHistoricoSolicitudesDireccion_Internalname ;
      private string edtHistoricoSolicitudesAutoEnumer_Internalname ;
      private string edtHistoricoSolicitudesCotizacion_Internalname ;
      private string edtHistoricoSolicitudesTotal_Internalname ;
      private string A301HistoricoSolicitudServicioSolC ;
      private string edtHistoricoSolicitudServicioSolC_Internalname ;
      private string edtHistoricoSolicitudServicioPFin_Internalname ;
      private string A130EstadosSolTipo ;
      private string edtEstadosSolTipo_Internalname ;
      private string edtEstadosSolId_Internalname ;
      private string A132EstadosSolNombre ;
      private string edtEstadosSolNombre_Internalname ;
      private string A303HistoricoSolicitudesOtros1 ;
      private string edtHistoricoSolicitudesOtros1_Internalname ;
      private string A304HistoricoSolicitudesOtros2 ;
      private string edtHistoricoSolicitudesOtros2_Internalname ;
      private string A305HistoricoSolicitudesOtros3 ;
      private string edtHistoricoSolicitudesOtros3_Internalname ;
      private string edtHistoricoSolicitudesFechaAlta_Internalname ;
      private string edtHistoricoSolicitudesFechaActua_Internalname ;
      private string edtHistoricoSolicitudesFechaInsta_Internalname ;
      private string A309HistoricoSolicitudesHoraInstal ;
      private string edtHistoricoSolicitudesHoraInstal_Internalname ;
      private string edtHistoricoSolicitudesComentario_Internalname ;
      private string edtMetodoPagosID_Internalname ;
      private string A129MetodoPagosNombre ;
      private string edtMetodoPagosNombre_Internalname ;
      private string A311HistoricoSolicitudesNota ;
      private string edtHistoricoSolicitudesNota_Internalname ;
      private string A312HistoricoSolicitudesNotificaci ;
      private string edtHistoricoSolicitudesNotificaci_Internalname ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string edtHistoricoSolicitudesOrigenPago_Internalname ;
      private string cmbHistoricoSolicitudesPagado_Internalname ;
      private string A442HistoricoSolicitudesPagado ;
      private string GXDecQS ;
      private string lV21TFHistoricoSolicitudesNombre ;
      private string lV23TFHistoricoSolicitudesTelefono ;
      private string lV27TFHistoricoPaisID ;
      private string lV43TFHistoricoSolicitudServicioSolCoti ;
      private string lV47TFEstadosSolTipo ;
      private string lV49TFEstadosSolNombre ;
      private string lV51TFHistoricoSolicitudesOtros1 ;
      private string lV53TFHistoricoSolicitudesOtros2 ;
      private string lV55TFHistoricoSolicitudesOtros3 ;
      private string lV72TFHistoricoSolicitudesHoraInstalacion ;
      private string lV78TFMetodoPagosNombre ;
      private string lV80TFHistoricoSolicitudesNota ;
      private string lV82TFHistoricoSolicitudesNotificacion ;
      private string lV84TFHistoricoSolicitudesOrigenPago ;
      private string edtEstadosSolNombre_Link ;
      private string edtMetodoPagosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char21 ;
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
      private string GXt_char5 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8HistoricoSolicitudesID ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtHistoricoSolicitudesNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtHistoricoSolicitudesTelefono_Jsonclick ;
      private string edtHistoricoSolicitudesMail_Jsonclick ;
      private string edtHistoricoPaisID_Jsonclick ;
      private string edtHistoricoDepartamentoId_Jsonclick ;
      private string edtHistoricoDepartamentoMunicipio_Jsonclick ;
      private string edtHistoricoZonasID_Jsonclick ;
      private string edtHistoricoSolicitudesDireccion_Jsonclick ;
      private string edtHistoricoSolicitudesAutoEnumer_Jsonclick ;
      private string edtHistoricoSolicitudesCotizacion_Jsonclick ;
      private string edtHistoricoSolicitudesTotal_Jsonclick ;
      private string edtHistoricoSolicitudServicioSolC_Jsonclick ;
      private string edtHistoricoSolicitudServicioPFin_Jsonclick ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtEstadosSolNombre_Jsonclick ;
      private string edtHistoricoSolicitudesOtros1_Jsonclick ;
      private string edtHistoricoSolicitudesOtros2_Jsonclick ;
      private string edtHistoricoSolicitudesOtros3_Jsonclick ;
      private string edtHistoricoSolicitudesFechaAlta_Jsonclick ;
      private string edtHistoricoSolicitudesFechaActua_Jsonclick ;
      private string edtHistoricoSolicitudesFechaInsta_Jsonclick ;
      private string edtHistoricoSolicitudesHoraInstal_Jsonclick ;
      private string edtHistoricoSolicitudesComentario_Jsonclick ;
      private string edtMetodoPagosID_Jsonclick ;
      private string edtMetodoPagosNombre_Jsonclick ;
      private string edtHistoricoSolicitudesNota_Jsonclick ;
      private string edtHistoricoSolicitudesNotificaci_Jsonclick ;
      private string edtHistoricoSolicitudesOrigenPago_Jsonclick ;
      private string GXCCtl ;
      private string cmbHistoricoSolicitudesPagado_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV62TFHistoricoSolicitudesFechaActualizacion ;
      private DateTime AV63TFHistoricoSolicitudesFechaActualizacion_To ;
      private DateTime A307HistoricoSolicitudesFechaActua ;
      private DateTime AV57TFHistoricoSolicitudesFechaAlta ;
      private DateTime AV58TFHistoricoSolicitudesFechaAlta_To ;
      private DateTime AV67TFHistoricoSolicitudesFechaInstalacion ;
      private DateTime AV68TFHistoricoSolicitudesFechaInstalacion_To ;
      private DateTime AV60DDO_HistoricoSolicitudesFechaAltaAuxDateTo ;
      private DateTime AV65DDO_HistoricoSolicitudesFechaActualizacionAuxDateTo ;
      private DateTime AV70DDO_HistoricoSolicitudesFechaInstalacionAuxDateTo ;
      private DateTime AV59DDO_HistoricoSolicitudesFechaAltaAuxDate ;
      private DateTime AV64DDO_HistoricoSolicitudesFechaActualizacionAuxDate ;
      private DateTime AV69DDO_HistoricoSolicitudesFechaInstalacionAuxDate ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime A308HistoricoSolicitudesFechaInsta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV99IsAuthorized_EstadosSolNombre ;
      private bool AV97IsAuthorized_MetodoPagosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n290HistoricoSolicitudesMail ;
      private bool n318HistoricoZonasID ;
      private bool bGXsfl_33_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private string AV86TFHistoricoSolicitudesPagado_SelsJson ;
      private string A310HistoricoSolicitudesComentario ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV25TFHistoricoSolicitudesMail ;
      private string AV26TFHistoricoSolicitudesMail_Sel ;
      private string AV35TFHistoricoSolicitudesDireccion ;
      private string AV36TFHistoricoSolicitudesDireccion_Sel ;
      private string AV74TFHistoricoSolicitudesComentario ;
      private string AV75TFHistoricoSolicitudesComentario_Sel ;
      private string AV93GridAppliedFilters ;
      private string AV61DDO_HistoricoSolicitudesFechaAltaAuxDateText ;
      private string AV66DDO_HistoricoSolicitudesFechaActualizacionAuxDateText ;
      private string AV71DDO_HistoricoSolicitudesFechaInstalacionAuxDateText ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private string lV25TFHistoricoSolicitudesMail ;
      private string lV35TFHistoricoSolicitudesDireccion ;
      private string lV74TFHistoricoSolicitudesComentario ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfhistoricosolicitudesfechaalta_rangepicker ;
      private GXUserControl ucTfhistoricosolicitudesfechaactualizacion_rangepicker ;
      private GXUserControl ucTfhistoricosolicitudesfechainstalacion_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbHistoricoSolicitudesPagado ;
      private GxSimpleCollection<string> AV87TFHistoricoSolicitudesPagado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] H002Q2_A153HistoricoSolicitudesID ;
      private short[] H002Q2_A154HistoricoSolicitudesItemsID ;
      private decimal[] H002Q2_A298HistoricoSolicitudesItemsComis ;
      private string[] H002Q2_A297HistoricoSolicitudesItemsCT ;
      private string[] H002Q2_A296HistoricoSolicitudesItemsSR ;
      private short[] H002Q2_A293HItemsSolicitudesItemsCantidad ;
      private short[] H002Q2_A295HItemsInventarioPrecioFinal ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV88DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private long[] H002Q3_A153HistoricoSolicitudesID ;
      private string[] H002Q3_A442HistoricoSolicitudesPagado ;
      private string[] H002Q3_A439HistoricoSolicitudesOrigenPago ;
      private string[] H002Q3_A312HistoricoSolicitudesNotificaci ;
      private string[] H002Q3_A311HistoricoSolicitudesNota ;
      private string[] H002Q3_A129MetodoPagosNombre ;
      private long[] H002Q3_A128MetodoPagosID ;
      private string[] H002Q3_A310HistoricoSolicitudesComentario ;
      private string[] H002Q3_A309HistoricoSolicitudesHoraInstal ;
      private DateTime[] H002Q3_A308HistoricoSolicitudesFechaInsta ;
      private DateTime[] H002Q3_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] H002Q3_A306HistoricoSolicitudesFechaAlta ;
      private string[] H002Q3_A305HistoricoSolicitudesOtros3 ;
      private string[] H002Q3_A304HistoricoSolicitudesOtros2 ;
      private string[] H002Q3_A303HistoricoSolicitudesOtros1 ;
      private string[] H002Q3_A132EstadosSolNombre ;
      private int[] H002Q3_A131EstadosSolId ;
      private string[] H002Q3_A130EstadosSolTipo ;
      private string[] H002Q3_A301HistoricoSolicitudServicioSolC ;
      private short[] H002Q3_A292HistoricoSolicitudesAutoEnumer ;
      private string[] H002Q3_A291HistoricoSolicitudesDireccion ;
      private long[] H002Q3_A318HistoricoZonasID ;
      private bool[] H002Q3_n318HistoricoZonasID ;
      private long[] H002Q3_A317HistoricoDepartamentoMunicipio ;
      private long[] H002Q3_A316HistoricoDepartamentoId ;
      private string[] H002Q3_A315HistoricoPaisID ;
      private string[] H002Q3_A290HistoricoSolicitudesMail ;
      private bool[] H002Q3_n290HistoricoSolicitudesMail ;
      private string[] H002Q3_A289HistoricoSolicitudesTelefono ;
      private string[] H002Q3_A288HistoricoSolicitudesNombre ;
      private decimal[] H002Q3_A299HistoricoSolicitudesCotizacion ;
      private long[] H002Q4_A153HistoricoSolicitudesID ;
      private string[] H002Q4_A442HistoricoSolicitudesPagado ;
      private string[] H002Q4_A439HistoricoSolicitudesOrigenPago ;
      private string[] H002Q4_A312HistoricoSolicitudesNotificaci ;
      private string[] H002Q4_A311HistoricoSolicitudesNota ;
      private string[] H002Q4_A129MetodoPagosNombre ;
      private long[] H002Q4_A128MetodoPagosID ;
      private string[] H002Q4_A310HistoricoSolicitudesComentario ;
      private string[] H002Q4_A309HistoricoSolicitudesHoraInstal ;
      private DateTime[] H002Q4_A308HistoricoSolicitudesFechaInsta ;
      private DateTime[] H002Q4_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] H002Q4_A306HistoricoSolicitudesFechaAlta ;
      private string[] H002Q4_A305HistoricoSolicitudesOtros3 ;
      private string[] H002Q4_A304HistoricoSolicitudesOtros2 ;
      private string[] H002Q4_A303HistoricoSolicitudesOtros1 ;
      private string[] H002Q4_A132EstadosSolNombre ;
      private int[] H002Q4_A131EstadosSolId ;
      private string[] H002Q4_A130EstadosSolTipo ;
      private string[] H002Q4_A301HistoricoSolicitudServicioSolC ;
      private short[] H002Q4_A292HistoricoSolicitudesAutoEnumer ;
      private string[] H002Q4_A291HistoricoSolicitudesDireccion ;
      private long[] H002Q4_A318HistoricoZonasID ;
      private bool[] H002Q4_n318HistoricoZonasID ;
      private long[] H002Q4_A317HistoricoDepartamentoMunicipio ;
      private long[] H002Q4_A316HistoricoDepartamentoId ;
      private string[] H002Q4_A315HistoricoPaisID ;
      private string[] H002Q4_A290HistoricoSolicitudesMail ;
      private bool[] H002Q4_n290HistoricoSolicitudesMail ;
      private string[] H002Q4_A289HistoricoSolicitudesTelefono ;
      private string[] H002Q4_A288HistoricoSolicitudesNombre ;
      private decimal[] H002Q4_A299HistoricoSolicitudesCotizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historicorelacionesitemswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002Q3( IGxContext context ,
                                             string A442HistoricoSolicitudesPagado ,
                                             GxSimpleCollection<string> AV87TFHistoricoSolicitudesPagado_Sels ,
                                             string AV22TFHistoricoSolicitudesNombre_Sel ,
                                             string AV21TFHistoricoSolicitudesNombre ,
                                             string AV24TFHistoricoSolicitudesTelefono_Sel ,
                                             string AV23TFHistoricoSolicitudesTelefono ,
                                             string AV26TFHistoricoSolicitudesMail_Sel ,
                                             string AV25TFHistoricoSolicitudesMail ,
                                             string AV28TFHistoricoPaisID_Sel ,
                                             string AV27TFHistoricoPaisID ,
                                             long AV29TFHistoricoDepartamentoId ,
                                             long AV30TFHistoricoDepartamentoId_To ,
                                             long AV31TFHistoricoDepartamentoMunicipioId ,
                                             long AV32TFHistoricoDepartamentoMunicipioId_To ,
                                             long AV33TFHistoricoZonasID ,
                                             long AV34TFHistoricoZonasID_To ,
                                             string AV36TFHistoricoSolicitudesDireccion_Sel ,
                                             string AV35TFHistoricoSolicitudesDireccion ,
                                             short AV37TFHistoricoSolicitudesAutoEnumerar ,
                                             short AV38TFHistoricoSolicitudesAutoEnumerar_To ,
                                             decimal AV39TFHistoricoSolicitudesCotizacion ,
                                             decimal AV40TFHistoricoSolicitudesCotizacion_To ,
                                             decimal AV41TFHistoricoSolicitudesTotal ,
                                             decimal AV42TFHistoricoSolicitudesTotal_To ,
                                             string AV44TFHistoricoSolicitudServicioSolCoti_Sel ,
                                             string AV43TFHistoricoSolicitudServicioSolCoti ,
                                             string AV48TFEstadosSolTipo_Sel ,
                                             string AV47TFEstadosSolTipo ,
                                             string AV50TFEstadosSolNombre_Sel ,
                                             string AV49TFEstadosSolNombre ,
                                             string AV52TFHistoricoSolicitudesOtros1_Sel ,
                                             string AV51TFHistoricoSolicitudesOtros1 ,
                                             string AV54TFHistoricoSolicitudesOtros2_Sel ,
                                             string AV53TFHistoricoSolicitudesOtros2 ,
                                             string AV56TFHistoricoSolicitudesOtros3_Sel ,
                                             string AV55TFHistoricoSolicitudesOtros3 ,
                                             DateTime AV57TFHistoricoSolicitudesFechaAlta ,
                                             DateTime AV58TFHistoricoSolicitudesFechaAlta_To ,
                                             DateTime AV62TFHistoricoSolicitudesFechaActualizacion ,
                                             DateTime AV63TFHistoricoSolicitudesFechaActualizacion_To ,
                                             DateTime AV67TFHistoricoSolicitudesFechaInstalacion ,
                                             DateTime AV68TFHistoricoSolicitudesFechaInstalacion_To ,
                                             string AV73TFHistoricoSolicitudesHoraInstalacion_Sel ,
                                             string AV72TFHistoricoSolicitudesHoraInstalacion ,
                                             string AV75TFHistoricoSolicitudesComentario_Sel ,
                                             string AV74TFHistoricoSolicitudesComentario ,
                                             long AV76TFMetodoPagosID ,
                                             long AV77TFMetodoPagosID_To ,
                                             string AV79TFMetodoPagosNombre_Sel ,
                                             string AV78TFMetodoPagosNombre ,
                                             string AV81TFHistoricoSolicitudesNota_Sel ,
                                             string AV80TFHistoricoSolicitudesNota ,
                                             string AV83TFHistoricoSolicitudesNotificacion_Sel ,
                                             string AV82TFHistoricoSolicitudesNotificacion ,
                                             string AV85TFHistoricoSolicitudesOrigenPago_Sel ,
                                             string AV84TFHistoricoSolicitudesOrigenPago ,
                                             int AV87TFHistoricoSolicitudesPagado_Sels_Count ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A315HistoricoPaisID ,
                                             long A316HistoricoDepartamentoId ,
                                             long A317HistoricoDepartamentoMunicipio ,
                                             long A318HistoricoZonasID ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             short A292HistoricoSolicitudesAutoEnumer ,
                                             decimal A299HistoricoSolicitudesCotizacion ,
                                             decimal A300HistoricoSolicitudesTotal ,
                                             string A301HistoricoSolicitudServicioSolC ,
                                             string A130EstadosSolTipo ,
                                             string A132EstadosSolNombre ,
                                             string A303HistoricoSolicitudesOtros1 ,
                                             string A304HistoricoSolicitudesOtros2 ,
                                             string A305HistoricoSolicitudesOtros3 ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime A307HistoricoSolicitudesFechaActua ,
                                             DateTime A308HistoricoSolicitudesFechaInsta ,
                                             string A309HistoricoSolicitudesHoraInstal ,
                                             string A310HistoricoSolicitudesComentario ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A311HistoricoSolicitudesNota ,
                                             string A312HistoricoSolicitudesNotificaci ,
                                             string A439HistoricoSolicitudesOrigenPago ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             decimal AV45TFHistoricoSolicitudServicioPFinal ,
                                             decimal AV46TFHistoricoSolicitudServicioPFinal_To ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int22 = new short[53];
         Object[] GXv_Object23 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T1.[HistoricoSolicitudesNotificaci], T1.[HistoricoSolicitudesNota], T2.[MetodoPagosNombre], T1.[MetodoPagosID], T1.[HistoricoSolicitudesComentario], T1.[HistoricoSolicitudesHoraInstal], T1.[HistoricoSolicitudesFechaInsta], T1.[HistoricoSolicitudesFechaActua], T1.[HistoricoSolicitudesFechaAlta], T1.[HistoricoSolicitudesOtros3], T1.[HistoricoSolicitudesOtros2], T1.[HistoricoSolicitudesOtros1], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[HistoricoSolicitudServicioSolC], T1.[HistoricoSolicitudesAutoEnumer], T1.[HistoricoSolicitudesDireccion], T1.[HistoricoZonasID], T1.[HistoricoDepartamentoMunicipio], T1.[HistoricoDepartamentoId], T1.[HistoricoPaisID], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T1.[HistoricoSolicitudesCotizacion] FROM (([HistoricoSolicitudes] T1 INNER JOIN [MetodoPagos] T2 ON T2.[MetodoPagosID] = T1.[MetodoPagosID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNombre]) like UPPER(@lV21TFHistoricoSolicitudesNombre))");
         }
         else
         {
            GXv_int22[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNombre] = @AV22TFHistoricoSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int22[2] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesTelefono]) like UPPER(@lV23TFHistoricoSolicitudesTelefono))");
         }
         else
         {
            GXv_int22[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV24TFHistoricoSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesTelefono] = @AV24TFHistoricoSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int22[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFHistoricoSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFHistoricoSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesMail]) like UPPER(@lV25TFHistoricoSolicitudesMail))");
         }
         else
         {
            GXv_int22[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV26TFHistoricoSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesMail] = @AV26TFHistoricoSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int22[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFHistoricoSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesMail] IS NULL or (T1.[HistoricoSolicitudesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHistoricoPaisID)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoPaisID]) like UPPER(@lV27TFHistoricoPaisID))");
         }
         else
         {
            GXv_int22[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)) && ! ( StringUtil.StrCmp(AV28TFHistoricoPaisID_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoPaisID] = @AV28TFHistoricoPaisID_Sel)");
         }
         else
         {
            GXv_int22[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFHistoricoPaisID_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoPaisID] = ''))");
         }
         if ( ! (0==AV29TFHistoricoDepartamentoId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoId] >= @AV29TFHistoricoDepartamentoId)");
         }
         else
         {
            GXv_int22[9] = 1;
         }
         if ( ! (0==AV30TFHistoricoDepartamentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoId] <= @AV30TFHistoricoDepartamentoId_To)");
         }
         else
         {
            GXv_int22[10] = 1;
         }
         if ( ! (0==AV31TFHistoricoDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoMunicipio] >= @AV31TFHistoricoDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int22[11] = 1;
         }
         if ( ! (0==AV32TFHistoricoDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoMunicipio] <= @AV32TFHistoricoDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int22[12] = 1;
         }
         if ( ! (0==AV33TFHistoricoZonasID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoZonasID] >= @AV33TFHistoricoZonasID)");
         }
         else
         {
            GXv_int22[13] = 1;
         }
         if ( ! (0==AV34TFHistoricoZonasID_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoZonasID] <= @AV34TFHistoricoZonasID_To)");
         }
         else
         {
            GXv_int22[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesDireccion]) like UPPER(@lV35TFHistoricoSolicitudesDireccion))");
         }
         else
         {
            GXv_int22[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV36TFHistoricoSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesDireccion] = @AV36TFHistoricoSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int22[16] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFHistoricoSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesDireccion] = ''))");
         }
         if ( ! (0==AV37TFHistoricoSolicitudesAutoEnumerar) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesAutoEnumer] >= @AV37TFHistoricoSolicitudesAutoEnumerar)");
         }
         else
         {
            GXv_int22[17] = 1;
         }
         if ( ! (0==AV38TFHistoricoSolicitudesAutoEnumerar_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesAutoEnumer] <= @AV38TFHistoricoSolicitudesAutoEnumerar_To)");
         }
         else
         {
            GXv_int22[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39TFHistoricoSolicitudesCotizacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesCotizacion] >= @AV39TFHistoricoSolicitudesCotizacion)");
         }
         else
         {
            GXv_int22[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40TFHistoricoSolicitudesCotizacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesCotizacion] <= @AV40TFHistoricoSolicitudesCotizacion_To)");
         }
         else
         {
            GXv_int22[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudServicioSolC]) like UPPER(@lV43TFHistoricoSolicitudServicioSolCoti))");
         }
         else
         {
            GXv_int22[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)) && ! ( StringUtil.StrCmp(AV44TFHistoricoSolicitudServicioSolCoti_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudServicioSolC] = @AV44TFHistoricoSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int22[22] = 1;
         }
         if ( StringUtil.StrCmp(AV44TFHistoricoSolicitudServicioSolCoti_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudServicioSolC] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEstadosSolTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadosSolTipo]) like UPPER(@lV47TFEstadosSolTipo))");
         }
         else
         {
            GXv_int22[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)) && ! ( StringUtil.StrCmp(AV48TFEstadosSolTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolTipo] = @AV48TFEstadosSolTipo_Sel)");
         }
         else
         {
            GXv_int22[24] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFEstadosSolTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadosSolTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEstadosSolNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV49TFEstadosSolNombre))");
         }
         else
         {
            GXv_int22[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)) && ! ( StringUtil.StrCmp(AV50TFEstadosSolNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV50TFEstadosSolNombre_Sel)");
         }
         else
         {
            GXv_int22[26] = 1;
         }
         if ( StringUtil.StrCmp(AV50TFEstadosSolNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros1]) like UPPER(@lV51TFHistoricoSolicitudesOtros1))");
         }
         else
         {
            GXv_int22[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)) && ! ( StringUtil.StrCmp(AV52TFHistoricoSolicitudesOtros1_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros1] = @AV52TFHistoricoSolicitudesOtros1_Sel)");
         }
         else
         {
            GXv_int22[28] = 1;
         }
         if ( StringUtil.StrCmp(AV52TFHistoricoSolicitudesOtros1_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros1] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros2]) like UPPER(@lV53TFHistoricoSolicitudesOtros2))");
         }
         else
         {
            GXv_int22[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)) && ! ( StringUtil.StrCmp(AV54TFHistoricoSolicitudesOtros2_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros2] = @AV54TFHistoricoSolicitudesOtros2_Sel)");
         }
         else
         {
            GXv_int22[30] = 1;
         }
         if ( StringUtil.StrCmp(AV54TFHistoricoSolicitudesOtros2_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros2] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros3]) like UPPER(@lV55TFHistoricoSolicitudesOtros3))");
         }
         else
         {
            GXv_int22[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)) && ! ( StringUtil.StrCmp(AV56TFHistoricoSolicitudesOtros3_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros3] = @AV56TFHistoricoSolicitudesOtros3_Sel)");
         }
         else
         {
            GXv_int22[32] = 1;
         }
         if ( StringUtil.StrCmp(AV56TFHistoricoSolicitudesOtros3_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros3] = ''))");
         }
         if ( ! (DateTime.MinValue==AV57TFHistoricoSolicitudesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV57TFHistoricoSolicitudesFechaAlta)");
         }
         else
         {
            GXv_int22[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV58TFHistoricoSolicitudesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] <= @AV58TFHistoricoSolicitudesFechaAlta_To)");
         }
         else
         {
            GXv_int22[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV62TFHistoricoSolicitudesFechaActualizacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaActua] >= @AV62TFHistoricoSolicitudesFechaActualizacion)");
         }
         else
         {
            GXv_int22[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV63TFHistoricoSolicitudesFechaActualizacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaActua] <= @AV63TFHistoricoSolicitudesFechaActualizacion_To)");
         }
         else
         {
            GXv_int22[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV67TFHistoricoSolicitudesFechaInstalacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaInsta] >= @AV67TFHistoricoSolicitudesFechaInstalacion)");
         }
         else
         {
            GXv_int22[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV68TFHistoricoSolicitudesFechaInstalacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaInsta] <= @AV68TFHistoricoSolicitudesFechaInstalacion_To)");
         }
         else
         {
            GXv_int22[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesHoraInstal]) like UPPER(@lV72TFHistoricoSolicitudesHoraInstalacion))");
         }
         else
         {
            GXv_int22[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)) && ! ( StringUtil.StrCmp(AV73TFHistoricoSolicitudesHoraInstalacion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesHoraInstal] = @AV73TFHistoricoSolicitudesHoraInstalacion_Sel)");
         }
         else
         {
            GXv_int22[40] = 1;
         }
         if ( StringUtil.StrCmp(AV73TFHistoricoSolicitudesHoraInstalacion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesHoraInstal] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesComentario]) like UPPER(@lV74TFHistoricoSolicitudesComentario))");
         }
         else
         {
            GXv_int22[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)) && ! ( StringUtil.StrCmp(AV75TFHistoricoSolicitudesComentario_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesComentario] = @AV75TFHistoricoSolicitudesComentario_Sel)");
         }
         else
         {
            GXv_int22[42] = 1;
         }
         if ( StringUtil.StrCmp(AV75TFHistoricoSolicitudesComentario_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[HistoricoSolicitudesComentario])=0))");
         }
         if ( ! (0==AV76TFMetodoPagosID) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV76TFMetodoPagosID)");
         }
         else
         {
            GXv_int22[43] = 1;
         }
         if ( ! (0==AV77TFMetodoPagosID_To) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV77TFMetodoPagosID_To)");
         }
         else
         {
            GXv_int22[44] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78TFMetodoPagosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MetodoPagosNombre]) like UPPER(@lV78TFMetodoPagosNombre))");
         }
         else
         {
            GXv_int22[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)) && ! ( StringUtil.StrCmp(AV79TFMetodoPagosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MetodoPagosNombre] = @AV79TFMetodoPagosNombre_Sel)");
         }
         else
         {
            GXv_int22[46] = 1;
         }
         if ( StringUtil.StrCmp(AV79TFMetodoPagosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFHistoricoSolicitudesNota)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNota]) like UPPER(@lV80TFHistoricoSolicitudesNota))");
         }
         else
         {
            GXv_int22[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)) && ! ( StringUtil.StrCmp(AV81TFHistoricoSolicitudesNota_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNota] = @AV81TFHistoricoSolicitudesNota_Sel)");
         }
         else
         {
            GXv_int22[48] = 1;
         }
         if ( StringUtil.StrCmp(AV81TFHistoricoSolicitudesNota_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNota] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNotificaci]) like UPPER(@lV82TFHistoricoSolicitudesNotificacion))");
         }
         else
         {
            GXv_int22[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)) && ! ( StringUtil.StrCmp(AV83TFHistoricoSolicitudesNotificacion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNotificaci] = @AV83TFHistoricoSolicitudesNotificacion_Sel)");
         }
         else
         {
            GXv_int22[50] = 1;
         }
         if ( StringUtil.StrCmp(AV83TFHistoricoSolicitudesNotificacion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNotificaci] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOrigenPago]) like UPPER(@lV84TFHistoricoSolicitudesOrigenPago))");
         }
         else
         {
            GXv_int22[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)) && ! ( StringUtil.StrCmp(AV85TFHistoricoSolicitudesOrigenPago_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOrigenPago] = @AV85TFHistoricoSolicitudesOrigenPago_Sel)");
         }
         else
         {
            GXv_int22[52] = 1;
         }
         if ( StringUtil.StrCmp(AV85TFHistoricoSolicitudesOrigenPago_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOrigenPago] = ''))");
         }
         if ( AV87TFHistoricoSolicitudesPagado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV87TFHistoricoSolicitudesPagado_Sels, "T1.[HistoricoSolicitudesPagado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoPaisID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoPaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoDepartamentoId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoDepartamentoId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoDepartamentoMunicipio]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoDepartamentoMunicipio] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoZonasID]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoZonasID] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesAutoEnumer]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesAutoEnumer] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudServicioSolC]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudServicioSolC] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[EstadosSolTipo]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[EstadosSolTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T3.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros1]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros1] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros2]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros2] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros3]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros3] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaActua]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaActua] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaInsta]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaInsta] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesHoraInstal]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesHoraInstal] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesComentario]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesComentario] DESC";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[MetodoPagosID]";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[MetodoPagosID] DESC";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T2.[MetodoPagosNombre]";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T2.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNota]";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNota] DESC";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNotificaci]";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNotificaci] DESC";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesPagado] DESC";
         }
         GXv_Object23[0] = scmdbuf;
         GXv_Object23[1] = GXv_int22;
         return GXv_Object23 ;
      }

      protected Object[] conditional_H002Q4( IGxContext context ,
                                             string A442HistoricoSolicitudesPagado ,
                                             GxSimpleCollection<string> AV87TFHistoricoSolicitudesPagado_Sels ,
                                             string AV22TFHistoricoSolicitudesNombre_Sel ,
                                             string AV21TFHistoricoSolicitudesNombre ,
                                             string AV24TFHistoricoSolicitudesTelefono_Sel ,
                                             string AV23TFHistoricoSolicitudesTelefono ,
                                             string AV26TFHistoricoSolicitudesMail_Sel ,
                                             string AV25TFHistoricoSolicitudesMail ,
                                             string AV28TFHistoricoPaisID_Sel ,
                                             string AV27TFHistoricoPaisID ,
                                             long AV29TFHistoricoDepartamentoId ,
                                             long AV30TFHistoricoDepartamentoId_To ,
                                             long AV31TFHistoricoDepartamentoMunicipioId ,
                                             long AV32TFHistoricoDepartamentoMunicipioId_To ,
                                             long AV33TFHistoricoZonasID ,
                                             long AV34TFHistoricoZonasID_To ,
                                             string AV36TFHistoricoSolicitudesDireccion_Sel ,
                                             string AV35TFHistoricoSolicitudesDireccion ,
                                             short AV37TFHistoricoSolicitudesAutoEnumerar ,
                                             short AV38TFHistoricoSolicitudesAutoEnumerar_To ,
                                             decimal AV39TFHistoricoSolicitudesCotizacion ,
                                             decimal AV40TFHistoricoSolicitudesCotizacion_To ,
                                             decimal AV41TFHistoricoSolicitudesTotal ,
                                             decimal AV42TFHistoricoSolicitudesTotal_To ,
                                             string AV44TFHistoricoSolicitudServicioSolCoti_Sel ,
                                             string AV43TFHistoricoSolicitudServicioSolCoti ,
                                             string AV48TFEstadosSolTipo_Sel ,
                                             string AV47TFEstadosSolTipo ,
                                             string AV50TFEstadosSolNombre_Sel ,
                                             string AV49TFEstadosSolNombre ,
                                             string AV52TFHistoricoSolicitudesOtros1_Sel ,
                                             string AV51TFHistoricoSolicitudesOtros1 ,
                                             string AV54TFHistoricoSolicitudesOtros2_Sel ,
                                             string AV53TFHistoricoSolicitudesOtros2 ,
                                             string AV56TFHistoricoSolicitudesOtros3_Sel ,
                                             string AV55TFHistoricoSolicitudesOtros3 ,
                                             DateTime AV57TFHistoricoSolicitudesFechaAlta ,
                                             DateTime AV58TFHistoricoSolicitudesFechaAlta_To ,
                                             DateTime AV62TFHistoricoSolicitudesFechaActualizacion ,
                                             DateTime AV63TFHistoricoSolicitudesFechaActualizacion_To ,
                                             DateTime AV67TFHistoricoSolicitudesFechaInstalacion ,
                                             DateTime AV68TFHistoricoSolicitudesFechaInstalacion_To ,
                                             string AV73TFHistoricoSolicitudesHoraInstalacion_Sel ,
                                             string AV72TFHistoricoSolicitudesHoraInstalacion ,
                                             string AV75TFHistoricoSolicitudesComentario_Sel ,
                                             string AV74TFHistoricoSolicitudesComentario ,
                                             long AV76TFMetodoPagosID ,
                                             long AV77TFMetodoPagosID_To ,
                                             string AV79TFMetodoPagosNombre_Sel ,
                                             string AV78TFMetodoPagosNombre ,
                                             string AV81TFHistoricoSolicitudesNota_Sel ,
                                             string AV80TFHistoricoSolicitudesNota ,
                                             string AV83TFHistoricoSolicitudesNotificacion_Sel ,
                                             string AV82TFHistoricoSolicitudesNotificacion ,
                                             string AV85TFHistoricoSolicitudesOrigenPago_Sel ,
                                             string AV84TFHistoricoSolicitudesOrigenPago ,
                                             int AV87TFHistoricoSolicitudesPagado_Sels_Count ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A315HistoricoPaisID ,
                                             long A316HistoricoDepartamentoId ,
                                             long A317HistoricoDepartamentoMunicipio ,
                                             long A318HistoricoZonasID ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             short A292HistoricoSolicitudesAutoEnumer ,
                                             decimal A299HistoricoSolicitudesCotizacion ,
                                             decimal A300HistoricoSolicitudesTotal ,
                                             string A301HistoricoSolicitudServicioSolC ,
                                             string A130EstadosSolTipo ,
                                             string A132EstadosSolNombre ,
                                             string A303HistoricoSolicitudesOtros1 ,
                                             string A304HistoricoSolicitudesOtros2 ,
                                             string A305HistoricoSolicitudesOtros3 ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime A307HistoricoSolicitudesFechaActua ,
                                             DateTime A308HistoricoSolicitudesFechaInsta ,
                                             string A309HistoricoSolicitudesHoraInstal ,
                                             string A310HistoricoSolicitudesComentario ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A311HistoricoSolicitudesNota ,
                                             string A312HistoricoSolicitudesNotificaci ,
                                             string A439HistoricoSolicitudesOrigenPago ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             decimal AV45TFHistoricoSolicitudServicioPFinal ,
                                             decimal AV46TFHistoricoSolicitudServicioPFinal_To ,
                                             long AV8HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int24 = new short[53];
         Object[] GXv_Object25 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T1.[HistoricoSolicitudesNotificaci], T1.[HistoricoSolicitudesNota], T2.[MetodoPagosNombre], T1.[MetodoPagosID], T1.[HistoricoSolicitudesComentario], T1.[HistoricoSolicitudesHoraInstal], T1.[HistoricoSolicitudesFechaInsta], T1.[HistoricoSolicitudesFechaActua], T1.[HistoricoSolicitudesFechaAlta], T1.[HistoricoSolicitudesOtros3], T1.[HistoricoSolicitudesOtros2], T1.[HistoricoSolicitudesOtros1], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[HistoricoSolicitudServicioSolC], T1.[HistoricoSolicitudesAutoEnumer], T1.[HistoricoSolicitudesDireccion], T1.[HistoricoZonasID], T1.[HistoricoDepartamentoMunicipio], T1.[HistoricoDepartamentoId], T1.[HistoricoPaisID], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T1.[HistoricoSolicitudesCotizacion] FROM (([HistoricoSolicitudes] T1 INNER JOIN [MetodoPagos] T2 ON T2.[MetodoPagosID] = T1.[MetodoPagosID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV8HistoricoSolicitudesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHistoricoSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNombre]) like UPPER(@lV21TFHistoricoSolicitudesNombre))");
         }
         else
         {
            GXv_int24[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHistoricoSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNombre] = @AV22TFHistoricoSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int24[2] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFHistoricoSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesTelefono]) like UPPER(@lV23TFHistoricoSolicitudesTelefono))");
         }
         else
         {
            GXv_int24[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFHistoricoSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV24TFHistoricoSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesTelefono] = @AV24TFHistoricoSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int24[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFHistoricoSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFHistoricoSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesMail]) like UPPER(@lV25TFHistoricoSolicitudesMail))");
         }
         else
         {
            GXv_int24[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFHistoricoSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV26TFHistoricoSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesMail] = @AV26TFHistoricoSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int24[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFHistoricoSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesMail] IS NULL or (T1.[HistoricoSolicitudesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFHistoricoPaisID)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoPaisID]) like UPPER(@lV27TFHistoricoPaisID))");
         }
         else
         {
            GXv_int24[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFHistoricoPaisID_Sel)) && ! ( StringUtil.StrCmp(AV28TFHistoricoPaisID_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoPaisID] = @AV28TFHistoricoPaisID_Sel)");
         }
         else
         {
            GXv_int24[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFHistoricoPaisID_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoPaisID] = ''))");
         }
         if ( ! (0==AV29TFHistoricoDepartamentoId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoId] >= @AV29TFHistoricoDepartamentoId)");
         }
         else
         {
            GXv_int24[9] = 1;
         }
         if ( ! (0==AV30TFHistoricoDepartamentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoId] <= @AV30TFHistoricoDepartamentoId_To)");
         }
         else
         {
            GXv_int24[10] = 1;
         }
         if ( ! (0==AV31TFHistoricoDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoMunicipio] >= @AV31TFHistoricoDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int24[11] = 1;
         }
         if ( ! (0==AV32TFHistoricoDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoDepartamentoMunicipio] <= @AV32TFHistoricoDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int24[12] = 1;
         }
         if ( ! (0==AV33TFHistoricoZonasID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoZonasID] >= @AV33TFHistoricoZonasID)");
         }
         else
         {
            GXv_int24[13] = 1;
         }
         if ( ! (0==AV34TFHistoricoZonasID_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoZonasID] <= @AV34TFHistoricoZonasID_To)");
         }
         else
         {
            GXv_int24[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFHistoricoSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesDireccion]) like UPPER(@lV35TFHistoricoSolicitudesDireccion))");
         }
         else
         {
            GXv_int24[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHistoricoSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV36TFHistoricoSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesDireccion] = @AV36TFHistoricoSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int24[16] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFHistoricoSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesDireccion] = ''))");
         }
         if ( ! (0==AV37TFHistoricoSolicitudesAutoEnumerar) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesAutoEnumer] >= @AV37TFHistoricoSolicitudesAutoEnumerar)");
         }
         else
         {
            GXv_int24[17] = 1;
         }
         if ( ! (0==AV38TFHistoricoSolicitudesAutoEnumerar_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesAutoEnumer] <= @AV38TFHistoricoSolicitudesAutoEnumerar_To)");
         }
         else
         {
            GXv_int24[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39TFHistoricoSolicitudesCotizacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesCotizacion] >= @AV39TFHistoricoSolicitudesCotizacion)");
         }
         else
         {
            GXv_int24[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40TFHistoricoSolicitudesCotizacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesCotizacion] <= @AV40TFHistoricoSolicitudesCotizacion_To)");
         }
         else
         {
            GXv_int24[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFHistoricoSolicitudServicioSolCoti)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudServicioSolC]) like UPPER(@lV43TFHistoricoSolicitudServicioSolCoti))");
         }
         else
         {
            GXv_int24[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFHistoricoSolicitudServicioSolCoti_Sel)) && ! ( StringUtil.StrCmp(AV44TFHistoricoSolicitudServicioSolCoti_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudServicioSolC] = @AV44TFHistoricoSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int24[22] = 1;
         }
         if ( StringUtil.StrCmp(AV44TFHistoricoSolicitudServicioSolCoti_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudServicioSolC] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEstadosSolTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadosSolTipo]) like UPPER(@lV47TFEstadosSolTipo))");
         }
         else
         {
            GXv_int24[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEstadosSolTipo_Sel)) && ! ( StringUtil.StrCmp(AV48TFEstadosSolTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolTipo] = @AV48TFEstadosSolTipo_Sel)");
         }
         else
         {
            GXv_int24[24] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFEstadosSolTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadosSolTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEstadosSolNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV49TFEstadosSolNombre))");
         }
         else
         {
            GXv_int24[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEstadosSolNombre_Sel)) && ! ( StringUtil.StrCmp(AV50TFEstadosSolNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV50TFEstadosSolNombre_Sel)");
         }
         else
         {
            GXv_int24[26] = 1;
         }
         if ( StringUtil.StrCmp(AV50TFEstadosSolNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFHistoricoSolicitudesOtros1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros1]) like UPPER(@lV51TFHistoricoSolicitudesOtros1))");
         }
         else
         {
            GXv_int24[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFHistoricoSolicitudesOtros1_Sel)) && ! ( StringUtil.StrCmp(AV52TFHistoricoSolicitudesOtros1_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros1] = @AV52TFHistoricoSolicitudesOtros1_Sel)");
         }
         else
         {
            GXv_int24[28] = 1;
         }
         if ( StringUtil.StrCmp(AV52TFHistoricoSolicitudesOtros1_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros1] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFHistoricoSolicitudesOtros2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros2]) like UPPER(@lV53TFHistoricoSolicitudesOtros2))");
         }
         else
         {
            GXv_int24[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFHistoricoSolicitudesOtros2_Sel)) && ! ( StringUtil.StrCmp(AV54TFHistoricoSolicitudesOtros2_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros2] = @AV54TFHistoricoSolicitudesOtros2_Sel)");
         }
         else
         {
            GXv_int24[30] = 1;
         }
         if ( StringUtil.StrCmp(AV54TFHistoricoSolicitudesOtros2_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros2] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFHistoricoSolicitudesOtros3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOtros3]) like UPPER(@lV55TFHistoricoSolicitudesOtros3))");
         }
         else
         {
            GXv_int24[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHistoricoSolicitudesOtros3_Sel)) && ! ( StringUtil.StrCmp(AV56TFHistoricoSolicitudesOtros3_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOtros3] = @AV56TFHistoricoSolicitudesOtros3_Sel)");
         }
         else
         {
            GXv_int24[32] = 1;
         }
         if ( StringUtil.StrCmp(AV56TFHistoricoSolicitudesOtros3_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOtros3] = ''))");
         }
         if ( ! (DateTime.MinValue==AV57TFHistoricoSolicitudesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV57TFHistoricoSolicitudesFechaAlta)");
         }
         else
         {
            GXv_int24[33] = 1;
         }
         if ( ! (DateTime.MinValue==AV58TFHistoricoSolicitudesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] <= @AV58TFHistoricoSolicitudesFechaAlta_To)");
         }
         else
         {
            GXv_int24[34] = 1;
         }
         if ( ! (DateTime.MinValue==AV62TFHistoricoSolicitudesFechaActualizacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaActua] >= @AV62TFHistoricoSolicitudesFechaActualizacion)");
         }
         else
         {
            GXv_int24[35] = 1;
         }
         if ( ! (DateTime.MinValue==AV63TFHistoricoSolicitudesFechaActualizacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaActua] <= @AV63TFHistoricoSolicitudesFechaActualizacion_To)");
         }
         else
         {
            GXv_int24[36] = 1;
         }
         if ( ! (DateTime.MinValue==AV67TFHistoricoSolicitudesFechaInstalacion) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaInsta] >= @AV67TFHistoricoSolicitudesFechaInstalacion)");
         }
         else
         {
            GXv_int24[37] = 1;
         }
         if ( ! (DateTime.MinValue==AV68TFHistoricoSolicitudesFechaInstalacion_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaInsta] <= @AV68TFHistoricoSolicitudesFechaInstalacion_To)");
         }
         else
         {
            GXv_int24[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFHistoricoSolicitudesHoraInstalacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesHoraInstal]) like UPPER(@lV72TFHistoricoSolicitudesHoraInstalacion))");
         }
         else
         {
            GXv_int24[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFHistoricoSolicitudesHoraInstalacion_Sel)) && ! ( StringUtil.StrCmp(AV73TFHistoricoSolicitudesHoraInstalacion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesHoraInstal] = @AV73TFHistoricoSolicitudesHoraInstalacion_Sel)");
         }
         else
         {
            GXv_int24[40] = 1;
         }
         if ( StringUtil.StrCmp(AV73TFHistoricoSolicitudesHoraInstalacion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesHoraInstal] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFHistoricoSolicitudesComentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesComentario]) like UPPER(@lV74TFHistoricoSolicitudesComentario))");
         }
         else
         {
            GXv_int24[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFHistoricoSolicitudesComentario_Sel)) && ! ( StringUtil.StrCmp(AV75TFHistoricoSolicitudesComentario_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesComentario] = @AV75TFHistoricoSolicitudesComentario_Sel)");
         }
         else
         {
            GXv_int24[42] = 1;
         }
         if ( StringUtil.StrCmp(AV75TFHistoricoSolicitudesComentario_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[HistoricoSolicitudesComentario])=0))");
         }
         if ( ! (0==AV76TFMetodoPagosID) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV76TFMetodoPagosID)");
         }
         else
         {
            GXv_int24[43] = 1;
         }
         if ( ! (0==AV77TFMetodoPagosID_To) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV77TFMetodoPagosID_To)");
         }
         else
         {
            GXv_int24[44] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78TFMetodoPagosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MetodoPagosNombre]) like UPPER(@lV78TFMetodoPagosNombre))");
         }
         else
         {
            GXv_int24[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMetodoPagosNombre_Sel)) && ! ( StringUtil.StrCmp(AV79TFMetodoPagosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MetodoPagosNombre] = @AV79TFMetodoPagosNombre_Sel)");
         }
         else
         {
            GXv_int24[46] = 1;
         }
         if ( StringUtil.StrCmp(AV79TFMetodoPagosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFHistoricoSolicitudesNota)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNota]) like UPPER(@lV80TFHistoricoSolicitudesNota))");
         }
         else
         {
            GXv_int24[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFHistoricoSolicitudesNota_Sel)) && ! ( StringUtil.StrCmp(AV81TFHistoricoSolicitudesNota_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNota] = @AV81TFHistoricoSolicitudesNota_Sel)");
         }
         else
         {
            GXv_int24[48] = 1;
         }
         if ( StringUtil.StrCmp(AV81TFHistoricoSolicitudesNota_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNota] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFHistoricoSolicitudesNotificacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesNotificaci]) like UPPER(@lV82TFHistoricoSolicitudesNotificacion))");
         }
         else
         {
            GXv_int24[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFHistoricoSolicitudesNotificacion_Sel)) && ! ( StringUtil.StrCmp(AV83TFHistoricoSolicitudesNotificacion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesNotificaci] = @AV83TFHistoricoSolicitudesNotificacion_Sel)");
         }
         else
         {
            GXv_int24[50] = 1;
         }
         if ( StringUtil.StrCmp(AV83TFHistoricoSolicitudesNotificacion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesNotificaci] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFHistoricoSolicitudesOrigenPago)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesOrigenPago]) like UPPER(@lV84TFHistoricoSolicitudesOrigenPago))");
         }
         else
         {
            GXv_int24[51] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFHistoricoSolicitudesOrigenPago_Sel)) && ! ( StringUtil.StrCmp(AV85TFHistoricoSolicitudesOrigenPago_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesOrigenPago] = @AV85TFHistoricoSolicitudesOrigenPago_Sel)");
         }
         else
         {
            GXv_int24[52] = 1;
         }
         if ( StringUtil.StrCmp(AV85TFHistoricoSolicitudesOrigenPago_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesOrigenPago] = ''))");
         }
         if ( AV87TFHistoricoSolicitudesPagado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV87TFHistoricoSolicitudesPagado_Sels, "T1.[HistoricoSolicitudesPagado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoPaisID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoPaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoDepartamentoId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoDepartamentoId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoDepartamentoMunicipio]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoDepartamentoMunicipio] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoZonasID]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoZonasID] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesAutoEnumer]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesAutoEnumer] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudServicioSolC]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudServicioSolC] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[EstadosSolTipo]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[EstadosSolTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T3.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros1]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros1] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros2]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros2] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOtros3]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOtros3] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaActua]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaActua] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesFechaInsta]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesFechaInsta] DESC";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesHoraInstal]";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesHoraInstal] DESC";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesComentario]";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesComentario] DESC";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[MetodoPagosID]";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[MetodoPagosID] DESC";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T2.[MetodoPagosNombre]";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T2.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNota]";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNota] DESC";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesNotificaci]";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesNotificaci] DESC";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC, T1.[HistoricoSolicitudesPagado] DESC";
         }
         GXv_Object25[0] = scmdbuf;
         GXv_Object25[1] = GXv_int24;
         return GXv_Object25 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H002Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (long)dynConstraints[46] , (long)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (int)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (long)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (string)dynConstraints[64] , (short)dynConstraints[65] , (decimal)dynConstraints[66] , (decimal)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (DateTime)dynConstraints[74] , (DateTime)dynConstraints[75] , (DateTime)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (long)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (short)dynConstraints[84] , (bool)dynConstraints[85] , (string)dynConstraints[86] , (decimal)dynConstraints[87] , (decimal)dynConstraints[88] , (decimal)dynConstraints[89] , (long)dynConstraints[90] , (long)dynConstraints[91] );
               case 2 :
                     return conditional_H002Q4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (long)dynConstraints[46] , (long)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (int)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (long)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (string)dynConstraints[64] , (short)dynConstraints[65] , (decimal)dynConstraints[66] , (decimal)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (DateTime)dynConstraints[74] , (DateTime)dynConstraints[75] , (DateTime)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (long)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (short)dynConstraints[84] , (bool)dynConstraints[85] , (string)dynConstraints[86] , (decimal)dynConstraints[87] , (decimal)dynConstraints[88] , (decimal)dynConstraints[89] , (long)dynConstraints[90] , (long)dynConstraints[91] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002Q2;
          prmH002Q2 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH002Q3;
          prmH002Q3 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHistoricoSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHistoricoSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV23TFHistoricoSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV24TFHistoricoSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV25TFHistoricoSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFHistoricoSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV27TFHistoricoPaisID",GXType.Char,2,0) ,
          new ParDef("@AV28TFHistoricoPaisID_Sel",GXType.NChar,2,0) ,
          new ParDef("@AV29TFHistoricoDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHistoricoDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV31TFHistoricoDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFHistoricoDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFHistoricoZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV34TFHistoricoZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV35TFHistoricoSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV36TFHistoricoSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV37TFHistoricoSolicitudesAutoEnumerar",GXType.Int16,4,0) ,
          new ParDef("@AV38TFHistoricoSolicitudesAutoEnumerar_To",GXType.Int16,4,0) ,
          new ParDef("@AV39TFHistoricoSolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@AV40TFHistoricoSolicitudesCotizacion_To",GXType.Decimal,18,2) ,
          new ParDef("@lV43TFHistoricoSolicitudServicioSolCoti",GXType.Char,1,0) ,
          new ParDef("@AV44TFHistoricoSolicitudServicioSolCoti_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV47TFEstadosSolTipo",GXType.Char,3,0) ,
          new ParDef("@AV48TFEstadosSolTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV49TFEstadosSolNombre",GXType.Char,80,0) ,
          new ParDef("@AV50TFEstadosSolNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV51TFHistoricoSolicitudesOtros1",GXType.Char,1,0) ,
          new ParDef("@AV52TFHistoricoSolicitudesOtros1_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV53TFHistoricoSolicitudesOtros2",GXType.Char,1000,0) ,
          new ParDef("@AV54TFHistoricoSolicitudesOtros2_Sel",GXType.NChar,1000,0) ,
          new ParDef("@lV55TFHistoricoSolicitudesOtros3",GXType.Char,500,0) ,
          new ParDef("@AV56TFHistoricoSolicitudesOtros3_Sel",GXType.NChar,500,0) ,
          new ParDef("@AV57TFHistoricoSolicitudesFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV58TFHistoricoSolicitudesFechaAlta_To",GXType.Date,8,0) ,
          new ParDef("@AV62TFHistoricoSolicitudesFechaActualizacion",GXType.DateTime,8,5) ,
          new ParDef("@AV63TFHistoricoSolicitudesFechaActualizacion_To",GXType.DateTime,8,5) ,
          new ParDef("@AV67TFHistoricoSolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@AV68TFHistoricoSolicitudesFechaInstalacion_To",GXType.Date,8,0) ,
          new ParDef("@lV72TFHistoricoSolicitudesHoraInstalacion",GXType.Char,1,0) ,
          new ParDef("@AV73TFHistoricoSolicitudesHoraInstalacion_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV74TFHistoricoSolicitudesComentario",GXType.VarChar,200,0) ,
          new ParDef("@AV75TFHistoricoSolicitudesComentario_Sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76TFMetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV77TFMetodoPagosID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV78TFMetodoPagosNombre",GXType.Char,80,0) ,
          new ParDef("@AV79TFMetodoPagosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV80TFHistoricoSolicitudesNota",GXType.Char,500,0) ,
          new ParDef("@AV81TFHistoricoSolicitudesNota_Sel",GXType.NChar,500,0) ,
          new ParDef("@lV82TFHistoricoSolicitudesNotificacion",GXType.Char,1,0) ,
          new ParDef("@AV83TFHistoricoSolicitudesNotificacion_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV84TFHistoricoSolicitudesOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV85TFHistoricoSolicitudesOrigenPago_Sel",GXType.NChar,1,0)
          };
          Object[] prmH002Q4;
          prmH002Q4 = new Object[] {
          new ParDef("@AV8HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHistoricoSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHistoricoSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV23TFHistoricoSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV24TFHistoricoSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV25TFHistoricoSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFHistoricoSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV27TFHistoricoPaisID",GXType.Char,2,0) ,
          new ParDef("@AV28TFHistoricoPaisID_Sel",GXType.NChar,2,0) ,
          new ParDef("@AV29TFHistoricoDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHistoricoDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV31TFHistoricoDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFHistoricoDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFHistoricoZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV34TFHistoricoZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV35TFHistoricoSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV36TFHistoricoSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV37TFHistoricoSolicitudesAutoEnumerar",GXType.Int16,4,0) ,
          new ParDef("@AV38TFHistoricoSolicitudesAutoEnumerar_To",GXType.Int16,4,0) ,
          new ParDef("@AV39TFHistoricoSolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@AV40TFHistoricoSolicitudesCotizacion_To",GXType.Decimal,18,2) ,
          new ParDef("@lV43TFHistoricoSolicitudServicioSolCoti",GXType.Char,1,0) ,
          new ParDef("@AV44TFHistoricoSolicitudServicioSolCoti_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV47TFEstadosSolTipo",GXType.Char,3,0) ,
          new ParDef("@AV48TFEstadosSolTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV49TFEstadosSolNombre",GXType.Char,80,0) ,
          new ParDef("@AV50TFEstadosSolNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV51TFHistoricoSolicitudesOtros1",GXType.Char,1,0) ,
          new ParDef("@AV52TFHistoricoSolicitudesOtros1_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV53TFHistoricoSolicitudesOtros2",GXType.Char,1000,0) ,
          new ParDef("@AV54TFHistoricoSolicitudesOtros2_Sel",GXType.NChar,1000,0) ,
          new ParDef("@lV55TFHistoricoSolicitudesOtros3",GXType.Char,500,0) ,
          new ParDef("@AV56TFHistoricoSolicitudesOtros3_Sel",GXType.NChar,500,0) ,
          new ParDef("@AV57TFHistoricoSolicitudesFechaAlta",GXType.Date,8,0) ,
          new ParDef("@AV58TFHistoricoSolicitudesFechaAlta_To",GXType.Date,8,0) ,
          new ParDef("@AV62TFHistoricoSolicitudesFechaActualizacion",GXType.DateTime,8,5) ,
          new ParDef("@AV63TFHistoricoSolicitudesFechaActualizacion_To",GXType.DateTime,8,5) ,
          new ParDef("@AV67TFHistoricoSolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@AV68TFHistoricoSolicitudesFechaInstalacion_To",GXType.Date,8,0) ,
          new ParDef("@lV72TFHistoricoSolicitudesHoraInstalacion",GXType.Char,1,0) ,
          new ParDef("@AV73TFHistoricoSolicitudesHoraInstalacion_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV74TFHistoricoSolicitudesComentario",GXType.VarChar,200,0) ,
          new ParDef("@AV75TFHistoricoSolicitudesComentario_Sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76TFMetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV77TFMetodoPagosID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV78TFMetodoPagosNombre",GXType.Char,80,0) ,
          new ParDef("@AV79TFMetodoPagosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV80TFHistoricoSolicitudesNota",GXType.Char,500,0) ,
          new ParDef("@AV81TFHistoricoSolicitudesNota_Sel",GXType.NChar,500,0) ,
          new ParDef("@lV82TFHistoricoSolicitudesNotificacion",GXType.Char,1,0) ,
          new ParDef("@AV83TFHistoricoSolicitudesNotificacion_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV84TFHistoricoSolicitudesOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV85TFHistoricoSolicitudesOrigenPago_Sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002Q2", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q4,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 500);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 500);
                ((string[]) buf[13])[0] = rslt.getString(14, 1000);
                ((string[]) buf[14])[0] = rslt.getString(15, 1);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                ((string[]) buf[17])[0] = rslt.getString(18, 3);
                ((string[]) buf[18])[0] = rslt.getString(19, 1);
                ((short[]) buf[19])[0] = rslt.getShort(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((long[]) buf[21])[0] = rslt.getLong(22);
                ((bool[]) buf[22])[0] = rslt.wasNull(22);
                ((long[]) buf[23])[0] = rslt.getLong(23);
                ((long[]) buf[24])[0] = rslt.getLong(24);
                ((string[]) buf[25])[0] = rslt.getString(25, 2);
                ((string[]) buf[26])[0] = rslt.getVarchar(26);
                ((bool[]) buf[27])[0] = rslt.wasNull(26);
                ((string[]) buf[28])[0] = rslt.getString(27, 20);
                ((string[]) buf[29])[0] = rslt.getString(28, 100);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 500);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 500);
                ((string[]) buf[13])[0] = rslt.getString(14, 1000);
                ((string[]) buf[14])[0] = rslt.getString(15, 1);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((int[]) buf[16])[0] = rslt.getInt(17);
                ((string[]) buf[17])[0] = rslt.getString(18, 3);
                ((string[]) buf[18])[0] = rslt.getString(19, 1);
                ((short[]) buf[19])[0] = rslt.getShort(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((long[]) buf[21])[0] = rslt.getLong(22);
                ((bool[]) buf[22])[0] = rslt.wasNull(22);
                ((long[]) buf[23])[0] = rslt.getLong(23);
                ((long[]) buf[24])[0] = rslt.getLong(24);
                ((string[]) buf[25])[0] = rslt.getString(25, 2);
                ((string[]) buf[26])[0] = rslt.getVarchar(26);
                ((bool[]) buf[27])[0] = rslt.wasNull(26);
                ((string[]) buf[28])[0] = rslt.getString(27, 20);
                ((string[]) buf[29])[0] = rslt.getString(28, 100);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                return;
       }
    }

 }

}
