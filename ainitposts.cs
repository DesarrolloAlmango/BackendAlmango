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
   public class ainitposts : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new ainitposts().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public ainitposts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ainitposts( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P00A42 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P00A43 */
         pr_default.execute(1);
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("Post");
         /* End optimized DELETE. */
         /*
            INSERT RECORD ON TABLE Post

         */
         A195PostId = 1;
         A408PostTitle = context.GetMessage( "Cafe Carioca", "");
         A409PostImage = context.GetImagePath( "e6796cb2-6cdc-4483-9742-0b5c4d3c9be2", "", context.GetTheme( ));
         A40000PostImage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e6796cb2-6cdc-4483-9742-0b5c4d3c9be2", "", context.GetTheme( )), context);
         /* Using cursor P00A44 */
         pr_default.execute(2, new Object[] {A195PostId, A415PostReferencia, A408PostTitle, A409PostImage, A40000PostImage_GXI});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("Post");
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 1;
         A407PostCommentId = 1;
         A410PostCommentContent = context.GetMessage( "En carioca el frio nos encanta , tenemos el antídoto al invierno, mega expreso con mezcla sublime, estan invitados.", "");
         /* Using cursor P00A45 */
         pr_default.execute(3, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(3) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 1;
         A407PostCommentId = 2;
         A410PostCommentContent = context.GetMessage( "Ya está en la cocina!!", "");
         /* Using cursor P00A46 */
         pr_default.execute(4, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(4) == 1) )
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
         /*
            INSERT RECORD ON TABLE Post

         */
         A195PostId = 2;
         A408PostTitle = context.GetMessage( "Mmmmmmm que lindo verlas, me encanta que me reciban así!! ", "");
         A409PostImage = context.GetImagePath( "08baf471-f61e-4efb-bdaa-847823273555", "", context.GetTheme( ));
         A40000PostImage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "08baf471-f61e-4efb-bdaa-847823273555", "", context.GetTheme( )), context);
         /* Using cursor P00A47 */
         pr_default.execute(5, new Object[] {A195PostId, A415PostReferencia, A408PostTitle, A409PostImage, A40000PostImage_GXI});
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("Post");
         if ( (pr_default.getStatus(5) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 2;
         A407PostCommentId = 1;
         A410PostCommentContent = context.GetMessage( "No se luce la picada. Y el depto más cool de la CV tampoco! In jus ti cia", "");
         /* Using cursor P00A48 */
         pr_default.execute(6, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(6);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(6) == 1) )
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
         /*
            INSERT RECORD ON TABLE Post

         */
         A195PostId = 3;
         A408PostTitle = context.GetMessage( "Te vi... juntabas margaritas del mantel", "");
         /* Using cursor P00A49 */
         pr_default.execute(7, new Object[] {A195PostId, A415PostReferencia, A408PostTitle});
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("Post");
         if ( (pr_default.getStatus(7) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 3;
         A407PostCommentId = 1;
         A410PostCommentContent = context.GetMessage( "lo peor que yo te vi ahí en el estadio! yo se que para ver a un uruguayo en esta fase de la copa tuviste que ir! pero ta jaja", "");
         /* Using cursor P00A410 */
         pr_default.execute(8, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(8);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(8) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 3;
         A407PostCommentId = 2;
         A410PostCommentContent = context.GetMessage( "segui con rentitas mejor!", "");
         /* Using cursor P00A411 */
         pr_default.execute(9, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(9);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(9) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 3;
         A407PostCommentId = 3;
         A410PostCommentContent = context.GetMessage( "Excelente tema de FITO PAEZ. Uno de los primeros. Muuuuy biien Luis.", "");
         /* Using cursor P00A412 */
         pr_default.execute(10, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(10);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(10) == 1) )
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
         context.CommitDataStores("initposts",pr_default);
         /*
            INSERT RECORD ON TABLE Post

         */
         A195PostId = 4;
         A408PostTitle = context.GetMessage( "Laura Pássaro mixed a combination on Candy Crush Saga.", "");
         A409PostImage = context.GetImagePath( "aced7afd-a2d6-4518-b070-fa6ffbbd3bb0", "", context.GetTheme( ));
         A40000PostImage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "aced7afd-a2d6-4518-b070-fa6ffbbd3bb0", "", context.GetTheme( )), context);
         /* Using cursor P00A413 */
         pr_default.execute(11, new Object[] {A195PostId, A415PostReferencia, A408PostTitle, A409PostImage, A40000PostImage_GXI});
         pr_default.close(11);
         pr_default.SmartCacheProvider.SetUpdated("Post");
         if ( (pr_default.getStatus(11) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 4;
         A407PostCommentId = 1;
         A410PostCommentContent = context.GetMessage( "NoComment", "");
         /* Using cursor P00A414 */
         pr_default.execute(12, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(12);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(12) == 1) )
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
         /*
            INSERT RECORD ON TABLE Post

         */
         A195PostId = 5;
         A408PostTitle = context.GetMessage( "Bio Oficina", "");
         A409PostImage = context.GetImagePath( "e4d84850-f08c-469d-8439-01a26956c5c2", "", context.GetTheme( ));
         A40000PostImage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "e4d84850-f08c-469d-8439-01a26956c5c2", "", context.GetTheme( )), context);
         /* Using cursor P00A415 */
         pr_default.execute(13, new Object[] {A195PostId, A415PostReferencia, A408PostTitle, A409PostImage, A40000PostImage_GXI});
         pr_default.close(13);
         pr_default.SmartCacheProvider.SetUpdated("Post");
         if ( (pr_default.getStatus(13) == 1) )
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
         /*
            INSERT RECORD ON TABLE PostComment

         */
         A195PostId = 5;
         A407PostCommentId = 1;
         A410PostCommentContent = context.GetMessage( "Que placer trabajar", "");
         /* Using cursor P00A416 */
         pr_default.execute(14, new Object[] {A195PostId, A415PostReferencia, A407PostCommentId, A410PostCommentContent});
         pr_default.close(14);
         pr_default.SmartCacheProvider.SetUpdated("PostComment");
         if ( (pr_default.getStatus(14) == 1) )
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
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("initposts",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         A408PostTitle = "";
         A409PostImage = "";
         A40000PostImage_GXI = "";
         A415PostReferencia = "";
         Gx_emsg = "";
         A410PostCommentContent = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ainitposts__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainitposts__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS63 ;
      private int GX_INS64 ;
      private long A195PostId ;
      private long A407PostCommentId ;
      private string A415PostReferencia ;
      private string Gx_emsg ;
      private string A410PostCommentContent ;
      private string A408PostTitle ;
      private string A40000PostImage_GXI ;
      private string A409PostImage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class ainitposts__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class ainitposts__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00A42;
        prmP00A42 = new Object[] {
        };
        Object[] prmP00A43;
        prmP00A43 = new Object[] {
        };
        Object[] prmP00A44;
        prmP00A44 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Post", Fld="PostImage"}
        };
        Object[] prmP00A45;
        prmP00A45 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A46;
        prmP00A46 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A47;
        prmP00A47 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Post", Fld="PostImage"}
        };
        Object[] prmP00A48;
        prmP00A48 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A49;
        prmP00A49 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0)
        };
        Object[] prmP00A410;
        prmP00A410 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A411;
        prmP00A411 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A412;
        prmP00A412 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A413;
        prmP00A413 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Post", Fld="PostImage"}
        };
        Object[] prmP00A414;
        prmP00A414 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        Object[] prmP00A415;
        prmP00A415 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostTitle",GXType.NVarChar,256,0) ,
        new ParDef("@PostImage",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@PostImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Post", Fld="PostImage"}
        };
        Object[] prmP00A416;
        prmP00A416 = new Object[] {
        new ParDef("@PostId",GXType.Decimal,18,0) ,
        new ParDef("@PostReferencia",GXType.NChar,20,0) ,
        new ParDef("@PostCommentId",GXType.Decimal,18,0) ,
        new ParDef("@PostCommentContent",GXType.NVarChar,2097152,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00A42", "DELETE FROM [PostComment] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A42)
           ,new CursorDef("P00A43", "DELETE FROM [Post] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A43)
           ,new CursorDef("P00A44", "INSERT INTO [Post]([PostId], [PostReferencia], [PostTitle], [PostImage], [PostImage_GXI], [PostUsuario], [PostUsuarioNombre], [PostFecha], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostTitle, @PostImage, @PostImage_GXI, '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A44)
           ,new CursorDef("P00A45", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A45)
           ,new CursorDef("P00A46", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A46)
           ,new CursorDef("P00A47", "INSERT INTO [Post]([PostId], [PostReferencia], [PostTitle], [PostImage], [PostImage_GXI], [PostUsuario], [PostUsuarioNombre], [PostFecha], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostTitle, @PostImage, @PostImage_GXI, '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A47)
           ,new CursorDef("P00A48", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A48)
           ,new CursorDef("P00A49", "INSERT INTO [Post]([PostId], [PostReferencia], [PostTitle], [PostUsuario], [PostUsuarioNombre], [PostFecha], [PostImage], [PostImage_GXI], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostTitle, '', '', convert( DATETIME, '17530101', 112 ), CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A49)
           ,new CursorDef("P00A410", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A410)
           ,new CursorDef("P00A411", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A411)
           ,new CursorDef("P00A412", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A412)
           ,new CursorDef("P00A413", "INSERT INTO [Post]([PostId], [PostReferencia], [PostTitle], [PostImage], [PostImage_GXI], [PostUsuario], [PostUsuarioNombre], [PostFecha], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostTitle, @PostImage, @PostImage_GXI, '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A413)
           ,new CursorDef("P00A414", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A414)
           ,new CursorDef("P00A415", "INSERT INTO [Post]([PostId], [PostReferencia], [PostTitle], [PostImage], [PostImage_GXI], [PostUsuario], [PostUsuarioNombre], [PostFecha], [PostDateUpdated]) VALUES(@PostId, @PostReferencia, @PostTitle, @PostImage, @PostImage_GXI, '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A415)
           ,new CursorDef("P00A416", "INSERT INTO [PostComment]([PostId], [PostReferencia], [PostCommentId], [PostCommentContent], [PostCommentUsuario], [PostCommentUsuarioNom], [PostCommentUsuarioImg], [PostCommentUsuarioImg_GXI], [PostCommentDate]) VALUES(@PostId, @PostReferencia, @PostCommentId, @PostCommentContent, '', '', CONVERT(varbinary(1), ''), '', convert( DATETIME, '17530101', 112 ))", GxErrorMask.GX_NOMASK,prmP00A416)
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
