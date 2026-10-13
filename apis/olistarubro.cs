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
   public class olistarubro : GXProcedure
   {
      public olistarubro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public olistarubro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SdtRubros ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV11User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9SdtRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV14RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_SdtRubros=this.AV9SdtRubros;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV14RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SdtRubros ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SdtRubros, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV14RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SdtRubros ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV11User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9SdtRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV14RestMessage = "" ;
         SubmitImpl();
         aP2_SdtRubros=this.AV9SdtRubros;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV14RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV21HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11User)) )
         {
            Gx_restcode = 400;
            AV14RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV15HttpRequest, out  AV16TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TokenId)) )
         {
            Gx_restcode = 401;
            AV14RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.oprofesionalid(context ).execute(  AV11User, out  AV19ProfesionalesIdAux) ;
         AV20ProfId = StringUtil.Trim( AV19ProfesionalesIdAux);
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV11User,  AV20ProfId,  AV16TokenId, out  AV17EsValido, out  AV18TokenDesencriptado) ;
         if ( ! AV17EsValido )
         {
            Gx_restcode = 401;
            AV14RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV9SdtRubros.Clear();
         AV13RubrosProfesional = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
         {
            /* Using cursor P00JQ2 */
            pr_default.execute(0, new Object[] {AV8ProfesionalesId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A125EstadosProfRubId = P00JQ2_A125EstadosProfRubId[0];
               A124EstadosProfRubTipo = P00JQ2_A124EstadosProfRubTipo[0];
               A120ProfesionalesId = P00JQ2_A120ProfesionalesId[0];
               A121RubrosId = P00JQ2_A121RubrosId[0];
               A122RubrosNombre = P00JQ2_A122RubrosNombre[0];
               A122RubrosNombre = P00JQ2_A122RubrosNombre[0];
               if ( StringUtil.StrCmp(A124EstadosProfRubTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV12Item = new GeneXus.Programs.apis.SdtSDTRubros(context);
                  AV12Item.gxTpr_Rubrosid = A121RubrosId;
                  AV12Item.gxTpr_Rubrosnombre = A122RubrosNombre;
                  AV9SdtRubros.Add(AV12Item, 0);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV14RestMessage = context.GetMessage( "Solicitud procesada para el profesional ", "") + AV8ProfesionalesId;
            Gx_restcode = 200;
         }
         else
         {
            /* Using cursor P00JQ3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A123RubrosEstado = P00JQ3_A123RubrosEstado[0];
               n123RubrosEstado = P00JQ3_n123RubrosEstado[0];
               A121RubrosId = P00JQ3_A121RubrosId[0];
               A122RubrosNombre = P00JQ3_A122RubrosNombre[0];
               AV12Item = new GeneXus.Programs.apis.SdtSDTRubros(context);
               AV12Item.gxTpr_Rubrosid = A121RubrosId;
               AV12Item.gxTpr_Rubrosnombre = A122RubrosNombre;
               AV9SdtRubros.Add(AV12Item, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV14RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            Gx_restcode = 200;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14RestMessage)) )
         {
            AV14RestMessage = context.GetMessage( "Hubo un problema, intente nuevamente mas tarde", "");
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
         AV9SdtRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX");
         AV14RestMessage = "";
         AV21HttpResponse = new GxHttpResponse( context);
         AV15HttpRequest = new GxHttpRequest( context);
         AV16TokenId = "";
         AV19ProfesionalesIdAux = "";
         AV20ProfId = "";
         AV18TokenDesencriptado = "";
         AV13RubrosProfesional = new GxSimpleCollection<short>();
         P00JQ2_A125EstadosProfRubId = new int[1] ;
         P00JQ2_A124EstadosProfRubTipo = new string[] {""} ;
         P00JQ2_A120ProfesionalesId = new string[] {""} ;
         P00JQ2_A121RubrosId = new short[1] ;
         P00JQ2_A122RubrosNombre = new string[] {""} ;
         A124EstadosProfRubTipo = "";
         A120ProfesionalesId = "";
         A122RubrosNombre = "";
         AV12Item = new GeneXus.Programs.apis.SdtSDTRubros(context);
         P00JQ3_A123RubrosEstado = new string[] {""} ;
         P00JQ3_n123RubrosEstado = new bool[] {false} ;
         P00JQ3_A121RubrosId = new short[1] ;
         P00JQ3_A122RubrosNombre = new string[] {""} ;
         A123RubrosEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.olistarubro__default(),
            new Object[][] {
                new Object[] {
               P00JQ2_A125EstadosProfRubId, P00JQ2_A124EstadosProfRubTipo, P00JQ2_A120ProfesionalesId, P00JQ2_A121RubrosId, P00JQ2_A122RubrosNombre
               }
               , new Object[] {
               P00JQ3_A123RubrosEstado, P00JQ3_n123RubrosEstado, P00JQ3_A121RubrosId, P00JQ3_A122RubrosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A121RubrosId ;
      private int A125EstadosProfRubId ;
      private string AV11User ;
      private string AV8ProfesionalesId ;
      private string AV16TokenId ;
      private string AV19ProfesionalesIdAux ;
      private string AV20ProfId ;
      private string AV18TokenDesencriptado ;
      private string A124EstadosProfRubTipo ;
      private string A120ProfesionalesId ;
      private string A122RubrosNombre ;
      private string A123RubrosEstado ;
      private bool AV17EsValido ;
      private bool n123RubrosEstado ;
      private string AV14RestMessage ;
      private GxHttpRequest AV15HttpRequest ;
      private GxHttpResponse AV21HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> AV9SdtRubros ;
      private GxSimpleCollection<short> AV13RubrosProfesional ;
      private IDataStoreProvider pr_default ;
      private int[] P00JQ2_A125EstadosProfRubId ;
      private string[] P00JQ2_A124EstadosProfRubTipo ;
      private string[] P00JQ2_A120ProfesionalesId ;
      private short[] P00JQ2_A121RubrosId ;
      private string[] P00JQ2_A122RubrosNombre ;
      private GeneXus.Programs.apis.SdtSDTRubros AV12Item ;
      private string[] P00JQ3_A123RubrosEstado ;
      private bool[] P00JQ3_n123RubrosEstado ;
      private short[] P00JQ3_A121RubrosId ;
      private string[] P00JQ3_A122RubrosNombre ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SdtRubros ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class olistarubro__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JQ2;
          prmP00JQ2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JQ3;
          prmP00JQ3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00JQ2", "SELECT T1.[EstadosProfRubId], T1.[EstadosProfRubTipo], T1.[ProfesionalesId], T1.[RubrosId], T2.[RubrosNombre] FROM ([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE (T1.[ProfesionalesId] = @AV8ProfesionalesId) AND (T1.[EstadosProfRubId] = 1) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JQ2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00JQ3", "SELECT [RubrosEstado], [RubrosId], [RubrosNombre] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JQ3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
