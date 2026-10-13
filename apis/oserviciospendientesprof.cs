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
   public class oserviciospendientesprof : GXProcedure
   {
      public oserviciospendientesprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oserviciospendientesprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GXBaseCollection<SdtSDTServicios_Item> aP2_SDTServicios ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV17User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV14SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV13RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_SDTServicios=this.AV14SDTServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV13RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GXBaseCollection<SdtSDTServicios_Item> aP2_SDTServicios ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SDTServicios, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV13RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GXBaseCollection<SdtSDTServicios_Item> aP2_SDTServicios ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV17User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV14SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV13RestMessage = "" ;
         SubmitImpl();
         aP2_SDTServicios=this.AV14SDTServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV13RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV10HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV10HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV10HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV17User)) )
         {
            Gx_restcode = 400;
            AV13RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV9HttpRequest, out  AV16TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TokenId)) )
         {
            Gx_restcode = 401;
            AV13RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV17User,  AV12ProfesionalesId,  AV16TokenId, out  AV8EsValido, out  AV15TokenDesencriptado) ;
         if ( ! AV8EsValido )
         {
            Gx_restcode = 401;
            AV13RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV14SDTServicios.Clear();
         /* Using cursor P00ML2 */
         pr_default.execute(0, new Object[] {AV12ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A995EstadoServProf = P00ML2_A995EstadoServProf[0];
            n995EstadoServProf = P00ML2_n995EstadoServProf[0];
            A120ProfesionalesId = P00ML2_A120ProfesionalesId[0];
            A993ProfesionalServicioId = P00ML2_A993ProfesionalServicioId[0];
            A994ProfesionalServicioNombre = P00ML2_A994ProfesionalServicioNombre[0];
            A994ProfesionalServicioNombre = P00ML2_A994ProfesionalServicioNombre[0];
            AV11Item = new SdtSDTServicios_Item(context);
            AV11Item.gxTpr_Serviciosid = A993ProfesionalServicioId;
            AV11Item.gxTpr_Serviciosnombre = A994ProfesionalServicioNombre;
            AV14SDTServicios.Add(AV11Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         Gx_restcode = 200;
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
         AV14SDTServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         AV13RestMessage = "";
         AV10HttpResponse = new GxHttpResponse( context);
         AV9HttpRequest = new GxHttpRequest( context);
         AV16TokenId = "";
         AV15TokenDesencriptado = "";
         P00ML2_A995EstadoServProf = new string[] {""} ;
         P00ML2_n995EstadoServProf = new bool[] {false} ;
         P00ML2_A120ProfesionalesId = new string[] {""} ;
         P00ML2_A993ProfesionalServicioId = new long[1] ;
         P00ML2_A994ProfesionalServicioNombre = new string[] {""} ;
         A995EstadoServProf = "";
         A120ProfesionalesId = "";
         A994ProfesionalServicioNombre = "";
         AV11Item = new SdtSDTServicios_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oserviciospendientesprof__default(),
            new Object[][] {
                new Object[] {
               P00ML2_A995EstadoServProf, P00ML2_n995EstadoServProf, P00ML2_A120ProfesionalesId, P00ML2_A993ProfesionalServicioId, P00ML2_A994ProfesionalServicioNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long A993ProfesionalServicioId ;
      private string AV17User ;
      private string AV12ProfesionalesId ;
      private string AV16TokenId ;
      private string AV15TokenDesencriptado ;
      private string A995EstadoServProf ;
      private string A120ProfesionalesId ;
      private string A994ProfesionalServicioNombre ;
      private bool AV8EsValido ;
      private bool n995EstadoServProf ;
      private string AV13RestMessage ;
      private GxHttpRequest AV9HttpRequest ;
      private GxHttpResponse AV10HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTServicios_Item> AV14SDTServicios ;
      private IDataStoreProvider pr_default ;
      private string[] P00ML2_A995EstadoServProf ;
      private bool[] P00ML2_n995EstadoServProf ;
      private string[] P00ML2_A120ProfesionalesId ;
      private long[] P00ML2_A993ProfesionalServicioId ;
      private string[] P00ML2_A994ProfesionalServicioNombre ;
      private SdtSDTServicios_Item AV11Item ;
      private GXBaseCollection<SdtSDTServicios_Item> aP2_SDTServicios ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class oserviciospendientesprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ML2;
          prmP00ML2 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ML2", "SELECT T1.[EstadoServProf], T1.[ProfesionalesId], T1.[ProfesionalServicioId] AS ProfesionalServicioId, T2.[ServiciosNombre] AS ProfesionalServicioNombre FROM ([ProfesionalesServicios] T1 INNER JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ProfesionalServicioId]) WHERE (T1.[ProfesionalesId] = @AV12ProfesionalesId) AND (T1.[EstadoServProf] = 'PEN') ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ML2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                return;
       }
    }

 }

}
