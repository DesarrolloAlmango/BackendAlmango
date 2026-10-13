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
   public class ocomisionglobal : GXProcedure
   {
      public ocomisionglobal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocomisionglobal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out decimal aP0_ComisionesDefaultProf )
      {
         this.AV8ComisionesDefaultProf = 0 ;
         initialize();
         ExecutePrivate();
         aP0_ComisionesDefaultProf=this.AV8ComisionesDefaultProf;
      }

      public decimal executeUdp( )
      {
         execute(out aP0_ComisionesDefaultProf);
         return AV8ComisionesDefaultProf ;
      }

      public void executeSubmit( out decimal aP0_ComisionesDefaultProf )
      {
         this.AV8ComisionesDefaultProf = 0 ;
         SubmitImpl();
         aP0_ComisionesDefaultProf=this.AV8ComisionesDefaultProf;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00I72 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A520ComisionesGlobal = P00I72_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P00I72_n520ComisionesGlobal[0];
            A511ComisionesEstado = P00I72_A511ComisionesEstado[0];
            n511ComisionesEstado = P00I72_n511ComisionesEstado[0];
            A505ComisionesTipo = P00I72_A505ComisionesTipo[0];
            A506ComisionesDefault = P00I72_A506ComisionesDefault[0];
            n506ComisionesDefault = P00I72_n506ComisionesDefault[0];
            A503ComisionesID = P00I72_A503ComisionesID[0];
            AV8ComisionesDefaultProf = A506ComisionesDefault;
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
         P00I72_A520ComisionesGlobal = new bool[] {false} ;
         P00I72_n520ComisionesGlobal = new bool[] {false} ;
         P00I72_A511ComisionesEstado = new string[] {""} ;
         P00I72_n511ComisionesEstado = new bool[] {false} ;
         P00I72_A505ComisionesTipo = new string[] {""} ;
         P00I72_A506ComisionesDefault = new decimal[1] ;
         P00I72_n506ComisionesDefault = new bool[] {false} ;
         P00I72_A503ComisionesID = new long[1] ;
         A511ComisionesEstado = "";
         A505ComisionesTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocomisionglobal__default(),
            new Object[][] {
                new Object[] {
               P00I72_A520ComisionesGlobal, P00I72_n520ComisionesGlobal, P00I72_A511ComisionesEstado, P00I72_n511ComisionesEstado, P00I72_A505ComisionesTipo, P00I72_A506ComisionesDefault, P00I72_n506ComisionesDefault, P00I72_A503ComisionesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A503ComisionesID ;
      private decimal AV8ComisionesDefaultProf ;
      private decimal A506ComisionesDefault ;
      private string A511ComisionesEstado ;
      private string A505ComisionesTipo ;
      private bool A520ComisionesGlobal ;
      private bool n520ComisionesGlobal ;
      private bool n511ComisionesEstado ;
      private bool n506ComisionesDefault ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P00I72_A520ComisionesGlobal ;
      private bool[] P00I72_n520ComisionesGlobal ;
      private string[] P00I72_A511ComisionesEstado ;
      private bool[] P00I72_n511ComisionesEstado ;
      private string[] P00I72_A505ComisionesTipo ;
      private decimal[] P00I72_A506ComisionesDefault ;
      private bool[] P00I72_n506ComisionesDefault ;
      private long[] P00I72_A503ComisionesID ;
      private decimal aP0_ComisionesDefaultProf ;
   }

   public class ocomisionglobal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00I72;
          prmP00I72 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00I72", "SELECT [ComisionesGlobal], [ComisionesEstado], [ComisionesTipo], [ComisionesDefault], [ComisionesID] FROM [Comisiones] WHERE ([ComisionesTipo] = 'P') AND ([ComisionesEstado] = 'HAB') AND ([ComisionesGlobal] = 1) ORDER BY [ComisionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I72,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
