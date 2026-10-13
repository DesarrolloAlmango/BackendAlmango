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
   public class secfunctionalitywwgetfilterdata : GXProcedure
   {
      public secfunctionalitywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitywwgetfilterdata( IGxContext context )
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
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
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
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
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
            AV43MaxItems = 10;
            AV42PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
            AV41SkipItems = (short)(AV42PageIndex*AV43MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV38WWPContext) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
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
               AV39TFSecFunctionalityType_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV40TFSecFunctionalityType_Sels.FromJSonString(AV39TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecFunctionalityKey = AV17SearchTxt;
         AV11TFSecFunctionalityKey_Sel = "";
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A15SecFunctionalityKey ,
                                              A20SecFunctionalityDescription ,
                                              A23SecParentFunctionalityDescript ,
                                              AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002F2 */
         pr_default.execute(0, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2F2 = false;
            A14SecParentFunctionalityId = P002F2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002F2_n14SecParentFunctionalityId[0];
            A15SecFunctionalityKey = P002F2_A15SecFunctionalityKey[0];
            A23SecParentFunctionalityDescript = P002F2_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002F2_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002F2_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002F2_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002F2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002F2_A15SecFunctionalityKey[0], A15SecFunctionalityKey) == 0 ) )
               {
                  BRK2F2 = false;
                  A13SecFunctionalityId = P002F2_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2F2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV41SkipItems) )
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
                  AV41SkipItems = (short)(AV41SkipItems-1);
               }
            }
            if ( ! BRK2F2 )
            {
               BRK2F2 = true;
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
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A15SecFunctionalityKey ,
                                              A20SecFunctionalityDescription ,
                                              A23SecParentFunctionalityDescript ,
                                              AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002F3 */
         pr_default.execute(1, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2F4 = false;
            A14SecParentFunctionalityId = P002F3_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002F3_n14SecParentFunctionalityId[0];
            A20SecFunctionalityDescription = P002F3_A20SecFunctionalityDescription[0];
            A23SecParentFunctionalityDescript = P002F3_A23SecParentFunctionalityDescript[0];
            A15SecFunctionalityKey = P002F3_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002F3_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002F3_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002F3_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002F3_A20SecFunctionalityDescription[0], A20SecFunctionalityDescription) == 0 ) )
               {
                  BRK2F4 = false;
                  A13SecFunctionalityId = P002F3_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2F4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV41SkipItems) )
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
                  AV41SkipItems = (short)(AV41SkipItems-1);
               }
            }
            if ( ! BRK2F4 )
            {
               BRK2F4 = true;
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
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV45FilterFullText;
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV10TFSecFunctionalityKey;
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV11TFSecFunctionalityKey_Sel;
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV12TFSecFunctionalityDescription;
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV13TFSecFunctionalityDescription_Sel;
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV40TFSecFunctionalityType_Sels;
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV15TFSecParentFunctionalityDescription;
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV16TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A15SecFunctionalityKey ,
                                              A20SecFunctionalityDescription ,
                                              A23SecParentFunctionalityDescript ,
                                              AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002F4 */
         pr_default.execute(2, new Object[] {lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2F6 = false;
            A14SecParentFunctionalityId = P002F4_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002F4_n14SecParentFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002F4_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002F4_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P002F4_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002F4_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002F4_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002F4_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002F4_A23SecParentFunctionalityDescript[0], A23SecParentFunctionalityDescript) == 0 ) )
               {
                  BRK2F6 = false;
                  A14SecParentFunctionalityId = P002F4_A14SecParentFunctionalityId[0];
                  n14SecParentFunctionalityId = P002F4_n14SecParentFunctionalityId[0];
                  A13SecFunctionalityId = P002F4_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2F6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV41SkipItems) )
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
                  AV41SkipItems = (short)(AV41SkipItems-1);
               }
            }
            if ( ! BRK2F6 )
            {
               BRK2F6 = true;
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
         AV38WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV10TFSecFunctionalityKey = "";
         AV11TFSecFunctionalityKey_Sel = "";
         AV12TFSecFunctionalityDescription = "";
         AV13TFSecFunctionalityDescription_Sel = "";
         AV39TFSecFunctionalityType_SelsJson = "";
         AV40TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         A23SecParentFunctionalityDescript = "";
         P002F2_A14SecParentFunctionalityId = new long[1] ;
         P002F2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002F2_A15SecFunctionalityKey = new string[] {""} ;
         P002F2_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002F2_A20SecFunctionalityDescription = new string[] {""} ;
         P002F2_A21SecFunctionalityType = new short[1] ;
         P002F2_A13SecFunctionalityId = new long[1] ;
         AV21Option = "";
         P002F3_A14SecParentFunctionalityId = new long[1] ;
         P002F3_n14SecParentFunctionalityId = new bool[] {false} ;
         P002F3_A20SecFunctionalityDescription = new string[] {""} ;
         P002F3_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002F3_A15SecFunctionalityKey = new string[] {""} ;
         P002F3_A21SecFunctionalityType = new short[1] ;
         P002F3_A13SecFunctionalityId = new long[1] ;
         P002F4_A14SecParentFunctionalityId = new long[1] ;
         P002F4_n14SecParentFunctionalityId = new bool[] {false} ;
         P002F4_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002F4_A20SecFunctionalityDescription = new string[] {""} ;
         P002F4_A15SecFunctionalityKey = new string[] {""} ;
         P002F4_A21SecFunctionalityType = new short[1] ;
         P002F4_A13SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002F2_A14SecParentFunctionalityId, P002F2_n14SecParentFunctionalityId, P002F2_A15SecFunctionalityKey, P002F2_A23SecParentFunctionalityDescript, P002F2_A20SecFunctionalityDescription, P002F2_A21SecFunctionalityType, P002F2_A13SecFunctionalityId
               }
               , new Object[] {
               P002F3_A14SecParentFunctionalityId, P002F3_n14SecParentFunctionalityId, P002F3_A20SecFunctionalityDescription, P002F3_A23SecParentFunctionalityDescript, P002F3_A15SecFunctionalityKey, P002F3_A21SecFunctionalityType, P002F3_A13SecFunctionalityId
               }
               , new Object[] {
               P002F4_A14SecParentFunctionalityId, P002F4_n14SecParentFunctionalityId, P002F4_A23SecParentFunctionalityDescript, P002F4_A20SecFunctionalityDescription, P002F4_A15SecFunctionalityKey, P002F4_A21SecFunctionalityType, P002F4_A13SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV43MaxItems ;
      private short AV42PageIndex ;
      private short AV41SkipItems ;
      private short A21SecFunctionalityType ;
      private int AV46GXV1 ;
      private int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private long AV29count ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK2F2 ;
      private bool n14SecParentFunctionalityId ;
      private bool BRK2F4 ;
      private bool BRK2F6 ;
      private string AV23OptionsJson ;
      private string AV26OptionsDescJson ;
      private string AV28OptionIndexesJson ;
      private string AV39TFSecFunctionalityType_SelsJson ;
      private string AV19DDOName ;
      private string AV44SearchTxtParms ;
      private string AV18SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV45FilterFullText ;
      private string AV10TFSecFunctionalityKey ;
      private string AV11TFSecFunctionalityKey_Sel ;
      private string AV12TFSecFunctionalityDescription ;
      private string AV13TFSecFunctionalityDescription_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A23SecParentFunctionalityDescript ;
      private string AV21Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV38WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<short> AV40TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P002F2_A14SecParentFunctionalityId ;
      private bool[] P002F2_n14SecParentFunctionalityId ;
      private string[] P002F2_A15SecFunctionalityKey ;
      private string[] P002F2_A23SecParentFunctionalityDescript ;
      private string[] P002F2_A20SecFunctionalityDescription ;
      private short[] P002F2_A21SecFunctionalityType ;
      private long[] P002F2_A13SecFunctionalityId ;
      private long[] P002F3_A14SecParentFunctionalityId ;
      private bool[] P002F3_n14SecParentFunctionalityId ;
      private string[] P002F3_A20SecFunctionalityDescription ;
      private string[] P002F3_A23SecParentFunctionalityDescript ;
      private string[] P002F3_A15SecFunctionalityKey ;
      private short[] P002F3_A21SecFunctionalityType ;
      private long[] P002F3_A13SecFunctionalityId ;
      private long[] P002F4_A14SecParentFunctionalityId ;
      private bool[] P002F4_n14SecParentFunctionalityId ;
      private string[] P002F4_A23SecParentFunctionalityDescript ;
      private string[] P002F4_A20SecFunctionalityDescription ;
      private string[] P002F4_A15SecFunctionalityKey ;
      private short[] P002F4_A21SecFunctionalityType ;
      private long[] P002F4_A13SecFunctionalityId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secfunctionalitywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002F2( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A15SecFunctionalityKey ,
                                             string A20SecFunctionalityDescription ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecFunctionalityKey], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecFunctionalityKey]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P002F3( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A15SecFunctionalityKey ,
                                             string A20SecFunctionalityDescription ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecFunctionalityDescription], T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecFunctionalityDescription]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P002F4( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A15SecFunctionalityKey ,
                                             string A20SecFunctionalityDescription ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV48Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( StringUtil.StrCmp(AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[SecFunctionalityDescription]";
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
                     return conditional_P002F2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P002F3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P002F4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP002F2;
          prmP002F2 = new Object[] {
          new ParDef("@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002F3;
          prmP002F3 = new Object[] {
          new ParDef("@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002F4;
          prmP002F4 = new Object[] {
          new ParDef("@lV49Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV50Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV51Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV52Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV54Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV55Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002F4,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.secfunctionalitywwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class secfunctionalitywwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SecFunctionalityWWGetFilterData" )]
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
          if ( ! ProcessHeaders("wwpbaseobjects.secfunctionalitywwgetfilterdata") )
          {
             return  ;
          }
          secfunctionalitywwgetfilterdata worker = new secfunctionalitywwgetfilterdata(context);
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
