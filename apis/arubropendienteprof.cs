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
   public class arubropendienteprof : GXProcedure
   {
      public arubropendienteprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arubropendienteprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           short aP2_RubroIdSolicitado ,
                           out bool aP3_IsOk ,
                           out short aP4_Gx_restcode ,
                           out string aP5_RestMessage )
      {
         this.AV13User = aP0_User;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV14RubroIdSolicitado = aP2_RubroIdSolicitado;
         this.AV8IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP3_IsOk=this.AV8IsOk;
         aP4_Gx_restcode=this.Gx_restcode;
         aP5_RestMessage=this.AV11RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                short aP2_RubroIdSolicitado ,
                                out bool aP3_IsOk ,
                                out short aP4_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_RubroIdSolicitado, out aP3_IsOk, out aP4_Gx_restcode, out aP5_RestMessage);
         return AV11RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 short aP2_RubroIdSolicitado ,
                                 out bool aP3_IsOk ,
                                 out short aP4_Gx_restcode ,
                                 out string aP5_RestMessage )
      {
         this.AV13User = aP0_User;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV14RubroIdSolicitado = aP2_RubroIdSolicitado;
         this.AV8IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         SubmitImpl();
         aP3_IsOk=this.AV8IsOk;
         aP4_Gx_restcode=this.Gx_restcode;
         aP5_RestMessage=this.AV11RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalesId)) || (0==AV14RubroIdSolicitado) )
         {
            Gx_restcode = 400;
            AV11RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV17TokenId = "";
         AV18IsOkToken = true;
         Gx_restcode = 200;
         AV11RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV15HttpRequest,  AV13User,  AV10ProfesionalesId, out  AV17TokenId, out  AV18IsOkToken, out  Gx_restcode, out  AV11RestMessage) ;
         if ( ! AV18IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalesId)) || (0==AV14RubroIdSolicitado) )
         {
            AV8IsOk = false;
            AV11RestMessage = context.GetMessage( "No se encontró el rubro solicitado", "");
            Gx_restcode = 404;
            cleanup();
            if (true) return;
         }
         AV8IsOk = true;
         AV21NuevoEstado = 1;
         AV20IsInsert = false;
         AV23GXLvl30 = 0;
         /* Using cursor P00JX2 */
         pr_default.execute(0, new Object[] {AV10ProfesionalesId, AV14RubroIdSolicitado});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A121RubrosId = P00JX2_A121RubrosId[0];
            A120ProfesionalesId = P00JX2_A120ProfesionalesId[0];
            A125EstadosProfRubId = P00JX2_A125EstadosProfRubId[0];
            AV23GXLvl30 = 1;
            if ( A125EstadosProfRubId == 2 )
            {
               AV8IsOk = false;
               AV11RestMessage = context.GetMessage( "No tiene permitido habilitar un rubro que se lo deshabilitaron", "");
               Gx_restcode = 403;
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            else
            {
               if ( A125EstadosProfRubId == 1 )
               {
                  AV11RestMessage = context.GetMessage( "No podrá visualizar trabajos de este rubro.", "");
                  AV21NuevoEstado = 3;
               }
               else
               {
                  if ( A125EstadosProfRubId == 3 )
                  {
                     AV11RestMessage = context.GetMessage( "Rubro habilitado nuevamente con éxito!", "");
                     AV21NuevoEstado = 1;
                  }
               }
            }
            A125EstadosProfRubId = AV21NuevoEstado;
            /* Using cursor P00JX3 */
            pr_default.execute(1, new Object[] {A125EstadosProfRubId, A120ProfesionalesId, A121RubrosId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV23GXLvl30 == 0 )
         {
            AV20IsInsert = true;
         }
         if ( ( AV8IsOk ) && AV20IsInsert )
         {
            /*
               INSERT RECORD ON TABLE ProfesionalesRubros

            */
            A120ProfesionalesId = AV10ProfesionalesId;
            A121RubrosId = AV14RubroIdSolicitado;
            A124EstadosProfRubTipo = context.GetMessage( "STS", "");
            A125EstadosProfRubId = AV21NuevoEstado;
            /* Using cursor P00JX4 */
            pr_default.execute(2, new Object[] {A120ProfesionalesId, A121RubrosId, A124EstadosProfRubTipo, A125EstadosProfRubId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11RestMessage)) )
            {
               AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            }
            Gx_restcode = 200;
         }
         if ( Gx_restcode != 200 )
         {
            AV11RestMessage = context.GetMessage( "Hubo un problema en el proceso de su solicitud", "");
            Gx_restcode = 500;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.arubropendienteprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11RestMessage = "";
         AV17TokenId = "";
         AV15HttpRequest = new GxHttpRequest( context);
         P00JX2_A121RubrosId = new short[1] ;
         P00JX2_A120ProfesionalesId = new string[] {""} ;
         P00JX2_A125EstadosProfRubId = new int[1] ;
         A120ProfesionalesId = "";
         A124EstadosProfRubTipo = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.arubropendienteprof__default(),
            new Object[][] {
                new Object[] {
               P00JX2_A121RubrosId, P00JX2_A120ProfesionalesId, P00JX2_A125EstadosProfRubId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14RubroIdSolicitado ;
      private short Gx_restcode ;
      private short AV21NuevoEstado ;
      private short AV23GXLvl30 ;
      private short A121RubrosId ;
      private int A125EstadosProfRubId ;
      private int GX_INS35 ;
      private string AV13User ;
      private string AV10ProfesionalesId ;
      private string AV17TokenId ;
      private string A120ProfesionalesId ;
      private string A124EstadosProfRubTipo ;
      private string Gx_emsg ;
      private bool AV8IsOk ;
      private bool AV18IsOkToken ;
      private bool AV20IsInsert ;
      private string AV11RestMessage ;
      private GxHttpRequest AV15HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00JX2_A121RubrosId ;
      private string[] P00JX2_A120ProfesionalesId ;
      private int[] P00JX2_A125EstadosProfRubId ;
      private bool aP3_IsOk ;
      private short aP4_Gx_restcode ;
      private string aP5_RestMessage ;
   }

   public class arubropendienteprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JX2;
          prmP00JX2 = new Object[] {
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14RubroIdSolicitado",GXType.Int16,4,0)
          };
          Object[] prmP00JX3;
          prmP00JX3 = new Object[] {
          new ParDef("@EstadosProfRubId",GXType.Int32,5,0) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00JX4;
          prmP00JX4 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
          new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JX2", "SELECT [RubrosId], [ProfesionalesId], [EstadosProfRubId] FROM [ProfesionalesRubros] WITH (UPDLOCK) WHERE [ProfesionalesId] = @AV10ProfesionalesId and [RubrosId] = @AV14RubroIdSolicitado ORDER BY [ProfesionalesId], [RubrosId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JX2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JX3", "UPDATE [ProfesionalesRubros] SET [EstadosProfRubId]=@EstadosProfRubId  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00JX3)
             ,new CursorDef("P00JX4", "INSERT INTO [ProfesionalesRubros]([ProfesionalesId], [RubrosId], [EstadosProfRubTipo], [EstadosProfRubId]) VALUES(@ProfesionalesId, @RubrosId, @EstadosProfRubTipo, @EstadosProfRubId)", GxErrorMask.GX_NOMASK,prmP00JX4)
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
