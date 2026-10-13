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
   public class walletwwgetfilterdata : GXProcedure
   {
      public walletwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletwwgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV36MaxItems = 10;
            AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
            AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_WALLETCODREFENCIA") == 0 )
            {
               /* Execute user subroutine: 'LOADWALLETCODREFENCIAOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_WALLETNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADWALLETNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_MONEDAISOSIMBOLO") == 0 )
            {
               /* Execute user subroutine: 'LOADMONEDAISOSIMBOLOOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("WalletWWGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WalletWWGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("WalletWWGridState"), null, "", "");
         }
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETID") == 0 )
            {
               AV11TFWalletId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFWalletId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA") == 0 )
            {
               AV21TFWalletCodRefencia = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA_SEL") == 0 )
            {
               AV22TFWalletCodRefencia_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE") == 0 )
            {
               AV70TFWalletNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE_SEL") == 0 )
            {
               AV71TFWalletNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV72TFMonedaISOSimbolo = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV73TFMonedaISOSimbolo_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFWALLETSALDO") == 0 )
            {
               AV29TFWalletSaldo = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV30TFWalletSaldo_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV74GXV1 = (int)(AV74GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWALLETCODREFENCIAOPTIONS' Routine */
         returnInSub = false;
         AV21TFWalletCodRefencia = AV33SearchTxt;
         AV22TFWalletCodRefencia_Sel = "";
         AV76Walletwwds_1_filterfulltext = AV55FilterFullText;
         AV77Walletwwds_2_tfwalletid = AV11TFWalletId;
         AV78Walletwwds_3_tfwalletid_to = AV12TFWalletId_To;
         AV79Walletwwds_4_tfwalletcodrefencia = AV21TFWalletCodRefencia;
         AV80Walletwwds_5_tfwalletcodrefencia_sel = AV22TFWalletCodRefencia_Sel;
         AV81Walletwwds_6_tfwalletnombre = AV70TFWalletNombre;
         AV82Walletwwds_7_tfwalletnombre_sel = AV71TFWalletNombre_Sel;
         AV83Walletwwds_8_tfmonedaisosimbolo = AV72TFMonedaISOSimbolo;
         AV84Walletwwds_9_tfmonedaisosimbolo_sel = AV73TFMonedaISOSimbolo_Sel;
         AV85Walletwwds_10_tfwalletsaldo = AV29TFWalletSaldo;
         AV86Walletwwds_11_tfwalletsaldo_to = AV30TFWalletSaldo_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77Walletwwds_2_tfwalletid ,
                                              AV78Walletwwds_3_tfwalletid_to ,
                                              AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV79Walletwwds_4_tfwalletcodrefencia ,
                                              AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV83Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV76Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV82Walletwwds_7_tfwalletnombre_sel ,
                                              AV81Walletwwds_6_tfwalletnombre ,
                                              AV85Walletwwds_10_tfwalletsaldo ,
                                              AV86Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV79Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV83Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor P00BC2 */
         pr_default.execute(0, new Object[] {AV77Walletwwds_2_tfwalletid, AV78Walletwwds_3_tfwalletid_to, lV79Walletwwds_4_tfwalletcodrefencia, AV80Walletwwds_5_tfwalletcodrefencia_sel, lV83Walletwwds_8_tfmonedaisosimbolo, AV84Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBC2 = false;
            A118MonedaId = P00BC2_A118MonedaId[0];
            n118MonedaId = P00BC2_n118MonedaId[0];
            A119MonedaISOSimbolo = P00BC2_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00BC2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00BC2_A638WalletTipoEntidad[0];
            A637WalletId = P00BC2_A637WalletId[0];
            A119MonedaISOSimbolo = P00BC2_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV85Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV85Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV86Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV86Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV81Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV82Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV43count = 0;
                              while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BC2_A639WalletCodRefencia[0], A639WalletCodRefencia) == 0 ) )
                              {
                                 BRKBC2 = false;
                                 A637WalletId = P00BC2_A637WalletId[0];
                                 AV43count = (long)(AV43count+1);
                                 BRKBC2 = true;
                                 pr_default.readNext(0);
                              }
                              if ( (0==AV34SkipItems) )
                              {
                                 AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A639WalletCodRefencia)) ? "<#Empty#>" : A639WalletCodRefencia);
                                 AV39Options.Add(AV38Option, 0);
                                 AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                                 if ( AV39Options.Count == 10 )
                                 {
                                    /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                    if (true) break;
                                 }
                              }
                              else
                              {
                                 AV34SkipItems = (short)(AV34SkipItems-1);
                              }
                           }
                        }
                     }
                  }
               }
            }
            if ( ! BRKBC2 )
            {
               BRKBC2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWALLETNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV70TFWalletNombre = AV33SearchTxt;
         AV71TFWalletNombre_Sel = "";
         AV76Walletwwds_1_filterfulltext = AV55FilterFullText;
         AV77Walletwwds_2_tfwalletid = AV11TFWalletId;
         AV78Walletwwds_3_tfwalletid_to = AV12TFWalletId_To;
         AV79Walletwwds_4_tfwalletcodrefencia = AV21TFWalletCodRefencia;
         AV80Walletwwds_5_tfwalletcodrefencia_sel = AV22TFWalletCodRefencia_Sel;
         AV81Walletwwds_6_tfwalletnombre = AV70TFWalletNombre;
         AV82Walletwwds_7_tfwalletnombre_sel = AV71TFWalletNombre_Sel;
         AV83Walletwwds_8_tfmonedaisosimbolo = AV72TFMonedaISOSimbolo;
         AV84Walletwwds_9_tfmonedaisosimbolo_sel = AV73TFMonedaISOSimbolo_Sel;
         AV85Walletwwds_10_tfwalletsaldo = AV29TFWalletSaldo;
         AV86Walletwwds_11_tfwalletsaldo_to = AV30TFWalletSaldo_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV77Walletwwds_2_tfwalletid ,
                                              AV78Walletwwds_3_tfwalletid_to ,
                                              AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV79Walletwwds_4_tfwalletcodrefencia ,
                                              AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV83Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV76Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV82Walletwwds_7_tfwalletnombre_sel ,
                                              AV81Walletwwds_6_tfwalletnombre ,
                                              AV85Walletwwds_10_tfwalletsaldo ,
                                              AV86Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV79Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV83Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor P00BC3 */
         pr_default.execute(1, new Object[] {AV77Walletwwds_2_tfwalletid, AV78Walletwwds_3_tfwalletid_to, lV79Walletwwds_4_tfwalletcodrefencia, AV80Walletwwds_5_tfwalletcodrefencia_sel, lV83Walletwwds_8_tfmonedaisosimbolo, AV84Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A118MonedaId = P00BC3_A118MonedaId[0];
            n118MonedaId = P00BC3_n118MonedaId[0];
            A119MonedaISOSimbolo = P00BC3_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00BC3_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00BC3_A638WalletTipoEntidad[0];
            A637WalletId = P00BC3_A637WalletId[0];
            A119MonedaISOSimbolo = P00BC3_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV85Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV85Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV86Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV86Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV81Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV82Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ? "<#Empty#>" : A715WalletNombre);
                              AV37InsertIndex = 1;
                              while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
                              {
                                 AV37InsertIndex = (int)(AV37InsertIndex+1);
                              }
                              if ( ( AV37InsertIndex <= AV39Options.Count ) && ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) == 0 ) )
                              {
                                 AV43count = (long)(Math.Round(NumberUtil.Val( ((string)AV42OptionIndexes.Item(AV37InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                 AV43count = (long)(AV43count+1);
                                 AV42OptionIndexes.RemoveItem(AV37InsertIndex);
                                 AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
                              }
                              else
                              {
                                 AV39Options.Add(AV38Option, AV37InsertIndex);
                                 AV42OptionIndexes.Add("1", AV37InsertIndex);
                              }
                              if ( AV39Options.Count == AV34SkipItems + 11 )
                              {
                                 AV39Options.RemoveItem(AV39Options.Count);
                                 AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADMONEDAISOSIMBOLOOPTIONS' Routine */
         returnInSub = false;
         AV72TFMonedaISOSimbolo = AV33SearchTxt;
         AV73TFMonedaISOSimbolo_Sel = "";
         AV76Walletwwds_1_filterfulltext = AV55FilterFullText;
         AV77Walletwwds_2_tfwalletid = AV11TFWalletId;
         AV78Walletwwds_3_tfwalletid_to = AV12TFWalletId_To;
         AV79Walletwwds_4_tfwalletcodrefencia = AV21TFWalletCodRefencia;
         AV80Walletwwds_5_tfwalletcodrefencia_sel = AV22TFWalletCodRefencia_Sel;
         AV81Walletwwds_6_tfwalletnombre = AV70TFWalletNombre;
         AV82Walletwwds_7_tfwalletnombre_sel = AV71TFWalletNombre_Sel;
         AV83Walletwwds_8_tfmonedaisosimbolo = AV72TFMonedaISOSimbolo;
         AV84Walletwwds_9_tfmonedaisosimbolo_sel = AV73TFMonedaISOSimbolo_Sel;
         AV85Walletwwds_10_tfwalletsaldo = AV29TFWalletSaldo;
         AV86Walletwwds_11_tfwalletsaldo_to = AV30TFWalletSaldo_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV77Walletwwds_2_tfwalletid ,
                                              AV78Walletwwds_3_tfwalletid_to ,
                                              AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV79Walletwwds_4_tfwalletcodrefencia ,
                                              AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV83Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV76Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV82Walletwwds_7_tfwalletnombre_sel ,
                                              AV81Walletwwds_6_tfwalletnombre ,
                                              AV85Walletwwds_10_tfwalletsaldo ,
                                              AV86Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV79Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV83Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor P00BC4 */
         pr_default.execute(2, new Object[] {AV77Walletwwds_2_tfwalletid, AV78Walletwwds_3_tfwalletid_to, lV79Walletwwds_4_tfwalletcodrefencia, AV80Walletwwds_5_tfwalletcodrefencia_sel, lV83Walletwwds_8_tfmonedaisosimbolo, AV84Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBC5 = false;
            A118MonedaId = P00BC4_A118MonedaId[0];
            n118MonedaId = P00BC4_n118MonedaId[0];
            A119MonedaISOSimbolo = P00BC4_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00BC4_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00BC4_A638WalletTipoEntidad[0];
            A637WalletId = P00BC4_A637WalletId[0];
            A119MonedaISOSimbolo = P00BC4_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV85Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV85Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV86Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV86Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV76Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV81Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV82Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV82Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV43count = 0;
                              while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BC4_A119MonedaISOSimbolo[0], A119MonedaISOSimbolo) == 0 ) )
                              {
                                 BRKBC5 = false;
                                 A118MonedaId = P00BC4_A118MonedaId[0];
                                 n118MonedaId = P00BC4_n118MonedaId[0];
                                 A637WalletId = P00BC4_A637WalletId[0];
                                 AV43count = (long)(AV43count+1);
                                 BRKBC5 = true;
                                 pr_default.readNext(2);
                              }
                              if ( (0==AV34SkipItems) )
                              {
                                 AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A119MonedaISOSimbolo)) ? "<#Empty#>" : A119MonedaISOSimbolo);
                                 AV39Options.Add(AV38Option, 0);
                                 AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                                 if ( AV39Options.Count == 10 )
                                 {
                                    /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                    if (true) break;
                                 }
                              }
                              else
                              {
                                 AV34SkipItems = (short)(AV34SkipItems-1);
                              }
                           }
                        }
                     }
                  }
               }
            }
            if ( ! BRKBC5 )
            {
               BRKBC5 = true;
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV47GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV11TFWalletId = 0;
         AV12TFWalletId_To = 0;
         AV21TFWalletCodRefencia = "";
         AV22TFWalletCodRefencia_Sel = "";
         AV70TFWalletNombre = "";
         AV71TFWalletNombre_Sel = "";
         AV72TFMonedaISOSimbolo = "";
         AV73TFMonedaISOSimbolo_Sel = "";
         AV76Walletwwds_1_filterfulltext = "";
         AV79Walletwwds_4_tfwalletcodrefencia = "";
         AV80Walletwwds_5_tfwalletcodrefencia_sel = "";
         AV81Walletwwds_6_tfwalletnombre = "";
         AV82Walletwwds_7_tfwalletnombre_sel = "";
         AV83Walletwwds_8_tfmonedaisosimbolo = "";
         AV84Walletwwds_9_tfmonedaisosimbolo_sel = "";
         lV79Walletwwds_4_tfwalletcodrefencia = "";
         lV83Walletwwds_8_tfmonedaisosimbolo = "";
         A639WalletCodRefencia = "";
         A119MonedaISOSimbolo = "";
         A715WalletNombre = "";
         P00BC2_A118MonedaId = new short[1] ;
         P00BC2_n118MonedaId = new bool[] {false} ;
         P00BC2_A119MonedaISOSimbolo = new string[] {""} ;
         P00BC2_A639WalletCodRefencia = new string[] {""} ;
         P00BC2_A638WalletTipoEntidad = new string[] {""} ;
         P00BC2_A637WalletId = new long[1] ;
         A638WalletTipoEntidad = "";
         AV38Option = "";
         P00BC3_A118MonedaId = new short[1] ;
         P00BC3_n118MonedaId = new bool[] {false} ;
         P00BC3_A119MonedaISOSimbolo = new string[] {""} ;
         P00BC3_A639WalletCodRefencia = new string[] {""} ;
         P00BC3_A638WalletTipoEntidad = new string[] {""} ;
         P00BC3_A637WalletId = new long[1] ;
         P00BC4_A118MonedaId = new short[1] ;
         P00BC4_n118MonedaId = new bool[] {false} ;
         P00BC4_A119MonedaISOSimbolo = new string[] {""} ;
         P00BC4_A639WalletCodRefencia = new string[] {""} ;
         P00BC4_A638WalletTipoEntidad = new string[] {""} ;
         P00BC4_A637WalletId = new long[1] ;
         GXt_char3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BC2_A118MonedaId, P00BC2_n118MonedaId, P00BC2_A119MonedaISOSimbolo, P00BC2_A639WalletCodRefencia, P00BC2_A638WalletTipoEntidad, P00BC2_A637WalletId
               }
               , new Object[] {
               P00BC3_A118MonedaId, P00BC3_n118MonedaId, P00BC3_A119MonedaISOSimbolo, P00BC3_A639WalletCodRefencia, P00BC3_A638WalletTipoEntidad, P00BC3_A637WalletId
               }
               , new Object[] {
               P00BC4_A118MonedaId, P00BC4_n118MonedaId, P00BC4_A119MonedaISOSimbolo, P00BC4_A639WalletCodRefencia, P00BC4_A638WalletTipoEntidad, P00BC4_A637WalletId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short A118MonedaId ;
      private int AV74GXV1 ;
      private int AV37InsertIndex ;
      private long AV11TFWalletId ;
      private long AV12TFWalletId_To ;
      private long AV77Walletwwds_2_tfwalletid ;
      private long AV78Walletwwds_3_tfwalletid_to ;
      private long A637WalletId ;
      private long AV43count ;
      private decimal AV29TFWalletSaldo ;
      private decimal AV30TFWalletSaldo_To ;
      private decimal AV85Walletwwds_10_tfwalletsaldo ;
      private decimal AV86Walletwwds_11_tfwalletsaldo_to ;
      private decimal A648WalletSaldo ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal2 ;
      private string AV21TFWalletCodRefencia ;
      private string AV22TFWalletCodRefencia_Sel ;
      private string AV70TFWalletNombre ;
      private string AV71TFWalletNombre_Sel ;
      private string AV72TFMonedaISOSimbolo ;
      private string AV73TFMonedaISOSimbolo_Sel ;
      private string AV79Walletwwds_4_tfwalletcodrefencia ;
      private string AV80Walletwwds_5_tfwalletcodrefencia_sel ;
      private string AV81Walletwwds_6_tfwalletnombre ;
      private string AV82Walletwwds_7_tfwalletnombre_sel ;
      private string AV83Walletwwds_8_tfmonedaisosimbolo ;
      private string AV84Walletwwds_9_tfmonedaisosimbolo_sel ;
      private string lV79Walletwwds_4_tfwalletcodrefencia ;
      private string lV83Walletwwds_8_tfmonedaisosimbolo ;
      private string A639WalletCodRefencia ;
      private string A119MonedaISOSimbolo ;
      private string A715WalletNombre ;
      private string A638WalletTipoEntidad ;
      private string GXt_char3 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKBC2 ;
      private bool n118MonedaId ;
      private bool BRKBC5 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV76Walletwwds_1_filterfulltext ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV46GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00BC2_A118MonedaId ;
      private bool[] P00BC2_n118MonedaId ;
      private string[] P00BC2_A119MonedaISOSimbolo ;
      private string[] P00BC2_A639WalletCodRefencia ;
      private string[] P00BC2_A638WalletTipoEntidad ;
      private long[] P00BC2_A637WalletId ;
      private short[] P00BC3_A118MonedaId ;
      private bool[] P00BC3_n118MonedaId ;
      private string[] P00BC3_A119MonedaISOSimbolo ;
      private string[] P00BC3_A639WalletCodRefencia ;
      private string[] P00BC3_A638WalletTipoEntidad ;
      private long[] P00BC3_A637WalletId ;
      private short[] P00BC4_A118MonedaId ;
      private bool[] P00BC4_n118MonedaId ;
      private string[] P00BC4_A119MonedaISOSimbolo ;
      private string[] P00BC4_A639WalletCodRefencia ;
      private string[] P00BC4_A638WalletTipoEntidad ;
      private long[] P00BC4_A637WalletId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class walletwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BC2( IGxContext context ,
                                             long AV77Walletwwds_2_tfwalletid ,
                                             long AV78Walletwwds_3_tfwalletid_to ,
                                             string AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV79Walletwwds_4_tfwalletcodrefencia ,
                                             string AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV83Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV76Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV82Walletwwds_7_tfwalletnombre_sel ,
                                             string AV81Walletwwds_6_tfwalletnombre ,
                                             decimal AV85Walletwwds_10_tfwalletsaldo ,
                                             decimal AV86Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV77Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV77Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV78Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV78Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV79Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV80Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV83Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV84Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00BC3( IGxContext context ,
                                             long AV77Walletwwds_2_tfwalletid ,
                                             long AV78Walletwwds_3_tfwalletid_to ,
                                             string AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV79Walletwwds_4_tfwalletcodrefencia ,
                                             string AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV83Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV76Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV82Walletwwds_7_tfwalletnombre_sel ,
                                             string AV81Walletwwds_6_tfwalletnombre ,
                                             decimal AV85Walletwwds_10_tfwalletsaldo ,
                                             decimal AV86Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV77Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV77Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV78Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV78Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV79Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV80Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV83Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV84Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletId]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00BC4( IGxContext context ,
                                             long AV77Walletwwds_2_tfwalletid ,
                                             long AV78Walletwwds_3_tfwalletid_to ,
                                             string AV80Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV79Walletwwds_4_tfwalletcodrefencia ,
                                             string AV84Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV83Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV76Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV82Walletwwds_7_tfwalletnombre_sel ,
                                             string AV81Walletwwds_6_tfwalletnombre ,
                                             decimal AV85Walletwwds_10_tfwalletsaldo ,
                                             decimal AV86Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV77Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV77Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV78Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV78Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV79Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV80Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV80Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV83Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV84Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV84Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BC2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
               case 1 :
                     return conditional_P00BC3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
               case 2 :
                     return conditional_P00BC4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
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
          Object[] prmP00BC2;
          prmP00BC2 = new Object[] {
          new ParDef("@AV77Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV78Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV79Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV80Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV83Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV84Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          Object[] prmP00BC3;
          prmP00BC3 = new Object[] {
          new ParDef("@AV77Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV78Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV79Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV80Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV83Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV84Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          Object[] prmP00BC4;
          prmP00BC4 = new Object[] {
          new ParDef("@AV77Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV78Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV79Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV80Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV83Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV84Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BC3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BC4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BC4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.walletwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class walletwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "WalletWWGetFilterData" )]
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
          if ( ! ProcessHeaders("walletwwgetfilterdata") )
          {
             return  ;
          }
          walletwwgetfilterdata worker = new walletwwgetfilterdata(context);
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
