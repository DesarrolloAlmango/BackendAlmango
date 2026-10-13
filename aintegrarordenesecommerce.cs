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
   public class aintegrarordenesecommerce : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aintegrarordenesecommerce().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_DebugLog = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_DebugLog=((string)(args[0]));
         }
         else
         {
            aP0_DebugLog="";
         }
         execute(out aP0_DebugLog);
         return GX.GXRuntime.ExitCode ;
      }

      public aintegrarordenesecommerce( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aintegrarordenesecommerce( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_DebugLog )
      {
         this.AV9DebugLog = "" ;
         initialize();
         ExecutePrivate();
         aP0_DebugLog=this.AV9DebugLog;
      }

      public string executeUdp( )
      {
         execute(out aP0_DebugLog);
         return AV9DebugLog ;
      }

      public void executeSubmit( out string aP0_DebugLog )
      {
         this.AV9DebugLog = "" ;
         SubmitImpl();
         aP0_DebugLog=this.AV9DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00LQ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A552ConexionesID = P00LQ2_A552ConexionesID[0];
            n552ConexionesID = P00LQ2_n552ConexionesID[0];
            A562ConexionesEstado = P00LQ2_A562ConexionesEstado[0];
            n562ConexionesEstado = P00LQ2_n562ConexionesEstado[0];
            A133ProveedorID = P00LQ2_A133ProveedorID[0];
            A919STComerciosID = P00LQ2_A919STComerciosID[0];
            n919STComerciosID = P00LQ2_n919STComerciosID[0];
            A964ConexionesTipoIntegracion = P00LQ2_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = P00LQ2_n964ConexionesTipoIntegracion[0];
            A558ConexionesBaseURL = P00LQ2_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00LQ2_n558ConexionesBaseURL[0];
            A918MapeoID = P00LQ2_A918MapeoID[0];
            A562ConexionesEstado = P00LQ2_A562ConexionesEstado[0];
            n562ConexionesEstado = P00LQ2_n562ConexionesEstado[0];
            A964ConexionesTipoIntegracion = P00LQ2_A964ConexionesTipoIntegracion[0];
            n964ConexionesTipoIntegracion = P00LQ2_n964ConexionesTipoIntegracion[0];
            A558ConexionesBaseURL = P00LQ2_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00LQ2_n558ConexionesBaseURL[0];
            AV12STComercioId = A133ProveedorID;
            AV13EcommerceId = A919STComerciosID;
            if ( A964ConexionesTipoIntegracion == 1 )
            {
               AV14BaseApiUrl = A558ConexionesBaseURL;
               AV16Estado = "5";
               AV9DebugLog += context.GetMessage( "CTX -> ", "") + context.GetMessage( "EcommerceId=", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV13EcommerceId), 18, 0)) + " | " + context.GetMessage( "STComercioId=", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV12STComercioId), 18, 0)) + " | " + context.GetMessage( "BaseApiUrl=", "") + StringUtil.Trim( AV14BaseApiUrl) + " | " + StringUtil.NewLine( );
               new integrarfenicio(context ).execute(  AV13EcommerceId,  AV12STComercioId,  AV14BaseApiUrl,  AV16Estado, out  AV10ResultadoOk, ref  AV9DebugLog) ;
            }
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
         AV9DebugLog = "";
         P00LQ2_A552ConexionesID = new string[] {""} ;
         P00LQ2_n552ConexionesID = new bool[] {false} ;
         P00LQ2_A562ConexionesEstado = new string[] {""} ;
         P00LQ2_n562ConexionesEstado = new bool[] {false} ;
         P00LQ2_A133ProveedorID = new long[1] ;
         P00LQ2_A919STComerciosID = new long[1] ;
         P00LQ2_n919STComerciosID = new bool[] {false} ;
         P00LQ2_A964ConexionesTipoIntegracion = new short[1] ;
         P00LQ2_n964ConexionesTipoIntegracion = new bool[] {false} ;
         P00LQ2_A558ConexionesBaseURL = new string[] {""} ;
         P00LQ2_n558ConexionesBaseURL = new bool[] {false} ;
         P00LQ2_A918MapeoID = new long[1] ;
         A552ConexionesID = "";
         A562ConexionesEstado = "";
         A558ConexionesBaseURL = "";
         AV14BaseApiUrl = "";
         AV16Estado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aintegrarordenesecommerce__default(),
            new Object[][] {
                new Object[] {
               P00LQ2_A552ConexionesID, P00LQ2_n552ConexionesID, P00LQ2_A562ConexionesEstado, P00LQ2_n562ConexionesEstado, P00LQ2_A133ProveedorID, P00LQ2_A919STComerciosID, P00LQ2_n919STComerciosID, P00LQ2_A964ConexionesTipoIntegracion, P00LQ2_n964ConexionesTipoIntegracion, P00LQ2_A558ConexionesBaseURL,
               P00LQ2_n558ConexionesBaseURL, P00LQ2_A918MapeoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A964ConexionesTipoIntegracion ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A918MapeoID ;
      private long AV12STComercioId ;
      private long AV13EcommerceId ;
      private string A552ConexionesID ;
      private string A562ConexionesEstado ;
      private string A558ConexionesBaseURL ;
      private bool n552ConexionesID ;
      private bool n562ConexionesEstado ;
      private bool n919STComerciosID ;
      private bool n964ConexionesTipoIntegracion ;
      private bool n558ConexionesBaseURL ;
      private bool AV10ResultadoOk ;
      private string AV9DebugLog ;
      private string AV14BaseApiUrl ;
      private string AV16Estado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00LQ2_A552ConexionesID ;
      private bool[] P00LQ2_n552ConexionesID ;
      private string[] P00LQ2_A562ConexionesEstado ;
      private bool[] P00LQ2_n562ConexionesEstado ;
      private long[] P00LQ2_A133ProveedorID ;
      private long[] P00LQ2_A919STComerciosID ;
      private bool[] P00LQ2_n919STComerciosID ;
      private short[] P00LQ2_A964ConexionesTipoIntegracion ;
      private bool[] P00LQ2_n964ConexionesTipoIntegracion ;
      private string[] P00LQ2_A558ConexionesBaseURL ;
      private bool[] P00LQ2_n558ConexionesBaseURL ;
      private long[] P00LQ2_A918MapeoID ;
      private string aP0_DebugLog ;
   }

   public class aintegrarordenesecommerce__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LQ2;
          prmP00LQ2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00LQ2", "SELECT T1.[ConexionesID], T2.[ConexionesEstado], T1.[ProveedorID], T1.[STComerciosID], T2.[ConexionesTipoIntegracion], T2.[ConexionesBaseURL], T1.[MapeoID] FROM ([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) WHERE T2.[ConexionesEstado] = 'HAB' ORDER BY T1.[MapeoID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LQ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 9);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 128);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
