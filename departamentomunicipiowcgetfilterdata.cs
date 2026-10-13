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
   public class departamentomunicipiowcgetfilterdata : GXProcedure
   {
      public departamentomunicipiowcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public departamentomunicipiowcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_DEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV26Session.Get("DepartamentoMunicipioWCGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DepartamentoMunicipioWCGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("DepartamentoMunicipioWCGridState"), null, "", "");
         }
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIOID") == 0 )
            {
               AV11TFDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV13TFDepartamentoMunicipioNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV14TFDepartamentoMunicipioNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARM_&DEPARTAMENTOID") == 0 )
            {
               AV37DepartamentoId = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFDepartamentoMunicipioNombre = AV15SearchTxt;
         AV14TFDepartamentoMunicipioNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFDepartamentoMunicipioId ,
                                              AV12TFDepartamentoMunicipioId_To ,
                                              AV14TFDepartamentoMunicipioNombre_Sel ,
                                              AV13TFDepartamentoMunicipioNombre ,
                                              A114DepartamentoMunicipioId ,
                                              A115DepartamentoMunicipioNombre ,
                                              AV37DepartamentoId ,
                                              A112DepartamentoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFDepartamentoMunicipioNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFDepartamentoMunicipioNombre), 120, "%");
         /* Using cursor P003Z2 */
         pr_default.execute(0, new Object[] {AV37DepartamentoId, AV11TFDepartamentoMunicipioId, AV12TFDepartamentoMunicipioId_To, lV13TFDepartamentoMunicipioNombre, AV14TFDepartamentoMunicipioNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3Z2 = false;
            A112DepartamentoId = P003Z2_A112DepartamentoId[0];
            A115DepartamentoMunicipioNombre = P003Z2_A115DepartamentoMunicipioNombre[0];
            A114DepartamentoMunicipioId = P003Z2_A114DepartamentoMunicipioId[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P003Z2_A112DepartamentoId[0] == A112DepartamentoId ) && ( StringUtil.StrCmp(P003Z2_A115DepartamentoMunicipioNombre[0], A115DepartamentoMunicipioNombre) == 0 ) )
            {
               BRK3Z2 = false;
               A114DepartamentoMunicipioId = P003Z2_A114DepartamentoMunicipioId[0];
               AV25count = (long)(AV25count+1);
               BRK3Z2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A115DepartamentoMunicipioNombre)) ? "<#Empty#>" : A115DepartamentoMunicipioNombre);
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
            if ( ! BRK3Z2 )
            {
               BRK3Z2 = true;
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
         AV13TFDepartamentoMunicipioNombre = "";
         AV14TFDepartamentoMunicipioNombre_Sel = "";
         lV13TFDepartamentoMunicipioNombre = "";
         A115DepartamentoMunicipioNombre = "";
         P003Z2_A112DepartamentoId = new long[1] ;
         P003Z2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P003Z2_A114DepartamentoMunicipioId = new long[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.departamentomunicipiowcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003Z2_A112DepartamentoId, P003Z2_A115DepartamentoMunicipioNombre, P003Z2_A114DepartamentoMunicipioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV38GXV1 ;
      private long AV11TFDepartamentoMunicipioId ;
      private long AV12TFDepartamentoMunicipioId_To ;
      private long AV37DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long AV25count ;
      private string AV13TFDepartamentoMunicipioNombre ;
      private string AV14TFDepartamentoMunicipioNombre_Sel ;
      private string lV13TFDepartamentoMunicipioNombre ;
      private string A115DepartamentoMunicipioNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK3Z2 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
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
      private long[] P003Z2_A112DepartamentoId ;
      private string[] P003Z2_A115DepartamentoMunicipioNombre ;
      private long[] P003Z2_A114DepartamentoMunicipioId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class departamentomunicipiowcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Z2( IGxContext context ,
                                             long AV11TFDepartamentoMunicipioId ,
                                             long AV12TFDepartamentoMunicipioId_To ,
                                             string AV14TFDepartamentoMunicipioNombre_Sel ,
                                             string AV13TFDepartamentoMunicipioNombre ,
                                             long A114DepartamentoMunicipioId ,
                                             string A115DepartamentoMunicipioNombre ,
                                             long AV37DepartamentoId ,
                                             long A112DepartamentoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DepartamentoId], [DepartamentoMunicipioNombre], [DepartamentoMunicipioId] FROM [DepartamentoMunicipio]";
         AddWhere(sWhereString, "([DepartamentoId] = @AV37DepartamentoId)");
         if ( ! (0==AV11TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV11TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] <= @AV12TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDepartamentoMunicipioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFDepartamentoMunicipioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoMunicipioNombre]) like UPPER(@lV13TFDepartamentoMunicipioNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFDepartamentoMunicipioNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFDepartamentoMunicipioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioNombre] = @AV14TFDepartamentoMunicipioNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFDepartamentoMunicipioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DepartamentoId], [DepartamentoMunicipioNombre]";
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
                     return conditional_P003Z2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
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
          Object[] prmP003Z2;
          prmP003Z2 = new Object[] {
          new ParDef("@AV37DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFDepartamentoMunicipioNombre",GXType.Char,120,0) ,
          new ParDef("@AV14TFDepartamentoMunicipioNombre_Sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.departamentomunicipiowcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class departamentomunicipiowcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DepartamentoMunicipioWCGetFilterData" )]
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
          if ( ! ProcessHeaders("departamentomunicipiowcgetfilterdata") )
          {
             return  ;
          }
          departamentomunicipiowcgetfilterdata worker = new departamentomunicipiowcgetfilterdata(context);
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
