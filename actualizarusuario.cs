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
   public class actualizarusuario : GXProcedure
   {
      public actualizarusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public actualizarusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref SdtSDTUser aP0_SdtUsuario ,
                           out string aP1_ok )
      {
         this.AV17SdtUsuario = aP0_SdtUsuario;
         this.AV12ok = "" ;
         initialize();
         ExecutePrivate();
         aP0_SdtUsuario=this.AV17SdtUsuario;
         aP1_ok=this.AV12ok;
      }

      public string executeUdp( ref SdtSDTUser aP0_SdtUsuario )
      {
         execute(ref aP0_SdtUsuario, out aP1_ok);
         return AV12ok ;
      }

      public void executeSubmit( ref SdtSDTUser aP0_SdtUsuario ,
                                 out string aP1_ok )
      {
         this.AV17SdtUsuario = aP0_SdtUsuario;
         this.AV12ok = "" ;
         SubmitImpl();
         aP0_SdtUsuario=this.AV17SdtUsuario;
         aP1_ok=this.AV12ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12ok = context.GetMessage( "N", "");
         AV8usuariosId = AV17SdtUsuario.gxTpr_Usuariosid;
         /* Using cursor P009N2 */
         pr_default.execute(0, new Object[] {AV8usuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P009N2_A145usuariosId[0];
            A223usuariosPasw = P009N2_A223usuariosPasw[0];
            GXt_char1 = AV13Enc;
            new pencripta(context ).execute(  AV17SdtUsuario.gxTpr_Usuariospassw, out  GXt_char1) ;
            AV13Enc = GXt_char1;
            A223usuariosPasw = StringUtil.Trim( AV13Enc);
            AV12ok = context.GetMessage( "S", "");
            /* Using cursor P009N3 */
            pr_default.execute(1, new Object[] {A223usuariosPasw, A145usuariosId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("usuarios");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizarusuario",pr_default);
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
         AV8usuariosId = "";
         P009N2_A145usuariosId = new string[] {""} ;
         P009N2_A223usuariosPasw = new string[] {""} ;
         A145usuariosId = "";
         A223usuariosPasw = "";
         AV13Enc = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarusuario__default(),
            new Object[][] {
                new Object[] {
               P009N2_A145usuariosId, P009N2_A223usuariosPasw
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV12ok ;
      private string AV8usuariosId ;
      private string A145usuariosId ;
      private string A223usuariosPasw ;
      private string AV13Enc ;
      private string GXt_char1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTUser AV17SdtUsuario ;
      private SdtSDTUser aP0_SdtUsuario ;
      private IDataStoreProvider pr_default ;
      private string[] P009N2_A145usuariosId ;
      private string[] P009N2_A223usuariosPasw ;
      private string aP1_ok ;
   }

   public class actualizarusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009N2;
          prmP009N2 = new Object[] {
          new ParDef("@AV8usuariosId",GXType.Char,20,0)
          };
          Object[] prmP009N3;
          prmP009N3 = new Object[] {
          new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
          new ParDef("@usuariosId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009N2", "SELECT [usuariosId], [usuariosPasw] FROM [usuarios] WITH (UPDLOCK) WHERE RTRIM(LTRIM(UPPER([usuariosId]))) = RTRIM(LTRIM(UPPER(@AV8usuariosId))) ORDER BY [usuariosId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009N3", "UPDATE [usuarios] SET [usuariosPasw]=@usuariosPasw  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009N3)
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
