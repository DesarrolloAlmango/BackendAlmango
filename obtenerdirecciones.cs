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
   public class obtenerdirecciones : GXProcedure
   {
      public obtenerdirecciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerdirecciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SearchTxt ,
                           string aP1_Coordenadas ,
                           out string aP2_Result )
      {
         this.AV9SearchTxt = aP0_SearchTxt;
         this.AV11Coordenadas = aP1_Coordenadas;
         this.AV8Result = "" ;
         initialize();
         ExecutePrivate();
         aP2_Result=this.AV8Result;
      }

      public string executeUdp( string aP0_SearchTxt ,
                                string aP1_Coordenadas )
      {
         execute(aP0_SearchTxt, aP1_Coordenadas, out aP2_Result);
         return AV8Result ;
      }

      public void executeSubmit( string aP0_SearchTxt ,
                                 string aP1_Coordenadas ,
                                 out string aP2_Result )
      {
         this.AV9SearchTxt = aP0_SearchTxt;
         this.AV11Coordenadas = aP1_Coordenadas;
         this.AV8Result = "" ;
         SubmitImpl();
         aP2_Result=this.AV8Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV8Result;
         new osuggestmapbox(context ).execute(  AV9SearchTxt,  StringUtil.Trim( AV11Coordenadas), out  GXt_char1) ;
         AV8Result = GXt_char1;
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
         AV8Result = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV8Result ;
      private string AV9SearchTxt ;
      private string AV11Coordenadas ;
      private string aP2_Result ;
   }

}
