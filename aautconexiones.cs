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
   public class aautconexiones : GXProcedure
   {
      public aautconexiones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aautconexiones( IGxContext context )
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
            INSERT RECORD ON TABLE Conexiones

         */
         A552ConexionesID = context.GetMessage( "API", "");
         A556ConexionesNombre = context.GetMessage( "Datos de Conexión para API", "");
         n556ConexionesNombre = false;
         A562ConexionesEstado = "HAB";
         n562ConexionesEstado = false;
         /* Using cursor P009F2 */
         pr_default.execute(0, new Object[] {A552ConexionesID, n556ConexionesNombre, A556ConexionesNombre, n562ConexionesEstado, A562ConexionesEstado});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "API", "");
         A553ConexionesDatosId = context.GetMessage( "KEY1", "");
         A566ConexionesDatosInt = context.GetMessage( "SISTARBANK", "");
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "WpzpGZ3Dy7-Bq}@", "");
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = context.GetMessage( "Conexión para confirmación de pago", "");
         n568ConexionesDatosDetalle = false;
         /* Using cursor P009F3 */
         pr_default.execute(1, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "API", "");
         A553ConexionesDatosId = context.GetMessage( "KEY2", "");
         A566ConexionesDatosInt = context.GetMessage( "ALMANGO", "");
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "11#$hilSd62", "");
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = context.GetMessage( "Conexión para confirmación de pago Mercadopagos", "");
         n568ConexionesDatosDetalle = false;
         /* Using cursor P009F4 */
         pr_default.execute(2, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "API", "");
         A553ConexionesDatosId = context.GetMessage( "KEY3", "");
         A566ConexionesDatosInt = context.GetMessage( "SISALMANGO", "");
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "d3d3LmF6bWl0YS5jb20=", "");
         n567ConexionesDatosExt = false;
         A568ConexionesDatosDetalle = context.GetMessage( "Conexión para confirmación de pago Mercadopagos", "");
         n568ConexionesDatosDetalle = false;
         /* Using cursor P009F5 */
         pr_default.execute(3, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt, n568ConexionesDatosDetalle, A568ConexionesDatosDetalle});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE Conexiones

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A556ConexionesNombre = context.GetMessage( "Datos de Conexión para SISTARBAK", "");
         n556ConexionesNombre = false;
         A557ConexionesHost = context.GetMessage( "spftest.sistarbanc.com.uy", "");
         n557ConexionesHost = false;
         A558ConexionesBaseURL = context.GetMessage( "/spfe/servlet/PagoEmpresa", "");
         n558ConexionesBaseURL = false;
         A559ConexionesPort = 0;
         n559ConexionesPort = false;
         A562ConexionesEstado = "HAB";
         n562ConexionesEstado = false;
         /* Using cursor P009F6 */
         pr_default.execute(4, new Object[] {A552ConexionesID, n556ConexionesNombre, A556ConexionesNombre, n557ConexionesHost, A557ConexionesHost, n558ConexionesBaseURL, A558ConexionesBaseURL, n559ConexionesPort, A559ConexionesPort, n562ConexionesEstado, A562ConexionesEstado});
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("Conexiones");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "consumidorFinal", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = "1";
         n567ConexionesDatosExt = false;
         /* Using cursor P009F7 */
         pr_default.execute(5, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "idBanco", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = "009";
         n567ConexionesDatosExt = false;
         /* Using cursor P009F8 */
         pr_default.execute(6, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(6);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
         if ( (pr_default.getStatus(6) == 1) )
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "idCuenta", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = "123456";
         n567ConexionesDatosExt = false;
         /* Using cursor P009F9 */
         pr_default.execute(7, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
         if ( (pr_default.getStatus(7) == 1) )
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "idOrganismo", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "ALMANGO", "");
         n567ConexionesDatosExt = false;
         /* Using cursor P009F10 */
         pr_default.execute(8, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(8);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "tipoServicio", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "SERV", "");
         n567ConexionesDatosExt = false;
         /* Using cursor P009F11 */
         pr_default.execute(9, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(9);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "urlVuelta", "");
         A566ConexionesDatosInt = "";
         n566ConexionesDatosInt = false;
         A567ConexionesDatosExt = context.GetMessage( "almango.com.uy", "");
         n567ConexionesDatosExt = false;
         /* Using cursor P009F12 */
         pr_default.execute(10, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt, n567ConexionesDatosExt, A567ConexionesDatosExt});
         pr_default.close(10);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "PFXDIR", "");
         A566ConexionesDatosInt = context.GetMessage( "C:\\bak\\Almango.pfx", "");
         n566ConexionesDatosInt = false;
         /* Using cursor P009F13 */
         pr_default.execute(11, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt});
         pr_default.close(11);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
            INSERT RECORD ON TABLE ConexionesDatos

         */
         A552ConexionesID = context.GetMessage( "SISTAR", "");
         A553ConexionesDatosId = context.GetMessage( "PFXKEY", "");
         A566ConexionesDatosInt = "123456";
         n566ConexionesDatosInt = false;
         /* Using cursor P009F14 */
         pr_default.execute(12, new Object[] {A552ConexionesID, A553ConexionesDatosId, n566ConexionesDatosInt, A566ConexionesDatosInt});
         pr_default.close(12);
         pr_default.SmartCacheProvider.SetUpdated("ConexionesDatos");
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
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aautconexiones",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A552ConexionesID = "";
         A556ConexionesNombre = "";
         A562ConexionesEstado = "";
         Gx_emsg = "";
         A553ConexionesDatosId = "";
         A566ConexionesDatosInt = "";
         A567ConexionesDatosExt = "";
         A568ConexionesDatosDetalle = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aautconexiones__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS80 ;
      private int GX_INS81 ;
      private int A559ConexionesPort ;
      private string A552ConexionesID ;
      private string A556ConexionesNombre ;
      private string A562ConexionesEstado ;
      private string Gx_emsg ;
      private string A553ConexionesDatosId ;
      private string A566ConexionesDatosInt ;
      private string A567ConexionesDatosExt ;
      private string A568ConexionesDatosDetalle ;
      private string A557ConexionesHost ;
      private string A558ConexionesBaseURL ;
      private bool n556ConexionesNombre ;
      private bool n562ConexionesEstado ;
      private bool n566ConexionesDatosInt ;
      private bool n567ConexionesDatosExt ;
      private bool n568ConexionesDatosDetalle ;
      private bool n557ConexionesHost ;
      private bool n558ConexionesBaseURL ;
      private bool n559ConexionesPort ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class aautconexiones__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009F2;
          prmP009F2 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
          new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true}
          };
          Object[] prmP009F3;
          prmP009F3 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true}
          };
          Object[] prmP009F4;
          prmP009F4 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true}
          };
          Object[] prmP009F5;
          prmP009F5 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosDetalle",GXType.NChar,256,0){Nullable=true}
          };
          Object[] prmP009F6;
          prmP009F6 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesNombre",GXType.NChar,80,0){Nullable=true} ,
          new ParDef("@ConexionesHost",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesBaseURL",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesPort",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@ConexionesEstado",GXType.NChar,3,0){Nullable=true}
          };
          Object[] prmP009F7;
          prmP009F7 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F8;
          prmP009F8 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F9;
          prmP009F9 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F10;
          prmP009F10 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F11;
          prmP009F11 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F12;
          prmP009F12 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true} ,
          new ParDef("@ConexionesDatosExt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F13;
          prmP009F13 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true}
          };
          Object[] prmP009F14;
          prmP009F14 = new Object[] {
          new ParDef("@ConexionesID",GXType.NChar,9,0) ,
          new ParDef("@ConexionesDatosId",GXType.NChar,25,0) ,
          new ParDef("@ConexionesDatosInt",GXType.NChar,128,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P009F2", "INSERT INTO [Conexiones]([ConexionesID], [ConexionesNombre], [ConexionesEstado], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesTipoIntegracion]) VALUES(@ConexionesID, @ConexionesNombre, @ConexionesEstado, '', '', convert(int, 0), '', '', '', '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmP009F2)
             ,new CursorDef("P009F3", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, @ConexionesDatosDetalle)", GxErrorMask.GX_NOMASK,prmP009F3)
             ,new CursorDef("P009F4", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, @ConexionesDatosDetalle)", GxErrorMask.GX_NOMASK,prmP009F4)
             ,new CursorDef("P009F5", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, @ConexionesDatosDetalle)", GxErrorMask.GX_NOMASK,prmP009F5)
             ,new CursorDef("P009F6", "INSERT INTO [Conexiones]([ConexionesID], [ConexionesNombre], [ConexionesHost], [ConexionesBaseURL], [ConexionesPort], [ConexionesEstado], [ConexionesApiKey], [ConexionesUsr], [ConexionesAux1], [ConexionesAux2], [ConexionesAux3], [ConexionesTipoIntegracion]) VALUES(@ConexionesID, @ConexionesNombre, @ConexionesHost, @ConexionesBaseURL, @ConexionesPort, @ConexionesEstado, '', '', '', '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmP009F6)
             ,new CursorDef("P009F7", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F7)
             ,new CursorDef("P009F8", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F8)
             ,new CursorDef("P009F9", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F9)
             ,new CursorDef("P009F10", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F10)
             ,new CursorDef("P009F11", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F11)
             ,new CursorDef("P009F12", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, @ConexionesDatosExt, '')", GxErrorMask.GX_NOMASK,prmP009F12)
             ,new CursorDef("P009F13", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, '', '')", GxErrorMask.GX_NOMASK,prmP009F13)
             ,new CursorDef("P009F14", "INSERT INTO [ConexionesDatos]([ConexionesID], [ConexionesDatosId], [ConexionesDatosInt], [ConexionesDatosExt], [ConexionesDatosDetalle]) VALUES(@ConexionesID, @ConexionesDatosId, @ConexionesDatosInt, '', '')", GxErrorMask.GX_NOMASK,prmP009F14)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
