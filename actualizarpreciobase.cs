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
   public class actualizarpreciobase : GXProcedure
   {
      public actualizarpreciobase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarpreciobase( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( decimal aP0_PrecioChico ,
                           decimal aP1_PrecioMediano ,
                           decimal aP2_PrecioGrande )
      {
         this.AV8PrecioChico = aP0_PrecioChico;
         this.AV9PrecioMediano = aP1_PrecioMediano;
         this.AV10PrecioGrande = aP2_PrecioGrande;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( decimal aP0_PrecioChico ,
                                 decimal aP1_PrecioMediano ,
                                 decimal aP2_PrecioGrande )
      {
         this.AV8PrecioChico = aP0_PrecioChico;
         this.AV9PrecioMediano = aP1_PrecioMediano;
         this.AV10PrecioGrande = aP2_PrecioGrande;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GXLvl1 = 0;
         /* Using cursor P00GJ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A732ParametroMudanzaNombre = P00GJ2_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = P00GJ2_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00GJ2_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GJ2_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "CHICO", "")) == 0 )
            {
               AV11GXLvl1 = 1;
               A733ParametroMudanzaValor = AV8PrecioChico;
               /* Using cursor P00GJ3 */
               pr_default.execute(1, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl1 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "CHICO", "");
            A733ParametroMudanzaValor = AV8PrecioChico;
            A731ParametroMudanzaTipo = "PrecioBase";
            A734ParametroMudanzaUnidad = "$";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GJ4 */
            pr_default.execute(2, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GJ4_A730ParametroMudanzaId[0];
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
         AV12GXLvl14 = 0;
         /* Using cursor P00GJ5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A732ParametroMudanzaNombre = P00GJ5_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = P00GJ5_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00GJ5_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GJ5_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "MEDIANO", "")) == 0 )
            {
               AV12GXLvl14 = 1;
               A733ParametroMudanzaValor = AV9PrecioMediano;
               /* Using cursor P00GJ6 */
               pr_default.execute(4, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV12GXLvl14 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "MEDIANO", "");
            A733ParametroMudanzaValor = AV9PrecioMediano;
            A731ParametroMudanzaTipo = "PrecioBase";
            A734ParametroMudanzaUnidad = "$";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GJ7 */
            pr_default.execute(5, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GJ7_A730ParametroMudanzaId[0];
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
         AV13GXLvl27 = 0;
         /* Using cursor P00GJ8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A732ParametroMudanzaNombre = P00GJ8_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = P00GJ8_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = P00GJ8_A733ParametroMudanzaValor[0];
            A730ParametroMudanzaId = P00GJ8_A730ParametroMudanzaId[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "GRANDE", "")) == 0 )
            {
               AV13GXLvl27 = 1;
               A733ParametroMudanzaValor = AV10PrecioGrande;
               /* Using cursor P00GJ9 */
               pr_default.execute(7, new Object[] {A733ParametroMudanzaValor, A730ParametroMudanzaId});
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( AV13GXLvl27 == 0 )
         {
            /*
               INSERT RECORD ON TABLE ParametroMudanza

            */
            A732ParametroMudanzaNombre = context.GetMessage( "GRANDE", "");
            A733ParametroMudanzaValor = AV10PrecioGrande;
            A731ParametroMudanzaTipo = "PrecioBase";
            A734ParametroMudanzaUnidad = "$";
            A877ParametroMudanzaActivo = true;
            /* Using cursor P00GJ10 */
            pr_default.execute(8, new Object[] {A731ParametroMudanzaTipo, A732ParametroMudanzaNombre, A733ParametroMudanzaValor, A734ParametroMudanzaUnidad, A877ParametroMudanzaActivo});
            A730ParametroMudanzaId = P00GJ10_A730ParametroMudanzaId[0];
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("ParametroMudanza");
            if ( (pr_default.getStatus(8) == 1) )
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
         context.CommitDataStores("actualizarpreciobase",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00GJ2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GJ2_A731ParametroMudanzaTipo = new string[] {""} ;
         P00GJ2_A733ParametroMudanzaValor = new decimal[1] ;
         P00GJ2_A730ParametroMudanzaId = new short[1] ;
         A732ParametroMudanzaNombre = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         P00GJ4_A730ParametroMudanzaId = new short[1] ;
         Gx_emsg = "";
         P00GJ5_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GJ5_A731ParametroMudanzaTipo = new string[] {""} ;
         P00GJ5_A733ParametroMudanzaValor = new decimal[1] ;
         P00GJ5_A730ParametroMudanzaId = new short[1] ;
         P00GJ7_A730ParametroMudanzaId = new short[1] ;
         P00GJ8_A732ParametroMudanzaNombre = new string[] {""} ;
         P00GJ8_A731ParametroMudanzaTipo = new string[] {""} ;
         P00GJ8_A733ParametroMudanzaValor = new decimal[1] ;
         P00GJ8_A730ParametroMudanzaId = new short[1] ;
         P00GJ10_A730ParametroMudanzaId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarpreciobase__default(),
            new Object[][] {
                new Object[] {
               P00GJ2_A732ParametroMudanzaNombre, P00GJ2_A731ParametroMudanzaTipo, P00GJ2_A733ParametroMudanzaValor, P00GJ2_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GJ4_A730ParametroMudanzaId
               }
               , new Object[] {
               P00GJ5_A732ParametroMudanzaNombre, P00GJ5_A731ParametroMudanzaTipo, P00GJ5_A733ParametroMudanzaValor, P00GJ5_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GJ7_A730ParametroMudanzaId
               }
               , new Object[] {
               P00GJ8_A732ParametroMudanzaNombre, P00GJ8_A731ParametroMudanzaTipo, P00GJ8_A733ParametroMudanzaValor, P00GJ8_A730ParametroMudanzaId
               }
               , new Object[] {
               }
               , new Object[] {
               P00GJ10_A730ParametroMudanzaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl1 ;
      private short A730ParametroMudanzaId ;
      private short AV12GXLvl14 ;
      private short AV13GXLvl27 ;
      private int GX_INS118 ;
      private decimal AV8PrecioChico ;
      private decimal AV9PrecioMediano ;
      private decimal AV10PrecioGrande ;
      private decimal A733ParametroMudanzaValor ;
      private string A734ParametroMudanzaUnidad ;
      private string Gx_emsg ;
      private bool A877ParametroMudanzaActivo ;
      private string A732ParametroMudanzaNombre ;
      private string A731ParametroMudanzaTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GJ2_A732ParametroMudanzaNombre ;
      private string[] P00GJ2_A731ParametroMudanzaTipo ;
      private decimal[] P00GJ2_A733ParametroMudanzaValor ;
      private short[] P00GJ2_A730ParametroMudanzaId ;
      private short[] P00GJ4_A730ParametroMudanzaId ;
      private string[] P00GJ5_A732ParametroMudanzaNombre ;
      private string[] P00GJ5_A731ParametroMudanzaTipo ;
      private decimal[] P00GJ5_A733ParametroMudanzaValor ;
      private short[] P00GJ5_A730ParametroMudanzaId ;
      private short[] P00GJ7_A730ParametroMudanzaId ;
      private string[] P00GJ8_A732ParametroMudanzaNombre ;
      private string[] P00GJ8_A731ParametroMudanzaTipo ;
      private decimal[] P00GJ8_A733ParametroMudanzaValor ;
      private short[] P00GJ8_A730ParametroMudanzaId ;
      private short[] P00GJ10_A730ParametroMudanzaId ;
   }

   public class actualizarpreciobase__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GJ2;
          prmP00GJ2 = new Object[] {
          };
          Object[] prmP00GJ3;
          prmP00GJ3 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GJ4;
          prmP00GJ4 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          Object[] prmP00GJ5;
          prmP00GJ5 = new Object[] {
          };
          Object[] prmP00GJ6;
          prmP00GJ6 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GJ7;
          prmP00GJ7 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          Object[] prmP00GJ8;
          prmP00GJ8 = new Object[] {
          };
          Object[] prmP00GJ9;
          prmP00GJ9 = new Object[] {
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmP00GJ10;
          prmP00GJ10 = new Object[] {
          new ParDef("@ParametroMudanzaTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametroMudanzaNombre",GXType.NVarChar,100,0) ,
          new ParDef("@ParametroMudanzaValor",GXType.Decimal,18,2) ,
          new ParDef("@ParametroMudanzaUnidad",GXType.NChar,2,0) ,
          new ParDef("@ParametroMudanzaActivo",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GJ2", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ3", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GJ3)
             ,new CursorDef("P00GJ4", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GJ4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GJ5", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ6", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GJ6)
             ,new CursorDef("P00GJ7", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GJ7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GJ8", "SELECT [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor], [ParametroMudanzaId] FROM [ParametroMudanza] WITH (UPDLOCK) WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ9", "UPDATE [ParametroMudanza] SET [ParametroMudanzaValor]=@ParametroMudanzaValor  WHERE [ParametroMudanzaId] = @ParametroMudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GJ9)
             ,new CursorDef("P00GJ10", "INSERT INTO [ParametroMudanza]([ParametroMudanzaTipo], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaActivo], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaTitulo], [ParametroMudanzaImagen], [ParametroMudanzaImagen_GXI]) VALUES(@ParametroMudanzaTipo, @ParametroMudanzaNombre, @ParametroMudanzaValor, @ParametroMudanzaUnidad, @ParametroMudanzaActivo, '', convert(int, 0), '', CONVERT(varbinary(1), ''), ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GJ10,1, GxCacheFrequency.OFF ,true,true )
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
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
