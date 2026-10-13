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
   public class obtenermunicipio : GXProcedure
   {
      public obtenermunicipio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenermunicipio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_DepartamentoId ,
                           out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         this.AV8DepartamentoId = aP0_DepartamentoId;
         this.AV9SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>( context, "SDTMunicipio", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP1_SDTMunicipio=this.AV9SDTMunicipio;
      }

      public GXBaseCollection<SdtSDTMunicipio> executeUdp( long aP0_DepartamentoId )
      {
         execute(aP0_DepartamentoId, out aP1_SDTMunicipio);
         return AV9SDTMunicipio ;
      }

      public void executeSubmit( long aP0_DepartamentoId ,
                                 out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         this.AV8DepartamentoId = aP0_DepartamentoId;
         this.AV9SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>( context, "SDTMunicipio", "AlmangoX") ;
         SubmitImpl();
         aP1_SDTMunicipio=this.AV9SDTMunicipio;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H42 */
         pr_default.execute(0, new Object[] {AV8DepartamentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A908DepartamentoMunicipioEstado = P00H42_A908DepartamentoMunicipioEstado[0];
            n908DepartamentoMunicipioEstado = P00H42_n908DepartamentoMunicipioEstado[0];
            A114DepartamentoMunicipioId = P00H42_A114DepartamentoMunicipioId[0];
            A907DepartamentoEstado = P00H42_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00H42_n907DepartamentoEstado[0];
            A112DepartamentoId = P00H42_A112DepartamentoId[0];
            A115DepartamentoMunicipioNombre = P00H42_A115DepartamentoMunicipioNombre[0];
            A863DepartamentoMunicipioCosto = P00H42_A863DepartamentoMunicipioCosto[0];
            A907DepartamentoEstado = P00H42_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00H42_n907DepartamentoEstado[0];
            if ( StringUtil.StrCmp(A907DepartamentoEstado, context.GetMessage( "DES", "")) != 0 )
            {
               if ( StringUtil.StrCmp(A908DepartamentoMunicipioEstado, context.GetMessage( "DES", "")) != 0 )
               {
                  AV10SDTMunicipioItem = new SdtSDTMunicipio(context);
                  AV10SDTMunicipioItem.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
                  AV10SDTMunicipioItem.gxTpr_Departamentomunicipionombre = A115DepartamentoMunicipioNombre;
                  AV10SDTMunicipioItem.gxTpr_Zonacostoadicional = A863DepartamentoMunicipioCosto;
                  AV9SDTMunicipio.Add(AV10SDTMunicipioItem, 0);
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
         AV9SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>( context, "SDTMunicipio", "AlmangoX");
         P00H42_A908DepartamentoMunicipioEstado = new string[] {""} ;
         P00H42_n908DepartamentoMunicipioEstado = new bool[] {false} ;
         P00H42_A114DepartamentoMunicipioId = new long[1] ;
         P00H42_A907DepartamentoEstado = new string[] {""} ;
         P00H42_n907DepartamentoEstado = new bool[] {false} ;
         P00H42_A112DepartamentoId = new long[1] ;
         P00H42_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00H42_A863DepartamentoMunicipioCosto = new decimal[1] ;
         A908DepartamentoMunicipioEstado = "";
         A907DepartamentoEstado = "";
         A115DepartamentoMunicipioNombre = "";
         AV10SDTMunicipioItem = new SdtSDTMunicipio(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenermunicipio__default(),
            new Object[][] {
                new Object[] {
               P00H42_A908DepartamentoMunicipioEstado, P00H42_n908DepartamentoMunicipioEstado, P00H42_A114DepartamentoMunicipioId, P00H42_A907DepartamentoEstado, P00H42_n907DepartamentoEstado, P00H42_A112DepartamentoId, P00H42_A115DepartamentoMunicipioNombre, P00H42_A863DepartamentoMunicipioCosto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private decimal A863DepartamentoMunicipioCosto ;
      private string A908DepartamentoMunicipioEstado ;
      private string A907DepartamentoEstado ;
      private string A115DepartamentoMunicipioNombre ;
      private bool n908DepartamentoMunicipioEstado ;
      private bool n907DepartamentoEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTMunicipio> AV9SDTMunicipio ;
      private IDataStoreProvider pr_default ;
      private string[] P00H42_A908DepartamentoMunicipioEstado ;
      private bool[] P00H42_n908DepartamentoMunicipioEstado ;
      private long[] P00H42_A114DepartamentoMunicipioId ;
      private string[] P00H42_A907DepartamentoEstado ;
      private bool[] P00H42_n907DepartamentoEstado ;
      private long[] P00H42_A112DepartamentoId ;
      private string[] P00H42_A115DepartamentoMunicipioNombre ;
      private decimal[] P00H42_A863DepartamentoMunicipioCosto ;
      private SdtSDTMunicipio AV10SDTMunicipioItem ;
      private GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio ;
   }

   public class obtenermunicipio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H42;
          prmP00H42 = new Object[] {
          new ParDef("@AV8DepartamentoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H42", "SELECT T1.[DepartamentoMunicipioEstado], T1.[DepartamentoMunicipioId], T2.[DepartamentoEstado], T1.[DepartamentoId], T1.[DepartamentoMunicipioNombre], T1.[DepartamentoMunicipioCosto] FROM ([DepartamentoMunicipio] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE (T1.[DepartamentoId] = @AV8DepartamentoId) AND (T1.[DepartamentoMunicipioId] <> 9999) ORDER BY T1.[DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H42,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 120);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
