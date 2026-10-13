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
   public class operacionesidpromptgetfilterdata : GXProcedure
   {
      public operacionesidpromptgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacionesidpromptgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_OPERACIONESREF") == 0 )
         {
            /* Execute user subroutine: 'LOADOPERACIONESREFOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_OPERACIONESNOMBREREF") == 0 )
         {
            /* Execute user subroutine: 'LOADOPERACIONESNOMBREREFOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("OperacionesIdPromptGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacionesIdPromptGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("OperacionesIdPromptGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESID") == 0 )
            {
               AV11TFOperacionesId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFOperacionesId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESTIPO_SEL") == 0 )
            {
               AV13TFOperacionesTipo_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV14TFOperacionesTipo_Sels.FromJSonString(AV13TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESREF") == 0 )
            {
               AV15TFOperacionesRef = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESREF_SEL") == 0 )
            {
               AV16TFOperacionesRef_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESNOMBREREF") == 0 )
            {
               AV17TFOperacionesNombreRef = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESNOMBREREF_SEL") == 0 )
            {
               AV18TFOperacionesNombreRef_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFOPERACIONESIMPORTE") == 0 )
            {
               AV19TFOperacionesImporte = NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, ".");
               AV20TFOperacionesImporte_To = NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADOPERACIONESREFOPTIONS' Routine */
         returnInSub = false;
         AV15TFOperacionesRef = AV31SearchTxt;
         AV16TFOperacionesRef_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV14TFOperacionesTipo_Sels ,
                                              AV11TFOperacionesId ,
                                              AV12TFOperacionesId_To ,
                                              AV14TFOperacionesTipo_Sels.Count ,
                                              AV16TFOperacionesRef_Sel ,
                                              AV15TFOperacionesRef ,
                                              AV18TFOperacionesNombreRef_Sel ,
                                              AV17TFOperacionesNombreRef ,
                                              AV19TFOperacionesImporte ,
                                              AV20TFOperacionesImporte_To ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A570OperacionesImporte ,
                                              AV53FilterFullText ,
                                              A577OperacionesEstado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFOperacionesRef = StringUtil.PadR( StringUtil.RTrim( AV15TFOperacionesRef), 25, "%");
         lV17TFOperacionesNombreRef = StringUtil.PadR( StringUtil.RTrim( AV17TFOperacionesNombreRef), 120, "%");
         /* Using cursor P00D62 */
         pr_default.execute(0, new Object[] {AV11TFOperacionesId, AV12TFOperacionesId_To, lV15TFOperacionesRef, AV16TFOperacionesRef_Sel, lV17TFOperacionesNombreRef, AV18TFOperacionesNombreRef_Sel, AV19TFOperacionesImporte, AV20TFOperacionesImporte_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD62 = false;
            A555OperacionesRef = P00D62_A555OperacionesRef[0];
            n555OperacionesRef = P00D62_n555OperacionesRef[0];
            A577OperacionesEstado = P00D62_A577OperacionesEstado[0];
            n577OperacionesEstado = P00D62_n577OperacionesEstado[0];
            A570OperacionesImporte = P00D62_A570OperacionesImporte[0];
            n570OperacionesImporte = P00D62_n570OperacionesImporte[0];
            A657OperacionesNombreRef = P00D62_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00D62_n657OperacionesNombreRef[0];
            A649OperacionesTipo = P00D62_A649OperacionesTipo[0];
            n649OperacionesTipo = P00D62_n649OperacionesTipo[0];
            A554OperacionesId = P00D62_A554OperacionesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00D62_A555OperacionesRef[0], A555OperacionesRef) == 0 ) )
               {
                  BRKD62 = false;
                  A554OperacionesId = P00D62_A554OperacionesId[0];
                  AV41count = (long)(AV41count+1);
                  BRKD62 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A555OperacionesRef)) ? "<#Empty#>" : A555OperacionesRef);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRKD62 )
            {
               BRKD62 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADOPERACIONESNOMBREREFOPTIONS' Routine */
         returnInSub = false;
         AV17TFOperacionesNombreRef = AV31SearchTxt;
         AV18TFOperacionesNombreRef_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV14TFOperacionesTipo_Sels ,
                                              AV11TFOperacionesId ,
                                              AV12TFOperacionesId_To ,
                                              AV14TFOperacionesTipo_Sels.Count ,
                                              AV16TFOperacionesRef_Sel ,
                                              AV15TFOperacionesRef ,
                                              AV18TFOperacionesNombreRef_Sel ,
                                              AV17TFOperacionesNombreRef ,
                                              AV19TFOperacionesImporte ,
                                              AV20TFOperacionesImporte_To ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A570OperacionesImporte ,
                                              AV53FilterFullText ,
                                              A577OperacionesEstado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFOperacionesRef = StringUtil.PadR( StringUtil.RTrim( AV15TFOperacionesRef), 25, "%");
         lV17TFOperacionesNombreRef = StringUtil.PadR( StringUtil.RTrim( AV17TFOperacionesNombreRef), 120, "%");
         /* Using cursor P00D63 */
         pr_default.execute(1, new Object[] {AV11TFOperacionesId, AV12TFOperacionesId_To, lV15TFOperacionesRef, AV16TFOperacionesRef_Sel, lV17TFOperacionesNombreRef, AV18TFOperacionesNombreRef_Sel, AV19TFOperacionesImporte, AV20TFOperacionesImporte_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD64 = false;
            A577OperacionesEstado = P00D63_A577OperacionesEstado[0];
            n577OperacionesEstado = P00D63_n577OperacionesEstado[0];
            A657OperacionesNombreRef = P00D63_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00D63_n657OperacionesNombreRef[0];
            A570OperacionesImporte = P00D63_A570OperacionesImporte[0];
            n570OperacionesImporte = P00D63_n570OperacionesImporte[0];
            A555OperacionesRef = P00D63_A555OperacionesRef[0];
            n555OperacionesRef = P00D63_n555OperacionesRef[0];
            A649OperacionesTipo = P00D63_A649OperacionesTipo[0];
            n649OperacionesTipo = P00D63_n649OperacionesTipo[0];
            A554OperacionesId = P00D63_A554OperacionesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00D63_A657OperacionesNombreRef[0], A657OperacionesNombreRef) == 0 ) )
               {
                  BRKD64 = false;
                  A554OperacionesId = P00D63_A554OperacionesId[0];
                  AV41count = (long)(AV41count+1);
                  BRKD64 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A657OperacionesNombreRef)) ? "<#Empty#>" : A657OperacionesNombreRef);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRKD64 )
            {
               BRKD64 = true;
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV13TFOperacionesTipo_SelsJson = "";
         AV14TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV15TFOperacionesRef = "";
         AV16TFOperacionesRef_Sel = "";
         AV17TFOperacionesNombreRef = "";
         AV18TFOperacionesNombreRef_Sel = "";
         lV53FilterFullText = "";
         lV15TFOperacionesRef = "";
         lV17TFOperacionesNombreRef = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A577OperacionesEstado = "";
         P00D62_A555OperacionesRef = new string[] {""} ;
         P00D62_n555OperacionesRef = new bool[] {false} ;
         P00D62_A577OperacionesEstado = new string[] {""} ;
         P00D62_n577OperacionesEstado = new bool[] {false} ;
         P00D62_A570OperacionesImporte = new decimal[1] ;
         P00D62_n570OperacionesImporte = new bool[] {false} ;
         P00D62_A657OperacionesNombreRef = new string[] {""} ;
         P00D62_n657OperacionesNombreRef = new bool[] {false} ;
         P00D62_A649OperacionesTipo = new string[] {""} ;
         P00D62_n649OperacionesTipo = new bool[] {false} ;
         P00D62_A554OperacionesId = new long[1] ;
         AV36Option = "";
         P00D63_A577OperacionesEstado = new string[] {""} ;
         P00D63_n577OperacionesEstado = new bool[] {false} ;
         P00D63_A657OperacionesNombreRef = new string[] {""} ;
         P00D63_n657OperacionesNombreRef = new bool[] {false} ;
         P00D63_A570OperacionesImporte = new decimal[1] ;
         P00D63_n570OperacionesImporte = new bool[] {false} ;
         P00D63_A555OperacionesRef = new string[] {""} ;
         P00D63_n555OperacionesRef = new bool[] {false} ;
         P00D63_A649OperacionesTipo = new string[] {""} ;
         P00D63_n649OperacionesTipo = new bool[] {false} ;
         P00D63_A554OperacionesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacionesidpromptgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D62_A555OperacionesRef, P00D62_n555OperacionesRef, P00D62_A577OperacionesEstado, P00D62_n577OperacionesEstado, P00D62_A570OperacionesImporte, P00D62_n570OperacionesImporte, P00D62_A657OperacionesNombreRef, P00D62_n657OperacionesNombreRef, P00D62_A649OperacionesTipo, P00D62_n649OperacionesTipo,
               P00D62_A554OperacionesId
               }
               , new Object[] {
               P00D63_A577OperacionesEstado, P00D63_n577OperacionesEstado, P00D63_A657OperacionesNombreRef, P00D63_n657OperacionesNombreRef, P00D63_A570OperacionesImporte, P00D63_n570OperacionesImporte, P00D63_A555OperacionesRef, P00D63_n555OperacionesRef, P00D63_A649OperacionesTipo, P00D63_n649OperacionesTipo,
               P00D63_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private int AV55GXV1 ;
      private int AV14TFOperacionesTipo_Sels_Count ;
      private long AV11TFOperacionesId ;
      private long AV12TFOperacionesId_To ;
      private long A554OperacionesId ;
      private long AV41count ;
      private decimal AV19TFOperacionesImporte ;
      private decimal AV20TFOperacionesImporte_To ;
      private decimal A570OperacionesImporte ;
      private string AV15TFOperacionesRef ;
      private string AV16TFOperacionesRef_Sel ;
      private string AV17TFOperacionesNombreRef ;
      private string AV18TFOperacionesNombreRef_Sel ;
      private string lV15TFOperacionesRef ;
      private string lV17TFOperacionesNombreRef ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string A577OperacionesEstado ;
      private bool returnInSub ;
      private bool BRKD62 ;
      private bool n555OperacionesRef ;
      private bool n577OperacionesEstado ;
      private bool n570OperacionesImporte ;
      private bool n657OperacionesNombreRef ;
      private bool n649OperacionesTipo ;
      private bool BRKD64 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV13TFOperacionesTipo_SelsJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string lV53FilterFullText ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFOperacionesTipo_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00D62_A555OperacionesRef ;
      private bool[] P00D62_n555OperacionesRef ;
      private string[] P00D62_A577OperacionesEstado ;
      private bool[] P00D62_n577OperacionesEstado ;
      private decimal[] P00D62_A570OperacionesImporte ;
      private bool[] P00D62_n570OperacionesImporte ;
      private string[] P00D62_A657OperacionesNombreRef ;
      private bool[] P00D62_n657OperacionesNombreRef ;
      private string[] P00D62_A649OperacionesTipo ;
      private bool[] P00D62_n649OperacionesTipo ;
      private long[] P00D62_A554OperacionesId ;
      private string[] P00D63_A577OperacionesEstado ;
      private bool[] P00D63_n577OperacionesEstado ;
      private string[] P00D63_A657OperacionesNombreRef ;
      private bool[] P00D63_n657OperacionesNombreRef ;
      private decimal[] P00D63_A570OperacionesImporte ;
      private bool[] P00D63_n570OperacionesImporte ;
      private string[] P00D63_A555OperacionesRef ;
      private bool[] P00D63_n555OperacionesRef ;
      private string[] P00D63_A649OperacionesTipo ;
      private bool[] P00D63_n649OperacionesTipo ;
      private long[] P00D63_A554OperacionesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class operacionesidpromptgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D62( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV14TFOperacionesTipo_Sels ,
                                             long AV11TFOperacionesId ,
                                             long AV12TFOperacionesId_To ,
                                             int AV14TFOperacionesTipo_Sels_Count ,
                                             string AV16TFOperacionesRef_Sel ,
                                             string AV15TFOperacionesRef ,
                                             string AV18TFOperacionesNombreRef_Sel ,
                                             string AV17TFOperacionesNombreRef ,
                                             decimal AV19TFOperacionesImporte ,
                                             decimal AV20TFOperacionesImporte_To ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             decimal A570OperacionesImporte ,
                                             string AV53FilterFullText ,
                                             string A577OperacionesEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [OperacionesRef], [OperacionesEstado], [OperacionesImporte], [OperacionesNombreRef], [OperacionesTipo], [OperacionesId] FROM [Operaciones]";
         AddWhere(sWhereString, "([OperacionesImporte] < 0)");
         AddWhere(sWhereString, "([OperacionesEstado] = 'PND')");
         if ( ! (0==AV11TFOperacionesId) )
         {
            AddWhere(sWhereString, "([OperacionesId] >= @AV11TFOperacionesId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV12TFOperacionesId_To) )
         {
            AddWhere(sWhereString, "([OperacionesId] <= @AV12TFOperacionesId_To)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV14TFOperacionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFOperacionesTipo_Sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFOperacionesRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFOperacionesRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesRef]) like UPPER(@lV15TFOperacionesRef))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFOperacionesRef_Sel)) && ! ( StringUtil.StrCmp(AV16TFOperacionesRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesRef] = @AV16TFOperacionesRef_Sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFOperacionesRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesRef] IS NULL or ([OperacionesRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFOperacionesNombreRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFOperacionesNombreRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesNombreRef]) like UPPER(@lV17TFOperacionesNombreRef))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFOperacionesNombreRef_Sel)) && ! ( StringUtil.StrCmp(AV18TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] = @AV18TFOperacionesNombreRef_Sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] IS NULL or ([OperacionesNombreRef] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFOperacionesImporte) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] >= @AV19TFOperacionesImporte)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFOperacionesImporte_To) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] <= @AV20TFOperacionesImporte_To)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OperacionesRef]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D63( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV14TFOperacionesTipo_Sels ,
                                             long AV11TFOperacionesId ,
                                             long AV12TFOperacionesId_To ,
                                             int AV14TFOperacionesTipo_Sels_Count ,
                                             string AV16TFOperacionesRef_Sel ,
                                             string AV15TFOperacionesRef ,
                                             string AV18TFOperacionesNombreRef_Sel ,
                                             string AV17TFOperacionesNombreRef ,
                                             decimal AV19TFOperacionesImporte ,
                                             decimal AV20TFOperacionesImporte_To ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             decimal A570OperacionesImporte ,
                                             string AV53FilterFullText ,
                                             string A577OperacionesEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [OperacionesEstado], [OperacionesNombreRef], [OperacionesImporte], [OperacionesRef], [OperacionesTipo], [OperacionesId] FROM [Operaciones]";
         AddWhere(sWhereString, "([OperacionesImporte] < 0)");
         AddWhere(sWhereString, "([OperacionesEstado] = 'PND')");
         if ( ! (0==AV11TFOperacionesId) )
         {
            AddWhere(sWhereString, "([OperacionesId] >= @AV11TFOperacionesId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV12TFOperacionesId_To) )
         {
            AddWhere(sWhereString, "([OperacionesId] <= @AV12TFOperacionesId_To)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV14TFOperacionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFOperacionesTipo_Sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFOperacionesRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFOperacionesRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesRef]) like UPPER(@lV15TFOperacionesRef))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFOperacionesRef_Sel)) && ! ( StringUtil.StrCmp(AV16TFOperacionesRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesRef] = @AV16TFOperacionesRef_Sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFOperacionesRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesRef] IS NULL or ([OperacionesRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFOperacionesNombreRef_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFOperacionesNombreRef)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesNombreRef]) like UPPER(@lV17TFOperacionesNombreRef))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFOperacionesNombreRef_Sel)) && ! ( StringUtil.StrCmp(AV18TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] = @AV18TFOperacionesNombreRef_Sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFOperacionesNombreRef_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesNombreRef] IS NULL or ([OperacionesNombreRef] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFOperacionesImporte) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] >= @AV19TFOperacionesImporte)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFOperacionesImporte_To) )
         {
            AddWhere(sWhereString, "([OperacionesImporte] <= @AV20TFOperacionesImporte_To)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OperacionesNombreRef]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00D62(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] );
               case 1 :
                     return conditional_P00D63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] );
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
          Object[] prmP00D62;
          prmP00D62 = new Object[] {
          new ParDef("@AV11TFOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFOperacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFOperacionesRef",GXType.Char,25,0) ,
          new ParDef("@AV16TFOperacionesRef_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV17TFOperacionesNombreRef",GXType.Char,120,0) ,
          new ParDef("@AV18TFOperacionesNombreRef_Sel",GXType.NChar,120,0) ,
          new ParDef("@AV19TFOperacionesImporte",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFOperacionesImporte_To",GXType.Decimal,18,2)
          };
          Object[] prmP00D63;
          prmP00D63 = new Object[] {
          new ParDef("@AV11TFOperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFOperacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFOperacionesRef",GXType.Char,25,0) ,
          new ParDef("@AV16TFOperacionesRef_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV17TFOperacionesNombreRef",GXType.Char,120,0) ,
          new ParDef("@AV18TFOperacionesNombreRef_Sel",GXType.NChar,120,0) ,
          new ParDef("@AV19TFOperacionesImporte",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFOperacionesImporte_To",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00D62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D63,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 120);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 120);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.operacionesidpromptgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class operacionesidpromptgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "OperacionesIdPromptGetFilterData" )]
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
          if ( ! ProcessHeaders("operacionesidpromptgetfilterdata") )
          {
             return  ;
          }
          operacionesidpromptgetfilterdata worker = new operacionesidpromptgetfilterdata(context);
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
