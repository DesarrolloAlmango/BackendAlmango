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
   public class resolverproductodesdesku : GXProcedure
   {
      public resolverproductodesdesku( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public resolverproductodesdesku( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EcommerceId ,
                           long aP1_ComercioId ,
                           string aP2_SkuExterno ,
                           out short aP3_RubrosId ,
                           out long aP4_MedidasId ,
                           out long aP5_InventarioId ,
                           out bool aP6_Error ,
                           ref string aP7_DebugLog )
      {
         this.AV10EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV15SkuExterno = aP2_SkuExterno;
         this.AV14RubrosId = 0 ;
         this.AV13MedidasId = 0 ;
         this.AV12InventarioId = 0 ;
         this.AV11Error = false ;
         this.AV9DebugLog = aP7_DebugLog;
         initialize();
         ExecutePrivate();
         aP3_RubrosId=this.AV14RubrosId;
         aP4_MedidasId=this.AV13MedidasId;
         aP5_InventarioId=this.AV12InventarioId;
         aP6_Error=this.AV11Error;
         aP7_DebugLog=this.AV9DebugLog;
      }

      public string executeUdp( long aP0_EcommerceId ,
                                long aP1_ComercioId ,
                                string aP2_SkuExterno ,
                                out short aP3_RubrosId ,
                                out long aP4_MedidasId ,
                                out long aP5_InventarioId ,
                                out bool aP6_Error )
      {
         execute(aP0_EcommerceId, aP1_ComercioId, aP2_SkuExterno, out aP3_RubrosId, out aP4_MedidasId, out aP5_InventarioId, out aP6_Error, ref aP7_DebugLog);
         return AV9DebugLog ;
      }

      public void executeSubmit( long aP0_EcommerceId ,
                                 long aP1_ComercioId ,
                                 string aP2_SkuExterno ,
                                 out short aP3_RubrosId ,
                                 out long aP4_MedidasId ,
                                 out long aP5_InventarioId ,
                                 out bool aP6_Error ,
                                 ref string aP7_DebugLog )
      {
         this.AV10EcommerceId = aP0_EcommerceId;
         this.AV8ComercioId = aP1_ComercioId;
         this.AV15SkuExterno = aP2_SkuExterno;
         this.AV14RubrosId = 0 ;
         this.AV13MedidasId = 0 ;
         this.AV12InventarioId = 0 ;
         this.AV11Error = false ;
         this.AV9DebugLog = aP7_DebugLog;
         SubmitImpl();
         aP3_RubrosId=this.AV14RubrosId;
         aP4_MedidasId=this.AV13MedidasId;
         aP5_InventarioId=this.AV12InventarioId;
         aP6_Error=this.AV11Error;
         aP7_DebugLog=this.AV9DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9DebugLog += context.GetMessage( "ResolverProductoDesdeInventario - SKU: ", "") + StringUtil.Trim( AV15SkuExterno) + StringUtil.NewLine( );
         AV11Error = true;
         AV14RubrosId = 0;
         AV13MedidasId = 0;
         AV12InventarioId = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15SkuExterno)) )
         {
            AV9DebugLog += context.GetMessage( "SKU vacío", "") + StringUtil.NewLine( );
            cleanup();
            if (true) return;
         }
         AV23LenSku = (short)(NumberUtil.Int( StringUtil.Len( StringUtil.Trim( AV15SkuExterno))));
         AV26Largo1 = (short)(AV23LenSku-3);
         AV20Texto = StringUtil.Substring( AV15SkuExterno, 4, AV26Largo1);
         AV24LenTexto = (short)(NumberUtil.Int( StringUtil.Len( AV20Texto)));
         AV21Pos1 = (short)(NumberUtil.Int( StringUtil.StringSearch( AV20Texto, "-", 1)));
         AV22Pos2 = (short)(NumberUtil.Int( StringUtil.StringSearch( AV20Texto, "-", AV21Pos1+1)));
         if ( ( AV21Pos1 == 0 ) || ( AV22Pos2 == 0 ) )
         {
            AV9DebugLog += context.GetMessage( "Formato SKU inválido (separadores)", "") + StringUtil.NewLine( );
            cleanup();
            if (true) return;
         }
         AV27LargoRubro = (short)(AV21Pos1-1);
         AV17RubroTxt = StringUtil.Substring( AV20Texto, 1, AV27LargoRubro);
         AV28DesdeMedida = (short)(AV21Pos1+1);
         AV29LargoMedida = (short)(AV22Pos2-AV21Pos1-1);
         AV18MedidaTxt = StringUtil.Substring( AV20Texto, AV28DesdeMedida, AV29LargoMedida);
         AV25LenInv = (short)(AV24LenTexto-AV22Pos2);
         AV30DesdeInv = (short)(AV22Pos2+1);
         AV19InventarioTxt = StringUtil.Substring( AV20Texto, AV30DesdeInv, AV25LenInv);
         AV14RubrosId = (short)(Math.Round(NumberUtil.Val( AV17RubroTxt, "."), 18, MidpointRounding.ToEven));
         AV13MedidasId = (long)(Math.Round(NumberUtil.Val( AV18MedidaTxt, "."), 18, MidpointRounding.ToEven));
         AV12InventarioId = (long)(Math.Round(NumberUtil.Val( AV19InventarioTxt, "."), 18, MidpointRounding.ToEven));
         AV9DebugLog += context.GetMessage( "IDs obtenidos ? ", "") + StringUtil.Str( (decimal)(AV14RubrosId), 4, 0) + " | " + StringUtil.Str( (decimal)(AV13MedidasId), 18, 0) + " | " + StringUtil.Str( (decimal)(AV12InventarioId), 18, 0) + StringUtil.NewLine( );
         /* Using cursor P00LL2 */
         pr_default.execute(0, new Object[] {AV14RubrosId, AV13MedidasId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A137MedidasID = P00LL2_A137MedidasID[0];
            A121RubrosId = P00LL2_A121RubrosId[0];
            AV9DebugLog += context.GetMessage( "Valores rubros y medidas: ", "") + StringUtil.Str( (decimal)(AV14RubrosId), 4, 0) + "-" + StringUtil.Str( (decimal)(AV13MedidasId), 18, 0) + StringUtil.NewLine( );
            /* Using cursor P00LL3 */
            pr_default.execute(1, new Object[] {A121RubrosId, A137MedidasID, AV12InventarioId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A135InventarioId = P00LL3_A135InventarioId[0];
               AV9DebugLog += context.GetMessage( "Referencia encontrada para SKU", "") + StringUtil.NewLine( );
               AV16Plog = new SdtPlog(context);
               AV16Plog.gxTpr_Plogmsg = context.GetMessage( "C", "")+StringUtil.Str( (decimal)(AV14RubrosId), 4, 0)+"-"+StringUtil.Str( (decimal)(AV13MedidasId), 18, 0);
               AV16Plog.gxTpr_Plogpgm = StringUtil.Str( (decimal)(AV12InventarioId), 18, 0);
               AV16Plog.Insert();
               context.CommitDataStores("resolverproductodesdesku",pr_default);
               if ( ( AV14RubrosId > 0 ) && ( AV13MedidasId > 0 ) && ( AV12InventarioId > 0 ) )
               {
                  AV11Error = false;
                  AV9DebugLog += context.GetMessage( "Producto resuelto OK ? ", "") + StringUtil.Str( (decimal)(AV14RubrosId), 4, 0) + " / " + StringUtil.Str( (decimal)(AV13MedidasId), 18, 0) + " / " + StringUtil.Str( (decimal)(AV12InventarioId), 18, 0) + StringUtil.NewLine( );
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
               else
               {
                  AV9DebugLog += context.GetMessage( "IDs inválidos en mapeo", "") + StringUtil.NewLine( );
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV9DebugLog += context.GetMessage( "No se encontró referencia para el SKU", "") + StringUtil.NewLine( );
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV9DebugLog += context.GetMessage( "No se encontró mapeo activo para comercio/proveedor", "") + StringUtil.NewLine( );
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
         AV20Texto = "";
         AV17RubroTxt = "";
         AV18MedidaTxt = "";
         AV19InventarioTxt = "";
         P00LL2_A137MedidasID = new long[1] ;
         P00LL2_A121RubrosId = new short[1] ;
         P00LL3_A121RubrosId = new short[1] ;
         P00LL3_A137MedidasID = new long[1] ;
         P00LL3_A135InventarioId = new long[1] ;
         AV16Plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.resolverproductodesdesku__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.resolverproductodesdesku__default(),
            new Object[][] {
                new Object[] {
               P00LL2_A137MedidasID, P00LL2_A121RubrosId
               }
               , new Object[] {
               P00LL3_A121RubrosId, P00LL3_A137MedidasID, P00LL3_A135InventarioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14RubrosId ;
      private short AV23LenSku ;
      private short AV26Largo1 ;
      private short AV24LenTexto ;
      private short AV21Pos1 ;
      private short AV22Pos2 ;
      private short AV27LargoRubro ;
      private short AV28DesdeMedida ;
      private short AV29LargoMedida ;
      private short AV25LenInv ;
      private short AV30DesdeInv ;
      private short A121RubrosId ;
      private long AV10EcommerceId ;
      private long AV8ComercioId ;
      private long AV13MedidasId ;
      private long AV12InventarioId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private string AV15SkuExterno ;
      private bool AV11Error ;
      private string AV9DebugLog ;
      private string AV20Texto ;
      private string AV17RubroTxt ;
      private string AV18MedidaTxt ;
      private string AV19InventarioTxt ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP7_DebugLog ;
      private IDataStoreProvider pr_default ;
      private long[] P00LL2_A137MedidasID ;
      private short[] P00LL2_A121RubrosId ;
      private short[] P00LL3_A121RubrosId ;
      private long[] P00LL3_A137MedidasID ;
      private long[] P00LL3_A135InventarioId ;
      private SdtPlog AV16Plog ;
      private short aP3_RubrosId ;
      private long aP4_MedidasId ;
      private long aP5_InventarioId ;
      private bool aP6_Error ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class resolverproductodesdesku__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class resolverproductodesdesku__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00LL2;
        prmP00LL2 = new Object[] {
        new ParDef("@AV14RubrosId",GXType.Int16,4,0) ,
        new ParDef("@AV13MedidasId",GXType.Decimal,18,0)
        };
        Object[] prmP00LL3;
        prmP00LL3 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@AV12InventarioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00LL2", "SELECT [MedidasID], [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @AV14RubrosId and [MedidasID] = @AV13MedidasId ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LL2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00LL3", "SELECT [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId and [MedidasID] = @MedidasID and [InventarioId] = @AV12InventarioId ORDER BY [RubrosId], [MedidasID], [InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LL3,1, GxCacheFrequency.OFF ,true,true )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
