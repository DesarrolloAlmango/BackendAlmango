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
   public class historicosolicitudesrelacioneswcgetfilterdata : GXProcedure
   {
      public historicosolicitudesrelacioneswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudesrelacioneswcgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV20MaxItems = 10;
            AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
            AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_HISTORICOSOLICITUDESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICOSOLICITUDESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_HISTORICORELACIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICORELACIONESNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("HistoricoSolicitudesRelacionesWCGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoSolicitudesRelacionesWCGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("HistoricoSolicitudesRelacionesWCGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESID") == 0 )
            {
               AV11TFHistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFHistoricoSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOMBRE") == 0 )
            {
               AV13TFHistoricoSolicitudesNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV14TFHistoricoSolicitudesNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE") == 0 )
            {
               AV15TFHistoricoRelacionesNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE_SEL") == 0 )
            {
               AV16TFHistoricoRelacionesNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&HISTORICOSOLICITUDESID") == 0 )
            {
               AV40HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHISTORICOSOLICITUDESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFHistoricoSolicitudesNombre = AV17SearchTxt;
         AV14TFHistoricoSolicitudesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV11TFHistoricoSolicitudesID ,
                                              AV12TFHistoricoSolicitudesID_To ,
                                              AV14TFHistoricoSolicitudesNombre_Sel ,
                                              AV13TFHistoricoSolicitudesNombre ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A323HistoricoRelacionesNombre ,
                                              AV40HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV13TFHistoricoSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoSolicitudesNombre), 100, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         /* Using cursor P004P2 */
         pr_default.execute(0, new Object[] {AV40HistoricoSolicitudesID, lV39FilterFullText, lV39FilterFullText, lV39FilterFullText, AV11TFHistoricoSolicitudesID, AV12TFHistoricoSolicitudesID_To, lV13TFHistoricoSolicitudesNombre, AV14TFHistoricoSolicitudesNombre_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4P2 = false;
            A153HistoricoSolicitudesID = P004P2_A153HistoricoSolicitudesID[0];
            A288HistoricoSolicitudesNombre = P004P2_A288HistoricoSolicitudesNombre[0];
            A323HistoricoRelacionesNombre = P004P2_A323HistoricoRelacionesNombre[0];
            A156HistoricoRelacionesId = P004P2_A156HistoricoRelacionesId[0];
            A288HistoricoSolicitudesNombre = P004P2_A288HistoricoSolicitudesNombre[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004P2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004P2_A288HistoricoSolicitudesNombre[0], A288HistoricoSolicitudesNombre) == 0 ) )
            {
               BRK4P2 = false;
               A156HistoricoRelacionesId = P004P2_A156HistoricoRelacionesId[0];
               AV27count = (long)(AV27count+1);
               BRK4P2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A288HistoricoSolicitudesNombre)) ? "<#Empty#>" : A288HistoricoSolicitudesNombre);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK4P2 )
            {
               BRK4P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADHISTORICORELACIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFHistoricoRelacionesNombre = AV17SearchTxt;
         AV16TFHistoricoRelacionesNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV39FilterFullText ,
                                              AV11TFHistoricoSolicitudesID ,
                                              AV12TFHistoricoSolicitudesID_To ,
                                              AV14TFHistoricoSolicitudesNombre_Sel ,
                                              AV13TFHistoricoSolicitudesNombre ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A323HistoricoRelacionesNombre ,
                                              AV40HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV39FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV39FilterFullText), "%", "");
         lV13TFHistoricoSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoSolicitudesNombre), 100, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         /* Using cursor P004P3 */
         pr_default.execute(1, new Object[] {AV40HistoricoSolicitudesID, lV39FilterFullText, lV39FilterFullText, lV39FilterFullText, AV11TFHistoricoSolicitudesID, AV12TFHistoricoSolicitudesID_To, lV13TFHistoricoSolicitudesNombre, AV14TFHistoricoSolicitudesNombre_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4P4 = false;
            A153HistoricoSolicitudesID = P004P3_A153HistoricoSolicitudesID[0];
            A323HistoricoRelacionesNombre = P004P3_A323HistoricoRelacionesNombre[0];
            A288HistoricoSolicitudesNombre = P004P3_A288HistoricoSolicitudesNombre[0];
            A156HistoricoRelacionesId = P004P3_A156HistoricoRelacionesId[0];
            A288HistoricoSolicitudesNombre = P004P3_A288HistoricoSolicitudesNombre[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P004P3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004P3_A323HistoricoRelacionesNombre[0], A323HistoricoRelacionesNombre) == 0 ) )
            {
               BRK4P4 = false;
               A156HistoricoRelacionesId = P004P3_A156HistoricoRelacionesId[0];
               AV27count = (long)(AV27count+1);
               BRK4P4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A323HistoricoRelacionesNombre)) ? "<#Empty#>" : A323HistoricoRelacionesNombre);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK4P4 )
            {
               BRK4P4 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV13TFHistoricoSolicitudesNombre = "";
         AV14TFHistoricoSolicitudesNombre_Sel = "";
         AV15TFHistoricoRelacionesNombre = "";
         AV16TFHistoricoRelacionesNombre_Sel = "";
         lV39FilterFullText = "";
         lV13TFHistoricoSolicitudesNombre = "";
         lV15TFHistoricoRelacionesNombre = "";
         A288HistoricoSolicitudesNombre = "";
         A323HistoricoRelacionesNombre = "";
         P004P2_A153HistoricoSolicitudesID = new long[1] ;
         P004P2_A288HistoricoSolicitudesNombre = new string[] {""} ;
         P004P2_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004P2_A156HistoricoRelacionesId = new long[1] ;
         AV22Option = "";
         P004P3_A153HistoricoSolicitudesID = new long[1] ;
         P004P3_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004P3_A288HistoricoSolicitudesNombre = new string[] {""} ;
         P004P3_A156HistoricoRelacionesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudesrelacioneswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004P2_A153HistoricoSolicitudesID, P004P2_A288HistoricoSolicitudesNombre, P004P2_A323HistoricoRelacionesNombre, P004P2_A156HistoricoRelacionesId
               }
               , new Object[] {
               P004P3_A153HistoricoSolicitudesID, P004P3_A323HistoricoRelacionesNombre, P004P3_A288HistoricoSolicitudesNombre, P004P3_A156HistoricoRelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV41GXV1 ;
      private long AV11TFHistoricoSolicitudesID ;
      private long AV12TFHistoricoSolicitudesID_To ;
      private long AV40HistoricoSolicitudesID ;
      private long A153HistoricoSolicitudesID ;
      private long A156HistoricoRelacionesId ;
      private long AV27count ;
      private string AV13TFHistoricoSolicitudesNombre ;
      private string AV14TFHistoricoSolicitudesNombre_Sel ;
      private string AV15TFHistoricoRelacionesNombre ;
      private string AV16TFHistoricoRelacionesNombre_Sel ;
      private string lV13TFHistoricoSolicitudesNombre ;
      private string lV15TFHistoricoRelacionesNombre ;
      private string A288HistoricoSolicitudesNombre ;
      private string A323HistoricoRelacionesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4P2 ;
      private bool BRK4P4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string lV39FilterFullText ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P004P2_A153HistoricoSolicitudesID ;
      private string[] P004P2_A288HistoricoSolicitudesNombre ;
      private string[] P004P2_A323HistoricoRelacionesNombre ;
      private long[] P004P2_A156HistoricoRelacionesId ;
      private long[] P004P3_A153HistoricoSolicitudesID ;
      private string[] P004P3_A323HistoricoRelacionesNombre ;
      private string[] P004P3_A288HistoricoSolicitudesNombre ;
      private long[] P004P3_A156HistoricoRelacionesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class historicosolicitudesrelacioneswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004P2( IGxContext context ,
                                             string AV39FilterFullText ,
                                             long AV11TFHistoricoSolicitudesID ,
                                             long AV12TFHistoricoSolicitudesID_To ,
                                             string AV14TFHistoricoSolicitudesNombre_Sel ,
                                             string AV13TFHistoricoSolicitudesNombre ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A323HistoricoRelacionesNombre ,
                                             long AV40HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesID], T2.[HistoricoSolicitudesNombre], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [HistoricoSolicitudes] T2 ON T2.[HistoricoSolicitudesID] = T1.[HistoricoSolicitudesID])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV40HistoricoSolicitudesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[HistoricoSolicitudesID] AS decimal(18,0))) like '%' + @lV39FilterFullText) or ( UPPER(T2.[HistoricoSolicitudesNombre]) like '%' + UPPER(@lV39FilterFullText)) or ( UPPER(T1.[HistoricoRelacionesNombre]) like '%' + UPPER(@lV39FilterFullText)))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV11TFHistoricoSolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] >= @AV11TFHistoricoSolicitudesID)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesID_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] <= @AV12TFHistoricoSolicitudesID_To)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[HistoricoSolicitudesNombre]) like UPPER(@lV13TFHistoricoSolicitudesNombre))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[HistoricoSolicitudesNombre] = @AV14TFHistoricoSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[HistoricoSolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T2.[HistoricoSolicitudesNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004P3( IGxContext context ,
                                             string AV39FilterFullText ,
                                             long AV11TFHistoricoSolicitudesID ,
                                             long AV12TFHistoricoSolicitudesID_To ,
                                             string AV14TFHistoricoSolicitudesNombre_Sel ,
                                             string AV13TFHistoricoSolicitudesNombre ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A323HistoricoRelacionesNombre ,
                                             long AV40HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre], T2.[HistoricoSolicitudesNombre], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [HistoricoSolicitudes] T2 ON T2.[HistoricoSolicitudesID] = T1.[HistoricoSolicitudesID])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV40HistoricoSolicitudesID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[HistoricoSolicitudesID] AS decimal(18,0))) like '%' + @lV39FilterFullText) or ( UPPER(T2.[HistoricoSolicitudesNombre]) like '%' + UPPER(@lV39FilterFullText)) or ( UPPER(T1.[HistoricoRelacionesNombre]) like '%' + UPPER(@lV39FilterFullText)))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV11TFHistoricoSolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] >= @AV11TFHistoricoSolicitudesID)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesID_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] <= @AV12TFHistoricoSolicitudesID_To)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[HistoricoSolicitudesNombre]) like UPPER(@lV13TFHistoricoSolicitudesNombre))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[HistoricoSolicitudesNombre] = @AV14TFHistoricoSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[HistoricoSolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre]";
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
                     return conditional_P004P2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_P004P3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] );
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
          Object[] prmP004P2;
          prmP004P2 = new Object[] {
          new ParDef("@AV40HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFHistoricoSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP004P3;
          prmP004P3 = new Object[] {
          new ParDef("@AV40HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV39FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFHistoricoSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004P3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.historicosolicitudesrelacioneswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class historicosolicitudesrelacioneswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "HistoricoSolicitudesRelacionesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("historicosolicitudesrelacioneswcgetfilterdata") )
          {
             return  ;
          }
          historicosolicitudesrelacioneswcgetfilterdata worker = new historicosolicitudesrelacioneswcgetfilterdata(context);
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
