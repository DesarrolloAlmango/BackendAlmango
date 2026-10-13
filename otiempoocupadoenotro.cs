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
   public class otiempoocupadoenotro : GXProcedure
   {
      public otiempoocupadoenotro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public otiempoocupadoenotro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           long aP1_DepartamentoId ,
                           short aP2_RubrosId ,
                           out decimal aP3_TiempoEnOtros )
      {
         this.AV12Date = aP0_Date;
         this.AV9DepartamentoId = aP1_DepartamentoId;
         this.AV8RubrosId = aP2_RubrosId;
         this.AV10TiempoEnOtros = 0 ;
         initialize();
         ExecutePrivate();
         aP3_TiempoEnOtros=this.AV10TiempoEnOtros;
      }

      public decimal executeUdp( DateTime aP0_Date ,
                                 long aP1_DepartamentoId ,
                                 short aP2_RubrosId )
      {
         execute(aP0_Date, aP1_DepartamentoId, aP2_RubrosId, out aP3_TiempoEnOtros);
         return AV10TiempoEnOtros ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 long aP1_DepartamentoId ,
                                 short aP2_RubrosId ,
                                 out decimal aP3_TiempoEnOtros )
      {
         this.AV12Date = aP0_Date;
         this.AV9DepartamentoId = aP1_DepartamentoId;
         this.AV8RubrosId = aP2_RubrosId;
         this.AV10TiempoEnOtros = 0 ;
         SubmitImpl();
         aP3_TiempoEnOtros=this.AV10TiempoEnOtros;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9DepartamentoId ,
                                              AV8RubrosId ,
                                              A112DepartamentoId ,
                                              A121RubrosId ,
                                              A131EstadosSolId ,
                                              AV12Date ,
                                              A184SolicitudesFechaInstalacion } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00GD2 */
         pr_default.execute(0, new Object[] {AV12Date, AV9DepartamentoId, AV8RubrosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00GD2_A127SolicitudesID[0];
            A137MedidasID = P00GD2_A137MedidasID[0];
            A135InventarioId = P00GD2_A135InventarioId[0];
            A184SolicitudesFechaInstalacion = P00GD2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00GD2_A131EstadosSolId[0];
            A121RubrosId = P00GD2_A121RubrosId[0];
            A112DepartamentoId = P00GD2_A112DepartamentoId[0];
            n112DepartamentoId = P00GD2_n112DepartamentoId[0];
            A177SolicitudesItemsCantidad = P00GD2_A177SolicitudesItemsCantidad[0];
            A801InventarioConsumoProductivo = P00GD2_A801InventarioConsumoProductivo[0];
            A134SolicitudesItemsID = P00GD2_A134SolicitudesItemsID[0];
            A184SolicitudesFechaInstalacion = P00GD2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00GD2_A131EstadosSolId[0];
            A112DepartamentoId = P00GD2_A112DepartamentoId[0];
            n112DepartamentoId = P00GD2_n112DepartamentoId[0];
            A801InventarioConsumoProductivo = P00GD2_A801InventarioConsumoProductivo[0];
            AV10TiempoEnOtros = (decimal)(AV10TiempoEnOtros+((A801InventarioConsumoProductivo*A177SolicitudesItemsCantidad)));
            pr_default.readNext(0);
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
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         P00GD2_A127SolicitudesID = new long[1] ;
         P00GD2_A137MedidasID = new long[1] ;
         P00GD2_A135InventarioId = new long[1] ;
         P00GD2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00GD2_A131EstadosSolId = new int[1] ;
         P00GD2_A121RubrosId = new short[1] ;
         P00GD2_A112DepartamentoId = new long[1] ;
         P00GD2_n112DepartamentoId = new bool[] {false} ;
         P00GD2_A177SolicitudesItemsCantidad = new short[1] ;
         P00GD2_A801InventarioConsumoProductivo = new decimal[1] ;
         P00GD2_A134SolicitudesItemsID = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.otiempoocupadoenotro__default(),
            new Object[][] {
                new Object[] {
               P00GD2_A127SolicitudesID, P00GD2_A137MedidasID, P00GD2_A135InventarioId, P00GD2_A184SolicitudesFechaInstalacion, P00GD2_A131EstadosSolId, P00GD2_A121RubrosId, P00GD2_A112DepartamentoId, P00GD2_n112DepartamentoId, P00GD2_A177SolicitudesItemsCantidad, P00GD2_A801InventarioConsumoProductivo,
               P00GD2_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8RubrosId ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private short A134SolicitudesItemsID ;
      private int A131EstadosSolId ;
      private long AV9DepartamentoId ;
      private long A112DepartamentoId ;
      private long A127SolicitudesID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private decimal AV10TiempoEnOtros ;
      private decimal A801InventarioConsumoProductivo ;
      private DateTime AV12Date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n112DepartamentoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GD2_A127SolicitudesID ;
      private long[] P00GD2_A137MedidasID ;
      private long[] P00GD2_A135InventarioId ;
      private DateTime[] P00GD2_A184SolicitudesFechaInstalacion ;
      private int[] P00GD2_A131EstadosSolId ;
      private short[] P00GD2_A121RubrosId ;
      private long[] P00GD2_A112DepartamentoId ;
      private bool[] P00GD2_n112DepartamentoId ;
      private short[] P00GD2_A177SolicitudesItemsCantidad ;
      private decimal[] P00GD2_A801InventarioConsumoProductivo ;
      private short[] P00GD2_A134SolicitudesItemsID ;
      private decimal aP3_TiempoEnOtros ;
   }

   public class otiempoocupadoenotro__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GD2( IGxContext context ,
                                             long AV9DepartamentoId ,
                                             short AV8RubrosId ,
                                             long A112DepartamentoId ,
                                             short A121RubrosId ,
                                             int A131EstadosSolId ,
                                             DateTime AV12Date ,
                                             DateTime A184SolicitudesFechaInstalacion )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesID], T1.[MedidasID], T1.[InventarioId], T2.[SolicitudesFechaInstalacion], T2.[EstadosSolId], T1.[RubrosId], T2.[DepartamentoId], T1.[SolicitudesItemsCantidad], T3.[InventarioConsumoProductivo], T1.[SolicitudesItemsID] FROM (([SolicitudesItems] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] = @AV12Date)");
         AddWhere(sWhereString, "(Not T2.[EstadosSolId] = 3)");
         if ( ! (0==AV9DepartamentoId) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoId] <> @AV9DepartamentoId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8RubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <> @AV8RubrosId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[SolicitudesFechaInstalacion]";
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
                     return conditional_P00GD2(context, (long)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (short)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GD2;
          prmP00GD2 = new Object[] {
          new ParDef("@AV12Date",GXType.Date,8,0) ,
          new ParDef("@AV9DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV8RubrosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
