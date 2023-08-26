USE AdventureWorks2022;

INSERT INTO dbdatastore.dbo.tabObjeto
(
	serverName,
	codigoBancoDados,
	codigoObjeto,
	codigoSchema,
	descricaoTipoObjeto
)
SELECT @@SERVERNAME,
	   DB_ID(),
	   sob.[object_id],
	   sob.[schema_id], 
	   REPLACE(LOWER(sob.[type_desc]), '_', ' ') tipo
FROM sys.objects sob
WHERE 1 = 1
	AND sob.[type] IN ('U', 'V', 'P') -- user tables, views and procedures
