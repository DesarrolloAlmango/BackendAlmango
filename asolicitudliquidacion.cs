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
   public class asolicitudliquidacion : GXProcedure
   {
      public asolicitudliquidacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asolicitudliquidacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_OperacionesTipo ,
                           long aP2_OperacionesId ,
                           out bool aP3_IsOk )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10OperacionesTipo = aP1_OperacionesTipo;
         this.AV9OperacionesId = aP2_OperacionesId;
         this.AV11IsOk = false ;
         initialize();
         ExecutePrivate();
         aP3_IsOk=this.AV11IsOk;
      }

      public bool executeUdp( long aP0_SolicitudesId ,
                              string aP1_OperacionesTipo ,
                              long aP2_OperacionesId )
      {
         execute(aP0_SolicitudesId, aP1_OperacionesTipo, aP2_OperacionesId, out aP3_IsOk);
         return AV11IsOk ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_OperacionesTipo ,
                                 long aP2_OperacionesId ,
                                 out bool aP3_IsOk )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV10OperacionesTipo = aP1_OperacionesTipo;
         this.AV9OperacionesId = aP2_OperacionesId;
         this.AV11IsOk = false ;
         SubmitImpl();
         aP3_IsOk=this.AV11IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11IsOk = false;
         /* Using cursor P00D52 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00D52_A127SolicitudesID[0];
            A688SolicitudesLiqProf = P00D52_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = P00D52_n688SolicitudesLiqProf[0];
            A689SolicitudesLiqProv = P00D52_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = P00D52_n689SolicitudesLiqProv[0];
            if ( StringUtil.StrCmp(AV10OperacionesTipo, "LSF") == 0 )
            {
               A688SolicitudesLiqProf = AV9OperacionesId;
               n688SolicitudesLiqProf = false;
            }
            else
            {
               A689SolicitudesLiqProv = AV9OperacionesId;
               n689SolicitudesLiqProv = false;
            }
            AV11IsOk = true;
            /* Using cursor P00D53 */
            pr_default.execute(1, new Object[] {n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
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
         P00D52_A127SolicitudesID = new long[1] ;
         P00D52_A688SolicitudesLiqProf = new long[1] ;
         P00D52_n688SolicitudesLiqProf = new bool[] {false} ;
         P00D52_A689SolicitudesLiqProv = new long[1] ;
         P00D52_n689SolicitudesLiqProv = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asolicitudliquidacion__default(),
            new Object[][] {
                new Object[] {
               P00D52_A127SolicitudesID, P00D52_A688SolicitudesLiqProf, P00D52_n688SolicitudesLiqProf, P00D52_A689SolicitudesLiqProv, P00D52_n689SolicitudesLiqProv
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SolicitudesId ;
      private long AV9OperacionesId ;
      private long A127SolicitudesID ;
      private long A688SolicitudesLiqProf ;
      private long A689SolicitudesLiqProv ;
      private string AV10OperacionesTipo ;
      private bool AV11IsOk ;
      private bool n688SolicitudesLiqProf ;
      private bool n689SolicitudesLiqProv ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00D52_A127SolicitudesID ;
      private long[] P00D52_A688SolicitudesLiqProf ;
      private bool[] P00D52_n688SolicitudesLiqProf ;
      private long[] P00D52_A689SolicitudesLiqProv ;
      private bool[] P00D52_n689SolicitudesLiqProv ;
      private bool aP3_IsOk ;
   }

   public class asolicitudliquidacion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D52;
          prmP00D52 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00D53;
          prmP00D53 = new Object[] {
          new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D52", "SELECT [SolicitudesID], [SolicitudesLiqProf], [SolicitudesLiqProv] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D52,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00D53", "UPDATE [Solicitudes] SET [SolicitudesLiqProf]=@SolicitudesLiqProf, [SolicitudesLiqProv]=@SolicitudesLiqProv  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D53)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
