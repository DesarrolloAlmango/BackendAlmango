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
   public class comisionesagruparprofesionaleswcgetfilterdata : GXProcedure
   {
      public comisionesagruparprofesionaleswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagruparprofesionaleswcgetfilterdata( IGxContext context )
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
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV27MaxItems = 10;
            AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
            AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_COMISIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMISIONESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_COMISIONESCOMENTARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMISIONESCOMENTARIOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("ComisionesAgruparProfesionalesWCGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesAgruparProfesionalesWCGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("ComisionesAgruparProfesionalesWCGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV46FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV11TFComisionesNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV12TFComisionesNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV13TFComisionesTipo_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV14TFComisionesTipo_Sels.FromJSonString(AV13TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV15TFComisionesDefault = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV16TFComisionesDefault_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESFECHAVENCIMIENTO") == 0 )
            {
               AV17TFComisionesFechaVencimiento = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV18TFComisionesFechaVencimiento_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESESTADO_SEL") == 0 )
            {
               AV19TFComisionesEstado_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV20TFComisionesEstado_Sels.FromJSonString(AV19TFComisionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESCOMENTARIO") == 0 )
            {
               AV21TFComisionesComentario = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESCOMENTARIO_SEL") == 0 )
            {
               AV22TFComisionesComentario_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOMISIONESGLOBAL_SEL") == 0 )
            {
               AV23TFComisionesGlobal_Sel = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&COMISIONESID") == 0 )
            {
               AV47ComisionesID = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMISIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV11TFComisionesNombre = AV24SearchTxt;
         AV12TFComisionesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV14TFComisionesTipo_Sels ,
                                              A511ComisionesEstado ,
                                              AV20TFComisionesEstado_Sels ,
                                              AV12TFComisionesNombre_Sel ,
                                              AV11TFComisionesNombre ,
                                              AV14TFComisionesTipo_Sels.Count ,
                                              AV15TFComisionesDefault ,
                                              AV16TFComisionesDefault_To ,
                                              AV17TFComisionesFechaVencimiento ,
                                              AV18TFComisionesFechaVencimiento_To ,
                                              AV20TFComisionesEstado_Sels.Count ,
                                              AV22TFComisionesComentario_Sel ,
                                              AV21TFComisionesComentario ,
                                              AV23TFComisionesGlobal_Sel ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              A510ComisionesFechaVencimiento ,
                                              A518ComisionesComentario ,
                                              A520ComisionesGlobal ,
                                              AV46FilterFullText ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFComisionesNombre = StringUtil.PadR( StringUtil.RTrim( AV11TFComisionesNombre), 80, "%");
         lV21TFComisionesComentario = StringUtil.Concat( StringUtil.RTrim( AV21TFComisionesComentario), "%", "");
         /* Using cursor P006M2 */
         pr_default.execute(0, new Object[] {AV47ComisionesID, lV11TFComisionesNombre, AV12TFComisionesNombre_Sel, AV15TFComisionesDefault, AV16TFComisionesDefault_To, AV17TFComisionesFechaVencimiento, AV18TFComisionesFechaVencimiento_To, lV21TFComisionesComentario, AV22TFComisionesComentario_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6M2 = false;
            A503ComisionesID = P006M2_A503ComisionesID[0];
            A504ComisionesNombre = P006M2_A504ComisionesNombre[0];
            A520ComisionesGlobal = P006M2_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006M2_n520ComisionesGlobal[0];
            A510ComisionesFechaVencimiento = P006M2_A510ComisionesFechaVencimiento[0];
            n510ComisionesFechaVencimiento = P006M2_n510ComisionesFechaVencimiento[0];
            A518ComisionesComentario = P006M2_A518ComisionesComentario[0];
            n518ComisionesComentario = P006M2_n518ComisionesComentario[0];
            A511ComisionesEstado = P006M2_A511ComisionesEstado[0];
            n511ComisionesEstado = P006M2_n511ComisionesEstado[0];
            A506ComisionesDefault = P006M2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006M2_n506ComisionesDefault[0];
            A505ComisionesTipo = P006M2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV46FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV46FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A518ComisionesComentario) , StringUtil.PadR( "%" + StringUtil.Upper( AV46FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P006M2_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006M2_A504ComisionesNombre[0], A504ComisionesNombre) == 0 ) )
               {
                  BRK6M2 = false;
                  AV34count = (long)(AV34count+1);
                  BRK6M2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A504ComisionesNombre)) ? "<#Empty#>" : A504ComisionesNombre);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRK6M2 )
            {
               BRK6M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCOMISIONESCOMENTARIOOPTIONS' Routine */
         returnInSub = false;
         AV21TFComisionesComentario = AV24SearchTxt;
         AV22TFComisionesComentario_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV14TFComisionesTipo_Sels ,
                                              A511ComisionesEstado ,
                                              AV20TFComisionesEstado_Sels ,
                                              AV12TFComisionesNombre_Sel ,
                                              AV11TFComisionesNombre ,
                                              AV14TFComisionesTipo_Sels.Count ,
                                              AV15TFComisionesDefault ,
                                              AV16TFComisionesDefault_To ,
                                              AV17TFComisionesFechaVencimiento ,
                                              AV18TFComisionesFechaVencimiento_To ,
                                              AV20TFComisionesEstado_Sels.Count ,
                                              AV22TFComisionesComentario_Sel ,
                                              AV21TFComisionesComentario ,
                                              AV23TFComisionesGlobal_Sel ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              A510ComisionesFechaVencimiento ,
                                              A518ComisionesComentario ,
                                              A520ComisionesGlobal ,
                                              AV46FilterFullText ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFComisionesNombre = StringUtil.PadR( StringUtil.RTrim( AV11TFComisionesNombre), 80, "%");
         lV21TFComisionesComentario = StringUtil.Concat( StringUtil.RTrim( AV21TFComisionesComentario), "%", "");
         /* Using cursor P006M3 */
         pr_default.execute(1, new Object[] {AV47ComisionesID, lV11TFComisionesNombre, AV12TFComisionesNombre_Sel, AV15TFComisionesDefault, AV16TFComisionesDefault_To, AV17TFComisionesFechaVencimiento, AV18TFComisionesFechaVencimiento_To, lV21TFComisionesComentario, AV22TFComisionesComentario_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6M4 = false;
            A503ComisionesID = P006M3_A503ComisionesID[0];
            A518ComisionesComentario = P006M3_A518ComisionesComentario[0];
            n518ComisionesComentario = P006M3_n518ComisionesComentario[0];
            A520ComisionesGlobal = P006M3_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006M3_n520ComisionesGlobal[0];
            A510ComisionesFechaVencimiento = P006M3_A510ComisionesFechaVencimiento[0];
            n510ComisionesFechaVencimiento = P006M3_n510ComisionesFechaVencimiento[0];
            A511ComisionesEstado = P006M3_A511ComisionesEstado[0];
            n511ComisionesEstado = P006M3_n511ComisionesEstado[0];
            A506ComisionesDefault = P006M3_A506ComisionesDefault[0];
            n506ComisionesDefault = P006M3_n506ComisionesDefault[0];
            A505ComisionesTipo = P006M3_A505ComisionesTipo[0];
            A504ComisionesNombre = P006M3_A504ComisionesNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV46FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV46FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV46FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A518ComisionesComentario) , StringUtil.PadR( "%" + StringUtil.Upper( AV46FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV34count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P006M3_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006M3_A518ComisionesComentario[0], A518ComisionesComentario) == 0 ) )
               {
                  BRK6M4 = false;
                  AV34count = (long)(AV34count+1);
                  BRK6M4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV25SkipItems) )
               {
                  AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A518ComisionesComentario)) ? "<#Empty#>" : A518ComisionesComentario);
                  AV30Options.Add(AV29Option, 0);
                  AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV30Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV25SkipItems = (short)(AV25SkipItems-1);
               }
            }
            if ( ! BRK6M4 )
            {
               BRK6M4 = true;
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46FilterFullText = "";
         AV11TFComisionesNombre = "";
         AV12TFComisionesNombre_Sel = "";
         AV13TFComisionesTipo_SelsJson = "";
         AV14TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV17TFComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         AV18TFComisionesFechaVencimiento_To = (DateTime)(DateTime.MinValue);
         AV19TFComisionesEstado_SelsJson = "";
         AV20TFComisionesEstado_Sels = new GxSimpleCollection<string>();
         AV21TFComisionesComentario = "";
         AV22TFComisionesComentario_Sel = "";
         lV46FilterFullText = "";
         lV11TFComisionesNombre = "";
         lV21TFComisionesComentario = "";
         A505ComisionesTipo = "";
         A511ComisionesEstado = "";
         A504ComisionesNombre = "";
         A510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         A518ComisionesComentario = "";
         P006M2_A503ComisionesID = new long[1] ;
         P006M2_A504ComisionesNombre = new string[] {""} ;
         P006M2_A520ComisionesGlobal = new bool[] {false} ;
         P006M2_n520ComisionesGlobal = new bool[] {false} ;
         P006M2_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         P006M2_n510ComisionesFechaVencimiento = new bool[] {false} ;
         P006M2_A518ComisionesComentario = new string[] {""} ;
         P006M2_n518ComisionesComentario = new bool[] {false} ;
         P006M2_A511ComisionesEstado = new string[] {""} ;
         P006M2_n511ComisionesEstado = new bool[] {false} ;
         P006M2_A506ComisionesDefault = new decimal[1] ;
         P006M2_n506ComisionesDefault = new bool[] {false} ;
         P006M2_A505ComisionesTipo = new string[] {""} ;
         AV29Option = "";
         P006M3_A503ComisionesID = new long[1] ;
         P006M3_A518ComisionesComentario = new string[] {""} ;
         P006M3_n518ComisionesComentario = new bool[] {false} ;
         P006M3_A520ComisionesGlobal = new bool[] {false} ;
         P006M3_n520ComisionesGlobal = new bool[] {false} ;
         P006M3_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         P006M3_n510ComisionesFechaVencimiento = new bool[] {false} ;
         P006M3_A511ComisionesEstado = new string[] {""} ;
         P006M3_n511ComisionesEstado = new bool[] {false} ;
         P006M3_A506ComisionesDefault = new decimal[1] ;
         P006M3_n506ComisionesDefault = new bool[] {false} ;
         P006M3_A505ComisionesTipo = new string[] {""} ;
         P006M3_A504ComisionesNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagruparprofesionaleswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006M2_A503ComisionesID, P006M2_A504ComisionesNombre, P006M2_A520ComisionesGlobal, P006M2_n520ComisionesGlobal, P006M2_A510ComisionesFechaVencimiento, P006M2_n510ComisionesFechaVencimiento, P006M2_A518ComisionesComentario, P006M2_n518ComisionesComentario, P006M2_A511ComisionesEstado, P006M2_n511ComisionesEstado,
               P006M2_A506ComisionesDefault, P006M2_n506ComisionesDefault, P006M2_A505ComisionesTipo
               }
               , new Object[] {
               P006M3_A503ComisionesID, P006M3_A518ComisionesComentario, P006M3_n518ComisionesComentario, P006M3_A520ComisionesGlobal, P006M3_n520ComisionesGlobal, P006M3_A510ComisionesFechaVencimiento, P006M3_n510ComisionesFechaVencimiento, P006M3_A511ComisionesEstado, P006M3_n511ComisionesEstado, P006M3_A506ComisionesDefault,
               P006M3_n506ComisionesDefault, P006M3_A505ComisionesTipo, P006M3_A504ComisionesNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private short AV23TFComisionesGlobal_Sel ;
      private int AV48GXV1 ;
      private int AV14TFComisionesTipo_Sels_Count ;
      private int AV20TFComisionesEstado_Sels_Count ;
      private long AV47ComisionesID ;
      private long A503ComisionesID ;
      private long AV34count ;
      private decimal AV15TFComisionesDefault ;
      private decimal AV16TFComisionesDefault_To ;
      private decimal A506ComisionesDefault ;
      private string AV11TFComisionesNombre ;
      private string AV12TFComisionesNombre_Sel ;
      private string lV11TFComisionesNombre ;
      private string A505ComisionesTipo ;
      private string A511ComisionesEstado ;
      private string A504ComisionesNombre ;
      private DateTime AV17TFComisionesFechaVencimiento ;
      private DateTime AV18TFComisionesFechaVencimiento_To ;
      private DateTime A510ComisionesFechaVencimiento ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool A520ComisionesGlobal ;
      private bool BRK6M2 ;
      private bool n520ComisionesGlobal ;
      private bool n510ComisionesFechaVencimiento ;
      private bool n518ComisionesComentario ;
      private bool n511ComisionesEstado ;
      private bool n506ComisionesDefault ;
      private bool BRK6M4 ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV13TFComisionesTipo_SelsJson ;
      private string AV19TFComisionesEstado_SelsJson ;
      private string A518ComisionesComentario ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV46FilterFullText ;
      private string AV21TFComisionesComentario ;
      private string AV22TFComisionesComentario_Sel ;
      private string lV46FilterFullText ;
      private string lV21TFComisionesComentario ;
      private string AV29Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFComisionesTipo_Sels ;
      private GxSimpleCollection<string> AV20TFComisionesEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P006M2_A503ComisionesID ;
      private string[] P006M2_A504ComisionesNombre ;
      private bool[] P006M2_A520ComisionesGlobal ;
      private bool[] P006M2_n520ComisionesGlobal ;
      private DateTime[] P006M2_A510ComisionesFechaVencimiento ;
      private bool[] P006M2_n510ComisionesFechaVencimiento ;
      private string[] P006M2_A518ComisionesComentario ;
      private bool[] P006M2_n518ComisionesComentario ;
      private string[] P006M2_A511ComisionesEstado ;
      private bool[] P006M2_n511ComisionesEstado ;
      private decimal[] P006M2_A506ComisionesDefault ;
      private bool[] P006M2_n506ComisionesDefault ;
      private string[] P006M2_A505ComisionesTipo ;
      private long[] P006M3_A503ComisionesID ;
      private string[] P006M3_A518ComisionesComentario ;
      private bool[] P006M3_n518ComisionesComentario ;
      private bool[] P006M3_A520ComisionesGlobal ;
      private bool[] P006M3_n520ComisionesGlobal ;
      private DateTime[] P006M3_A510ComisionesFechaVencimiento ;
      private bool[] P006M3_n510ComisionesFechaVencimiento ;
      private string[] P006M3_A511ComisionesEstado ;
      private bool[] P006M3_n511ComisionesEstado ;
      private decimal[] P006M3_A506ComisionesDefault ;
      private bool[] P006M3_n506ComisionesDefault ;
      private string[] P006M3_A505ComisionesTipo ;
      private string[] P006M3_A504ComisionesNombre ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisionesagruparprofesionaleswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006M2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV14TFComisionesTipo_Sels ,
                                             string A511ComisionesEstado ,
                                             GxSimpleCollection<string> AV20TFComisionesEstado_Sels ,
                                             string AV12TFComisionesNombre_Sel ,
                                             string AV11TFComisionesNombre ,
                                             int AV14TFComisionesTipo_Sels_Count ,
                                             decimal AV15TFComisionesDefault ,
                                             decimal AV16TFComisionesDefault_To ,
                                             DateTime AV17TFComisionesFechaVencimiento ,
                                             DateTime AV18TFComisionesFechaVencimiento_To ,
                                             int AV20TFComisionesEstado_Sels_Count ,
                                             string AV22TFComisionesComentario_Sel ,
                                             string AV21TFComisionesComentario ,
                                             short AV23TFComisionesGlobal_Sel ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             DateTime A510ComisionesFechaVencimiento ,
                                             string A518ComisionesComentario ,
                                             bool A520ComisionesGlobal ,
                                             string AV46FilterFullText ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesID], [ComisionesNombre], [ComisionesGlobal], [ComisionesFechaVencimiento], [ComisionesComentario], [ComisionesEstado], [ComisionesDefault], [ComisionesTipo] FROM [Comisiones]";
         AddWhere(sWhereString, "([ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFComisionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFComisionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV11TFComisionesNombre))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFComisionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV12TFComisionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV12TFComisionesNombre_Sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFComisionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( AV14TFComisionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFComisionesTipo_Sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFComisionesDefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV15TFComisionesDefault)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFComisionesDefault_To) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV16TFComisionesDefault_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TFComisionesFechaVencimiento) )
         {
            AddWhere(sWhereString, "([ComisionesFechaVencimiento] >= @AV17TFComisionesFechaVencimiento)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV18TFComisionesFechaVencimiento_To) )
         {
            AddWhere(sWhereString, "([ComisionesFechaVencimiento] <= @AV18TFComisionesFechaVencimiento_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV20TFComisionesEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFComisionesEstado_Sels, "[ComisionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFComisionesComentario_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFComisionesComentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesComentario]) like UPPER(@lV21TFComisionesComentario))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFComisionesComentario_Sel)) && ! ( StringUtil.StrCmp(AV22TFComisionesComentario_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesComentario] = @AV22TFComisionesComentario_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFComisionesComentario_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ComisionesComentario] IS NULL or (DATALENGTH([ComisionesComentario])=0))");
         }
         if ( AV23TFComisionesGlobal_Sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV23TFComisionesGlobal_Sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ComisionesID], [ComisionesNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006M3( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV14TFComisionesTipo_Sels ,
                                             string A511ComisionesEstado ,
                                             GxSimpleCollection<string> AV20TFComisionesEstado_Sels ,
                                             string AV12TFComisionesNombre_Sel ,
                                             string AV11TFComisionesNombre ,
                                             int AV14TFComisionesTipo_Sels_Count ,
                                             decimal AV15TFComisionesDefault ,
                                             decimal AV16TFComisionesDefault_To ,
                                             DateTime AV17TFComisionesFechaVencimiento ,
                                             DateTime AV18TFComisionesFechaVencimiento_To ,
                                             int AV20TFComisionesEstado_Sels_Count ,
                                             string AV22TFComisionesComentario_Sel ,
                                             string AV21TFComisionesComentario ,
                                             short AV23TFComisionesGlobal_Sel ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             DateTime A510ComisionesFechaVencimiento ,
                                             string A518ComisionesComentario ,
                                             bool A520ComisionesGlobal ,
                                             string AV46FilterFullText ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ComisionesID], [ComisionesComentario], [ComisionesGlobal], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesDefault], [ComisionesTipo], [ComisionesNombre] FROM [Comisiones]";
         AddWhere(sWhereString, "([ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFComisionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFComisionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV11TFComisionesNombre))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFComisionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV12TFComisionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV12TFComisionesNombre_Sel)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFComisionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( AV14TFComisionesTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFComisionesTipo_Sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFComisionesDefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV15TFComisionesDefault)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFComisionesDefault_To) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV16TFComisionesDefault_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV17TFComisionesFechaVencimiento) )
         {
            AddWhere(sWhereString, "([ComisionesFechaVencimiento] >= @AV17TFComisionesFechaVencimiento)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV18TFComisionesFechaVencimiento_To) )
         {
            AddWhere(sWhereString, "([ComisionesFechaVencimiento] <= @AV18TFComisionesFechaVencimiento_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV20TFComisionesEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFComisionesEstado_Sels, "[ComisionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFComisionesComentario_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFComisionesComentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesComentario]) like UPPER(@lV21TFComisionesComentario))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFComisionesComentario_Sel)) && ! ( StringUtil.StrCmp(AV22TFComisionesComentario_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesComentario] = @AV22TFComisionesComentario_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFComisionesComentario_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ComisionesComentario] IS NULL or (DATALENGTH([ComisionesComentario])=0))");
         }
         if ( AV23TFComisionesGlobal_Sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV23TFComisionesGlobal_Sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ComisionesID], [ComisionesComentario]";
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
                     return conditional_P006M2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 1 :
                     return conditional_P006M3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
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
          Object[] prmP006M2;
          prmP006M2 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@lV11TFComisionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV12TFComisionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV15TFComisionesDefault",GXType.Decimal,6,2) ,
          new ParDef("@AV16TFComisionesDefault_To",GXType.Decimal,6,2) ,
          new ParDef("@AV17TFComisionesFechaVencimiento",GXType.DateTime,8,5) ,
          new ParDef("@AV18TFComisionesFechaVencimiento_To",GXType.DateTime,8,5) ,
          new ParDef("@lV21TFComisionesComentario",GXType.VarChar,200,0) ,
          new ParDef("@AV22TFComisionesComentario_Sel",GXType.NVarChar,200,0)
          };
          Object[] prmP006M3;
          prmP006M3 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@lV11TFComisionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV12TFComisionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV15TFComisionesDefault",GXType.Decimal,6,2) ,
          new ParDef("@AV16TFComisionesDefault_To",GXType.Decimal,6,2) ,
          new ParDef("@AV17TFComisionesFechaVencimiento",GXType.DateTime,8,5) ,
          new ParDef("@AV18TFComisionesFechaVencimiento_To",GXType.DateTime,8,5) ,
          new ParDef("@lV21TFComisionesComentario",GXType.VarChar,200,0) ,
          new ParDef("@AV22TFComisionesComentario_Sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 1);
                ((string[]) buf[12])[0] = rslt.getString(8, 80);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisionesagruparprofesionaleswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisionesagruparprofesionaleswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesAgruparProfesionalesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("comisionesagruparprofesionaleswcgetfilterdata") )
          {
             return  ;
          }
          comisionesagruparprofesionaleswcgetfilterdata worker = new comisionesagruparprofesionaleswcgetfilterdata(context);
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
