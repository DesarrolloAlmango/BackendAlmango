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
   public class integrarfenicio : GXProcedure
   {
      public integrarfenicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public integrarfenicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EcommerceId ,
                           long aP1_ComercioId ,
                           string aP2_BaseApiUrl ,
                           string aP3_Estado ,
                           out bool aP4_ResultadoOK ,
                           ref string aP5_DebugLog )
      {
         this.AV11EcommerceId = aP0_EcommerceId;
         this.AV9ComercioId = aP1_ComercioId;
         this.AV8BaseApiUrl = aP2_BaseApiUrl;
         this.AV13Estado = aP3_Estado;
         this.AV20ResultadoOK = false ;
         this.AV10DebugLog = aP5_DebugLog;
         initialize();
         ExecutePrivate();
         aP4_ResultadoOK=this.AV20ResultadoOK;
         aP5_DebugLog=this.AV10DebugLog;
      }

      public string executeUdp( long aP0_EcommerceId ,
                                long aP1_ComercioId ,
                                string aP2_BaseApiUrl ,
                                string aP3_Estado ,
                                out bool aP4_ResultadoOK )
      {
         execute(aP0_EcommerceId, aP1_ComercioId, aP2_BaseApiUrl, aP3_Estado, out aP4_ResultadoOK, ref aP5_DebugLog);
         return AV10DebugLog ;
      }

      public void executeSubmit( long aP0_EcommerceId ,
                                 long aP1_ComercioId ,
                                 string aP2_BaseApiUrl ,
                                 string aP3_Estado ,
                                 out bool aP4_ResultadoOK ,
                                 ref string aP5_DebugLog )
      {
         this.AV11EcommerceId = aP0_EcommerceId;
         this.AV9ComercioId = aP1_ComercioId;
         this.AV8BaseApiUrl = aP2_BaseApiUrl;
         this.AV13Estado = aP3_Estado;
         this.AV20ResultadoOK = false ;
         this.AV10DebugLog = aP5_DebugLog;
         SubmitImpl();
         aP4_ResultadoOK=this.AV20ResultadoOK;
         aP5_DebugLog=this.AV10DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18PageSize = 50;
         Gx_page = 1;
         AV21Total = 0;
         AV22TotalPages = 0;
         new obtenercontrolintegracion(context ).execute(  AV11EcommerceId,  AV9ComercioId,  "FGO", out  AV14FechaDesde, out  AV15FechaHasta) ;
         AV10DebugLog += context.GetMessage( "[CTRL] Fechas ", "") + context.localUtil.Format( AV14FechaDesde, "99/99/99") + " - " + context.localUtil.Format( AV15FechaHasta, "99/99/99") + StringUtil.NewLine( );
         Gx_page = 1;
         AV10DebugLog += context.GetMessage( "[API][PAGE 1] pageSize=", "") + StringUtil.Str( (decimal)(AV18PageSize), 4, 0) + StringUtil.NewLine( );
         new fenicio_getorders(context ).execute(  AV8BaseApiUrl,  AV13Estado,  AV14FechaDesde,  AV15FechaHasta,  (short)(Gx_page),  AV18PageSize, out  AV17OrdersResponse, out  AV12Error, ref  AV10DebugLog) ;
         AV26OperacionContexto = StringUtil.Trim( AV8BaseApiUrl) + context.GetMessage( "/page=1&pageSize=", "") + StringUtil.Str( (decimal)(AV18PageSize), 4, 0);
         AV27OperacionPayload = AV17OrdersResponse.ToJSonString(false, true);
         AV28OperacionMensajeApi = AV17OrdersResponse.gxTpr_Msj;
         AV25EstadoOperacion = (AV12Error ? "PND" : "PRO");
         /* Execute user subroutine: 'REGISTRAROPERACIONFENICIO' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV12Error )
         {
            cleanup();
            if (true) return;
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV17OrdersResponse.gxTpr_Ordenes.Count )
         {
            AV23Orden = ((SdtSDTFenicioOrdersResponse_ordenesItem)AV17OrdersResponse.gxTpr_Ordenes.Item(AV41GXV1));
            AV42GXV2 = 1;
            while ( AV42GXV2 <= AV23Orden.gxTpr_Lineas.Count )
            {
               AV32Linea = ((SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem)AV23Orden.gxTpr_Lineas.Item(AV42GXV2));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Linea.gxTpr_Sku)) )
               {
                  AV33SkuOriginal = StringUtil.Lower( StringUtil.Trim( AV32Linea.gxTpr_Sku));
                  if ( StringUtil.StartsWith( AV33SkuOriginal, context.GetMessage( "amg", "")) )
                  {
                     AV37SkuNormalizado = "";
                     AV39UltimoGuionPos = 0;
                     AV36Pos = 1;
                     while ( AV36Pos <= StringUtil.Len( AV33SkuOriginal) )
                     {
                        AV38Caracter = StringUtil.Substring( AV33SkuOriginal, AV36Pos, 1);
                        if ( StringUtil.StrCmp(AV38Caracter, "-") == 0 )
                        {
                           AV39UltimoGuionPos = AV36Pos;
                        }
                        AV36Pos = (short)(AV36Pos+1);
                     }
                     AV36Pos = 1;
                     while ( AV36Pos <= StringUtil.Len( AV33SkuOriginal) )
                     {
                        AV38Caracter = StringUtil.Substring( AV33SkuOriginal, AV36Pos, 1);
                        if ( ( ( StringUtil.StrCmp(AV38Caracter, context.GetMessage( "a", "")) >= 0 ) && ( StringUtil.StrCmp(AV38Caracter, context.GetMessage( "z", "")) <= 0 ) ) || ( ( StringUtil.StrCmp(AV38Caracter, "0") >= 0 ) && ( StringUtil.StrCmp(AV38Caracter, "9") <= 0 ) ) )
                        {
                           AV37SkuNormalizado += AV38Caracter;
                        }
                        else if ( ( StringUtil.StrCmp(AV38Caracter, "-") == 0 ) && ( AV36Pos == AV39UltimoGuionPos ) )
                        {
                           AV37SkuNormalizado += "-";
                        }
                        else if ( StringUtil.StrCmp(AV38Caracter, "-") == 0 )
                        {
                           AV37SkuNormalizado += "-";
                        }
                        else
                        {
                           if (true) break;
                        }
                        AV36Pos = (short)(AV36Pos+1);
                     }
                     AV10DebugLog += context.GetMessage( "[sku] ", "") + StringUtil.Trim( AV37SkuNormalizado);
                     AV32Linea.gxTpr_Sku = StringUtil.Trim( AV37SkuNormalizado);
                     AV35Plog = new SdtPlog(context);
                     AV35Plog.gxTpr_Plogmsg = AV37SkuNormalizado;
                     AV35Plog.Insert();
                     context.CommitDataStores("integrarfenicio",pr_default);
                  }
               }
               AV42GXV2 = (int)(AV42GXV2+1);
            }
            new procesarordenfenicio(context ).execute(  AV23Orden,  AV11EcommerceId,  AV9ComercioId,  AV14FechaDesde,  AV15FechaHasta, out  AV24ProcesadaOK, ref  AV10DebugLog) ;
            AV41GXV1 = (int)(AV41GXV1+1);
         }
         AV21Total = AV17OrdersResponse.gxTpr_Totabs;
         AV22TotalPages = (short)((AV21Total+AV18PageSize-1)/ (decimal)(AV18PageSize));
         AV10DebugLog += context.GetMessage( "[CTRL] Total=", "") + StringUtil.Str( AV21Total, 18, 2) + context.GetMessage( " Pages=", "") + StringUtil.Str( (decimal)(AV22TotalPages), 4, 0) + StringUtil.NewLine( );
         Gx_page = 2;
         while ( Gx_page <= AV22TotalPages )
         {
            AV10DebugLog += context.GetMessage( "[API][PAGE ", "") + StringUtil.Str( (decimal)(Gx_page), 6, 0) + "]" + StringUtil.NewLine( );
            new fenicio_getorders(context ).execute(  AV8BaseApiUrl,  AV13Estado,  AV14FechaDesde,  AV15FechaHasta,  (short)(Gx_page),  AV18PageSize, out  AV17OrdersResponse, out  AV12Error, ref  AV10DebugLog) ;
            AV26OperacionContexto = StringUtil.Trim( AV8BaseApiUrl) + context.GetMessage( "/page=", "") + StringUtil.Str( (decimal)(Gx_page), 6, 0) + context.GetMessage( "&pageSize=", "") + StringUtil.Str( (decimal)(AV18PageSize), 4, 0) + context.GetMessage( "&from=", "") + context.localUtil.Format( AV14FechaDesde, "99/99/99") + context.GetMessage( "&to=", "") + context.localUtil.Format( AV15FechaHasta, "99/99/99");
            AV27OperacionPayload = AV17OrdersResponse.ToJSonString(false, true);
            AV28OperacionMensajeApi = AV17OrdersResponse.gxTpr_Msj;
            AV25EstadoOperacion = (AV12Error ? "PND" : "PRO");
            /* Execute user subroutine: 'REGISTRAROPERACIONFENICIO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( AV12Error )
            {
               cleanup();
               if (true) return;
            }
            AV10DebugLog += context.GetMessage( "Procesando página ", "") + StringUtil.Str( (decimal)(Gx_page), 6, 0) + StringUtil.NewLine( );
            AV43GXV3 = 1;
            while ( AV43GXV3 <= AV17OrdersResponse.gxTpr_Ordenes.Count )
            {
               AV23Orden = ((SdtSDTFenicioOrdersResponse_ordenesItem)AV17OrdersResponse.gxTpr_Ordenes.Item(AV43GXV3));
               AV44GXV4 = 1;
               while ( AV44GXV4 <= AV23Orden.gxTpr_Lineas.Count )
               {
                  AV32Linea = ((SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem)AV23Orden.gxTpr_Lineas.Item(AV44GXV4));
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Linea.gxTpr_Sku)) )
                  {
                     AV33SkuOriginal = StringUtil.Lower( StringUtil.Trim( AV32Linea.gxTpr_Sku));
                     if ( StringUtil.StartsWith( AV33SkuOriginal, context.GetMessage( "amg", "")) )
                     {
                        AV37SkuNormalizado = "";
                        AV39UltimoGuionPos = 0;
                        AV36Pos = 1;
                        while ( AV36Pos <= StringUtil.Len( AV33SkuOriginal) )
                        {
                           AV38Caracter = StringUtil.Substring( AV33SkuOriginal, AV36Pos, 1);
                           if ( StringUtil.StrCmp(AV38Caracter, "-") == 0 )
                           {
                              AV39UltimoGuionPos = AV36Pos;
                           }
                           AV36Pos = (short)(AV36Pos+1);
                        }
                        AV36Pos = 1;
                        while ( AV36Pos <= StringUtil.Len( AV33SkuOriginal) )
                        {
                           AV38Caracter = StringUtil.Substring( AV33SkuOriginal, AV36Pos, 1);
                           if ( ( ( StringUtil.StrCmp(AV38Caracter, context.GetMessage( "a", "")) >= 0 ) && ( StringUtil.StrCmp(AV38Caracter, context.GetMessage( "z", "")) <= 0 ) ) || ( ( StringUtil.StrCmp(AV38Caracter, "0") >= 0 ) && ( StringUtil.StrCmp(AV38Caracter, "9") <= 0 ) ) )
                           {
                              AV37SkuNormalizado += AV38Caracter;
                           }
                           else if ( ( StringUtil.StrCmp(AV38Caracter, "-") == 0 ) && ( AV36Pos == AV39UltimoGuionPos ) )
                           {
                              AV37SkuNormalizado += "-";
                           }
                           else if ( StringUtil.StrCmp(AV38Caracter, "-") == 0 )
                           {
                              AV37SkuNormalizado += "-";
                           }
                           else
                           {
                              if (true) break;
                           }
                           AV36Pos = (short)(AV36Pos+1);
                        }
                        AV32Linea.gxTpr_Sku = StringUtil.Trim( AV37SkuNormalizado);
                     }
                  }
                  AV44GXV4 = (int)(AV44GXV4+1);
               }
               new procesarordenfenicio(context ).execute(  AV23Orden,  AV11EcommerceId,  AV9ComercioId,  AV14FechaDesde,  AV15FechaHasta, out  AV24ProcesadaOK, ref  AV10DebugLog) ;
               AV43GXV3 = (int)(AV43GXV3+1);
            }
            Gx_page = (int)(Gx_page+1);
         }
         AV20ResultadoOK = true;
         cleanup();
      }

      protected void S111( )
      {
         /* 'REGISTRAROPERACIONFENICIO' Routine */
         returnInSub = false;
         new registrarordenfenicioprocesada(context ).execute(  "",  AV11EcommerceId,  AV9ComercioId,  "FGO",  AV25EstadoOperacion,  AV26OperacionContexto,  AV27OperacionPayload,  AV16MensajeBC,  AV14FechaDesde,  AV15FechaHasta,  AV28OperacionMensajeApi, out  AV20ResultadoOK) ;
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
         AV14FechaDesde = DateTime.MinValue;
         AV15FechaHasta = DateTime.MinValue;
         AV17OrdersResponse = new SdtSDTFenicioOrdersResponse(context);
         AV26OperacionContexto = "";
         AV27OperacionPayload = "";
         AV28OperacionMensajeApi = "";
         AV25EstadoOperacion = "";
         AV23Orden = new SdtSDTFenicioOrdersResponse_ordenesItem(context);
         AV32Linea = new SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem(context);
         AV33SkuOriginal = "";
         AV37SkuNormalizado = "";
         AV38Caracter = "";
         AV35Plog = new SdtPlog(context);
         AV16MensajeBC = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.integrarfenicio__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.integrarfenicio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18PageSize ;
      private short AV22TotalPages ;
      private short AV39UltimoGuionPos ;
      private short AV36Pos ;
      private int AV41GXV1 ;
      private int AV42GXV2 ;
      private int AV43GXV3 ;
      private int AV44GXV4 ;
      private long AV11EcommerceId ;
      private long AV9ComercioId ;
      private decimal AV21Total ;
      private string AV25EstadoOperacion ;
      private string AV33SkuOriginal ;
      private string AV37SkuNormalizado ;
      private string AV38Caracter ;
      private DateTime AV14FechaDesde ;
      private DateTime AV15FechaHasta ;
      private bool AV20ResultadoOK ;
      private bool AV12Error ;
      private bool returnInSub ;
      private bool AV24ProcesadaOK ;
      private string AV10DebugLog ;
      private string AV26OperacionContexto ;
      private string AV27OperacionPayload ;
      private string AV16MensajeBC ;
      private string AV8BaseApiUrl ;
      private string AV13Estado ;
      private string AV28OperacionMensajeApi ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP5_DebugLog ;
      private SdtSDTFenicioOrdersResponse AV17OrdersResponse ;
      private SdtSDTFenicioOrdersResponse_ordenesItem AV23Orden ;
      private SdtSDTFenicioOrdersResponse_ordenesItem_lineasItem AV32Linea ;
      private SdtPlog AV35Plog ;
      private IDataStoreProvider pr_default ;
      private bool aP4_ResultadoOK ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class integrarfenicio__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class integrarfenicio__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
