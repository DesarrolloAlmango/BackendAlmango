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
   public class nuevousuario : GXProcedure
   {
      public nuevousuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public nuevousuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_usuariosNombre ,
                           string aP2_usuariosPasw ,
                           string aP3_usuariosCorreo ,
                           string aP4_usuarioTipo ,
                           string aP5_PaisID ,
                           string aP6_ProfesionalesId ,
                           SdtSDTProfesionales aP7_SDTProfesionales ,
                           SdtSDTComercio aP8_SDTProveedores ,
                           out string aP9_ok )
      {
         this.AV8usuariosId = aP0_usuariosId;
         this.AV9usuariosNombre = aP1_usuariosNombre;
         this.AV10usuariosPasw = aP2_usuariosPasw;
         this.AV11usuariosCorreo = aP3_usuariosCorreo;
         this.AV14usuarioTipo = aP4_usuarioTipo;
         this.AV15PaisID = aP5_PaisID;
         this.AV17ProfesionalesId = aP6_ProfesionalesId;
         this.AV28SDTProfesionales = aP7_SDTProfesionales;
         this.AV29SDTProveedores = aP8_SDTProveedores;
         this.AV12ok = "" ;
         initialize();
         ExecutePrivate();
         aP9_ok=this.AV12ok;
      }

      public string executeUdp( string aP0_usuariosId ,
                                string aP1_usuariosNombre ,
                                string aP2_usuariosPasw ,
                                string aP3_usuariosCorreo ,
                                string aP4_usuarioTipo ,
                                string aP5_PaisID ,
                                string aP6_ProfesionalesId ,
                                SdtSDTProfesionales aP7_SDTProfesionales ,
                                SdtSDTComercio aP8_SDTProveedores )
      {
         execute(aP0_usuariosId, aP1_usuariosNombre, aP2_usuariosPasw, aP3_usuariosCorreo, aP4_usuarioTipo, aP5_PaisID, aP6_ProfesionalesId, aP7_SDTProfesionales, aP8_SDTProveedores, out aP9_ok);
         return AV12ok ;
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_usuariosNombre ,
                                 string aP2_usuariosPasw ,
                                 string aP3_usuariosCorreo ,
                                 string aP4_usuarioTipo ,
                                 string aP5_PaisID ,
                                 string aP6_ProfesionalesId ,
                                 SdtSDTProfesionales aP7_SDTProfesionales ,
                                 SdtSDTComercio aP8_SDTProveedores ,
                                 out string aP9_ok )
      {
         this.AV8usuariosId = aP0_usuariosId;
         this.AV9usuariosNombre = aP1_usuariosNombre;
         this.AV10usuariosPasw = aP2_usuariosPasw;
         this.AV11usuariosCorreo = aP3_usuariosCorreo;
         this.AV14usuarioTipo = aP4_usuarioTipo;
         this.AV15PaisID = aP5_PaisID;
         this.AV17ProfesionalesId = aP6_ProfesionalesId;
         this.AV28SDTProfesionales = aP7_SDTProfesionales;
         this.AV29SDTProveedores = aP8_SDTProveedores;
         this.AV12ok = "" ;
         SubmitImpl();
         aP9_ok=this.AV12ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12ok = context.GetMessage( "N", "");
         /*
            INSERT RECORD ON TABLE usuarios

         */
         A145usuariosId = StringUtil.Trim( AV8usuariosId);
         A222usuariosNombre = AV9usuariosNombre;
         GXt_char1 = AV13Enc;
         new pencripta(context ).execute(  AV10usuariosPasw, out  GXt_char1) ;
         AV13Enc = GXt_char1;
         A223usuariosPasw = StringUtil.Trim( AV13Enc);
         A224usuariosCorreo = AV11usuariosCorreo;
         A225usuariosTipo = AV14usuarioTipo;
         A116PaisID = AV15PaisID;
         A240usuariosNumeroIdentidad = StringUtil.Trim( AV17ProfesionalesId);
         A226usuariosEstado = "PEN";
         AV12ok = context.GetMessage( "S", "");
         /* Using cursor P009B2 */
         pr_default.execute(0, new Object[] {A145usuariosId, A225usuariosTipo, A222usuariosNombre, A224usuariosCorreo, A116PaisID, A223usuariosPasw, A226usuariosEstado, A240usuariosNumeroIdentidad});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("usuarios");
         if ( (pr_default.getStatus(0) == 1) )
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
         if ( StringUtil.StrCmp(AV14usuarioTipo, context.GetMessage( "S", "")) == 0 )
         {
            /* Execute user subroutine: 'CREAR CUENTA PROFESIONAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV14usuarioTipo, context.GetMessage( "P", "")) == 0 )
         {
            /* Execute user subroutine: 'CREAR PROVEEDOR' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV14usuarioTipo, context.GetMessage( "C", "")) == 0 )
         {
            /* Execute user subroutine: 'CREAR CLIENTE' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREAR CUENTA PROFESIONAL' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE Profesionales

         */
         A120ProfesionalesId = AV17ProfesionalesId;
         A166ProfesionalesPrimerNombre = AV28SDTProfesionales.gxTpr_Primernombre;
         A191ProfesionalesSegundoNombre = AV28SDTProfesionales.gxTpr_Segundonombre;
         A167ProfesionalesApellidoPrimero = AV28SDTProfesionales.gxTpr_Apellidoprimero;
         A192ProfesionalesApellidoSegundo = AV28SDTProfesionales.gxTpr_Apellidosegundo;
         A170ProfesionalesTelefono = StringUtil.Trim( AV28SDTProfesionales.gxTpr_Telefono);
         A198ProfesionalesDireccion = StringUtil.Trim( AV28SDTProfesionales.gxTpr_Direccion);
         A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         A193ProfesionalesEmail = AV11usuariosCorreo;
         n193ProfesionalesEmail = false;
         A107EstadosTipo = context.GetMessage( "STS", "");
         A108EstadosGenericosId = 3;
         A199ProfesionalesFechaAlta = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
         A200ProfesionalesFechaActualizado = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
         A676ProfesionalesEsRUT = AV28SDTProfesionales.gxTpr_Esrut;
         n676ProfesionalesEsRUT = false;
         A677ProfesionalesExperiencia = AV28SDTProfesionales.gxTpr_Experiencia;
         n677ProfesionalesExperiencia = false;
         A678ProfesionalesAceptoTerminos = DateTimeUtil.Now( context);
         n678ProfesionalesAceptoTerminos = false;
         A679ProfesionalesDeclaroDatosV = DateTimeUtil.Now( context);
         n679ProfesionalesDeclaroDatosV = false;
         A680ProfesionalesCuentaBancaria = AV28SDTProfesionales.gxTpr_Cuentabancaria;
         n680ProfesionalesCuentaBancaria = false;
         if ( AV28SDTProfesionales.gxTpr_Bancoid > 0 )
         {
            A673BancoId = AV28SDTProfesionales.gxTpr_Bancoid;
            n673BancoId = false;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SDTProfesionales.gxTpr_Imagenbase64)) )
         {
            A169ProfesionalesPhoto = AV28SDTProfesionales.gxTpr_Imagenbase64;
            A40000ProfesionalesPhoto_GXI = GXDbFile.PathToUrl( AV28SDTProfesionales.gxTpr_Imagenbase64, context);
         }
         A900ProfesionalesFechaNacimiento = AV28SDTProfesionales.gxTpr_Fechanacimiento;
         n900ProfesionalesFechaNacimiento = false;
         A901ProfesionalesRUT = AV28SDTProfesionales.gxTpr_Rutempresa;
         n901ProfesionalesRUT = false;
         A902ProfesionalesTipoEmpresa = AV28SDTProfesionales.gxTpr_Tipoempresa;
         n902ProfesionalesTipoEmpresa = false;
         /* Using cursor P009B3 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A267ProfesionalesVerDatPerSol, A107EstadosTipo, A108EstadosGenericosId, A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n678ProfesionalesAceptoTerminos, A678ProfesionalesAceptoTerminos, n679ProfesionalesDeclaroDatosV, A679ProfesionalesDeclaroDatosV, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, n673BancoId, A673BancoId, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n901ProfesionalesRUT, A901ProfesionalesRUT, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Profesionales");
         if ( (pr_default.getStatus(1) == 1) )
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
      }

      protected void S121( )
      {
         /* 'CREAR PROVEEDOR' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE Proveedor

         */
         A151ProveedoresTipoId = 5;
         A282ProveedorNombre = StringUtil.Trim( AV9usuariosNombre);
         A338ProveedorDocIdentidad = StringUtil.Trim( AV17ProfesionalesId);
         A433ProveedorEmail = AV11usuariosCorreo;
         n433ProveedorEmail = false;
         A682ProveedorRazonSocial = AV29SDTProveedores.gxTpr_Razonsocial;
         n682ProveedorRazonSocial = false;
         A683ProveedorContacto = AV29SDTProveedores.gxTpr_Contacto;
         n683ProveedorContacto = false;
         A684ProveedorContactoCell = AV29SDTProveedores.gxTpr_Telefono;
         n684ProveedorContactoCell = false;
         A685ProveedorSitioWeb = AV29SDTProveedores.gxTpr_Sitioweb;
         n685ProveedorSitioWeb = false;
         A431ProveedorDireccion = AV29SDTProveedores.gxTpr_Direccion;
         n431ProveedorDireccion = false;
         A430ProveedorTelefono = AV29SDTProveedores.gxTpr_Telefono;
         n430ProveedorTelefono = false;
         A686ProveedorAceptoTerminos = DateTimeUtil.Now( context);
         n686ProveedorAceptoTerminos = false;
         A687ProveedorCuentaBancaria = AV29SDTProveedores.gxTpr_Cuentabancaria;
         n687ProveedorCuentaBancaria = false;
         if ( AV29SDTProveedores.gxTpr_Bancoid > 0 )
         {
            A673BancoId = AV29SDTProveedores.gxTpr_Bancoid;
            n673BancoId = false;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SDTProveedores.gxTpr_Imagenbase64)) )
         {
            A432ProveedorImagen = AV29SDTProveedores.gxTpr_Imagenbase64;
            n432ProveedorImagen = false;
            A40001ProveedorImagen_GXI = GXDbFile.PathToUrl( AV29SDTProveedores.gxTpr_Imagenbase64, context);
            n40001ProveedorImagen_GXI = false;
         }
         A344ProveedorEstado = "PEN";
         AV21ProveedorID = A133ProveedorID;
         A978ProveedorCIU = false;
         /* Using cursor P009B4 */
         pr_default.execute(2, new Object[] {A151ProveedoresTipoId, A282ProveedorNombre, n432ProveedorImagen, A432ProveedorImagen, n40001ProveedorImagen_GXI, A40001ProveedorImagen_GXI, A338ProveedorDocIdentidad, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, A344ProveedorEstado, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n685ProveedorSitioWeb, A685ProveedorSitioWeb, n686ProveedorAceptoTerminos, A686ProveedorAceptoTerminos, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, n673BancoId, A673BancoId, A978ProveedorCIU});
         A133ProveedorID = P009B4_A133ProveedorID[0];
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Proveedor");
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
         context.CommitDataStores("nuevousuario",pr_default);
         GXt_char1 = AV23Exite;
         new oexisteuser(context ).execute(  AV8usuariosId,  AV8usuariosId,  "S", out  GXt_char1) ;
         AV23Exite = GXt_char1;
         if ( StringUtil.StrCmp(AV23Exite, context.GetMessage( "N", "")) == 0 )
         {
            /* Execute user subroutine: 'ALTA SECUSUARIO' */
            S131 ();
            if (returnInSub) return;
         }
      }

      protected void S131( )
      {
         /* 'ALTA SECUSUARIO' Routine */
         returnInSub = false;
         AV24SecUser = new GeneXus.Programs.wwpbaseobjects.SdtSecUser(context);
         AV24SecUser.gxTpr_Secusername = AV8usuariosId;
         AV24SecUser.gxTpr_Secuserfullname = AV9usuariosNombre;
         AV24SecUser.gxTpr_Secuserpassword = StringUtil.Trim( AV13Enc);
         AV24SecUser.gxTpr_Usuariosid = AV8usuariosId;
         AV24SecUser.gxTpr_Secuserestado = "PEN";
         AV24SecUser.Save();
         context.CommitDataStores("nuevousuario",pr_default);
         AV25UserId = AV24SecUser.gxTpr_Secuserid;
         if ( AV25UserId > 0 )
         {
            /* Execute user subroutine: 'AGREGARROL' */
            S141 ();
            if (returnInSub) return;
         }
      }

      protected void S141( )
      {
         /* 'AGREGARROL' Routine */
         returnInSub = false;
         AV26SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
         AV26SecUserRole.gxTpr_Secuserid = AV25UserId;
         AV26SecUserRole.gxTpr_Secroleid = 5;
         AV26SecUserRole.gxTpr_Secuserroleestado = "HAB";
         AV26SecUserRole.Save();
         context.CommitDataStores("nuevousuario",pr_default);
      }

      protected void S151( )
      {
         /* 'CREAR CLIENTE' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE Clientes

         */
         A434ClientesIdentidad = AV17ProfesionalesId;
         A160ClientesNombre = StringUtil.Trim( AV9usuariosNombre);
         A162ClientesEmail = AV11usuariosCorreo;
         A435ClientesEstado = "PEN";
         A112DepartamentoId = 1;
         A114DepartamentoMunicipioId = 1;
         /* Using cursor P009B5 */
         pr_default.execute(3, new Object[] {A160ClientesNombre, A434ClientesIdentidad, A162ClientesEmail, A112DepartamentoId, A114DepartamentoMunicipioId, A435ClientesEstado});
         A106ClientesId = P009B5_A106ClientesId[0];
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("Clientes");
         if ( (pr_default.getStatus(3) == 1) )
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
      }

      public override void cleanup( )
      {
         context.CommitDataStores("nuevousuario",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12ok = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         AV13Enc = "";
         A223usuariosPasw = "";
         A224usuariosCorreo = "";
         A225usuariosTipo = "";
         A116PaisID = "";
         A240usuariosNumeroIdentidad = "";
         A226usuariosEstado = "";
         Gx_emsg = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A198ProfesionalesDireccion = "";
         A267ProfesionalesVerDatPerSol = "";
         A193ProfesionalesEmail = "";
         A107EstadosTipo = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         A677ProfesionalesExperiencia = "";
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         A680ProfesionalesCuentaBancaria = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         A901ProfesionalesRUT = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A433ProveedorEmail = "";
         A682ProveedorRazonSocial = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A685ProveedorSitioWeb = "";
         A431ProveedorDireccion = "";
         A430ProveedorTelefono = "";
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         A687ProveedorCuentaBancaria = "";
         A432ProveedorImagen = "";
         A40001ProveedorImagen_GXI = "";
         A344ProveedorEstado = "";
         P009B4_A133ProveedorID = new long[1] ;
         AV23Exite = "";
         GXt_char1 = "";
         AV24SecUser = new GeneXus.Programs.wwpbaseobjects.SdtSecUser(context);
         AV26SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
         A434ClientesIdentidad = "";
         A160ClientesNombre = "";
         A162ClientesEmail = "";
         A435ClientesEstado = "";
         P009B5_A106ClientesId = new long[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.nuevousuario__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.nuevousuario__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P009B4_A133ProveedorID
               }
               , new Object[] {
               P009B5_A106ClientesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A902ProfesionalesTipoEmpresa ;
      private int GX_INS45 ;
      private int GX_INS34 ;
      private int A108EstadosGenericosId ;
      private int GX_INS28 ;
      private int GX_INS20 ;
      private long A673BancoId ;
      private long A151ProveedoresTipoId ;
      private long AV21ProveedorID ;
      private long A133ProveedorID ;
      private long AV25UserId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A106ClientesId ;
      private string AV8usuariosId ;
      private string AV9usuariosNombre ;
      private string AV10usuariosPasw ;
      private string AV14usuarioTipo ;
      private string AV15PaisID ;
      private string AV17ProfesionalesId ;
      private string AV12ok ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string AV13Enc ;
      private string A223usuariosPasw ;
      private string A225usuariosTipo ;
      private string A116PaisID ;
      private string A240usuariosNumeroIdentidad ;
      private string A226usuariosEstado ;
      private string Gx_emsg ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A267ProfesionalesVerDatPerSol ;
      private string A107EstadosTipo ;
      private string A680ProfesionalesCuentaBancaria ;
      private string A901ProfesionalesRUT ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A682ProveedorRazonSocial ;
      private string A683ProveedorContacto ;
      private string A684ProveedorContactoCell ;
      private string A685ProveedorSitioWeb ;
      private string A430ProveedorTelefono ;
      private string A687ProveedorCuentaBancaria ;
      private string A344ProveedorEstado ;
      private string AV23Exite ;
      private string GXt_char1 ;
      private string A434ClientesIdentidad ;
      private string A160ClientesNombre ;
      private string A435ClientesEstado ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private DateTime A678ProfesionalesAceptoTerminos ;
      private DateTime A679ProfesionalesDeclaroDatosV ;
      private DateTime A686ProveedorAceptoTerminos ;
      private DateTime A900ProfesionalesFechaNacimiento ;
      private bool returnInSub ;
      private bool n193ProfesionalesEmail ;
      private bool A676ProfesionalesEsRUT ;
      private bool n676ProfesionalesEsRUT ;
      private bool n677ProfesionalesExperiencia ;
      private bool n678ProfesionalesAceptoTerminos ;
      private bool n679ProfesionalesDeclaroDatosV ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n673BancoId ;
      private bool n900ProfesionalesFechaNacimiento ;
      private bool n901ProfesionalesRUT ;
      private bool n902ProfesionalesTipoEmpresa ;
      private bool n433ProveedorEmail ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n685ProveedorSitioWeb ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n432ProveedorImagen ;
      private bool n40001ProveedorImagen_GXI ;
      private bool A978ProveedorCIU ;
      private string AV11usuariosCorreo ;
      private string A224usuariosCorreo ;
      private string A198ProfesionalesDireccion ;
      private string A193ProfesionalesEmail ;
      private string A677ProfesionalesExperiencia ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A433ProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A40001ProveedorImagen_GXI ;
      private string A162ClientesEmail ;
      private string A169ProfesionalesPhoto ;
      private string A432ProveedorImagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTProfesionales AV28SDTProfesionales ;
      private SdtSDTComercio AV29SDTProveedores ;
      private IDataStoreProvider pr_default ;
      private long[] P009B4_A133ProveedorID ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUser AV24SecUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole AV26SecUserRole ;
      private long[] P009B5_A106ClientesId ;
      private string aP9_ok ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class nuevousuario__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class nuevousuario__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP009B2;
        prmP009B2 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0) ,
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@usuariosCorreo",GXType.NVarChar,100,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
        new ParDef("@usuariosNumeroIdentidad",GXType.NChar,20,0)
        };
        Object[] prmP009B3;
        prmP009B3 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProfesionalesAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesDeclaroDatosV",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmP009B4;
        prmP009B4 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorSitioWeb",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0)
        };
        Object[] prmP009B5;
        prmP009B5 = new Object[] {
        new ParDef("@ClientesNombre",GXType.NChar,100,0) ,
        new ParDef("@ClientesIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ClientesEmail",GXType.NVarChar,100,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ClientesEstado",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009B2", "INSERT INTO [usuarios]([usuariosId], [usuariosTipo], [usuariosNombre], [usuariosCorreo], [PaisID], [usuariosPasw], [usuariosEstado], [usuariosNumeroIdentidad], [usuariosDireccion], [usuariosImagen], [usuariosImagen_GXI], [usuariosCPostal], [usuariosTelefono], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff]) VALUES(@usuariosId, @usuariosTipo, @usuariosNombre, @usuariosCorreo, @PaisID, @usuariosPasw, @usuariosEstado, @usuariosNumeroIdentidad, '', CONVERT(varbinary(1), ''), '', convert(int, 0), '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP009B2)
           ,new CursorDef("P009B3", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [EstadosTipo], [EstadosGenericosId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesEsRUT], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [ProfesionalesLimitOSF], [ProfesionalesCapacidadProducti]) VALUES(@ProfesionalesId, @ProfesionalesPrimerNombre, @ProfesionalesSegundoNombre, @ProfesionalesApellidoPrimero, @ProfesionalesApellidoSegundo, @ProfesionalesPhoto, @ProfesionalesPhoto_GXI, @ProfesionalesTelefono, @ProfesionalesEmail, @ProfesionalesDireccion, @ProfesionalesVerDatPerSol, @EstadosTipo, @EstadosGenericosId, @ProfesionalesFechaAlta, @ProfesionalesFechaActualizado, @ProfesionalesEsRUT, @ProfesionalesExperiencia, @ProfesionalesAceptoTerminos, @ProfesionalesDeclaroDatosV, @ProfesionalesCuentaBancaria, @BancoId, @ProfesionalesFechaNacimiento, @ProfesionalesRUT, @ProfesionalesTipoEmpresa, '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0))", GxErrorMask.GX_NOMASK,prmP009B3)
           ,new CursorDef("P009B4", "INSERT INTO [Proveedor]([ProveedoresTipoId], [ProveedorNombre], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorEstado], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorCuentaBancaria], [BancoId], [ProveedorCIU], [ProveedorSerialComi], [ProveedorPerAltShop], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ComercioProductosREnum], [ProveedorFreezePrice]) VALUES(@ProveedoresTipoId, @ProveedorNombre, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorDocIdentidad, @ProveedorTelefono, @ProveedorDireccion, @ProveedorEmail, @ProveedorEstado, @ProveedorRazonSocial, @ProveedorContacto, @ProveedorContactoCell, @ProveedorSitioWeb, @ProveedorAceptoTerminos, @ProveedorCuentaBancaria, @BancoId, @ProveedorCIU, convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009B4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009B5", "INSERT INTO [Clientes]([ClientesNombre], [ClientesIdentidad], [ClientesEmail], [DepartamentoId], [DepartamentoMunicipioId], [ClientesEstado], [ClientesImagen], [ClientesImagen_GXI], [ClientesTelefono], [ClientesDireccion]) VALUES(@ClientesNombre, @ClientesIdentidad, @ClientesEmail, @DepartamentoId, @DepartamentoMunicipioId, @ClientesEstado, CONVERT(varbinary(1), ''), '', '', ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009B5,1, GxCacheFrequency.OFF ,true,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
