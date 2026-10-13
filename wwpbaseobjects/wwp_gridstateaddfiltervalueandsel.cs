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
   public class wwp_gridstateaddfiltervalueandsel : GXProcedure
   {
      public wwp_gridstateaddfiltervalueandsel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_gridstateaddfiltervalueandsel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                           string aP1_FilterName ,
                           string aP2_FilterDsc ,
                           bool aP3_AddFitler ,
                           short aP4_FilterOperator ,
                           string aP5_FilterValue ,
                           string aP6_FilterValueTo ,
                           bool aP7_AddFitlerSel ,
                           string aP8_FilterValueSel ,
                           string aP9_FilterValueToSel )
      {
         this.AV13GridState = aP0_GridState;
         this.AV8FilterName = aP1_FilterName;
         this.AV9FilterDsc = aP2_FilterDsc;
         this.AV12AddFitler = aP3_AddFitler;
         this.AV15FilterOperator = aP4_FilterOperator;
         this.AV11FilterValue = aP5_FilterValue;
         this.AV10FilterValueTo = aP6_FilterValueTo;
         this.AV16AddFitlerSel = aP7_AddFitlerSel;
         this.AV17FilterValueSel = aP8_FilterValueSel;
         this.AV18FilterValueToSel = aP9_FilterValueToSel;
         initialize();
         ExecutePrivate();
         aP0_GridState=this.AV13GridState;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ,
                                 string aP1_FilterName ,
                                 string aP2_FilterDsc ,
                                 bool aP3_AddFitler ,
                                 short aP4_FilterOperator ,
                                 string aP5_FilterValue ,
                                 string aP6_FilterValueTo ,
                                 bool aP7_AddFitlerSel ,
                                 string aP8_FilterValueSel ,
                                 string aP9_FilterValueToSel )
      {
         this.AV13GridState = aP0_GridState;
         this.AV8FilterName = aP1_FilterName;
         this.AV9FilterDsc = aP2_FilterDsc;
         this.AV12AddFitler = aP3_AddFitler;
         this.AV15FilterOperator = aP4_FilterOperator;
         this.AV11FilterValue = aP5_FilterValue;
         this.AV10FilterValueTo = aP6_FilterValueTo;
         this.AV16AddFitlerSel = aP7_AddFitlerSel;
         this.AV17FilterValueSel = aP8_FilterValueSel;
         this.AV18FilterValueToSel = aP9_FilterValueToSel;
         SubmitImpl();
         aP0_GridState=this.AV13GridState;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV12AddFitler )
         {
            AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV14GridStateFilterValue.gxTpr_Name = AV8FilterName;
            AV14GridStateFilterValue.gxTpr_Dsc = AV9FilterDsc;
            AV14GridStateFilterValue.gxTpr_Operator = AV15FilterOperator;
            AV14GridStateFilterValue.gxTpr_Value = AV11FilterValue;
            AV14GridStateFilterValue.gxTpr_Valueto = AV10FilterValueTo;
            AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         }
         if ( AV16AddFitlerSel )
         {
            AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV14GridStateFilterValue.gxTpr_Name = AV8FilterName+"_SEL";
            AV14GridStateFilterValue.gxTpr_Dsc = AV9FilterDsc;
            AV14GridStateFilterValue.gxTpr_Value = AV17FilterValueSel;
            AV14GridStateFilterValue.gxTpr_Valueto = AV18FilterValueToSel;
            AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
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
         AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         /* GeneXus formulas. */
      }

      private short AV15FilterOperator ;
      private bool AV12AddFitler ;
      private bool AV16AddFitlerSel ;
      private string AV8FilterName ;
      private string AV9FilterDsc ;
      private string AV11FilterValue ;
      private string AV10FilterValueTo ;
      private string AV17FilterValueSel ;
      private string AV18FilterValueToSel ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV13GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState aP0_GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
   }

}
