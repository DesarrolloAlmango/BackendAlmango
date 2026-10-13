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
   public class oexisterelacion : GXProcedure
   {
      public oexisterelacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oexisterelacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_ProfesionalesId ,
                           out string aP2_Exists )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV8Exists = "" ;
         initialize();
         ExecutePrivate();
         aP2_Exists=this.AV8Exists;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                string aP1_ProfesionalesId )
      {
         execute(aP0_SolicitudesID, aP1_ProfesionalesId, out aP2_Exists);
         return AV8Exists ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_ProfesionalesId ,
                                 out string aP2_Exists )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV8Exists = "" ;
         SubmitImpl();
         aP2_Exists=this.AV8Exists;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Exists = context.GetMessage( "N", "");
         /* Using cursor P008D2 */
         pr_default.execute(0, new Object[] {AV9SolicitudesID, AV10ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A142EstadoSGId = P008D2_A142EstadoSGId[0];
            A141EstadoSGTipo = P008D2_A141EstadoSGTipo[0];
            A120ProfesionalesId = P008D2_A120ProfesionalesId[0];
            A127SolicitudesID = P008D2_A127SolicitudesID[0];
            A140RelacionesId = P008D2_A140RelacionesId[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV8Exists = context.GetMessage( "S", "");
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
         AV8Exists = "";
         P008D2_A142EstadoSGId = new int[1] ;
         P008D2_A141EstadoSGTipo = new string[] {""} ;
         P008D2_A120ProfesionalesId = new string[] {""} ;
         P008D2_A127SolicitudesID = new long[1] ;
         P008D2_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oexisterelacion__default(),
            new Object[][] {
                new Object[] {
               P008D2_A142EstadoSGId, P008D2_A141EstadoSGTipo, P008D2_A120ProfesionalesId, P008D2_A127SolicitudesID, P008D2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A142EstadoSGId ;
      private long AV9SolicitudesID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV10ProfesionalesId ;
      private string AV8Exists ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P008D2_A142EstadoSGId ;
      private string[] P008D2_A141EstadoSGTipo ;
      private string[] P008D2_A120ProfesionalesId ;
      private long[] P008D2_A127SolicitudesID ;
      private long[] P008D2_A140RelacionesId ;
      private string aP2_Exists ;
   }

   public class oexisterelacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008D2;
          prmP008D2 = new Object[] {
          new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008D2", "SELECT [EstadoSGId], [EstadoSGTipo], [ProfesionalesId], [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV9SolicitudesID) AND ([ProfesionalesId] = @AV10ProfesionalesId) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
