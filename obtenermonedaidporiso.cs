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
   public class obtenermonedaidporiso : GXProcedure
   {
      public obtenermonedaidporiso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenermonedaidporiso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MonedaISO ,
                           out short aP1_MonedaId ,
                           out bool aP2_Existe )
      {
         this.AV8MonedaISO = aP0_MonedaISO;
         this.AV9MonedaId = 0 ;
         this.AV10Existe = false ;
         initialize();
         ExecutePrivate();
         aP1_MonedaId=this.AV9MonedaId;
         aP2_Existe=this.AV10Existe;
      }

      public bool executeUdp( string aP0_MonedaISO ,
                              out short aP1_MonedaId )
      {
         execute(aP0_MonedaISO, out aP1_MonedaId, out aP2_Existe);
         return AV10Existe ;
      }

      public void executeSubmit( string aP0_MonedaISO ,
                                 out short aP1_MonedaId ,
                                 out bool aP2_Existe )
      {
         this.AV8MonedaISO = aP0_MonedaISO;
         this.AV9MonedaId = 0 ;
         this.AV10Existe = false ;
         SubmitImpl();
         aP1_MonedaId=this.AV9MonedaId;
         aP2_Existe=this.AV10Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Existe = false;
         AV9MonedaId = 0;
         /* Using cursor P00LK2 */
         pr_default.execute(0, new Object[] {AV8MonedaISO});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119MonedaISOSimbolo = P00LK2_A119MonedaISOSimbolo[0];
            A118MonedaId = P00LK2_A118MonedaId[0];
            AV9MonedaId = A118MonedaId;
            AV10Existe = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00LK2_A119MonedaISOSimbolo = new string[] {""} ;
         P00LK2_A118MonedaId = new short[1] ;
         A119MonedaISOSimbolo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenermonedaidporiso__default(),
            new Object[][] {
                new Object[] {
               P00LK2_A119MonedaISOSimbolo, P00LK2_A118MonedaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9MonedaId ;
      private short A118MonedaId ;
      private string AV8MonedaISO ;
      private string A119MonedaISOSimbolo ;
      private bool AV10Existe ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00LK2_A119MonedaISOSimbolo ;
      private short[] P00LK2_A118MonedaId ;
      private short aP1_MonedaId ;
      private bool aP2_Existe ;
   }

   public class obtenermonedaidporiso__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LK2;
          prmP00LK2 = new Object[] {
          new ParDef("@AV8MonedaISO",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LK2", "SELECT TOP 1 [MonedaISOSimbolo], [MonedaId] FROM [Moneda] WHERE [MonedaISOSimbolo] = @AV8MonedaISO ORDER BY [MonedaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LK2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
