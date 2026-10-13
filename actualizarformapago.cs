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
   public class actualizarformapago : GXProcedure
   {
      public actualizarformapago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarformapago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           string aP1_FormaPago ,
                           out bool aP2_Pagado )
      {
         this.AV8MudanzaId = aP0_MudanzaId;
         this.AV9FormaPago = aP1_FormaPago;
         this.AV10Pagado = false ;
         initialize();
         ExecutePrivate();
         aP2_Pagado=this.AV10Pagado;
      }

      public bool executeUdp( long aP0_MudanzaId ,
                              string aP1_FormaPago )
      {
         execute(aP0_MudanzaId, aP1_FormaPago, out aP2_Pagado);
         return AV10Pagado ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 string aP1_FormaPago ,
                                 out bool aP2_Pagado )
      {
         this.AV8MudanzaId = aP0_MudanzaId;
         this.AV9FormaPago = aP1_FormaPago;
         this.AV10Pagado = false ;
         SubmitImpl();
         aP2_Pagado=this.AV10Pagado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV9FormaPago, context.GetMessage( "EF", "")) == 0 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P00FS2 */
            pr_default.execute(0, new Object[] {AV8MudanzaId});
            pr_default.close(0);
            pr_default.SmartCacheProvider.SetUpdated("Mudanza");
            /* End optimized UPDATE. */
         }
         if ( StringUtil.StrCmp(AV9FormaPago, context.GetMessage( "MP", "")) == 0 )
         {
            /* Optimized UPDATE. */
            /* Using cursor P00FS3 */
            pr_default.execute(1, new Object[] {AV8MudanzaId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Mudanza");
            /* End optimized UPDATE. */
         }
         AV10Pagado = false;
         /* Using cursor P00FS4 */
         pr_default.execute(2, new Object[] {AV8MudanzaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A128MetodoPagosID = P00FS4_A128MetodoPagosID[0];
            A735MudanzaId = P00FS4_A735MudanzaId[0];
            n735MudanzaId = P00FS4_n735MudanzaId[0];
            A441SolicitudesPagado = P00FS4_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00FS4_n441SolicitudesPagado[0];
            A127SolicitudesID = P00FS4_A127SolicitudesID[0];
            if ( StringUtil.StrCmp(A441SolicitudesPagado, context.GetMessage( "S", "")) == 0 )
            {
               AV10Pagado = true;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizarformapago",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00FS4_A128MetodoPagosID = new long[1] ;
         P00FS4_A735MudanzaId = new long[1] ;
         P00FS4_n735MudanzaId = new bool[] {false} ;
         P00FS4_A441SolicitudesPagado = new string[] {""} ;
         P00FS4_n441SolicitudesPagado = new bool[] {false} ;
         P00FS4_A127SolicitudesID = new long[1] ;
         A441SolicitudesPagado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarformapago__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00FS4_A128MetodoPagosID, P00FS4_A735MudanzaId, P00FS4_n735MudanzaId, P00FS4_A441SolicitudesPagado, P00FS4_n441SolicitudesPagado, P00FS4_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8MudanzaId ;
      private long A128MetodoPagosID ;
      private long A735MudanzaId ;
      private long A127SolicitudesID ;
      private string A441SolicitudesPagado ;
      private bool AV10Pagado ;
      private bool n735MudanzaId ;
      private bool n441SolicitudesPagado ;
      private string AV9FormaPago ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00FS4_A128MetodoPagosID ;
      private long[] P00FS4_A735MudanzaId ;
      private bool[] P00FS4_n735MudanzaId ;
      private string[] P00FS4_A441SolicitudesPagado ;
      private bool[] P00FS4_n441SolicitudesPagado ;
      private long[] P00FS4_A127SolicitudesID ;
      private bool aP2_Pagado ;
   }

   public class actualizarformapago__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FS2;
          prmP00FS2 = new Object[] {
          new ParDef("@AV8MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00FS3;
          prmP00FS3 = new Object[] {
          new ParDef("@AV8MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00FS4;
          prmP00FS4 = new Object[] {
          new ParDef("@AV8MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FS2", "UPDATE [Mudanza] SET [MudanzaFormaPago]='Efectivo'  WHERE [MudanzaId] = @AV8MudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FS2)
             ,new CursorDef("P00FS3", "UPDATE [Mudanza] SET [MudanzaFormaPago]='MercadoP'  WHERE [MudanzaId] = @AV8MudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FS3)
             ,new CursorDef("P00FS4", "SELECT [MetodoPagosID], [MudanzaId], [SolicitudesPagado], [SolicitudesID] FROM [Solicitudes] WHERE ([MetodoPagosID] = 4) AND ([MudanzaId] = @AV8MudanzaId) ORDER BY [MetodoPagosID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FS4,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
