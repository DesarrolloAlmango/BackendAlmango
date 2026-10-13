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
namespace GeneXus.Programs.apis {
   public class omotivos : GXProcedure
   {
      public omotivos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public omotivos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MotivoTipo ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo )
      {
         this.AV8MotivoTipo = aP0_MotivoTipo;
         this.AV9SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>( context, "SDTMotivo", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP1_SDTMotivo=this.AV9SDTMotivo;
      }

      public GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> executeUdp( string aP0_MotivoTipo )
      {
         execute(aP0_MotivoTipo, out aP1_SDTMotivo);
         return AV9SDTMotivo ;
      }

      public void executeSubmit( string aP0_MotivoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo )
      {
         this.AV8MotivoTipo = aP0_MotivoTipo;
         this.AV9SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>( context, "SDTMotivo", "AlmangoX") ;
         SubmitImpl();
         aP1_SDTMotivo=this.AV9SDTMotivo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDTMotivo.Clear();
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8MotivoTipo ,
                                              A618MotivoTipo } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00JR2 */
         pr_default.execute(0, new Object[] {AV8MotivoTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A618MotivoTipo = P00JR2_A618MotivoTipo[0];
            n618MotivoTipo = P00JR2_n618MotivoTipo[0];
            A604MotivoId = P00JR2_A604MotivoId[0];
            A616MotivoNombre = P00JR2_A616MotivoNombre[0];
            AV10Item = new GeneXus.Programs.apis.SdtSDTMotivo(context);
            AV10Item.gxTpr_Motivoid = A604MotivoId;
            AV10Item.gxTpr_Motivonombre = A616MotivoNombre;
            AV10Item.gxTpr_Motivotipo = A618MotivoTipo;
            AV9SDTMotivo.Add(AV10Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
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
         AV9SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>( context, "SDTMotivo", "AlmangoX");
         A618MotivoTipo = "";
         P00JR2_A618MotivoTipo = new string[] {""} ;
         P00JR2_n618MotivoTipo = new bool[] {false} ;
         P00JR2_A604MotivoId = new long[1] ;
         P00JR2_A616MotivoNombre = new string[] {""} ;
         A616MotivoNombre = "";
         AV10Item = new GeneXus.Programs.apis.SdtSDTMotivo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.omotivos__default(),
            new Object[][] {
                new Object[] {
               P00JR2_A618MotivoTipo, P00JR2_n618MotivoTipo, P00JR2_A604MotivoId, P00JR2_A616MotivoNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A604MotivoId ;
      private string AV8MotivoTipo ;
      private string A618MotivoTipo ;
      private string A616MotivoNombre ;
      private bool n618MotivoTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> AV9SDTMotivo ;
      private IDataStoreProvider pr_default ;
      private string[] P00JR2_A618MotivoTipo ;
      private bool[] P00JR2_n618MotivoTipo ;
      private long[] P00JR2_A604MotivoId ;
      private string[] P00JR2_A616MotivoNombre ;
      private GeneXus.Programs.apis.SdtSDTMotivo AV10Item ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo ;
   }

   public class omotivos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00JR2( IGxContext context ,
                                             string AV8MotivoTipo ,
                                             string A618MotivoTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MotivoTipo], [MotivoId], [MotivoNombre] FROM [Motivo]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8MotivoTipo)) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV8MotivoTipo)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MotivoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00JR2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00JR2;
          prmP00JR2 = new Object[] {
          new ParDef("@AV8MotivoTipo",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JR2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}
