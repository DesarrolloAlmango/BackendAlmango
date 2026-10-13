using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
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
   public class ocantidadsolicitudes : GXProcedure
   {
      public ocantidadsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public ocantidadsolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out short aP1_Cantidad )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3Cantidad = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Cantidad=this.AV3Cantidad;
      }

      public short executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_Cantidad);
         return AV3Cantidad ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out short aP1_Cantidad )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3Cantidad = 0 ;
         SubmitImpl();
         aP1_Cantidad=this.AV3Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ProfesionalesId,(short)AV3Cantidad} ;
         ClassLoader.Execute("aocantidadsolicitudes","GeneXus.Programs","aocantidadsolicitudes", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3Cantidad = (short)(args[1]) ;
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
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private short AV3Cantidad ;
      private string AV2ProfesionalesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private short aP1_Cantidad ;
   }

}
