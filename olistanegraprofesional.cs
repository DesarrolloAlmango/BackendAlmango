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
   public class olistanegraprofesional : GXProcedure
   {
      public olistanegraprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public olistanegraprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           string aP1_ProfesionalesId ,
                           out bool aP2_IsOk )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9IsOk = false ;
         initialize();
         ExecutePrivate();
         aP2_IsOk=this.AV9IsOk;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              string aP1_ProfesionalesId )
      {
         execute(aP0_ProveedorID, aP1_ProfesionalesId, out aP2_IsOk);
         return AV9IsOk ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 string aP1_ProfesionalesId ,
                                 out bool aP2_IsOk )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9IsOk = false ;
         SubmitImpl();
         aP2_IsOk=this.AV9IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsOk = false;
         /* Using cursor P00AR2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A590Listaid = P00AR2_A590Listaid[0];
            A593ListaEstado = P00AR2_A593ListaEstado[0];
            n593ListaEstado = P00AR2_n593ListaEstado[0];
            A591ListaTipo = P00AR2_A591ListaTipo[0];
            /* Using cursor P00AR3 */
            pr_default.execute(1, new Object[] {A590Listaid, AV10ProveedorID, AV8ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A588AgrupacionEstado = P00AR3_A588AgrupacionEstado[0];
               A120ProfesionalesId = P00AR3_A120ProfesionalesId[0];
               A133ProveedorID = P00AR3_A133ProveedorID[0];
               AV9IsOk = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
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
         P00AR2_A590Listaid = new long[1] ;
         P00AR2_A593ListaEstado = new string[] {""} ;
         P00AR2_n593ListaEstado = new bool[] {false} ;
         P00AR2_A591ListaTipo = new string[] {""} ;
         A593ListaEstado = "";
         A591ListaTipo = "";
         P00AR3_A590Listaid = new long[1] ;
         P00AR3_A588AgrupacionEstado = new string[] {""} ;
         P00AR3_A120ProfesionalesId = new string[] {""} ;
         P00AR3_A133ProveedorID = new long[1] ;
         A588AgrupacionEstado = "";
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.olistanegraprofesional__default(),
            new Object[][] {
                new Object[] {
               P00AR2_A590Listaid, P00AR2_A593ListaEstado, P00AR2_n593ListaEstado, P00AR2_A591ListaTipo
               }
               , new Object[] {
               P00AR3_A590Listaid, P00AR3_A588AgrupacionEstado, P00AR3_A120ProfesionalesId, P00AR3_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10ProveedorID ;
      private long A590Listaid ;
      private long A133ProveedorID ;
      private string AV8ProfesionalesId ;
      private string A593ListaEstado ;
      private string A591ListaTipo ;
      private string A588AgrupacionEstado ;
      private string A120ProfesionalesId ;
      private bool AV9IsOk ;
      private bool n593ListaEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AR2_A590Listaid ;
      private string[] P00AR2_A593ListaEstado ;
      private bool[] P00AR2_n593ListaEstado ;
      private string[] P00AR2_A591ListaTipo ;
      private long[] P00AR3_A590Listaid ;
      private string[] P00AR3_A588AgrupacionEstado ;
      private string[] P00AR3_A120ProfesionalesId ;
      private long[] P00AR3_A133ProveedorID ;
      private bool aP2_IsOk ;
   }

   public class olistanegraprofesional__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AR2;
          prmP00AR2 = new Object[] {
          };
          Object[] prmP00AR3;
          prmP00AR3 = new Object[] {
          new ParDef("@Listaid",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AR2", "SELECT [Listaid], [ListaEstado], [ListaTipo] FROM [Lista] WHERE ([Listaid] = 1) AND ([ListaTipo] = 'PROF') AND ([ListaEstado] = 'HAB') ORDER BY [Listaid] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00AR3", "SELECT [Listaid], [AgrupacionEstado], [ProfesionalesId], [ProveedorID] FROM [ListaAgrupacion] WHERE ([Listaid] = @Listaid and [ProveedorID] = @AV10ProveedorID and [ProfesionalesId] = @AV8ProfesionalesId) AND ([AgrupacionEstado] = 'VIN') ORDER BY [Listaid], [ProveedorID], [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AR3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
