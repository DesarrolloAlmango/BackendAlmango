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
   public class eusertoken : GXProcedure
   {
      public eusertoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public eusertoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuariosId ,
                           out bool aP1_oK )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9oK = false ;
         initialize();
         ExecutePrivate();
         aP1_oK=this.AV9oK;
      }

      public bool executeUdp( string aP0_UsuariosId )
      {
         execute(aP0_UsuariosId, out aP1_oK);
         return AV9oK ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 out bool aP1_oK )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9oK = false ;
         SubmitImpl();
         aP1_oK=this.AV9oK;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8UsuariosId)) )
         {
            AV9oK = false;
            cleanup();
            if (true) return;
         }
         /* Optimized DELETE. */
         /* Using cursor P00K62 */
         pr_default.execute(0, new Object[] {AV8UsuariosId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Token");
         /* End optimized DELETE. */
         AV9oK = true;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.eusertoken",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.eusertoken__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8UsuariosId ;
      private bool AV9oK ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP1_oK ;
   }

   public class eusertoken__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K62;
          prmP00K62 = new Object[] {
          new ParDef("@AV8UsuariosId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K62", "DELETE FROM [Token]  WHERE RTRIM(LTRIM([usuariosId])) = RTRIM(LTRIM(@AV8UsuariosId))", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00K62)
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
