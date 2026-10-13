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
   public class consultarpagopendientemudanza : GXProcedure
   {
      public consultarpagopendientemudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public consultarpagopendientemudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           out long aP1_SolicitudesId ,
                           out string aP2_Pagado )
      {
         this.AV10MudanzaId = aP0_MudanzaId;
         this.AV8SolicitudesId = 0 ;
         this.AV9Pagado = "" ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudesId=this.AV8SolicitudesId;
         aP2_Pagado=this.AV9Pagado;
      }

      public string executeUdp( long aP0_MudanzaId ,
                                out long aP1_SolicitudesId )
      {
         execute(aP0_MudanzaId, out aP1_SolicitudesId, out aP2_Pagado);
         return AV9Pagado ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 out long aP1_SolicitudesId ,
                                 out string aP2_Pagado )
      {
         this.AV10MudanzaId = aP0_MudanzaId;
         this.AV8SolicitudesId = 0 ;
         this.AV9Pagado = "" ;
         SubmitImpl();
         aP1_SolicitudesId=this.AV8SolicitudesId;
         aP2_Pagado=this.AV9Pagado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00IE2 */
         pr_default.execute(0, new Object[] {AV10MudanzaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A735MudanzaId = P00IE2_A735MudanzaId[0];
            n735MudanzaId = P00IE2_n735MudanzaId[0];
            A441SolicitudesPagado = P00IE2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00IE2_n441SolicitudesPagado[0];
            A127SolicitudesID = P00IE2_A127SolicitudesID[0];
            AV9Pagado = A441SolicitudesPagado;
            AV8SolicitudesId = A127SolicitudesID;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9Pagado = "";
         P00IE2_A735MudanzaId = new long[1] ;
         P00IE2_n735MudanzaId = new bool[] {false} ;
         P00IE2_A441SolicitudesPagado = new string[] {""} ;
         P00IE2_n441SolicitudesPagado = new bool[] {false} ;
         P00IE2_A127SolicitudesID = new long[1] ;
         A441SolicitudesPagado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.consultarpagopendientemudanza__default(),
            new Object[][] {
                new Object[] {
               P00IE2_A735MudanzaId, P00IE2_n735MudanzaId, P00IE2_A441SolicitudesPagado, P00IE2_n441SolicitudesPagado, P00IE2_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10MudanzaId ;
      private long AV8SolicitudesId ;
      private long A735MudanzaId ;
      private long A127SolicitudesID ;
      private string AV9Pagado ;
      private string A441SolicitudesPagado ;
      private bool n735MudanzaId ;
      private bool n441SolicitudesPagado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00IE2_A735MudanzaId ;
      private bool[] P00IE2_n735MudanzaId ;
      private string[] P00IE2_A441SolicitudesPagado ;
      private bool[] P00IE2_n441SolicitudesPagado ;
      private long[] P00IE2_A127SolicitudesID ;
      private long aP1_SolicitudesId ;
      private string aP2_Pagado ;
   }

   public class consultarpagopendientemudanza__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00IE2;
          prmP00IE2 = new Object[] {
          new ParDef("@AV10MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IE2", "SELECT [MudanzaId], [SolicitudesPagado], [SolicitudesID] FROM [Solicitudes] WHERE [MudanzaId] = @AV10MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IE2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
