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
   public class productosvarios : GXProcedure
   {
      public productosvarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public productosvarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out short aP1_Count )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Count = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Count=this.AV9Count;
      }

      public short executeUdp( long aP0_SolicitudesId )
      {
         execute(aP0_SolicitudesId, out aP1_Count);
         return AV9Count ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out short aP1_Count )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Count = 0 ;
         SubmitImpl();
         aP1_Count=this.AV9Count;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Count = 0;
         /* Optimized group. */
         /* Using cursor P00NC2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         cV9Count = P00NC2_AV9Count[0];
         pr_default.close(0);
         AV9Count = (short)(AV9Count+cV9Count*1);
         /* End optimized group. */
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
         P00NC2_AV9Count = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productosvarios__default(),
            new Object[][] {
                new Object[] {
               P00NC2_AV9Count
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9Count ;
      private short cV9Count ;
      private long AV8SolicitudesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00NC2_AV9Count ;
      private short aP1_Count ;
   }

   public class productosvarios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NC2;
          prmP00NC2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NC2", "SELECT COUNT(*) FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV8SolicitudesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NC2,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
