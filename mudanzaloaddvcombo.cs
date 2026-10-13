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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class mudanzaloaddvcombo : GXProcedure
   {
      public mudanzaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public mudanzaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_MudanzaId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV2ComboName = aP0_ComboName;
         this.AV3TrnMode = aP1_TrnMode;
         this.AV4IsDynamicCall = aP2_IsDynamicCall;
         this.AV5MudanzaId = aP3_MudanzaId;
         this.AV6SearchTxtParms = aP4_SearchTxtParms;
         this.AV7SelectedValue = "" ;
         this.AV8SelectedText = "" ;
         this.AV9Combo_DataJson = "" ;
         initialize();
         ExecutePrivate();
         aP5_SelectedValue=this.AV7SelectedValue;
         aP6_SelectedText=this.AV8SelectedText;
         aP7_Combo_DataJson=this.AV9Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                long aP3_MudanzaId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_MudanzaId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV9Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_MudanzaId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV2ComboName = aP0_ComboName;
         this.AV3TrnMode = aP1_TrnMode;
         this.AV4IsDynamicCall = aP2_IsDynamicCall;
         this.AV5MudanzaId = aP3_MudanzaId;
         this.AV6SearchTxtParms = aP4_SearchTxtParms;
         this.AV7SelectedValue = "" ;
         this.AV8SelectedText = "" ;
         this.AV9Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV7SelectedValue;
         aP6_SelectedText=this.AV8SelectedText;
         aP7_Combo_DataJson=this.AV9Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ComboName,(string)AV3TrnMode,(bool)AV4IsDynamicCall,(long)AV5MudanzaId,(string)AV6SearchTxtParms,(string)AV7SelectedValue,(string)AV8SelectedText,(string)AV9Combo_DataJson} ;
         ClassLoader.Execute("amudanzaloaddvcombo","GeneXus.Programs","amudanzaloaddvcombo", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 8 ) )
         {
            AV7SelectedValue = (string)(args[5]) ;
            AV8SelectedText = (string)(args[6]) ;
            AV9Combo_DataJson = (string)(args[7]) ;
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
         AV7SelectedValue = "";
         AV8SelectedText = "";
         AV9Combo_DataJson = "";
         /* GeneXus formulas. */
      }

      private long AV5MudanzaId ;
      private string AV3TrnMode ;
      private bool AV4IsDynamicCall ;
      private string AV9Combo_DataJson ;
      private string AV2ComboName ;
      private string AV6SearchTxtParms ;
      private string AV7SelectedValue ;
      private string AV8SelectedText ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

}
