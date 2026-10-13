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
   public class odatconexion : GXProcedure
   {
      public odatconexion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odatconexion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ConexionesID ,
                           out SdtSDTConexiones aP1_Gxm1sdtconexiones )
      {
         this.AV5ConexionesID = aP0_ConexionesID;
         this.Gxm1sdtconexiones = new SdtSDTConexiones(context) ;
         initialize();
         ExecutePrivate();
         aP1_Gxm1sdtconexiones=this.Gxm1sdtconexiones;
      }

      public SdtSDTConexiones executeUdp( string aP0_ConexionesID )
      {
         execute(aP0_ConexionesID, out aP1_Gxm1sdtconexiones);
         return Gxm1sdtconexiones ;
      }

      public void executeSubmit( string aP0_ConexionesID ,
                                 out SdtSDTConexiones aP1_Gxm1sdtconexiones )
      {
         this.AV5ConexionesID = aP0_ConexionesID;
         this.Gxm1sdtconexiones = new SdtSDTConexiones(context) ;
         SubmitImpl();
         aP1_Gxm1sdtconexiones=this.Gxm1sdtconexiones;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000E2 */
         pr_default.execute(0, new Object[] {AV5ConexionesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A552ConexionesID = P000E2_A552ConexionesID[0];
            A562ConexionesEstado = P000E2_A562ConexionesEstado[0];
            n562ConexionesEstado = P000E2_n562ConexionesEstado[0];
            A556ConexionesNombre = P000E2_A556ConexionesNombre[0];
            n556ConexionesNombre = P000E2_n556ConexionesNombre[0];
            A557ConexionesHost = P000E2_A557ConexionesHost[0];
            n557ConexionesHost = P000E2_n557ConexionesHost[0];
            A558ConexionesBaseURL = P000E2_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P000E2_n558ConexionesBaseURL[0];
            A559ConexionesPort = P000E2_A559ConexionesPort[0];
            n559ConexionesPort = P000E2_n559ConexionesPort[0];
            A560ConexionesApiKey = P000E2_A560ConexionesApiKey[0];
            n560ConexionesApiKey = P000E2_n560ConexionesApiKey[0];
            A561ConexionesUsr = P000E2_A561ConexionesUsr[0];
            n561ConexionesUsr = P000E2_n561ConexionesUsr[0];
            A563ConexionesAux1 = P000E2_A563ConexionesAux1[0];
            n563ConexionesAux1 = P000E2_n563ConexionesAux1[0];
            A564ConexionesAux2 = P000E2_A564ConexionesAux2[0];
            n564ConexionesAux2 = P000E2_n564ConexionesAux2[0];
            A565ConexionesAux3 = P000E2_A565ConexionesAux3[0];
            n565ConexionesAux3 = P000E2_n565ConexionesAux3[0];
            Gxm1sdtconexiones.gxTpr_Conexionesid = A552ConexionesID;
            Gxm1sdtconexiones.gxTpr_Conexionesnombre = A556ConexionesNombre;
            Gxm1sdtconexiones.gxTpr_Conexioneshost = A557ConexionesHost;
            Gxm1sdtconexiones.gxTpr_Conexionesbaseurl = A558ConexionesBaseURL;
            Gxm1sdtconexiones.gxTpr_Conexionesport = A559ConexionesPort;
            Gxm1sdtconexiones.gxTpr_Conexionesapikey = A560ConexionesApiKey;
            Gxm1sdtconexiones.gxTpr_Conexionesusr = A561ConexionesUsr;
            Gxm1sdtconexiones.gxTpr_Conexionesaux1 = A563ConexionesAux1;
            Gxm1sdtconexiones.gxTpr_Conexionesaux2 = A564ConexionesAux2;
            Gxm1sdtconexiones.gxTpr_Conexionesaux3 = A565ConexionesAux3;
            Gxm1sdtconexiones.gxTpr_Conexionesestado = A562ConexionesEstado;
            /* Using cursor P000E3 */
            pr_default.execute(1, new Object[] {A552ConexionesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A553ConexionesDatosId = P000E3_A553ConexionesDatosId[0];
               A566ConexionesDatosInt = P000E3_A566ConexionesDatosInt[0];
               n566ConexionesDatosInt = P000E3_n566ConexionesDatosInt[0];
               A567ConexionesDatosExt = P000E3_A567ConexionesDatosExt[0];
               n567ConexionesDatosExt = P000E3_n567ConexionesDatosExt[0];
               A568ConexionesDatosDetalle = P000E3_A568ConexionesDatosDetalle[0];
               n568ConexionesDatosDetalle = P000E3_n568ConexionesDatosDetalle[0];
               Gxm2sdtconexiones_datos = new SdtSDTConexiones_Item(context);
               Gxm1sdtconexiones.gxTpr_Datos.Add(Gxm2sdtconexiones_datos, 0);
               Gxm2sdtconexiones_datos.gxTpr_Conexionesdatosid = A553ConexionesDatosId;
               Gxm2sdtconexiones_datos.gxTpr_Conexionesdatosint = A566ConexionesDatosInt;
               Gxm2sdtconexiones_datos.gxTpr_Conexionesdatosext = A567ConexionesDatosExt;
               Gxm2sdtconexiones_datos.gxTpr_Conexionesdatosdetalle = A568ConexionesDatosDetalle;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         P000E2_A552ConexionesID = new string[] {""} ;
         P000E2_A562ConexionesEstado = new string[] {""} ;
         P000E2_n562ConexionesEstado = new bool[] {false} ;
         P000E2_A556ConexionesNombre = new string[] {""} ;
         P000E2_n556ConexionesNombre = new bool[] {false} ;
         P000E2_A557ConexionesHost = new string[] {""} ;
         P000E2_n557ConexionesHost = new bool[] {false} ;
         P000E2_A558ConexionesBaseURL = new string[] {""} ;
         P000E2_n558ConexionesBaseURL = new bool[] {false} ;
         P000E2_A559ConexionesPort = new int[1] ;
         P000E2_n559ConexionesPort = new bool[] {false} ;
         P000E2_A560ConexionesApiKey = new string[] {""} ;
         P000E2_n560ConexionesApiKey = new bool[] {false} ;
         P000E2_A561ConexionesUsr = new string[] {""} ;
         P000E2_n561ConexionesUsr = new bool[] {false} ;
         P000E2_A563ConexionesAux1 = new string[] {""} ;
         P000E2_n563ConexionesAux1 = new bool[] {false} ;
         P000E2_A564ConexionesAux2 = new string[] {""} ;
         P000E2_n564ConexionesAux2 = new bool[] {false} ;
         P000E2_A565ConexionesAux3 = new string[] {""} ;
         P000E2_n565ConexionesAux3 = new bool[] {false} ;
         A552ConexionesID = "";
         A562ConexionesEstado = "";
         A556ConexionesNombre = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         A560ConexionesApiKey = "";
         A561ConexionesUsr = "";
         A563ConexionesAux1 = "";
         A564ConexionesAux2 = "";
         A565ConexionesAux3 = "";
         P000E3_A552ConexionesID = new string[] {""} ;
         P000E3_A553ConexionesDatosId = new string[] {""} ;
         P000E3_A566ConexionesDatosInt = new string[] {""} ;
         P000E3_n566ConexionesDatosInt = new bool[] {false} ;
         P000E3_A567ConexionesDatosExt = new string[] {""} ;
         P000E3_n567ConexionesDatosExt = new bool[] {false} ;
         P000E3_A568ConexionesDatosDetalle = new string[] {""} ;
         P000E3_n568ConexionesDatosDetalle = new bool[] {false} ;
         A553ConexionesDatosId = "";
         A566ConexionesDatosInt = "";
         A567ConexionesDatosExt = "";
         A568ConexionesDatosDetalle = "";
         Gxm2sdtconexiones_datos = new SdtSDTConexiones_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.odatconexion__default(),
            new Object[][] {
                new Object[] {
               P000E2_A552ConexionesID, P000E2_A562ConexionesEstado, P000E2_n562ConexionesEstado, P000E2_A556ConexionesNombre, P000E2_n556ConexionesNombre, P000E2_A557ConexionesHost, P000E2_n557ConexionesHost, P000E2_A558ConexionesBaseURL, P000E2_n558ConexionesBaseURL, P000E2_A559ConexionesPort,
               P000E2_n559ConexionesPort, P000E2_A560ConexionesApiKey, P000E2_n560ConexionesApiKey, P000E2_A561ConexionesUsr, P000E2_n561ConexionesUsr, P000E2_A563ConexionesAux1, P000E2_n563ConexionesAux1, P000E2_A564ConexionesAux2, P000E2_n564ConexionesAux2, P000E2_A565ConexionesAux3,
               P000E2_n565ConexionesAux3
               }
               , new Object[] {
               P000E3_A552ConexionesID, P000E3_A553ConexionesDatosId, P000E3_A566ConexionesDatosInt, P000E3_n566ConexionesDatosInt, P000E3_A567ConexionesDatosExt, P000E3_n567ConexionesDatosExt, P000E3_A568ConexionesDatosDetalle, P000E3_n568ConexionesDatosDetalle
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A559ConexionesPort ;
      private string AV5ConexionesID ;
      private string A552ConexionesID ;
      private string A562ConexionesEstado ;
      private string A556ConexionesNombre ;
      private string A557ConexionesHost ;
      private string A558ConexionesBaseURL ;
      private string A560ConexionesApiKey ;
      private string A561ConexionesUsr ;
      private string A563ConexionesAux1 ;
      private string A564ConexionesAux2 ;
      private string A565ConexionesAux3 ;
      private string A553ConexionesDatosId ;
      private string A566ConexionesDatosInt ;
      private string A567ConexionesDatosExt ;
      private string A568ConexionesDatosDetalle ;
      private bool n562ConexionesEstado ;
      private bool n556ConexionesNombre ;
      private bool n557ConexionesHost ;
      private bool n558ConexionesBaseURL ;
      private bool n559ConexionesPort ;
      private bool n560ConexionesApiKey ;
      private bool n561ConexionesUsr ;
      private bool n563ConexionesAux1 ;
      private bool n564ConexionesAux2 ;
      private bool n565ConexionesAux3 ;
      private bool n566ConexionesDatosInt ;
      private bool n567ConexionesDatosExt ;
      private bool n568ConexionesDatosDetalle ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTConexiones Gxm1sdtconexiones ;
      private IDataStoreProvider pr_default ;
      private string[] P000E2_A552ConexionesID ;
      private string[] P000E2_A562ConexionesEstado ;
      private bool[] P000E2_n562ConexionesEstado ;
      private string[] P000E2_A556ConexionesNombre ;
      private bool[] P000E2_n556ConexionesNombre ;
      private string[] P000E2_A557ConexionesHost ;
      private bool[] P000E2_n557ConexionesHost ;
      private string[] P000E2_A558ConexionesBaseURL ;
      private bool[] P000E2_n558ConexionesBaseURL ;
      private int[] P000E2_A559ConexionesPort ;
      private bool[] P000E2_n559ConexionesPort ;
      private string[] P000E2_A560ConexionesApiKey ;
      private bool[] P000E2_n560ConexionesApiKey ;
      private string[] P000E2_A561ConexionesUsr ;
      private bool[] P000E2_n561ConexionesUsr ;
      private string[] P000E2_A563ConexionesAux1 ;
      private bool[] P000E2_n563ConexionesAux1 ;
      private string[] P000E2_A564ConexionesAux2 ;
      private bool[] P000E2_n564ConexionesAux2 ;
      private string[] P000E2_A565ConexionesAux3 ;
      private bool[] P000E2_n565ConexionesAux3 ;
      private string[] P000E3_A552ConexionesID ;
      private string[] P000E3_A553ConexionesDatosId ;
      private string[] P000E3_A566ConexionesDatosInt ;
      private bool[] P000E3_n566ConexionesDatosInt ;
      private string[] P000E3_A567ConexionesDatosExt ;
      private bool[] P000E3_n567ConexionesDatosExt ;
      private string[] P000E3_A568ConexionesDatosDetalle ;
      private bool[] P000E3_n568ConexionesDatosDetalle ;
      private SdtSDTConexiones_Item Gxm2sdtconexiones_datos ;
      private SdtSDTConexiones aP1_Gxm1sdtconexiones ;
   }

   public class odatconexion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000E2;
          prmP000E2 = new Object[] {
          new ParDef("@AV5ConexionesID",GXType.NChar,9,0)
          };
          Object[] prmP000E3;
          prmP000E3 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000E2", "SELECT [ConexionesID], [ConexionesEstado], [ConexionesNombre], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3] FROM [Conexiones] WHERE (RTRIM(LTRIM([ConexionesID])) = RTRIM(LTRIM(@AV5ConexionesID))) AND ([ConexionesEstado] = 'HAB') ORDER BY [ConexionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000E3", "SELECT [ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle] FROM [ConexionesDatos] WHERE [ConexionesID] = @ConexionesID ORDER BY [ConexionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 128);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 128);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 128);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 64);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 128);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 128);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 128);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 9);
                ((string[]) buf[1])[0] = rslt.getString(2, 25);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 128);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 256);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
