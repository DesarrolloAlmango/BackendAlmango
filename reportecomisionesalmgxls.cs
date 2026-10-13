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
   public class reportecomisionesalmgxls : GXProcedure
   {
      public reportecomisionesalmgxls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reportecomisionesalmgxls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_ProveedorID ,
                           int aP1_EstadosGenericosID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           string aP4_FechaFiltro ,
                           string aP5_SolicitudServicioOrigenPago ,
                           ref string aP6_SecUserIDJson )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6FechaFiltro = aP4_FechaFiltro;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8SecUserIDJson = aP6_SecUserIDJson;
         initialize();
         ExecutePrivate();
         aP6_SecUserIDJson=this.AV8SecUserIDJson;
      }

      public string executeUdp( GxSimpleCollection<long> aP0_ProveedorID ,
                                int aP1_EstadosGenericosID ,
                                DateTime aP2_Desde ,
                                DateTime aP3_Hasta ,
                                string aP4_FechaFiltro ,
                                string aP5_SolicitudServicioOrigenPago )
      {
         execute(aP0_ProveedorID, aP1_EstadosGenericosID, aP2_Desde, aP3_Hasta, aP4_FechaFiltro, aP5_SolicitudServicioOrigenPago, ref aP6_SecUserIDJson);
         return AV8SecUserIDJson ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_ProveedorID ,
                                 int aP1_EstadosGenericosID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 string aP4_FechaFiltro ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 ref string aP6_SecUserIDJson )
      {
         this.AV2ProveedorID = aP0_ProveedorID;
         this.AV3EstadosGenericosID = aP1_EstadosGenericosID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6FechaFiltro = aP4_FechaFiltro;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8SecUserIDJson = aP6_SecUserIDJson;
         SubmitImpl();
         aP6_SecUserIDJson=this.AV8SecUserIDJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GxSimpleCollection<long>)AV2ProveedorID,(int)AV3EstadosGenericosID,(DateTime)AV4Desde,(DateTime)AV5Hasta,(string)AV6FechaFiltro,(string)AV7SolicitudServicioOrigenPago,(string)AV8SecUserIDJson} ;
         ClassLoader.Execute("areportecomisionesalmgxls","GeneXus.Programs","areportecomisionesalmgxls", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 7 ) )
         {
            AV8SecUserIDJson = (string)(args[6]) ;
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

      private int AV3EstadosGenericosID ;
      private string AV7SolicitudServicioOrigenPago ;
      private DateTime AV4Desde ;
      private DateTime AV5Hasta ;
      private string AV8SecUserIDJson ;
      private string AV6FechaFiltro ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV2ProveedorID ;
      private string aP6_SecUserIDJson ;
      private Object[] args ;
   }

}
