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
   public class aincidencia : GXProcedure
   {
      public aincidencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aincidencia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_IncidenciaCodRef ,
                           string aP1_Origen ,
                           string aP2_IncidenciaEstado ,
                           long aP3_MotivoId ,
                           DateTime aP4_IncidenciaFechaAlta ,
                           DateTime aP5_IncidenciaFechaActualizacion ,
                           string aP6_IncidenciaUsrAlta ,
                           string aP7_IncidenciaUsrActualizacion ,
                           string aP8_IncidenciaDetalleDesc ,
                           out long aP9_IncidenciaAux ,
                           out bool aP10_IsOk )
      {
         this.AV9IncidenciaCodRef = aP0_IncidenciaCodRef;
         this.AV20Origen = aP1_Origen;
         this.AV12IncidenciaEstado = aP2_IncidenciaEstado;
         this.AV19MotivoId = aP3_MotivoId;
         this.AV14IncidenciaFechaAlta = aP4_IncidenciaFechaAlta;
         this.AV13IncidenciaFechaActualizacion = aP5_IncidenciaFechaActualizacion;
         this.AV16IncidenciaUsrAlta = aP6_IncidenciaUsrAlta;
         this.AV15IncidenciaUsrActualizacion = aP7_IncidenciaUsrActualizacion;
         this.AV11IncidenciaDetalleDesc = aP8_IncidenciaDetalleDesc;
         this.AV8IncidenciaAux = 0 ;
         this.AV17IsOk = false ;
         initialize();
         ExecutePrivate();
         aP9_IncidenciaAux=this.AV8IncidenciaAux;
         aP10_IsOk=this.AV17IsOk;
      }

      public bool executeUdp( string aP0_IncidenciaCodRef ,
                              string aP1_Origen ,
                              string aP2_IncidenciaEstado ,
                              long aP3_MotivoId ,
                              DateTime aP4_IncidenciaFechaAlta ,
                              DateTime aP5_IncidenciaFechaActualizacion ,
                              string aP6_IncidenciaUsrAlta ,
                              string aP7_IncidenciaUsrActualizacion ,
                              string aP8_IncidenciaDetalleDesc ,
                              out long aP9_IncidenciaAux )
      {
         execute(aP0_IncidenciaCodRef, aP1_Origen, aP2_IncidenciaEstado, aP3_MotivoId, aP4_IncidenciaFechaAlta, aP5_IncidenciaFechaActualizacion, aP6_IncidenciaUsrAlta, aP7_IncidenciaUsrActualizacion, aP8_IncidenciaDetalleDesc, out aP9_IncidenciaAux, out aP10_IsOk);
         return AV17IsOk ;
      }

      public void executeSubmit( string aP0_IncidenciaCodRef ,
                                 string aP1_Origen ,
                                 string aP2_IncidenciaEstado ,
                                 long aP3_MotivoId ,
                                 DateTime aP4_IncidenciaFechaAlta ,
                                 DateTime aP5_IncidenciaFechaActualizacion ,
                                 string aP6_IncidenciaUsrAlta ,
                                 string aP7_IncidenciaUsrActualizacion ,
                                 string aP8_IncidenciaDetalleDesc ,
                                 out long aP9_IncidenciaAux ,
                                 out bool aP10_IsOk )
      {
         this.AV9IncidenciaCodRef = aP0_IncidenciaCodRef;
         this.AV20Origen = aP1_Origen;
         this.AV12IncidenciaEstado = aP2_IncidenciaEstado;
         this.AV19MotivoId = aP3_MotivoId;
         this.AV14IncidenciaFechaAlta = aP4_IncidenciaFechaAlta;
         this.AV13IncidenciaFechaActualizacion = aP5_IncidenciaFechaActualizacion;
         this.AV16IncidenciaUsrAlta = aP6_IncidenciaUsrAlta;
         this.AV15IncidenciaUsrActualizacion = aP7_IncidenciaUsrActualizacion;
         this.AV11IncidenciaDetalleDesc = aP8_IncidenciaDetalleDesc;
         this.AV8IncidenciaAux = 0 ;
         this.AV17IsOk = false ;
         SubmitImpl();
         aP9_IncidenciaAux=this.AV8IncidenciaAux;
         aP10_IsOk=this.AV17IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17IsOk = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9IncidenciaCodRef)) )
         {
            AV22GXLvl3 = 0;
            /* Using cursor P00JS2 */
            pr_default.execute(0, new Object[] {AV9IncidenciaCodRef});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A606IncidenciaCodRef = P00JS2_A606IncidenciaCodRef[0];
               A613IncidenciaUltLin = P00JS2_A613IncidenciaUltLin[0];
               A603IncidenciaId = P00JS2_A603IncidenciaId[0];
               AV22GXLvl3 = 1;
               AV18Linea = (long)(A613IncidenciaUltLin+1);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV22GXLvl3 == 0 )
            {
               AV18Linea = 1;
            }
            /*
               INSERT RECORD ON TABLE Incidencia

            */
            A611IncidenciaOrigen = AV20Origen;
            A606IncidenciaCodRef = AV9IncidenciaCodRef;
            A608IncidenciaEstado = AV12IncidenciaEstado;
            A604MotivoId = AV19MotivoId;
            A610IncidenciaFechaAlta = AV14IncidenciaFechaAlta;
            A609IncidenciaFechaActualizacion = AV13IncidenciaFechaActualizacion;
            A615IncidenciaUsrAlta = AV16IncidenciaUsrAlta;
            A614IncidenciaUsrActualizacion = AV15IncidenciaUsrActualizacion;
            A613IncidenciaUltLin = (short)(AV18Linea);
            /* Using cursor P00JS3 */
            pr_default.execute(1, new Object[] {A611IncidenciaOrigen, A606IncidenciaCodRef, A608IncidenciaEstado, A604MotivoId, A610IncidenciaFechaAlta, A609IncidenciaFechaActualizacion, A615IncidenciaUsrAlta, A614IncidenciaUsrActualizacion, A613IncidenciaUltLin});
            A603IncidenciaId = P00JS3_A603IncidenciaId[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Incidencia");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            AV8IncidenciaAux = A603IncidenciaId;
            if ( AV8IncidenciaAux == 0 )
            {
               cleanup();
               if (true) return;
            }
            /*
               INSERT RECORD ON TABLE IncidenciaDetalle

            */
            A603IncidenciaId = AV8IncidenciaAux;
            A605IncidenciaDetalleId = AV18Linea;
            A607IncidenciaDetalleDesc = AV11IncidenciaDetalleDesc;
            AV17IsOk = true;
            /* Using cursor P00JS4 */
            pr_default.execute(2, new Object[] {A603IncidenciaId, A605IncidenciaDetalleId, A607IncidenciaDetalleDesc});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("IncidenciaDetalle");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.aincidencia",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00JS2_A606IncidenciaCodRef = new string[] {""} ;
         P00JS2_A613IncidenciaUltLin = new short[1] ;
         P00JS2_A603IncidenciaId = new long[1] ;
         A606IncidenciaCodRef = "";
         A611IncidenciaOrigen = "";
         A608IncidenciaEstado = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         A615IncidenciaUsrAlta = "";
         A614IncidenciaUsrActualizacion = "";
         P00JS3_A603IncidenciaId = new long[1] ;
         Gx_emsg = "";
         A607IncidenciaDetalleDesc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.aincidencia__default(),
            new Object[][] {
                new Object[] {
               P00JS2_A606IncidenciaCodRef, P00JS2_A613IncidenciaUltLin, P00JS2_A603IncidenciaId
               }
               , new Object[] {
               P00JS3_A603IncidenciaId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22GXLvl3 ;
      private short A613IncidenciaUltLin ;
      private int GX_INS89 ;
      private int GX_INS90 ;
      private long AV19MotivoId ;
      private long AV8IncidenciaAux ;
      private long A603IncidenciaId ;
      private long AV18Linea ;
      private long A604MotivoId ;
      private long A605IncidenciaDetalleId ;
      private string AV20Origen ;
      private string AV12IncidenciaEstado ;
      private string AV16IncidenciaUsrAlta ;
      private string AV15IncidenciaUsrActualizacion ;
      private string AV11IncidenciaDetalleDesc ;
      private string A611IncidenciaOrigen ;
      private string A608IncidenciaEstado ;
      private string A615IncidenciaUsrAlta ;
      private string A614IncidenciaUsrActualizacion ;
      private string Gx_emsg ;
      private string A607IncidenciaDetalleDesc ;
      private DateTime AV14IncidenciaFechaAlta ;
      private DateTime AV13IncidenciaFechaActualizacion ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private bool AV17IsOk ;
      private string AV9IncidenciaCodRef ;
      private string A606IncidenciaCodRef ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00JS2_A606IncidenciaCodRef ;
      private short[] P00JS2_A613IncidenciaUltLin ;
      private long[] P00JS2_A603IncidenciaId ;
      private long[] P00JS3_A603IncidenciaId ;
      private long aP9_IncidenciaAux ;
      private bool aP10_IsOk ;
   }

   public class aincidencia__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JS2;
          prmP00JS2 = new Object[] {
          new ParDef("@AV9IncidenciaCodRef",GXType.NVarChar,40,0)
          };
          Object[] prmP00JS3;
          prmP00JS3 = new Object[] {
          new ParDef("@IncidenciaOrigen",GXType.NChar,3,0) ,
          new ParDef("@IncidenciaCodRef",GXType.NVarChar,40,0) ,
          new ParDef("@IncidenciaEstado",GXType.NChar,3,0) ,
          new ParDef("@MotivoId",GXType.Decimal,18,0) ,
          new ParDef("@IncidenciaFechaAlta",GXType.Date,8,0) ,
          new ParDef("@IncidenciaFechaActualizacion",GXType.Date,8,0) ,
          new ParDef("@IncidenciaUsrAlta",GXType.NChar,20,0) ,
          new ParDef("@IncidenciaUsrActualizacion",GXType.NChar,20,0) ,
          new ParDef("@IncidenciaUltLin",GXType.Int16,4,0)
          };
          Object[] prmP00JS4;
          prmP00JS4 = new Object[] {
          new ParDef("@IncidenciaId",GXType.Decimal,18,0) ,
          new ParDef("@IncidenciaDetalleId",GXType.Decimal,18,0) ,
          new ParDef("@IncidenciaDetalleDesc",GXType.NChar,250,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JS2", "SELECT TOP 1 [IncidenciaCodRef], [IncidenciaUltLin], [IncidenciaId] FROM [Incidencia] WHERE [IncidenciaCodRef] = @AV9IncidenciaCodRef ORDER BY [IncidenciaUltLin] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JS2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00JS3", "INSERT INTO [Incidencia]([IncidenciaOrigen], [IncidenciaCodRef], [IncidenciaEstado], [MotivoId], [IncidenciaFechaAlta], [IncidenciaFechaActualizacion], [IncidenciaUsrAlta], [IncidenciaUsrActualizacion], [IncidenciaUltLin]) VALUES(@IncidenciaOrigen, @IncidenciaCodRef, @IncidenciaEstado, @MotivoId, @IncidenciaFechaAlta, @IncidenciaFechaActualizacion, @IncidenciaUsrAlta, @IncidenciaUsrActualizacion, @IncidenciaUltLin); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00JS3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JS4", "INSERT INTO [IncidenciaDetalle]([IncidenciaId], [IncidenciaDetalleId], [IncidenciaDetalleDesc]) VALUES(@IncidenciaId, @IncidenciaDetalleId, @IncidenciaDetalleDesc)", GxErrorMask.GX_NOMASK,prmP00JS4)
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
