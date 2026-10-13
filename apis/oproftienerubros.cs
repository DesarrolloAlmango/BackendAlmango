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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class oproftienerubros : GXProcedure
   {
      public oproftienerubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oproftienerubros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out bool aP1_TieneRubros )
      {
         this.AV10ProfesionalesId = aP0_ProfesionalesId;
         this.AV12TieneRubros = false ;
         initialize();
         ExecutePrivate();
         aP1_TieneRubros=this.AV12TieneRubros;
      }

      public bool executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_TieneRubros);
         return AV12TieneRubros ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out bool aP1_TieneRubros )
      {
         this.AV10ProfesionalesId = aP0_ProfesionalesId;
         this.AV12TieneRubros = false ;
         SubmitImpl();
         aP1_TieneRubros=this.AV12TieneRubros;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12TieneRubros = false;
         /* Using cursor P00J62 */
         pr_default.execute(0, new Object[] {AV10ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00J62_A120ProfesionalesId[0];
            A121RubrosId = P00J62_A121RubrosId[0];
            AV12TieneRubros = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00J62_A120ProfesionalesId = new string[] {""} ;
         P00J62_A121RubrosId = new short[1] ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oproftienerubros__default(),
            new Object[][] {
                new Object[] {
               P00J62_A120ProfesionalesId, P00J62_A121RubrosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private string AV10ProfesionalesId ;
      private string A120ProfesionalesId ;
      private bool AV12TieneRubros ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00J62_A120ProfesionalesId ;
      private short[] P00J62_A121RubrosId ;
      private bool aP1_TieneRubros ;
   }

   public class oproftienerubros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00J62;
          prmP00J62 = new Object[] {
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J62", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV10ProfesionalesId)) ORDER BY [ProfesionalesId], [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J62,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
