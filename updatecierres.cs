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
   public class updatecierres : GXProcedure
   {
      public updatecierres( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public updatecierres( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FechaUpdate ,
                           string aP1_Modo ,
                           out DateTime aP2_FechaCierre )
      {
         this.AV8FechaUpdate = aP0_FechaUpdate;
         this.AV10Modo = aP1_Modo;
         this.AV9FechaCierre = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP2_FechaCierre=this.AV9FechaCierre;
      }

      public DateTime executeUdp( DateTime aP0_FechaUpdate ,
                                  string aP1_Modo )
      {
         execute(aP0_FechaUpdate, aP1_Modo, out aP2_FechaCierre);
         return AV9FechaCierre ;
      }

      public void executeSubmit( DateTime aP0_FechaUpdate ,
                                 string aP1_Modo ,
                                 out DateTime aP2_FechaCierre )
      {
         this.AV8FechaUpdate = aP0_FechaUpdate;
         this.AV10Modo = aP1_Modo;
         this.AV9FechaCierre = DateTime.MinValue ;
         SubmitImpl();
         aP2_FechaCierre=this.AV9FechaCierre;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV10Modo, context.GetMessage( "Actualizar", "")) == 0 )
         {
            /* Using cursor P00J22 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A314CierresUsuario = P00J22_A314CierresUsuario[0];
               A313CierresUltimaFecha = P00J22_A313CierresUltimaFecha[0];
               A155CierresId = P00J22_A155CierresId[0];
               if ( StringUtil.StrCmp(StringUtil.Trim( A314CierresUsuario), context.GetMessage( "FechaCierreSolicitud", "")) == 0 )
               {
                  A313CierresUltimaFecha = AV8FechaUpdate;
                  /* Using cursor P00J23 */
                  pr_default.execute(1, new Object[] {A313CierresUltimaFecha, A155CierresId});
                  pr_default.close(1);
                  pr_default.SmartCacheProvider.SetUpdated("Cierres");
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( StringUtil.StrCmp(AV10Modo, context.GetMessage( "Obtener", "")) == 0 )
         {
            /* Using cursor P00J24 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A314CierresUsuario = P00J24_A314CierresUsuario[0];
               A313CierresUltimaFecha = P00J24_A313CierresUltimaFecha[0];
               A155CierresId = P00J24_A155CierresId[0];
               if ( StringUtil.StrCmp(StringUtil.Trim( A314CierresUsuario), context.GetMessage( "FechaCierreSolicitud", "")) == 0 )
               {
                  AV9FechaCierre = A313CierresUltimaFecha;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("updatecierres",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9FechaCierre = DateTime.MinValue;
         P00J22_A314CierresUsuario = new string[] {""} ;
         P00J22_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         P00J22_A155CierresId = new long[1] ;
         A314CierresUsuario = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         P00J24_A314CierresUsuario = new string[] {""} ;
         P00J24_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         P00J24_A155CierresId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.updatecierres__default(),
            new Object[][] {
                new Object[] {
               P00J22_A314CierresUsuario, P00J22_A313CierresUltimaFecha, P00J22_A155CierresId
               }
               , new Object[] {
               }
               , new Object[] {
               P00J24_A314CierresUsuario, P00J24_A313CierresUltimaFecha, P00J24_A155CierresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A155CierresId ;
      private string A314CierresUsuario ;
      private DateTime AV8FechaUpdate ;
      private DateTime AV9FechaCierre ;
      private DateTime A313CierresUltimaFecha ;
      private string AV10Modo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00J22_A314CierresUsuario ;
      private DateTime[] P00J22_A313CierresUltimaFecha ;
      private long[] P00J22_A155CierresId ;
      private string[] P00J24_A314CierresUsuario ;
      private DateTime[] P00J24_A313CierresUltimaFecha ;
      private long[] P00J24_A155CierresId ;
      private DateTime aP2_FechaCierre ;
   }

   public class updatecierres__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00J22;
          prmP00J22 = new Object[] {
          };
          Object[] prmP00J23;
          prmP00J23 = new Object[] {
          new ParDef("@CierresUltimaFecha",GXType.Date,8,0) ,
          new ParDef("@CierresId",GXType.Decimal,18,0)
          };
          Object[] prmP00J24;
          prmP00J24 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00J22", "SELECT [CierresUsuario], [CierresUltimaFecha], [CierresId] FROM [Cierres] WITH (UPDLOCK) ORDER BY [CierresId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00J23", "UPDATE [Cierres] SET [CierresUltimaFecha]=@CierresUltimaFecha  WHERE [CierresId] = @CierresId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00J23)
             ,new CursorDef("P00J24", "SELECT [CierresUsuario], [CierresUltimaFecha], [CierresId] FROM [Cierres] ORDER BY [CierresId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J24,100, GxCacheFrequency.OFF ,false,false )
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
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
