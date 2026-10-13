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
   public class tokenupdatemudanza : GXProcedure
   {
      public tokenupdatemudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tokenupdatemudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesID )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Hora = DateTimeUtil.ServerNow( context, pr_default);
         AV9Hora = DateTimeUtil.TAdd( AV9Hora, 60*(2));
         /*
            INSERT RECORD ON TABLE Plog

         */
         A726PlogMsg = StringUtil.Str( (decimal)(AV8SolicitudesID), 18, 0);
         A727PlogPgm = context.localUtil.TToC( AV9Hora, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
         /* Using cursor P00IH2 */
         pr_default.execute(0, new Object[] {A726PlogMsg, A727PlogPgm});
         A725PlogId = P00IH2_A725PlogId[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Plog");
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
         context.CommitDataStores("tokenupdatemudanza",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Hora = (DateTime)(DateTime.MinValue);
         A726PlogMsg = "";
         A727PlogPgm = "";
         P00IH2_A725PlogId = new short[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tokenupdatemudanza__default(),
            new Object[][] {
                new Object[] {
               P00IH2_A725PlogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A725PlogId ;
      private int GX_INS117 ;
      private long AV8SolicitudesID ;
      private string Gx_emsg ;
      private DateTime AV9Hora ;
      private string A726PlogMsg ;
      private string A727PlogPgm ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00IH2_A725PlogId ;
   }

   public class tokenupdatemudanza__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00IH2;
          prmP00IH2 = new Object[] {
          new ParDef("@PlogMsg",GXType.NVarChar,2097152,0) ,
          new ParDef("@PlogPgm",GXType.NVarChar,2097152,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IH2", "INSERT INTO [Plog]([PlogMsg], [PlogPgm]) VALUES(@PlogMsg, @PlogPgm); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00IH2,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
