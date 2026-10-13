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
   public class posmtpsession : GXProcedure
   {
      public posmtpsession( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public posmtpsession( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_MailId ,
                           ref GeneXus.Mail.GXSMTPSession aP1_SMTPSession )
      {
         this.AV10MailId = aP0_MailId;
         this.AV9SMTPSession = aP1_SMTPSession;
         initialize();
         ExecutePrivate();
         aP0_MailId=this.AV10MailId;
         aP1_SMTPSession=this.AV9SMTPSession;
      }

      public GeneXus.Mail.GXSMTPSession executeUdp( ref long aP0_MailId )
      {
         execute(ref aP0_MailId, ref aP1_SMTPSession);
         return AV9SMTPSession ;
      }

      public void executeSubmit( ref long aP0_MailId ,
                                 ref GeneXus.Mail.GXSMTPSession aP1_SMTPSession )
      {
         this.AV10MailId = aP0_MailId;
         this.AV9SMTPSession = aP1_SMTPSession;
         SubmitImpl();
         aP0_MailId=this.AV10MailId;
         aP1_SMTPSession=this.AV9SMTPSession;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00942 */
         pr_default.execute(0, new Object[] {AV10MailId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A243MailEstado = P00942_A243MailEstado[0];
            A149MailId = P00942_A149MailId[0];
            A249MailHostSMTP = P00942_A249MailHostSMTP[0];
            A241MailCuentaNombre = P00942_A241MailCuentaNombre[0];
            A714MailSender = P00942_A714MailSender[0];
            n714MailSender = P00942_n714MailSender[0];
            A242MailDireccion = P00942_A242MailDireccion[0];
            A255MailPawword = P00942_A255MailPawword[0];
            A248MailPuertoSMTP = P00942_A248MailPuertoSMTP[0];
            if ( StringUtil.StrCmp(A243MailEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               context.StatusMessage( context.GetMessage( "Logueando al servidor de correo...", "") );
               AV9SMTPSession.Host = StringUtil.Trim( A249MailHostSMTP);
               AV9SMTPSession.Sender.Name = StringUtil.Trim( A241MailCuentaNombre);
               AV9SMTPSession.Sender.Address = StringUtil.Trim( A714MailSender);
               AV9SMTPSession.UserName = StringUtil.Trim( A242MailDireccion);
               AV9SMTPSession.Password = StringUtil.Trim( A255MailPawword);
               AV9SMTPSession.Port = (int)(A248MailPuertoSMTP);
               AV9SMTPSession.Authentication = 1;
               if ( ( A248MailPuertoSMTP == 465 ) || ( A248MailPuertoSMTP == 587 ) )
               {
                  AV9SMTPSession.Secure = 1;
               }
               else
               {
                  AV9SMTPSession.Secure = 0;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         P00942_A243MailEstado = new string[] {""} ;
         P00942_A149MailId = new long[1] ;
         P00942_A249MailHostSMTP = new string[] {""} ;
         P00942_A241MailCuentaNombre = new string[] {""} ;
         P00942_A714MailSender = new string[] {""} ;
         P00942_n714MailSender = new bool[] {false} ;
         P00942_A242MailDireccion = new string[] {""} ;
         P00942_A255MailPawword = new string[] {""} ;
         P00942_A248MailPuertoSMTP = new long[1] ;
         A243MailEstado = "";
         A249MailHostSMTP = "";
         A241MailCuentaNombre = "";
         A714MailSender = "";
         A242MailDireccion = "";
         A255MailPawword = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.posmtpsession__default(),
            new Object[][] {
                new Object[] {
               P00942_A243MailEstado, P00942_A149MailId, P00942_A249MailHostSMTP, P00942_A241MailCuentaNombre, P00942_A714MailSender, P00942_n714MailSender, P00942_A242MailDireccion, P00942_A255MailPawword, P00942_A248MailPuertoSMTP
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10MailId ;
      private long A149MailId ;
      private long A248MailPuertoSMTP ;
      private string A243MailEstado ;
      private string A249MailHostSMTP ;
      private string A241MailCuentaNombre ;
      private string A255MailPawword ;
      private bool n714MailSender ;
      private string A714MailSender ;
      private string A242MailDireccion ;
      private GeneXus.Mail.GXSMTPSession AV9SMTPSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_MailId ;
      private GeneXus.Mail.GXSMTPSession aP1_SMTPSession ;
      private IDataStoreProvider pr_default ;
      private string[] P00942_A243MailEstado ;
      private long[] P00942_A149MailId ;
      private string[] P00942_A249MailHostSMTP ;
      private string[] P00942_A241MailCuentaNombre ;
      private string[] P00942_A714MailSender ;
      private bool[] P00942_n714MailSender ;
      private string[] P00942_A242MailDireccion ;
      private string[] P00942_A255MailPawword ;
      private long[] P00942_A248MailPuertoSMTP ;
   }

   public class posmtpsession__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00942;
          prmP00942 = new Object[] {
          new ParDef("@AV10MailId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00942", "SELECT [MailEstado], [MailId], [MailHostSMTP], [MailCuentaNombre], [MailSender], [MailDireccion], [MailPawword], [MailPuertoSMTP] FROM [Mail] WHERE [MailId] = @AV10MailId ORDER BY [MailId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00942,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 250);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
