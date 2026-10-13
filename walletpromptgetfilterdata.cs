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
   public class walletpromptgetfilterdata : GXProcedure
   {
      public walletpromptgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletpromptgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV24MaxItems = 10;
            AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
            AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WALLETCODREFENCIA") == 0 )
            {
               /* Execute user subroutine: 'LOADWALLETCODREFENCIAOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WALLETNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADWALLETNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MONEDAISOSIMBOLO") == 0 )
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
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("WalletPromptGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WalletPromptGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WalletPromptGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETID") == 0 )
            {
               AV11TFWalletId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFWalletId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA") == 0 )
            {
               AV13TFWalletCodRefencia = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA_SEL") == 0 )
            {
               AV14TFWalletCodRefencia_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE") == 0 )
            {
               AV15TFWalletNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE_SEL") == 0 )
            {
               AV16TFWalletNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV17TFMonedaISOSimbolo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV18TFMonedaISOSimbolo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWALLETSALDO") == 0 )
            {
               AV19TFWalletSaldo = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV20TFWalletSaldo_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWALLETCODREFENCIAOPTIONS' Routine */
         returnInSub = false;
         AV13TFWalletCodRefencia = AV21SearchTxt;
         AV14TFWalletCodRefencia_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFWalletId ,
                                              AV12TFWalletId_To ,
                                              AV14TFWalletCodRefencia_Sel ,
                                              AV13TFWalletCodRefencia ,
                                              AV18TFMonedaISOSimbolo_Sel ,
                                              AV17TFMonedaISOSimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV43FilterFullText ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV16TFWalletNombre_Sel ,
                                              AV15TFWalletNombre ,
                                              AV19TFWalletSaldo ,
                                              AV20TFWalletSaldo_To } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV13TFWalletCodRefencia = StringUtil.PadR( StringUtil.RTrim( AV13TFWalletCodRefencia), 25, "%");
         lV17TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV17TFMonedaISOSimbolo), 3, "%");
         /* Using cursor P00DJ2 */
         pr_default.execute(0, new Object[] {AV11TFWalletId, AV12TFWalletId_To, lV13TFWalletCodRefencia, AV14TFWalletCodRefencia_Sel, lV17TFMonedaISOSimbolo, AV18TFMonedaISOSimbolo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDJ2 = false;
            A118MonedaId = P00DJ2_A118MonedaId[0];
            n118MonedaId = P00DJ2_n118MonedaId[0];
            A119MonedaISOSimbolo = P00DJ2_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00DJ2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00DJ2_A638WalletTipoEntidad[0];
            A637WalletId = P00DJ2_A637WalletId[0];
            A119MonedaISOSimbolo = P00DJ2_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV19TFWalletSaldo) || ( ( A648WalletSaldo >= AV19TFWalletSaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV20TFWalletSaldo_To) || ( ( A648WalletSaldo <= AV20TFWalletSaldo_To ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFWalletNombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV15TFWalletNombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV16TFWalletNombre_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV31count = 0;
                              while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DJ2_A639WalletCodRefencia[0], A639WalletCodRefencia) == 0 ) )
                              {
                                 BRKDJ2 = false;
                                 A637WalletId = P00DJ2_A637WalletId[0];
                                 AV31count = (long)(AV31count+1);
                                 BRKDJ2 = true;
                                 pr_default.readNext(0);
                              }
                              if ( (0==AV22SkipItems) )
                              {
                                 AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A639WalletCodRefencia)) ? "<#Empty#>" : A639WalletCodRefencia);
                                 AV27Options.Add(AV26Option, 0);
                                 AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                                 if ( AV27Options.Count == 10 )
                                 {
                                    /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                    if (true) break;
                                 }
                              }
                              else
                              {
                                 AV22SkipItems = (short)(AV22SkipItems-1);
                              }
                           }
                        }
                     }
                  }
               }
            }
            if ( ! BRKDJ2 )
            {
               BRKDJ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWALLETNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFWalletNombre = AV21SearchTxt;
         AV16TFWalletNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11TFWalletId ,
                                              AV12TFWalletId_To ,
                                              AV14TFWalletCodRefencia_Sel ,
                                              AV13TFWalletCodRefencia ,
                                              AV18TFMonedaISOSimbolo_Sel ,
                                              AV17TFMonedaISOSimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV43FilterFullText ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV16TFWalletNombre_Sel ,
                                              AV15TFWalletNombre ,
                                              AV19TFWalletSaldo ,
                                              AV20TFWalletSaldo_To } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV13TFWalletCodRefencia = StringUtil.PadR( StringUtil.RTrim( AV13TFWalletCodRefencia), 25, "%");
         lV17TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV17TFMonedaISOSimbolo), 3, "%");
         /* Using cursor P00DJ3 */
         pr_default.execute(1, new Object[] {AV11TFWalletId, AV12TFWalletId_To, lV13TFWalletCodRefencia, AV14TFWalletCodRefencia_Sel, lV17TFMonedaISOSimbolo, AV18TFMonedaISOSimbolo_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A118MonedaId = P00DJ3_A118MonedaId[0];
            n118MonedaId = P00DJ3_n118MonedaId[0];
            A119MonedaISOSimbolo = P00DJ3_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00DJ3_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00DJ3_A638WalletTipoEntidad[0];
            A637WalletId = P00DJ3_A637WalletId[0];
            A119MonedaISOSimbolo = P00DJ3_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV19TFWalletSaldo) || ( ( A648WalletSaldo >= AV19TFWalletSaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV20TFWalletSaldo_To) || ( ( A648WalletSaldo <= AV20TFWalletSaldo_To ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFWalletNombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV15TFWalletNombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV16TFWalletNombre_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ? "<#Empty#>" : A715WalletNombre);
                              AV25InsertIndex = 1;
                              while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
                              {
                                 AV25InsertIndex = (int)(AV25InsertIndex+1);
                              }
                              if ( ( AV25InsertIndex <= AV27Options.Count ) && ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) == 0 ) )
                              {
                                 AV31count = (long)(Math.Round(NumberUtil.Val( ((string)AV30OptionIndexes.Item(AV25InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                 AV31count = (long)(AV31count+1);
                                 AV30OptionIndexes.RemoveItem(AV25InsertIndex);
                                 AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
                              }
                              else
                              {
                                 AV27Options.Add(AV26Option, AV25InsertIndex);
                                 AV30OptionIndexes.Add("1", AV25InsertIndex);
                              }
                              if ( AV27Options.Count == AV22SkipItems + 11 )
                              {
                                 AV27Options.RemoveItem(AV27Options.Count);
                                 AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
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
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADMONEDAISOSIMBOLOOPTIONS' Routine */
         returnInSub = false;
         AV17TFMonedaISOSimbolo = AV21SearchTxt;
         AV18TFMonedaISOSimbolo_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV11TFWalletId ,
                                              AV12TFWalletId_To ,
                                              AV14TFWalletCodRefencia_Sel ,
                                              AV13TFWalletCodRefencia ,
                                              AV18TFMonedaISOSimbolo_Sel ,
                                              AV17TFMonedaISOSimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV43FilterFullText ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV16TFWalletNombre_Sel ,
                                              AV15TFWalletNombre ,
                                              AV19TFWalletSaldo ,
                                              AV20TFWalletSaldo_To } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV13TFWalletCodRefencia = StringUtil.PadR( StringUtil.RTrim( AV13TFWalletCodRefencia), 25, "%");
         lV17TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV17TFMonedaISOSimbolo), 3, "%");
         /* Using cursor P00DJ4 */
         pr_default.execute(2, new Object[] {AV11TFWalletId, AV12TFWalletId_To, lV13TFWalletCodRefencia, AV14TFWalletCodRefencia_Sel, lV17TFMonedaISOSimbolo, AV18TFMonedaISOSimbolo_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKDJ5 = false;
            A118MonedaId = P00DJ4_A118MonedaId[0];
            n118MonedaId = P00DJ4_n118MonedaId[0];
            A119MonedaISOSimbolo = P00DJ4_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00DJ4_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00DJ4_A638WalletTipoEntidad[0];
            A637WalletId = P00DJ4_A637WalletId[0];
            A119MonedaISOSimbolo = P00DJ4_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV19TFWalletSaldo) || ( ( A648WalletSaldo >= AV19TFWalletSaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV20TFWalletSaldo_To) || ( ( A648WalletSaldo <= AV20TFWalletSaldo_To ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV43FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV43FilterFullText , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFWalletNombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV15TFWalletNombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFWalletNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV16TFWalletNombre_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV16TFWalletNombre_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              AV31count = 0;
                              while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00DJ4_A119MonedaISOSimbolo[0], A119MonedaISOSimbolo) == 0 ) )
                              {
                                 BRKDJ5 = false;
                                 A118MonedaId = P00DJ4_A118MonedaId[0];
                                 n118MonedaId = P00DJ4_n118MonedaId[0];
                                 A637WalletId = P00DJ4_A637WalletId[0];
                                 AV31count = (long)(AV31count+1);
                                 BRKDJ5 = true;
                                 pr_default.readNext(2);
                              }
                              if ( (0==AV22SkipItems) )
                              {
                                 AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A119MonedaISOSimbolo)) ? "<#Empty#>" : A119MonedaISOSimbolo);
                                 AV27Options.Add(AV26Option, 0);
                                 AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                                 if ( AV27Options.Count == 10 )
                                 {
                                    /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                    if (true) break;
                                 }
                              }
                              else
                              {
                                 AV22SkipItems = (short)(AV22SkipItems-1);
                              }
                           }
                        }
                     }
                  }
               }
            }
            if ( ! BRKDJ5 )
            {
               BRKDJ5 = true;
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV11TFWalletId = 0;
         AV12TFWalletId_To = 0;
         AV13TFWalletCodRefencia = "";
         AV14TFWalletCodRefencia_Sel = "";
         AV15TFWalletNombre = "";
         AV16TFWalletNombre_Sel = "";
         AV17TFMonedaISOSimbolo = "";
         AV18TFMonedaISOSimbolo_Sel = "";
         lV13TFWalletCodRefencia = "";
         lV17TFMonedaISOSimbolo = "";
         A639WalletCodRefencia = "";
         A119MonedaISOSimbolo = "";
         A715WalletNombre = "";
         P00DJ2_A118MonedaId = new short[1] ;
         P00DJ2_n118MonedaId = new bool[] {false} ;
         P00DJ2_A119MonedaISOSimbolo = new string[] {""} ;
         P00DJ2_A639WalletCodRefencia = new string[] {""} ;
         P00DJ2_A638WalletTipoEntidad = new string[] {""} ;
         P00DJ2_A637WalletId = new long[1] ;
         A638WalletTipoEntidad = "";
         AV26Option = "";
         P00DJ3_A118MonedaId = new short[1] ;
         P00DJ3_n118MonedaId = new bool[] {false} ;
         P00DJ3_A119MonedaISOSimbolo = new string[] {""} ;
         P00DJ3_A639WalletCodRefencia = new string[] {""} ;
         P00DJ3_A638WalletTipoEntidad = new string[] {""} ;
         P00DJ3_A637WalletId = new long[1] ;
         P00DJ4_A118MonedaId = new short[1] ;
         P00DJ4_n118MonedaId = new bool[] {false} ;
         P00DJ4_A119MonedaISOSimbolo = new string[] {""} ;
         P00DJ4_A639WalletCodRefencia = new string[] {""} ;
         P00DJ4_A638WalletTipoEntidad = new string[] {""} ;
         P00DJ4_A637WalletId = new long[1] ;
         GXt_char3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletpromptgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DJ2_A118MonedaId, P00DJ2_n118MonedaId, P00DJ2_A119MonedaISOSimbolo, P00DJ2_A639WalletCodRefencia, P00DJ2_A638WalletTipoEntidad, P00DJ2_A637WalletId
               }
               , new Object[] {
               P00DJ3_A118MonedaId, P00DJ3_n118MonedaId, P00DJ3_A119MonedaISOSimbolo, P00DJ3_A639WalletCodRefencia, P00DJ3_A638WalletTipoEntidad, P00DJ3_A637WalletId
               }
               , new Object[] {
               P00DJ4_A118MonedaId, P00DJ4_n118MonedaId, P00DJ4_A119MonedaISOSimbolo, P00DJ4_A639WalletCodRefencia, P00DJ4_A638WalletTipoEntidad, P00DJ4_A637WalletId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short A118MonedaId ;
      private int AV44GXV1 ;
      private int AV25InsertIndex ;
      private long AV11TFWalletId ;
      private long AV12TFWalletId_To ;
      private long A637WalletId ;
      private long AV31count ;
      private decimal AV19TFWalletSaldo ;
      private decimal AV20TFWalletSaldo_To ;
      private decimal A648WalletSaldo ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal2 ;
      private string AV13TFWalletCodRefencia ;
      private string AV14TFWalletCodRefencia_Sel ;
      private string AV15TFWalletNombre ;
      private string AV16TFWalletNombre_Sel ;
      private string AV17TFMonedaISOSimbolo ;
      private string AV18TFMonedaISOSimbolo_Sel ;
      private string lV13TFWalletCodRefencia ;
      private string lV17TFMonedaISOSimbolo ;
      private string A639WalletCodRefencia ;
      private string A119MonedaISOSimbolo ;
      private string A715WalletNombre ;
      private string A638WalletTipoEntidad ;
      private string GXt_char3 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKDJ2 ;
      private bool n118MonedaId ;
      private bool BRKDJ5 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00DJ2_A118MonedaId ;
      private bool[] P00DJ2_n118MonedaId ;
      private string[] P00DJ2_A119MonedaISOSimbolo ;
      private string[] P00DJ2_A639WalletCodRefencia ;
      private string[] P00DJ2_A638WalletTipoEntidad ;
      private long[] P00DJ2_A637WalletId ;
      private short[] P00DJ3_A118MonedaId ;
      private bool[] P00DJ3_n118MonedaId ;
      private string[] P00DJ3_A119MonedaISOSimbolo ;
      private string[] P00DJ3_A639WalletCodRefencia ;
      private string[] P00DJ3_A638WalletTipoEntidad ;
      private long[] P00DJ3_A637WalletId ;
      private short[] P00DJ4_A118MonedaId ;
      private bool[] P00DJ4_n118MonedaId ;
      private string[] P00DJ4_A119MonedaISOSimbolo ;
      private string[] P00DJ4_A639WalletCodRefencia ;
      private string[] P00DJ4_A638WalletTipoEntidad ;
      private long[] P00DJ4_A637WalletId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class walletpromptgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DJ2( IGxContext context ,
                                             long AV11TFWalletId ,
                                             long AV12TFWalletId_To ,
                                             string AV14TFWalletCodRefencia_Sel ,
                                             string AV13TFWalletCodRefencia ,
                                             string AV18TFMonedaISOSimbolo_Sel ,
                                             string AV17TFMonedaISOSimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV43FilterFullText ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV16TFWalletNombre_Sel ,
                                             string AV15TFWalletNombre ,
                                             decimal AV19TFWalletSaldo ,
                                             decimal AV20TFWalletSaldo_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV11TFWalletId) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV11TFWalletId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV12TFWalletId_To) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV12TFWalletId_To)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWalletCodRefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV13TFWalletCodRefencia))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ! ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV14TFWalletCodRefencia_Sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV17TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV18TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DJ3( IGxContext context ,
                                             long AV11TFWalletId ,
                                             long AV12TFWalletId_To ,
                                             string AV14TFWalletCodRefencia_Sel ,
                                             string AV13TFWalletCodRefencia ,
                                             string AV18TFMonedaISOSimbolo_Sel ,
                                             string AV17TFMonedaISOSimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV43FilterFullText ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV16TFWalletNombre_Sel ,
                                             string AV15TFWalletNombre ,
                                             decimal AV19TFWalletSaldo ,
                                             decimal AV20TFWalletSaldo_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV11TFWalletId) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV11TFWalletId)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV12TFWalletId_To) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV12TFWalletId_To)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWalletCodRefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV13TFWalletCodRefencia))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ! ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV14TFWalletCodRefencia_Sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV17TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV18TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[WalletId]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00DJ4( IGxContext context ,
                                             long AV11TFWalletId ,
                                             long AV12TFWalletId_To ,
                                             string AV14TFWalletCodRefencia_Sel ,
                                             string AV13TFWalletCodRefencia ,
                                             string AV18TFMonedaISOSimbolo_Sel ,
                                             string AV17TFMonedaISOSimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             string AV43FilterFullText ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV16TFWalletNombre_Sel ,
                                             string AV15TFWalletNombre ,
                                             decimal AV19TFWalletSaldo ,
                                             decimal AV20TFWalletSaldo_To )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV11TFWalletId) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV11TFWalletId)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV12TFWalletId_To) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV12TFWalletId_To)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFWalletCodRefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV13TFWalletCodRefencia))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFWalletCodRefencia_Sel)) && ! ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV14TFWalletCodRefencia_Sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFWalletCodRefencia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV17TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV18TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
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
                     return conditional_P00DJ2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
               case 1 :
                     return conditional_P00DJ3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
               case 2 :
                     return conditional_P00DJ4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] );
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
          Object[] prmP00DJ2;
          prmP00DJ2 = new Object[] {
          new ParDef("@AV11TFWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFWalletId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFWalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV14TFWalletCodRefencia_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV17TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV18TFMonedaISOSimbolo_Sel",GXType.NChar,3,0)
          };
          Object[] prmP00DJ3;
          prmP00DJ3 = new Object[] {
          new ParDef("@AV11TFWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFWalletId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFWalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV14TFWalletCodRefencia_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV17TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV18TFMonedaISOSimbolo_Sel",GXType.NChar,3,0)
          };
          Object[] prmP00DJ4;
          prmP00DJ4 = new Object[] {
          new ParDef("@AV11TFWalletId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFWalletId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFWalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV14TFWalletCodRefencia_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV17TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV18TFMonedaISOSimbolo_Sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DJ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DJ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DJ4,100, GxCacheFrequency.OFF ,true,false )
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

 [ServiceContract(Namespace = "GeneXus.Programs.walletpromptgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class walletpromptgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "WalletPromptGetFilterData" )]
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
          if ( ! ProcessHeaders("walletpromptgetfilterdata") )
          {
             return  ;
          }
          walletpromptgetfilterdata worker = new walletpromptgetfilterdata(context);
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
