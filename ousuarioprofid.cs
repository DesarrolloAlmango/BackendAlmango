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
   public class ousuarioprofid : GXProcedure
   {
      public ousuarioprofid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ousuarioprofid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out SdtUsuariosSDT aP1_UsuariosSDT )
      {
         this.AV10ProfesionalesId = aP0_ProfesionalesId;
         this.AV8UsuariosSDT = new SdtUsuariosSDT(context) ;
         initialize();
         ExecutePrivate();
         aP1_UsuariosSDT=this.AV8UsuariosSDT;
      }

      public SdtUsuariosSDT executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_UsuariosSDT);
         return AV8UsuariosSDT ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out SdtUsuariosSDT aP1_UsuariosSDT )
      {
         this.AV10ProfesionalesId = aP0_ProfesionalesId;
         this.AV8UsuariosSDT = new SdtUsuariosSDT(context) ;
         SubmitImpl();
         aP1_UsuariosSDT=this.AV8UsuariosSDT;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CD2 */
         pr_default.execute(0, new Object[] {AV10ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A240usuariosNumeroIdentidad = P00CD2_A240usuariosNumeroIdentidad[0];
            A40000usuariosImagen_GXI = P00CD2_A40000usuariosImagen_GXI[0];
            A145usuariosId = P00CD2_A145usuariosId[0];
            A225usuariosTipo = P00CD2_A225usuariosTipo[0];
            A222usuariosNombre = P00CD2_A222usuariosNombre[0];
            A224usuariosCorreo = P00CD2_A224usuariosCorreo[0];
            A116PaisID = P00CD2_A116PaisID[0];
            A165PaisNombre = P00CD2_A165PaisNombre[0];
            A230usuariosDireccion = P00CD2_A230usuariosDireccion[0];
            A231usuariosCPostal = P00CD2_A231usuariosCPostal[0];
            A232usuariosTelefono = P00CD2_A232usuariosTelefono[0];
            A226usuariosEstado = P00CD2_A226usuariosEstado[0];
            A266usuariosImagen = P00CD2_A266usuariosImagen[0];
            A165PaisNombre = P00CD2_A165PaisNombre[0];
            AV8UsuariosSDT.gxTpr_Usuariosid = A145usuariosId;
            AV8UsuariosSDT.gxTpr_Usuariostipo = A225usuariosTipo;
            AV8UsuariosSDT.gxTpr_Usuariosnombre = A222usuariosNombre;
            AV8UsuariosSDT.gxTpr_Usuarioscorreo = A224usuariosCorreo;
            AV8UsuariosSDT.gxTpr_Paisid = A116PaisID;
            AV8UsuariosSDT.gxTpr_Paisnombre = A165PaisNombre;
            AV8UsuariosSDT.gxTpr_Usuariosdireccion = A230usuariosDireccion;
            AV8UsuariosSDT.gxTpr_Usuariosimagen = A266usuariosImagen;
            AV8UsuariosSDT.gxTpr_Usuariosimagen_gxi = A40000usuariosImagen_GXI;
            AV8UsuariosSDT.gxTpr_Usuarioscpostal = A231usuariosCPostal;
            AV8UsuariosSDT.gxTpr_Usuariostelefono = A232usuariosTelefono;
            AV8UsuariosSDT.gxTpr_Usuariosestado = A226usuariosEstado;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV8UsuariosSDT = new SdtUsuariosSDT(context);
         P00CD2_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00CD2_A40000usuariosImagen_GXI = new string[] {""} ;
         P00CD2_A145usuariosId = new string[] {""} ;
         P00CD2_A225usuariosTipo = new string[] {""} ;
         P00CD2_A222usuariosNombre = new string[] {""} ;
         P00CD2_A224usuariosCorreo = new string[] {""} ;
         P00CD2_A116PaisID = new string[] {""} ;
         P00CD2_A165PaisNombre = new string[] {""} ;
         P00CD2_A230usuariosDireccion = new string[] {""} ;
         P00CD2_A231usuariosCPostal = new int[1] ;
         P00CD2_A232usuariosTelefono = new string[] {""} ;
         P00CD2_A226usuariosEstado = new string[] {""} ;
         P00CD2_A266usuariosImagen = new string[] {""} ;
         A240usuariosNumeroIdentidad = "";
         A40000usuariosImagen_GXI = "";
         A145usuariosId = "";
         A225usuariosTipo = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A230usuariosDireccion = "";
         A232usuariosTelefono = "";
         A226usuariosEstado = "";
         A266usuariosImagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ousuarioprofid__default(),
            new Object[][] {
                new Object[] {
               P00CD2_A240usuariosNumeroIdentidad, P00CD2_A40000usuariosImagen_GXI, P00CD2_A145usuariosId, P00CD2_A225usuariosTipo, P00CD2_A222usuariosNombre, P00CD2_A224usuariosCorreo, P00CD2_A116PaisID, P00CD2_A165PaisNombre, P00CD2_A230usuariosDireccion, P00CD2_A231usuariosCPostal,
               P00CD2_A232usuariosTelefono, P00CD2_A226usuariosEstado, P00CD2_A266usuariosImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A231usuariosCPostal ;
      private string AV10ProfesionalesId ;
      private string A240usuariosNumeroIdentidad ;
      private string A145usuariosId ;
      private string A225usuariosTipo ;
      private string A222usuariosNombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A232usuariosTelefono ;
      private string A226usuariosEstado ;
      private string A40000usuariosImagen_GXI ;
      private string A224usuariosCorreo ;
      private string A230usuariosDireccion ;
      private string A266usuariosImagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtUsuariosSDT AV8UsuariosSDT ;
      private IDataStoreProvider pr_default ;
      private string[] P00CD2_A240usuariosNumeroIdentidad ;
      private string[] P00CD2_A40000usuariosImagen_GXI ;
      private string[] P00CD2_A145usuariosId ;
      private string[] P00CD2_A225usuariosTipo ;
      private string[] P00CD2_A222usuariosNombre ;
      private string[] P00CD2_A224usuariosCorreo ;
      private string[] P00CD2_A116PaisID ;
      private string[] P00CD2_A165PaisNombre ;
      private string[] P00CD2_A230usuariosDireccion ;
      private int[] P00CD2_A231usuariosCPostal ;
      private string[] P00CD2_A232usuariosTelefono ;
      private string[] P00CD2_A226usuariosEstado ;
      private string[] P00CD2_A266usuariosImagen ;
      private SdtUsuariosSDT aP1_UsuariosSDT ;
   }

   public class ousuarioprofid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CD2;
          prmP00CD2 = new Object[] {
          new ParDef("@AV10ProfesionalesId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CD2", "SELECT TOP 1 T1.[usuariosNumeroIdentidad], T1.[usuariosImagen_GXI], T1.[usuariosId], T1.[usuariosTipo], T1.[usuariosNombre], T1.[usuariosCorreo], T1.[PaisID], T2.[PaisNombre], T1.[usuariosDireccion], T1.[usuariosCPostal], T1.[usuariosTelefono], T1.[usuariosEstado], T1.[usuariosImagen] FROM ([usuarios] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID]) WHERE RTRIM(LTRIM(T1.[usuariosNumeroIdentidad])) = RTRIM(LTRIM(@AV10ProfesionalesId)) ORDER BY T1.[usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CD2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 2);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 3);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
                return;
       }
    }

 }

}
