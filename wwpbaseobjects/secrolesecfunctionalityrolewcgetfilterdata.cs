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
   public class secrolesecfunctionalityrolewcgetfilterdata : GXProcedure
   {
      public secrolesecfunctionalityrolewcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolesecfunctionalityrolewcgetfilterdata( IGxContext context )
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
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
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
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecRole", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV56MaxItems = 10;
            AV55PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV57SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? "" : StringUtil.Substring( AV57SearchTxtParms, 3, -1));
            AV54SkipItems = (short)(AV55PageIndex*AV56MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV51WWPContext) ;
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
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV19DDOName), "DDO_SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               /* Execute user subroutine: 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' */
               S131 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecRoleSecFunctionalityRoleWCGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV58FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV35SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV10TFSecFunctionalityKey = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV11TFSecFunctionalityKey_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV52TFSecFunctionalityType_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV53TFSecFunctionalityType_Sels.FromJSonString(AV52TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV15TFSecParentFunctionalityDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV16TFSecParentFunctionalityDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&SECROLEID") == 0 )
            {
               AV50SecRoleId = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECFUNCTIONALITYKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecFunctionalityKey = AV17SearchTxt;
         AV11TFSecFunctionalityKey_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV53TFSecFunctionalityType_Sels ,
                                              AV35SecFunctionalityType ,
                                              AV11TFSecFunctionalityKey_Sel ,
                                              AV10TFSecFunctionalityKey ,
                                              AV53TFSecFunctionalityType_Sels.Count ,
                                              AV16TFSecParentFunctionalityDescription_Sel ,
                                              AV15TFSecParentFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV58FilterFullText ,
                                              A20SecFunctionalityDescription ,
                                              AV50SecRoleId ,
                                              A16SecRoleId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV10TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV10TFSecFunctionalityKey), "%", "");
         lV15TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV15TFSecParentFunctionalityDescription), "%", "");
         /* Using cursor P002J2 */
         pr_default.execute(0, new Object[] {AV50SecRoleId, AV35SecFunctionalityType, lV10TFSecFunctionalityKey, AV11TFSecFunctionalityKey_Sel, lV15TFSecParentFunctionalityDescription, AV16TFSecParentFunctionalityDescription_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2J2 = false;
            A13SecFunctionalityId = P002J2_A13SecFunctionalityId[0];
            A14SecParentFunctionalityId = P002J2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002J2_n14SecParentFunctionalityId[0];
            A16SecRoleId = P002J2_A16SecRoleId[0];
            A15SecFunctionalityKey = P002J2_A15SecFunctionalityKey[0];
            A23SecParentFunctionalityDescript = P002J2_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002J2_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002J2_A21SecFunctionalityType[0];
            A14SecParentFunctionalityId = P002J2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002J2_n14SecParentFunctionalityId[0];
            A15SecFunctionalityKey = P002J2_A15SecFunctionalityKey[0];
            A20SecFunctionalityDescription = P002J2_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002J2_A21SecFunctionalityType[0];
            A23SecParentFunctionalityDescript = P002J2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P002J2_A16SecRoleId[0] == A16SecRoleId ) && ( StringUtil.StrCmp(P002J2_A15SecFunctionalityKey[0], A15SecFunctionalityKey) == 0 ) )
               {
                  BRK2J2 = false;
                  A13SecFunctionalityId = P002J2_A13SecFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2J2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV54SkipItems) )
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
                  AV54SkipItems = (short)(AV54SkipItems-1);
               }
            }
            if ( ! BRK2J2 )
            {
               BRK2J2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECPARENTFUNCTIONALITYDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFSecParentFunctionalityDescription = AV17SearchTxt;
         AV16TFSecParentFunctionalityDescription_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV53TFSecFunctionalityType_Sels ,
                                              AV35SecFunctionalityType ,
                                              AV11TFSecFunctionalityKey_Sel ,
                                              AV10TFSecFunctionalityKey ,
                                              AV53TFSecFunctionalityType_Sels.Count ,
                                              AV16TFSecParentFunctionalityDescription_Sel ,
                                              AV15TFSecParentFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV58FilterFullText ,
                                              A20SecFunctionalityDescription ,
                                              AV50SecRoleId ,
                                              A16SecRoleId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV10TFSecFunctionalityKey = StringUtil.Concat( StringUtil.RTrim( AV10TFSecFunctionalityKey), "%", "");
         lV15TFSecParentFunctionalityDescription = StringUtil.Concat( StringUtil.RTrim( AV15TFSecParentFunctionalityDescription), "%", "");
         /* Using cursor P002J3 */
         pr_default.execute(1, new Object[] {AV50SecRoleId, AV35SecFunctionalityType, lV10TFSecFunctionalityKey, AV11TFSecFunctionalityKey_Sel, lV15TFSecParentFunctionalityDescription, AV16TFSecParentFunctionalityDescription_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2J4 = false;
            A13SecFunctionalityId = P002J3_A13SecFunctionalityId[0];
            A14SecParentFunctionalityId = P002J3_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002J3_n14SecParentFunctionalityId[0];
            A16SecRoleId = P002J3_A16SecRoleId[0];
            A23SecParentFunctionalityDescript = P002J3_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002J3_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002J3_A21SecFunctionalityType[0];
            A15SecFunctionalityKey = P002J3_A15SecFunctionalityKey[0];
            A14SecParentFunctionalityId = P002J3_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002J3_n14SecParentFunctionalityId[0];
            A20SecFunctionalityDescription = P002J3_A20SecFunctionalityDescription[0];
            A21SecFunctionalityType = P002J3_A21SecFunctionalityType[0];
            A15SecFunctionalityKey = P002J3_A15SecFunctionalityKey[0];
            A23SecParentFunctionalityDescript = P002J3_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58FilterFullText) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV58FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P002J3_A16SecRoleId[0] == A16SecRoleId ) && ( StringUtil.StrCmp(P002J3_A23SecParentFunctionalityDescript[0], A23SecParentFunctionalityDescript) == 0 ) )
               {
                  BRK2J4 = false;
                  A13SecFunctionalityId = P002J3_A13SecFunctionalityId[0];
                  A14SecParentFunctionalityId = P002J3_A14SecParentFunctionalityId[0];
                  n14SecParentFunctionalityId = P002J3_n14SecParentFunctionalityId[0];
                  A14SecParentFunctionalityId = P002J3_A14SecParentFunctionalityId[0];
                  n14SecParentFunctionalityId = P002J3_n14SecParentFunctionalityId[0];
                  AV29count = (long)(AV29count+1);
                  BRK2J4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV54SkipItems) )
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
                  AV54SkipItems = (short)(AV54SkipItems-1);
               }
            }
            if ( ! BRK2J4 )
            {
               BRK2J4 = true;
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
         AV23OptionsJson = "";
         AV26OptionsDescJson = "";
         AV28OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV51WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV58FilterFullText = "";
         AV10TFSecFunctionalityKey = "";
         AV11TFSecFunctionalityKey_Sel = "";
         AV52TFSecFunctionalityType_SelsJson = "";
         AV53TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV15TFSecParentFunctionalityDescription = "";
         AV16TFSecParentFunctionalityDescription_Sel = "";
         lV58FilterFullText = "";
         lV10TFSecFunctionalityKey = "";
         lV15TFSecParentFunctionalityDescription = "";
         A15SecFunctionalityKey = "";
         A23SecParentFunctionalityDescript = "";
         A20SecFunctionalityDescription = "";
         P002J2_A13SecFunctionalityId = new long[1] ;
         P002J2_A14SecParentFunctionalityId = new long[1] ;
         P002J2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002J2_A16SecRoleId = new short[1] ;
         P002J2_A15SecFunctionalityKey = new string[] {""} ;
         P002J2_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002J2_A20SecFunctionalityDescription = new string[] {""} ;
         P002J2_A21SecFunctionalityType = new short[1] ;
         AV21Option = "";
         P002J3_A13SecFunctionalityId = new long[1] ;
         P002J3_A14SecParentFunctionalityId = new long[1] ;
         P002J3_n14SecParentFunctionalityId = new bool[] {false} ;
         P002J3_A16SecRoleId = new short[1] ;
         P002J3_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002J3_A20SecFunctionalityDescription = new string[] {""} ;
         P002J3_A21SecFunctionalityType = new short[1] ;
         P002J3_A15SecFunctionalityKey = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolesecfunctionalityrolewcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002J2_A13SecFunctionalityId, P002J2_A14SecParentFunctionalityId, P002J2_n14SecParentFunctionalityId, P002J2_A16SecRoleId, P002J2_A15SecFunctionalityKey, P002J2_A23SecParentFunctionalityDescript, P002J2_A20SecFunctionalityDescription, P002J2_A21SecFunctionalityType
               }
               , new Object[] {
               P002J3_A13SecFunctionalityId, P002J3_A14SecParentFunctionalityId, P002J3_n14SecParentFunctionalityId, P002J3_A16SecRoleId, P002J3_A23SecParentFunctionalityDescript, P002J3_A20SecFunctionalityDescription, P002J3_A21SecFunctionalityType, P002J3_A15SecFunctionalityKey
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV56MaxItems ;
      private short AV55PageIndex ;
      private short AV54SkipItems ;
      private short AV35SecFunctionalityType ;
      private short AV50SecRoleId ;
      private short A21SecFunctionalityType ;
      private short A16SecRoleId ;
      private int AV59GXV1 ;
      private int AV53TFSecFunctionalityType_Sels_Count ;
      private long A13SecFunctionalityId ;
      private long A14SecParentFunctionalityId ;
      private long AV29count ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK2J2 ;
      private bool n14SecParentFunctionalityId ;
      private bool BRK2J4 ;
      private string AV23OptionsJson ;
      private string AV26OptionsDescJson ;
      private string AV28OptionIndexesJson ;
      private string AV52TFSecFunctionalityType_SelsJson ;
      private string AV19DDOName ;
      private string AV57SearchTxtParms ;
      private string AV18SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV58FilterFullText ;
      private string AV10TFSecFunctionalityKey ;
      private string AV11TFSecFunctionalityKey_Sel ;
      private string AV15TFSecParentFunctionalityDescription ;
      private string AV16TFSecParentFunctionalityDescription_Sel ;
      private string lV58FilterFullText ;
      private string lV10TFSecFunctionalityKey ;
      private string lV15TFSecParentFunctionalityDescription ;
      private string A15SecFunctionalityKey ;
      private string A23SecParentFunctionalityDescript ;
      private string A20SecFunctionalityDescription ;
      private string AV21Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV51WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<short> AV53TFSecFunctionalityType_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P002J2_A13SecFunctionalityId ;
      private long[] P002J2_A14SecParentFunctionalityId ;
      private bool[] P002J2_n14SecParentFunctionalityId ;
      private short[] P002J2_A16SecRoleId ;
      private string[] P002J2_A15SecFunctionalityKey ;
      private string[] P002J2_A23SecParentFunctionalityDescript ;
      private string[] P002J2_A20SecFunctionalityDescription ;
      private short[] P002J2_A21SecFunctionalityType ;
      private long[] P002J3_A13SecFunctionalityId ;
      private long[] P002J3_A14SecParentFunctionalityId ;
      private bool[] P002J3_n14SecParentFunctionalityId ;
      private short[] P002J3_A16SecRoleId ;
      private string[] P002J3_A23SecParentFunctionalityDescript ;
      private string[] P002J3_A20SecFunctionalityDescription ;
      private short[] P002J3_A21SecFunctionalityType ;
      private string[] P002J3_A15SecFunctionalityKey ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secrolesecfunctionalityrolewcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002J2( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53TFSecFunctionalityType_Sels ,
                                             short AV35SecFunctionalityType ,
                                             string AV11TFSecFunctionalityKey_Sel ,
                                             string AV10TFSecFunctionalityKey ,
                                             int AV53TFSecFunctionalityType_Sels_Count ,
                                             string AV16TFSecParentFunctionalityDescription_Sel ,
                                             string AV15TFSecParentFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV58FilterFullText ,
                                             string A20SecFunctionalityDescription ,
                                             short AV50SecRoleId ,
                                             short A16SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecFunctionalityId], T2.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecRoleId], T2.[SecFunctionalityKey], T3.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T2.[SecFunctionalityDescription], T2.[SecFunctionalityType] FROM (([SecFunctionalityRole] T1 INNER JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecFunctionalityId]) LEFT JOIN [SecFunctionality] T3 ON T3.[SecFunctionalityId] = T2.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecRoleId] = @AV50SecRoleId)");
         if ( ! (0==AV35SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityType] = @AV35SecFunctionalityType)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityKey]) like UPPER(@lV10TFSecFunctionalityKey))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV11TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityKey] = @AV11TFSecFunctionalityKey_Sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[SecFunctionalityKey] = ''))");
         }
         if ( AV53TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53TFSecFunctionalityType_Sels, "T2.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[SecFunctionalityDescription]) like UPPER(@lV15TFSecParentFunctionalityDescription))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[SecFunctionalityDescription] = @AV16TFSecParentFunctionalityDescription_Sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecRoleId], T2.[SecFunctionalityKey]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P002J3( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV53TFSecFunctionalityType_Sels ,
                                             short AV35SecFunctionalityType ,
                                             string AV11TFSecFunctionalityKey_Sel ,
                                             string AV10TFSecFunctionalityKey ,
                                             int AV53TFSecFunctionalityType_Sels_Count ,
                                             string AV16TFSecParentFunctionalityDescription_Sel ,
                                             string AV15TFSecParentFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             string AV58FilterFullText ,
                                             string A20SecFunctionalityDescription ,
                                             short AV50SecRoleId ,
                                             short A16SecRoleId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecFunctionalityId], T2.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecRoleId], T3.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T2.[SecFunctionalityDescription], T2.[SecFunctionalityType], T2.[SecFunctionalityKey] FROM (([SecFunctionalityRole] T1 INNER JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecFunctionalityId]) LEFT JOIN [SecFunctionality] T3 ON T3.[SecFunctionalityId] = T2.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecRoleId] = @AV50SecRoleId)");
         if ( ! (0==AV35SecFunctionalityType) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityType] = @AV35SecFunctionalityType)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFSecFunctionalityKey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityKey]) like UPPER(@lV10TFSecFunctionalityKey))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFSecFunctionalityKey_Sel)) && ! ( StringUtil.StrCmp(AV11TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityKey] = @AV11TFSecFunctionalityKey_Sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFSecFunctionalityKey_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[SecFunctionalityKey] = ''))");
         }
         if ( AV53TFSecFunctionalityType_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53TFSecFunctionalityType_Sels, "T2.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSecParentFunctionalityDescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[SecFunctionalityDescription]) like UPPER(@lV15TFSecParentFunctionalityDescription))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSecParentFunctionalityDescription_Sel)) && ! ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[SecFunctionalityDescription] = @AV16TFSecParentFunctionalityDescription_Sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSecParentFunctionalityDescription_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecRoleId], T3.[SecFunctionalityDescription]";
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
                     return conditional_P002J2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
               case 1 :
                     return conditional_P002J3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP002J2;
          prmP002J2 = new Object[] {
          new ParDef("@AV50SecRoleId",GXType.Int16,4,0) ,
          new ParDef("@AV35SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("@lV10TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFSecFunctionalityKey_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV15TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("@AV16TFSecParentFunctionalityDescription_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002J3;
          prmP002J3 = new Object[] {
          new ParDef("@AV50SecRoleId",GXType.Int16,4,0) ,
          new ParDef("@AV35SecFunctionalityType",GXType.Int16,2,0) ,
          new ParDef("@lV10TFSecFunctionalityKey",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFSecFunctionalityKey_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV15TFSecParentFunctionalityDescription",GXType.VarChar,100,0) ,
          new ParDef("@AV16TFSecParentFunctionalityDescription_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.secrolesecfunctionalityrolewcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class secrolesecfunctionalityrolewcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SecRoleSecFunctionalityRoleWCGetFilterData" )]
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
          if ( ! ProcessHeaders("wwpbaseobjects.secrolesecfunctionalityrolewcgetfilterdata") )
          {
             return  ;
          }
          secrolesecfunctionalityrolewcgetfilterdata worker = new secrolesecfunctionalityrolewcgetfilterdata(context);
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
