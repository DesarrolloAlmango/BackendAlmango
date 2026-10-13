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
   public class reporteprofcomi : GXProcedure
   {
      public reporteprofcomi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reporteprofcomi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProfesionalesId ,
                           ref long aP1_InSolicitudesID ,
                           ref DateTime aP2_Desde ,
                           ref DateTime aP3_Hasta ,
                           ref int aP4_Clasificaciones ,
                           ref string aP5_SolicitudServicioOrigenPago ,
                           ref string aP6_Opciones ,
                           ref string aP7_Veridicar )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3InSolicitudesID = aP1_InSolicitudesID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8Opciones = aP6_Opciones;
         this.AV9Veridicar = aP7_Veridicar;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.AV2ProfesionalesId;
         aP1_InSolicitudesID=this.AV3InSolicitudesID;
         aP2_Desde=this.AV4Desde;
         aP3_Hasta=this.AV5Hasta;
         aP4_Clasificaciones=this.AV6Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV7SolicitudServicioOrigenPago;
         aP6_Opciones=this.AV8Opciones;
         aP7_Veridicar=this.AV9Veridicar;
      }

      public string executeUdp( ref string aP0_ProfesionalesId ,
                                ref long aP1_InSolicitudesID ,
                                ref DateTime aP2_Desde ,
                                ref DateTime aP3_Hasta ,
                                ref int aP4_Clasificaciones ,
                                ref string aP5_SolicitudServicioOrigenPago ,
                                ref string aP6_Opciones )
      {
         execute(ref aP0_ProfesionalesId, ref aP1_InSolicitudesID, ref aP2_Desde, ref aP3_Hasta, ref aP4_Clasificaciones, ref aP5_SolicitudServicioOrigenPago, ref aP6_Opciones, ref aP7_Veridicar);
         return AV9Veridicar ;
      }

      public void executeSubmit( ref string aP0_ProfesionalesId ,
                                 ref long aP1_InSolicitudesID ,
                                 ref DateTime aP2_Desde ,
                                 ref DateTime aP3_Hasta ,
                                 ref int aP4_Clasificaciones ,
                                 ref string aP5_SolicitudServicioOrigenPago ,
                                 ref string aP6_Opciones ,
                                 ref string aP7_Veridicar )
      {
         this.AV2ProfesionalesId = aP0_ProfesionalesId;
         this.AV3InSolicitudesID = aP1_InSolicitudesID;
         this.AV4Desde = aP2_Desde;
         this.AV5Hasta = aP3_Hasta;
         this.AV6Clasificaciones = aP4_Clasificaciones;
         this.AV7SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV8Opciones = aP6_Opciones;
         this.AV9Veridicar = aP7_Veridicar;
         SubmitImpl();
         aP0_ProfesionalesId=this.AV2ProfesionalesId;
         aP1_InSolicitudesID=this.AV3InSolicitudesID;
         aP2_Desde=this.AV4Desde;
         aP3_Hasta=this.AV5Hasta;
         aP4_Clasificaciones=this.AV6Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV7SolicitudServicioOrigenPago;
         aP6_Opciones=this.AV8Opciones;
         aP7_Veridicar=this.AV9Veridicar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ProfesionalesId,(long)AV3InSolicitudesID,(DateTime)AV4Desde,(DateTime)AV5Hasta,(int)AV6Clasificaciones,(string)AV7SolicitudServicioOrigenPago,(string)AV8Opciones,(string)AV9Veridicar} ;
         ClassLoader.Execute("areporteprofcomi","GeneXus.Programs","areporteprofcomi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 8 ) )
         {
            AV2ProfesionalesId = (string)(args[0]) ;
            AV3InSolicitudesID = (long)(args[1]) ;
            AV4Desde = (DateTime)(args[2]) ;
            AV5Hasta = (DateTime)(args[3]) ;
            AV6Clasificaciones = (int)(args[4]) ;
            AV7SolicitudServicioOrigenPago = (string)(args[5]) ;
            AV8Opciones = (string)(args[6]) ;
            AV9Veridicar = (string)(args[7]) ;
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
      private long AV3InSolicitudesID ;
      private string AV2ProfesionalesId ;
      private string AV7SolicitudServicioOrigenPago ;
      private string AV8Opciones ;
      private string AV9Veridicar ;
      private DateTime AV4Desde ;
      private DateTime AV5Hasta ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_InSolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private string aP6_Opciones ;
      private string aP7_Veridicar ;
      private Object[] args ;
   }

}
