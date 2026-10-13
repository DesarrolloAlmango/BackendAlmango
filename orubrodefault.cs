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
   public class orubrodefault : GXProcedure
   {
      public orubrodefault( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orubrodefault( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_RubrosId )
      {
         this.AV8RubrosId = 0 ;
         initialize();
         ExecutePrivate();
         aP0_RubrosId=this.AV8RubrosId;
      }

      public short executeUdp( )
      {
         execute(out aP0_RubrosId);
         return AV8RubrosId ;
      }

      public void executeSubmit( out short aP0_RubrosId )
      {
         this.AV8RubrosId = 0 ;
         SubmitImpl();
         aP0_RubrosId=this.AV8RubrosId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GXLvl1 = 0;
         /* Using cursor P00972 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A501RubrosDefault = P00972_A501RubrosDefault[0];
            n501RubrosDefault = P00972_n501RubrosDefault[0];
            A123RubrosEstado = P00972_A123RubrosEstado[0];
            n123RubrosEstado = P00972_n123RubrosEstado[0];
            A121RubrosId = P00972_A121RubrosId[0];
            AV9GXLvl1 = 1;
            AV8RubrosId = A121RubrosId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9GXLvl1 == 0 )
         {
            /* Using cursor P00973 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A123RubrosEstado = P00973_A123RubrosEstado[0];
               n123RubrosEstado = P00973_n123RubrosEstado[0];
               A121RubrosId = P00973_A121RubrosId[0];
               AV8RubrosId = A121RubrosId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
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
         P00972_A501RubrosDefault = new bool[] {false} ;
         P00972_n501RubrosDefault = new bool[] {false} ;
         P00972_A123RubrosEstado = new string[] {""} ;
         P00972_n123RubrosEstado = new bool[] {false} ;
         P00972_A121RubrosId = new short[1] ;
         A123RubrosEstado = "";
         P00973_A123RubrosEstado = new string[] {""} ;
         P00973_n123RubrosEstado = new bool[] {false} ;
         P00973_A121RubrosId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.orubrodefault__default(),
            new Object[][] {
                new Object[] {
               P00972_A501RubrosDefault, P00972_n501RubrosDefault, P00972_A123RubrosEstado, P00972_n123RubrosEstado, P00972_A121RubrosId
               }
               , new Object[] {
               P00973_A123RubrosEstado, P00973_n123RubrosEstado, P00973_A121RubrosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8RubrosId ;
      private short AV9GXLvl1 ;
      private short A121RubrosId ;
      private string A123RubrosEstado ;
      private bool A501RubrosDefault ;
      private bool n501RubrosDefault ;
      private bool n123RubrosEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00972_A501RubrosDefault ;
      private bool[] P00972_n501RubrosDefault ;
      private string[] P00972_A123RubrosEstado ;
      private bool[] P00972_n123RubrosEstado ;
      private short[] P00972_A121RubrosId ;
      private string[] P00973_A123RubrosEstado ;
      private bool[] P00973_n123RubrosEstado ;
      private short[] P00973_A121RubrosId ;
      private short aP0_RubrosId ;
   }

   public class orubrodefault__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00972;
          prmP00972 = new Object[] {
          };
          Object[] prmP00973;
          prmP00973 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00972", "SELECT TOP 1 [RubrosDefault], [RubrosEstado], [RubrosId] FROM [Rubros] WHERE ([RubrosEstado] = 'HAB') AND ([RubrosDefault] = 1) ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00972,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00973", "SELECT TOP 1 [RubrosEstado], [RubrosId] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00973,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
