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
   public class actualizarcentrocostos : GXProcedure
   {
      public actualizarcentrocostos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarcentrocostos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolcitudesId ,
                           string aP1_ProfesionalesId ,
                           int aP2_NuevoEstadoDetalleCosto )
      {
         this.AV8SolcitudesId = aP0_SolcitudesId;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV9NuevoEstadoDetalleCosto = aP2_NuevoEstadoDetalleCosto;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolcitudesId ,
                                 string aP1_ProfesionalesId ,
                                 int aP2_NuevoEstadoDetalleCosto )
      {
         this.AV8SolcitudesId = aP0_SolcitudesId;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV9NuevoEstadoDetalleCosto = aP2_NuevoEstadoDetalleCosto;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P00MF2 */
         long AV9NuevoEstadoDetalleCosto893Aux;
         AV9NuevoEstadoDetalleCosto893Aux = AV9NuevoEstadoDetalleCosto;
         pr_default.execute(0, new Object[] {AV9NuevoEstadoDetalleCosto893Aux, AV10ProfesionalesId, AV8SolcitudesId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.actualizarcentrocostos",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.actualizarcentrocostos__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9NuevoEstadoDetalleCosto ;
      private long AV8SolcitudesId ;
      private long A893CentroCostosDetallesEstado ;
      private string AV10ProfesionalesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class actualizarcentrocostos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MF2;
          prmP00MF2 = new Object[] {
          new ParDef("@CentroCostosDetallesEstado",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV8SolcitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MF2", "UPDATE [CentroCostosDetalles] SET [CentroCostosDetallesEstado]=@CentroCostosDetallesEstado  WHERE ([CCDetallesProfId] = RTRIM(LTRIM(@AV10ProfesionalesId))) AND ([CentroCostosDetallesSolId] = @AV8SolcitudesId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MF2)
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
