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
   public class liquidacionsolicitudes : GXProcedure
   {
      public liquidacionsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public liquidacionsolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_OperacionesTipo ,
                           string aP1_OperacionesRef ,
                           string aP2_OperacionesNombreRef ,
                           DateTime aP3_OperacionesFechaDesde ,
                           DateTime aP4_OperacionesFechaHasta ,
                           GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                           string aP6_OperacionesPeriodoCod ,
                           out string aP7_Gx_msg ,
                           out bool aP8_IsOk )
      {
         this.AV2OperacionesTipo = aP0_OperacionesTipo;
         this.AV3OperacionesRef = aP1_OperacionesRef;
         this.AV4OperacionesNombreRef = aP2_OperacionesNombreRef;
         this.AV5OperacionesFechaDesde = aP3_OperacionesFechaDesde;
         this.AV6OperacionesFechaHasta = aP4_OperacionesFechaHasta;
         this.AV7BalancesSeleccionados = aP5_BalancesSeleccionados;
         this.AV8OperacionesPeriodoCod = aP6_OperacionesPeriodoCod;
         this.Gx_msg = "" ;
         this.AV10IsOk = false ;
         initialize();
         ExecutePrivate();
         aP7_Gx_msg=this.Gx_msg;
         aP8_IsOk=this.AV10IsOk;
      }

      public bool executeUdp( string aP0_OperacionesTipo ,
                              string aP1_OperacionesRef ,
                              string aP2_OperacionesNombreRef ,
                              DateTime aP3_OperacionesFechaDesde ,
                              DateTime aP4_OperacionesFechaHasta ,
                              GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                              string aP6_OperacionesPeriodoCod ,
                              out string aP7_Gx_msg )
      {
         execute(aP0_OperacionesTipo, aP1_OperacionesRef, aP2_OperacionesNombreRef, aP3_OperacionesFechaDesde, aP4_OperacionesFechaHasta, aP5_BalancesSeleccionados, aP6_OperacionesPeriodoCod, out aP7_Gx_msg, out aP8_IsOk);
         return AV10IsOk ;
      }

      public void executeSubmit( string aP0_OperacionesTipo ,
                                 string aP1_OperacionesRef ,
                                 string aP2_OperacionesNombreRef ,
                                 DateTime aP3_OperacionesFechaDesde ,
                                 DateTime aP4_OperacionesFechaHasta ,
                                 GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                                 string aP6_OperacionesPeriodoCod ,
                                 out string aP7_Gx_msg ,
                                 out bool aP8_IsOk )
      {
         this.AV2OperacionesTipo = aP0_OperacionesTipo;
         this.AV3OperacionesRef = aP1_OperacionesRef;
         this.AV4OperacionesNombreRef = aP2_OperacionesNombreRef;
         this.AV5OperacionesFechaDesde = aP3_OperacionesFechaDesde;
         this.AV6OperacionesFechaHasta = aP4_OperacionesFechaHasta;
         this.AV7BalancesSeleccionados = aP5_BalancesSeleccionados;
         this.AV8OperacionesPeriodoCod = aP6_OperacionesPeriodoCod;
         this.Gx_msg = "" ;
         this.AV10IsOk = false ;
         SubmitImpl();
         aP7_Gx_msg=this.Gx_msg;
         aP8_IsOk=this.AV10IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2OperacionesTipo,(string)AV3OperacionesRef,(string)AV4OperacionesNombreRef,(DateTime)AV5OperacionesFechaDesde,(DateTime)AV6OperacionesFechaHasta,(GxSimpleCollection<long>)AV7BalancesSeleccionados,(string)AV8OperacionesPeriodoCod,(string)Gx_msg,(bool)AV10IsOk} ;
         ClassLoader.Execute("aliquidacionsolicitudes","GeneXus.Programs","aliquidacionsolicitudes", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 9 ) )
         {
            Gx_msg = (string)(args[7]) ;
            AV10IsOk = (bool)(args[8]) ;
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

      private string AV2OperacionesTipo ;
      private string AV3OperacionesRef ;
      private string AV4OperacionesNombreRef ;
      private string Gx_msg ;
      private DateTime AV5OperacionesFechaDesde ;
      private DateTime AV6OperacionesFechaHasta ;
      private bool AV10IsOk ;
      private string AV8OperacionesPeriodoCod ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV7BalancesSeleccionados ;
      private Object[] args ;
      private string aP7_Gx_msg ;
      private bool aP8_IsOk ;
   }

}
