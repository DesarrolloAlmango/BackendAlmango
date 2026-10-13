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
   public class aserviciopendienteprof : GXProcedure
   {
      public aserviciopendienteprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aserviciopendienteprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           long aP2_ServicioIdSolicitado ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10ServicioIdSolicitado = aP2_ServicioIdSolicitado;
         this.Gx_restcode = 0 ;
         this.AV12RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV12RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                long aP2_ServicioIdSolicitado ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_ServicioIdSolicitado, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV12RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_ServicioIdSolicitado ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10ServicioIdSolicitado = aP2_ServicioIdSolicitado;
         this.Gx_restcode = 0 ;
         this.AV12RestMessage = "" ;
         SubmitImpl();
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV12RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.apis.existeservicio(context ).execute(  AV10ServicioIdSolicitado, out  AV19Existe) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9ProfesionalesId)) || (0==AV10ServicioIdSolicitado) || ! AV19Existe )
         {
            Gx_restcode = 400;
            AV12RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV14HttpRequest, out  AV13TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TokenId)) )
         {
            Gx_restcode = 401;
            AV12RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV8User,  AV9ProfesionalesId,  AV13TokenId, out  AV18EsValido, out  AV17TokenDesencriptado) ;
         if ( ! AV18EsValido )
         {
            Gx_restcode = 401;
            AV12RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV11IsOk = true;
         AV16IsInsert = false;
         AV21GXLvl29 = 0;
         /* Using cursor P00MO2 */
         pr_default.execute(0, new Object[] {AV9ProfesionalesId, AV10ServicioIdSolicitado});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A993ProfesionalServicioId = P00MO2_A993ProfesionalServicioId[0];
            A120ProfesionalesId = P00MO2_A120ProfesionalesId[0];
            A995EstadoServProf = P00MO2_A995EstadoServProf[0];
            n995EstadoServProf = P00MO2_n995EstadoServProf[0];
            AV21GXLvl29 = 1;
            if ( StringUtil.StrCmp(A995EstadoServProf, "DES") == 0 )
            {
               AV11IsOk = false;
               AV12RestMessage = context.GetMessage( "No tiene permitido habilitar un rubro que se lo deshabilitaron", "");
               Gx_restcode = 403;
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            else
            {
               if ( StringUtil.StrCmp(A995EstadoServProf, "HAB") == 0 )
               {
                  AV12RestMessage = context.GetMessage( "No podrá visualizar trabajos de este rubro.", "");
                  AV15NuevoEstado = "PEN";
               }
               else
               {
                  if ( StringUtil.StrCmp(A995EstadoServProf, "PEN") == 0 )
                  {
                     AV12RestMessage = context.GetMessage( "Rubro habilitado nuevamente con éxito!", "");
                     AV15NuevoEstado = "HAB";
                  }
               }
            }
            A995EstadoServProf = AV15NuevoEstado;
            n995EstadoServProf = false;
            Gx_restcode = 200;
            /* Using cursor P00MO3 */
            pr_default.execute(1, new Object[] {n995EstadoServProf, A995EstadoServProf, A120ProfesionalesId, A993ProfesionalServicioId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV21GXLvl29 == 0 )
         {
            AV16IsInsert = true;
            AV15NuevoEstado = "HAB";
         }
         if ( ( AV11IsOk ) && AV16IsInsert )
         {
            /*
               INSERT RECORD ON TABLE ProfesionalesServicios

            */
            A120ProfesionalesId = AV9ProfesionalesId;
            A993ProfesionalServicioId = AV10ServicioIdSolicitado;
            A995EstadoServProf = AV15NuevoEstado;
            n995EstadoServProf = false;
            /* Using cursor P00MO4 */
            pr_default.execute(2, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId, n995EstadoServProf, A995EstadoServProf});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12RestMessage)) )
            {
               AV12RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            }
            Gx_restcode = 200;
         }
         if ( Gx_restcode != 200 )
         {
            AV12RestMessage = context.GetMessage( "Hubo un problema en el proceso de su solicitud", "");
            Gx_restcode = 500;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.aserviciopendienteprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12RestMessage = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV13TokenId = "";
         AV17TokenDesencriptado = "";
         P00MO2_A993ProfesionalServicioId = new long[1] ;
         P00MO2_A120ProfesionalesId = new string[] {""} ;
         P00MO2_A995EstadoServProf = new string[] {""} ;
         P00MO2_n995EstadoServProf = new bool[] {false} ;
         A120ProfesionalesId = "";
         A995EstadoServProf = "";
         AV15NuevoEstado = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.aserviciopendienteprof__default(),
            new Object[][] {
                new Object[] {
               P00MO2_A993ProfesionalServicioId, P00MO2_A120ProfesionalesId, P00MO2_A995EstadoServProf, P00MO2_n995EstadoServProf
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV21GXLvl29 ;
      private int GX_INS145 ;
      private long AV10ServicioIdSolicitado ;
      private long A993ProfesionalServicioId ;
      private string AV8User ;
      private string AV9ProfesionalesId ;
      private string AV13TokenId ;
      private string AV17TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private string A995EstadoServProf ;
      private string AV15NuevoEstado ;
      private string Gx_emsg ;
      private bool AV19Existe ;
      private bool AV18EsValido ;
      private bool AV11IsOk ;
      private bool AV16IsInsert ;
      private bool n995EstadoServProf ;
      private string AV12RestMessage ;
      private GxHttpRequest AV14HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MO2_A993ProfesionalServicioId ;
      private string[] P00MO2_A120ProfesionalesId ;
      private string[] P00MO2_A995EstadoServProf ;
      private bool[] P00MO2_n995EstadoServProf ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class aserviciopendienteprof__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MO2;
          prmP00MO2 = new Object[] {
          new ParDef("@AV9ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV10ServicioIdSolicitado",GXType.Decimal,18,0)
          };
          Object[] prmP00MO3;
          prmP00MO3 = new Object[] {
          new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
          };
          Object[] prmP00MO4;
          prmP00MO4 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0) ,
          new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00MO2", "SELECT [ProfesionalServicioId], [ProfesionalesId], [EstadoServProf] FROM [ProfesionalesServicios] WITH (UPDLOCK) WHERE [ProfesionalesId] = @AV9ProfesionalesId and [ProfesionalServicioId] = @AV10ServicioIdSolicitado ORDER BY [ProfesionalesId], [ProfesionalServicioId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MO2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00MO3", "UPDATE [ProfesionalesServicios] SET [EstadoServProf]=@EstadoServProf  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MO3)
             ,new CursorDef("P00MO4", "INSERT INTO [ProfesionalesServicios]([ProfesionalesId], [ProfesionalServicioId], [EstadoServProf]) VALUES(@ProfesionalesId, @ProfesionalServicioId, @EstadoServProf)", GxErrorMask.GX_NOMASK,prmP00MO4)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
