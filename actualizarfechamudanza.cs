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
   public class actualizarfechamudanza : GXProcedure
   {
      public actualizarfechamudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarfechamudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           long aP1_MudanzaId ,
                           DateTime aP2_Date )
      {
         this.AV11SolicitudesId = aP0_SolicitudesId;
         this.AV9MudanzaId = aP1_MudanzaId;
         this.AV8Date = aP2_Date;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 long aP1_MudanzaId ,
                                 DateTime aP2_Date )
      {
         this.AV11SolicitudesId = aP0_SolicitudesId;
         this.AV9MudanzaId = aP1_MudanzaId;
         this.AV8Date = aP2_Date;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Boolean = false;
         /* Using cursor P00GP2 */
         pr_default.execute(0, new Object[] {AV11SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00GP2_A127SolicitudesID[0];
            A184SolicitudesFechaInstalacion = P00GP2_A184SolicitudesFechaInstalacion[0];
            if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) != DateTimeUtil.ResetTime ( AV8Date ) )
            {
               AV12Boolean = true;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV12Boolean )
         {
            AV10Mudanza.Load(AV9MudanzaId);
            AV10Mudanza.gxTpr_Mudanzafechaservicio = AV8Date;
            AV10Mudanza.Update();
            if ( AV10Mudanza.Success() )
            {
               context.CommitDataStores("actualizarfechamudanza",pr_default);
            }
         }
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
         P00GP2_A127SolicitudesID = new long[1] ;
         P00GP2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         AV10Mudanza = new SdtMudanza(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.actualizarfechamudanza__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarfechamudanza__default(),
            new Object[][] {
                new Object[] {
               P00GP2_A127SolicitudesID, P00GP2_A184SolicitudesFechaInstalacion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11SolicitudesId ;
      private long AV9MudanzaId ;
      private long A127SolicitudesID ;
      private DateTime AV8Date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV12Boolean ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GP2_A127SolicitudesID ;
      private DateTime[] P00GP2_A184SolicitudesFechaInstalacion ;
      private SdtMudanza AV10Mudanza ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class actualizarfechamudanza__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class actualizarfechamudanza__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00GP2;
        prmP00GP2 = new Object[] {
        new ParDef("@AV11SolicitudesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00GP2", "SELECT [SolicitudesID], [SolicitudesFechaInstalacion] FROM [Solicitudes] WHERE [SolicitudesID] = @AV11SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GP2,1, GxCacheFrequency.OFF ,false,true )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
     }
  }

}

}
