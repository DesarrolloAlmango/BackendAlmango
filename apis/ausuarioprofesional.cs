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
   public class ausuarioprofesional : GXProcedure
   {
      public ausuarioprofesional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ausuarioprofesional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_Password ,
                           string aP2_usuariosTipo ,
                           SdtSDTProfesionales aP3_SdtProfesionalesRegistro ,
                           out bool aP4_ok ,
                           out string aP5_RestMessage ,
                           out short aP6_Gx_restcode )
      {
         this.AV20usuariosId = aP0_usuariosId;
         this.AV16Password = aP1_Password;
         this.AV22usuariosTipo = aP2_usuariosTipo;
         this.AV28SdtProfesionalesRegistro = aP3_SdtProfesionalesRegistro;
         this.AV13ok = false ;
         this.AV17RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP4_ok=this.AV13ok;
         aP5_RestMessage=this.AV17RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_usuariosId ,
                               string aP1_Password ,
                               string aP2_usuariosTipo ,
                               SdtSDTProfesionales aP3_SdtProfesionalesRegistro ,
                               out bool aP4_ok ,
                               out string aP5_RestMessage )
      {
         execute(aP0_usuariosId, aP1_Password, aP2_usuariosTipo, aP3_SdtProfesionalesRegistro, out aP4_ok, out aP5_RestMessage, out aP6_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_Password ,
                                 string aP2_usuariosTipo ,
                                 SdtSDTProfesionales aP3_SdtProfesionalesRegistro ,
                                 out bool aP4_ok ,
                                 out string aP5_RestMessage ,
                                 out short aP6_Gx_restcode )
      {
         this.AV20usuariosId = aP0_usuariosId;
         this.AV16Password = aP1_Password;
         this.AV22usuariosTipo = aP2_usuariosTipo;
         this.AV28SdtProfesionalesRegistro = aP3_SdtProfesionalesRegistro;
         this.AV13ok = false ;
         this.AV17RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP4_ok=this.AV13ok;
         aP5_RestMessage=this.AV17RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV22usuariosTipo, "S") != 0 )
         {
            Gx_restcode = 403;
            AV17RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20usuariosId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV16Password)) || String.IsNullOrEmpty(StringUtil.RTrim( AV22usuariosTipo)) )
         {
            Gx_restcode = 404;
            AV17RestMessage = context.GetMessage( "Error de parámetros en la solicitud", "");
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'EVALUARUSUARIO' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EVALUARUSUARIO' Routine */
         returnInSub = false;
         GXt_char1 = AV11ExisteUsr;
         new oexisteuser(context ).execute(  AV20usuariosId,  AV20usuariosId,  "U", out  GXt_char1) ;
         AV11ExisteUsr = GXt_char1;
         if ( StringUtil.StrCmp(AV11ExisteUsr, context.GetMessage( "S", "")) == 0 )
         {
            AV17RestMessage = context.GetMessage( "Ya existe un usuario con el mismo nickname.", "");
            Gx_restcode = 409;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            GXt_char1 = AV11ExisteUsr;
            new oexisteuser(context ).execute(  AV20usuariosId,  AV20usuariosId,  "S", out  GXt_char1) ;
            AV11ExisteUsr = GXt_char1;
            if ( StringUtil.StrCmp(AV11ExisteUsr, context.GetMessage( "S", "")) == 0 )
            {
               AV17RestMessage = context.GetMessage( "Ya existe un registro asociado al mismo usuario.", "");
               Gx_restcode = 409;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               /* Execute user subroutine: 'EVALUAR MAS DATOS' */
               S121 ();
               if (returnInSub) return;
            }
         }
      }

      protected void S121( )
      {
         /* 'EVALUAR MAS DATOS' Routine */
         returnInSub = false;
         AV23validacion = context.GetMessage( "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "");
         if ( StringUtil.StrCmp(AV22usuariosTipo, "S") == 0 )
         {
            /* Execute user subroutine: 'PROFESIONAL' */
            S131 ();
            if (returnInSub) return;
         }
         else
         {
            AV17RestMessage = context.GetMessage( "Registro de usuario no implementado.", "");
            Gx_restcode = 500;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'PROFESIONAL' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28SdtProfesionalesRegistro.gxTpr_Primernombre)) || String.IsNullOrEmpty(StringUtil.RTrim( AV28SdtProfesionalesRegistro.gxTpr_Apellidoprimero)) )
         {
            AV17RestMessage = context.GetMessage( "El nombre del profesional no es valido.", "");
            Gx_restcode = 400;
            returnInSub = true;
            if (true) return;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28SdtProfesionalesRegistro.gxTpr_Docidentidad)) )
         {
            AV17RestMessage = context.GetMessage( "El documento de identidad o RUT del profesional no es valido.", "");
            Gx_restcode = 400;
            returnInSub = true;
            if (true) return;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28SdtProfesionalesRegistro.gxTpr_Telefono)) )
         {
            AV17RestMessage = context.GetMessage( "El número de teléfono no es valido.", "");
            Gx_restcode = 400;
         }
         else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28SdtProfesionalesRegistro.gxTpr_Direccion)) )
         {
            AV17RestMessage = context.GetMessage( "La dirección no es valida.", "");
            Gx_restcode = 400;
         }
         else if ( ! GxRegex.IsMatch(AV28SdtProfesionalesRegistro.gxTpr_Email,AV23validacion) )
         {
            AV17RestMessage = context.GetMessage( "Mail no valido.", "");
            Gx_restcode = 400;
         }
         else
         {
            /* Execute user subroutine: 'EVALUAR DOCIDENTIDAD' */
            S141 ();
            if (returnInSub) return;
         }
         if ( Gx_restcode == 0 )
         {
            AV12FullName = StringUtil.Format( "%1 %2", AV28SdtProfesionalesRegistro.gxTpr_Primernombre, AV28SdtProfesionalesRegistro.gxTpr_Apellidoprimero, "", "", "", "", "", "", "");
            AV29SdtProfesionalId = AV28SdtProfesionalesRegistro.gxTpr_Docidentidad;
            new nuevousuario(context ).execute(  AV20usuariosId,  AV12FullName,  AV16Password,  AV28SdtProfesionalesRegistro.gxTpr_Email,  AV22usuariosTipo,  AV28SdtProfesionalesRegistro.gxTpr_Paisiso2,  AV29SdtProfesionalId,  AV28SdtProfesionalesRegistro,  AV8SDTProveedores, out  AV14okNew) ;
            if ( StringUtil.StrCmp(AV14okNew, context.GetMessage( "S", "")) == 0 )
            {
               Gx_restcode = 201;
               AV17RestMessage = context.GetMessage( "Cuenta creada con éxito", "");
               AV13ok = true;
            }
            else
            {
               Gx_restcode = 500;
               AV17RestMessage = context.GetMessage( "Error al procesar la cuenta, comuníquese con el administrador", "");
            }
         }
      }

      protected void S141( )
      {
         /* 'EVALUAR DOCIDENTIDAD' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV22usuariosTipo, "S") == 0 )
         {
            /* Using cursor P00K02 */
            pr_default.execute(0, new Object[] {AV28SdtProfesionalesRegistro.gxTpr_Docidentidad});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A120ProfesionalesId = P00K02_A120ProfesionalesId[0];
               AV17RestMessage = context.GetMessage( "Documento de Identidad ya fue registrado con anterioridad.", "");
               Gx_restcode = 400;
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
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
         AV17RestMessage = "";
         AV11ExisteUsr = "";
         GXt_char1 = "";
         AV23validacion = "";
         AV12FullName = "";
         AV29SdtProfesionalId = "";
         AV8SDTProveedores = new SdtSDTComercio(context);
         AV14okNew = "";
         P00K02_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.ausuarioprofesional__default(),
            new Object[][] {
                new Object[] {
               P00K02_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private string AV20usuariosId ;
      private string AV16Password ;
      private string AV22usuariosTipo ;
      private string AV11ExisteUsr ;
      private string GXt_char1 ;
      private string AV23validacion ;
      private string AV12FullName ;
      private string AV29SdtProfesionalId ;
      private string AV14okNew ;
      private string A120ProfesionalesId ;
      private bool AV13ok ;
      private bool returnInSub ;
      private string AV17RestMessage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTProfesionales AV28SdtProfesionalesRegistro ;
      private SdtSDTComercio AV8SDTProveedores ;
      private IDataStoreProvider pr_default ;
      private string[] P00K02_A120ProfesionalesId ;
      private bool aP4_ok ;
      private string aP5_RestMessage ;
      private short aP6_Gx_restcode ;
   }

   public class ausuarioprofesional__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K02;
          prmP00K02 = new Object[] {
          new ParDef("@AV28SdtP_1Docidentidad",GXType.Char,25,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K02", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV28SdtP_1Docidentidad)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K02,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
