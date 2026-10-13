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
   public class sincronizarpostulacionessolicitudes : GXProcedure
   {
      public sincronizarpostulacionessolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sincronizarpostulacionessolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           long aP1_PostulacionesId )
      {
         this.AV9SolicitudesId = aP0_SolicitudesId;
         this.AV11PostulacionesId = aP1_PostulacionesId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 long aP1_PostulacionesId )
      {
         this.AV9SolicitudesId = aP0_SolicitudesId;
         this.AV11PostulacionesId = aP1_PostulacionesId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Postulaciones.Load(AV11PostulacionesId);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         /* Using cursor P00M12 */
         pr_default.execute(0, new Object[] {AV9SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00M12_A127SolicitudesID[0];
            A133ProveedorID = P00M12_A133ProveedorID[0];
            A212SolicitudesCotizacion = P00M12_A212SolicitudesCotizacion[0];
            A184SolicitudesFechaInstalacion = P00M12_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00M12_A183SolicitudesHoraInstalacion[0];
            A204SolicitudesFechaActualizacion = P00M12_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P00M12_n204SolicitudesFechaActualizacion[0];
            A205SolicitudesComentario = P00M12_A205SolicitudesComentario[0];
            A171SolicitudesNombre = P00M12_A171SolicitudesNombre[0];
            A206SolicitudesMail = P00M12_A206SolicitudesMail[0];
            n206SolicitudesMail = P00M12_n206SolicitudesMail[0];
            A172SolicitudesTelefono = P00M12_A172SolicitudesTelefono[0];
            A598SolicitudesUsrActualizacion = P00M12_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = P00M12_n598SolicitudesUsrActualizacion[0];
            A110ZonasID = P00M12_A110ZonasID[0];
            n110ZonasID = P00M12_n110ZonasID[0];
            if ( ! (0==AV10Postulaciones.gxTpr_Postulacionesproveedorid) )
            {
               A133ProveedorID = AV10Postulaciones.gxTpr_Postulacionesproveedorid;
            }
            else
            {
               A133ProveedorID = 1001;
            }
            A212SolicitudesCotizacion = AV10Postulaciones.gxTpr_Postulacionesprecio;
            A184SolicitudesFechaInstalacion = AV10Postulaciones.gxTpr_Postulacionesfechatrabajo;
            A183SolicitudesHoraInstalacion = AV10Postulaciones.gxTpr_Postulacionesrgohoraservicio;
            A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n204SolicitudesFechaActualizacion = false;
            A205SolicitudesComentario = AV10Postulaciones.gxTpr_Postulacionesdescripcion;
            A171SolicitudesNombre = AV10Postulaciones.gxTpr_Postulacionesapellidonombre;
            A206SolicitudesMail = AV10Postulaciones.gxTpr_Postulacionesmail;
            n206SolicitudesMail = false;
            A172SolicitudesTelefono = AV10Postulaciones.gxTpr_Postulacionestelefono;
            A598SolicitudesUsrActualizacion = AV13WWPContext.gxTpr_Userid;
            n598SolicitudesUsrActualizacion = false;
            if ( ! (0==AV10Postulaciones.gxTpr_Postulacioneszonasid) )
            {
               A110ZonasID = AV10Postulaciones.gxTpr_Postulacioneszonasid;
               n110ZonasID = false;
            }
            else
            {
               A110ZonasID = 0;
               n110ZonasID = false;
               n110ZonasID = true;
            }
            /* Using cursor P00M13 */
            pr_default.execute(1, new Object[] {A133ProveedorID, A212SolicitudesCotizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A205SolicitudesComentario, A171SolicitudesNombre, n206SolicitudesMail, A206SolicitudesMail, A172SolicitudesTelefono, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n110ZonasID, A110ZonasID, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("sincronizarpostulacionessolicitudes",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Postulaciones = new SdtPostulaciones(context);
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00M12_A127SolicitudesID = new long[1] ;
         P00M12_A133ProveedorID = new long[1] ;
         P00M12_A212SolicitudesCotizacion = new decimal[1] ;
         P00M12_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00M12_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00M12_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00M12_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00M12_A205SolicitudesComentario = new string[] {""} ;
         P00M12_A171SolicitudesNombre = new string[] {""} ;
         P00M12_A206SolicitudesMail = new string[] {""} ;
         P00M12_n206SolicitudesMail = new bool[] {false} ;
         P00M12_A172SolicitudesTelefono = new string[] {""} ;
         P00M12_A598SolicitudesUsrActualizacion = new long[1] ;
         P00M12_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P00M12_A110ZonasID = new long[1] ;
         P00M12_n110ZonasID = new bool[] {false} ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A205SolicitudesComentario = "";
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         A172SolicitudesTelefono = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sincronizarpostulacionessolicitudes__default(),
            new Object[][] {
                new Object[] {
               P00M12_A127SolicitudesID, P00M12_A133ProveedorID, P00M12_A212SolicitudesCotizacion, P00M12_A184SolicitudesFechaInstalacion, P00M12_A183SolicitudesHoraInstalacion, P00M12_A204SolicitudesFechaActualizacion, P00M12_n204SolicitudesFechaActualizacion, P00M12_A205SolicitudesComentario, P00M12_A171SolicitudesNombre, P00M12_A206SolicitudesMail,
               P00M12_n206SolicitudesMail, P00M12_A172SolicitudesTelefono, P00M12_A598SolicitudesUsrActualizacion, P00M12_n598SolicitudesUsrActualizacion, P00M12_A110ZonasID, P00M12_n110ZonasID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9SolicitudesId ;
      private long AV11PostulacionesId ;
      private long A127SolicitudesID ;
      private long A133ProveedorID ;
      private long A598SolicitudesUsrActualizacion ;
      private long A110ZonasID ;
      private decimal A212SolicitudesCotizacion ;
      private string A183SolicitudesHoraInstalacion ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n206SolicitudesMail ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n110ZonasID ;
      private string A205SolicitudesComentario ;
      private string A206SolicitudesMail ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtPostulaciones AV10Postulaciones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00M12_A127SolicitudesID ;
      private long[] P00M12_A133ProveedorID ;
      private decimal[] P00M12_A212SolicitudesCotizacion ;
      private DateTime[] P00M12_A184SolicitudesFechaInstalacion ;
      private string[] P00M12_A183SolicitudesHoraInstalacion ;
      private DateTime[] P00M12_A204SolicitudesFechaActualizacion ;
      private bool[] P00M12_n204SolicitudesFechaActualizacion ;
      private string[] P00M12_A205SolicitudesComentario ;
      private string[] P00M12_A171SolicitudesNombre ;
      private string[] P00M12_A206SolicitudesMail ;
      private bool[] P00M12_n206SolicitudesMail ;
      private string[] P00M12_A172SolicitudesTelefono ;
      private long[] P00M12_A598SolicitudesUsrActualizacion ;
      private bool[] P00M12_n598SolicitudesUsrActualizacion ;
      private long[] P00M12_A110ZonasID ;
      private bool[] P00M12_n110ZonasID ;
   }

   public class sincronizarpostulacionessolicitudes__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00M12;
          prmP00M12 = new Object[] {
          new ParDef("@AV9SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00M13;
          prmP00M13 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
          new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
          new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
          new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M12", "SELECT [SolicitudesID], [ProveedorID], [SolicitudesCotizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesFechaActualizacion], [SolicitudesComentario], [SolicitudesNombre], [SolicitudesMail], [SolicitudesTelefono], [SolicitudesUsrActualizacion], [ZonasID] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV9SolicitudesId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00M13", "UPDATE [Solicitudes] SET [ProveedorID]=@ProveedorID, [SolicitudesCotizacion]=@SolicitudesCotizacion, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesHoraInstalacion]=@SolicitudesHoraInstalacion, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion, [SolicitudesComentario]=@SolicitudesComentario, [SolicitudesNombre]=@SolicitudesNombre, [SolicitudesMail]=@SolicitudesMail, [SolicitudesTelefono]=@SolicitudesTelefono, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion, [ZonasID]=@ZonasID  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00M13)
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((long[]) buf[12])[0] = rslt.getLong(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((long[]) buf[14])[0] = rslt.getLong(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
