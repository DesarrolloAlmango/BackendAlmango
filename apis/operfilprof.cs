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
   public class operfilprof : GXProcedure
   {
      public operfilprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operfilprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out SdtSDTProfesionales aP2_SDTProfesionales ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV12User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9SDTProfesionales = new SdtSDTProfesionales(context) ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_SDTProfesionales=this.AV9SDTProfesionales;
         aP3_RestMessage=this.AV11RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               out SdtSDTProfesionales aP2_SDTProfesionales ,
                               out string aP3_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SDTProfesionales, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out SdtSDTProfesionales aP2_SDTProfesionales ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV12User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9SDTProfesionales = new SdtSDTProfesionales(context) ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_SDTProfesionales=this.AV9SDTProfesionales;
         aP3_RestMessage=this.AV11RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
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
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV12User,  AV8ProfesionalesId,  AV14TokenId, out  AV16EsValido, out  AV15TokenDesencriptado) ;
         if ( ! AV16EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV19GXLvl27 = 0;
         /* Using cursor P00K22 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00K22_A120ProfesionalesId[0];
            A167ProfesionalesApellidoPrimero = P00K22_A167ProfesionalesApellidoPrimero[0];
            A680ProfesionalesCuentaBancaria = P00K22_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = P00K22_n680ProfesionalesCuentaBancaria[0];
            A673BancoId = P00K22_A673BancoId[0];
            n673BancoId = P00K22_n673BancoId[0];
            A198ProfesionalesDireccion = P00K22_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00K22_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00K22_n193ProfesionalesEmail[0];
            A676ProfesionalesEsRUT = P00K22_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P00K22_n676ProfesionalesEsRUT[0];
            A677ProfesionalesExperiencia = P00K22_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = P00K22_n677ProfesionalesExperiencia[0];
            A166ProfesionalesPrimerNombre = P00K22_A166ProfesionalesPrimerNombre[0];
            A170ProfesionalesTelefono = P00K22_A170ProfesionalesTelefono[0];
            A902ProfesionalesTipoEmpresa = P00K22_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = P00K22_n902ProfesionalesTipoEmpresa[0];
            A900ProfesionalesFechaNacimiento = P00K22_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = P00K22_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = P00K22_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = P00K22_n901ProfesionalesRUT[0];
            AV19GXLvl27 = 1;
            AV9SDTProfesionales.gxTpr_Apellidoprimero = A167ProfesionalesApellidoPrimero;
            AV9SDTProfesionales.gxTpr_Cuentabancaria = A680ProfesionalesCuentaBancaria;
            AV9SDTProfesionales.gxTpr_Bancoid = A673BancoId;
            AV9SDTProfesionales.gxTpr_Direccion = A198ProfesionalesDireccion;
            AV9SDTProfesionales.gxTpr_Docidentidad = AV8ProfesionalesId;
            AV9SDTProfesionales.gxTpr_Email = A193ProfesionalesEmail;
            AV9SDTProfesionales.gxTpr_Esrut = A676ProfesionalesEsRUT;
            AV9SDTProfesionales.gxTpr_Experiencia = A677ProfesionalesExperiencia;
            AV9SDTProfesionales.gxTpr_Primernombre = A166ProfesionalesPrimerNombre;
            AV9SDTProfesionales.gxTpr_Telefono = A170ProfesionalesTelefono;
            AV9SDTProfesionales.gxTpr_Tipoempresa = A902ProfesionalesTipoEmpresa;
            AV9SDTProfesionales.gxTpr_Fechanacimiento = A900ProfesionalesFechaNacimiento;
            AV9SDTProfesionales.gxTpr_Rutempresa = A901ProfesionalesRUT;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV19GXLvl27 == 0 )
         {
            Gx_restcode = 404;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         Gx_restcode = 200;
         AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
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
         AV9SDTProfesionales = new SdtSDTProfesionales(context);
         AV11RestMessage = "";
         AV17HttpResponse = new GxHttpResponse( context);
         AV13HttpRequest = new GxHttpRequest( context);
         AV14TokenId = "";
         AV15TokenDesencriptado = "";
         P00K22_A120ProfesionalesId = new string[] {""} ;
         P00K22_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00K22_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         P00K22_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         P00K22_A673BancoId = new long[1] ;
         P00K22_n673BancoId = new bool[] {false} ;
         P00K22_A198ProfesionalesDireccion = new string[] {""} ;
         P00K22_A193ProfesionalesEmail = new string[] {""} ;
         P00K22_n193ProfesionalesEmail = new bool[] {false} ;
         P00K22_A676ProfesionalesEsRUT = new bool[] {false} ;
         P00K22_n676ProfesionalesEsRUT = new bool[] {false} ;
         P00K22_A677ProfesionalesExperiencia = new string[] {""} ;
         P00K22_n677ProfesionalesExperiencia = new bool[] {false} ;
         P00K22_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00K22_A170ProfesionalesTelefono = new string[] {""} ;
         P00K22_A902ProfesionalesTipoEmpresa = new short[1] ;
         P00K22_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         P00K22_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         P00K22_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         P00K22_A901ProfesionalesRUT = new string[] {""} ;
         P00K22_n901ProfesionalesRUT = new bool[] {false} ;
         A120ProfesionalesId = "";
         A167ProfesionalesApellidoPrimero = "";
         A680ProfesionalesCuentaBancaria = "";
         A198ProfesionalesDireccion = "";
         A193ProfesionalesEmail = "";
         A677ProfesionalesExperiencia = "";
         A166ProfesionalesPrimerNombre = "";
         A170ProfesionalesTelefono = "";
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         A901ProfesionalesRUT = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.operfilprof__default(),
            new Object[][] {
                new Object[] {
               P00K22_A120ProfesionalesId, P00K22_A167ProfesionalesApellidoPrimero, P00K22_A680ProfesionalesCuentaBancaria, P00K22_n680ProfesionalesCuentaBancaria, P00K22_A673BancoId, P00K22_n673BancoId, P00K22_A198ProfesionalesDireccion, P00K22_A193ProfesionalesEmail, P00K22_n193ProfesionalesEmail, P00K22_A676ProfesionalesEsRUT,
               P00K22_n676ProfesionalesEsRUT, P00K22_A677ProfesionalesExperiencia, P00K22_n677ProfesionalesExperiencia, P00K22_A166ProfesionalesPrimerNombre, P00K22_A170ProfesionalesTelefono, P00K22_A902ProfesionalesTipoEmpresa, P00K22_n902ProfesionalesTipoEmpresa, P00K22_A900ProfesionalesFechaNacimiento, P00K22_n900ProfesionalesFechaNacimiento, P00K22_A901ProfesionalesRUT,
               P00K22_n901ProfesionalesRUT
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV19GXLvl27 ;
      private short A902ProfesionalesTipoEmpresa ;
      private long A673BancoId ;
      private string AV12User ;
      private string AV8ProfesionalesId ;
      private string AV14TokenId ;
      private string AV15TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A680ProfesionalesCuentaBancaria ;
      private string A166ProfesionalesPrimerNombre ;
      private string A170ProfesionalesTelefono ;
      private string A901ProfesionalesRUT ;
      private DateTime A900ProfesionalesFechaNacimiento ;
      private bool AV16EsValido ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n673BancoId ;
      private bool n193ProfesionalesEmail ;
      private bool A676ProfesionalesEsRUT ;
      private bool n676ProfesionalesEsRUT ;
      private bool n677ProfesionalesExperiencia ;
      private bool n902ProfesionalesTipoEmpresa ;
      private bool n900ProfesionalesFechaNacimiento ;
      private bool n901ProfesionalesRUT ;
      private string AV11RestMessage ;
      private string A198ProfesionalesDireccion ;
      private string A193ProfesionalesEmail ;
      private string A677ProfesionalesExperiencia ;
      private GxHttpRequest AV13HttpRequest ;
      private GxHttpResponse AV17HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTProfesionales AV9SDTProfesionales ;
      private IDataStoreProvider pr_default ;
      private string[] P00K22_A120ProfesionalesId ;
      private string[] P00K22_A167ProfesionalesApellidoPrimero ;
      private string[] P00K22_A680ProfesionalesCuentaBancaria ;
      private bool[] P00K22_n680ProfesionalesCuentaBancaria ;
      private long[] P00K22_A673BancoId ;
      private bool[] P00K22_n673BancoId ;
      private string[] P00K22_A198ProfesionalesDireccion ;
      private string[] P00K22_A193ProfesionalesEmail ;
      private bool[] P00K22_n193ProfesionalesEmail ;
      private bool[] P00K22_A676ProfesionalesEsRUT ;
      private bool[] P00K22_n676ProfesionalesEsRUT ;
      private string[] P00K22_A677ProfesionalesExperiencia ;
      private bool[] P00K22_n677ProfesionalesExperiencia ;
      private string[] P00K22_A166ProfesionalesPrimerNombre ;
      private string[] P00K22_A170ProfesionalesTelefono ;
      private short[] P00K22_A902ProfesionalesTipoEmpresa ;
      private bool[] P00K22_n902ProfesionalesTipoEmpresa ;
      private DateTime[] P00K22_A900ProfesionalesFechaNacimiento ;
      private bool[] P00K22_n900ProfesionalesFechaNacimiento ;
      private string[] P00K22_A901ProfesionalesRUT ;
      private bool[] P00K22_n901ProfesionalesRUT ;
      private SdtSDTProfesionales aP2_SDTProfesionales ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
   }

   public class operfilprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K22;
          prmP00K22 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K22", "SELECT [ProfesionalesId], [ProfesionalesApellidoPrimero], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesDireccion], [ProfesionalesEmail], [ProfesionalesEsRUT], [ProfesionalesExperiencia], [ProfesionalesPrimerNombre], [ProfesionalesTelefono], [ProfesionalesTipoEmpresa], [ProfesionalesFechaNacimiento], [ProfesionalesRUT] FROM [Profesionales] WHERE [ProfesionalesId] = RTRIM(LTRIM(@AV8ProfesionalesId)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K22,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getString(9, 30);
                ((string[]) buf[14])[0] = rslt.getString(10, 20);
                ((short[]) buf[15])[0] = rslt.getShort(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getString(13, 20);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
