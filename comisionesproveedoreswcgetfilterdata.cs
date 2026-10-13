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
   public class comisionesproveedoreswcgetfilterdata : GXProcedure
   {
      public comisionesproveedoreswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesproveedoreswcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PROVEEDOREMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDOREMAILOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PROVEEDORTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORTELEFONOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV32Session.Get("ComisionesProveedoresWCGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesProveedoresWCGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ComisionesProveedoresWCGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV13TFProveedorNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV14TFProveedorNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV15TFProveedorEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV16TFProveedorEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV17TFProveedorTelefono = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV18TFProveedorTelefono_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV19TFProveedorEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFProveedorEstado_Sels.FromJSonString(AV19TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&COMISIONESID") == 0 )
            {
               AV43ComisionesID = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProveedorNombre = AV21SearchTxt;
         AV14TFProveedorNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV20TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorEmail_Sel ,
                                              AV15TFProveedorEmail ,
                                              AV18TFProveedorTelefono_Sel ,
                                              AV17TFProveedorTelefono ,
                                              AV20TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A433ProveedorEmail ,
                                              A430ProveedorTelefono ,
                                              AV43ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFProveedorEmail), "%", "");
         lV17TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorTelefono), 20, "%");
         /* Using cursor P006F2 */
         pr_default.execute(0, new Object[] {AV43ComisionesID, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorEmail, AV16TFProveedorEmail_Sel, lV17TFProveedorTelefono, AV18TFProveedorTelefono_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6F2 = false;
            A133ProveedorID = P006F2_A133ProveedorID[0];
            A503ComisionesID = P006F2_A503ComisionesID[0];
            A344ProveedorEstado = P006F2_A344ProveedorEstado[0];
            A430ProveedorTelefono = P006F2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F2_n430ProveedorTelefono[0];
            A433ProveedorEmail = P006F2_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F2_n433ProveedorEmail[0];
            A282ProveedorNombre = P006F2_A282ProveedorNombre[0];
            A344ProveedorEstado = P006F2_A344ProveedorEstado[0];
            A430ProveedorTelefono = P006F2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F2_n430ProveedorTelefono[0];
            A433ProveedorEmail = P006F2_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F2_n433ProveedorEmail[0];
            A282ProveedorNombre = P006F2_A282ProveedorNombre[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006F2_A503ComisionesID[0] == A503ComisionesID ) && ( P006F2_A133ProveedorID[0] == A133ProveedorID ) )
            {
               BRK6F2 = false;
               AV31count = (long)(AV31count+1);
               BRK6F2 = true;
               pr_default.readNext(0);
            }
            AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
            AV25InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV25InsertIndex = (int)(AV25InsertIndex+1);
            }
            AV27Options.Add(AV26Option, AV25InsertIndex);
            AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
            if ( AV27Options.Count == AV22SkipItems + 11 )
            {
               AV27Options.RemoveItem(AV27Options.Count);
               AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
            }
            if ( ! BRK6F2 )
            {
               BRK6F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDOREMAILOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorEmail = AV21SearchTxt;
         AV16TFProveedorEmail_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV20TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorEmail_Sel ,
                                              AV15TFProveedorEmail ,
                                              AV18TFProveedorTelefono_Sel ,
                                              AV17TFProveedorTelefono ,
                                              AV20TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A433ProveedorEmail ,
                                              A430ProveedorTelefono ,
                                              AV43ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFProveedorEmail), "%", "");
         lV17TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorTelefono), 20, "%");
         /* Using cursor P006F3 */
         pr_default.execute(1, new Object[] {AV43ComisionesID, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorEmail, AV16TFProveedorEmail_Sel, lV17TFProveedorTelefono, AV18TFProveedorTelefono_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6F4 = false;
            A503ComisionesID = P006F3_A503ComisionesID[0];
            A433ProveedorEmail = P006F3_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F3_n433ProveedorEmail[0];
            A344ProveedorEstado = P006F3_A344ProveedorEstado[0];
            A430ProveedorTelefono = P006F3_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F3_n430ProveedorTelefono[0];
            A282ProveedorNombre = P006F3_A282ProveedorNombre[0];
            A133ProveedorID = P006F3_A133ProveedorID[0];
            A433ProveedorEmail = P006F3_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F3_n433ProveedorEmail[0];
            A344ProveedorEstado = P006F3_A344ProveedorEstado[0];
            A430ProveedorTelefono = P006F3_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F3_n430ProveedorTelefono[0];
            A282ProveedorNombre = P006F3_A282ProveedorNombre[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006F3_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006F3_A433ProveedorEmail[0], A433ProveedorEmail) == 0 ) )
            {
               BRK6F4 = false;
               A133ProveedorID = P006F3_A133ProveedorID[0];
               AV31count = (long)(AV31count+1);
               BRK6F4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? "<#Empty#>" : A433ProveedorEmail);
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
            if ( ! BRK6F4 )
            {
               BRK6F4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROVEEDORTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorTelefono = AV21SearchTxt;
         AV18TFProveedorTelefono_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV20TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorEmail_Sel ,
                                              AV15TFProveedorEmail ,
                                              AV18TFProveedorTelefono_Sel ,
                                              AV17TFProveedorTelefono ,
                                              AV20TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A433ProveedorEmail ,
                                              A430ProveedorTelefono ,
                                              AV43ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV15TFProveedorEmail), "%", "");
         lV17TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorTelefono), 20, "%");
         /* Using cursor P006F4 */
         pr_default.execute(2, new Object[] {AV43ComisionesID, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorEmail, AV16TFProveedorEmail_Sel, lV17TFProveedorTelefono, AV18TFProveedorTelefono_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6F6 = false;
            A503ComisionesID = P006F4_A503ComisionesID[0];
            A430ProveedorTelefono = P006F4_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F4_n430ProveedorTelefono[0];
            A344ProveedorEstado = P006F4_A344ProveedorEstado[0];
            A433ProveedorEmail = P006F4_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F4_n433ProveedorEmail[0];
            A282ProveedorNombre = P006F4_A282ProveedorNombre[0];
            A133ProveedorID = P006F4_A133ProveedorID[0];
            A430ProveedorTelefono = P006F4_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006F4_n430ProveedorTelefono[0];
            A344ProveedorEstado = P006F4_A344ProveedorEstado[0];
            A433ProveedorEmail = P006F4_A433ProveedorEmail[0];
            n433ProveedorEmail = P006F4_n433ProveedorEmail[0];
            A282ProveedorNombre = P006F4_A282ProveedorNombre[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P006F4_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006F4_A430ProveedorTelefono[0], A430ProveedorTelefono) == 0 ) )
            {
               BRK6F6 = false;
               A133ProveedorID = P006F4_A133ProveedorID[0];
               AV31count = (long)(AV31count+1);
               BRK6F6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? "<#Empty#>" : A430ProveedorTelefono);
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
            if ( ! BRK6F6 )
            {
               BRK6F6 = true;
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
         AV13TFProveedorNombre = "";
         AV14TFProveedorNombre_Sel = "";
         AV15TFProveedorEmail = "";
         AV16TFProveedorEmail_Sel = "";
         AV17TFProveedorTelefono = "";
         AV18TFProveedorTelefono_Sel = "";
         AV19TFProveedorEstado_SelsJson = "";
         AV20TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         lV13TFProveedorNombre = "";
         lV15TFProveedorEmail = "";
         lV17TFProveedorTelefono = "";
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A433ProveedorEmail = "";
         A430ProveedorTelefono = "";
         P006F2_A133ProveedorID = new long[1] ;
         P006F2_A503ComisionesID = new long[1] ;
         P006F2_A344ProveedorEstado = new string[] {""} ;
         P006F2_A430ProveedorTelefono = new string[] {""} ;
         P006F2_n430ProveedorTelefono = new bool[] {false} ;
         P006F2_A433ProveedorEmail = new string[] {""} ;
         P006F2_n433ProveedorEmail = new bool[] {false} ;
         P006F2_A282ProveedorNombre = new string[] {""} ;
         AV26Option = "";
         P006F3_A503ComisionesID = new long[1] ;
         P006F3_A433ProveedorEmail = new string[] {""} ;
         P006F3_n433ProveedorEmail = new bool[] {false} ;
         P006F3_A344ProveedorEstado = new string[] {""} ;
         P006F3_A430ProveedorTelefono = new string[] {""} ;
         P006F3_n430ProveedorTelefono = new bool[] {false} ;
         P006F3_A282ProveedorNombre = new string[] {""} ;
         P006F3_A133ProveedorID = new long[1] ;
         P006F4_A503ComisionesID = new long[1] ;
         P006F4_A430ProveedorTelefono = new string[] {""} ;
         P006F4_n430ProveedorTelefono = new bool[] {false} ;
         P006F4_A344ProveedorEstado = new string[] {""} ;
         P006F4_A433ProveedorEmail = new string[] {""} ;
         P006F4_n433ProveedorEmail = new bool[] {false} ;
         P006F4_A282ProveedorNombre = new string[] {""} ;
         P006F4_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesproveedoreswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006F2_A133ProveedorID, P006F2_A503ComisionesID, P006F2_A344ProveedorEstado, P006F2_A430ProveedorTelefono, P006F2_n430ProveedorTelefono, P006F2_A433ProveedorEmail, P006F2_n433ProveedorEmail, P006F2_A282ProveedorNombre
               }
               , new Object[] {
               P006F3_A503ComisionesID, P006F3_A433ProveedorEmail, P006F3_n433ProveedorEmail, P006F3_A344ProveedorEstado, P006F3_A430ProveedorTelefono, P006F3_n430ProveedorTelefono, P006F3_A282ProveedorNombre, P006F3_A133ProveedorID
               }
               , new Object[] {
               P006F4_A503ComisionesID, P006F4_A430ProveedorTelefono, P006F4_n430ProveedorTelefono, P006F4_A344ProveedorEstado, P006F4_A433ProveedorEmail, P006F4_n433ProveedorEmail, P006F4_A282ProveedorNombre, P006F4_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV44GXV1 ;
      private int AV20TFProveedorEstado_Sels_Count ;
      private int AV25InsertIndex ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long AV43ComisionesID ;
      private long A133ProveedorID ;
      private long A503ComisionesID ;
      private long AV31count ;
      private string AV13TFProveedorNombre ;
      private string AV14TFProveedorNombre_Sel ;
      private string AV17TFProveedorTelefono ;
      private string AV18TFProveedorTelefono_Sel ;
      private string lV13TFProveedorNombre ;
      private string lV17TFProveedorTelefono ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A430ProveedorTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK6F2 ;
      private bool n430ProveedorTelefono ;
      private bool n433ProveedorEmail ;
      private bool BRK6F4 ;
      private bool BRK6F6 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFProveedorEstado_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV15TFProveedorEmail ;
      private string AV16TFProveedorEmail_Sel ;
      private string lV15TFProveedorEmail ;
      private string A433ProveedorEmail ;
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
      private GxSimpleCollection<string> AV20TFProveedorEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P006F2_A133ProveedorID ;
      private long[] P006F2_A503ComisionesID ;
      private string[] P006F2_A344ProveedorEstado ;
      private string[] P006F2_A430ProveedorTelefono ;
      private bool[] P006F2_n430ProveedorTelefono ;
      private string[] P006F2_A433ProveedorEmail ;
      private bool[] P006F2_n433ProveedorEmail ;
      private string[] P006F2_A282ProveedorNombre ;
      private long[] P006F3_A503ComisionesID ;
      private string[] P006F3_A433ProveedorEmail ;
      private bool[] P006F3_n433ProveedorEmail ;
      private string[] P006F3_A344ProveedorEstado ;
      private string[] P006F3_A430ProveedorTelefono ;
      private bool[] P006F3_n430ProveedorTelefono ;
      private string[] P006F3_A282ProveedorNombre ;
      private long[] P006F3_A133ProveedorID ;
      private long[] P006F4_A503ComisionesID ;
      private string[] P006F4_A430ProveedorTelefono ;
      private bool[] P006F4_n430ProveedorTelefono ;
      private string[] P006F4_A344ProveedorEstado ;
      private string[] P006F4_A433ProveedorEmail ;
      private bool[] P006F4_n433ProveedorEmail ;
      private string[] P006F4_A282ProveedorNombre ;
      private long[] P006F4_A133ProveedorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisionesproveedoreswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006F2( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV20TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorEmail_Sel ,
                                             string AV15TFProveedorEmail ,
                                             string AV18TFProveedorTelefono_Sel ,
                                             string AV17TFProveedorTelefono ,
                                             int AV20TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A433ProveedorEmail ,
                                             string A430ProveedorTelefono ,
                                             long AV43ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedorID], T1.[ComisionesID], T2.[ProveedorEstado], T2.[ProveedorTelefono], T2.[ProveedorEmail], T2.[ProveedorNombre] FROM ([ComisionesProveedores] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV43ComisionesID)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorEmail]) like UPPER(@lV15TFProveedorEmail))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] = @AV16TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] IS NULL or (T2.[ProveedorEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorTelefono]) like UPPER(@lV17TFProveedorTelefono))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] = @AV18TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] IS NULL or (T2.[ProveedorTelefono] = ''))");
         }
         if ( AV20TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFProveedorEstado_Sels, "T2.[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T1.[ProveedorID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006F3( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV20TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorEmail_Sel ,
                                             string AV15TFProveedorEmail ,
                                             string AV18TFProveedorTelefono_Sel ,
                                             string AV17TFProveedorTelefono ,
                                             int AV20TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A433ProveedorEmail ,
                                             string A430ProveedorTelefono ,
                                             long AV43ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ComisionesID], T2.[ProveedorEmail], T2.[ProveedorEstado], T2.[ProveedorTelefono], T2.[ProveedorNombre], T1.[ProveedorID] FROM ([ComisionesProveedores] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV43ComisionesID)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorEmail]) like UPPER(@lV15TFProveedorEmail))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] = @AV16TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] IS NULL or (T2.[ProveedorEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorTelefono]) like UPPER(@lV17TFProveedorTelefono))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] = @AV18TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] IS NULL or (T2.[ProveedorTelefono] = ''))");
         }
         if ( AV20TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFProveedorEstado_Sels, "T2.[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProveedorEmail]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006F4( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV20TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorEmail_Sel ,
                                             string AV15TFProveedorEmail ,
                                             string AV18TFProveedorTelefono_Sel ,
                                             string AV17TFProveedorTelefono ,
                                             int AV20TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A433ProveedorEmail ,
                                             string A430ProveedorTelefono ,
                                             long AV43ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ComisionesID], T2.[ProveedorTelefono], T2.[ProveedorEstado], T2.[ProveedorEmail], T2.[ProveedorNombre], T1.[ProveedorID] FROM ([ComisionesProveedores] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV43ComisionesID)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorEmail]) like UPPER(@lV15TFProveedorEmail))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] = @AV16TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorEmail] IS NULL or (T2.[ProveedorEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorTelefono]) like UPPER(@lV17TFProveedorTelefono))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] = @AV18TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorTelefono] IS NULL or (T2.[ProveedorTelefono] = ''))");
         }
         if ( AV20TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFProveedorEstado_Sels, "T2.[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProveedorTelefono]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006F2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] );
               case 1 :
                     return conditional_P006F3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] );
               case 2 :
                     return conditional_P006F4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] );
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
          Object[] prmP006F2;
          prmP006F2 = new Object[] {
          new ParDef("@AV43ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV16TFProveedorEmail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV17TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV18TFProveedorTelefono_Sel",GXType.NChar,20,0)
          };
          Object[] prmP006F3;
          prmP006F3 = new Object[] {
          new ParDef("@AV43ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV16TFProveedorEmail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV17TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV18TFProveedorTelefono_Sel",GXType.NChar,20,0)
          };
          Object[] prmP006F4;
          prmP006F4 = new Object[] {
          new ParDef("@AV43ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV16TFProveedorEmail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV17TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV18TFProveedorTelefono_Sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 80);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 80);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisionesproveedoreswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisionesproveedoreswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesProveedoresWCGetFilterData" )]
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
          if ( ! ProcessHeaders("comisionesproveedoreswcgetfilterdata") )
          {
             return  ;
          }
          comisionesproveedoreswcgetfilterdata worker = new comisionesproveedoreswcgetfilterdata(context);
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
