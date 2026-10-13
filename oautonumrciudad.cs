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
   public class oautonumrciudad : GXProcedure
   {
      public oautonumrciudad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oautonumrciudad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PaisID ,
                           out long aP1_CiudadId )
      {
         this.AV9PaisID = aP0_PaisID;
         this.AV8CiudadId = 0 ;
         initialize();
         ExecutePrivate();
         aP1_CiudadId=this.AV8CiudadId;
      }

      public long executeUdp( string aP0_PaisID )
      {
         execute(aP0_PaisID, out aP1_CiudadId);
         return AV8CiudadId ;
      }

      public void executeSubmit( string aP0_PaisID ,
                                 out long aP1_CiudadId )
      {
         this.AV9PaisID = aP0_PaisID;
         this.AV8CiudadId = 0 ;
         SubmitImpl();
         aP1_CiudadId=this.AV8CiudadId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8CiudadId = 0;
         /* Using cursor P008O2 */
         pr_default.execute(0, new Object[] {AV9PaisID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A116PaisID = P008O2_A116PaisID[0];
            A144CiudadId = P008O2_A144CiudadId[0];
            AV8CiudadId = A144CiudadId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8CiudadId = (long)(AV8CiudadId+1);
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
         P008O2_A116PaisID = new string[] {""} ;
         P008O2_A144CiudadId = new long[1] ;
         A116PaisID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oautonumrciudad__default(),
            new Object[][] {
                new Object[] {
               P008O2_A116PaisID, P008O2_A144CiudadId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8CiudadId ;
      private long A144CiudadId ;
      private string AV9PaisID ;
      private string A116PaisID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008O2_A116PaisID ;
      private long[] P008O2_A144CiudadId ;
      private long aP1_CiudadId ;
   }

   public class oautonumrciudad__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008O2;
          prmP008O2 = new Object[] {
          new ParDef("@AV9PaisID",GXType.Char,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008O2", "SELECT [PaisID], [CiudadId] FROM [Ciudad] WHERE RTRIM(LTRIM(UPPER([PaisID]))) = RTRIM(LTRIM(UPPER(@AV9PaisID))) ORDER BY [CiudadId], [PaisID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008O2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
