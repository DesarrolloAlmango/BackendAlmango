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
   public class oclidoc : GXProcedure
   {
      public oclidoc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oclidoc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientesIdentidad ,
                           out long aP1_ClientesId )
      {
         this.AV11ClientesIdentidad = aP0_ClientesIdentidad;
         this.AV10ClientesId = 0 ;
         initialize();
         ExecutePrivate();
         aP1_ClientesId=this.AV10ClientesId;
      }

      public long executeUdp( string aP0_ClientesIdentidad )
      {
         execute(aP0_ClientesIdentidad, out aP1_ClientesId);
         return AV10ClientesId ;
      }

      public void executeSubmit( string aP0_ClientesIdentidad ,
                                 out long aP1_ClientesId )
      {
         this.AV11ClientesIdentidad = aP0_ClientesIdentidad;
         this.AV10ClientesId = 0 ;
         SubmitImpl();
         aP1_ClientesId=this.AV10ClientesId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008Q2 */
         pr_default.execute(0, new Object[] {AV11ClientesIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A434ClientesIdentidad = P008Q2_A434ClientesIdentidad[0];
            A106ClientesId = P008Q2_A106ClientesId[0];
            AV10ClientesId = A106ClientesId;
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
         P008Q2_A434ClientesIdentidad = new string[] {""} ;
         P008Q2_A106ClientesId = new long[1] ;
         A434ClientesIdentidad = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oclidoc__default(),
            new Object[][] {
                new Object[] {
               P008Q2_A434ClientesIdentidad, P008Q2_A106ClientesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10ClientesId ;
      private long A106ClientesId ;
      private string AV11ClientesIdentidad ;
      private string A434ClientesIdentidad ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008Q2_A434ClientesIdentidad ;
      private long[] P008Q2_A106ClientesId ;
      private long aP1_ClientesId ;
   }

   public class oclidoc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008Q2;
          prmP008Q2 = new Object[] {
          new ParDef("@AV11ClientesIdentidad",GXType.Char,25,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Q2", "SELECT TOP 1 [ClientesIdentidad], [ClientesId] FROM [Clientes] WHERE RTRIM(LTRIM(UPPER([ClientesIdentidad]))) = RTRIM(LTRIM(UPPER(@AV11ClientesIdentidad))) ORDER BY [ClientesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
