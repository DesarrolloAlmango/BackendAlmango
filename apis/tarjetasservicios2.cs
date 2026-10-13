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
namespace GeneXus.Programs.apis {
   public class tarjetasservicios2 : GXProcedure
   {
      public tarjetasservicios2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tarjetasservicios2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_SDTTarjetasServiciosJson )
      {
         this.AV10SDTTarjetasServiciosJson = "" ;
         initialize();
         ExecutePrivate();
         aP0_SDTTarjetasServiciosJson=this.AV10SDTTarjetasServiciosJson;
      }

      public string executeUdp( )
      {
         execute(out aP0_SDTTarjetasServiciosJson);
         return AV10SDTTarjetasServiciosJson ;
      }

      public void executeSubmit( out string aP0_SDTTarjetasServiciosJson )
      {
         this.AV10SDTTarjetasServiciosJson = "" ;
         SubmitImpl();
         aP0_SDTTarjetasServiciosJson=this.AV10SDTTarjetasServiciosJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDTTarjetasServiciosItem = new GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem(context);
         AV9SDTTarjetasServiciosItem.gxTpr_Id = 1111;
         AV9SDTTarjetasServiciosItem.gxTpr_Name = context.GetMessage( "Fletes y Mudanzas", "");
         AV9SDTTarjetasServiciosItem.gxTpr_Icon = context.GetMessage( "https://tn.com.ar/resizer/v2/en-febrero-hacer-una-mudanza-en-el-amba-puede-costar-hasta-500000-foto-blogdeseguroscom-R76YF6LYRVFEHIWDAB5QT4S2EM.png?auth=0e45d37cfd3288d80391fb141181b48361378c8617a55a19aed4d0348d10ac9a&width=1440", "");
         AV9SDTTarjetasServiciosItem.gxTpr_Url = context.GetMessage( "https://mudanza.almango.com.uy/", "");
         AV8SDTTarjetasServicios.Add(AV9SDTTarjetasServiciosItem, 0);
         AV10SDTTarjetasServiciosJson = AV8SDTTarjetasServicios.ToJSonString(false);
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
         AV10SDTTarjetasServiciosJson = "";
         AV9SDTTarjetasServiciosItem = new GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem(context);
         AV8SDTTarjetasServicios = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem>( context, "SDTTarjetasServiciosItem", "AlmangoX");
         /* GeneXus formulas. */
      }

      private string AV10SDTTarjetasServiciosJson ;
      private GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem AV9SDTTarjetasServiciosItem ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem> AV8SDTTarjetasServicios ;
      private string aP0_SDTTarjetasServiciosJson ;
   }

}
