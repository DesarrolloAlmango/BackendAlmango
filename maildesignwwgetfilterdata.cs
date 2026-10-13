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
   public class maildesignwwgetfilterdata : GXProcedure
   {
      public maildesignwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public maildesignwwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MAILDESIGNASUNTO") == 0 )
            {
               /* Execute user subroutine: 'LOADMAILDESIGNASUNTOOPTIONS' */
               S121 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("MailDesignWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailDesignWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("MailDesignWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNID") == 0 )
            {
               AV11TFMailDesignId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNTIPO_SEL") == 0 )
            {
               AV13TFMailDesignTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV14TFMailDesignTipo_Sels.FromJSonString(AV13TFMailDesignTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO") == 0 )
            {
               AV15TFMailDesignAsunto = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO_SEL") == 0 )
            {
               AV16TFMailDesignAsunto_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNESTADO_SEL") == 0 )
            {
               AV17TFMailDesignEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFMailDesignEstado_Sels.FromJSonString(AV17TFMailDesignEstado_SelsJson, null);
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 )
            {
               AV43MailDesignTipo1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 )
               {
                  AV46MailDesignTipo2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 )
                  {
                     AV49MailDesignTipo3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMAILDESIGNASUNTOOPTIONS' Routine */
         returnInSub = false;
         AV15TFMailDesignAsunto = AV19SearchTxt;
         AV16TFMailDesignAsunto_Sel = "";
         AV52Maildesignwwds_1_filterfulltext = AV41FilterFullText;
         AV53Maildesignwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV54Maildesignwwds_3_maildesigntipo1 = AV43MailDesignTipo1;
         AV55Maildesignwwds_4_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV56Maildesignwwds_5_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV57Maildesignwwds_6_maildesigntipo2 = AV46MailDesignTipo2;
         AV58Maildesignwwds_7_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV59Maildesignwwds_8_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV60Maildesignwwds_9_maildesigntipo3 = AV49MailDesignTipo3;
         AV61Maildesignwwds_10_tfmaildesignid = AV11TFMailDesignId;
         AV62Maildesignwwds_11_tfmaildesignid_to = AV12TFMailDesignId_To;
         AV63Maildesignwwds_12_tfmaildesigntipo_sels = AV14TFMailDesignTipo_Sels;
         AV64Maildesignwwds_13_tfmaildesignasunto = AV15TFMailDesignAsunto;
         AV65Maildesignwwds_14_tfmaildesignasunto_sel = AV16TFMailDesignAsunto_Sel;
         AV66Maildesignwwds_15_tfmaildesignestado_sels = AV18TFMailDesignEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A244MailDesignTipo ,
                                              AV63Maildesignwwds_12_tfmaildesigntipo_sels ,
                                              A245MailDesignEstado ,
                                              AV66Maildesignwwds_15_tfmaildesignestado_sels ,
                                              AV53Maildesignwwds_2_dynamicfiltersselector1 ,
                                              AV54Maildesignwwds_3_maildesigntipo1 ,
                                              AV55Maildesignwwds_4_dynamicfiltersenabled2 ,
                                              AV56Maildesignwwds_5_dynamicfiltersselector2 ,
                                              AV57Maildesignwwds_6_maildesigntipo2 ,
                                              AV58Maildesignwwds_7_dynamicfiltersenabled3 ,
                                              AV59Maildesignwwds_8_dynamicfiltersselector3 ,
                                              AV60Maildesignwwds_9_maildesigntipo3 ,
                                              AV61Maildesignwwds_10_tfmaildesignid ,
                                              AV62Maildesignwwds_11_tfmaildesignid_to ,
                                              AV63Maildesignwwds_12_tfmaildesigntipo_sels.Count ,
                                              AV65Maildesignwwds_14_tfmaildesignasunto_sel ,
                                              AV64Maildesignwwds_13_tfmaildesignasunto ,
                                              AV66Maildesignwwds_15_tfmaildesignestado_sels.Count ,
                                              A148MailDesignId ,
                                              A246MailDesignAsunto ,
                                              AV52Maildesignwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV64Maildesignwwds_13_tfmaildesignasunto = StringUtil.PadR( StringUtil.RTrim( AV64Maildesignwwds_13_tfmaildesignasunto), 80, "%");
         /* Using cursor P00BI2 */
         pr_default.execute(0, new Object[] {AV54Maildesignwwds_3_maildesigntipo1, AV57Maildesignwwds_6_maildesigntipo2, AV60Maildesignwwds_9_maildesigntipo3, AV61Maildesignwwds_10_tfmaildesignid, AV62Maildesignwwds_11_tfmaildesignid_to, lV64Maildesignwwds_13_tfmaildesignasunto, AV65Maildesignwwds_14_tfmaildesignasunto_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBI2 = false;
            A246MailDesignAsunto = P00BI2_A246MailDesignAsunto[0];
            A148MailDesignId = P00BI2_A148MailDesignId[0];
            A245MailDesignEstado = P00BI2_A245MailDesignEstado[0];
            A244MailDesignTipo = P00BI2_A244MailDesignTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Maildesignwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A148MailDesignId), 18, 0) , StringUtil.PadR( "%" + AV52Maildesignwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "publicidad", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "recuperar usuario y contraseña", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "R") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "notificación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A246MailDesignAsunto) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "DES") == 0 ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BI2_A246MailDesignAsunto[0], A246MailDesignAsunto) == 0 ) )
               {
                  BRKBI2 = false;
                  A148MailDesignId = P00BI2_A148MailDesignId[0];
                  AV29count = (long)(AV29count+1);
                  BRKBI2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A246MailDesignAsunto)) ? "<#Empty#>" : A246MailDesignAsunto);
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
            }
            if ( ! BRKBI2 )
            {
               BRKBI2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV13TFMailDesignTipo_SelsJson = "";
         AV14TFMailDesignTipo_Sels = new GxSimpleCollection<string>();
         AV15TFMailDesignAsunto = "";
         AV16TFMailDesignAsunto_Sel = "";
         AV17TFMailDesignEstado_SelsJson = "";
         AV18TFMailDesignEstado_Sels = new GxSimpleCollection<string>();
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV43MailDesignTipo1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV46MailDesignTipo2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV49MailDesignTipo3 = "";
         AV52Maildesignwwds_1_filterfulltext = "";
         AV53Maildesignwwds_2_dynamicfiltersselector1 = "";
         AV54Maildesignwwds_3_maildesigntipo1 = "";
         AV56Maildesignwwds_5_dynamicfiltersselector2 = "";
         AV57Maildesignwwds_6_maildesigntipo2 = "";
         AV59Maildesignwwds_8_dynamicfiltersselector3 = "";
         AV60Maildesignwwds_9_maildesigntipo3 = "";
         AV63Maildesignwwds_12_tfmaildesigntipo_sels = new GxSimpleCollection<string>();
         AV64Maildesignwwds_13_tfmaildesignasunto = "";
         AV65Maildesignwwds_14_tfmaildesignasunto_sel = "";
         AV66Maildesignwwds_15_tfmaildesignestado_sels = new GxSimpleCollection<string>();
         lV64Maildesignwwds_13_tfmaildesignasunto = "";
         A244MailDesignTipo = "";
         A245MailDesignEstado = "";
         A246MailDesignAsunto = "";
         P00BI2_A246MailDesignAsunto = new string[] {""} ;
         P00BI2_A148MailDesignId = new long[1] ;
         P00BI2_A245MailDesignEstado = new string[] {""} ;
         P00BI2_A244MailDesignTipo = new string[] {""} ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.maildesignwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BI2_A246MailDesignAsunto, P00BI2_A148MailDesignId, P00BI2_A245MailDesignEstado, P00BI2_A244MailDesignTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV50GXV1 ;
      private int AV63Maildesignwwds_12_tfmaildesigntipo_sels_Count ;
      private int AV66Maildesignwwds_15_tfmaildesignestado_sels_Count ;
      private long AV11TFMailDesignId ;
      private long AV12TFMailDesignId_To ;
      private long AV61Maildesignwwds_10_tfmaildesignid ;
      private long AV62Maildesignwwds_11_tfmaildesignid_to ;
      private long A148MailDesignId ;
      private long AV29count ;
      private string AV15TFMailDesignAsunto ;
      private string AV16TFMailDesignAsunto_Sel ;
      private string AV43MailDesignTipo1 ;
      private string AV46MailDesignTipo2 ;
      private string AV49MailDesignTipo3 ;
      private string AV54Maildesignwwds_3_maildesigntipo1 ;
      private string AV57Maildesignwwds_6_maildesigntipo2 ;
      private string AV60Maildesignwwds_9_maildesigntipo3 ;
      private string AV64Maildesignwwds_13_tfmaildesignasunto ;
      private string AV65Maildesignwwds_14_tfmaildesignasunto_sel ;
      private string lV64Maildesignwwds_13_tfmaildesignasunto ;
      private string A244MailDesignTipo ;
      private string A245MailDesignEstado ;
      private string A246MailDesignAsunto ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV55Maildesignwwds_4_dynamicfiltersenabled2 ;
      private bool AV58Maildesignwwds_7_dynamicfiltersenabled3 ;
      private bool BRKBI2 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV13TFMailDesignTipo_SelsJson ;
      private string AV17TFMailDesignEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV52Maildesignwwds_1_filterfulltext ;
      private string AV53Maildesignwwds_2_dynamicfiltersselector1 ;
      private string AV56Maildesignwwds_5_dynamicfiltersselector2 ;
      private string AV59Maildesignwwds_8_dynamicfiltersselector3 ;
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
      private GxSimpleCollection<string> AV14TFMailDesignTipo_Sels ;
      private GxSimpleCollection<string> AV18TFMailDesignEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV63Maildesignwwds_12_tfmaildesigntipo_sels ;
      private GxSimpleCollection<string> AV66Maildesignwwds_15_tfmaildesignestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BI2_A246MailDesignAsunto ;
      private long[] P00BI2_A148MailDesignId ;
      private string[] P00BI2_A245MailDesignEstado ;
      private string[] P00BI2_A244MailDesignTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class maildesignwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BI2( IGxContext context ,
                                             string A244MailDesignTipo ,
                                             GxSimpleCollection<string> AV63Maildesignwwds_12_tfmaildesigntipo_sels ,
                                             string A245MailDesignEstado ,
                                             GxSimpleCollection<string> AV66Maildesignwwds_15_tfmaildesignestado_sels ,
                                             string AV53Maildesignwwds_2_dynamicfiltersselector1 ,
                                             string AV54Maildesignwwds_3_maildesigntipo1 ,
                                             bool AV55Maildesignwwds_4_dynamicfiltersenabled2 ,
                                             string AV56Maildesignwwds_5_dynamicfiltersselector2 ,
                                             string AV57Maildesignwwds_6_maildesigntipo2 ,
                                             bool AV58Maildesignwwds_7_dynamicfiltersenabled3 ,
                                             string AV59Maildesignwwds_8_dynamicfiltersselector3 ,
                                             string AV60Maildesignwwds_9_maildesigntipo3 ,
                                             long AV61Maildesignwwds_10_tfmaildesignid ,
                                             long AV62Maildesignwwds_11_tfmaildesignid_to ,
                                             int AV63Maildesignwwds_12_tfmaildesigntipo_sels_Count ,
                                             string AV65Maildesignwwds_14_tfmaildesignasunto_sel ,
                                             string AV64Maildesignwwds_13_tfmaildesignasunto ,
                                             int AV66Maildesignwwds_15_tfmaildesignestado_sels_Count ,
                                             long A148MailDesignId ,
                                             string A246MailDesignAsunto ,
                                             string AV52Maildesignwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MailDesignAsunto], [MailDesignId], [MailDesignEstado], [MailDesignTipo] FROM [MailDesign]";
         if ( ( StringUtil.StrCmp(AV53Maildesignwwds_2_dynamicfiltersselector1, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Maildesignwwds_3_maildesigntipo1)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV54Maildesignwwds_3_maildesigntipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV55Maildesignwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Maildesignwwds_5_dynamicfiltersselector2, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Maildesignwwds_6_maildesigntipo2)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV57Maildesignwwds_6_maildesigntipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV58Maildesignwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Maildesignwwds_8_dynamicfiltersselector3, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Maildesignwwds_9_maildesigntipo3)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV60Maildesignwwds_9_maildesigntipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV61Maildesignwwds_10_tfmaildesignid) )
         {
            AddWhere(sWhereString, "([MailDesignId] >= @AV61Maildesignwwds_10_tfmaildesignid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV62Maildesignwwds_11_tfmaildesignid_to) )
         {
            AddWhere(sWhereString, "([MailDesignId] <= @AV62Maildesignwwds_11_tfmaildesignid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV63Maildesignwwds_12_tfmaildesigntipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Maildesignwwds_12_tfmaildesigntipo_sels, "[MailDesignTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Maildesignwwds_14_tfmaildesignasunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Maildesignwwds_13_tfmaildesignasunto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDesignAsunto]) like UPPER(@lV64Maildesignwwds_13_tfmaildesignasunto))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Maildesignwwds_14_tfmaildesignasunto_sel)) && ! ( StringUtil.StrCmp(AV65Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] = @AV65Maildesignwwds_14_tfmaildesignasunto_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDesignAsunto] = ''))");
         }
         if ( AV66Maildesignwwds_15_tfmaildesignestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Maildesignwwds_15_tfmaildesignestado_sels, "[MailDesignEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MailDesignAsunto]";
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
                     return conditional_P00BI2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP00BI2;
          prmP00BI2 = new Object[] {
          new ParDef("@AV54Maildesignwwds_3_maildesigntipo1",GXType.NChar,1,0) ,
          new ParDef("@AV57Maildesignwwds_6_maildesigntipo2",GXType.NChar,1,0) ,
          new ParDef("@AV60Maildesignwwds_9_maildesigntipo3",GXType.NChar,1,0) ,
          new ParDef("@AV61Maildesignwwds_10_tfmaildesignid",GXType.Decimal,18,0) ,
          new ParDef("@AV62Maildesignwwds_11_tfmaildesignid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV64Maildesignwwds_13_tfmaildesignasunto",GXType.Char,80,0) ,
          new ParDef("@AV65Maildesignwwds_14_tfmaildesignasunto_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.maildesignwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class maildesignwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MailDesignWWGetFilterData" )]
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
          if ( ! ProcessHeaders("maildesignwwgetfilterdata") )
          {
             return  ;
          }
          maildesignwwgetfilterdata worker = new maildesignwwgetfilterdata(context);
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
