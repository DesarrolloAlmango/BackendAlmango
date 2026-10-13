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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class obtenerdatostoupdatesol : GXProcedure
   {
      public obtenerdatostoupdatesol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerdatostoupdatesol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudId ,
                           out long aP1_ProveedorID ,
                           out SdtSDTASolicitudes aP2_SolicitudesDatos )
      {
         this.AV8SolicitudId = aP0_SolicitudId;
         this.AV16ProveedorID = 0 ;
         this.AV13SolicitudesDatos = new SdtSDTASolicitudes(context) ;
         initialize();
         ExecutePrivate();
         aP1_ProveedorID=this.AV16ProveedorID;
         aP2_SolicitudesDatos=this.AV13SolicitudesDatos;
      }

      public SdtSDTASolicitudes executeUdp( long aP0_SolicitudId ,
                                            out long aP1_ProveedorID )
      {
         execute(aP0_SolicitudId, out aP1_ProveedorID, out aP2_SolicitudesDatos);
         return AV13SolicitudesDatos ;
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 out long aP1_ProveedorID ,
                                 out SdtSDTASolicitudes aP2_SolicitudesDatos )
      {
         this.AV8SolicitudId = aP0_SolicitudId;
         this.AV16ProveedorID = 0 ;
         this.AV13SolicitudesDatos = new SdtSDTASolicitudes(context) ;
         SubmitImpl();
         aP1_ProveedorID=this.AV16ProveedorID;
         aP2_SolicitudesDatos=this.AV13SolicitudesDatos;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00J42 */
         pr_default.execute(0, new Object[] {AV8SolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00J42_A127SolicitudesID[0];
            A133ProveedorID = P00J42_A133ProveedorID[0];
            A171SolicitudesNombre = P00J42_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = P00J42_A172SolicitudesTelefono[0];
            A206SolicitudesMail = P00J42_A206SolicitudesMail[0];
            n206SolicitudesMail = P00J42_n206SolicitudesMail[0];
            A112DepartamentoId = P00J42_A112DepartamentoId[0];
            n112DepartamentoId = P00J42_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P00J42_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00J42_n114DepartamentoMunicipioId[0];
            A173SolicitudesDireccion = P00J42_A173SolicitudesDireccion[0];
            A897SolicitudesDescuento = P00J42_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00J42_n897SolicitudesDescuento[0];
            A184SolicitudesFechaInstalacion = P00J42_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00J42_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = P00J42_A205SolicitudesComentario[0];
            A533ProveedorNombreAux = P00J42_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P00J42_n533ProveedorNombreAux[0];
            AV16ProveedorID = A133ProveedorID;
            AV13SolicitudesDatos.gxTpr_Nombre = A171SolicitudesNombre;
            AV13SolicitudesDatos.gxTpr_Telefono = A172SolicitudesTelefono;
            AV13SolicitudesDatos.gxTpr_Mail = A206SolicitudesMail;
            AV13SolicitudesDatos.gxTpr_Departamentoid = A112DepartamentoId;
            AV13SolicitudesDatos.gxTpr_Municipioid = A114DepartamentoMunicipioId;
            AV13SolicitudesDatos.gxTpr_Direccion = A173SolicitudesDireccion;
            AV13SolicitudesDatos.gxTpr_Descuento = A897SolicitudesDescuento;
            AV13SolicitudesDatos.gxTpr_Fechainstalacion = A184SolicitudesFechaInstalacion;
            AV13SolicitudesDatos.gxTpr_Turnoinstalacion = (short)(Math.Round(NumberUtil.Val( A183SolicitudesHoraInstalacion, "."), 18, MidpointRounding.ToEven));
            AV13SolicitudesDatos.gxTpr_Comentario = A205SolicitudesComentario;
            AV13SolicitudesDatos.gxTpr_Proveedorauxiliar = StringUtil.Trim( A533ProveedorNombreAux);
            /* Using cursor P00J43 */
            pr_default.execute(1, new Object[] {A127SolicitudesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A121RubrosId = P00J43_A121RubrosId[0];
               A137MedidasID = P00J43_A137MedidasID[0];
               A135InventarioId = P00J43_A135InventarioId[0];
               A177SolicitudesItemsCantidad = P00J43_A177SolicitudesItemsCantidad[0];
               A134SolicitudesItemsID = P00J43_A134SolicitudesItemsID[0];
               AV15SolicitudesDatosItem = new SdtSDTASolicitudes_Items(context);
               AV15SolicitudesDatosItem.gxTpr_Rubrosid = A121RubrosId;
               AV15SolicitudesDatosItem.gxTpr_Productoid = A137MedidasID;
               AV15SolicitudesDatosItem.gxTpr_Detalleid = A135InventarioId;
               AV15SolicitudesDatosItem.gxTpr_Cantidad = A177SolicitudesItemsCantidad;
               AV13SolicitudesDatos.gxTpr_Level1.Add(AV15SolicitudesDatosItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
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
         AV13SolicitudesDatos = new SdtSDTASolicitudes(context);
         P00J42_A127SolicitudesID = new long[1] ;
         P00J42_A133ProveedorID = new long[1] ;
         P00J42_A171SolicitudesNombre = new string[] {""} ;
         P00J42_A172SolicitudesTelefono = new string[] {""} ;
         P00J42_A206SolicitudesMail = new string[] {""} ;
         P00J42_n206SolicitudesMail = new bool[] {false} ;
         P00J42_A112DepartamentoId = new long[1] ;
         P00J42_n112DepartamentoId = new bool[] {false} ;
         P00J42_A114DepartamentoMunicipioId = new long[1] ;
         P00J42_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00J42_A173SolicitudesDireccion = new string[] {""} ;
         P00J42_A897SolicitudesDescuento = new decimal[1] ;
         P00J42_n897SolicitudesDescuento = new bool[] {false} ;
         P00J42_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00J42_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00J42_A205SolicitudesComentario = new string[] {""} ;
         P00J42_A533ProveedorNombreAux = new string[] {""} ;
         P00J42_n533ProveedorNombreAux = new bool[] {false} ;
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A173SolicitudesDireccion = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A205SolicitudesComentario = "";
         A533ProveedorNombreAux = "";
         P00J43_A127SolicitudesID = new long[1] ;
         P00J43_A121RubrosId = new short[1] ;
         P00J43_A137MedidasID = new long[1] ;
         P00J43_A135InventarioId = new long[1] ;
         P00J43_A177SolicitudesItemsCantidad = new short[1] ;
         P00J43_A134SolicitudesItemsID = new short[1] ;
         AV15SolicitudesDatosItem = new SdtSDTASolicitudes_Items(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerdatostoupdatesol__default(),
            new Object[][] {
                new Object[] {
               P00J42_A127SolicitudesID, P00J42_A133ProveedorID, P00J42_A171SolicitudesNombre, P00J42_A172SolicitudesTelefono, P00J42_A206SolicitudesMail, P00J42_n206SolicitudesMail, P00J42_A112DepartamentoId, P00J42_n112DepartamentoId, P00J42_A114DepartamentoMunicipioId, P00J42_n114DepartamentoMunicipioId,
               P00J42_A173SolicitudesDireccion, P00J42_A897SolicitudesDescuento, P00J42_n897SolicitudesDescuento, P00J42_A184SolicitudesFechaInstalacion, P00J42_A183SolicitudesHoraInstalacion, P00J42_A205SolicitudesComentario, P00J42_A533ProveedorNombreAux, P00J42_n533ProveedorNombreAux
               }
               , new Object[] {
               P00J43_A127SolicitudesID, P00J43_A121RubrosId, P00J43_A137MedidasID, P00J43_A135InventarioId, P00J43_A177SolicitudesItemsCantidad, P00J43_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private short A134SolicitudesItemsID ;
      private long AV8SolicitudId ;
      private long AV16ProveedorID ;
      private long A127SolicitudesID ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private decimal A897SolicitudesDescuento ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A183SolicitudesHoraInstalacion ;
      private string A533ProveedorNombreAux ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n206SolicitudesMail ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n897SolicitudesDescuento ;
      private bool n533ProveedorNombreAux ;
      private string A205SolicitudesComentario ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTASolicitudes AV13SolicitudesDatos ;
      private IDataStoreProvider pr_default ;
      private long[] P00J42_A127SolicitudesID ;
      private long[] P00J42_A133ProveedorID ;
      private string[] P00J42_A171SolicitudesNombre ;
      private string[] P00J42_A172SolicitudesTelefono ;
      private string[] P00J42_A206SolicitudesMail ;
      private bool[] P00J42_n206SolicitudesMail ;
      private long[] P00J42_A112DepartamentoId ;
      private bool[] P00J42_n112DepartamentoId ;
      private long[] P00J42_A114DepartamentoMunicipioId ;
      private bool[] P00J42_n114DepartamentoMunicipioId ;
      private string[] P00J42_A173SolicitudesDireccion ;
      private decimal[] P00J42_A897SolicitudesDescuento ;
      private bool[] P00J42_n897SolicitudesDescuento ;
      private DateTime[] P00J42_A184SolicitudesFechaInstalacion ;
      private string[] P00J42_A183SolicitudesHoraInstalacion ;
      private string[] P00J42_A205SolicitudesComentario ;
      private string[] P00J42_A533ProveedorNombreAux ;
      private bool[] P00J42_n533ProveedorNombreAux ;
      private long[] P00J43_A127SolicitudesID ;
      private short[] P00J43_A121RubrosId ;
      private long[] P00J43_A137MedidasID ;
      private long[] P00J43_A135InventarioId ;
      private short[] P00J43_A177SolicitudesItemsCantidad ;
      private short[] P00J43_A134SolicitudesItemsID ;
      private SdtSDTASolicitudes_Items AV15SolicitudesDatosItem ;
      private long aP1_ProveedorID ;
      private SdtSDTASolicitudes aP2_SolicitudesDatos ;
   }

   public class obtenerdatostoupdatesol__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00J42;
          prmP00J42 = new Object[] {
          new ParDef("@AV8SolicitudId",GXType.Decimal,18,0)
          };
          Object[] prmP00J43;
          prmP00J43 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J42", "SELECT [SolicitudesID], [ProveedorID], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [DepartamentoId], [DepartamentoMunicipioId], [SolicitudesDireccion], [SolicitudesDescuento], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [ProveedorNombreAux] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00J43", "SELECT [SolicitudesID], [RubrosId], [MedidasID], [InventarioId], [SolicitudesItemsCantidad], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J43,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 1);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
