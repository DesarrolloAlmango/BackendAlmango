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
   public class reportesolicitudes : GXProcedure
   {
      public reportesolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportesolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_cProveedorId ,
                           int aP1_EstadosGenericosID ,
                           DateTime aP2_FechaIni ,
                           DateTime aP3_FechaFin ,
                           string aP4_FechaFiltro ,
                           string aP5_BusDireccion ,
                           bool aP6_SiNo )
      {
         this.AV22cProveedorId = aP0_cProveedorId;
         this.AV10EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV14FechaIni = aP2_FechaIni;
         this.AV15FechaFin = aP3_FechaFin;
         this.AV23FechaFiltro = aP4_FechaFiltro;
         this.AV11BusDireccion = aP5_BusDireccion;
         this.AV21SiNo = aP6_SiNo;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_cProveedorId ,
                                 int aP1_EstadosGenericosID ,
                                 DateTime aP2_FechaIni ,
                                 DateTime aP3_FechaFin ,
                                 string aP4_FechaFiltro ,
                                 string aP5_BusDireccion ,
                                 bool aP6_SiNo )
      {
         this.AV22cProveedorId = aP0_cProveedorId;
         this.AV10EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV14FechaIni = aP2_FechaIni;
         this.AV15FechaFin = aP3_FechaFin;
         this.AV23FechaFiltro = aP4_FechaFiltro;
         this.AV11BusDireccion = aP5_BusDireccion;
         this.AV21SiNo = aP6_SiNo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Random = (int)(NumberUtil.Random( )*10000);
         AV13Filename = "ReporteSolicitudo-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV12Random), 8, 0)) + ".xlsx";
         AV8ExcelDocument.Clear();
         AV8ExcelDocument.Open(AV13Filename);
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A133ProveedorID ,
                                              AV22cProveedorId ,
                                              AV23FechaFiltro ,
                                              AV11BusDireccion ,
                                              AV21SiNo ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV14FechaIni ,
                                              AV15FechaFin ,
                                              A182SolicitudesFechaAlta ,
                                              A173SolicitudesDireccion ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              AV22cProveedorId.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV11BusDireccion = StringUtil.PadR( StringUtil.RTrim( AV11BusDireccion), 100, "%");
         lV11BusDireccion = StringUtil.PadR( StringUtil.RTrim( AV11BusDireccion), 100, "%");
         /* Using cursor P008N2 */
         pr_default.execute(0, new Object[] {AV22cProveedorId.Count, AV14FechaIni, AV15FechaFin, AV14FechaIni, AV15FechaFin, lV11BusDireccion, lV11BusDireccion});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P008N2_A112DepartamentoId[0];
            n112DepartamentoId = P008N2_n112DepartamentoId[0];
            A130EstadosSolTipo = P008N2_A130EstadosSolTipo[0];
            A533ProveedorNombreAux = P008N2_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P008N2_n533ProveedorNombreAux[0];
            A113DepartamentoDepartamento = P008N2_A113DepartamentoDepartamento[0];
            A173SolicitudesDireccion = P008N2_A173SolicitudesDireccion[0];
            A182SolicitudesFechaAlta = P008N2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P008N2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P008N2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P008N2_A133ProveedorID[0];
            A131EstadosSolId = P008N2_A131EstadosSolId[0];
            A127SolicitudesID = P008N2_A127SolicitudesID[0];
            A282ProveedorNombre = P008N2_A282ProveedorNombre[0];
            A171SolicitudesNombre = P008N2_A171SolicitudesNombre[0];
            A205SolicitudesComentario = P008N2_A205SolicitudesComentario[0];
            A172SolicitudesTelefono = P008N2_A172SolicitudesTelefono[0];
            A212SolicitudesCotizacion = P008N2_A212SolicitudesCotizacion[0];
            A132EstadosSolNombre = P008N2_A132EstadosSolNombre[0];
            A113DepartamentoDepartamento = P008N2_A113DepartamentoDepartamento[0];
            A282ProveedorNombre = P008N2_A282ProveedorNombre[0];
            A132EstadosSolNombre = P008N2_A132EstadosSolNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( ( AV10EstadosGenericosID == 6 ) && ( ( A131EstadosSolId == 6 ) || ( A131EstadosSolId == 7 ) ) ) || ( ( AV10EstadosGenericosID == 0 ) && ( ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) ) || ( AV10EstadosGenericosID == A131EstadosSolId ) )
            {
               AV16CellRow = (long)(AV16CellRow+1);
               AV17ColumnIndex = 1;
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Number = A127SolicitudesID;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A282ProveedorNombre;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A533ProveedorNombreAux;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A171SolicitudesNombre;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A205SolicitudesComentario;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.Trim( A172SolicitudesTelefono);
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.Trim( context.localUtil.DToC( A182SolicitudesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = StringUtil.Trim( context.localUtil.DToC( A184SolicitudesFechaInstalacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A113DepartamentoDepartamento;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A173SolicitudesDireccion;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Number = (double)(A174SolicitudesTotal);
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Number = (double)(A212SolicitudesCotizacion);
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
               AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = A132EstadosSolNombre;
               AV17ColumnIndex = (short)(AV17ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8ExcelDocument.Close();
         CallWebObject(formatLink(AV13Filename) );
         context.wjLocDisableFrm = 0;
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV8ExcelDocument.ErrCode != 0 )
         {
            AV13Filename = "";
            AV20ErrorMessage = AV8ExcelDocument.ErrDescription;
            AV19HttpResponse.AddString(AV20ErrorMessage);
            context.StatusMessage( AV20ErrorMessage );
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'COLUMNTITLE' Routine */
         returnInSub = false;
         AV16CellRow = 1;
         AV17ColumnIndex = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Solicitud", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Proveedor", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Proveedor Auxiliar", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Cliente", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Comentario", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Telefono", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Fecha Instalar", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Departamento", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Dirección", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Total", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Cotización", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Bold = 1;
         AV8ExcelDocument.get_Cells((int)(AV16CellRow), AV18FirstColumn+AV17ColumnIndex, 1, 1).Text = context.GetMessage( "Estado", "");
         AV17ColumnIndex = (short)(AV17ColumnIndex+1);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P008N3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P008N3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008N3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008N3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008N3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008N3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])-(P008N3_A180SolicitudItemsComision[0]*P008N3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008N3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008N3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])+(P008N3_A180SolicitudItemsComision[0]*P008N3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008N3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008N3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])-((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])*(P008N3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008N3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008N3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])+((P008N3_A176SolicitudesItemsPrecioFinal[0]*P008N3_A177SolicitudesItemsCantidad[0])*(P008N3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         AV13Filename = "";
         AV8ExcelDocument = new ExcelDocumentI();
         lV11BusDireccion = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A173SolicitudesDireccion = "";
         A113DepartamentoDepartamento = "";
         A533ProveedorNombreAux = "";
         P008N2_A112DepartamentoId = new long[1] ;
         P008N2_n112DepartamentoId = new bool[] {false} ;
         P008N2_A130EstadosSolTipo = new string[] {""} ;
         P008N2_A533ProveedorNombreAux = new string[] {""} ;
         P008N2_n533ProveedorNombreAux = new bool[] {false} ;
         P008N2_A113DepartamentoDepartamento = new string[] {""} ;
         P008N2_A173SolicitudesDireccion = new string[] {""} ;
         P008N2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P008N2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P008N2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008N2_A133ProveedorID = new long[1] ;
         P008N2_A131EstadosSolId = new int[1] ;
         P008N2_A127SolicitudesID = new long[1] ;
         P008N2_A282ProveedorNombre = new string[] {""} ;
         P008N2_A171SolicitudesNombre = new string[] {""} ;
         P008N2_A205SolicitudesComentario = new string[] {""} ;
         P008N2_A172SolicitudesTelefono = new string[] {""} ;
         P008N2_A212SolicitudesCotizacion = new decimal[1] ;
         P008N2_A132EstadosSolNombre = new string[] {""} ;
         A130EstadosSolTipo = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A205SolicitudesComentario = "";
         A172SolicitudesTelefono = "";
         A132EstadosSolNombre = "";
         AV20ErrorMessage = "";
         AV19HttpResponse = new GxHttpResponse( context);
         P008N3_A127SolicitudesID = new long[1] ;
         P008N3_A134SolicitudesItemsID = new short[1] ;
         P008N3_A180SolicitudItemsComision = new decimal[1] ;
         P008N3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008N3_A178SolicitudItemsSR = new string[] {""} ;
         P008N3_A177SolicitudesItemsCantidad = new short[1] ;
         P008N3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008N3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportesolicitudes__default(),
            new Object[][] {
                new Object[] {
               P008N2_A112DepartamentoId, P008N2_n112DepartamentoId, P008N2_A130EstadosSolTipo, P008N2_A533ProveedorNombreAux, P008N2_n533ProveedorNombreAux, P008N2_A113DepartamentoDepartamento, P008N2_A173SolicitudesDireccion, P008N2_A182SolicitudesFechaAlta, P008N2_n182SolicitudesFechaAlta, P008N2_A184SolicitudesFechaInstalacion,
               P008N2_A133ProveedorID, P008N2_A131EstadosSolId, P008N2_A127SolicitudesID, P008N2_A282ProveedorNombre, P008N2_A171SolicitudesNombre, P008N2_A205SolicitudesComentario, P008N2_A172SolicitudesTelefono, P008N2_A212SolicitudesCotizacion, P008N2_A132EstadosSolNombre
               }
               , new Object[] {
               P008N3_A127SolicitudesID, P008N3_A134SolicitudesItemsID, P008N3_A180SolicitudItemsComision, P008N3_A179SolicitudItemsComisionTipo, P008N3_A178SolicitudItemsSR, P008N3_A177SolicitudesItemsCantidad, P008N3_A176SolicitudesItemsPrecioFinal, P008N3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17ColumnIndex ;
      private short AV18FirstColumn ;
      private int AV10EstadosGenericosID ;
      private int AV12Random ;
      private int AV22cProveedorId_Count ;
      private int A131EstadosSolId ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A127SolicitudesID ;
      private long AV16CellRow ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV11BusDireccion ;
      private string lV11BusDireccion ;
      private string A113DepartamentoDepartamento ;
      private string A533ProveedorNombreAux ;
      private string A130EstadosSolTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A132EstadosSolNombre ;
      private DateTime AV14FechaIni ;
      private DateTime AV15FechaFin ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private bool AV21SiNo ;
      private bool returnInSub ;
      private bool n112DepartamentoId ;
      private bool n533ProveedorNombreAux ;
      private bool n182SolicitudesFechaAlta ;
      private string A205SolicitudesComentario ;
      private string AV23FechaFiltro ;
      private string AV13Filename ;
      private string A173SolicitudesDireccion ;
      private string AV20ErrorMessage ;
      private GxHttpResponse AV19HttpResponse ;
      private ExcelDocumentI AV8ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV22cProveedorId ;
      private IDataStoreProvider pr_default ;
      private long[] P008N2_A112DepartamentoId ;
      private bool[] P008N2_n112DepartamentoId ;
      private string[] P008N2_A130EstadosSolTipo ;
      private string[] P008N2_A533ProveedorNombreAux ;
      private bool[] P008N2_n533ProveedorNombreAux ;
      private string[] P008N2_A113DepartamentoDepartamento ;
      private string[] P008N2_A173SolicitudesDireccion ;
      private DateTime[] P008N2_A182SolicitudesFechaAlta ;
      private bool[] P008N2_n182SolicitudesFechaAlta ;
      private DateTime[] P008N2_A184SolicitudesFechaInstalacion ;
      private long[] P008N2_A133ProveedorID ;
      private int[] P008N2_A131EstadosSolId ;
      private long[] P008N2_A127SolicitudesID ;
      private string[] P008N2_A282ProveedorNombre ;
      private string[] P008N2_A171SolicitudesNombre ;
      private string[] P008N2_A205SolicitudesComentario ;
      private string[] P008N2_A172SolicitudesTelefono ;
      private decimal[] P008N2_A212SolicitudesCotizacion ;
      private string[] P008N2_A132EstadosSolNombre ;
      private long[] P008N3_A127SolicitudesID ;
      private short[] P008N3_A134SolicitudesItemsID ;
      private decimal[] P008N3_A180SolicitudItemsComision ;
      private string[] P008N3_A179SolicitudItemsComisionTipo ;
      private string[] P008N3_A178SolicitudItemsSR ;
      private short[] P008N3_A177SolicitudesItemsCantidad ;
      private decimal[] P008N3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008N3_n176SolicitudesItemsPrecioFinal ;
   }

   public class reportesolicitudes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008N2( IGxContext context ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV22cProveedorId ,
                                             string AV23FechaFiltro ,
                                             string AV11BusDireccion ,
                                             bool AV21SiNo ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV14FechaIni ,
                                             DateTime AV15FechaFin ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             string A173SolicitudesDireccion ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             int AV22cProveedorId_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[ProveedorNombreAux], T2.[DepartamentoDepartamento], T1.[SolicitudesDireccion], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T3.[ProveedorNombre], T1.[SolicitudesNombre], T1.[SolicitudesComentario], T1.[SolicitudesTelefono], T1.[SolicitudesCotizacion], T4.[EstadosGenericosNombre] AS EstadosSolNombre FROM ((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [EstadosGenericos] T4 ON T4.[EstadosTipo] = T1.[EstadosSolTipo] AND T4.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22cProveedorId, "T1.[ProveedorID] IN (", ")")+" or @AV22cProveedorId_Count = 0)");
         if ( StringUtil.StrCmp(AV23FechaFiltro, context.GetMessage( "Trabajo", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV14FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV15FechaFin)");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV23FechaFiltro, context.GetMessage( "Alta", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV14FechaIni and T1.[SolicitudesFechaAlta] <= @AV15FechaFin)");
         }
         else
         {
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11BusDireccion)) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] like @lV11BusDireccion or T2.[DepartamentoDepartamento] like @lV11BusDireccion)");
         }
         else
         {
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( AV21SiNo )
         {
            AddWhere(sWhereString, "(Not (T1.[ProveedorNombreAux] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesID]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008N2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP008N3;
          prmP008N3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP008N2;
          prmP008N2 = new Object[] {
          new ParDef("@AV22cProveedorId_Count",GXType.Int32,9,0) ,
          new ParDef("@AV14FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV15FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV14FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV15FechaFin",GXType.Date,8,0) ,
          new ParDef("@lV11BusDireccion",GXType.NChar,100,0) ,
          new ParDef("@lV11BusDireccion",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008N3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 80);
                ((string[]) buf[14])[0] = rslt.getString(12, 100);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((string[]) buf[18])[0] = rslt.getString(16, 80);
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
