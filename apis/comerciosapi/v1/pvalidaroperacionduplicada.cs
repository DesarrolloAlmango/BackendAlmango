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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class pvalidaroperacionduplicada : GXProcedure
   {
      public pvalidaroperacionduplicada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pvalidaroperacionduplicada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_OrderId ,
                           long aP1_ProveedorID ,
                           long aP2_EcommerceId ,
                           out bool aP3_Existe ,
                           out long aP4_TrackingIdEncontrado )
      {
         this.AV9OrderId = aP0_OrderId;
         this.AV13ProveedorID = aP1_ProveedorID;
         this.AV11EcommerceId = aP2_EcommerceId;
         this.AV8Existe = false ;
         this.AV12TrackingIdEncontrado = 0 ;
         initialize();
         ExecutePrivate();
         aP3_Existe=this.AV8Existe;
         aP4_TrackingIdEncontrado=this.AV12TrackingIdEncontrado;
      }

      public long executeUdp( string aP0_OrderId ,
                              long aP1_ProveedorID ,
                              long aP2_EcommerceId ,
                              out bool aP3_Existe )
      {
         execute(aP0_OrderId, aP1_ProveedorID, aP2_EcommerceId, out aP3_Existe, out aP4_TrackingIdEncontrado);
         return AV12TrackingIdEncontrado ;
      }

      public void executeSubmit( string aP0_OrderId ,
                                 long aP1_ProveedorID ,
                                 long aP2_EcommerceId ,
                                 out bool aP3_Existe ,
                                 out long aP4_TrackingIdEncontrado )
      {
         this.AV9OrderId = aP0_OrderId;
         this.AV13ProveedorID = aP1_ProveedorID;
         this.AV11EcommerceId = aP2_EcommerceId;
         this.AV8Existe = false ;
         this.AV12TrackingIdEncontrado = 0 ;
         SubmitImpl();
         aP3_Existe=this.AV8Existe;
         aP4_TrackingIdEncontrado=this.AV12TrackingIdEncontrado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Existe = false;
         AV12TrackingIdEncontrado = 0;
         /* Using cursor P00MT2 */
         pr_default.execute(0, new Object[] {AV9OrderId, AV13ProveedorID, AV11EcommerceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A555OperacionesRef = P00MT2_A555OperacionesRef[0];
            n555OperacionesRef = P00MT2_n555OperacionesRef[0];
            A577OperacionesEstado = P00MT2_A577OperacionesEstado[0];
            n577OperacionesEstado = P00MT2_n577OperacionesEstado[0];
            A963OperacionesComercioId2 = P00MT2_A963OperacionesComercioId2[0];
            n963OperacionesComercioId2 = P00MT2_n963OperacionesComercioId2[0];
            A962OperacionesComercioId1 = P00MT2_A962OperacionesComercioId1[0];
            n962OperacionesComercioId1 = P00MT2_n962OperacionesComercioId1[0];
            A554OperacionesId = P00MT2_A554OperacionesId[0];
            AV8Existe = true;
            AV12TrackingIdEncontrado = A554OperacionesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00MT2_A555OperacionesRef = new string[] {""} ;
         P00MT2_n555OperacionesRef = new bool[] {false} ;
         P00MT2_A577OperacionesEstado = new string[] {""} ;
         P00MT2_n577OperacionesEstado = new bool[] {false} ;
         P00MT2_A963OperacionesComercioId2 = new long[1] ;
         P00MT2_n963OperacionesComercioId2 = new bool[] {false} ;
         P00MT2_A962OperacionesComercioId1 = new long[1] ;
         P00MT2_n962OperacionesComercioId1 = new bool[] {false} ;
         P00MT2_A554OperacionesId = new long[1] ;
         A555OperacionesRef = "";
         A577OperacionesEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pvalidaroperacionduplicada__default(),
            new Object[][] {
                new Object[] {
               P00MT2_A555OperacionesRef, P00MT2_n555OperacionesRef, P00MT2_A577OperacionesEstado, P00MT2_n577OperacionesEstado, P00MT2_A963OperacionesComercioId2, P00MT2_n963OperacionesComercioId2, P00MT2_A962OperacionesComercioId1, P00MT2_n962OperacionesComercioId1, P00MT2_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV13ProveedorID ;
      private long AV11EcommerceId ;
      private long AV12TrackingIdEncontrado ;
      private long A963OperacionesComercioId2 ;
      private long A962OperacionesComercioId1 ;
      private long A554OperacionesId ;
      private string A555OperacionesRef ;
      private string A577OperacionesEstado ;
      private bool AV8Existe ;
      private bool n555OperacionesRef ;
      private bool n577OperacionesEstado ;
      private bool n963OperacionesComercioId2 ;
      private bool n962OperacionesComercioId1 ;
      private string AV9OrderId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MT2_A555OperacionesRef ;
      private bool[] P00MT2_n555OperacionesRef ;
      private string[] P00MT2_A577OperacionesEstado ;
      private bool[] P00MT2_n577OperacionesEstado ;
      private long[] P00MT2_A963OperacionesComercioId2 ;
      private bool[] P00MT2_n963OperacionesComercioId2 ;
      private long[] P00MT2_A962OperacionesComercioId1 ;
      private bool[] P00MT2_n962OperacionesComercioId1 ;
      private long[] P00MT2_A554OperacionesId ;
      private bool aP3_Existe ;
      private long aP4_TrackingIdEncontrado ;
   }

   public class pvalidaroperacionduplicada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MT2;
          prmP00MT2 = new Object[] {
          new ParDef("@AV9OrderId",GXType.NVarChar,20,0) ,
          new ParDef("@AV13ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV11EcommerceId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MT2", "SELECT TOP 1 [OperacionesRef], [OperacionesEstado], [OperacionesComercioId2], [OperacionesComercioId1], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesEstado] = 'PRO' or [OperacionesEstado] = 'PND') AND ([OperacionesRef] = RTRIM(LTRIM(@AV9OrderId))) AND ([OperacionesComercioId1] = @AV13ProveedorID) AND ([OperacionesComercioId2] = @AV11EcommerceId) ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MT2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
