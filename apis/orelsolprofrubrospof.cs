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
   public class orelsolprofrubrospof : GXProcedure
   {
      public orelsolprofrubrospof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orelsolprofrubrospof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           out bool aP2_exists )
      {
         this.AV9SolicitudesId = aP0_SolicitudesId;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10exists = false ;
         initialize();
         ExecutePrivate();
         aP2_exists=this.AV10exists;
      }

      public bool executeUdp( long aP0_SolicitudesId ,
                              string aP1_ProfesionalesId )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, out aP2_exists);
         return AV10exists ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 out bool aP2_exists )
      {
         this.AV9SolicitudesId = aP0_SolicitudesId;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10exists = false ;
         SubmitImpl();
         aP2_exists=this.AV10exists;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11ListaTubrosId.Clear();
         AV10exists = false;
         /* Using cursor P00JD2 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124EstadosProfRubTipo = P00JD2_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = P00JD2_A125EstadosProfRubId[0];
            A120ProfesionalesId = P00JD2_A120ProfesionalesId[0];
            A121RubrosId = P00JD2_A121RubrosId[0];
            if ( StringUtil.StrCmp(A124EstadosProfRubTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV11ListaTubrosId.Add(A121RubrosId, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11ListaTubrosId.Count < 1 )
         {
            cleanup();
            if (true) return;
         }
         AV13GXLvl16 = 0;
         /* Using cursor P00JD3 */
         pr_default.execute(1, new Object[] {AV9SolicitudesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127SolicitudesID = P00JD3_A127SolicitudesID[0];
            A121RubrosId = P00JD3_A121RubrosId[0];
            A134SolicitudesItemsID = P00JD3_A134SolicitudesItemsID[0];
            AV13GXLvl16 = 1;
            if ( (AV11ListaTubrosId.IndexOf(A121RubrosId)>0) )
            {
               AV10exists = true;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV13GXLvl16 == 0 )
         {
            AV10exists = false;
         }
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
         AV11ListaTubrosId = new GxSimpleCollection<short>();
         P00JD2_A124EstadosProfRubTipo = new string[] {""} ;
         P00JD2_A125EstadosProfRubId = new int[1] ;
         P00JD2_A120ProfesionalesId = new string[] {""} ;
         P00JD2_A121RubrosId = new short[1] ;
         A124EstadosProfRubTipo = "";
         A120ProfesionalesId = "";
         P00JD3_A127SolicitudesID = new long[1] ;
         P00JD3_A121RubrosId = new short[1] ;
         P00JD3_A134SolicitudesItemsID = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.orelsolprofrubrospof__default(),
            new Object[][] {
                new Object[] {
               P00JD2_A124EstadosProfRubTipo, P00JD2_A125EstadosProfRubId, P00JD2_A120ProfesionalesId, P00JD2_A121RubrosId
               }
               , new Object[] {
               P00JD3_A127SolicitudesID, P00JD3_A121RubrosId, P00JD3_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private short AV13GXLvl16 ;
      private short A134SolicitudesItemsID ;
      private int A125EstadosProfRubId ;
      private long AV9SolicitudesId ;
      private long A127SolicitudesID ;
      private string AV8ProfesionalesId ;
      private string A124EstadosProfRubTipo ;
      private string A120ProfesionalesId ;
      private bool AV10exists ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV11ListaTubrosId ;
      private IDataStoreProvider pr_default ;
      private string[] P00JD2_A124EstadosProfRubTipo ;
      private int[] P00JD2_A125EstadosProfRubId ;
      private string[] P00JD2_A120ProfesionalesId ;
      private short[] P00JD2_A121RubrosId ;
      private long[] P00JD3_A127SolicitudesID ;
      private short[] P00JD3_A121RubrosId ;
      private short[] P00JD3_A134SolicitudesItemsID ;
      private bool aP2_exists ;
   }

   public class orelsolprofrubrospof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JD2;
          prmP00JD2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JD3;
          prmP00JD3 = new Object[] {
          new ParDef("@AV9SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JD2", "SELECT [EstadosProfRubTipo], [EstadosProfRubId], [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE ([ProfesionalesId] = @AV8ProfesionalesId) AND ([EstadosProfRubId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JD2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00JD3", "SELECT [SolicitudesID], [RubrosId], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV9SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JD3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
