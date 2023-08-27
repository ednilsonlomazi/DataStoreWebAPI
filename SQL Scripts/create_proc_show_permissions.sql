USE dbdatastore;
GO

CREATE PROCEDURE dbo.spr_list_permissions 

@database VARCHAR(256) = 'AdventureWorks2022',
@username VARCHAR(256) = 'Bob',
@object_id INT

AS
	
	DECLARE @comando_base NVARCHAR(MAX) = 

		'
			USE @dynamic_sql_param_database;

			EXECUTE AS USER = @dynamic_sql_param_user;

			WITH cte AS
			(
				SELECT BD_ID() [database_id],
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
					CROSS APPLY fn_my_permissions(sc.[name] + ''.'' + so.[name], ''OBJECT'') [permissions]
				WHERE 1 = 1
					AND so.[type] IN (''U'', ''V'')
					AND [permissions].subentity_name = ''''
				UNION ALL
				SELECT BD_ID() [database_id], 
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
					CROSS APPLY fn_my_permissions(sc.[name] + ''.'' + so.[name], ''OBJECT'') [permissions]
				WHERE 1 = 1
					AND so.[type] IN (''P'', ''FN'')
			)
			SELECT * FROM cte cte
			WHERE 1 = 1
				AND cte.[object_id] = @dynamic_sql_param_object_id

		',
		@comando NVARCHAR(MAX);

	SET @comando = REPLACE(
						REPLACE(
							REPLACE(
								@comando_base, 
									'@dynamic_sql_param_database', @database
							), '@dynamic_sql_param_user', @username
						), '@dynamic_sql_param_object_id', @object_id
					);

	EXEC (@comando);
GO