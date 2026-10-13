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
namespace GeneXus.Programs.apis {
   public class olimitordensinfinalizar : GXProcedure
   {
      public olimitordensinfinalizar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public olimitordensinfinalizar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out short aP1_ValorNum )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9ValorNum = 0 ;
         initialize();
         ExecutePrivate();
         aP1_ValorNum=this.AV9ValorNum;
      }

      public short executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_ValorNum);
         return AV9ValorNum ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out short aP1_ValorNum )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9ValorNum = 0 ;
         SubmitImpl();
         aP1_ValorNum=this.AV9ValorNum;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00JL2 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00JL2_A120ProfesionalesId[0];
            A617ProfesionalesLimitOSF = P00JL2_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = P00JL2_n617ProfesionalesLimitOSF[0];
            AV9ValorNum = A617ProfesionalesLimitOSF;
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
         P00JL2_A120ProfesionalesId = new string[] {""} ;
         P00JL2_A617ProfesionalesLimitOSF = new short[1] ;
         P00JL2_n617ProfesionalesLimitOSF = new bool[] {false} ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.olimitordensinfinalizar__default(),
            new Object[][] {
                new Object[] {
               P00JL2_A120ProfesionalesId, P00JL2_A617ProfesionalesLimitOSF, P00JL2_n617ProfesionalesLimitOSF
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9ValorNum ;
      private short A617ProfesionalesLimitOSF ;
      private string AV8ProfesionalesId ;
      private string A120ProfesionalesId ;
      private bool n617ProfesionalesLimitOSF ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00JL2_A120ProfesionalesId ;
      private short[] P00JL2_A617ProfesionalesLimitOSF ;
      private bool[] P00JL2_n617ProfesionalesLimitOSF ;
      private short aP1_ValorNum ;
   }

   public class olimitordensinfinalizar__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JL2;
          prmP00JL2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JL2", "SELECT [ProfesionalesId], [ProfesionalesLimitOSF] FROM [Profesionales] WHERE [ProfesionalesId] = @AV8ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JL2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
