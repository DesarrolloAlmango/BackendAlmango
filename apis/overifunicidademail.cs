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
   public class overifunicidademail : GXProcedure
   {
      public overifunicidademail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public overifunicidademail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuariosId ,
                           string aP1_mail ,
                           out bool aP2_Existe )
      {
         this.AV10UsuariosId = aP0_UsuariosId;
         this.AV9mail = aP1_mail;
         this.AV8Existe = false ;
         initialize();
         ExecutePrivate();
         aP2_Existe=this.AV8Existe;
      }

      public bool executeUdp( string aP0_UsuariosId ,
                              string aP1_mail )
      {
         execute(aP0_UsuariosId, aP1_mail, out aP2_Existe);
         return AV8Existe ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 string aP1_mail ,
                                 out bool aP2_Existe )
      {
         this.AV10UsuariosId = aP0_UsuariosId;
         this.AV9mail = aP1_mail;
         this.AV8Existe = false ;
         SubmitImpl();
         aP2_Existe=this.AV8Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Existe = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9mail)) || String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuariosId)) )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00K42 */
         pr_default.execute(0, new Object[] {AV9mail, AV10UsuariosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A145usuariosId = P00K42_A145usuariosId[0];
            A224usuariosCorreo = P00K42_A224usuariosCorreo[0];
            AV8Existe = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00K42_A145usuariosId = new string[] {""} ;
         P00K42_A224usuariosCorreo = new string[] {""} ;
         A145usuariosId = "";
         A224usuariosCorreo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.overifunicidademail__default(),
            new Object[][] {
                new Object[] {
               P00K42_A145usuariosId, P00K42_A224usuariosCorreo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV10UsuariosId ;
      private string A145usuariosId ;
      private bool AV8Existe ;
      private string AV9mail ;
      private string A224usuariosCorreo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00K42_A145usuariosId ;
      private string[] P00K42_A224usuariosCorreo ;
      private bool aP2_Existe ;
   }

   public class overifunicidademail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K42;
          prmP00K42 = new Object[] {
          new ParDef("@AV9mail",GXType.VarChar,100,0) ,
          new ParDef("@AV10UsuariosId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K42", "SELECT TOP 1 [usuariosId], [usuariosCorreo] FROM [usuarios] WHERE RTRIM(LTRIM(UPPER([usuariosCorreo]))) = RTRIM(LTRIM(UPPER(@AV9mail))) and RTRIM(LTRIM([usuariosId])) <> RTRIM(LTRIM(@AV10UsuariosId)) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K42,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
