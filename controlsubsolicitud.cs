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
   public class controlsubsolicitud : GXProcedure
   {
      public controlsubsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public controlsubsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CentroCostosId )
      {
         this.AV8CentroCostosId = aP0_CentroCostosId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_CentroCostosId )
      {
         this.AV8CentroCostosId = aP0_CentroCostosId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00IS2 */
         pr_default.execute(0, new Object[] {AV8CentroCostosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A461CentroCostosId = P00IS2_A461CentroCostosId[0];
            A889CentroCostosJson = P00IS2_A889CentroCostosJson[0];
            AV10CentroCostosIdJson.FromJSonString(A889CentroCostosJson, null);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00IS3 */
         pr_default.execute(1, new Object[] {AV8CentroCostosId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A461CentroCostosId = P00IS3_A461CentroCostosId[0];
            A888CentroCostosDetallesSolId = P00IS3_A888CentroCostosDetallesSolId[0];
            A466CentroCostosDetallesId = P00IS3_A466CentroCostosDetallesId[0];
            AV9CentroCostosIdCollection.Add(A888CentroCostosDetallesSolId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV10CentroCostosIdJson.Count )
         {
            AV11CentroCostosDetallesSolId = (long)(AV10CentroCostosIdJson.GetNumeric(AV27GXV1));
            if ( ! (AV9CentroCostosIdCollection.IndexOf(AV11CentroCostosDetallesSolId)>0) )
            {
               /* Using cursor P00IS4 */
               pr_default.execute(2, new Object[] {AV11CentroCostosDetallesSolId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A127SolicitudesID = P00IS4_A127SolicitudesID[0];
                  A131EstadosSolId = P00IS4_A131EstadosSolId[0];
                  A598SolicitudesUsrActualizacion = P00IS4_A598SolicitudesUsrActualizacion[0];
                  n598SolicitudesUsrActualizacion = P00IS4_n598SolicitudesUsrActualizacion[0];
                  A131EstadosSolId = 3;
                  new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV24WWPContext) ;
                  A598SolicitudesUsrActualizacion = AV24WWPContext.gxTpr_Userid;
                  n598SolicitudesUsrActualizacion = false;
                  /* Using cursor P00IS5 */
                  pr_default.execute(3, new Object[] {A131EstadosSolId, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               /* Optimized UPDATE. */
               /* Using cursor P00IS6 */
               pr_default.execute(4, new Object[] {AV11CentroCostosDetallesSolId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
               /* End optimized UPDATE. */
            }
            else
            {
               /* Using cursor P00IS7 */
               pr_default.execute(5, new Object[] {AV11CentroCostosDetallesSolId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A127SolicitudesID = P00IS7_A127SolicitudesID[0];
                  A530SolicitudServicioComALM = P00IS7_A530SolicitudServicioComALM[0];
                  n530SolicitudServicioComALM = P00IS7_n530SolicitudServicioComALM[0];
                  A184SolicitudesFechaInstalacion = P00IS7_A184SolicitudesFechaInstalacion[0];
                  A171SolicitudesNombre = P00IS7_A171SolicitudesNombre[0];
                  A131EstadosSolId = P00IS7_A131EstadosSolId[0];
                  A598SolicitudesUsrActualizacion = P00IS7_A598SolicitudesUsrActualizacion[0];
                  n598SolicitudesUsrActualizacion = P00IS7_n598SolicitudesUsrActualizacion[0];
                  O893CentroCostosDetallesEstado = A893CentroCostosDetallesEstado;
                  /* Execute user subroutine: 'DETALLESVALOR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
                     cleanup();
                     if (true) return;
                  }
                  A530SolicitudServicioComALM = (decimal)(AV15CentroCostosDetallesValor*(-1));
                  n530SolicitudServicioComALM = false;
                  if ( ! (DateTime.MinValue==AV19CentroCostosDetallesFecha) )
                  {
                     A184SolicitudesFechaInstalacion = AV19CentroCostosDetallesFecha;
                  }
                  if ( ! (0==AV23CentroCostosDetallesEstado) )
                  {
                     A893CentroCostosDetallesEstado = AV23CentroCostosDetallesEstado;
                  }
                  A171SolicitudesNombre = AV20CentroCostosDetallesNombre;
                  A131EstadosSolId = (int)(AV23CentroCostosDetallesEstado);
                  new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV24WWPContext) ;
                  A598SolicitudesUsrActualizacion = AV24WWPContext.gxTpr_Userid;
                  n598SolicitudesUsrActualizacion = false;
                  /* Using cursor P00IS8 */
                  pr_default.execute(6, new Object[] {n530SolicitudServicioComALM, A530SolicitudServicioComALM, A184SolicitudesFechaInstalacion, A171SolicitudesNombre, A131EstadosSolId, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
               /* Using cursor P00IS9 */
               pr_default.execute(7, new Object[] {AV11CentroCostosDetallesSolId});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A127SolicitudesID = P00IS9_A127SolicitudesID[0];
                  A140RelacionesId = P00IS9_A140RelacionesId[0];
                  A120ProfesionalesId = P00IS9_A120ProfesionalesId[0];
                  /* Execute user subroutine: 'DETALLESVALOR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(7);
                     cleanup();
                     if (true) return;
                  }
                  A120ProfesionalesId = AV18ProfesionalesId;
                  /* Using cursor P00IS10 */
                  pr_default.execute(8, new Object[] {A120ProfesionalesId, A127SolicitudesID, A140RelacionesId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Relaciones");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(7);
            }
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         AV10CentroCostosIdJson.Clear();
         /* Using cursor P00IS11 */
         pr_default.execute(9, new Object[] {AV8CentroCostosId});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A461CentroCostosId = P00IS11_A461CentroCostosId[0];
            A888CentroCostosDetallesSolId = P00IS11_A888CentroCostosDetallesSolId[0];
            A889CentroCostosJson = P00IS11_A889CentroCostosJson[0];
            A466CentroCostosDetallesId = P00IS11_A466CentroCostosDetallesId[0];
            A889CentroCostosJson = P00IS11_A889CentroCostosJson[0];
            if ( ! (0==A888CentroCostosDetallesSolId) )
            {
               AV10CentroCostosIdJson.Add(A888CentroCostosDetallesSolId, 0);
            }
            A889CentroCostosJson = AV10CentroCostosIdJson.ToJSonString(false);
            /* Using cursor P00IS12 */
            pr_default.execute(10, new Object[] {A889CentroCostosJson, A461CentroCostosId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
            pr_default.readNext(9);
         }
         pr_default.close(9);
         cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLESVALOR' Routine */
         returnInSub = false;
         /* Using cursor P00IS13 */
         pr_default.execute(11, new Object[] {AV8CentroCostosId, AV11CentroCostosDetallesSolId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A888CentroCostosDetallesSolId = P00IS13_A888CentroCostosDetallesSolId[0];
            A461CentroCostosId = P00IS13_A461CentroCostosId[0];
            A468CentroCostosDetallesValor = P00IS13_A468CentroCostosDetallesValor[0];
            A890CCDetallesProfId = P00IS13_A890CCDetallesProfId[0];
            A892CentroCostosDetallesFecha = P00IS13_A892CentroCostosDetallesFecha[0];
            A473CentroCostosDetallesNombre = P00IS13_A473CentroCostosDetallesNombre[0];
            A893CentroCostosDetallesEstado = P00IS13_A893CentroCostosDetallesEstado[0];
            A466CentroCostosDetallesId = P00IS13_A466CentroCostosDetallesId[0];
            AV15CentroCostosDetallesValor = A468CentroCostosDetallesValor;
            AV18ProfesionalesId = A890CCDetallesProfId;
            AV19CentroCostosDetallesFecha = A892CentroCostosDetallesFecha;
            AV20CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
            AV23CentroCostosDetallesEstado = A893CentroCostosDetallesEstado;
            pr_default.readNext(11);
         }
         pr_default.close(11);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("controlsubsolicitud",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00IS2_A461CentroCostosId = new long[1] ;
         P00IS2_A889CentroCostosJson = new string[] {""} ;
         A889CentroCostosJson = "";
         AV10CentroCostosIdJson = new GxSimpleCollection<long>();
         P00IS3_A461CentroCostosId = new long[1] ;
         P00IS3_A888CentroCostosDetallesSolId = new long[1] ;
         P00IS3_A466CentroCostosDetallesId = new long[1] ;
         AV9CentroCostosIdCollection = new GxSimpleCollection<long>();
         P00IS4_A127SolicitudesID = new long[1] ;
         P00IS4_A131EstadosSolId = new int[1] ;
         P00IS4_A598SolicitudesUsrActualizacion = new long[1] ;
         P00IS4_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         AV24WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00IS7_A127SolicitudesID = new long[1] ;
         P00IS7_A530SolicitudServicioComALM = new decimal[1] ;
         P00IS7_n530SolicitudServicioComALM = new bool[] {false} ;
         P00IS7_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IS7_A171SolicitudesNombre = new string[] {""} ;
         P00IS7_A131EstadosSolId = new int[1] ;
         P00IS7_A598SolicitudesUsrActualizacion = new long[1] ;
         P00IS7_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         AV19CentroCostosDetallesFecha = DateTime.MinValue;
         AV20CentroCostosDetallesNombre = "";
         P00IS9_A127SolicitudesID = new long[1] ;
         P00IS9_A140RelacionesId = new long[1] ;
         P00IS9_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         AV18ProfesionalesId = "";
         P00IS11_A461CentroCostosId = new long[1] ;
         P00IS11_A888CentroCostosDetallesSolId = new long[1] ;
         P00IS11_A889CentroCostosJson = new string[] {""} ;
         P00IS11_A466CentroCostosDetallesId = new long[1] ;
         P00IS13_A888CentroCostosDetallesSolId = new long[1] ;
         P00IS13_A461CentroCostosId = new long[1] ;
         P00IS13_A468CentroCostosDetallesValor = new decimal[1] ;
         P00IS13_A890CCDetallesProfId = new string[] {""} ;
         P00IS13_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IS13_A473CentroCostosDetallesNombre = new string[] {""} ;
         P00IS13_A893CentroCostosDetallesEstado = new long[1] ;
         P00IS13_A466CentroCostosDetallesId = new long[1] ;
         A890CCDetallesProfId = "";
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         A473CentroCostosDetallesNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.controlsubsolicitud__default(),
            new Object[][] {
                new Object[] {
               P00IS2_A461CentroCostosId, P00IS2_A889CentroCostosJson
               }
               , new Object[] {
               P00IS3_A461CentroCostosId, P00IS3_A888CentroCostosDetallesSolId, P00IS3_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IS4_A127SolicitudesID, P00IS4_A131EstadosSolId, P00IS4_A598SolicitudesUsrActualizacion, P00IS4_n598SolicitudesUsrActualizacion
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00IS7_A127SolicitudesID, P00IS7_A530SolicitudServicioComALM, P00IS7_n530SolicitudServicioComALM, P00IS7_A184SolicitudesFechaInstalacion, P00IS7_A171SolicitudesNombre, P00IS7_A131EstadosSolId, P00IS7_A598SolicitudesUsrActualizacion, P00IS7_n598SolicitudesUsrActualizacion
               }
               , new Object[] {
               }
               , new Object[] {
               P00IS9_A127SolicitudesID, P00IS9_A140RelacionesId, P00IS9_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               P00IS11_A461CentroCostosId, P00IS11_A888CentroCostosDetallesSolId, P00IS11_A889CentroCostosJson, P00IS11_A466CentroCostosDetallesId
               }
               , new Object[] {
               }
               , new Object[] {
               P00IS13_A888CentroCostosDetallesSolId, P00IS13_A461CentroCostosId, P00IS13_A468CentroCostosDetallesValor, P00IS13_A890CCDetallesProfId, P00IS13_A892CentroCostosDetallesFecha, P00IS13_A473CentroCostosDetallesNombre, P00IS13_A893CentroCostosDetallesEstado, P00IS13_A466CentroCostosDetallesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27GXV1 ;
      private int A131EstadosSolId ;
      private long AV8CentroCostosId ;
      private long A461CentroCostosId ;
      private long A888CentroCostosDetallesSolId ;
      private long A466CentroCostosDetallesId ;
      private long AV11CentroCostosDetallesSolId ;
      private long A127SolicitudesID ;
      private long A598SolicitudesUsrActualizacion ;
      private long O893CentroCostosDetallesEstado ;
      private long A893CentroCostosDetallesEstado ;
      private long AV23CentroCostosDetallesEstado ;
      private long A140RelacionesId ;
      private decimal A530SolicitudServicioComALM ;
      private decimal AV15CentroCostosDetallesValor ;
      private decimal A468CentroCostosDetallesValor ;
      private string A171SolicitudesNombre ;
      private string AV20CentroCostosDetallesNombre ;
      private string A120ProfesionalesId ;
      private string AV18ProfesionalesId ;
      private string A890CCDetallesProfId ;
      private string A473CentroCostosDetallesNombre ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV19CentroCostosDetallesFecha ;
      private DateTime A892CentroCostosDetallesFecha ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n530SolicitudServicioComALM ;
      private bool returnInSub ;
      private string A889CentroCostosJson ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00IS2_A461CentroCostosId ;
      private string[] P00IS2_A889CentroCostosJson ;
      private GxSimpleCollection<long> AV10CentroCostosIdJson ;
      private long[] P00IS3_A461CentroCostosId ;
      private long[] P00IS3_A888CentroCostosDetallesSolId ;
      private long[] P00IS3_A466CentroCostosDetallesId ;
      private GxSimpleCollection<long> AV9CentroCostosIdCollection ;
      private long[] P00IS4_A127SolicitudesID ;
      private int[] P00IS4_A131EstadosSolId ;
      private long[] P00IS4_A598SolicitudesUsrActualizacion ;
      private bool[] P00IS4_n598SolicitudesUsrActualizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV24WWPContext ;
      private long[] P00IS7_A127SolicitudesID ;
      private decimal[] P00IS7_A530SolicitudServicioComALM ;
      private bool[] P00IS7_n530SolicitudServicioComALM ;
      private DateTime[] P00IS7_A184SolicitudesFechaInstalacion ;
      private string[] P00IS7_A171SolicitudesNombre ;
      private int[] P00IS7_A131EstadosSolId ;
      private long[] P00IS7_A598SolicitudesUsrActualizacion ;
      private bool[] P00IS7_n598SolicitudesUsrActualizacion ;
      private long[] P00IS9_A127SolicitudesID ;
      private long[] P00IS9_A140RelacionesId ;
      private string[] P00IS9_A120ProfesionalesId ;
      private long[] P00IS11_A461CentroCostosId ;
      private long[] P00IS11_A888CentroCostosDetallesSolId ;
      private string[] P00IS11_A889CentroCostosJson ;
      private long[] P00IS11_A466CentroCostosDetallesId ;
      private long[] P00IS13_A888CentroCostosDetallesSolId ;
      private long[] P00IS13_A461CentroCostosId ;
      private decimal[] P00IS13_A468CentroCostosDetallesValor ;
      private string[] P00IS13_A890CCDetallesProfId ;
      private DateTime[] P00IS13_A892CentroCostosDetallesFecha ;
      private string[] P00IS13_A473CentroCostosDetallesNombre ;
      private long[] P00IS13_A893CentroCostosDetallesEstado ;
      private long[] P00IS13_A466CentroCostosDetallesId ;
   }

   public class controlsubsolicitud__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00IS2;
          prmP00IS2 = new Object[] {
          new ParDef("@AV8CentroCostosId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS3;
          prmP00IS3 = new Object[] {
          new ParDef("@AV8CentroCostosId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS4;
          prmP00IS4 = new Object[] {
          new ParDef("@AV11CentroCostosDetallesSolId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS5;
          prmP00IS5 = new Object[] {
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IS6;
          prmP00IS6 = new Object[] {
          new ParDef("@AV11CentroCostosDetallesSolId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS7;
          prmP00IS7 = new Object[] {
          new ParDef("@AV11CentroCostosDetallesSolId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS8;
          prmP00IS8 = new Object[] {
          new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IS9;
          prmP00IS9 = new Object[] {
          new ParDef("@AV11CentroCostosDetallesSolId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS10;
          prmP00IS10 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@RelacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS11;
          prmP00IS11 = new Object[] {
          new ParDef("@AV8CentroCostosId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS12;
          prmP00IS12 = new Object[] {
          new ParDef("@CentroCostosJson",GXType.NVarChar,2097152,0) ,
          new ParDef("@CentroCostosId",GXType.Decimal,18,0)
          };
          Object[] prmP00IS13;
          prmP00IS13 = new Object[] {
          new ParDef("@AV8CentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11CentroCostosDetallesSolId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IS2", "SELECT [CentroCostosId], [CentroCostosJson] FROM [CentroCostos] WHERE [CentroCostosId] = @AV8CentroCostosId ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IS3", "SELECT [CentroCostosId], [CentroCostosDetallesSolId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @AV8CentroCostosId ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00IS4", "SELECT [SolicitudesID], [EstadosSolId], [SolicitudesUsrActualizacion] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV11CentroCostosDetallesSolId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00IS5", "UPDATE [Solicitudes] SET [EstadosSolId]=@EstadosSolId, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IS5)
             ,new CursorDef("P00IS6", "UPDATE [Relaciones] SET [ProfesionalesId]='', [EstadoSGId]=3  WHERE [SolicitudesID] = @AV11CentroCostosDetallesSolId and [RelacionesId] = 1", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IS6)
             ,new CursorDef("P00IS7", "SELECT [SolicitudesID], [SolicitudServicioComALM], [SolicitudesFechaInstalacion], [SolicitudesNombre], [EstadosSolId], [SolicitudesUsrActualizacion] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV11CentroCostosDetallesSolId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00IS8", "UPDATE [Solicitudes] SET [SolicitudServicioComALM]=@SolicitudServicioComALM, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesNombre]=@SolicitudesNombre, [EstadosSolId]=@EstadosSolId, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IS8)
             ,new CursorDef("P00IS9", "SELECT [SolicitudesID], [RelacionesId], [ProfesionalesId] FROM [Relaciones] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV11CentroCostosDetallesSolId and [RelacionesId] = 1 ORDER BY [SolicitudesID], [RelacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00IS10", "UPDATE [Relaciones] SET [ProfesionalesId]=@ProfesionalesId  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IS10)
             ,new CursorDef("P00IS11", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesSolId], T2.[CentroCostosJson], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 WITH (UPDLOCK) ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE T1.[CentroCostosId] = @AV8CentroCostosId ORDER BY T1.[CentroCostosId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IS12", "UPDATE [CentroCostos] SET [CentroCostosJson]=@CentroCostosJson  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IS12)
             ,new CursorDef("P00IS13", "SELECT [CentroCostosDetallesSolId], [CentroCostosId], [CentroCostosDetallesValor], [CCDetallesProfId], [CentroCostosDetallesFecha], [CentroCostosDetallesNombre], [CentroCostosDetallesEstado], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE ([CentroCostosId] = @AV8CentroCostosId) AND ([CentroCostosDetallesSolId] = @AV11CentroCostosDetallesSolId) ORDER BY [CentroCostosId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IS13,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
