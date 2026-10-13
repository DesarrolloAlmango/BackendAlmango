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
   public class obtenerurlmapa : GXProcedure
   {
      public obtenerurlmapa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerurlmapa( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_OrigenCoordenadas ,
                           string aP1_DestinoCoordenadas ,
                           out string aP2_URL )
      {
         this.AV12OrigenCoordenadas = aP0_OrigenCoordenadas;
         this.AV13DestinoCoordenadas = aP1_DestinoCoordenadas;
         this.AV8URL = "" ;
         initialize();
         ExecutePrivate();
         aP2_URL=this.AV8URL;
      }

      public string executeUdp( string aP0_OrigenCoordenadas ,
                                string aP1_DestinoCoordenadas )
      {
         execute(aP0_OrigenCoordenadas, aP1_DestinoCoordenadas, out aP2_URL);
         return AV8URL ;
      }

      public void executeSubmit( string aP0_OrigenCoordenadas ,
                                 string aP1_DestinoCoordenadas ,
                                 out string aP2_URL )
      {
         this.AV12OrigenCoordenadas = aP0_OrigenCoordenadas;
         this.AV13DestinoCoordenadas = aP1_DestinoCoordenadas;
         this.AV8URL = "" ;
         SubmitImpl();
         aP2_URL=this.AV8URL;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new oparametros(context ).execute(  context.GetMessage( "URLMAPBOX", ""), out  AV10URLMAPA, out  AV15ParametrosNumerico, out  AV14ParametrosEstado) ;
         new oparametros(context ).execute(  context.GetMessage( "TOKENMAPBOX", ""), out  AV11Token, out  AV15ParametrosNumerico, out  AV14ParametrosEstado) ;
         AV9SessionTxt = StringUtil.Trim( AV12OrigenCoordenadas) + context.GetMessage( "),pin-s-b+000(", "") + StringUtil.Trim( AV13DestinoCoordenadas);
         AV8URL = StringUtil.Format( context.GetMessage( "%1pin-s-a+9ed4bd(%2)/auto/397x275?access_token=%3", ""), AV10URLMAPA, StringUtil.Trim( AV9SessionTxt), AV11Token, "", "", "", "", "", "");
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
         AV8URL = "";
         AV10URLMAPA = "";
         AV14ParametrosEstado = "";
         AV11Token = "";
         AV9SessionTxt = "";
         /* GeneXus formulas. */
      }

      private int AV15ParametrosNumerico ;
      private string AV14ParametrosEstado ;
      private string AV9SessionTxt ;
      private string AV12OrigenCoordenadas ;
      private string AV13DestinoCoordenadas ;
      private string AV8URL ;
      private string AV10URLMAPA ;
      private string AV11Token ;
      private string aP2_URL ;
   }

}
