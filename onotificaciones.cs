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
   public class onotificaciones : GXProcedure
   {
      public onotificaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public onotificaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_usuariosNotificacionTipo ,
                           string aP2_usuariosNotificacionNotificado ,
                           bool aP3_Salir ,
                           out GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> aP4_Gxm2rootcol )
      {
         this.AV7usuariosId = aP0_usuariosId;
         this.AV5usuariosNotificacionTipo = aP1_usuariosNotificacionTipo;
         this.AV6usuariosNotificacionNotificado = aP2_usuariosNotificacionNotificado;
         this.AV8Salir = aP3_Salir;
         this.Gxm2rootcol = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> executeUdp( string aP0_usuariosId ,
                                                                                      string aP1_usuariosNotificacionTipo ,
                                                                                      string aP2_usuariosNotificacionNotificado ,
                                                                                      bool aP3_Salir )
      {
         execute(aP0_usuariosId, aP1_usuariosNotificacionTipo, aP2_usuariosNotificacionNotificado, aP3_Salir, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_usuariosNotificacionTipo ,
                                 string aP2_usuariosNotificacionNotificado ,
                                 bool aP3_Salir ,
                                 out GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> aP4_Gxm2rootcol )
      {
         this.AV7usuariosId = aP0_usuariosId;
         this.AV5usuariosNotificacionTipo = aP1_usuariosNotificacionTipo;
         this.AV6usuariosNotificacionNotificado = aP2_usuariosNotificacionNotificado;
         this.AV8Salir = aP3_Salir;
         this.Gxm2rootcol = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000B2 */
         pr_default.execute(0, new Object[] {AV6usuariosNotificacionNotificado, AV5usuariosNotificacionTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P000B2_A145usuariosId[0];
            A146usuariosNotificacionTipo = P000B2_A146usuariosNotificacionTipo[0];
            A234usuariosNotificacionNotificado = P000B2_A234usuariosNotificacionNotificado[0];
            A147usuariosNotificacionCodigo = P000B2_A147usuariosNotificacionCodigo[0];
            A233usuariosNotificacionDescripcio = P000B2_A233usuariosNotificacionDescripcio[0];
            A420usuariosNotificacionParametros = P000B2_A420usuariosNotificacionParametros[0];
            A421usuariosNotificacionObjeto = P000B2_A421usuariosNotificacionObjeto[0];
            A235usuariosNotificacionFecha = P000B2_A235usuariosNotificacionFecha[0];
            if ( ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Upper( A145usuariosId)), StringUtil.Trim( StringUtil.Upper( AV7usuariosId))) == 0 ) || ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Upper( A145usuariosId)), StringUtil.Trim( StringUtil.Upper( context.GetMessage( "admin", "")))) == 0 ) )
            {
               Gxm1notificacionessdt = new SdtNotificacionesSDT_NotificacionesSDTItem(context);
               Gxm2rootcol.Add(Gxm1notificacionessdt, 0);
               Gxm1notificacionessdt.gxTpr_Nusuariosid = A145usuariosId;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificaciontipo = A146usuariosNotificacionTipo;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificacioncodigo = A147usuariosNotificacionCodigo;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificacionnotificado = A234usuariosNotificacionNotificado;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificaciondescripcion = A233usuariosNotificacionDescripcio;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificacionparametros = A420usuariosNotificacionParametros;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificacionobjeto = A421usuariosNotificacionObjeto;
               Gxm1notificacionessdt.gxTpr_Nusuariosnotificacionfecha = A235usuariosNotificacionFecha;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P000B2_A145usuariosId = new string[] {""} ;
         P000B2_A146usuariosNotificacionTipo = new string[] {""} ;
         P000B2_A234usuariosNotificacionNotificado = new string[] {""} ;
         P000B2_A147usuariosNotificacionCodigo = new long[1] ;
         P000B2_A233usuariosNotificacionDescripcio = new string[] {""} ;
         P000B2_A420usuariosNotificacionParametros = new string[] {""} ;
         P000B2_A421usuariosNotificacionObjeto = new string[] {""} ;
         P000B2_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         A145usuariosId = "";
         A146usuariosNotificacionTipo = "";
         A234usuariosNotificacionNotificado = "";
         A233usuariosNotificacionDescripcio = "";
         A420usuariosNotificacionParametros = "";
         A421usuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         Gxm1notificacionessdt = new SdtNotificacionesSDT_NotificacionesSDTItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.onotificaciones__default(),
            new Object[][] {
                new Object[] {
               P000B2_A145usuariosId, P000B2_A146usuariosNotificacionTipo, P000B2_A234usuariosNotificacionNotificado, P000B2_A147usuariosNotificacionCodigo, P000B2_A233usuariosNotificacionDescripcio, P000B2_A420usuariosNotificacionParametros, P000B2_A421usuariosNotificacionObjeto, P000B2_A235usuariosNotificacionFecha
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A147usuariosNotificacionCodigo ;
      private string AV7usuariosId ;
      private string AV5usuariosNotificacionTipo ;
      private string AV6usuariosNotificacionNotificado ;
      private string A145usuariosId ;
      private string A146usuariosNotificacionTipo ;
      private string A234usuariosNotificacionNotificado ;
      private string A233usuariosNotificacionDescripcio ;
      private string A420usuariosNotificacionParametros ;
      private string A421usuariosNotificacionObjeto ;
      private DateTime A235usuariosNotificacionFecha ;
      private bool AV8Salir ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P000B2_A145usuariosId ;
      private string[] P000B2_A146usuariosNotificacionTipo ;
      private string[] P000B2_A234usuariosNotificacionNotificado ;
      private long[] P000B2_A147usuariosNotificacionCodigo ;
      private string[] P000B2_A233usuariosNotificacionDescripcio ;
      private string[] P000B2_A420usuariosNotificacionParametros ;
      private string[] P000B2_A421usuariosNotificacionObjeto ;
      private DateTime[] P000B2_A235usuariosNotificacionFecha ;
      private SdtNotificacionesSDT_NotificacionesSDTItem Gxm1notificacionessdt ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> aP4_Gxm2rootcol ;
   }

   public class onotificaciones__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000B2;
          prmP000B2 = new Object[] {
          new ParDef("@AV6usuariosNotificacionNotificado",GXType.NChar,1,0) ,
          new ParDef("@AV5usuariosNotificacionTipo",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000B2", "SELECT [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionNotificado], [usuariosNotificacionCodigo], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha] FROM [usuariosNotificacion] WHERE ([usuariosNotificacionNotificado] = @AV6usuariosNotificacionNotificado) AND ([usuariosNotificacionTipo] = @AV5usuariosNotificacionTipo) ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000B2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 250);
                ((string[]) buf[5])[0] = rslt.getString(6, 500);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                return;
       }
    }

 }

}
