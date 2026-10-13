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
   public class ofeedbackxpro : GXProcedure
   {
      public ofeedbackxpro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ofeedbackxpro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           out GXBaseCollection<SdtSDTFeedBack_Items> aP1_SDTFeedBack )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV8SDTFeedBack = new GXBaseCollection<SdtSDTFeedBack_Items>( context, "Items", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP1_SDTFeedBack=this.AV8SDTFeedBack;
      }

      public GXBaseCollection<SdtSDTFeedBack_Items> executeUdp( long aP0_ProveedorID )
      {
         execute(aP0_ProveedorID, out aP1_SDTFeedBack);
         return AV8SDTFeedBack ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 out GXBaseCollection<SdtSDTFeedBack_Items> aP1_SDTFeedBack )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV8SDTFeedBack = new GXBaseCollection<SdtSDTFeedBack_Items>( context, "Items", "AlmangoX") ;
         SubmitImpl();
         aP1_SDTFeedBack=this.AV8SDTFeedBack;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Salir = false;
         /* Using cursor P00C22 */
         pr_default.execute(0, new Object[] {AV9ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00C22_A133ProveedorID[0];
            A127SolicitudesID = P00C22_A127SolicitudesID[0];
            AV11SolicitudesID = A127SolicitudesID;
            /* Execute user subroutine: 'OBTENER FEEDBACK' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            if ( AV16Salir )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER FEEDBACK' Routine */
         returnInSub = false;
         /* Using cursor P00C23 */
         pr_default.execute(1, new Object[] {AV11SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A117FeedBackId = P00C23_A117FeedBackId[0];
            A272FeedBackSolicitudId = P00C23_A272FeedBackSolicitudId[0];
            A273FeedBackProfesionalId = P00C23_A273FeedBackProfesionalId[0];
            A275FeedBackNum = P00C23_A275FeedBackNum[0];
            A271FeedBackComentario = P00C23_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = P00C23_A276FeedBackFechaAlta[0];
            A277FeedBackFechaModif = P00C23_A277FeedBackFechaModif[0];
            AV13SDTFeedBackItem = new SdtSDTFeedBack_Items(context);
            AV13SDTFeedBackItem.gxTpr_Feedbacksolicitudid = A272FeedBackSolicitudId;
            AV13SDTFeedBackItem.gxTpr_Feedbackid = A117FeedBackId;
            AV13SDTFeedBackItem.gxTpr_Feedbackprofesionalid = A273FeedBackProfesionalId;
            AV13SDTFeedBackItem.gxTpr_Feedbacknum = A275FeedBackNum;
            AV13SDTFeedBackItem.gxTpr_Feedbackcomentario = A271FeedBackComentario;
            AV13SDTFeedBackItem.gxTpr_Feedbackfechaalta = A276FeedBackFechaAlta;
            AV13SDTFeedBackItem.gxTpr_Feedbackfechamodif = A277FeedBackFechaModif;
            /* Execute user subroutine: 'OBTENER PROFESIONAL' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV8SDTFeedBack.Add(AV13SDTFeedBackItem, 0);
            AV15i = (short)(AV15i+1);
            if ( AV15i > 80 )
            {
               AV16Salir = true;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S123( )
      {
         /* 'OBTENER PROFESIONAL' Routine */
         returnInSub = false;
         /* Using cursor P00C24 */
         pr_default.execute(2, new Object[] {AV13SDTFeedBackItem.gxTpr_Feedbackprofesionalid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A120ProfesionalesId = P00C24_A120ProfesionalesId[0];
            A40000ProfesionalesPhoto_GXI = P00C24_A40000ProfesionalesPhoto_GXI[0];
            A167ProfesionalesApellidoPrimero = P00C24_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00C24_A166ProfesionalesPrimerNombre[0];
            A169ProfesionalesPhoto = P00C24_A169ProfesionalesPhoto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)) )
            {
               AV13SDTFeedBackItem.gxTpr_Imagen = context.GetImagePath( "43abcb77-c434-4394-9540-41bfffe10a43", "", context.GetTheme( ));
               AV13SDTFeedBackItem.gxTpr_Imagen_gxi = GXDbFile.PathToUrl( context.GetImagePath( "43abcb77-c434-4394-9540-41bfffe10a43", "", context.GetTheme( )), context);
            }
            else
            {
               AV13SDTFeedBackItem.gxTpr_Imagen = A169ProfesionalesPhoto;
               AV13SDTFeedBackItem.gxTpr_Imagen_gxi = A40000ProfesionalesPhoto_GXI;
            }
            AV13SDTFeedBackItem.gxTpr_Profesionalnombre = StringUtil.Format( "%1 %2", StringUtil.Upper( StringUtil.Trim( A166ProfesionalesPrimerNombre)), StringUtil.Upper( StringUtil.Trim( A167ProfesionalesApellidoPrimero)), "", "", "", "", "", "", "");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         AV8SDTFeedBack = new GXBaseCollection<SdtSDTFeedBack_Items>( context, "Items", "AlmangoX");
         P00C22_A133ProveedorID = new long[1] ;
         P00C22_A127SolicitudesID = new long[1] ;
         P00C23_A117FeedBackId = new long[1] ;
         P00C23_A272FeedBackSolicitudId = new long[1] ;
         P00C23_A273FeedBackProfesionalId = new string[] {""} ;
         P00C23_A275FeedBackNum = new long[1] ;
         P00C23_A271FeedBackComentario = new string[] {""} ;
         P00C23_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00C23_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         A273FeedBackProfesionalId = "";
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         A277FeedBackFechaModif = DateTime.MinValue;
         AV13SDTFeedBackItem = new SdtSDTFeedBack_Items(context);
         P00C24_A120ProfesionalesId = new string[] {""} ;
         P00C24_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         P00C24_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00C24_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00C24_A169ProfesionalesPhoto = new string[] {""} ;
         A120ProfesionalesId = "";
         A40000ProfesionalesPhoto_GXI = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A169ProfesionalesPhoto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ofeedbackxpro__default(),
            new Object[][] {
                new Object[] {
               P00C22_A133ProveedorID, P00C22_A127SolicitudesID
               }
               , new Object[] {
               P00C23_A117FeedBackId, P00C23_A272FeedBackSolicitudId, P00C23_A273FeedBackProfesionalId, P00C23_A275FeedBackNum, P00C23_A271FeedBackComentario, P00C23_A276FeedBackFechaAlta, P00C23_A277FeedBackFechaModif
               }
               , new Object[] {
               P00C24_A120ProfesionalesId, P00C24_A40000ProfesionalesPhoto_GXI, P00C24_A167ProfesionalesApellidoPrimero, P00C24_A166ProfesionalesPrimerNombre, P00C24_A169ProfesionalesPhoto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15i ;
      private long AV9ProveedorID ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private long AV11SolicitudesID ;
      private long A117FeedBackId ;
      private long A272FeedBackSolicitudId ;
      private long A275FeedBackNum ;
      private string A273FeedBackProfesionalId ;
      private string A120ProfesionalesId ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private DateTime A276FeedBackFechaAlta ;
      private DateTime A277FeedBackFechaModif ;
      private bool AV16Salir ;
      private bool returnInSub ;
      private string A271FeedBackComentario ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTFeedBack_Items> AV8SDTFeedBack ;
      private IDataStoreProvider pr_default ;
      private long[] P00C22_A133ProveedorID ;
      private long[] P00C22_A127SolicitudesID ;
      private long[] P00C23_A117FeedBackId ;
      private long[] P00C23_A272FeedBackSolicitudId ;
      private string[] P00C23_A273FeedBackProfesionalId ;
      private long[] P00C23_A275FeedBackNum ;
      private string[] P00C23_A271FeedBackComentario ;
      private DateTime[] P00C23_A276FeedBackFechaAlta ;
      private DateTime[] P00C23_A277FeedBackFechaModif ;
      private SdtSDTFeedBack_Items AV13SDTFeedBackItem ;
      private string[] P00C24_A120ProfesionalesId ;
      private string[] P00C24_A40000ProfesionalesPhoto_GXI ;
      private string[] P00C24_A167ProfesionalesApellidoPrimero ;
      private string[] P00C24_A166ProfesionalesPrimerNombre ;
      private string[] P00C24_A169ProfesionalesPhoto ;
      private GXBaseCollection<SdtSDTFeedBack_Items> aP1_SDTFeedBack ;
   }

   public class ofeedbackxpro__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C22;
          prmP00C22 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00C23;
          prmP00C23 = new Object[] {
          new ParDef("@AV11SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00C24;
          prmP00C24 = new Object[] {
          new ParDef("@AV13SDTF_1Feedbackprofesional",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C22", "SELECT [ProveedorID], [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @AV9ProveedorID ORDER BY [SolicitudesID] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C23", "SELECT TOP 1 [FeedBackId], [FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif] FROM [FeedBack] WHERE ([FeedBackId] > 0) AND ([FeedBackSolicitudId] > 0) AND ([FeedBackSolicitudId] = @AV11SolicitudesID) ORDER BY [FeedBackId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C24", "SELECT [ProfesionalesId], [ProfesionalesPhoto_GXI], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @AV13SDTF_1Feedbackprofesional ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C24,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
                return;
       }
    }

 }

}
