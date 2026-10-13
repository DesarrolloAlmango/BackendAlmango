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
   public class wwp_getappliedfiltersdescription : GXProcedure
   {
      public wwp_getappliedfiltersdescription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getappliedfiltersdescription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ListObjectName ,
                           out string aP1_AppliedFiltersDescription )
      {
         this.AV14ListObjectName = aP0_ListObjectName;
         this.AV8AppliedFiltersDescription = "" ;
         initialize();
         ExecutePrivate();
         aP1_AppliedFiltersDescription=this.AV8AppliedFiltersDescription;
      }

      public string executeUdp( string aP0_ListObjectName )
      {
         execute(aP0_ListObjectName, out aP1_AppliedFiltersDescription);
         return AV8AppliedFiltersDescription ;
      }

      public void executeSubmit( string aP0_ListObjectName ,
                                 out string aP1_AppliedFiltersDescription )
      {
         this.AV14ListObjectName = aP0_ListObjectName;
         this.AV8AppliedFiltersDescription = "" ;
         SubmitImpl();
         aP1_AppliedFiltersDescription=this.AV8AppliedFiltersDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GridState.FromXml(AV15Session.Get(AV14ListObjectName+"GridState"), null, "", "");
         AV9index = 1;
         while ( AV12GridState.gxTpr_Filtervalues.Count >= AV9index )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV9index)).gxTpr_Dsc))) )
            {
               AV12GridState.gxTpr_Filtervalues.RemoveItem(AV9index);
            }
            else
            {
               AV9index = (short)(AV9index+1);
            }
         }
         AV16TotalFilters = (short)(AV12GridState.gxTpr_Filtervalues.Count+AV12GridState.gxTpr_Dynamicfilters.Count);
         AV8AppliedFiltersDescription = "";
         if ( AV16TotalFilters > 0 )
         {
            AV9index = 1;
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
            {
               AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV17GXV1));
               AV11FilterDescription = AV13GridStateFilterValue.gxTpr_Dsc;
               /* Execute user subroutine: 'ADD FILTER TO DESCRIPTION' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
            AV18GXV2 = 1;
            while ( AV18GXV2 <= AV12GridState.gxTpr_Dynamicfilters.Count )
            {
               AV10DynamicFiltersItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(AV18GXV2));
               AV11FilterDescription = AV10DynamicFiltersItem.gxTpr_Dsc;
               /* Execute user subroutine: 'ADD FILTER TO DESCRIPTION' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV18GXV2 = (int)(AV18GXV2+1);
            }
            AV8AppliedFiltersDescription = StringUtil.Format( context.GetMessage( "WWP_FilteringByCaption", ""), AV8AppliedFiltersDescription, "", "", "", "", "", "", "", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADD FILTER TO DESCRIPTION' Routine */
         returnInSub = false;
         if ( AV9index >= 6 )
         {
            if ( AV9index == 6 )
            {
               AV8AppliedFiltersDescription += "...";
            }
         }
         else
         {
            if ( AV9index > 1 )
            {
               AV8AppliedFiltersDescription += ((AV9index==AV16TotalFilters) ? " "+context.GetMessage( "WWP_WordsListLastSeparator", "") : context.GetMessage( "WWP_WordsListSeparator", "")) + " ";
            }
            AV8AppliedFiltersDescription += AV11FilterDescription;
         }
         AV9index = (short)(AV9index+1);
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
         AV8AppliedFiltersDescription = "";
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV15Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11FilterDescription = "";
         AV10DynamicFiltersItem = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         /* GeneXus formulas. */
      }

      private short AV9index ;
      private short AV16TotalFilters ;
      private int AV17GXV1 ;
      private int AV18GXV2 ;
      private bool returnInSub ;
      private string AV14ListObjectName ;
      private string AV8AppliedFiltersDescription ;
      private string AV11FilterDescription ;
      private IGxSession AV15Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV10DynamicFiltersItem ;
      private string aP1_AppliedFiltersDescription ;
   }

}
