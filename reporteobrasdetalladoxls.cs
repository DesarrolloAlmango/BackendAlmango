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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class reporteobrasdetalladoxls : GXProcedure
   {
      public reporteobrasdetalladoxls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reporteobrasdetalladoxls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedoresTipoId ,
                           long aP1_ProveedorID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           short aP4_Clasificaciones ,
                           string aP5_SolicitudServicioOrigenPago ,
                           bool aP6_DSPALmango ,
                           long aP7_SolicitudesID )
      {
         this.AV43ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV44ProveedorID = aP1_ProveedorID;
         this.AV19Desde = aP2_Desde;
         this.AV30Hasta = aP3_Hasta;
         this.AV11Clasificaciones = aP4_Clasificaciones;
         this.AV64SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV22DSPALmango = aP6_DSPALmango;
         this.AV47SolicitudesID = aP7_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 short aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 bool aP6_DSPALmango ,
                                 long aP7_SolicitudesID )
      {
         this.AV43ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV44ProveedorID = aP1_ProveedorID;
         this.AV19Desde = aP2_Desde;
         this.AV30Hasta = aP3_Hasta;
         this.AV11Clasificaciones = aP4_Clasificaciones;
         this.AV64SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV22DSPALmango = aP6_DSPALmango;
         this.AV47SolicitudesID = aP7_SolicitudesID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV46Random = (short)(NumberUtil.Random( )*10000);
         AV29FileName = "ReporteDetalladoGastos-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV46Random), 4, 0)) + ".xlsx";
         AV25ExcelDocument.Open(AV29FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV25ExcelDocument.Clear();
         /* Execute user subroutine: 'COLUMNTITLE' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV74NuevaDesde = AV19Desde;
         AV75NuevaHasta = AV30Hasta;
         if ( (0==AV47SolicitudesID) )
         {
            /* Using cursor P00IW2 */
            pr_default.execute(0, new Object[] {AV19Desde, AV30Hasta});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A461CentroCostosId = P00IW2_A461CentroCostosId[0];
               A892CentroCostosDetallesFecha = P00IW2_A892CentroCostosDetallesFecha[0];
               A462CentroCostosRef = P00IW2_A462CentroCostosRef[0];
               A466CentroCostosDetallesId = P00IW2_A466CentroCostosDetallesId[0];
               A462CentroCostosRef = P00IW2_A462CentroCostosRef[0];
               AV76CentroCostosRef = A462CentroCostosRef;
               /* Execute user subroutine: 'ACTUALIZARFECHAS' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         /* Using cursor P00IW3 */
         pr_default.execute(1, new Object[] {AV44ProveedorID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A133ProveedorID = P00IW3_A133ProveedorID[0];
            AV45ProveedorNombre = StringUtil.Upper( AV45ProveedorNombre);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A127SolicitudesID ,
                                              AV77SolicitudesIDCollection ,
                                              AV47SolicitudesID ,
                                              A130EstadosSolTipo ,
                                              A131EstadosSolId ,
                                              AV11Clasificaciones ,
                                              A133ProveedorID ,
                                              AV44ProveedorID ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV64SolicitudServicioOrigenPago ,
                                              A600SolicitudesSubTipo ,
                                              AV75NuevaHasta ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV74NuevaDesde } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE
                                              }
         });
         /* Using cursor P00IW4 */
         pr_default.execute(2, new Object[] {AV75NuevaHasta, AV11Clasificaciones, AV11Clasificaciones, AV44ProveedorID, AV44ProveedorID, AV64SolicitudServicioOrigenPago, AV64SolicitudServicioOrigenPago, AV74NuevaDesde, AV47SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A600SolicitudesSubTipo = P00IW4_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00IW4_n600SolicitudesSubTipo[0];
            A127SolicitudesID = P00IW4_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = P00IW4_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00IW4_n438SolicitudServicioOrigenPago[0];
            A184SolicitudesFechaInstalacion = P00IW4_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00IW4_A133ProveedorID[0];
            A131EstadosSolId = P00IW4_A131EstadosSolId[0];
            A130EstadosSolTipo = P00IW4_A130EstadosSolTipo[0];
            A282ProveedorNombre = P00IW4_A282ProveedorNombre[0];
            A171SolicitudesNombre = P00IW4_A171SolicitudesNombre[0];
            A527SolicitudServicioComProv = P00IW4_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00IW4_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00IW4_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00IW4_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P00IW4_A132EstadosSolNombre[0];
            A796SolicitudesComisionMetodoPago = P00IW4_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00IW4_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00IW4_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00IW4_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00IW4_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00IW4_A864SolicitudesCostoXZona[0];
            A282ProveedorNombre = P00IW4_A282ProveedorNombre[0];
            A132EstadosSolNombre = P00IW4_A132EstadosSolNombre[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
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
               AV47SolicitudesID = A127SolicitudesID;
               AV27Fecha = A184SolicitudesFechaInstalacion;
               AV73Obra = A282ProveedorNombre;
               AV37NombreCliente = A171SolicitudesNombre;
               AV33Importe = A211SolicitudServicioPFinal;
               AV15Comision = A527SolicitudServicioComProv;
               AV16ComisionALM = A530SolicitudServicioComALM;
               AV24Estado = A132EstadosSolNombre;
               AV52TotalComisiones = (decimal)(AV52TotalComisiones+AV15Comision);
               AV53TotalComisionProveedor = (decimal)(AV53TotalComisionProveedor+AV33Importe);
               AV10Cantidad = (long)(AV10Cantidad+1);
               AV60CellRow = (short)(AV60CellRow+1);
               AV61ColumnIndex = 1;
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.localUtil.DToC( AV27Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(AV47SolicitudesID), 18, 0));
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV73Obra);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV37NombreCliente);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Venta Total", "");
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV16ComisionALM);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV33Importe);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Obra", "");
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = "-";
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = AV24Estado;
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               /* Using cursor P00IW6 */
               pr_default.execute(3, new Object[] {AV30Hasta, A127SolicitudesID, AV19Desde});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A461CentroCostosId = P00IW6_A461CentroCostosId[0];
                  A892CentroCostosDetallesFecha = P00IW6_A892CentroCostosDetallesFecha[0];
                  A462CentroCostosRef = P00IW6_A462CentroCostosRef[0];
                  A890CCDetallesProfId = P00IW6_A890CCDetallesProfId[0];
                  A459ListaCostosId = P00IW6_A459ListaCostosId[0];
                  n459ListaCostosId = P00IW6_n459ListaCostosId[0];
                  A468CentroCostosDetallesValor = P00IW6_A468CentroCostosDetallesValor[0];
                  A473CentroCostosDetallesNombre = P00IW6_A473CentroCostosDetallesNombre[0];
                  A888CentroCostosDetallesSolId = P00IW6_A888CentroCostosDetallesSolId[0];
                  A40000ProfesionalesNombreCompleto = P00IW6_A40000ProfesionalesNombreCompleto[0];
                  n40000ProfesionalesNombreCompleto = P00IW6_n40000ProfesionalesNombreCompleto[0];
                  A466CentroCostosDetallesId = P00IW6_A466CentroCostosDetallesId[0];
                  A462CentroCostosRef = P00IW6_A462CentroCostosRef[0];
                  A40000ProfesionalesNombreCompleto = P00IW6_A40000ProfesionalesNombreCompleto[0];
                  n40000ProfesionalesNombreCompleto = P00IW6_n40000ProfesionalesNombreCompleto[0];
                  AV67CCDetallesProfId = A890CCDetallesProfId;
                  if ( ( A459ListaCostosId == 5 ) || ( A459ListaCostosId == 6 ) )
                  {
                     AV68CentroCostosDetallesValor = A468CentroCostosDetallesValor;
                  }
                  else
                  {
                     AV68CentroCostosDetallesValor = (decimal)(A468CentroCostosDetallesValor*(-1));
                  }
                  AV72CentroCostosDetallesValorP = A468CentroCostosDetallesValor;
                  AV66CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
                  AV69ProfesionalesNombre = A40000ProfesionalesNombreCompleto;
                  if ( StringUtil.Contains( AV69ProfesionalesNombre, context.GetMessage( "NULL", "")) )
                  {
                     AV69ProfesionalesNombre = "-";
                     AV82Comisioncostosotros = (decimal)(AV82Comisioncostosotros+A468CentroCostosDetallesValor);
                  }
                  else
                  {
                     AV83Comisionprofesionales = (decimal)(AV83Comisionprofesionales+A468CentroCostosDetallesValor);
                  }
                  AV70SubsolicitudId = A888CentroCostosDetallesSolId;
                  if ( AV70SubsolicitudId == 0 )
                  {
                     AV71SubsolicitudIdTexto = "-";
                  }
                  else
                  {
                     AV71SubsolicitudIdTexto = StringUtil.Trim( StringUtil.Str( (decimal)(AV70SubsolicitudId), 18, 0));
                  }
                  AV60CellRow = (short)(AV60CellRow+1);
                  AV61ColumnIndex = 1;
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.localUtil.DToC( AV27Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV71SubsolicitudIdTexto);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV73Obra);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV37NombreCliente);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV66CentroCostosDetallesNombre);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV68CentroCostosDetallesValor);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV72CentroCostosDetallesValorP);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Costo", "");
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Trim( AV69ProfesionalesNombre);
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = AV24Estado;
                  AV61ColumnIndex = (short)(AV61ColumnIndex+1);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV60CellRow = (short)(AV60CellRow+1);
         AV25ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV25ExcelDocument.Close();
         CallWebObject(formatLink(AV29FileName) );
         context.wjLocDisableFrm = 0;
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV25ExcelDocument.ErrCode != 0 )
         {
            AV29FileName = "";
            AV23ErrorMessage = AV25ExcelDocument.ErrDescription;
            AV32HttpResponse.AddString(AV23ErrorMessage);
            context.StatusMessage( AV23ErrorMessage );
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'COLUMNTITLE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV64SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
         {
            AV65OrigenPago = context.GetMessage( "Cobro Directo", "");
         }
         else if ( StringUtil.StrCmp(AV64SolicitudServicioOrigenPago, context.GetMessage( "T", "")) == 0 )
         {
            AV65OrigenPago = context.GetMessage( "Cobro Prepago Comercio", "");
         }
         else if ( StringUtil.StrCmp(AV64SolicitudServicioOrigenPago, context.GetMessage( "O", "")) == 0 )
         {
            AV65OrigenPago = context.GetMessage( "Cobro Prepago Almango", "");
         }
         else
         {
            AV65OrigenPago = context.GetMessage( "Todos los Cobros", "");
         }
         AV60CellRow = 1;
         AV61ColumnIndex = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha del Reporte: ", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV60CellRow = (short)(AV60CellRow+1);
         AV61ColumnIndex = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Reporte Comisiones del Comercio - ", "")+StringUtil.Trim( AV65OrigenPago);
         AV60CellRow = (short)(AV60CellRow+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Rango de Fechas:", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV19Desde ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = "-";
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV30Hasta ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV60CellRow = (short)(AV60CellRow+1);
         AV61ColumnIndex = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "REMITENTE DE SOLICITUD DE SERVICIOS: ", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = AV45ProveedorNombre;
         AV60CellRow = (short)(AV60CellRow+1);
         AV61ColumnIndex = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Solicitud", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Comercio", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Cliente", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Concepto", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Almango", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Importe", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Tipo", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Profesional", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Estado", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
      }

      protected void S131( )
      {
         /* 'ACTUALIZARFECHAS' Routine */
         returnInSub = false;
         /* Using cursor P00IW7 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A461CentroCostosId = P00IW7_A461CentroCostosId[0];
            /* Using cursor P00IW8 */
            pr_default.execute(5, new Object[] {AV76CentroCostosRef});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A127SolicitudesID = P00IW8_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P00IW8_A184SolicitudesFechaInstalacion[0];
               AV77SolicitudesIDCollection.Add(AV76CentroCostosRef, 0);
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) <= DateTimeUtil.ResetTime ( AV74NuevaDesde ) )
               {
                  AV74NuevaDesde = A184SolicitudesFechaInstalacion;
               }
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( AV75NuevaHasta ) )
               {
                  AV75NuevaHasta = A184SolicitudesFechaInstalacion;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00IW9 */
         pr_default.execute(6, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(6) != 101) && ( P00IW9_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00IW9_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00IW9_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00IW9_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IW9_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])-(P00IW9_A180SolicitudItemsComision[0]*P00IW9_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00IW9_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IW9_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])+(P00IW9_A180SolicitudItemsComision[0]*P00IW9_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00IW9_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IW9_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])-((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])*(P00IW9_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00IW9_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IW9_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])+((P00IW9_A176SolicitudesItemsPrecioFinal[0]*P00IW9_A177SolicitudesItemsCantidad[0])*(P00IW9_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(6);
         }
         pr_default.close(6);
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
         AV29FileName = "";
         AV25ExcelDocument = new ExcelDocumentI();
         AV74NuevaDesde = DateTime.MinValue;
         AV75NuevaHasta = DateTime.MinValue;
         P00IW2_A461CentroCostosId = new long[1] ;
         P00IW2_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IW2_A462CentroCostosRef = new long[1] ;
         P00IW2_A466CentroCostosDetallesId = new long[1] ;
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         P00IW3_A133ProveedorID = new long[1] ;
         AV45ProveedorNombre = "";
         AV77SolicitudesIDCollection = new GxSimpleCollection<long>();
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         P00IW4_A600SolicitudesSubTipo = new string[] {""} ;
         P00IW4_n600SolicitudesSubTipo = new bool[] {false} ;
         P00IW4_A127SolicitudesID = new long[1] ;
         P00IW4_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00IW4_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00IW4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IW4_A133ProveedorID = new long[1] ;
         P00IW4_A131EstadosSolId = new int[1] ;
         P00IW4_A130EstadosSolTipo = new string[] {""} ;
         P00IW4_A282ProveedorNombre = new string[] {""} ;
         P00IW4_A171SolicitudesNombre = new string[] {""} ;
         P00IW4_A527SolicitudServicioComProv = new decimal[1] ;
         P00IW4_n527SolicitudServicioComProv = new bool[] {false} ;
         P00IW4_A530SolicitudServicioComALM = new decimal[1] ;
         P00IW4_n530SolicitudServicioComALM = new bool[] {false} ;
         P00IW4_A132EstadosSolNombre = new string[] {""} ;
         P00IW4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00IW4_A212SolicitudesCotizacion = new decimal[1] ;
         P00IW4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00IW4_A897SolicitudesDescuento = new decimal[1] ;
         P00IW4_n897SolicitudesDescuento = new bool[] {false} ;
         P00IW4_A864SolicitudesCostoXZona = new decimal[1] ;
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV27Fecha = DateTime.MinValue;
         AV73Obra = "";
         AV37NombreCliente = "";
         AV24Estado = "";
         P00IW6_A461CentroCostosId = new long[1] ;
         P00IW6_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IW6_A462CentroCostosRef = new long[1] ;
         P00IW6_A890CCDetallesProfId = new string[] {""} ;
         P00IW6_A459ListaCostosId = new long[1] ;
         P00IW6_n459ListaCostosId = new bool[] {false} ;
         P00IW6_A468CentroCostosDetallesValor = new decimal[1] ;
         P00IW6_A473CentroCostosDetallesNombre = new string[] {""} ;
         P00IW6_A888CentroCostosDetallesSolId = new long[1] ;
         P00IW6_A40000ProfesionalesNombreCompleto = new string[] {""} ;
         P00IW6_n40000ProfesionalesNombreCompleto = new bool[] {false} ;
         P00IW6_A466CentroCostosDetallesId = new long[1] ;
         A890CCDetallesProfId = "";
         A473CentroCostosDetallesNombre = "";
         A40000ProfesionalesNombreCompleto = "";
         AV67CCDetallesProfId = "";
         AV66CentroCostosDetallesNombre = "";
         AV69ProfesionalesNombre = "";
         AV71SubsolicitudIdTexto = "";
         AV23ErrorMessage = "";
         AV32HttpResponse = new GxHttpResponse( context);
         AV65OrigenPago = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00IW7_A461CentroCostosId = new long[1] ;
         P00IW8_A127SolicitudesID = new long[1] ;
         P00IW8_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IW9_A127SolicitudesID = new long[1] ;
         P00IW9_A134SolicitudesItemsID = new short[1] ;
         P00IW9_A180SolicitudItemsComision = new decimal[1] ;
         P00IW9_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00IW9_A178SolicitudItemsSR = new string[] {""} ;
         P00IW9_A177SolicitudesItemsCantidad = new short[1] ;
         P00IW9_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00IW9_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reporteobrasdetalladoxls__default(),
            new Object[][] {
                new Object[] {
               P00IW2_A461CentroCostosId, P00IW2_A892CentroCostosDetallesFecha, P00IW2_A462CentroCostosRef, P00IW2_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IW3_A133ProveedorID
               }
               , new Object[] {
               P00IW4_A600SolicitudesSubTipo, P00IW4_n600SolicitudesSubTipo, P00IW4_A127SolicitudesID, P00IW4_A438SolicitudServicioOrigenPago, P00IW4_n438SolicitudServicioOrigenPago, P00IW4_A184SolicitudesFechaInstalacion, P00IW4_A133ProveedorID, P00IW4_A131EstadosSolId, P00IW4_A130EstadosSolTipo, P00IW4_A282ProveedorNombre,
               P00IW4_A171SolicitudesNombre, P00IW4_A527SolicitudServicioComProv, P00IW4_n527SolicitudServicioComProv, P00IW4_A530SolicitudServicioComALM, P00IW4_n530SolicitudServicioComALM, P00IW4_A132EstadosSolNombre, P00IW4_A796SolicitudesComisionMetodoPago, P00IW4_A212SolicitudesCotizacion, P00IW4_A1016SolicitudesDescuentoCupon, P00IW4_A897SolicitudesDescuento,
               P00IW4_n897SolicitudesDescuento, P00IW4_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00IW6_A461CentroCostosId, P00IW6_A892CentroCostosDetallesFecha, P00IW6_A462CentroCostosRef, P00IW6_A890CCDetallesProfId, P00IW6_A459ListaCostosId, P00IW6_n459ListaCostosId, P00IW6_A468CentroCostosDetallesValor, P00IW6_A473CentroCostosDetallesNombre, P00IW6_A888CentroCostosDetallesSolId, P00IW6_A40000ProfesionalesNombreCompleto,
               P00IW6_n40000ProfesionalesNombreCompleto, P00IW6_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IW7_A461CentroCostosId
               }
               , new Object[] {
               P00IW8_A127SolicitudesID, P00IW8_A184SolicitudesFechaInstalacion
               }
               , new Object[] {
               P00IW9_A127SolicitudesID, P00IW9_A134SolicitudesItemsID, P00IW9_A180SolicitudItemsComision, P00IW9_A179SolicitudItemsComisionTipo, P00IW9_A178SolicitudItemsSR, P00IW9_A177SolicitudesItemsCantidad, P00IW9_A176SolicitudesItemsPrecioFinal, P00IW9_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11Clasificaciones ;
      private short AV46Random ;
      private short AV60CellRow ;
      private short AV61ColumnIndex ;
      private short AV63FirstColumn ;
      private int A131EstadosSolId ;
      private long AV43ProveedoresTipoId ;
      private long AV44ProveedorID ;
      private long AV47SolicitudesID ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A466CentroCostosDetallesId ;
      private long AV76CentroCostosRef ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private long AV10Cantidad ;
      private long A459ListaCostosId ;
      private long A888CentroCostosDetallesSolId ;
      private long AV70SubsolicitudId ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV33Importe ;
      private decimal AV15Comision ;
      private decimal AV16ComisionALM ;
      private decimal AV52TotalComisiones ;
      private decimal AV53TotalComisionProveedor ;
      private decimal A468CentroCostosDetallesValor ;
      private decimal AV68CentroCostosDetallesValor ;
      private decimal AV72CentroCostosDetallesValorP ;
      private decimal AV82Comisioncostosotros ;
      private decimal AV83Comisionprofesionales ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV64SolicitudServicioOrigenPago ;
      private string AV45ProveedorNombre ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV37NombreCliente ;
      private string AV24Estado ;
      private string A890CCDetallesProfId ;
      private string A473CentroCostosDetallesNombre ;
      private string AV67CCDetallesProfId ;
      private string AV66CentroCostosDetallesNombre ;
      private string AV69ProfesionalesNombre ;
      private string AV65OrigenPago ;
      private DateTime GXt_dtime1 ;
      private DateTime AV19Desde ;
      private DateTime AV30Hasta ;
      private DateTime AV74NuevaDesde ;
      private DateTime AV75NuevaHasta ;
      private DateTime A892CentroCostosDetallesFecha ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV27Fecha ;
      private bool AV22DSPALmango ;
      private bool returnInSub ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private bool n459ListaCostosId ;
      private bool n40000ProfesionalesNombreCompleto ;
      private string AV29FileName ;
      private string AV73Obra ;
      private string A40000ProfesionalesNombreCompleto ;
      private string AV71SubsolicitudIdTexto ;
      private string AV23ErrorMessage ;
      private GxHttpResponse AV32HttpResponse ;
      private ExcelDocumentI AV25ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00IW2_A461CentroCostosId ;
      private DateTime[] P00IW2_A892CentroCostosDetallesFecha ;
      private long[] P00IW2_A462CentroCostosRef ;
      private long[] P00IW2_A466CentroCostosDetallesId ;
      private long[] P00IW3_A133ProveedorID ;
      private GxSimpleCollection<long> AV77SolicitudesIDCollection ;
      private string[] P00IW4_A600SolicitudesSubTipo ;
      private bool[] P00IW4_n600SolicitudesSubTipo ;
      private long[] P00IW4_A127SolicitudesID ;
      private string[] P00IW4_A438SolicitudServicioOrigenPago ;
      private bool[] P00IW4_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00IW4_A184SolicitudesFechaInstalacion ;
      private long[] P00IW4_A133ProveedorID ;
      private int[] P00IW4_A131EstadosSolId ;
      private string[] P00IW4_A130EstadosSolTipo ;
      private string[] P00IW4_A282ProveedorNombre ;
      private string[] P00IW4_A171SolicitudesNombre ;
      private decimal[] P00IW4_A527SolicitudServicioComProv ;
      private bool[] P00IW4_n527SolicitudServicioComProv ;
      private decimal[] P00IW4_A530SolicitudServicioComALM ;
      private bool[] P00IW4_n530SolicitudServicioComALM ;
      private string[] P00IW4_A132EstadosSolNombre ;
      private decimal[] P00IW4_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00IW4_A212SolicitudesCotizacion ;
      private decimal[] P00IW4_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00IW4_A897SolicitudesDescuento ;
      private bool[] P00IW4_n897SolicitudesDescuento ;
      private decimal[] P00IW4_A864SolicitudesCostoXZona ;
      private long[] P00IW6_A461CentroCostosId ;
      private DateTime[] P00IW6_A892CentroCostosDetallesFecha ;
      private long[] P00IW6_A462CentroCostosRef ;
      private string[] P00IW6_A890CCDetallesProfId ;
      private long[] P00IW6_A459ListaCostosId ;
      private bool[] P00IW6_n459ListaCostosId ;
      private decimal[] P00IW6_A468CentroCostosDetallesValor ;
      private string[] P00IW6_A473CentroCostosDetallesNombre ;
      private long[] P00IW6_A888CentroCostosDetallesSolId ;
      private string[] P00IW6_A40000ProfesionalesNombreCompleto ;
      private bool[] P00IW6_n40000ProfesionalesNombreCompleto ;
      private long[] P00IW6_A466CentroCostosDetallesId ;
      private long[] P00IW7_A461CentroCostosId ;
      private long[] P00IW8_A127SolicitudesID ;
      private DateTime[] P00IW8_A184SolicitudesFechaInstalacion ;
      private long[] P00IW9_A127SolicitudesID ;
      private short[] P00IW9_A134SolicitudesItemsID ;
      private decimal[] P00IW9_A180SolicitudItemsComision ;
      private string[] P00IW9_A179SolicitudItemsComisionTipo ;
      private string[] P00IW9_A178SolicitudItemsSR ;
      private short[] P00IW9_A177SolicitudesItemsCantidad ;
      private decimal[] P00IW9_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00IW9_n176SolicitudesItemsPrecioFinal ;
   }

   public class reporteobrasdetalladoxls__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00IW4( IGxContext context ,
                                             long A127SolicitudesID ,
                                             GxSimpleCollection<long> AV77SolicitudesIDCollection ,
                                             long AV47SolicitudesID ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             short AV11Clasificaciones ,
                                             long A133ProveedorID ,
                                             long AV44ProveedorID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV64SolicitudServicioOrigenPago ,
                                             string A600SolicitudesSubTipo ,
                                             DateTime AV75NuevaHasta ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV74NuevaDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T2.[ProveedorNombre], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV75NuevaHasta)");
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV11Clasificaciones or @AV11Clasificaciones = 0)");
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV44ProveedorID or @AV44ProveedorID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV64SolicitudServicioOrigenPago or @AV64SolicitudServicioOrigenPago = '')");
         AddWhere(sWhereString, "(T1.[SolicitudesSubTipo] = 'A')");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV74NuevaDesde)");
         if ( ! (0==AV47SolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] = @AV47SolicitudesID)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( (0==AV47SolicitudesID) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77SolicitudesIDCollection, "T1.[SolicitudesID] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC, T1.[SolicitudesID] DESC";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00IW4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00IW2;
          prmP00IW2 = new Object[] {
          new ParDef("@AV19Desde",GXType.Date,8,0) ,
          new ParDef("@AV30Hasta",GXType.Date,8,0)
          };
          Object[] prmP00IW3;
          prmP00IW3 = new Object[] {
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00IW6;
          prmP00IW6 = new Object[] {
          new ParDef("@AV30Hasta",GXType.Date,8,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV19Desde",GXType.Date,8,0)
          };
          Object[] prmP00IW7;
          prmP00IW7 = new Object[] {
          };
          Object[] prmP00IW8;
          prmP00IW8 = new Object[] {
          new ParDef("@AV76CentroCostosRef",GXType.Decimal,18,0)
          };
          Object[] prmP00IW9;
          prmP00IW9 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IW4;
          prmP00IW4 = new Object[] {
          new ParDef("@AV75NuevaHasta",GXType.Date,8,0) ,
          new ParDef("@AV11Clasificaciones",GXType.Int16,4,0) ,
          new ParDef("@AV11Clasificaciones",GXType.Int16,4,0) ,
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV64SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV64SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV74NuevaDesde",GXType.Date,8,0) ,
          new ParDef("@AV47SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IW2", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE T1.[CentroCostosDetallesFecha] >= @AV19Desde and T1.[CentroCostosDetallesFecha] <= @AV30Hasta ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IW3", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV44ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IW4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IW6", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CCDetallesProfId], T1.[ListaCostosId], T1.[CentroCostosDetallesValor], T1.[CentroCostosDetallesNombre], T1.[CentroCostosDetallesSolId], COALESCE( T3.[ProfesionalesNombreCompleto], '-') AS ProfesionalesNombreCompleto, T1.[CentroCostosDetallesId] FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT ( RTRIM(LTRIM([ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM([ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM([ProfesionalesSegundoNombre]))) AS ProfesionalesNombreCompleto, [ProfesionalesId] FROM [Profesionales] ) T3 ON T3.[ProfesionalesId] = T1.[CCDetallesProfId]) WHERE (T1.[CentroCostosDetallesFecha] <= @AV30Hasta) AND (T2.[CentroCostosRef] = @SolicitudesID) AND (T1.[CentroCostosDetallesFecha] >= @AV19Desde) ORDER BY T1.[CentroCostosDetallesFecha] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00IW7", "SELECT [CentroCostosId] FROM [CentroCostos] ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IW8", "SELECT [SolicitudesID], [SolicitudesFechaInstalacion] FROM [Solicitudes] WHERE [SolicitudesID] = @AV76CentroCostosRef ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IW9", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IW9,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 80);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 80);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 6 :
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
