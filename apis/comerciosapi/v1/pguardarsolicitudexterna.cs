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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class pguardarsolicitudexterna : GXProcedure
   {
      public pguardarsolicitudexterna( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pguardarsolicitudexterna( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna aP0_EntradaSDT ,
                           out bool aP1_Error ,
                           out string aP2_Msj ,
                           out long aP3_TrackingId ,
                           out short aP4_Gx_restcode )
      {
         this.AV11EntradaSDT = aP0_EntradaSDT;
         this.AV13Error = false ;
         this.AV15Msj = "" ;
         this.AV31TrackingId = 0 ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Error=this.AV13Error;
         aP2_Msj=this.AV15Msj;
         aP3_TrackingId=this.AV31TrackingId;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna aP0_EntradaSDT ,
                               out bool aP1_Error ,
                               out string aP2_Msj ,
                               out long aP3_TrackingId )
      {
         execute(aP0_EntradaSDT, out aP1_Error, out aP2_Msj, out aP3_TrackingId, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna aP0_EntradaSDT ,
                                 out bool aP1_Error ,
                                 out string aP2_Msj ,
                                 out long aP3_TrackingId ,
                                 out short aP4_Gx_restcode )
      {
         this.AV11EntradaSDT = aP0_EntradaSDT;
         this.AV13Error = false ;
         this.AV15Msj = "" ;
         this.AV31TrackingId = 0 ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP1_Error=this.AV13Error;
         aP2_Msj=this.AV15Msj;
         aP3_TrackingId=this.AV31TrackingId;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8ApiKeyHeader = AV14HttpRequest.GetHeader(context.GetMessage( "x-api-key", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ApiKeyHeader)) )
         {
            Gx_restcode = 401;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Acceso Denegado.", "");
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11EntradaSDT.gxTpr_Comercioticketid)) )
         {
            Gx_restcode = 400;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Error: El campo 'ComercioTicketId' es obligatorio.", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio(context ).execute(  AV8ApiKeyHeader, out  AV24ProveedorID, out  AV22EcommerceId, out  AV26TipoIntegracion, out  AV27ComercioAutenticado) ;
         if ( ! AV27ComercioAutenticado )
         {
            Gx_restcode = 401;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Acceso Denegado.", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidaroperacionduplicada(context ).execute(  AV11EntradaSDT.gxTpr_Comercioticketid,  AV24ProveedorID,  AV22EcommerceId, out  AV21Existe, out  AV30TrackingIdEncontrado) ;
         if ( AV21Existe )
         {
            Gx_restcode = 200;
            AV13Error = false;
            AV15Msj = context.GetMessage( "Solicitud duplicada.", "");
            AV31TrackingId = AV30TrackingIdEncontrado;
            cleanup();
            if (true) return;
         }
         Gx_restcode = 201;
         AV13Error = false;
         AV15Msj = context.GetMessage( "Solicitud recibida y procesada correctamente.", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11EntradaSDT.gxTpr_Comercioticketid)) )
         {
            Gx_restcode = 400;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Error: El campo 'ComercioTicketId' es obligatorio.", "");
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11EntradaSDT.gxTpr_Cliente.gxTpr_Email)) )
         {
            Gx_restcode = 400;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Error: El 'Email' del cliente es obligatorio.", "");
            cleanup();
            if (true) return;
         }
         if ( AV11EntradaSDT.gxTpr_Servicios.Count == 0 )
         {
            Gx_restcode = 400;
            AV13Error = true;
            AV15Msj = context.GetMessage( "Error: Debe enviar al menos un ítem en la colección 'Servicios'.", "");
            cleanup();
            if (true) return;
         }
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV11EntradaSDT.gxTpr_Servicios.Count )
         {
            AV28Item = ((GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item)AV11EntradaSDT.gxTpr_Servicios.Item(AV33GXV1));
            if ( ! StringUtil.StartsWith( StringUtil.Lower( StringUtil.Trim( AV28Item.gxTpr_Codigoservicioalmango)), context.GetMessage( "amg", "")) )
            {
               Gx_restcode = 400;
               AV13Error = true;
               AV15Msj = context.GetMessage( "El código de servicio '", "") + StringUtil.Trim( AV28Item.gxTpr_Codigoservicioalmango) + context.GetMessage( "' no es válido.", "");
               cleanup();
               if (true) return;
            }
            if ( ( AV28Item.gxTpr_Montoabonado <= Convert.ToDecimal( 0 )) )
            {
               Gx_restcode = 400;
               AV13Error = true;
               AV15Msj = context.GetMessage( "El monto abonado para el servicio '", "") + StringUtil.Trim( AV28Item.gxTpr_Codigoservicioalmango) + context.GetMessage( "' debe ser mayor a 0.", "");
               cleanup();
               if (true) return;
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
         AV17RequestJsonStr = AV11EntradaSDT.ToJSonString(false, true);
         AV20DatosAuditoria = context.GetMessage( "IP: ", "") + AV14HttpRequest.RemoteAddress + context.GetMessage( " | Referer: ", "") + AV14HttpRequest.GetHeader(context.GetMessage( "Referer", ""));
         new registrarordenfenicioprocesada(context ).execute(  AV11EntradaSDT.gxTpr_Comercioticketid,  AV22EcommerceId,  AV24ProveedorID,  "CEX",  "PND",  AV17RequestJsonStr,  "",  AV20DatosAuditoria,  DateTimeUtil.ServerNow( context, pr_default),  DateTimeUtil.ServerNow( context, pr_default),  "", out  AV19ResultadoOk) ;
         if ( AV19ResultadoOk )
         {
            /* Using cursor P00MR2 */
            pr_default.execute(0, new Object[] {AV11EntradaSDT.gxTpr_Comercioticketid, AV24ProveedorID, AV22EcommerceId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A577OperacionesEstado = P00MR2_A577OperacionesEstado[0];
               n577OperacionesEstado = P00MR2_n577OperacionesEstado[0];
               A963OperacionesComercioId2 = P00MR2_A963OperacionesComercioId2[0];
               n963OperacionesComercioId2 = P00MR2_n963OperacionesComercioId2[0];
               A962OperacionesComercioId1 = P00MR2_A962OperacionesComercioId1[0];
               n962OperacionesComercioId1 = P00MR2_n962OperacionesComercioId1[0];
               A555OperacionesRef = P00MR2_A555OperacionesRef[0];
               n555OperacionesRef = P00MR2_n555OperacionesRef[0];
               A554OperacionesId = P00MR2_A554OperacionesId[0];
               AV31TrackingId = A554OperacionesId;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            Gx_restcode = 201;
            AV15Msj = context.GetMessage( "Solicitud procesada correctamente.", "");
         }
         else
         {
            AV15Msj = context.GetMessage( "Error interno", "");
            Gx_restcode = 500;
         }
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
         AV15Msj = "";
         AV8ApiKeyHeader = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV28Item = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item(context);
         AV17RequestJsonStr = "";
         AV20DatosAuditoria = "";
         P00MR2_A577OperacionesEstado = new string[] {""} ;
         P00MR2_n577OperacionesEstado = new bool[] {false} ;
         P00MR2_A963OperacionesComercioId2 = new long[1] ;
         P00MR2_n963OperacionesComercioId2 = new bool[] {false} ;
         P00MR2_A962OperacionesComercioId1 = new long[1] ;
         P00MR2_n962OperacionesComercioId1 = new bool[] {false} ;
         P00MR2_A555OperacionesRef = new string[] {""} ;
         P00MR2_n555OperacionesRef = new bool[] {false} ;
         P00MR2_A554OperacionesId = new long[1] ;
         A577OperacionesEstado = "";
         A555OperacionesRef = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pguardarsolicitudexterna__default(),
            new Object[][] {
                new Object[] {
               P00MR2_A577OperacionesEstado, P00MR2_n577OperacionesEstado, P00MR2_A963OperacionesComercioId2, P00MR2_n963OperacionesComercioId2, P00MR2_A962OperacionesComercioId1, P00MR2_n962OperacionesComercioId1, P00MR2_A555OperacionesRef, P00MR2_n555OperacionesRef, P00MR2_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV26TipoIntegracion ;
      private int AV33GXV1 ;
      private long AV31TrackingId ;
      private long AV24ProveedorID ;
      private long AV22EcommerceId ;
      private long AV30TrackingIdEncontrado ;
      private long A963OperacionesComercioId2 ;
      private long A962OperacionesComercioId1 ;
      private long A554OperacionesId ;
      private string A577OperacionesEstado ;
      private string A555OperacionesRef ;
      private bool AV13Error ;
      private bool AV27ComercioAutenticado ;
      private bool AV21Existe ;
      private bool AV19ResultadoOk ;
      private bool n577OperacionesEstado ;
      private bool n963OperacionesComercioId2 ;
      private bool n962OperacionesComercioId1 ;
      private bool n555OperacionesRef ;
      private string AV15Msj ;
      private string AV8ApiKeyHeader ;
      private string AV17RequestJsonStr ;
      private string AV20DatosAuditoria ;
      private GxHttpRequest AV14HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna AV11EntradaSDT ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item AV28Item ;
      private IDataStoreProvider pr_default ;
      private string[] P00MR2_A577OperacionesEstado ;
      private bool[] P00MR2_n577OperacionesEstado ;
      private long[] P00MR2_A963OperacionesComercioId2 ;
      private bool[] P00MR2_n963OperacionesComercioId2 ;
      private long[] P00MR2_A962OperacionesComercioId1 ;
      private bool[] P00MR2_n962OperacionesComercioId1 ;
      private string[] P00MR2_A555OperacionesRef ;
      private bool[] P00MR2_n555OperacionesRef ;
      private long[] P00MR2_A554OperacionesId ;
      private bool aP1_Error ;
      private string aP2_Msj ;
      private long aP3_TrackingId ;
      private short aP4_Gx_restcode ;
   }

   public class pguardarsolicitudexterna__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MR2;
          prmP00MR2 = new Object[] {
          new ParDef("@AV11Entr_1Comercioticketid",GXType.NVarChar,40,0) ,
          new ParDef("@AV24ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV22EcommerceId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MR2", "SELECT [OperacionesEstado], [OperacionesComercioId2], [OperacionesComercioId1], [OperacionesRef], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesRef] = RTRIM(LTRIM(@AV11Entr_1Comercioticketid))) AND ([OperacionesComercioId1] = @AV24ProveedorID) AND ([OperacionesComercioId2] = @AV22EcommerceId) AND ([OperacionesEstado] = 'PND') ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MR2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
