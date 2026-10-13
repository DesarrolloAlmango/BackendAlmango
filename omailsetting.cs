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
   public class omailsetting : GXProcedure
   {
      public omailsetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public omailsetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MailId ,
                           out string aP1_MailDireccion ,
                           out string aP2_MailCuentaNombre )
      {
         this.AV8MailId = aP0_MailId;
         this.AV9MailDireccion = "" ;
         this.AV10MailCuentaNombre = "" ;
         initialize();
         ExecutePrivate();
         aP1_MailDireccion=this.AV9MailDireccion;
         aP2_MailCuentaNombre=this.AV10MailCuentaNombre;
      }

      public string executeUdp( long aP0_MailId ,
                                out string aP1_MailDireccion )
      {
         execute(aP0_MailId, out aP1_MailDireccion, out aP2_MailCuentaNombre);
         return AV10MailCuentaNombre ;
      }

      public void executeSubmit( long aP0_MailId ,
                                 out string aP1_MailDireccion ,
                                 out string aP2_MailCuentaNombre )
      {
         this.AV8MailId = aP0_MailId;
         this.AV9MailDireccion = "" ;
         this.AV10MailCuentaNombre = "" ;
         SubmitImpl();
         aP1_MailDireccion=this.AV9MailDireccion;
         aP2_MailCuentaNombre=this.AV10MailCuentaNombre;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00902 */
         pr_default.execute(0, new Object[] {AV8MailId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A243MailEstado = P00902_A243MailEstado[0];
            A149MailId = P00902_A149MailId[0];
            A714MailSender = P00902_A714MailSender[0];
            n714MailSender = P00902_n714MailSender[0];
            A241MailCuentaNombre = P00902_A241MailCuentaNombre[0];
            if ( StringUtil.StrCmp(A243MailEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV9MailDireccion = A714MailSender;
               AV10MailCuentaNombre = A241MailCuentaNombre;
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
         AV9MailDireccion = "";
         AV10MailCuentaNombre = "";
         P00902_A243MailEstado = new string[] {""} ;
         P00902_A149MailId = new long[1] ;
         P00902_A714MailSender = new string[] {""} ;
         P00902_n714MailSender = new bool[] {false} ;
         P00902_A241MailCuentaNombre = new string[] {""} ;
         A243MailEstado = "";
         A714MailSender = "";
         A241MailCuentaNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.omailsetting__default(),
            new Object[][] {
                new Object[] {
               P00902_A243MailEstado, P00902_A149MailId, P00902_A714MailSender, P00902_n714MailSender, P00902_A241MailCuentaNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8MailId ;
      private long A149MailId ;
      private string AV10MailCuentaNombre ;
      private string A243MailEstado ;
      private string A241MailCuentaNombre ;
      private bool n714MailSender ;
      private string AV9MailDireccion ;
      private string A714MailSender ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00902_A243MailEstado ;
      private long[] P00902_A149MailId ;
      private string[] P00902_A714MailSender ;
      private bool[] P00902_n714MailSender ;
      private string[] P00902_A241MailCuentaNombre ;
      private string aP1_MailDireccion ;
      private string aP2_MailCuentaNombre ;
   }

   public class omailsetting__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00902;
          prmP00902 = new Object[] {
          new ParDef("@AV8MailId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00902", "SELECT [MailEstado], [MailId], [MailSender], [MailCuentaNombre] FROM [Mail] WHERE [MailId] = @AV8MailId ORDER BY [MailId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00902,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                return;
       }
    }

 }

}
