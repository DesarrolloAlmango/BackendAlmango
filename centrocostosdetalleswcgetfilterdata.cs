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
   public class centrocostosdetalleswcgetfilterdata : GXProcedure
   {
      public centrocostosdetalleswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostosdetalleswcgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV22MaxItems = 10;
            AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
            AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_CENTROCOSTOSDETALLESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSDETALLESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("CentroCostosDetallesWCGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CentroCostosDetallesWCGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("CentroCostosDetallesWCGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSDETALLESID") == 0 )
            {
               AV11TFCentroCostosDetallesId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCentroCostosDetallesId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSID") == 0 )
            {
               AV13TFListaCostosId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFListaCostosId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSDETALLESNOMBRE") == 0 )
            {
               AV15TFCentroCostosDetallesNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSDETALLESNOMBRE_SEL") == 0 )
            {
               AV16TFCentroCostosDetallesNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSDETALLESVALOR") == 0 )
            {
               AV17TFCentroCostosDetallesValor = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV18TFCentroCostosDetallesValor_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&CENTROCOSTOSID") == 0 )
            {
               AV41CentroCostosId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&CENTROCOSTOSREF") == 0 )
            {
               AV42CentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCENTROCOSTOSDETALLESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFCentroCostosDetallesNombre = AV19SearchTxt;
         AV16TFCentroCostosDetallesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFCentroCostosDetallesId ,
                                              AV12TFCentroCostosDetallesId_To ,
                                              AV13TFListaCostosId ,
                                              AV14TFListaCostosId_To ,
                                              AV16TFCentroCostosDetallesNombre_Sel ,
                                              AV15TFCentroCostosDetallesNombre ,
                                              AV17TFCentroCostosDetallesValor ,
                                              AV18TFCentroCostosDetallesValor_To ,
                                              A466CentroCostosDetallesId ,
                                              A459ListaCostosId ,
                                              A473CentroCostosDetallesNombre ,
                                              A468CentroCostosDetallesValor ,
                                              AV41CentroCostosId ,
                                              AV42CentroCostosRef ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV15TFCentroCostosDetallesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFCentroCostosDetallesNombre), 80, "%");
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {AV41CentroCostosId, AV42CentroCostosRef, AV11TFCentroCostosDetallesId, AV12TFCentroCostosDetallesId_To, AV13TFListaCostosId, AV14TFListaCostosId_To, lV15TFCentroCostosDetallesNombre, AV16TFCentroCostosDetallesNombre_Sel, AV17TFCentroCostosDetallesValor, AV18TFCentroCostosDetallesValor_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5X2 = false;
            A461CentroCostosId = P005X2_A461CentroCostosId[0];
            A462CentroCostosRef = P005X2_A462CentroCostosRef[0];
            A473CentroCostosDetallesNombre = P005X2_A473CentroCostosDetallesNombre[0];
            A468CentroCostosDetallesValor = P005X2_A468CentroCostosDetallesValor[0];
            A459ListaCostosId = P005X2_A459ListaCostosId[0];
            n459ListaCostosId = P005X2_n459ListaCostosId[0];
            A466CentroCostosDetallesId = P005X2_A466CentroCostosDetallesId[0];
            A462CentroCostosRef = P005X2_A462CentroCostosRef[0];
            W462CentroCostosRef = A462CentroCostosRef;
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P005X2_A461CentroCostosId[0] == A461CentroCostosId ) && ( P005X2_A462CentroCostosRef[0] == A462CentroCostosRef ) && ( StringUtil.StrCmp(P005X2_A473CentroCostosDetallesNombre[0], A473CentroCostosDetallesNombre) == 0 ) )
            {
               BRK5X2 = false;
               A466CentroCostosDetallesId = P005X2_A466CentroCostosDetallesId[0];
               AV29count = (long)(AV29count+1);
               BRK5X2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A473CentroCostosDetallesNombre)) ? "<#Empty#>" : A473CentroCostosDetallesNombre);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            A462CentroCostosRef = W462CentroCostosRef;
            if ( ! BRK5X2 )
            {
               BRK5X2 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV15TFCentroCostosDetallesNombre = "";
         AV16TFCentroCostosDetallesNombre_Sel = "";
         lV15TFCentroCostosDetallesNombre = "";
         A473CentroCostosDetallesNombre = "";
         P005X2_A461CentroCostosId = new long[1] ;
         P005X2_A462CentroCostosRef = new long[1] ;
         P005X2_A473CentroCostosDetallesNombre = new string[] {""} ;
         P005X2_A468CentroCostosDetallesValor = new decimal[1] ;
         P005X2_A459ListaCostosId = new long[1] ;
         P005X2_n459ListaCostosId = new bool[] {false} ;
         P005X2_A466CentroCostosDetallesId = new long[1] ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostosdetalleswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005X2_A461CentroCostosId, P005X2_A462CentroCostosRef, P005X2_A473CentroCostosDetallesNombre, P005X2_A468CentroCostosDetallesValor, P005X2_A459ListaCostosId, P005X2_n459ListaCostosId, P005X2_A466CentroCostosDetallesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV43GXV1 ;
      private long AV11TFCentroCostosDetallesId ;
      private long AV12TFCentroCostosDetallesId_To ;
      private long AV13TFListaCostosId ;
      private long AV14TFListaCostosId_To ;
      private long AV41CentroCostosId ;
      private long AV42CentroCostosRef ;
      private long A466CentroCostosDetallesId ;
      private long A459ListaCostosId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long W462CentroCostosRef ;
      private long AV29count ;
      private decimal AV17TFCentroCostosDetallesValor ;
      private decimal AV18TFCentroCostosDetallesValor_To ;
      private decimal A468CentroCostosDetallesValor ;
      private string AV15TFCentroCostosDetallesNombre ;
      private string AV16TFCentroCostosDetallesNombre_Sel ;
      private string lV15TFCentroCostosDetallesNombre ;
      private string A473CentroCostosDetallesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK5X2 ;
      private bool n459ListaCostosId ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P005X2_A461CentroCostosId ;
      private long[] P005X2_A462CentroCostosRef ;
      private string[] P005X2_A473CentroCostosDetallesNombre ;
      private decimal[] P005X2_A468CentroCostosDetallesValor ;
      private long[] P005X2_A459ListaCostosId ;
      private bool[] P005X2_n459ListaCostosId ;
      private long[] P005X2_A466CentroCostosDetallesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class centrocostosdetalleswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005X2( IGxContext context ,
                                             long AV11TFCentroCostosDetallesId ,
                                             long AV12TFCentroCostosDetallesId_To ,
                                             long AV13TFListaCostosId ,
                                             long AV14TFListaCostosId_To ,
                                             string AV16TFCentroCostosDetallesNombre_Sel ,
                                             string AV15TFCentroCostosDetallesNombre ,
                                             decimal AV17TFCentroCostosDetallesValor ,
                                             decimal AV18TFCentroCostosDetallesValor_To ,
                                             long A466CentroCostosDetallesId ,
                                             long A459ListaCostosId ,
                                             string A473CentroCostosDetallesNombre ,
                                             decimal A468CentroCostosDetallesValor ,
                                             long AV41CentroCostosId ,
                                             long AV42CentroCostosRef ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosId], T2.[CentroCostosRef], T1.[CentroCostosDetallesNombre], T1.[CentroCostosDetallesValor], T1.[ListaCostosId], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[CentroCostosId] = @AV41CentroCostosId and T2.[CentroCostosRef] = @AV42CentroCostosRef)");
         if ( ! (0==AV11TFCentroCostosDetallesId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosDetallesId] >= @AV11TFCentroCostosDetallesId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV12TFCentroCostosDetallesId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosDetallesId] <= @AV12TFCentroCostosDetallesId_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV13TFListaCostosId) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV13TFListaCostosId)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV14TFListaCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV14TFListaCostosId_To)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosDetallesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFCentroCostosDetallesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosDetallesNombre]) like UPPER(@lV15TFCentroCostosDetallesNombre))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosDetallesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFCentroCostosDetallesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosDetallesNombre] = @AV16TFCentroCostosDetallesNombre_Sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFCentroCostosDetallesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CentroCostosDetallesNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFCentroCostosDetallesValor) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosDetallesValor] >= @AV17TFCentroCostosDetallesValor)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFCentroCostosDetallesValor_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosDetallesValor] <= @AV18TFCentroCostosDetallesValor_To)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CentroCostosId], T2.[CentroCostosRef], T1.[CentroCostosDetallesNombre]";
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
                     return conditional_P005X2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] );
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("@AV41CentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV42CentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosDetallesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosDetallesId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFListaCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFCentroCostosDetallesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFCentroCostosDetallesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV17TFCentroCostosDetallesValor",GXType.Decimal,10,2) ,
          new ParDef("@AV18TFCentroCostosDetallesValor_To",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.centrocostosdetalleswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class centrocostosdetalleswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "CentroCostosDetallesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("centrocostosdetalleswcgetfilterdata") )
          {
             return  ;
          }
          centrocostosdetalleswcgetfilterdata worker = new centrocostosdetalleswcgetfilterdata(context);
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
