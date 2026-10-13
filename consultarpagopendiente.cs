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
   public class consultarpagopendiente : GXProcedure
   {
      public consultarpagopendiente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public consultarpagopendiente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out string aP1_Pagado )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Pagado = "" ;
         initialize();
         ExecutePrivate();
         aP1_Pagado=this.AV9Pagado;
      }

      public string executeUdp( long aP0_SolicitudesId )
      {
         execute(aP0_SolicitudesId, out aP1_Pagado);
         return AV9Pagado ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out string aP1_Pagado )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Pagado = "" ;
         SubmitImpl();
         aP1_Pagado=this.AV9Pagado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HJ2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00HJ2_A127SolicitudesID[0];
            A441SolicitudesPagado = P00HJ2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00HJ2_n441SolicitudesPagado[0];
            AV9Pagado = A441SolicitudesPagado;
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
         AV9Pagado = "";
         P00HJ2_A127SolicitudesID = new long[1] ;
         P00HJ2_A441SolicitudesPagado = new string[] {""} ;
         P00HJ2_n441SolicitudesPagado = new bool[] {false} ;
         A441SolicitudesPagado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultarpagopendiente__default(),
            new Object[][] {
                new Object[] {
               P00HJ2_A127SolicitudesID, P00HJ2_A441SolicitudesPagado, P00HJ2_n441SolicitudesPagado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SolicitudesId ;
      private long A127SolicitudesID ;
      private string AV9Pagado ;
      private string A441SolicitudesPagado ;
      private bool n441SolicitudesPagado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00HJ2_A127SolicitudesID ;
      private string[] P00HJ2_A441SolicitudesPagado ;
      private bool[] P00HJ2_n441SolicitudesPagado ;
      private string aP1_Pagado ;
   }

   public class consultarpagopendiente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HJ2;
          prmP00HJ2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HJ2", "SELECT [SolicitudesID], [SolicitudesPagado] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HJ2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
