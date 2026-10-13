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
   public class actualizarsolicitudecommerce : GXProcedure
   {
      public actualizarsolicitudecommerce( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarsolicitudecommerce( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDTSolicitudes aP0_Solicitud ,
                           string aP1_SolicitudesEmail ,
                           out string aP2_RestMessage ,
                           out short aP3_Gx_restcode )
      {
         this.AV9Solicitud = aP0_Solicitud;
         this.AV17SolicitudesEmail = aP1_SolicitudesEmail;
         this.AV8RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_RestMessage=this.AV8RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( SdtSDTSolicitudes aP0_Solicitud ,
                               string aP1_SolicitudesEmail ,
                               out string aP2_RestMessage )
      {
         execute(aP0_Solicitud, aP1_SolicitudesEmail, out aP2_RestMessage, out aP3_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( SdtSDTSolicitudes aP0_Solicitud ,
                                 string aP1_SolicitudesEmail ,
                                 out string aP2_RestMessage ,
                                 out short aP3_Gx_restcode )
      {
         this.AV9Solicitud = aP0_Solicitud;
         this.AV17SolicitudesEmail = aP1_SolicitudesEmail;
         this.AV8RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_RestMessage=this.AV8RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gx_restcode = 200;
         AV8RestMessage = context.GetMessage( "¡Solicitud actualizada! A partir de este momento, profesionales de Almango podrán postularse.", "");
         AV13ApiKey = AV14HttpRequest.GetHeader(context.GetMessage( "X-API-KEY", ""));
         AV15ExpectedApiKey = context.GetMessage( "f7A9dC3e-92B4-4F6E-8c1A-5D8E3B1aC9F2", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ApiKey)) || ( StringUtil.StrCmp(AV13ApiKey, AV15ExpectedApiKey) != 0 ) )
         {
            Gx_restcode = 401;
            AV8RestMessage = context.GetMessage( "No está autorizado para realizar esta acción", "");
            cleanup();
            if (true) return;
         }
         if ( (0==AV9Solicitud.gxTpr_Solicitudesid) )
         {
            Gx_restcode = 400;
            AV8RestMessage = context.GetMessage( "Los parámetros enviados no son válidos. Comuníquese con Almango para más información.", "");
            cleanup();
            if (true) return;
         }
         AV16EmailCorrecto = "";
         /* Using cursor P00LZ2 */
         pr_default.execute(0, new Object[] {AV9Solicitud.gxTpr_Solicitudesid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00LZ2_A127SolicitudesID[0];
            A206SolicitudesMail = P00LZ2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00LZ2_n206SolicitudesMail[0];
            AV16EmailCorrecto = A206SolicitudesMail;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV17SolicitudesEmail)), StringUtil.Trim( StringUtil.Lower( AV16EmailCorrecto))) != 0 )
         {
            Gx_restcode = 403;
            AV8RestMessage = context.GetMessage( "El correo ingresado no coincide con el de la compra.", "");
            cleanup();
            if (true) return;
         }
         AV12ExisteMunicipio = false;
         /* Using cursor P00LZ3 */
         pr_default.execute(1, new Object[] {AV9Solicitud.gxTpr_Departamentoid, AV9Solicitud.gxTpr_Departamentomunicipioid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A114DepartamentoMunicipioId = P00LZ3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00LZ3_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P00LZ3_A112DepartamentoId[0];
            n112DepartamentoId = P00LZ3_n112DepartamentoId[0];
            AV12ExisteMunicipio = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( ! AV12ExisteMunicipio )
         {
            Gx_restcode = 400;
            AV8RestMessage = context.GetMessage( "La localidad seleccionada no es válida.", "");
            cleanup();
            if (true) return;
         }
         AV22GXLvl53 = 0;
         /* Using cursor P00LZ4 */
         pr_default.execute(2, new Object[] {AV9Solicitud.gxTpr_Solicitudesid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A600SolicitudesSubTipo = P00LZ4_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00LZ4_n600SolicitudesSubTipo[0];
            A130EstadosSolTipo = P00LZ4_A130EstadosSolTipo[0];
            A127SolicitudesID = P00LZ4_A127SolicitudesID[0];
            A131EstadosSolId = P00LZ4_A131EstadosSolId[0];
            A173SolicitudesDireccion = P00LZ4_A173SolicitudesDireccion[0];
            A112DepartamentoId = P00LZ4_A112DepartamentoId[0];
            n112DepartamentoId = P00LZ4_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P00LZ4_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00LZ4_n114DepartamentoMunicipioId[0];
            A184SolicitudesFechaInstalacion = P00LZ4_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00LZ4_A183SolicitudesHoraInstalacion[0];
            A204SolicitudesFechaActualizacion = P00LZ4_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P00LZ4_n204SolicitudesFechaActualizacion[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV22GXLvl53 = 1;
               if ( A131EstadosSolId == 1 )
               {
                  A131EstadosSolId = 8;
               }
               else
               {
                  if ( A131EstadosSolId == 8 )
                  {
                     Gx_restcode = 400;
                     AV8RestMessage = context.GetMessage( "Esta solicitud ya fue actualizada. Si necesita modificarla contáctese con Almango.", "");
                     pr_default.close(2);
                     cleanup();
                     if (true) return;
                  }
                  else
                  {
                     Gx_restcode = 400;
                     AV8RestMessage = context.GetMessage( "La solicitud no se encuentra en un estado válido para ser actualizada.", "");
                     pr_default.close(2);
                     cleanup();
                     if (true) return;
                  }
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A173SolicitudesDireccion)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Solicitud.gxTpr_Solicitudesdireccion)) )
               {
                  A173SolicitudesDireccion = AV9Solicitud.gxTpr_Solicitudesdireccion;
               }
               if ( AV9Solicitud.gxTpr_Departamentoid > 0 )
               {
                  A112DepartamentoId = AV9Solicitud.gxTpr_Departamentoid;
                  n112DepartamentoId = false;
               }
               if ( AV9Solicitud.gxTpr_Departamentomunicipioid > 0 )
               {
                  A114DepartamentoMunicipioId = AV9Solicitud.gxTpr_Departamentomunicipioid;
                  n114DepartamentoMunicipioId = false;
               }
               if ( (DateTime.MinValue==A184SolicitudesFechaInstalacion) && ! (DateTime.MinValue==AV9Solicitud.gxTpr_Solicitudesfechainstalacion) && ( DateTimeUtil.ResetTime ( AV9Solicitud.gxTpr_Solicitudesfechainstalacion ) >= DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) ) )
               {
                  A184SolicitudesFechaInstalacion = AV9Solicitud.gxTpr_Solicitudesfechainstalacion;
               }
               if ( ( NumberUtil.Val( AV9Solicitud.gxTpr_Solicitudeshorainstalacion, ".") > Convert.ToDecimal( 0 )) )
               {
                  A183SolicitudesHoraInstalacion = AV9Solicitud.gxTpr_Solicitudeshorainstalacion;
               }
               A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
               n204SolicitudesFechaActualizacion = false;
               AV11ok = true;
               /* Using cursor P00LZ5 */
               pr_default.execute(3, new Object[] {A131EstadosSolId, A173SolicitudesDireccion, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A127SolicitudesID});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV22GXLvl53 == 0 )
         {
            Gx_restcode = 400;
            AV8RestMessage = context.GetMessage( "Los parámetros enviados no son válidos. Comuníquese con Almango para más información.", "");
            AV11ok = false;
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.actualizarsolicitudecommerce",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8RestMessage = "";
         AV13ApiKey = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV15ExpectedApiKey = "";
         AV16EmailCorrecto = "";
         P00LZ2_A127SolicitudesID = new long[1] ;
         P00LZ2_A206SolicitudesMail = new string[] {""} ;
         P00LZ2_n206SolicitudesMail = new bool[] {false} ;
         A206SolicitudesMail = "";
         P00LZ3_A114DepartamentoMunicipioId = new long[1] ;
         P00LZ3_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00LZ3_A112DepartamentoId = new long[1] ;
         P00LZ3_n112DepartamentoId = new bool[] {false} ;
         P00LZ4_A600SolicitudesSubTipo = new string[] {""} ;
         P00LZ4_n600SolicitudesSubTipo = new bool[] {false} ;
         P00LZ4_A130EstadosSolTipo = new string[] {""} ;
         P00LZ4_A127SolicitudesID = new long[1] ;
         P00LZ4_A131EstadosSolId = new int[1] ;
         P00LZ4_A173SolicitudesDireccion = new string[] {""} ;
         P00LZ4_A112DepartamentoId = new long[1] ;
         P00LZ4_n112DepartamentoId = new bool[] {false} ;
         P00LZ4_A114DepartamentoMunicipioId = new long[1] ;
         P00LZ4_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00LZ4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00LZ4_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00LZ4_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00LZ4_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         A600SolicitudesSubTipo = "";
         A130EstadosSolTipo = "";
         A173SolicitudesDireccion = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.actualizarsolicitudecommerce__default(),
            new Object[][] {
                new Object[] {
               P00LZ2_A127SolicitudesID, P00LZ2_A206SolicitudesMail, P00LZ2_n206SolicitudesMail
               }
               , new Object[] {
               P00LZ3_A114DepartamentoMunicipioId, P00LZ3_A112DepartamentoId
               }
               , new Object[] {
               P00LZ4_A600SolicitudesSubTipo, P00LZ4_n600SolicitudesSubTipo, P00LZ4_A130EstadosSolTipo, P00LZ4_A127SolicitudesID, P00LZ4_A131EstadosSolId, P00LZ4_A173SolicitudesDireccion, P00LZ4_A112DepartamentoId, P00LZ4_n112DepartamentoId, P00LZ4_A114DepartamentoMunicipioId, P00LZ4_n114DepartamentoMunicipioId,
               P00LZ4_A184SolicitudesFechaInstalacion, P00LZ4_A183SolicitudesHoraInstalacion, P00LZ4_A204SolicitudesFechaActualizacion, P00LZ4_n204SolicitudesFechaActualizacion
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV22GXLvl53 ;
      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private string A600SolicitudesSubTipo ;
      private string A130EstadosSolTipo ;
      private string A183SolicitudesHoraInstalacion ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n206SolicitudesMail ;
      private bool AV12ExisteMunicipio ;
      private bool n114DepartamentoMunicipioId ;
      private bool n112DepartamentoId ;
      private bool n600SolicitudesSubTipo ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool AV11ok ;
      private string AV17SolicitudesEmail ;
      private string AV8RestMessage ;
      private string AV13ApiKey ;
      private string AV15ExpectedApiKey ;
      private string AV16EmailCorrecto ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private GxHttpRequest AV14HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTSolicitudes AV9Solicitud ;
      private IDataStoreProvider pr_default ;
      private long[] P00LZ2_A127SolicitudesID ;
      private string[] P00LZ2_A206SolicitudesMail ;
      private bool[] P00LZ2_n206SolicitudesMail ;
      private long[] P00LZ3_A114DepartamentoMunicipioId ;
      private bool[] P00LZ3_n114DepartamentoMunicipioId ;
      private long[] P00LZ3_A112DepartamentoId ;
      private bool[] P00LZ3_n112DepartamentoId ;
      private string[] P00LZ4_A600SolicitudesSubTipo ;
      private bool[] P00LZ4_n600SolicitudesSubTipo ;
      private string[] P00LZ4_A130EstadosSolTipo ;
      private long[] P00LZ4_A127SolicitudesID ;
      private int[] P00LZ4_A131EstadosSolId ;
      private string[] P00LZ4_A173SolicitudesDireccion ;
      private long[] P00LZ4_A112DepartamentoId ;
      private bool[] P00LZ4_n112DepartamentoId ;
      private long[] P00LZ4_A114DepartamentoMunicipioId ;
      private bool[] P00LZ4_n114DepartamentoMunicipioId ;
      private DateTime[] P00LZ4_A184SolicitudesFechaInstalacion ;
      private string[] P00LZ4_A183SolicitudesHoraInstalacion ;
      private DateTime[] P00LZ4_A204SolicitudesFechaActualizacion ;
      private bool[] P00LZ4_n204SolicitudesFechaActualizacion ;
      private string aP2_RestMessage ;
      private short aP3_Gx_restcode ;
   }

   public class actualizarsolicitudecommerce__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00LZ2;
          prmP00LZ2 = new Object[] {
          new ParDef("@AV9Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00LZ3;
          prmP00LZ3 = new Object[] {
          new ParDef("@AV9Solicitud__Departamentoid",GXType.Decimal,18,0) ,
          new ParDef("@AV9Solic_1Departamentomunicip",GXType.Decimal,18,0)
          };
          Object[] prmP00LZ4;
          prmP00LZ4 = new Object[] {
          new ParDef("@AV9Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00LZ5;
          prmP00LZ5 = new Object[] {
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
          new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LZ2", "SELECT [SolicitudesID], [SolicitudesMail] FROM [Solicitudes] WHERE [SolicitudesID] = @AV9Solicitud__Solicitudesid ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LZ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00LZ3", "SELECT TOP 1 [DepartamentoMunicipioId], [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @AV9Solicitud__Departamentoid and [DepartamentoMunicipioId] = @AV9Solic_1Departamentomunicip ORDER BY [DepartamentoId], [DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LZ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00LZ4", "SELECT [SolicitudesSubTipo], [EstadosSolTipo], [SolicitudesID], [EstadosSolId], [SolicitudesDireccion], [DepartamentoId], [DepartamentoMunicipioId], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesFechaActualizacion] FROM [Solicitudes] WITH (UPDLOCK) WHERE ([SolicitudesID] = @AV9Solicitud__Solicitudesid) AND ([SolicitudesSubTipo] = 'Z') ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LZ4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00LZ5", "UPDATE [Solicitudes] SET [EstadosSolId]=@EstadosSolId, [SolicitudesDireccion]=@SolicitudesDireccion, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesHoraInstalacion]=@SolicitudesHoraInstalacion, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00LZ5)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 1);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
