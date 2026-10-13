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
   public class getpisoelevacion : GXProcedure
   {
      public getpisoelevacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getpisoelevacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ParametroMudanzaId ,
                           out short aP1_Piso )
      {
         this.A730ParametroMudanzaId = aP0_ParametroMudanzaId;
         this.AV8Piso = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Piso=this.AV8Piso;
      }

      public short executeUdp( short aP0_ParametroMudanzaId )
      {
         execute(aP0_ParametroMudanzaId, out aP1_Piso);
         return AV8Piso ;
      }

      public void executeSubmit( short aP0_ParametroMudanzaId ,
                                 out short aP1_Piso )
      {
         this.A730ParametroMudanzaId = aP0_ParametroMudanzaId;
         this.AV8Piso = 0 ;
         SubmitImpl();
         aP1_Piso=this.AV8Piso;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GF2 */
         pr_default.execute(0, new Object[] {A730ParametroMudanzaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A818ParametroMudanzaPisoElev = P00GF2_A818ParametroMudanzaPisoElev[0];
            AV8Piso = A818ParametroMudanzaPisoElev;
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
         P00GF2_A730ParametroMudanzaId = new short[1] ;
         P00GF2_A818ParametroMudanzaPisoElev = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getpisoelevacion__default(),
            new Object[][] {
                new Object[] {
               P00GF2_A730ParametroMudanzaId, P00GF2_A818ParametroMudanzaPisoElev
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A730ParametroMudanzaId ;
      private short AV8Piso ;
      private short A818ParametroMudanzaPisoElev ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00GF2_A730ParametroMudanzaId ;
      private short[] P00GF2_A818ParametroMudanzaPisoElev ;
      private short aP1_Piso ;
   }

   public class getpisoelevacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GF2;
          prmP00GF2 = new Object[] {
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GF2", "SELECT [ParametroMudanzaId], [ParametroMudanzaPisoElev] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GF2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
