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
   public class onombrewallet : GXProcedure
   {
      public onombrewallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public onombrewallet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TipoEntidad ,
                           string aP1_WalletCodRefencia ,
                           out string aP2_Nombre )
      {
         this.AV8TipoEntidad = aP0_TipoEntidad;
         this.AV11WalletCodRefencia = aP1_WalletCodRefencia;
         this.AV9Nombre = "" ;
         initialize();
         ExecutePrivate();
         aP2_Nombre=this.AV9Nombre;
      }

      public string executeUdp( string aP0_TipoEntidad ,
                                string aP1_WalletCodRefencia )
      {
         execute(aP0_TipoEntidad, aP1_WalletCodRefencia, out aP2_Nombre);
         return AV9Nombre ;
      }

      public void executeSubmit( string aP0_TipoEntidad ,
                                 string aP1_WalletCodRefencia ,
                                 out string aP2_Nombre )
      {
         this.AV8TipoEntidad = aP0_TipoEntidad;
         this.AV11WalletCodRefencia = aP1_WalletCodRefencia;
         this.AV9Nombre = "" ;
         SubmitImpl();
         aP2_Nombre=this.AV9Nombre;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp("PRO", AV8TipoEntidad) == 0 )
         {
            /* Using cursor P00DG2 */
            pr_default.execute(0, new Object[] {AV11WalletCodRefencia});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A120ProfesionalesId = P00DG2_A120ProfesionalesId[0];
               A191ProfesionalesSegundoNombre = P00DG2_A191ProfesionalesSegundoNombre[0];
               A192ProfesionalesApellidoSegundo = P00DG2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = P00DG2_A167ProfesionalesApellidoPrimero[0];
               A166ProfesionalesPrimerNombre = P00DG2_A166ProfesionalesPrimerNombre[0];
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) )
               {
                  AV9Nombre = StringUtil.Format( "%1 %2 %3 %4", StringUtil.Trim( A166ProfesionalesPrimerNombre), StringUtil.Trim( A191ProfesionalesSegundoNombre), StringUtil.Trim( A167ProfesionalesApellidoPrimero), StringUtil.Trim( A192ProfesionalesApellidoSegundo), "", "", "", "", "");
               }
               else
               {
                  AV9Nombre = StringUtil.Format( "%1 %2", StringUtil.Trim( A166ProfesionalesPrimerNombre), StringUtil.Trim( A167ProfesionalesApellidoPrimero), "", "", "", "", "", "", "");
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
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
         AV9Nombre = "";
         P00DG2_A120ProfesionalesId = new string[] {""} ;
         P00DG2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00DG2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00DG2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00DG2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         A120ProfesionalesId = "";
         A191ProfesionalesSegundoNombre = "";
         A192ProfesionalesApellidoSegundo = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.onombrewallet__default(),
            new Object[][] {
                new Object[] {
               P00DG2_A120ProfesionalesId, P00DG2_A191ProfesionalesSegundoNombre, P00DG2_A192ProfesionalesApellidoSegundo, P00DG2_A167ProfesionalesApellidoPrimero, P00DG2_A166ProfesionalesPrimerNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string AV8TipoEntidad ;
      private string AV11WalletCodRefencia ;
      private string AV9Nombre ;
      private string A120ProfesionalesId ;
      private string A191ProfesionalesSegundoNombre ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DG2_A120ProfesionalesId ;
      private string[] P00DG2_A191ProfesionalesSegundoNombre ;
      private string[] P00DG2_A192ProfesionalesApellidoSegundo ;
      private string[] P00DG2_A167ProfesionalesApellidoPrimero ;
      private string[] P00DG2_A166ProfesionalesPrimerNombre ;
      private string aP2_Nombre ;
   }

   public class onombrewallet__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DG2;
          prmP00DG2 = new Object[] {
          new ParDef("@AV11WalletCodRefencia",GXType.Char,25,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DG2", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesSegundoNombre], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre] FROM [Profesionales] WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV11WalletCodRefencia)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                return;
       }
    }

 }

}
