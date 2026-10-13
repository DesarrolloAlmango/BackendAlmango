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
   public class ordentieneamg : GXProcedure
   {
      public ordentieneamg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ordentieneamg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden ,
                           out bool aP1_TieneAMG )
      {
         this.AV8Orden = aP0_Orden;
         this.AV9TieneAMG = false ;
         initialize();
         ExecutePrivate();
         aP1_TieneAMG=this.AV9TieneAMG;
      }

      public bool executeUdp( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden )
      {
         execute(aP0_Orden, out aP1_TieneAMG);
         return AV9TieneAMG ;
      }

      public void executeSubmit( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden ,
                                 out bool aP1_TieneAMG )
      {
         this.AV8Orden = aP0_Orden;
         this.AV9TieneAMG = false ;
         SubmitImpl();
         aP1_TieneAMG=this.AV9TieneAMG;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9TieneAMG = false;
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV8Orden.gxTpr_Lineas.Count )
         {
            AV10Linea = ((SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem)AV8Orden.gxTpr_Lineas.Item(AV11GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Linea.gxTpr_Sku)) )
            {
               if ( StringUtil.StrCmp(StringUtil.Substring( StringUtil.Trim( AV10Linea.gxTpr_Sku), 1, 3), context.GetMessage( "amg", "")) == 0 )
               {
                  AV9TieneAMG = true;
                  if (true) break;
               }
            }
            AV11GXV1 = (int)(AV11GXV1+1);
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
         AV10Linea = new SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem(context);
         /* GeneXus formulas. */
      }

      private int AV11GXV1 ;
      private bool AV9TieneAMG ;
      private SdtSDTFenicioOrdersResponse_ordenesItem AV8Orden ;
      private SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem AV10Linea ;
      private bool aP1_TieneAMG ;
   }

}
