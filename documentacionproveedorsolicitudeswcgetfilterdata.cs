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
   public class documentacionproveedorsolicitudeswcgetfilterdata : GXProcedure
   {
      public documentacionproveedorsolicitudeswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionproveedorsolicitudeswcgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV22MaxItems = 10;
            AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
            AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROVEEDORESTIPONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORESTIPONOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("DocumentacionProveedorSolicitudesWCGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionProveedorSolicitudesWCGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("DocumentacionProveedorSolicitudesWCGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPOID") == 0 )
            {
               AV13TFProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFProveedoresTipoId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE") == 0 )
            {
               AV15TFProveedoresTipoNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE_SEL") == 0 )
            {
               AV16TFProveedoresTipoNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV17TFProveedorNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV18TFProveedorNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&DOCUMENTACIONID") == 0 )
            {
               AV42DocumentacionId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORESTIPONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedoresTipoNombre = AV19SearchTxt;
         AV16TFProveedoresTipoNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              AV42DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         /* Using cursor P00682 */
         pr_default.execute(0, new Object[] {AV42DocumentacionId, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK682 = false;
            A488DocumentacionId = P00682_A488DocumentacionId[0];
            n488DocumentacionId = P00682_n488DocumentacionId[0];
            A151ProveedoresTipoId = P00682_A151ProveedoresTipoId[0];
            A282ProveedorNombre = P00682_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00682_A278ProveedoresTipoNombre[0];
            A133ProveedorID = P00682_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00682_A278ProveedoresTipoNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00682_A488DocumentacionId[0] == A488DocumentacionId ) && ( P00682_A151ProveedoresTipoId[0] == A151ProveedoresTipoId ) )
            {
               BRK682 = false;
               A133ProveedorID = P00682_A133ProveedorID[0];
               AV29count = (long)(AV29count+1);
               BRK682 = true;
               pr_default.readNext(0);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A278ProveedoresTipoNombre)) ? "<#Empty#>" : A278ProveedoresTipoNombre);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRK682 )
            {
               BRK682 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorNombre = AV19SearchTxt;
         AV18TFProveedorNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41FilterFullText ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              AV42DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV41FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV41FilterFullText), "%", "");
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         /* Using cursor P00683 */
         pr_default.execute(1, new Object[] {AV42DocumentacionId, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, lV41FilterFullText, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK684 = false;
            A488DocumentacionId = P00683_A488DocumentacionId[0];
            n488DocumentacionId = P00683_n488DocumentacionId[0];
            A282ProveedorNombre = P00683_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00683_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00683_A151ProveedoresTipoId[0];
            A133ProveedorID = P00683_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00683_A278ProveedoresTipoNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00683_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00683_A282ProveedorNombre[0], A282ProveedorNombre) == 0 ) )
            {
               BRK684 = false;
               A133ProveedorID = P00683_A133ProveedorID[0];
               AV29count = (long)(AV29count+1);
               BRK684 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK684 )
            {
               BRK684 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV15TFProveedoresTipoNombre = "";
         AV16TFProveedoresTipoNombre_Sel = "";
         AV17TFProveedorNombre = "";
         AV18TFProveedorNombre_Sel = "";
         lV41FilterFullText = "";
         lV15TFProveedoresTipoNombre = "";
         lV17TFProveedorNombre = "";
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         P00682_A488DocumentacionId = new long[1] ;
         P00682_n488DocumentacionId = new bool[] {false} ;
         P00682_A151ProveedoresTipoId = new long[1] ;
         P00682_A282ProveedorNombre = new string[] {""} ;
         P00682_A278ProveedoresTipoNombre = new string[] {""} ;
         P00682_A133ProveedorID = new long[1] ;
         AV24Option = "";
         P00683_A488DocumentacionId = new long[1] ;
         P00683_n488DocumentacionId = new bool[] {false} ;
         P00683_A282ProveedorNombre = new string[] {""} ;
         P00683_A278ProveedoresTipoNombre = new string[] {""} ;
         P00683_A151ProveedoresTipoId = new long[1] ;
         P00683_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionproveedorsolicitudeswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00682_A488DocumentacionId, P00682_n488DocumentacionId, P00682_A151ProveedoresTipoId, P00682_A282ProveedorNombre, P00682_A278ProveedoresTipoNombre, P00682_A133ProveedorID
               }
               , new Object[] {
               P00683_A488DocumentacionId, P00683_n488DocumentacionId, P00683_A282ProveedorNombre, P00683_A278ProveedoresTipoNombre, P00683_A151ProveedoresTipoId, P00683_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV43GXV1 ;
      private int AV23InsertIndex ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long AV13TFProveedoresTipoId ;
      private long AV14TFProveedoresTipoId_To ;
      private long AV42DocumentacionId ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A488DocumentacionId ;
      private long AV29count ;
      private string AV15TFProveedoresTipoNombre ;
      private string AV16TFProveedoresTipoNombre_Sel ;
      private string AV17TFProveedorNombre ;
      private string AV18TFProveedorNombre_Sel ;
      private string lV15TFProveedoresTipoNombre ;
      private string lV17TFProveedorNombre ;
      private string A278ProveedoresTipoNombre ;
      private string A282ProveedorNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK682 ;
      private bool n488DocumentacionId ;
      private bool BRK684 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string lV41FilterFullText ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P00682_A488DocumentacionId ;
      private bool[] P00682_n488DocumentacionId ;
      private long[] P00682_A151ProveedoresTipoId ;
      private string[] P00682_A282ProveedorNombre ;
      private string[] P00682_A278ProveedoresTipoNombre ;
      private long[] P00682_A133ProveedorID ;
      private long[] P00683_A488DocumentacionId ;
      private bool[] P00683_n488DocumentacionId ;
      private string[] P00683_A282ProveedorNombre ;
      private string[] P00683_A278ProveedoresTipoNombre ;
      private long[] P00683_A151ProveedoresTipoId ;
      private long[] P00683_A133ProveedorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class documentacionproveedorsolicitudeswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00682( IGxContext context ,
                                             string AV41FilterFullText ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             long AV42DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedoresTipoId], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV42DocumentacionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV41FilterFullText) or ( CONVERT( char(18), CAST(T1.[ProveedoresTipoId] AS decimal(18,0))) like '%' + @lV41FilterFullText) or ( UPPER(T2.[ProveedoresTipoNombre]) like '%' + UPPER(@lV41FilterFullText)) or ( UPPER(T1.[ProveedorNombre]) like '%' + UPPER(@lV41FilterFullText)))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
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
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedoresTipoId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00683( IGxContext context ,
                                             string AV41FilterFullText ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             long AV42DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV42DocumentacionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV41FilterFullText) or ( CONVERT( char(18), CAST(T1.[ProveedoresTipoId] AS decimal(18,0))) like '%' + @lV41FilterFullText) or ( UPPER(T2.[ProveedoresTipoNombre]) like '%' + UPPER(@lV41FilterFullText)) or ( UPPER(T1.[ProveedorNombre]) like '%' + UPPER(@lV41FilterFullText)))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
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
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorNombre]";
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
                     return conditional_P00682(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
               case 1 :
                     return conditional_P00683(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
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
          Object[] prmP00682;
          prmP00682 = new Object[] {
          new ParDef("@AV42DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00683;
          prmP00683 = new Object[] {
          new ParDef("@AV42DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV41FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00682", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00682,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00683", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00683,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((string[]) buf[3])[0] = rslt.getString(3, 120);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.documentacionproveedorsolicitudeswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class documentacionproveedorsolicitudeswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DocumentacionProveedorSolicitudesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("documentacionproveedorsolicitudeswcgetfilterdata") )
          {
             return  ;
          }
          documentacionproveedorsolicitudeswcgetfilterdata worker = new documentacionproveedorsolicitudeswcgetfilterdata(context);
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
