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
   public class aobtenerprecio : GXProcedure
   {
      public aobtenerprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aobtenerprecio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           short aP1_RubrosId ,
                           long aP2_MedidasID ,
                           long aP3_InventarioId ,
                           out decimal aP4_Precio )
      {
         this.AV19ProveedorID = aP0_ProveedorID;
         this.AV17RubrosId = aP1_RubrosId;
         this.AV21MedidasID = aP2_MedidasID;
         this.AV22InventarioId = aP3_InventarioId;
         this.AV27Precio = 0 ;
         initialize();
         ExecutePrivate();
         aP4_Precio=this.AV27Precio;
      }

      public decimal executeUdp( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, out aP4_Precio);
         return AV27Precio ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 out decimal aP4_Precio )
      {
         this.AV19ProveedorID = aP0_ProveedorID;
         this.AV17RubrosId = aP1_RubrosId;
         this.AV21MedidasID = aP2_MedidasID;
         this.AV22InventarioId = aP3_InventarioId;
         this.AV27Precio = 0 ;
         SubmitImpl();
         aP4_Precio=this.AV27Precio;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H22 */
         pr_default.execute(0, new Object[] {AV19ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A344ProveedorEstado = P00H22_A344ProveedorEstado[0];
            A133ProveedorID = P00H22_A133ProveedorID[0];
            if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV20ProvedorOK = context.GetMessage( "S", "");
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV20ProvedorOK, context.GetMessage( "S", "")) == 0 )
         {
            /* Using cursor P00H23 */
            pr_default.execute(1, new Object[] {AV17RubrosId, AV21MedidasID, AV22InventarioId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A135InventarioId = P00H23_A135InventarioId[0];
               A137MedidasID = P00H23_A137MedidasID[0];
               A121RubrosId = P00H23_A121RubrosId[0];
               A139MedidasEstado = P00H23_A139MedidasEstado[0];
               n139MedidasEstado = P00H23_n139MedidasEstado[0];
               A108EstadosGenericosId = P00H23_A108EstadosGenericosId[0];
               A107EstadosTipo = P00H23_A107EstadosTipo[0];
               A118MonedaId = P00H23_A118MonedaId[0];
               A181InventarioPrecioFinal = P00H23_A181InventarioPrecioFinal[0];
               A139MedidasEstado = P00H23_A139MedidasEstado[0];
               n139MedidasEstado = P00H23_n139MedidasEstado[0];
               A118MonedaId = P00H23_A118MonedaId[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "INV", "")) == 0 )
               {
                  new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  0,  0, out  AV10ok) ;
                  if ( AV10ok )
                  {
                     new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  0, out  AV10ok) ;
                     if ( AV10ok )
                     {
                        new orubroitemactivo(context ).execute(  AV19ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV10ok) ;
                     }
                  }
                  if ( AV10ok )
                  {
                     new oprecprov(context ).execute(  AV19ProveedorID,  AV17RubrosId,  AV21MedidasID,  AV22InventarioId,  A118MonedaId, out  AV24SolicitudItemsComision, out  AV25SolicitudItemsSR, out  AV26SolicitudItemsComisionTipo, out  AV30PrecioFinal, out  AV28Freezar) ;
                     AV29InventarioPrecioFinal = ((AV28Freezar) ? AV30PrecioFinal : A181InventarioPrecioFinal);
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25SolicitudItemsSR)) || ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
                     {
                        AV27Precio = AV29InventarioPrecioFinal;
                     }
                     if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        AV27Precio = (decimal)((AV29InventarioPrecioFinal)-(AV24SolicitudItemsComision));
                     }
                     if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        AV27Precio = (decimal)((AV29InventarioPrecioFinal)+(AV24SolicitudItemsComision));
                     }
                     if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        AV27Precio = (decimal)((AV29InventarioPrecioFinal)-((AV29InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                     }
                     if ( ( StringUtil.StrCmp(AV26SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(AV25SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        AV27Precio = (decimal)((AV29InventarioPrecioFinal)+((AV29InventarioPrecioFinal)*(AV24SolicitudItemsComision/ (decimal)(100))));
                     }
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
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
         P00H22_A344ProveedorEstado = new string[] {""} ;
         P00H22_A133ProveedorID = new long[1] ;
         A344ProveedorEstado = "";
         AV20ProvedorOK = "";
         P00H23_A135InventarioId = new long[1] ;
         P00H23_A137MedidasID = new long[1] ;
         P00H23_A121RubrosId = new short[1] ;
         P00H23_A139MedidasEstado = new string[] {""} ;
         P00H23_n139MedidasEstado = new bool[] {false} ;
         P00H23_A108EstadosGenericosId = new int[1] ;
         P00H23_A107EstadosTipo = new string[] {""} ;
         P00H23_A118MonedaId = new short[1] ;
         P00H23_A181InventarioPrecioFinal = new decimal[1] ;
         A139MedidasEstado = "";
         A107EstadosTipo = "";
         AV25SolicitudItemsSR = "";
         AV26SolicitudItemsComisionTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aobtenerprecio__default(),
            new Object[][] {
                new Object[] {
               P00H22_A344ProveedorEstado, P00H22_A133ProveedorID
               }
               , new Object[] {
               P00H23_A135InventarioId, P00H23_A137MedidasID, P00H23_A121RubrosId, P00H23_A139MedidasEstado, P00H23_n139MedidasEstado, P00H23_A108EstadosGenericosId, P00H23_A107EstadosTipo, P00H23_A118MonedaId, P00H23_A181InventarioPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17RubrosId ;
      private short A121RubrosId ;
      private short A118MonedaId ;
      private int A108EstadosGenericosId ;
      private long AV19ProveedorID ;
      private long AV21MedidasID ;
      private long AV22InventarioId ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private decimal AV27Precio ;
      private decimal A181InventarioPrecioFinal ;
      private decimal AV24SolicitudItemsComision ;
      private decimal AV30PrecioFinal ;
      private decimal AV29InventarioPrecioFinal ;
      private string A344ProveedorEstado ;
      private string AV20ProvedorOK ;
      private string A139MedidasEstado ;
      private string A107EstadosTipo ;
      private string AV25SolicitudItemsSR ;
      private string AV26SolicitudItemsComisionTipo ;
      private bool n139MedidasEstado ;
      private bool AV10ok ;
      private bool AV28Freezar ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00H22_A344ProveedorEstado ;
      private long[] P00H22_A133ProveedorID ;
      private long[] P00H23_A135InventarioId ;
      private long[] P00H23_A137MedidasID ;
      private short[] P00H23_A121RubrosId ;
      private string[] P00H23_A139MedidasEstado ;
      private bool[] P00H23_n139MedidasEstado ;
      private int[] P00H23_A108EstadosGenericosId ;
      private string[] P00H23_A107EstadosTipo ;
      private short[] P00H23_A118MonedaId ;
      private decimal[] P00H23_A181InventarioPrecioFinal ;
      private decimal aP4_Precio ;
   }

   public class aobtenerprecio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H22;
          prmP00H22 = new Object[] {
          new ParDef("@AV19ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00H23;
          prmP00H23 = new Object[] {
          new ParDef("@AV17RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV21MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV22InventarioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H22", "SELECT [ProveedorEstado], [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV19ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H23", "SELECT T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T2.[MedidasEstado], T1.[EstadosGenericosId], T1.[EstadosTipo], T2.[MonedaId], T1.[InventarioPrecioFinal] FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) WHERE (T1.[RubrosId] = @AV17RubrosId and T1.[MedidasID] = @AV21MedidasID and T1.[InventarioId] = @AV22InventarioId) AND (T1.[EstadosGenericosId] = 1) AND (T2.[MedidasEstado] = 'HAB') ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H23,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
