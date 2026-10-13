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
   public class insertarfeedback : GXProcedure
   {
      public insertarfeedback( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public insertarfeedback( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudId ,
                           string aP1_Feedback )
      {
         this.AV10SolicitudId = aP0_SolicitudId;
         this.AV8Feedback = aP1_Feedback;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 string aP1_Feedback )
      {
         this.AV10SolicitudId = aP0_SolicitudId;
         this.AV8Feedback = aP1_Feedback;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9plog = new SdtPlog(context);
         AV9plog.gxTpr_Plogmsg = AV8Feedback;
         AV9plog.gxTpr_Plogpgm = context.GetMessage( "Solicitud n°: ", "")+StringUtil.Str( (decimal)(AV10SolicitudId), 18, 0);
         AV9plog.Insert();
         context.CommitDataStores("apis.insertarfeedback",pr_default);
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
         AV9plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.insertarfeedback__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.insertarfeedback__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10SolicitudId ;
      private string AV8Feedback ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtPlog AV9plog ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class insertarfeedback__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class insertarfeedback__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
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
