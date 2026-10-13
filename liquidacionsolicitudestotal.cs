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
   public class liquidacionsolicitudestotal : GXProcedure
   {
      public liquidacionsolicitudestotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public liquidacionsolicitudestotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_OperacionesTipo ,
                           DateTime aP1_OperacionesFechaDesde ,
                           DateTime aP2_OperacionesFechaHasta ,
                           string aP3_OperacionesPeriodoCod ,
                           long aP4_UserId ,
                           out string aP5_Gx_msg ,
                           out bool aP6_IsOk )
      {
         this.AV2OperacionesTipo = aP0_OperacionesTipo;
         this.AV3OperacionesFechaDesde = aP1_OperacionesFechaDesde;
         this.AV4OperacionesFechaHasta = aP2_OperacionesFechaHasta;
         this.AV5OperacionesPeriodoCod = aP3_OperacionesPeriodoCod;
         this.AV6UserId = aP4_UserId;
         this.Gx_msg = "" ;
         this.AV8IsOk = false ;
         initialize();
         ExecutePrivate();
         aP5_Gx_msg=this.Gx_msg;
         aP6_IsOk=this.AV8IsOk;
      }

      public bool executeUdp( string aP0_OperacionesTipo ,
                              DateTime aP1_OperacionesFechaDesde ,
                              DateTime aP2_OperacionesFechaHasta ,
                              string aP3_OperacionesPeriodoCod ,
                              long aP4_UserId ,
                              out string aP5_Gx_msg )
      {
         execute(aP0_OperacionesTipo, aP1_OperacionesFechaDesde, aP2_OperacionesFechaHasta, aP3_OperacionesPeriodoCod, aP4_UserId, out aP5_Gx_msg, out aP6_IsOk);
         return AV8IsOk ;
      }

      public void executeSubmit( string aP0_OperacionesTipo ,
                                 DateTime aP1_OperacionesFechaDesde ,
                                 DateTime aP2_OperacionesFechaHasta ,
                                 string aP3_OperacionesPeriodoCod ,
                                 long aP4_UserId ,
                                 out string aP5_Gx_msg ,
                                 out bool aP6_IsOk )
      {
         this.AV2OperacionesTipo = aP0_OperacionesTipo;
         this.AV3OperacionesFechaDesde = aP1_OperacionesFechaDesde;
         this.AV4OperacionesFechaHasta = aP2_OperacionesFechaHasta;
         this.AV5OperacionesPeriodoCod = aP3_OperacionesPeriodoCod;
         this.AV6UserId = aP4_UserId;
         this.Gx_msg = "" ;
         this.AV8IsOk = false ;
         SubmitImpl();
         aP5_Gx_msg=this.Gx_msg;
         aP6_IsOk=this.AV8IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2OperacionesTipo,(DateTime)AV3OperacionesFechaDesde,(DateTime)AV4OperacionesFechaHasta,(string)AV5OperacionesPeriodoCod,(long)AV6UserId,(string)Gx_msg,(bool)AV8IsOk} ;
         ClassLoader.Execute("aliquidacionsolicitudestotal","GeneXus.Programs","aliquidacionsolicitudestotal", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 7 ) )
         {
            Gx_msg = (string)(args[5]) ;
            AV8IsOk = (bool)(args[6]) ;
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
         Gx_msg = "";
         /* GeneXus formulas. */
      }

      private long AV6UserId ;
      private string AV2OperacionesTipo ;
      private string Gx_msg ;
      private DateTime AV3OperacionesFechaDesde ;
      private DateTime AV4OperacionesFechaHasta ;
      private bool AV8IsOk ;
      private string AV5OperacionesPeriodoCod ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP5_Gx_msg ;
      private bool aP6_IsOk ;
   }

}
