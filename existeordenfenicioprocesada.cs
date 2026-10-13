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
   public class existeordenfenicioprocesada : GXProcedure
   {
      public existeordenfenicioprocesada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public existeordenfenicioprocesada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_FenicioOrderId ,
                           out bool aP1_Existe ,
                           ref string aP2_DebugLog )
      {
         this.AV8FenicioOrderId = aP0_FenicioOrderId;
         this.AV9Existe = false ;
         this.AV11DebugLog = aP2_DebugLog;
         initialize();
         ExecutePrivate();
         aP1_Existe=this.AV9Existe;
         aP2_DebugLog=this.AV11DebugLog;
      }

      public string executeUdp( string aP0_FenicioOrderId ,
                                out bool aP1_Existe )
      {
         execute(aP0_FenicioOrderId, out aP1_Existe, ref aP2_DebugLog);
         return AV11DebugLog ;
      }

      public void executeSubmit( string aP0_FenicioOrderId ,
                                 out bool aP1_Existe ,
                                 ref string aP2_DebugLog )
      {
         this.AV8FenicioOrderId = aP0_FenicioOrderId;
         this.AV9Existe = false ;
         this.AV11DebugLog = aP2_DebugLog;
         SubmitImpl();
         aP1_Existe=this.AV9Existe;
         aP2_DebugLog=this.AV11DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Existe = false;
         AV11DebugLog += context.GetMessage( "orden fenicio id", "") + AV8FenicioOrderId;
         /* Using cursor P00LF2 */
         pr_default.execute(0, new Object[] {AV8FenicioOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A577OperacionesEstado = P00LF2_A577OperacionesEstado[0];
            n577OperacionesEstado = P00LF2_n577OperacionesEstado[0];
            A555OperacionesRef = P00LF2_A555OperacionesRef[0];
            n555OperacionesRef = P00LF2_n555OperacionesRef[0];
            A554OperacionesId = P00LF2_A554OperacionesId[0];
            AV9Existe = true;
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
         P00LF2_A577OperacionesEstado = new string[] {""} ;
         P00LF2_n577OperacionesEstado = new bool[] {false} ;
         P00LF2_A555OperacionesRef = new string[] {""} ;
         P00LF2_n555OperacionesRef = new bool[] {false} ;
         P00LF2_A554OperacionesId = new long[1] ;
         A577OperacionesEstado = "";
         A555OperacionesRef = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.existeordenfenicioprocesada__default(),
            new Object[][] {
                new Object[] {
               P00LF2_A577OperacionesEstado, P00LF2_n577OperacionesEstado, P00LF2_A555OperacionesRef, P00LF2_n555OperacionesRef, P00LF2_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A554OperacionesId ;
      private string A577OperacionesEstado ;
      private string A555OperacionesRef ;
      private bool AV9Existe ;
      private bool n577OperacionesEstado ;
      private bool n555OperacionesRef ;
      private string AV11DebugLog ;
      private string AV8FenicioOrderId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP2_DebugLog ;
      private IDataStoreProvider pr_default ;
      private string[] P00LF2_A577OperacionesEstado ;
      private bool[] P00LF2_n577OperacionesEstado ;
      private string[] P00LF2_A555OperacionesRef ;
      private bool[] P00LF2_n555OperacionesRef ;
      private long[] P00LF2_A554OperacionesId ;
      private bool aP1_Existe ;
   }

   public class existeordenfenicioprocesada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LF2;
          prmP00LF2 = new Object[] {
          new ParDef("@AV8FenicioOrderId",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LF2", "SELECT TOP 1 [OperacionesEstado], [OperacionesRef], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesRef] = RTRIM(LTRIM(@AV8FenicioOrderId))) AND ([OperacionesEstado] = 'PRO') ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LF2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 25);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
