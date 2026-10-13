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
   public class textosinventariowcgetfilterdata : GXProcedure
   {
      public textosinventariowcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textosinventariowcgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV24MaxItems = 10;
            AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
            AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MEDIDASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMEDIDASNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("TextosInventarioWCGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosInventarioWCGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("TextosInventarioWCGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV17TFMedidasNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV18TFMedidasNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV19TFMedidasEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFMedidasEstado_Sels.FromJSonString(AV19TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&TEXTOSID") == 0 )
            {
               AV44TextosId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV21SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV20TFMedidasEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV18TFMedidasNombre_Sel ,
                                              AV17TFMedidasNombre ,
                                              AV20TFMedidasEstado_Sels.Count ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A138MedidasNombre ,
                                              AV43FilterFullText ,
                                              AV44TextosId ,
                                              A150TextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         lV17TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFMedidasNombre), 50, "%");
         /* Using cursor P004Y2 */
         pr_default.execute(0, new Object[] {AV44TextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel, lV17TFMedidasNombre, AV18TFMedidasNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4Y2 = false;
            A150TextosId = P004Y2_A150TextosId[0];
            n150TextosId = P004Y2_n150TextosId[0];
            A121RubrosId = P004Y2_A121RubrosId[0];
            A139MedidasEstado = P004Y2_A139MedidasEstado[0];
            n139MedidasEstado = P004Y2_n139MedidasEstado[0];
            A138MedidasNombre = P004Y2_A138MedidasNombre[0];
            A122RubrosNombre = P004Y2_A122RubrosNombre[0];
            A137MedidasID = P004Y2_A137MedidasID[0];
            A122RubrosNombre = P004Y2_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P004Y2_A150TextosId[0] == A150TextosId ) && ( P004Y2_A121RubrosId[0] == A121RubrosId ) )
               {
                  BRK4Y2 = false;
                  A137MedidasID = P004Y2_A137MedidasID[0];
                  AV31count = (long)(AV31count+1);
                  BRK4Y2 = true;
                  pr_default.readNext(0);
               }
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
               AV25InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV25InsertIndex = (int)(AV25InsertIndex+1);
               }
               AV27Options.Add(AV26Option, AV25InsertIndex);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
               if ( AV27Options.Count == AV22SkipItems + 11 )
               {
                  AV27Options.RemoveItem(AV27Options.Count);
                  AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
               }
            }
            if ( ! BRK4Y2 )
            {
               BRK4Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADMEDIDASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFMedidasNombre = AV21SearchTxt;
         AV18TFMedidasNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV20TFMedidasEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV18TFMedidasNombre_Sel ,
                                              AV17TFMedidasNombre ,
                                              AV20TFMedidasEstado_Sels.Count ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A138MedidasNombre ,
                                              AV43FilterFullText ,
                                              AV44TextosId ,
                                              A150TextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         lV17TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFMedidasNombre), 50, "%");
         /* Using cursor P004Y3 */
         pr_default.execute(1, new Object[] {AV44TextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel, lV17TFMedidasNombre, AV18TFMedidasNombre_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4Y4 = false;
            A150TextosId = P004Y3_A150TextosId[0];
            n150TextosId = P004Y3_n150TextosId[0];
            A138MedidasNombre = P004Y3_A138MedidasNombre[0];
            A139MedidasEstado = P004Y3_A139MedidasEstado[0];
            n139MedidasEstado = P004Y3_n139MedidasEstado[0];
            A122RubrosNombre = P004Y3_A122RubrosNombre[0];
            A121RubrosId = P004Y3_A121RubrosId[0];
            A137MedidasID = P004Y3_A137MedidasID[0];
            A122RubrosNombre = P004Y3_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P004Y3_A150TextosId[0] == A150TextosId ) && ( StringUtil.StrCmp(P004Y3_A138MedidasNombre[0], A138MedidasNombre) == 0 ) )
               {
                  BRK4Y4 = false;
                  A121RubrosId = P004Y3_A121RubrosId[0];
                  A137MedidasID = P004Y3_A137MedidasID[0];
                  AV31count = (long)(AV31count+1);
                  BRK4Y4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138MedidasNombre)) ? "<#Empty#>" : A138MedidasNombre);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRK4Y4 )
            {
               BRK4Y4 = true;
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV17TFMedidasNombre = "";
         AV18TFMedidasNombre_Sel = "";
         AV19TFMedidasEstado_SelsJson = "";
         AV20TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         lV13TFRubrosNombre = "";
         lV17TFMedidasNombre = "";
         A139MedidasEstado = "";
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         P004Y2_A150TextosId = new long[1] ;
         P004Y2_n150TextosId = new bool[] {false} ;
         P004Y2_A121RubrosId = new short[1] ;
         P004Y2_A139MedidasEstado = new string[] {""} ;
         P004Y2_n139MedidasEstado = new bool[] {false} ;
         P004Y2_A138MedidasNombre = new string[] {""} ;
         P004Y2_A122RubrosNombre = new string[] {""} ;
         P004Y2_A137MedidasID = new long[1] ;
         AV26Option = "";
         P004Y3_A150TextosId = new long[1] ;
         P004Y3_n150TextosId = new bool[] {false} ;
         P004Y3_A138MedidasNombre = new string[] {""} ;
         P004Y3_A139MedidasEstado = new string[] {""} ;
         P004Y3_n139MedidasEstado = new bool[] {false} ;
         P004Y3_A122RubrosNombre = new string[] {""} ;
         P004Y3_A121RubrosId = new short[1] ;
         P004Y3_A137MedidasID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textosinventariowcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004Y2_A150TextosId, P004Y2_n150TextosId, P004Y2_A121RubrosId, P004Y2_A139MedidasEstado, P004Y2_n139MedidasEstado, P004Y2_A138MedidasNombre, P004Y2_A122RubrosNombre, P004Y2_A137MedidasID
               }
               , new Object[] {
               P004Y3_A150TextosId, P004Y3_n150TextosId, P004Y3_A138MedidasNombre, P004Y3_A139MedidasEstado, P004Y3_n139MedidasEstado, P004Y3_A122RubrosNombre, P004Y3_A121RubrosId, P004Y3_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short A121RubrosId ;
      private int AV45GXV1 ;
      private int AV20TFMedidasEstado_Sels_Count ;
      private int AV25InsertIndex ;
      private long AV44TextosId ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private long AV31count ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string AV17TFMedidasNombre ;
      private string AV18TFMedidasNombre_Sel ;
      private string lV13TFRubrosNombre ;
      private string lV17TFMedidasNombre ;
      private string A139MedidasEstado ;
      private string A122RubrosNombre ;
      private string A138MedidasNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4Y2 ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool BRK4Y4 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFMedidasEstado_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GxSimpleCollection<string> AV20TFMedidasEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P004Y2_A150TextosId ;
      private bool[] P004Y2_n150TextosId ;
      private short[] P004Y2_A121RubrosId ;
      private string[] P004Y2_A139MedidasEstado ;
      private bool[] P004Y2_n139MedidasEstado ;
      private string[] P004Y2_A138MedidasNombre ;
      private string[] P004Y2_A122RubrosNombre ;
      private long[] P004Y2_A137MedidasID ;
      private long[] P004Y3_A150TextosId ;
      private bool[] P004Y3_n150TextosId ;
      private string[] P004Y3_A138MedidasNombre ;
      private string[] P004Y3_A139MedidasEstado ;
      private bool[] P004Y3_n139MedidasEstado ;
      private string[] P004Y3_A122RubrosNombre ;
      private short[] P004Y3_A121RubrosId ;
      private long[] P004Y3_A137MedidasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class textosinventariowcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Y2( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV20TFMedidasEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             string AV18TFMedidasNombre_Sel ,
                                             string AV17TFMedidasNombre ,
                                             int AV20TFMedidasEstado_Sels_Count ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             string A138MedidasNombre ,
                                             string AV43FilterFullText ,
                                             long AV44TextosId ,
                                             long A150TextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TextosId], T1.[RubrosId], T1.[MedidasEstado], T1.[MedidasNombre], T2.[RubrosNombre], T1.[MedidasID] FROM ([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId])";
         AddWhere(sWhereString, "(T1.[TextosId] = @AV44TextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV17TFMedidasNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV18TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( AV20TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TextosId], T1.[RubrosId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004Y3( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV20TFMedidasEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             string AV18TFMedidasNombre_Sel ,
                                             string AV17TFMedidasNombre ,
                                             int AV20TFMedidasEstado_Sels_Count ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             string A138MedidasNombre ,
                                             string AV43FilterFullText ,
                                             long AV44TextosId ,
                                             long A150TextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TextosId], T1.[MedidasNombre], T1.[MedidasEstado], T2.[RubrosNombre], T1.[RubrosId], T1.[MedidasID] FROM ([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId])";
         AddWhere(sWhereString, "(T1.[TextosId] = @AV44TextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV17TFMedidasNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV18TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( AV20TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TextosId], T1.[MedidasNombre]";
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
                     return conditional_P004Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
               case 1 :
                     return conditional_P004Y3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
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
          Object[] prmP004Y2;
          prmP004Y2 = new Object[] {
          new ParDef("@AV44TextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV17TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV18TFMedidasNombre_Sel",GXType.NChar,50,0)
          };
          Object[] prmP004Y3;
          prmP004Y3 = new Object[] {
          new ParDef("@AV44TextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV17TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV18TFMedidasNombre_Sel",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 50);
                ((string[]) buf[6])[0] = rslt.getString(5, 100);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 50);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 100);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.textosinventariowcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class textosinventariowcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TextosInventarioWCGetFilterData" )]
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
          if ( ! ProcessHeaders("textosinventariowcgetfilterdata") )
          {
             return  ;
          }
          textosinventariowcgetfilterdata worker = new textosinventariowcgetfilterdata(context);
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
