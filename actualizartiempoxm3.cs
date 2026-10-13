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
   public class actualizartiempoxm3 : GXProcedure
   {
      public actualizartiempoxm3( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizartiempoxm3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( decimal aP0_TiempoxM3 )
      {
         this.AV8TiempoxM3 = aP0_TiempoxM3;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( decimal aP0_TiempoxM3 )
      {
         this.AV8TiempoxM3 = aP0_TiempoxM3;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GXLvl1 = 0;
         /* Using cursor P00GT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A732ParametroMudanzaNombre = P00GT2_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = P00GT2_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00GT2_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GT2_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "TiempoxM3", "")) == 0 )
            {
               AV9GXLvl1 = 1;
               A733ParametroMudanzaValor = AV8TiempoxM3;
               /* Using cursor P00GT3 */
               pr_default.execute(1, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9GXLvl1 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "TiempoxM3", "");
            A733ParametroMudanzaValor = AV8TiempoxM3;
            A731ParametroMudanzaTipo = "TiempoxM3";
            A734ParametroMudanzaUnidad = "mm";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GT4 */
            pr_default.execute(2, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GT4_A730ParametroMudanzaId[0];
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizartiempoxm3",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00GT2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GT2_A731ParametroMudanzaTipo = new string[] {""} ;
         P00GT2_A733ParametroMudanzaValor = new decimal[1] ;
         P00GT2_A730ParametroMudanzaId = new short[1] ;
         A732ParametroMudanzaNombre = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         P00GT4_A730ParametroMudanzaId = new short[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizartiempoxm3__default(),
            new Object[][] {
                new Object[] {
               P00GT2_A732ParametroMudanzaNombre, P00GT2_A731ParametroMudanzaTipo, P00GT2_A733ParametroMudanzaValor, P00GT2_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GT4_A730ParametroMudanzaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9GXLvl1 ;
      private short A730ParametroMudanzaId ;
      private int GX_INS118 ;
      private decimal AV8TiempoxM3 ;
      private decimal A733ParametroMudanzaValor ;
      private string A734ParametroMudanzaUnidad ;
      private string Gx_emsg ;
      private bool A877ParametroMudanzaActivo ;
      private string A732ParametroMudanzaNombre ;
      private string A731ParametroMudanzaTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GT2_A732ParametroMudanzaNombre ;
      private string[] P00GT2_A731ParametroMudanzaTipo ;
      private decimal[] P00GT2_A733ParametroMudanzaValor ;
      private short[] P00GT2_A730ParametroMudanzaId ;
      private short[] P00GT4_A730ParametroMudanzaId ;
   }

   public class actualizartiempoxm3__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GT2;
          prmP00GT2 = new Object[] {
          };
          Object[] prmP00GT3;
          prmP00GT3 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GT4;
          prmP00GT4 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GT2", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaTipo] = 'TiempoxM3' ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GT2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GT3", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GT3)
             ,new CursorDef("P00GT4", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GT4,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
