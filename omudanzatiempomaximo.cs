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
   public class omudanzatiempomaximo : GXProcedure
   {
      public omudanzatiempomaximo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public omudanzatiempomaximo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ParametroMudanzaId ,
                           out decimal aP1_ParametroMudanzaValor )
      {
         this.AV8ParametroMudanzaId = aP0_ParametroMudanzaId;
         this.AV9ParametroMudanzaValor = 0 ;
         initialize();
         ExecutePrivate();
         aP1_ParametroMudanzaValor=this.AV9ParametroMudanzaValor;
      }

      public decimal executeUdp( short aP0_ParametroMudanzaId )
      {
         execute(aP0_ParametroMudanzaId, out aP1_ParametroMudanzaValor);
         return AV9ParametroMudanzaValor ;
      }

      public void executeSubmit( short aP0_ParametroMudanzaId ,
                                 out decimal aP1_ParametroMudanzaValor )
      {
         this.AV8ParametroMudanzaId = aP0_ParametroMudanzaId;
         this.AV9ParametroMudanzaValor = 0 ;
         SubmitImpl();
         aP1_ParametroMudanzaValor=this.AV9ParametroMudanzaValor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00F12 */
         pr_default.execute(0, new Object[] {AV8ParametroMudanzaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A730ParametroMudanzaId = P00F12_A730ParametroMudanzaId[0];
            A733ParametroMudanzaValor = P00F12_A733ParametroMudanzaValor[0];
            AV9ParametroMudanzaValor = A733ParametroMudanzaValor;
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
         P00F12_A730ParametroMudanzaId = new short[1] ;
         P00F12_A733ParametroMudanzaValor = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.omudanzatiempomaximo__default(),
            new Object[][] {
                new Object[] {
               P00F12_A730ParametroMudanzaId, P00F12_A733ParametroMudanzaValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8ParametroMudanzaId ;
      private short A730ParametroMudanzaId ;
      private decimal AV9ParametroMudanzaValor ;
      private decimal A733ParametroMudanzaValor ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00F12_A730ParametroMudanzaId ;
      private decimal[] P00F12_A733ParametroMudanzaValor ;
      private decimal aP1_ParametroMudanzaValor ;
   }

   public class omudanzatiempomaximo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00F12;
          prmP00F12 = new Object[] {
          new ParDef("@AV8ParametroMudanzaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F12", "SELECT [ParametroMudanzaId], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @AV8ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F12,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
