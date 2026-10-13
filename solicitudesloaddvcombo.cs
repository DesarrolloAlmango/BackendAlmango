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
   public class solicitudesloaddvcombo : GXProcedure
   {
      public solicitudesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           long aP2_SolicitudesID ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15SolicitudesID = aP2_SolicitudesID;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecutePrivate();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    long aP2_SolicitudesID ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_SolicitudesID, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 long aP2_SolicitudesID ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15SolicitudesID = aP2_SolicitudesID;
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            if ( StringUtil.StrCmp(AV13ComboName, "EstadosSolId") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMBOITEMS_ESTADOSSOLID' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(AV13ComboName, "ProveedorID") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMBOITEMS_PROVEEDORID' */
               S121 ();
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
         /* 'LOADCOMBOITEMS_ESTADOSSOLID' Routine */
         returnInSub = false;
         /* Using cursor P00CC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P00CC2_A107EstadosTipo[0];
            A108EstadosGenericosId = P00CC2_A108EstadosGenericosId[0];
            A109EstadosGenericosNombre = P00CC2_A109EstadosGenericosNombre[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
               AV12Combo_DataItem.gxTpr_Title = A109EstadosGenericosNombre;
               AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00CC3 */
            pr_default.execute(1, new Object[] {AV15SolicitudesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A127SolicitudesID = P00CC3_A127SolicitudesID[0];
               A131EstadosSolId = P00CC3_A131EstadosSolId[0];
               AV16SelectedValue = ((0==A131EstadosSolId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A131EstadosSolId), 5, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROVEEDORID' Routine */
         returnInSub = false;
         /* Using cursor P00CC4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A344ProveedorEstado = P00CC4_A344ProveedorEstado[0];
            A133ProveedorID = P00CC4_A133ProveedorID[0];
            A282ProveedorNombre = P00CC4_A282ProveedorNombre[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
            AV12Combo_DataItem.gxTpr_Title = A282ProveedorNombre;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00CC5 */
            pr_default.execute(3, new Object[] {AV15SolicitudesID});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A127SolicitudesID = P00CC5_A127SolicitudesID[0];
               A133ProveedorID = P00CC5_A133ProveedorID[0];
               AV16SelectedValue = ((0==A133ProveedorID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
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
         P00CC2_A107EstadosTipo = new string[] {""} ;
         P00CC2_A108EstadosGenericosId = new int[1] ;
         P00CC2_A109EstadosGenericosNombre = new string[] {""} ;
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00CC3_A127SolicitudesID = new long[1] ;
         P00CC3_A131EstadosSolId = new int[1] ;
         P00CC4_A344ProveedorEstado = new string[] {""} ;
         P00CC4_A133ProveedorID = new long[1] ;
         P00CC4_A282ProveedorNombre = new string[] {""} ;
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         P00CC5_A127SolicitudesID = new long[1] ;
         P00CC5_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00CC2_A107EstadosTipo, P00CC2_A108EstadosGenericosId, P00CC2_A109EstadosGenericosNombre
               }
               , new Object[] {
               P00CC3_A127SolicitudesID, P00CC3_A131EstadosSolId
               }
               , new Object[] {
               P00CC4_A344ProveedorEstado, P00CC4_A133ProveedorID, P00CC4_A282ProveedorNombre
               }
               , new Object[] {
               P00CC5_A127SolicitudesID, P00CC5_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A108EstadosGenericosId ;
      private int A131EstadosSolId ;
      private long AV15SolicitudesID ;
      private long A127SolicitudesID ;
      private long A133ProveedorID ;
      private string AV14TrnMode ;
      private string A107EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00CC2_A107EstadosTipo ;
      private int[] P00CC2_A108EstadosGenericosId ;
      private string[] P00CC2_A109EstadosGenericosNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private long[] P00CC3_A127SolicitudesID ;
      private int[] P00CC3_A131EstadosSolId ;
      private string[] P00CC4_A344ProveedorEstado ;
      private long[] P00CC4_A133ProveedorID ;
      private string[] P00CC4_A282ProveedorNombre ;
      private long[] P00CC5_A127SolicitudesID ;
      private long[] P00CC5_A133ProveedorID ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class solicitudesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00CC2;
          prmP00CC2 = new Object[] {
          };
          Object[] prmP00CC3;
          prmP00CC3 = new Object[] {
          new ParDef("@AV15SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00CC4;
          prmP00CC4 = new Object[] {
          };
          Object[] prmP00CC5;
          prmP00CC5 = new Object[] {
          new ParDef("@AV15SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CC2", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CC3", "SELECT [SolicitudesID], [EstadosSolId] FROM [Solicitudes] WHERE [SolicitudesID] = @AV15SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CC4", "SELECT [ProveedorEstado], [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorEstado] = 'HAB' ORDER BY [ProveedorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CC5", "SELECT [SolicitudesID], [ProveedorID] FROM [Solicitudes] WHERE [SolicitudesID] = @AV15SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CC5,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
