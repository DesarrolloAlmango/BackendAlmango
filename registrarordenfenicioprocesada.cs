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
   public class registrarordenfenicioprocesada : GXProcedure
   {
      public registrarordenfenicioprocesada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public registrarordenfenicioprocesada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_IdOrdenFenicio ,
                           long aP1_ComercioEccomerceId ,
                           long aP2_ComercioId ,
                           string aP3_TipoOperacion ,
                           string aP4_EstadoOperacion ,
                           string aP5_RequestJson ,
                           string aP6_ResponseJson ,
                           string aP7_MensajeBC ,
                           DateTime aP8_FechaDesde ,
                           DateTime aP9_FechaHasta ,
                           string aP10_MensajeError ,
                           out bool aP11_ResultadoOk )
      {
         this.AV12IdOrdenFenicio = aP0_IdOrdenFenicio;
         this.AV20ComercioEccomerceId = aP1_ComercioEccomerceId;
         this.AV19ComercioId = aP2_ComercioId;
         this.AV8TipoOperacion = aP3_TipoOperacion;
         this.AV13EstadoOperacion = aP4_EstadoOperacion;
         this.AV9RequestJson = aP5_RequestJson;
         this.AV10ResponseJson = aP6_ResponseJson;
         this.AV15MensajeBC = aP7_MensajeBC;
         this.AV21FechaDesde = aP8_FechaDesde;
         this.AV22FechaHasta = aP9_FechaHasta;
         this.AV11MensajeError = aP10_MensajeError;
         this.AV14ResultadoOk = false ;
         initialize();
         ExecutePrivate();
         aP11_ResultadoOk=this.AV14ResultadoOk;
      }

      public bool executeUdp( string aP0_IdOrdenFenicio ,
                              long aP1_ComercioEccomerceId ,
                              long aP2_ComercioId ,
                              string aP3_TipoOperacion ,
                              string aP4_EstadoOperacion ,
                              string aP5_RequestJson ,
                              string aP6_ResponseJson ,
                              string aP7_MensajeBC ,
                              DateTime aP8_FechaDesde ,
                              DateTime aP9_FechaHasta ,
                              string aP10_MensajeError )
      {
         execute(aP0_IdOrdenFenicio, aP1_ComercioEccomerceId, aP2_ComercioId, aP3_TipoOperacion, aP4_EstadoOperacion, aP5_RequestJson, aP6_ResponseJson, aP7_MensajeBC, aP8_FechaDesde, aP9_FechaHasta, aP10_MensajeError, out aP11_ResultadoOk);
         return AV14ResultadoOk ;
      }

      public void executeSubmit( string aP0_IdOrdenFenicio ,
                                 long aP1_ComercioEccomerceId ,
                                 long aP2_ComercioId ,
                                 string aP3_TipoOperacion ,
                                 string aP4_EstadoOperacion ,
                                 string aP5_RequestJson ,
                                 string aP6_ResponseJson ,
                                 string aP7_MensajeBC ,
                                 DateTime aP8_FechaDesde ,
                                 DateTime aP9_FechaHasta ,
                                 string aP10_MensajeError ,
                                 out bool aP11_ResultadoOk )
      {
         this.AV12IdOrdenFenicio = aP0_IdOrdenFenicio;
         this.AV20ComercioEccomerceId = aP1_ComercioEccomerceId;
         this.AV19ComercioId = aP2_ComercioId;
         this.AV8TipoOperacion = aP3_TipoOperacion;
         this.AV13EstadoOperacion = aP4_EstadoOperacion;
         this.AV9RequestJson = aP5_RequestJson;
         this.AV10ResponseJson = aP6_ResponseJson;
         this.AV15MensajeBC = aP7_MensajeBC;
         this.AV21FechaDesde = aP8_FechaDesde;
         this.AV22FechaHasta = aP9_FechaHasta;
         this.AV11MensajeError = aP10_MensajeError;
         this.AV14ResultadoOk = false ;
         SubmitImpl();
         aP11_ResultadoOk=this.AV14ResultadoOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17UltimoOperacionesId = 0;
         /* Using cursor P00LI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A554OperacionesId = P00LI2_A554OperacionesId[0];
            AV17UltimoOperacionesId = A554OperacionesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18NuevoOperacionesId = (long)(AV17UltimoOperacionesId+1);
         /*
            INSERT RECORD ON TABLE Operaciones

         */
         A554OperacionesId = AV18NuevoOperacionesId;
         A649OperacionesTipo = AV8TipoOperacion;
         n649OperacionesTipo = false;
         A555OperacionesRef = AV12IdOrdenFenicio;
         n555OperacionesRef = false;
         A577OperacionesEstado = AV13EstadoOperacion;
         n577OperacionesEstado = false;
         A962OperacionesComercioId1 = AV19ComercioId;
         n962OperacionesComercioId1 = false;
         A963OperacionesComercioId2 = AV20ComercioEccomerceId;
         n963OperacionesComercioId2 = false;
         A575OperacionesRequest = AV9RequestJson;
         n575OperacionesRequest = false;
         A576OperacionesResponse = AV10ResponseJson;
         n576OperacionesResponse = false;
         A583OperacionesAux1 = AV11MensajeError;
         n583OperacionesAux1 = false;
         A585OperacionesAux3 = AV15MensajeBC;
         n585OperacionesAux3 = false;
         A658OperacionesFechaDesde = AV21FechaDesde;
         n658OperacionesFechaDesde = false;
         A659OperacionesFechaHasta = AV22FechaHasta;
         n659OperacionesFechaHasta = false;
         A581OperacionesFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n581OperacionesFechaAlta = false;
         /* Using cursor P00LI3 */
         pr_default.execute(1, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n575OperacionesRequest, A575OperacionesRequest, n576OperacionesResponse, A576OperacionesResponse, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n583OperacionesAux1, A583OperacionesAux1, n585OperacionesAux3, A585OperacionesAux3, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n962OperacionesComercioId1, A962OperacionesComercioId1, n963OperacionesComercioId2, A963OperacionesComercioId2});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Operaciones");
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
         AV14ResultadoOk = true;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("registrarordenfenicioprocesada",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00LI2_A554OperacionesId = new long[1] ;
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A577OperacionesEstado = "";
         A575OperacionesRequest = "";
         A576OperacionesResponse = "";
         A583OperacionesAux1 = "";
         A585OperacionesAux3 = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A581OperacionesFechaAlta = DateTime.MinValue;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registrarordenfenicioprocesada__default(),
            new Object[][] {
                new Object[] {
               P00LI2_A554OperacionesId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS82 ;
      private long AV20ComercioEccomerceId ;
      private long AV19ComercioId ;
      private long AV17UltimoOperacionesId ;
      private long A554OperacionesId ;
      private long AV18NuevoOperacionesId ;
      private long A962OperacionesComercioId1 ;
      private long A963OperacionesComercioId2 ;
      private string AV12IdOrdenFenicio ;
      private string AV8TipoOperacion ;
      private string AV13EstadoOperacion ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A577OperacionesEstado ;
      private string Gx_emsg ;
      private DateTime AV21FechaDesde ;
      private DateTime AV22FechaHasta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private bool AV14ResultadoOk ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n577OperacionesEstado ;
      private bool n962OperacionesComercioId1 ;
      private bool n963OperacionesComercioId2 ;
      private bool n575OperacionesRequest ;
      private bool n576OperacionesResponse ;
      private bool n583OperacionesAux1 ;
      private bool n585OperacionesAux3 ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n581OperacionesFechaAlta ;
      private string AV9RequestJson ;
      private string AV10ResponseJson ;
      private string AV15MensajeBC ;
      private string A575OperacionesRequest ;
      private string A576OperacionesResponse ;
      private string A585OperacionesAux3 ;
      private string AV11MensajeError ;
      private string A583OperacionesAux1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00LI2_A554OperacionesId ;
      private bool aP11_ResultadoOk ;
   }

   public class registrarordenfenicioprocesada__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00LI2;
          prmP00LI2 = new Object[] {
          };
          Object[] prmP00LI3;
          prmP00LI3 = new Object[] {
          new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesRequest",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@OperacionesResponse",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesAux1",GXType.NVarChar,120,0){Nullable=true} ,
          new ParDef("@OperacionesAux3",GXType.NVarChar,2097152,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesFechaDesde",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesFechaHasta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesComercioId1",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@OperacionesComercioId2",GXType.Decimal,18,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00LI2", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LI2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00LI3", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesRequest], [OperacionesResponse], [OperacionesFechaAlta], [OperacionesAux1], [OperacionesAux3], [OperacionesEstado], [OperacionesTipo], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux2], [OperacionesNombreRef], [OperacionesMonId], [OperacionesBlob1], [OperacionesBlob2], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesRequest, @OperacionesResponse, @OperacionesFechaAlta, @OperacionesAux1, @OperacionesAux3, @OperacionesEstado, @OperacionesTipo, @OperacionesFechaDesde, @OperacionesFechaHasta, @OperacionesComercioId1, @OperacionesComercioId2, convert(int, 0), '', '', convert(int, 0), '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', convert( DATETIME, '17530101', 112 ), '', '', convert(int, 0), CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00LI3)
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
                return;
       }
    }

 }

}
