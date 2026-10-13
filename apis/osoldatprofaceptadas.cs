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
   public class osoldatprofaceptadas : GXProcedure
   {
      public osoldatprofaceptadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osoldatprofaceptadas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalId ,
                           short aP2_Mes ,
                           short aP3_Anio ,
                           int aP4_Estado ,
                           out string aP5_RestMessage ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes ,
                           out short aP7_Gx_restcode )
      {
         this.AV31User = aP0_User;
         this.AV20ProfesionalId = aP1_ProfesionalId;
         this.AV17Mes = aP2_Mes;
         this.AV8Anio = aP3_Anio;
         this.AV12Estado = aP4_Estado;
         this.AV22RestMessage = "" ;
         this.AV24Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>( context, "SDTSolicitudesAceptadas", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP5_RestMessage=this.AV22RestMessage;
         aP6_Solicitudes=this.AV24Solicitudes;
         aP7_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalId ,
                               short aP2_Mes ,
                               short aP3_Anio ,
                               int aP4_Estado ,
                               out string aP5_RestMessage ,
                               out GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes )
      {
         execute(aP0_User, aP1_ProfesionalId, aP2_Mes, aP3_Anio, aP4_Estado, out aP5_RestMessage, out aP6_Solicitudes, out aP7_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalId ,
                                 short aP2_Mes ,
                                 short aP3_Anio ,
                                 int aP4_Estado ,
                                 out string aP5_RestMessage ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes ,
                                 out short aP7_Gx_restcode )
      {
         this.AV31User = aP0_User;
         this.AV20ProfesionalId = aP1_ProfesionalId;
         this.AV17Mes = aP2_Mes;
         this.AV8Anio = aP3_Anio;
         this.AV12Estado = aP4_Estado;
         this.AV22RestMessage = "" ;
         this.AV24Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>( context, "SDTSolicitudesAceptadas", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP5_RestMessage=this.AV22RestMessage;
         aP6_Solicitudes=this.AV24Solicitudes;
         aP7_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ProfesionalId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV31User)) )
         {
            AV22RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV13HttpRequest, out  AV37TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TokenId)) )
         {
            AV16IsOkToken = false;
            Gx_restcode = 401;
            AV22RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV31User,  AV20ProfesionalId,  AV37TokenId, out  AV35EsValido, out  AV36TokenDesencriptado) ;
         if ( ! AV35EsValido )
         {
            AV34IsOk = false;
            Gx_restcode = 401;
            AV22RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV10Counter = 0;
         AV24Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>( context, "SDTSolicitudesAceptadas", "AlmangoX");
         AV15InicioMes = context.localUtil.YMDToD( AV8Anio, AV17Mes, 1);
         AV38FinMes = DateTimeUtil.DAdd(DateTimeUtil.AddMth( AV15InicioMes, 1),-((int)(1)));
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8Anio ,
                                              AV17Mes ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV15InicioMes ,
                                              AV38FinMes ,
                                              A130EstadosSolTipo ,
                                              A131EstadosSolId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                              }
         });
         /* Using cursor P00JG2 */
         pr_default.execute(0, new Object[] {AV15InicioMes, AV38FinMes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00JG2_A127SolicitudesID[0];
            A171SolicitudesNombre = P00JG2_A171SolicitudesNombre[0];
            A173SolicitudesDireccion = P00JG2_A173SolicitudesDireccion[0];
            A183SolicitudesHoraInstalacion = P00JG2_A183SolicitudesHoraInstalacion[0];
            A184SolicitudesFechaInstalacion = P00JG2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00JG2_A131EstadosSolId[0];
            A130EstadosSolTipo = P00JG2_A130EstadosSolTipo[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV25SolicitudId = A127SolicitudesID;
               /* Execute user subroutine: 'OBTENER NOMBRE RUBRO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               /* Using cursor P00JG3 */
               pr_default.execute(1, new Object[] {A127SolicitudesID, AV20ProfesionalId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A120ProfesionalesId = P00JG3_A120ProfesionalesId[0];
                  A140RelacionesId = P00JG3_A140RelacionesId[0];
                  AV26SolicitudItem = new GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas(context);
                  AV26SolicitudItem.gxTpr_Id = A127SolicitudesID;
                  AV26SolicitudItem.gxTpr_Cliente = A171SolicitudesNombre;
                  AV26SolicitudItem.gxTpr_Direccion = A173SolicitudesDireccion;
                  AV26SolicitudItem.gxTpr_Turno = A183SolicitudesHoraInstalacion;
                  /* Execute user subroutine: 'CARGAR DESCRIPCION TURNO' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     cleanup();
                     if (true) return;
                  }
                  AV26SolicitudItem.gxTpr_Fechainstalacion = A184SolicitudesFechaInstalacion;
                  AV24Solicitudes.Add(AV26SolicitudItem, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Gx_restcode = 200;
         AV22RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER NOMBRE RUBRO' Routine */
         returnInSub = false;
         /* Using cursor P00JG4 */
         pr_default.execute(2, new Object[] {AV25SolicitudId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A127SolicitudesID = P00JG4_A127SolicitudesID[0];
            A121RubrosId = P00JG4_A121RubrosId[0];
            A122RubrosNombre = P00JG4_A122RubrosNombre[0];
            A134SolicitudesItemsID = P00JG4_A134SolicitudesItemsID[0];
            A122RubrosNombre = P00JG4_A122RubrosNombre[0];
            AV26SolicitudItem.gxTpr_Rubroid = A121RubrosId;
            AV26SolicitudItem.gxTpr_Rubronombre = A122RubrosNombre;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'CARGAR DESCRIPCION TURNO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26SolicitudItem.gxTpr_Turno, "1") == 0 )
         {
            AV26SolicitudItem.gxTpr_Turnodsc = context.GetMessage( "Turno 1, 8:00-12:00", "");
         }
         else if ( StringUtil.StrCmp(AV26SolicitudItem.gxTpr_Turno, "2") == 0 )
         {
            AV26SolicitudItem.gxTpr_Turnodsc = context.GetMessage( "Turno 2, 12:00-16:00", "");
         }
         else if ( StringUtil.StrCmp(AV26SolicitudItem.gxTpr_Turno, "3") == 0 )
         {
            AV26SolicitudItem.gxTpr_Turnodsc = context.GetMessage( "Turno 3, 16:00-20:00", "");
         }
         else
         {
            AV29Turno = context.GetMessage( "No especificado", "");
         }
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
         AV22RestMessage = "";
         AV24Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>( context, "SDTSolicitudesAceptadas", "AlmangoX");
         AV13HttpRequest = new GxHttpRequest( context);
         AV37TokenId = "";
         AV36TokenDesencriptado = "";
         AV15InicioMes = DateTime.MinValue;
         AV38FinMes = DateTime.MinValue;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         P00JG2_A127SolicitudesID = new long[1] ;
         P00JG2_A171SolicitudesNombre = new string[] {""} ;
         P00JG2_A173SolicitudesDireccion = new string[] {""} ;
         P00JG2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00JG2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00JG2_A131EstadosSolId = new int[1] ;
         P00JG2_A130EstadosSolTipo = new string[] {""} ;
         A171SolicitudesNombre = "";
         A173SolicitudesDireccion = "";
         A183SolicitudesHoraInstalacion = "";
         P00JG3_A127SolicitudesID = new long[1] ;
         P00JG3_A120ProfesionalesId = new string[] {""} ;
         P00JG3_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         AV26SolicitudItem = new GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas(context);
         P00JG4_A127SolicitudesID = new long[1] ;
         P00JG4_A121RubrosId = new short[1] ;
         P00JG4_A122RubrosNombre = new string[] {""} ;
         P00JG4_A134SolicitudesItemsID = new short[1] ;
         A122RubrosNombre = "";
         AV29Turno = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.osoldatprofaceptadas__default(),
            new Object[][] {
                new Object[] {
               P00JG2_A127SolicitudesID, P00JG2_A171SolicitudesNombre, P00JG2_A173SolicitudesDireccion, P00JG2_A183SolicitudesHoraInstalacion, P00JG2_A184SolicitudesFechaInstalacion, P00JG2_A131EstadosSolId, P00JG2_A130EstadosSolTipo
               }
               , new Object[] {
               P00JG3_A127SolicitudesID, P00JG3_A120ProfesionalesId, P00JG3_A140RelacionesId
               }
               , new Object[] {
               P00JG4_A127SolicitudesID, P00JG4_A121RubrosId, P00JG4_A122RubrosNombre, P00JG4_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17Mes ;
      private short AV8Anio ;
      private short Gx_restcode ;
      private short AV10Counter ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private int AV12Estado ;
      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private long AV25SolicitudId ;
      private long A140RelacionesId ;
      private string AV31User ;
      private string AV20ProfesionalId ;
      private string AV37TokenId ;
      private string A130EstadosSolTipo ;
      private string A171SolicitudesNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A120ProfesionalesId ;
      private string A122RubrosNombre ;
      private string AV29Turno ;
      private DateTime AV15InicioMes ;
      private DateTime AV38FinMes ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV16IsOkToken ;
      private bool AV35EsValido ;
      private bool AV34IsOk ;
      private bool returnInSub ;
      private string AV22RestMessage ;
      private string AV36TokenDesencriptado ;
      private string A173SolicitudesDireccion ;
      private GxHttpRequest AV13HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> AV24Solicitudes ;
      private IDataStoreProvider pr_default ;
      private long[] P00JG2_A127SolicitudesID ;
      private string[] P00JG2_A171SolicitudesNombre ;
      private string[] P00JG2_A173SolicitudesDireccion ;
      private string[] P00JG2_A183SolicitudesHoraInstalacion ;
      private DateTime[] P00JG2_A184SolicitudesFechaInstalacion ;
      private int[] P00JG2_A131EstadosSolId ;
      private string[] P00JG2_A130EstadosSolTipo ;
      private long[] P00JG3_A127SolicitudesID ;
      private string[] P00JG3_A120ProfesionalesId ;
      private long[] P00JG3_A140RelacionesId ;
      private GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas AV26SolicitudItem ;
      private long[] P00JG4_A127SolicitudesID ;
      private short[] P00JG4_A121RubrosId ;
      private string[] P00JG4_A122RubrosNombre ;
      private short[] P00JG4_A134SolicitudesItemsID ;
      private string aP5_RestMessage ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes ;
      private short aP7_Gx_restcode ;
   }

   public class osoldatprofaceptadas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00JG2( IGxContext context ,
                                             short AV8Anio ,
                                             short AV17Mes ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV15InicioMes ,
                                             DateTime AV38FinMes ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesDireccion], [SolicitudesHoraInstalacion], [SolicitudesFechaInstalacion], [EstadosSolId], [EstadosSolTipo] FROM [Solicitudes]";
         AddWhere(sWhereString, "([EstadosSolId] = 5)");
         if ( ! (0==AV8Anio) && ! (0==AV17Mes) )
         {
            AddWhere(sWhereString, "([SolicitudesFechaInstalacion] >= @AV15InicioMes)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV8Anio) && ! (0==AV17Mes) )
         {
            AddWhere(sWhereString, "([SolicitudesFechaInstalacion] <= @AV38FinMes)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SolicitudesID]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00JG2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00JG3;
          prmP00JG3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV20ProfesionalId",GXType.Char,20,0)
          };
          Object[] prmP00JG4;
          prmP00JG4 = new Object[] {
          new ParDef("@AV25SolicitudId",GXType.Decimal,18,0)
          };
          Object[] prmP00JG2;
          prmP00JG2 = new Object[] {
          new ParDef("@AV15InicioMes",GXType.Date,8,0) ,
          new ParDef("@AV38FinMes",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JG2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00JG3", "SELECT [SolicitudesID], [ProfesionalesId], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @SolicitudesID) AND ([ProfesionalesId] = @AV20ProfesionalId) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00JG4", "SELECT T1.[SolicitudesID], T1.[RubrosId], T2.[RubrosNombre], T1.[SolicitudesItemsID] FROM ([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE T1.[SolicitudesID] = @AV25SolicitudId ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JG4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
