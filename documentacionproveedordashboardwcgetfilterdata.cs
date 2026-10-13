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
   public class documentacionproveedordashboardwcgetfilterdata : GXProcedure
   {
      public documentacionproveedordashboardwcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionproveedordashboardwcgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedorDashboard", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV26MaxItems = 10;
            AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
            AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDORTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORTELEFONOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDORDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORDIRECCIONOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PROVEEDOREMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDOREMAILOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("DocumentacionProveedorDashboardWCGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionProveedorDashboardWCGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("DocumentacionProveedorDashboardWCGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV13TFProveedorNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV14TFProveedorNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV15TFProveedorTelefono = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV16TFProveedorTelefono_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV17TFProveedorDireccion = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV18TFProveedorDireccion_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV19TFProveedorEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV20TFProveedorEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV21TFProveedorEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV22TFProveedorEstado_Sels.FromJSonString(AV21TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&DOCUMENTACIONID") == 0 )
            {
               AV46DocumentacionId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProveedorNombre = AV23SearchTxt;
         AV14TFProveedorNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV22TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorTelefono_Sel ,
                                              AV15TFProveedorTelefono ,
                                              AV18TFProveedorDireccion_Sel ,
                                              AV17TFProveedorDireccion ,
                                              AV20TFProveedorEmail_Sel ,
                                              AV19TFProveedorEmail ,
                                              AV22TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV45FilterFullText ,
                                              AV46DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedorTelefono), 20, "%");
         lV17TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV17TFProveedorDireccion), "%", "");
         lV19TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFProveedorEmail), "%", "");
         /* Using cursor P00672 */
         pr_default.execute(0, new Object[] {AV46DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorTelefono, AV16TFProveedorTelefono_Sel, lV17TFProveedorDireccion, AV18TFProveedorDireccion_Sel, lV19TFProveedorEmail, AV20TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK672 = false;
            A488DocumentacionId = P00672_A488DocumentacionId[0];
            n488DocumentacionId = P00672_n488DocumentacionId[0];
            A282ProveedorNombre = P00672_A282ProveedorNombre[0];
            A344ProveedorEstado = P00672_A344ProveedorEstado[0];
            A433ProveedorEmail = P00672_A433ProveedorEmail[0];
            n433ProveedorEmail = P00672_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00672_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00672_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00672_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00672_n430ProveedorTelefono[0];
            A133ProveedorID = P00672_A133ProveedorID[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00672_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00672_A282ProveedorNombre[0], A282ProveedorNombre) == 0 ) )
               {
                  BRK672 = false;
                  A133ProveedorID = P00672_A133ProveedorID[0];
                  AV33count = (long)(AV33count+1);
                  BRK672 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK672 )
            {
               BRK672 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorTelefono = AV23SearchTxt;
         AV16TFProveedorTelefono_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV22TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorTelefono_Sel ,
                                              AV15TFProveedorTelefono ,
                                              AV18TFProveedorDireccion_Sel ,
                                              AV17TFProveedorDireccion ,
                                              AV20TFProveedorEmail_Sel ,
                                              AV19TFProveedorEmail ,
                                              AV22TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV45FilterFullText ,
                                              AV46DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedorTelefono), 20, "%");
         lV17TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV17TFProveedorDireccion), "%", "");
         lV19TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFProveedorEmail), "%", "");
         /* Using cursor P00673 */
         pr_default.execute(1, new Object[] {AV46DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorTelefono, AV16TFProveedorTelefono_Sel, lV17TFProveedorDireccion, AV18TFProveedorDireccion_Sel, lV19TFProveedorEmail, AV20TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK674 = false;
            A488DocumentacionId = P00673_A488DocumentacionId[0];
            n488DocumentacionId = P00673_n488DocumentacionId[0];
            A430ProveedorTelefono = P00673_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00673_n430ProveedorTelefono[0];
            A344ProveedorEstado = P00673_A344ProveedorEstado[0];
            A433ProveedorEmail = P00673_A433ProveedorEmail[0];
            n433ProveedorEmail = P00673_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00673_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00673_n431ProveedorDireccion[0];
            A282ProveedorNombre = P00673_A282ProveedorNombre[0];
            A133ProveedorID = P00673_A133ProveedorID[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00673_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00673_A430ProveedorTelefono[0], A430ProveedorTelefono) == 0 ) )
               {
                  BRK674 = false;
                  A133ProveedorID = P00673_A133ProveedorID[0];
                  AV33count = (long)(AV33count+1);
                  BRK674 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? "<#Empty#>" : A430ProveedorTelefono);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK674 )
            {
               BRK674 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROVEEDORDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorDireccion = AV23SearchTxt;
         AV18TFProveedorDireccion_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV22TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorTelefono_Sel ,
                                              AV15TFProveedorTelefono ,
                                              AV18TFProveedorDireccion_Sel ,
                                              AV17TFProveedorDireccion ,
                                              AV20TFProveedorEmail_Sel ,
                                              AV19TFProveedorEmail ,
                                              AV22TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV45FilterFullText ,
                                              AV46DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedorTelefono), 20, "%");
         lV17TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV17TFProveedorDireccion), "%", "");
         lV19TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFProveedorEmail), "%", "");
         /* Using cursor P00674 */
         pr_default.execute(2, new Object[] {AV46DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorTelefono, AV16TFProveedorTelefono_Sel, lV17TFProveedorDireccion, AV18TFProveedorDireccion_Sel, lV19TFProveedorEmail, AV20TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK676 = false;
            A488DocumentacionId = P00674_A488DocumentacionId[0];
            n488DocumentacionId = P00674_n488DocumentacionId[0];
            A431ProveedorDireccion = P00674_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00674_n431ProveedorDireccion[0];
            A344ProveedorEstado = P00674_A344ProveedorEstado[0];
            A433ProveedorEmail = P00674_A433ProveedorEmail[0];
            n433ProveedorEmail = P00674_n433ProveedorEmail[0];
            A430ProveedorTelefono = P00674_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00674_n430ProveedorTelefono[0];
            A282ProveedorNombre = P00674_A282ProveedorNombre[0];
            A133ProveedorID = P00674_A133ProveedorID[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00674_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00674_A431ProveedorDireccion[0], A431ProveedorDireccion) == 0 ) )
               {
                  BRK676 = false;
                  A133ProveedorID = P00674_A133ProveedorID[0];
                  AV33count = (long)(AV33count+1);
                  BRK676 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? "<#Empty#>" : A431ProveedorDireccion);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK676 )
            {
               BRK676 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROVEEDOREMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFProveedorEmail = AV23SearchTxt;
         AV20TFProveedorEmail_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV22TFProveedorEstado_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV14TFProveedorNombre_Sel ,
                                              AV13TFProveedorNombre ,
                                              AV16TFProveedorTelefono_Sel ,
                                              AV15TFProveedorTelefono ,
                                              AV18TFProveedorDireccion_Sel ,
                                              AV17TFProveedorDireccion ,
                                              AV20TFProveedorEmail_Sel ,
                                              AV19TFProveedorEmail ,
                                              AV22TFProveedorEstado_Sels.Count ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV45FilterFullText ,
                                              AV46DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProveedorNombre), 80, "%");
         lV15TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedorTelefono), 20, "%");
         lV17TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV17TFProveedorDireccion), "%", "");
         lV19TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV19TFProveedorEmail), "%", "");
         /* Using cursor P00675 */
         pr_default.execute(3, new Object[] {AV46DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, lV13TFProveedorNombre, AV14TFProveedorNombre_Sel, lV15TFProveedorTelefono, AV16TFProveedorTelefono_Sel, lV17TFProveedorDireccion, AV18TFProveedorDireccion_Sel, lV19TFProveedorEmail, AV20TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK678 = false;
            A488DocumentacionId = P00675_A488DocumentacionId[0];
            n488DocumentacionId = P00675_n488DocumentacionId[0];
            A433ProveedorEmail = P00675_A433ProveedorEmail[0];
            n433ProveedorEmail = P00675_n433ProveedorEmail[0];
            A344ProveedorEstado = P00675_A344ProveedorEstado[0];
            A431ProveedorDireccion = P00675_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00675_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00675_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00675_n430ProveedorTelefono[0];
            A282ProveedorNombre = P00675_A282ProveedorNombre[0];
            A133ProveedorID = P00675_A133ProveedorID[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P00675_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00675_A433ProveedorEmail[0], A433ProveedorEmail) == 0 ) )
               {
                  BRK678 = false;
                  A133ProveedorID = P00675_A133ProveedorID[0];
                  AV33count = (long)(AV33count+1);
                  BRK678 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? "<#Empty#>" : A433ProveedorEmail);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK678 )
            {
               BRK678 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFProveedorNombre = "";
         AV14TFProveedorNombre_Sel = "";
         AV15TFProveedorTelefono = "";
         AV16TFProveedorTelefono_Sel = "";
         AV17TFProveedorDireccion = "";
         AV18TFProveedorDireccion_Sel = "";
         AV19TFProveedorEmail = "";
         AV20TFProveedorEmail_Sel = "";
         AV21TFProveedorEstado_SelsJson = "";
         AV22TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         lV13TFProveedorNombre = "";
         lV15TFProveedorTelefono = "";
         lV17TFProveedorDireccion = "";
         lV19TFProveedorEmail = "";
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         P00672_A488DocumentacionId = new long[1] ;
         P00672_n488DocumentacionId = new bool[] {false} ;
         P00672_A282ProveedorNombre = new string[] {""} ;
         P00672_A344ProveedorEstado = new string[] {""} ;
         P00672_A433ProveedorEmail = new string[] {""} ;
         P00672_n433ProveedorEmail = new bool[] {false} ;
         P00672_A431ProveedorDireccion = new string[] {""} ;
         P00672_n431ProveedorDireccion = new bool[] {false} ;
         P00672_A430ProveedorTelefono = new string[] {""} ;
         P00672_n430ProveedorTelefono = new bool[] {false} ;
         P00672_A133ProveedorID = new long[1] ;
         AV28Option = "";
         P00673_A488DocumentacionId = new long[1] ;
         P00673_n488DocumentacionId = new bool[] {false} ;
         P00673_A430ProveedorTelefono = new string[] {""} ;
         P00673_n430ProveedorTelefono = new bool[] {false} ;
         P00673_A344ProveedorEstado = new string[] {""} ;
         P00673_A433ProveedorEmail = new string[] {""} ;
         P00673_n433ProveedorEmail = new bool[] {false} ;
         P00673_A431ProveedorDireccion = new string[] {""} ;
         P00673_n431ProveedorDireccion = new bool[] {false} ;
         P00673_A282ProveedorNombre = new string[] {""} ;
         P00673_A133ProveedorID = new long[1] ;
         P00674_A488DocumentacionId = new long[1] ;
         P00674_n488DocumentacionId = new bool[] {false} ;
         P00674_A431ProveedorDireccion = new string[] {""} ;
         P00674_n431ProveedorDireccion = new bool[] {false} ;
         P00674_A344ProveedorEstado = new string[] {""} ;
         P00674_A433ProveedorEmail = new string[] {""} ;
         P00674_n433ProveedorEmail = new bool[] {false} ;
         P00674_A430ProveedorTelefono = new string[] {""} ;
         P00674_n430ProveedorTelefono = new bool[] {false} ;
         P00674_A282ProveedorNombre = new string[] {""} ;
         P00674_A133ProveedorID = new long[1] ;
         P00675_A488DocumentacionId = new long[1] ;
         P00675_n488DocumentacionId = new bool[] {false} ;
         P00675_A433ProveedorEmail = new string[] {""} ;
         P00675_n433ProveedorEmail = new bool[] {false} ;
         P00675_A344ProveedorEstado = new string[] {""} ;
         P00675_A431ProveedorDireccion = new string[] {""} ;
         P00675_n431ProveedorDireccion = new bool[] {false} ;
         P00675_A430ProveedorTelefono = new string[] {""} ;
         P00675_n430ProveedorTelefono = new bool[] {false} ;
         P00675_A282ProveedorNombre = new string[] {""} ;
         P00675_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionproveedordashboardwcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00672_A488DocumentacionId, P00672_n488DocumentacionId, P00672_A282ProveedorNombre, P00672_A344ProveedorEstado, P00672_A433ProveedorEmail, P00672_n433ProveedorEmail, P00672_A431ProveedorDireccion, P00672_n431ProveedorDireccion, P00672_A430ProveedorTelefono, P00672_n430ProveedorTelefono,
               P00672_A133ProveedorID
               }
               , new Object[] {
               P00673_A488DocumentacionId, P00673_n488DocumentacionId, P00673_A430ProveedorTelefono, P00673_n430ProveedorTelefono, P00673_A344ProveedorEstado, P00673_A433ProveedorEmail, P00673_n433ProveedorEmail, P00673_A431ProveedorDireccion, P00673_n431ProveedorDireccion, P00673_A282ProveedorNombre,
               P00673_A133ProveedorID
               }
               , new Object[] {
               P00674_A488DocumentacionId, P00674_n488DocumentacionId, P00674_A431ProveedorDireccion, P00674_n431ProveedorDireccion, P00674_A344ProveedorEstado, P00674_A433ProveedorEmail, P00674_n433ProveedorEmail, P00674_A430ProveedorTelefono, P00674_n430ProveedorTelefono, P00674_A282ProveedorNombre,
               P00674_A133ProveedorID
               }
               , new Object[] {
               P00675_A488DocumentacionId, P00675_n488DocumentacionId, P00675_A433ProveedorEmail, P00675_n433ProveedorEmail, P00675_A344ProveedorEstado, P00675_A431ProveedorDireccion, P00675_n431ProveedorDireccion, P00675_A430ProveedorTelefono, P00675_n430ProveedorTelefono, P00675_A282ProveedorNombre,
               P00675_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV47GXV1 ;
      private int AV22TFProveedorEstado_Sels_Count ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long AV46DocumentacionId ;
      private long A133ProveedorID ;
      private long A488DocumentacionId ;
      private long AV33count ;
      private string AV13TFProveedorNombre ;
      private string AV14TFProveedorNombre_Sel ;
      private string AV15TFProveedorTelefono ;
      private string AV16TFProveedorTelefono_Sel ;
      private string lV13TFProveedorNombre ;
      private string lV15TFProveedorTelefono ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A430ProveedorTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK672 ;
      private bool n488DocumentacionId ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool BRK674 ;
      private bool BRK676 ;
      private bool BRK678 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV21TFProveedorEstado_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV17TFProveedorDireccion ;
      private string AV18TFProveedorDireccion_Sel ;
      private string AV19TFProveedorEmail ;
      private string AV20TFProveedorEmail_Sel ;
      private string lV17TFProveedorDireccion ;
      private string lV19TFProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GxSimpleCollection<string> AV22TFProveedorEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00672_A488DocumentacionId ;
      private bool[] P00672_n488DocumentacionId ;
      private string[] P00672_A282ProveedorNombre ;
      private string[] P00672_A344ProveedorEstado ;
      private string[] P00672_A433ProveedorEmail ;
      private bool[] P00672_n433ProveedorEmail ;
      private string[] P00672_A431ProveedorDireccion ;
      private bool[] P00672_n431ProveedorDireccion ;
      private string[] P00672_A430ProveedorTelefono ;
      private bool[] P00672_n430ProveedorTelefono ;
      private long[] P00672_A133ProveedorID ;
      private long[] P00673_A488DocumentacionId ;
      private bool[] P00673_n488DocumentacionId ;
      private string[] P00673_A430ProveedorTelefono ;
      private bool[] P00673_n430ProveedorTelefono ;
      private string[] P00673_A344ProveedorEstado ;
      private string[] P00673_A433ProveedorEmail ;
      private bool[] P00673_n433ProveedorEmail ;
      private string[] P00673_A431ProveedorDireccion ;
      private bool[] P00673_n431ProveedorDireccion ;
      private string[] P00673_A282ProveedorNombre ;
      private long[] P00673_A133ProveedorID ;
      private long[] P00674_A488DocumentacionId ;
      private bool[] P00674_n488DocumentacionId ;
      private string[] P00674_A431ProveedorDireccion ;
      private bool[] P00674_n431ProveedorDireccion ;
      private string[] P00674_A344ProveedorEstado ;
      private string[] P00674_A433ProveedorEmail ;
      private bool[] P00674_n433ProveedorEmail ;
      private string[] P00674_A430ProveedorTelefono ;
      private bool[] P00674_n430ProveedorTelefono ;
      private string[] P00674_A282ProveedorNombre ;
      private long[] P00674_A133ProveedorID ;
      private long[] P00675_A488DocumentacionId ;
      private bool[] P00675_n488DocumentacionId ;
      private string[] P00675_A433ProveedorEmail ;
      private bool[] P00675_n433ProveedorEmail ;
      private string[] P00675_A344ProveedorEstado ;
      private string[] P00675_A431ProveedorDireccion ;
      private bool[] P00675_n431ProveedorDireccion ;
      private string[] P00675_A430ProveedorTelefono ;
      private bool[] P00675_n430ProveedorTelefono ;
      private string[] P00675_A282ProveedorNombre ;
      private long[] P00675_A133ProveedorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class documentacionproveedordashboardwcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00672( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV22TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorTelefono_Sel ,
                                             string AV15TFProveedorTelefono ,
                                             string AV18TFProveedorDireccion_Sel ,
                                             string AV17TFProveedorDireccion ,
                                             string AV20TFProveedorEmail_Sel ,
                                             string AV19TFProveedorEmail ,
                                             int AV22TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV45FilterFullText ,
                                             long AV46DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DocumentacionId], [ProveedorNombre], [ProveedorEstado], [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorID] FROM [Proveedor]";
         AddWhere(sWhereString, "([DocumentacionId] = @AV46DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV15TFProveedorTelefono))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV16TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV17TFProveedorDireccion))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV18TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV19TFProveedorEmail))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV20TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV22TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFProveedorEstado_Sels, "[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentacionId], [ProveedorNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00673( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV22TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorTelefono_Sel ,
                                             string AV15TFProveedorTelefono ,
                                             string AV18TFProveedorDireccion_Sel ,
                                             string AV17TFProveedorDireccion ,
                                             string AV20TFProveedorEmail_Sel ,
                                             string AV19TFProveedorEmail ,
                                             int AV22TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV45FilterFullText ,
                                             long AV46DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [DocumentacionId], [ProveedorTelefono], [ProveedorEstado], [ProveedorEmail], [ProveedorDireccion], [ProveedorNombre], [ProveedorID] FROM [Proveedor]";
         AddWhere(sWhereString, "([DocumentacionId] = @AV46DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV15TFProveedorTelefono))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV16TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV17TFProveedorDireccion))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV18TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV19TFProveedorEmail))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV20TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV22TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFProveedorEstado_Sels, "[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentacionId], [ProveedorTelefono]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00674( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV22TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorTelefono_Sel ,
                                             string AV15TFProveedorTelefono ,
                                             string AV18TFProveedorDireccion_Sel ,
                                             string AV17TFProveedorDireccion ,
                                             string AV20TFProveedorEmail_Sel ,
                                             string AV19TFProveedorEmail ,
                                             int AV22TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV45FilterFullText ,
                                             long AV46DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[11];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [DocumentacionId], [ProveedorDireccion], [ProveedorEstado], [ProveedorEmail], [ProveedorTelefono], [ProveedorNombre], [ProveedorID] FROM [Proveedor]";
         AddWhere(sWhereString, "([DocumentacionId] = @AV46DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV15TFProveedorTelefono))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV16TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV17TFProveedorDireccion))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV18TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV19TFProveedorEmail))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV20TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV22TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFProveedorEstado_Sels, "[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentacionId], [ProveedorDireccion]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00675( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV22TFProveedorEstado_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             string AV14TFProveedorNombre_Sel ,
                                             string AV13TFProveedorNombre ,
                                             string AV16TFProveedorTelefono_Sel ,
                                             string AV15TFProveedorTelefono ,
                                             string AV18TFProveedorDireccion_Sel ,
                                             string AV17TFProveedorDireccion ,
                                             string AV20TFProveedorEmail_Sel ,
                                             string AV19TFProveedorEmail ,
                                             int AV22TFProveedorEstado_Sels_Count ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV45FilterFullText ,
                                             long AV46DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[11];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [DocumentacionId], [ProveedorEmail], [ProveedorEstado], [ProveedorDireccion], [ProveedorTelefono], [ProveedorNombre], [ProveedorID] FROM [Proveedor]";
         AddWhere(sWhereString, "([DocumentacionId] = @AV46DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV13TFProveedorNombre))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV14TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV15TFProveedorTelefono))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV16TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV17TFProveedorDireccion))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV18TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV19TFProveedorEmail))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV20TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV22TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFProveedorEstado_Sels, "[ProveedorEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentacionId], [ProveedorEmail]";
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
                     return conditional_P00672(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
               case 1 :
                     return conditional_P00673(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
               case 2 :
                     return conditional_P00674(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
               case 3 :
                     return conditional_P00675(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00672;
          prmP00672 = new Object[] {
          new ParDef("@AV46DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV18TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV19TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV20TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00673;
          prmP00673 = new Object[] {
          new ParDef("@AV46DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV18TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV19TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV20TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00674;
          prmP00674 = new Object[] {
          new ParDef("@AV46DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV18TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV19TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV20TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00675;
          prmP00675 = new Object[] {
          new ParDef("@AV46DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV14TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV15TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV18TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV19TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV20TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00672", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00672,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00673", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00673,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00674", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00674,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00675", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00675,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 80);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 80);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 80);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.documentacionproveedordashboardwcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class documentacionproveedordashboardwcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DocumentacionProveedorDashboardWCGetFilterData" )]
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
          if ( ! ProcessHeaders("documentacionproveedordashboardwcgetfilterdata") )
          {
             return  ;
          }
          documentacionproveedordashboardwcgetfilterdata worker = new documentacionproveedordashboardwcgetfilterdata(context);
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
