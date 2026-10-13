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
   public class desasignarprofesional : GXProcedure
   {
      public desasignarprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public desasignarprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesID )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00KG2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128MetodoPagosID = P00KG2_A128MetodoPagosID[0];
            A142EstadoSGId = P00KG2_A142EstadoSGId[0];
            A107EstadosTipo = P00KG2_A107EstadosTipo[0];
            A127SolicitudesID = P00KG2_A127SolicitudesID[0];
            A140RelacionesId = P00KG2_A140RelacionesId[0];
            A128MetodoPagosID = P00KG2_A128MetodoPagosID[0];
            A107EstadosTipo = P00KG2_A107EstadosTipo[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               A142EstadoSGId = 2;
               /* Using cursor P00KG3 */
               pr_default.execute(1, new Object[] {A142EstadoSGId, A127SolicitudesID, A140RelacionesId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         n528SolicitudServicioComProvP = false;
         n527SolicitudServicioComProv = false;
         n532SolicitudServicioComALMP = false;
         n530SolicitudServicioComALM = false;
         /* Optimized UPDATE. */
         /* Using cursor P00KG4 */
         pr_default.execute(2, new Object[] {AV8SolicitudesID});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("desasignarprofesional",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00KG2_A128MetodoPagosID = new long[1] ;
         P00KG2_A142EstadoSGId = new int[1] ;
         P00KG2_A107EstadosTipo = new string[] {""} ;
         P00KG2_A127SolicitudesID = new long[1] ;
         P00KG2_A140RelacionesId = new long[1] ;
         A107EstadosTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.desasignarprofesional__default(),
            new Object[][] {
                new Object[] {
               P00KG2_A128MetodoPagosID, P00KG2_A142EstadoSGId, P00KG2_A107EstadosTipo, P00KG2_A127SolicitudesID, P00KG2_A140RelacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A142EstadoSGId ;
      private long AV8SolicitudesID ;
      private long A128MetodoPagosID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string A107EstadosTipo ;
      private bool n528SolicitudServicioComProvP ;
      private bool n527SolicitudServicioComProv ;
      private bool n532SolicitudServicioComALMP ;
      private bool n530SolicitudServicioComALM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00KG2_A128MetodoPagosID ;
      private int[] P00KG2_A142EstadoSGId ;
      private string[] P00KG2_A107EstadosTipo ;
      private long[] P00KG2_A127SolicitudesID ;
      private long[] P00KG2_A140RelacionesId ;
   }

   public class desasignarprofesional__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00KG2;
          prmP00KG2 = new Object[] {
          new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00KG3;
          prmP00KG3 = new Object[] {
          new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@RelacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00KG4;
          prmP00KG4 = new Object[] {
          new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KG2", "SELECT T2.[MetodoPagosID], T1.[EstadoSGId], T3.[EstadosTipo], T1.[SolicitudesID], T1.[RelacionesId] FROM (([Relaciones] T1 WITH (UPDLOCK) INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [MetodoPagos] T3 ON T3.[MetodoPagosID] = T2.[MetodoPagosID]) WHERE (T1.[SolicitudesID] = @AV8SolicitudesID) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KG2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KG3", "UPDATE [Relaciones] SET [EstadoSGId]=@EstadoSGId  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00KG3)
             ,new CursorDef("P00KG4", "UPDATE [Solicitudes] SET [EstadosSolId]=1, [SolicitudServicioComProvP]=0, [SolicitudServicioComProv]=0, [SolicitudServicioComALMP]=0, [SolicitudServicioComALM]=0  WHERE [SolicitudesID] = @AV8SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00KG4)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
