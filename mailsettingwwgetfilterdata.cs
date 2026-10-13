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
   public class mailsettingwwgetfilterdata : GXProcedure
   {
      public mailsettingwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mailsettingwwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MAILCUENTANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMAILCUENTANOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MAILDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADMAILDIRECCIONOPTIONS' */
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
         if ( StringUtil.StrCmp(AV30Session.Get("MailSettingWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailSettingWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("MailSettingWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILID") == 0 )
            {
               AV11TFMailId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMailId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE") == 0 )
            {
               AV13TFMailCuentaNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE_SEL") == 0 )
            {
               AV14TFMailCuentaNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION") == 0 )
            {
               AV15TFMailDireccion = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION_SEL") == 0 )
            {
               AV16TFMailDireccion_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILESTADO_SEL") == 0 )
            {
               AV17TFMailEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFMailEstado_Sels.FromJSonString(AV17TFMailEstado_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "MAILHOSTSMTP") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44MailHostSMTP1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "MAILHOSTSMTP") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48MailHostSMTP2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "MAILHOSTSMTP") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52MailHostSMTP3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMAILCUENTANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFMailCuentaNombre = AV19SearchTxt;
         AV14TFMailCuentaNombre_Sel = "";
         AV55Mailsettingwwds_1_filterfulltext = AV41FilterFullText;
         AV56Mailsettingwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Mailsettingwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Mailsettingwwds_4_mailhostsmtp1 = AV44MailHostSMTP1;
         AV59Mailsettingwwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Mailsettingwwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Mailsettingwwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Mailsettingwwds_8_mailhostsmtp2 = AV48MailHostSMTP2;
         AV63Mailsettingwwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Mailsettingwwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Mailsettingwwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Mailsettingwwds_12_mailhostsmtp3 = AV52MailHostSMTP3;
         AV67Mailsettingwwds_13_tfmailid = AV11TFMailId;
         AV68Mailsettingwwds_14_tfmailid_to = AV12TFMailId_To;
         AV69Mailsettingwwds_15_tfmailcuentanombre = AV13TFMailCuentaNombre;
         AV70Mailsettingwwds_16_tfmailcuentanombre_sel = AV14TFMailCuentaNombre_Sel;
         AV71Mailsettingwwds_17_tfmaildireccion = AV15TFMailDireccion;
         AV72Mailsettingwwds_18_tfmaildireccion_sel = AV16TFMailDireccion_Sel;
         AV73Mailsettingwwds_19_tfmailestado_sels = AV18TFMailEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A243MailEstado ,
                                              AV73Mailsettingwwds_19_tfmailestado_sels ,
                                              AV56Mailsettingwwds_2_dynamicfiltersselector1 ,
                                              AV57Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                              AV58Mailsettingwwds_4_mailhostsmtp1 ,
                                              AV59Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                              AV60Mailsettingwwds_6_dynamicfiltersselector2 ,
                                              AV61Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                              AV62Mailsettingwwds_8_mailhostsmtp2 ,
                                              AV63Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                              AV64Mailsettingwwds_10_dynamicfiltersselector3 ,
                                              AV65Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                              AV66Mailsettingwwds_12_mailhostsmtp3 ,
                                              AV67Mailsettingwwds_13_tfmailid ,
                                              AV68Mailsettingwwds_14_tfmailid_to ,
                                              AV70Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                              AV69Mailsettingwwds_15_tfmailcuentanombre ,
                                              AV72Mailsettingwwds_18_tfmaildireccion_sel ,
                                              AV71Mailsettingwwds_17_tfmaildireccion ,
                                              AV73Mailsettingwwds_19_tfmailestado_sels.Count ,
                                              A249MailHostSMTP ,
                                              A149MailId ,
                                              A241MailCuentaNombre ,
                                              A242MailDireccion ,
                                              AV55Mailsettingwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV58Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV58Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV62Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV62Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV66Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV66Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV69Mailsettingwwds_15_tfmailcuentanombre = StringUtil.PadR( StringUtil.RTrim( AV69Mailsettingwwds_15_tfmailcuentanombre), 80, "%");
         lV71Mailsettingwwds_17_tfmaildireccion = StringUtil.Concat( StringUtil.RTrim( AV71Mailsettingwwds_17_tfmaildireccion), "%", "");
         /* Using cursor P00BX2 */
         pr_default.execute(0, new Object[] {lV58Mailsettingwwds_4_mailhostsmtp1, lV58Mailsettingwwds_4_mailhostsmtp1, lV62Mailsettingwwds_8_mailhostsmtp2, lV62Mailsettingwwds_8_mailhostsmtp2, lV66Mailsettingwwds_12_mailhostsmtp3, lV66Mailsettingwwds_12_mailhostsmtp3, AV67Mailsettingwwds_13_tfmailid, AV68Mailsettingwwds_14_tfmailid_to, lV69Mailsettingwwds_15_tfmailcuentanombre, AV70Mailsettingwwds_16_tfmailcuentanombre_sel, lV71Mailsettingwwds_17_tfmaildireccion, AV72Mailsettingwwds_18_tfmaildireccion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBX2 = false;
            A241MailCuentaNombre = P00BX2_A241MailCuentaNombre[0];
            A249MailHostSMTP = P00BX2_A249MailHostSMTP[0];
            A242MailDireccion = P00BX2_A242MailDireccion[0];
            A149MailId = P00BX2_A149MailId[0];
            A243MailEstado = P00BX2_A243MailEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Mailsettingwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A149MailId), 18, 0) , StringUtil.PadR( "%" + AV55Mailsettingwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A241MailCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A242MailDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "DES") == 0 ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BX2_A241MailCuentaNombre[0], A241MailCuentaNombre) == 0 ) )
               {
                  BRKBX2 = false;
                  A149MailId = P00BX2_A149MailId[0];
                  AV29count = (long)(AV29count+1);
                  BRKBX2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A241MailCuentaNombre)) ? "<#Empty#>" : A241MailCuentaNombre);
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
            if ( ! BRKBX2 )
            {
               BRKBX2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMAILDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFMailDireccion = AV19SearchTxt;
         AV16TFMailDireccion_Sel = "";
         AV55Mailsettingwwds_1_filterfulltext = AV41FilterFullText;
         AV56Mailsettingwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Mailsettingwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Mailsettingwwds_4_mailhostsmtp1 = AV44MailHostSMTP1;
         AV59Mailsettingwwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Mailsettingwwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Mailsettingwwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Mailsettingwwds_8_mailhostsmtp2 = AV48MailHostSMTP2;
         AV63Mailsettingwwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Mailsettingwwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Mailsettingwwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Mailsettingwwds_12_mailhostsmtp3 = AV52MailHostSMTP3;
         AV67Mailsettingwwds_13_tfmailid = AV11TFMailId;
         AV68Mailsettingwwds_14_tfmailid_to = AV12TFMailId_To;
         AV69Mailsettingwwds_15_tfmailcuentanombre = AV13TFMailCuentaNombre;
         AV70Mailsettingwwds_16_tfmailcuentanombre_sel = AV14TFMailCuentaNombre_Sel;
         AV71Mailsettingwwds_17_tfmaildireccion = AV15TFMailDireccion;
         AV72Mailsettingwwds_18_tfmaildireccion_sel = AV16TFMailDireccion_Sel;
         AV73Mailsettingwwds_19_tfmailestado_sels = AV18TFMailEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A243MailEstado ,
                                              AV73Mailsettingwwds_19_tfmailestado_sels ,
                                              AV56Mailsettingwwds_2_dynamicfiltersselector1 ,
                                              AV57Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                              AV58Mailsettingwwds_4_mailhostsmtp1 ,
                                              AV59Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                              AV60Mailsettingwwds_6_dynamicfiltersselector2 ,
                                              AV61Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                              AV62Mailsettingwwds_8_mailhostsmtp2 ,
                                              AV63Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                              AV64Mailsettingwwds_10_dynamicfiltersselector3 ,
                                              AV65Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                              AV66Mailsettingwwds_12_mailhostsmtp3 ,
                                              AV67Mailsettingwwds_13_tfmailid ,
                                              AV68Mailsettingwwds_14_tfmailid_to ,
                                              AV70Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                              AV69Mailsettingwwds_15_tfmailcuentanombre ,
                                              AV72Mailsettingwwds_18_tfmaildireccion_sel ,
                                              AV71Mailsettingwwds_17_tfmaildireccion ,
                                              AV73Mailsettingwwds_19_tfmailestado_sels.Count ,
                                              A249MailHostSMTP ,
                                              A149MailId ,
                                              A241MailCuentaNombre ,
                                              A242MailDireccion ,
                                              AV55Mailsettingwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV58Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV58Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV62Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV62Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV66Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV66Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV69Mailsettingwwds_15_tfmailcuentanombre = StringUtil.PadR( StringUtil.RTrim( AV69Mailsettingwwds_15_tfmailcuentanombre), 80, "%");
         lV71Mailsettingwwds_17_tfmaildireccion = StringUtil.Concat( StringUtil.RTrim( AV71Mailsettingwwds_17_tfmaildireccion), "%", "");
         /* Using cursor P00BX3 */
         pr_default.execute(1, new Object[] {lV58Mailsettingwwds_4_mailhostsmtp1, lV58Mailsettingwwds_4_mailhostsmtp1, lV62Mailsettingwwds_8_mailhostsmtp2, lV62Mailsettingwwds_8_mailhostsmtp2, lV66Mailsettingwwds_12_mailhostsmtp3, lV66Mailsettingwwds_12_mailhostsmtp3, AV67Mailsettingwwds_13_tfmailid, AV68Mailsettingwwds_14_tfmailid_to, lV69Mailsettingwwds_15_tfmailcuentanombre, AV70Mailsettingwwds_16_tfmailcuentanombre_sel, lV71Mailsettingwwds_17_tfmaildireccion, AV72Mailsettingwwds_18_tfmaildireccion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBX4 = false;
            A242MailDireccion = P00BX3_A242MailDireccion[0];
            A249MailHostSMTP = P00BX3_A249MailHostSMTP[0];
            A241MailCuentaNombre = P00BX3_A241MailCuentaNombre[0];
            A149MailId = P00BX3_A149MailId[0];
            A243MailEstado = P00BX3_A243MailEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Mailsettingwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A149MailId), 18, 0) , StringUtil.PadR( "%" + AV55Mailsettingwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A241MailCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A242MailDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "DES") == 0 ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BX3_A242MailDireccion[0], A242MailDireccion) == 0 ) )
               {
                  BRKBX4 = false;
                  A149MailId = P00BX3_A149MailId[0];
                  AV29count = (long)(AV29count+1);
                  BRKBX4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A242MailDireccion)) ? "<#Empty#>" : A242MailDireccion);
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
            if ( ! BRKBX4 )
            {
               BRKBX4 = true;
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
         AV13TFMailCuentaNombre = "";
         AV14TFMailCuentaNombre_Sel = "";
         AV15TFMailDireccion = "";
         AV16TFMailDireccion_Sel = "";
         AV17TFMailEstado_SelsJson = "";
         AV18TFMailEstado_Sels = new GxSimpleCollection<string>();
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44MailHostSMTP1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48MailHostSMTP2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52MailHostSMTP3 = "";
         AV55Mailsettingwwds_1_filterfulltext = "";
         AV56Mailsettingwwds_2_dynamicfiltersselector1 = "";
         AV58Mailsettingwwds_4_mailhostsmtp1 = "";
         AV60Mailsettingwwds_6_dynamicfiltersselector2 = "";
         AV62Mailsettingwwds_8_mailhostsmtp2 = "";
         AV64Mailsettingwwds_10_dynamicfiltersselector3 = "";
         AV66Mailsettingwwds_12_mailhostsmtp3 = "";
         AV69Mailsettingwwds_15_tfmailcuentanombre = "";
         AV70Mailsettingwwds_16_tfmailcuentanombre_sel = "";
         AV71Mailsettingwwds_17_tfmaildireccion = "";
         AV72Mailsettingwwds_18_tfmaildireccion_sel = "";
         AV73Mailsettingwwds_19_tfmailestado_sels = new GxSimpleCollection<string>();
         lV58Mailsettingwwds_4_mailhostsmtp1 = "";
         lV62Mailsettingwwds_8_mailhostsmtp2 = "";
         lV66Mailsettingwwds_12_mailhostsmtp3 = "";
         lV69Mailsettingwwds_15_tfmailcuentanombre = "";
         lV71Mailsettingwwds_17_tfmaildireccion = "";
         A243MailEstado = "";
         A249MailHostSMTP = "";
         A241MailCuentaNombre = "";
         A242MailDireccion = "";
         P00BX2_A241MailCuentaNombre = new string[] {""} ;
         P00BX2_A249MailHostSMTP = new string[] {""} ;
         P00BX2_A242MailDireccion = new string[] {""} ;
         P00BX2_A149MailId = new long[1] ;
         P00BX2_A243MailEstado = new string[] {""} ;
         AV24Option = "";
         P00BX3_A242MailDireccion = new string[] {""} ;
         P00BX3_A249MailHostSMTP = new string[] {""} ;
         P00BX3_A241MailCuentaNombre = new string[] {""} ;
         P00BX3_A149MailId = new long[1] ;
         P00BX3_A243MailEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mailsettingwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BX2_A241MailCuentaNombre, P00BX2_A249MailHostSMTP, P00BX2_A242MailDireccion, P00BX2_A149MailId, P00BX2_A243MailEstado
               }
               , new Object[] {
               P00BX3_A242MailDireccion, P00BX3_A249MailHostSMTP, P00BX3_A241MailCuentaNombre, P00BX3_A149MailId, P00BX3_A243MailEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV57Mailsettingwwds_3_dynamicfiltersoperator1 ;
      private short AV61Mailsettingwwds_7_dynamicfiltersoperator2 ;
      private short AV65Mailsettingwwds_11_dynamicfiltersoperator3 ;
      private int AV53GXV1 ;
      private int AV73Mailsettingwwds_19_tfmailestado_sels_Count ;
      private long AV11TFMailId ;
      private long AV12TFMailId_To ;
      private long AV67Mailsettingwwds_13_tfmailid ;
      private long AV68Mailsettingwwds_14_tfmailid_to ;
      private long A149MailId ;
      private long AV29count ;
      private string AV13TFMailCuentaNombre ;
      private string AV14TFMailCuentaNombre_Sel ;
      private string AV44MailHostSMTP1 ;
      private string AV48MailHostSMTP2 ;
      private string AV52MailHostSMTP3 ;
      private string AV58Mailsettingwwds_4_mailhostsmtp1 ;
      private string AV62Mailsettingwwds_8_mailhostsmtp2 ;
      private string AV66Mailsettingwwds_12_mailhostsmtp3 ;
      private string AV69Mailsettingwwds_15_tfmailcuentanombre ;
      private string AV70Mailsettingwwds_16_tfmailcuentanombre_sel ;
      private string lV58Mailsettingwwds_4_mailhostsmtp1 ;
      private string lV62Mailsettingwwds_8_mailhostsmtp2 ;
      private string lV66Mailsettingwwds_12_mailhostsmtp3 ;
      private string lV69Mailsettingwwds_15_tfmailcuentanombre ;
      private string A243MailEstado ;
      private string A249MailHostSMTP ;
      private string A241MailCuentaNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV59Mailsettingwwds_5_dynamicfiltersenabled2 ;
      private bool AV63Mailsettingwwds_9_dynamicfiltersenabled3 ;
      private bool BRKBX2 ;
      private bool BRKBX4 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV17TFMailEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV15TFMailDireccion ;
      private string AV16TFMailDireccion_Sel ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV55Mailsettingwwds_1_filterfulltext ;
      private string AV56Mailsettingwwds_2_dynamicfiltersselector1 ;
      private string AV60Mailsettingwwds_6_dynamicfiltersselector2 ;
      private string AV64Mailsettingwwds_10_dynamicfiltersselector3 ;
      private string AV71Mailsettingwwds_17_tfmaildireccion ;
      private string AV72Mailsettingwwds_18_tfmaildireccion_sel ;
      private string lV71Mailsettingwwds_17_tfmaildireccion ;
      private string A242MailDireccion ;
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
      private GxSimpleCollection<string> AV18TFMailEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV73Mailsettingwwds_19_tfmailestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BX2_A241MailCuentaNombre ;
      private string[] P00BX2_A249MailHostSMTP ;
      private string[] P00BX2_A242MailDireccion ;
      private long[] P00BX2_A149MailId ;
      private string[] P00BX2_A243MailEstado ;
      private string[] P00BX3_A242MailDireccion ;
      private string[] P00BX3_A249MailHostSMTP ;
      private string[] P00BX3_A241MailCuentaNombre ;
      private long[] P00BX3_A149MailId ;
      private string[] P00BX3_A243MailEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class mailsettingwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BX2( IGxContext context ,
                                             string A243MailEstado ,
                                             GxSimpleCollection<string> AV73Mailsettingwwds_19_tfmailestado_sels ,
                                             string AV56Mailsettingwwds_2_dynamicfiltersselector1 ,
                                             short AV57Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                             string AV58Mailsettingwwds_4_mailhostsmtp1 ,
                                             bool AV59Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                             string AV60Mailsettingwwds_6_dynamicfiltersselector2 ,
                                             short AV61Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                             string AV62Mailsettingwwds_8_mailhostsmtp2 ,
                                             bool AV63Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                             string AV64Mailsettingwwds_10_dynamicfiltersselector3 ,
                                             short AV65Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                             string AV66Mailsettingwwds_12_mailhostsmtp3 ,
                                             long AV67Mailsettingwwds_13_tfmailid ,
                                             long AV68Mailsettingwwds_14_tfmailid_to ,
                                             string AV70Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                             string AV69Mailsettingwwds_15_tfmailcuentanombre ,
                                             string AV72Mailsettingwwds_18_tfmaildireccion_sel ,
                                             string AV71Mailsettingwwds_17_tfmaildireccion ,
                                             int AV73Mailsettingwwds_19_tfmailestado_sels_Count ,
                                             string A249MailHostSMTP ,
                                             long A149MailId ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             string AV55Mailsettingwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MailCuentaNombre], [MailHostSMTP], [MailDireccion], [MailId], [MailEstado] FROM [Mail]";
         if ( ( StringUtil.StrCmp(AV56Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV57Mailsettingwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV58Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV57Mailsettingwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV58Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV59Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV61Mailsettingwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV62Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV59Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV61Mailsettingwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV62Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV63Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV65Mailsettingwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV66Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV63Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV65Mailsettingwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV66Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV67Mailsettingwwds_13_tfmailid) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV67Mailsettingwwds_13_tfmailid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV68Mailsettingwwds_14_tfmailid_to) )
         {
            AddWhere(sWhereString, "([MailId] <= @AV68Mailsettingwwds_14_tfmailid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Mailsettingwwds_16_tfmailcuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Mailsettingwwds_15_tfmailcuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailCuentaNombre]) like UPPER(@lV69Mailsettingwwds_15_tfmailcuentanombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Mailsettingwwds_16_tfmailcuentanombre_sel)) && ! ( StringUtil.StrCmp(AV70Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] = @AV70Mailsettingwwds_16_tfmailcuentanombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_18_tfmaildireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Mailsettingwwds_17_tfmaildireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDireccion]) like UPPER(@lV71Mailsettingwwds_17_tfmaildireccion))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_18_tfmaildireccion_sel)) && ! ( StringUtil.StrCmp(AV72Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDireccion] = @AV72Mailsettingwwds_18_tfmaildireccion_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDireccion] = ''))");
         }
         if ( AV73Mailsettingwwds_19_tfmailestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Mailsettingwwds_19_tfmailestado_sels, "[MailEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MailCuentaNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BX3( IGxContext context ,
                                             string A243MailEstado ,
                                             GxSimpleCollection<string> AV73Mailsettingwwds_19_tfmailestado_sels ,
                                             string AV56Mailsettingwwds_2_dynamicfiltersselector1 ,
                                             short AV57Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                             string AV58Mailsettingwwds_4_mailhostsmtp1 ,
                                             bool AV59Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                             string AV60Mailsettingwwds_6_dynamicfiltersselector2 ,
                                             short AV61Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                             string AV62Mailsettingwwds_8_mailhostsmtp2 ,
                                             bool AV63Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                             string AV64Mailsettingwwds_10_dynamicfiltersselector3 ,
                                             short AV65Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                             string AV66Mailsettingwwds_12_mailhostsmtp3 ,
                                             long AV67Mailsettingwwds_13_tfmailid ,
                                             long AV68Mailsettingwwds_14_tfmailid_to ,
                                             string AV70Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                             string AV69Mailsettingwwds_15_tfmailcuentanombre ,
                                             string AV72Mailsettingwwds_18_tfmaildireccion_sel ,
                                             string AV71Mailsettingwwds_17_tfmaildireccion ,
                                             int AV73Mailsettingwwds_19_tfmailestado_sels_Count ,
                                             string A249MailHostSMTP ,
                                             long A149MailId ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             string AV55Mailsettingwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [MailDireccion], [MailHostSMTP], [MailCuentaNombre], [MailId], [MailEstado] FROM [Mail]";
         if ( ( StringUtil.StrCmp(AV56Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV57Mailsettingwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV58Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV57Mailsettingwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV58Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV59Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV61Mailsettingwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV62Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV59Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV61Mailsettingwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV62Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV63Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV65Mailsettingwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV66Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV63Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV65Mailsettingwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV66Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV67Mailsettingwwds_13_tfmailid) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV67Mailsettingwwds_13_tfmailid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV68Mailsettingwwds_14_tfmailid_to) )
         {
            AddWhere(sWhereString, "([MailId] <= @AV68Mailsettingwwds_14_tfmailid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Mailsettingwwds_16_tfmailcuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Mailsettingwwds_15_tfmailcuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailCuentaNombre]) like UPPER(@lV69Mailsettingwwds_15_tfmailcuentanombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Mailsettingwwds_16_tfmailcuentanombre_sel)) && ! ( StringUtil.StrCmp(AV70Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] = @AV70Mailsettingwwds_16_tfmailcuentanombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_18_tfmaildireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Mailsettingwwds_17_tfmaildireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDireccion]) like UPPER(@lV71Mailsettingwwds_17_tfmaildireccion))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_18_tfmaildireccion_sel)) && ! ( StringUtil.StrCmp(AV72Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDireccion] = @AV72Mailsettingwwds_18_tfmaildireccion_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDireccion] = ''))");
         }
         if ( AV73Mailsettingwwds_19_tfmailestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Mailsettingwwds_19_tfmailestado_sels, "[MailEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MailDireccion]";
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
                     return conditional_P00BX2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 1 :
                     return conditional_P00BX3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
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
          Object[] prmP00BX2;
          prmP00BX2 = new Object[] {
          new ParDef("@lV58Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV58Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV62Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV62Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV66Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@lV66Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@AV67Mailsettingwwds_13_tfmailid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Mailsettingwwds_14_tfmailid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV69Mailsettingwwds_15_tfmailcuentanombre",GXType.Char,80,0) ,
          new ParDef("@AV70Mailsettingwwds_16_tfmailcuentanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV71Mailsettingwwds_17_tfmaildireccion",GXType.VarChar,100,0) ,
          new ParDef("@AV72Mailsettingwwds_18_tfmaildireccion_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BX3;
          prmP00BX3 = new Object[] {
          new ParDef("@lV58Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV58Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV62Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV62Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV66Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@lV66Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@AV67Mailsettingwwds_13_tfmailid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Mailsettingwwds_14_tfmailid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV69Mailsettingwwds_15_tfmailcuentanombre",GXType.Char,80,0) ,
          new ParDef("@AV70Mailsettingwwds_16_tfmailcuentanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV71Mailsettingwwds_17_tfmaildireccion",GXType.VarChar,100,0) ,
          new ParDef("@AV72Mailsettingwwds_18_tfmaildireccion_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BX3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 250);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 250);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.mailsettingwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class mailsettingwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MailSettingWWGetFilterData" )]
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
          if ( ! ProcessHeaders("mailsettingwwgetfilterdata") )
          {
             return  ;
          }
          mailsettingwwgetfilterdata worker = new mailsettingwwgetfilterdata(context);
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
