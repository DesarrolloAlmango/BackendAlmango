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
   public class aincidenciaestado : GXProcedure
   {
      public aincidenciaestado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aincidenciaestado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_IncidenciaId ,
                           long aP1_MotivoId ,
                           string aP2_IncidenciaUsrAlta ,
                           string aP3_IncidenciaUsrActualizacion ,
                           string aP4_IncidenciaEstado )
      {
         this.AV9IncidenciaId = aP0_IncidenciaId;
         this.AV11MotivoId = aP1_MotivoId;
         this.AV10IncidenciaUsrAlta = aP2_IncidenciaUsrAlta;
         this.AV12IncidenciaUsrActualizacion = aP3_IncidenciaUsrActualizacion;
         this.AV8IncidenciaEstado = aP4_IncidenciaEstado;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_IncidenciaId ,
                                 long aP1_MotivoId ,
                                 string aP2_IncidenciaUsrAlta ,
                                 string aP3_IncidenciaUsrActualizacion ,
                                 string aP4_IncidenciaEstado )
      {
         this.AV9IncidenciaId = aP0_IncidenciaId;
         this.AV11MotivoId = aP1_MotivoId;
         this.AV10IncidenciaUsrAlta = aP2_IncidenciaUsrAlta;
         this.AV12IncidenciaUsrActualizacion = aP3_IncidenciaUsrActualizacion;
         this.AV8IncidenciaEstado = aP4_IncidenciaEstado;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P00B02 */
         pr_default.execute(0, new Object[] {AV12IncidenciaUsrActualizacion, AV8IncidenciaEstado, AV9IncidenciaId, AV10IncidenciaUsrAlta, AV11MotivoId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Incidencia");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aincidenciaestado",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A614IncidenciaUsrActualizacion = "";
         A608IncidenciaEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aincidenciaestado__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9IncidenciaId ;
      private long AV11MotivoId ;
      private string AV10IncidenciaUsrAlta ;
      private string AV12IncidenciaUsrActualizacion ;
      private string AV8IncidenciaEstado ;
      private string A614IncidenciaUsrActualizacion ;
      private string A608IncidenciaEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class aincidenciaestado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B02;
          prmP00B02 = new Object[] {
          new ParDef("@IncidenciaUsrActualizacion",GXType.NChar,20,0) ,
          new ParDef("@IncidenciaEstado",GXType.NChar,3,0) ,
          new ParDef("@AV9IncidenciaId",GXType.Decimal,18,0) ,
          new ParDef("@AV10IncidenciaUsrAlta",GXType.NChar,20,0) ,
          new ParDef("@AV11MotivoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B02", "UPDATE [Incidencia] SET [IncidenciaFechaActualizacion]=GETDATE(), [IncidenciaUsrActualizacion]=@IncidenciaUsrActualizacion, [IncidenciaEstado]=@IncidenciaEstado  WHERE ([IncidenciaId] = @AV9IncidenciaId) AND ([IncidenciaUsrAlta] = @AV10IncidenciaUsrAlta) AND ([MotivoId] = @AV11MotivoId)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00B02)
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
