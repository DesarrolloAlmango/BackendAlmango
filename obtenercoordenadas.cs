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
   public class obtenercoordenadas : GXProcedure
   {
      public obtenercoordenadas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercoordenadas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_MapBox_id ,
                           out string aP1_Result )
      {
         this.AV9MapBox_id = aP0_MapBox_id;
         this.AV10Result = "" ;
         initialize();
         ExecutePrivate();
         aP1_Result=this.AV10Result;
      }

      public string executeUdp( string aP0_MapBox_id )
      {
         execute(aP0_MapBox_id, out aP1_Result);
         return AV10Result ;
      }

      public void executeSubmit( string aP0_MapBox_id ,
                                 out string aP1_Result )
      {
         this.AV9MapBox_id = aP0_MapBox_id;
         this.AV10Result = "" ;
         SubmitImpl();
         aP1_Result=this.AV10Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8WebSession.Set(context.GetMessage( "&MapBox_id", ""), AV9MapBox_id);
         GXt_char1 = AV10Result;
         new oretrievemapbox(context ).execute( out  GXt_char1) ;
         AV10Result = GXt_char1;
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
         AV10Result = "";
         AV8WebSession = context.GetSession();
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV10Result ;
      private string AV9MapBox_id ;
      private IGxSession AV8WebSession ;
      private string aP1_Result ;
   }

}
