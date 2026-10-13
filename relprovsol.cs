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
   public class relprovsol : GXProcedure
   {
      public relprovsol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public relprovsol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           long aP1_ProveedorSolicitudesId ,
                           string aP2_ProveedorSolicitudesNombre )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9ProveedorSolicitudesId = aP1_ProveedorSolicitudesId;
         this.AV10ProveedorSolicitudesNombre = aP2_ProveedorSolicitudesNombre;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 long aP1_ProveedorSolicitudesId ,
                                 string aP2_ProveedorSolicitudesNombre )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9ProveedorSolicitudesId = aP1_ProveedorSolicitudesId;
         this.AV10ProveedorSolicitudesNombre = aP2_ProveedorSolicitudesNombre;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE ProveedorSolicitudes

         */
         A133ProveedorID = AV8ProveedorID;
         A152ProveedorSolicitudesId = AV9ProveedorSolicitudesId;
         A337ProveedorSolicitudesNombre = AV10ProveedorSolicitudesNombre;
         A280ProveedorSolicitudesFecha = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
         n280ProveedorSolicitudesFecha = false;
         /* Using cursor P007V2 */
         pr_default.execute(0, new Object[] {A133ProveedorID, A152ProveedorSolicitudesId, A337ProveedorSolicitudesNombre, n280ProveedorSolicitudesFecha, A280ProveedorSolicitudesFecha});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("ProveedorSolicitudes");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("relprovsol",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A337ProveedorSolicitudesNombre = "";
         A280ProveedorSolicitudesFecha = DateTime.MinValue;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relprovsol__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS52 ;
      private long AV8ProveedorID ;
      private long AV9ProveedorSolicitudesId ;
      private long A133ProveedorID ;
      private long A152ProveedorSolicitudesId ;
      private string AV10ProveedorSolicitudesNombre ;
      private string A337ProveedorSolicitudesNombre ;
      private string Gx_emsg ;
      private DateTime A280ProveedorSolicitudesFecha ;
      private bool n280ProveedorSolicitudesFecha ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class relprovsol__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007V2;
          prmP007V2 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@ProveedorSolicitudesId",GXType.Decimal,18,0) ,
          new ParDef("@ProveedorSolicitudesNombre",GXType.NChar,120,0) ,
          new ParDef("@ProveedorSolicitudesFecha",GXType.Date,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P007V2", "INSERT INTO [ProveedorSolicitudes]([ProveedorID], [ProveedorSolicitudesId], [ProveedorSolicitudesNombre], [ProveedorSolicitudesFecha]) VALUES(@ProveedorID, @ProveedorSolicitudesId, @ProveedorSolicitudesNombre, @ProveedorSolicitudesFecha)", GxErrorMask.GX_NOMASK,prmP007V2)
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
