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
   public class setperfilprof : GXProcedure
   {
      public setperfilprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public setperfilprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           string aP1_UsuariosId ,
                           SdtSDTProfesionales aP2_SDTProfesionales ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12UsuariosId = aP1_UsuariosId;
         this.AV9SDTProfesionales = aP2_SDTProfesionales;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_RestMessage=this.AV10RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_ProfesionalesId ,
                               string aP1_UsuariosId ,
                               SdtSDTProfesionales aP2_SDTProfesionales ,
                               out string aP3_RestMessage )
      {
         execute(aP0_ProfesionalesId, aP1_UsuariosId, aP2_SDTProfesionales, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 string aP1_UsuariosId ,
                                 SdtSDTProfesionales aP2_SDTProfesionales ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12UsuariosId = aP1_UsuariosId;
         this.AV9SDTProfesionales = aP2_SDTProfesionales;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_RestMessage=this.AV10RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV12UsuariosId)) )
         {
            AV10RestMessage = context.GetMessage( "Error de parámetros", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         AV13TokenId = "";
         AV14IsOkToken = true;
         AV10RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV15HttpRequest,  AV12UsuariosId,  AV8ProfesionalesId, out  AV13TokenId, out  AV14IsOkToken, out  Gx_restcode, out  AV10RestMessage) ;
         if ( ! AV14IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.overifunicidademail(context ).execute(  AV12UsuariosId,  AV9SDTProfesionales.gxTpr_Email, out  AV16Existe) ;
         if ( AV16Existe )
         {
            Gx_restcode = 409;
            AV10RestMessage = context.GetMessage( "Correo electrónico ya existe en sistema.", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00K32 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00K32_A120ProfesionalesId[0];
            A166ProfesionalesPrimerNombre = P00K32_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00K32_A167ProfesionalesApellidoPrimero[0];
            A193ProfesionalesEmail = P00K32_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00K32_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00K32_A170ProfesionalesTelefono[0];
            A198ProfesionalesDireccion = P00K32_A198ProfesionalesDireccion[0];
            A677ProfesionalesExperiencia = P00K32_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = P00K32_n677ProfesionalesExperiencia[0];
            A673BancoId = P00K32_A673BancoId[0];
            n673BancoId = P00K32_n673BancoId[0];
            A680ProfesionalesCuentaBancaria = P00K32_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = P00K32_n680ProfesionalesCuentaBancaria[0];
            A676ProfesionalesEsRUT = P00K32_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P00K32_n676ProfesionalesEsRUT[0];
            A900ProfesionalesFechaNacimiento = P00K32_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = P00K32_n900ProfesionalesFechaNacimiento[0];
            A902ProfesionalesTipoEmpresa = P00K32_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = P00K32_n902ProfesionalesTipoEmpresa[0];
            A901ProfesionalesRUT = P00K32_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = P00K32_n901ProfesionalesRUT[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Primernombre)) )
            {
               A166ProfesionalesPrimerNombre = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Primernombre);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Apellidoprimero)) )
            {
               A167ProfesionalesApellidoPrimero = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Apellidoprimero);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Email)) )
            {
               A193ProfesionalesEmail = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Email);
               n193ProfesionalesEmail = false;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Telefono)) )
            {
               A170ProfesionalesTelefono = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Telefono);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Apellidoprimero)) )
            {
               A167ProfesionalesApellidoPrimero = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Apellidoprimero);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Direccion)) )
            {
               A198ProfesionalesDireccion = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Direccion);
            }
            A677ProfesionalesExperiencia = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Experiencia);
            n677ProfesionalesExperiencia = false;
            if ( ! (0==AV9SDTProfesionales.gxTpr_Bancoid) && ( AV9SDTProfesionales.gxTpr_Bancoid > 0 ) )
            {
               A673BancoId = AV9SDTProfesionales.gxTpr_Bancoid;
               n673BancoId = false;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SDTProfesionales.gxTpr_Cuentabancaria)) )
            {
               A680ProfesionalesCuentaBancaria = StringUtil.Trim( AV9SDTProfesionales.gxTpr_Cuentabancaria);
               n680ProfesionalesCuentaBancaria = false;
            }
            A676ProfesionalesEsRUT = AV9SDTProfesionales.gxTpr_Esrut;
            n676ProfesionalesEsRUT = false;
            A900ProfesionalesFechaNacimiento = AV9SDTProfesionales.gxTpr_Fechanacimiento;
            n900ProfesionalesFechaNacimiento = false;
            A902ProfesionalesTipoEmpresa = AV9SDTProfesionales.gxTpr_Tipoempresa;
            n902ProfesionalesTipoEmpresa = false;
            A901ProfesionalesRUT = AV9SDTProfesionales.gxTpr_Rutempresa;
            n901ProfesionalesRUT = false;
            /* Using cursor P00K33 */
            pr_default.execute(1, new Object[] {A166ProfesionalesPrimerNombre, A167ProfesionalesApellidoPrimero, n193ProfesionalesEmail, A193ProfesionalesEmail, A170ProfesionalesTelefono, A198ProfesionalesDireccion, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n673BancoId, A673BancoId, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa, n901ProfesionalesRUT, A901ProfesionalesRUT, A120ProfesionalesId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Optimized UPDATE. */
         /* Using cursor P00K34 */
         pr_default.execute(2, new Object[] {AV9SDTProfesionales.gxTpr_Email, AV12UsuariosId});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("usuarios");
         /* End optimized UPDATE. */
         AV10RestMessage = context.GetMessage( "Perfil actualizado con éxito", "");
         Gx_restcode = 200;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.setperfilprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10RestMessage = "";
         AV13TokenId = "";
         AV15HttpRequest = new GxHttpRequest( context);
         P00K32_A120ProfesionalesId = new string[] {""} ;
         P00K32_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00K32_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00K32_A193ProfesionalesEmail = new string[] {""} ;
         P00K32_n193ProfesionalesEmail = new bool[] {false} ;
         P00K32_A170ProfesionalesTelefono = new string[] {""} ;
         P00K32_A198ProfesionalesDireccion = new string[] {""} ;
         P00K32_A677ProfesionalesExperiencia = new string[] {""} ;
         P00K32_n677ProfesionalesExperiencia = new bool[] {false} ;
         P00K32_A673BancoId = new long[1] ;
         P00K32_n673BancoId = new bool[] {false} ;
         P00K32_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         P00K32_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         P00K32_A676ProfesionalesEsRUT = new bool[] {false} ;
         P00K32_n676ProfesionalesEsRUT = new bool[] {false} ;
         P00K32_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         P00K32_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         P00K32_A902ProfesionalesTipoEmpresa = new short[1] ;
         P00K32_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         P00K32_A901ProfesionalesRUT = new string[] {""} ;
         P00K32_n901ProfesionalesRUT = new bool[] {false} ;
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A193ProfesionalesEmail = "";
         A170ProfesionalesTelefono = "";
         A198ProfesionalesDireccion = "";
         A677ProfesionalesExperiencia = "";
         A680ProfesionalesCuentaBancaria = "";
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         A901ProfesionalesRUT = "";
         A224usuariosCorreo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.setperfilprof__default(),
            new Object[][] {
                new Object[] {
               P00K32_A120ProfesionalesId, P00K32_A166ProfesionalesPrimerNombre, P00K32_A167ProfesionalesApellidoPrimero, P00K32_A193ProfesionalesEmail, P00K32_n193ProfesionalesEmail, P00K32_A170ProfesionalesTelefono, P00K32_A198ProfesionalesDireccion, P00K32_A677ProfesionalesExperiencia, P00K32_n677ProfesionalesExperiencia, P00K32_A673BancoId,
               P00K32_n673BancoId, P00K32_A680ProfesionalesCuentaBancaria, P00K32_n680ProfesionalesCuentaBancaria, P00K32_A676ProfesionalesEsRUT, P00K32_n676ProfesionalesEsRUT, P00K32_A900ProfesionalesFechaNacimiento, P00K32_n900ProfesionalesFechaNacimiento, P00K32_A902ProfesionalesTipoEmpresa, P00K32_n902ProfesionalesTipoEmpresa, P00K32_A901ProfesionalesRUT,
               P00K32_n901ProfesionalesRUT
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
      private short A902ProfesionalesTipoEmpresa ;
      private long A673BancoId ;
      private string AV8ProfesionalesId ;
      private string AV12UsuariosId ;
      private string AV13TokenId ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A170ProfesionalesTelefono ;
      private string A680ProfesionalesCuentaBancaria ;
      private string A901ProfesionalesRUT ;
      private DateTime A900ProfesionalesFechaNacimiento ;
      private bool AV14IsOkToken ;
      private bool AV16Existe ;
      private bool n193ProfesionalesEmail ;
      private bool n677ProfesionalesExperiencia ;
      private bool n673BancoId ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool A676ProfesionalesEsRUT ;
      private bool n676ProfesionalesEsRUT ;
      private bool n900ProfesionalesFechaNacimiento ;
      private bool n902ProfesionalesTipoEmpresa ;
      private bool n901ProfesionalesRUT ;
      private string AV10RestMessage ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string A677ProfesionalesExperiencia ;
      private string A224usuariosCorreo ;
      private GxHttpRequest AV15HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTProfesionales AV9SDTProfesionales ;
      private IDataStoreProvider pr_default ;
      private string[] P00K32_A120ProfesionalesId ;
      private string[] P00K32_A166ProfesionalesPrimerNombre ;
      private string[] P00K32_A167ProfesionalesApellidoPrimero ;
      private string[] P00K32_A193ProfesionalesEmail ;
      private bool[] P00K32_n193ProfesionalesEmail ;
      private string[] P00K32_A170ProfesionalesTelefono ;
      private string[] P00K32_A198ProfesionalesDireccion ;
      private string[] P00K32_A677ProfesionalesExperiencia ;
      private bool[] P00K32_n677ProfesionalesExperiencia ;
      private long[] P00K32_A673BancoId ;
      private bool[] P00K32_n673BancoId ;
      private string[] P00K32_A680ProfesionalesCuentaBancaria ;
      private bool[] P00K32_n680ProfesionalesCuentaBancaria ;
      private bool[] P00K32_A676ProfesionalesEsRUT ;
      private bool[] P00K32_n676ProfesionalesEsRUT ;
      private DateTime[] P00K32_A900ProfesionalesFechaNacimiento ;
      private bool[] P00K32_n900ProfesionalesFechaNacimiento ;
      private short[] P00K32_A902ProfesionalesTipoEmpresa ;
      private bool[] P00K32_n902ProfesionalesTipoEmpresa ;
      private string[] P00K32_A901ProfesionalesRUT ;
      private bool[] P00K32_n901ProfesionalesRUT ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
   }

   public class setperfilprof__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K32;
          prmP00K32 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00K33;
          prmP00K33 = new Object[] {
          new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
          new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
          new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
          new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
          new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
          new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00K34;
          prmP00K34 = new Object[] {
          new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
          new ParDef("@AV12UsuariosId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K32", "SELECT [ProfesionalesId], [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesDireccion], [ProfesionalesExperiencia], [BancoId], [ProfesionalesCuentaBancaria], [ProfesionalesEsRUT], [ProfesionalesFechaNacimiento], [ProfesionalesTipoEmpresa], [ProfesionalesRUT] FROM [Profesionales] WITH (UPDLOCK) WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV8ProfesionalesId)) ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00K33", "UPDATE [Profesionales] SET [ProfesionalesPrimerNombre]=@ProfesionalesPrimerNombre, [ProfesionalesApellidoPrimero]=@ProfesionalesApellidoPrimero, [ProfesionalesEmail]=@ProfesionalesEmail, [ProfesionalesTelefono]=@ProfesionalesTelefono, [ProfesionalesDireccion]=@ProfesionalesDireccion, [ProfesionalesExperiencia]=@ProfesionalesExperiencia, [BancoId]=@BancoId, [ProfesionalesCuentaBancaria]=@ProfesionalesCuentaBancaria, [ProfesionalesEsRUT]=@ProfesionalesEsRUT, [ProfesionalesFechaNacimiento]=@ProfesionalesFechaNacimiento, [ProfesionalesTipoEmpresa]=@ProfesionalesTipoEmpresa, [ProfesionalesRUT]=@ProfesionalesRUT  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00K33)
             ,new CursorDef("P00K34", "UPDATE [usuarios] SET [usuariosCorreo]=@usuariosCorreo  WHERE RTRIM(LTRIM([usuariosId])) = @AV12UsuariosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00K34)
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
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((long[]) buf[9])[0] = rslt.getLong(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 50);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((bool[]) buf[13])[0] = rslt.getBool(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((short[]) buf[17])[0] = rslt.getShort(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getString(13, 20);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
