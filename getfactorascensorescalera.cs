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
   public class getfactorascensorescalera : GXProcedure
   {
      public getfactorascensorescalera( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getfactorascensorescalera( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ParametroMudanzaNombre ,
                           out decimal aP1_FactorAE )
      {
         this.AV8ParametroMudanzaNombre = aP0_ParametroMudanzaNombre;
         this.AV9FactorAE = 0 ;
         initialize();
         ExecutePrivate();
         aP1_FactorAE=this.AV9FactorAE;
      }

      public decimal executeUdp( string aP0_ParametroMudanzaNombre )
      {
         execute(aP0_ParametroMudanzaNombre, out aP1_FactorAE);
         return AV9FactorAE ;
      }

      public void executeSubmit( string aP0_ParametroMudanzaNombre ,
                                 out decimal aP1_FactorAE )
      {
         this.AV8ParametroMudanzaNombre = aP0_ParametroMudanzaNombre;
         this.AV9FactorAE = 0 ;
         SubmitImpl();
         aP1_FactorAE=this.AV9FactorAE;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV8ParametroMudanzaNombre, context.GetMessage( "Escalera", "")) == 0 )
         {
            AV10ParametroMudanzaTipo = "Escalera";
         }
         else if ( StringUtil.StrCmp(AV8ParametroMudanzaNombre, context.GetMessage( "Ascensor", "")) == 0 )
         {
            AV10ParametroMudanzaTipo = "Ascensor";
         }
         else if ( StringUtil.StrCmp(AV8ParametroMudanzaNombre, context.GetMessage( "EscaAsce", "")) == 0 )
         {
            AV10ParametroMudanzaTipo = "EscaAsce";
         }
         /* Using cursor P00FW2 */
         pr_default.execute(0, new Object[] {AV10ParametroMudanzaTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A731ParametroMudanzaTipo = P00FW2_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00FW2_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00FW2_A730ParametroMudanzaId[0];
            AV9FactorAE = (decimal)(A733ParametroMudanzaValor/ (decimal)(100));
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
         AV10ParametroMudanzaTipo = "";
         P00FW2_A731ParametroMudanzaTipo = new string[] {""} ;
         P00FW2_A733ParametroMudanzaValor = new decimal[1] ;
         P00FW2_A730ParametroMudanzaId = new short[1] ;
         A731ParametroMudanzaTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getfactorascensorescalera__default(),
            new Object[][] {
                new Object[] {
               P00FW2_A731ParametroMudanzaTipo, P00FW2_A733ParametroMudanzaValor, P00FW2_A730ParametroMudanzaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A730ParametroMudanzaId ;
      private decimal AV9FactorAE ;
      private decimal A733ParametroMudanzaValor ;
      private string AV8ParametroMudanzaNombre ;
      private string AV10ParametroMudanzaTipo ;
      private string A731ParametroMudanzaTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00FW2_A731ParametroMudanzaTipo ;
      private decimal[] P00FW2_A733ParametroMudanzaValor ;
      private short[] P00FW2_A730ParametroMudanzaId ;
      private decimal aP1_FactorAE ;
   }

   public class getfactorascensorescalera__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00FW2;
          prmP00FW2 = new Object[] {
          new ParDef("@AV10ParametroMudanzaTipo",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FW2", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = @AV10ParametroMudanzaTipo ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FW2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
