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
   public class comercioprompt1getfilterdata : GXProcedure
   {
      public comercioprompt1getfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercioprompt1getfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PROVEEDORESTIPONOMBRE") == 0 )
         {
            /* Execute user subroutine: 'LOADPROVEEDORESTIPONOMBREOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
         {
            /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ComercioPrompt1GridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComercioPrompt1GridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ComercioPrompt1GridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE") == 0 )
            {
               AV15TFProveedoresTipoNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE_SEL") == 0 )
            {
               AV16TFProveedoresTipoNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV17TFProveedorNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV18TFProveedorNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV19TFProveedorEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFProveedorEstado_Sels.FromJSonString(AV19TFProveedorEstado_SelsJson, null);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORESTIPONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedoresTipoNombre = AV21SearchTxt;
         AV16TFProveedoresTipoNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV20TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              AV43FilterFullText } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         /* Using cursor P00D92 */
         pr_default.execute(0, new Object[] {AV11TFProveedorID, AV12TFProveedorID_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD92 = false;
            A151ProveedoresTipoId = P00D92_A151ProveedoresTipoId[0];
            A344ProveedorEstado = P00D92_A344ProveedorEstado[0];
            A282ProveedorNombre = P00D92_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00D92_A278ProveedoresTipoNombre[0];
            A133ProveedorID = P00D92_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00D92_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00D92_A151ProveedoresTipoId[0] == A151ProveedoresTipoId ) )
               {
                  BRKD92 = false;
                  A133ProveedorID = P00D92_A133ProveedorID[0];
                  AV31count = (long)(AV31count+1);
                  BRKD92 = true;
                  pr_default.readNext(0);
               }
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A278ProveedoresTipoNombre)) ? "<#Empty#>" : A278ProveedoresTipoNombre);
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
            if ( ! BRKD92 )
            {
               BRKD92 = true;
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
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorNombre = AV21SearchTxt;
         AV18TFProveedorNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV20TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              AV43FilterFullText } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         /* Using cursor P00D93 */
         pr_default.execute(1, new Object[] {AV11TFProveedorID, AV12TFProveedorID_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD94 = false;
            A151ProveedoresTipoId = P00D93_A151ProveedoresTipoId[0];
            A282ProveedorNombre = P00D93_A282ProveedorNombre[0];
            A344ProveedorEstado = P00D93_A344ProveedorEstado[0];
            A278ProveedoresTipoNombre = P00D93_A278ProveedoresTipoNombre[0];
            A133ProveedorID = P00D93_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00D93_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV43FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00D93_A282ProveedorNombre[0], A282ProveedorNombre) == 0 ) )
               {
                  BRKD94 = false;
                  A133ProveedorID = P00D93_A133ProveedorID[0];
                  AV31count = (long)(AV31count+1);
                  BRKD94 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
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
            if ( ! BRKD94 )
            {
               BRKD94 = true;
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
         AV15TFProveedoresTipoNombre = "";
         AV16TFProveedoresTipoNombre_Sel = "";
         AV17TFProveedorNombre = "";
         AV18TFProveedorNombre_Sel = "";
         AV19TFProveedorEstado_SelsJson = "";
         AV20TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         lV15TFProveedoresTipoNombre = "";
         lV17TFProveedorNombre = "";
         A344ProveedorEstado = "";
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         P00D92_A151ProveedoresTipoId = new long[1] ;
         P00D92_A344ProveedorEstado = new string[] {""} ;
         P00D92_A282ProveedorNombre = new string[] {""} ;
         P00D92_A278ProveedoresTipoNombre = new string[] {""} ;
         P00D92_A133ProveedorID = new long[1] ;
         AV26Option = "";
         P00D93_A151ProveedoresTipoId = new long[1] ;
         P00D93_A282ProveedorNombre = new string[] {""} ;
         P00D93_A344ProveedorEstado = new string[] {""} ;
         P00D93_A278ProveedoresTipoNombre = new string[] {""} ;
         P00D93_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercioprompt1getfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D92_A151ProveedoresTipoId, P00D92_A344ProveedorEstado, P00D92_A282ProveedorNombre, P00D92_A278ProveedoresTipoNombre, P00D92_A133ProveedorID
               }
               , new Object[] {
               P00D93_A151ProveedoresTipoId, P00D93_A282ProveedorNombre, P00D93_A344ProveedorEstado, P00D93_A278ProveedoresTipoNombre, P00D93_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV44GXV1 ;
      private int AV20TFProveedorEstado_Sels_Count ;
      private int AV25InsertIndex ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long AV31count ;
      private string AV15TFProveedoresTipoNombre ;
      private string AV16TFProveedoresTipoNombre_Sel ;
      private string AV17TFProveedorNombre ;
      private string AV18TFProveedorNombre_Sel ;
      private string lV15TFProveedoresTipoNombre ;
      private string lV17TFProveedorNombre ;
      private string A344ProveedorEstado ;
      private string A278ProveedoresTipoNombre ;
      private string A282ProveedorNombre ;
      private bool returnInSub ;
      private bool BRKD92 ;
      private bool BRKD94 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFProveedorEstado_SelsJson ;
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
      private GxSimpleCollection<string> AV20TFProveedorEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00D92_A151ProveedoresTipoId ;
      private string[] P00D92_A344ProveedorEstado ;
      private string[] P00D92_A282ProveedorNombre ;
      private string[] P00D92_A278ProveedoresTipoNombre ;
      private long[] P00D92_A133ProveedorID ;
      private long[] P00D93_A151ProveedoresTipoId ;
      private string[] P00D93_A282ProveedorNombre ;
      private string[] P00D93_A344ProveedorEstado ;
      private string[] P00D93_A278ProveedoresTipoNombre ;
      private long[] P00D93_A133ProveedorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comercioprompt1getfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D92( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV20TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             int AV20TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string AV43FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedoresTipoId], T1.[ProveedorEstado], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( AV20TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedoresTipoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D93( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV20TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             int AV20TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string AV43FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedoresTipoId], T1.[ProveedorNombre], T1.[ProveedorEstado], T2.[ProveedoresTipoNombre], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( AV20TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorNombre]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00D92(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P00D93(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP00D92;
          prmP00D92 = new Object[] {
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00D93;
          prmP00D93 = new Object[] {
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D92,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D93,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comercioprompt1getfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comercioprompt1getfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComercioPrompt1GetFilterData" )]
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
          if ( ! ProcessHeaders("comercioprompt1getfilterdata") )
          {
             return  ;
          }
          comercioprompt1getfilterdata worker = new comercioprompt1getfilterdata(context);
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
