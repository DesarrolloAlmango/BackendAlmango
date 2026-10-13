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
   public class saveuserkeyvalue : GXProcedure
   {
      public saveuserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public saveuserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           string aP1_UserCustomizationsValue )
      {
         this.AV18UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV19UserCustomizationsValue = aP1_UserCustomizationsValue;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 string aP1_UserCustomizationsValue )
      {
         this.AV18UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV19UserCustomizationsValue = aP1_UserCustomizationsValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19UserCustomizationsValue)) )
         {
            AV17Session.Remove(AV18UserCustomizationsKey);
         }
         else
         {
            AV17Session.Set(AV18UserCustomizationsKey, AV19UserCustomizationsValue);
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV21WWPContext) ;
         AV20UserCustomizations.Load((int)(AV21WWPContext.gxTpr_Userid), AV18UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19UserCustomizationsValue)) )
         {
            if ( AV20UserCustomizations.Success() )
            {
               AV20UserCustomizations.Delete();
               context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
            }
         }
         else
         {
            if ( ! AV20UserCustomizations.Success() )
            {
               AV20UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
               AV20UserCustomizations.gxTpr_Usercustomizationsid = (int)(AV21WWPContext.gxTpr_Userid);
               AV20UserCustomizations.gxTpr_Usercustomizationskey = AV18UserCustomizationsKey;
            }
            AV20UserCustomizations.gxTpr_Usercustomizationsvalue = AV19UserCustomizationsValue;
            AV20UserCustomizations.Save();
            context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
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
         AV17Session = context.GetSession();
         AV21WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV19UserCustomizationsValue ;
      private string AV18UserCustomizationsKey ;
      private IGxSession AV17Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV21WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV20UserCustomizations ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class saveuserkeyvalue__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class saveuserkeyvalue__default : DataStoreHelperBase, IDataStoreHelper
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
