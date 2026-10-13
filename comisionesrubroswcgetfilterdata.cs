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
   public class comisionesrubroswcgetfilterdata : GXProcedure
   {
      public comisionesrubroswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesrubroswcgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV21MaxItems = 10;
            AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
            AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_COMISIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMISIONESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("ComisionesRubrosWCGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesRubrosWCGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ComisionesRubrosWCGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV11TFComisionesTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV12TFComisionesTipo_Sels.FromJSonString(AV11TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV13TFComisionesNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV14TFComisionesNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV15TFComisionesDefault = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV16TFComisionesDefault_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESGLOBAL_SEL") == 0 )
            {
               AV17TFComisionesGlobal_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&COMISIONESID") == 0 )
            {
               AV41ComisionesID = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMISIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFComisionesNombre = AV18SearchTxt;
         AV14TFComisionesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV12TFComisionesTipo_Sels ,
                                              AV12TFComisionesTipo_Sels.Count ,
                                              AV14TFComisionesNombre_Sel ,
                                              AV13TFComisionesNombre ,
                                              AV15TFComisionesDefault ,
                                              AV16TFComisionesDefault_To ,
                                              AV17TFComisionesGlobal_Sel ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              A520ComisionesGlobal ,
                                              AV40FilterFullText ,
                                              AV41ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFComisionesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFComisionesNombre), 80, "%");
         /* Using cursor P006H2 */
         pr_default.execute(0, new Object[] {AV41ComisionesID, lV13TFComisionesNombre, AV14TFComisionesNombre_Sel, AV15TFComisionesDefault, AV16TFComisionesDefault_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6H2 = false;
            A503ComisionesID = P006H2_A503ComisionesID[0];
            A504ComisionesNombre = P006H2_A504ComisionesNombre[0];
            A520ComisionesGlobal = P006H2_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006H2_n520ComisionesGlobal[0];
            A506ComisionesDefault = P006H2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006H2_n506ComisionesDefault[0];
            A505ComisionesTipo = P006H2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40FilterFullText)) || ( ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV40FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV40FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "zona", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV40FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV40FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV40FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               AV28count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P006H2_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006H2_A504ComisionesNombre[0], A504ComisionesNombre) == 0 ) )
               {
                  BRK6H2 = false;
                  AV28count = (long)(AV28count+1);
                  BRK6H2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV19SkipItems) )
               {
                  AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A504ComisionesNombre)) ? "<#Empty#>" : A504ComisionesNombre);
                  AV24Options.Add(AV23Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV24Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV19SkipItems = (short)(AV19SkipItems-1);
               }
            }
            if ( ! BRK6H2 )
            {
               BRK6H2 = true;
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV11TFComisionesTipo_SelsJson = "";
         AV12TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV13TFComisionesNombre = "";
         AV14TFComisionesNombre_Sel = "";
         lV40FilterFullText = "";
         lV13TFComisionesNombre = "";
         A505ComisionesTipo = "";
         A504ComisionesNombre = "";
         P006H2_A503ComisionesID = new long[1] ;
         P006H2_A504ComisionesNombre = new string[] {""} ;
         P006H2_A520ComisionesGlobal = new bool[] {false} ;
         P006H2_n520ComisionesGlobal = new bool[] {false} ;
         P006H2_A506ComisionesDefault = new decimal[1] ;
         P006H2_n506ComisionesDefault = new bool[] {false} ;
         P006H2_A505ComisionesTipo = new string[] {""} ;
         AV23Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesrubroswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006H2_A503ComisionesID, P006H2_A504ComisionesNombre, P006H2_A520ComisionesGlobal, P006H2_n520ComisionesGlobal, P006H2_A506ComisionesDefault, P006H2_n506ComisionesDefault, P006H2_A505ComisionesTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV17TFComisionesGlobal_Sel ;
      private int AV42GXV1 ;
      private int AV12TFComisionesTipo_Sels_Count ;
      private long AV41ComisionesID ;
      private long A503ComisionesID ;
      private long AV28count ;
      private decimal AV15TFComisionesDefault ;
      private decimal AV16TFComisionesDefault_To ;
      private decimal A506ComisionesDefault ;
      private string AV13TFComisionesNombre ;
      private string AV14TFComisionesNombre_Sel ;
      private string lV13TFComisionesNombre ;
      private string A505ComisionesTipo ;
      private string A504ComisionesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool A520ComisionesGlobal ;
      private bool BRK6H2 ;
      private bool n520ComisionesGlobal ;
      private bool n506ComisionesDefault ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV11TFComisionesTipo_SelsJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string lV40FilterFullText ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GxSimpleCollection<string> AV12TFComisionesTipo_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P006H2_A503ComisionesID ;
      private string[] P006H2_A504ComisionesNombre ;
      private bool[] P006H2_A520ComisionesGlobal ;
      private bool[] P006H2_n520ComisionesGlobal ;
      private decimal[] P006H2_A506ComisionesDefault ;
      private bool[] P006H2_n506ComisionesDefault ;
      private string[] P006H2_A505ComisionesTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisionesrubroswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV12TFComisionesTipo_Sels ,
                                             int AV12TFComisionesTipo_Sels_Count ,
                                             string AV14TFComisionesNombre_Sel ,
                                             string AV13TFComisionesNombre ,
                                             decimal AV15TFComisionesDefault ,
                                             decimal AV16TFComisionesDefault_To ,
                                             short AV17TFComisionesGlobal_Sel ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             bool A520ComisionesGlobal ,
                                             string AV40FilterFullText ,
                                             long AV41ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesID], [ComisionesNombre], [ComisionesGlobal], [ComisionesDefault], [ComisionesTipo] FROM [Comisiones]";
         AddWhere(sWhereString, "([ComisionesID] = @AV41ComisionesID)");
         if ( AV12TFComisionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV12TFComisionesTipo_Sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFComisionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFComisionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV13TFComisionesNombre))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFComisionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFComisionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV14TFComisionesNombre_Sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFComisionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFComisionesDefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV15TFComisionesDefault)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFComisionesDefault_To) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV16TFComisionesDefault_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV17TFComisionesGlobal_Sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV17TFComisionesGlobal_Sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ComisionesID], [ComisionesNombre]";
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
                     return conditional_P006H2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] );
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
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("@AV41ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFComisionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFComisionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV15TFComisionesDefault",GXType.Decimal,6,2) ,
          new ParDef("@AV16TFComisionesDefault_To",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisionesrubroswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisionesrubroswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesRubrosWCGetFilterData" )]
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
          if ( ! ProcessHeaders("comisionesrubroswcgetfilterdata") )
          {
             return  ;
          }
          comisionesrubroswcgetfilterdata worker = new comisionesrubroswcgetfilterdata(context);
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
