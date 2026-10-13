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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_hassubscriptionstodisplay : GXProcedure
   {
      public wwp_hassubscriptionstodisplay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hassubscriptionstodisplay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           out bool aP2_HasSubscriptions )
      {
         this.AV10WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV8HasSubscriptions = false ;
         initialize();
         ExecutePrivate();
         aP2_HasSubscriptions=this.AV8HasSubscriptions;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              short aP1_WWPNotificationAppliesTo )
      {
         execute(aP0_WWPEntityName, aP1_WWPNotificationAppliesTo, out aP2_HasSubscriptions);
         return AV8HasSubscriptions ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 short aP1_WWPNotificationAppliesTo ,
                                 out bool aP2_HasSubscriptions )
      {
         this.AV10WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV8HasSubscriptions = false ;
         SubmitImpl();
         aP2_HasSubscriptions=this.AV8HasSubscriptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HasSubscriptions = false;
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
         /* GeneXus formulas. */
      }

      private short AV9WWPNotificationAppliesTo ;
      private bool AV8HasSubscriptions ;
      private string AV10WWPEntityName ;
      private bool aP2_HasSubscriptions ;
   }

}
