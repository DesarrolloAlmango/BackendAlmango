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
   public class aactualizaciones : GXProcedure
   {
      public aactualizaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aactualizaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ActualizacionesId ,
                           out string aP1_Ok )
      {
         this.AV9ActualizacionesId = aP0_ActualizacionesId;
         this.AV10Ok = "" ;
         initialize();
         ExecutePrivate();
         aP1_Ok=this.AV10Ok;
      }

      public string executeUdp( string aP0_ActualizacionesId )
      {
         execute(aP0_ActualizacionesId, out aP1_Ok);
         return AV10Ok ;
      }

      public void executeSubmit( string aP0_ActualizacionesId ,
                                 out string aP1_Ok )
      {
         this.AV9ActualizacionesId = aP0_ActualizacionesId;
         this.AV10Ok = "" ;
         SubmitImpl();
         aP1_Ok=this.AV10Ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new loadcontext(context ).execute( out  AV11Context) ;
         /*
            INSERT RECORD ON TABLE Actualizaciones

         */
         A366ActualizacionesId = StringUtil.Upper( StringUtil.Trim( AV9ActualizacionesId));
         A367ActualizacionesFecha = DateTimeUtil.ServerNow( context, pr_default);
         A369ActualizacionesUsuario = AV11Context.gxTpr_Usuariosid;
         AV10Ok = context.GetMessage( "S", "");
         /* Using cursor P009I2 */
         pr_default.execute(0, new Object[] {A366ActualizacionesId, A367ActualizacionesFecha, A369ActualizacionesUsuario});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Actualizaciones");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            A367ActualizacionesFecha = DateTimeUtil.ServerNow( context, pr_default);
            A369ActualizacionesUsuario = AV11Context.gxTpr_Usuariosid;
            AV10Ok = context.GetMessage( "S", "");
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aactualizaciones",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Ok = "";
         AV11Context = new SdtContext(context);
         A366ActualizacionesId = "";
         A367ActualizacionesFecha = (DateTime)(DateTime.MinValue);
         A369ActualizacionesUsuario = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aactualizaciones__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS55 ;
      private string AV9ActualizacionesId ;
      private string AV10Ok ;
      private string A366ActualizacionesId ;
      private string A369ActualizacionesUsuario ;
      private string Gx_emsg ;
      private DateTime A367ActualizacionesFecha ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtContext AV11Context ;
      private IDataStoreProvider pr_default ;
      private string aP1_Ok ;
   }

   public class aactualizaciones__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009I2;
          prmP009I2 = new Object[] {
          new ParDef("@ActualizacionesId",GXType.NChar,100,0) ,
          new ParDef("@ActualizacionesFecha",GXType.DateTime,8,5) ,
          new ParDef("@ActualizacionesUsuario",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009I2", "INSERT INTO [Actualizaciones]([ActualizacionesId], [ActualizacionesFecha], [ActualizacionesUsuario]) VALUES(@ActualizacionesId, @ActualizacionesFecha, @ActualizacionesUsuario)", GxErrorMask.GX_NOMASK,prmP009I2)
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
