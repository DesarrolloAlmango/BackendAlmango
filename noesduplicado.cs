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
   public class noesduplicado : GXProcedure
   {
      public noesduplicado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public noesduplicado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesDuplicado )
      {
         this.A972SolicitudesDuplicado = aP0_SolicitudesDuplicado;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesDuplicado )
      {
         this.A972SolicitudesDuplicado = aP0_SolicitudesDuplicado;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P00M42 */
         pr_default.execute(0, new Object[] {n972SolicitudesDuplicado, A972SolicitudesDuplicado});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("noesduplicado",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.noesduplicado__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A972SolicitudesDuplicado ;
      private bool n972SolicitudesDuplicado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class noesduplicado__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00M42;
          prmP00M42 = new Object[] {
          new ParDef("@SolicitudesDuplicado",GXType.Decimal,18,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00M42", "UPDATE [Solicitudes] SET [SolicitudesDuplicado]=NULL  WHERE [SolicitudesDuplicado] = @SolicitudesDuplicado", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00M42)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
