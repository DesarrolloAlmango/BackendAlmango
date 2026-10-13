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
   public class secgetadvancedsecurityuserfunctionalities : GXProcedure
   {
      public secgetadvancedsecurityuserfunctionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgetadvancedsecurityuserfunctionalities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad>( context, "SecFunctionalitiesToLoad", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad>( context, "SecFunctionalitiesToLoad", "AlmangoX") ;
         SubmitImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> Gxm1rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> aP0_Gxm1rootcol ;
   }

}
