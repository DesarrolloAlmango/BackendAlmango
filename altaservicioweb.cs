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
   public class altaservicioweb : GXProcedure
   {
      public altaservicioweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public altaservicioweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserConect ,
                           string aP1_Key ,
                           long aP2_ProveedorID ,
                           string aP3_UsuarioID ,
                           string aP4_Solicitud ,
                           out long aP5_SolicitudesID )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4ProveedorID = aP2_ProveedorID;
         this.AV5UsuarioID = aP3_UsuarioID;
         this.AV6Solicitud = aP4_Solicitud;
         this.AV7SolicitudesID = 0 ;
         initialize();
         ExecutePrivate();
         aP5_SolicitudesID=this.AV7SolicitudesID;
      }

      public long executeUdp( string aP0_UserConect ,
                              string aP1_Key ,
                              long aP2_ProveedorID ,
                              string aP3_UsuarioID ,
                              string aP4_Solicitud )
      {
         execute(aP0_UserConect, aP1_Key, aP2_ProveedorID, aP3_UsuarioID, aP4_Solicitud, out aP5_SolicitudesID);
         return AV7SolicitudesID ;
      }

      public void executeSubmit( string aP0_UserConect ,
                                 string aP1_Key ,
                                 long aP2_ProveedorID ,
                                 string aP3_UsuarioID ,
                                 string aP4_Solicitud ,
                                 out long aP5_SolicitudesID )
      {
         this.AV2UserConect = aP0_UserConect;
         this.AV3Key = aP1_Key;
         this.AV4ProveedorID = aP2_ProveedorID;
         this.AV5UsuarioID = aP3_UsuarioID;
         this.AV6Solicitud = aP4_Solicitud;
         this.AV7SolicitudesID = 0 ;
         SubmitImpl();
         aP5_SolicitudesID=this.AV7SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2UserConect,(string)AV3Key,(long)AV4ProveedorID,(string)AV5UsuarioID,(string)AV6Solicitud,(long)AV7SolicitudesID} ;
         ClassLoader.Execute("aaltaservicioweb","GeneXus.Programs","aaltaservicioweb", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV7SolicitudesID = (long)(args[5]) ;
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

      private long AV4ProveedorID ;
      private long AV7SolicitudesID ;
      private string AV2UserConect ;
      private string AV3Key ;
      private string AV5UsuarioID ;
      private string AV6Solicitud ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private long aP5_SolicitudesID ;
   }

}
