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
   public class azonaprofesional : GXProcedure
   {
      public azonaprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public azonaprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           GXBaseCollection<SdtSDTDepartamento> aP2_Departamentos ,
                           out bool aP3_IsOk ,
                           out short aP4_Gx_restcode ,
                           out string aP5_RestMessage )
      {
         this.AV24User = aP0_User;
         this.AV19ProfesionalesId = aP1_ProfesionalesId;
         this.AV9Departamentos = aP2_Departamentos;
         this.AV15IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV21RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP3_IsOk=this.AV15IsOk;
         aP4_Gx_restcode=this.Gx_restcode;
         aP5_RestMessage=this.AV21RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                GXBaseCollection<SdtSDTDepartamento> aP2_Departamentos ,
                                out bool aP3_IsOk ,
                                out short aP4_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_Departamentos, out aP3_IsOk, out aP4_Gx_restcode, out aP5_RestMessage);
         return AV21RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 GXBaseCollection<SdtSDTDepartamento> aP2_Departamentos ,
                                 out bool aP3_IsOk ,
                                 out short aP4_Gx_restcode ,
                                 out string aP5_RestMessage )
      {
         this.AV24User = aP0_User;
         this.AV19ProfesionalesId = aP1_ProfesionalesId;
         this.AV9Departamentos = aP2_Departamentos;
         this.AV15IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV21RestMessage = "" ;
         SubmitImpl();
         aP3_IsOk=this.AV15IsOk;
         aP4_Gx_restcode=this.Gx_restcode;
         aP5_RestMessage=this.AV21RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV24User)) )
         {
            Gx_restcode = 400;
            AV21RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV14HttpRequest, out  AV23TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TokenId)) )
         {
            Gx_restcode = 401;
            AV21RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV24User,  AV19ProfesionalesId,  AV23TokenId, out  AV11EsValido, out  AV22TokenDesencriptado) ;
         if ( ! AV11EsValido )
         {
            Gx_restcode = 401;
            AV21RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00KA2 */
         pr_default.execute(0, new Object[] {AV19ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00KA2_A120ProfesionalesId[0];
            A112DepartamentoId = P00KA2_A112DepartamentoId[0];
            A126ProfesionalesZonasCorrelativo = P00KA2_A126ProfesionalesZonasCorrelativo[0];
            AV10DepId = A112DepartamentoId;
            AV13Found = false;
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV9Departamentos.Count )
            {
               AV16Item = ((SdtSDTDepartamento)AV9Departamentos.Item(AV27GXV1));
               if ( AV16Item.gxTpr_Departamentoid == AV10DepId )
               {
                  AV13Found = true;
                  if (true) break;
               }
               AV27GXV1 = (int)(AV27GXV1+1);
            }
            if ( ! AV13Found )
            {
               /* Using cursor P00KA3 */
               pr_default.execute(1, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV28GXV2 = 1;
         while ( AV28GXV2 <= AV9Departamentos.Count )
         {
            AV8Dep = ((SdtSDTDepartamento)AV9Departamentos.Item(AV28GXV2));
            AV10DepId = AV8Dep.gxTpr_Departamentoid;
            AV12ExistsAll = false;
            /* Using cursor P00KA4 */
            pr_default.execute(2, new Object[] {AV19ProfesionalesId, AV10DepId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A112DepartamentoId = P00KA4_A112DepartamentoId[0];
               A120ProfesionalesId = P00KA4_A120ProfesionalesId[0];
               A114DepartamentoMunicipioId = P00KA4_A114DepartamentoMunicipioId[0];
               A126ProfesionalesZonasCorrelativo = P00KA4_A126ProfesionalesZonasCorrelativo[0];
               if ( A114DepartamentoMunicipioId == 9999 )
               {
                  AV12ExistsAll = true;
               }
               else
               {
                  /* Using cursor P00KA5 */
                  pr_default.execute(3, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( ! AV12ExistsAll )
            {
               AV18Profesionales = new SdtProfesionales(context);
               AV18Profesionales.Load(AV19ProfesionalesId);
               AV20ProfesionalZonas = new SdtProfesionales_Zonas(context);
               AV20ProfesionalZonas.gxTpr_Departamentoid = AV10DepId;
               AV20ProfesionalZonas.gxTpr_Departamentomunicipioid = 9999;
               AV20ProfesionalZonas.gxTpr_Zonasid = 9999;
               AV18Profesionales.gxTpr_Zonas.Add(AV20ProfesionalZonas, 0);
               AV18Profesionales.Update();
               if ( AV18Profesionales.Success() )
               {
                  Gx_restcode = 200;
               }
               else
               {
                  AV21RestMessage = context.GetMessage( "Error al actualizar zonas. Intente nuevamente más tarde", "");
                  Gx_restcode = 500;
                  AV15IsOk = false;
               }
            }
            AV28GXV2 = (int)(AV28GXV2+1);
         }
         if ( Gx_restcode != 500 )
         {
            AV15IsOk = true;
            AV21RestMessage = context.GetMessage( "Zonas actualizadas con éxito", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.azonaprofesional",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV21RestMessage = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV23TokenId = "";
         AV22TokenDesencriptado = "";
         P00KA2_A120ProfesionalesId = new string[] {""} ;
         P00KA2_A112DepartamentoId = new long[1] ;
         P00KA2_A126ProfesionalesZonasCorrelativo = new short[1] ;
         A120ProfesionalesId = "";
         AV16Item = new SdtSDTDepartamento(context);
         AV8Dep = new SdtSDTDepartamento(context);
         P00KA4_A112DepartamentoId = new long[1] ;
         P00KA4_A120ProfesionalesId = new string[] {""} ;
         P00KA4_A114DepartamentoMunicipioId = new long[1] ;
         P00KA4_A126ProfesionalesZonasCorrelativo = new short[1] ;
         AV18Profesionales = new SdtProfesionales(context);
         AV20ProfesionalZonas = new SdtProfesionales_Zonas(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.azonaprofesional__default(),
            new Object[][] {
                new Object[] {
               P00KA2_A120ProfesionalesId, P00KA2_A112DepartamentoId, P00KA2_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               }
               , new Object[] {
               P00KA4_A112DepartamentoId, P00KA4_A120ProfesionalesId, P00KA4_A114DepartamentoMunicipioId, P00KA4_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A126ProfesionalesZonasCorrelativo ;
      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private long A112DepartamentoId ;
      private long AV10DepId ;
      private long A114DepartamentoMunicipioId ;
      private string AV24User ;
      private string AV19ProfesionalesId ;
      private string AV23TokenId ;
      private string AV22TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private bool AV15IsOk ;
      private bool AV11EsValido ;
      private bool AV13Found ;
      private bool AV12ExistsAll ;
      private string AV21RestMessage ;
      private GxHttpRequest AV14HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTDepartamento> AV9Departamentos ;
      private IDataStoreProvider pr_default ;
      private string[] P00KA2_A120ProfesionalesId ;
      private long[] P00KA2_A112DepartamentoId ;
      private short[] P00KA2_A126ProfesionalesZonasCorrelativo ;
      private SdtSDTDepartamento AV16Item ;
      private SdtSDTDepartamento AV8Dep ;
      private long[] P00KA4_A112DepartamentoId ;
      private string[] P00KA4_A120ProfesionalesId ;
      private long[] P00KA4_A114DepartamentoMunicipioId ;
      private short[] P00KA4_A126ProfesionalesZonasCorrelativo ;
      private SdtProfesionales AV18Profesionales ;
      private SdtProfesionales_Zonas AV20ProfesionalZonas ;
      private bool aP3_IsOk ;
      private short aP4_Gx_restcode ;
      private string aP5_RestMessage ;
   }

   public class azonaprofesional__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00KA2;
          prmP00KA2 = new Object[] {
          new ParDef("@AV19ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00KA3;
          prmP00KA3 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
          };
          Object[] prmP00KA4;
          prmP00KA4 = new Object[] {
          new ParDef("@AV19ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV10DepId",GXType.Decimal,18,0)
          };
          Object[] prmP00KA5;
          prmP00KA5 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KA2", "SELECT [ProfesionalesId], [DepartamentoId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WITH (UPDLOCK) WHERE [ProfesionalesId] = @AV19ProfesionalesId ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KA2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KA3", "DELETE FROM [ProfesionalesZonas]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00KA3)
             ,new CursorDef("P00KA4", "SELECT [DepartamentoId], [ProfesionalesId], [DepartamentoMunicipioId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WITH (UPDLOCK) WHERE ([ProfesionalesId] = @AV19ProfesionalesId) AND ([DepartamentoId] = @AV10DepId) ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KA4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KA5", "DELETE FROM [ProfesionalesZonas]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00KA5)
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
