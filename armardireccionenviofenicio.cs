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
   public class armardireccionenviofenicio : GXProcedure
   {
      public armardireccionenviofenicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public armardireccionenviofenicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Localidad ,
                           string aP1_Calle ,
                           string aP2_NumeroPuerta ,
                           string aP3_NumeroApto ,
                           out string aP4_Direccion )
      {
         this.AV9Localidad = aP0_Localidad;
         this.AV10Calle = aP1_Calle;
         this.AV11NumeroPuerta = aP2_NumeroPuerta;
         this.AV12NumeroApto = aP3_NumeroApto;
         this.AV8Direccion = "" ;
         initialize();
         ExecutePrivate();
         aP4_Direccion=this.AV8Direccion;
      }

      public string executeUdp( string aP0_Localidad ,
                                string aP1_Calle ,
                                string aP2_NumeroPuerta ,
                                string aP3_NumeroApto )
      {
         execute(aP0_Localidad, aP1_Calle, aP2_NumeroPuerta, aP3_NumeroApto, out aP4_Direccion);
         return AV8Direccion ;
      }

      public void executeSubmit( string aP0_Localidad ,
                                 string aP1_Calle ,
                                 string aP2_NumeroPuerta ,
                                 string aP3_NumeroApto ,
                                 out string aP4_Direccion )
      {
         this.AV9Localidad = aP0_Localidad;
         this.AV10Calle = aP1_Calle;
         this.AV11NumeroPuerta = aP2_NumeroPuerta;
         this.AV12NumeroApto = aP3_NumeroApto;
         this.AV8Direccion = "" ;
         SubmitImpl();
         aP4_Direccion=this.AV8Direccion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Direccion = "";
         AV13TieneAlgo = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Localidad)) )
         {
            AV8Direccion = AV9Localidad;
            AV13TieneAlgo = true;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Calle)) )
         {
            if ( AV13TieneAlgo )
            {
               AV8Direccion += ", ";
            }
            AV8Direccion += AV10Calle;
            AV13TieneAlgo = true;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11NumeroPuerta)) )
         {
            if ( AV13TieneAlgo )
            {
               AV8Direccion += " ";
            }
            AV8Direccion += AV11NumeroPuerta;
            AV13TieneAlgo = true;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12NumeroApto)) )
         {
            AV8Direccion += context.GetMessage( " Apto ", "") + AV12NumeroApto;
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV8Direccion = "";
         /* GeneXus formulas. */
      }

      private string AV8Direccion ;
      private bool AV13TieneAlgo ;
      private string AV9Localidad ;
      private string AV10Calle ;
      private string AV11NumeroPuerta ;
      private string AV12NumeroApto ;
      private string aP4_Direccion ;
   }

}
