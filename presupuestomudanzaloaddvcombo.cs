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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class presupuestomudanzaloaddvcombo : GXProcedure
   {
      public presupuestomudanzaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public presupuestomudanzaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ComboName ,
                           string aP1_SearchTxtParms ,
                           out string aP2_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18SearchTxtParms = aP1_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         initialize();
         ExecutePrivate();
         aP2_Combo_DataJson=this.AV19Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_SearchTxtParms, out aP2_Combo_DataJson);
         return AV19Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_SearchTxtParms ,
                                 out string aP2_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18SearchTxtParms = aP1_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         SubmitImpl();
         aP2_Combo_DataJson=this.AV19Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV18SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? "" : StringUtil.Substring( AV18SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "DireccionDestino") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DIRECCIONDESTINO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "DireccionOrigen") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DIRECCIONORIGEN' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_DIRECCIONDESTINO' Routine */
         returnInSub = false;
         AV15Combo_Data.Sort("Title");
         AV19Combo_DataJson = AV15Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_DIRECCIONORIGEN' Routine */
         returnInSub = false;
         AV15Combo_Data.Sort("Title");
         AV19Combo_DataJson = AV15Combo_Data.ToJSonString(false);
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
         AV19Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV17ComboName ;
      private string AV18SearchTxtParms ;
      private string AV14SearchTxt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP2_Combo_DataJson ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.presupuestomudanzaloaddvcombo_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class presupuestomudanzaloaddvcombo_services : GxRestService
   {
      [OperationContract(Name = "PresupuestoMudanzaLoadDVCombo" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( string ComboName ,
                           string SearchTxtParms ,
                           out string Combo_DataJson )
      {
         Combo_DataJson = "" ;
         try
         {
            if ( ! ProcessHeaders("presupuestomudanzaloaddvcombo") )
            {
               return  ;
            }
            presupuestomudanzaloaddvcombo worker = new presupuestomudanzaloaddvcombo(context);
            worker.IsMain = RunAsMain ;
            worker.execute(ComboName,SearchTxtParms,out Combo_DataJson );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}
