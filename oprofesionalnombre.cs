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
   public class oprofesionalnombre : GXProcedure
   {
      public oprofesionalnombre( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oprofesionalnombre( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out string aP1_nombreProfesional ,
                           out long aP2_ProfesionalesFeedBackCant ,
                           out decimal aP3_ProfesionalesFeedBackProm ,
                           out decimal aP4_ProfesionalesFeedback )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV13nombreProfesional = "" ;
         this.AV10ProfesionalesFeedBackCant = 0 ;
         this.AV11ProfesionalesFeedBackProm = 0 ;
         this.AV12ProfesionalesFeedback = 0 ;
         initialize();
         ExecutePrivate();
         aP1_nombreProfesional=this.AV13nombreProfesional;
         aP2_ProfesionalesFeedBackCant=this.AV10ProfesionalesFeedBackCant;
         aP3_ProfesionalesFeedBackProm=this.AV11ProfesionalesFeedBackProm;
         aP4_ProfesionalesFeedback=this.AV12ProfesionalesFeedback;
      }

      public decimal executeUdp( string aP0_ProfesionalesId ,
                                 out string aP1_nombreProfesional ,
                                 out long aP2_ProfesionalesFeedBackCant ,
                                 out decimal aP3_ProfesionalesFeedBackProm )
      {
         execute(aP0_ProfesionalesId, out aP1_nombreProfesional, out aP2_ProfesionalesFeedBackCant, out aP3_ProfesionalesFeedBackProm, out aP4_ProfesionalesFeedback);
         return AV12ProfesionalesFeedback ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out string aP1_nombreProfesional ,
                                 out long aP2_ProfesionalesFeedBackCant ,
                                 out decimal aP3_ProfesionalesFeedBackProm ,
                                 out decimal aP4_ProfesionalesFeedback )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV13nombreProfesional = "" ;
         this.AV10ProfesionalesFeedBackCant = 0 ;
         this.AV11ProfesionalesFeedBackProm = 0 ;
         this.AV12ProfesionalesFeedback = 0 ;
         SubmitImpl();
         aP1_nombreProfesional=this.AV13nombreProfesional;
         aP2_ProfesionalesFeedBackCant=this.AV10ProfesionalesFeedBackCant;
         aP3_ProfesionalesFeedBackProm=this.AV11ProfesionalesFeedBackProm;
         aP4_ProfesionalesFeedback=this.AV12ProfesionalesFeedback;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008C2 */
         pr_default.execute(0, new Object[] {AV9ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P008C2_A120ProfesionalesId[0];
            A167ProfesionalesApellidoPrimero = P008C2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P008C2_A166ProfesionalesPrimerNombre[0];
            A268ProfesionalesFeedBackCant = P008C2_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = P008C2_A269ProfesionalesFeedBackProm[0];
            if ( A268ProfesionalesFeedBackCant > 0 )
            {
               A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
            }
            else
            {
               A270ProfesionalesFeedback = 0;
            }
            AV13nombreProfesional = StringUtil.Trim( A166ProfesionalesPrimerNombre) + ", " + StringUtil.Trim( A167ProfesionalesApellidoPrimero);
            AV10ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
            AV11ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
            AV12ProfesionalesFeedback = A270ProfesionalesFeedback;
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
         AV13nombreProfesional = "";
         P008C2_A120ProfesionalesId = new string[] {""} ;
         P008C2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P008C2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P008C2_A268ProfesionalesFeedBackCant = new long[1] ;
         P008C2_A269ProfesionalesFeedBackProm = new decimal[1] ;
         A120ProfesionalesId = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oprofesionalnombre__default(),
            new Object[][] {
                new Object[] {
               P008C2_A120ProfesionalesId, P008C2_A167ProfesionalesApellidoPrimero, P008C2_A166ProfesionalesPrimerNombre, P008C2_A268ProfesionalesFeedBackCant, P008C2_A269ProfesionalesFeedBackProm
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10ProfesionalesFeedBackCant ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal AV11ProfesionalesFeedBackProm ;
      private decimal AV12ProfesionalesFeedback ;
      private decimal A269ProfesionalesFeedBackProm ;
      private decimal A270ProfesionalesFeedback ;
      private string AV9ProfesionalesId ;
      private string AV13nombreProfesional ;
      private string A120ProfesionalesId ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008C2_A120ProfesionalesId ;
      private string[] P008C2_A167ProfesionalesApellidoPrimero ;
      private string[] P008C2_A166ProfesionalesPrimerNombre ;
      private long[] P008C2_A268ProfesionalesFeedBackCant ;
      private decimal[] P008C2_A269ProfesionalesFeedBackProm ;
      private string aP1_nombreProfesional ;
      private long aP2_ProfesionalesFeedBackCant ;
      private decimal aP3_ProfesionalesFeedBackProm ;
      private decimal aP4_ProfesionalesFeedback ;
   }

   public class oprofesionalnombre__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("@AV9ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "SELECT [ProfesionalesId], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm] FROM [Profesionales] WHERE [ProfesionalesId] = @AV9ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
       }
    }

 }

}
