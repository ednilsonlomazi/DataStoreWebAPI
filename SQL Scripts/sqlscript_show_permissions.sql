USE dbdatastore;
GO

CREATE PROCEDURE dbo.spr_list_permissions 

@database VARCHAR(256) = 'AdventureWorks2022',
@username VARCHAR(256) = 'Bob'

AS

	DECLARE @comando_base VARCHAR(MAX),
			@comando VARCHAR(MAX);

	SELECT @comando_base = Contents.BulkColumn 
	FROM OPENROWSET(BULK N'C:\Users\Ednilson\source\repos\DataStoreWebAPI\base_show_permissions.txt', SINGLE_CLOB) AS Contents

	SET @comando = REPLACE(REPLACE(@comando_base, '__user__', @username), '__database__', @database);

	EXEC (@comando);
GO