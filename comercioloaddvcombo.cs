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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class comercioloaddvcombo : GXProcedure
   {
      public comercioloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercioloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           long aP2_ProveedorID ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ProveedorID = aP2_ProveedorID;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecutePrivate();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    long aP2_ProveedorID ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProveedorID, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 long aP2_ProveedorID ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ProveedorID = aP2_ProveedorID;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedorDashboard", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            if ( StringUtil.StrCmp(AV13ComboName, "BancoId") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMBOITEMS_BANCOID' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_BANCOID' Routine */
         returnInSub = false;
         /* Using cursor P00C12 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A673BancoId = P00C12_A673BancoId[0];
            n673BancoId = P00C12_n673BancoId[0];
            A674BancoNombre = P00C12_A674BancoNombre[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AV12Combo_DataItem.gxTpr_Title = A674BancoNombre;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00C13 */
            pr_default.execute(1, new Object[] {AV15ProveedorID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A133ProveedorID = P00C13_A133ProveedorID[0];
               A673BancoId = P00C13_A673BancoId[0];
               n673BancoId = P00C13_n673BancoId[0];
               AV16SelectedValue = ((0==A673BancoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
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
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00C12_A673BancoId = new long[1] ;
         P00C12_n673BancoId = new bool[] {false} ;
         P00C12_A674BancoNombre = new string[] {""} ;
         A674BancoNombre = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00C13_A133ProveedorID = new long[1] ;
         P00C13_A673BancoId = new long[1] ;
         P00C13_n673BancoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercioloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00C12_A673BancoId, P00C12_A674BancoNombre
               }
               , new Object[] {
               P00C13_A133ProveedorID, P00C13_A673BancoId, P00C13_n673BancoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV15ProveedorID ;
      private long A673BancoId ;
      private long A133ProveedorID ;
      private string AV14TrnMode ;
      private string A674BancoNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n673BancoId ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00C12_A673BancoId ;
      private bool[] P00C12_n673BancoId ;
      private string[] P00C12_A674BancoNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private long[] P00C13_A133ProveedorID ;
      private long[] P00C13_A673BancoId ;
      private bool[] P00C13_n673BancoId ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class comercioloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00C12;
          prmP00C12 = new Object[] {
          };
          Object[] prmP00C13;
          prmP00C13 = new Object[] {
          new ParDef("@AV15ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C12", "SELECT [BancoId], [BancoNombre] FROM [Banco] ORDER BY [BancoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C13", "SELECT [ProveedorID], [BancoId] FROM [Proveedor] WHERE [ProveedorID] = @AV15ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C13,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
