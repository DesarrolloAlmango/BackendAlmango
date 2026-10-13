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
   public class solicitudtienerelacion : GXProcedure
   {
      public solicitudtienerelacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudtienerelacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out bool aP1_Boolean )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Boolean = false ;
         initialize();
         ExecutePrivate();
         aP1_Boolean=this.AV9Boolean;
      }

      public bool executeUdp( long aP0_SolicitudesId )
      {
         execute(aP0_SolicitudesId, out aP1_Boolean);
         return AV9Boolean ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out bool aP1_Boolean )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Boolean = false ;
         SubmitImpl();
         aP1_Boolean=this.AV9Boolean;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Boolean = false;
         /* Using cursor P00KF2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A128MetodoPagosID = P00KF2_A128MetodoPagosID[0];
            A142EstadoSGId = P00KF2_A142EstadoSGId[0];
            A107EstadosTipo = P00KF2_A107EstadosTipo[0];
            A127SolicitudesID = P00KF2_A127SolicitudesID[0];
            A140RelacionesId = P00KF2_A140RelacionesId[0];
            A128MetodoPagosID = P00KF2_A128MetodoPagosID[0];
            A107EstadosTipo = P00KF2_A107EstadosTipo[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV9Boolean = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
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
         P00KF2_A128MetodoPagosID = new long[1] ;
         P00KF2_A142EstadoSGId = new int[1] ;
         P00KF2_A107EstadosTipo = new string[] {""} ;
         P00KF2_A127SolicitudesID = new long[1] ;
         P00KF2_A140RelacionesId = new long[1] ;
         A107EstadosTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudtienerelacion__default(),
            new Object[][] {
                new Object[] {
               P00KF2_A128MetodoPagosID, P00KF2_A142EstadoSGId, P00KF2_A107EstadosTipo, P00KF2_A127SolicitudesID, P00KF2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A142EstadoSGId ;
      private long AV8SolicitudesId ;
      private long A128MetodoPagosID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string A107EstadosTipo ;
      private bool AV9Boolean ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00KF2_A128MetodoPagosID ;
      private int[] P00KF2_A142EstadoSGId ;
      private string[] P00KF2_A107EstadosTipo ;
      private long[] P00KF2_A127SolicitudesID ;
      private long[] P00KF2_A140RelacionesId ;
      private bool aP1_Boolean ;
   }

   public class solicitudtienerelacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00KF2;
          prmP00KF2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KF2", "SELECT T2.[MetodoPagosID], T1.[EstadoSGId], T3.[EstadosTipo], T1.[SolicitudesID], T1.[RelacionesId] FROM (([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [MetodoPagos] T3 ON T3.[MetodoPagosID] = T2.[MetodoPagosID]) WHERE (T1.[SolicitudesID] = @AV8SolicitudesId) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KF2,100, GxCacheFrequency.OFF ,false,false )
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
