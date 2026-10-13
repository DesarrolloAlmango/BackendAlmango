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
   public class setusuariospasw : GXProcedure
   {
      public setusuariospasw( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public setusuariospasw( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_PasswordSinEncritpar )
      {
         this.AV9usuariosId = aP0_usuariosId;
         this.AV11PasswordSinEncritpar = aP1_PasswordSinEncritpar;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_PasswordSinEncritpar )
      {
         this.AV9usuariosId = aP0_usuariosId;
         this.AV11PasswordSinEncritpar = aP1_PasswordSinEncritpar;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new pencripta(context ).execute(  StringUtil.Trim( AV11PasswordSinEncritpar), out  AV10usuariosPasw) ;
         AV8usuarios.Load(AV9usuariosId);
         AV8usuarios.gxTpr_Usuariospasw = StringUtil.Trim( AV10usuariosPasw);
         AV8usuarios.Save();
         context.CommitDataStores("setusuariospasw",pr_default);
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
         AV10usuariosPasw = "";
         AV8usuarios = new Sdtusuarios(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.setusuariospasw__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.setusuariospasw__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV9usuariosId ;
      private string AV11PasswordSinEncritpar ;
      private string AV10usuariosPasw ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Sdtusuarios AV8usuarios ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class setusuariospasw__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class setusuariospasw__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
