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
   public class eliminarnotificacion : GXProcedure
   {
      public eliminarnotificacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public eliminarnotificacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_usuariosNotificacionTipo ,
                           long aP2_usuariosNotificacionCodigo )
      {
         this.AV8usuariosId = aP0_usuariosId;
         this.AV9usuariosNotificacionTipo = aP1_usuariosNotificacionTipo;
         this.AV10usuariosNotificacionCodigo = aP2_usuariosNotificacionCodigo;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_usuariosNotificacionTipo ,
                                 long aP2_usuariosNotificacionCodigo )
      {
         this.AV8usuariosId = aP0_usuariosId;
         this.AV9usuariosNotificacionTipo = aP1_usuariosNotificacionTipo;
         this.AV10usuariosNotificacionCodigo = aP2_usuariosNotificacionCodigo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00A02 */
         pr_default.execute(0, new Object[] {AV8usuariosId, AV9usuariosNotificacionTipo, AV10usuariosNotificacionCodigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A147usuariosNotificacionCodigo = P00A02_A147usuariosNotificacionCodigo[0];
            A146usuariosNotificacionTipo = P00A02_A146usuariosNotificacionTipo[0];
            A145usuariosId = P00A02_A145usuariosId[0];
            /* Using cursor P00A03 */
            pr_default.execute(1, new Object[] {A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("eliminarnotificacion",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("eliminarnotificacion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00A02_A147usuariosNotificacionCodigo = new long[1] ;
         P00A02_A146usuariosNotificacionTipo = new string[] {""} ;
         P00A02_A145usuariosId = new string[] {""} ;
         A146usuariosNotificacionTipo = "";
         A145usuariosId = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.eliminarnotificacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.eliminarnotificacion__default(),
            new Object[][] {
                new Object[] {
               P00A02_A147usuariosNotificacionCodigo, P00A02_A146usuariosNotificacionTipo, P00A02_A145usuariosId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10usuariosNotificacionCodigo ;
      private long A147usuariosNotificacionCodigo ;
      private string AV8usuariosId ;
      private string AV9usuariosNotificacionTipo ;
      private string A146usuariosNotificacionTipo ;
      private string A145usuariosId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00A02_A147usuariosNotificacionCodigo ;
      private string[] P00A02_A146usuariosNotificacionTipo ;
      private string[] P00A02_A145usuariosId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class eliminarnotificacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class eliminarnotificacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00A02;
        prmP00A02 = new Object[] {
        new ParDef("@AV8usuariosId",GXType.NChar,20,0) ,
        new ParDef("@AV9usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@AV10usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        Object[] prmP00A03;
        prmP00A03 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0) ,
        new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00A02", "SELECT TOP 1 [usuariosNotificacionCodigo], [usuariosNotificacionTipo], [usuariosId] FROM [usuariosNotificacion] WITH (UPDLOCK) WHERE (RTRIM(LTRIM([usuariosId])) = RTRIM(LTRIM(@AV8usuariosId))) AND ([usuariosNotificacionTipo] = @AV9usuariosNotificacionTipo) AND ([usuariosNotificacionCodigo] = @AV10usuariosNotificacionCodigo) ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A02,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00A03", "DELETE FROM [usuariosNotificacion]  WHERE [usuariosId] = @usuariosId AND [usuariosNotificacionTipo] = @usuariosNotificacionTipo AND [usuariosNotificacionCodigo] = @usuariosNotificacionCodigo", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A03)
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
     }
  }

}

}
