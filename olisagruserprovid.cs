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
   public class olisagruserprovid : GXProcedure
   {
      public olisagruserprovid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public olisagruserprovid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecUserId ,
                           long aP1_ProveedorID ,
                           string aP2_ListaTipo ,
                           out bool aP3_Existe ,
                           out string aP4_AgrProveedorEstado )
      {
         this.AV8SecUserId = aP0_SecUserId;
         this.AV9ProveedorID = aP1_ProveedorID;
         this.AV12ListaTipo = aP2_ListaTipo;
         this.AV11Existe = false ;
         this.AV10AgrProveedorEstado = "" ;
         initialize();
         ExecutePrivate();
         aP3_Existe=this.AV11Existe;
         aP4_AgrProveedorEstado=this.AV10AgrProveedorEstado;
      }

      public string executeUdp( long aP0_SecUserId ,
                                long aP1_ProveedorID ,
                                string aP2_ListaTipo ,
                                out bool aP3_Existe )
      {
         execute(aP0_SecUserId, aP1_ProveedorID, aP2_ListaTipo, out aP3_Existe, out aP4_AgrProveedorEstado);
         return AV10AgrProveedorEstado ;
      }

      public void executeSubmit( long aP0_SecUserId ,
                                 long aP1_ProveedorID ,
                                 string aP2_ListaTipo ,
                                 out bool aP3_Existe ,
                                 out string aP4_AgrProveedorEstado )
      {
         this.AV8SecUserId = aP0_SecUserId;
         this.AV9ProveedorID = aP1_ProveedorID;
         this.AV12ListaTipo = aP2_ListaTipo;
         this.AV11Existe = false ;
         this.AV10AgrProveedorEstado = "" ;
         SubmitImpl();
         aP3_Existe=this.AV11Existe;
         aP4_AgrProveedorEstado=this.AV10AgrProveedorEstado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10AgrProveedorEstado = "DES";
         AV11Existe = false;
         /* Using cursor P008Z2 */
         pr_default.execute(0, new Object[] {AV9ProveedorID, AV8SecUserId, AV12ListaTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A590Listaid = P008Z2_A590Listaid[0];
            A133ProveedorID = P008Z2_A133ProveedorID[0];
            A599ListaAgrUserEstado = P008Z2_A599ListaAgrUserEstado[0];
            A591ListaTipo = P008Z2_A591ListaTipo[0];
            A18SecUserId = P008Z2_A18SecUserId[0];
            A594AgrProveedorEstado = P008Z2_A594AgrProveedorEstado[0];
            n594AgrProveedorEstado = P008Z2_n594AgrProveedorEstado[0];
            A591ListaTipo = P008Z2_A591ListaTipo[0];
            A599ListaAgrUserEstado = P008Z2_A599ListaAgrUserEstado[0];
            AV11Existe = true;
            AV10AgrProveedorEstado = A594AgrProveedorEstado;
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
         AV10AgrProveedorEstado = "";
         P008Z2_A590Listaid = new long[1] ;
         P008Z2_A133ProveedorID = new long[1] ;
         P008Z2_A599ListaAgrUserEstado = new string[] {""} ;
         P008Z2_A591ListaTipo = new string[] {""} ;
         P008Z2_A18SecUserId = new long[1] ;
         P008Z2_A594AgrProveedorEstado = new string[] {""} ;
         P008Z2_n594AgrProveedorEstado = new bool[] {false} ;
         A599ListaAgrUserEstado = "";
         A591ListaTipo = "";
         A594AgrProveedorEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.olisagruserprovid__default(),
            new Object[][] {
                new Object[] {
               P008Z2_A590Listaid, P008Z2_A133ProveedorID, P008Z2_A599ListaAgrUserEstado, P008Z2_A591ListaTipo, P008Z2_A18SecUserId, P008Z2_A594AgrProveedorEstado, P008Z2_n594AgrProveedorEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8SecUserId ;
      private long AV9ProveedorID ;
      private long A590Listaid ;
      private long A133ProveedorID ;
      private long A18SecUserId ;
      private string AV12ListaTipo ;
      private string AV10AgrProveedorEstado ;
      private string A599ListaAgrUserEstado ;
      private string A591ListaTipo ;
      private string A594AgrProveedorEstado ;
      private bool AV11Existe ;
      private bool n594AgrProveedorEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008Z2_A590Listaid ;
      private long[] P008Z2_A133ProveedorID ;
      private string[] P008Z2_A599ListaAgrUserEstado ;
      private string[] P008Z2_A591ListaTipo ;
      private long[] P008Z2_A18SecUserId ;
      private string[] P008Z2_A594AgrProveedorEstado ;
      private bool[] P008Z2_n594AgrProveedorEstado ;
      private bool aP3_Existe ;
      private string aP4_AgrProveedorEstado ;
   }

   public class olisagruserprovid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008Z2;
          prmP008Z2 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8SecUserId",GXType.Decimal,10,0) ,
          new ParDef("@AV12ListaTipo",GXType.NChar,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Z2", "SELECT TOP 1 T1.[Listaid], T1.[ProveedorID], T3.[ListaAgrUserEstado], T2.[ListaTipo], T1.[SecUserId], T1.[AgrProveedorEstado] FROM (([ListaAgrUserProveedor] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [ListaAgrUser] T3 ON T3.[Listaid] = T1.[Listaid] AND T3.[SecUserId] = T1.[SecUserId]) WHERE (T1.[ProveedorID] = @AV9ProveedorID or @AV9ProveedorID = 0) AND (T1.[SecUserId] = @AV8SecUserId) AND (T2.[ListaTipo] = @AV12ListaTipo) AND (T3.[ListaAgrUserEstado] = 'HAB') ORDER BY T1.[Listaid], T1.[SecUserId], T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
