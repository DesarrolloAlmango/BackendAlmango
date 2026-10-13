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
   public class obtenernivel1 : GXProcedure
   {
      public obtenernivel1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenernivel1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_Nivel0 ,
                           out GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection )
      {
         this.AV8Nivel0 = aP0_Nivel0;
         this.AV10Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP1_Nivel1SDTCollection=this.AV10Nivel1SDTCollection;
      }

      public GXBaseCollection<SdtNivel1SDTCollection> executeUdp( long aP0_Nivel0 )
      {
         execute(aP0_Nivel0, out aP1_Nivel1SDTCollection);
         return AV10Nivel1SDTCollection ;
      }

      public void executeSubmit( long aP0_Nivel0 ,
                                 out GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection )
      {
         this.AV8Nivel0 = aP0_Nivel0;
         this.AV10Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX") ;
         SubmitImpl();
         aP1_Nivel1SDTCollection=this.AV10Nivel1SDTCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H02 */
         pr_default.execute(0, new Object[] {AV8Nivel0});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139MedidasEstado = P00H02_A139MedidasEstado[0];
            n139MedidasEstado = P00H02_n139MedidasEstado[0];
            A121RubrosId = P00H02_A121RubrosId[0];
            A137MedidasID = P00H02_A137MedidasID[0];
            A138MedidasNombre = P00H02_A138MedidasNombre[0];
            A40000MedidasImagen_GXI = P00H02_A40000MedidasImagen_GXI[0];
            n40000MedidasImagen_GXI = P00H02_n40000MedidasImagen_GXI[0];
            A842MedidasImagen = P00H02_A842MedidasImagen[0];
            n842MedidasImagen = P00H02_n842MedidasImagen[0];
            if ( StringUtil.StrCmp(A139MedidasEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV9Nivel1SDTCollectionItem = new SdtNivel1SDTCollection(context);
               AV9Nivel1SDTCollectionItem.gxTpr_Id = A137MedidasID;
               AV9Nivel1SDTCollectionItem.gxTpr_Name = A138MedidasNombre;
               AV11Imagen = A842MedidasImagen;
               AV9Nivel1SDTCollectionItem.gxTpr_Image = context.FileToBase64( AV11Imagen);
               AV10Nivel1SDTCollection.Add(AV9Nivel1SDTCollectionItem, 0);
            }
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
         AV10Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX");
         P00H02_A139MedidasEstado = new string[] {""} ;
         P00H02_n139MedidasEstado = new bool[] {false} ;
         P00H02_A121RubrosId = new short[1] ;
         P00H02_A137MedidasID = new long[1] ;
         P00H02_A138MedidasNombre = new string[] {""} ;
         P00H02_A40000MedidasImagen_GXI = new string[] {""} ;
         P00H02_n40000MedidasImagen_GXI = new bool[] {false} ;
         P00H02_A842MedidasImagen = new string[] {""} ;
         P00H02_n842MedidasImagen = new bool[] {false} ;
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         A40000MedidasImagen_GXI = "";
         A842MedidasImagen = "";
         AV9Nivel1SDTCollectionItem = new SdtNivel1SDTCollection(context);
         AV11Imagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenernivel1__default(),
            new Object[][] {
                new Object[] {
               P00H02_A139MedidasEstado, P00H02_n139MedidasEstado, P00H02_A121RubrosId, P00H02_A137MedidasID, P00H02_A138MedidasNombre, P00H02_A40000MedidasImagen_GXI, P00H02_n40000MedidasImagen_GXI, P00H02_A842MedidasImagen, P00H02_n842MedidasImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private long AV8Nivel0 ;
      private long A137MedidasID ;
      private string A139MedidasEstado ;
      private string A138MedidasNombre ;
      private bool n139MedidasEstado ;
      private bool n40000MedidasImagen_GXI ;
      private bool n842MedidasImagen ;
      private string A40000MedidasImagen_GXI ;
      private string A842MedidasImagen ;
      private string AV11Imagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtNivel1SDTCollection> AV10Nivel1SDTCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P00H02_A139MedidasEstado ;
      private bool[] P00H02_n139MedidasEstado ;
      private short[] P00H02_A121RubrosId ;
      private long[] P00H02_A137MedidasID ;
      private string[] P00H02_A138MedidasNombre ;
      private string[] P00H02_A40000MedidasImagen_GXI ;
      private bool[] P00H02_n40000MedidasImagen_GXI ;
      private string[] P00H02_A842MedidasImagen ;
      private bool[] P00H02_n842MedidasImagen ;
      private SdtNivel1SDTCollection AV9Nivel1SDTCollectionItem ;
      private GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection ;
   }

   public class obtenernivel1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H02;
          prmP00H02 = new Object[] {
          new ParDef("@AV8Nivel0",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H02", "SELECT [MedidasEstado], [RubrosId], [MedidasID], [MedidasNombre], [MedidasImagen_GXI], [MedidasImagen] FROM [RubrosMedidas] WHERE [RubrosId] = @AV8Nivel0 ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H02,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
