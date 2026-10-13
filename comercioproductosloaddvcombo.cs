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
   public class comercioproductosloaddvcombo : GXProcedure
   {
      public comercioproductosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercioproductosloaddvcombo( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercioProductos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            if ( StringUtil.StrCmp(AV13ComboName, "RubrosId") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMBOITEMS_RUBROSID' */
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
         /* 'LOADCOMBOITEMS_RUBROSID' Routine */
         returnInSub = false;
         /* Using cursor P00CY2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123RubrosEstado = P00CY2_A123RubrosEstado[0];
            n123RubrosEstado = P00CY2_n123RubrosEstado[0];
            A40000RubrosImagen_GXI = P00CY2_A40000RubrosImagen_GXI[0];
            A121RubrosId = P00CY2_A121RubrosId[0];
            A122RubrosNombre = P00CY2_A122RubrosNombre[0];
            A168RubrosImagen = P00CY2_A168RubrosImagen[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
            AV19ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV19ComboTitles.Add(A122RubrosNombre, 0);
            AV20ImageAux = A168RubrosImagen;
            AV22Imageaux_GXI = A40000RubrosImagen_GXI;
            AV19ComboTitles.Add(A40000RubrosImagen_GXI, 0);
            AV12Combo_DataItem.gxTpr_Title = AV19ComboTitles.ToJSonString(false);
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
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
         AV16SelectedValue = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00CY2_A123RubrosEstado = new string[] {""} ;
         P00CY2_n123RubrosEstado = new bool[] {false} ;
         P00CY2_A40000RubrosImagen_GXI = new string[] {""} ;
         P00CY2_A121RubrosId = new short[1] ;
         P00CY2_A122RubrosNombre = new string[] {""} ;
         P00CY2_A168RubrosImagen = new string[] {""} ;
         A123RubrosEstado = "";
         A40000RubrosImagen_GXI = "";
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV19ComboTitles = new GxSimpleCollection<string>();
         AV20ImageAux = "";
         AV22Imageaux_GXI = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercioproductosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00CY2_A123RubrosEstado, P00CY2_n123RubrosEstado, P00CY2_A40000RubrosImagen_GXI, P00CY2_A121RubrosId, P00CY2_A122RubrosNombre, P00CY2_A168RubrosImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private long AV15ProveedorID ;
      private string AV14TrnMode ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n123RubrosEstado ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private string A40000RubrosImagen_GXI ;
      private string AV22Imageaux_GXI ;
      private string A168RubrosImagen ;
      private string AV20ImageAux ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00CY2_A123RubrosEstado ;
      private bool[] P00CY2_n123RubrosEstado ;
      private string[] P00CY2_A40000RubrosImagen_GXI ;
      private short[] P00CY2_A121RubrosId ;
      private string[] P00CY2_A122RubrosNombre ;
      private string[] P00CY2_A168RubrosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private GxSimpleCollection<string> AV19ComboTitles ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class comercioproductosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00CY2;
          prmP00CY2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CY2", "SELECT [RubrosEstado], [RubrosImagen_GXI], [RubrosId], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosEstado] <> 'DES' ORDER BY [RubrosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CY2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                return;
       }
    }

 }

}
