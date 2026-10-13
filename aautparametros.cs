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
   public class aautparametros : GXProcedure
   {
      public aautparametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aautparametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "LIMITESOLICITUD", "");
         A284ParametrosNombre = context.GetMessage( "Limite Maximo Solicitudes sin Finalizar", "");
         A602ParametrosValor = "10";
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B62 */
         pr_default.execute(0, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado});
         A283ParametrosId = P00B62_A283ParametrosId[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(0) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "CANCELARSOLMAXMIN", "");
         A284ParametrosNombre = context.GetMessage( "Cancelar Solicitud Maximo de Minutos Transcurridos", "");
         A602ParametrosValor = "180";
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B63 */
         pr_default.execute(1, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado});
         A283ParametrosId = P00B63_A283ParametrosId[0];
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(1) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "LIKSOLICITUDES", "");
         A284ParametrosNombre = context.GetMessage( "Link del wizard usado para ingreso de solicitudes", "");
         A602ParametrosValor = context.GetMessage( "https://almango.com.uy/solicitud/alta1.php?id=", "");
         A635ParametrosNumerico = 2;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B64 */
         pr_default.execute(2, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B64_A283ParametrosId[0];
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "LIKFEEDBACK", "");
         A284ParametrosNombre = context.GetMessage( "Link para el feedback de solicitudes", "");
         A602ParametrosValor = context.GetMessage( "https://sis.almango.com.uy/calificarservicio.aspx?", "");
         A635ParametrosNumerico = 1;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B65 */
         pr_default.execute(3, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B65_A283ParametrosId[0];
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(3) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLINICIO", "");
         A284ParametrosNombre = context.GetMessage( "Link el inicio de sesion", "");
         A602ParametrosValor = context.GetMessage( "https://app.almango.com.uy/wwpbaseobjects.login.aspx", "");
         A635ParametrosNumerico = 1;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B66 */
         pr_default.execute(4, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B66_A283ParametrosId[0];
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(4) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLPOLITICAS", "");
         A284ParametrosNombre = context.GetMessage( "Link para el archivo adjunto de las politicas de almango.", "");
         A602ParametrosValor = context.GetMessage( "https://almango.com.uy/politicas/ALMANGO%20-%20Pol%C3%ADticas%20de%20Privacidad%20v2.pdf", "");
         A635ParametrosNumerico = 1;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B67 */
         pr_default.execute(5, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B67_A283ParametrosId[0];
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLPOLITICASCOM", "");
         A284ParametrosNombre = context.GetMessage( "Link de  politicas de almango para el comercio.", "");
         A602ParametrosValor = context.GetMessage( "https://sis.almango.com.uy/textosview.aspx?31", "");
         A635ParametrosNumerico = 1;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B68 */
         pr_default.execute(6, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B68_A283ParametrosId[0];
         pr_default.close(6);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(6) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            A284ParametrosNombre = context.GetMessage( "Link de  politicas de almango para el comercio.", "");
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLPOLITICASPRF", "");
         A284ParametrosNombre = context.GetMessage( "Link de politicas de almango para el profesional.", "");
         A602ParametrosValor = context.GetMessage( "https://sis.almango.com.uy/textosview.aspx?30", "");
         A635ParametrosNumerico = 1;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B69 */
         pr_default.execute(7, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B69_A283ParametrosId[0];
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(7) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            A284ParametrosNombre = context.GetMessage( "Link de politicas de almango para el profesional.", "");
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLPAGOBAMBOO", "");
         A284ParametrosNombre = context.GetMessage( "Link para pasarala de pago de bamboo, Trx es un string en base64 con el siguiente dato: TipoOpe=S&Identificador=323631", "");
         A602ParametrosValor = context.GetMessage( "https://almango.com.uy/pago/index.html?Trx=", "");
         A635ParametrosNumerico = 2;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B610 */
         pr_default.execute(8, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B610_A283ParametrosId[0];
         pr_default.close(8);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLPASPAG", "");
         A284ParametrosNombre = context.GetMessage( "Link Pasarela de pago (Mercado Pago)", "");
         A602ParametrosValor = context.GetMessage( "https://pay.almango.com.uy/procesarpago.aspx?", "");
         A635ParametrosNumerico = 0;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B611 */
         pr_default.execute(9, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B611_A283ParametrosId[0];
         pr_default.close(9);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(9) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "COORDENADAMAPBOX", "");
         A284ParametrosNombre = context.GetMessage( "COORDENADA DEL MAPA MAPBOX", "");
         A602ParametrosValor = "-56.1913095,-33.2058916,5";
         A635ParametrosNumerico = 0;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B612 */
         pr_default.execute(10, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B612_A283ParametrosId[0];
         pr_default.close(10);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(10) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "URLMAPBOX", "");
         A284ParametrosNombre = context.GetMessage( "URL de MAPBOX", "");
         A602ParametrosValor = context.GetMessage( "https://api.mapbox.com/styles/v1/mapbox/streets-v12/static/", "");
         A635ParametrosNumerico = 0;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B613 */
         pr_default.execute(11, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B613_A283ParametrosId[0];
         pr_default.close(11);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(11) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "TOKENMAPBOX", "");
         A284ParametrosNombre = context.GetMessage( "Token de MAPBOX", "");
         A602ParametrosValor = context.GetMessage( "pk.eyJ1IjoibWFwYm94Y3VlbnRhIiwiYSI6ImNtMGQxM3h0aTA3c2YybG9jNmxqcmxxZjYifQ.NvvfF-ebLRB2aJnO5zMqUw", "");
         A635ParametrosNumerico = 0;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B614 */
         pr_default.execute(12, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B614_A283ParametrosId[0];
         pr_default.close(12);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(12) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "STOKENMAPBOX", "");
         A284ParametrosNombre = context.GetMessage( "Session Token de MAPBOX", "");
         A602ParametrosValor = context.GetMessage( "05beb917-06ef-45b1-8912-e62db7406c05", "");
         A635ParametrosNumerico = 0;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B615 */
         pr_default.execute(13, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B615_A283ParametrosId[0];
         pr_default.close(13);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(13) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "DiasLimite", "");
         A284ParametrosNombre = context.GetMessage( "DiasLimite de Dasboard1", "");
         A602ParametrosValor = "";
         A635ParametrosNumerico = 15;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B616 */
         pr_default.execute(14, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B616_A283ParametrosId[0];
         pr_default.close(14);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(14) == 1) )
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
         /*
            INSERT RECORD ON TABLE Parametros

         */
         A237ParametrosCodigo = context.GetMessage( "DiaSaturado", "");
         A284ParametrosNombre = context.GetMessage( "DiasSaturado de Dasboard1", "");
         A602ParametrosValor = "";
         A635ParametrosNumerico = 20;
         A238ParametrosEstado = "HAB";
         /* Using cursor P00B617 */
         pr_default.execute(15, new Object[] {A237ParametrosCodigo, A284ParametrosNombre, A602ParametrosValor, A238ParametrosEstado, A635ParametrosNumerico});
         A283ParametrosId = P00B617_A283ParametrosId[0];
         pr_default.close(15);
         pr_default.SmartCacheProvider.SetUpdated("Parametros");
         if ( (pr_default.getStatus(15) == 1) )
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
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aautparametros",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A237ParametrosCodigo = "";
         A284ParametrosNombre = "";
         A602ParametrosValor = "";
         A238ParametrosEstado = "";
         P00B62_A283ParametrosId = new long[1] ;
         Gx_emsg = "";
         P00B63_A283ParametrosId = new long[1] ;
         P00B64_A283ParametrosId = new long[1] ;
         P00B65_A283ParametrosId = new long[1] ;
         P00B66_A283ParametrosId = new long[1] ;
         P00B67_A283ParametrosId = new long[1] ;
         P00B68_A283ParametrosId = new long[1] ;
         P00B69_A283ParametrosId = new long[1] ;
         P00B610_A283ParametrosId = new long[1] ;
         P00B611_A283ParametrosId = new long[1] ;
         P00B612_A283ParametrosId = new long[1] ;
         P00B613_A283ParametrosId = new long[1] ;
         P00B614_A283ParametrosId = new long[1] ;
         P00B615_A283ParametrosId = new long[1] ;
         P00B616_A283ParametrosId = new long[1] ;
         P00B617_A283ParametrosId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aautparametros__default(),
            new Object[][] {
                new Object[] {
               P00B62_A283ParametrosId
               }
               , new Object[] {
               P00B63_A283ParametrosId
               }
               , new Object[] {
               P00B64_A283ParametrosId
               }
               , new Object[] {
               P00B65_A283ParametrosId
               }
               , new Object[] {
               P00B66_A283ParametrosId
               }
               , new Object[] {
               P00B67_A283ParametrosId
               }
               , new Object[] {
               P00B68_A283ParametrosId
               }
               , new Object[] {
               P00B69_A283ParametrosId
               }
               , new Object[] {
               P00B610_A283ParametrosId
               }
               , new Object[] {
               P00B611_A283ParametrosId
               }
               , new Object[] {
               P00B612_A283ParametrosId
               }
               , new Object[] {
               P00B613_A283ParametrosId
               }
               , new Object[] {
               P00B614_A283ParametrosId
               }
               , new Object[] {
               P00B615_A283ParametrosId
               }
               , new Object[] {
               P00B616_A283ParametrosId
               }
               , new Object[] {
               P00B617_A283ParametrosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS88 ;
      private int A635ParametrosNumerico ;
      private long A283ParametrosId ;
      private string A237ParametrosCodigo ;
      private string A284ParametrosNombre ;
      private string A238ParametrosEstado ;
      private string Gx_emsg ;
      private string A602ParametrosValor ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B62_A283ParametrosId ;
      private long[] P00B63_A283ParametrosId ;
      private long[] P00B64_A283ParametrosId ;
      private long[] P00B65_A283ParametrosId ;
      private long[] P00B66_A283ParametrosId ;
      private long[] P00B67_A283ParametrosId ;
      private long[] P00B68_A283ParametrosId ;
      private long[] P00B69_A283ParametrosId ;
      private long[] P00B610_A283ParametrosId ;
      private long[] P00B611_A283ParametrosId ;
      private long[] P00B612_A283ParametrosId ;
      private long[] P00B613_A283ParametrosId ;
      private long[] P00B614_A283ParametrosId ;
      private long[] P00B615_A283ParametrosId ;
      private long[] P00B616_A283ParametrosId ;
      private long[] P00B617_A283ParametrosId ;
   }

   public class aautparametros__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00B62;
          prmP00B62 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0)
          };
          Object[] prmP00B63;
          prmP00B63 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0)
          };
          Object[] prmP00B64;
          prmP00B64 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B65;
          prmP00B65 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B66;
          prmP00B66 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B67;
          prmP00B67 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B68;
          prmP00B68 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B69;
          prmP00B69 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B610;
          prmP00B610 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B611;
          prmP00B611 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B612;
          prmP00B612 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B613;
          prmP00B613 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B614;
          prmP00B614 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B615;
          prmP00B615 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B616;
          prmP00B616 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          Object[] prmP00B617;
          prmP00B617 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosNombre",GXType.NChar,80,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0) ,
          new ParDef("@ParametrosEstado",GXType.NChar,3,0) ,
          new ParDef("@ParametrosNumerico",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B62", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B62,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B63", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B63,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B64", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B64,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B65", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B65,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B66", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B66,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B67", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B67,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B68", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B68,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B69", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B69,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B610", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B610,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B611", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B612", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B612,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B613", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B614", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B614,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B615", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B615,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B616", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B616,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B617", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombre], [ParametrosValor], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosNombre, @ParametrosValor, @ParametrosEstado, @ParametrosNumerico); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B617,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
