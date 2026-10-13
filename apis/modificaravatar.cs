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
   public class modificaravatar : GXProcedure
   {
      public modificaravatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public modificaravatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           string aP2_AvatarStr ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV18User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV19AvatarStr = aP2_AvatarStr;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_RestMessage=this.AV14RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               string aP2_AvatarStr ,
                               out string aP3_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_AvatarStr, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_AvatarStr ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV18User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV19AvatarStr = aP2_AvatarStr;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_RestMessage=this.AV14RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18User)) || String.IsNullOrEmpty(StringUtil.RTrim( AV12ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV19AvatarStr)) )
         {
            Gx_restcode = 400;
            AV14RestMessage = context.GetMessage( "Error al procesar la solicitud: Datos incompletos", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV10HttpRequest, out  AV17TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TokenId)) )
         {
            Gx_restcode = 401;
            AV14RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV18User,  AV12ProfesionalesId,  AV17TokenId, out  AV9EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV9EsValido )
         {
            Gx_restcode = 401;
            AV14RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV21GXLvl26 = 0;
         /* Using cursor P00MD2 */
         pr_default.execute(0, new Object[] {AV12ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTMD2 = 0;
            A120ProfesionalesId = P00MD2_A120ProfesionalesId[0];
            A40000ProfesionalesPhoto_GXI = P00MD2_A40000ProfesionalesPhoto_GXI[0];
            A169ProfesionalesPhoto = P00MD2_A169ProfesionalesPhoto[0];
            AV21GXLvl26 = 1;
            AV15TempBlob=context.FileFromBase64( AV19AvatarStr) ;
            A169ProfesionalesPhoto = AV15TempBlob;
            A40000ProfesionalesPhoto_GXI = GXDbFile.GetUriFromFile( "", "", AV15TempBlob);
            Gx_restcode = 200;
            AV14RestMessage = context.GetMessage( "Foto de perfil actualizada con éxito", "");
            GXTMD2 = 1;
            /* Using cursor P00MD3 */
            pr_default.execute(1, new Object[] {A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A120ProfesionalesId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            if ( GXTMD2 == 1 )
            {
               context.CommitDataStores("apis.modificaravatar",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV21GXLvl26 == 0 )
         {
            Gx_restcode = 404;
            AV14RestMessage = context.GetMessage( "Profesional no encontrado", "");
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.modificaravatar",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV14RestMessage = "";
         AV10HttpRequest = new GxHttpRequest( context);
         AV17TokenId = "";
         AV16TokenDesencriptado = "";
         P00MD2_A120ProfesionalesId = new string[] {""} ;
         P00MD2_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         P00MD2_A169ProfesionalesPhoto = new string[] {""} ;
         A120ProfesionalesId = "";
         A40000ProfesionalesPhoto_GXI = "";
         A169ProfesionalesPhoto = "";
         AV15TempBlob = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.modificaravatar__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.modificaravatar__default(),
            new Object[][] {
                new Object[] {
               P00MD2_A120ProfesionalesId, P00MD2_A40000ProfesionalesPhoto_GXI, P00MD2_A169ProfesionalesPhoto
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV21GXLvl26 ;
      private short GXTMD2 ;
      private string AV18User ;
      private string AV12ProfesionalesId ;
      private string AV17TokenId ;
      private string AV16TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private bool AV9EsValido ;
      private string AV19AvatarStr ;
      private string AV14RestMessage ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private string AV15TempBlob ;
      private GxHttpRequest AV10HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MD2_A120ProfesionalesId ;
      private string[] P00MD2_A40000ProfesionalesPhoto_GXI ;
      private string[] P00MD2_A169ProfesionalesPhoto ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class modificaravatar__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class modificaravatar__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00MD2;
        prmP00MD2 = new Object[] {
        new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP00MD3;
        prmP00MD3 = new Object[] {
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00MD2", "SELECT [ProfesionalesId], [ProfesionalesPhoto_GXI], [ProfesionalesPhoto] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = RTRIM(LTRIM(@AV12ProfesionalesId)) ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MD2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00MD3", "UPDATE [Profesionales] SET [ProfesionalesPhoto]=@ProfesionalesPhoto, [ProfesionalesPhoto_GXI]=@ProfesionalesPhoto_GXI  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MD3)
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
