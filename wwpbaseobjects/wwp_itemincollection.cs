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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_itemincollection : GXProcedure
   {
      public wwp_itemincollection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_itemincollection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Item ,
                           GxSimpleCollection<string> aP1_Collection ,
                           out bool aP2_IsContained )
      {
         this.AV8Item = aP0_Item;
         this.AV9Collection = aP1_Collection;
         this.AV10IsContained = false ;
         initialize();
         ExecutePrivate();
         aP2_IsContained=this.AV10IsContained;
      }

      public bool executeUdp( string aP0_Item ,
                              GxSimpleCollection<string> aP1_Collection )
      {
         execute(aP0_Item, aP1_Collection, out aP2_IsContained);
         return AV10IsContained ;
      }

      public void executeSubmit( string aP0_Item ,
                                 GxSimpleCollection<string> aP1_Collection ,
                                 out bool aP2_IsContained )
      {
         this.AV8Item = aP0_Item;
         this.AV9Collection = aP1_Collection;
         this.AV10IsContained = false ;
         SubmitImpl();
         aP2_IsContained=this.AV10IsContained;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV9Collection.IndexOf(AV8Item) > 0 )
         {
            AV10IsContained = true;
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
         /* GeneXus formulas. */
      }

      private bool AV10IsContained ;
      private string AV8Item ;
      private GxSimpleCollection<string> AV9Collection ;
      private bool aP2_IsContained ;
   }

}
