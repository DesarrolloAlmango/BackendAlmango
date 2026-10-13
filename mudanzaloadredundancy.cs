using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class mudanzaloadredundancy : GXProcedure
   {
      public mudanzaloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public mudanzaloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor MUDANZALOA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A735MudanzaId = MUDANZALOA2_A735MudanzaId[0];
            A760MudanzaPeajevalor = MUDANZALOA2_A760MudanzaPeajevalor[0];
            GXt_decimal1 = A760MudanzaPeajevalor;
            new opeajevalor(context ).execute( out  GXt_decimal1) ;
            A760MudanzaPeajevalor = GXt_decimal1;
            /* Using cursor MUDANZALOA3 */
            pr_default.execute(1, new Object[] {A760MudanzaPeajevalor, A735MudanzaId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Mudanza");
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
         MUDANZALOA2_A735MudanzaId = new long[1] ;
         MUDANZALOA2_A760MudanzaPeajevalor = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanzaloadredundancy__default(),
            new Object[][] {
                new Object[] {
               MUDANZALOA2_A735MudanzaId, MUDANZALOA2_A760MudanzaPeajevalor
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A735MudanzaId ;
      private decimal A760MudanzaPeajevalor ;
      private decimal GXt_decimal1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] MUDANZALOA2_A735MudanzaId ;
      private decimal[] MUDANZALOA2_A760MudanzaPeajevalor ;
   }

   public class mudanzaloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmMUDANZALOA2;
          prmMUDANZALOA2 = new Object[] {
          };
          Object[] prmMUDANZALOA3;
          prmMUDANZALOA3 = new Object[] {
          new ParDef("@MudanzaPeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("MUDANZALOA2", "SELECT [MudanzaId], [MudanzaPeajevalor] FROM [Mudanza] WITH (UPDLOCK) ORDER BY [MudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmMUDANZALOA2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("MUDANZALOA3", "UPDATE [Mudanza] SET [MudanzaPeajevalor]=@MudanzaPeajevalor  WHERE [MudanzaId] = @MudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmMUDANZALOA3)
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
