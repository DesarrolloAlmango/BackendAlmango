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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class obtenerreportedeconomico : GXProcedure
   {
      public obtenerreportedeconomico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerreportedeconomico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           int aP4_Clasificaciones ,
                           string aP5_SolicitudServicioOrigenPago ,
                           out GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ,
                           out string aP7_RestMessage ,
                           out short aP8_Gx_restcode )
      {
         this.AV29User = aP0_User;
         this.AV18ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Desde = aP2_Desde;
         this.AV14Hasta = aP3_Hasta;
         this.AV8Clasificaciones = aP4_Clasificaciones;
         this.AV22SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV20SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico(context) ;
         this.AV19RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP6_SDT_ReporteFinanciero=this.AV20SDT_ReporteFinanciero;
         aP7_RestMessage=this.AV19RestMessage;
         aP8_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               DateTime aP2_Desde ,
                               DateTime aP3_Hasta ,
                               int aP4_Clasificaciones ,
                               string aP5_SolicitudServicioOrigenPago ,
                               out GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ,
                               out string aP7_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_Desde, aP3_Hasta, aP4_Clasificaciones, aP5_SolicitudServicioOrigenPago, out aP6_SDT_ReporteFinanciero, out aP7_RestMessage, out aP8_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 int aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 out GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ,
                                 out string aP7_RestMessage ,
                                 out short aP8_Gx_restcode )
      {
         this.AV29User = aP0_User;
         this.AV18ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Desde = aP2_Desde;
         this.AV14Hasta = aP3_Hasta;
         this.AV8Clasificaciones = aP4_Clasificaciones;
         this.AV22SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV20SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico(context) ;
         this.AV19RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP6_SDT_ReporteFinanciero=this.AV20SDT_ReporteFinanciero;
         aP7_RestMessage=this.AV19RestMessage;
         aP8_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV29User)) || (DateTime.MinValue==AV10Desde) || (DateTime.MinValue==AV14Hasta) )
         {
            Gx_restcode = 400;
            AV19RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV15HttpRequest, out  AV24TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TokenId)) )
         {
            Gx_restcode = 401;
            AV19RestMessage = "Parece que tu sesión terminó. Inicia sesión otra vez";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV29User,  AV18ProfesionalesId,  AV24TokenId, out  AV12EsValido, out  AV23TokenDesencriptado) ;
         if ( ! AV12EsValido )
         {
            Gx_restcode = 401;
            AV19RestMessage = context.GetMessage( "Parece que tu sesión terminó. Inicia sesión otra vez", "");
            cleanup();
            if (true) return;
         }
         AV26TotalCobrado = 0;
         AV25TotalAlmango = 0;
         AV27TotalProfesional = 0;
         AV28TotalProfNoCDirecto = 0;
         AV20SDT_ReporteFinanciero.gxTpr_Cabezal.gxTpr_Rangofechas = context.GetMessage( "Rango de fecha: ", "")+context.localUtil.Format( AV10Desde, "99/99/99")+" - "+context.localUtil.Format( AV14Hasta, "99/99/99");
         AV20SDT_ReporteFinanciero.gxTpr_Cabezal.gxTpr_Fechareporte = Gx_date;
         /* Using cursor P00MH2 */
         pr_default.execute(0, new Object[] {AV8Clasificaciones, AV10Desde, AV14Hasta, AV22SolicitudServicioOrigenPago});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P00MH2_A130EstadosSolTipo[0];
            A438SolicitudServicioOrigenPago = P00MH2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00MH2_n438SolicitudServicioOrigenPago[0];
            A184SolicitudesFechaInstalacion = P00MH2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00MH2_A131EstadosSolId[0];
            A127SolicitudesID = P00MH2_A127SolicitudesID[0];
            A171SolicitudesNombre = P00MH2_A171SolicitudesNombre[0];
            A132EstadosSolNombre = P00MH2_A132EstadosSolNombre[0];
            A527SolicitudServicioComProv = P00MH2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00MH2_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00MH2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00MH2_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00MH2_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00MH2_n865SolicitudesCostoXZComAlm[0];
            A796SolicitudesComisionMetodoPago = P00MH2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00MH2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00MH2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00MH2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00MH2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00MH2_A864SolicitudesCostoXZona[0];
            A132EstadosSolNombre = P00MH2_A132EstadosSolNombre[0];
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
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
            if ( ( ( AV8Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV8Clasificaciones > 0 ) )
            {
               GXt_char1 = AV13Exists;
               new oexisterelacion(context ).execute(  A127SolicitudesID,  AV18ProfesionalesId, out  GXt_char1) ;
               AV13Exists = (String.IsNullOrEmpty(StringUtil.RTrim( AV18ProfesionalesId)) ? context.GetMessage( "S", "") : GXt_char1);
               if ( StringUtil.StrCmp(AV13Exists, context.GetMessage( "S", "")) == 0 )
               {
                  AV21SDT_ReporteFinancieroItem = new GeneXus.Programs.apis.SdtSdtReporteDEconomico_SolicitudesItem(context);
                  AV21SDT_ReporteFinancieroItem.gxTpr_Solicitudesid = A127SolicitudesID;
                  AV21SDT_ReporteFinancieroItem.gxTpr_Nombrecliente = A171SolicitudesNombre;
                  AV21SDT_ReporteFinancieroItem.gxTpr_Estado = A132EstadosSolNombre;
                  AV21SDT_ReporteFinancieroItem.gxTpr_Origenpago = A438SolicitudServicioOrigenPago;
                  AV11EsCD = ((StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "F")==0) ? true : false);
                  AV21SDT_ReporteFinancieroItem.gxTpr_Escobrodirecto = AV11EsCD;
                  if ( AV11EsCD )
                  {
                     AV16ImpCobrado = A211SolicitudServicioPFinal;
                     AV9ComisAlm = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm+A527SolicitudServicioComProv);
                     AV26TotalCobrado = (decimal)(AV26TotalCobrado+AV16ImpCobrado);
                     AV25TotalAlmango = (decimal)(AV25TotalAlmango+AV9ComisAlm);
                  }
                  else
                  {
                     AV16ImpCobrado = 0;
                     AV9ComisAlm = 0;
                  }
                  AV17PagoProf = (decimal)(System.Math.Abs( A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf));
                  AV21SDT_ReporteFinancieroItem.gxTpr_Importecobrado = AV16ImpCobrado;
                  AV21SDT_ReporteFinancieroItem.gxTpr_Comisionalmango = AV9ComisAlm;
                  AV21SDT_ReporteFinancieroItem.gxTpr_Pagoprofesional = AV17PagoProf;
                  if ( ! AV11EsCD )
                  {
                     AV28TotalProfNoCDirecto = (decimal)(AV28TotalProfNoCDirecto+AV17PagoProf);
                  }
                  AV27TotalProfesional = (decimal)(AV27TotalProfesional+AV17PagoProf);
                  AV20SDT_ReporteFinanciero.gxTpr_Solicitudes.Add(AV21SDT_ReporteFinancieroItem, 0);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20SDT_ReporteFinanciero.gxTpr_Totales.gxTpr_Totalcobrado = AV26TotalCobrado;
         AV20SDT_ReporteFinanciero.gxTpr_Totales.gxTpr_Totalalmango = AV25TotalAlmango;
         AV20SDT_ReporteFinanciero.gxTpr_Totales.gxTpr_Totalprofesional = AV27TotalProfesional;
         AV20SDT_ReporteFinanciero.gxTpr_Totales.gxTpr_Totalprofnocdirecto = AV28TotalProfNoCDirecto;
         AV20SDT_ReporteFinanciero.gxTpr_Totales.gxTpr_Resultadoneto = (decimal)(AV25TotalAlmango-AV28TotalProfNoCDirecto);
         Gx_restcode = 200;
         AV19RestMessage = context.GetMessage( "Solicitude procesada con éxito", "");
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00MH3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00MH3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00MH3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00MH3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00MH3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00MH3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])-(P00MH3_A180SolicitudItemsComision[0]*P00MH3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00MH3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00MH3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])+(P00MH3_A180SolicitudItemsComision[0]*P00MH3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00MH3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00MH3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])-((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])*(P00MH3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00MH3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00MH3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])+((P00MH3_A176SolicitudesItemsPrecioFinal[0]*P00MH3_A177SolicitudesItemsCantidad[0])*(P00MH3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV20SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico(context);
         AV19RestMessage = "";
         AV15HttpRequest = new GxHttpRequest( context);
         AV24TokenId = "";
         AV23TokenDesencriptado = "";
         Gx_date = DateTime.MinValue;
         P00MH2_A130EstadosSolTipo = new string[] {""} ;
         P00MH2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00MH2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00MH2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00MH2_A131EstadosSolId = new int[1] ;
         P00MH2_A127SolicitudesID = new long[1] ;
         P00MH2_A171SolicitudesNombre = new string[] {""} ;
         P00MH2_A132EstadosSolNombre = new string[] {""} ;
         P00MH2_A527SolicitudServicioComProv = new decimal[1] ;
         P00MH2_n527SolicitudServicioComProv = new bool[] {false} ;
         P00MH2_A530SolicitudServicioComALM = new decimal[1] ;
         P00MH2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00MH2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00MH2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00MH2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00MH2_A212SolicitudesCotizacion = new decimal[1] ;
         P00MH2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00MH2_A897SolicitudesDescuento = new decimal[1] ;
         P00MH2_n897SolicitudesDescuento = new bool[] {false} ;
         P00MH2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV13Exists = "";
         GXt_char1 = "";
         AV21SDT_ReporteFinancieroItem = new GeneXus.Programs.apis.SdtSdtReporteDEconomico_SolicitudesItem(context);
         P00MH3_A127SolicitudesID = new long[1] ;
         P00MH3_A134SolicitudesItemsID = new short[1] ;
         P00MH3_A180SolicitudItemsComision = new decimal[1] ;
         P00MH3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00MH3_A178SolicitudItemsSR = new string[] {""} ;
         P00MH3_A177SolicitudesItemsCantidad = new short[1] ;
         P00MH3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00MH3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenerreportedeconomico__default(),
            new Object[][] {
                new Object[] {
               P00MH2_A130EstadosSolTipo, P00MH2_A438SolicitudServicioOrigenPago, P00MH2_n438SolicitudServicioOrigenPago, P00MH2_A184SolicitudesFechaInstalacion, P00MH2_A131EstadosSolId, P00MH2_A127SolicitudesID, P00MH2_A171SolicitudesNombre, P00MH2_A132EstadosSolNombre, P00MH2_A527SolicitudServicioComProv, P00MH2_n527SolicitudServicioComProv,
               P00MH2_A530SolicitudServicioComALM, P00MH2_n530SolicitudServicioComALM, P00MH2_A865SolicitudesCostoXZComAlm, P00MH2_n865SolicitudesCostoXZComAlm, P00MH2_A796SolicitudesComisionMetodoPago, P00MH2_A212SolicitudesCotizacion, P00MH2_A1016SolicitudesDescuentoCupon, P00MH2_A897SolicitudesDescuento, P00MH2_n897SolicitudesDescuento, P00MH2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00MH3_A127SolicitudesID, P00MH3_A134SolicitudesItemsID, P00MH3_A180SolicitudItemsComision, P00MH3_A179SolicitudItemsComisionTipo, P00MH3_A178SolicitudItemsSR, P00MH3_A177SolicitudesItemsCantidad, P00MH3_A176SolicitudesItemsPrecioFinal, P00MH3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Gx_restcode ;
      private int AV8Clasificaciones ;
      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private decimal AV26TotalCobrado ;
      private decimal AV25TotalAlmango ;
      private decimal AV27TotalProfesional ;
      private decimal AV28TotalProfNoCDirecto ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal AV16ImpCobrado ;
      private decimal AV9ComisAlm ;
      private decimal AV17PagoProf ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV29User ;
      private string AV18ProfesionalesId ;
      private string AV22SolicitudServicioOrigenPago ;
      private string AV24TokenId ;
      private string AV23TokenDesencriptado ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV13Exists ;
      private string GXt_char1 ;
      private DateTime AV10Desde ;
      private DateTime AV14Hasta ;
      private DateTime Gx_date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV12EsValido ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n897SolicitudesDescuento ;
      private bool AV11EsCD ;
      private string AV19RestMessage ;
      private GxHttpRequest AV15HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.SdtSdtReporteDEconomico AV20SDT_ReporteFinanciero ;
      private IDataStoreProvider pr_default ;
      private string[] P00MH2_A130EstadosSolTipo ;
      private string[] P00MH2_A438SolicitudServicioOrigenPago ;
      private bool[] P00MH2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00MH2_A184SolicitudesFechaInstalacion ;
      private int[] P00MH2_A131EstadosSolId ;
      private long[] P00MH2_A127SolicitudesID ;
      private string[] P00MH2_A171SolicitudesNombre ;
      private string[] P00MH2_A132EstadosSolNombre ;
      private decimal[] P00MH2_A527SolicitudServicioComProv ;
      private bool[] P00MH2_n527SolicitudServicioComProv ;
      private decimal[] P00MH2_A530SolicitudServicioComALM ;
      private bool[] P00MH2_n530SolicitudServicioComALM ;
      private decimal[] P00MH2_A865SolicitudesCostoXZComAlm ;
      private bool[] P00MH2_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00MH2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00MH2_A212SolicitudesCotizacion ;
      private decimal[] P00MH2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00MH2_A897SolicitudesDescuento ;
      private bool[] P00MH2_n897SolicitudesDescuento ;
      private decimal[] P00MH2_A864SolicitudesCostoXZona ;
      private GeneXus.Programs.apis.SdtSdtReporteDEconomico_SolicitudesItem AV21SDT_ReporteFinancieroItem ;
      private long[] P00MH3_A127SolicitudesID ;
      private short[] P00MH3_A134SolicitudesItemsID ;
      private decimal[] P00MH3_A180SolicitudItemsComision ;
      private string[] P00MH3_A179SolicitudItemsComisionTipo ;
      private string[] P00MH3_A178SolicitudItemsSR ;
      private short[] P00MH3_A177SolicitudesItemsCantidad ;
      private decimal[] P00MH3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00MH3_n176SolicitudesItemsPrecioFinal ;
      private GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ;
      private string aP7_RestMessage ;
      private short aP8_Gx_restcode ;
   }

   public class obtenerreportedeconomico__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MH2;
          prmP00MH2 = new Object[] {
          new ParDef("@AV8Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV10Desde",GXType.Date,8,0) ,
          new ParDef("@AV14Hasta",GXType.Date,8,0) ,
          new ParDef("@AV22SolicitudServicioOrigenPago",GXType.NChar,1,0)
          };
          Object[] prmP00MH3;
          prmP00MH3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MH2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[EstadosSolId] = @AV8Clasificaciones or @AV8Clasificaciones = 0) AND (T1.[SolicitudesFechaInstalacion] >= @AV10Desde and T1.[SolicitudesFechaInstalacion] <= @AV14Hasta) AND (T1.[SolicitudServicioOrigenPago] = @AV22SolicitudServicioOrigenPago or (@AV22SolicitudServicioOrigenPago = '')) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00MH3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MH3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
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
       }
    }

 }

}
