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
   public class solicitudesfechavigente : GXProcedure
   {
      public solicitudesfechavigente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesfechavigente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           DateTime aP1_FechaCierreSolicitud ,
                           out GxSimpleCollection<long> aP2_SolicitudesIdCollection )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10FechaCierreSolicitud = aP1_FechaCierreSolicitud;
         this.AV9SolicitudesIdCollection = new GxSimpleCollection<long>() ;
         initialize();
         ExecutePrivate();
         aP2_SolicitudesIdCollection=this.AV9SolicitudesIdCollection;
      }

      public GxSimpleCollection<long> executeUdp( long aP0_SolicitudesId ,
                                                  DateTime aP1_FechaCierreSolicitud )
      {
         execute(aP0_SolicitudesId, aP1_FechaCierreSolicitud, out aP2_SolicitudesIdCollection);
         return AV9SolicitudesIdCollection ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 DateTime aP1_FechaCierreSolicitud ,
                                 out GxSimpleCollection<long> aP2_SolicitudesIdCollection )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10FechaCierreSolicitud = aP1_FechaCierreSolicitud;
         this.AV9SolicitudesIdCollection = new GxSimpleCollection<long>() ;
         SubmitImpl();
         aP2_SolicitudesIdCollection=this.AV9SolicitudesIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00KB2 */
         pr_default.execute(0, new Object[] {AV10FechaCierreSolicitud, AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A461CentroCostosId = P00KB2_A461CentroCostosId[0];
            A892CentroCostosDetallesFecha = P00KB2_A892CentroCostosDetallesFecha[0];
            A462CentroCostosRef = P00KB2_A462CentroCostosRef[0];
            A888CentroCostosDetallesSolId = P00KB2_A888CentroCostosDetallesSolId[0];
            A466CentroCostosDetallesId = P00KB2_A466CentroCostosDetallesId[0];
            A462CentroCostosRef = P00KB2_A462CentroCostosRef[0];
            AV9SolicitudesIdCollection.Add(A888CentroCostosDetallesSolId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11SolicitudesIdJson = AV9SolicitudesIdCollection.ToJSonString(false);
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
         AV9SolicitudesIdCollection = new GxSimpleCollection<long>();
         P00KB2_A461CentroCostosId = new long[1] ;
         P00KB2_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00KB2_A462CentroCostosRef = new long[1] ;
         P00KB2_A888CentroCostosDetallesSolId = new long[1] ;
         P00KB2_A466CentroCostosDetallesId = new long[1] ;
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         AV11SolicitudesIdJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesfechavigente__default(),
            new Object[][] {
                new Object[] {
               P00KB2_A461CentroCostosId, P00KB2_A892CentroCostosDetallesFecha, P00KB2_A462CentroCostosRef, P00KB2_A888CentroCostosDetallesSolId, P00KB2_A466CentroCostosDetallesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SolicitudesId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A888CentroCostosDetallesSolId ;
      private long A466CentroCostosDetallesId ;
      private DateTime AV10FechaCierreSolicitud ;
      private DateTime A892CentroCostosDetallesFecha ;
      private string AV11SolicitudesIdJson ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV9SolicitudesIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00KB2_A461CentroCostosId ;
      private DateTime[] P00KB2_A892CentroCostosDetallesFecha ;
      private long[] P00KB2_A462CentroCostosRef ;
      private long[] P00KB2_A888CentroCostosDetallesSolId ;
      private long[] P00KB2_A466CentroCostosDetallesId ;
      private GxSimpleCollection<long> aP2_SolicitudesIdCollection ;
   }

   public class solicitudesfechavigente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00KB2;
          prmP00KB2 = new Object[] {
          new ParDef("@AV10FechaCierreSolicitud",GXType.Date,8,0) ,
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KB2", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CentroCostosDetallesSolId], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE (T1.[CentroCostosDetallesFecha] >= @AV10FechaCierreSolicitud) AND (T2.[CentroCostosRef] = @AV8SolicitudesId) ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KB2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
