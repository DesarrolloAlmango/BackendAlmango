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
   public class amudanzaloaddvcombo : GXProcedure
   {
      public amudanzaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amudanzaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_MudanzaId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV23IsDynamicCall = aP2_IsDynamicCall;
         this.AV15MudanzaId = aP3_MudanzaId;
         this.AV24SearchTxtParms = aP4_SearchTxtParms;
         this.AV16SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         initialize();
         ExecutePrivate();
         aP5_SelectedValue=this.AV16SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_DataJson=this.AV26Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                long aP3_MudanzaId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_MudanzaId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV26Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_MudanzaId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV23IsDynamicCall = aP2_IsDynamicCall;
         this.AV15MudanzaId = aP3_MudanzaId;
         this.AV24SearchTxtParms = aP4_SearchTxtParms;
         this.AV16SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV16SelectedValue;
         aP6_SelectedText=this.AV25SelectedText;
         aP7_Combo_DataJson=this.AV26Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( 0 == 1 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               AV19MaxItems = 10;
               AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV24SearchTxtParms))||StringUtil.StartsWith( AV14TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV24SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
               AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV24SearchTxtParms))||StringUtil.StartsWith( AV14TrnMode, "GET") ? AV24SearchTxtParms : StringUtil.Substring( AV24SearchTxtParms, 3, -1));
               AV20SkipItems = (short)(AV21PageIndex*AV19MaxItems);
               if ( StringUtil.StrCmp(AV13ComboName, "ItemAdicionalId") == 0 )
               {
                  /* Execute user subroutine: 'LOADCOMBOITEMS_ITEMADICIONALID' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( StringUtil.StrCmp(AV13ComboName, "MudanzaDireccionDestino") == 0 )
               {
                  /* Execute user subroutine: 'LOADCOMBOITEMS_MUDANZADIRECCIONDESTINO' */
                  S121 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( StringUtil.StrCmp(AV13ComboName, "MudanzaDireccionOrigen") == 0 )
               {
                  /* Execute user subroutine: 'LOADCOMBOITEMS_MUDANZADIRECCIONORIGEN' */
                  S131 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
            }
         }
         AV19MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV24SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV24SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = StringUtil.Substring( AV24SearchTxtParms, 3, StringUtil.Len( AV24SearchTxtParms)-2);
         AV20SkipItems = (short)(AV21PageIndex*AV19MaxItems);
         if ( StringUtil.StrCmp(AV13ComboName, "ItemAdicionalId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ITEMADICIONALID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( ( StringUtil.StrCmp(AV13ComboName, "MudanzaDireccionDestino") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxt)) )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MUDANZADIRECCIONDESTINO' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( ( StringUtil.StrCmp(AV13ComboName, "MudanzaDireccionOrigen") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxt)) )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MUDANZADIRECCIONORIGEN' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_ITEMADICIONALID' Routine */
         returnInSub = false;
         /* Using cursor P00EY2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A731ParametroMudanzaTipo = P00EY2_A731ParametroMudanzaTipo[0];
            A730ParametroMudanzaId = P00EY2_A730ParametroMudanzaId[0];
            A732ParametroMudanzaNombre = P00EY2_A732ParametroMudanzaNombre[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0));
            AV12Combo_DataItem.gxTpr_Title = A732ParametroMudanzaNombre;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26Combo_DataJson = AV11Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_MUDANZADIRECCIONDESTINO' Routine */
         returnInSub = false;
         AV38OrigenCoordenadas = StringUtil.Trim( AV39WebSession.Get(context.GetMessage( "&OrigenCoordenadas", "")));
         GXt_char2 = AV34Result;
         new osuggestmapbox(context ).execute(  AV22SearchTxt,  StringUtil.Trim( AV38OrigenCoordenadas), out  GXt_char2) ;
         AV34Result = GXt_char2;
         AV29IndiceInicio = (short)(StringUtil.StringSearch( AV34Result, "[", 1));
         AV28IndiceFin = (short)(StringUtil.StringSearch( AV34Result, "]", 1));
         AV37Start = AV29IndiceInicio;
         AV31Length = (short)(AV28IndiceFin-AV29IndiceInicio+1);
         AV34Result = StringUtil.Substring( AV34Result, AV37Start, AV31Length);
         AV35SDTSuggestMapBox.FromJSonString(AV34Result, null);
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV35SDTSuggestMapBox.Count )
         {
            AV36SDTSuggestMapBoxItem = ((SdtSDTSuggestMapBox_suggestions)AV35SDTSuggestMapBox.Item(AV43GXV1));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Mapbox_id)+"&-"+StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Distance);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Region.gxTpr_Name)) )
            {
               AV12Combo_DataItem.gxTpr_Title = StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Full_address);
            }
            else
            {
               AV12Combo_DataItem.gxTpr_Title = AV36SDTSuggestMapBoxItem.gxTpr_Name+", "+AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Place.gxTpr_Name+", "+AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Region.gxTpr_Name;
            }
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         if ( AV23IsDynamicCall )
         {
            AV26Combo_DataJson = AV11Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
            {
               /* Using cursor P00EY3 */
               pr_default.execute(1, new Object[] {AV15MudanzaId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A735MudanzaId = P00EY3_A735MudanzaId[0];
                  A741MudanzaDireccionDestino = P00EY3_A741MudanzaDireccionDestino[0];
                  AV16SelectedValue = A741MudanzaDireccionDestino;
                  AV25SelectedText = AV16SelectedValue;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_MUDANZADIRECCIONORIGEN' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV39WebSession.Get(context.GetMessage( "&MapBox_Id", "")), AV39WebSession.Get(context.GetMessage( "&MapBox_IdDestino", ""))) != 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV39WebSession.Get(context.GetMessage( "&MapBox_IdDestino", "")))) )
         {
            AV40Origen = AV39WebSession.Get(context.GetMessage( "&OrigenCoordenadasDestino", ""));
            GXt_char2 = AV34Result;
            new osuggestmapbox(context ).execute(  AV22SearchTxt,  AV40Origen, out  GXt_char2) ;
            AV34Result = GXt_char2;
         }
         else
         {
            GXt_char2 = AV34Result;
            new osuggestmapbox(context ).execute(  AV22SearchTxt,  "", out  GXt_char2) ;
            AV34Result = GXt_char2;
         }
         AV29IndiceInicio = (short)(StringUtil.StringSearch( AV34Result, "[", 1));
         AV28IndiceFin = (short)(StringUtil.StringSearch( AV34Result, "]", 1));
         AV37Start = AV29IndiceInicio;
         AV31Length = (short)(AV28IndiceFin-AV29IndiceInicio+1);
         AV34Result = StringUtil.Substring( AV34Result, AV37Start, AV31Length);
         AV35SDTSuggestMapBox.FromJSonString(AV34Result, null);
         AV45GXV2 = 1;
         while ( AV45GXV2 <= AV35SDTSuggestMapBox.Count )
         {
            AV36SDTSuggestMapBoxItem = ((SdtSDTSuggestMapBox_suggestions)AV35SDTSuggestMapBox.Item(AV45GXV2));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Mapbox_id)+"&-"+StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Distance);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Region.gxTpr_Name)) )
            {
               AV12Combo_DataItem.gxTpr_Title = StringUtil.Trim( AV36SDTSuggestMapBoxItem.gxTpr_Full_address);
            }
            else
            {
               AV12Combo_DataItem.gxTpr_Title = AV36SDTSuggestMapBoxItem.gxTpr_Name+", "+AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Place.gxTpr_Name+", "+AV36SDTSuggestMapBoxItem.gxTpr_Context.gxTpr_Region.gxTpr_Name;
            }
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV45GXV2 = (int)(AV45GXV2+1);
         }
         if ( AV23IsDynamicCall )
         {
            AV26Combo_DataJson = AV11Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
            {
               /* Using cursor P00EY4 */
               pr_default.execute(2, new Object[] {AV15MudanzaId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A735MudanzaId = P00EY4_A735MudanzaId[0];
                  A740MudanzaDireccionOrigen = P00EY4_A740MudanzaDireccionOrigen[0];
                  AV16SelectedValue = A740MudanzaDireccionOrigen;
                  AV25SelectedText = AV16SelectedValue;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
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
         AV16SelectedValue = "";
         AV25SelectedText = "";
         AV26Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV22SearchTxt = "";
         P00EY2_A731ParametroMudanzaTipo = new string[] {""} ;
         P00EY2_A730ParametroMudanzaId = new short[1] ;
         P00EY2_A732ParametroMudanzaNombre = new string[] {""} ;
         A731ParametroMudanzaTipo = "";
         A732ParametroMudanzaNombre = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV38OrigenCoordenadas = "";
         AV39WebSession = context.GetSession();
         AV34Result = "";
         AV35SDTSuggestMapBox = new GXBaseCollection<SdtSDTSuggestMapBox_suggestions>( context, "suggestions", "AlmangoX");
         AV36SDTSuggestMapBoxItem = new SdtSDTSuggestMapBox_suggestions(context);
         P00EY3_A735MudanzaId = new long[1] ;
         P00EY3_A741MudanzaDireccionDestino = new string[] {""} ;
         A741MudanzaDireccionDestino = "";
         AV40Origen = "";
         GXt_char2 = "";
         P00EY4_A735MudanzaId = new long[1] ;
         P00EY4_A740MudanzaDireccionOrigen = new string[] {""} ;
         A740MudanzaDireccionOrigen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amudanzaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00EY2_A731ParametroMudanzaTipo, P00EY2_A730ParametroMudanzaId, P00EY2_A732ParametroMudanzaNombre
               }
               , new Object[] {
               P00EY3_A735MudanzaId, P00EY3_A741MudanzaDireccionDestino
               }
               , new Object[] {
               P00EY4_A735MudanzaId, P00EY4_A740MudanzaDireccionOrigen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short A730ParametroMudanzaId ;
      private short AV29IndiceInicio ;
      private short AV28IndiceFin ;
      private short AV37Start ;
      private short AV31Length ;
      private int AV19MaxItems ;
      private int AV43GXV1 ;
      private int AV45GXV2 ;
      private long AV15MudanzaId ;
      private long A735MudanzaId ;
      private string AV14TrnMode ;
      private string GXt_char2 ;
      private bool AV23IsDynamicCall ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private string AV26Combo_DataJson ;
      private string AV34Result ;
      private string AV13ComboName ;
      private string AV24SearchTxtParms ;
      private string AV16SelectedValue ;
      private string AV25SelectedText ;
      private string AV22SearchTxt ;
      private string A731ParametroMudanzaTipo ;
      private string A732ParametroMudanzaNombre ;
      private string AV38OrigenCoordenadas ;
      private string A741MudanzaDireccionDestino ;
      private string AV40Origen ;
      private string A740MudanzaDireccionOrigen ;
      private IGxSession AV39WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00EY2_A731ParametroMudanzaTipo ;
      private short[] P00EY2_A730ParametroMudanzaId ;
      private string[] P00EY2_A732ParametroMudanzaNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GXBaseCollection<SdtSDTSuggestMapBox_suggestions> AV35SDTSuggestMapBox ;
      private SdtSDTSuggestMapBox_suggestions AV36SDTSuggestMapBoxItem ;
      private long[] P00EY3_A735MudanzaId ;
      private string[] P00EY3_A741MudanzaDireccionDestino ;
      private long[] P00EY4_A735MudanzaId ;
      private string[] P00EY4_A740MudanzaDireccionOrigen ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class amudanzaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00EY2;
          prmP00EY2 = new Object[] {
          };
          Object[] prmP00EY3;
          prmP00EY3 = new Object[] {
          new ParDef("@AV15MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00EY4;
          prmP00EY4 = new Object[] {
          new ParDef("@AV15MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EY2", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaNombre] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemAdicional' ORDER BY [ParametroMudanzaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EY2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EY3", "SELECT [MudanzaId], [MudanzaDireccionDestino] FROM [Mudanza] WHERE [MudanzaId] = @AV15MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EY3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EY4", "SELECT [MudanzaId], [MudanzaDireccionOrigen] FROM [Mudanza] WHERE [MudanzaId] = @AV15MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EY4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.mudanzaloaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class mudanzaloaddvcombo_services : GxRestService
 {
    [OperationContract(Name = "MudanzaLoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         string TrnMode ,
                         bool IsDynamicCall ,
                         string MudanzaId ,
                         string SearchTxtParms ,
                         out string SelectedValue ,
                         out string SelectedText ,
                         out string Combo_DataJson )
    {
       SelectedValue = "" ;
       SelectedText = "" ;
       Combo_DataJson = "" ;
       try
       {
          if ( ! ProcessHeaders("mudanzaloaddvcombo") )
          {
             return  ;
          }
          amudanzaloaddvcombo worker = new amudanzaloaddvcombo(context);
          worker.IsMain = RunAsMain ;
          long gxrMudanzaId = 0;
          gxrMudanzaId = (long)(Math.Round(NumberUtil.Val( (string)(MudanzaId), "."), 18, MidpointRounding.ToEven));
          worker.execute(ComboName,TrnMode,IsDynamicCall,gxrMudanzaId,SearchTxtParms,out SelectedValue,out SelectedText,out Combo_DataJson );
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
