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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class obteneravatar : GXProcedure
   {
      public obteneravatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obteneravatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out string aP2_Avatar ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV9User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Avatar = "" ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_Avatar=this.AV10Avatar;
         aP3_RestMessage=this.AV11RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               out string aP2_Avatar ,
                               out string aP3_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_Avatar, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out string aP2_Avatar ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV9User = aP0_User;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Avatar = "" ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_Avatar=this.AV10Avatar;
         aP3_RestMessage=this.AV11RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
         {
            Gx_restcode = 400;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV13HttpRequest, out  AV14TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TokenId)) )
         {
            Gx_restcode = 401;
            AV11RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV9User,  AV8ProfesionalesId,  AV14TokenId, out  AV15EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV15EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV18GXLvl25 = 0;
         /* Using cursor P00ME2 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00ME2_A120ProfesionalesId[0];
            A40000ProfesionalesPhoto_GXI = P00ME2_A40000ProfesionalesPhoto_GXI[0];
            A169ProfesionalesPhoto = P00ME2_A169ProfesionalesPhoto[0];
            AV18GXLvl25 = 1;
            AV12ImagenProfesional = A169ProfesionalesPhoto;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ImagenProfesional)) )
            {
               AV10Avatar = context.FileToBase64( AV12ImagenProfesional);
            }
            Gx_restcode = 200;
            AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV18GXLvl25 == 0 )
         {
            Gx_restcode = 404;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
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
         AV10Avatar = "";
         AV11RestMessage = "";
         AV13HttpRequest = new GxHttpRequest( context);
         AV14TokenId = "";
         AV16TokenDesencriptado = "";
         P00ME2_A120ProfesionalesId = new string[] {""} ;
         P00ME2_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         P00ME2_A169ProfesionalesPhoto = new string[] {""} ;
         A120ProfesionalesId = "";
         A40000ProfesionalesPhoto_GXI = "";
         A169ProfesionalesPhoto = "";
         AV12ImagenProfesional = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obteneravatar__default(),
            new Object[][] {
                new Object[] {
               P00ME2_A120ProfesionalesId, P00ME2_A40000ProfesionalesPhoto_GXI, P00ME2_A169ProfesionalesPhoto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV18GXLvl25 ;
      private string AV9User ;
      private string AV8ProfesionalesId ;
      private string AV14TokenId ;
      private string AV16TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private bool AV15EsValido ;
      private string AV11RestMessage ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string AV10Avatar ;
      private string A169ProfesionalesPhoto ;
      private string AV12ImagenProfesional ;
      private GxHttpRequest AV13HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00ME2_A120ProfesionalesId ;
      private string[] P00ME2_A40000ProfesionalesPhoto_GXI ;
      private string[] P00ME2_A169ProfesionalesPhoto ;
      private string aP2_Avatar ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
   }

   public class obteneravatar__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ME2;
          prmP00ME2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ME2", "SELECT [ProfesionalesId], [ProfesionalesPhoto_GXI], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = RTRIM(LTRIM(@AV8ProfesionalesId)) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ME2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
       }
    }

 }

}
