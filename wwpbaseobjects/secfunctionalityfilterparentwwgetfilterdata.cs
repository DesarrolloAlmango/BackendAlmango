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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityfilterparentwwgetfilterdata : GXProcedure
   {
      public secfunctionalityfilterparentwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentwwgetfilterdata( IGxContext context )
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
         this.AV19DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV18SearchTxtTo = aP2_SearchTxtTo;
         this.AV23OptionsJson = "" ;
         this.AV26OptionsDescJson = "" ;
         this.AV28OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV23OptionsJson;
         aP4_OptionsDescJson=this.AV26OptionsDescJson;
         aP5_OptionIndexesJson=this.AV28OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV28OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV19DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV18SearchTxtTo = aP2_SearchTxtTo;
         this.AV23OptionsJson = "" ;
         this.AV26OptionsDescJson = "" ;
         this.AV28OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV23OptionsJson;
         aP4_OptionsDescJson=this.AV26OptionsDescJson;
         aP5_OptionIndexesJson=this.AV28OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecFunctionality", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV44MaxItems = 10;
            AV43PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV45SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? "" : StringUtil.Substring( AV45SearchTxtParms, 3, -1));
            AV42SkipItems = (short)(AV43PageIndex*AV44MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV39WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECFUNCTIONALITYKEY") == 0 )
            {
               /* Execute user subroutine: 'LOADSECFUNCTIONALITYKEYOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               /* Execute user subroutine: 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               /* Execute user subroutine: 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV23OptionsJson = AV22Options.ToJSonString(false);
         AV26OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV28OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV35SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV37SecFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
               AV36SecFunctionalityDescriptionOperator = AV33GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV10TFSecFunctionalityKey = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV11TFSecFunctionalityKey_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV12TFSecFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV13TFSecFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV40TFSecFunctionalityType_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV41TFSecFunctionalityType_Sels.FromJSonString(AV40TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&SECPARENTFUNCTIONALITYID") == 0 )
            {
               AV38SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecFunctionalityKey = AV17SearchTxt;
         AV11TFSecFunctionalityKey_Sel = "";
         AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A20SecFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A14SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002A2 */
         pr_default.execute(0, new Object[] {AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2A2 = false;
            A14SecParentFunctionalityId = P002A2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002A2_n14SecParentFunctionalityId[0];
            A15SecFunctionalityKey = P002A2_A15SecFunctionalityKey[0];
            A23SecParentFunctionalityDescript = P002A2_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002A2_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002A2_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002A2_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002A2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P002A2_A14SecParentFunctionalityId[0] == A14SecParentFunctionalityId ) && ( StringUtil.StrCmp(P002A2_A15SecFunctionalityKey[0], A15SecFunctionalityKey) == 0 ) )
               {
                  BRK2A2 = false;
                  A13SecFunctionalityId = P002A2_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2A2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV42SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A15SecFunctionalityKey)) ? "<#Empty#>" : A15SecFunctionalityKey);
                  AV22Options.Add(AV21Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV42SkipItems = (short)(AV42SkipItems-1);
               }
            }
            if ( ! BRK2A2 )
            {
               BRK2A2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecFunctionalityDescription = AV17SearchTxt;
         AV13TFSecFunctionalityDescription_Sel = "";
         AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A20SecFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A14SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002A3 */
         pr_default.execute(1, new Object[] {AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2A4 = false;
            A14SecParentFunctionalityId = P002A3_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002A3_n14SecParentFunctionalityId[0];
            A20SecFunctionalityDescription = P002A3_A20SecFunctionalityDescription[0];
            A23SecParentFunctionalityDescript = P002A3_A23SecParentFunctionalityDescript[0];
            A15SecFunctionalityKey = P002A3_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002A3_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002A3_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002A3_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P002A3_A14SecParentFunctionalityId[0] == A14SecParentFunctionalityId ) && ( StringUtil.StrCmp(P002A3_A20SecFunctionalityDescription[0], A20SecFunctionalityDescription) == 0 ) )
               {
                  BRK2A4 = false;
                  A13SecFunctionalityId = P002A3_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2A4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV42SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A20SecFunctionalityDescription)) ? "<#Empty#>" : A20SecFunctionalityDescription);
                  AV22Options.Add(AV21Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV42SkipItems = (short)(AV42SkipItems-1);
               }
            }
            if ( ! BRK2A4 )
            {
               BRK2A4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFSecParentFunctionalityDescription = AV17SearchTxt;
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV38SecParentFunctionalityId;
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV46FilterFullText;
         AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV35SecFunctionalityType;
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV37SecFunctionalityDescription;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV41TFSecFunctionalityType_Sels;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV36SecFunctionalityDescriptionOperator ,
                                              AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A20SecFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A14SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002A4 */
         pr_default.execute(2, new Object[] {AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2A6 = false;
            A14SecParentFunctionalityId = P002A4_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002A4_n14SecParentFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002A4_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002A4_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P002A4_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002A4_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002A4_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002A4_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P002A4_A14SecParentFunctionalityId[0] == A14SecParentFunctionalityId ) && ( StringUtil.StrCmp(P002A4_A23SecParentFunctionalityDescript[0], A23SecParentFunctionalityDescript) == 0 ) )
               {
                  BRK2A6 = false;
                  A13SecFunctionalityId = P002A4_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2A6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV42SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A23SecParentFunctionalityDescript)) ? "<#Empty#>" : A23SecParentFunctionalityDescript);
                  AV22Options.Add(AV21Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV42SkipItems = (short)(AV42SkipItems-1);
               }
            }
            if ( ! BRK2A6 )
            {
               BRK2A6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV23OptionsJson = "";
         AV26OptionsDescJson = "";
         AV28OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV39WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV37SecFunctionalityDescription = "";
         AV10TFSecFunctionalityKey = "";
         AV11TFSecFunctionalityKey_Sel = "";
         AV12TFSecFunctionalityDescription = "";
         AV13TFSecFunctionalityDescription_Sel = "";
         AV40TFSecFunctionalityType_SelsJson = "";
         AV41TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         lV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         A20SecFunctionalityDescription = "";
         A15SecFunctionalityKey = "";
         A23SecParentFunctionalityDescript = "";
         P002A2_A14SecParentFunctionalityId = new long[1] ;
         P002A2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002A2_A15SecFunctionalityKey = new string[] {""} ;
         P002A2_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002A2_A20SecFunctionalityDescription = new string[] {""} ;
         P002A2_A21SecFunctionalityType = new short[1] ;
         P002A2_A13SecFunctionalityId = new long[1] ;
         AV21Option = "";
         P002A3_A14SecParentFunctionalityId = new long[1] ;
         P002A3_n14SecParentFunctionalityId = new bool[] {false} ;
         P002A3_A20SecFunctionalityDescription = new string[] {""} ;
         P002A3_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002A3_A15SecFunctionalityKey = new string[] {""} ;
         P002A3_A21SecFunctionalityType = new short[1] ;
         P002A3_A13SecFunctionalityId = new long[1] ;
         P002A4_A14SecParentFunctionalityId = new long[1] ;
         P002A4_n14SecParentFunctionalityId = new bool[] {false} ;
         P002A4_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002A4_A20SecFunctionalityDescription = new string[] {""} ;
         P002A4_A15SecFunctionalityKey = new string[] {""} ;
         P002A4_A21SecFunctionalityType = new short[1] ;
         P002A4_A13SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002A2_A14SecParentFunctionalityId, P002A2_n14SecParentFunctionalityId, P002A2_A15SecFunctionalityKey, P002A2_A23SecParentFunctionalityDescript, P002A2_A20SecFunctionalityDescription, P002A2_A21SecFunctionalityType, P002A2_A13SecFunctionalityId
               }
               , new Object[] {
               P002A3_A14SecParentFunctionalityId, P002A3_n14SecParentFunctionalityId, P002A3_A20SecFunctionalityDescription, P002A3_A23SecParentFunctionalityDescript, P002A3_A15SecFunctionalityKey, P002A3_A21SecFunctionalityType, P002A3_A13SecFunctionalityId
               }
               , new Object[] {
               P002A4_A14SecParentFunctionalityId, P002A4_n14SecParentFunctionalityId, P002A4_A23SecParentFunctionalityDescript, P002A4_A20SecFunctionalityDescription, P002A4_A15SecFunctionalityKey, P002A4_A21SecFunctionalityType, P002A4_A13SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV44MaxItems ;
      private short AV43PageIndex ;
      private short AV42SkipItems ;
      private short AV35SecFunctionalityType ;
      private short AV36SecFunctionalityDescriptionOperator ;
      private short AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
      private short A21SecFunctionalityType ;
      private int AV47GXV1 ;
      private int AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private long AV38SecParentFunctionalityId ;
      private long AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private long AV29count ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK2A2 ;
      private bool n14SecParentFunctionalityId ;
      private bool BRK2A4 ;
      private bool BRK2A6 ;
      private string AV23OptionsJson ;
      private string AV26OptionsDescJson ;
      private string AV28OptionIndexesJson ;
      private string AV40TFSecFunctionalityType_SelsJson ;
      private string AV19DDOName ;
      private string AV45SearchTxtParms ;
      private string AV18SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV46FilterFullText ;
      private string AV37SecFunctionalityDescription ;
      private string AV10TFSecFunctionalityKey ;
      private string AV11TFSecFunctionalityKey_Sel ;
      private string AV12TFSecFunctionalityDescription ;
      private string AV13TFSecFunctionalityDescription_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string lV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string A20SecFunctionalityDescription ;
      private string A15SecFunctionalityKey ;
      private string A23SecParentFunctionalityDescript ;
      private string AV21Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<short> AV41TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P002A2_A14SecParentFunctionalityId ;
      private bool[] P002A2_n14SecParentFunctionalityId ;
      private string[] P002A2_A15SecFunctionalityKey ;
      private string[] P002A2_A23SecParentFunctionalityDescript ;
      private string[] P002A2_A20SecFunctionalityDescription ;
      private short[] P002A2_A21SecFunctionalityType ;
      private long[] P002A2_A13SecFunctionalityId ;
      private long[] P002A3_A14SecParentFunctionalityId ;
      private bool[] P002A3_n14SecParentFunctionalityId ;
      private string[] P002A3_A20SecFunctionalityDescription ;
      private string[] P002A3_A23SecParentFunctionalityDescript ;
      private string[] P002A3_A15SecFunctionalityKey ;
      private short[] P002A3_A21SecFunctionalityType ;
      private long[] P002A3_A13SecFunctionalityId ;
      private long[] P002A4_A14SecParentFunctionalityId ;
      private bool[] P002A4_n14SecParentFunctionalityId ;
      private string[] P002A4_A23SecParentFunctionalityDescript ;
      private string[] P002A4_A20SecFunctionalityDescription ;
      private string[] P002A4_A15SecFunctionalityKey ;
      private short[] P002A4_A21SecFunctionalityType ;
      private long[] P002A4_A13SecFunctionalityId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secfunctionalityfilterparentwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002A2( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             short AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A20SecFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             long AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A14SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecFunctionalityKey], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecParentFunctionalityId] = @AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid)");
         if ( ! (0==AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityType] = @AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like '%' + UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T1.[SecFunctionalityKey]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P002A3( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             short AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A20SecFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             long AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A14SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecFunctionalityDescription], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecParentFunctionalityId] = @AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid)");
         if ( ! (0==AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityType] = @AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like '%' + UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T1.[SecFunctionalityDescription]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P002A4( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             short AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV36SecFunctionalityDescriptionOperator ,
                                             string AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A20SecFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV50Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             long AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A14SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[10];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecParentFunctionalityId] = @AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid)");
         if ( ! (0==AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityType] = @AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( AV36SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like '%' + UPPER(@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T2.[SecFunctionalityDescription]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002A2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 1 :
                     return conditional_P002A3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 2 :
                     return conditional_P002A4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002A2;
          prmP002A2 = new Object[] {
          new ParDef("@AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid",GXType.Decimal,10,0) ,
          new ParDef("@AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype",GXType.Int16,2,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002A3;
          prmP002A3 = new Object[] {
          new ParDef("@AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid",GXType.Decimal,10,0) ,
          new ParDef("@AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype",GXType.Int16,2,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002A4;
          prmP002A4 = new Object[] {
          new ParDef("@AV49Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid",GXType.Decimal,10,0) ,
          new ParDef("@AV51Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype",GXType.Int16,2,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV52Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV53Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002A4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002A4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class secfunctionalityfilterparentwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SecFunctionalityFilterParentWWGetFilterData" )]
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
          if ( ! ProcessHeaders("wwpbaseobjects.secfunctionalityfilterparentwwgetfilterdata") )
          {
             return  ;
          }
          secfunctionalityfilterparentwwgetfilterdata worker = new secfunctionalityfilterparentwwgetfilterdata(context);
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
