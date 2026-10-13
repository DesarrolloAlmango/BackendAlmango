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
   public class estadoswwgetfilterdata : GXProcedure
   {
      public estadoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadoswwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV18MaxItems = 10;
            AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
            AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_ESTADOSTIPO") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSTIPOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_ESTADOSDESCRIP") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSDESCRIPOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("EstadosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("EstadosWWGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV11TFEstadosTipo = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV12TFEstadosTipo_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP") == 0 )
            {
               AV13TFEstadosDescrip = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP_SEL") == 0 )
            {
               AV14TFEstadosDescrip_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADESTADOSTIPOOPTIONS' Routine */
         returnInSub = false;
         AV11TFEstadosTipo = AV15SearchTxt;
         AV12TFEstadosTipo_Sel = "";
         AV40Estadoswwds_1_filterfulltext = AV37FilterFullText;
         AV41Estadoswwds_2_tfestadostipo = AV11TFEstadosTipo;
         AV42Estadoswwds_3_tfestadostipo_sel = AV12TFEstadosTipo_Sel;
         AV43Estadoswwds_4_tfestadosdescrip = AV13TFEstadosDescrip;
         AV44Estadoswwds_5_tfestadosdescrip_sel = AV14TFEstadosDescrip_Sel;
         GXPagingFrom2 = AV16SkipItems;
         GXPagingTo2 = AV18MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Estadoswwds_1_filterfulltext ,
                                              AV42Estadoswwds_3_tfestadostipo_sel ,
                                              AV41Estadoswwds_2_tfestadostipo ,
                                              AV44Estadoswwds_5_tfestadosdescrip_sel ,
                                              AV43Estadoswwds_4_tfestadosdescrip ,
                                              A107EstadosTipo ,
                                              A158EstadosDescrip } ,
                                              new int[]{
                                              }
         });
         lV40Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext), "%", "");
         lV40Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext), "%", "");
         lV41Estadoswwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV41Estadoswwds_2_tfestadostipo), 3, "%");
         lV43Estadoswwds_4_tfestadosdescrip = StringUtil.PadR( StringUtil.RTrim( AV43Estadoswwds_4_tfestadosdescrip), 80, "%");
         /* Using cursor P00C42 */
         pr_default.execute(0, new Object[] {lV40Estadoswwds_1_filterfulltext, lV40Estadoswwds_1_filterfulltext, lV41Estadoswwds_2_tfestadostipo, AV42Estadoswwds_3_tfestadostipo_sel, lV43Estadoswwds_4_tfestadosdescrip, AV44Estadoswwds_5_tfestadosdescrip_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158EstadosDescrip = P00C42_A158EstadosDescrip[0];
            A107EstadosTipo = P00C42_A107EstadosTipo[0];
            AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) ? "<#Empty#>" : A107EstadosTipo);
            AV21Options.Add(AV20Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADESTADOSDESCRIPOPTIONS' Routine */
         returnInSub = false;
         AV13TFEstadosDescrip = AV15SearchTxt;
         AV14TFEstadosDescrip_Sel = "";
         AV40Estadoswwds_1_filterfulltext = AV37FilterFullText;
         AV41Estadoswwds_2_tfestadostipo = AV11TFEstadosTipo;
         AV42Estadoswwds_3_tfestadostipo_sel = AV12TFEstadosTipo_Sel;
         AV43Estadoswwds_4_tfestadosdescrip = AV13TFEstadosDescrip;
         AV44Estadoswwds_5_tfestadosdescrip_sel = AV14TFEstadosDescrip_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV40Estadoswwds_1_filterfulltext ,
                                              AV42Estadoswwds_3_tfestadostipo_sel ,
                                              AV41Estadoswwds_2_tfestadostipo ,
                                              AV44Estadoswwds_5_tfestadosdescrip_sel ,
                                              AV43Estadoswwds_4_tfestadosdescrip ,
                                              A107EstadosTipo ,
                                              A158EstadosDescrip } ,
                                              new int[]{
                                              }
         });
         lV40Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext), "%", "");
         lV40Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext), "%", "");
         lV41Estadoswwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV41Estadoswwds_2_tfestadostipo), 3, "%");
         lV43Estadoswwds_4_tfestadosdescrip = StringUtil.PadR( StringUtil.RTrim( AV43Estadoswwds_4_tfestadosdescrip), 80, "%");
         /* Using cursor P00C43 */
         pr_default.execute(1, new Object[] {lV40Estadoswwds_1_filterfulltext, lV40Estadoswwds_1_filterfulltext, lV41Estadoswwds_2_tfestadostipo, AV42Estadoswwds_3_tfestadostipo_sel, lV43Estadoswwds_4_tfestadosdescrip, AV44Estadoswwds_5_tfestadosdescrip_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC43 = false;
            A158EstadosDescrip = P00C43_A158EstadosDescrip[0];
            A107EstadosTipo = P00C43_A107EstadosTipo[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00C43_A158EstadosDescrip[0], A158EstadosDescrip) == 0 ) )
            {
               BRKC43 = false;
               A107EstadosTipo = P00C43_A107EstadosTipo[0];
               AV25count = (long)(AV25count+1);
               BRKC43 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A158EstadosDescrip)) ? "<#Empty#>" : A158EstadosDescrip);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRKC43 )
            {
               BRKC43 = true;
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFEstadosTipo = "";
         AV12TFEstadosTipo_Sel = "";
         AV13TFEstadosDescrip = "";
         AV14TFEstadosDescrip_Sel = "";
         AV40Estadoswwds_1_filterfulltext = "";
         AV41Estadoswwds_2_tfestadostipo = "";
         AV42Estadoswwds_3_tfestadostipo_sel = "";
         AV43Estadoswwds_4_tfestadosdescrip = "";
         AV44Estadoswwds_5_tfestadosdescrip_sel = "";
         lV40Estadoswwds_1_filterfulltext = "";
         lV41Estadoswwds_2_tfestadostipo = "";
         lV43Estadoswwds_4_tfestadosdescrip = "";
         A107EstadosTipo = "";
         A158EstadosDescrip = "";
         P00C42_A158EstadosDescrip = new string[] {""} ;
         P00C42_A107EstadosTipo = new string[] {""} ;
         AV20Option = "";
         P00C43_A158EstadosDescrip = new string[] {""} ;
         P00C43_A107EstadosTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C42_A158EstadosDescrip, P00C42_A107EstadosTipo
               }
               , new Object[] {
               P00C43_A158EstadosDescrip, P00C43_A107EstadosTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV38GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV25count ;
      private string AV11TFEstadosTipo ;
      private string AV12TFEstadosTipo_Sel ;
      private string AV13TFEstadosDescrip ;
      private string AV14TFEstadosDescrip_Sel ;
      private string AV41Estadoswwds_2_tfestadostipo ;
      private string AV42Estadoswwds_3_tfestadostipo_sel ;
      private string AV43Estadoswwds_4_tfestadosdescrip ;
      private string AV44Estadoswwds_5_tfestadosdescrip_sel ;
      private string lV41Estadoswwds_2_tfestadostipo ;
      private string lV43Estadoswwds_4_tfestadosdescrip ;
      private string A107EstadosTipo ;
      private string A158EstadosDescrip ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKC43 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV40Estadoswwds_1_filterfulltext ;
      private string lV40Estadoswwds_1_filterfulltext ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00C42_A158EstadosDescrip ;
      private string[] P00C42_A107EstadosTipo ;
      private string[] P00C43_A158EstadosDescrip ;
      private string[] P00C43_A107EstadosTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class estadoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C42( IGxContext context ,
                                             string AV40Estadoswwds_1_filterfulltext ,
                                             string AV42Estadoswwds_3_tfestadostipo_sel ,
                                             string AV41Estadoswwds_2_tfestadostipo ,
                                             string AV44Estadoswwds_5_tfestadosdescrip_sel ,
                                             string AV43Estadoswwds_4_tfestadosdescrip ,
                                             string A107EstadosTipo ,
                                             string A158EstadosDescrip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS [EstadosDescrip], [EstadosTipo] FROM ( SELECT TOP(100) PERCENT [EstadosDescrip], [EstadosTipo]";
         sFromString = " FROM [Estados]";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY [EstadosTipo]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV40Estadoswwds_1_filterfulltext)) or ( UPPER([EstadosDescrip]) like '%' + UPPER(@lV40Estadoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Estadoswwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Estadoswwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV41Estadoswwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Estadoswwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV42Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV42Estadoswwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Estadoswwds_5_tfestadosdescrip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Estadoswwds_4_tfestadosdescrip)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosDescrip]) like UPPER(@lV43Estadoswwds_4_tfestadosdescrip))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Estadoswwds_5_tfestadosdescrip_sel)) && ! ( StringUtil.StrCmp(AV44Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosDescrip] = @AV44Estadoswwds_5_tfestadosdescrip_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosDescrip] = ''))");
         }
         sOrderString += " ORDER BY [EstadosTipo]";
         sOrderStringT = " ORDER BY [EstadosTipo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00C43( IGxContext context ,
                                             string AV40Estadoswwds_1_filterfulltext ,
                                             string AV42Estadoswwds_3_tfestadostipo_sel ,
                                             string AV41Estadoswwds_2_tfestadostipo ,
                                             string AV44Estadoswwds_5_tfestadosdescrip_sel ,
                                             string AV43Estadoswwds_4_tfestadosdescrip ,
                                             string A107EstadosTipo ,
                                             string A158EstadosDescrip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [EstadosDescrip], [EstadosTipo] FROM [Estados]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Estadoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV40Estadoswwds_1_filterfulltext)) or ( UPPER([EstadosDescrip]) like '%' + UPPER(@lV40Estadoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Estadoswwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Estadoswwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV41Estadoswwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Estadoswwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV42Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV42Estadoswwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Estadoswwds_5_tfestadosdescrip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Estadoswwds_4_tfestadosdescrip)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosDescrip]) like UPPER(@lV43Estadoswwds_4_tfestadosdescrip))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Estadoswwds_5_tfestadosdescrip_sel)) && ! ( StringUtil.StrCmp(AV44Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosDescrip] = @AV44Estadoswwds_5_tfestadosdescrip_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosDescrip] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EstadosDescrip]";
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
                     return conditional_P00C42(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P00C43(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00C42;
          prmP00C42 = new Object[] {
          new ParDef("@lV40Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV40Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV41Estadoswwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV42Estadoswwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@lV43Estadoswwds_4_tfestadosdescrip",GXType.Char,80,0) ,
          new ParDef("@AV44Estadoswwds_5_tfestadosdescrip_sel",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00C43;
          prmP00C43 = new Object[] {
          new ParDef("@lV40Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV40Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV41Estadoswwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV42Estadoswwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@lV43Estadoswwds_4_tfestadosdescrip",GXType.Char,80,0) ,
          new ParDef("@AV44Estadoswwds_5_tfestadosdescrip_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C42,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C43,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.estadoswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class estadoswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "EstadosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("estadoswwgetfilterdata") )
          {
             return  ;
          }
          estadoswwgetfilterdata worker = new estadoswwgetfilterdata(context);
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
