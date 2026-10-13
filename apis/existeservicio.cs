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
namespace GeneXus.Programs.apis {
   public class existeservicio : GXProcedure
   {
      public existeservicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public existeservicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ServicioId ,
                           out bool aP1_Existe )
      {
         this.AV8ServicioId = aP0_ServicioId;
         this.AV9Existe = false ;
         initialize();
         ExecutePrivate();
         aP1_Existe=this.AV9Existe;
      }

      public bool executeUdp( long aP0_ServicioId )
      {
         execute(aP0_ServicioId, out aP1_Existe);
         return AV9Existe ;
      }

      public void executeSubmit( long aP0_ServicioId ,
                                 out bool aP1_Existe )
      {
         this.AV8ServicioId = aP0_ServicioId;
         this.AV9Existe = false ;
         SubmitImpl();
         aP1_Existe=this.AV9Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Existe = false;
         /* Using cursor P00MN2 */
         pr_default.execute(0, new Object[] {AV8ServicioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A942ServiciosId = P00MN2_A942ServiciosId[0];
            AV9Existe = true;
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
         P00MN2_A942ServiciosId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.existeservicio__default(),
            new Object[][] {
                new Object[] {
               P00MN2_A942ServiciosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8ServicioId ;
      private long A942ServiciosId ;
      private bool AV9Existe ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MN2_A942ServiciosId ;
      private bool aP1_Existe ;
   }

   public class existeservicio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MN2;
          prmP00MN2 = new Object[] {
          new ParDef("@AV8ServicioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MN2", "SELECT [ServiciosId] FROM [Servicios] WHERE [ServiciosId] = @AV8ServicioId ORDER BY [ServiciosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MN2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
