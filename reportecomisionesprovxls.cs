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
   public class reportecomisionesprovxls : GXProcedure
   {
      public reportecomisionesprovxls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportecomisionesprovxls( IGxContext context )
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
                           bool aP6_DSPALmango )
      {
         this.AV43ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV44ProveedorID = aP1_ProveedorID;
         this.AV19Desde = aP2_Desde;
         this.AV30Hasta = aP3_Hasta;
         this.AV11Clasificaciones = aP4_Clasificaciones;
         this.AV64SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV22DSPALmango = aP6_DSPALmango;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 short aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 bool aP6_DSPALmango )
      {
         this.AV43ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV44ProveedorID = aP1_ProveedorID;
         this.AV19Desde = aP2_Desde;
         this.AV30Hasta = aP3_Hasta;
         this.AV11Clasificaciones = aP4_Clasificaciones;
         this.AV64SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV22DSPALmango = aP6_DSPALmango;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV46Random = (short)(NumberUtil.Random( )*10000);
         AV29FileName = "ReporteComisionesGenerales-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV46Random), 4, 0)) + ".xlsx";
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
         /* Using cursor P008G2 */
         pr_default.execute(0, new Object[] {AV44ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P008G2_A133ProveedorID[0];
            AV45ProveedorNombre = StringUtil.Upper( AV45ProveedorNombre);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44ProveedorID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A130EstadosSolTipo ,
                                              A131EstadosSolId ,
                                              AV11Clasificaciones ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV19Desde ,
                                              AV30Hasta ,
                                              A127SolicitudesID ,
                                              AV47SolicitudesID ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV64SolicitudServicioOrigenPago } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P008G3 */
         pr_default.execute(1, new Object[] {AV11Clasificaciones, AV11Clasificaciones, AV19Desde, AV30Hasta, AV47SolicitudesID, AV47SolicitudesID, AV64SolicitudServicioOrigenPago, AV64SolicitudServicioOrigenPago, AV44ProveedorID, AV44ProveedorID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A438SolicitudServicioOrigenPago = P008G3_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P008G3_n438SolicitudServicioOrigenPago[0];
            A127SolicitudesID = P008G3_A127SolicitudesID[0];
            A184SolicitudesFechaInstalacion = P008G3_A184SolicitudesFechaInstalacion[0];
            A919STComerciosID = P008G3_A919STComerciosID[0];
            n919STComerciosID = P008G3_n919STComerciosID[0];
            A133ProveedorID = P008G3_A133ProveedorID[0];
            A131EstadosSolId = P008G3_A131EstadosSolId[0];
            A130EstadosSolTipo = P008G3_A130EstadosSolTipo[0];
            A171SolicitudesNombre = P008G3_A171SolicitudesNombre[0];
            A527SolicitudServicioComProv = P008G3_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P008G3_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P008G3_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P008G3_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P008G3_A132EstadosSolNombre[0];
            A182SolicitudesFechaAlta = P008G3_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P008G3_n182SolicitudesFechaAlta[0];
            A796SolicitudesComisionMetodoPago = P008G3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P008G3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P008G3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P008G3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P008G3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P008G3_A864SolicitudesCostoXZona[0];
            A132EstadosSolNombre = P008G3_A132EstadosSolNombre[0];
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
               AV37NombreCliente = A171SolicitudesNombre;
               AV33Importe = A211SolicitudServicioPFinal;
               AV15Comision = A527SolicitudServicioComProv;
               AV16ComisionALM = A530SolicitudServicioComALM;
               AV24Estado = A132EstadosSolNombre;
               AV52TotalComisiones = (decimal)(AV52TotalComisiones+AV15Comision);
               AV53TotalComisionProveedor = (decimal)(AV53TotalComisionProveedor+AV33Importe);
               AV10Cantidad = (long)(AV10Cantidad+1);
               if ( AV22DSPALmango )
               {
                  AV51TotalAlmango = (decimal)(AV51TotalAlmango+AV16ComisionALM);
               }
               else
               {
                  AV51TotalAlmango = 0;
               }
               AV60CellRow = (short)(AV60CellRow+1);
               AV61ColumnIndex = 1;
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.localUtil.DToC( AV27Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = StringUtil.Str( (decimal)(AV47SolicitudesID), 18, 0);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = AV37NombreCliente;
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV16ComisionALM);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV15Comision);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Number = (double)(AV33Importe);
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
               AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = AV24Estado;
               AV61ColumnIndex = (short)(AV61ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV60CellRow = (short)(AV60CellRow+1);
         AV61ColumnIndex = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "ComisionesALM", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Comisiones", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Total", "");
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
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Cliente", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Almango", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Comisión", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Importe", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Bold = 1;
         AV25ExcelDocument.get_Cells(AV60CellRow, AV63FirstColumn+AV61ColumnIndex, 1, 1).Text = context.GetMessage( "Estado", "");
         AV61ColumnIndex = (short)(AV61ColumnIndex+1);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P008G4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P008G4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008G4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008G4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008G4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008G4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])-(P008G4_A180SolicitudItemsComision[0]*P008G4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008G4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008G4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])+(P008G4_A180SolicitudItemsComision[0]*P008G4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008G4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008G4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])-((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])*(P008G4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008G4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008G4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])+((P008G4_A176SolicitudesItemsPrecioFinal[0]*P008G4_A177SolicitudesItemsCantidad[0])*(P008G4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         P008G2_A133ProveedorID = new long[1] ;
         AV45ProveedorNombre = "";
         A130EstadosSolTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A438SolicitudServicioOrigenPago = "";
         P008G3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008G3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008G3_A127SolicitudesID = new long[1] ;
         P008G3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008G3_A919STComerciosID = new long[1] ;
         P008G3_n919STComerciosID = new bool[] {false} ;
         P008G3_A133ProveedorID = new long[1] ;
         P008G3_A131EstadosSolId = new int[1] ;
         P008G3_A130EstadosSolTipo = new string[] {""} ;
         P008G3_A171SolicitudesNombre = new string[] {""} ;
         P008G3_A527SolicitudServicioComProv = new decimal[1] ;
         P008G3_n527SolicitudServicioComProv = new bool[] {false} ;
         P008G3_A530SolicitudServicioComALM = new decimal[1] ;
         P008G3_n530SolicitudServicioComALM = new bool[] {false} ;
         P008G3_A132EstadosSolNombre = new string[] {""} ;
         P008G3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P008G3_n182SolicitudesFechaAlta = new bool[] {false} ;
         P008G3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008G3_A212SolicitudesCotizacion = new decimal[1] ;
         P008G3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008G3_A897SolicitudesDescuento = new decimal[1] ;
         P008G3_n897SolicitudesDescuento = new bool[] {false} ;
         P008G3_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         AV27Fecha = DateTime.MinValue;
         AV37NombreCliente = "";
         AV24Estado = "";
         AV23ErrorMessage = "";
         AV32HttpResponse = new GxHttpResponse( context);
         AV65OrigenPago = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P008G4_A127SolicitudesID = new long[1] ;
         P008G4_A134SolicitudesItemsID = new short[1] ;
         P008G4_A180SolicitudItemsComision = new decimal[1] ;
         P008G4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008G4_A178SolicitudItemsSR = new string[] {""} ;
         P008G4_A177SolicitudesItemsCantidad = new short[1] ;
         P008G4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008G4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportecomisionesprovxls__default(),
            new Object[][] {
                new Object[] {
               P008G2_A133ProveedorID
               }
               , new Object[] {
               P008G3_A438SolicitudServicioOrigenPago, P008G3_n438SolicitudServicioOrigenPago, P008G3_A127SolicitudesID, P008G3_A184SolicitudesFechaInstalacion, P008G3_A919STComerciosID, P008G3_n919STComerciosID, P008G3_A133ProveedorID, P008G3_A131EstadosSolId, P008G3_A130EstadosSolTipo, P008G3_A171SolicitudesNombre,
               P008G3_A527SolicitudServicioComProv, P008G3_n527SolicitudServicioComProv, P008G3_A530SolicitudServicioComALM, P008G3_n530SolicitudServicioComALM, P008G3_A132EstadosSolNombre, P008G3_A182SolicitudesFechaAlta, P008G3_n182SolicitudesFechaAlta, P008G3_A796SolicitudesComisionMetodoPago, P008G3_A212SolicitudesCotizacion, P008G3_A1016SolicitudesDescuentoCupon,
               P008G3_A897SolicitudesDescuento, P008G3_n897SolicitudesDescuento, P008G3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008G4_A127SolicitudesID, P008G4_A134SolicitudesItemsID, P008G4_A180SolicitudItemsComision, P008G4_A179SolicitudItemsComisionTipo, P008G4_A178SolicitudItemsSR, P008G4_A177SolicitudesItemsCantidad, P008G4_A176SolicitudesItemsPrecioFinal, P008G4_n176SolicitudesItemsPrecioFinal
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
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A127SolicitudesID ;
      private long AV47SolicitudesID ;
      private long AV10Cantidad ;
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
      private decimal AV51TotalAlmango ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV64SolicitudServicioOrigenPago ;
      private string AV45ProveedorNombre ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV37NombreCliente ;
      private string AV24Estado ;
      private string AV65OrigenPago ;
      private DateTime GXt_dtime1 ;
      private DateTime AV19Desde ;
      private DateTime AV30Hasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV27Fecha ;
      private bool AV22DSPALmango ;
      private bool returnInSub ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n919STComerciosID ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private string AV29FileName ;
      private string AV23ErrorMessage ;
      private GxHttpResponse AV32HttpResponse ;
      private ExcelDocumentI AV25ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008G2_A133ProveedorID ;
      private string[] P008G3_A438SolicitudServicioOrigenPago ;
      private bool[] P008G3_n438SolicitudServicioOrigenPago ;
      private long[] P008G3_A127SolicitudesID ;
      private DateTime[] P008G3_A184SolicitudesFechaInstalacion ;
      private long[] P008G3_A919STComerciosID ;
      private bool[] P008G3_n919STComerciosID ;
      private long[] P008G3_A133ProveedorID ;
      private int[] P008G3_A131EstadosSolId ;
      private string[] P008G3_A130EstadosSolTipo ;
      private string[] P008G3_A171SolicitudesNombre ;
      private decimal[] P008G3_A527SolicitudServicioComProv ;
      private bool[] P008G3_n527SolicitudServicioComProv ;
      private decimal[] P008G3_A530SolicitudServicioComALM ;
      private bool[] P008G3_n530SolicitudServicioComALM ;
      private string[] P008G3_A132EstadosSolNombre ;
      private DateTime[] P008G3_A182SolicitudesFechaAlta ;
      private bool[] P008G3_n182SolicitudesFechaAlta ;
      private decimal[] P008G3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008G3_A212SolicitudesCotizacion ;
      private decimal[] P008G3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008G3_A897SolicitudesDescuento ;
      private bool[] P008G3_n897SolicitudesDescuento ;
      private decimal[] P008G3_A864SolicitudesCostoXZona ;
      private long[] P008G4_A127SolicitudesID ;
      private short[] P008G4_A134SolicitudesItemsID ;
      private decimal[] P008G4_A180SolicitudItemsComision ;
      private string[] P008G4_A179SolicitudItemsComisionTipo ;
      private string[] P008G4_A178SolicitudItemsSR ;
      private short[] P008G4_A177SolicitudesItemsCantidad ;
      private decimal[] P008G4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008G4_n176SolicitudesItemsPrecioFinal ;
   }

   public class reportecomisionesprovxls__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008G3( IGxContext context ,
                                             long AV44ProveedorID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             short AV11Clasificaciones ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV19Desde ,
                                             DateTime AV30Hasta ,
                                             long A127SolicitudesID ,
                                             long AV47SolicitudesID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV64SolicitudServicioOrigenPago )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudServicioOrigenPago], T1.[SolicitudesID], T1.[SolicitudesFechaInstalacion], T1.[STComerciosID], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesFechaAlta], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV11Clasificaciones or @AV11Clasificaciones = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV19Desde and T1.[SolicitudesFechaInstalacion] <= @AV30Hasta)");
         AddWhere(sWhereString, "(T1.[SolicitudesID] = @AV47SolicitudesID or @AV47SolicitudesID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV64SolicitudServicioOrigenPago or @AV64SolicitudServicioOrigenPago = '')");
         if ( AV44ProveedorID != 0 )
         {
            AddWhere(sWhereString, "(( T1.[ProveedorID] = @AV44ProveedorID or T1.[STComerciosID] = @AV44ProveedorID))");
         }
         else
         {
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
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
               case 1 :
                     return conditional_P008G3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP008G2;
          prmP008G2 = new Object[] {
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP008G4;
          prmP008G4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP008G3;
          prmP008G3 = new Object[] {
          new ParDef("@AV11Clasificaciones",GXType.Int16,4,0) ,
          new ParDef("@AV11Clasificaciones",GXType.Int16,4,0) ,
          new ParDef("@AV19Desde",GXType.Date,8,0) ,
          new ParDef("@AV30Hasta",GXType.Date,8,0) ,
          new ParDef("@AV47SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV47SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV64SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV64SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV44ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008G2", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV44ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008G4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G4,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 80);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                ((bool[]) buf[21])[0] = rslt.wasNull(16);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(17);
                return;
             case 2 :
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
