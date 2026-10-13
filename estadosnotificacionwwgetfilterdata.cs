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
   public class estadosnotificacionwwgetfilterdata : GXProcedure
   {
      public estadosnotificacionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacionwwgetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV23MaxItems = 10;
            AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
            AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_ESTADOSTIPO") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSTIPOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_ESTADOSGENERICOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSGENERICOSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("EstadosNotificacionWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosNotificacionWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("EstadosNotificacionWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV11TFEstadosTipo = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV12TFEstadosTipo_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSID") == 0 )
            {
               AV13TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV15TFEstadosGenericosNombre = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV16TFEstadosGenericosNombre_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONCLIENTE_SEL") == 0 )
            {
               AV17TFEstadosNotificacionCliente_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONPROFESIONAL_SEL") == 0 )
            {
               AV18TFEstadosNotificacionProfesional_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONOPERADOR_SEL") == 0 )
            {
               AV19TFEstadosNotificacionOperador_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADESTADOSTIPOOPTIONS' Routine */
         returnInSub = false;
         AV11TFEstadosTipo = AV20SearchTxt;
         AV12TFEstadosTipo_Sel = "";
         AV45Estadosnotificacionwwds_1_filterfulltext = AV42FilterFullText;
         AV46Estadosnotificacionwwds_2_tfestadostipo = AV11TFEstadosTipo;
         AV47Estadosnotificacionwwds_3_tfestadostipo_sel = AV12TFEstadosTipo_Sel;
         AV48Estadosnotificacionwwds_4_tfestadosgenericosid = AV13TFEstadosGenericosId;
         AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV14TFEstadosGenericosId_To;
         AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV15TFEstadosGenericosNombre;
         AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV16TFEstadosGenericosNombre_Sel;
         AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV17TFEstadosNotificacionCliente_Sel;
         AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV18TFEstadosNotificacionProfesional_Sel;
         AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV19TFEstadosNotificacionOperador_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Estadosnotificacionwwds_1_filterfulltext ,
                                              AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                              AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                              AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                              AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                              AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                              AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                              AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                              AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                              AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV46Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
         lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00C72 */
         pr_default.execute(0, new Object[] {lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV46Estadosnotificacionwwds_2_tfestadostipo, AV47Estadosnotificacionwwds_3_tfestadostipo_sel, AV48Estadosnotificacionwwds_4_tfestadosgenericosid, AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKC72 = false;
            A107EstadosTipo = P00C72_A107EstadosTipo[0];
            A265EstadosNotificacionOperador = P00C72_A265EstadosNotificacionOperador[0];
            A264EstadosNotificacionProfesional = P00C72_A264EstadosNotificacionProfesional[0];
            A263EstadosNotificacionCliente = P00C72_A263EstadosNotificacionCliente[0];
            A109EstadosGenericosNombre = P00C72_A109EstadosGenericosNombre[0];
            A108EstadosGenericosId = P00C72_A108EstadosGenericosId[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00C72_A107EstadosTipo[0], A107EstadosTipo) == 0 ) )
            {
               BRKC72 = false;
               A108EstadosGenericosId = P00C72_A108EstadosGenericosId[0];
               AV30count = (long)(AV30count+1);
               BRKC72 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) ? "<#Empty#>" : A107EstadosTipo);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRKC72 )
            {
               BRKC72 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADESTADOSGENERICOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFEstadosGenericosNombre = AV20SearchTxt;
         AV16TFEstadosGenericosNombre_Sel = "";
         AV45Estadosnotificacionwwds_1_filterfulltext = AV42FilterFullText;
         AV46Estadosnotificacionwwds_2_tfestadostipo = AV11TFEstadosTipo;
         AV47Estadosnotificacionwwds_3_tfestadostipo_sel = AV12TFEstadosTipo_Sel;
         AV48Estadosnotificacionwwds_4_tfestadosgenericosid = AV13TFEstadosGenericosId;
         AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV14TFEstadosGenericosId_To;
         AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV15TFEstadosGenericosNombre;
         AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV16TFEstadosGenericosNombre_Sel;
         AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV17TFEstadosNotificacionCliente_Sel;
         AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV18TFEstadosNotificacionProfesional_Sel;
         AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV19TFEstadosNotificacionOperador_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV45Estadosnotificacionwwds_1_filterfulltext ,
                                              AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                              AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                              AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                              AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                              AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                              AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                              AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                              AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                              AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV45Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV46Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
         lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00C73 */
         pr_default.execute(1, new Object[] {lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV45Estadosnotificacionwwds_1_filterfulltext, lV46Estadosnotificacionwwds_2_tfestadostipo, AV47Estadosnotificacionwwds_3_tfestadostipo_sel, AV48Estadosnotificacionwwds_4_tfestadosgenericosid, AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKC74 = false;
            A109EstadosGenericosNombre = P00C73_A109EstadosGenericosNombre[0];
            A265EstadosNotificacionOperador = P00C73_A265EstadosNotificacionOperador[0];
            A264EstadosNotificacionProfesional = P00C73_A264EstadosNotificacionProfesional[0];
            A263EstadosNotificacionCliente = P00C73_A263EstadosNotificacionCliente[0];
            A108EstadosGenericosId = P00C73_A108EstadosGenericosId[0];
            A107EstadosTipo = P00C73_A107EstadosTipo[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00C73_A109EstadosGenericosNombre[0], A109EstadosGenericosNombre) == 0 ) )
            {
               BRKC74 = false;
               A108EstadosGenericosId = P00C73_A108EstadosGenericosId[0];
               A107EstadosTipo = P00C73_A107EstadosTipo[0];
               AV30count = (long)(AV30count+1);
               BRKC74 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EstadosGenericosNombre)) ? "<#Empty#>" : A109EstadosGenericosNombre);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRKC74 )
            {
               BRKC74 = true;
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42FilterFullText = "";
         AV11TFEstadosTipo = "";
         AV12TFEstadosTipo_Sel = "";
         AV15TFEstadosGenericosNombre = "";
         AV16TFEstadosGenericosNombre_Sel = "";
         AV17TFEstadosNotificacionCliente_Sel = "";
         AV18TFEstadosNotificacionProfesional_Sel = "";
         AV19TFEstadosNotificacionOperador_Sel = "";
         AV45Estadosnotificacionwwds_1_filterfulltext = "";
         AV46Estadosnotificacionwwds_2_tfestadostipo = "";
         AV47Estadosnotificacionwwds_3_tfestadostipo_sel = "";
         AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = "";
         AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = "";
         AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = "";
         AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = "";
         lV45Estadosnotificacionwwds_1_filterfulltext = "";
         lV46Estadosnotificacionwwds_2_tfestadostipo = "";
         lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         P00C72_A107EstadosTipo = new string[] {""} ;
         P00C72_A265EstadosNotificacionOperador = new string[] {""} ;
         P00C72_A264EstadosNotificacionProfesional = new string[] {""} ;
         P00C72_A263EstadosNotificacionCliente = new string[] {""} ;
         P00C72_A109EstadosGenericosNombre = new string[] {""} ;
         P00C72_A108EstadosGenericosId = new int[1] ;
         AV25Option = "";
         P00C73_A109EstadosGenericosNombre = new string[] {""} ;
         P00C73_A265EstadosNotificacionOperador = new string[] {""} ;
         P00C73_A264EstadosNotificacionProfesional = new string[] {""} ;
         P00C73_A263EstadosNotificacionCliente = new string[] {""} ;
         P00C73_A108EstadosGenericosId = new int[1] ;
         P00C73_A107EstadosTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00C72_A107EstadosTipo, P00C72_A265EstadosNotificacionOperador, P00C72_A264EstadosNotificacionProfesional, P00C72_A263EstadosNotificacionCliente, P00C72_A109EstadosGenericosNombre, P00C72_A108EstadosGenericosId
               }
               , new Object[] {
               P00C73_A109EstadosGenericosNombre, P00C73_A265EstadosNotificacionOperador, P00C73_A264EstadosNotificacionProfesional, P00C73_A263EstadosNotificacionCliente, P00C73_A108EstadosGenericosId, P00C73_A107EstadosTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV43GXV1 ;
      private int AV13TFEstadosGenericosId ;
      private int AV14TFEstadosGenericosId_To ;
      private int AV48Estadosnotificacionwwds_4_tfestadosgenericosid ;
      private int AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ;
      private int A108EstadosGenericosId ;
      private long AV30count ;
      private string AV11TFEstadosTipo ;
      private string AV12TFEstadosTipo_Sel ;
      private string AV15TFEstadosGenericosNombre ;
      private string AV16TFEstadosGenericosNombre_Sel ;
      private string AV17TFEstadosNotificacionCliente_Sel ;
      private string AV18TFEstadosNotificacionProfesional_Sel ;
      private string AV19TFEstadosNotificacionOperador_Sel ;
      private string AV46Estadosnotificacionwwds_2_tfestadostipo ;
      private string AV47Estadosnotificacionwwds_3_tfestadostipo_sel ;
      private string AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ;
      private string AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ;
      private string AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ;
      private string AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ;
      private string lV46Estadosnotificacionwwds_2_tfestadostipo ;
      private string lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string A107EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKC72 ;
      private bool BRKC74 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV42FilterFullText ;
      private string AV45Estadosnotificacionwwds_1_filterfulltext ;
      private string lV45Estadosnotificacionwwds_1_filterfulltext ;
      private string AV25Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00C72_A107EstadosTipo ;
      private string[] P00C72_A265EstadosNotificacionOperador ;
      private string[] P00C72_A264EstadosNotificacionProfesional ;
      private string[] P00C72_A263EstadosNotificacionCliente ;
      private string[] P00C72_A109EstadosGenericosNombre ;
      private int[] P00C72_A108EstadosGenericosId ;
      private string[] P00C73_A109EstadosGenericosNombre ;
      private string[] P00C73_A265EstadosNotificacionOperador ;
      private string[] P00C73_A264EstadosNotificacionProfesional ;
      private string[] P00C73_A263EstadosNotificacionCliente ;
      private int[] P00C73_A108EstadosGenericosId ;
      private string[] P00C73_A107EstadosTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class estadosnotificacionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C72( IGxContext context ,
                                             string AV45Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [EstadosTipo], [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosNombre], [EstadosGenericosId] FROM [EstadosGenericos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV45Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV46Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV47Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV48Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV48Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EstadosTipo]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00C73( IGxContext context ,
                                             string AV45Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV47Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV46Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV48Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [EstadosGenericosNombre], [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosId], [EstadosTipo] FROM [EstadosGenericos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV45Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV45Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV46Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV47Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV47Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV48Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV48Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EstadosGenericosNombre]";
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
                     return conditional_P00C72(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P00C73(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
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
          Object[] prmP00C72;
          prmP00C72 = new Object[] {
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV47Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV48Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0)
          };
          Object[] prmP00C73;
          prmP00C73 = new Object[] {
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV45Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV46Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV47Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV48Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV49Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV50Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV53Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV54Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C72,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C73,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.estadosnotificacionwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class estadosnotificacionwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "EstadosNotificacionWWGetFilterData" )]
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
          if ( ! ProcessHeaders("estadosnotificacionwwgetfilterdata") )
          {
             return  ;
          }
          estadosnotificacionwwgetfilterdata worker = new estadosnotificacionwwgetfilterdata(context);
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
