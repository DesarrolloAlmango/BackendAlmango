using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class loadcontext : GXProcedure
   {
      public loadcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtContext aP0_Context )
      {
         this.AV8Context = new SdtContext(context) ;
         initialize();
         ExecutePrivate();
         aP0_Context=this.AV8Context;
      }

      public SdtContext executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out SdtContext aP0_Context )
      {
         this.AV8Context = new SdtContext(context) ;
         SubmitImpl();
         aP0_Context=this.AV8Context;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Context.FromXml(AV9Session.Get("context"), null, "", "");
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
         AV8Context = new SdtContext(context);
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
      }

      private IGxSession AV9Session ;
      private SdtContext AV8Context ;
      private SdtContext aP0_Context ;
   }

}
