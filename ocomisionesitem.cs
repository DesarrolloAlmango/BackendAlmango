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
   public class ocomisionesitem : GXProcedure
   {
      public ocomisionesitem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocomisionesitem( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComisionesTipo ,
                           string aP1_ProfesionalesId ,
                           long aP2_ProveedorID ,
                           short aP3_RubrosId ,
                           long aP4_MedidasID ,
                           long aP5_InventarioId ,
                           out bool aP6_ExiteEnInventario ,
                           out decimal aP7_ComisionesAgruparRubrosValor )
      {
         this.AV16ComisionesTipo = aP0_ComisionesTipo;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV11ProveedorID = aP2_ProveedorID;
         this.AV12RubrosId = aP3_RubrosId;
         this.AV9MedidasID = aP4_MedidasID;
         this.AV8InventarioId = aP5_InventarioId;
         this.AV23ExiteEnInventario = false ;
         this.AV13ComisionesAgruparRubrosValor = 0 ;
         initialize();
         ExecutePrivate();
         aP6_ExiteEnInventario=this.AV23ExiteEnInventario;
         aP7_ComisionesAgruparRubrosValor=this.AV13ComisionesAgruparRubrosValor;
      }

      public decimal executeUdp( string aP0_ComisionesTipo ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_ProveedorID ,
                                 short aP3_RubrosId ,
                                 long aP4_MedidasID ,
                                 long aP5_InventarioId ,
                                 out bool aP6_ExiteEnInventario )
      {
         execute(aP0_ComisionesTipo, aP1_ProfesionalesId, aP2_ProveedorID, aP3_RubrosId, aP4_MedidasID, aP5_InventarioId, out aP6_ExiteEnInventario, out aP7_ComisionesAgruparRubrosValor);
         return AV13ComisionesAgruparRubrosValor ;
      }

      public void executeSubmit( string aP0_ComisionesTipo ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_ProveedorID ,
                                 short aP3_RubrosId ,
                                 long aP4_MedidasID ,
                                 long aP5_InventarioId ,
                                 out bool aP6_ExiteEnInventario ,
                                 out decimal aP7_ComisionesAgruparRubrosValor )
      {
         this.AV16ComisionesTipo = aP0_ComisionesTipo;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV11ProveedorID = aP2_ProveedorID;
         this.AV12RubrosId = aP3_RubrosId;
         this.AV9MedidasID = aP4_MedidasID;
         this.AV8InventarioId = aP5_InventarioId;
         this.AV23ExiteEnInventario = false ;
         this.AV13ComisionesAgruparRubrosValor = 0 ;
         SubmitImpl();
         aP6_ExiteEnInventario=this.AV23ExiteEnInventario;
         aP7_ComisionesAgruparRubrosValor=this.AV13ComisionesAgruparRubrosValor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13ComisionesAgruparRubrosValor = 0;
         AV23ExiteEnInventario = false;
         /* Using cursor P008S2 */
         pr_default.execute(0, new Object[] {AV12RubrosId, AV9MedidasID, AV8InventarioId, AV16ComisionesTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135InventarioId = P008S2_A135InventarioId[0];
            n135InventarioId = P008S2_n135InventarioId[0];
            A137MedidasID = P008S2_A137MedidasID[0];
            n137MedidasID = P008S2_n137MedidasID[0];
            A121RubrosId = P008S2_A121RubrosId[0];
            A505ComisionesTipo = P008S2_A505ComisionesTipo[0];
            A503ComisionesID = P008S2_A503ComisionesID[0];
            A515ComisionesAgruparRubrosValor = P008S2_A515ComisionesAgruparRubrosValor[0];
            A513ComisionesAgruparRubrosId = P008S2_A513ComisionesAgruparRubrosId[0];
            A505ComisionesTipo = P008S2_A505ComisionesTipo[0];
            AV15ComisionesID = A503ComisionesID;
            /* Execute user subroutine: 'BUSCO VINCULO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            if ( ( AV21ExisteProveedor ) && ( AV22ExisteProfesional ) )
            {
               AV23ExiteEnInventario = true;
               AV13ComisionesAgruparRubrosValor = A515ComisionesAgruparRubrosValor;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCO VINCULO' Routine */
         returnInSub = false;
         /* Using cursor P008S3 */
         pr_default.execute(1, new Object[] {AV15ComisionesID, AV10ProfesionalesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A120ProfesionalesId = P008S3_A120ProfesionalesId[0];
            A503ComisionesID = P008S3_A503ComisionesID[0];
            AV22ExisteProfesional = true;
            /* Execute user subroutine: 'EXISTE PROVEEDOR' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( AV21ExisteProveedor )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S123( )
      {
         /* 'EXISTE PROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P008S4 */
         pr_default.execute(2, new Object[] {AV15ComisionesID, AV11ProveedorID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A133ProveedorID = P008S4_A133ProveedorID[0];
            A503ComisionesID = P008S4_A503ComisionesID[0];
            AV21ExisteProveedor = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P008S2_A135InventarioId = new long[1] ;
         P008S2_n135InventarioId = new bool[] {false} ;
         P008S2_A137MedidasID = new long[1] ;
         P008S2_n137MedidasID = new bool[] {false} ;
         P008S2_A121RubrosId = new short[1] ;
         P008S2_A505ComisionesTipo = new string[] {""} ;
         P008S2_A503ComisionesID = new long[1] ;
         P008S2_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         P008S2_A513ComisionesAgruparRubrosId = new long[1] ;
         A505ComisionesTipo = "";
         P008S3_A120ProfesionalesId = new string[] {""} ;
         P008S3_A503ComisionesID = new long[1] ;
         A120ProfesionalesId = "";
         P008S4_A133ProveedorID = new long[1] ;
         P008S4_A503ComisionesID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocomisionesitem__default(),
            new Object[][] {
                new Object[] {
               P008S2_A135InventarioId, P008S2_n135InventarioId, P008S2_A137MedidasID, P008S2_n137MedidasID, P008S2_A121RubrosId, P008S2_A505ComisionesTipo, P008S2_A503ComisionesID, P008S2_A515ComisionesAgruparRubrosValor, P008S2_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               P008S3_A120ProfesionalesId, P008S3_A503ComisionesID
               }
               , new Object[] {
               P008S4_A133ProveedorID, P008S4_A503ComisionesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12RubrosId ;
      private short A121RubrosId ;
      private long AV11ProveedorID ;
      private long AV9MedidasID ;
      private long AV8InventarioId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A503ComisionesID ;
      private long A513ComisionesAgruparRubrosId ;
      private long AV15ComisionesID ;
      private long A133ProveedorID ;
      private decimal AV13ComisionesAgruparRubrosValor ;
      private decimal A515ComisionesAgruparRubrosValor ;
      private string AV16ComisionesTipo ;
      private string AV10ProfesionalesId ;
      private string A505ComisionesTipo ;
      private string A120ProfesionalesId ;
      private bool AV23ExiteEnInventario ;
      private bool n135InventarioId ;
      private bool n137MedidasID ;
      private bool returnInSub ;
      private bool AV21ExisteProveedor ;
      private bool AV22ExisteProfesional ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008S2_A135InventarioId ;
      private bool[] P008S2_n135InventarioId ;
      private long[] P008S2_A137MedidasID ;
      private bool[] P008S2_n137MedidasID ;
      private short[] P008S2_A121RubrosId ;
      private string[] P008S2_A505ComisionesTipo ;
      private long[] P008S2_A503ComisionesID ;
      private decimal[] P008S2_A515ComisionesAgruparRubrosValor ;
      private long[] P008S2_A513ComisionesAgruparRubrosId ;
      private string[] P008S3_A120ProfesionalesId ;
      private long[] P008S3_A503ComisionesID ;
      private long[] P008S4_A133ProveedorID ;
      private long[] P008S4_A503ComisionesID ;
      private bool aP6_ExiteEnInventario ;
      private decimal aP7_ComisionesAgruparRubrosValor ;
   }

   public class ocomisionesitem__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008S2;
          prmP008S2 = new Object[] {
          new ParDef("@AV12RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV9MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV8InventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV16ComisionesTipo",GXType.NChar,1,0)
          };
          Object[] prmP008S3;
          prmP008S3 = new Object[] {
          new ParDef("@AV15ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP008S4;
          prmP008S4 = new Object[] {
          new ParDef("@AV15ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008S2", "SELECT T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T2.[ComisionesTipo], T1.[ComisionesID], T1.[ComisionesAgruparRubrosValor], T1.[ComisionesAgruparRubrosId] FROM ([ComisionesAgruparRubros] T1 INNER JOIN [Comisiones] T2 ON T2.[ComisionesID] = T1.[ComisionesID]) WHERE (T1.[RubrosId] = @AV12RubrosId and T1.[MedidasID] = @AV9MedidasID and T1.[InventarioId] = @AV8InventarioId) AND (T2.[ComisionesTipo] = @AV16ComisionesTipo) ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008S3", "SELECT [ProfesionalesId], [ComisionesID] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @AV15ComisionesID and [ProfesionalesId] = @AV10ProfesionalesId ORDER BY [ComisionesID], [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008S3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P008S4", "SELECT TOP 1 [ProveedorID], [ComisionesID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @AV15ComisionesID and [ProveedorID] = @AV11ProveedorID ORDER BY [ComisionesID], [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008S4,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 1);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
