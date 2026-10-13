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
   public class tipocuentawwgetfilterdata : GXProcedure
   {
      public tipocuentawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipocuentawwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTipoCuenta", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TIPOCUENTANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADTIPOCUENTANOMBREOPTIONS' */
               S121 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("TipoCuentaWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoCuentaWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("TipoCuentaWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV11TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV13TFTipoCuentaNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV14TFTipoCuentaNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTACONCEPTO_SEL") == 0 )
            {
               AV15TFTipoCuentaConcepto_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV16TFTipoCuentaConcepto_Sels.FromJSonString(AV15TFTipoCuentaConcepto_SelsJson, null);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOCUENTANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFTipoCuentaNombre = AV17SearchTxt;
         AV14TFTipoCuentaNombre_Sel = "";
         AV42Tipocuentawwds_1_filterfulltext = AV39FilterFullText;
         AV43Tipocuentawwds_2_tftipocuentaid = AV11TFTipoCuentaId;
         AV44Tipocuentawwds_3_tftipocuentaid_to = AV12TFTipoCuentaId_To;
         AV45Tipocuentawwds_4_tftipocuentanombre = AV13TFTipoCuentaNombre;
         AV46Tipocuentawwds_5_tftipocuentanombre_sel = AV14TFTipoCuentaNombre_Sel;
         AV47Tipocuentawwds_6_tftipocuentaconcepto_sels = AV16TFTipoCuentaConcepto_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A636TipoCuentaConcepto ,
                                              AV47Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                              AV43Tipocuentawwds_2_tftipocuentaid ,
                                              AV44Tipocuentawwds_3_tftipocuentaid_to ,
                                              AV46Tipocuentawwds_5_tftipocuentanombre_sel ,
                                              AV45Tipocuentawwds_4_tftipocuentanombre ,
                                              AV47Tipocuentawwds_6_tftipocuentaconcepto_sels.Count ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              AV42Tipocuentawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV45Tipocuentawwds_4_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV45Tipocuentawwds_4_tftipocuentanombre), 120, "%");
         /* Using cursor P00DC2 */
         pr_default.execute(0, new Object[] {AV43Tipocuentawwds_2_tftipocuentaid, AV44Tipocuentawwds_3_tftipocuentaid_to, lV45Tipocuentawwds_4_tftipocuentanombre, AV46Tipocuentawwds_5_tftipocuentanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDC2 = false;
            A484TipoCuentaNombre = P00DC2_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00DC2_A483TipoCuentaId[0];
            A636TipoCuentaConcepto = P00DC2_A636TipoCuentaConcepto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Tipocuentawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV42Tipocuentawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV42Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "saldo por cuentas", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "SAL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usada en centro costo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "COS") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV42Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "OTR") == 0 ) ) ) )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DC2_A484TipoCuentaNombre[0], A484TipoCuentaNombre) == 0 ) )
               {
                  BRKDC2 = false;
                  A483TipoCuentaId = P00DC2_A483TipoCuentaId[0];
                  AV27count = (long)(AV27count+1);
                  BRKDC2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A484TipoCuentaNombre)) ? "<#Empty#>" : A484TipoCuentaNombre);
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
            }
            if ( ! BRKDC2 )
            {
               BRKDC2 = true;
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
         AV13TFTipoCuentaNombre = "";
         AV14TFTipoCuentaNombre_Sel = "";
         AV15TFTipoCuentaConcepto_SelsJson = "";
         AV16TFTipoCuentaConcepto_Sels = new GxSimpleCollection<string>();
         AV42Tipocuentawwds_1_filterfulltext = "";
         AV45Tipocuentawwds_4_tftipocuentanombre = "";
         AV46Tipocuentawwds_5_tftipocuentanombre_sel = "";
         AV47Tipocuentawwds_6_tftipocuentaconcepto_sels = new GxSimpleCollection<string>();
         lV45Tipocuentawwds_4_tftipocuentanombre = "";
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         P00DC2_A484TipoCuentaNombre = new string[] {""} ;
         P00DC2_A483TipoCuentaId = new long[1] ;
         P00DC2_A636TipoCuentaConcepto = new string[] {""} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipocuentawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DC2_A484TipoCuentaNombre, P00DC2_A483TipoCuentaId, P00DC2_A636TipoCuentaConcepto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV40GXV1 ;
      private int AV47Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ;
      private long AV11TFTipoCuentaId ;
      private long AV12TFTipoCuentaId_To ;
      private long AV43Tipocuentawwds_2_tftipocuentaid ;
      private long AV44Tipocuentawwds_3_tftipocuentaid_to ;
      private long A483TipoCuentaId ;
      private long AV27count ;
      private string AV13TFTipoCuentaNombre ;
      private string AV14TFTipoCuentaNombre_Sel ;
      private string AV45Tipocuentawwds_4_tftipocuentanombre ;
      private string AV46Tipocuentawwds_5_tftipocuentanombre_sel ;
      private string lV45Tipocuentawwds_4_tftipocuentanombre ;
      private string A636TipoCuentaConcepto ;
      private string A484TipoCuentaNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKDC2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV15TFTipoCuentaConcepto_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV42Tipocuentawwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV16TFTipoCuentaConcepto_Sels ;
      private GxSimpleCollection<string> AV47Tipocuentawwds_6_tftipocuentaconcepto_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DC2_A484TipoCuentaNombre ;
      private long[] P00DC2_A483TipoCuentaId ;
      private string[] P00DC2_A636TipoCuentaConcepto ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class tipocuentawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DC2( IGxContext context ,
                                             string A636TipoCuentaConcepto ,
                                             GxSimpleCollection<string> AV47Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                             long AV43Tipocuentawwds_2_tftipocuentaid ,
                                             long AV44Tipocuentawwds_3_tftipocuentaid_to ,
                                             string AV46Tipocuentawwds_5_tftipocuentanombre_sel ,
                                             string AV45Tipocuentawwds_4_tftipocuentanombre ,
                                             int AV47Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             string AV42Tipocuentawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TipoCuentaNombre], [TipoCuentaId], [TipoCuentaConcepto] FROM [TipoCuenta]";
         if ( ! (0==AV43Tipocuentawwds_2_tftipocuentaid) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] >= @AV43Tipocuentawwds_2_tftipocuentaid)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV44Tipocuentawwds_3_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] <= @AV44Tipocuentawwds_3_tftipocuentaid_to)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Tipocuentawwds_5_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Tipocuentawwds_4_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TipoCuentaNombre]) like UPPER(@lV45Tipocuentawwds_4_tftipocuentanombre))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Tipocuentawwds_5_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV46Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TipoCuentaNombre] = @AV46Tipocuentawwds_5_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV46Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TipoCuentaNombre] = ''))");
         }
         if ( AV47Tipocuentawwds_6_tftipocuentaconcepto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV47Tipocuentawwds_6_tftipocuentaconcepto_sels, "[TipoCuentaConcepto] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipoCuentaNombre]";
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
                     return conditional_P00DC2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP00DC2;
          prmP00DC2 = new Object[] {
          new ParDef("@AV43Tipocuentawwds_2_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV44Tipocuentawwds_3_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV45Tipocuentawwds_4_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV46Tipocuentawwds_5_tftipocuentanombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DC2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.tipocuentawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class tipocuentawwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TipoCuentaWWGetFilterData" )]
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
          if ( ! ProcessHeaders("tipocuentawwgetfilterdata") )
          {
             return  ;
          }
          tipocuentawwgetfilterdata worker = new tipocuentawwgetfilterdata(context);
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
