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
namespace GeneXus.Programs.apis {
   public class verificartrabajosporestadodeuda : GXProcedure
   {
      public verificartrabajosporestadodeuda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public verificartrabajosporestadodeuda( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           long aP1_ListaDeudas ,
                           out bool aP2_ProfesionalesTieneDeuda ,
                           out bool aP3_PuedeAceptar )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12ListaDeudas = aP1_ListaDeudas;
         this.AV11ProfesionalesTieneDeuda = false ;
         this.AV9PuedeAceptar = false ;
         initialize();
         ExecutePrivate();
         aP2_ProfesionalesTieneDeuda=this.AV11ProfesionalesTieneDeuda;
         aP3_PuedeAceptar=this.AV9PuedeAceptar;
      }

      public bool executeUdp( string aP0_ProfesionalesId ,
                              long aP1_ListaDeudas ,
                              out bool aP2_ProfesionalesTieneDeuda )
      {
         execute(aP0_ProfesionalesId, aP1_ListaDeudas, out aP2_ProfesionalesTieneDeuda, out aP3_PuedeAceptar);
         return AV9PuedeAceptar ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 long aP1_ListaDeudas ,
                                 out bool aP2_ProfesionalesTieneDeuda ,
                                 out bool aP3_PuedeAceptar )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12ListaDeudas = aP1_ListaDeudas;
         this.AV11ProfesionalesTieneDeuda = false ;
         this.AV9PuedeAceptar = false ;
         SubmitImpl();
         aP2_ProfesionalesTieneDeuda=this.AV11ProfesionalesTieneDeuda;
         aP3_PuedeAceptar=this.AV9PuedeAceptar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11ProfesionalesTieneDeuda = false;
         AV9PuedeAceptar = true;
         /* Using cursor P00M02 */
         pr_default.execute(0, new Object[] {AV12ListaDeudas, AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A974RestriccionesEstado = P00M02_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M02_n974RestriccionesEstado[0];
            A590Listaid = P00M02_A590Listaid[0];
            A120ProfesionalesId = P00M02_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M02_A976ProfesionalesRestriccionId[0];
            AV11ProfesionalesTieneDeuda = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ! AV11ProfesionalesTieneDeuda )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00M03 */
         pr_default.execute(1, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A120ProfesionalesId = P00M03_A120ProfesionalesId[0];
            if ( AV11ProfesionalesTieneDeuda )
            {
               AV10ContadorProcesados = 0;
               /* Using cursor P00M04 */
               pr_default.execute(2, new Object[] {AV8ProfesionalesId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A127SolicitudesID = P00M04_A127SolicitudesID[0];
                  A120ProfesionalesId = P00M04_A120ProfesionalesId[0];
                  A142EstadoSGId = P00M04_A142EstadoSGId[0];
                  A141EstadoSGTipo = P00M04_A141EstadoSGTipo[0];
                  A438SolicitudServicioOrigenPago = P00M04_A438SolicitudServicioOrigenPago[0];
                  n438SolicitudServicioOrigenPago = P00M04_n438SolicitudServicioOrigenPago[0];
                  A219SolicitudesRelacionesFechaAlta = P00M04_A219SolicitudesRelacionesFechaAlta[0];
                  A140RelacionesId = P00M04_A140RelacionesId[0];
                  A438SolicitudServicioOrigenPago = P00M04_A438SolicitudServicioOrigenPago[0];
                  n438SolicitudServicioOrigenPago = P00M04_n438SolicitudServicioOrigenPago[0];
                  if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     AV10ContadorProcesados = (short)(AV10ContadorProcesados+1);
                     if ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "F") == 0 )
                     {
                        AV9PuedeAceptar = false;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                     if ( AV10ContadorProcesados == 3 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( AV10ContadorProcesados < 3 )
               {
                  AV9PuedeAceptar = false;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00M02_A974RestriccionesEstado = new string[] {""} ;
         P00M02_n974RestriccionesEstado = new bool[] {false} ;
         P00M02_A590Listaid = new long[1] ;
         P00M02_A120ProfesionalesId = new string[] {""} ;
         P00M02_A976ProfesionalesRestriccionId = new long[1] ;
         A974RestriccionesEstado = "";
         A120ProfesionalesId = "";
         P00M03_A120ProfesionalesId = new string[] {""} ;
         P00M04_A127SolicitudesID = new long[1] ;
         P00M04_A120ProfesionalesId = new string[] {""} ;
         P00M04_A142EstadoSGId = new int[1] ;
         P00M04_A141EstadoSGTipo = new string[] {""} ;
         P00M04_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00M04_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00M04_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M04_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.verificartrabajosporestadodeuda__default(),
            new Object[][] {
                new Object[] {
               P00M02_A974RestriccionesEstado, P00M02_n974RestriccionesEstado, P00M02_A590Listaid, P00M02_A120ProfesionalesId, P00M02_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               P00M03_A120ProfesionalesId
               }
               , new Object[] {
               P00M04_A127SolicitudesID, P00M04_A120ProfesionalesId, P00M04_A142EstadoSGId, P00M04_A141EstadoSGTipo, P00M04_A438SolicitudServicioOrigenPago, P00M04_n438SolicitudServicioOrigenPago, P00M04_A219SolicitudesRelacionesFechaAlta, P00M04_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10ContadorProcesados ;
      private int A142EstadoSGId ;
      private long AV12ListaDeudas ;
      private long A590Listaid ;
      private long A976ProfesionalesRestriccionId ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV8ProfesionalesId ;
      private string A974RestriccionesEstado ;
      private string A120ProfesionalesId ;
      private string A141EstadoSGTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private bool AV11ProfesionalesTieneDeuda ;
      private bool AV9PuedeAceptar ;
      private bool n974RestriccionesEstado ;
      private bool n438SolicitudServicioOrigenPago ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00M02_A974RestriccionesEstado ;
      private bool[] P00M02_n974RestriccionesEstado ;
      private long[] P00M02_A590Listaid ;
      private string[] P00M02_A120ProfesionalesId ;
      private long[] P00M02_A976ProfesionalesRestriccionId ;
      private string[] P00M03_A120ProfesionalesId ;
      private long[] P00M04_A127SolicitudesID ;
      private string[] P00M04_A120ProfesionalesId ;
      private int[] P00M04_A142EstadoSGId ;
      private string[] P00M04_A141EstadoSGTipo ;
      private string[] P00M04_A438SolicitudServicioOrigenPago ;
      private bool[] P00M04_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00M04_A219SolicitudesRelacionesFechaAlta ;
      private long[] P00M04_A140RelacionesId ;
      private bool aP2_ProfesionalesTieneDeuda ;
      private bool aP3_PuedeAceptar ;
   }

   public class verificartrabajosporestadodeuda__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00M02;
          prmP00M02 = new Object[] {
          new ParDef("@AV12ListaDeudas",GXType.Decimal,18,0) ,
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00M03;
          prmP00M03 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00M04;
          prmP00M04 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M02", "SELECT TOP 1 [RestriccionesEstado], [Listaid], [ProfesionalesId], [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE ([Listaid] = @AV12ListaDeudas) AND ([ProfesionalesId] = @AV8ProfesionalesId) AND ([RestriccionesEstado] = 'HAB') ORDER BY [Listaid] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M02,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00M03", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @AV8ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M03,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00M04", "SELECT T1.[SolicitudesID], T1.[ProfesionalesId], T1.[EstadoSGId], T1.[EstadoSGTipo], T2.[SolicitudServicioOrigenPago], T1.[SolicitudesRelacionesFechaAlta], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = @AV8ProfesionalesId) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesRelacionesFechaAlta] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M04,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
