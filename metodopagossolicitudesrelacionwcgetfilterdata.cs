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
   public class metodopagossolicitudesrelacionwcgetfilterdata : GXProcedure
   {
      public metodopagossolicitudesrelacionwcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagossolicitudesrelacionwcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SOLICITUDESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESNOMBREOPTIONS' */
               S121 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("MetodoPagosSolicitudesRelacionWCGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MetodoPagosSolicitudesRelacionWCGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("MetodoPagosSolicitudesRelacionWCGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV11TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE") == 0 )
            {
               AV13TFSolicitudesNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV14TFSolicitudesNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARM_&METODOPAGOSID") == 0 )
            {
               AV38MetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSOLICITUDESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFSolicitudesNombre = AV15SearchTxt;
         AV14TFSolicitudesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV37FilterFullText ,
                                              AV11TFSolicitudesID ,
                                              AV12TFSolicitudesID_To ,
                                              AV14TFSolicitudesNombre_Sel ,
                                              AV13TFSolicitudesNombre ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              AV38MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV37FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV37FilterFullText), "%", "");
         lV13TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFSolicitudesNombre), 100, "%");
         /* Using cursor P004K2 */
         pr_default.execute(0, new Object[] {AV38MetodoPagosID, lV37FilterFullText, lV37FilterFullText, AV11TFSolicitudesID, AV12TFSolicitudesID_To, lV13TFSolicitudesNombre, AV14TFSolicitudesNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4K2 = false;
            A128MetodoPagosID = P004K2_A128MetodoPagosID[0];
            A171SolicitudesNombre = P004K2_A171SolicitudesNombre[0];
            A127SolicitudesID = P004K2_A127SolicitudesID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004K2_A128MetodoPagosID[0] == A128MetodoPagosID ) && ( StringUtil.StrCmp(P004K2_A171SolicitudesNombre[0], A171SolicitudesNombre) == 0 ) )
            {
               BRK4K2 = false;
               A127SolicitudesID = P004K2_A127SolicitudesID[0];
               AV25count = (long)(AV25count+1);
               BRK4K2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171SolicitudesNombre)) ? "<#Empty#>" : A171SolicitudesNombre);
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
            if ( ! BRK4K2 )
            {
               BRK4K2 = true;
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
         AV13TFSolicitudesNombre = "";
         AV14TFSolicitudesNombre_Sel = "";
         lV37FilterFullText = "";
         lV13TFSolicitudesNombre = "";
         A171SolicitudesNombre = "";
         P004K2_A128MetodoPagosID = new long[1] ;
         P004K2_A171SolicitudesNombre = new string[] {""} ;
         P004K2_A127SolicitudesID = new long[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagossolicitudesrelacionwcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004K2_A128MetodoPagosID, P004K2_A171SolicitudesNombre, P004K2_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV39GXV1 ;
      private long AV11TFSolicitudesID ;
      private long AV12TFSolicitudesID_To ;
      private long AV38MetodoPagosID ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private long AV25count ;
      private string AV13TFSolicitudesNombre ;
      private string AV14TFSolicitudesNombre_Sel ;
      private string lV13TFSolicitudesNombre ;
      private string A171SolicitudesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4K2 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string lV37FilterFullText ;
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
      private long[] P004K2_A128MetodoPagosID ;
      private string[] P004K2_A171SolicitudesNombre ;
      private long[] P004K2_A127SolicitudesID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class metodopagossolicitudesrelacionwcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004K2( IGxContext context ,
                                             string AV37FilterFullText ,
                                             long AV11TFSolicitudesID ,
                                             long AV12TFSolicitudesID_To ,
                                             string AV14TFSolicitudesNombre_Sel ,
                                             string AV13TFSolicitudesNombre ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             long AV38MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MetodoPagosID], [SolicitudesNombre], [SolicitudesID] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MetodoPagosID] = @AV38MetodoPagosID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37FilterFullText)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([SolicitudesID] AS decimal(18,0))) like '%' + @lV37FilterFullText) or ( UPPER([SolicitudesNombre]) like '%' + UPPER(@lV37FilterFullText)))");
         }
         else
         {
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV11TFSolicitudesID) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV11TFSolicitudesID)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV12TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV12TFSolicitudesID_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesNombre]) like UPPER(@lV13TFSolicitudesNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesNombre] = @AV14TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MetodoPagosID], [SolicitudesNombre]";
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
                     return conditional_P004K2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmP004K2;
          prmP004K2 = new Object[] {
          new ParDef("@AV38MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV37FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@AV11TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFSolicitudesNombre_Sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.metodopagossolicitudesrelacionwcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class metodopagossolicitudesrelacionwcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MetodoPagosSolicitudesRelacionWCGetFilterData" )]
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
          if ( ! ProcessHeaders("metodopagossolicitudesrelacionwcgetfilterdata") )
          {
             return  ;
          }
          metodopagossolicitudesrelacionwcgetfilterdata worker = new metodopagossolicitudesrelacionwcgetfilterdata(context);
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
