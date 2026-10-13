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
   public class ocomiprof : GXProcedure
   {
      public ocomiprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocomiprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_proveedorid ,
                           string aP1_ProfesionalesId ,
                           short aP2_RubrosId ,
                           long aP3_MedidasID ,
                           long aP4_InventarioId ,
                           out string aP5_ProfComisionesRubrosTipo ,
                           out decimal aP6_ProfComisionesRubrosValor ,
                           out long aP7_ProfComisionesRubrosGanPRF ,
                           out long aP8_ProfComisionesRubrosGan )
      {
         this.AV17proveedorid = aP0_proveedorid;
         this.AV14ProfesionalesId = aP1_ProfesionalesId;
         this.AV12RubrosId = aP2_RubrosId;
         this.AV15MedidasID = aP3_MedidasID;
         this.AV13InventarioId = aP4_InventarioId;
         this.AV10ProfComisionesRubrosTipo = "" ;
         this.AV11ProfComisionesRubrosValor = 0 ;
         this.AV8ProfComisionesRubrosGanPRF = 0 ;
         this.AV9ProfComisionesRubrosGan = 0 ;
         initialize();
         ExecutePrivate();
         aP5_ProfComisionesRubrosTipo=this.AV10ProfComisionesRubrosTipo;
         aP6_ProfComisionesRubrosValor=this.AV11ProfComisionesRubrosValor;
         aP7_ProfComisionesRubrosGanPRF=this.AV8ProfComisionesRubrosGanPRF;
         aP8_ProfComisionesRubrosGan=this.AV9ProfComisionesRubrosGan;
      }

      public long executeUdp( long aP0_proveedorid ,
                              string aP1_ProfesionalesId ,
                              short aP2_RubrosId ,
                              long aP3_MedidasID ,
                              long aP4_InventarioId ,
                              out string aP5_ProfComisionesRubrosTipo ,
                              out decimal aP6_ProfComisionesRubrosValor ,
                              out long aP7_ProfComisionesRubrosGanPRF )
      {
         execute(aP0_proveedorid, aP1_ProfesionalesId, aP2_RubrosId, aP3_MedidasID, aP4_InventarioId, out aP5_ProfComisionesRubrosTipo, out aP6_ProfComisionesRubrosValor, out aP7_ProfComisionesRubrosGanPRF, out aP8_ProfComisionesRubrosGan);
         return AV9ProfComisionesRubrosGan ;
      }

      public void executeSubmit( long aP0_proveedorid ,
                                 string aP1_ProfesionalesId ,
                                 short aP2_RubrosId ,
                                 long aP3_MedidasID ,
                                 long aP4_InventarioId ,
                                 out string aP5_ProfComisionesRubrosTipo ,
                                 out decimal aP6_ProfComisionesRubrosValor ,
                                 out long aP7_ProfComisionesRubrosGanPRF ,
                                 out long aP8_ProfComisionesRubrosGan )
      {
         this.AV17proveedorid = aP0_proveedorid;
         this.AV14ProfesionalesId = aP1_ProfesionalesId;
         this.AV12RubrosId = aP2_RubrosId;
         this.AV15MedidasID = aP3_MedidasID;
         this.AV13InventarioId = aP4_InventarioId;
         this.AV10ProfComisionesRubrosTipo = "" ;
         this.AV11ProfComisionesRubrosValor = 0 ;
         this.AV8ProfComisionesRubrosGanPRF = 0 ;
         this.AV9ProfComisionesRubrosGan = 0 ;
         SubmitImpl();
         aP5_ProfComisionesRubrosTipo=this.AV10ProfComisionesRubrosTipo;
         aP6_ProfComisionesRubrosValor=this.AV11ProfComisionesRubrosValor;
         aP7_ProfComisionesRubrosGanPRF=this.AV8ProfComisionesRubrosGanPRF;
         aP8_ProfComisionesRubrosGan=this.AV9ProfComisionesRubrosGan;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008M2 */
         pr_default.execute(0, new Object[] {AV12RubrosId, AV15MedidasID, AV13InventarioId, AV14ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A450ProfComisionesID = P008M2_A450ProfComisionesID[0];
            A133ProveedorID = P008M2_A133ProveedorID[0];
            n133ProveedorID = P008M2_n133ProveedorID[0];
            A135InventarioId = P008M2_A135InventarioId[0];
            A137MedidasID = P008M2_A137MedidasID[0];
            A121RubrosId = P008M2_A121RubrosId[0];
            A120ProfesionalesId = P008M2_A120ProfesionalesId[0];
            A181InventarioPrecioFinal = P008M2_A181InventarioPrecioFinal[0];
            A453ProfComisionesRubrosTipo = P008M2_A453ProfComisionesRubrosTipo[0];
            A454ProfComisionesRubrosValor = P008M2_A454ProfComisionesRubrosValor[0];
            A452ProfComisionesRubrosId = P008M2_A452ProfComisionesRubrosId[0];
            A120ProfesionalesId = P008M2_A120ProfesionalesId[0];
            A181InventarioPrecioFinal = P008M2_A181InventarioPrecioFinal[0];
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
               }
               else
               {
                  A457ProfComisionesRubrosGanPRF = 0;
               }
            }
            A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
            if ( ( A133ProveedorID == AV17proveedorid ) || ( AV17proveedorid == 0 ) )
            {
               AV10ProfComisionesRubrosTipo = A453ProfComisionesRubrosTipo;
               AV11ProfComisionesRubrosValor = A454ProfComisionesRubrosValor;
               AV8ProfComisionesRubrosGanPRF = A457ProfComisionesRubrosGanPRF;
               AV9ProfComisionesRubrosGan = A456ProfComisionesRubrosGan;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( AV11ProfComisionesRubrosValor == Convert.ToDecimal( 0 )) )
         {
            /* Using cursor P008M3 */
            pr_default.execute(1, new Object[] {AV12RubrosId, AV15MedidasID, AV13InventarioId, AV14ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A450ProfComisionesID = P008M3_A450ProfComisionesID[0];
               A135InventarioId = P008M3_A135InventarioId[0];
               A137MedidasID = P008M3_A137MedidasID[0];
               A121RubrosId = P008M3_A121RubrosId[0];
               A120ProfesionalesId = P008M3_A120ProfesionalesId[0];
               A133ProveedorID = P008M3_A133ProveedorID[0];
               n133ProveedorID = P008M3_n133ProveedorID[0];
               A181InventarioPrecioFinal = P008M3_A181InventarioPrecioFinal[0];
               A453ProfComisionesRubrosTipo = P008M3_A453ProfComisionesRubrosTipo[0];
               A454ProfComisionesRubrosValor = P008M3_A454ProfComisionesRubrosValor[0];
               A452ProfComisionesRubrosId = P008M3_A452ProfComisionesRubrosId[0];
               A120ProfesionalesId = P008M3_A120ProfesionalesId[0];
               A181InventarioPrecioFinal = P008M3_A181InventarioPrecioFinal[0];
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
                  {
                     A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
                  }
                  else
                  {
                     A457ProfComisionesRubrosGanPRF = 0;
                  }
               }
               A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
               if ( A133ProveedorID == 0 )
               {
                  AV10ProfComisionesRubrosTipo = A453ProfComisionesRubrosTipo;
                  AV11ProfComisionesRubrosValor = A454ProfComisionesRubrosValor;
                  AV8ProfComisionesRubrosGanPRF = A457ProfComisionesRubrosGanPRF;
                  AV9ProfComisionesRubrosGan = A456ProfComisionesRubrosGan;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( ( AV11ProfComisionesRubrosValor == Convert.ToDecimal( 0 )) )
         {
            /* Execute user subroutine: 'COSTO POR DEFECTO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'COSTO POR DEFECTO' Routine */
         returnInSub = false;
         /* Using cursor P008M4 */
         pr_default.execute(2, new Object[] {AV12RubrosId, AV15MedidasID, AV13InventarioId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A135InventarioId = P008M4_A135InventarioId[0];
            A137MedidasID = P008M4_A137MedidasID[0];
            A121RubrosId = P008M4_A121RubrosId[0];
            A190InventarioCosto = P008M4_A190InventarioCosto[0];
            A181InventarioPrecioFinal = P008M4_A181InventarioPrecioFinal[0];
            AV10ProfComisionesRubrosTipo = context.GetMessage( "F", "");
            AV11ProfComisionesRubrosValor = A190InventarioCosto;
            AV8ProfComisionesRubrosGanPRF = (long)(Math.Round(AV11ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
            AV9ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-AV8ProfComisionesRubrosGanPRF);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV10ProfComisionesRubrosTipo = "";
         P008M2_A450ProfComisionesID = new long[1] ;
         P008M2_A133ProveedorID = new long[1] ;
         P008M2_n133ProveedorID = new bool[] {false} ;
         P008M2_A135InventarioId = new long[1] ;
         P008M2_A137MedidasID = new long[1] ;
         P008M2_A121RubrosId = new short[1] ;
         P008M2_A120ProfesionalesId = new string[] {""} ;
         P008M2_A181InventarioPrecioFinal = new decimal[1] ;
         P008M2_A453ProfComisionesRubrosTipo = new string[] {""} ;
         P008M2_A454ProfComisionesRubrosValor = new decimal[1] ;
         P008M2_A452ProfComisionesRubrosId = new long[1] ;
         A120ProfesionalesId = "";
         A453ProfComisionesRubrosTipo = "";
         P008M3_A450ProfComisionesID = new long[1] ;
         P008M3_A135InventarioId = new long[1] ;
         P008M3_A137MedidasID = new long[1] ;
         P008M3_A121RubrosId = new short[1] ;
         P008M3_A120ProfesionalesId = new string[] {""} ;
         P008M3_A133ProveedorID = new long[1] ;
         P008M3_n133ProveedorID = new bool[] {false} ;
         P008M3_A181InventarioPrecioFinal = new decimal[1] ;
         P008M3_A453ProfComisionesRubrosTipo = new string[] {""} ;
         P008M3_A454ProfComisionesRubrosValor = new decimal[1] ;
         P008M3_A452ProfComisionesRubrosId = new long[1] ;
         P008M4_A135InventarioId = new long[1] ;
         P008M4_A137MedidasID = new long[1] ;
         P008M4_A121RubrosId = new short[1] ;
         P008M4_A190InventarioCosto = new decimal[1] ;
         P008M4_A181InventarioPrecioFinal = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocomiprof__default(),
            new Object[][] {
                new Object[] {
               P008M2_A450ProfComisionesID, P008M2_A133ProveedorID, P008M2_n133ProveedorID, P008M2_A135InventarioId, P008M2_A137MedidasID, P008M2_A121RubrosId, P008M2_A120ProfesionalesId, P008M2_A181InventarioPrecioFinal, P008M2_A453ProfComisionesRubrosTipo, P008M2_A454ProfComisionesRubrosValor,
               P008M2_A452ProfComisionesRubrosId
               }
               , new Object[] {
               P008M3_A450ProfComisionesID, P008M3_A135InventarioId, P008M3_A137MedidasID, P008M3_A121RubrosId, P008M3_A120ProfesionalesId, P008M3_A133ProveedorID, P008M3_n133ProveedorID, P008M3_A181InventarioPrecioFinal, P008M3_A453ProfComisionesRubrosTipo, P008M3_A454ProfComisionesRubrosValor,
               P008M3_A452ProfComisionesRubrosId
               }
               , new Object[] {
               P008M4_A135InventarioId, P008M4_A137MedidasID, P008M4_A121RubrosId, P008M4_A190InventarioCosto, P008M4_A181InventarioPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12RubrosId ;
      private short A121RubrosId ;
      private long AV17proveedorid ;
      private long AV15MedidasID ;
      private long AV13InventarioId ;
      private long AV8ProfComisionesRubrosGanPRF ;
      private long AV9ProfComisionesRubrosGan ;
      private long A450ProfComisionesID ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A452ProfComisionesRubrosId ;
      private long A457ProfComisionesRubrosGanPRF ;
      private long A456ProfComisionesRubrosGan ;
      private decimal AV11ProfComisionesRubrosValor ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A454ProfComisionesRubrosValor ;
      private decimal A190InventarioCosto ;
      private string AV14ProfesionalesId ;
      private string AV10ProfComisionesRubrosTipo ;
      private string A120ProfesionalesId ;
      private string A453ProfComisionesRubrosTipo ;
      private bool n133ProveedorID ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008M2_A450ProfComisionesID ;
      private long[] P008M2_A133ProveedorID ;
      private bool[] P008M2_n133ProveedorID ;
      private long[] P008M2_A135InventarioId ;
      private long[] P008M2_A137MedidasID ;
      private short[] P008M2_A121RubrosId ;
      private string[] P008M2_A120ProfesionalesId ;
      private decimal[] P008M2_A181InventarioPrecioFinal ;
      private string[] P008M2_A453ProfComisionesRubrosTipo ;
      private decimal[] P008M2_A454ProfComisionesRubrosValor ;
      private long[] P008M2_A452ProfComisionesRubrosId ;
      private long[] P008M3_A450ProfComisionesID ;
      private long[] P008M3_A135InventarioId ;
      private long[] P008M3_A137MedidasID ;
      private short[] P008M3_A121RubrosId ;
      private string[] P008M3_A120ProfesionalesId ;
      private long[] P008M3_A133ProveedorID ;
      private bool[] P008M3_n133ProveedorID ;
      private decimal[] P008M3_A181InventarioPrecioFinal ;
      private string[] P008M3_A453ProfComisionesRubrosTipo ;
      private decimal[] P008M3_A454ProfComisionesRubrosValor ;
      private long[] P008M3_A452ProfComisionesRubrosId ;
      private long[] P008M4_A135InventarioId ;
      private long[] P008M4_A137MedidasID ;
      private short[] P008M4_A121RubrosId ;
      private decimal[] P008M4_A190InventarioCosto ;
      private decimal[] P008M4_A181InventarioPrecioFinal ;
      private string aP5_ProfComisionesRubrosTipo ;
      private decimal aP6_ProfComisionesRubrosValor ;
      private long aP7_ProfComisionesRubrosGanPRF ;
      private long aP8_ProfComisionesRubrosGan ;
   }

   public class ocomiprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008M2;
          prmP008M2 = new Object[] {
          new ParDef("@AV12RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV15MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV13InventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV14ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP008M3;
          prmP008M3 = new Object[] {
          new ParDef("@AV12RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV15MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV13InventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV14ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP008M4;
          prmP008M4 = new Object[] {
          new ParDef("@AV12RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV15MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV13InventarioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008M2", "SELECT T1.[ProfComisionesID], T1.[ProveedorID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T2.[ProfesionalesId], T3.[InventarioPrecioFinal], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor], T1.[ProfComisionesRubrosId] FROM (([ProfComisionesRubros] T1 INNER JOIN [ProfComisiones] T2 ON T2.[ProfComisionesID] = T1.[ProfComisionesID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId]) WHERE (T1.[RubrosId] = @AV12RubrosId) AND (T1.[MedidasID] = @AV15MedidasID or T1.[MedidasID] = 0) AND (T1.[InventarioId] = @AV13InventarioId or T1.[InventarioId] = 0) AND (T1.[ProveedorID] > 0) AND (T2.[ProfesionalesId] = @AV14ProfesionalesId) ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008M3", "SELECT T1.[ProfComisionesID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T2.[ProfesionalesId], T1.[ProveedorID], T3.[InventarioPrecioFinal], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor], T1.[ProfComisionesRubrosId] FROM (([ProfComisionesRubros] T1 INNER JOIN [ProfComisiones] T2 ON T2.[ProfComisionesID] = T1.[ProfComisionesID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId]) WHERE (T1.[RubrosId] = @AV12RubrosId) AND (T1.[MedidasID] = @AV15MedidasID or T1.[MedidasID] = 0) AND (T1.[InventarioId] = @AV13InventarioId or T1.[InventarioId] = 0) AND (T2.[ProfesionalesId] = @AV14ProfesionalesId) ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008M4", "SELECT TOP 1 [InventarioId], [MedidasID], [RubrosId], [InventarioCosto], [InventarioPrecioFinal] FROM [Inventario] WHERE ([RubrosId] = @AV12RubrosId) AND ([MedidasID] = @AV15MedidasID or [MedidasID] = 0) AND ([InventarioId] = @AV13InventarioId or [InventarioId] = 0) ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M4,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
       }
    }

 }

}
