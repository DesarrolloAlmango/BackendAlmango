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
   public class operfilprofesionalinterno : GXProcedure
   {
      public operfilprofesionalinterno( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operfilprofesionalinterno( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out GeneXus.Programs.apis.SdtSDTPerfilProfesional aP1_SDTItem )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9SDTItem = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context) ;
         initialize();
         ExecutePrivate();
         aP1_SDTItem=this.AV9SDTItem;
      }

      public GeneXus.Programs.apis.SdtSDTPerfilProfesional executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_SDTItem);
         return AV9SDTItem ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out GeneXus.Programs.apis.SdtSDTPerfilProfesional aP1_SDTItem )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9SDTItem = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context) ;
         SubmitImpl();
         aP1_SDTItem=this.AV9SDTItem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00MI3 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00MI3_A120ProfesionalesId[0];
            A166ProfesionalesPrimerNombre = P00MI3_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00MI3_A167ProfesionalesApellidoPrimero[0];
            A677ProfesionalesExperiencia = P00MI3_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = P00MI3_n677ProfesionalesExperiencia[0];
            A268ProfesionalesFeedBackCant = P00MI3_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = P00MI3_A269ProfesionalesFeedBackProm[0];
            A40000GXC1 = P00MI3_A40000GXC1[0];
            n40000GXC1 = P00MI3_n40000GXC1[0];
            A40000GXC1 = P00MI3_A40000GXC1[0];
            n40000GXC1 = P00MI3_n40000GXC1[0];
            AV9SDTItem = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context);
            AV9SDTItem.gxTpr_Profesionalesid = A120ProfesionalesId;
            AV9SDTItem.gxTpr_Profesionalesprimernombre = A166ProfesionalesPrimerNombre;
            AV9SDTItem.gxTpr_Profesionalesapellidoprimero = A167ProfesionalesApellidoPrimero;
            AV9SDTItem.gxTpr_Profesionalesexperiencia = A677ProfesionalesExperiencia;
            AV9SDTItem.gxTpr_Trabajoscalificados = A268ProfesionalesFeedBackCant;
            if ( A268ProfesionalesFeedBackCant > 0 )
            {
               AV9SDTItem.gxTpr_Calificacion = NumberUtil.Round( A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant), 1);
            }
            else
            {
               AV9SDTItem.gxTpr_Calificacion = (decimal)(0);
            }
            AV9SDTItem.gxTpr_Trabajosfinalizados = A40000GXC1;
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
         AV9SDTItem = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context);
         P00MI3_A120ProfesionalesId = new string[] {""} ;
         P00MI3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00MI3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00MI3_A677ProfesionalesExperiencia = new string[] {""} ;
         P00MI3_n677ProfesionalesExperiencia = new bool[] {false} ;
         P00MI3_A268ProfesionalesFeedBackCant = new long[1] ;
         P00MI3_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00MI3_A40000GXC1 = new int[1] ;
         P00MI3_n40000GXC1 = new bool[] {false} ;
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A677ProfesionalesExperiencia = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.operfilprofesionalinterno__default(),
            new Object[][] {
                new Object[] {
               P00MI3_A120ProfesionalesId, P00MI3_A166ProfesionalesPrimerNombre, P00MI3_A167ProfesionalesApellidoPrimero, P00MI3_A677ProfesionalesExperiencia, P00MI3_n677ProfesionalesExperiencia, P00MI3_A268ProfesionalesFeedBackCant, P00MI3_A269ProfesionalesFeedBackProm, P00MI3_A40000GXC1, P00MI3_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A40000GXC1 ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string AV8ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private bool n677ProfesionalesExperiencia ;
      private bool n40000GXC1 ;
      private string A677ProfesionalesExperiencia ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.SdtSDTPerfilProfesional AV9SDTItem ;
      private IDataStoreProvider pr_default ;
      private string[] P00MI3_A120ProfesionalesId ;
      private string[] P00MI3_A166ProfesionalesPrimerNombre ;
      private string[] P00MI3_A167ProfesionalesApellidoPrimero ;
      private string[] P00MI3_A677ProfesionalesExperiencia ;
      private bool[] P00MI3_n677ProfesionalesExperiencia ;
      private long[] P00MI3_A268ProfesionalesFeedBackCant ;
      private decimal[] P00MI3_A269ProfesionalesFeedBackProm ;
      private int[] P00MI3_A40000GXC1 ;
      private bool[] P00MI3_n40000GXC1 ;
      private GeneXus.Programs.apis.SdtSDTPerfilProfesional aP1_SDTItem ;
   }

   public class operfilprofesionalinterno__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MI3;
          prmP00MI3 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MI3", "SELECT T1.[ProfesionalesId], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesExperiencia], T1.[ProfesionalesFeedBackCant], T1.[ProfesionalesFeedBackProm], COALESCE( T2.[GXC1], 0) AS GXC1 FROM [Profesionales] T1,  (SELECT COUNT(*) AS GXC1 FROM ([Relaciones] T3 INNER JOIN [Solicitudes] T4 ON T4.[SolicitudesID] = T3.[SolicitudesID]) WHERE (T3.[EstadoSGId] = 1) AND (T4.[EstadosSolId] = 6) AND (T3.[ProfesionalesId] = @AV8ProfesionalesId) ) T2 WHERE T1.[ProfesionalesId] = @AV8ProfesionalesId ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MI3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
