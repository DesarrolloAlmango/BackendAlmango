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
   public class cambiasolicitudesautoenumerar : GXProcedure
   {
      public cambiasolicitudesautoenumerar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cambiasolicitudesautoenumerar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SolicitudesAutoEnumerarInicio = (short)(Math.Round(NumberUtil.Val( AV8WebSession.Get(context.GetMessage( "SerialInicio", "")), "."), 18, MidpointRounding.ToEven));
         /* Using cursor P00NE2 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A194SolicitudesAutoEnumerar = P00NE2_A194SolicitudesAutoEnumerar[0];
            A210SolicitudServicioSolCoti = P00NE2_A210SolicitudServicioSolCoti[0];
            A212SolicitudesCotizacion = P00NE2_A212SolicitudesCotizacion[0];
            if ( A194SolicitudesAutoEnumerar != AV9SolicitudesAutoEnumerarInicio )
            {
               A210SolicitudServicioSolCoti = "1";
               A212SolicitudesCotizacion = 0;
            }
            /* Using cursor P00NE3 */
            pr_default.execute(1, new Object[] {A210SolicitudServicioSolCoti, A212SolicitudesCotizacion, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("cambiasolicitudesautoenumerar",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8WebSession = context.GetSession();
         P00NE2_A127SolicitudesID = new long[1] ;
         P00NE2_A194SolicitudesAutoEnumerar = new short[1] ;
         P00NE2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00NE2_A212SolicitudesCotizacion = new decimal[1] ;
         A210SolicitudServicioSolCoti = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambiasolicitudesautoenumerar__default(),
            new Object[][] {
                new Object[] {
               P00NE2_A127SolicitudesID, P00NE2_A194SolicitudesAutoEnumerar, P00NE2_A210SolicitudServicioSolCoti, P00NE2_A212SolicitudesCotizacion
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9SolicitudesAutoEnumerarInicio ;
      private short A194SolicitudesAutoEnumerar ;
      private long A127SolicitudesID ;
      private decimal A212SolicitudesCotizacion ;
      private string A210SolicitudServicioSolCoti ;
      private IGxSession AV8WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00NE2_A127SolicitudesID ;
      private short[] P00NE2_A194SolicitudesAutoEnumerar ;
      private string[] P00NE2_A210SolicitudServicioSolCoti ;
      private decimal[] P00NE2_A212SolicitudesCotizacion ;
   }

   public class cambiasolicitudesautoenumerar__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NE2;
          prmP00NE2 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00NE3;
          prmP00NE3 = new Object[] {
          new ParDef("@SolicitudServicioSolCoti",GXType.NChar,1,0) ,
          new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NE2", "SELECT [SolicitudesID], [SolicitudesAutoEnumerar], [SolicitudServicioSolCoti], [SolicitudesCotizacion] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NE2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00NE3", "UPDATE [Solicitudes] SET [SolicitudServicioSolCoti]=@SolicitudServicioSolCoti, [SolicitudesCotizacion]=@SolicitudesCotizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00NE3)
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
