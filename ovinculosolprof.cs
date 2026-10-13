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
   public class ovinculosolprof : GXProcedure
   {
      public ovinculosolprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ovinculosolprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_ProfesionalesId ,
                           out bool aP2_Vinculo )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV9Vinculo = false ;
         initialize();
         ExecutePrivate();
         aP2_Vinculo=this.AV9Vinculo;
      }

      public bool executeUdp( long aP0_SolicitudesID ,
                              string aP1_ProfesionalesId )
      {
         execute(aP0_SolicitudesID, aP1_ProfesionalesId, out aP2_Vinculo);
         return AV9Vinculo ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_ProfesionalesId ,
                                 out bool aP2_Vinculo )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV9Vinculo = false ;
         SubmitImpl();
         aP2_Vinculo=this.AV9Vinculo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Vinculo = false;
         /* Using cursor P00GL2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00GL2_A127SolicitudesID[0];
            A140RelacionesId = P00GL2_A140RelacionesId[0];
            A142EstadoSGId = P00GL2_A142EstadoSGId[0];
            A141EstadoSGTipo = P00GL2_A141EstadoSGTipo[0];
            A120ProfesionalesId = P00GL2_A120ProfesionalesId[0];
            if ( A140RelacionesId > 0 )
            {
               if ( ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 ) && ( A142EstadoSGId == 1 ) )
               {
                  if ( StringUtil.StrCmp(A120ProfesionalesId, AV10ProfesionalesId) != 0 )
                  {
                     AV9Vinculo = true;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
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
         P00GL2_A127SolicitudesID = new long[1] ;
         P00GL2_A140RelacionesId = new long[1] ;
         P00GL2_A142EstadoSGId = new int[1] ;
         P00GL2_A141EstadoSGTipo = new string[] {""} ;
         P00GL2_A120ProfesionalesId = new string[] {""} ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ovinculosolprof__default(),
            new Object[][] {
                new Object[] {
               P00GL2_A127SolicitudesID, P00GL2_A140RelacionesId, P00GL2_A142EstadoSGId, P00GL2_A141EstadoSGTipo, P00GL2_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A142EstadoSGId ;
      private long AV8SolicitudesID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV10ProfesionalesId ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private bool AV9Vinculo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GL2_A127SolicitudesID ;
      private long[] P00GL2_A140RelacionesId ;
      private int[] P00GL2_A142EstadoSGId ;
      private string[] P00GL2_A141EstadoSGTipo ;
      private string[] P00GL2_A120ProfesionalesId ;
      private bool aP2_Vinculo ;
   }

   public class ovinculosolprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GL2;
          prmP00GL2 = new Object[] {
          new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GL2", "SELECT [SolicitudesID], [RelacionesId], [EstadoSGId], [EstadoSGTipo], [ProfesionalesId] FROM [Relaciones] WHERE [SolicitudesID] = @AV8SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GL2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
       }
    }

 }

}
