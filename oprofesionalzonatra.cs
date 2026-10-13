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
   public class oprofesionalzonatra : GXProcedure
   {
      public oprofesionalzonatra( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oprofesionalzonatra( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           string aP1_PaisID ,
                           long aP2_DepartamentoId ,
                           long aP3_DepartamentoMunicipioId ,
                           long aP4_ZonasID ,
                           out bool aP5_Ok )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9PaisID = aP1_PaisID;
         this.AV10DepartamentoId = aP2_DepartamentoId;
         this.AV13DepartamentoMunicipioId = aP3_DepartamentoMunicipioId;
         this.AV12ZonasID = aP4_ZonasID;
         this.AV11Ok = false ;
         initialize();
         ExecutePrivate();
         aP5_Ok=this.AV11Ok;
      }

      public bool executeUdp( string aP0_ProfesionalesId ,
                              string aP1_PaisID ,
                              long aP2_DepartamentoId ,
                              long aP3_DepartamentoMunicipioId ,
                              long aP4_ZonasID )
      {
         execute(aP0_ProfesionalesId, aP1_PaisID, aP2_DepartamentoId, aP3_DepartamentoMunicipioId, aP4_ZonasID, out aP5_Ok);
         return AV11Ok ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 string aP1_PaisID ,
                                 long aP2_DepartamentoId ,
                                 long aP3_DepartamentoMunicipioId ,
                                 long aP4_ZonasID ,
                                 out bool aP5_Ok )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV9PaisID = aP1_PaisID;
         this.AV10DepartamentoId = aP2_DepartamentoId;
         this.AV13DepartamentoMunicipioId = aP3_DepartamentoMunicipioId;
         this.AV12ZonasID = aP4_ZonasID;
         this.AV11Ok = false ;
         SubmitImpl();
         aP5_Ok=this.AV11Ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Ok = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9PaisID ,
                                              A116PaisID ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              AV8ProfesionalesId ,
                                              A120ProfesionalesId } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P009G2 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId, AV9PaisID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A116PaisID = P009G2_A116PaisID[0];
            A108EstadosGenericosId = P009G2_A108EstadosGenericosId[0];
            A107EstadosTipo = P009G2_A107EstadosTipo[0];
            A120ProfesionalesId = P009G2_A120ProfesionalesId[0];
            A112DepartamentoId = P009G2_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P009G2_A114DepartamentoMunicipioId[0];
            A126ProfesionalesZonasCorrelativo = P009G2_A126ProfesionalesZonasCorrelativo[0];
            A108EstadosGenericosId = P009G2_A108EstadosGenericosId[0];
            A107EstadosTipo = P009G2_A107EstadosTipo[0];
            A116PaisID = P009G2_A116PaisID[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               if ( ( A112DepartamentoId == 1 ) && ( A112DepartamentoId == AV10DepartamentoId ) && ! ( StringUtil.StrCmp(AV9PaisID, context.GetMessage( "MZ", "")) == 0 ) )
               {
                  if ( ( A114DepartamentoMunicipioId == AV13DepartamentoMunicipioId ) || ( A114DepartamentoMunicipioId == 9999 ) )
                  {
                     AV11Ok = true;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               if ( ( A112DepartamentoId > 1 ) && ( A112DepartamentoId == AV10DepartamentoId ) && ( ( A114DepartamentoMunicipioId == AV13DepartamentoMunicipioId ) || ( A114DepartamentoMunicipioId == 9999 ) ) && ! ( StringUtil.StrCmp(AV9PaisID, context.GetMessage( "MZ", "")) == 0 ) )
               {
                  AV11Ok = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               if ( StringUtil.StrCmp(AV9PaisID, context.GetMessage( "MZ", "")) == 0 )
               {
                  AV11Ok = true;
               }
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
         A116PaisID = "";
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         P009G2_A116PaisID = new string[] {""} ;
         P009G2_A108EstadosGenericosId = new int[1] ;
         P009G2_A107EstadosTipo = new string[] {""} ;
         P009G2_A120ProfesionalesId = new string[] {""} ;
         P009G2_A112DepartamentoId = new long[1] ;
         P009G2_A114DepartamentoMunicipioId = new long[1] ;
         P009G2_A126ProfesionalesZonasCorrelativo = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oprofesionalzonatra__default(),
            new Object[][] {
                new Object[] {
               P009G2_A116PaisID, P009G2_A108EstadosGenericosId, P009G2_A107EstadosTipo, P009G2_A120ProfesionalesId, P009G2_A112DepartamentoId, P009G2_A114DepartamentoMunicipioId, P009G2_A126ProfesionalesZonasCorrelativo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A126ProfesionalesZonasCorrelativo ;
      private int A108EstadosGenericosId ;
      private long AV10DepartamentoId ;
      private long AV13DepartamentoMunicipioId ;
      private long AV12ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private string AV8ProfesionalesId ;
      private string AV9PaisID ;
      private string A116PaisID ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private bool AV11Ok ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009G2_A116PaisID ;
      private int[] P009G2_A108EstadosGenericosId ;
      private string[] P009G2_A107EstadosTipo ;
      private string[] P009G2_A120ProfesionalesId ;
      private long[] P009G2_A112DepartamentoId ;
      private long[] P009G2_A114DepartamentoMunicipioId ;
      private short[] P009G2_A126ProfesionalesZonasCorrelativo ;
      private bool aP5_Ok ;
   }

   public class oprofesionalzonatra__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009G2( IGxContext context ,
                                             string AV9PaisID ,
                                             string A116PaisID ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string AV8ProfesionalesId ,
                                             string A120ProfesionalesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.[PaisID], T2.[EstadosGenericosId], T2.[EstadosTipo], T1.[ProfesionalesId], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ProfesionalesZonasCorrelativo] FROM (([ProfesionalesZonas] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Departamento] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId])";
         AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV8ProfesionalesId)");
         AddWhere(sWhereString, "(T2.[EstadosGenericosId] = 1)");
         if ( ! ( StringUtil.StrCmp(AV9PaisID, context.GetMessage( "MZ", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[PaisID] = @AV9PaisID)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo]";
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
                     return conditional_P009G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
          Object[] prmP009G2;
          prmP009G2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV9PaisID",GXType.NChar,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
