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
   public class validartoken : GXProcedure
   {
      public validartoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public validartoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TokenId ,
                           out bool aP1_EsValido )
      {
         this.AV8TokenId = aP0_TokenId;
         this.AV9EsValido = false ;
         initialize();
         ExecutePrivate();
         aP1_EsValido=this.AV9EsValido;
      }

      public bool executeUdp( string aP0_TokenId )
      {
         execute(aP0_TokenId, out aP1_EsValido);
         return AV9EsValido ;
      }

      public void executeSubmit( string aP0_TokenId ,
                                 out bool aP1_EsValido )
      {
         this.AV8TokenId = aP0_TokenId;
         this.AV9EsValido = false ;
         SubmitImpl();
         aP1_EsValido=this.AV9EsValido;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9EsValido = false;
         /* Using cursor P00JF2 */
         pr_default.execute(0, new Object[] {AV8TokenId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A899TokenId = P00JF2_A899TokenId[0];
            A904TokenFechaExpiracion = P00JF2_A904TokenFechaExpiracion[0];
            A903TokenRequests = P00JF2_A903TokenRequests[0];
            AV10Ahora = DateTimeUtil.Now( context);
            if ( AV10Ahora <= A904TokenFechaExpiracion )
            {
               AV9EsValido = true;
               A903TokenRequests = (short)(A903TokenRequests+1);
            }
            /* Using cursor P00JF3 */
            pr_default.execute(1, new Object[] {A903TokenRequests, A899TokenId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Token");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.validartoken",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00JF2_A899TokenId = new string[] {""} ;
         P00JF2_A904TokenFechaExpiracion = new DateTime[] {DateTime.MinValue} ;
         P00JF2_A903TokenRequests = new short[1] ;
         A899TokenId = "";
         A904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         AV10Ahora = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.validartoken__default(),
            new Object[][] {
                new Object[] {
               P00JF2_A899TokenId, P00JF2_A904TokenFechaExpiracion, P00JF2_A903TokenRequests
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A903TokenRequests ;
      private string AV8TokenId ;
      private string A899TokenId ;
      private DateTime A904TokenFechaExpiracion ;
      private DateTime AV10Ahora ;
      private bool AV9EsValido ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00JF2_A899TokenId ;
      private DateTime[] P00JF2_A904TokenFechaExpiracion ;
      private short[] P00JF2_A903TokenRequests ;
      private bool aP1_EsValido ;
   }

   public class validartoken__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JF2;
          prmP00JF2 = new Object[] {
          new ParDef("@AV8TokenId",GXType.NChar,80,0)
          };
          Object[] prmP00JF3;
          prmP00JF3 = new Object[] {
          new ParDef("@TokenRequests",GXType.Int16,4,0) ,
          new ParDef("@TokenId",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JF2", "SELECT [TokenId], [TokenFechaExpiracion], [TokenRequests] FROM [Token] WITH (UPDLOCK) WHERE [TokenId] = @AV8TokenId ORDER BY [TokenId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JF2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JF3", "UPDATE [Token] SET [TokenRequests]=@TokenRequests  WHERE [TokenId] = @TokenId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00JF3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
