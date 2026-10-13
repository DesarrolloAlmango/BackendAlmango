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
   public class oprofesionalid : GXProcedure
   {
      public oprofesionalid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oprofesionalid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuariosId ,
                           out string aP1_ProfesionalesId )
      {
         this.AV10UsuariosId = aP0_UsuariosId;
         this.AV9ProfesionalesId = "" ;
         initialize();
         ExecutePrivate();
         aP1_ProfesionalesId=this.AV9ProfesionalesId;
      }

      public string executeUdp( string aP0_UsuariosId )
      {
         execute(aP0_UsuariosId, out aP1_ProfesionalesId);
         return AV9ProfesionalesId ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 out string aP1_ProfesionalesId )
      {
         this.AV10UsuariosId = aP0_UsuariosId;
         this.AV9ProfesionalesId = "" ;
         SubmitImpl();
         aP1_ProfesionalesId=this.AV9ProfesionalesId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuariosId)) )
         {
            cleanup();
            if (true) return;
         }
         AV9ProfesionalesId = "";
         /* Using cursor P00JE2 */
         pr_default.execute(0, new Object[] {AV10UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P00JE2_A145usuariosId[0];
            A240usuariosNumeroIdentidad = P00JE2_A240usuariosNumeroIdentidad[0];
            AV9ProfesionalesId = StringUtil.Trim( A240usuariosNumeroIdentidad);
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
         AV9ProfesionalesId = "";
         P00JE2_A145usuariosId = new string[] {""} ;
         P00JE2_A240usuariosNumeroIdentidad = new string[] {""} ;
         A145usuariosId = "";
         A240usuariosNumeroIdentidad = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oprofesionalid__default(),
            new Object[][] {
                new Object[] {
               P00JE2_A145usuariosId, P00JE2_A240usuariosNumeroIdentidad
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10UsuariosId ;
      private string AV9ProfesionalesId ;
      private string A145usuariosId ;
      private string A240usuariosNumeroIdentidad ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00JE2_A145usuariosId ;
      private string[] P00JE2_A240usuariosNumeroIdentidad ;
      private string aP1_ProfesionalesId ;
   }

   public class oprofesionalid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JE2;
          prmP00JE2 = new Object[] {
          new ParDef("@AV10UsuariosId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JE2", "SELECT [usuariosId], [usuariosNumeroIdentidad] FROM [usuarios] WHERE RTRIM(LTRIM([usuariosId])) = RTRIM(LTRIM(@AV10UsuariosId)) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JE2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
       }
    }

 }

}
