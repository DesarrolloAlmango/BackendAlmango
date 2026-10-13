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
   public class anuevacontrasena : GXProcedure
   {
      public anuevacontrasena( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public anuevacontrasena( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Usuariosid ,
                           string aP1_ProfesionalesId ,
                           string aP2_PasswordAnterior ,
                           string aP3_NuevoPassword ,
                           string aP4_ConfirmarPassword ,
                           out string aP5_RestMessage ,
                           out short aP6_Gx_restcode )
      {
         this.AV16Usuariosid = aP0_Usuariosid;
         this.AV20ProfesionalesId = aP1_ProfesionalesId;
         this.AV8PasswordAnterior = aP2_PasswordAnterior;
         this.AV9NuevoPassword = aP3_NuevoPassword;
         this.AV10ConfirmarPassword = aP4_ConfirmarPassword;
         this.AV15RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP5_RestMessage=this.AV15RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_Usuariosid ,
                               string aP1_ProfesionalesId ,
                               string aP2_PasswordAnterior ,
                               string aP3_NuevoPassword ,
                               string aP4_ConfirmarPassword ,
                               out string aP5_RestMessage )
      {
         execute(aP0_Usuariosid, aP1_ProfesionalesId, aP2_PasswordAnterior, aP3_NuevoPassword, aP4_ConfirmarPassword, out aP5_RestMessage, out aP6_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_Usuariosid ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_PasswordAnterior ,
                                 string aP3_NuevoPassword ,
                                 string aP4_ConfirmarPassword ,
                                 out string aP5_RestMessage ,
                                 out short aP6_Gx_restcode )
      {
         this.AV16Usuariosid = aP0_Usuariosid;
         this.AV20ProfesionalesId = aP1_ProfesionalesId;
         this.AV8PasswordAnterior = aP2_PasswordAnterior;
         this.AV9NuevoPassword = aP3_NuevoPassword;
         this.AV10ConfirmarPassword = aP4_ConfirmarPassword;
         this.AV15RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP5_RestMessage=this.AV15RestMessage;
         aP6_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16Usuariosid)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8PasswordAnterior)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9NuevoPassword)) || String.IsNullOrEmpty(StringUtil.RTrim( AV10ConfirmarPassword)) || String.IsNullOrEmpty(StringUtil.RTrim( AV20ProfesionalesId)) )
         {
            AV15RestMessage = context.GetMessage( "Error de parámetros", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         AV18TokenId = "";
         AV19IsOkToken = true;
         AV15RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV21HttpRequest,  AV16Usuariosid,  AV20ProfesionalesId, out  AV18TokenId, out  AV19IsOkToken, out  Gx_restcode, out  AV15RestMessage) ;
         if ( ! AV19IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         /* Using cursor P00K52 */
         pr_default.execute(0, new Object[] {AV16Usuariosid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P00K52_A145usuariosId[0];
            A223usuariosPasw = P00K52_A223usuariosPasw[0];
            GXt_char1 = AV17PasswordEnc;
            new pencripta(context ).execute(  StringUtil.Trim( AV8PasswordAnterior), out  GXt_char1) ;
            AV17PasswordEnc = GXt_char1;
            if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A223usuariosPasw)), StringUtil.Upper( StringUtil.Trim( AV17PasswordEnc))) == 0 )
            {
               AV13Ok = context.GetMessage( "S", "");
            }
            else
            {
               AV14OkPwd = context.GetMessage( "N", "");
            }
            if ( StringUtil.StrCmp(AV13Ok, context.GetMessage( "S", "")) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9NuevoPassword)) || String.IsNullOrEmpty(StringUtil.RTrim( AV10ConfirmarPassword)) )
               {
                  AV15RestMessage = context.GetMessage( "Nueva Contraseña Incorrecta", "");
               }
               else
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV9NuevoPassword), StringUtil.Trim( AV10ConfirmarPassword)) == 0 )
                  {
                     AV12SdtUsuario.gxTpr_Usuariosid = StringUtil.Trim( AV16Usuariosid);
                     AV12SdtUsuario.gxTpr_Usuariospassw = StringUtil.Trim( AV9NuevoPassword);
                     new actualizarusuario(context ).execute( ref  AV12SdtUsuario, out  AV13Ok) ;
                     if ( StringUtil.StrCmp(AV13Ok, context.GetMessage( "S", "")) == 0 )
                     {
                        AV15RestMessage = context.GetMessage( "Nueva Contraseña confirmada con exito", "");
                        Gx_restcode = 200;
                     }
                     else
                     {
                        AV15RestMessage = context.GetMessage( "Nueva contraseña no se puede confirmar", "");
                        Gx_restcode = 500;
                     }
                  }
                  else
                  {
                     AV15RestMessage = context.GetMessage( "Nueva Contraseña no coinciden", "");
                     Gx_restcode = 400;
                  }
               }
            }
            else
            {
               AV15RestMessage = context.GetMessage( "Contraseña actual incorrecta", "");
               Gx_restcode = 400;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV15RestMessage = "";
         AV18TokenId = "";
         AV21HttpRequest = new GxHttpRequest( context);
         P00K52_A145usuariosId = new string[] {""} ;
         P00K52_A223usuariosPasw = new string[] {""} ;
         A145usuariosId = "";
         A223usuariosPasw = "";
         AV17PasswordEnc = "";
         GXt_char1 = "";
         AV13Ok = "";
         AV14OkPwd = "";
         AV12SdtUsuario = new SdtSDTUser(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.anuevacontrasena__default(),
            new Object[][] {
                new Object[] {
               P00K52_A145usuariosId, P00K52_A223usuariosPasw
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private string AV16Usuariosid ;
      private string AV20ProfesionalesId ;
      private string AV8PasswordAnterior ;
      private string AV9NuevoPassword ;
      private string AV10ConfirmarPassword ;
      private string AV18TokenId ;
      private string A145usuariosId ;
      private string A223usuariosPasw ;
      private string AV17PasswordEnc ;
      private string GXt_char1 ;
      private string AV13Ok ;
      private string AV14OkPwd ;
      private bool AV19IsOkToken ;
      private string AV15RestMessage ;
      private GxHttpRequest AV21HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00K52_A145usuariosId ;
      private string[] P00K52_A223usuariosPasw ;
      private SdtSDTUser AV12SdtUsuario ;
      private string aP5_RestMessage ;
      private short aP6_Gx_restcode ;
   }

   public class anuevacontrasena__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K52;
          prmP00K52 = new Object[] {
          new ParDef("@AV16Usuariosid",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K52", "SELECT [usuariosId], [usuariosPasw] FROM [usuarios] WHERE UPPER([usuariosId]) = UPPER(@AV16Usuariosid) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K52,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
       }
    }

 }

}
