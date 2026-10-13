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
   public class obtenerzonas : GXProcedure
   {
      public obtenerzonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerzonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_DepartamentoId ,
                           long aP1_MunicipioId ,
                           out GXBaseCollection<SdtSDTZona> aP2_SDTZona )
      {
         this.AV8DepartamentoId = aP0_DepartamentoId;
         this.AV16MunicipioId = aP1_MunicipioId;
         this.AV14SDTZona = new GXBaseCollection<SdtSDTZona>( context, "SDTZona", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP2_SDTZona=this.AV14SDTZona;
      }

      public GXBaseCollection<SdtSDTZona> executeUdp( long aP0_DepartamentoId ,
                                                      long aP1_MunicipioId )
      {
         execute(aP0_DepartamentoId, aP1_MunicipioId, out aP2_SDTZona);
         return AV14SDTZona ;
      }

      public void executeSubmit( long aP0_DepartamentoId ,
                                 long aP1_MunicipioId ,
                                 out GXBaseCollection<SdtSDTZona> aP2_SDTZona )
      {
         this.AV8DepartamentoId = aP0_DepartamentoId;
         this.AV16MunicipioId = aP1_MunicipioId;
         this.AV14SDTZona = new GXBaseCollection<SdtSDTZona>( context, "SDTZona", "AlmangoX") ;
         SubmitImpl();
         aP2_SDTZona=this.AV14SDTZona;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14SDTZona = new GXBaseCollection<SdtSDTZona>( context, "SDTZona", "AlmangoX");
         /* Using cursor P00MB2 */
         pr_default.execute(0, new Object[] {AV8DepartamentoId, AV16MunicipioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A906ZonasEstado = P00MB2_A906ZonasEstado[0];
            n906ZonasEstado = P00MB2_n906ZonasEstado[0];
            A908DepartamentoMunicipioEstado = P00MB2_A908DepartamentoMunicipioEstado[0];
            n908DepartamentoMunicipioEstado = P00MB2_n908DepartamentoMunicipioEstado[0];
            A114DepartamentoMunicipioId = P00MB2_A114DepartamentoMunicipioId[0];
            A907DepartamentoEstado = P00MB2_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00MB2_n907DepartamentoEstado[0];
            A112DepartamentoId = P00MB2_A112DepartamentoId[0];
            A110ZonasID = P00MB2_A110ZonasID[0];
            A111ZonasNombre = P00MB2_A111ZonasNombre[0];
            A907DepartamentoEstado = P00MB2_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00MB2_n907DepartamentoEstado[0];
            A908DepartamentoMunicipioEstado = P00MB2_A908DepartamentoMunicipioEstado[0];
            n908DepartamentoMunicipioEstado = P00MB2_n908DepartamentoMunicipioEstado[0];
            if ( StringUtil.StrCmp(A907DepartamentoEstado, context.GetMessage( "DES", "")) != 0 )
            {
               if ( StringUtil.StrCmp(A908DepartamentoMunicipioEstado, context.GetMessage( "DES", "")) != 0 )
               {
                  if ( StringUtil.StrCmp(A906ZonasEstado, context.GetMessage( "HAB", "")) == 0 )
                  {
                     AV13SDTZonaItem = new SdtSDTZona(context);
                     AV13SDTZonaItem.gxTpr_Zonasid = A110ZonasID;
                     AV13SDTZonaItem.gxTpr_Zonasnombre = A111ZonasNombre;
                     AV14SDTZona.Add(AV13SDTZonaItem, 0);
                  }
               }
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
         AV14SDTZona = new GXBaseCollection<SdtSDTZona>( context, "SDTZona", "AlmangoX");
         P00MB2_A906ZonasEstado = new string[] {""} ;
         P00MB2_n906ZonasEstado = new bool[] {false} ;
         P00MB2_A908DepartamentoMunicipioEstado = new string[] {""} ;
         P00MB2_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         P00MB2_A114DepartamentoMunicipioId = new long[1] ;
         P00MB2_A907DepartamentoEstado = new string[] {""} ;
         P00MB2_n907DepartamentoEstado = new bool[] {false} ;
         P00MB2_A112DepartamentoId = new long[1] ;
         P00MB2_A110ZonasID = new long[1] ;
         P00MB2_A111ZonasNombre = new string[] {""} ;
         A906ZonasEstado = "";
         A908DepartamentoMunicipioEstado = "";
         A907DepartamentoEstado = "";
         A111ZonasNombre = "";
         AV13SDTZonaItem = new SdtSDTZona(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerzonas__default(),
            new Object[][] {
                new Object[] {
               P00MB2_A906ZonasEstado, P00MB2_n906ZonasEstado, P00MB2_A908DepartamentoMunicipioEstado, P00MB2_n908DepartamentoMunicipioEstado, P00MB2_A114DepartamentoMunicipioId, P00MB2_A907DepartamentoEstado, P00MB2_n907DepartamentoEstado, P00MB2_A112DepartamentoId, P00MB2_A110ZonasID, P00MB2_A111ZonasNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8DepartamentoId ;
      private long AV16MunicipioId ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A110ZonasID ;
      private string A906ZonasEstado ;
      private string A908DepartamentoMunicipioEstado ;
      private string A907DepartamentoEstado ;
      private string A111ZonasNombre ;
      private bool n906ZonasEstado ;
      private bool n908DepartamentoMunicipioEstado ;
      private bool n907DepartamentoEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTZona> AV14SDTZona ;
      private IDataStoreProvider pr_default ;
      private string[] P00MB2_A906ZonasEstado ;
      private bool[] P00MB2_n906ZonasEstado ;
      private string[] P00MB2_A908DepartamentoMunicipioEstado ;
      private bool[] P00MB2_n908DepartamentoMunicipioEstado ;
      private long[] P00MB2_A114DepartamentoMunicipioId ;
      private string[] P00MB2_A907DepartamentoEstado ;
      private bool[] P00MB2_n907DepartamentoEstado ;
      private long[] P00MB2_A112DepartamentoId ;
      private long[] P00MB2_A110ZonasID ;
      private string[] P00MB2_A111ZonasNombre ;
      private SdtSDTZona AV13SDTZonaItem ;
      private GXBaseCollection<SdtSDTZona> aP2_SDTZona ;
   }

   public class obtenerzonas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MB2;
          prmP00MB2 = new Object[] {
          new ParDef("@AV8DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV16MunicipioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MB2", "SELECT T1.[ZonasEstado], T3.[DepartamentoMunicipioEstado], T1.[DepartamentoMunicipioId], T2.[DepartamentoEstado], T1.[DepartamentoId], T1.[ZonasID], T1.[ZonasNombre] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) WHERE T1.[DepartamentoId] = @AV8DepartamentoId and T1.[DepartamentoMunicipioId] = @AV16MunicipioId ORDER BY T1.[DepartamentoId], T1.[DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MB2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 120);
                return;
       }
    }

 }

}
