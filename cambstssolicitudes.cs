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
   public class cambstssolicitudes : GXProcedure
   {
      public cambstssolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cambstssolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           int aP1_NuevoEstadoId ,
                           string aP2_ProfesionalesId ,
                           SdtSDTCNotificaciones aP3_SDTCNotificaciones ,
                           string aP4_UsuariosId ,
                           out string aP5_CambioSTSOK )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV13NuevoEstadoId = aP1_NuevoEstadoId;
         this.AV8ProfesionalesId = aP2_ProfesionalesId;
         this.AV16SDTCNotificaciones = aP3_SDTCNotificaciones;
         this.AV28UsuariosId = aP4_UsuariosId;
         this.AV15CambioSTSOK = "" ;
         initialize();
         ExecutePrivate();
         aP5_CambioSTSOK=this.AV15CambioSTSOK;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                int aP1_NuevoEstadoId ,
                                string aP2_ProfesionalesId ,
                                SdtSDTCNotificaciones aP3_SDTCNotificaciones ,
                                string aP4_UsuariosId )
      {
         execute(aP0_SolicitudesID, aP1_NuevoEstadoId, aP2_ProfesionalesId, aP3_SDTCNotificaciones, aP4_UsuariosId, out aP5_CambioSTSOK);
         return AV15CambioSTSOK ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 int aP1_NuevoEstadoId ,
                                 string aP2_ProfesionalesId ,
                                 SdtSDTCNotificaciones aP3_SDTCNotificaciones ,
                                 string aP4_UsuariosId ,
                                 out string aP5_CambioSTSOK )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV13NuevoEstadoId = aP1_NuevoEstadoId;
         this.AV8ProfesionalesId = aP2_ProfesionalesId;
         this.AV16SDTCNotificaciones = aP3_SDTCNotificaciones;
         this.AV28UsuariosId = aP4_UsuariosId;
         this.AV15CambioSTSOK = "" ;
         SubmitImpl();
         aP5_CambioSTSOK=this.AV15CambioSTSOK;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15CambioSTSOK = context.GetMessage( "N", "");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV27WWPContext) ;
         /* Using cursor P009S2 */
         pr_default.execute(0, new Object[] {AV9SolicitudesID, AV13NuevoEstadoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXT9S2 = 0;
            A131EstadosSolId = P009S2_A131EstadosSolId[0];
            A127SolicitudesID = P009S2_A127SolicitudesID[0];
            A672SolicitudesCalComi = P009S2_A672SolicitudesCalComi[0];
            A527SolicitudServicioComProv = P009S2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P009S2_n527SolicitudServicioComProv[0];
            A528SolicitudServicioComProvP = P009S2_A528SolicitudServicioComProvP[0];
            n528SolicitudServicioComProvP = P009S2_n528SolicitudServicioComProvP[0];
            A530SolicitudServicioComALM = P009S2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P009S2_n530SolicitudServicioComALM[0];
            A532SolicitudServicioComALMP = P009S2_A532SolicitudServicioComALMP[0];
            n532SolicitudServicioComALMP = P009S2_n532SolicitudServicioComALMP[0];
            A866SolicitudesCostoXZComAlmP = P009S2_A866SolicitudesCostoXZComAlmP[0];
            n866SolicitudesCostoXZComAlmP = P009S2_n866SolicitudesCostoXZComAlmP[0];
            A864SolicitudesCostoXZona = P009S2_A864SolicitudesCostoXZona[0];
            A865SolicitudesCostoXZComAlm = P009S2_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P009S2_n865SolicitudesCostoXZComAlm[0];
            A598SolicitudesUsrActualizacion = P009S2_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = P009S2_n598SolicitudesUsrActualizacion[0];
            A441SolicitudesPagado = P009S2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P009S2_n441SolicitudesPagado[0];
            if ( ( ( AV13NuevoEstadoId == 2 ) || ( AV13NuevoEstadoId == 5 ) ) && ( A672SolicitudesCalComi ) )
            {
               new ocomisionsolicitud(context ).execute(  A127SolicitudesID,  AV8ProfesionalesId,  true, out  AV20SolicitudServicioComProv, out  AV21SolicitudServicioComProvP, out  AV22SolicitudServicioComALM, out  AV23SolicitudServicioComALMP, out  AV24SolicitudServicioComPro, out  AV25SolicitudServicioComProP) ;
               A527SolicitudServicioComProv = AV20SolicitudServicioComProv;
               n527SolicitudServicioComProv = false;
               A528SolicitudServicioComProvP = AV21SolicitudServicioComProvP;
               n528SolicitudServicioComProvP = false;
               A530SolicitudServicioComALM = AV22SolicitudServicioComALM;
               n530SolicitudServicioComALM = false;
               A532SolicitudServicioComALMP = AV23SolicitudServicioComALMP;
               n532SolicitudServicioComALMP = false;
               GXt_decimal1 = A866SolicitudesCostoXZComAlmP;
               new ocomisionglobal(context ).execute( out  GXt_decimal1) ;
               A866SolicitudesCostoXZComAlmP = GXt_decimal1;
               n866SolicitudesCostoXZComAlmP = false;
               A865SolicitudesCostoXZComAlm = (decimal)(A864SolicitudesCostoXZona*(A866SolicitudesCostoXZComAlmP/ (decimal)(100)));
               n865SolicitudesCostoXZComAlm = false;
            }
            if ( ! (0==AV27WWPContext.gxTpr_Userid) )
            {
               A598SolicitudesUsrActualizacion = AV27WWPContext.gxTpr_Userid;
               n598SolicitudesUsrActualizacion = false;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UsuariosId)) )
            {
               A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( AV28UsuariosId, "."), 18, MidpointRounding.ToEven));
               n598SolicitudesUsrActualizacion = false;
            }
            A131EstadosSolId = AV13NuevoEstadoId;
            if ( AV13NuevoEstadoId == 6 )
            {
               A441SolicitudesPagado = context.GetMessage( "S", "");
               n441SolicitudesPagado = false;
            }
            GXT9S2 = 1;
            AV15CambioSTSOK = context.GetMessage( "S", "");
            /* Using cursor P009S3 */
            pr_default.execute(1, new Object[] {A131EstadosSolId, n527SolicitudServicioComProv, A527SolicitudServicioComProv, n528SolicitudServicioComProvP, A528SolicitudServicioComProvP, n530SolicitudServicioComALM, A530SolicitudServicioComALM, n532SolicitudServicioComALMP, A532SolicitudServicioComALMP, n866SolicitudesCostoXZComAlmP, A866SolicitudesCostoXZComAlmP, n865SolicitudesCostoXZComAlm, A865SolicitudesCostoXZComAlm, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n441SolicitudesPagado, A441SolicitudesPagado, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            if ( GXT9S2 == 1 )
            {
               context.CommitDataStores("cambstssolicitudes",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ( AV13NuevoEstadoId == 4 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) || ( AV13NuevoEstadoId == 3 ) )
         {
            AV10Vinculo = context.GetMessage( "N", "");
            /* Using cursor P009S4 */
            pr_default.execute(2, new Object[] {AV9SolicitudesID, AV8ProfesionalesId, AV13NuevoEstadoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               GXT9S3 = 0;
               A120ProfesionalesId = P009S4_A120ProfesionalesId[0];
               A127SolicitudesID = P009S4_A127SolicitudesID[0];
               A142EstadoSGId = P009S4_A142EstadoSGId[0];
               A598SolicitudesUsrActualizacion = P009S4_A598SolicitudesUsrActualizacion[0];
               n598SolicitudesUsrActualizacion = P009S4_n598SolicitudesUsrActualizacion[0];
               A140RelacionesId = P009S4_A140RelacionesId[0];
               A598SolicitudesUsrActualizacion = P009S4_A598SolicitudesUsrActualizacion[0];
               n598SolicitudesUsrActualizacion = P009S4_n598SolicitudesUsrActualizacion[0];
               A142EstadoSGId = 2;
               if ( ! (0==AV27WWPContext.gxTpr_Userid) )
               {
                  A598SolicitudesUsrActualizacion = AV27WWPContext.gxTpr_Userid;
                  n598SolicitudesUsrActualizacion = false;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28UsuariosId)) )
               {
                  A598SolicitudesUsrActualizacion = (long)(Math.Round(NumberUtil.Val( AV28UsuariosId, "."), 18, MidpointRounding.ToEven));
                  n598SolicitudesUsrActualizacion = false;
               }
               AV10Vinculo = context.GetMessage( "S", "");
               GXT9S3 = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P009S5 */
               pr_default.execute(3, new Object[] {n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
               /* Using cursor P009S6 */
               pr_default.execute(4, new Object[] {A142EstadoSGId, A127SolicitudesID, A140RelacionesId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
               if ( GXT9S3 == 1 )
               {
                  context.CommitDataStores("cambstssolicitudes",pr_default);
               }
               if (true) break;
               /* Using cursor P009S7 */
               pr_default.execute(5, new Object[] {n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
               pr_default.close(5);
               pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
               /* Using cursor P009S8 */
               pr_default.execute(6, new Object[] {A142EstadoSGId, A127SolicitudesID, A140RelacionesId});
               pr_default.close(6);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
               if ( GXT9S3 == 1 )
               {
                  context.CommitDataStores("cambstssolicitudes",pr_default);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         new cnotificaciones(context ).execute(  AV16SDTCNotificaciones, out  AV17Ok, out  AV18ErrorDescription) ;
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
         AV15CambioSTSOK = "";
         AV27WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P009S2_A131EstadosSolId = new int[1] ;
         P009S2_A127SolicitudesID = new long[1] ;
         P009S2_A672SolicitudesCalComi = new bool[] {false} ;
         P009S2_A527SolicitudServicioComProv = new decimal[1] ;
         P009S2_n527SolicitudServicioComProv = new bool[] {false} ;
         P009S2_A528SolicitudServicioComProvP = new decimal[1] ;
         P009S2_n528SolicitudServicioComProvP = new bool[] {false} ;
         P009S2_A530SolicitudServicioComALM = new decimal[1] ;
         P009S2_n530SolicitudServicioComALM = new bool[] {false} ;
         P009S2_A532SolicitudServicioComALMP = new decimal[1] ;
         P009S2_n532SolicitudServicioComALMP = new bool[] {false} ;
         P009S2_A866SolicitudesCostoXZComAlmP = new decimal[1] ;
         P009S2_n866SolicitudesCostoXZComAlmP = new bool[] {false} ;
         P009S2_A864SolicitudesCostoXZona = new decimal[1] ;
         P009S2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P009S2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P009S2_A598SolicitudesUsrActualizacion = new long[1] ;
         P009S2_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P009S2_A441SolicitudesPagado = new string[] {""} ;
         P009S2_n441SolicitudesPagado = new bool[] {false} ;
         A441SolicitudesPagado = "";
         AV10Vinculo = "";
         P009S4_A120ProfesionalesId = new string[] {""} ;
         P009S4_A127SolicitudesID = new long[1] ;
         P009S4_A142EstadoSGId = new int[1] ;
         P009S4_A598SolicitudesUsrActualizacion = new long[1] ;
         P009S4_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P009S4_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         AV17Ok = "";
         AV18ErrorDescription = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.cambstssolicitudes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cambstssolicitudes__default(),
            new Object[][] {
                new Object[] {
               P009S2_A131EstadosSolId, P009S2_A127SolicitudesID, P009S2_A672SolicitudesCalComi, P009S2_A527SolicitudServicioComProv, P009S2_n527SolicitudServicioComProv, P009S2_A528SolicitudServicioComProvP, P009S2_n528SolicitudServicioComProvP, P009S2_A530SolicitudServicioComALM, P009S2_n530SolicitudServicioComALM, P009S2_A532SolicitudServicioComALMP,
               P009S2_n532SolicitudServicioComALMP, P009S2_A866SolicitudesCostoXZComAlmP, P009S2_n866SolicitudesCostoXZComAlmP, P009S2_A864SolicitudesCostoXZona, P009S2_A865SolicitudesCostoXZComAlm, P009S2_n865SolicitudesCostoXZComAlm, P009S2_A598SolicitudesUsrActualizacion, P009S2_n598SolicitudesUsrActualizacion, P009S2_A441SolicitudesPagado, P009S2_n441SolicitudesPagado
               }
               , new Object[] {
               }
               , new Object[] {
               P009S4_A120ProfesionalesId, P009S4_A127SolicitudesID, P009S4_A142EstadoSGId, P009S4_A598SolicitudesUsrActualizacion, P009S4_n598SolicitudesUsrActualizacion, P009S4_A140RelacionesId
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

      private short GXT9S2 ;
      private short GXT9S3 ;
      private int AV13NuevoEstadoId ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private long AV9SolicitudesID ;
      private long A127SolicitudesID ;
      private long A598SolicitudesUsrActualizacion ;
      private long A140RelacionesId ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A528SolicitudServicioComProvP ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A532SolicitudServicioComALMP ;
      private decimal A866SolicitudesCostoXZComAlmP ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal AV20SolicitudServicioComProv ;
      private decimal AV21SolicitudServicioComProvP ;
      private decimal AV22SolicitudServicioComALM ;
      private decimal AV23SolicitudServicioComALMP ;
      private decimal AV24SolicitudServicioComPro ;
      private decimal AV25SolicitudServicioComProP ;
      private decimal GXt_decimal1 ;
      private string AV8ProfesionalesId ;
      private string AV28UsuariosId ;
      private string AV15CambioSTSOK ;
      private string A441SolicitudesPagado ;
      private string AV10Vinculo ;
      private string A120ProfesionalesId ;
      private string AV17Ok ;
      private string AV18ErrorDescription ;
      private bool A672SolicitudesCalComi ;
      private bool n527SolicitudServicioComProv ;
      private bool n528SolicitudServicioComProvP ;
      private bool n530SolicitudServicioComALM ;
      private bool n532SolicitudServicioComALMP ;
      private bool n866SolicitudesCostoXZComAlmP ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n441SolicitudesPagado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCNotificaciones AV16SDTCNotificaciones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV27WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P009S2_A131EstadosSolId ;
      private long[] P009S2_A127SolicitudesID ;
      private bool[] P009S2_A672SolicitudesCalComi ;
      private decimal[] P009S2_A527SolicitudServicioComProv ;
      private bool[] P009S2_n527SolicitudServicioComProv ;
      private decimal[] P009S2_A528SolicitudServicioComProvP ;
      private bool[] P009S2_n528SolicitudServicioComProvP ;
      private decimal[] P009S2_A530SolicitudServicioComALM ;
      private bool[] P009S2_n530SolicitudServicioComALM ;
      private decimal[] P009S2_A532SolicitudServicioComALMP ;
      private bool[] P009S2_n532SolicitudServicioComALMP ;
      private decimal[] P009S2_A866SolicitudesCostoXZComAlmP ;
      private bool[] P009S2_n866SolicitudesCostoXZComAlmP ;
      private decimal[] P009S2_A864SolicitudesCostoXZona ;
      private decimal[] P009S2_A865SolicitudesCostoXZComAlm ;
      private bool[] P009S2_n865SolicitudesCostoXZComAlm ;
      private long[] P009S2_A598SolicitudesUsrActualizacion ;
      private bool[] P009S2_n598SolicitudesUsrActualizacion ;
      private string[] P009S2_A441SolicitudesPagado ;
      private bool[] P009S2_n441SolicitudesPagado ;
      private string[] P009S4_A120ProfesionalesId ;
      private long[] P009S4_A127SolicitudesID ;
      private int[] P009S4_A142EstadoSGId ;
      private long[] P009S4_A598SolicitudesUsrActualizacion ;
      private bool[] P009S4_n598SolicitudesUsrActualizacion ;
      private long[] P009S4_A140RelacionesId ;
      private string aP5_CambioSTSOK ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class cambstssolicitudes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class cambstssolicitudes__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP009S2;
        prmP009S2 = new Object[] {
        new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@AV13NuevoEstadoId",GXType.Int32,5,0)
        };
        Object[] prmP009S3;
        prmP009S3 = new Object[] {
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudServicioComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudServicioComALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlmP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesCostoXZComAlm",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009S4;
        prmP009S4 = new Object[] {
        new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@AV8ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@AV13NuevoEstadoId",GXType.Int32,5,0)
        };
        Object[] prmP009S5;
        prmP009S5 = new Object[] {
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009S6;
        prmP009S6 = new Object[] {
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP009S7;
        prmP009S7 = new Object[] {
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009S8;
        prmP009S8 = new Object[] {
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009S2", "SELECT [EstadosSolId], [SolicitudesID], [SolicitudesCalComi], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesCostoXZComAlmP], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesUsrActualizacion], [SolicitudesPagado] FROM [Solicitudes] WITH (UPDLOCK) WHERE ([SolicitudesID] = @AV9SolicitudesID) AND ([EstadosSolId] <> @AV13NuevoEstadoId) ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009S3", "UPDATE [Solicitudes] SET [EstadosSolId]=@EstadosSolId, [SolicitudServicioComProv]=@SolicitudServicioComProv, [SolicitudServicioComProvP]=@SolicitudServicioComProvP, [SolicitudServicioComALM]=@SolicitudServicioComALM, [SolicitudServicioComALMP]=@SolicitudServicioComALMP, [SolicitudesCostoXZComAlmP]=@SolicitudesCostoXZComAlmP, [SolicitudesCostoXZComAlm]=@SolicitudesCostoXZComAlm, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion, [SolicitudesPagado]=@SolicitudesPagado  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009S3)
           ,new CursorDef("P009S4", "SELECT TOP 1 T1.[ProfesionalesId], T1.[SolicitudesID], T1.[EstadoSGId], T2.[SolicitudesUsrActualizacion], T1.[RelacionesId] FROM ([Relaciones] T1 WITH (UPDLOCK) INNER JOIN [Solicitudes] T2 WITH (UPDLOCK) ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[SolicitudesID] = @AV9SolicitudesID) AND (T1.[ProfesionalesId] = @AV8ProfesionalesId or @AV13NuevoEstadoId = 3) ORDER BY T1.[SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009S5", "UPDATE [Solicitudes] SET [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009S5)
           ,new CursorDef("P009S6", "UPDATE [Relaciones] SET [EstadoSGId]=@EstadoSGId  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009S6)
           ,new CursorDef("P009S7", "UPDATE [Solicitudes] SET [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009S7)
           ,new CursorDef("P009S8", "UPDATE [Relaciones] SET [EstadoSGId]=@EstadoSGId  WHERE [SolicitudesID] = @SolicitudesID AND [RelacionesId] = @RelacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009S8)
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((long[]) buf[16])[0] = rslt.getLong(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 1);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              return;
     }
  }

}

}
