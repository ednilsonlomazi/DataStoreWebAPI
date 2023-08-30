USE dbdatastore;
GO

CREATE PROCEDURE dbo.spr_gera_relatorio_permissoes 
@serverName VARCHAR(256) = 'LAPTOP-RU2VMCN7',
@database VARCHAR(256) = 'AdventureWorks2022',
@username VARCHAR(256) = 'Bob'
AS


	DECLARE @tab_bancos 
	TABLE (
			cod INT IDENTITY(1,1), 
			serverName VARCHAR(256), 
			bancoDados VARCHAR(256), 
			loop_time BIT DEFAULT 0
	);
	DECLARE @codSelecao INT, 
			@serverNameSelecao VARCHAR(256), 
			@bancoDadosSelecao VARCHAR(256);
	
	
	INSERT INTO @tab_bancos 
	(
		serverName,
		bancoDados
	)
	SELECT DISTINCT tob.serverName,
					DB_NAME(tob.codigoBancoDados)
	FROM dbdatastore.dbo.tabObjeto tob WITH (NOLOCK)

	
	DECLARE @comando_base NVARCHAR(MAX),
			@comando NVARCHAR(MAX);
		
		SET @comando_base =

		'
			USE @dynamic_sql_db;

			EXECUTE AS USER = ''@dynamic_sql_user'';

			WITH cte AS
			(
				SELECT DB_ID() [database_id],
					   so.object_id [object_id],
					   sc.[schema_id],
					   sc.[name] [schema_name],
					   so.[name] [object_name],
					   CONCAT(sc.[name], ''.'', so.[name]) [name],
					   so.[type_desc],
					   [permissions].[permission_name]
				FROM sys.objects so
					LEFT JOIN sys.schemas sc
						ON so.schema_id = sc.schema_id
					CROSS APPLY sys.fn_my_permissions(sc.[name] + ''.'' + so.[name], ''OBJECT'') [permissions]
				WHERE 1 = 1
					AND so.[type] IN (''U'', ''V'')
					AND [permissions].subentity_name = ''''
				UNION ALL
				SELECT DB_ID() [database_id], 
					   so.object_id [object_id],
					   sc.[schema_id],
					   sc.[name] [schema_name],
					   so.[name] [object_name],
					   CONCAT(sc.[name], ''.'', so.[name]) [name],
					   so.[type_desc],
					   [permissions].[permission_name]
				FROM sys.objects so
					LEFT JOIN sys.schemas sc
						ON so.schema_id = sc.schema_id
					CROSS APPLY sys.fn_my_permissions(sc.[name] + ''.'' + so.[name], ''OBJECT'') [permissions]
				WHERE 1 = 1
					AND so.[type] IN (''P'', ''FN'')
			)
			SELECT * FROM cte cte
			WHERE 1 = 1
				AND EXISTS (
					SELECT to.codigoObjeto
					FROM dbdatastore.dbo.tabObjeto to WITH (NOLOCK)
					WHERE 1 = 1
						AND cte.database_id = to.codigoObjeto
						AND cte.object_id = to.codigoObjeto
				)
	

		'

	WHILE EXISTS (SELECT TOP 1 1 check_while FROM @tab_bancos WHERE loop_time = 0)
	BEGIN

		
		SELECT TOP 1 @codSelecao = tbs.cod,
					 @serverNameSelecao = tbs.serverName, 
					 @bancoDadosSelecao = tbs.bancoDados 
		FROM @tab_bancos tbs
		WHERE tbs.loop_time = 0
		ORDER BY tbs.cod DESC
		
		SET @comando = REPLACE(
							REPLACE(
								REPLACE(
									@comando_base, 
										'@dynamic_sql_server', @serverNameSelecao
								), '@dynamic_sql_db', @bancoDadosSelecao
							), '@dynamic_sql_user', @username
						)

		EXEC (@comando);

		UPDATE @tab_bancos
		SET loop_time = 1
		FROM @tab_bancos tbs
		WHERE tbs.cod = @codSelecao
		
	END	
		


GO