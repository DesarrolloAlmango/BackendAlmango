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
   public class osolorigenpago : GXProcedure
   {
      public osolorigenpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osolorigenpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out string aP1_SolicitudServicioOrigenPago )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9SolicitudServicioOrigenPago = "" ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudServicioOrigenPago=this.AV9SolicitudServicioOrigenPago;
      }

      public string executeUdp( long aP0_SolicitudesId )
      {
         execute(aP0_SolicitudesId, out aP1_SolicitudServicioOrigenPago);
         return AV9SolicitudServicioOrigenPago ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out string aP1_SolicitudServicioOrigenPago )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9SolicitudServicioOrigenPago = "" ;
         SubmitImpl();
         aP1_SolicitudServicioOrigenPago=this.AV9SolicitudServicioOrigenPago;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00MJ2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00MJ2_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = P00MJ2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00MJ2_n438SolicitudServicioOrigenPago[0];
            AV9SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
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
         AV9SolicitudServicioOrigenPago = "";
         P00MJ2_A127SolicitudesID = new long[1] ;
         P00MJ2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00MJ2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         A438SolicitudServicioOrigenPago = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.osolorigenpago__default(),
            new Object[][] {
                new Object[] {
               P00MJ2_A127SolicitudesID, P00MJ2_A438SolicitudServicioOrigenPago, P00MJ2_n438SolicitudServicioOrigenPago
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SolicitudesId ;
      private long A127SolicitudesID ;
      private string AV9SolicitudServicioOrigenPago ;
      private string A438SolicitudServicioOrigenPago ;
      private bool n438SolicitudServicioOrigenPago ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MJ2_A127SolicitudesID ;
      private string[] P00MJ2_A438SolicitudServicioOrigenPago ;
      private bool[] P00MJ2_n438SolicitudServicioOrigenPago ;
      private string aP1_SolicitudServicioOrigenPago ;
   }

   public class osolorigenpago__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MJ2;
          prmP00MJ2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MJ2", "SELECT [SolicitudesID], [SolicitudServicioOrigenPago] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MJ2,1, GxCacheFrequency.OFF ,false,true )
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
