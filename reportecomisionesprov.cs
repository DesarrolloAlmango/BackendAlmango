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
   public class reportecomisionesprov : GXProcedure
   {
      public reportecomisionesprov( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reportecomisionesprov( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedoresTipoId ,
                           long aP1_ProveedorID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           int aP4_Clasificaciones ,
                           string aP5_SolicitudServicioOrigenPago ,
                           bool aP6_DSPALmango )
      {
         this.AV2ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV3ProveedorID = aP1_ProveedorID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8DSPALmango = aP6_DSPALmango;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 int aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 bool aP6_DSPALmango )
      {
         this.AV2ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV3ProveedorID = aP1_ProveedorID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8DSPALmango = aP6_DSPALmango;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2ProveedoresTipoId,(long)AV3ProveedorID,(DateTime)AV4Desde,(DateTime)AV5Hasta,(int)AV6Clasificaciones,(string)AV7SolicitudServicioOrigenPago,(bool)AV8DSPALmango} ;
         ClassLoader.Execute("areportecomisionesprov","GeneXus.Programs","areportecomisionesprov", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 7 ) )
         {
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

      private int AV6Clasificaciones ;
      private long AV2ProveedoresTipoId ;
      private long AV3ProveedorID ;
      private string AV7SolicitudServicioOrigenPago ;
      private DateTime AV4Desde ;
      private DateTime AV5Hasta ;
      private bool AV8DSPALmango ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
