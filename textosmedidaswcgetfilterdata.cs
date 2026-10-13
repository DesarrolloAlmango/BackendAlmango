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
   public class textosmedidaswcgetfilterdata : GXProcedure
   {
      public textosmedidaswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textosmedidaswcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubrosMedidas", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("TextosMedidasWCGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosMedidasWCGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("TextosMedidasWCGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV15TFRubrosEstado_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV16TFRubrosEstado_Sels.FromJSonString(AV15TFRubrosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&TEXTOSID") == 0 )
            {
               AV40TextosId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV17SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV16TFRubrosEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV16TFRubrosEstado_Sels.Count ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              AV39FilterFullText ,
                                              AV40TextosId ,
                                              A150TextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         /* Using cursor P004Z2 */
         pr_default.execute(0, new Object[] {AV40TextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4Z2 = false;
            A150TextosId = P004Z2_A150TextosId[0];
            n150TextosId = P004Z2_n150TextosId[0];
            A122RubrosNombre = P004Z2_A122RubrosNombre[0];
            A123RubrosEstado = P004Z2_A123RubrosEstado[0];
            n123RubrosEstado = P004Z2_n123RubrosEstado[0];
            A121RubrosId = P004Z2_A121RubrosId[0];
            A137MedidasID = P004Z2_A137MedidasID[0];
            A122RubrosNombre = P004Z2_A122RubrosNombre[0];
            A123RubrosEstado = P004Z2_A123RubrosEstado[0];
            n123RubrosEstado = P004Z2_n123RubrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV39FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV39FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV39FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV39FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV39FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) ) )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P004Z2_A150TextosId[0] == A150TextosId ) && ( StringUtil.StrCmp(P004Z2_A122RubrosNombre[0], A122RubrosNombre) == 0 ) )
               {
                  BRK4Z2 = false;
                  A121RubrosId = P004Z2_A121RubrosId[0];
                  A137MedidasID = P004Z2_A137MedidasID[0];
                  AV27count = (long)(AV27count+1);
                  BRK4Z2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
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
            if ( ! BRK4Z2 )
            {
               BRK4Z2 = true;
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
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV15TFRubrosEstado_SelsJson = "";
         AV16TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         lV13TFRubrosNombre = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         P004Z2_A150TextosId = new long[1] ;
         P004Z2_n150TextosId = new bool[] {false} ;
         P004Z2_A122RubrosNombre = new string[] {""} ;
         P004Z2_A123RubrosEstado = new string[] {""} ;
         P004Z2_n123RubrosEstado = new bool[] {false} ;
         P004Z2_A121RubrosId = new short[1] ;
         P004Z2_A137MedidasID = new long[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textosmedidaswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004Z2_A150TextosId, P004Z2_n150TextosId, P004Z2_A122RubrosNombre, P004Z2_A123RubrosEstado, P004Z2_n123RubrosEstado, P004Z2_A121RubrosId, P004Z2_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short A121RubrosId ;
      private int AV41GXV1 ;
      private int AV16TFRubrosEstado_Sels_Count ;
      private long AV40TextosId ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private long AV27count ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string lV13TFRubrosNombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4Z2 ;
      private bool n150TextosId ;
      private bool n123RubrosEstado ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV15TFRubrosEstado_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
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
      private GxSimpleCollection<string> AV16TFRubrosEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P004Z2_A150TextosId ;
      private bool[] P004Z2_n150TextosId ;
      private string[] P004Z2_A122RubrosNombre ;
      private string[] P004Z2_A123RubrosEstado ;
      private bool[] P004Z2_n123RubrosEstado ;
      private short[] P004Z2_A121RubrosId ;
      private long[] P004Z2_A137MedidasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class textosmedidaswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Z2( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV16TFRubrosEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             int AV16TFRubrosEstado_Sels_Count ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             string AV39FilterFullText ,
                                             long AV40TextosId ,
                                             long A150TextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TextosId], T2.[RubrosNombre], T2.[RubrosEstado], T1.[RubrosId], T1.[MedidasID] FROM ([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId])";
         AddWhere(sWhereString, "(T1.[TextosId] = @AV40TextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( AV16TFRubrosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV16TFRubrosEstado_Sels, "T2.[RubrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TextosId], T2.[RubrosNombre]";
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
                     return conditional_P004Z2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
          Object[] prmP004Z2;
          prmP004Z2 = new Object[] {
          new ParDef("@AV40TextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.textosmedidaswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class textosmedidaswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TextosMedidasWCGetFilterData" )]
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
          if ( ! ProcessHeaders("textosmedidaswcgetfilterdata") )
          {
             return  ;
          }
          textosmedidaswcgetfilterdata worker = new textosmedidaswcgetfilterdata(context);
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
