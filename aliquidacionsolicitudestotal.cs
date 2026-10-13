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
   public class aliquidacionsolicitudestotal : GXProcedure
   {
      public aliquidacionsolicitudestotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aliquidacionsolicitudestotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_OperacionesTipo ,
                           DateTime aP1_OperacionesFechaDesde ,
                           DateTime aP2_OperacionesFechaHasta ,
                           string aP3_OperacionesPeriodoCod ,
                           long aP4_UserId ,
                           out string aP5_Gx_msg ,
                           out bool aP6_IsOk )
      {
         this.AV21OperacionesTipo = aP0_OperacionesTipo;
         this.AV16OperacionesFechaDesde = aP1_OperacionesFechaDesde;
         this.AV17OperacionesFechaHasta = aP2_OperacionesFechaHasta;
         this.AV46OperacionesPeriodoCod = aP3_OperacionesPeriodoCod;
         this.AV38UserId = aP4_UserId;
         this.Gx_msg = "" ;
         this.AV36IsOk = false ;
         initialize();
         ExecutePrivate();
         aP5_Gx_msg=this.Gx_msg;
         aP6_IsOk=this.AV36IsOk;
      }

      public bool executeUdp( string aP0_OperacionesTipo ,
                              DateTime aP1_OperacionesFechaDesde ,
                              DateTime aP2_OperacionesFechaHasta ,
                              string aP3_OperacionesPeriodoCod ,
                              long aP4_UserId ,
                              out string aP5_Gx_msg )
      {
         execute(aP0_OperacionesTipo, aP1_OperacionesFechaDesde, aP2_OperacionesFechaHasta, aP3_OperacionesPeriodoCod, aP4_UserId, out aP5_Gx_msg, out aP6_IsOk);
         return AV36IsOk ;
      }

      public void executeSubmit( string aP0_OperacionesTipo ,
                                 DateTime aP1_OperacionesFechaDesde ,
                                 DateTime aP2_OperacionesFechaHasta ,
                                 string aP3_OperacionesPeriodoCod ,
                                 long aP4_UserId ,
                                 out string aP5_Gx_msg ,
                                 out bool aP6_IsOk )
      {
         this.AV21OperacionesTipo = aP0_OperacionesTipo;
         this.AV16OperacionesFechaDesde = aP1_OperacionesFechaDesde;
         this.AV17OperacionesFechaHasta = aP2_OperacionesFechaHasta;
         this.AV46OperacionesPeriodoCod = aP3_OperacionesPeriodoCod;
         this.AV38UserId = aP4_UserId;
         this.Gx_msg = "" ;
         this.AV36IsOk = false ;
         SubmitImpl();
         aP5_Gx_msg=this.Gx_msg;
         aP6_IsOk=this.AV36IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV36IsOk = true;
         Gx_msg = "";
         if ( StringUtil.StrCmp(AV21OperacionesTipo, "LSF") == 0 )
         {
            /* Using cursor P00D72 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A108EstadosGenericosId = P00D72_A108EstadosGenericosId[0];
               A107EstadosTipo = P00D72_A107EstadosTipo[0];
               A120ProfesionalesId = P00D72_A120ProfesionalesId[0];
               A167ProfesionalesApellidoPrimero = P00D72_A167ProfesionalesApellidoPrimero[0];
               A166ProfesionalesPrimerNombre = P00D72_A166ProfesionalesPrimerNombre[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV20OperacionesRef = A120ProfesionalesId;
                  AV19OperacionesNombreRef = StringUtil.Format( "%1 %2", StringUtil.Trim( A166ProfesionalesPrimerNombre), StringUtil.Trim( A167ProfesionalesApellidoPrimero), "", "", "", "", "", "", "");
                  AV53WalletIsOk = false;
                  AV52WalletMsg = "";
                  new wallet_obtenerocrear(context ).execute(  "PRO",  AV20OperacionesRef, out  AV48WalletId, out  AV51FueCreada, out  AV53WalletIsOk, out  AV52WalletMsg) ;
                  if ( ! AV53WalletIsOk )
                  {
                     AV47Plog = new SdtPlog(context);
                     AV47Plog.gxTpr_Plogmsg = StringUtil.Format( context.GetMessage( "Error cuenta para profesional %1: %2", ""), AV20OperacionesRef, AV52WalletMsg, "", "", "", "", "", "", "");
                     AV47Plog.gxTpr_Plogpgm = context.GetMessage( "Liq. total", "");
                     AV47Plog.Save();
                     context.CommitDataStores("liquidacionsolicitudestotal",pr_default);
                  }
                  else
                  {
                     AV45BalancesSeleccionados.Clear();
                     /* Using cursor P00D73 */
                     pr_default.execute(1, new Object[] {AV20OperacionesRef});
                     while ( (pr_default.getStatus(1) != 101) )
                     {
                        A637WalletId = P00D73_A637WalletId[0];
                        A645WalletBalancesEstadoOPE = P00D73_A645WalletBalancesEstadoOPE[0];
                        A1012WalletBalanceLiquidacion = P00D73_A1012WalletBalanceLiquidacion[0];
                        n1012WalletBalanceLiquidacion = P00D73_n1012WalletBalanceLiquidacion[0];
                        A1010WalletBalancesConcepto = P00D73_A1010WalletBalancesConcepto[0];
                        n1010WalletBalancesConcepto = P00D73_n1010WalletBalancesConcepto[0];
                        A639WalletCodRefencia = P00D73_A639WalletCodRefencia[0];
                        A638WalletTipoEntidad = P00D73_A638WalletTipoEntidad[0];
                        A640WalletBalancesId = P00D73_A640WalletBalancesId[0];
                        A639WalletCodRefencia = P00D73_A639WalletCodRefencia[0];
                        A638WalletTipoEntidad = P00D73_A638WalletTipoEntidad[0];
                        AV45BalancesSeleccionados.Add(A640WalletBalancesId, 0);
                        pr_default.readNext(1);
                     }
                     pr_default.close(1);
                     AV50DebeLiquidar = false;
                     if ( AV45BalancesSeleccionados.Count > 0 )
                     {
                        AV50DebeLiquidar = true;
                     }
                     else
                     {
                        /* Using cursor P00D74 */
                        pr_default.execute(2, new Object[] {AV20OperacionesRef, AV16OperacionesFechaDesde, AV17OperacionesFechaHasta});
                        while ( (pr_default.getStatus(2) != 101) )
                        {
                           A127SolicitudesID = P00D74_A127SolicitudesID[0];
                           A184SolicitudesFechaInstalacion = P00D74_A184SolicitudesFechaInstalacion[0];
                           A131EstadosSolId = P00D74_A131EstadosSolId[0];
                           A130EstadosSolTipo = P00D74_A130EstadosSolTipo[0];
                           A688SolicitudesLiqProf = P00D74_A688SolicitudesLiqProf[0];
                           n688SolicitudesLiqProf = P00D74_n688SolicitudesLiqProf[0];
                           A142EstadoSGId = P00D74_A142EstadoSGId[0];
                           A141EstadoSGTipo = P00D74_A141EstadoSGTipo[0];
                           A120ProfesionalesId = P00D74_A120ProfesionalesId[0];
                           A140RelacionesId = P00D74_A140RelacionesId[0];
                           A184SolicitudesFechaInstalacion = P00D74_A184SolicitudesFechaInstalacion[0];
                           A131EstadosSolId = P00D74_A131EstadosSolId[0];
                           A130EstadosSolTipo = P00D74_A130EstadosSolTipo[0];
                           A688SolicitudesLiqProf = P00D74_A688SolicitudesLiqProf[0];
                           n688SolicitudesLiqProf = P00D74_n688SolicitudesLiqProf[0];
                           if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
                           {
                              if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
                              {
                                 AV50DebeLiquidar = true;
                                 /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                 if (true) break;
                              }
                           }
                           pr_default.readNext(2);
                        }
                        pr_default.close(2);
                     }
                     if ( AV50DebeLiquidar )
                     {
                        AV55LiqIsOk = false;
                        AV54LiqMsg = "";
                        new liquidacionsolicitudes(context ).execute(  AV21OperacionesTipo,  AV20OperacionesRef,  AV19OperacionesNombreRef,  AV16OperacionesFechaDesde,  AV17OperacionesFechaHasta,  AV45BalancesSeleccionados,  AV46OperacionesPeriodoCod, out  AV54LiqMsg, out  AV55LiqIsOk) ;
                        if ( ! AV55LiqIsOk )
                        {
                           AV47Plog = new SdtPlog(context);
                           AV47Plog.gxTpr_Plogmsg = StringUtil.Format( context.GetMessage( "Error al liquidar profesional %1: %2", ""), AV20OperacionesRef, AV54LiqMsg, "", "", "", "", "", "", "");
                           AV47Plog.gxTpr_Plogpgm = context.GetMessage( "Liq. total", "");
                           AV47Plog.Save();
                           context.CommitDataStores("liquidacionsolicitudestotal",pr_default);
                        }
                     }
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV36IsOk = true;
            Gx_msg = context.GetMessage( "Proceso masivo completado.", "");
         }
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
         Gx_msg = "";
         P00D72_A108EstadosGenericosId = new int[1] ;
         P00D72_A107EstadosTipo = new string[] {""} ;
         P00D72_A120ProfesionalesId = new string[] {""} ;
         P00D72_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00D72_A166ProfesionalesPrimerNombre = new string[] {""} ;
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         AV20OperacionesRef = "";
         AV19OperacionesNombreRef = "";
         AV52WalletMsg = "";
         AV47Plog = new SdtPlog(context);
         AV45BalancesSeleccionados = new GxSimpleCollection<long>();
         P00D73_A637WalletId = new long[1] ;
         P00D73_A645WalletBalancesEstadoOPE = new string[] {""} ;
         P00D73_A1012WalletBalanceLiquidacion = new long[1] ;
         P00D73_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         P00D73_A1010WalletBalancesConcepto = new short[1] ;
         P00D73_n1010WalletBalancesConcepto = new bool[] {false} ;
         P00D73_A639WalletCodRefencia = new string[] {""} ;
         P00D73_A638WalletTipoEntidad = new string[] {""} ;
         P00D73_A640WalletBalancesId = new long[1] ;
         A645WalletBalancesEstadoOPE = "";
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         P00D74_A127SolicitudesID = new long[1] ;
         P00D74_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00D74_A131EstadosSolId = new int[1] ;
         P00D74_A130EstadosSolTipo = new string[] {""} ;
         P00D74_A688SolicitudesLiqProf = new long[1] ;
         P00D74_n688SolicitudesLiqProf = new bool[] {false} ;
         P00D74_A142EstadoSGId = new int[1] ;
         P00D74_A141EstadoSGTipo = new string[] {""} ;
         P00D74_A120ProfesionalesId = new string[] {""} ;
         P00D74_A140RelacionesId = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         AV54LiqMsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aliquidacionsolicitudestotal__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aliquidacionsolicitudestotal__default(),
            new Object[][] {
                new Object[] {
               P00D72_A108EstadosGenericosId, P00D72_A107EstadosTipo, P00D72_A120ProfesionalesId, P00D72_A167ProfesionalesApellidoPrimero, P00D72_A166ProfesionalesPrimerNombre
               }
               , new Object[] {
               P00D73_A637WalletId, P00D73_A645WalletBalancesEstadoOPE, P00D73_A1012WalletBalanceLiquidacion, P00D73_n1012WalletBalanceLiquidacion, P00D73_A1010WalletBalancesConcepto, P00D73_n1010WalletBalancesConcepto, P00D73_A639WalletCodRefencia, P00D73_A638WalletTipoEntidad, P00D73_A640WalletBalancesId
               }
               , new Object[] {
               P00D74_A127SolicitudesID, P00D74_A184SolicitudesFechaInstalacion, P00D74_A131EstadosSolId, P00D74_A130EstadosSolTipo, P00D74_A688SolicitudesLiqProf, P00D74_n688SolicitudesLiqProf, P00D74_A142EstadoSGId, P00D74_A141EstadoSGTipo, P00D74_A120ProfesionalesId, P00D74_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A1010WalletBalancesConcepto ;
      private int A108EstadosGenericosId ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private long AV38UserId ;
      private long AV48WalletId ;
      private long A637WalletId ;
      private long A1012WalletBalanceLiquidacion ;
      private long A640WalletBalancesId ;
      private long A127SolicitudesID ;
      private long A688SolicitudesLiqProf ;
      private long A140RelacionesId ;
      private string AV21OperacionesTipo ;
      private string Gx_msg ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string AV20OperacionesRef ;
      private string AV19OperacionesNombreRef ;
      private string A645WalletBalancesEstadoOPE ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private DateTime AV16OperacionesFechaDesde ;
      private DateTime AV17OperacionesFechaHasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV36IsOk ;
      private bool AV53WalletIsOk ;
      private bool AV51FueCreada ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n1010WalletBalancesConcepto ;
      private bool AV50DebeLiquidar ;
      private bool n688SolicitudesLiqProf ;
      private bool AV55LiqIsOk ;
      private string AV46OperacionesPeriodoCod ;
      private string AV52WalletMsg ;
      private string AV54LiqMsg ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00D72_A108EstadosGenericosId ;
      private string[] P00D72_A107EstadosTipo ;
      private string[] P00D72_A120ProfesionalesId ;
      private string[] P00D72_A167ProfesionalesApellidoPrimero ;
      private string[] P00D72_A166ProfesionalesPrimerNombre ;
      private SdtPlog AV47Plog ;
      private GxSimpleCollection<long> AV45BalancesSeleccionados ;
      private long[] P00D73_A637WalletId ;
      private string[] P00D73_A645WalletBalancesEstadoOPE ;
      private long[] P00D73_A1012WalletBalanceLiquidacion ;
      private bool[] P00D73_n1012WalletBalanceLiquidacion ;
      private short[] P00D73_A1010WalletBalancesConcepto ;
      private bool[] P00D73_n1010WalletBalancesConcepto ;
      private string[] P00D73_A639WalletCodRefencia ;
      private string[] P00D73_A638WalletTipoEntidad ;
      private long[] P00D73_A640WalletBalancesId ;
      private long[] P00D74_A127SolicitudesID ;
      private DateTime[] P00D74_A184SolicitudesFechaInstalacion ;
      private int[] P00D74_A131EstadosSolId ;
      private string[] P00D74_A130EstadosSolTipo ;
      private long[] P00D74_A688SolicitudesLiqProf ;
      private bool[] P00D74_n688SolicitudesLiqProf ;
      private int[] P00D74_A142EstadoSGId ;
      private string[] P00D74_A141EstadoSGTipo ;
      private string[] P00D74_A120ProfesionalesId ;
      private long[] P00D74_A140RelacionesId ;
      private string aP5_Gx_msg ;
      private bool aP6_IsOk ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aliquidacionsolicitudestotal__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class aliquidacionsolicitudestotal__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00D72;
        prmP00D72 = new Object[] {
        };
        Object[] prmP00D73;
        prmP00D73 = new Object[] {
        new ParDef("@AV20OperacionesRef",GXType.NChar,25,0)
        };
        Object[] prmP00D74;
        prmP00D74 = new Object[] {
        new ParDef("@AV20OperacionesRef",GXType.Char,25,0) ,
        new ParDef("@AV16OperacionesFechaDesde",GXType.Date,8,0) ,
        new ParDef("@AV17OperacionesFechaHasta",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00D72", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre] FROM [Profesionales] WHERE [EstadosGenericosId] = 1 ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D72,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00D73", "SELECT T1.[WalletId], T1.[WalletBalancesEstadoOPE], T1.[WalletBalanceLiquidacion], T1.[WalletBalancesConcepto], T2.[WalletCodRefencia], T2.[WalletTipoEntidad], T1.[WalletBalancesId] FROM ([WalletBalances] T1 INNER JOIN [Wallet] T2 ON T2.[WalletId] = T1.[WalletId]) WHERE (T1.[WalletBalancesConcepto] <> 5) AND (T1.[WalletBalanceLiquidacion] IS NULL or (T1.[WalletBalanceLiquidacion] = convert(int, 0)) or T1.[WalletBalanceLiquidacion] = 0) AND (T2.[WalletTipoEntidad] = 'PRO') AND (T2.[WalletCodRefencia] = @AV20OperacionesRef) AND (T1.[WalletBalancesEstadoOPE] = 'PND') ORDER BY T1.[WalletId], T1.[WalletBalancesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D73,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00D74", "SELECT T1.[SolicitudesID], T2.[SolicitudesFechaInstalacion], T2.[EstadosSolId], T2.[EstadosSolTipo], T2.[SolicitudesLiqProf], T1.[EstadoSGId], T1.[EstadoSGTipo], T1.[ProfesionalesId], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = @AV20OperacionesRef) AND (T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)) or T2.[SolicitudesLiqProf] = 0) AND (T2.[EstadosSolId] = 6 or T2.[EstadosSolId] = 7 or T2.[EstadosSolId] = 5 or T2.[EstadosSolId] = 2) AND (T2.[SolicitudesFechaInstalacion] >= @AV16OperacionesFechaDesde) AND (T2.[SolicitudesFechaInstalacion] <= @AV17OperacionesFechaHasta) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D74,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 25);
              ((string[]) buf[7])[0] = rslt.getString(6, 3);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 3);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              return;
     }
  }

}

}
