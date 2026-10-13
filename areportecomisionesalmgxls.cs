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
   public class areportecomisionesalmgxls : GXProcedure
   {
      public areportecomisionesalmgxls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areportecomisionesalmgxls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_ProveedorID ,
                           int aP1_EstadosGenericosID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           string aP4_FechaFiltro ,
                           string aP5_SolicitudServicioOrigenPago ,
                           ref string aP6_SecUserIDJson )
      {
         this.AV44ProveedorID = aP0_ProveedorID;
         this.AV70EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV19Desde = aP2_Desde;
         this.AV28Hasta = aP3_Hasta;
         this.AV71FechaFiltro = aP4_FechaFiltro;
         this.AV51SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV72SecUserIDJson = aP6_SecUserIDJson;
         initialize();
         ExecutePrivate();
         aP6_SecUserIDJson=this.AV72SecUserIDJson;
      }

      public string executeUdp( GxSimpleCollection<long> aP0_ProveedorID ,
                                int aP1_EstadosGenericosID ,
                                DateTime aP2_Desde ,
                                DateTime aP3_Hasta ,
                                string aP4_FechaFiltro ,
                                string aP5_SolicitudServicioOrigenPago )
      {
         execute(aP0_ProveedorID, aP1_EstadosGenericosID, aP2_Desde, aP3_Hasta, aP4_FechaFiltro, aP5_SolicitudServicioOrigenPago, ref aP6_SecUserIDJson);
         return AV72SecUserIDJson ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_ProveedorID ,
                                 int aP1_EstadosGenericosID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 string aP4_FechaFiltro ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 ref string aP6_SecUserIDJson )
      {
         this.AV44ProveedorID = aP0_ProveedorID;
         this.AV70EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV19Desde = aP2_Desde;
         this.AV28Hasta = aP3_Hasta;
         this.AV71FechaFiltro = aP4_FechaFiltro;
         this.AV51SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV72SecUserIDJson = aP6_SecUserIDJson;
         SubmitImpl();
         aP6_SecUserIDJson=this.AV72SecUserIDJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV66Random = (long)(NumberUtil.Random( )*10000);
         AV27FileName = "ReporteComisionALM-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV66Random), 10, 0)) + ".xlsx";
         AV8ExcelDocument.Open(AV27FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Clear();
         /* Execute user subroutine: 'COLUMNTITLE' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV46SecUserID.FromJSonString(AV72SecUserIDJson, null);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A133ProveedorID ,
                                              AV44ProveedorID ,
                                              A597SolicitudesUsrAlta ,
                                              AV46SecUserID ,
                                              AV71FechaFiltro ,
                                              AV46SecUserID.Count ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV19Desde ,
                                              AV28Hasta ,
                                              A182SolicitudesFechaAlta ,
                                              AV44ProveedorID.Count ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV51SolicitudServicioOrigenPago } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00FM2 */
         pr_default.execute(0, new Object[] {AV44ProveedorID.Count, AV51SolicitudServicioOrigenPago, AV51SolicitudServicioOrigenPago, AV19Desde, AV28Hasta, AV19Desde, AV28Hasta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P00FM2_A130EstadosSolTipo[0];
            A597SolicitudesUsrAlta = P00FM2_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = P00FM2_n597SolicitudesUsrAlta[0];
            A438SolicitudServicioOrigenPago = P00FM2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00FM2_n438SolicitudServicioOrigenPago[0];
            A182SolicitudesFechaAlta = P00FM2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P00FM2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P00FM2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00FM2_A133ProveedorID[0];
            A131EstadosSolId = P00FM2_A131EstadosSolId[0];
            A282ProveedorNombre = P00FM2_A282ProveedorNombre[0];
            A127SolicitudesID = P00FM2_A127SolicitudesID[0];
            A530SolicitudServicioComALM = P00FM2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00FM2_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P00FM2_A132EstadosSolNombre[0];
            A796SolicitudesComisionMetodoPago = P00FM2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00FM2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00FM2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00FM2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00FM2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00FM2_A864SolicitudesCostoXZona[0];
            A282ProveedorNombre = P00FM2_A282ProveedorNombre[0];
            A132EstadosSolNombre = P00FM2_A132EstadosSolNombre[0];
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
            if ( ( ( AV70EstadosGenericosID == 6 ) && ( ( A131EstadosSolId == 6 ) || ( A131EstadosSolId == 7 ) ) ) || ( ( AV70EstadosGenericosID == 0 ) && ( ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) ) || ( AV70EstadosGenericosID == A131EstadosSolId ) )
            {
               AV50SolicitudesUsrAlta = A597SolicitudesUsrAlta;
               /* Execute user subroutine: 'BUSCAR NOMBRE' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               AV64CellRow = (short)(AV64CellRow+1);
               AV68ColumnIndex = 1;
               GXt_dtime1 = DateTimeUtil.ResetTime( A184SolicitudesFechaInstalacion ) ;
               AV8ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Number = A133ProveedorID;
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = A282ProveedorNombre;
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0));
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Number = (double)(A530SolicitudServicioComALM);
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Number = (double)(A211SolicitudServicioPFinal);
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = A132EstadosSolNombre;
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = StringUtil.Trim( AV47SecUserName);
               AV68ColumnIndex = (short)(AV68ColumnIndex+1);
               AV55TotalAlmango = (decimal)(AV55TotalAlmango+A530SolicitudServicioComALM);
               AV53Total = (decimal)(AV53Total+A211SolicitudServicioPFinal);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV64CellRow = (short)(AV64CellRow+2);
         AV68ColumnIndex = 5;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Size = 11;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Total Comisión", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Size = 11;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Total Solicitudes", "");
         AV64CellRow = (short)(AV64CellRow+1);
         AV68ColumnIndex = 5;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Number = (double)(AV55TotalAlmango);
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Number = (double)(AV53Total);
         AV8ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Close();
         CallWebObject(formatLink(AV27FileName) );
         context.wjLocDisableFrm = 0;
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV8ExcelDocument.ErrCode != 0 )
         {
            AV27FileName = "";
            AV65ErrorMessage = AV8ExcelDocument.ErrDescription;
            AV67HttpResponse.AddString(AV65ErrorMessage);
            context.StatusMessage( AV65ErrorMessage );
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'COLUMNTITLE' Routine */
         returnInSub = false;
         AV64CellRow = 1;
         AV68ColumnIndex = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Comercio", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Nombre del comercio", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Solicitud", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Comision Almango", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Importe", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Estado", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells(AV64CellRow, AV69FirstColumn+AV68ColumnIndex, 1, 1).Text = context.GetMessage( "Solicitud Alta", "");
         AV68ColumnIndex = (short)(AV68ColumnIndex+1);
      }

      protected void S131( )
      {
         /* 'BUSCAR NOMBRE' Routine */
         returnInSub = false;
         /* Using cursor P00FM3 */
         pr_default.execute(1, new Object[] {AV50SolicitudesUsrAlta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18SecUserId = P00FM3_A18SecUserId[0];
            A26SecUserName = P00FM3_A26SecUserName[0];
            AV47SecUserName = A26SecUserName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00FM4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P00FM4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00FM4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00FM4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00FM4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00FM4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])-(P00FM4_A180SolicitudItemsComision[0]*P00FM4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00FM4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00FM4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])+(P00FM4_A180SolicitudItemsComision[0]*P00FM4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00FM4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00FM4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])-((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])*(P00FM4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00FM4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00FM4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])+((P00FM4_A176SolicitudesItemsPrecioFinal[0]*P00FM4_A177SolicitudesItemsCantidad[0])*(P00FM4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         AV27FileName = "";
         AV8ExcelDocument = new ExcelDocumentI();
         AV46SecUserID = new GxSimpleCollection<long>();
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A438SolicitudServicioOrigenPago = "";
         P00FM2_A130EstadosSolTipo = new string[] {""} ;
         P00FM2_A597SolicitudesUsrAlta = new long[1] ;
         P00FM2_n597SolicitudesUsrAlta = new bool[] {false} ;
         P00FM2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00FM2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00FM2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00FM2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00FM2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00FM2_A133ProveedorID = new long[1] ;
         P00FM2_A131EstadosSolId = new int[1] ;
         P00FM2_A282ProveedorNombre = new string[] {""} ;
         P00FM2_A127SolicitudesID = new long[1] ;
         P00FM2_A530SolicitudServicioComALM = new decimal[1] ;
         P00FM2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00FM2_A132EstadosSolNombre = new string[] {""} ;
         P00FM2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00FM2_A212SolicitudesCotizacion = new decimal[1] ;
         P00FM2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00FM2_A897SolicitudesDescuento = new decimal[1] ;
         P00FM2_n897SolicitudesDescuento = new bool[] {false} ;
         P00FM2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A282ProveedorNombre = "";
         A132EstadosSolNombre = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV47SecUserName = "";
         AV65ErrorMessage = "";
         AV67HttpResponse = new GxHttpResponse( context);
         P00FM3_A18SecUserId = new long[1] ;
         P00FM3_A26SecUserName = new string[] {""} ;
         A26SecUserName = "";
         P00FM4_A127SolicitudesID = new long[1] ;
         P00FM4_A134SolicitudesItemsID = new short[1] ;
         P00FM4_A180SolicitudItemsComision = new decimal[1] ;
         P00FM4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00FM4_A178SolicitudItemsSR = new string[] {""} ;
         P00FM4_A177SolicitudesItemsCantidad = new short[1] ;
         P00FM4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00FM4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areportecomisionesalmgxls__default(),
            new Object[][] {
                new Object[] {
               P00FM2_A130EstadosSolTipo, P00FM2_A597SolicitudesUsrAlta, P00FM2_n597SolicitudesUsrAlta, P00FM2_A438SolicitudServicioOrigenPago, P00FM2_n438SolicitudServicioOrigenPago, P00FM2_A182SolicitudesFechaAlta, P00FM2_n182SolicitudesFechaAlta, P00FM2_A184SolicitudesFechaInstalacion, P00FM2_A133ProveedorID, P00FM2_A131EstadosSolId,
               P00FM2_A282ProveedorNombre, P00FM2_A127SolicitudesID, P00FM2_A530SolicitudServicioComALM, P00FM2_n530SolicitudServicioComALM, P00FM2_A132EstadosSolNombre, P00FM2_A796SolicitudesComisionMetodoPago, P00FM2_A212SolicitudesCotizacion, P00FM2_A1016SolicitudesDescuentoCupon, P00FM2_A897SolicitudesDescuento, P00FM2_n897SolicitudesDescuento,
               P00FM2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00FM3_A18SecUserId, P00FM3_A26SecUserName
               }
               , new Object[] {
               P00FM4_A127SolicitudesID, P00FM4_A134SolicitudesItemsID, P00FM4_A180SolicitudItemsComision, P00FM4_A179SolicitudItemsComisionTipo, P00FM4_A178SolicitudItemsSR, P00FM4_A177SolicitudesItemsCantidad, P00FM4_A176SolicitudesItemsPrecioFinal, P00FM4_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV64CellRow ;
      private short AV68ColumnIndex ;
      private short AV69FirstColumn ;
      private int AV70EstadosGenericosID ;
      private int AV46SecUserID_Count ;
      private int AV44ProveedorID_Count ;
      private int A131EstadosSolId ;
      private long AV66Random ;
      private long A133ProveedorID ;
      private long A597SolicitudesUsrAlta ;
      private long A127SolicitudesID ;
      private long AV50SolicitudesUsrAlta ;
      private long A18SecUserId ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV55TotalAlmango ;
      private decimal AV53Total ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV51SolicitudServicioOrigenPago ;
      private string A438SolicitudServicioOrigenPago ;
      private string A130EstadosSolTipo ;
      private string A282ProveedorNombre ;
      private string A132EstadosSolNombre ;
      private DateTime GXt_dtime1 ;
      private DateTime AV19Desde ;
      private DateTime AV28Hasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private bool returnInSub ;
      private bool n597SolicitudesUsrAlta ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n182SolicitudesFechaAlta ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private string AV72SecUserIDJson ;
      private string AV71FechaFiltro ;
      private string AV27FileName ;
      private string AV47SecUserName ;
      private string AV65ErrorMessage ;
      private string A26SecUserName ;
      private GxHttpResponse AV67HttpResponse ;
      private ExcelDocumentI AV8ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV44ProveedorID ;
      private string aP6_SecUserIDJson ;
      private GxSimpleCollection<long> AV46SecUserID ;
      private IDataStoreProvider pr_default ;
      private string[] P00FM2_A130EstadosSolTipo ;
      private long[] P00FM2_A597SolicitudesUsrAlta ;
      private bool[] P00FM2_n597SolicitudesUsrAlta ;
      private string[] P00FM2_A438SolicitudServicioOrigenPago ;
      private bool[] P00FM2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00FM2_A182SolicitudesFechaAlta ;
      private bool[] P00FM2_n182SolicitudesFechaAlta ;
      private DateTime[] P00FM2_A184SolicitudesFechaInstalacion ;
      private long[] P00FM2_A133ProveedorID ;
      private int[] P00FM2_A131EstadosSolId ;
      private string[] P00FM2_A282ProveedorNombre ;
      private long[] P00FM2_A127SolicitudesID ;
      private decimal[] P00FM2_A530SolicitudServicioComALM ;
      private bool[] P00FM2_n530SolicitudServicioComALM ;
      private string[] P00FM2_A132EstadosSolNombre ;
      private decimal[] P00FM2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00FM2_A212SolicitudesCotizacion ;
      private decimal[] P00FM2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00FM2_A897SolicitudesDescuento ;
      private bool[] P00FM2_n897SolicitudesDescuento ;
      private decimal[] P00FM2_A864SolicitudesCostoXZona ;
      private long[] P00FM3_A18SecUserId ;
      private string[] P00FM3_A26SecUserName ;
      private long[] P00FM4_A127SolicitudesID ;
      private short[] P00FM4_A134SolicitudesItemsID ;
      private decimal[] P00FM4_A180SolicitudItemsComision ;
      private string[] P00FM4_A179SolicitudItemsComisionTipo ;
      private string[] P00FM4_A178SolicitudItemsSR ;
      private short[] P00FM4_A177SolicitudesItemsCantidad ;
      private decimal[] P00FM4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00FM4_n176SolicitudesItemsPrecioFinal ;
   }

   public class areportecomisionesalmgxls__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FM2( IGxContext context ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV44ProveedorID ,
                                             long A597SolicitudesUsrAlta ,
                                             GxSimpleCollection<long> AV46SecUserID ,
                                             string AV71FechaFiltro ,
                                             int AV46SecUserID_Count ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV19Desde ,
                                             DateTime AV28Hasta ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             int AV44ProveedorID_Count ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV51SolicitudServicioOrigenPago )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesUsrAlta], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T2.[ProveedorNombre], T1.[SolicitudesID], T1.[SolicitudServicioComALM], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV44ProveedorID, "T1.[ProveedorID] IN (", ")")+" or @AV44ProveedorID_Count = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV51SolicitudServicioOrigenPago or @AV51SolicitudServicioOrigenPago = '')");
         if ( StringUtil.StrCmp(AV71FechaFiltro, context.GetMessage( "Trabajo", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV19Desde and T1.[SolicitudesFechaInstalacion] <= @AV28Hasta)");
         }
         else
         {
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV71FechaFiltro, context.GetMessage( "Alta", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV19Desde and T1.[SolicitudesFechaAlta] <= @AV28Hasta)");
         }
         else
         {
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
         }
         if ( ! ( AV46SecUserID_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV46SecUserID, "T1.[SolicitudesUsrAlta] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorID] DESC, T1.[SolicitudesFechaAlta] DESC";
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
               case 0 :
                     return conditional_P00FM2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP00FM3;
          prmP00FM3 = new Object[] {
          new ParDef("@AV50SolicitudesUsrAlta",GXType.Decimal,10,0)
          };
          Object[] prmP00FM4;
          prmP00FM4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00FM2;
          prmP00FM2 = new Object[] {
          new ParDef("@AV44ProveedorID_Count",GXType.Int32,9,0) ,
          new ParDef("@AV51SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV51SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV19Desde",GXType.Date,8,0) ,
          new ParDef("@AV28Hasta",GXType.Date,8,0) ,
          new ParDef("@AV19Desde",GXType.Date,8,0) ,
          new ParDef("@AV28Hasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FM3", "SELECT TOP 1 [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @AV50SolicitudesUsrAlta ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FM4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FM4,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 80);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 80);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
