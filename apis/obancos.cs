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
namespace GeneXus.Programs.apis {
   public class obancos : GXProcedure
   {
      public obancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obancos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ,
                           out string aP1_RestMessage ,
                           out short aP2_Gx_restcode )
      {
         this.AV8SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>( context, "SDTBanco", "AlmangoX") ;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP0_SdtBancos=this.AV8SdtBancos;
         aP1_RestMessage=this.AV10RestMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ,
                               out string aP1_RestMessage )
      {
         execute(out aP0_SdtBancos, out aP1_RestMessage, out aP2_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ,
                                 out string aP1_RestMessage ,
                                 out short aP2_Gx_restcode )
      {
         this.AV8SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>( context, "SDTBanco", "AlmangoX") ;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP0_SdtBancos=this.AV8SdtBancos;
         aP1_RestMessage=this.AV10RestMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SdtBancos.Clear();
         /* Using cursor P00K12 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A675BancoEstado = P00K12_A675BancoEstado[0];
            A673BancoId = P00K12_A673BancoId[0];
            A674BancoNombre = P00K12_A674BancoNombre[0];
            AV9Item = new GeneXus.Programs.apis.SdtSDTBanco(context);
            AV9Item.gxTpr_Bancoid = A673BancoId;
            AV9Item.gxTpr_Banconombre = A674BancoNombre;
            AV8SdtBancos.Add(AV9Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV8SdtBancos.Count > 0 )
         {
            AV10RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            Gx_restcode = 200;
         }
         else
         {
            AV10RestMessage = context.GetMessage( "Error en la Solicitud", "");
            Gx_restcode = 500;
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
         AV8SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>( context, "SDTBanco", "AlmangoX");
         AV10RestMessage = "";
         P00K12_A675BancoEstado = new string[] {""} ;
         P00K12_A673BancoId = new long[1] ;
         P00K12_A674BancoNombre = new string[] {""} ;
         A675BancoEstado = "";
         A674BancoNombre = "";
         AV9Item = new GeneXus.Programs.apis.SdtSDTBanco(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obancos__default(),
            new Object[][] {
                new Object[] {
               P00K12_A675BancoEstado, P00K12_A673BancoId, P00K12_A674BancoNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long A673BancoId ;
      private string A675BancoEstado ;
      private string A674BancoNombre ;
      private string AV10RestMessage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> AV8SdtBancos ;
      private IDataStoreProvider pr_default ;
      private string[] P00K12_A675BancoEstado ;
      private long[] P00K12_A673BancoId ;
      private string[] P00K12_A674BancoNombre ;
      private GeneXus.Programs.apis.SdtSDTBanco AV9Item ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ;
      private string aP1_RestMessage ;
      private short aP2_Gx_restcode ;
   }

   public class obancos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00K12;
          prmP00K12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00K12", "SELECT [BancoEstado], [BancoId], [BancoNombre] FROM [Banco] WHERE [BancoEstado] = 'HAB' ORDER BY [BancoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K12,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}
