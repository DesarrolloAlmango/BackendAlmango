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
namespace GeneXus.Programs.comercios {
   public class ocantsolicitudescardtime : GXProcedure
   {
      public ocantsolicitudescardtime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocantsolicitudescardtime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Fecha ,
                           long aP1_ProveedorID ,
                           out SdtSDTCantSol aP2_SDTCantSol )
      {
         this.AV18Fecha = aP0_Fecha;
         this.AV8ProveedorID = aP1_ProveedorID;
         this.AV9SDTCantSol = new SdtSDTCantSol(context) ;
         initialize();
         ExecutePrivate();
         aP2_SDTCantSol=this.AV9SDTCantSol;
      }

      public SdtSDTCantSol executeUdp( DateTime aP0_Fecha ,
                                       long aP1_ProveedorID )
      {
         execute(aP0_Fecha, aP1_ProveedorID, out aP2_SDTCantSol);
         return AV9SDTCantSol ;
      }

      public void executeSubmit( DateTime aP0_Fecha ,
                                 long aP1_ProveedorID ,
                                 out SdtSDTCantSol aP2_SDTCantSol )
      {
         this.AV18Fecha = aP0_Fecha;
         this.AV8ProveedorID = aP1_ProveedorID;
         this.AV9SDTCantSol = new SdtSDTCantSol(context) ;
         SubmitImpl();
         aP2_SDTCantSol=this.AV9SDTCantSol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19SolicitudesFechaInstalacion = DateTimeUtil.DAdd(AV18Fecha,-((int)(1)));
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         /* Using cursor P00DK2 */
         pr_default.execute(0, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A131EstadosSolId = P00DK2_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK2_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK2_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK2_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Ayer = (long)(AV9SDTCantSol.gxTpr_Ayer+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Ayerturnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9SDTCantSol.gxTpr_Ayerfecha = AV19SolicitudesFechaInstalacion;
         AV19SolicitudesFechaInstalacion = AV18Fecha;
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         /* Using cursor P00DK3 */
         pr_default.execute(1, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A131EstadosSolId = P00DK3_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK3_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK3_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK3_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK3_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Hoy = (long)(AV9SDTCantSol.gxTpr_Hoy+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Hoyturnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV9SDTCantSol.gxTpr_Hoyfecha = AV19SolicitudesFechaInstalacion;
         AV19SolicitudesFechaInstalacion = DateTimeUtil.DAdd(AV18Fecha,+((int)(1)));
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         /* Using cursor P00DK4 */
         pr_default.execute(2, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A131EstadosSolId = P00DK4_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK4_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK4_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK4_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK4_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Manana = (long)(AV9SDTCantSol.gxTpr_Manana+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Mananaturnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV9SDTCantSol.gxTpr_Mananafecha = AV19SolicitudesFechaInstalacion;
         AV19SolicitudesFechaInstalacion = DateTimeUtil.DAdd(AV18Fecha,+((int)(2)));
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         /* Using cursor P00DK5 */
         pr_default.execute(3, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A131EstadosSolId = P00DK5_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK5_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK5_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK5_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK5_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Pmanana = (long)(AV9SDTCantSol.gxTpr_Pmanana+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Pmananaturnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV9SDTCantSol.gxTpr_Pmananafecha = AV19SolicitudesFechaInstalacion;
         AV19SolicitudesFechaInstalacion = DateTimeUtil.DAdd(AV18Fecha,+((int)(3)));
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         /* Using cursor P00DK6 */
         pr_default.execute(4, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A131EstadosSolId = P00DK6_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK6_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK6_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK6_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK6_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Dia1 = (long)(AV9SDTCantSol.gxTpr_Dia1+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Dia1turnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV9SDTCantSol.gxTpr_Dia1fecha = AV19SolicitudesFechaInstalacion;
         AV20T1 = 0;
         AV21T2 = 0;
         AV22T3 = 0;
         AV19SolicitudesFechaInstalacion = DateTimeUtil.DAdd(AV18Fecha,+((int)(4)));
         /* Using cursor P00DK7 */
         pr_default.execute(5, new Object[] {AV8ProveedorID, AV19SolicitudesFechaInstalacion});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A131EstadosSolId = P00DK7_A131EstadosSolId[0];
            A184SolicitudesFechaInstalacion = P00DK7_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00DK7_A133ProveedorID[0];
            A183SolicitudesHoraInstalacion = P00DK7_A183SolicitudesHoraInstalacion[0];
            A127SolicitudesID = P00DK7_A127SolicitudesID[0];
            AV9SDTCantSol.gxTpr_Dia2 = (long)(AV9SDTCantSol.gxTpr_Dia2+1);
            if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
            {
               AV20T1 = (long)(AV20T1+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
            {
               AV21T2 = (long)(AV21T2+1);
            }
            else if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
            {
               AV22T3 = (long)(AV22T3+1);
            }
            AV9SDTCantSol.gxTpr_Dia2turnos = StringUtil.Format( context.GetMessage( "Turnos:A%1 B%2 C%3", ""), StringUtil.LTrimStr( (decimal)(AV20T1), 10, 0), StringUtil.LTrimStr( (decimal)(AV21T2), 10, 0), StringUtil.LTrimStr( (decimal)(AV22T3), 10, 0), "", "", "", "", "", "");
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV9SDTCantSol.gxTpr_Dia2fecha = AV19SolicitudesFechaInstalacion;
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
         AV9SDTCantSol = new SdtSDTCantSol(context);
         AV19SolicitudesFechaInstalacion = DateTime.MinValue;
         P00DK2_A131EstadosSolId = new int[1] ;
         P00DK2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK2_A133ProveedorID = new long[1] ;
         P00DK2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK2_A127SolicitudesID = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         P00DK3_A131EstadosSolId = new int[1] ;
         P00DK3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK3_A133ProveedorID = new long[1] ;
         P00DK3_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK3_A127SolicitudesID = new long[1] ;
         P00DK4_A131EstadosSolId = new int[1] ;
         P00DK4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK4_A133ProveedorID = new long[1] ;
         P00DK4_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK4_A127SolicitudesID = new long[1] ;
         P00DK5_A131EstadosSolId = new int[1] ;
         P00DK5_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK5_A133ProveedorID = new long[1] ;
         P00DK5_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK5_A127SolicitudesID = new long[1] ;
         P00DK6_A131EstadosSolId = new int[1] ;
         P00DK6_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK6_A133ProveedorID = new long[1] ;
         P00DK6_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK6_A127SolicitudesID = new long[1] ;
         P00DK7_A131EstadosSolId = new int[1] ;
         P00DK7_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DK7_A133ProveedorID = new long[1] ;
         P00DK7_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00DK7_A127SolicitudesID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercios.ocantsolicitudescardtime__default(),
            new Object[][] {
                new Object[] {
               P00DK2_A131EstadosSolId, P00DK2_A184SolicitudesFechaInstalacion, P00DK2_A133ProveedorID, P00DK2_A183SolicitudesHoraInstalacion, P00DK2_A127SolicitudesID
               }
               , new Object[] {
               P00DK3_A131EstadosSolId, P00DK3_A184SolicitudesFechaInstalacion, P00DK3_A133ProveedorID, P00DK3_A183SolicitudesHoraInstalacion, P00DK3_A127SolicitudesID
               }
               , new Object[] {
               P00DK4_A131EstadosSolId, P00DK4_A184SolicitudesFechaInstalacion, P00DK4_A133ProveedorID, P00DK4_A183SolicitudesHoraInstalacion, P00DK4_A127SolicitudesID
               }
               , new Object[] {
               P00DK5_A131EstadosSolId, P00DK5_A184SolicitudesFechaInstalacion, P00DK5_A133ProveedorID, P00DK5_A183SolicitudesHoraInstalacion, P00DK5_A127SolicitudesID
               }
               , new Object[] {
               P00DK6_A131EstadosSolId, P00DK6_A184SolicitudesFechaInstalacion, P00DK6_A133ProveedorID, P00DK6_A183SolicitudesHoraInstalacion, P00DK6_A127SolicitudesID
               }
               , new Object[] {
               P00DK7_A131EstadosSolId, P00DK7_A184SolicitudesFechaInstalacion, P00DK7_A133ProveedorID, P00DK7_A183SolicitudesHoraInstalacion, P00DK7_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A131EstadosSolId ;
      private long AV8ProveedorID ;
      private long AV20T1 ;
      private long AV21T2 ;
      private long AV22T3 ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private string A183SolicitudesHoraInstalacion ;
      private DateTime AV18Fecha ;
      private DateTime AV19SolicitudesFechaInstalacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCantSol AV9SDTCantSol ;
      private IDataStoreProvider pr_default ;
      private int[] P00DK2_A131EstadosSolId ;
      private DateTime[] P00DK2_A184SolicitudesFechaInstalacion ;
      private long[] P00DK2_A133ProveedorID ;
      private string[] P00DK2_A183SolicitudesHoraInstalacion ;
      private long[] P00DK2_A127SolicitudesID ;
      private int[] P00DK3_A131EstadosSolId ;
      private DateTime[] P00DK3_A184SolicitudesFechaInstalacion ;
      private long[] P00DK3_A133ProveedorID ;
      private string[] P00DK3_A183SolicitudesHoraInstalacion ;
      private long[] P00DK3_A127SolicitudesID ;
      private int[] P00DK4_A131EstadosSolId ;
      private DateTime[] P00DK4_A184SolicitudesFechaInstalacion ;
      private long[] P00DK4_A133ProveedorID ;
      private string[] P00DK4_A183SolicitudesHoraInstalacion ;
      private long[] P00DK4_A127SolicitudesID ;
      private int[] P00DK5_A131EstadosSolId ;
      private DateTime[] P00DK5_A184SolicitudesFechaInstalacion ;
      private long[] P00DK5_A133ProveedorID ;
      private string[] P00DK5_A183SolicitudesHoraInstalacion ;
      private long[] P00DK5_A127SolicitudesID ;
      private int[] P00DK6_A131EstadosSolId ;
      private DateTime[] P00DK6_A184SolicitudesFechaInstalacion ;
      private long[] P00DK6_A133ProveedorID ;
      private string[] P00DK6_A183SolicitudesHoraInstalacion ;
      private long[] P00DK6_A127SolicitudesID ;
      private int[] P00DK7_A131EstadosSolId ;
      private DateTime[] P00DK7_A184SolicitudesFechaInstalacion ;
      private long[] P00DK7_A133ProveedorID ;
      private string[] P00DK7_A183SolicitudesHoraInstalacion ;
      private long[] P00DK7_A127SolicitudesID ;
      private SdtSDTCantSol aP2_SDTCantSol ;
   }

   public class ocantsolicitudescardtime__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DK2;
          prmP00DK2 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          Object[] prmP00DK3;
          prmP00DK3 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          Object[] prmP00DK4;
          prmP00DK4 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          Object[] prmP00DK5;
          prmP00DK5 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          Object[] prmP00DK6;
          prmP00DK6 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          Object[] prmP00DK7;
          prmP00DK7 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV19SolicitudesFechaInstalacion",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DK2", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DK3", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DK4", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DK5", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DK6", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DK7", "SELECT [EstadosSolId], [SolicitudesFechaInstalacion], [ProveedorID], [SolicitudesHoraInstalacion], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV8ProveedorID or @AV8ProveedorID = 0) AND ([EstadosSolId] <> 3) AND ([SolicitudesFechaInstalacion] = @AV19SolicitudesFechaInstalacion) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK7,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
