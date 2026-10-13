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
   public class validarprofesionalenlista : GXProcedure
   {
      public validarprofesionalenlista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public validarprofesionalenlista( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           long aP1_ListaId ,
                           out bool aP2_EstaAsociado )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9ListaId = aP1_ListaId;
         this.AV10EstaAsociado = false ;
         initialize();
         ExecutePrivate();
         aP2_EstaAsociado=this.AV10EstaAsociado;
      }

      public bool executeUdp( string aP0_ProfesionalesId ,
                              long aP1_ListaId )
      {
         execute(aP0_ProfesionalesId, aP1_ListaId, out aP2_EstaAsociado);
         return AV10EstaAsociado ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 long aP1_ListaId ,
                                 out bool aP2_EstaAsociado )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9ListaId = aP1_ListaId;
         this.AV10EstaAsociado = false ;
         SubmitImpl();
         aP2_EstaAsociado=this.AV10EstaAsociado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10EstaAsociado = false;
         /* Using cursor P00N22 */
         pr_default.execute(0, new Object[] {AV9ListaId, AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A590Listaid = P00N22_A590Listaid[0];
            A120ProfesionalesId = P00N22_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00N22_A976ProfesionalesRestriccionId[0];
            AV10EstaAsociado = true;
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
         P00N22_A590Listaid = new long[1] ;
         P00N22_A120ProfesionalesId = new string[] {""} ;
         P00N22_A976ProfesionalesRestriccionId = new long[1] ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.validarprofesionalenlista__default(),
            new Object[][] {
                new Object[] {
               P00N22_A590Listaid, P00N22_A120ProfesionalesId, P00N22_A976ProfesionalesRestriccionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9ListaId ;
      private long A590Listaid ;
      private long A976ProfesionalesRestriccionId ;
      private string AV8ProfesionalesId ;
      private string A120ProfesionalesId ;
      private bool AV10EstaAsociado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00N22_A590Listaid ;
      private string[] P00N22_A120ProfesionalesId ;
      private long[] P00N22_A976ProfesionalesRestriccionId ;
      private bool aP2_EstaAsociado ;
   }

   public class validarprofesionalenlista__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00N22;
          prmP00N22 = new Object[] {
          new ParDef("@AV9ListaId",GXType.Decimal,18,0) ,
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N22", "SELECT TOP 1 [Listaid], [ProfesionalesId], [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE ([Listaid] = @AV9ListaId) AND ([ProfesionalesId] = @AV8ProfesionalesId) ORDER BY [Listaid] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N22,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
