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
   public class aautmotivos : GXProcedure
   {
      public aautmotivos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aautmotivos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE Motivo

         */
         A616MotivoNombre = context.GetMessage( "CANCELACION", "");
         A618MotivoTipo = "INC";
         n618MotivoTipo = false;
         /* Using cursor P00B42 */
         pr_default.execute(0, new Object[] {A616MotivoNombre, n618MotivoTipo, A618MotivoTipo});
         A604MotivoId = P00B42_A604MotivoId[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Motivo");
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
         /*
            INSERT RECORD ON TABLE Motivo

         */
         A616MotivoNombre = context.GetMessage( "MODIFICACION", "");
         A618MotivoTipo = "INC";
         n618MotivoTipo = false;
         /* Using cursor P00B43 */
         pr_default.execute(1, new Object[] {A616MotivoNombre, n618MotivoTipo, A618MotivoTipo});
         A604MotivoId = P00B43_A604MotivoId[0];
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Motivo");
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
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aautmotivos",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A616MotivoNombre = "";
         A618MotivoTipo = "";
         P00B42_A604MotivoId = new long[1] ;
         Gx_emsg = "";
         P00B43_A604MotivoId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aautmotivos__default(),
            new Object[][] {
                new Object[] {
               P00B42_A604MotivoId
               }
               , new Object[] {
               P00B43_A604MotivoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS91 ;
      private long A604MotivoId ;
      private string A616MotivoNombre ;
      private string A618MotivoTipo ;
      private string Gx_emsg ;
      private bool n618MotivoTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B42_A604MotivoId ;
      private long[] P00B43_A604MotivoId ;
   }

   public class aautmotivos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B42;
          prmP00B42 = new Object[] {
          new ParDef("@MotivoNombre",GXType.NChar,80,0) ,
          new ParDef("@MotivoTipo",GXType.NChar,3,0){Nullable=true}
          };
          Object[] prmP00B43;
          prmP00B43 = new Object[] {
          new ParDef("@MotivoNombre",GXType.NChar,80,0) ,
          new ParDef("@MotivoTipo",GXType.NChar,3,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00B42", "INSERT INTO [Motivo]([MotivoNombre], [MotivoTipo]) VALUES(@MotivoNombre, @MotivoTipo); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B43", "INSERT INTO [Motivo]([MotivoNombre], [MotivoTipo]) VALUES(@MotivoNombre, @MotivoTipo); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00B43,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
