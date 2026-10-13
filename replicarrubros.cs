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
   public class replicarrubros : GXProcedure
   {
      public replicarrubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public replicarrubros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorIdOrigen ,
                           long aP1_ProveedorIdDestino ,
                           out bool aP2_Exito )
      {
         this.AV12ProveedorIdOrigen = aP0_ProveedorIdOrigen;
         this.AV11ProveedorIdDestino = aP1_ProveedorIdDestino;
         this.AV10Exito = false ;
         initialize();
         ExecutePrivate();
         aP2_Exito=this.AV10Exito;
      }

      public bool executeUdp( long aP0_ProveedorIdOrigen ,
                              long aP1_ProveedorIdDestino )
      {
         execute(aP0_ProveedorIdOrigen, aP1_ProveedorIdDestino, out aP2_Exito);
         return AV10Exito ;
      }

      public void executeSubmit( long aP0_ProveedorIdOrigen ,
                                 long aP1_ProveedorIdDestino ,
                                 out bool aP2_Exito )
      {
         this.AV12ProveedorIdOrigen = aP0_ProveedorIdOrigen;
         this.AV11ProveedorIdDestino = aP1_ProveedorIdDestino;
         this.AV10Exito = false ;
         SubmitImpl();
         aP2_Exito=this.AV10Exito;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXLvl2 = 0;
         /* Using cursor P00N42 */
         pr_default.execute(0, new Object[] {AV11ProveedorIdDestino});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00N42_A133ProveedorID[0];
            AV14GXLvl2 = 1;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl2 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Proveedor

            */
            A133ProveedorID = AV11ProveedorIdDestino;
            A978ProveedorCIU = false;
            /* Using cursor P00N43 */
            pr_default.execute(1, new Object[] {A978ProveedorCIU});
            A133ProveedorID = P00N43_A133ProveedorID[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         /* Optimized DELETE. */
         /* Using cursor P00N44 */
         pr_default.execute(2, new Object[] {AV11ProveedorIdDestino});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("ComercioProductosRubros");
         /* End optimized DELETE. */
         AV13MaxID = 0;
         /* Using cursor P00N45 */
         pr_default.execute(3, new Object[] {AV12ProveedorIdOrigen});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A135InventarioId = P00N45_A135InventarioId[0];
            n135InventarioId = P00N45_n135InventarioId[0];
            A137MedidasID = P00N45_A137MedidasID[0];
            n137MedidasID = P00N45_n137MedidasID[0];
            A713ComercioProductosRubrosID = P00N45_A713ComercioProductosRubrosID[0];
            A133ProveedorID = P00N45_A133ProveedorID[0];
            A696ComercioRubrosInventarioActiva = P00N45_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = P00N45_n696ComercioRubrosInventarioActiva[0];
            A695ComercioItemsEstado = P00N45_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = P00N45_n695ComercioItemsEstado[0];
            A692ComercioRubrosEstado = P00N45_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = P00N45_n692ComercioRubrosEstado[0];
            A121RubrosId = P00N45_A121RubrosId[0];
            W133ProveedorID = A133ProveedorID;
            AV13MaxID = (long)(AV13MaxID+1);
            /*
               INSERT RECORD ON TABLE ComercioProductosRubros

            */
            W133ProveedorID = A133ProveedorID;
            W713ComercioProductosRubrosID = A713ComercioProductosRubrosID;
            W121RubrosId = A121RubrosId;
            W137MedidasID = A137MedidasID;
            n137MedidasID = false;
            W137MedidasID = A137MedidasID;
            n137MedidasID = false;
            W135InventarioId = A135InventarioId;
            n135InventarioId = false;
            W135InventarioId = A135InventarioId;
            n135InventarioId = false;
            W692ComercioRubrosEstado = A692ComercioRubrosEstado;
            n692ComercioRubrosEstado = false;
            W695ComercioItemsEstado = A695ComercioItemsEstado;
            n695ComercioItemsEstado = false;
            W696ComercioRubrosInventarioActiva = A696ComercioRubrosInventarioActiva;
            n696ComercioRubrosInventarioActiva = false;
            A133ProveedorID = AV11ProveedorIdDestino;
            A713ComercioProductosRubrosID = AV13MaxID;
            if ( (0==A121RubrosId) )
            {
            }
            if ( (0==A137MedidasID) )
            {
               A137MedidasID = 0;
               n137MedidasID = false;
               n137MedidasID = true;
            }
            else
            {
               n137MedidasID = false;
            }
            if ( (0==A135InventarioId) )
            {
               A135InventarioId = 0;
               n135InventarioId = false;
               n135InventarioId = true;
            }
            else
            {
               n135InventarioId = false;
            }
            n692ComercioRubrosEstado = false;
            n695ComercioItemsEstado = false;
            n696ComercioRubrosInventarioActiva = false;
            /* Using cursor P00N46 */
            pr_default.execute(4, new Object[] {A133ProveedorID, A713ComercioProductosRubrosID, A121RubrosId, n692ComercioRubrosEstado, A692ComercioRubrosEstado, n137MedidasID, A137MedidasID, n695ComercioItemsEstado, A695ComercioItemsEstado, n135InventarioId, A135InventarioId, n696ComercioRubrosInventarioActiva, A696ComercioRubrosInventarioActiva});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("ComercioProductosRubros");
            if ( (pr_default.getStatus(4) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            A133ProveedorID = W133ProveedorID;
            A713ComercioProductosRubrosID = W713ComercioProductosRubrosID;
            A121RubrosId = W121RubrosId;
            A137MedidasID = W137MedidasID;
            n137MedidasID = false;
            A137MedidasID = W137MedidasID;
            n137MedidasID = false;
            A135InventarioId = W135InventarioId;
            n135InventarioId = false;
            A135InventarioId = W135InventarioId;
            n135InventarioId = false;
            A692ComercioRubrosEstado = W692ComercioRubrosEstado;
            n692ComercioRubrosEstado = false;
            A695ComercioItemsEstado = W695ComercioItemsEstado;
            n695ComercioItemsEstado = false;
            A696ComercioRubrosInventarioActiva = W696ComercioRubrosInventarioActiva;
            n696ComercioRubrosInventarioActiva = false;
            /* End Insert */
            A133ProveedorID = W133ProveedorID;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV10Exito = true;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("replicarrubros",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00N42_A133ProveedorID = new long[1] ;
         P00N43_A133ProveedorID = new long[1] ;
         Gx_emsg = "";
         P00N45_A135InventarioId = new long[1] ;
         P00N45_n135InventarioId = new bool[] {false} ;
         P00N45_A137MedidasID = new long[1] ;
         P00N45_n137MedidasID = new bool[] {false} ;
         P00N45_A713ComercioProductosRubrosID = new long[1] ;
         P00N45_A133ProveedorID = new long[1] ;
         P00N45_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00N45_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00N45_A695ComercioItemsEstado = new bool[] {false} ;
         P00N45_n695ComercioItemsEstado = new bool[] {false} ;
         P00N45_A692ComercioRubrosEstado = new bool[] {false} ;
         P00N45_n692ComercioRubrosEstado = new bool[] {false} ;
         P00N45_A121RubrosId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.replicarrubros__default(),
            new Object[][] {
                new Object[] {
               P00N42_A133ProveedorID
               }
               , new Object[] {
               P00N43_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               P00N45_A135InventarioId, P00N45_n135InventarioId, P00N45_A137MedidasID, P00N45_n137MedidasID, P00N45_A713ComercioProductosRubrosID, P00N45_A133ProveedorID, P00N45_A696ComercioRubrosInventarioActiva, P00N45_n696ComercioRubrosInventarioActiva, P00N45_A695ComercioItemsEstado, P00N45_n695ComercioItemsEstado,
               P00N45_A692ComercioRubrosEstado, P00N45_n692ComercioRubrosEstado, P00N45_A121RubrosId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GXLvl2 ;
      private short A121RubrosId ;
      private short W121RubrosId ;
      private int GX_INS28 ;
      private int GX_INS116 ;
      private long AV12ProveedorIdOrigen ;
      private long AV11ProveedorIdDestino ;
      private long A133ProveedorID ;
      private long AV13MaxID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A713ComercioProductosRubrosID ;
      private long W133ProveedorID ;
      private long W713ComercioProductosRubrosID ;
      private long W137MedidasID ;
      private long W135InventarioId ;
      private string Gx_emsg ;
      private bool AV10Exito ;
      private bool A978ProveedorCIU ;
      private bool n135InventarioId ;
      private bool n137MedidasID ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool n696ComercioRubrosInventarioActiva ;
      private bool A695ComercioItemsEstado ;
      private bool n695ComercioItemsEstado ;
      private bool A692ComercioRubrosEstado ;
      private bool n692ComercioRubrosEstado ;
      private bool W692ComercioRubrosEstado ;
      private bool W695ComercioItemsEstado ;
      private bool W696ComercioRubrosInventarioActiva ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00N42_A133ProveedorID ;
      private long[] P00N43_A133ProveedorID ;
      private long[] P00N45_A135InventarioId ;
      private bool[] P00N45_n135InventarioId ;
      private long[] P00N45_A137MedidasID ;
      private bool[] P00N45_n137MedidasID ;
      private long[] P00N45_A713ComercioProductosRubrosID ;
      private long[] P00N45_A133ProveedorID ;
      private bool[] P00N45_A696ComercioRubrosInventarioActiva ;
      private bool[] P00N45_n696ComercioRubrosInventarioActiva ;
      private bool[] P00N45_A695ComercioItemsEstado ;
      private bool[] P00N45_n695ComercioItemsEstado ;
      private bool[] P00N45_A692ComercioRubrosEstado ;
      private bool[] P00N45_n692ComercioRubrosEstado ;
      private short[] P00N45_A121RubrosId ;
      private bool aP2_Exito ;
   }

   public class replicarrubros__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00N42;
          prmP00N42 = new Object[] {
          new ParDef("@AV11ProveedorIdDestino",GXType.Decimal,18,0)
          };
          Object[] prmP00N43;
          prmP00N43 = new Object[] {
          new ParDef("@ProveedorCIU",GXType.Boolean,4,0)
          };
          Object[] prmP00N44;
          prmP00N44 = new Object[] {
          new ParDef("@AV11ProveedorIdDestino",GXType.Decimal,18,0)
          };
          Object[] prmP00N45;
          prmP00N45 = new Object[] {
          new ParDef("@AV12ProveedorIdOrigen",GXType.Decimal,18,0)
          };
          Object[] prmP00N46;
          prmP00N46 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0) ,
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@ComercioRubrosEstado",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@ComercioItemsEstado",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@ComercioRubrosInventarioActiva",GXType.Boolean,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00N42", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @AV11ProveedorIdDestino ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00N43", "INSERT INTO [Proveedor]([ProveedorCIU], [ProveedoresTipoId], [ProveedorNombre], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorCuentaBancaria], [BancoId], [ComercioProductosREnum], [ProveedorFreezePrice]) VALUES(@ProveedorCIU, convert(int, 0), '', CONVERT(varbinary(1), ''), '', '', convert(int, 0), '', '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00N43,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00N44", "DELETE FROM [ComercioProductosRubros]  WHERE [ProveedorID] = @AV11ProveedorIdDestino", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00N44)
             ,new CursorDef("P00N45", "SELECT [InventarioId], [MedidasID], [ComercioProductosRubrosID], [ProveedorID], [ComercioRubrosInventarioActiva], [ComercioItemsEstado], [ComercioRubrosEstado], [RubrosId] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @AV12ProveedorIdOrigen ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00N46", "INSERT INTO [ComercioProductosRubros]([ProveedorID], [ComercioProductosRubrosID], [RubrosId], [ComercioRubrosEstado], [MedidasID], [ComercioItemsEstado], [InventarioId], [ComercioRubrosInventarioActiva]) VALUES(@ProveedorID, @ComercioProductosRubrosID, @RubrosId, @ComercioRubrosEstado, @MedidasID, @ComercioItemsEstado, @InventarioId, @ComercioRubrosInventarioActiva)", GxErrorMask.GX_NOMASK,prmP00N46)
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
