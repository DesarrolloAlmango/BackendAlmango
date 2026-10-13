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
   public class atoken : GXProcedure
   {
      public atoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuariosId ,
                           out string aP1_Token )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Token = "" ;
         initialize();
         ExecutePrivate();
         aP1_Token=this.AV9Token;
      }

      public string executeUdp( string aP0_UsuariosId )
      {
         execute(aP0_UsuariosId, out aP1_Token);
         return AV9Token ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 out string aP1_Token )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9Token = "" ;
         SubmitImpl();
         aP1_Token=this.AV9Token;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21FechaHora = DateTimeUtil.Now( context);
         AV22Anio = StringUtil.Str( (decimal)(DateTimeUtil.Year( AV21FechaHora)), 4, 0);
         AV23Mes = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV21FechaHora)), 2, 0));
         AV24Dia = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV21FechaHora)), 2, 0));
         AV13hora = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( AV21FechaHora)), 2, 0));
         AV25Minuto = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( AV21FechaHora)), 2, 0));
         AV26Segundo = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( AV21FechaHora)), 2, 0));
         AV27FechaCompacta = AV22Anio + AV23Mes + AV24Dia + AV13hora + AV25Minuto + AV26Segundo;
         AV12Texto = StringUtil.Trim( AV8UsuariosId) + "|" + AV27FechaCompacta;
         GXt_char1 = AV9Token;
         new pencripta(context ).execute(  AV12Texto, out  GXt_char1) ;
         AV9Token = GXt_char1;
         AV18NewTokenFechaExpiracion = DateTimeUtil.ServerNow( context, pr_default);
         AV19FechaExpiracion = DateTimeUtil.TAdd( AV18NewTokenFechaExpiracion, 3600*(1));
         new GeneXus.Programs.apis.eusertoken(context ).execute(  AV8UsuariosId, out  AV28ok) ;
         /*
            INSERT RECORD ON TABLE Token

         */
         A899TokenId = AV9Token;
         A905TokenFechaAlta = DateTimeUtil.ServerNow( context, pr_default);
         A904TokenFechaExpiracion = AV19FechaExpiracion;
         A145usuariosId = StringUtil.Trim( AV8UsuariosId);
         A903TokenRequests = 1;
         /* Using cursor P00J72 */
         pr_default.execute(0, new Object[] {A899TokenId, A905TokenFechaAlta, A904TokenFechaExpiracion, A145usuariosId, A903TokenRequests});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Token");
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
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.atoken",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Token = "";
         AV21FechaHora = (DateTime)(DateTime.MinValue);
         AV22Anio = "";
         AV23Mes = "";
         AV24Dia = "";
         AV13hora = "";
         AV25Minuto = "";
         AV26Segundo = "";
         AV27FechaCompacta = "";
         AV12Texto = "";
         GXt_char1 = "";
         AV18NewTokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         AV19FechaExpiracion = (DateTime)(DateTime.MinValue);
         A899TokenId = "";
         A905TokenFechaAlta = (DateTime)(DateTime.MinValue);
         A904TokenFechaExpiracion = (DateTime)(DateTime.MinValue);
         A145usuariosId = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.atoken__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A903TokenRequests ;
      private int GX_INS132 ;
      private string AV8UsuariosId ;
      private string AV9Token ;
      private string AV22Anio ;
      private string AV23Mes ;
      private string AV24Dia ;
      private string AV13hora ;
      private string AV25Minuto ;
      private string AV26Segundo ;
      private string AV27FechaCompacta ;
      private string GXt_char1 ;
      private string A899TokenId ;
      private string A145usuariosId ;
      private string Gx_emsg ;
      private DateTime AV21FechaHora ;
      private DateTime AV18NewTokenFechaExpiracion ;
      private DateTime AV19FechaExpiracion ;
      private DateTime A905TokenFechaAlta ;
      private DateTime A904TokenFechaExpiracion ;
      private bool AV28ok ;
      private string AV12Texto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string aP1_Token ;
   }

   public class atoken__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00J72;
          prmP00J72 = new Object[] {
          new ParDef("@TokenId",GXType.NChar,80,0) ,
          new ParDef("@TokenFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@TokenFechaExpiracion",GXType.DateTime,8,5) ,
          new ParDef("@usuariosId",GXType.NChar,20,0) ,
          new ParDef("@TokenRequests",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J72", "INSERT INTO [Token]([TokenId], [TokenFechaAlta], [TokenFechaExpiracion], [usuariosId], [TokenRequests]) VALUES(@TokenId, @TokenFechaAlta, @TokenFechaExpiracion, @usuariosId, @TokenRequests)", GxErrorMask.GX_NOMASK,prmP00J72)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
