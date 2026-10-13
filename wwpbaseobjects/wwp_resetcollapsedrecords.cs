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
   public class wwp_resetcollapsedrecords : GXProcedure
   {
      public wwp_resetcollapsedrecords( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_resetcollapsedrecords( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_OldGridState ,
                           GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP1_NewGridState ,
                           out bool aP2_Reset )
      {
         this.AV9OldGridState = aP0_OldGridState;
         this.AV10NewGridState = aP1_NewGridState;
         this.AV8Reset = false ;
         initialize();
         ExecutePrivate();
         aP2_Reset=this.AV8Reset;
      }

      public bool executeUdp( GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_OldGridState ,
                              GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP1_NewGridState )
      {
         execute(aP0_OldGridState, aP1_NewGridState, out aP2_Reset);
         return AV8Reset ;
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_OldGridState ,
                                 GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP1_NewGridState ,
                                 out bool aP2_Reset )
      {
         this.AV9OldGridState = aP0_OldGridState;
         this.AV10NewGridState = aP1_NewGridState;
         this.AV8Reset = false ;
         SubmitImpl();
         aP2_Reset=this.AV8Reset;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11AuxGridState = AV9OldGridState;
         AV11AuxGridState.gxTpr_Orderedby = AV10NewGridState.gxTpr_Orderedby;
         AV11AuxGridState.gxTpr_Ordereddsc = AV10NewGridState.gxTpr_Ordereddsc;
         AV11AuxGridState.gxTpr_Currentpage = AV10NewGridState.gxTpr_Currentpage;
         AV11AuxGridState.gxTpr_Pagesize = AV10NewGridState.gxTpr_Pagesize;
         AV11AuxGridState.gxTpr_Collapsedrecords = AV10NewGridState.gxTpr_Collapsedrecords;
         if ( StringUtil.StrCmp(AV11AuxGridState.ToJSonString(false, true), AV10NewGridState.ToJSonString(false, true)) != 0 )
         {
            AV8Reset = true;
         }
         else
         {
            AV8Reset = false;
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
         AV11AuxGridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         /* GeneXus formulas. */
      }

      private bool AV8Reset ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV9OldGridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10NewGridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11AuxGridState ;
      private bool aP2_Reset ;
   }

}
