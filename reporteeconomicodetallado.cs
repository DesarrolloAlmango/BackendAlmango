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
   public class reporteeconomicodetallado : GXProcedure
   {
      public reporteeconomicodetallado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reporteeconomicodetallado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProfesionalesId ,
                           ref long aP1_SolicitudesID ,
                           ref DateTime aP2_Desde ,
                           ref DateTime aP3_Hasta ,
                           ref int aP4_Clasificaciones ,
                           ref string aP5_SolicitudServicioOrigenPago )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3SolicitudesID = aP1_SolicitudesID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.AV2ProfesionalesId;
         aP1_SolicitudesID=this.AV3SolicitudesID;
         aP2_Desde=this.AV4Desde;
         aP3_Hasta=this.AV5Hasta;
         aP4_Clasificaciones=this.AV6Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV7SolicitudServicioOrigenPago;
      }

      public string executeUdp( ref string aP0_ProfesionalesId ,
                                ref long aP1_SolicitudesID ,
                                ref DateTime aP2_Desde ,
                                ref DateTime aP3_Hasta ,
                                ref int aP4_Clasificaciones )
      {
         execute(ref aP0_ProfesionalesId, ref aP1_SolicitudesID, ref aP2_Desde, ref aP3_Hasta, ref aP4_Clasificaciones, ref aP5_SolicitudServicioOrigenPago);
         return AV7SolicitudServicioOrigenPago ;
      }

      public void executeSubmit( ref string aP0_ProfesionalesId ,
                                 ref long aP1_SolicitudesID ,
                                 ref DateTime aP2_Desde ,
                                 ref DateTime aP3_Hasta ,
                                 ref int aP4_Clasificaciones ,
                                 ref string aP5_SolicitudServicioOrigenPago )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3SolicitudesID = aP1_SolicitudesID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         SubmitImpl();
         aP0_ProfesionalesId=this.AV2ProfesionalesId;
         aP1_SolicitudesID=this.AV3SolicitudesID;
         aP2_Desde=this.AV4Desde;
         aP3_Hasta=this.AV5Hasta;
         aP4_Clasificaciones=this.AV6Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV7SolicitudServicioOrigenPago;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ProfesionalesId,(long)AV3SolicitudesID,(DateTime)AV4Desde,(DateTime)AV5Hasta,(int)AV6Clasificaciones,(string)AV7SolicitudServicioOrigenPago} ;
         ClassLoader.Execute("areporteeconomicodetallado","GeneXus.Programs","areporteeconomicodetallado", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV2ProfesionalesId = (string)(args[0]) ;
            AV3SolicitudesID = (long)(args[1]) ;
            AV4Desde = (DateTime)(args[2]) ;
            AV5Hasta = (DateTime)(args[3]) ;
            AV6Clasificaciones = (int)(args[4]) ;
            AV7SolicitudServicioOrigenPago = (string)(args[5]) ;
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
      private long AV3SolicitudesID ;
      private string AV2ProfesionalesId ;
      private string AV7SolicitudServicioOrigenPago ;
      private DateTime AV4Desde ;
      private DateTime AV5Hasta ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_SolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private Object[] args ;
   }

}
