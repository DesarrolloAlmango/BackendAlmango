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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_getusersfordiscussionmentions : GXProcedure
   {
      public wwp_getusersfordiscussionmentions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfordiscussionmentions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchTxt ,
                           out string aP1_OptionsJson )
      {
         this.AV14SearchTxt = aP0_SearchTxt;
         this.AV13OptionsJson = "" ;
         initialize();
         ExecutePrivate();
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      public string executeUdp( string aP0_SearchTxt )
      {
         execute(aP0_SearchTxt, out aP1_OptionsJson);
         return AV13OptionsJson ;
      }

      public void executeSubmit( string aP0_SearchTxt ,
                                 out string aP1_OptionsJson )
      {
         this.AV14SearchTxt = aP0_SearchTxt;
         this.AV13OptionsJson = "" ;
         SubmitImpl();
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "AlmangoX");
         AV10MaxOptions = 5;
         AV9CheckDuplicated = false;
         /* Execute user subroutine: 'SEARCH USERS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV12Options.Count < AV10MaxOptions )
         {
            AV9CheckDuplicated = true;
            /* Execute user subroutine: 'SEARCH USERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( AV12Options.Count < AV10MaxOptions )
            {
               AV9CheckDuplicated = true;
               /* Execute user subroutine: 'SEARCH USERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV13OptionsJson = AV12Options.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCH USERS' Routine */
         returnInSub = false;
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         /* Using cursor P00AH2 */
         pr_default.execute(0, new Object[] {lV14SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3WWPUserExtendedEmail = P00AH2_A3WWPUserExtendedEmail[0];
            A2WWPUserExtendedFullName = P00AH2_A2WWPUserExtendedFullName[0];
            A11WWPUserExtendedDeleted = P00AH2_A11WWPUserExtendedDeleted[0];
            A10WWPUserExtendedName = P00AH2_A10WWPUserExtendedName[0];
            A1WWPUserExtendedId = P00AH2_A1WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = P00AH2_A40000WWPUserExtendedPhoto_GXI[0];
            AV8WWPUserExtendedFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A2WWPUserExtendedFullName)) ? A10WWPUserExtendedName : A2WWPUserExtendedFullName);
            AV11Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
            AV11Option.gxTpr_Id = A1WWPUserExtendedId;
            AV11Option.gxTpr_Displayname = AV8WWPUserExtendedFullName;
            AV11Option.gxTpr_Text.Add(AV8WWPUserExtendedFullName, 0);
            AV11Option.gxTpr_Text.Add(A3WWPUserExtendedEmail, 0);
            AV11Option.gxTpr_Text.Add(A40000WWPUserExtendedPhoto_GXI, 0);
            if ( ! AV9CheckDuplicated || ! StringUtil.Contains( AV12Options.ToJSonString(false), AV11Option.ToJSonString(false, true)) )
            {
               AV12Options.Add(AV11Option, 0);
            }
            if ( AV12Options.Count > AV10MaxOptions )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV13OptionsJson = "";
         AV12Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "AlmangoX");
         lV14SearchTxt = "";
         P00AH2_A3WWPUserExtendedEmail = new string[] {""} ;
         P00AH2_A2WWPUserExtendedFullName = new string[] {""} ;
         P00AH2_A11WWPUserExtendedDeleted = new bool[] {false} ;
         P00AH2_A10WWPUserExtendedName = new string[] {""} ;
         P00AH2_A1WWPUserExtendedId = new string[] {""} ;
         P00AH2_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         A3WWPUserExtendedEmail = "";
         A2WWPUserExtendedFullName = "";
         A10WWPUserExtendedName = "";
         A1WWPUserExtendedId = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         AV8WWPUserExtendedFullName = "";
         AV11Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions__default(),
            new Object[][] {
                new Object[] {
               P00AH2_A3WWPUserExtendedEmail, P00AH2_A2WWPUserExtendedFullName, P00AH2_A11WWPUserExtendedDeleted, P00AH2_A10WWPUserExtendedName, P00AH2_A1WWPUserExtendedId, P00AH2_A40000WWPUserExtendedPhoto_GXI
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10MaxOptions ;
      private string A1WWPUserExtendedId ;
      private bool AV9CheckDuplicated ;
      private bool returnInSub ;
      private bool A11WWPUserExtendedDeleted ;
      private string AV13OptionsJson ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A3WWPUserExtendedEmail ;
      private string A2WWPUserExtendedFullName ;
      private string A10WWPUserExtendedName ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string AV8WWPUserExtendedFullName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV12Options ;
      private IDataStoreProvider pr_default ;
      private string[] P00AH2_A3WWPUserExtendedEmail ;
      private string[] P00AH2_A2WWPUserExtendedFullName ;
      private bool[] P00AH2_A11WWPUserExtendedDeleted ;
      private string[] P00AH2_A10WWPUserExtendedName ;
      private string[] P00AH2_A1WWPUserExtendedId ;
      private string[] P00AH2_A40000WWPUserExtendedPhoto_GXI ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem AV11Option ;
      private string aP1_OptionsJson ;
   }

   public class wwp_getusersfordiscussionmentions__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AH2;
          prmP00AH2 = new Object[] {
          new ParDef("@lV14SearchTxt",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AH2", "SELECT [WWPUserExtendedEmail], [WWPUserExtendedFullName], [WWPUserExtendedDeleted], [WWPUserExtendedName], [WWPUserExtendedId], [WWPUserExtendedPhoto_GXI] FROM [WWP_UserExtended] WHERE (Not ( [WWPUserExtendedDeleted] = 1)) AND ([WWPUserExtendedFullName] like '%' + @lV14SearchTxt or [WWPUserExtendedEmail] like @lV14SearchTxt) ORDER BY [WWPUserExtendedId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class wwp_getusersfordiscussionmentions_services : GxRestService
 {
    [OperationContract(Name = "WWP_GetUsersForDiscussionMentions" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string SearchTxt ,
                         out string OptionsJson )
    {
       OptionsJson = "" ;
       try
       {
          if ( ! ProcessHeaders("wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions") )
          {
             return  ;
          }
          wwp_getusersfordiscussionmentions worker = new wwp_getusersfordiscussionmentions(context);
          worker.IsMain = RunAsMain ;
          worker.execute(SearchTxt,out OptionsJson );
          worker.cleanup( );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}
