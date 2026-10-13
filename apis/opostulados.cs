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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class opostulados : GXProcedure
   {
      public opostulados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public opostulados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ,
                           out string aP2_RestMessage ,
                           out short aP3_Gx_restcode )
      {
         this.AV13SolicitudesId = aP0_SolicitudesId;
         this.AV12SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>( context, "SDTPerfilProfesional", "AlmangoX") ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP1_SDTPerfilProfesional=this.AV12SDTPerfilProfesional;
         aP2_RestMessage=this.AV11RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ,
                               out string aP2_RestMessage )
      {
         execute(aP0_SolicitudesId, out aP1_SDTPerfilProfesional, out aP2_RestMessage, out aP3_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ,
                                 out string aP2_RestMessage ,
                                 out short aP3_Gx_restcode )
      {
         this.AV13SolicitudesId = aP0_SolicitudesId;
         this.AV12SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>( context, "SDTPerfilProfesional", "AlmangoX") ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP1_SDTPerfilProfesional=this.AV12SDTPerfilProfesional;
         aP2_RestMessage=this.AV11RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV14HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV14HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV14HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         AV12SDTPerfilProfesional.Clear();
         Gx_restcode = 200;
         AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         AV16GXLvl9 = 0;
         /* Using cursor P00LX2 */
         pr_default.execute(0, new Object[] {AV13SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422PostulacionesId = P00LX2_A422PostulacionesId[0];
            n422PostulacionesId = P00LX2_n422PostulacionesId[0];
            A127SolicitudesID = P00LX2_A127SolicitudesID[0];
            AV16GXLvl9 = 1;
            /* Using cursor P00LX3 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00LX3_A120ProfesionalesId[0];
               A958PostulacionProfesionalFechaT = P00LX3_A958PostulacionProfesionalFechaT[0];
               A959PostulacionProfesionalTurnoT = P00LX3_A959PostulacionProfesionalTurnoT[0];
               A956PostulacionProfesionalEstado = P00LX3_A956PostulacionProfesionalEstado[0];
               A166ProfesionalesPrimerNombre = P00LX3_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = P00LX3_A167ProfesionalesApellidoPrimero[0];
               A677ProfesionalesExperiencia = P00LX3_A677ProfesionalesExperiencia[0];
               n677ProfesionalesExperiencia = P00LX3_n677ProfesionalesExperiencia[0];
               A268ProfesionalesFeedBackCant = P00LX3_A268ProfesionalesFeedBackCant[0];
               A269ProfesionalesFeedBackProm = P00LX3_A269ProfesionalesFeedBackProm[0];
               A40006ProfesionalesPhoto_GXI = P00LX3_A40006ProfesionalesPhoto_GXI[0];
               A169ProfesionalesPhoto = P00LX3_A169ProfesionalesPhoto[0];
               A166ProfesionalesPrimerNombre = P00LX3_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = P00LX3_A167ProfesionalesApellidoPrimero[0];
               A677ProfesionalesExperiencia = P00LX3_A677ProfesionalesExperiencia[0];
               n677ProfesionalesExperiencia = P00LX3_n677ProfesionalesExperiencia[0];
               A268ProfesionalesFeedBackCant = P00LX3_A268ProfesionalesFeedBackCant[0];
               A269ProfesionalesFeedBackProm = P00LX3_A269ProfesionalesFeedBackProm[0];
               A40006ProfesionalesPhoto_GXI = P00LX3_A40006ProfesionalesPhoto_GXI[0];
               A169ProfesionalesPhoto = P00LX3_A169ProfesionalesPhoto[0];
               AV10Item = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context);
               AV10Item.gxTpr_Profesionalesid = A120ProfesionalesId;
               AV10Item.gxTpr_Fechapropuesta = A958PostulacionProfesionalFechaT;
               AV10Item.gxTpr_Turnopropuesto = A959PostulacionProfesionalTurnoT;
               AV10Item.gxTpr_Estadopostulacion = A956PostulacionProfesionalEstado;
               AV10Item.gxTpr_Profesionalesprimernombre = A166ProfesionalesPrimerNombre;
               AV10Item.gxTpr_Profesionalesapellidoprimero = A167ProfesionalesApellidoPrimero;
               AV10Item.gxTpr_Profesionalesexperiencia = A677ProfesionalesExperiencia;
               AV10Item.gxTpr_Trabajoscalificados = A268ProfesionalesFeedBackCant;
               if ( A268ProfesionalesFeedBackCant > 0 )
               {
                  AV10Item.gxTpr_Calificacion = NumberUtil.Round( A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant), 1);
               }
               else
               {
                  AV10Item.gxTpr_Calificacion = (decimal)(0);
               }
               AV8idBusqueda = AV10Item.gxTpr_Profesionalesid;
               /* Execute user subroutine: 'OBTENERTRABAJOSFINALIZADOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
               AV9ImagenProfesional = A169ProfesionalesPhoto;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ImagenProfesional)) )
               {
                  AV10Item.gxTpr_Profesionalesphoto = context.FileToBase64( AV9ImagenProfesional);
               }
               AV12SDTPerfilProfesional.Add(AV10Item, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV16GXLvl9 == 0 )
         {
            Gx_restcode = 404;
            AV11RestMessage = context.GetMessage( "No se encontró la solicitud.", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENERTRABAJOSFINALIZADOS' Routine */
         returnInSub = false;
         /* Using cursor P00LX5 */
         pr_default.execute(2, new Object[] {AV8idBusqueda});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P00LX5_A40000GXC1[0];
            n40000GXC1 = P00LX5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV10Item.gxTpr_Trabajosfinalizados = A40000GXC1;
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV12SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>( context, "SDTPerfilProfesional", "AlmangoX");
         AV11RestMessage = "";
         AV14HttpResponse = new GxHttpResponse( context);
         P00LX2_A422PostulacionesId = new long[1] ;
         P00LX2_n422PostulacionesId = new bool[] {false} ;
         P00LX2_A127SolicitudesID = new long[1] ;
         P00LX3_A422PostulacionesId = new long[1] ;
         P00LX3_n422PostulacionesId = new bool[] {false} ;
         P00LX3_A120ProfesionalesId = new string[] {""} ;
         P00LX3_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         P00LX3_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         P00LX3_A956PostulacionProfesionalEstado = new string[] {""} ;
         P00LX3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00LX3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00LX3_A677ProfesionalesExperiencia = new string[] {""} ;
         P00LX3_n677ProfesionalesExperiencia = new bool[] {false} ;
         P00LX3_A268ProfesionalesFeedBackCant = new long[1] ;
         P00LX3_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00LX3_A40006ProfesionalesPhoto_GXI = new string[] {""} ;
         P00LX3_A169ProfesionalesPhoto = new string[] {""} ;
         A120ProfesionalesId = "";
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A956PostulacionProfesionalEstado = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A677ProfesionalesExperiencia = "";
         A40006ProfesionalesPhoto_GXI = "";
         A169ProfesionalesPhoto = "";
         AV10Item = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context);
         AV8idBusqueda = "";
         AV9ImagenProfesional = "";
         P00LX5_A40000GXC1 = new int[1] ;
         P00LX5_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.opostulados__default(),
            new Object[][] {
                new Object[] {
               P00LX2_A422PostulacionesId, P00LX2_n422PostulacionesId, P00LX2_A127SolicitudesID
               }
               , new Object[] {
               P00LX3_A422PostulacionesId, P00LX3_A120ProfesionalesId, P00LX3_A958PostulacionProfesionalFechaT, P00LX3_A959PostulacionProfesionalTurnoT, P00LX3_A956PostulacionProfesionalEstado, P00LX3_A166ProfesionalesPrimerNombre, P00LX3_A167ProfesionalesApellidoPrimero, P00LX3_A677ProfesionalesExperiencia, P00LX3_n677ProfesionalesExperiencia, P00LX3_A268ProfesionalesFeedBackCant,
               P00LX3_A269ProfesionalesFeedBackProm, P00LX3_A40006ProfesionalesPhoto_GXI, P00LX3_A169ProfesionalesPhoto
               }
               , new Object[] {
               P00LX5_A40000GXC1, P00LX5_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV16GXLvl9 ;
      private int A40000GXC1 ;
      private long AV13SolicitudesId ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string A120ProfesionalesId ;
      private string A959PostulacionProfesionalTurnoT ;
      private string A956PostulacionProfesionalEstado ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string AV8idBusqueda ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool n422PostulacionesId ;
      private bool n677ProfesionalesExperiencia ;
      private bool returnInSub ;
      private bool n40000GXC1 ;
      private string AV11RestMessage ;
      private string A677ProfesionalesExperiencia ;
      private string A40006ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private string AV9ImagenProfesional ;
      private GxHttpResponse AV14HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> AV12SDTPerfilProfesional ;
      private IDataStoreProvider pr_default ;
      private long[] P00LX2_A422PostulacionesId ;
      private bool[] P00LX2_n422PostulacionesId ;
      private long[] P00LX2_A127SolicitudesID ;
      private long[] P00LX3_A422PostulacionesId ;
      private bool[] P00LX3_n422PostulacionesId ;
      private string[] P00LX3_A120ProfesionalesId ;
      private DateTime[] P00LX3_A958PostulacionProfesionalFechaT ;
      private string[] P00LX3_A959PostulacionProfesionalTurnoT ;
      private string[] P00LX3_A956PostulacionProfesionalEstado ;
      private string[] P00LX3_A166ProfesionalesPrimerNombre ;
      private string[] P00LX3_A167ProfesionalesApellidoPrimero ;
      private string[] P00LX3_A677ProfesionalesExperiencia ;
      private bool[] P00LX3_n677ProfesionalesExperiencia ;
      private long[] P00LX3_A268ProfesionalesFeedBackCant ;
      private decimal[] P00LX3_A269ProfesionalesFeedBackProm ;
      private string[] P00LX3_A40006ProfesionalesPhoto_GXI ;
      private string[] P00LX3_A169ProfesionalesPhoto ;
      private GeneXus.Programs.apis.SdtSDTPerfilProfesional AV10Item ;
      private int[] P00LX5_A40000GXC1 ;
      private bool[] P00LX5_n40000GXC1 ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ;
      private string aP2_RestMessage ;
      private short aP3_Gx_restcode ;
   }

   public class opostulados__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LX2;
          prmP00LX2 = new Object[] {
          new ParDef("@AV13SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00LX3;
          prmP00LX3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmP00LX5;
          prmP00LX5 = new Object[] {
          new ParDef("@AV8idBusqueda",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LX2", "SELECT [PostulacionesId], [SolicitudesID] FROM [Solicitudes] WHERE [SolicitudesID] = @AV13SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LX2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00LX3", "SELECT T1.[PostulacionesId], T1.[ProfesionalesId], T1.[PostulacionProfesionalFechaT], T1.[PostulacionProfesionalTurnoT], T1.[PostulacionProfesionalEstado], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesExperiencia], T2.[ProfesionalesFeedBackCant], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesPhoto_GXI], T2.[ProfesionalesPhoto] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[PostulacionesId] = @PostulacionesId ORDER BY T1.[PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LX3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LX5", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 6) AND (T2.[ProfesionalesId] = @AV8idBusqueda) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LX5,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((string[]) buf[11])[0] = rslt.getMultimediaUri(11);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(11));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
