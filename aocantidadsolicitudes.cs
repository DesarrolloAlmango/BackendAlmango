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
   public class aocantidadsolicitudes : GXProcedure
   {
      public aocantidadsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aocantidadsolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out short aP1_Cantidad )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV8Cantidad = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Cantidad=this.AV8Cantidad;
      }

      public short executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_Cantidad);
         return AV8Cantidad ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out short aP1_Cantidad )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV8Cantidad = 0 ;
         SubmitImpl();
         aP1_Cantidad=this.AV8Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Cantidad = 0;
         /* Using cursor P00AA2 */
         pr_default.execute(0, new Object[] {AV9ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00AA2_A127SolicitudesID[0];
            A131EstadosSolId = P00AA2_A131EstadosSolId[0];
            A130EstadosSolTipo = P00AA2_A130EstadosSolTipo[0];
            A120ProfesionalesId = P00AA2_A120ProfesionalesId[0];
            A140RelacionesId = P00AA2_A140RelacionesId[0];
            A131EstadosSolId = P00AA2_A131EstadosSolId[0];
            A130EstadosSolTipo = P00AA2_A130EstadosSolTipo[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV8Cantidad = (short)(AV8Cantidad+1);
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
         P00AA2_A127SolicitudesID = new long[1] ;
         P00AA2_A131EstadosSolId = new int[1] ;
         P00AA2_A130EstadosSolTipo = new string[] {""} ;
         P00AA2_A120ProfesionalesId = new string[] {""} ;
         P00AA2_A140RelacionesId = new long[1] ;
         A130EstadosSolTipo = "";
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aocantidadsolicitudes__default(),
            new Object[][] {
                new Object[] {
               P00AA2_A127SolicitudesID, P00AA2_A131EstadosSolId, P00AA2_A130EstadosSolTipo, P00AA2_A120ProfesionalesId, P00AA2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8Cantidad ;
      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV9ProfesionalesId ;
      private string A130EstadosSolTipo ;
      private string A120ProfesionalesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AA2_A127SolicitudesID ;
      private int[] P00AA2_A131EstadosSolId ;
      private string[] P00AA2_A130EstadosSolTipo ;
      private string[] P00AA2_A120ProfesionalesId ;
      private long[] P00AA2_A140RelacionesId ;
      private short aP1_Cantidad ;
   }

   public class aocantidadsolicitudes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AA2;
          prmP00AA2 = new Object[] {
          new ParDef("@AV9ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AA2", "SELECT T1.[SolicitudesID], T2.[EstadosSolId], T2.[EstadosSolTipo], T1.[ProfesionalesId], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = @AV9ProfesionalesId) AND (T2.[EstadosSolId] = 5) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AA2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
