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
   public class feedbackwwgetfilterdata : GXProcedure
   {
      public feedbackwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public feedbackwwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV28MaxItems = 10;
            AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
            AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_FEEDBACKPROFESIONALID") == 0 )
            {
               /* Execute user subroutine: 'LOADFEEDBACKPROFESIONALIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_FEEDBACKCOMENTARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADFEEDBACKCOMENTARIOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("FeedBackWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FeedBackWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("FeedBackWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKID") == 0 )
            {
               AV13TFFeedBackId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFFeedBackId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKSOLICITUDID") == 0 )
            {
               AV15TFFeedBackSolicitudId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFFeedBackSolicitudId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKPROFESIONALID") == 0 )
            {
               AV17TFFeedBackProfesionalId = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKPROFESIONALID_SEL") == 0 )
            {
               AV18TFFeedBackProfesionalId_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKCOMENTARIO") == 0 )
            {
               AV23TFFeedBackComentario = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKCOMENTARIO_SEL") == 0 )
            {
               AV24TFFeedBackComentario_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKNUM") == 0 )
            {
               AV21TFFeedBackNum = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFFeedBackNum_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFEEDBACKFECHAALTA") == 0 )
            {
               AV11TFFeedBackFechaAlta = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV12TFFeedBackFechaAlta_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADFEEDBACKPROFESIONALIDOPTIONS' Routine */
         returnInSub = false;
         AV17TFFeedBackProfesionalId = AV25SearchTxt;
         AV18TFFeedBackProfesionalId_Sel = "";
         AV61Feedbackwwds_1_filterfulltext = AV47FilterFullText;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Feedbackwwds_1_filterfulltext ,
                                              A272FeedBackSolicitudId ,
                                              A273FeedBackProfesionalId ,
                                              A271FeedBackComentario } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         /* Using cursor P006P2 */
         pr_default.execute(0, new Object[] {lV61Feedbackwwds_1_filterfulltext, lV61Feedbackwwds_1_filterfulltext, lV61Feedbackwwds_1_filterfulltext});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6P2 = false;
            A273FeedBackProfesionalId = P006P2_A273FeedBackProfesionalId[0];
            A271FeedBackComentario = P006P2_A271FeedBackComentario[0];
            A272FeedBackSolicitudId = P006P2_A272FeedBackSolicitudId[0];
            A117FeedBackId = P006P2_A117FeedBackId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006P2_A273FeedBackProfesionalId[0], A273FeedBackProfesionalId) == 0 ) )
            {
               BRK6P2 = false;
               A117FeedBackId = P006P2_A117FeedBackId[0];
               AV35count = (long)(AV35count+1);
               BRK6P2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A273FeedBackProfesionalId)) ? "<#Empty#>" : A273FeedBackProfesionalId);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6P2 )
            {
               BRK6P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADFEEDBACKCOMENTARIOOPTIONS' Routine */
         returnInSub = false;
         AV23TFFeedBackComentario = AV25SearchTxt;
         AV24TFFeedBackComentario_Sel = "";
         AV61Feedbackwwds_1_filterfulltext = AV47FilterFullText;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Feedbackwwds_1_filterfulltext ,
                                              A272FeedBackSolicitudId ,
                                              A273FeedBackProfesionalId ,
                                              A271FeedBackComentario } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         lV61Feedbackwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext), "%", "");
         /* Using cursor P006P3 */
         pr_default.execute(1, new Object[] {lV61Feedbackwwds_1_filterfulltext, lV61Feedbackwwds_1_filterfulltext, lV61Feedbackwwds_1_filterfulltext});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6P4 = false;
            A271FeedBackComentario = P006P3_A271FeedBackComentario[0];
            A273FeedBackProfesionalId = P006P3_A273FeedBackProfesionalId[0];
            A272FeedBackSolicitudId = P006P3_A272FeedBackSolicitudId[0];
            A117FeedBackId = P006P3_A117FeedBackId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006P3_A271FeedBackComentario[0], A271FeedBackComentario) == 0 ) )
            {
               BRK6P4 = false;
               A117FeedBackId = P006P3_A117FeedBackId[0];
               AV35count = (long)(AV35count+1);
               BRK6P4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A271FeedBackComentario)) ? "<#Empty#>" : A271FeedBackComentario);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6P4 )
            {
               BRK6P4 = true;
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV17TFFeedBackProfesionalId = "";
         AV18TFFeedBackProfesionalId_Sel = "";
         AV23TFFeedBackComentario = "";
         AV24TFFeedBackComentario_Sel = "";
         AV11TFFeedBackFechaAlta = DateTime.MinValue;
         AV12TFFeedBackFechaAlta_To = DateTime.MinValue;
         AV61Feedbackwwds_1_filterfulltext = "";
         lV61Feedbackwwds_1_filterfulltext = "";
         A273FeedBackProfesionalId = "";
         A271FeedBackComentario = "";
         P006P2_A273FeedBackProfesionalId = new string[] {""} ;
         P006P2_A271FeedBackComentario = new string[] {""} ;
         P006P2_A272FeedBackSolicitudId = new long[1] ;
         P006P2_A117FeedBackId = new long[1] ;
         AV30Option = "";
         P006P3_A271FeedBackComentario = new string[] {""} ;
         P006P3_A273FeedBackProfesionalId = new string[] {""} ;
         P006P3_A272FeedBackSolicitudId = new long[1] ;
         P006P3_A117FeedBackId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.feedbackwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006P2_A273FeedBackProfesionalId, P006P2_A271FeedBackComentario, P006P2_A272FeedBackSolicitudId, P006P2_A117FeedBackId
               }
               , new Object[] {
               P006P3_A271FeedBackComentario, P006P3_A273FeedBackProfesionalId, P006P3_A272FeedBackSolicitudId, P006P3_A117FeedBackId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV59GXV1 ;
      private long AV13TFFeedBackId ;
      private long AV14TFFeedBackId_To ;
      private long AV15TFFeedBackSolicitudId ;
      private long AV16TFFeedBackSolicitudId_To ;
      private long AV21TFFeedBackNum ;
      private long AV22TFFeedBackNum_To ;
      private long A272FeedBackSolicitudId ;
      private long A117FeedBackId ;
      private long AV35count ;
      private string AV17TFFeedBackProfesionalId ;
      private string AV18TFFeedBackProfesionalId_Sel ;
      private string A273FeedBackProfesionalId ;
      private DateTime AV11TFFeedBackFechaAlta ;
      private DateTime AV12TFFeedBackFechaAlta_To ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK6P2 ;
      private bool BRK6P4 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string A271FeedBackComentario ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV23TFFeedBackComentario ;
      private string AV24TFFeedBackComentario_Sel ;
      private string AV61Feedbackwwds_1_filterfulltext ;
      private string lV61Feedbackwwds_1_filterfulltext ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P006P2_A273FeedBackProfesionalId ;
      private string[] P006P2_A271FeedBackComentario ;
      private long[] P006P2_A272FeedBackSolicitudId ;
      private long[] P006P2_A117FeedBackId ;
      private string[] P006P3_A271FeedBackComentario ;
      private string[] P006P3_A273FeedBackProfesionalId ;
      private long[] P006P3_A272FeedBackSolicitudId ;
      private long[] P006P3_A117FeedBackId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class feedbackwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006P2( IGxContext context ,
                                             string AV61Feedbackwwds_1_filterfulltext ,
                                             long A272FeedBackSolicitudId ,
                                             string A273FeedBackProfesionalId ,
                                             string A271FeedBackComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [FeedBackProfesionalId], [FeedBackComentario], [FeedBackSolicitudId], [FeedBackId] FROM [FeedBack]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([FeedBackSolicitudId] AS decimal(18,0))) like '%' + @lV61Feedbackwwds_1_filterfulltext) or ( UPPER([FeedBackProfesionalId]) like '%' + UPPER(@lV61Feedbackwwds_1_filterfulltext)) or ( UPPER([FeedBackComentario]) like '%' + UPPER(@lV61Feedbackwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FeedBackProfesionalId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006P3( IGxContext context ,
                                             string AV61Feedbackwwds_1_filterfulltext ,
                                             long A272FeedBackSolicitudId ,
                                             string A273FeedBackProfesionalId ,
                                             string A271FeedBackComentario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [FeedBackComentario], [FeedBackProfesionalId], [FeedBackSolicitudId], [FeedBackId] FROM [FeedBack]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Feedbackwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([FeedBackSolicitudId] AS decimal(18,0))) like '%' + @lV61Feedbackwwds_1_filterfulltext) or ( UPPER([FeedBackProfesionalId]) like '%' + UPPER(@lV61Feedbackwwds_1_filterfulltext)) or ( UPPER([FeedBackComentario]) like '%' + UPPER(@lV61Feedbackwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FeedBackComentario]";
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
                     return conditional_P006P2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 1 :
                     return conditional_P006P3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
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
          Object[] prmP006P2;
          prmP006P2 = new Object[] {
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0)
          };
          Object[] prmP006P3;
          prmP006P3 = new Object[] {
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Feedbackwwds_1_filterfulltext",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006P3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.feedbackwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class feedbackwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "FeedBackWWGetFilterData" )]
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
          if ( ! ProcessHeaders("feedbackwwgetfilterdata") )
          {
             return  ;
          }
          feedbackwwgetfilterdata worker = new feedbackwwgetfilterdata(context);
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
