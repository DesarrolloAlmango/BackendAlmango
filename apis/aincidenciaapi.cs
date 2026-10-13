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
   public class aincidenciaapi : GXProcedure
   {
      public aincidenciaapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aincidenciaapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_IncidenciaCodRef ,
                           string aP1_Origen ,
                           long aP2_MotivoId ,
                           string aP3_IncidenciaUsrAlta ,
                           string aP4_IncidenciaDetalleDesc ,
                           string aP5_ProfesionalesId ,
                           out string aP6_RestMessage ,
                           out short aP7_Gx_restcode )
      {
         this.AV13IncidenciaCodRef = aP0_IncidenciaCodRef;
         this.AV21Origen = aP1_Origen;
         this.AV20MotivoId = aP2_MotivoId;
         this.AV18IncidenciaUsrAlta = aP3_IncidenciaUsrAlta;
         this.AV14IncidenciaDetalleDesc = aP4_IncidenciaDetalleDesc;
         this.AV24ProfesionalesId = aP5_ProfesionalesId;
         this.AV25RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP6_RestMessage=this.AV25RestMessage;
         aP7_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_IncidenciaCodRef ,
                               string aP1_Origen ,
                               long aP2_MotivoId ,
                               string aP3_IncidenciaUsrAlta ,
                               string aP4_IncidenciaDetalleDesc ,
                               string aP5_ProfesionalesId ,
                               out string aP6_RestMessage )
      {
         execute(aP0_IncidenciaCodRef, aP1_Origen, aP2_MotivoId, aP3_IncidenciaUsrAlta, aP4_IncidenciaDetalleDesc, aP5_ProfesionalesId, out aP6_RestMessage, out aP7_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_IncidenciaCodRef ,
                                 string aP1_Origen ,
                                 long aP2_MotivoId ,
                                 string aP3_IncidenciaUsrAlta ,
                                 string aP4_IncidenciaDetalleDesc ,
                                 string aP5_ProfesionalesId ,
                                 out string aP6_RestMessage ,
                                 out short aP7_Gx_restcode )
      {
         this.AV13IncidenciaCodRef = aP0_IncidenciaCodRef;
         this.AV21Origen = aP1_Origen;
         this.AV20MotivoId = aP2_MotivoId;
         this.AV18IncidenciaUsrAlta = aP3_IncidenciaUsrAlta;
         this.AV14IncidenciaDetalleDesc = aP4_IncidenciaDetalleDesc;
         this.AV24ProfesionalesId = aP5_ProfesionalesId;
         this.AV25RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP6_RestMessage=this.AV25RestMessage;
         aP7_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ProfesionalesId)) || (0==AV20MotivoId) || String.IsNullOrEmpty(StringUtil.RTrim( AV14IncidenciaDetalleDesc)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13IncidenciaCodRef)) )
         {
            Gx_restcode = 400;
            AV25RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV11HttpRequest = new GxHttpRequest( context);
         AV10Header = AV11HttpRequest.GetHeader(context.GetMessage( "Authorization", ""));
         AV23Prefix = context.GetMessage( "Bearer ", "");
         AV22Pos = (short)(StringUtil.StringSearch( AV10Header, AV23Prefix, 1));
         if ( AV22Pos > 0 )
         {
            AV27TokenId = StringUtil.Trim( StringUtil.Substring( AV10Header, AV22Pos+StringUtil.Len( AV23Prefix), StringUtil.Len( AV10Header)));
         }
         else
         {
            AV27TokenId = StringUtil.Trim( AV10Header);
         }
         /* Execute user subroutine: 'AUTORIZARREQUEST' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( ! (0==AV20MotivoId) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV14IncidenciaDetalleDesc)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13IncidenciaCodRef)) )
         {
            AV15IncidenciaEstado = "PND";
            AV8IncidenciaFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            AV16IncidenciaFechaActualizacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            AV17IncidenciaUsrActualizacion = "";
            new GeneXus.Programs.apis.aincidencia(context ).execute(  AV13IncidenciaCodRef,  AV21Origen,  AV15IncidenciaEstado,  AV20MotivoId,  AV8IncidenciaFechaAlta,  AV16IncidenciaFechaActualizacion,  AV18IncidenciaUsrAlta,  AV17IncidenciaUsrActualizacion,  AV14IncidenciaDetalleDesc, out  AV12IncidenciaAux, out  AV19IsOk) ;
            if ( AV19IsOk )
            {
               AV25RestMessage = context.GetMessage( "Se ingresó incidencia correctamente.", "");
               Gx_restcode = 200;
            }
            else
            {
               AV25RestMessage = context.GetMessage( "Error: No se ingreso incidencia.", "");
               Gx_restcode = 500;
            }
         }
         else
         {
            AV25RestMessage = context.GetMessage( "Error: Debe seleccionar Motivo y Agregar Detalle.", "");
            Gx_restcode = 400;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'AUTORIZARREQUEST' Routine */
         returnInSub = false;
         AV29usuariosIdInc = AV18IncidenciaUsrAlta;
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV29usuariosIdInc,  AV24ProfesionalesId,  AV27TokenId, out  AV9EsValido, out  AV26TokenDesencriptado) ;
         if ( ! AV9EsValido )
         {
            Gx_restcode = 401;
            AV25RestMessage = context.GetMessage( "No autorizado o token inválido", "");
            returnInSub = true;
            if (true) return;
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
         AV25RestMessage = "";
         AV11HttpRequest = new GxHttpRequest( context);
         AV10Header = "";
         AV23Prefix = "";
         AV27TokenId = "";
         AV15IncidenciaEstado = "";
         AV8IncidenciaFechaAlta = DateTime.MinValue;
         AV16IncidenciaFechaActualizacion = DateTime.MinValue;
         AV17IncidenciaUsrActualizacion = "";
         AV29usuariosIdInc = "";
         AV26TokenDesencriptado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.aincidenciaapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV22Pos ;
      private long AV20MotivoId ;
      private long AV12IncidenciaAux ;
      private string AV21Origen ;
      private string AV18IncidenciaUsrAlta ;
      private string AV14IncidenciaDetalleDesc ;
      private string AV24ProfesionalesId ;
      private string AV27TokenId ;
      private string AV15IncidenciaEstado ;
      private string AV17IncidenciaUsrActualizacion ;
      private string AV29usuariosIdInc ;
      private DateTime AV8IncidenciaFechaAlta ;
      private DateTime AV16IncidenciaFechaActualizacion ;
      private bool returnInSub ;
      private bool AV19IsOk ;
      private bool AV9EsValido ;
      private string AV13IncidenciaCodRef ;
      private string AV25RestMessage ;
      private string AV10Header ;
      private string AV23Prefix ;
      private string AV26TokenDesencriptado ;
      private GxHttpRequest AV11HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string aP6_RestMessage ;
      private short aP7_Gx_restcode ;
   }

   public class aincidenciaapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
