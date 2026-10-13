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
   public class orubrospendientesprof : GXProcedure
   {
      public orubrospendientesprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orubrospendientesprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV13User = aP0_User;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV12SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_SDTRubros=this.AV12SDTRubros;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SDTRubros, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV11RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV13User = aP0_User;
         this.AV10ProfesionalesId = aP1_ProfesionalesId;
         this.AV12SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         SubmitImpl();
         aP2_SDTRubros=this.AV12SDTRubros;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV18HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV18HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV18HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV13User)) )
         {
            Gx_restcode = 400;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV14HttpRequest, out  AV15TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TokenId)) )
         {
            Gx_restcode = 401;
            AV11RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV13User,  AV10ProfesionalesId,  AV15TokenId, out  AV16EsValido, out  AV17TokenDesencriptado) ;
         if ( ! AV16EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV12SDTRubros.Clear();
         /* Using cursor P00JY2 */
         pr_default.execute(0, new Object[] {AV10ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A125EstadosProfRubId = P00JY2_A125EstadosProfRubId[0];
            A124EstadosProfRubTipo = P00JY2_A124EstadosProfRubTipo[0];
            A120ProfesionalesId = P00JY2_A120ProfesionalesId[0];
            A121RubrosId = P00JY2_A121RubrosId[0];
            A122RubrosNombre = P00JY2_A122RubrosNombre[0];
            A122RubrosNombre = P00JY2_A122RubrosNombre[0];
            if ( StringUtil.StrCmp(A124EstadosProfRubTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV8Item = new GeneXus.Programs.apis.SdtSDTRubros(context);
               AV8Item.gxTpr_Rubrosid = A121RubrosId;
               AV8Item.gxTpr_Rubrosnombre = A122RubrosNombre;
               AV12SDTRubros.Add(AV8Item, 0);
            }
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
         AV12SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX");
         AV11RestMessage = "";
         AV18HttpResponse = new GxHttpResponse( context);
         AV14HttpRequest = new GxHttpRequest( context);
         AV15TokenId = "";
         AV17TokenDesencriptado = "";
         P00JY2_A125EstadosProfRubId = new int[1] ;
         P00JY2_A124EstadosProfRubTipo = new string[] {""} ;
         P00JY2_A120ProfesionalesId = new string[] {""} ;
         P00JY2_A121RubrosId = new short[1] ;
         P00JY2_A122RubrosNombre = new string[] {""} ;
         A124EstadosProfRubTipo = "";
         A120ProfesionalesId = "";
         A122RubrosNombre = "";
         AV8Item = new GeneXus.Programs.apis.SdtSDTRubros(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.orubrospendientesprof__default(),
            new Object[][] {
                new Object[] {
               P00JY2_A125EstadosProfRubId, P00JY2_A124EstadosProfRubTipo, P00JY2_A120ProfesionalesId, P00JY2_A121RubrosId, P00JY2_A122RubrosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A121RubrosId ;
      private int A125EstadosProfRubId ;
      private string AV13User ;
      private string AV10ProfesionalesId ;
      private string AV15TokenId ;
      private string AV17TokenDesencriptado ;
      private string A124EstadosProfRubTipo ;
      private string A120ProfesionalesId ;
      private string A122RubrosNombre ;
      private bool AV16EsValido ;
      private string AV11RestMessage ;
      private GxHttpRequest AV14HttpRequest ;
      private GxHttpResponse AV18HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> AV12SDTRubros ;
      private IDataStoreProvider pr_default ;
      private int[] P00JY2_A125EstadosProfRubId ;
      private string[] P00JY2_A124EstadosProfRubTipo ;
      private string[] P00JY2_A120ProfesionalesId ;
      private short[] P00JY2_A121RubrosId ;
      private string[] P00JY2_A122RubrosNombre ;
      private GeneXus.Programs.apis.SdtSDTRubros AV8Item ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class orubrospendientesprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JY2;
          prmP00JY2 = new Object[] {
          new ParDef("@AV10ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JY2", "SELECT T1.[EstadosProfRubId], T1.[EstadosProfRubTipo], T1.[ProfesionalesId], T1.[RubrosId], T2.[RubrosNombre] FROM ([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE (T1.[ProfesionalesId] = @AV10ProfesionalesId) AND (T1.[EstadosProfRubId] = 3) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JY2,100, GxCacheFrequency.OFF ,false,false )
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
       }
    }

 }

}
