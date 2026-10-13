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
   public class orelnom : GXProcedure
   {
      public orelnom( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orelnom( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           out string aP1_ProfesionalesId ,
                           out string aP2_NombreProfesional ,
                           out string aP3_Existe )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV9ProfesionalesId = "" ;
         this.AV11NombreProfesional = "" ;
         this.AV10Existe = "" ;
         initialize();
         ExecutePrivate();
         aP1_ProfesionalesId=this.AV9ProfesionalesId;
         aP2_NombreProfesional=this.AV11NombreProfesional;
         aP3_Existe=this.AV10Existe;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                out string aP1_ProfesionalesId ,
                                out string aP2_NombreProfesional )
      {
         execute(aP0_SolicitudesID, out aP1_ProfesionalesId, out aP2_NombreProfesional, out aP3_Existe);
         return AV10Existe ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 out string aP1_ProfesionalesId ,
                                 out string aP2_NombreProfesional ,
                                 out string aP3_Existe )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV9ProfesionalesId = "" ;
         this.AV11NombreProfesional = "" ;
         this.AV10Existe = "" ;
         SubmitImpl();
         aP1_ProfesionalesId=this.AV9ProfesionalesId;
         aP2_NombreProfesional=this.AV11NombreProfesional;
         aP3_Existe=this.AV10Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Existe = context.GetMessage( "N", "");
         /* Using cursor P009X2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A142EstadoSGId = P009X2_A142EstadoSGId[0];
            A141EstadoSGTipo = P009X2_A141EstadoSGTipo[0];
            A127SolicitudesID = P009X2_A127SolicitudesID[0];
            A120ProfesionalesId = P009X2_A120ProfesionalesId[0];
            A167ProfesionalesApellidoPrimero = P009X2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P009X2_A166ProfesionalesPrimerNombre[0];
            A140RelacionesId = P009X2_A140RelacionesId[0];
            A167ProfesionalesApellidoPrimero = P009X2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P009X2_A166ProfesionalesPrimerNombre[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV10Existe = context.GetMessage( "S", "");
               AV9ProfesionalesId = StringUtil.Trim( StringUtil.Upper( A120ProfesionalesId));
               AV11NombreProfesional = StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A167ProfesionalesApellidoPrimero);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
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
         AV9ProfesionalesId = "";
         AV11NombreProfesional = "";
         AV10Existe = "";
         P009X2_A142EstadoSGId = new int[1] ;
         P009X2_A141EstadoSGTipo = new string[] {""} ;
         P009X2_A127SolicitudesID = new long[1] ;
         P009X2_A120ProfesionalesId = new string[] {""} ;
         P009X2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P009X2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P009X2_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.orelnom__default(),
            new Object[][] {
                new Object[] {
               P009X2_A142EstadoSGId, P009X2_A141EstadoSGTipo, P009X2_A127SolicitudesID, P009X2_A120ProfesionalesId, P009X2_A167ProfesionalesApellidoPrimero, P009X2_A166ProfesionalesPrimerNombre, P009X2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A142EstadoSGId ;
      private long AV8SolicitudesID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV9ProfesionalesId ;
      private string AV11NombreProfesional ;
      private string AV10Existe ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P009X2_A142EstadoSGId ;
      private string[] P009X2_A141EstadoSGTipo ;
      private long[] P009X2_A127SolicitudesID ;
      private string[] P009X2_A120ProfesionalesId ;
      private string[] P009X2_A167ProfesionalesApellidoPrimero ;
      private string[] P009X2_A166ProfesionalesPrimerNombre ;
      private long[] P009X2_A140RelacionesId ;
      private string aP1_ProfesionalesId ;
      private string aP2_NombreProfesional ;
      private string aP3_Existe ;
   }

   public class orelnom__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009X2;
          prmP009X2 = new Object[] {
          new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009X2", "SELECT T1.[EstadoSGId], T1.[EstadoSGTipo], T1.[SolicitudesID], T1.[ProfesionalesId], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE (T1.[SolicitudesID] = @AV8SolicitudesID) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
