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
   public class ozonaprofesional : GXProcedure
   {
      public ozonaprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ozonaprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GxSimpleCollection<long> aP2_DepartamentosProf ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV16User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV9DepartamentosProf = new GxSimpleCollection<long>() ;
         this.Gx_restcode = 0 ;
         this.AV13RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_DepartamentosProf=this.AV9DepartamentosProf;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV13RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GxSimpleCollection<long> aP2_DepartamentosProf ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_DepartamentosProf, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV13RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GxSimpleCollection<long> aP2_DepartamentosProf ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV16User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV9DepartamentosProf = new GxSimpleCollection<long>() ;
         this.Gx_restcode = 0 ;
         this.AV13RestMessage = "" ;
         SubmitImpl();
         aP2_DepartamentosProf=this.AV9DepartamentosProf;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV13RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV17HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV17HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV17HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV16User)) )
         {
            Gx_restcode = 400;
            AV13RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV11HttpRequest, out  AV15TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TokenId)) )
         {
            Gx_restcode = 401;
            AV13RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV16User,  AV12ProfesionalesId,  AV15TokenId, out  AV10EsValido, out  AV14TokenDesencriptado) ;
         if ( ! AV10EsValido )
         {
            Gx_restcode = 401;
            AV13RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV9DepartamentosProf = (GxSimpleCollection<long>)(new GxSimpleCollection<long>());
         /* Using cursor P00K92 */
         pr_default.execute(0, new Object[] {AV12ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A114DepartamentoMunicipioId = P00K92_A114DepartamentoMunicipioId[0];
            A120ProfesionalesId = P00K92_A120ProfesionalesId[0];
            A112DepartamentoId = P00K92_A112DepartamentoId[0];
            A126ProfesionalesZonasCorrelativo = P00K92_A126ProfesionalesZonasCorrelativo[0];
            AV9DepartamentosProf.Add(A112DepartamentoId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Gx_restcode = 200;
         AV13RestMessage = context.GetMessage( "Zonas de trabajo obtenidas correctamente", "");
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
         AV9DepartamentosProf = new GxSimpleCollection<long>();
         AV13RestMessage = "";
         AV17HttpResponse = new GxHttpResponse( context);
         AV11HttpRequest = new GxHttpRequest( context);
         AV15TokenId = "";
         AV14TokenDesencriptado = "";
         P00K92_A114DepartamentoMunicipioId = new long[1] ;
         P00K92_A120ProfesionalesId = new string[] {""} ;
         P00K92_A112DepartamentoId = new long[1] ;
         P00K92_A126ProfesionalesZonasCorrelativo = new short[1] ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.ozonaprofesional__default(),
            new Object[][] {
                new Object[] {
               P00K92_A114DepartamentoMunicipioId, P00K92_A120ProfesionalesId, P00K92_A112DepartamentoId, P00K92_A126ProfesionalesZonasCorrelativo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A126ProfesionalesZonasCorrelativo ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private string AV16User ;
      private string AV12ProfesionalesId ;
      private string AV15TokenId ;
      private string AV14TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private bool AV10EsValido ;
      private string AV13RestMessage ;
      private GxHttpRequest AV11HttpRequest ;
      private GxHttpResponse AV17HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV9DepartamentosProf ;
      private IDataStoreProvider pr_default ;
      private long[] P00K92_A114DepartamentoMunicipioId ;
      private string[] P00K92_A120ProfesionalesId ;
      private long[] P00K92_A112DepartamentoId ;
      private short[] P00K92_A126ProfesionalesZonasCorrelativo ;
      private GxSimpleCollection<long> aP2_DepartamentosProf ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class ozonaprofesional__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K92;
          prmP00K92 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K92", "SELECT [DepartamentoMunicipioId], [ProfesionalesId], [DepartamentoId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE ([ProfesionalesId] = @AV12ProfesionalesId) AND ([DepartamentoMunicipioId] = 9999) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K92,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
