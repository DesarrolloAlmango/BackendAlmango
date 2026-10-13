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
   public class obtenerimagenproducto : GXProcedure
   {
      public obtenerimagenproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerimagenproducto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_RubroId ,
                           long aP1_CategoriaId ,
                           long aP2_ProductoId ,
                           out string aP3_ImageBase64 )
      {
         this.AV14RubroId = aP0_RubroId;
         this.AV13CategoriaId = aP1_CategoriaId;
         this.AV12ProductoId = aP2_ProductoId;
         this.AV9ImageBase64 = "" ;
         initialize();
         ExecutePrivate();
         aP3_ImageBase64=this.AV9ImageBase64;
      }

      public string executeUdp( long aP0_RubroId ,
                                long aP1_CategoriaId ,
                                long aP2_ProductoId )
      {
         execute(aP0_RubroId, aP1_CategoriaId, aP2_ProductoId, out aP3_ImageBase64);
         return AV9ImageBase64 ;
      }

      public void executeSubmit( long aP0_RubroId ,
                                 long aP1_CategoriaId ,
                                 long aP2_ProductoId ,
                                 out string aP3_ImageBase64 )
      {
         this.AV14RubroId = aP0_RubroId;
         this.AV13CategoriaId = aP1_CategoriaId;
         this.AV12ProductoId = aP2_ProductoId;
         this.AV9ImageBase64 = "" ;
         SubmitImpl();
         aP3_ImageBase64=this.AV9ImageBase64;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00NA2 */
         pr_default.execute(0, new Object[] {AV14RubroId, AV13CategoriaId, AV12ProductoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = P00NA2_A108EstadosGenericosId[0];
            A135InventarioId = P00NA2_A135InventarioId[0];
            A137MedidasID = P00NA2_A137MedidasID[0];
            A121RubrosId = P00NA2_A121RubrosId[0];
            A40000InventarioImagen_GXI = P00NA2_A40000InventarioImagen_GXI[0];
            A189InventarioImagen = P00NA2_A189InventarioImagen[0];
            AV11Imagen = A189InventarioImagen;
            AV9ImageBase64 = context.FileToBase64( AV11Imagen);
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
         AV9ImageBase64 = "";
         P00NA2_A108EstadosGenericosId = new int[1] ;
         P00NA2_A135InventarioId = new long[1] ;
         P00NA2_A137MedidasID = new long[1] ;
         P00NA2_A121RubrosId = new short[1] ;
         P00NA2_A40000InventarioImagen_GXI = new string[] {""} ;
         P00NA2_A189InventarioImagen = new string[] {""} ;
         A40000InventarioImagen_GXI = "";
         A189InventarioImagen = "";
         AV11Imagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerimagenproducto__default(),
            new Object[][] {
                new Object[] {
               P00NA2_A108EstadosGenericosId, P00NA2_A135InventarioId, P00NA2_A137MedidasID, P00NA2_A121RubrosId, P00NA2_A40000InventarioImagen_GXI, P00NA2_A189InventarioImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private int A108EstadosGenericosId ;
      private long AV14RubroId ;
      private long AV13CategoriaId ;
      private long AV12ProductoId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private string AV9ImageBase64 ;
      private string A40000InventarioImagen_GXI ;
      private string A189InventarioImagen ;
      private string AV11Imagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00NA2_A108EstadosGenericosId ;
      private long[] P00NA2_A135InventarioId ;
      private long[] P00NA2_A137MedidasID ;
      private short[] P00NA2_A121RubrosId ;
      private string[] P00NA2_A40000InventarioImagen_GXI ;
      private string[] P00NA2_A189InventarioImagen ;
      private string aP3_ImageBase64 ;
   }

   public class obtenerimagenproducto__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00NA2;
          prmP00NA2 = new Object[] {
          new ParDef("@AV14RubroId",GXType.Decimal,18,0) ,
          new ParDef("@AV13CategoriaId",GXType.Decimal,18,0) ,
          new ParDef("@AV12ProductoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NA2", "SELECT [EstadosGenericosId], [InventarioId], [MedidasID], [RubrosId], [InventarioImagen_GXI], [InventarioImagen] FROM [Inventario] WHERE ([RubrosId] = @AV14RubroId and [MedidasID] = @AV13CategoriaId and [InventarioId] = @AV12ProductoId) AND ([EstadosGenericosId] = 1) ORDER BY [RubrosId], [MedidasID], [InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NA2,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
                return;
       }
    }

 }

}
