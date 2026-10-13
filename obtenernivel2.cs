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
   public class obtenernivel2 : GXProcedure
   {
      public obtenernivel2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenernivel2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_Nivel0 ,
                           long aP1_Nivel1 ,
                           out GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection )
      {
         this.AV8Nivel0 = aP0_Nivel0;
         this.AV9Nivel1 = aP1_Nivel1;
         this.AV10Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP2_Nivel2SDTCollection=this.AV10Nivel2SDTCollection;
      }

      public GXBaseCollection<SdtNivel1SDTCollection> executeUdp( long aP0_Nivel0 ,
                                                                  long aP1_Nivel1 )
      {
         execute(aP0_Nivel0, aP1_Nivel1, out aP2_Nivel2SDTCollection);
         return AV10Nivel2SDTCollection ;
      }

      public void executeSubmit( long aP0_Nivel0 ,
                                 long aP1_Nivel1 ,
                                 out GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection )
      {
         this.AV8Nivel0 = aP0_Nivel0;
         this.AV9Nivel1 = aP1_Nivel1;
         this.AV10Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX") ;
         SubmitImpl();
         aP2_Nivel2SDTCollection=this.AV10Nivel2SDTCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13ProveedorID = 1001;
         /* Using cursor P00H12 */
         pr_default.execute(0, new Object[] {AV8Nivel0, AV9Nivel1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = P00H12_A108EstadosGenericosId[0];
            A137MedidasID = P00H12_A137MedidasID[0];
            A121RubrosId = P00H12_A121RubrosId[0];
            A135InventarioId = P00H12_A135InventarioId[0];
            A136InventarioNombre = P00H12_A136InventarioNombre[0];
            A118MonedaId = P00H12_A118MonedaId[0];
            A40000InventarioImagen_GXI = P00H12_A40000InventarioImagen_GXI[0];
            A535InventarioTextosId = P00H12_A535InventarioTextosId[0];
            n535InventarioTextosId = P00H12_n535InventarioTextosId[0];
            A150TextosId = P00H12_A150TextosId[0];
            n150TextosId = P00H12_n150TextosId[0];
            A189InventarioImagen = P00H12_A189InventarioImagen[0];
            A118MonedaId = P00H12_A118MonedaId[0];
            A150TextosId = P00H12_A150TextosId[0];
            n150TextosId = P00H12_n150TextosId[0];
            AV11Nivel2SDTCollectionItem = new SdtNivel1SDTCollection(context);
            AV11Nivel2SDTCollectionItem.gxTpr_Id = A135InventarioId;
            AV11Nivel2SDTCollectionItem.gxTpr_Name = A136InventarioNombre;
            AV11Nivel2SDTCollectionItem.gxTpr_Monedaid = A118MonedaId;
            AV14Imagen = A189InventarioImagen;
            AV11Nivel2SDTCollectionItem.gxTpr_Image = context.FileToBase64( AV14Imagen);
            GXt_decimal1 = 0;
            new obtenerprecio(context ).execute(  AV13ProveedorID,  (short)(AV8Nivel0),  AV9Nivel1,  A135InventarioId, out  GXt_decimal1) ;
            AV11Nivel2SDTCollectionItem.gxTpr_Price = GXt_decimal1;
            if ( (0==A535InventarioTextosId) )
            {
               AV11Nivel2SDTCollectionItem.gxTpr_Textosid = A150TextosId;
            }
            else
            {
               AV11Nivel2SDTCollectionItem.gxTpr_Textosid = A535InventarioTextosId;
            }
            AV10Nivel2SDTCollection.Add(AV11Nivel2SDTCollectionItem, 0);
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
         AV10Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX");
         P00H12_A108EstadosGenericosId = new int[1] ;
         P00H12_A137MedidasID = new long[1] ;
         P00H12_A121RubrosId = new short[1] ;
         P00H12_A135InventarioId = new long[1] ;
         P00H12_A136InventarioNombre = new string[] {""} ;
         P00H12_A118MonedaId = new short[1] ;
         P00H12_A40000InventarioImagen_GXI = new string[] {""} ;
         P00H12_A535InventarioTextosId = new long[1] ;
         P00H12_n535InventarioTextosId = new bool[] {false} ;
         P00H12_A150TextosId = new long[1] ;
         P00H12_n150TextosId = new bool[] {false} ;
         P00H12_A189InventarioImagen = new string[] {""} ;
         A136InventarioNombre = "";
         A40000InventarioImagen_GXI = "";
         A189InventarioImagen = "";
         AV11Nivel2SDTCollectionItem = new SdtNivel1SDTCollection(context);
         AV14Imagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenernivel2__default(),
            new Object[][] {
                new Object[] {
               P00H12_A108EstadosGenericosId, P00H12_A137MedidasID, P00H12_A121RubrosId, P00H12_A135InventarioId, P00H12_A136InventarioNombre, P00H12_A118MonedaId, P00H12_A40000InventarioImagen_GXI, P00H12_A535InventarioTextosId, P00H12_n535InventarioTextosId, P00H12_A150TextosId,
               P00H12_n150TextosId, P00H12_A189InventarioImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private short A118MonedaId ;
      private int A108EstadosGenericosId ;
      private long AV8Nivel0 ;
      private long AV9Nivel1 ;
      private long AV13ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A535InventarioTextosId ;
      private long A150TextosId ;
      private decimal GXt_decimal1 ;
      private string A136InventarioNombre ;
      private bool n535InventarioTextosId ;
      private bool n150TextosId ;
      private string A40000InventarioImagen_GXI ;
      private string A189InventarioImagen ;
      private string AV14Imagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtNivel1SDTCollection> AV10Nivel2SDTCollection ;
      private IDataStoreProvider pr_default ;
      private int[] P00H12_A108EstadosGenericosId ;
      private long[] P00H12_A137MedidasID ;
      private short[] P00H12_A121RubrosId ;
      private long[] P00H12_A135InventarioId ;
      private string[] P00H12_A136InventarioNombre ;
      private short[] P00H12_A118MonedaId ;
      private string[] P00H12_A40000InventarioImagen_GXI ;
      private long[] P00H12_A535InventarioTextosId ;
      private bool[] P00H12_n535InventarioTextosId ;
      private long[] P00H12_A150TextosId ;
      private bool[] P00H12_n150TextosId ;
      private string[] P00H12_A189InventarioImagen ;
      private SdtNivel1SDTCollection AV11Nivel2SDTCollectionItem ;
      private GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection ;
   }

   public class obtenernivel2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H12;
          prmP00H12 = new Object[] {
          new ParDef("@AV8Nivel0",GXType.Decimal,18,0) ,
          new ParDef("@AV9Nivel1",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H12", "SELECT T1.[EstadosGenericosId], T1.[MedidasID], T1.[RubrosId], T1.[InventarioId], T1.[InventarioNombre], T2.[MonedaId], T1.[InventarioImagen_GXI], T1.[InventarioTextosId], T2.[TextosId], T1.[InventarioImagen] FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) WHERE (T1.[RubrosId] = @AV8Nivel0 and T1.[MedidasID] = @AV9Nivel1) AND (T1.[EstadosGenericosId] = 1) ORDER BY T1.[RubrosId], T1.[MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H12,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(7));
                return;
       }
    }

 }

}
