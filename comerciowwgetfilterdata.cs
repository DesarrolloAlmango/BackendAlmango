using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class comerciowwgetfilterdata : GXProcedure
   {
      public comerciowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comerciowwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedorDashboard", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV26MaxItems = 10;
            AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
            AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDORCONTACTO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORCONTACTOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDORCONTACTOCELL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORCONTACTOCELLOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("ComercioWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComercioWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("ComercioWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORCONTACTO") == 0 )
            {
               AV13TFProveedorContacto = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORCONTACTO_SEL") == 0 )
            {
               AV14TFProveedorContacto_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORCONTACTOCELL") == 0 )
            {
               AV15TFProveedorContactoCell = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORCONTACTOCELL_SEL") == 0 )
            {
               AV16TFProveedorContactoCell_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORCONTACTOOPTIONS' Routine */
         returnInSub = false;
         AV13TFProveedorContacto = AV23SearchTxt;
         AV14TFProveedorContacto_Sel = "";
         AV48Comerciowwds_1_tfproveedorcontacto = AV13TFProveedorContacto;
         AV49Comerciowwds_2_tfproveedorcontacto_sel = AV14TFProveedorContacto_Sel;
         AV50Comerciowwds_3_tfproveedorcontactocell = AV15TFProveedorContactoCell;
         AV51Comerciowwds_4_tfproveedorcontactocell_sel = AV16TFProveedorContactoCell_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Comerciowwds_2_tfproveedorcontacto_sel ,
                                              AV48Comerciowwds_1_tfproveedorcontacto ,
                                              AV51Comerciowwds_4_tfproveedorcontactocell_sel ,
                                              AV50Comerciowwds_3_tfproveedorcontactocell ,
                                              A683ProveedorContacto ,
                                              A684ProveedorContactoCell ,
                                              A133ProveedorID ,
                                              AV45ProveedorID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV48Comerciowwds_1_tfproveedorcontacto = StringUtil.PadR( StringUtil.RTrim( AV48Comerciowwds_1_tfproveedorcontacto), 128, "%");
         lV50Comerciowwds_3_tfproveedorcontactocell = StringUtil.PadR( StringUtil.RTrim( AV50Comerciowwds_3_tfproveedorcontactocell), 20, "%");
         /* Using cursor P00C02 */
         pr_default.execute(0, new Object[] {AV45ProveedorID, lV48Comerciowwds_1_tfproveedorcontacto, AV49Comerciowwds_2_tfproveedorcontacto_sel, lV50Comerciowwds_3_tfproveedorcontactocell, AV51Comerciowwds_4_tfproveedorcontactocell_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC02 = false;
            A133ProveedorID = P00C02_A133ProveedorID[0];
            A683ProveedorContacto = P00C02_A683ProveedorContacto[0];
            n683ProveedorContacto = P00C02_n683ProveedorContacto[0];
            A684ProveedorContactoCell = P00C02_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = P00C02_n684ProveedorContactoCell[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00C02_A683ProveedorContacto[0], A683ProveedorContacto) == 0 ) )
            {
               BRKC02 = false;
               A133ProveedorID = P00C02_A133ProveedorID[0];
               AV33count = (long)(AV33count+1);
               BRKC02 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? "<#Empty#>" : A683ProveedorContacto);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRKC02 )
            {
               BRKC02 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORCONTACTOCELLOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorContactoCell = AV23SearchTxt;
         AV16TFProveedorContactoCell_Sel = "";
         AV48Comerciowwds_1_tfproveedorcontacto = AV13TFProveedorContacto;
         AV49Comerciowwds_2_tfproveedorcontacto_sel = AV14TFProveedorContacto_Sel;
         AV50Comerciowwds_3_tfproveedorcontactocell = AV15TFProveedorContactoCell;
         AV51Comerciowwds_4_tfproveedorcontactocell_sel = AV16TFProveedorContactoCell_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV49Comerciowwds_2_tfproveedorcontacto_sel ,
                                              AV48Comerciowwds_1_tfproveedorcontacto ,
                                              AV51Comerciowwds_4_tfproveedorcontactocell_sel ,
                                              AV50Comerciowwds_3_tfproveedorcontactocell ,
                                              A683ProveedorContacto ,
                                              A684ProveedorContactoCell ,
                                              A133ProveedorID ,
                                              AV45ProveedorID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV48Comerciowwds_1_tfproveedorcontacto = StringUtil.PadR( StringUtil.RTrim( AV48Comerciowwds_1_tfproveedorcontacto), 128, "%");
         lV50Comerciowwds_3_tfproveedorcontactocell = StringUtil.PadR( StringUtil.RTrim( AV50Comerciowwds_3_tfproveedorcontactocell), 20, "%");
         /* Using cursor P00C03 */
         pr_default.execute(1, new Object[] {AV45ProveedorID, lV48Comerciowwds_1_tfproveedorcontacto, AV49Comerciowwds_2_tfproveedorcontacto_sel, lV50Comerciowwds_3_tfproveedorcontactocell, AV51Comerciowwds_4_tfproveedorcontactocell_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC04 = false;
            A133ProveedorID = P00C03_A133ProveedorID[0];
            A684ProveedorContactoCell = P00C03_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = P00C03_n684ProveedorContactoCell[0];
            A683ProveedorContacto = P00C03_A683ProveedorContacto[0];
            n683ProveedorContacto = P00C03_n683ProveedorContacto[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00C03_A684ProveedorContactoCell[0], A684ProveedorContactoCell) == 0 ) )
            {
               BRKC04 = false;
               A133ProveedorID = P00C03_A133ProveedorID[0];
               AV33count = (long)(AV33count+1);
               BRKC04 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? "<#Empty#>" : A684ProveedorContactoCell);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRKC04 )
            {
               BRKC04 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV13TFProveedorContacto = "";
         AV14TFProveedorContacto_Sel = "";
         AV15TFProveedorContactoCell = "";
         AV16TFProveedorContactoCell_Sel = "";
         AV48Comerciowwds_1_tfproveedorcontacto = "";
         AV49Comerciowwds_2_tfproveedorcontacto_sel = "";
         AV50Comerciowwds_3_tfproveedorcontactocell = "";
         AV51Comerciowwds_4_tfproveedorcontactocell_sel = "";
         lV48Comerciowwds_1_tfproveedorcontacto = "";
         lV50Comerciowwds_3_tfproveedorcontactocell = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         P00C02_A133ProveedorID = new long[1] ;
         P00C02_A683ProveedorContacto = new string[] {""} ;
         P00C02_n683ProveedorContacto = new bool[] {false} ;
         P00C02_A684ProveedorContactoCell = new string[] {""} ;
         P00C02_n684ProveedorContactoCell = new bool[] {false} ;
         AV28Option = "";
         P00C03_A133ProveedorID = new long[1] ;
         P00C03_A684ProveedorContactoCell = new string[] {""} ;
         P00C03_n684ProveedorContactoCell = new bool[] {false} ;
         P00C03_A683ProveedorContacto = new string[] {""} ;
         P00C03_n683ProveedorContacto = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comerciowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C02_A133ProveedorID, P00C02_A683ProveedorContacto, P00C02_n683ProveedorContacto, P00C02_A684ProveedorContactoCell, P00C02_n684ProveedorContactoCell
               }
               , new Object[] {
               P00C03_A133ProveedorID, P00C03_A684ProveedorContactoCell, P00C03_n684ProveedorContactoCell, P00C03_A683ProveedorContacto, P00C03_n683ProveedorContacto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV46GXV1 ;
      private long A133ProveedorID ;
      private long AV45ProveedorID ;
      private long AV33count ;
      private string AV13TFProveedorContacto ;
      private string AV14TFProveedorContacto_Sel ;
      private string AV15TFProveedorContactoCell ;
      private string AV16TFProveedorContactoCell_Sel ;
      private string AV48Comerciowwds_1_tfproveedorcontacto ;
      private string AV49Comerciowwds_2_tfproveedorcontacto_sel ;
      private string AV50Comerciowwds_3_tfproveedorcontactocell ;
      private string AV51Comerciowwds_4_tfproveedorcontactocell_sel ;
      private string lV48Comerciowwds_1_tfproveedorcontacto ;
      private string lV50Comerciowwds_3_tfproveedorcontactocell ;
      private string A683ProveedorContacto ;
      private string A684ProveedorContactoCell ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKC02 ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool BRKC04 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P00C02_A133ProveedorID ;
      private string[] P00C02_A683ProveedorContacto ;
      private bool[] P00C02_n683ProveedorContacto ;
      private string[] P00C02_A684ProveedorContactoCell ;
      private bool[] P00C02_n684ProveedorContactoCell ;
      private long[] P00C03_A133ProveedorID ;
      private string[] P00C03_A684ProveedorContactoCell ;
      private bool[] P00C03_n684ProveedorContactoCell ;
      private string[] P00C03_A683ProveedorContacto ;
      private bool[] P00C03_n683ProveedorContacto ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comerciowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C02( IGxContext context ,
                                             string AV49Comerciowwds_2_tfproveedorcontacto_sel ,
                                             string AV48Comerciowwds_1_tfproveedorcontacto ,
                                             string AV51Comerciowwds_4_tfproveedorcontactocell_sel ,
                                             string AV50Comerciowwds_3_tfproveedorcontactocell ,
                                             string A683ProveedorContacto ,
                                             string A684ProveedorContactoCell ,
                                             long A133ProveedorID ,
                                             long AV45ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ProveedorID], [ProveedorContacto], [ProveedorContactoCell] FROM [Proveedor]";
         AddWhere(sWhereString, "([ProveedorID] = @AV45ProveedorID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Comerciowwds_2_tfproveedorcontacto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Comerciowwds_1_tfproveedorcontacto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorContacto]) like UPPER(@lV48Comerciowwds_1_tfproveedorcontacto))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Comerciowwds_2_tfproveedorcontacto_sel)) && ! ( StringUtil.StrCmp(AV49Comerciowwds_2_tfproveedorcontacto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorContacto] = @AV49Comerciowwds_2_tfproveedorcontacto_sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Comerciowwds_2_tfproveedorcontacto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorContacto] IS NULL or ([ProveedorContacto] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Comerciowwds_4_tfproveedorcontactocell_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Comerciowwds_3_tfproveedorcontactocell)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorContactoCell]) like UPPER(@lV50Comerciowwds_3_tfproveedorcontactocell))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Comerciowwds_4_tfproveedorcontactocell_sel)) && ! ( StringUtil.StrCmp(AV51Comerciowwds_4_tfproveedorcontactocell_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorContactoCell] = @AV51Comerciowwds_4_tfproveedorcontactocell_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Comerciowwds_4_tfproveedorcontactocell_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorContactoCell] IS NULL or ([ProveedorContactoCell] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorContacto]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00C03( IGxContext context ,
                                             string AV49Comerciowwds_2_tfproveedorcontacto_sel ,
                                             string AV48Comerciowwds_1_tfproveedorcontacto ,
                                             string AV51Comerciowwds_4_tfproveedorcontactocell_sel ,
                                             string AV50Comerciowwds_3_tfproveedorcontactocell ,
                                             string A683ProveedorContacto ,
                                             string A684ProveedorContactoCell ,
                                             long A133ProveedorID ,
                                             long AV45ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ProveedorID], [ProveedorContactoCell], [ProveedorContacto] FROM [Proveedor]";
         AddWhere(sWhereString, "([ProveedorID] = @AV45ProveedorID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Comerciowwds_2_tfproveedorcontacto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Comerciowwds_1_tfproveedorcontacto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorContacto]) like UPPER(@lV48Comerciowwds_1_tfproveedorcontacto))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Comerciowwds_2_tfproveedorcontacto_sel)) && ! ( StringUtil.StrCmp(AV49Comerciowwds_2_tfproveedorcontacto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorContacto] = @AV49Comerciowwds_2_tfproveedorcontacto_sel)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Comerciowwds_2_tfproveedorcontacto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorContacto] IS NULL or ([ProveedorContacto] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Comerciowwds_4_tfproveedorcontactocell_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Comerciowwds_3_tfproveedorcontactocell)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorContactoCell]) like UPPER(@lV50Comerciowwds_3_tfproveedorcontactocell))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Comerciowwds_4_tfproveedorcontactocell_sel)) && ! ( StringUtil.StrCmp(AV51Comerciowwds_4_tfproveedorcontactocell_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorContactoCell] = @AV51Comerciowwds_4_tfproveedorcontactocell_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Comerciowwds_4_tfproveedorcontactocell_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorContactoCell] IS NULL or ([ProveedorContactoCell] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorContactoCell]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00C02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
               case 1 :
                     return conditional_P00C03(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C02;
          prmP00C02 = new Object[] {
          new ParDef("@AV45ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV48Comerciowwds_1_tfproveedorcontacto",GXType.Char,128,0) ,
          new ParDef("@AV49Comerciowwds_2_tfproveedorcontacto_sel",GXType.NChar,128,0) ,
          new ParDef("@lV50Comerciowwds_3_tfproveedorcontactocell",GXType.Char,20,0) ,
          new ParDef("@AV51Comerciowwds_4_tfproveedorcontactocell_sel",GXType.NChar,20,0)
          };
          Object[] prmP00C03;
          prmP00C03 = new Object[] {
          new ParDef("@AV45ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@lV48Comerciowwds_1_tfproveedorcontacto",GXType.Char,128,0) ,
          new ParDef("@AV49Comerciowwds_2_tfproveedorcontacto_sel",GXType.NChar,128,0) ,
          new ParDef("@lV50Comerciowwds_3_tfproveedorcontactocell",GXType.Char,20,0) ,
          new ParDef("@AV51Comerciowwds_4_tfproveedorcontactocell_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C03,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 128);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comerciowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comerciowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComercioWWGetFilterData" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string DDOName ,
                         string SearchTxtParms ,
                         string SearchTxtTo ,
                         out string OptionsJson ,
                         out string OptionsDescJson ,
                         out string OptionIndexesJson )
    {
       OptionsJson = "" ;
       OptionsDescJson = "" ;
       OptionIndexesJson = "" ;
       try
       {
          if ( ! ProcessHeaders("comerciowwgetfilterdata") )
          {
             return  ;
          }
          comerciowwgetfilterdata worker = new comerciowwgetfilterdata(context);
          worker.IsMain = RunAsMain ;
          worker.execute(DDOName,SearchTxtParms,SearchTxtTo,out OptionsJson,out OptionsDescJson,out OptionIndexesJson );
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
