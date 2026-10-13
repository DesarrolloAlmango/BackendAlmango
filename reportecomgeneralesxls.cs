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
   public class reportecomgeneralesxls : GXProcedure
   {
      public reportecomgeneralesxls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportecomgeneralesxls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           DateTime aP1_Desde ,
                           DateTime aP2_Hasta ,
                           short aP3_Clasificaciones ,
                           string aP4_SolicitudServicioOrigenPago )
      {
         this.AV30ProfesionalesId = aP0_ProfesionalesId;
         this.AV13Desde = aP1_Desde;
         this.AV20Hasta = aP2_Hasta;
         this.AV9Clasificaciones = aP3_Clasificaciones;
         this.AV34SolicitudServicioOrigenPago = aP4_SolicitudServicioOrigenPago;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 DateTime aP1_Desde ,
                                 DateTime aP2_Hasta ,
                                 short aP3_Clasificaciones ,
                                 string aP4_SolicitudServicioOrigenPago )
      {
         this.AV30ProfesionalesId = aP0_ProfesionalesId;
         this.AV13Desde = aP1_Desde;
         this.AV20Hasta = aP2_Hasta;
         this.AV9Clasificaciones = aP3_Clasificaciones;
         this.AV34SolicitudServicioOrigenPago = aP4_SolicitudServicioOrigenPago;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Random = (short)(NumberUtil.Random( )*10000);
         AV18Filename = "ReporteComisionesGenerales-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV31Random), 4, 0)) + ".xlsx";
         AV16ExcelDocument.Open(AV18Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV16ExcelDocument.Clear();
         AV8CellRow = 1;
         AV10ColumnIndex = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha del Reporte: ", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
         AV16ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV8CellRow = (short)(AV8CellRow+1);
         AV10ColumnIndex = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Reporte Financiero de Actividades Profesionales", "");
         AV8CellRow = (short)(AV8CellRow+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Rango de Fechas:", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV13Desde ) ;
         AV16ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = "-";
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV20Hasta ) ;
         AV16ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Date = GXt_dtime1;
         AV8CellRow = (short)(AV8CellRow+2);
         AV10ColumnIndex = 1;
         /* Execute user subroutine: 'COLUMNTITLE' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV38TotalComisiones = 0;
         AV43TotalOrden = 0;
         AV39TotalComisionProveedor = 0;
         AV37TotalAlmango = 0;
         AV41TotalFin = 0;
         AV42TotalHab = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30ProfesionalesId)) )
         {
            /* Using cursor P008E2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A108EstadosGenericosId = P008E2_A108EstadosGenericosId[0];
               A107EstadosTipo = P008E2_A107EstadosTipo[0];
               A120ProfesionalesId = P008E2_A120ProfesionalesId[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV46ProfesionalesIdTodos = StringUtil.Trim( A120ProfesionalesId);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46ProfesionalesIdTodos)) )
                  {
                     /* Execute user subroutine: 'REPORTEPORPROFESIONAL' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        cleanup();
                        if (true) return;
                     }
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV46ProfesionalesIdTodos = StringUtil.Trim( AV30ProfesionalesId);
            /* Execute user subroutine: 'REPORTEPORPROFESIONAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV8CellRow = (short)(AV8CellRow+2);
         AV10ColumnIndex = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Total Delegadas/Habilitdas", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Total Aceptadas", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Total Finalizadas", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "ComisionesALM", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "ComisionesCom", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Profesional", "");
         AV8CellRow = (short)(AV8CellRow+1);
         AV10ColumnIndex = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV42TotalHab);
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV36TotalAcep);
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)((AV41TotalFin+AV36TotalAcep+AV42TotalHab));
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV37TotalAlmango);
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV39TotalComisionProveedor);
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV38TotalComisiones);
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV16ExcelDocument.Close();
         CallWebObject(formatLink(AV18Filename) );
         context.wjLocDisableFrm = 0;
         cleanup();
      }

      protected void S111( )
      {
         /* 'REPORTEPORPROFESIONAL' Routine */
         returnInSub = false;
         new oprofesionalnombre(context ).execute(  AV46ProfesionalesIdTodos, out  AV24nombreProfesional, out  AV28ProfesionalesFeedBackCant, out  AV29ProfesionalesFeedBackProm, out  AV27ProfesionalesFeedback) ;
         AV12ComisionProv = 0;
         AV11ComisionALM = 0;
         AV12ComisionProv = 0;
         AV22Importe = 0;
         AV17Fecha = DateTime.MinValue;
         AV25OrigenPago = "";
         /* Using cursor P008E3 */
         pr_default.execute(1, new Object[] {AV20Hasta, AV9Clasificaciones, AV34SolicitudServicioOrigenPago, AV13Desde});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A130EstadosSolTipo = P008E3_A130EstadosSolTipo[0];
            A131EstadosSolId = P008E3_A131EstadosSolId[0];
            A438SolicitudServicioOrigenPago = P008E3_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P008E3_n438SolicitudServicioOrigenPago[0];
            A184SolicitudesFechaInstalacion = P008E3_A184SolicitudesFechaInstalacion[0];
            A127SolicitudesID = P008E3_A127SolicitudesID[0];
            A171SolicitudesNombre = P008E3_A171SolicitudesNombre[0];
            A527SolicitudServicioComProv = P008E3_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P008E3_n527SolicitudServicioComProv[0];
            A865SolicitudesCostoXZComAlm = P008E3_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P008E3_n865SolicitudesCostoXZComAlm[0];
            A530SolicitudServicioComALM = P008E3_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P008E3_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P008E3_A132EstadosSolNombre[0];
            A796SolicitudesComisionMetodoPago = P008E3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P008E3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P008E3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P008E3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P008E3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P008E3_A864SolicitudesCostoXZona[0];
            A132EstadosSolNombre = P008E3_A132EstadosSolNombre[0];
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
            AV32SolicitudesID = A127SolicitudesID;
            AV23NombreCliente = A171SolicitudesNombre;
            AV12ComisionProv = A527SolicitudServicioComProv;
            AV11ComisionALM = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm);
            AV22Importe = A211SolicitudServicioPFinal;
            AV15Estado = A132EstadosSolNombre;
            AV17Fecha = A184SolicitudesFechaInstalacion;
            AV25OrigenPago = A438SolicitudServicioOrigenPago;
            /* Using cursor P008E4 */
            pr_default.execute(2, new Object[] {AV32SolicitudesID, AV46ProfesionalesIdTodos});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A142EstadoSGId = P008E4_A142EstadoSGId[0];
               A141EstadoSGTipo = P008E4_A141EstadoSGTipo[0];
               A120ProfesionalesId = P008E4_A120ProfesionalesId[0];
               A127SolicitudesID = P008E4_A127SolicitudesID[0];
               A140RelacionesId = P008E4_A140RelacionesId[0];
               if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  context.StatusMessage( AV50Pgmname+context.GetMessage( " fecha ", "")+context.localUtil.DToC( AV17Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")+context.GetMessage( " Solicitud543222 ", "")+StringUtil.Str( (decimal)(AV32SolicitudesID), 18, 0) );
                  AV8CellRow = (short)(AV8CellRow+1);
                  AV10ColumnIndex = 1;
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.localUtil.DToC( AV17Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = StringUtil.Str( (decimal)(AV32SolicitudesID), 18, 0);
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = AV23NombreCliente;
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = AV25OrigenPago;
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV11ComisionALM);
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV12ComisionProv);
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Number = (double)(AV22Importe);
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = AV15Estado;
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = AV24nombreProfesional;
                  AV10ColumnIndex = (short)(AV10ColumnIndex+1);
                  if ( A131EstadosSolId == 2 )
                  {
                     AV42TotalHab = (decimal)(AV42TotalHab+A211SolicitudServicioPFinal);
                  }
                  else if ( A131EstadosSolId == 8 )
                  {
                     AV42TotalHab = (decimal)(AV42TotalHab+A211SolicitudServicioPFinal);
                  }
                  else if ( A131EstadosSolId == 5 )
                  {
                     AV36TotalAcep = (decimal)(AV36TotalAcep+A211SolicitudServicioPFinal);
                  }
                  else if ( A131EstadosSolId == 6 )
                  {
                     AV41TotalFin = (decimal)(AV41TotalFin+A211SolicitudServicioPFinal);
                  }
                  else if ( A131EstadosSolId == 7 )
                  {
                     AV41TotalFin = (decimal)(AV41TotalFin+A211SolicitudServicioPFinal);
                  }
                  AV43TotalOrden = (decimal)(AV43TotalOrden+A211SolicitudServicioPFinal);
                  AV39TotalComisionProveedor = (decimal)(AV39TotalComisionProveedor+AV12ComisionProv);
                  AV37TotalAlmango = (decimal)(AV37TotalAlmango+AV11ComisionALM);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV38TotalComisiones = (decimal)(AV38TotalComisiones+(AV43TotalOrden-AV39TotalComisionProveedor-AV37TotalAlmango));
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV16ExcelDocument.ErrCode != 0 )
         {
            AV18Filename = "";
            AV14ErrorMessage = AV16ExcelDocument.ErrDescription;
            AV21HttpResponse.AddString(AV14ErrorMessage);
            context.StatusMessage( AV14ErrorMessage );
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'COLUMNTITLE' Routine */
         returnInSub = false;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Solicitud", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Cliente", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Pagado", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Almango", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Comercio", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Importe", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Estado", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Bold = 1;
         AV16ExcelDocument.get_Cells(AV8CellRow, AV19FirstColumn+AV10ColumnIndex, 1, 1).Text = context.GetMessage( "Nombre Profesional", "");
         AV10ColumnIndex = (short)(AV10ColumnIndex+1);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P008E5 */
         pr_default.execute(3, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(3) != 101) && ( P008E5_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008E5_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008E5_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008E5_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008E5_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])-(P008E5_A180SolicitudItemsComision[0]*P008E5_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008E5_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008E5_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])+(P008E5_A180SolicitudItemsComision[0]*P008E5_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008E5_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008E5_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])-((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])*(P008E5_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008E5_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008E5_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])+((P008E5_A176SolicitudesItemsPrecioFinal[0]*P008E5_A177SolicitudesItemsCantidad[0])*(P008E5_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         AV18Filename = "";
         AV16ExcelDocument = new ExcelDocumentI();
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P008E2_A108EstadosGenericosId = new int[1] ;
         P008E2_A107EstadosTipo = new string[] {""} ;
         P008E2_A120ProfesionalesId = new string[] {""} ;
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         AV46ProfesionalesIdTodos = "";
         AV24nombreProfesional = "";
         AV17Fecha = DateTime.MinValue;
         AV25OrigenPago = "";
         P008E3_A130EstadosSolTipo = new string[] {""} ;
         P008E3_A131EstadosSolId = new int[1] ;
         P008E3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008E3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008E3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008E3_A127SolicitudesID = new long[1] ;
         P008E3_A171SolicitudesNombre = new string[] {""} ;
         P008E3_A527SolicitudServicioComProv = new decimal[1] ;
         P008E3_n527SolicitudServicioComProv = new bool[] {false} ;
         P008E3_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P008E3_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P008E3_A530SolicitudServicioComALM = new decimal[1] ;
         P008E3_n530SolicitudServicioComALM = new bool[] {false} ;
         P008E3_A132EstadosSolNombre = new string[] {""} ;
         P008E3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008E3_A212SolicitudesCotizacion = new decimal[1] ;
         P008E3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008E3_A897SolicitudesDescuento = new decimal[1] ;
         P008E3_n897SolicitudesDescuento = new bool[] {false} ;
         P008E3_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV23NombreCliente = "";
         AV15Estado = "";
         P008E4_A142EstadoSGId = new int[1] ;
         P008E4_A141EstadoSGTipo = new string[] {""} ;
         P008E4_A120ProfesionalesId = new string[] {""} ;
         P008E4_A127SolicitudesID = new long[1] ;
         P008E4_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         AV50Pgmname = "";
         AV14ErrorMessage = "";
         AV21HttpResponse = new GxHttpResponse( context);
         P008E5_A127SolicitudesID = new long[1] ;
         P008E5_A134SolicitudesItemsID = new short[1] ;
         P008E5_A180SolicitudItemsComision = new decimal[1] ;
         P008E5_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008E5_A178SolicitudItemsSR = new string[] {""} ;
         P008E5_A177SolicitudesItemsCantidad = new short[1] ;
         P008E5_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008E5_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportecomgeneralesxls__default(),
            new Object[][] {
                new Object[] {
               P008E2_A108EstadosGenericosId, P008E2_A107EstadosTipo, P008E2_A120ProfesionalesId
               }
               , new Object[] {
               P008E3_A130EstadosSolTipo, P008E3_A131EstadosSolId, P008E3_A438SolicitudServicioOrigenPago, P008E3_n438SolicitudServicioOrigenPago, P008E3_A184SolicitudesFechaInstalacion, P008E3_A127SolicitudesID, P008E3_A171SolicitudesNombre, P008E3_A527SolicitudServicioComProv, P008E3_n527SolicitudServicioComProv, P008E3_A865SolicitudesCostoXZComAlm,
               P008E3_n865SolicitudesCostoXZComAlm, P008E3_A530SolicitudServicioComALM, P008E3_n530SolicitudServicioComALM, P008E3_A132EstadosSolNombre, P008E3_A796SolicitudesComisionMetodoPago, P008E3_A212SolicitudesCotizacion, P008E3_A1016SolicitudesDescuentoCupon, P008E3_A897SolicitudesDescuento, P008E3_n897SolicitudesDescuento, P008E3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008E4_A142EstadoSGId, P008E4_A141EstadoSGTipo, P008E4_A120ProfesionalesId, P008E4_A127SolicitudesID, P008E4_A140RelacionesId
               }
               , new Object[] {
               P008E5_A127SolicitudesID, P008E5_A134SolicitudesItemsID, P008E5_A180SolicitudItemsComision, P008E5_A179SolicitudItemsComisionTipo, P008E5_A178SolicitudItemsSR, P008E5_A177SolicitudesItemsCantidad, P008E5_A176SolicitudesItemsPrecioFinal, P008E5_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         AV50Pgmname = "ReporteComGeneralesXLS";
         /* GeneXus formulas. */
         AV50Pgmname = "ReporteComGeneralesXLS";
      }

      private short AV9Clasificaciones ;
      private short AV31Random ;
      private short AV8CellRow ;
      private short AV10ColumnIndex ;
      private short AV19FirstColumn ;
      private int A108EstadosGenericosId ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private long AV28ProfesionalesFeedBackCant ;
      private long A127SolicitudesID ;
      private long AV32SolicitudesID ;
      private long A140RelacionesId ;
      private decimal AV38TotalComisiones ;
      private decimal AV43TotalOrden ;
      private decimal AV39TotalComisionProveedor ;
      private decimal AV37TotalAlmango ;
      private decimal AV41TotalFin ;
      private decimal AV42TotalHab ;
      private decimal AV36TotalAcep ;
      private decimal AV29ProfesionalesFeedBackProm ;
      private decimal AV27ProfesionalesFeedback ;
      private decimal AV12ComisionProv ;
      private decimal AV11ComisionALM ;
      private decimal AV22Importe ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV30ProfesionalesId ;
      private string AV34SolicitudServicioOrigenPago ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private string AV46ProfesionalesIdTodos ;
      private string AV24nombreProfesional ;
      private string AV25OrigenPago ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV15Estado ;
      private string A141EstadoSGTipo ;
      private string AV50Pgmname ;
      private DateTime GXt_dtime1 ;
      private DateTime AV13Desde ;
      private DateTime AV20Hasta ;
      private DateTime AV17Fecha ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool returnInSub ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private string AV18Filename ;
      private string AV23NombreCliente ;
      private string AV14ErrorMessage ;
      private GxHttpResponse AV21HttpResponse ;
      private ExcelDocumentI AV16ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P008E2_A108EstadosGenericosId ;
      private string[] P008E2_A107EstadosTipo ;
      private string[] P008E2_A120ProfesionalesId ;
      private string[] P008E3_A130EstadosSolTipo ;
      private int[] P008E3_A131EstadosSolId ;
      private string[] P008E3_A438SolicitudServicioOrigenPago ;
      private bool[] P008E3_n438SolicitudServicioOrigenPago ;
      private DateTime[] P008E3_A184SolicitudesFechaInstalacion ;
      private long[] P008E3_A127SolicitudesID ;
      private string[] P008E3_A171SolicitudesNombre ;
      private decimal[] P008E3_A527SolicitudServicioComProv ;
      private bool[] P008E3_n527SolicitudServicioComProv ;
      private decimal[] P008E3_A865SolicitudesCostoXZComAlm ;
      private bool[] P008E3_n865SolicitudesCostoXZComAlm ;
      private decimal[] P008E3_A530SolicitudServicioComALM ;
      private bool[] P008E3_n530SolicitudServicioComALM ;
      private string[] P008E3_A132EstadosSolNombre ;
      private decimal[] P008E3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008E3_A212SolicitudesCotizacion ;
      private decimal[] P008E3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008E3_A897SolicitudesDescuento ;
      private bool[] P008E3_n897SolicitudesDescuento ;
      private decimal[] P008E3_A864SolicitudesCostoXZona ;
      private int[] P008E4_A142EstadoSGId ;
      private string[] P008E4_A141EstadoSGTipo ;
      private string[] P008E4_A120ProfesionalesId ;
      private long[] P008E4_A127SolicitudesID ;
      private long[] P008E4_A140RelacionesId ;
      private long[] P008E5_A127SolicitudesID ;
      private short[] P008E5_A134SolicitudesItemsID ;
      private decimal[] P008E5_A180SolicitudItemsComision ;
      private string[] P008E5_A179SolicitudItemsComisionTipo ;
      private string[] P008E5_A178SolicitudItemsSR ;
      private short[] P008E5_A177SolicitudesItemsCantidad ;
      private decimal[] P008E5_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008E5_n176SolicitudesItemsPrecioFinal ;
   }

   public class reportecomgeneralesxls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008E2;
          prmP008E2 = new Object[] {
          };
          Object[] prmP008E3;
          prmP008E3 = new Object[] {
          new ParDef("@AV20Hasta",GXType.Date,8,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int16,4,0) ,
          new ParDef("@AV34SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV13Desde",GXType.Date,8,0)
          };
          Object[] prmP008E4;
          prmP008E4 = new Object[] {
          new ParDef("@AV32SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV46ProfesionalesIdTodos",GXType.Char,20,0)
          };
          Object[] prmP008E5;
          prmP008E5 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008E2", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId] FROM [Profesionales] WHERE [EstadosGenericosId] = 1 ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E3", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesID], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[SolicitudesFechaInstalacion] <= @AV20Hasta) AND (T1.[EstadosSolId] = @AV9Clasificaciones or @AV9Clasificaciones = 0) AND (T1.[SolicitudServicioOrigenPago] = @AV34SolicitudServicioOrigenPago or @AV34SolicitudServicioOrigenPago = '') AND (T1.[SolicitudesFechaInstalacion] >= @AV13Desde) ORDER BY T1.[SolicitudesFechaInstalacion] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E4", "SELECT [EstadoSGId], [EstadoSGTipo], [ProfesionalesId], [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV32SolicitudesID) AND (RTRIM(LTRIM([ProfesionalesId])) = @AV46ProfesionalesIdTodos) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008E5", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E5,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 80);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 3 :
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
