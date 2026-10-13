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
   public class profcomisionesrubroswcgetfilterdata : GXProcedure
   {
      public profcomisionesrubroswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisionesrubroswcgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV36MaxItems = 10;
            AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
            AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("ProfComisionesRubrosWCGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfComisionesRubrosWCGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("ProfComisionesRubrosWCGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSID") == 0 )
            {
               AV11TFProfComisionesRubrosId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProfComisionesRubrosId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV13TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFMEDIDASID") == 0 )
            {
               AV15TFMedidasID = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFINVENTARIOID") == 0 )
            {
               AV17TFInventarioId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFInventarioId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFINVENTARIOPRECIOFINAL") == 0 )
            {
               AV19TFInventarioPrecioFinal = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV20TFInventarioPrecioFinal_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSTIPO_SEL") == 0 )
            {
               AV21TFProfComisionesRubrosTipo_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV22TFProfComisionesRubrosTipo_Sels.FromJSonString(AV21TFProfComisionesRubrosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSVALOR") == 0 )
            {
               AV23TFProfComisionesRubrosValor = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV24TFProfComisionesRubrosValor_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSGAN") == 0 )
            {
               AV25TFProfComisionesRubrosGan = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV26TFProfComisionesRubrosGan_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESRUBROSGANPRF") == 0 )
            {
               AV27TFProfComisionesRubrosGanPRF = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV28TFProfComisionesRubrosGanPRF_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV29TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV30TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV31TFProveedorNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV32TFProveedorNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "PARM_&PROFCOMISIONESID") == 0 )
            {
               AV55ProfComisionesID = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV31TFProveedorNombre = AV33SearchTxt;
         AV32TFProveedorNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A453ProfComisionesRubrosTipo ,
                                              AV22TFProfComisionesRubrosTipo_Sels ,
                                              AV11TFProfComisionesRubrosId ,
                                              AV12TFProfComisionesRubrosId_To ,
                                              AV13TFRubrosId ,
                                              AV14TFRubrosId_To ,
                                              AV15TFMedidasID ,
                                              AV16TFMedidasID_To ,
                                              AV17TFInventarioId ,
                                              AV18TFInventarioId_To ,
                                              AV19TFInventarioPrecioFinal ,
                                              AV20TFInventarioPrecioFinal_To ,
                                              AV22TFProfComisionesRubrosTipo_Sels.Count ,
                                              AV23TFProfComisionesRubrosValor ,
                                              AV24TFProfComisionesRubrosValor_To ,
                                              AV29TFProveedorID ,
                                              AV30TFProveedorID_To ,
                                              AV32TFProveedorNombre_Sel ,
                                              AV31TFProveedorNombre ,
                                              A452ProfComisionesRubrosId ,
                                              A121RubrosId ,
                                              A137MedidasID ,
                                              A135InventarioId ,
                                              A181InventarioPrecioFinal ,
                                              A454ProfComisionesRubrosValor ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              AV25TFProfComisionesRubrosGan ,
                                              A456ProfComisionesRubrosGan ,
                                              AV26TFProfComisionesRubrosGan_To ,
                                              AV27TFProfComisionesRubrosGanPRF ,
                                              A457ProfComisionesRubrosGanPRF ,
                                              AV28TFProfComisionesRubrosGanPRF_To ,
                                              AV55ProfComisionesID ,
                                              A450ProfComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV31TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV31TFProveedorNombre), 80, "%");
         /* Using cursor P005T2 */
         pr_default.execute(0, new Object[] {AV55ProfComisionesID, AV11TFProfComisionesRubrosId, AV12TFProfComisionesRubrosId_To, AV13TFRubrosId, AV14TFRubrosId_To, AV15TFMedidasID, AV16TFMedidasID_To, AV17TFInventarioId, AV18TFInventarioId_To, AV19TFInventarioPrecioFinal, AV20TFInventarioPrecioFinal_To, AV23TFProfComisionesRubrosValor, AV24TFProfComisionesRubrosValor_To, AV29TFProveedorID, AV30TFProveedorID_To, lV31TFProveedorNombre, AV32TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5T2 = false;
            A450ProfComisionesID = P005T2_A450ProfComisionesID[0];
            A133ProveedorID = P005T2_A133ProveedorID[0];
            n133ProveedorID = P005T2_n133ProveedorID[0];
            A282ProveedorNombre = P005T2_A282ProveedorNombre[0];
            A135InventarioId = P005T2_A135InventarioId[0];
            A137MedidasID = P005T2_A137MedidasID[0];
            A121RubrosId = P005T2_A121RubrosId[0];
            A452ProfComisionesRubrosId = P005T2_A452ProfComisionesRubrosId[0];
            A181InventarioPrecioFinal = P005T2_A181InventarioPrecioFinal[0];
            A453ProfComisionesRubrosTipo = P005T2_A453ProfComisionesRubrosTipo[0];
            A454ProfComisionesRubrosValor = P005T2_A454ProfComisionesRubrosValor[0];
            A282ProveedorNombre = P005T2_A282ProveedorNombre[0];
            A181InventarioPrecioFinal = P005T2_A181InventarioPrecioFinal[0];
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
               }
               else
               {
                  A457ProfComisionesRubrosGanPRF = 0;
               }
            }
            if ( (0==AV27TFProfComisionesRubrosGanPRF) || ( ( A457ProfComisionesRubrosGanPRF >= AV27TFProfComisionesRubrosGanPRF ) ) )
            {
               if ( (0==AV28TFProfComisionesRubrosGanPRF_To) || ( ( A457ProfComisionesRubrosGanPRF <= AV28TFProfComisionesRubrosGanPRF_To ) ) )
               {
                  A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
                  if ( (0==AV25TFProfComisionesRubrosGan) || ( ( A456ProfComisionesRubrosGan >= AV25TFProfComisionesRubrosGan ) ) )
                  {
                     if ( (0==AV26TFProfComisionesRubrosGan_To) || ( ( A456ProfComisionesRubrosGan <= AV26TFProfComisionesRubrosGan_To ) ) )
                     {
                        AV43count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( P005T2_A450ProfComisionesID[0] == A450ProfComisionesID ) && ( P005T2_A133ProveedorID[0] == A133ProveedorID ) )
                        {
                           BRK5T2 = false;
                           A452ProfComisionesRubrosId = P005T2_A452ProfComisionesRubrosId[0];
                           AV43count = (long)(AV43count+1);
                           BRK5T2 = true;
                           pr_default.readNext(0);
                        }
                        AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
                        AV37InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV37InsertIndex = (int)(AV37InsertIndex+1);
                        }
                        AV39Options.Add(AV38Option, AV37InsertIndex);
                        AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
                        if ( AV39Options.Count == AV34SkipItems + 11 )
                        {
                           AV39Options.RemoveItem(AV39Options.Count);
                           AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            if ( ! BRK5T2 )
            {
               BRK5T2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV47GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV21TFProfComisionesRubrosTipo_SelsJson = "";
         AV22TFProfComisionesRubrosTipo_Sels = new GxSimpleCollection<string>();
         AV31TFProveedorNombre = "";
         AV32TFProveedorNombre_Sel = "";
         lV31TFProveedorNombre = "";
         A453ProfComisionesRubrosTipo = "";
         A282ProveedorNombre = "";
         P005T2_A450ProfComisionesID = new long[1] ;
         P005T2_A133ProveedorID = new long[1] ;
         P005T2_n133ProveedorID = new bool[] {false} ;
         P005T2_A282ProveedorNombre = new string[] {""} ;
         P005T2_A135InventarioId = new long[1] ;
         P005T2_A137MedidasID = new long[1] ;
         P005T2_A121RubrosId = new short[1] ;
         P005T2_A452ProfComisionesRubrosId = new long[1] ;
         P005T2_A181InventarioPrecioFinal = new decimal[1] ;
         P005T2_A453ProfComisionesRubrosTipo = new string[] {""} ;
         P005T2_A454ProfComisionesRubrosValor = new decimal[1] ;
         AV38Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisionesrubroswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005T2_A450ProfComisionesID, P005T2_A133ProveedorID, P005T2_n133ProveedorID, P005T2_A282ProveedorNombre, P005T2_A135InventarioId, P005T2_A137MedidasID, P005T2_A121RubrosId, P005T2_A452ProfComisionesRubrosId, P005T2_A181InventarioPrecioFinal, P005T2_A453ProfComisionesRubrosTipo,
               P005T2_A454ProfComisionesRubrosValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV13TFRubrosId ;
      private short AV14TFRubrosId_To ;
      private short A121RubrosId ;
      private int AV56GXV1 ;
      private int AV22TFProfComisionesRubrosTipo_Sels_Count ;
      private int AV37InsertIndex ;
      private long AV11TFProfComisionesRubrosId ;
      private long AV12TFProfComisionesRubrosId_To ;
      private long AV15TFMedidasID ;
      private long AV16TFMedidasID_To ;
      private long AV17TFInventarioId ;
      private long AV18TFInventarioId_To ;
      private long AV25TFProfComisionesRubrosGan ;
      private long AV26TFProfComisionesRubrosGan_To ;
      private long AV27TFProfComisionesRubrosGanPRF ;
      private long AV28TFProfComisionesRubrosGanPRF_To ;
      private long AV29TFProveedorID ;
      private long AV30TFProveedorID_To ;
      private long AV55ProfComisionesID ;
      private long A452ProfComisionesRubrosId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A133ProveedorID ;
      private long A456ProfComisionesRubrosGan ;
      private long A457ProfComisionesRubrosGanPRF ;
      private long A450ProfComisionesID ;
      private long AV43count ;
      private decimal AV19TFInventarioPrecioFinal ;
      private decimal AV20TFInventarioPrecioFinal_To ;
      private decimal AV23TFProfComisionesRubrosValor ;
      private decimal AV24TFProfComisionesRubrosValor_To ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A454ProfComisionesRubrosValor ;
      private string AV31TFProveedorNombre ;
      private string AV32TFProveedorNombre_Sel ;
      private string lV31TFProveedorNombre ;
      private string A453ProfComisionesRubrosTipo ;
      private string A282ProveedorNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK5T2 ;
      private bool n133ProveedorID ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV21TFProfComisionesRubrosTipo_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV46GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private GxSimpleCollection<string> AV22TFProfComisionesRubrosTipo_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P005T2_A450ProfComisionesID ;
      private long[] P005T2_A133ProveedorID ;
      private bool[] P005T2_n133ProveedorID ;
      private string[] P005T2_A282ProveedorNombre ;
      private long[] P005T2_A135InventarioId ;
      private long[] P005T2_A137MedidasID ;
      private short[] P005T2_A121RubrosId ;
      private long[] P005T2_A452ProfComisionesRubrosId ;
      private decimal[] P005T2_A181InventarioPrecioFinal ;
      private string[] P005T2_A453ProfComisionesRubrosTipo ;
      private decimal[] P005T2_A454ProfComisionesRubrosValor ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profcomisionesrubroswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005T2( IGxContext context ,
                                             string A453ProfComisionesRubrosTipo ,
                                             GxSimpleCollection<string> AV22TFProfComisionesRubrosTipo_Sels ,
                                             long AV11TFProfComisionesRubrosId ,
                                             long AV12TFProfComisionesRubrosId_To ,
                                             short AV13TFRubrosId ,
                                             short AV14TFRubrosId_To ,
                                             long AV15TFMedidasID ,
                                             long AV16TFMedidasID_To ,
                                             long AV17TFInventarioId ,
                                             long AV18TFInventarioId_To ,
                                             decimal AV19TFInventarioPrecioFinal ,
                                             decimal AV20TFInventarioPrecioFinal_To ,
                                             int AV22TFProfComisionesRubrosTipo_Sels_Count ,
                                             decimal AV23TFProfComisionesRubrosValor ,
                                             decimal AV24TFProfComisionesRubrosValor_To ,
                                             long AV29TFProveedorID ,
                                             long AV30TFProveedorID_To ,
                                             string AV32TFProveedorNombre_Sel ,
                                             string AV31TFProveedorNombre ,
                                             long A452ProfComisionesRubrosId ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId ,
                                             decimal A181InventarioPrecioFinal ,
                                             decimal A454ProfComisionesRubrosValor ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long AV25TFProfComisionesRubrosGan ,
                                             long A456ProfComisionesRubrosGan ,
                                             long AV26TFProfComisionesRubrosGan_To ,
                                             long AV27TFProfComisionesRubrosGanPRF ,
                                             long A457ProfComisionesRubrosGanPRF ,
                                             long AV28TFProfComisionesRubrosGanPRF_To ,
                                             long AV55ProfComisionesID ,
                                             long A450ProfComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProfComisionesID], T1.[ProveedorID], T2.[ProveedorNombre], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProfComisionesRubrosId], T3.[InventarioPrecioFinal], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor] FROM (([ProfComisionesRubros] T1 LEFT JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ProfComisionesID] = @AV55ProfComisionesID)");
         if ( ! (0==AV11TFProfComisionesRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] >= @AV11TFProfComisionesRubrosId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFProfComisionesRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosId] <= @AV12TFProfComisionesRubrosId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV13TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV13TFRubrosId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV14TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV14TFRubrosId_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV15TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV15TFMedidasID)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV16TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV16TFMedidasID_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV17TFInventarioId) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] >= @AV17TFInventarioId)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV18TFInventarioId_To) )
         {
            AddWhere(sWhereString, "(T1.[InventarioId] <= @AV18TFInventarioId_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] >= @AV19TFInventarioPrecioFinal)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T3.[InventarioPrecioFinal] <= @AV20TFInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV22TFProfComisionesRubrosTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFProfComisionesRubrosTipo_Sels, "T1.[ProfComisionesRubrosTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFProfComisionesRubrosValor) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] >= @AV23TFProfComisionesRubrosValor)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFProfComisionesRubrosValor_To) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesRubrosValor] <= @AV24TFProfComisionesRubrosValor_To)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV29TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV29TFProveedorID)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV30TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV30TFProveedorID_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV31TFProveedorNombre))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV32TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV32TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] IS NULL or (T2.[ProveedorNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfComisionesID], T1.[ProveedorID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005T2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (int)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005T2;
          prmP005T2 = new Object[] {
          new ParDef("@AV55ProfComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProfComisionesRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProfComisionesRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV14TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@AV15TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV17TFInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFInventarioPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV23TFProfComisionesRubrosValor",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFProfComisionesRubrosValor_To",GXType.Decimal,18,2) ,
          new ParDef("@AV29TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV31TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV32TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 1);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.profcomisionesrubroswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class profcomisionesrubroswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProfComisionesRubrosWCGetFilterData" )]
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
          if ( ! ProcessHeaders("profcomisionesrubroswcgetfilterdata") )
          {
             return  ;
          }
          profcomisionesrubroswcgetfilterdata worker = new profcomisionesrubroswcgetfilterdata(context);
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
