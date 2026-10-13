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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class loginverificarprofesional : GXProcedure
   {
      public loginverificarprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loginverificarprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuarios ,
                           string aP1_Contrasenia ,
                           out string aP2_ErrorDes ,
                           out string aP3_ok ,
                           out string aP4_usuariosNombre ,
                           out string aP5_paisid ,
                           out string aP6_tipoUsuario ,
                           out string aP7_ProfesionalesId ,
                           out string aP8_usuariosCorreo ,
                           out string aP9_usuariosDireccion ,
                           out int aP10_UsuariosCPostal ,
                           out string aP11_UsuariosTelefono ,
                           out string aP12_usuariosImagen ,
                           out string aP13_UsuarioURL ,
                           out string aP14_usuariosEstado )
      {
         this.AV9usuarios = aP0_usuarios;
         this.AV11Contrasenia = aP1_Contrasenia;
         this.AV26ErrorDes = "" ;
         this.AV14ok = "" ;
         this.AV15usuariosNombre = "" ;
         this.AV16paisid = "" ;
         this.AV17tipoUsuario = "" ;
         this.AV22ProfesionalesId = "" ;
         this.AV18usuariosCorreo = "" ;
         this.AV19usuariosDireccion = "" ;
         this.AV20UsuariosCPostal = 0 ;
         this.AV21UsuariosTelefono = "" ;
         this.AV23usuariosImagen = "" ;
         this.AV24UsuarioURL = "" ;
         this.AV12usuariosEstado = "" ;
         initialize();
         ExecutePrivate();
         aP2_ErrorDes=this.AV26ErrorDes;
         aP3_ok=this.AV14ok;
         aP4_usuariosNombre=this.AV15usuariosNombre;
         aP5_paisid=this.AV16paisid;
         aP6_tipoUsuario=this.AV17tipoUsuario;
         aP7_ProfesionalesId=this.AV22ProfesionalesId;
         aP8_usuariosCorreo=this.AV18usuariosCorreo;
         aP9_usuariosDireccion=this.AV19usuariosDireccion;
         aP10_UsuariosCPostal=this.AV20UsuariosCPostal;
         aP11_UsuariosTelefono=this.AV21UsuariosTelefono;
         aP12_usuariosImagen=this.AV23usuariosImagen;
         aP13_UsuarioURL=this.AV24UsuarioURL;
         aP14_usuariosEstado=this.AV12usuariosEstado;
      }

      public string executeUdp( string aP0_usuarios ,
                                string aP1_Contrasenia ,
                                out string aP2_ErrorDes ,
                                out string aP3_ok ,
                                out string aP4_usuariosNombre ,
                                out string aP5_paisid ,
                                out string aP6_tipoUsuario ,
                                out string aP7_ProfesionalesId ,
                                out string aP8_usuariosCorreo ,
                                out string aP9_usuariosDireccion ,
                                out int aP10_UsuariosCPostal ,
                                out string aP11_UsuariosTelefono ,
                                out string aP12_usuariosImagen ,
                                out string aP13_UsuarioURL )
      {
         execute(aP0_usuarios, aP1_Contrasenia, out aP2_ErrorDes, out aP3_ok, out aP4_usuariosNombre, out aP5_paisid, out aP6_tipoUsuario, out aP7_ProfesionalesId, out aP8_usuariosCorreo, out aP9_usuariosDireccion, out aP10_UsuariosCPostal, out aP11_UsuariosTelefono, out aP12_usuariosImagen, out aP13_UsuarioURL, out aP14_usuariosEstado);
         return AV12usuariosEstado ;
      }

      public void executeSubmit( string aP0_usuarios ,
                                 string aP1_Contrasenia ,
                                 out string aP2_ErrorDes ,
                                 out string aP3_ok ,
                                 out string aP4_usuariosNombre ,
                                 out string aP5_paisid ,
                                 out string aP6_tipoUsuario ,
                                 out string aP7_ProfesionalesId ,
                                 out string aP8_usuariosCorreo ,
                                 out string aP9_usuariosDireccion ,
                                 out int aP10_UsuariosCPostal ,
                                 out string aP11_UsuariosTelefono ,
                                 out string aP12_usuariosImagen ,
                                 out string aP13_UsuarioURL ,
                                 out string aP14_usuariosEstado )
      {
         this.AV9usuarios = aP0_usuarios;
         this.AV11Contrasenia = aP1_Contrasenia;
         this.AV26ErrorDes = "" ;
         this.AV14ok = "" ;
         this.AV15usuariosNombre = "" ;
         this.AV16paisid = "" ;
         this.AV17tipoUsuario = "" ;
         this.AV22ProfesionalesId = "" ;
         this.AV18usuariosCorreo = "" ;
         this.AV19usuariosDireccion = "" ;
         this.AV20UsuariosCPostal = 0 ;
         this.AV21UsuariosTelefono = "" ;
         this.AV23usuariosImagen = "" ;
         this.AV24UsuarioURL = "" ;
         this.AV12usuariosEstado = "" ;
         SubmitImpl();
         aP2_ErrorDes=this.AV26ErrorDes;
         aP3_ok=this.AV14ok;
         aP4_usuariosNombre=this.AV15usuariosNombre;
         aP5_paisid=this.AV16paisid;
         aP6_tipoUsuario=this.AV17tipoUsuario;
         aP7_ProfesionalesId=this.AV22ProfesionalesId;
         aP8_usuariosCorreo=this.AV18usuariosCorreo;
         aP9_usuariosDireccion=this.AV19usuariosDireccion;
         aP10_UsuariosCPostal=this.AV20UsuariosCPostal;
         aP11_UsuariosTelefono=this.AV21UsuariosTelefono;
         aP12_usuariosImagen=this.AV23usuariosImagen;
         aP13_UsuarioURL=this.AV24UsuarioURL;
         aP14_usuariosEstado=this.AV12usuariosEstado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9usuarios)) || String.IsNullOrEmpty(StringUtil.RTrim( AV11Contrasenia)) )
         {
            AV14ok = context.GetMessage( "N", "");
            AV26ErrorDes = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV12usuariosEstado = "";
         AV27GXLvl9 = 0;
         /* Using cursor P00J52 */
         pr_default.execute(0, new Object[] {AV9usuarios});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P00J52_A145usuariosId[0];
            A40000usuariosImagen_GXI = P00J52_A40000usuariosImagen_GXI[0];
            A223usuariosPasw = P00J52_A223usuariosPasw[0];
            A225usuariosTipo = P00J52_A225usuariosTipo[0];
            A240usuariosNumeroIdentidad = P00J52_A240usuariosNumeroIdentidad[0];
            A226usuariosEstado = P00J52_A226usuariosEstado[0];
            A222usuariosNombre = P00J52_A222usuariosNombre[0];
            A116PaisID = P00J52_A116PaisID[0];
            A224usuariosCorreo = P00J52_A224usuariosCorreo[0];
            A230usuariosDireccion = P00J52_A230usuariosDireccion[0];
            A231usuariosCPostal = P00J52_A231usuariosCPostal[0];
            A232usuariosTelefono = P00J52_A232usuariosTelefono[0];
            A266usuariosImagen = P00J52_A266usuariosImagen[0];
            AV27GXLvl9 = 1;
            GXt_char1 = AV13Enc;
            new pencripta(context ).execute(  StringUtil.Trim( AV11Contrasenia), out  GXt_char1) ;
            AV13Enc = GXt_char1;
            if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A223usuariosPasw)), StringUtil.Upper( StringUtil.Trim( AV13Enc))) == 0 )
            {
               AV17tipoUsuario = A225usuariosTipo;
               AV22ProfesionalesId = A240usuariosNumeroIdentidad;
               AV12usuariosEstado = A226usuariosEstado;
               if ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 )
               {
                  /* Execute user subroutine: 'OBTENER ESTADO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
               if ( StringUtil.StrCmp(AV12usuariosEstado, "HAB") == 0 )
               {
                  AV14ok = context.GetMessage( "S", "");
                  AV15usuariosNombre = A222usuariosNombre;
                  AV16paisid = A116PaisID;
                  AV18usuariosCorreo = A224usuariosCorreo;
                  AV19usuariosDireccion = A230usuariosDireccion;
                  AV20UsuariosCPostal = A231usuariosCPostal;
                  AV21UsuariosTelefono = A232usuariosTelefono;
                  AV23usuariosImagen = A266usuariosImagen;
                  AV28Usuariosimagen_GXI = A40000usuariosImagen_GXI;
                  AV24UsuarioURL = StringUtil.Trim( A40000usuariosImagen_GXI);
               }
               else
               {
                  AV14ok = context.GetMessage( "N", "");
                  AV26ErrorDes = context.GetMessage( "Estado deshabilitado", "");
               }
            }
            else
            {
               AV26ErrorDes = context.GetMessage( "Contraseña incorrecta", "");
               AV14ok = context.GetMessage( "N", "");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV27GXLvl9 == 0 )
         {
            AV26ErrorDes = context.GetMessage( "Intento incorrecto, registro no existe", "");
            AV14ok = context.GetMessage( "N", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER ESTADO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17tipoUsuario, context.GetMessage( "S", "")) == 0 )
         {
            /* Using cursor P00J53 */
            pr_default.execute(1, new Object[] {AV22ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00J53_A120ProfesionalesId[0];
               A108EstadosGenericosId = P00J53_A108EstadosGenericosId[0];
               if ( A108EstadosGenericosId != 1 )
               {
                  AV12usuariosEstado = "DES";
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV26ErrorDes = "";
         AV14ok = "";
         AV15usuariosNombre = "";
         AV16paisid = "";
         AV17tipoUsuario = "";
         AV22ProfesionalesId = "";
         AV18usuariosCorreo = "";
         AV19usuariosDireccion = "";
         AV21UsuariosTelefono = "";
         AV23usuariosImagen = "";
         AV24UsuarioURL = "";
         AV12usuariosEstado = "";
         P00J52_A145usuariosId = new string[] {""} ;
         P00J52_A40000usuariosImagen_GXI = new string[] {""} ;
         P00J52_A223usuariosPasw = new string[] {""} ;
         P00J52_A225usuariosTipo = new string[] {""} ;
         P00J52_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00J52_A226usuariosEstado = new string[] {""} ;
         P00J52_A222usuariosNombre = new string[] {""} ;
         P00J52_A116PaisID = new string[] {""} ;
         P00J52_A224usuariosCorreo = new string[] {""} ;
         P00J52_A230usuariosDireccion = new string[] {""} ;
         P00J52_A231usuariosCPostal = new int[1] ;
         P00J52_A232usuariosTelefono = new string[] {""} ;
         P00J52_A266usuariosImagen = new string[] {""} ;
         A145usuariosId = "";
         A40000usuariosImagen_GXI = "";
         A223usuariosPasw = "";
         A225usuariosTipo = "";
         A240usuariosNumeroIdentidad = "";
         A226usuariosEstado = "";
         A222usuariosNombre = "";
         A116PaisID = "";
         A224usuariosCorreo = "";
         A230usuariosDireccion = "";
         A232usuariosTelefono = "";
         A266usuariosImagen = "";
         AV13Enc = "";
         GXt_char1 = "";
         AV28Usuariosimagen_GXI = "";
         P00J53_A120ProfesionalesId = new string[] {""} ;
         P00J53_A108EstadosGenericosId = new int[1] ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.loginverificarprofesional__default(),
            new Object[][] {
                new Object[] {
               P00J52_A145usuariosId, P00J52_A40000usuariosImagen_GXI, P00J52_A223usuariosPasw, P00J52_A225usuariosTipo, P00J52_A240usuariosNumeroIdentidad, P00J52_A226usuariosEstado, P00J52_A222usuariosNombre, P00J52_A116PaisID, P00J52_A224usuariosCorreo, P00J52_A230usuariosDireccion,
               P00J52_A231usuariosCPostal, P00J52_A232usuariosTelefono, P00J52_A266usuariosImagen
               }
               , new Object[] {
               P00J53_A120ProfesionalesId, P00J53_A108EstadosGenericosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27GXLvl9 ;
      private int AV20UsuariosCPostal ;
      private int A231usuariosCPostal ;
      private int A108EstadosGenericosId ;
      private string AV9usuarios ;
      private string AV11Contrasenia ;
      private string AV14ok ;
      private string AV15usuariosNombre ;
      private string AV16paisid ;
      private string AV17tipoUsuario ;
      private string AV22ProfesionalesId ;
      private string AV21UsuariosTelefono ;
      private string AV12usuariosEstado ;
      private string A145usuariosId ;
      private string A223usuariosPasw ;
      private string A225usuariosTipo ;
      private string A240usuariosNumeroIdentidad ;
      private string A226usuariosEstado ;
      private string A222usuariosNombre ;
      private string A116PaisID ;
      private string A232usuariosTelefono ;
      private string AV13Enc ;
      private string GXt_char1 ;
      private string A120ProfesionalesId ;
      private bool returnInSub ;
      private string AV26ErrorDes ;
      private string AV18usuariosCorreo ;
      private string AV19usuariosDireccion ;
      private string AV24UsuarioURL ;
      private string A40000usuariosImagen_GXI ;
      private string A224usuariosCorreo ;
      private string A230usuariosDireccion ;
      private string AV28Usuariosimagen_GXI ;
      private string AV23usuariosImagen ;
      private string A266usuariosImagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00J52_A145usuariosId ;
      private string[] P00J52_A40000usuariosImagen_GXI ;
      private string[] P00J52_A223usuariosPasw ;
      private string[] P00J52_A225usuariosTipo ;
      private string[] P00J52_A240usuariosNumeroIdentidad ;
      private string[] P00J52_A226usuariosEstado ;
      private string[] P00J52_A222usuariosNombre ;
      private string[] P00J52_A116PaisID ;
      private string[] P00J52_A224usuariosCorreo ;
      private string[] P00J52_A230usuariosDireccion ;
      private int[] P00J52_A231usuariosCPostal ;
      private string[] P00J52_A232usuariosTelefono ;
      private string[] P00J52_A266usuariosImagen ;
      private string[] P00J53_A120ProfesionalesId ;
      private int[] P00J53_A108EstadosGenericosId ;
      private string aP2_ErrorDes ;
      private string aP3_ok ;
      private string aP4_usuariosNombre ;
      private string aP5_paisid ;
      private string aP6_tipoUsuario ;
      private string aP7_ProfesionalesId ;
      private string aP8_usuariosCorreo ;
      private string aP9_usuariosDireccion ;
      private int aP10_UsuariosCPostal ;
      private string aP11_UsuariosTelefono ;
      private string aP12_usuariosImagen ;
      private string aP13_UsuarioURL ;
      private string aP14_usuariosEstado ;
   }

   public class loginverificarprofesional__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00J52;
          prmP00J52 = new Object[] {
          new ParDef("@AV9usuarios",GXType.Char,20,0)
          };
          Object[] prmP00J53;
          prmP00J53 = new Object[] {
          new ParDef("@AV22ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J52", "SELECT [usuariosId], [usuariosImagen_GXI], [usuariosPasw], [usuariosTipo], [usuariosNumeroIdentidad], [usuariosEstado], [usuariosNombre], [PaisID], [usuariosCorreo], [usuariosDireccion], [usuariosCPostal], [usuariosTelefono], [usuariosImagen] FROM [usuarios] WHERE RTRIM(LTRIM(UPPER([usuariosId]))) = RTRIM(LTRIM(UPPER(@AV9usuarios))) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00J53", "SELECT TOP 1 [ProfesionalesId], [EstadosGenericosId] FROM [Profesionales] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV22ProfesionalesId)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J53,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 80);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
