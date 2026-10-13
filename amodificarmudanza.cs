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
   public class amodificarmudanza : GXProcedure
   {
      public amodificarmudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amodificarmudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtMudanza aP0_Mudanza )
      {
         this.AV25Mudanza = aP0_Mudanza;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( SdtMudanza aP0_Mudanza )
      {
         this.AV25Mudanza = aP0_Mudanza;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Distancia = (decimal)(AV25Mudanza.gxTpr_Mudanzadistancia/ (decimal)(1000));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) )
         {
            AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) )
            {
               AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) )
               {
                  AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
               else
               {
                  AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
            }
         }
         if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "08-12") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "1";
         }
         else if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "12-16") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "2";
         }
         else if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "16-20") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "3";
         }
         /* Using cursor P00GY2 */
         pr_default.execute(0, new Object[] {AV25Mudanza.gxTpr_Mudanzaid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A735MudanzaId = P00GY2_A735MudanzaId[0];
            n735MudanzaId = P00GY2_n735MudanzaId[0];
            A212SolicitudesCotizacion = P00GY2_A212SolicitudesCotizacion[0];
            A184SolicitudesFechaInstalacion = P00GY2_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00GY2_A183SolicitudesHoraInstalacion[0];
            A597SolicitudesUsrAlta = P00GY2_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = P00GY2_n597SolicitudesUsrAlta[0];
            A598SolicitudesUsrActualizacion = P00GY2_A598SolicitudesUsrActualizacion[0];
            n598SolicitudesUsrActualizacion = P00GY2_n598SolicitudesUsrActualizacion[0];
            A204SolicitudesFechaActualizacion = P00GY2_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P00GY2_n204SolicitudesFechaActualizacion[0];
            A205SolicitudesComentario = P00GY2_A205SolicitudesComentario[0];
            A171SolicitudesNombre = P00GY2_A171SolicitudesNombre[0];
            A206SolicitudesMail = P00GY2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00GY2_n206SolicitudesMail[0];
            A172SolicitudesTelefono = P00GY2_A172SolicitudesTelefono[0];
            A173SolicitudesDireccion = P00GY2_A173SolicitudesDireccion[0];
            A127SolicitudesID = P00GY2_A127SolicitudesID[0];
            A212SolicitudesCotizacion = AV25Mudanza.gxTpr_Mudanzapreciofinal;
            if ( (DateTime.MinValue==AV25Mudanza.gxTpr_Mudanzafechaservicio) )
            {
               A184SolicitudesFechaInstalacion = AV25Mudanza.gxTpr_Mudanzafechaalta;
            }
            else
            {
               A184SolicitudesFechaInstalacion = AV25Mudanza.gxTpr_Mudanzafechaservicio;
            }
            A183SolicitudesHoraInstalacion = AV30SolicitudesHoraInstalacion;
            A597SolicitudesUsrAlta = AV25Mudanza.gxTpr_Mudanzasecuserid;
            n597SolicitudesUsrAlta = false;
            A598SolicitudesUsrActualizacion = AV25Mudanza.gxTpr_Mudanzasecuserid;
            n598SolicitudesUsrActualizacion = false;
            A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n204SolicitudesFechaActualizacion = false;
            A205SolicitudesComentario = AV25Mudanza.gxTpr_Mudanzacomentario;
            A171SolicitudesNombre = AV25Mudanza.gxTpr_Mudanzaapellidonombre;
            A206SolicitudesMail = AV25Mudanza.gxTpr_Mudanzamail;
            n206SolicitudesMail = false;
            A172SolicitudesTelefono = AV25Mudanza.gxTpr_Mudanzaphone;
            A173SolicitudesDireccion = AV26Direccion;
            /* Using cursor P00GY3 */
            pr_default.execute(1, new Object[] {A212SolicitudesCotizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A205SolicitudesComentario, A171SolicitudesNombre, n206SolicitudesMail, A206SolicitudesMail, A172SolicitudesTelefono, A173SolicitudesDireccion, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("modificarmudanza",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV26Direccion = "";
         AV30SolicitudesHoraInstalacion = "";
         P00GY2_A735MudanzaId = new long[1] ;
         P00GY2_n735MudanzaId = new bool[] {false} ;
         P00GY2_A212SolicitudesCotizacion = new decimal[1] ;
         P00GY2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00GY2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00GY2_A597SolicitudesUsrAlta = new long[1] ;
         P00GY2_n597SolicitudesUsrAlta = new bool[] {false} ;
         P00GY2_A598SolicitudesUsrActualizacion = new long[1] ;
         P00GY2_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P00GY2_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00GY2_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00GY2_A205SolicitudesComentario = new string[] {""} ;
         P00GY2_A171SolicitudesNombre = new string[] {""} ;
         P00GY2_A206SolicitudesMail = new string[] {""} ;
         P00GY2_n206SolicitudesMail = new bool[] {false} ;
         P00GY2_A172SolicitudesTelefono = new string[] {""} ;
         P00GY2_A173SolicitudesDireccion = new string[] {""} ;
         P00GY2_A127SolicitudesID = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A205SolicitudesComentario = "";
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         A172SolicitudesTelefono = "";
         A173SolicitudesDireccion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amodificarmudanza__default(),
            new Object[][] {
                new Object[] {
               P00GY2_A735MudanzaId, P00GY2_n735MudanzaId, P00GY2_A212SolicitudesCotizacion, P00GY2_A184SolicitudesFechaInstalacion, P00GY2_A183SolicitudesHoraInstalacion, P00GY2_A597SolicitudesUsrAlta, P00GY2_n597SolicitudesUsrAlta, P00GY2_A598SolicitudesUsrActualizacion, P00GY2_n598SolicitudesUsrActualizacion, P00GY2_A204SolicitudesFechaActualizacion,
               P00GY2_n204SolicitudesFechaActualizacion, P00GY2_A205SolicitudesComentario, P00GY2_A171SolicitudesNombre, P00GY2_A206SolicitudesMail, P00GY2_n206SolicitudesMail, P00GY2_A172SolicitudesTelefono, P00GY2_A173SolicitudesDireccion, P00GY2_A127SolicitudesID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A735MudanzaId ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A127SolicitudesID ;
      private decimal AV29Distancia ;
      private decimal A212SolicitudesCotizacion ;
      private string AV30SolicitudesHoraInstalacion ;
      private string A183SolicitudesHoraInstalacion ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n735MudanzaId ;
      private bool n597SolicitudesUsrAlta ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n206SolicitudesMail ;
      private string A205SolicitudesComentario ;
      private string AV26Direccion ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtMudanza AV25Mudanza ;
      private IDataStoreProvider pr_default ;
      private long[] P00GY2_A735MudanzaId ;
      private bool[] P00GY2_n735MudanzaId ;
      private decimal[] P00GY2_A212SolicitudesCotizacion ;
      private DateTime[] P00GY2_A184SolicitudesFechaInstalacion ;
      private string[] P00GY2_A183SolicitudesHoraInstalacion ;
      private long[] P00GY2_A597SolicitudesUsrAlta ;
      private bool[] P00GY2_n597SolicitudesUsrAlta ;
      private long[] P00GY2_A598SolicitudesUsrActualizacion ;
      private bool[] P00GY2_n598SolicitudesUsrActualizacion ;
      private DateTime[] P00GY2_A204SolicitudesFechaActualizacion ;
      private bool[] P00GY2_n204SolicitudesFechaActualizacion ;
      private string[] P00GY2_A205SolicitudesComentario ;
      private string[] P00GY2_A171SolicitudesNombre ;
      private string[] P00GY2_A206SolicitudesMail ;
      private bool[] P00GY2_n206SolicitudesMail ;
      private string[] P00GY2_A172SolicitudesTelefono ;
      private string[] P00GY2_A173SolicitudesDireccion ;
      private long[] P00GY2_A127SolicitudesID ;
   }

   public class amodificarmudanza__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GY2;
          prmP00GY2 = new Object[] {
          new ParDef("@AV25Mudanza__Mudanzaid",GXType.Decimal,18,0)
          };
          Object[] prmP00GY3;
          prmP00GY3 = new Object[] {
          new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
          new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
          new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
          new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
          new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
          new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
          new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GY2", "SELECT [MudanzaId], [SolicitudesCotizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaActualizacion], [SolicitudesComentario], [SolicitudesNombre], [SolicitudesMail], [SolicitudesTelefono], [SolicitudesDireccion], [SolicitudesID] FROM [Solicitudes] WITH (UPDLOCK) WHERE [MudanzaId] = @AV25Mudanza__Mudanzaid ORDER BY [MudanzaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GY2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GY3", "UPDATE [Solicitudes] SET [SolicitudesCotizacion]=@SolicitudesCotizacion, [SolicitudesFechaInstalacion]=@SolicitudesFechaInstalacion, [SolicitudesHoraInstalacion]=@SolicitudesHoraInstalacion, [SolicitudesUsrAlta]=@SolicitudesUsrAlta, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion, [SolicitudesFechaActualizacion]=@SolicitudesFechaActualizacion, [SolicitudesComentario]=@SolicitudesComentario, [SolicitudesNombre]=@SolicitudesNombre, [SolicitudesMail]=@SolicitudesMail, [SolicitudesTelefono]=@SolicitudesTelefono, [SolicitudesDireccion]=@SolicitudesDireccion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GY3)
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 100);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((string[]) buf[15])[0] = rslt.getString(11, 20);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((long[]) buf[17])[0] = rslt.getLong(13);
                return;
       }
    }

 }

}
