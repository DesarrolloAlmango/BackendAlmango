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
namespace GeneXus.Programs.dashboard {
   public class dashboard1loaddvcombo : GXProcedure
   {
      public dashboard1loaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dashboard1loaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_RubrosId ,
                           string aP2_SearchTxtParms ,
                           out string aP3_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV21Cond_RubrosId = aP1_Cond_RubrosId;
         this.AV18SearchTxtParms = aP2_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_Combo_DataJson=this.AV19Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_RubrosId ,
                                string aP2_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_RubrosId, aP2_SearchTxtParms, out aP3_Combo_DataJson);
         return AV19Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_RubrosId ,
                                 string aP2_SearchTxtParms ,
                                 out string aP3_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV21Cond_RubrosId = aP1_Cond_RubrosId;
         this.AV18SearchTxtParms = aP2_SearchTxtParms;
         this.AV19Combo_DataJson = "" ;
         SubmitImpl();
         aP3_Combo_DataJson=this.AV19Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( 0 == 1 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "Dashboard1", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               AV11MaxItems = 10;
               AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV18SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
               AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? "" : StringUtil.Substring( AV18SearchTxtParms, 3, -1));
               AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
               if ( StringUtil.StrCmp(AV17ComboName, "MedidasId") == 0 )
               {
                  /* Execute user subroutine: 'LOADCOMBOITEMS_MEDIDASID' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
            }
         }
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV18SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV18SearchTxtParms)) ? "" : StringUtil.Substring( AV18SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         /* Execute user subroutine: 'LOADCOMBOITEMS_MEDIDASID' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_MEDIDASID' Routine */
         returnInSub = false;
         GXPagingFrom2 = AV12SkipItems;
         GXPagingTo2 = AV11MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14SearchTxt ,
                                              A138MedidasNombre ,
                                              A121RubrosId ,
                                              AV21Cond_RubrosId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         /* Using cursor P00G02 */
         pr_default.execute(0, new Object[] {AV21Cond_RubrosId, lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A121RubrosId = P00G02_A121RubrosId[0];
            A138MedidasNombre = P00G02_A138MedidasNombre[0];
            A137MedidasID = P00G02_A137MedidasID[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AV16Combo_DataItem.gxTpr_Title = A138MedidasNombre;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            if ( AV15Combo_Data.Count > AV11MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV19Combo_DataJson = AV15Combo_Data.ToJSonString(false);
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
         AV19Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A138MedidasNombre = "";
         P00G02_A121RubrosId = new short[1] ;
         P00G02_A138MedidasNombre = new string[] {""} ;
         P00G02_A137MedidasID = new long[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dashboard.dashboard1loaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00G02_A121RubrosId, P00G02_A138MedidasNombre, P00G02_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21Cond_RubrosId ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A121RubrosId ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long A137MedidasID ;
      private string A138MedidasNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string AV17ComboName ;
      private string AV18SearchTxtParms ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private short[] P00G02_A121RubrosId ;
      private string[] P00G02_A138MedidasNombre ;
      private long[] P00G02_A137MedidasID ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private string aP3_Combo_DataJson ;
   }

   public class dashboard1loaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G02( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A138MedidasNombre ,
                                             short A121RubrosId ,
                                             short AV21Cond_RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [RubrosId], [MedidasNombre], [MedidasID]";
         sFromString = " FROM [RubrosMedidas]";
         sOrderString = "";
         AddWhere(sWhereString, "([RubrosId] = @AV21Cond_RubrosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(UPPER([MedidasNombre]) like '%' + UPPER(@lV14SearchTxt))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         sOrderString += " ORDER BY [MedidasNombre]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
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
                     return conditional_P00G02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmP00G02;
          prmP00G02 = new Object[] {
          new ParDef("@AV21Cond_RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G02,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.dashboard.dashboard1loaddvcombo_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class dashboard1loaddvcombo_services : GxRestService
 {
    [OperationContract(Name = "Dashboard1LoadDVCombo" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string ComboName ,
                         short Cond_RubrosId ,
                         string SearchTxtParms ,
                         out string Combo_DataJson )
    {
       Combo_DataJson = "" ;
       try
       {
          if ( ! ProcessHeaders("dashboard.dashboard1loaddvcombo") )
          {
             return  ;
          }
          dashboard1loaddvcombo worker = new dashboard1loaddvcombo(context);
          worker.IsMain = RunAsMain ;
          worker.execute(ComboName,Cond_RubrosId,SearchTxtParms,out Combo_DataJson );
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
