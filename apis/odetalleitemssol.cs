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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class odetalleitemssol : GXProcedure
   {
      public odetalleitemssol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odetalleitemssol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           long aP2_SolicitudesID ,
                           out GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ,
                           out bool aP4_TieneItems ,
                           out string aP5_RestMessage ,
                           out short aP6_Gx_restcode )
      {
         this.AV16User = aP0_User;
         this.AV17ProfesionalesId = aP1_ProfesionalesId;
         this.AV14SolicitudesID = aP2_SolicitudesID;
         this.AV13SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>( context, "SDTSolicitudes.Items", "AlmangoX") ;
         this.AV15TieneItems = false ;
         this.AV12RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_SdtItems=this.AV13SdtItems;
         aP4_TieneItems=this.AV15TieneItems;
         aP5_RestMessage=this.AV12RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               long aP2_SolicitudesID ,
                               out GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ,
                               out bool aP4_TieneItems ,
                               out string aP5_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_SolicitudesID, out aP3_SdtItems, out aP4_TieneItems, out aP5_RestMessage, out aP6_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_SolicitudesID ,
                                 out GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ,
                                 out bool aP4_TieneItems ,
                                 out string aP5_RestMessage ,
                                 out short aP6_Gx_restcode )
      {
         this.AV16User = aP0_User;
         this.AV17ProfesionalesId = aP1_ProfesionalesId;
         this.AV14SolicitudesID = aP2_SolicitudesID;
         this.AV13SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>( context, "SDTSolicitudes.Items", "AlmangoX") ;
         this.AV15TieneItems = false ;
         this.AV12RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_SdtItems=this.AV13SdtItems;
         aP4_TieneItems=this.AV15TieneItems;
         aP5_RestMessage=this.AV12RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV14SolicitudesID) || ( AV14SolicitudesID == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV16User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV17ProfesionalesId)) )
         {
            AV12RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            AV15TieneItems = false;
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         AV18TokenId = "";
         AV19IsOkToken = true;
         AV12RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV20HttpRequest,  AV16User,  AV17ProfesionalesId, out  AV18TokenId, out  AV19IsOkToken, out  Gx_restcode, out  AV12RestMessage) ;
         if ( ! AV19IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         AV15TieneItems = true;
         AV22GXLvl19 = 0;
         /* Using cursor P00JU2 */
         pr_default.execute(0, new Object[] {AV14SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135InventarioId = P00JU2_A135InventarioId[0];
            A127SolicitudesID = P00JU2_A127SolicitudesID[0];
            A134SolicitudesItemsID = P00JU2_A134SolicitudesItemsID[0];
            A177SolicitudesItemsCantidad = P00JU2_A177SolicitudesItemsCantidad[0];
            A121RubrosId = P00JU2_A121RubrosId[0];
            A122RubrosNombre = P00JU2_A122RubrosNombre[0];
            A40002RubrosImagen_GXI = P00JU2_A40002RubrosImagen_GXI[0];
            A40001InventarioImagen_GXI = P00JU2_A40001InventarioImagen_GXI[0];
            A136InventarioNombre = P00JU2_A136InventarioNombre[0];
            A137MedidasID = P00JU2_A137MedidasID[0];
            A138MedidasNombre = P00JU2_A138MedidasNombre[0];
            A150TextosId = P00JU2_A150TextosId[0];
            n150TextosId = P00JU2_n150TextosId[0];
            A259TextosTitulo = P00JU2_A259TextosTitulo[0];
            A257TextosDescripcion = P00JU2_A257TextosDescripcion[0];
            A535InventarioTextosId = P00JU2_A535InventarioTextosId[0];
            n535InventarioTextosId = P00JU2_n535InventarioTextosId[0];
            A168RubrosImagen = P00JU2_A168RubrosImagen[0];
            A189InventarioImagen = P00JU2_A189InventarioImagen[0];
            A122RubrosNombre = P00JU2_A122RubrosNombre[0];
            A40002RubrosImagen_GXI = P00JU2_A40002RubrosImagen_GXI[0];
            A168RubrosImagen = P00JU2_A168RubrosImagen[0];
            A138MedidasNombre = P00JU2_A138MedidasNombre[0];
            A150TextosId = P00JU2_A150TextosId[0];
            n150TextosId = P00JU2_n150TextosId[0];
            A259TextosTitulo = P00JU2_A259TextosTitulo[0];
            A257TextosDescripcion = P00JU2_A257TextosDescripcion[0];
            A40001InventarioImagen_GXI = P00JU2_A40001InventarioImagen_GXI[0];
            A136InventarioNombre = P00JU2_A136InventarioNombre[0];
            A535InventarioTextosId = P00JU2_A535InventarioTextosId[0];
            n535InventarioTextosId = P00JU2_n535InventarioTextosId[0];
            A189InventarioImagen = P00JU2_A189InventarioImagen[0];
            AV22GXLvl19 = 1;
            AV10Item = new SdtSDTSolicitudes_Items(context);
            AV10Item.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
            AV10Item.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
            AV10Item.gxTpr_Rubrosid = A121RubrosId;
            AV10Item.gxTpr_Rubrosnombre = A122RubrosNombre;
            AV9ImagenRubro = A168RubrosImagen;
            AV10Item.gxTpr_Rubrosimagen = context.FileToBase64( AV9ImagenRubro);
            AV8ImagenInventario = A189InventarioImagen;
            AV10Item.gxTpr_Inventarioimagen = context.FileToBase64( AV8ImagenInventario);
            AV10Item.gxTpr_Inventarionombre = A136InventarioNombre;
            AV10Item.gxTpr_Medidasid = A137MedidasID;
            AV10Item.gxTpr_Medidasnombre = A138MedidasNombre;
            AV10Item.gxTpr_Textosid = A150TextosId;
            AV10Item.gxTpr_Textostitulo = A259TextosTitulo;
            AV10Item.gxTpr_Textosdescripcion = A257TextosDescripcion;
            AV10Item.gxTpr_Inventariotextosid = A535InventarioTextosId;
            if ( ! (0==A535InventarioTextosId) )
            {
               AV10Item.gxTpr_Inventariotextosid = A535InventarioTextosId;
               /* Execute user subroutine: 'OBTENERDATOSTEXTO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            AV13SdtItems.Add(AV10Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV22GXLvl19 == 0 )
         {
            AV12RestMessage = context.GetMessage( "La solicitud no tiene items relacionados", "");
            AV15TieneItems = false;
            Gx_restcode = 200;
         }
         if ( AV15TieneItems )
         {
            AV12RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            Gx_restcode = 200;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENERDATOSTEXTO' Routine */
         returnInSub = false;
         /* Using cursor P00JU3 */
         pr_default.execute(1, new Object[] {AV10Item.gxTpr_Inventariotextosid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A150TextosId = P00JU3_A150TextosId[0];
            n150TextosId = P00JU3_n150TextosId[0];
            A257TextosDescripcion = P00JU3_A257TextosDescripcion[0];
            A259TextosTitulo = P00JU3_A259TextosTitulo[0];
            AV10Item.gxTpr_Inventariotextosdescripcion = A257TextosDescripcion;
            AV10Item.gxTpr_Inventariotextostitulo = A259TextosTitulo;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV13SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>( context, "SDTSolicitudes.Items", "AlmangoX");
         AV12RestMessage = "";
         AV18TokenId = "";
         AV20HttpRequest = new GxHttpRequest( context);
         P00JU2_A135InventarioId = new long[1] ;
         P00JU2_A127SolicitudesID = new long[1] ;
         P00JU2_A134SolicitudesItemsID = new short[1] ;
         P00JU2_A177SolicitudesItemsCantidad = new short[1] ;
         P00JU2_A121RubrosId = new short[1] ;
         P00JU2_A122RubrosNombre = new string[] {""} ;
         P00JU2_A40002RubrosImagen_GXI = new string[] {""} ;
         P00JU2_A40001InventarioImagen_GXI = new string[] {""} ;
         P00JU2_A136InventarioNombre = new string[] {""} ;
         P00JU2_A137MedidasID = new long[1] ;
         P00JU2_A138MedidasNombre = new string[] {""} ;
         P00JU2_A150TextosId = new long[1] ;
         P00JU2_n150TextosId = new bool[] {false} ;
         P00JU2_A259TextosTitulo = new string[] {""} ;
         P00JU2_A257TextosDescripcion = new string[] {""} ;
         P00JU2_A535InventarioTextosId = new long[1] ;
         P00JU2_n535InventarioTextosId = new bool[] {false} ;
         P00JU2_A168RubrosImagen = new string[] {""} ;
         P00JU2_A189InventarioImagen = new string[] {""} ;
         A122RubrosNombre = "";
         A40002RubrosImagen_GXI = "";
         A40001InventarioImagen_GXI = "";
         A136InventarioNombre = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         A257TextosDescripcion = "";
         A168RubrosImagen = "";
         A189InventarioImagen = "";
         AV10Item = new SdtSDTSolicitudes_Items(context);
         AV9ImagenRubro = "";
         AV8ImagenInventario = "";
         P00JU3_A150TextosId = new long[1] ;
         P00JU3_n150TextosId = new bool[] {false} ;
         P00JU3_A257TextosDescripcion = new string[] {""} ;
         P00JU3_A259TextosTitulo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.odetalleitemssol__default(),
            new Object[][] {
                new Object[] {
               P00JU2_A135InventarioId, P00JU2_A127SolicitudesID, P00JU2_A134SolicitudesItemsID, P00JU2_A177SolicitudesItemsCantidad, P00JU2_A121RubrosId, P00JU2_A122RubrosNombre, P00JU2_A40002RubrosImagen_GXI, P00JU2_A40001InventarioImagen_GXI, P00JU2_A136InventarioNombre, P00JU2_A137MedidasID,
               P00JU2_A138MedidasNombre, P00JU2_A150TextosId, P00JU2_n150TextosId, P00JU2_A259TextosTitulo, P00JU2_A257TextosDescripcion, P00JU2_A535InventarioTextosId, P00JU2_n535InventarioTextosId, P00JU2_A168RubrosImagen, P00JU2_A189InventarioImagen
               }
               , new Object[] {
               P00JU3_A150TextosId, P00JU3_A257TextosDescripcion, P00JU3_A259TextosTitulo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV22GXLvl19 ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
      private short A121RubrosId ;
      private long AV14SolicitudesID ;
      private long A135InventarioId ;
      private long A127SolicitudesID ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long A535InventarioTextosId ;
      private string AV16User ;
      private string AV17ProfesionalesId ;
      private string AV18TokenId ;
      private string A122RubrosNombre ;
      private string A136InventarioNombre ;
      private string A138MedidasNombre ;
      private string A259TextosTitulo ;
      private bool AV15TieneItems ;
      private bool AV19IsOkToken ;
      private bool n150TextosId ;
      private bool n535InventarioTextosId ;
      private bool returnInSub ;
      private string A257TextosDescripcion ;
      private string AV12RestMessage ;
      private string A40002RubrosImagen_GXI ;
      private string A40001InventarioImagen_GXI ;
      private string A168RubrosImagen ;
      private string A189InventarioImagen ;
      private string AV9ImagenRubro ;
      private string AV8ImagenInventario ;
      private GxHttpRequest AV20HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTSolicitudes_Items> AV13SdtItems ;
      private IDataStoreProvider pr_default ;
      private long[] P00JU2_A135InventarioId ;
      private long[] P00JU2_A127SolicitudesID ;
      private short[] P00JU2_A134SolicitudesItemsID ;
      private short[] P00JU2_A177SolicitudesItemsCantidad ;
      private short[] P00JU2_A121RubrosId ;
      private string[] P00JU2_A122RubrosNombre ;
      private string[] P00JU2_A40002RubrosImagen_GXI ;
      private string[] P00JU2_A40001InventarioImagen_GXI ;
      private string[] P00JU2_A136InventarioNombre ;
      private long[] P00JU2_A137MedidasID ;
      private string[] P00JU2_A138MedidasNombre ;
      private long[] P00JU2_A150TextosId ;
      private bool[] P00JU2_n150TextosId ;
      private string[] P00JU2_A259TextosTitulo ;
      private string[] P00JU2_A257TextosDescripcion ;
      private long[] P00JU2_A535InventarioTextosId ;
      private bool[] P00JU2_n535InventarioTextosId ;
      private string[] P00JU2_A168RubrosImagen ;
      private string[] P00JU2_A189InventarioImagen ;
      private SdtSDTSolicitudes_Items AV10Item ;
      private long[] P00JU3_A150TextosId ;
      private bool[] P00JU3_n150TextosId ;
      private string[] P00JU3_A257TextosDescripcion ;
      private string[] P00JU3_A259TextosTitulo ;
      private GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ;
      private bool aP4_TieneItems ;
      private string aP5_RestMessage ;
      private short aP6_Gx_restcode ;
   }

   public class odetalleitemssol__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JU2;
          prmP00JU2 = new Object[] {
          new ParDef("@AV14SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00JU3;
          prmP00JU3 = new Object[] {
          new ParDef("@AV10Item__Inventariotextosid",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JU2", "SELECT T1.[InventarioId], T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[RubrosId], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T5.[InventarioImagen_GXI], T5.[InventarioNombre], T1.[MedidasID], T3.[MedidasNombre], T3.[TextosId], T4.[TextosTitulo], T4.[TextosDescripcion], T5.[InventarioTextosId], T2.[RubrosImagen], T5.[InventarioImagen] FROM (((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId]) INNER JOIN [Inventario] T5 ON T5.[RubrosId] = T1.[RubrosId] AND T5.[MedidasID] = T1.[MedidasID] AND T5.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @AV14SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00JU3", "SELECT [TextosId], [TextosDescripcion], [TextosTitulo] FROM [Textos] WHERE [TextosId] = @AV10Item__Inventariotextosid ORDER BY [TextosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JU3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 50);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 80);
                ((string[]) buf[14])[0] = rslt.getLongVarchar(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                ((bool[]) buf[16])[0] = rslt.wasNull(15);
                ((string[]) buf[17])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(7));
                ((string[]) buf[18])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(8));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}
