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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_createuserextended : GXProcedure
   {
      public wwp_createuserextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createuserextended( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           string aP1_PhotURL )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9PhotURL = aP1_PhotURL;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 string aP1_PhotURL )
      {
         this.AV10WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV9PhotURL = aP1_PhotURL;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV8WWPUserExtended.gxTpr_Wwpuserextendedid = AV10WWPUserExtendedId;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9PhotURL)) )
         {
            AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto = AV9PhotURL;
            AV8WWPUserExtended.gxTpr_Wwpuserextendedphoto_gxi = GXDbFile.PathToUrl( AV9PhotURL, context);
         }
         AV8WWPUserExtended.gxTpr_Wwpuserextendeddesktopnotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedemainotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedsmsnotif = true;
         AV8WWPUserExtended.gxTpr_Wwpuserextendedmobilenotif = true;
         AV8WWPUserExtended.Save();
         if ( AV8WWPUserExtended.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.wwp_createuserextended",pr_default);
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV11Pgmname,  "Create Extended User: "+AV8WWPUserExtended.GetMessages().ToJSonString(false)) ;
         }
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
         AV8WWPUserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV11Pgmname = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_createuserextended__default(),
            new Object[][] {
            }
         );
         AV11Pgmname = "WWPBaseObjects.WWP_CreateUserExtended";
         /* GeneXus formulas. */
         AV11Pgmname = "WWPBaseObjects.WWP_CreateUserExtended";
      }

      private string AV10WWPUserExtendedId ;
      private string AV11Pgmname ;
      private string AV9PhotURL ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV8WWPUserExtended ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_createuserextended__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_createuserextended__default : DataStoreHelperBase, IDataStoreHelper
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
