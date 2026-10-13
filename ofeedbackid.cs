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
   public class ofeedbackid : GXProcedure
   {
      public ofeedbackid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ofeedbackid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           long aP1_ClientesId ,
                           long aP2_FeedBackSolicitudId ,
                           out long aP3_FeedBackid ,
                           out long aP4_Calificacion ,
                           out string aP5_Comentario ,
                           out DateTime aP6_FeedBackFechaAlta )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV10ClientesId = aP1_ClientesId;
         this.AV14FeedBackSolicitudId = aP2_FeedBackSolicitudId;
         this.AV9FeedBackid = 0 ;
         this.AV11Calificacion = 0 ;
         this.AV12Comentario = "" ;
         this.AV13FeedBackFechaAlta = DateTime.MinValue ;
         initialize();
         ExecutePrivate();
         aP3_FeedBackid=this.AV9FeedBackid;
         aP4_Calificacion=this.AV11Calificacion;
         aP5_Comentario=this.AV12Comentario;
         aP6_FeedBackFechaAlta=this.AV13FeedBackFechaAlta;
      }

      public DateTime executeUdp( string aP0_ProfesionalesId ,
                                  long aP1_ClientesId ,
                                  long aP2_FeedBackSolicitudId ,
                                  out long aP3_FeedBackid ,
                                  out long aP4_Calificacion ,
                                  out string aP5_Comentario )
      {
         execute(aP0_ProfesionalesId, aP1_ClientesId, aP2_FeedBackSolicitudId, out aP3_FeedBackid, out aP4_Calificacion, out aP5_Comentario, out aP6_FeedBackFechaAlta);
         return AV13FeedBackFechaAlta ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 long aP1_ClientesId ,
                                 long aP2_FeedBackSolicitudId ,
                                 out long aP3_FeedBackid ,
                                 out long aP4_Calificacion ,
                                 out string aP5_Comentario ,
                                 out DateTime aP6_FeedBackFechaAlta )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV10ClientesId = aP1_ClientesId;
         this.AV14FeedBackSolicitudId = aP2_FeedBackSolicitudId;
         this.AV9FeedBackid = 0 ;
         this.AV11Calificacion = 0 ;
         this.AV12Comentario = "" ;
         this.AV13FeedBackFechaAlta = DateTime.MinValue ;
         SubmitImpl();
         aP3_FeedBackid=this.AV9FeedBackid;
         aP4_Calificacion=this.AV11Calificacion;
         aP5_Comentario=this.AV12Comentario;
         aP6_FeedBackFechaAlta=this.AV13FeedBackFechaAlta;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9FeedBackid = 0;
         AV11Calificacion = 0;
         AV12Comentario = "";
         AV13FeedBackFechaAlta = DateTime.MinValue;
         /* Using cursor P008J2 */
         pr_default.execute(0, new Object[] {AV14FeedBackSolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A272FeedBackSolicitudId = P008J2_A272FeedBackSolicitudId[0];
            A117FeedBackId = P008J2_A117FeedBackId[0];
            A275FeedBackNum = P008J2_A275FeedBackNum[0];
            A271FeedBackComentario = P008J2_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = P008J2_A276FeedBackFechaAlta[0];
            AV9FeedBackid = A117FeedBackId;
            AV11Calificacion = A275FeedBackNum;
            AV12Comentario = A271FeedBackComentario;
            AV13FeedBackFechaAlta = A276FeedBackFechaAlta;
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
         AV12Comentario = "";
         AV13FeedBackFechaAlta = DateTime.MinValue;
         P008J2_A272FeedBackSolicitudId = new long[1] ;
         P008J2_A117FeedBackId = new long[1] ;
         P008J2_A275FeedBackNum = new long[1] ;
         P008J2_A271FeedBackComentario = new string[] {""} ;
         P008J2_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ofeedbackid__default(),
            new Object[][] {
                new Object[] {
               P008J2_A272FeedBackSolicitudId, P008J2_A117FeedBackId, P008J2_A275FeedBackNum, P008J2_A271FeedBackComentario, P008J2_A276FeedBackFechaAlta
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10ClientesId ;
      private long AV14FeedBackSolicitudId ;
      private long AV9FeedBackid ;
      private long AV11Calificacion ;
      private long A272FeedBackSolicitudId ;
      private long A117FeedBackId ;
      private long A275FeedBackNum ;
      private string AV8ProfesionalesId ;
      private DateTime AV13FeedBackFechaAlta ;
      private DateTime A276FeedBackFechaAlta ;
      private string AV12Comentario ;
      private string A271FeedBackComentario ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008J2_A272FeedBackSolicitudId ;
      private long[] P008J2_A117FeedBackId ;
      private long[] P008J2_A275FeedBackNum ;
      private string[] P008J2_A271FeedBackComentario ;
      private DateTime[] P008J2_A276FeedBackFechaAlta ;
      private long aP3_FeedBackid ;
      private long aP4_Calificacion ;
      private string aP5_Comentario ;
      private DateTime aP6_FeedBackFechaAlta ;
   }

   public class ofeedbackid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008J2;
          prmP008J2 = new Object[] {
          new ParDef("@AV14FeedBackSolicitudId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008J2", "SELECT TOP 1 [FeedBackSolicitudId], [FeedBackId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta] FROM [FeedBack] WHERE [FeedBackSolicitudId] = @AV14FeedBackSolicitudId ORDER BY [FeedBackId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
