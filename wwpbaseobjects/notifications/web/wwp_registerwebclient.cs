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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_registerwebclient : GXProcedure
   {
      public wwp_registerwebclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_registerwebclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientId ,
                           short aP1_BrowserId ,
                           string aP2_BrowserVersion ,
                           string aP3_UserGUID )
      {
         this.AV10ClientId = aP0_ClientId;
         this.AV8BrowserId = aP1_BrowserId;
         this.AV9BrowserVersion = aP2_BrowserVersion;
         this.AV12UserGUID = aP3_UserGUID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 short aP1_BrowserId ,
                                 string aP2_BrowserVersion ,
                                 string aP3_UserGUID )
      {
         this.AV10ClientId = aP0_ClientId;
         this.AV8BrowserId = aP1_BrowserId;
         this.AV9BrowserVersion = aP2_BrowserVersion;
         this.AV12UserGUID = aP3_UserGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Begin Web Client Registration") ;
         if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV12UserGUID) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  StringUtil.Format( "Creating User Extended %1...", AV12UserGUID, "", "", "", "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended(context ).execute(  AV12UserGUID,  "") ;
         }
         AV14GXLvl6 = 0;
         /* Using cursor P00392 */
         pr_default.execute(0, new Object[] {AV10ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A57WWPWebClientId = P00392_A57WWPWebClientId[0];
            A58WWPWebClientBrowserId = P00392_A58WWPWebClientBrowserId[0];
            A59WWPWebClientBrowserVersion = P00392_A59WWPWebClientBrowserVersion[0];
            A61WWPWebClientLastRegistered = P00392_A61WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = P00392_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P00392_n1WWPUserExtendedId[0];
            AV14GXLvl6 = 1;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Updating Web Client") ;
            A58WWPWebClientBrowserId = AV8BrowserId;
            A59WWPWebClientBrowserVersion = AV9BrowserVersion;
            A61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A1WWPUserExtendedId = AV12UserGUID;
            n1WWPUserExtendedId = false;
            /* Using cursor P00393 */
            pr_default.execute(1, new Object[] {A58WWPWebClientBrowserId, A59WWPWebClientBrowserVersion, A61WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId, A57WWPWebClientId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl6 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Creating Web Client") ;
            /*
               INSERT RECORD ON TABLE WWP_WebClient

            */
            A57WWPWebClientId = AV10ClientId;
            A58WWPWebClientBrowserId = AV8BrowserId;
            A59WWPWebClientBrowserVersion = AV9BrowserVersion;
            A60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A1WWPUserExtendedId = AV12UserGUID;
            n1WWPUserExtendedId = false;
            /* Using cursor P00394 */
            pr_default.execute(2, new Object[] {A57WWPWebClientId, A58WWPWebClientBrowserId, A59WWPWebClientBrowserVersion, A60WWPWebClientFirstRegistered, A61WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            if ( (pr_default.getStatus(2) == 1) )
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
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV13Pgmname,  "Completed Web Client Registration") ;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_registerwebclient",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13Pgmname = "";
         P00392_A57WWPWebClientId = new string[] {""} ;
         P00392_A58WWPWebClientBrowserId = new short[1] ;
         P00392_A59WWPWebClientBrowserVersion = new string[] {""} ;
         P00392_A61WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         P00392_A1WWPUserExtendedId = new string[] {""} ;
         P00392_n1WWPUserExtendedId = new bool[] {false} ;
         A57WWPWebClientId = "";
         A59WWPWebClientBrowserVersion = "";
         A61WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A1WWPUserExtendedId = "";
         A60WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient__default(),
            new Object[][] {
                new Object[] {
               P00392_A57WWPWebClientId, P00392_A58WWPWebClientBrowserId, P00392_A59WWPWebClientBrowserVersion, P00392_A61WWPWebClientLastRegistered, P00392_A1WWPUserExtendedId, P00392_n1WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         AV13Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         /* GeneXus formulas. */
         AV13Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
      }

      private short AV8BrowserId ;
      private short AV14GXLvl6 ;
      private short A58WWPWebClientBrowserId ;
      private int GX_INS13 ;
      private string AV10ClientId ;
      private string AV12UserGUID ;
      private string AV13Pgmname ;
      private string A57WWPWebClientId ;
      private string A1WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A61WWPWebClientLastRegistered ;
      private DateTime A60WWPWebClientFirstRegistered ;
      private bool n1WWPUserExtendedId ;
      private string AV9BrowserVersion ;
      private string A59WWPWebClientBrowserVersion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00392_A57WWPWebClientId ;
      private short[] P00392_A58WWPWebClientBrowserId ;
      private string[] P00392_A59WWPWebClientBrowserVersion ;
      private DateTime[] P00392_A61WWPWebClientLastRegistered ;
      private string[] P00392_A1WWPUserExtendedId ;
      private bool[] P00392_n1WWPUserExtendedId ;
   }

   public class wwp_registerwebclient__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("@AV10ClientId",GXType.NChar,100,0)
          };
          Object[] prmP00393;
          prmP00393 = new Object[] {
          new ParDef("@WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("@WWPWebClientBrowserVersion",GXType.NVarChar,2097152,0) ,
          new ParDef("@WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
          new ParDef("@WWPWebClientId",GXType.NChar,100,0)
          };
          Object[] prmP00394;
          prmP00394 = new Object[] {
          new ParDef("@WWPWebClientId",GXType.NChar,100,0) ,
          new ParDef("@WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("@WWPWebClientBrowserVersion",GXType.NVarChar,2097152,0) ,
          new ParDef("@WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
          new ParDef("@WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WITH (UPDLOCK) WHERE [WWPWebClientId] = @AV10ClientId ORDER BY [WWPWebClientId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00393", "UPDATE [WWP_WebClient] SET [WWPWebClientBrowserId]=@WWPWebClientBrowserId, [WWPWebClientBrowserVersion]=@WWPWebClientBrowserVersion, [WWPWebClientLastRegistered]=@WWPWebClientLastRegistered, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00393)
             ,new CursorDef("P00394", "INSERT INTO [WWP_WebClient]([WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId]) VALUES(@WWPWebClientId, @WWPWebClientBrowserId, @WWPWebClientBrowserVersion, @WWPWebClientFirstRegistered, @WWPWebClientLastRegistered, @WWPUserExtendedId)", GxErrorMask.GX_NOMASK,prmP00394)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
