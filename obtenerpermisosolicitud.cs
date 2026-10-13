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
   public class obtenerpermisosolicitud : GXProcedure
   {
      public obtenerpermisosolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerpermisosolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out bool aP1_Permiso )
      {
         this.AV10SolicitudesId = aP0_SolicitudesId;
         this.AV9Permiso = false ;
         initialize();
         ExecutePrivate();
         aP1_Permiso=this.AV9Permiso;
      }

      public bool executeUdp( long aP0_SolicitudesId )
      {
         execute(aP0_SolicitudesId, out aP1_Permiso);
         return AV9Permiso ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out bool aP1_Permiso )
      {
         this.AV10SolicitudesId = aP0_SolicitudesId;
         this.AV9Permiso = false ;
         SubmitImpl();
         aP1_Permiso=this.AV9Permiso;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Permiso = false;
         AV11Hora = DateTimeUtil.ServerNow( context, pr_default);
         /* Using cursor P00II2 */
         pr_default.execute(0, new Object[] {AV10SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A726PlogMsg = P00II2_A726PlogMsg[0];
            A727PlogPgm = P00II2_A727PlogPgm[0];
            A725PlogId = P00II2_A725PlogId[0];
            AV12HoraLimite = context.localUtil.CToT( StringUtil.Trim( A727PlogPgm), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            if ( AV11Hora < AV12HoraLimite )
            {
               AV9Permiso = true;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13Plog = new SdtPlog(context);
         AV13Plog.gxTpr_Plogmsg = context.localUtil.TToC( AV11Hora, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
         AV13Plog.gxTpr_Plogpgm = context.localUtil.TToC( AV12HoraLimite, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
         AV13Plog.Insert();
         context.CommitDataStores("obtenerpermisosolicitud",pr_default);
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
         AV11Hora = (DateTime)(DateTime.MinValue);
         P00II2_A726PlogMsg = new string[] {""} ;
         P00II2_A727PlogPgm = new string[] {""} ;
         P00II2_A725PlogId = new short[1] ;
         A726PlogMsg = "";
         A727PlogPgm = "";
         AV12HoraLimite = (DateTime)(DateTime.MinValue);
         AV13Plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.obtenerpermisosolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerpermisosolicitud__default(),
            new Object[][] {
                new Object[] {
               P00II2_A726PlogMsg, P00II2_A727PlogPgm, P00II2_A725PlogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A725PlogId ;
      private long AV10SolicitudesId ;
      private DateTime AV11Hora ;
      private DateTime AV12HoraLimite ;
      private bool AV9Permiso ;
      private string A726PlogMsg ;
      private string A727PlogPgm ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00II2_A726PlogMsg ;
      private string[] P00II2_A727PlogPgm ;
      private short[] P00II2_A725PlogId ;
      private SdtPlog AV13Plog ;
      private bool aP1_Permiso ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class obtenerpermisosolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class obtenerpermisosolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00II2;
        prmP00II2 = new Object[] {
        new ParDef("@AV10SolicitudesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00II2", "SELECT TOP 1 [PlogMsg], [PlogPgm], [PlogId] FROM [Plog] WHERE RTRIM(LTRIM([PlogMsg])) = RTRIM(LTRIM(CONVERT( char(18), CAST(@AV10SolicitudesId AS decimal(18,0))))) ORDER BY [PlogId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00II2,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
  }

}

}
