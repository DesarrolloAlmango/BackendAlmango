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
   public class replicarprecios : GXProcedure
   {
      public replicarprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public replicarprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorId ,
                           long aP1_ComercioId ,
                           out bool aP2_Exito )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9ComercioId = aP1_ComercioId;
         this.AV17Exito = false ;
         initialize();
         ExecutePrivate();
         aP2_Exito=this.AV17Exito;
      }

      public bool executeUdp( long aP0_ProveedorId ,
                              long aP1_ComercioId )
      {
         execute(aP0_ProveedorId, aP1_ComercioId, out aP2_Exito);
         return AV17Exito ;
      }

      public void executeSubmit( long aP0_ProveedorId ,
                                 long aP1_ComercioId ,
                                 out bool aP2_Exito )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9ComercioId = aP1_ComercioId;
         this.AV17Exito = false ;
         SubmitImpl();
         aP2_Exito=this.AV17Exito;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Count = 0;
         /* Optimized DELETE. */
         /* Using cursor P00HG2 */
         pr_default.execute(0, new Object[] {AV9ComercioId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
         /* End optimized DELETE. */
         AV11Proveedor.Load(AV9ComercioId);
         /* Using cursor P00HG3 */
         pr_default.execute(1, new Object[] {AV8ProveedorId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A133ProveedorID = P00HG3_A133ProveedorID[0];
            A121RubrosId = P00HG3_A121RubrosId[0];
            A137MedidasID = P00HG3_A137MedidasID[0];
            A135InventarioId = P00HG3_A135InventarioId[0];
            n135InventarioId = P00HG3_n135InventarioId[0];
            A346ProveedorComisionTipo = P00HG3_A346ProveedorComisionTipo[0];
            A347ProveedorComision = P00HG3_A347ProveedorComision[0];
            A348ProveedorComisionAccion = P00HG3_A348ProveedorComisionAccion[0];
            A1001ProveedorComisionFP = P00HG3_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = P00HG3_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = P00HG3_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = P00HG3_n1000ProveedorComisionFPF[0];
            A157ProveedorComisionID = P00HG3_A157ProveedorComisionID[0];
            AV10Count = (short)(AV10Count+1);
            AV12ProveedorItem = new SdtProveedor_Comision(context);
            AV12ProveedorItem.gxTpr_Proveedorcomisionid = AV10Count;
            AV12ProveedorItem.gxTpr_Rubrosid = A121RubrosId;
            AV12ProveedorItem.gxTpr_Medidasid = A137MedidasID;
            AV12ProveedorItem.gxTpr_Inventarioid = A135InventarioId;
            AV12ProveedorItem.gxTpr_Proveedorcomisiontipo = A346ProveedorComisionTipo;
            AV12ProveedorItem.gxTpr_Proveedorcomision = A347ProveedorComision;
            AV12ProveedorItem.gxTpr_Proveedorcomisionaccion = A348ProveedorComisionAccion;
            AV12ProveedorItem.gxTpr_Proveedorcomisionfp = A1001ProveedorComisionFP;
            AV12ProveedorItem.gxTpr_Proveedorcomisionfpf = A1000ProveedorComisionFPF;
            AV11Proveedor.gxTpr_Comision.Add(AV12ProveedorItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV16SecUserId = AV15WWPContext.gxTpr_Userid;
         AV11Proveedor.Update();
         if ( AV11Proveedor.Success() )
         {
            AV14Plog = new SdtPlog(context);
            AV14Plog.gxTpr_Plogpgm = context.localUtil.DToC( Gx_date, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")+" "+AV21Pgmname;
            AV14Plog.gxTpr_Plogmsg = context.GetMessage( "Usuario: ", "")+StringUtil.Str( (decimal)(AV16SecUserId), 10, 0)+context.GetMessage( ", replica precios de ProveedorId: ", "")+StringUtil.Str( (decimal)(AV8ProveedorId), 18, 0)+context.GetMessage( " en ProveedorId: ", "")+StringUtil.Str( (decimal)(AV9ComercioId), 18, 0);
            AV14Plog.Insert();
            context.CommitDataStores("replicarprecios",pr_default);
            AV17Exito = true;
         }
         else
         {
            AV17Exito = false;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("replicarprecios",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Proveedor = new SdtProveedor(context);
         P00HG3_A133ProveedorID = new long[1] ;
         P00HG3_A121RubrosId = new short[1] ;
         P00HG3_A137MedidasID = new long[1] ;
         P00HG3_A135InventarioId = new long[1] ;
         P00HG3_n135InventarioId = new bool[] {false} ;
         P00HG3_A346ProveedorComisionTipo = new string[] {""} ;
         P00HG3_A347ProveedorComision = new decimal[1] ;
         P00HG3_A348ProveedorComisionAccion = new string[] {""} ;
         P00HG3_A1001ProveedorComisionFP = new bool[] {false} ;
         P00HG3_n1001ProveedorComisionFP = new bool[] {false} ;
         P00HG3_A1000ProveedorComisionFPF = new decimal[1] ;
         P00HG3_n1000ProveedorComisionFPF = new bool[] {false} ;
         P00HG3_A157ProveedorComisionID = new long[1] ;
         A346ProveedorComisionTipo = "";
         A348ProveedorComisionAccion = "";
         AV12ProveedorItem = new SdtProveedor_Comision(context);
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14Plog = new SdtPlog(context);
         Gx_date = DateTime.MinValue;
         AV21Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.replicarprecios__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.replicarprecios__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00HG3_A133ProveedorID, P00HG3_A121RubrosId, P00HG3_A137MedidasID, P00HG3_A135InventarioId, P00HG3_n135InventarioId, P00HG3_A346ProveedorComisionTipo, P00HG3_A347ProveedorComision, P00HG3_A348ProveedorComisionAccion, P00HG3_A1001ProveedorComisionFP, P00HG3_n1001ProveedorComisionFP,
               P00HG3_A1000ProveedorComisionFPF, P00HG3_n1000ProveedorComisionFPF, P00HG3_A157ProveedorComisionID
               }
            }
         );
         AV21Pgmname = "ReplicarPrecios";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV21Pgmname = "ReplicarPrecios";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV10Count ;
      private short A121RubrosId ;
      private long AV8ProveedorId ;
      private long AV9ComercioId ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A157ProveedorComisionID ;
      private long AV16SecUserId ;
      private decimal A347ProveedorComision ;
      private decimal A1000ProveedorComisionFPF ;
      private string A346ProveedorComisionTipo ;
      private string A348ProveedorComisionAccion ;
      private string AV21Pgmname ;
      private DateTime Gx_date ;
      private bool AV17Exito ;
      private bool n135InventarioId ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool n1000ProveedorComisionFPF ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private SdtProveedor AV11Proveedor ;
      private long[] P00HG3_A133ProveedorID ;
      private short[] P00HG3_A121RubrosId ;
      private long[] P00HG3_A137MedidasID ;
      private long[] P00HG3_A135InventarioId ;
      private bool[] P00HG3_n135InventarioId ;
      private string[] P00HG3_A346ProveedorComisionTipo ;
      private decimal[] P00HG3_A347ProveedorComision ;
      private string[] P00HG3_A348ProveedorComisionAccion ;
      private bool[] P00HG3_A1001ProveedorComisionFP ;
      private bool[] P00HG3_n1001ProveedorComisionFP ;
      private decimal[] P00HG3_A1000ProveedorComisionFPF ;
      private bool[] P00HG3_n1000ProveedorComisionFPF ;
      private long[] P00HG3_A157ProveedorComisionID ;
      private SdtProveedor_Comision AV12ProveedorItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private SdtPlog AV14Plog ;
      private bool aP2_Exito ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class replicarprecios__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class replicarprecios__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00HG2;
        prmP00HG2 = new Object[] {
        new ParDef("@AV9ComercioId",GXType.Decimal,18,0)
        };
        Object[] prmP00HG3;
        prmP00HG3 = new Object[] {
        new ParDef("@AV8ProveedorId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00HG2", "DELETE FROM [ProveedorComision]  WHERE [ProveedorID] = @AV9ComercioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00HG2)
           ,new CursorDef("P00HG3", "SELECT [ProveedorID], [RubrosId], [MedidasID], [InventarioId], [ProveedorComisionTipo], [ProveedorComision], [ProveedorComisionAccion], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @AV8ProveedorId ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HG3,100, GxCacheFrequency.OFF ,false,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 1);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((long[]) buf[12])[0] = rslt.getLong(10);
              return;
     }
  }

}

}
