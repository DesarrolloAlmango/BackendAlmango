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
   public class oconsumoproductivo : GXProcedure
   {
      public oconsumoproductivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oconsumoproductivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_DepartamentoId ,
                           short aP1_RubrosId ,
                           out GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> aP2_SDTConsumoProductivo )
      {
         this.AV23DepartamentoId = aP0_DepartamentoId;
         this.AV22RubrosId = aP1_RubrosId;
         this.AV20SDTConsumoProductivo = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP2_SDTConsumoProductivo=this.AV20SDTConsumoProductivo;
      }

      public GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> executeUdp( long aP0_DepartamentoId ,
                                                                                            short aP1_RubrosId )
      {
         execute(aP0_DepartamentoId, aP1_RubrosId, out aP2_SDTConsumoProductivo);
         return AV20SDTConsumoProductivo ;
      }

      public void executeSubmit( long aP0_DepartamentoId ,
                                 short aP1_RubrosId ,
                                 out GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> aP2_SDTConsumoProductivo )
      {
         this.AV23DepartamentoId = aP0_DepartamentoId;
         this.AV22RubrosId = aP1_RubrosId;
         this.AV20SDTConsumoProductivo = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX") ;
         SubmitImpl();
         aP2_SDTConsumoProductivo=this.AV20SDTConsumoProductivo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Count = 0;
         GXt_decimal1 = AV24CapacidadProductiva;
         new ocapacidadproductivaalmango(context ).execute(  AV23DepartamentoId,  AV22RubrosId, out  GXt_decimal1) ;
         AV24CapacidadProductiva = GXt_decimal1;
         if ( ( AV24CapacidadProductiva == Convert.ToDecimal( 0 )) )
         {
            AV24CapacidadProductiva = 0.001m;
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV23DepartamentoId ,
                                              AV22RubrosId ,
                                              A112DepartamentoId ,
                                              A121RubrosId ,
                                              A131EstadosSolId ,
                                              Gx_date } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00GB2 */
         pr_default.execute(0, new Object[] {Gx_date, AV23DepartamentoId, AV22RubrosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00GB2_A127SolicitudesID[0];
            A137MedidasID = P00GB2_A137MedidasID[0];
            A135InventarioId = P00GB2_A135InventarioId[0];
            A131EstadosSolId = P00GB2_A131EstadosSolId[0];
            A121RubrosId = P00GB2_A121RubrosId[0];
            A112DepartamentoId = P00GB2_A112DepartamentoId[0];
            n112DepartamentoId = P00GB2_n112DepartamentoId[0];
            A184SolicitudesFechaInstalacion = P00GB2_A184SolicitudesFechaInstalacion[0];
            A177SolicitudesItemsCantidad = P00GB2_A177SolicitudesItemsCantidad[0];
            A801InventarioConsumoProductivo = P00GB2_A801InventarioConsumoProductivo[0];
            A134SolicitudesItemsID = P00GB2_A134SolicitudesItemsID[0];
            A131EstadosSolId = P00GB2_A131EstadosSolId[0];
            A112DepartamentoId = P00GB2_A112DepartamentoId[0];
            n112DepartamentoId = P00GB2_n112DepartamentoId[0];
            A184SolicitudesFechaInstalacion = P00GB2_A184SolicitudesFechaInstalacion[0];
            A801InventarioConsumoProductivo = P00GB2_A801InventarioConsumoProductivo[0];
            if ( ( ( AV8Count >= 1 ) ) && ( ( DateTimeUtil.ResetTime ( AV14FechaInstalacionLast ) == DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) ) ) )
            {
               AV8Count = (short)(AV8Count+1);
               AV27GXV1 = 1;
               while ( AV27GXV1 <= AV20SDTConsumoProductivo.Count )
               {
                  AV21SDTConsumoProductivoItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV20SDTConsumoProductivo.Item(AV27GXV1));
                  if ( DateTimeUtil.ResetTime ( AV21SDTConsumoProductivoItem.gxTpr_Dia ) == DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) )
                  {
                     AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas = (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas+((A801InventarioConsumoProductivo*A177SolicitudesItemsCantidad)));
                     AV21SDTConsumoProductivoItem.gxTpr_Horasdisponiblesteoricas = (decimal)(AV24CapacidadProductiva-AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas);
                     if ( ((A131EstadosSolId==5)||(A131EstadosSolId==6)||(A131EstadosSolId==7)) )
                     {
                        AV21SDTConsumoProductivoItem.gxTpr_Horastomadas = (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horastomadas+((A801InventarioConsumoProductivo*A177SolicitudesItemsCantidad)));
                     }
                     AV21SDTConsumoProductivoItem.gxTpr_Porcentajetomadas = (decimal)((AV21SDTConsumoProductivoItem.gxTpr_Horastomadas/ (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas))*100);
                     if (true) break;
                  }
                  AV27GXV1 = (int)(AV27GXV1+1);
               }
               AV14FechaInstalacionLast = A184SolicitudesFechaInstalacion;
            }
            else
            {
               if ( AV8Count != 0 )
               {
                  AV8Count = 0;
               }
            }
            if ( AV8Count == 0 )
            {
               AV8Count = (short)(AV8Count+1);
               AV21SDTConsumoProductivoItem = new SdtSDTConsumoProductivo_SDTConsumoProductivoItem(context);
               AV21SDTConsumoProductivoItem.gxTpr_Dia = A184SolicitudesFechaInstalacion;
               AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas = (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas+((A801InventarioConsumoProductivo*A177SolicitudesItemsCantidad)));
               AV21SDTConsumoProductivoItem.gxTpr_Horasdisponiblesteoricas = (decimal)(AV24CapacidadProductiva-AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas);
               if ( ((A131EstadosSolId==5)||(A131EstadosSolId==6)||(A131EstadosSolId==7)) )
               {
                  AV21SDTConsumoProductivoItem.gxTpr_Horastomadas = (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horastomadas+((A801InventarioConsumoProductivo*A177SolicitudesItemsCantidad)));
               }
               AV21SDTConsumoProductivoItem.gxTpr_Porcentajetomadas = (decimal)((AV21SDTConsumoProductivoItem.gxTpr_Horastomadas/ (decimal)(AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas))*100);
               AV20SDTConsumoProductivo.Add(AV21SDTConsumoProductivoItem, 0);
               AV14FechaInstalacionLast = A184SolicitudesFechaInstalacion;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20SDTConsumoProductivo.Sort(context.GetMessage( "Dia", ""));
         if ( ! (0==AV23DepartamentoId) || ! (0==AV22RubrosId) )
         {
            AV28GXV2 = 1;
            while ( AV28GXV2 <= AV20SDTConsumoProductivo.Count )
            {
               AV21SDTConsumoProductivoItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV20SDTConsumoProductivo.Item(AV28GXV2));
               GXt_decimal1 = 0;
               new otiempoocupadoenotro(context ).execute(  AV21SDTConsumoProductivoItem.gxTpr_Dia,  AV23DepartamentoId,  AV22RubrosId, out  GXt_decimal1) ;
               AV21SDTConsumoProductivoItem.gxTpr_Tiempoenotros = GXt_decimal1;
               AV21SDTConsumoProductivoItem.gxTpr_Horasdisponibles = (decimal)(AV24CapacidadProductiva-AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas-AV21SDTConsumoProductivoItem.gxTpr_Tiempoenotros);
               AV21SDTConsumoProductivoItem.gxTpr_Porcentajesolicitado = (decimal)((AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas/ (decimal)((AV21SDTConsumoProductivoItem.gxTpr_Horasdisponibles+AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas)))*100);
               AV28GXV2 = (int)(AV28GXV2+1);
            }
         }
         else
         {
            AV29GXV3 = 1;
            while ( AV29GXV3 <= AV20SDTConsumoProductivo.Count )
            {
               AV21SDTConsumoProductivoItem = ((SdtSDTConsumoProductivo_SDTConsumoProductivoItem)AV20SDTConsumoProductivo.Item(AV29GXV3));
               AV21SDTConsumoProductivoItem.gxTpr_Horasdisponibles = AV21SDTConsumoProductivoItem.gxTpr_Horasdisponiblesteoricas;
               AV21SDTConsumoProductivoItem.gxTpr_Porcentajesolicitado = (decimal)((AV21SDTConsumoProductivoItem.gxTpr_Horassolicitadas/ (decimal)(AV24CapacidadProductiva))*100);
               AV29GXV3 = (int)(AV29GXV3+1);
            }
         }
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
         AV20SDTConsumoProductivo = new GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem>( context, "SDTConsumoProductivoItem", "AlmangoX");
         Gx_date = DateTime.MinValue;
         P00GB2_A127SolicitudesID = new long[1] ;
         P00GB2_A137MedidasID = new long[1] ;
         P00GB2_A135InventarioId = new long[1] ;
         P00GB2_A131EstadosSolId = new int[1] ;
         P00GB2_A121RubrosId = new short[1] ;
         P00GB2_A112DepartamentoId = new long[1] ;
         P00GB2_n112DepartamentoId = new bool[] {false} ;
         P00GB2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00GB2_A177SolicitudesItemsCantidad = new short[1] ;
         P00GB2_A801InventarioConsumoProductivo = new decimal[1] ;
         P00GB2_A134SolicitudesItemsID = new short[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         AV14FechaInstalacionLast = DateTime.MinValue;
         AV21SDTConsumoProductivoItem = new SdtSDTConsumoProductivo_SDTConsumoProductivoItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oconsumoproductivo__default(),
            new Object[][] {
                new Object[] {
               P00GB2_A127SolicitudesID, P00GB2_A137MedidasID, P00GB2_A135InventarioId, P00GB2_A131EstadosSolId, P00GB2_A121RubrosId, P00GB2_A112DepartamentoId, P00GB2_n112DepartamentoId, P00GB2_A184SolicitudesFechaInstalacion, P00GB2_A177SolicitudesItemsCantidad, P00GB2_A801InventarioConsumoProductivo,
               P00GB2_A134SolicitudesItemsID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV22RubrosId ;
      private short AV8Count ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private short A134SolicitudesItemsID ;
      private int A131EstadosSolId ;
      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private int AV29GXV3 ;
      private long AV23DepartamentoId ;
      private long A112DepartamentoId ;
      private long A127SolicitudesID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private decimal AV24CapacidadProductiva ;
      private decimal A801InventarioConsumoProductivo ;
      private decimal GXt_decimal1 ;
      private DateTime Gx_date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV14FechaInstalacionLast ;
      private bool n112DepartamentoId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> AV20SDTConsumoProductivo ;
      private IDataStoreProvider pr_default ;
      private long[] P00GB2_A127SolicitudesID ;
      private long[] P00GB2_A137MedidasID ;
      private long[] P00GB2_A135InventarioId ;
      private int[] P00GB2_A131EstadosSolId ;
      private short[] P00GB2_A121RubrosId ;
      private long[] P00GB2_A112DepartamentoId ;
      private bool[] P00GB2_n112DepartamentoId ;
      private DateTime[] P00GB2_A184SolicitudesFechaInstalacion ;
      private short[] P00GB2_A177SolicitudesItemsCantidad ;
      private decimal[] P00GB2_A801InventarioConsumoProductivo ;
      private short[] P00GB2_A134SolicitudesItemsID ;
      private SdtSDTConsumoProductivo_SDTConsumoProductivoItem AV21SDTConsumoProductivoItem ;
      private GXBaseCollection<SdtSDTConsumoProductivo_SDTConsumoProductivoItem> aP2_SDTConsumoProductivo ;
   }

   public class oconsumoproductivo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GB2( IGxContext context ,
                                             long AV23DepartamentoId ,
                                             short AV22RubrosId ,
                                             long A112DepartamentoId ,
                                             short A121RubrosId ,
                                             int A131EstadosSolId ,
                                             DateTime Gx_date )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesID], T1.[MedidasID], T1.[InventarioId], T2.[EstadosSolId], T1.[RubrosId], T2.[DepartamentoId], T2.[SolicitudesFechaInstalacion], T1.[SolicitudesItemsCantidad], T3.[InventarioConsumoProductivo], T1.[SolicitudesItemsID] FROM (([SolicitudesItems] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] >= @Gx_date)");
         AddWhere(sWhereString, "(Not T2.[EstadosSolId] = 3)");
         if ( ! (0==AV23DepartamentoId) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoId] = @AV23DepartamentoId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV22RubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] = @AV22RubrosId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[SolicitudesFechaInstalacion]";
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
                     return conditional_P00GB2(context, (long)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (short)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] );
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
          Object[] prmP00GB2;
          prmP00GB2 = new Object[] {
          new ParDef("@Gx_date",GXType.Date,8,0) ,
          new ParDef("@AV23DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV22RubrosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GB2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GB2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                return;
       }
    }

 }

}
