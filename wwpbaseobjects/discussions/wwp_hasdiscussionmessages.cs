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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_hasdiscussionmessages : GXProcedure
   {
      public wwp_hasdiscussionmessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hasdiscussionmessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           string aP1_WWPDiscussionMessageEntityRecordId ,
                           out bool aP2_HasDiscussionMessages )
      {
         this.AV10WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPDiscussionMessageEntityRecordId = aP1_WWPDiscussionMessageEntityRecordId;
         this.AV8HasDiscussionMessages = false ;
         initialize();
         ExecutePrivate();
         aP2_HasDiscussionMessages=this.AV8HasDiscussionMessages;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              string aP1_WWPDiscussionMessageEntityRecordId )
      {
         execute(aP0_WWPEntityName, aP1_WWPDiscussionMessageEntityRecordId, out aP2_HasDiscussionMessages);
         return AV8HasDiscussionMessages ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 string aP1_WWPDiscussionMessageEntityRecordId ,
                                 out bool aP2_HasDiscussionMessages )
      {
         this.AV10WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPDiscussionMessageEntityRecordId = aP1_WWPDiscussionMessageEntityRecordId;
         this.AV8HasDiscussionMessages = false ;
         SubmitImpl();
         aP2_HasDiscussionMessages=this.AV8HasDiscussionMessages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HasDiscussionMessages = false;
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV10WWPEntityName);
         /* Using cursor P00AI2 */
         pr_default.execute(0, new Object[] {AV12Udparg1, AV9WWPDiscussionMessageEntityRecordId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A539WWPDiscussionMessageThreadId = P00AI2_A539WWPDiscussionMessageThreadId[0];
            n539WWPDiscussionMessageThreadId = P00AI2_n539WWPDiscussionMessageThreadId[0];
            A545WWPDiscussionMessageEntityReco = P00AI2_A545WWPDiscussionMessageEntityReco[0];
            A29WWPEntityId = P00AI2_A29WWPEntityId[0];
            A540WWPDiscussionMessageId = P00AI2_A540WWPDiscussionMessageId[0];
            AV8HasDiscussionMessages = true;
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
         P00AI2_A539WWPDiscussionMessageThreadId = new long[1] ;
         P00AI2_n539WWPDiscussionMessageThreadId = new bool[] {false} ;
         P00AI2_A545WWPDiscussionMessageEntityReco = new string[] {""} ;
         P00AI2_A29WWPEntityId = new long[1] ;
         P00AI2_A540WWPDiscussionMessageId = new long[1] ;
         A545WWPDiscussionMessageEntityReco = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages__default(),
            new Object[][] {
                new Object[] {
               P00AI2_A539WWPDiscussionMessageThreadId, P00AI2_n539WWPDiscussionMessageThreadId, P00AI2_A545WWPDiscussionMessageEntityReco, P00AI2_A29WWPEntityId, P00AI2_A540WWPDiscussionMessageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12Udparg1 ;
      private long A539WWPDiscussionMessageThreadId ;
      private long A29WWPEntityId ;
      private long A540WWPDiscussionMessageId ;
      private bool AV8HasDiscussionMessages ;
      private bool n539WWPDiscussionMessageThreadId ;
      private string AV10WWPEntityName ;
      private string AV9WWPDiscussionMessageEntityRecordId ;
      private string A545WWPDiscussionMessageEntityReco ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AI2_A539WWPDiscussionMessageThreadId ;
      private bool[] P00AI2_n539WWPDiscussionMessageThreadId ;
      private string[] P00AI2_A545WWPDiscussionMessageEntityReco ;
      private long[] P00AI2_A29WWPEntityId ;
      private long[] P00AI2_A540WWPDiscussionMessageId ;
      private bool aP2_HasDiscussionMessages ;
   }

   public class wwp_hasdiscussionmessages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AI2;
          prmP00AI2 = new Object[] {
          new ParDef("@AV12Udparg1",GXType.Decimal,10,0) ,
          new ParDef("@AV9WWPDiscussionMessageEntityRecordId",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AI2", "SELECT TOP 1 [WWPDiscussionMessageThreadId], [WWPDiscussionMessageEntityReco], [WWPEntityId], [WWPDiscussionMessageId] FROM [WWP_DiscussionMessage] WHERE ([WWPEntityId] = @AV12Udparg1) AND ([WWPDiscussionMessageThreadId] IS NULL or ([WWPDiscussionMessageThreadId] = convert(int, 0))) AND ([WWPDiscussionMessageEntityReco] = @AV9WWPDiscussionMessageEntityRecordId) ORDER BY [WWPEntityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
