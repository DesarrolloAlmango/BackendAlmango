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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class enviarmail : GXProcedure
   {
      public enviarmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public enviarmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref GeneXus.Mail.GXSMTPSession aP0_SMTPSession ,
                           ref GeneXus.Mail.GXMailMessage aP1_MailMessage ,
                           ref short aP2_ErrorCode ,
                           ref string aP3_ErrorDescription )
      {
         this.AV8SMTPSession = aP0_SMTPSession;
         this.AV9MailMessage = aP1_MailMessage;
         this.AV10ErrorCode = aP2_ErrorCode;
         this.AV11ErrorDescription = aP3_ErrorDescription;
         initialize();
         ExecutePrivate();
         aP0_SMTPSession=this.AV8SMTPSession;
         aP1_MailMessage=this.AV9MailMessage;
         aP2_ErrorCode=this.AV10ErrorCode;
         aP3_ErrorDescription=this.AV11ErrorDescription;
      }

      public string executeUdp( ref GeneXus.Mail.GXSMTPSession aP0_SMTPSession ,
                                ref GeneXus.Mail.GXMailMessage aP1_MailMessage ,
                                ref short aP2_ErrorCode )
      {
         execute(ref aP0_SMTPSession, ref aP1_MailMessage, ref aP2_ErrorCode, ref aP3_ErrorDescription);
         return AV11ErrorDescription ;
      }

      public void executeSubmit( ref GeneXus.Mail.GXSMTPSession aP0_SMTPSession ,
                                 ref GeneXus.Mail.GXMailMessage aP1_MailMessage ,
                                 ref short aP2_ErrorCode ,
                                 ref string aP3_ErrorDescription )
      {
         this.AV8SMTPSession = aP0_SMTPSession;
         this.AV9MailMessage = aP1_MailMessage;
         this.AV10ErrorCode = aP2_ErrorCode;
         this.AV11ErrorDescription = aP3_ErrorDescription;
         SubmitImpl();
         aP0_SMTPSession=this.AV8SMTPSession;
         aP1_MailMessage=this.AV9MailMessage;
         aP2_ErrorCode=this.AV10ErrorCode;
         aP3_ErrorDescription=this.AV11ErrorDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ErrorCode = 0;
         AV11ErrorDescription = "";
         AV8SMTPSession.Login();
         AV12Plog = new SdtPlog(context);
         AV12Plog.gxTpr_Plogmsg = StringUtil.Str( (decimal)(AV8SMTPSession.ErrCode), 10, 2);
         AV12Plog.Insert();
         context.CommitDataStores("enviarmail",pr_default);
         if ( AV8SMTPSession.ErrCode != 0 )
         {
            context.StatusMessage( AV8SMTPSession.ErrDescription );
            AV10ErrorCode = AV8SMTPSession.ErrCode;
            AV11ErrorDescription = AV8SMTPSession.ErrDescription;
            cleanup();
            if (true) return;
         }
         context.StatusMessage( context.GetMessage( "Enviando mensaje...", "") );
         AV8SMTPSession.Send(AV9MailMessage);
         AV10ErrorCode = AV8SMTPSession.ErrCode;
         AV11ErrorDescription = AV8SMTPSession.ErrDescription;
         if ( AV8SMTPSession.ErrCode != 0 )
         {
            context.StatusMessage( AV8SMTPSession.ErrDescription );
         }
         else
         {
            AV11ErrorDescription = context.GetMessage( "Mensaje enviado con éxito.", "");
            context.StatusMessage( AV11ErrorDescription );
         }
         AV8SMTPSession.Logout();
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
         AV12Plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.enviarmail__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enviarmail__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10ErrorCode ;
      private string AV11ErrorDescription ;
      private GeneXus.Mail.GXMailMessage AV9MailMessage ;
      private GeneXus.Mail.GXSMTPSession AV8SMTPSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Mail.GXSMTPSession aP0_SMTPSession ;
      private GeneXus.Mail.GXMailMessage aP1_MailMessage ;
      private short aP2_ErrorCode ;
      private string aP3_ErrorDescription ;
      private SdtPlog AV12Plog ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class enviarmail__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class enviarmail__default : DataStoreHelperBase, IDataStoreHelper
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
