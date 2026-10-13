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
   public class aingresaralista : GXProcedure
   {
      public aingresaralista( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aingresaralista( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ListaId ,
                           long aP1_ProveedorID ,
                           string aP2_ProfesionalesId ,
                           bool aP3_Proveedor ,
                           string aP4_Motivo ,
                           out bool aP5_IsOk )
      {
         this.AV10ListaId = aP0_ListaId;
         this.AV11ProveedorID = aP1_ProveedorID;
         this.AV8ProfesionalesId = aP2_ProfesionalesId;
         this.AV13Proveedor = aP3_Proveedor;
         this.AV15Motivo = aP4_Motivo;
         this.AV9IsOk = false ;
         initialize();
         ExecutePrivate();
         aP5_IsOk=this.AV9IsOk;
      }

      public bool executeUdp( long aP0_ListaId ,
                              long aP1_ProveedorID ,
                              string aP2_ProfesionalesId ,
                              bool aP3_Proveedor ,
                              string aP4_Motivo )
      {
         execute(aP0_ListaId, aP1_ProveedorID, aP2_ProfesionalesId, aP3_Proveedor, aP4_Motivo, out aP5_IsOk);
         return AV9IsOk ;
      }

      public void executeSubmit( long aP0_ListaId ,
                                 long aP1_ProveedorID ,
                                 string aP2_ProfesionalesId ,
                                 bool aP3_Proveedor ,
                                 string aP4_Motivo ,
                                 out bool aP5_IsOk )
      {
         this.AV10ListaId = aP0_ListaId;
         this.AV11ProveedorID = aP1_ProveedorID;
         this.AV8ProfesionalesId = aP2_ProfesionalesId;
         this.AV13Proveedor = aP3_Proveedor;
         this.AV15Motivo = aP4_Motivo;
         this.AV9IsOk = false ;
         SubmitImpl();
         aP5_IsOk=this.AV9IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsOk = false;
         if ( AV13Proveedor )
         {
            AV14Estado = "PEN";
         }
         else
         {
            AV14Estado = "VIN";
         }
         /*
            INSERT RECORD ON TABLE ListaAgrupacion

         */
         A590Listaid = AV10ListaId;
         A133ProveedorID = AV11ProveedorID;
         A120ProfesionalesId = AV8ProfesionalesId;
         A588AgrupacionEstado = AV14Estado;
         A589AgrupacionMotivo = AV15Motivo;
         AV12IsMsg = context.GetMessage( "Registro Ingresado", "");
         AV9IsOk = true;
         /* Using cursor P00BQ2 */
         pr_default.execute(0, new Object[] {A590Listaid, A133ProveedorID, A120ProfesionalesId, A588AgrupacionEstado, A589AgrupacionMotivo});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("ListaAgrupacion");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            AV12IsMsg = context.GetMessage( "Registro Duplicado", "");
            AV9IsOk = false;
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aingresaralista",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV14Estado = "";
         A120ProfesionalesId = "";
         A588AgrupacionEstado = "";
         A589AgrupacionMotivo = "";
         AV12IsMsg = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aingresaralista__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS87 ;
      private long AV10ListaId ;
      private long AV11ProveedorID ;
      private long A590Listaid ;
      private long A133ProveedorID ;
      private string AV8ProfesionalesId ;
      private string AV14Estado ;
      private string A120ProfesionalesId ;
      private string A588AgrupacionEstado ;
      private string Gx_emsg ;
      private bool AV13Proveedor ;
      private bool AV9IsOk ;
      private string AV15Motivo ;
      private string A589AgrupacionMotivo ;
      private string AV12IsMsg ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP5_IsOk ;
   }

   public class aingresaralista__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BQ2;
          prmP00BQ2 = new Object[] {
          new ParDef("@Listaid",GXType.Decimal,18,0) ,
          new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AgrupacionEstado",GXType.NChar,3,0) ,
          new ParDef("@AgrupacionMotivo",GXType.NVarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BQ2", "INSERT INTO [ListaAgrupacion]([Listaid], [ProveedorID], [ProfesionalesId], [AgrupacionEstado], [AgrupacionMotivo]) VALUES(@Listaid, @ProveedorID, @ProfesionalesId, @AgrupacionEstado, @AgrupacionMotivo)", GxErrorMask.GX_NOMASK,prmP00BQ2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
