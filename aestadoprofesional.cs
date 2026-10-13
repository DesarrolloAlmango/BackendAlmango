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
   public class aestadoprofesional : GXProcedure
   {
      public aestadoprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aestadoprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ListaId ,
                           long aP1_ProveedorID ,
                           string aP2_ProfesionalesId ,
                           string aP3_AgrupacionEstado )
      {
         this.AV8ListaId = aP0_ListaId;
         this.AV9ProveedorID = aP1_ProveedorID;
         this.AV10ProfesionalesId = aP2_ProfesionalesId;
         this.AV11AgrupacionEstado = aP3_AgrupacionEstado;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ListaId ,
                                 long aP1_ProveedorID ,
                                 string aP2_ProfesionalesId ,
                                 string aP3_AgrupacionEstado )
      {
         this.AV8ListaId = aP0_ListaId;
         this.AV9ProveedorID = aP1_ProveedorID;
         this.AV10ProfesionalesId = aP2_ProfesionalesId;
         this.AV11AgrupacionEstado = aP3_AgrupacionEstado;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized UPDATE. */
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV11AgrupacionEstado, AV8ListaId, AV9ProveedorID, AV10ProfesionalesId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("ListaAgrupacion");
         /* End optimized UPDATE. */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aestadoprofesional",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A588AgrupacionEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aestadoprofesional__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8ListaId ;
      private long AV9ProveedorID ;
      private string AV10ProfesionalesId ;
      private string AV11AgrupacionEstado ;
      private string A588AgrupacionEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class aestadoprofesional__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BR2;
          prmP00BR2 = new Object[] {
          new ParDef("@AgrupacionEstado",GXType.NChar,3,0) ,
          new ParDef("@AV8ListaId",GXType.Decimal,18,0) ,
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BR2", "UPDATE [ListaAgrupacion] SET [AgrupacionEstado]=@AgrupacionEstado  WHERE [Listaid] = @AV8ListaId and [ProveedorID] = @AV9ProveedorID and [ProfesionalesId] = @AV10ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BR2)
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
