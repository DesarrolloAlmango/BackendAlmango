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
namespace GeneXus.Programs {
   public class loginverificar : GXProcedure
   {
      public loginverificar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loginverificar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_usuarios ,
                           ref string aP1_Contrasenia ,
                           out string aP2_ErrorDes ,
                           out string aP3_ok ,
                           out long aP4_SecUserId ,
                           out string aP5_usuariosNombre ,
                           out string aP6_paisid ,
                           out string aP7_tipoUsuario ,
                           out string aP8_ProfesionalesId ,
                           out string aP9_usuariosCorreo ,
                           out string aP10_usuariosDireccion ,
                           out int aP11_UsuariosCPostal ,
                           out string aP12_UsuariosTelefono ,
                           out string aP13_usuariosImagen ,
                           out string aP14_UsuarioURL ,
                           out string aP15_usuariosEstado ,
                           out SdtSDTRoles aP16_SDTRoles )
      {
         this.AV12usuarios = aP0_usuarios;
         this.AV13Contrasenia = aP1_Contrasenia;
         this.AV10ErrorDes = "" ;
         this.AV11ok = "" ;
         this.AV29SecUserId = 0 ;
         this.AV14usuariosNombre = "" ;
         this.AV17paisid = "" ;
         this.AV16tipoUsuario = "" ;
         this.AV23ProfesionalesId = "" ;
         this.AV19usuariosCorreo = "" ;
         this.AV20usuariosDireccion = "" ;
         this.AV21UsuariosCPostal = 0 ;
         this.AV22UsuariosTelefono = "" ;
         this.AV24usuariosImagen = "" ;
         this.AV25UsuarioURL = "" ;
         this.AV26usuariosEstado = "" ;
         this.AV30SDTRoles = new SdtSDTRoles(context) ;
         initialize();
         ExecutePrivate();
         aP0_usuarios=this.AV12usuarios;
         aP1_Contrasenia=this.AV13Contrasenia;
         aP2_ErrorDes=this.AV10ErrorDes;
         aP3_ok=this.AV11ok;
         aP4_SecUserId=this.AV29SecUserId;
         aP5_usuariosNombre=this.AV14usuariosNombre;
         aP6_paisid=this.AV17paisid;
         aP7_tipoUsuario=this.AV16tipoUsuario;
         aP8_ProfesionalesId=this.AV23ProfesionalesId;
         aP9_usuariosCorreo=this.AV19usuariosCorreo;
         aP10_usuariosDireccion=this.AV20usuariosDireccion;
         aP11_UsuariosCPostal=this.AV21UsuariosCPostal;
         aP12_UsuariosTelefono=this.AV22UsuariosTelefono;
         aP13_usuariosImagen=this.AV24usuariosImagen;
         aP14_UsuarioURL=this.AV25UsuarioURL;
         aP15_usuariosEstado=this.AV26usuariosEstado;
         aP16_SDTRoles=this.AV30SDTRoles;
      }

      public SdtSDTRoles executeUdp( ref string aP0_usuarios ,
                                     ref string aP1_Contrasenia ,
                                     out string aP2_ErrorDes ,
                                     out string aP3_ok ,
                                     out long aP4_SecUserId ,
                                     out string aP5_usuariosNombre ,
                                     out string aP6_paisid ,
                                     out string aP7_tipoUsuario ,
                                     out string aP8_ProfesionalesId ,
                                     out string aP9_usuariosCorreo ,
                                     out string aP10_usuariosDireccion ,
                                     out int aP11_UsuariosCPostal ,
                                     out string aP12_UsuariosTelefono ,
                                     out string aP13_usuariosImagen ,
                                     out string aP14_UsuarioURL ,
                                     out string aP15_usuariosEstado )
      {
         execute(ref aP0_usuarios, ref aP1_Contrasenia, out aP2_ErrorDes, out aP3_ok, out aP4_SecUserId, out aP5_usuariosNombre, out aP6_paisid, out aP7_tipoUsuario, out aP8_ProfesionalesId, out aP9_usuariosCorreo, out aP10_usuariosDireccion, out aP11_UsuariosCPostal, out aP12_UsuariosTelefono, out aP13_usuariosImagen, out aP14_UsuarioURL, out aP15_usuariosEstado, out aP16_SDTRoles);
         return AV30SDTRoles ;
      }

      public void executeSubmit( ref string aP0_usuarios ,
                                 ref string aP1_Contrasenia ,
                                 out string aP2_ErrorDes ,
                                 out string aP3_ok ,
                                 out long aP4_SecUserId ,
                                 out string aP5_usuariosNombre ,
                                 out string aP6_paisid ,
                                 out string aP7_tipoUsuario ,
                                 out string aP8_ProfesionalesId ,
                                 out string aP9_usuariosCorreo ,
                                 out string aP10_usuariosDireccion ,
                                 out int aP11_UsuariosCPostal ,
                                 out string aP12_UsuariosTelefono ,
                                 out string aP13_usuariosImagen ,
                                 out string aP14_UsuarioURL ,
                                 out string aP15_usuariosEstado ,
                                 out SdtSDTRoles aP16_SDTRoles )
      {
         this.AV12usuarios = aP0_usuarios;
         this.AV13Contrasenia = aP1_Contrasenia;
         this.AV10ErrorDes = "" ;
         this.AV11ok = "" ;
         this.AV29SecUserId = 0 ;
         this.AV14usuariosNombre = "" ;
         this.AV17paisid = "" ;
         this.AV16tipoUsuario = "" ;
         this.AV23ProfesionalesId = "" ;
         this.AV19usuariosCorreo = "" ;
         this.AV20usuariosDireccion = "" ;
         this.AV21UsuariosCPostal = 0 ;
         this.AV22UsuariosTelefono = "" ;
         this.AV24usuariosImagen = "" ;
         this.AV25UsuarioURL = "" ;
         this.AV26usuariosEstado = "" ;
         this.AV30SDTRoles = new SdtSDTRoles(context) ;
         SubmitImpl();
         aP0_usuarios=this.AV12usuarios;
         aP1_Contrasenia=this.AV13Contrasenia;
         aP2_ErrorDes=this.AV10ErrorDes;
         aP3_ok=this.AV11ok;
         aP4_SecUserId=this.AV29SecUserId;
         aP5_usuariosNombre=this.AV14usuariosNombre;
         aP6_paisid=this.AV17paisid;
         aP7_tipoUsuario=this.AV16tipoUsuario;
         aP8_ProfesionalesId=this.AV23ProfesionalesId;
         aP9_usuariosCorreo=this.AV19usuariosCorreo;
         aP10_usuariosDireccion=this.AV20usuariosDireccion;
         aP11_UsuariosCPostal=this.AV21UsuariosCPostal;
         aP12_UsuariosTelefono=this.AV22UsuariosTelefono;
         aP13_usuariosImagen=this.AV24usuariosImagen;
         aP14_UsuarioURL=this.AV25UsuarioURL;
         aP15_usuariosEstado=this.AV26usuariosEstado;
         aP16_SDTRoles=this.AV30SDTRoles;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8usuariosId = AV12usuarios;
         AV9usuariosPasw = AV13Contrasenia;
         AV26usuariosEstado = "";
         AV11ok = context.GetMessage( "N", "");
         GXt_char1 = AV15Enc;
         new pencripta(context ).execute(  StringUtil.Trim( AV9usuariosPasw), out  GXt_char1) ;
         AV15Enc = GXt_char1;
         AV32GXLvl7 = 0;
         /* Using cursor P007Z2 */
         pr_default.execute(0, new Object[] {AV8usuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26SecUserName = P007Z2_A26SecUserName[0];
            A27SecUserPassword = P007Z2_A27SecUserPassword[0];
            A550SecUserEstado = P007Z2_A550SecUserEstado[0];
            n550SecUserEstado = P007Z2_n550SecUserEstado[0];
            A18SecUserId = P007Z2_A18SecUserId[0];
            AV32GXLvl7 = 1;
            if ( StringUtil.StrCmp(StringUtil.Trim( A27SecUserPassword), StringUtil.Trim( AV15Enc)) == 0 )
            {
               if ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 )
               {
                  AV29SecUserId = A18SecUserId;
                  AV11ok = context.GetMessage( "S", "");
                  /* Execute user subroutine: 'ROLES' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  AV10ErrorDes = context.GetMessage( "El usuario no se encuentra habilitado.", "");
                  AV11ok = context.GetMessage( "N", "");
               }
            }
            else
            {
               AV10ErrorDes = context.GetMessage( "Contraseña incorrecta.", "");
               AV11ok = context.GetMessage( "N", "");
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV32GXLvl7 == 0 )
         {
            AV10ErrorDes = context.GetMessage( "Intento incorrecto, registro no existe", "");
            AV11ok = context.GetMessage( "N", "");
         }
         if ( StringUtil.StrCmp(AV11ok, context.GetMessage( "S", "")) == 0 )
         {
            /* Using cursor P007Z3 */
            pr_default.execute(1, new Object[] {AV8usuariosId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A145usuariosId = P007Z3_A145usuariosId[0];
               A40000usuariosImagen_GXI = P007Z3_A40000usuariosImagen_GXI[0];
               A222usuariosNombre = P007Z3_A222usuariosNombre[0];
               A116PaisID = P007Z3_A116PaisID[0];
               A225usuariosTipo = P007Z3_A225usuariosTipo[0];
               A224usuariosCorreo = P007Z3_A224usuariosCorreo[0];
               A230usuariosDireccion = P007Z3_A230usuariosDireccion[0];
               A231usuariosCPostal = P007Z3_A231usuariosCPostal[0];
               A232usuariosTelefono = P007Z3_A232usuariosTelefono[0];
               A240usuariosNumeroIdentidad = P007Z3_A240usuariosNumeroIdentidad[0];
               A226usuariosEstado = P007Z3_A226usuariosEstado[0];
               A266usuariosImagen = P007Z3_A266usuariosImagen[0];
               AV14usuariosNombre = A222usuariosNombre;
               AV17paisid = A116PaisID;
               AV16tipoUsuario = A225usuariosTipo;
               AV19usuariosCorreo = A224usuariosCorreo;
               AV20usuariosDireccion = A230usuariosDireccion;
               AV21UsuariosCPostal = A231usuariosCPostal;
               AV22UsuariosTelefono = A232usuariosTelefono;
               AV23ProfesionalesId = A240usuariosNumeroIdentidad;
               AV24usuariosImagen = A266usuariosImagen;
               AV34Usuariosimagen_GXI = A40000usuariosImagen_GXI;
               AV25UsuarioURL = StringUtil.Trim( A40000usuariosImagen_GXI);
               AV26usuariosEstado = A226usuariosEstado;
               if ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 )
               {
                  AV27estado = context.GetMessage( "Habilitado", "");
                  /* Execute user subroutine: 'OBTENER ESTADO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     cleanup();
                     if (true) return;
                  }
               }
               if ( StringUtil.StrCmp(AV26usuariosEstado, "DES") == 0 )
               {
                  AV27estado = context.GetMessage( "Pendiente de Habilitación", "");
               }
               AV10ErrorDes = context.GetMessage( "Usuario con estado: ", "") + StringUtil.Trim( AV27estado);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER ESTADO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16tipoUsuario, context.GetMessage( "S", "")) == 0 )
         {
            /* Using cursor P007Z4 */
            pr_default.execute(2, new Object[] {AV23ProfesionalesId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A120ProfesionalesId = P007Z4_A120ProfesionalesId[0];
               A40001ProfesionalesPhoto_GXI = P007Z4_A40001ProfesionalesPhoto_GXI[0];
               A108EstadosGenericosId = P007Z4_A108EstadosGenericosId[0];
               A169ProfesionalesPhoto = P007Z4_A169ProfesionalesPhoto[0];
               if ( A108EstadosGenericosId == 1 )
               {
                  AV24usuariosImagen = A169ProfesionalesPhoto;
                  AV34Usuariosimagen_GXI = A40001ProfesionalesPhoto_GXI;
                  AV25UsuarioURL = StringUtil.Trim( A40001ProfesionalesPhoto_GXI);
                  AV26usuariosEstado = "HAB";
               }
               else
               {
                  AV26usuariosEstado = "DES";
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else if ( StringUtil.StrCmp(AV16tipoUsuario, context.GetMessage( "P", "")) == 0 )
         {
            /* Using cursor P007Z5 */
            pr_default.execute(3, new Object[] {AV23ProfesionalesId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A338ProveedorDocIdentidad = P007Z5_A338ProveedorDocIdentidad[0];
               A40002ProveedorImagen_GXI = P007Z5_A40002ProveedorImagen_GXI[0];
               n40002ProveedorImagen_GXI = P007Z5_n40002ProveedorImagen_GXI[0];
               A344ProveedorEstado = P007Z5_A344ProveedorEstado[0];
               A133ProveedorID = P007Z5_A133ProveedorID[0];
               A432ProveedorImagen = P007Z5_A432ProveedorImagen[0];
               n432ProveedorImagen = P007Z5_n432ProveedorImagen[0];
               AV26usuariosEstado = A344ProveedorEstado;
               AV24usuariosImagen = A432ProveedorImagen;
               AV34Usuariosimagen_GXI = A40002ProveedorImagen_GXI;
               AV25UsuarioURL = StringUtil.Trim( A40002ProveedorImagen_GXI);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else if ( StringUtil.StrCmp(AV16tipoUsuario, context.GetMessage( "C", "")) == 0 )
         {
            /* Using cursor P007Z6 */
            pr_default.execute(4, new Object[] {AV23ProfesionalesId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A434ClientesIdentidad = P007Z6_A434ClientesIdentidad[0];
               A435ClientesEstado = P007Z6_A435ClientesEstado[0];
               A106ClientesId = P007Z6_A106ClientesId[0];
               AV26usuariosEstado = A435ClientesEstado;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(4);
            }
            pr_default.close(4);
         }
      }

      protected void S121( )
      {
         /* 'ROLES' Routine */
         returnInSub = false;
         AV30SDTRoles.gxTpr_Secuserid = AV29SecUserId;
         /* Using cursor P007Z7 */
         pr_default.execute(5, new Object[] {AV29SecUserId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A551SecUserRoleEstado = P007Z7_A551SecUserRoleEstado[0];
            A18SecUserId = P007Z7_A18SecUserId[0];
            A16SecRoleId = P007Z7_A16SecRoleId[0];
            A25SecRoleName = P007Z7_A25SecRoleName[0];
            A25SecRoleName = P007Z7_A25SecRoleName[0];
            AV31SDTRolesItem = new SdtSDTRoles_Id(context);
            AV31SDTRolesItem.gxTpr_Secroleid = A16SecRoleId;
            AV31SDTRolesItem.gxTpr_Secrolename = A25SecRoleName;
            AV30SDTRoles.gxTpr_Roles.Add(AV31SDTRolesItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
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
         AV10ErrorDes = "";
         AV11ok = "";
         AV14usuariosNombre = "";
         AV17paisid = "";
         AV16tipoUsuario = "";
         AV23ProfesionalesId = "";
         AV19usuariosCorreo = "";
         AV20usuariosDireccion = "";
         AV22UsuariosTelefono = "";
         AV24usuariosImagen = "";
         AV25UsuarioURL = "";
         AV26usuariosEstado = "";
         AV30SDTRoles = new SdtSDTRoles(context);
         AV8usuariosId = "";
         AV9usuariosPasw = "";
         AV15Enc = "";
         GXt_char1 = "";
         P007Z2_A26SecUserName = new string[] {""} ;
         P007Z2_A27SecUserPassword = new string[] {""} ;
         P007Z2_A550SecUserEstado = new string[] {""} ;
         P007Z2_n550SecUserEstado = new bool[] {false} ;
         P007Z2_A18SecUserId = new long[1] ;
         A26SecUserName = "";
         A27SecUserPassword = "";
         A550SecUserEstado = "";
         P007Z3_A145usuariosId = new string[] {""} ;
         P007Z3_A40000usuariosImagen_GXI = new string[] {""} ;
         P007Z3_A222usuariosNombre = new string[] {""} ;
         P007Z3_A116PaisID = new string[] {""} ;
         P007Z3_A225usuariosTipo = new string[] {""} ;
         P007Z3_A224usuariosCorreo = new string[] {""} ;
         P007Z3_A230usuariosDireccion = new string[] {""} ;
         P007Z3_A231usuariosCPostal = new int[1] ;
         P007Z3_A232usuariosTelefono = new string[] {""} ;
         P007Z3_A240usuariosNumeroIdentidad = new string[] {""} ;
         P007Z3_A226usuariosEstado = new string[] {""} ;
         P007Z3_A266usuariosImagen = new string[] {""} ;
         A145usuariosId = "";
         A40000usuariosImagen_GXI = "";
         A222usuariosNombre = "";
         A116PaisID = "";
         A225usuariosTipo = "";
         A224usuariosCorreo = "";
         A230usuariosDireccion = "";
         A232usuariosTelefono = "";
         A240usuariosNumeroIdentidad = "";
         A226usuariosEstado = "";
         A266usuariosImagen = "";
         AV34Usuariosimagen_GXI = "";
         AV27estado = "";
         P007Z4_A120ProfesionalesId = new string[] {""} ;
         P007Z4_A40001ProfesionalesPhoto_GXI = new string[] {""} ;
         P007Z4_A108EstadosGenericosId = new int[1] ;
         P007Z4_A169ProfesionalesPhoto = new string[] {""} ;
         A120ProfesionalesId = "";
         A40001ProfesionalesPhoto_GXI = "";
         A169ProfesionalesPhoto = "";
         P007Z5_A338ProveedorDocIdentidad = new string[] {""} ;
         P007Z5_A40002ProveedorImagen_GXI = new string[] {""} ;
         P007Z5_n40002ProveedorImagen_GXI = new bool[] {false} ;
         P007Z5_A344ProveedorEstado = new string[] {""} ;
         P007Z5_A133ProveedorID = new long[1] ;
         P007Z5_A432ProveedorImagen = new string[] {""} ;
         P007Z5_n432ProveedorImagen = new bool[] {false} ;
         A338ProveedorDocIdentidad = "";
         A40002ProveedorImagen_GXI = "";
         A344ProveedorEstado = "";
         A432ProveedorImagen = "";
         P007Z6_A434ClientesIdentidad = new string[] {""} ;
         P007Z6_A435ClientesEstado = new string[] {""} ;
         P007Z6_A106ClientesId = new long[1] ;
         A434ClientesIdentidad = "";
         A435ClientesEstado = "";
         P007Z7_A551SecUserRoleEstado = new string[] {""} ;
         P007Z7_A18SecUserId = new long[1] ;
         P007Z7_A16SecRoleId = new short[1] ;
         P007Z7_A25SecRoleName = new string[] {""} ;
         A551SecUserRoleEstado = "";
         A25SecRoleName = "";
         AV31SDTRolesItem = new SdtSDTRoles_Id(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loginverificar__default(),
            new Object[][] {
                new Object[] {
               P007Z2_A26SecUserName, P007Z2_A27SecUserPassword, P007Z2_A550SecUserEstado, P007Z2_n550SecUserEstado, P007Z2_A18SecUserId
               }
               , new Object[] {
               P007Z3_A145usuariosId, P007Z3_A40000usuariosImagen_GXI, P007Z3_A222usuariosNombre, P007Z3_A116PaisID, P007Z3_A225usuariosTipo, P007Z3_A224usuariosCorreo, P007Z3_A230usuariosDireccion, P007Z3_A231usuariosCPostal, P007Z3_A232usuariosTelefono, P007Z3_A240usuariosNumeroIdentidad,
               P007Z3_A226usuariosEstado, P007Z3_A266usuariosImagen
               }
               , new Object[] {
               P007Z4_A120ProfesionalesId, P007Z4_A40001ProfesionalesPhoto_GXI, P007Z4_A108EstadosGenericosId, P007Z4_A169ProfesionalesPhoto
               }
               , new Object[] {
               P007Z5_A338ProveedorDocIdentidad, P007Z5_A40002ProveedorImagen_GXI, P007Z5_n40002ProveedorImagen_GXI, P007Z5_A344ProveedorEstado, P007Z5_A133ProveedorID, P007Z5_A432ProveedorImagen, P007Z5_n432ProveedorImagen
               }
               , new Object[] {
               P007Z6_A434ClientesIdentidad, P007Z6_A435ClientesEstado, P007Z6_A106ClientesId
               }
               , new Object[] {
               P007Z7_A551SecUserRoleEstado, P007Z7_A18SecUserId, P007Z7_A16SecRoleId, P007Z7_A25SecRoleName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32GXLvl7 ;
      private short A16SecRoleId ;
      private int AV21UsuariosCPostal ;
      private int A231usuariosCPostal ;
      private int A108EstadosGenericosId ;
      private long AV29SecUserId ;
      private long A18SecUserId ;
      private long A133ProveedorID ;
      private long A106ClientesId ;
      private string AV12usuarios ;
      private string AV13Contrasenia ;
      private string AV10ErrorDes ;
      private string AV11ok ;
      private string AV14usuariosNombre ;
      private string AV17paisid ;
      private string AV16tipoUsuario ;
      private string AV23ProfesionalesId ;
      private string AV22UsuariosTelefono ;
      private string AV26usuariosEstado ;
      private string AV8usuariosId ;
      private string AV9usuariosPasw ;
      private string AV15Enc ;
      private string GXt_char1 ;
      private string A550SecUserEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string A116PaisID ;
      private string A225usuariosTipo ;
      private string A232usuariosTelefono ;
      private string A240usuariosNumeroIdentidad ;
      private string A226usuariosEstado ;
      private string AV27estado ;
      private string A120ProfesionalesId ;
      private string A338ProveedorDocIdentidad ;
      private string A344ProveedorEstado ;
      private string A434ClientesIdentidad ;
      private string A435ClientesEstado ;
      private string A551SecUserRoleEstado ;
      private bool n550SecUserEstado ;
      private bool returnInSub ;
      private bool n40002ProveedorImagen_GXI ;
      private bool n432ProveedorImagen ;
      private string AV19usuariosCorreo ;
      private string AV20usuariosDireccion ;
      private string AV25UsuarioURL ;
      private string A26SecUserName ;
      private string A27SecUserPassword ;
      private string A40000usuariosImagen_GXI ;
      private string A224usuariosCorreo ;
      private string A230usuariosDireccion ;
      private string AV34Usuariosimagen_GXI ;
      private string A40001ProfesionalesPhoto_GXI ;
      private string A40002ProveedorImagen_GXI ;
      private string A25SecRoleName ;
      private string AV24usuariosImagen ;
      private string A266usuariosImagen ;
      private string A169ProfesionalesPhoto ;
      private string A432ProveedorImagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_usuarios ;
      private string aP1_Contrasenia ;
      private SdtSDTRoles AV30SDTRoles ;
      private IDataStoreProvider pr_default ;
      private string[] P007Z2_A26SecUserName ;
      private string[] P007Z2_A27SecUserPassword ;
      private string[] P007Z2_A550SecUserEstado ;
      private bool[] P007Z2_n550SecUserEstado ;
      private long[] P007Z2_A18SecUserId ;
      private string[] P007Z3_A145usuariosId ;
      private string[] P007Z3_A40000usuariosImagen_GXI ;
      private string[] P007Z3_A222usuariosNombre ;
      private string[] P007Z3_A116PaisID ;
      private string[] P007Z3_A225usuariosTipo ;
      private string[] P007Z3_A224usuariosCorreo ;
      private string[] P007Z3_A230usuariosDireccion ;
      private int[] P007Z3_A231usuariosCPostal ;
      private string[] P007Z3_A232usuariosTelefono ;
      private string[] P007Z3_A240usuariosNumeroIdentidad ;
      private string[] P007Z3_A226usuariosEstado ;
      private string[] P007Z3_A266usuariosImagen ;
      private string[] P007Z4_A120ProfesionalesId ;
      private string[] P007Z4_A40001ProfesionalesPhoto_GXI ;
      private int[] P007Z4_A108EstadosGenericosId ;
      private string[] P007Z4_A169ProfesionalesPhoto ;
      private string[] P007Z5_A338ProveedorDocIdentidad ;
      private string[] P007Z5_A40002ProveedorImagen_GXI ;
      private bool[] P007Z5_n40002ProveedorImagen_GXI ;
      private string[] P007Z5_A344ProveedorEstado ;
      private long[] P007Z5_A133ProveedorID ;
      private string[] P007Z5_A432ProveedorImagen ;
      private bool[] P007Z5_n432ProveedorImagen ;
      private string[] P007Z6_A434ClientesIdentidad ;
      private string[] P007Z6_A435ClientesEstado ;
      private long[] P007Z6_A106ClientesId ;
      private string[] P007Z7_A551SecUserRoleEstado ;
      private long[] P007Z7_A18SecUserId ;
      private short[] P007Z7_A16SecRoleId ;
      private string[] P007Z7_A25SecRoleName ;
      private SdtSDTRoles_Id AV31SDTRolesItem ;
      private string aP2_ErrorDes ;
      private string aP3_ok ;
      private long aP4_SecUserId ;
      private string aP5_usuariosNombre ;
      private string aP6_paisid ;
      private string aP7_tipoUsuario ;
      private string aP8_ProfesionalesId ;
      private string aP9_usuariosCorreo ;
      private string aP10_usuariosDireccion ;
      private int aP11_UsuariosCPostal ;
      private string aP12_UsuariosTelefono ;
      private string aP13_usuariosImagen ;
      private string aP14_UsuarioURL ;
      private string aP15_usuariosEstado ;
      private SdtSDTRoles aP16_SDTRoles ;
   }

   public class loginverificar__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007Z2;
          prmP007Z2 = new Object[] {
          new ParDef("@AV8usuariosId",GXType.Char,20,0)
          };
          Object[] prmP007Z3;
          prmP007Z3 = new Object[] {
          new ParDef("@AV8usuariosId",GXType.Char,20,0)
          };
          Object[] prmP007Z4;
          prmP007Z4 = new Object[] {
          new ParDef("@AV23ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP007Z5;
          prmP007Z5 = new Object[] {
          new ParDef("@AV23ProfesionalesId",GXType.NChar,20,0)
          };
          Object[] prmP007Z6;
          prmP007Z6 = new Object[] {
          new ParDef("@AV23ProfesionalesId",GXType.NChar,20,0)
          };
          Object[] prmP007Z7;
          prmP007Z7 = new Object[] {
          new ParDef("@AV29SecUserId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Z2", "SELECT [SecUserName], [SecUserPassword], [SecUserEstado], [SecUserId] FROM [SecUser] WHERE RTRIM(LTRIM(UPPER([SecUserName]))) = RTRIM(LTRIM(UPPER(@AV8usuariosId))) ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Z3", "SELECT [usuariosId], [usuariosImagen_GXI], [usuariosNombre], [PaisID], [usuariosTipo], [usuariosCorreo], [usuariosDireccion], [usuariosCPostal], [usuariosTelefono], [usuariosNumeroIdentidad], [usuariosEstado], [usuariosImagen] FROM [usuarios] WHERE RTRIM(LTRIM(UPPER([usuariosId]))) = RTRIM(LTRIM(UPPER(@AV8usuariosId))) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Z4", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesPhoto_GXI], [EstadosGenericosId], [ProfesionalesPhoto] FROM [Profesionales] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV23ProfesionalesId)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Z5", "SELECT TOP 1 [ProveedorDocIdentidad], [ProveedorImagen_GXI], [ProveedorEstado], [ProveedorID], [ProveedorImagen] FROM [Proveedor] WHERE RTRIM(LTRIM([ProveedorDocIdentidad])) = RTRIM(LTRIM(@AV23ProfesionalesId)) ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Z6", "SELECT TOP 1 [ClientesIdentidad], [ClientesEstado], [ClientesId] FROM [Clientes] WHERE RTRIM(LTRIM([ClientesIdentidad])) = RTRIM(LTRIM(@AV23ProfesionalesId)) ORDER BY [ClientesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Z7", "SELECT T1.[SecUserRoleEstado], T1.[SecUserId], T1.[SecRoleId], T2.[SecRoleName] FROM ([SecUserRole] T1 INNER JOIN [SecRole] T2 ON T2.[SecRoleId] = T1.[SecRoleId]) WHERE (T1.[SecUserId] = @AV29SecUserId) AND (T1.[SecUserRoleEstado] = 'HAB') ORDER BY T1.[SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z7,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 3);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(2));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
