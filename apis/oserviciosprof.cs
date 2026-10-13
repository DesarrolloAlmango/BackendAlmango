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
   public class oserviciosprof : GXProcedure
   {
      public oserviciosprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oserviciosprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_SdtServicios=this.AV10SdtServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SdtServicios, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV11RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         SubmitImpl();
         aP2_SdtServicios=this.AV10SdtServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV12HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV12HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV12HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8User)) )
         {
            Gx_restcode = 400;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV13HttpRequest, out  AV14TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TokenId)) )
         {
            Gx_restcode = 401;
            AV11RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV8User,  AV9ProfesionalesId,  AV14TokenId, out  AV15EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV15EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV10SdtServicios.Clear();
         /* Using cursor P00MM2 */
         pr_default.execute(0, new Object[] {AV9ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A995EstadoServProf = P00MM2_A995EstadoServProf[0];
            n995EstadoServProf = P00MM2_n995EstadoServProf[0];
            A120ProfesionalesId = P00MM2_A120ProfesionalesId[0];
            A993ProfesionalServicioId = P00MM2_A993ProfesionalServicioId[0];
            A994ProfesionalServicioNombre = P00MM2_A994ProfesionalServicioNombre[0];
            A994ProfesionalServicioNombre = P00MM2_A994ProfesionalServicioNombre[0];
            AV17Item = new SdtSDTServicios_Item(context);
            AV17Item.gxTpr_Serviciosid = A993ProfesionalServicioId;
            AV17Item.gxTpr_Serviciosnombre = A994ProfesionalServicioNombre;
            AV10SdtServicios.Add(AV17Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
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
         AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         AV11RestMessage = "";
         AV12HttpResponse = new GxHttpResponse( context);
         AV13HttpRequest = new GxHttpRequest( context);
         AV14TokenId = "";
         AV16TokenDesencriptado = "";
         P00MM2_A995EstadoServProf = new string[] {""} ;
         P00MM2_n995EstadoServProf = new bool[] {false} ;
         P00MM2_A120ProfesionalesId = new string[] {""} ;
         P00MM2_A993ProfesionalServicioId = new long[1] ;
         P00MM2_A994ProfesionalServicioNombre = new string[] {""} ;
         A995EstadoServProf = "";
         A120ProfesionalesId = "";
         A994ProfesionalServicioNombre = "";
         AV17Item = new SdtSDTServicios_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oserviciosprof__default(),
            new Object[][] {
                new Object[] {
               P00MM2_A995EstadoServProf, P00MM2_n995EstadoServProf, P00MM2_A120ProfesionalesId, P00MM2_A993ProfesionalServicioId, P00MM2_A994ProfesionalServicioNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long A993ProfesionalServicioId ;
      private string AV8User ;
      private string AV9ProfesionalesId ;
      private string AV14TokenId ;
      private string AV16TokenDesencriptado ;
      private string A995EstadoServProf ;
      private string A120ProfesionalesId ;
      private string A994ProfesionalServicioNombre ;
      private bool AV15EsValido ;
      private bool n995EstadoServProf ;
      private string AV11RestMessage ;
      private GxHttpRequest AV13HttpRequest ;
      private GxHttpResponse AV12HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTServicios_Item> AV10SdtServicios ;
      private IDataStoreProvider pr_default ;
      private string[] P00MM2_A995EstadoServProf ;
      private bool[] P00MM2_n995EstadoServProf ;
      private string[] P00MM2_A120ProfesionalesId ;
      private long[] P00MM2_A993ProfesionalServicioId ;
      private string[] P00MM2_A994ProfesionalServicioNombre ;
      private SdtSDTServicios_Item AV17Item ;
      private GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class oserviciosprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MM2;
          prmP00MM2 = new Object[] {
          new ParDef("@AV9ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MM2", "SELECT T1.[EstadoServProf], T1.[ProfesionalesId], T1.[ProfesionalServicioId] AS ProfesionalServicioId, T2.[ServiciosNombre] AS ProfesionalServicioNombre FROM ([ProfesionalesServicios] T1 INNER JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ProfesionalServicioId]) WHERE (T1.[ProfesionalesId] = @AV9ProfesionalesId) AND (T1.[EstadoServProf] = 'HAB') ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MM2,100, GxCacheFrequency.OFF ,false,false )
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
