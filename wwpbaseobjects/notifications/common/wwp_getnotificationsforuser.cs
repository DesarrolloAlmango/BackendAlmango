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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationsforuser : GXProcedure
   {
      public wwp_getnotificationsforuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationsforuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "AlmangoX") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13Udparg3 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P00092 */
         pr_default.execute(0, new Object[] {AV13Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A91WWPNotificationIsRead = P00092_A91WWPNotificationIsRead[0];
            A1WWPUserExtendedId = P00092_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = P00092_n1WWPUserExtendedId[0];
            A31WWPNotificationId = P00092_A31WWPNotificationId[0];
            A85WWPNotificationIcon = P00092_A85WWPNotificationIcon[0];
            A86WWPNotificationTitle = P00092_A86WWPNotificationTitle[0];
            A87WWPNotificationShortDescriptio = P00092_A87WWPNotificationShortDescriptio[0];
            A88WWPNotificationLink = P00092_A88WWPNotificationLink[0];
            A33WWPNotificationCreated = P00092_A33WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = A31WWPNotificationId;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A85WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A86WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A87WWPNotificationShortDescriptio;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A33WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A88WWPNotificationLink;
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
         AV13Udparg3 = "";
         P00092_A91WWPNotificationIsRead = new bool[] {false} ;
         P00092_A1WWPUserExtendedId = new string[] {""} ;
         P00092_n1WWPUserExtendedId = new bool[] {false} ;
         P00092_A31WWPNotificationId = new long[1] ;
         P00092_A85WWPNotificationIcon = new string[] {""} ;
         P00092_A86WWPNotificationTitle = new string[] {""} ;
         P00092_A87WWPNotificationShortDescriptio = new string[] {""} ;
         P00092_A88WWPNotificationLink = new string[] {""} ;
         P00092_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A1WWPUserExtendedId = "";
         A85WWPNotificationIcon = "";
         A86WWPNotificationTitle = "";
         A87WWPNotificationShortDescriptio = "";
         A88WWPNotificationLink = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser__default(),
            new Object[][] {
                new Object[] {
               P00092_A91WWPNotificationIsRead, P00092_A1WWPUserExtendedId, P00092_n1WWPUserExtendedId, P00092_A31WWPNotificationId, P00092_A85WWPNotificationIcon, P00092_A86WWPNotificationTitle, P00092_A87WWPNotificationShortDescriptio, P00092_A88WWPNotificationLink, P00092_A33WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A31WWPNotificationId ;
      private string AV13Udparg3 ;
      private string A1WWPUserExtendedId ;
      private DateTime A33WWPNotificationCreated ;
      private bool A91WWPNotificationIsRead ;
      private bool n1WWPUserExtendedId ;
      private string A85WWPNotificationIcon ;
      private string A86WWPNotificationTitle ;
      private string A87WWPNotificationShortDescriptio ;
      private string A88WWPNotificationLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P00092_A91WWPNotificationIsRead ;
      private string[] P00092_A1WWPUserExtendedId ;
      private bool[] P00092_n1WWPUserExtendedId ;
      private long[] P00092_A31WWPNotificationId ;
      private string[] P00092_A85WWPNotificationIcon ;
      private string[] P00092_A86WWPNotificationTitle ;
      private string[] P00092_A87WWPNotificationShortDescriptio ;
      private string[] P00092_A88WWPNotificationLink ;
      private DateTime[] P00092_A33WWPNotificationCreated ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
   }

   public class wwp_getnotificationsforuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00092;
          prmP00092 = new Object[] {
          new ParDef("@AV13Udparg3",GXType.NChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00092", "SELECT [WWPNotificationIsRead], [WWPUserExtendedId], [WWPNotificationId], [WWPNotificationIcon], [WWPNotificationTitle], [WWPNotificationShortDescriptio], [WWPNotificationLink], [WWPNotificationCreated] FROM [WWP_Notification] WHERE (Not [WWPNotificationIsRead] = 1) AND ([WWPUserExtendedId] = @AV13Udparg3) ORDER BY [WWPNotificationCreated] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00092,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
                return;
       }
    }

 }

}
