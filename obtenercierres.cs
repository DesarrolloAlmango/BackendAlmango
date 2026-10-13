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
   public class obtenercierres : GXProcedure
   {
      public obtenercierres( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercierres( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Codigo ,
                           out DateTime aP1_CierresUltimaFecha )
      {
         this.AV8Codigo = aP0_Codigo;
         this.AV9CierresUltimaFecha = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP1_CierresUltimaFecha=this.AV9CierresUltimaFecha;
      }

      public DateTime executeUdp( string aP0_Codigo )
      {
         execute(aP0_Codigo, out aP1_CierresUltimaFecha);
         return AV9CierresUltimaFecha ;
      }

      public void executeSubmit( string aP0_Codigo ,
                                 out DateTime aP1_CierresUltimaFecha )
      {
         this.AV8Codigo = aP0_Codigo;
         this.AV9CierresUltimaFecha = DateTime.MinValue ;
         SubmitImpl();
         aP1_CierresUltimaFecha=this.AV9CierresUltimaFecha;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00IY2 */
         pr_default.execute(0, new Object[] {AV8Codigo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A314CierresUsuario = P00IY2_A314CierresUsuario[0];
            A313CierresUltimaFecha = P00IY2_A313CierresUltimaFecha[0];
            A155CierresId = P00IY2_A155CierresId[0];
            AV9CierresUltimaFecha = A313CierresUltimaFecha;
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
         AV9CierresUltimaFecha = DateTime.MinValue;
         P00IY2_A314CierresUsuario = new string[] {""} ;
         P00IY2_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         P00IY2_A155CierresId = new long[1] ;
         A314CierresUsuario = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenercierres__default(),
            new Object[][] {
                new Object[] {
               P00IY2_A314CierresUsuario, P00IY2_A313CierresUltimaFecha, P00IY2_A155CierresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A155CierresId ;
      private string AV8Codigo ;
      private string A314CierresUsuario ;
      private DateTime AV9CierresUltimaFecha ;
      private DateTime A313CierresUltimaFecha ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00IY2_A314CierresUsuario ;
      private DateTime[] P00IY2_A313CierresUltimaFecha ;
      private long[] P00IY2_A155CierresId ;
      private DateTime aP1_CierresUltimaFecha ;
   }

   public class obtenercierres__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00IY2;
          prmP00IY2 = new Object[] {
          new ParDef("@AV8Codigo",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IY2", "SELECT TOP 1 [CierresUsuario], [CierresUltimaFecha], [CierresId] FROM [Cierres] WHERE UPPER([CierresUsuario]) = UPPER(@AV8Codigo) ORDER BY [CierresId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IY2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
