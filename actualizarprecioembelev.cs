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
   public class actualizarprecioembelev : GXProcedure
   {
      public actualizarprecioembelev( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarprecioembelev( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( decimal aP0_PrecioEmbMetro3 ,
                           decimal aP1_PrecioElevPiso )
      {
         this.AV8PrecioEmbMetro3 = aP0_PrecioEmbMetro3;
         this.AV9PrecioElevPiso = aP1_PrecioElevPiso;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( decimal aP0_PrecioEmbMetro3 ,
                                 decimal aP1_PrecioElevPiso )
      {
         this.AV8PrecioEmbMetro3 = aP0_PrecioEmbMetro3;
         this.AV9PrecioElevPiso = aP1_PrecioElevPiso;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         /* Using cursor P00GG2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A732ParametroMudanzaNombre = P00GG2_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = P00GG2_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GG2_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioElevPiso", "")) == 0 )
            {
               AV10GXLvl1 = 1;
               A733ParametroMudanzaValor = AV9PrecioElevPiso;
               /* Using cursor P00GG3 */
               pr_default.execute(1, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "PrecioElevPiso", "");
            A733ParametroMudanzaValor = AV9PrecioElevPiso;
            A731ParametroMudanzaTipo = "PrecioElevacion";
            A734ParametroMudanzaUnidad = "$";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GG4 */
            pr_default.execute(2, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GG4_A730ParametroMudanzaId[0];
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
         AV11GXLvl13 = 0;
         /* Using cursor P00GG5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A732ParametroMudanzaNombre = P00GG5_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = P00GG5_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GG5_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioEmbMetro3", "")) == 0 )
            {
               AV11GXLvl13 = 1;
               A733ParametroMudanzaValor = AV8PrecioEmbMetro3;
               /* Using cursor P00GG6 */
               pr_default.execute(4, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV11GXLvl13 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "PrecioEmbMetro3", "");
            A733ParametroMudanzaValor = AV8PrecioEmbMetro3;
            A731ParametroMudanzaTipo = "PrecioEmbalaje";
            A734ParametroMudanzaUnidad = "$";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GG7 */
            pr_default.execute(5, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GG7_A730ParametroMudanzaId[0];
            pr_default.close(5);
            pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            if ( (pr_default.getStatus(5) == 1) )
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
         context.CommitDataStores("actualizarprecioembelev",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00GG2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GG2_A733ParametroMudanzaValor = new decimal[1] ;
         P00GG2_A730ParametroMudanzaId = new short[1] ;
         A732ParametroMudanzaNombre = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         P00GG4_A730ParametroMudanzaId = new short[1] ;
         Gx_emsg = "";
         P00GG5_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GG5_A733ParametroMudanzaValor = new decimal[1] ;
         P00GG5_A730ParametroMudanzaId = new short[1] ;
         P00GG7_A730ParametroMudanzaId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarprecioembelev__default(),
            new Object[][] {
                new Object[] {
               P00GG2_A732ParametroMudanzaNombre, P00GG2_A733ParametroMudanzaValor, P00GG2_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GG4_A730ParametroMudanzaId
               }
               , new Object[] {
               P00GG5_A732ParametroMudanzaNombre, P00GG5_A733ParametroMudanzaValor, P00GG5_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GG7_A730ParametroMudanzaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private short A730ParametroMudanzaId ;
      private short AV11GXLvl13 ;
      private int GX_INS118 ;
      private decimal AV8PrecioEmbMetro3 ;
      private decimal AV9PrecioElevPiso ;
      private decimal A733ParametroMudanzaValor ;
      private string A734ParametroMudanzaUnidad ;
      private string Gx_emsg ;
      private bool A877ParametroMudanzaActivo ;
      private string A732ParametroMudanzaNombre ;
      private string A731ParametroMudanzaTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GG2_A732ParametroMudanzaNombre ;
      private decimal[] P00GG2_A733ParametroMudanzaValor ;
      private short[] P00GG2_A730ParametroMudanzaId ;
      private short[] P00GG4_A730ParametroMudanzaId ;
      private string[] P00GG5_A732ParametroMudanzaNombre ;
      private decimal[] P00GG5_A733ParametroMudanzaValor ;
      private short[] P00GG5_A730ParametroMudanzaId ;
      private short[] P00GG7_A730ParametroMudanzaId ;
   }

   public class actualizarprecioembelev__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GG2;
          prmP00GG2 = new Object[] {
          };
          Object[] prmP00GG3;
          prmP00GG3 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GG4;
          prmP00GG4 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          Object[] prmP00GG5;
          prmP00GG5 = new Object[] {
          };
          Object[] prmP00GG6;
          prmP00GG6 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GG7;
          prmP00GG7 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GG2", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GG2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GG3", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GG3)
             ,new CursorDef("P00GG4", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GG4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GG5", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GG5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GG6", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GG6)
             ,new CursorDef("P00GG7", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GG7,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
