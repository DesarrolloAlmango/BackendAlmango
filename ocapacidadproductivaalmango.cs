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
   public class ocapacidadproductivaalmango : GXProcedure
   {
      public ocapacidadproductivaalmango( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocapacidadproductivaalmango( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_DepartamentoId ,
                           short aP1_RubrosId ,
                           out decimal aP2_CapacidadProductiva )
      {
         this.AV9DepartamentoId = aP0_DepartamentoId;
         this.AV10RubrosId = aP1_RubrosId;
         this.AV8CapacidadProductiva = 0 ;
         initialize();
         ExecutePrivate();
         aP2_CapacidadProductiva=this.AV8CapacidadProductiva;
      }

      public decimal executeUdp( long aP0_DepartamentoId ,
                                 short aP1_RubrosId )
      {
         execute(aP0_DepartamentoId, aP1_RubrosId, out aP2_CapacidadProductiva);
         return AV8CapacidadProductiva ;
      }

      public void executeSubmit( long aP0_DepartamentoId ,
                                 short aP1_RubrosId ,
                                 out decimal aP2_CapacidadProductiva )
      {
         this.AV9DepartamentoId = aP0_DepartamentoId;
         this.AV10RubrosId = aP1_RubrosId;
         this.AV8CapacidadProductiva = 0 ;
         SubmitImpl();
         aP2_CapacidadProductiva=this.AV8CapacidadProductiva;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8CapacidadProductiva = 0;
         AV11ProfesionalesIdCollection.Clear();
         if ( (0==AV10RubrosId) && (0==AV9DepartamentoId) )
         {
            /* Using cursor P00GA2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A108EstadosGenericosId = P00GA2_A108EstadosGenericosId[0];
               A107EstadosTipo = P00GA2_A107EstadosTipo[0];
               A120ProfesionalesId = P00GA2_A120ProfesionalesId[0];
               A800ProfesionalesCapacidadProducti = P00GA2_A800ProfesionalesCapacidadProducti[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV8CapacidadProductiva = (decimal)(AV8CapacidadProductiva+A800ProfesionalesCapacidadProducti);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else if ( (0==AV10RubrosId) && ! (0==AV9DepartamentoId) )
         {
            /* Using cursor P00GA3 */
            pr_default.execute(1, new Object[] {AV9DepartamentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00GA3_A120ProfesionalesId[0];
               A107EstadosTipo = P00GA3_A107EstadosTipo[0];
               A800ProfesionalesCapacidadProducti = P00GA3_A800ProfesionalesCapacidadProducti[0];
               A112DepartamentoId = P00GA3_A112DepartamentoId[0];
               A126ProfesionalesZonasCorrelativo = P00GA3_A126ProfesionalesZonasCorrelativo[0];
               A107EstadosTipo = P00GA3_A107EstadosTipo[0];
               A800ProfesionalesCapacidadProducti = P00GA3_A800ProfesionalesCapacidadProducti[0];
               /* Using cursor P00GA4 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A108EstadosGenericosId = P00GA4_A108EstadosGenericosId[0];
                  A120ProfesionalesId = P00GA4_A120ProfesionalesId[0];
                  if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     AV8CapacidadProductiva = (decimal)(AV8CapacidadProductiva+A800ProfesionalesCapacidadProducti);
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         else if ( ! (0==AV10RubrosId) && (0==AV9DepartamentoId) )
         {
            /* Using cursor P00GA5 */
            pr_default.execute(3, new Object[] {AV10RubrosId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A120ProfesionalesId = P00GA5_A120ProfesionalesId[0];
               A107EstadosTipo = P00GA5_A107EstadosTipo[0];
               A800ProfesionalesCapacidadProducti = P00GA5_A800ProfesionalesCapacidadProducti[0];
               A121RubrosId = P00GA5_A121RubrosId[0];
               A107EstadosTipo = P00GA5_A107EstadosTipo[0];
               A800ProfesionalesCapacidadProducti = P00GA5_A800ProfesionalesCapacidadProducti[0];
               /* Using cursor P00GA6 */
               pr_default.execute(4);
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A108EstadosGenericosId = P00GA6_A108EstadosGenericosId[0];
                  A120ProfesionalesId = P00GA6_A120ProfesionalesId[0];
                  if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     AV8CapacidadProductiva = (decimal)(AV8CapacidadProductiva+A800ProfesionalesCapacidadProducti);
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else if ( ! (0==AV10RubrosId) && ! (0==AV9DepartamentoId) )
         {
            /* Using cursor P00GA7 */
            pr_default.execute(5, new Object[] {AV10RubrosId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A120ProfesionalesId = P00GA7_A120ProfesionalesId[0];
               A107EstadosTipo = P00GA7_A107EstadosTipo[0];
               A121RubrosId = P00GA7_A121RubrosId[0];
               A107EstadosTipo = P00GA7_A107EstadosTipo[0];
               /* Using cursor P00GA8 */
               pr_default.execute(6);
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A108EstadosGenericosId = P00GA8_A108EstadosGenericosId[0];
                  A120ProfesionalesId = P00GA8_A120ProfesionalesId[0];
                  if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     AV12ProfesionalesIdCollection1.Add(A120ProfesionalesId, 0);
                  }
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Using cursor P00GA9 */
            pr_default.execute(7, new Object[] {AV9DepartamentoId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A120ProfesionalesId = P00GA9_A120ProfesionalesId[0];
               A107EstadosTipo = P00GA9_A107EstadosTipo[0];
               A112DepartamentoId = P00GA9_A112DepartamentoId[0];
               A126ProfesionalesZonasCorrelativo = P00GA9_A126ProfesionalesZonasCorrelativo[0];
               A107EstadosTipo = P00GA9_A107EstadosTipo[0];
               /* Using cursor P00GA10 */
               pr_default.execute(8);
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A108EstadosGenericosId = P00GA10_A108EstadosGenericosId[0];
                  A120ProfesionalesId = P00GA10_A120ProfesionalesId[0];
                  if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
                  {
                     AV13ProfesionalesIdCollection2.Add(A120ProfesionalesId, 0);
                  }
                  pr_default.readNext(8);
               }
               pr_default.close(8);
               pr_default.readNext(7);
            }
            pr_default.close(7);
            pr_default.dynParam(9, new Object[]{ new Object[]{
                                                 A120ProfesionalesId ,
                                                 AV12ProfesionalesIdCollection1 ,
                                                 AV13ProfesionalesIdCollection2 ,
                                                 A107EstadosTipo ,
                                                 A108EstadosGenericosId } ,
                                                 new int[]{
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00GA11 */
            pr_default.execute(9);
            while ( (pr_default.getStatus(9) != 101) )
            {
               A108EstadosGenericosId = P00GA11_A108EstadosGenericosId[0];
               A107EstadosTipo = P00GA11_A107EstadosTipo[0];
               A120ProfesionalesId = P00GA11_A120ProfesionalesId[0];
               A800ProfesionalesCapacidadProducti = P00GA11_A800ProfesionalesCapacidadProducti[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV8CapacidadProductiva = (decimal)(AV8CapacidadProductiva+A800ProfesionalesCapacidadProducti);
               }
               pr_default.readNext(9);
            }
            pr_default.close(9);
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
         AV11ProfesionalesIdCollection = new GxSimpleCollection<string>();
         P00GA2_A108EstadosGenericosId = new int[1] ;
         P00GA2_A107EstadosTipo = new string[] {""} ;
         P00GA2_A120ProfesionalesId = new string[] {""} ;
         P00GA2_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         P00GA3_A120ProfesionalesId = new string[] {""} ;
         P00GA3_A107EstadosTipo = new string[] {""} ;
         P00GA3_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         P00GA3_A112DepartamentoId = new long[1] ;
         P00GA3_A126ProfesionalesZonasCorrelativo = new short[1] ;
         P00GA4_A108EstadosGenericosId = new int[1] ;
         P00GA4_A120ProfesionalesId = new string[] {""} ;
         P00GA5_A120ProfesionalesId = new string[] {""} ;
         P00GA5_A107EstadosTipo = new string[] {""} ;
         P00GA5_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         P00GA5_A121RubrosId = new short[1] ;
         P00GA6_A108EstadosGenericosId = new int[1] ;
         P00GA6_A120ProfesionalesId = new string[] {""} ;
         P00GA7_A120ProfesionalesId = new string[] {""} ;
         P00GA7_A107EstadosTipo = new string[] {""} ;
         P00GA7_A121RubrosId = new short[1] ;
         P00GA8_A108EstadosGenericosId = new int[1] ;
         P00GA8_A120ProfesionalesId = new string[] {""} ;
         AV12ProfesionalesIdCollection1 = new GxSimpleCollection<string>();
         P00GA9_A120ProfesionalesId = new string[] {""} ;
         P00GA9_A107EstadosTipo = new string[] {""} ;
         P00GA9_A112DepartamentoId = new long[1] ;
         P00GA9_A126ProfesionalesZonasCorrelativo = new short[1] ;
         P00GA10_A108EstadosGenericosId = new int[1] ;
         P00GA10_A120ProfesionalesId = new string[] {""} ;
         AV13ProfesionalesIdCollection2 = new GxSimpleCollection<string>();
         P00GA11_A108EstadosGenericosId = new int[1] ;
         P00GA11_A107EstadosTipo = new string[] {""} ;
         P00GA11_A120ProfesionalesId = new string[] {""} ;
         P00GA11_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocapacidadproductivaalmango__default(),
            new Object[][] {
                new Object[] {
               P00GA2_A108EstadosGenericosId, P00GA2_A107EstadosTipo, P00GA2_A120ProfesionalesId, P00GA2_A800ProfesionalesCapacidadProducti
               }
               , new Object[] {
               P00GA3_A120ProfesionalesId, P00GA3_A107EstadosTipo, P00GA3_A800ProfesionalesCapacidadProducti, P00GA3_A112DepartamentoId, P00GA3_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               P00GA4_A108EstadosGenericosId, P00GA4_A120ProfesionalesId
               }
               , new Object[] {
               P00GA5_A120ProfesionalesId, P00GA5_A107EstadosTipo, P00GA5_A800ProfesionalesCapacidadProducti, P00GA5_A121RubrosId
               }
               , new Object[] {
               P00GA6_A108EstadosGenericosId, P00GA6_A120ProfesionalesId
               }
               , new Object[] {
               P00GA7_A120ProfesionalesId, P00GA7_A107EstadosTipo, P00GA7_A121RubrosId
               }
               , new Object[] {
               P00GA8_A108EstadosGenericosId, P00GA8_A120ProfesionalesId
               }
               , new Object[] {
               P00GA9_A120ProfesionalesId, P00GA9_A107EstadosTipo, P00GA9_A112DepartamentoId, P00GA9_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               P00GA10_A108EstadosGenericosId, P00GA10_A120ProfesionalesId
               }
               , new Object[] {
               P00GA11_A108EstadosGenericosId, P00GA11_A107EstadosTipo, P00GA11_A120ProfesionalesId, P00GA11_A800ProfesionalesCapacidadProducti
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10RubrosId ;
      private short A126ProfesionalesZonasCorrelativo ;
      private short A121RubrosId ;
      private int A108EstadosGenericosId ;
      private long AV9DepartamentoId ;
      private long A112DepartamentoId ;
      private decimal AV8CapacidadProductiva ;
      private decimal A800ProfesionalesCapacidadProducti ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV11ProfesionalesIdCollection ;
      private IDataStoreProvider pr_default ;
      private int[] P00GA2_A108EstadosGenericosId ;
      private string[] P00GA2_A107EstadosTipo ;
      private string[] P00GA2_A120ProfesionalesId ;
      private decimal[] P00GA2_A800ProfesionalesCapacidadProducti ;
      private string[] P00GA3_A120ProfesionalesId ;
      private string[] P00GA3_A107EstadosTipo ;
      private decimal[] P00GA3_A800ProfesionalesCapacidadProducti ;
      private long[] P00GA3_A112DepartamentoId ;
      private short[] P00GA3_A126ProfesionalesZonasCorrelativo ;
      private int[] P00GA4_A108EstadosGenericosId ;
      private string[] P00GA4_A120ProfesionalesId ;
      private string[] P00GA5_A120ProfesionalesId ;
      private string[] P00GA5_A107EstadosTipo ;
      private decimal[] P00GA5_A800ProfesionalesCapacidadProducti ;
      private short[] P00GA5_A121RubrosId ;
      private int[] P00GA6_A108EstadosGenericosId ;
      private string[] P00GA6_A120ProfesionalesId ;
      private string[] P00GA7_A120ProfesionalesId ;
      private string[] P00GA7_A107EstadosTipo ;
      private short[] P00GA7_A121RubrosId ;
      private int[] P00GA8_A108EstadosGenericosId ;
      private string[] P00GA8_A120ProfesionalesId ;
      private GxSimpleCollection<string> AV12ProfesionalesIdCollection1 ;
      private string[] P00GA9_A120ProfesionalesId ;
      private string[] P00GA9_A107EstadosTipo ;
      private long[] P00GA9_A112DepartamentoId ;
      private short[] P00GA9_A126ProfesionalesZonasCorrelativo ;
      private int[] P00GA10_A108EstadosGenericosId ;
      private string[] P00GA10_A120ProfesionalesId ;
      private GxSimpleCollection<string> AV13ProfesionalesIdCollection2 ;
      private int[] P00GA11_A108EstadosGenericosId ;
      private string[] P00GA11_A107EstadosTipo ;
      private string[] P00GA11_A120ProfesionalesId ;
      private decimal[] P00GA11_A800ProfesionalesCapacidadProducti ;
      private decimal aP2_CapacidadProductiva ;
   }

   public class ocapacidadproductivaalmango__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GA11( IGxContext context ,
                                              string A120ProfesionalesId ,
                                              GxSimpleCollection<string> AV12ProfesionalesIdCollection1 ,
                                              GxSimpleCollection<string> AV13ProfesionalesIdCollection2 ,
                                              string A107EstadosTipo ,
                                              int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId], [ProfesionalesCapacidadProducti] FROM [Profesionales]";
         AddWhere(sWhereString, "(Not ([ProfesionalesId] = ''))");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV12ProfesionalesIdCollection1, "[ProfesionalesId] IN (", ")")+")");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV13ProfesionalesIdCollection2, "[ProfesionalesId] IN (", ")")+")");
         AddWhere(sWhereString, "([EstadosGenericosId] = 1)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesId]";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 9 :
                     return conditional_P00GA11(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (GxSimpleCollection<string>)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GA2;
          prmP00GA2 = new Object[] {
          };
          Object[] prmP00GA3;
          prmP00GA3 = new Object[] {
          new ParDef("@AV9DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GA4;
          prmP00GA4 = new Object[] {
          };
          Object[] prmP00GA5;
          prmP00GA5 = new Object[] {
          new ParDef("@AV10RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00GA6;
          prmP00GA6 = new Object[] {
          };
          Object[] prmP00GA7;
          prmP00GA7 = new Object[] {
          new ParDef("@AV10RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00GA8;
          prmP00GA8 = new Object[] {
          };
          Object[] prmP00GA9;
          prmP00GA9 = new Object[] {
          new ParDef("@AV9DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP00GA10;
          prmP00GA10 = new Object[] {
          };
          Object[] prmP00GA11;
          prmP00GA11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00GA2", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId], [ProfesionalesCapacidadProducti] FROM [Profesionales] WHERE (Not ([ProfesionalesId] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GA3", "SELECT T1.[ProfesionalesId], T2.[EstadosTipo], T2.[ProfesionalesCapacidadProducti], T1.[DepartamentoId], T1.[ProfesionalesZonasCorrelativo] FROM ([ProfesionalesZonas] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[DepartamentoId] = @AV9DepartamentoId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GA4", "SELECT [EstadosGenericosId], [ProfesionalesId] FROM [Profesionales] WHERE (Not ([ProfesionalesId] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GA5", "SELECT T1.[ProfesionalesId], T2.[EstadosTipo], T2.[ProfesionalesCapacidadProducti], T1.[RubrosId] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[RubrosId] = @AV10RubrosId ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GA6", "SELECT [EstadosGenericosId], [ProfesionalesId] FROM [Profesionales] WHERE (Not ([ProfesionalesId] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GA7", "SELECT T1.[ProfesionalesId], T2.[EstadosTipo], T1.[RubrosId] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[RubrosId] = @AV10RubrosId ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GA8", "SELECT [EstadosGenericosId], [ProfesionalesId] FROM [Profesionales] WHERE (Not ([ProfesionalesId] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GA9", "SELECT T1.[ProfesionalesId], T2.[EstadosTipo], T1.[DepartamentoId], T1.[ProfesionalesZonasCorrelativo] FROM ([ProfesionalesZonas] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[DepartamentoId] = @AV9DepartamentoId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GA10", "SELECT [EstadosGenericosId], [ProfesionalesId] FROM [Profesionales] WHERE (Not ([ProfesionalesId] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GA11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GA11,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
