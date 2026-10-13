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
   public class anotasolicitud : GXProcedure
   {
      public anotasolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public anotasolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           ref string aP1_NOTA ,
                           ref long aP2_CancelacionTipificacionId )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV10NOTA = aP1_NOTA;
         this.AV11CancelacionTipificacionId = aP2_CancelacionTipificacionId;
         initialize();
         ExecutePrivate();
         aP1_NOTA=this.AV10NOTA;
         aP2_CancelacionTipificacionId=this.AV11CancelacionTipificacionId;
      }

      public long executeUdp( long aP0_SolicitudesID ,
                              ref string aP1_NOTA )
      {
         execute(aP0_SolicitudesID, ref aP1_NOTA, ref aP2_CancelacionTipificacionId);
         return AV11CancelacionTipificacionId ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 ref string aP1_NOTA ,
                                 ref long aP2_CancelacionTipificacionId )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV10NOTA = aP1_NOTA;
         this.AV11CancelacionTipificacionId = aP2_CancelacionTipificacionId;
         SubmitImpl();
         aP1_NOTA=this.AV10NOTA;
         aP2_CancelacionTipificacionId=this.AV11CancelacionTipificacionId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009P2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P009P2_A127SolicitudesID[0];
            A261SolicitudesNota = P009P2_A261SolicitudesNota[0];
            A204SolicitudesFechaActualizacion = P009P2_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P009P2_n204SolicitudesFechaActualizacion[0];
            A996CancelacionTipificacionId = P009P2_A996CancelacionTipificacionId[0];
            AV9SolicitudesNota = StringUtil.Trim( AV10NOTA) + ".  " + StringUtil.Trim( A261SolicitudesNota);
            A261SolicitudesNota = AV9SolicitudesNota;
            A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n204SolicitudesFechaActualizacion = false;
            A996CancelacionTipificacionId = AV11CancelacionTipificacionId;
            /* Using cursor P009P3 */
            pr_default.execute(1, new Object[] {A261SolicitudesNota, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A996CancelacionTipificacionId, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("anotasolicitud",pr_default);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("anotasolicitud",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P009P2_A127SolicitudesID = new long[1] ;
         P009P2_A261SolicitudesNota = new string[] {""} ;
         P009P2_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P009P2_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P009P2_A996CancelacionTipificacionId = new long[1] ;
         A261SolicitudesNota = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV9SolicitudesNota = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.anotasolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anotasolicitud__default(),
            new Object[][] {
                new Object[] {
               P009P2_A127SolicitudesID, P009P2_A261SolicitudesNota, P009P2_A204SolicitudesFechaActualizacion, P009P2_n204SolicitudesFechaActualizacion, P009P2_A996CancelacionTipificacionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SolicitudesID ;
      private long AV11CancelacionTipificacionId ;
      private long A127SolicitudesID ;
      private long A996CancelacionTipificacionId ;
      private string AV10NOTA ;
      private string A261SolicitudesNota ;
      private string AV9SolicitudesNota ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private bool n204SolicitudesFechaActualizacion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP1_NOTA ;
      private long aP2_CancelacionTipificacionId ;
      private IDataStoreProvider pr_default ;
      private long[] P009P2_A127SolicitudesID ;
      private string[] P009P2_A261SolicitudesNota ;
      private DateTime[] P009P2_A204SolicitudesFechaActualizacion ;
      private bool[] P009P2_n204SolicitudesFechaActualizacion ;
      private long[] P009P2_A996CancelacionTipificacionId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class anotasolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class anotasolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP009P2;
        prmP009P2 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009P3;
        prmP009P3 = new Object[] {
        new ParDef("@SolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009P2", "SELECT [SolicitudesID], [SolicitudesNota], [SolicitudesFechaActualizacion], [CancelacionTipificacionId] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV8SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009P2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009P3", "UPDATE [Solicitudes] SET [SolicitudesNota]=@SolicitudesNota, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion, [CancelacionTipificacionId]=@CancelacionTipificacionId  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009P3)
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
              ((string[]) buf[1])[0] = rslt.getString(2, 500);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              return;
     }
  }

}

}
