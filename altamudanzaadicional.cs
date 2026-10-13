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
   public class altamudanzaadicional : GXProcedure
   {
      public altamudanzaadicional( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public altamudanzaadicional( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           string aP1_Gx_mode )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.Gx_mode = aP1_Gx_mode;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 string aP1_Gx_mode )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.Gx_mode = aP1_Gx_mode;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV14GXV1));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaAdicional

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A766ItemAdicionalId = AV11SDTCargaItem.gxTpr_Id;
                  A768ItemAdicionalCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  /* Using cursor P00FJ2 */
                  pr_default.execute(0, new Object[] {A735MudanzaId, A766ItemAdicionalId, A768ItemAdicionalCantidad});
                  pr_default.close(0);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
                  if ( (pr_default.getStatus(0) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV15GXLvl14 = 0;
               /* Optimized UPDATE. */
               /* Using cursor P00FJ3 */
               pr_default.execute(1, new Object[] {AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  AV15GXLvl14 = 1;
               }
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
               /* End optimized UPDATE. */
               if ( AV15GXLvl14 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaAdicional

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A766ItemAdicionalId = AV11SDTCargaItem.gxTpr_Id;
                     A768ItemAdicionalCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     /* Using cursor P00FJ4 */
                     pr_default.execute(2, new Object[] {A735MudanzaId, A766ItemAdicionalId, A768ItemAdicionalCantidad});
                     pr_default.close(2);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaAdicional");
                     if ( (pr_default.getStatus(2) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV8SDTCargaJson = "";
         AV9WebSession = context.GetSession();
         AV10SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV11SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.altamudanzaadicional__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A766ItemAdicionalId ;
      private short A768ItemAdicionalCantidad ;
      private short AV15GXLvl14 ;
      private int AV14GXV1 ;
      private int GX_INS121 ;
      private long AV12MudanzaId ;
      private long A735MudanzaId ;
      private string Gx_mode ;
      private string Gx_emsg ;
      private string AV8SDTCargaJson ;
      private IGxSession AV9WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV10SDTCarga ;
      private SdtSDTCarga_SDTCargaItem AV11SDTCargaItem ;
      private IDataStoreProvider pr_default ;
   }

   public class altamudanzaadicional__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FJ2;
          prmP00FJ2 = new Object[] {
          new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@ItemAdicionalId",GXType.Int16,4,0) ,
          new ParDef("@ItemAdicionalCantidad",GXType.Int16,4,0)
          };
          Object[] prmP00FJ3;
          prmP00FJ3 = new Object[] {
          new ParDef("@ItemAdicionalCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
          };
          Object[] prmP00FJ4;
          prmP00FJ4 = new Object[] {
          new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
          new ParDef("@ItemAdicionalId",GXType.Int16,4,0) ,
          new ParDef("@ItemAdicionalCantidad",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FJ2", "INSERT INTO [MudanzaAdicional]([MudanzaId], [ItemAdicionalId], [ItemAdicionalCantidad]) VALUES(@MudanzaId, @ItemAdicionalId, @ItemAdicionalCantidad)", GxErrorMask.GX_NOMASK,prmP00FJ2)
             ,new CursorDef("P00FJ3", "UPDATE [MudanzaAdicional] SET [ItemAdicionalCantidad]=@ItemAdicionalCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemAdicionalId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FJ3)
             ,new CursorDef("P00FJ4", "INSERT INTO [MudanzaAdicional]([MudanzaId], [ItemAdicionalId], [ItemAdicionalCantidad]) VALUES(@MudanzaId, @ItemAdicionalId, @ItemAdicionalCantidad)", GxErrorMask.GX_NOMASK,prmP00FJ4)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
