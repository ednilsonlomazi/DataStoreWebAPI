USE AdventureWorks2022;
 
INSERT INTO dbdatastore.dbo.tabClasseObjeto
(DescricaoClasse)
SELECT DISTINCT UPPER([NAME]) FROM sys.schemas sc
WHERE 1 = 1
	 

--------------- populando objetos disponiveis -------------------
DELETE FROM dbdatastore.dbo.tabObjeto;
INSERT INTO dbdatastore.dbo.tabObjeto
(
	serverName,
	DatabaseName,
	ObjectName,
	codigoBancoDados,
	codigoObjeto,
	codigoSchema,
	descricaoTipoObjeto
)
SELECT @@SERVERNAME,
	   'AdventureWorks2022',
	   sob.name,
	   DB_ID('AdventureWorks2022'),
	   sob.[object_id],
	   sob.[schema_id], 
	   REPLACE(LOWER(sob.[type_desc]), '_', ' ') tipo
FROM AdventureWorks2022.sys.objects sob
WHERE 1 = 1
	AND sob.[type] IN ('U', 'V', 'P') -- user tables, views and procedures
 

UPDATE dbdatastore.dbo.tabObjeto
SET idClasseObjeto = sc.IdClasse 
FROM dbdatastore.dbo.tabObjeto obj
	OUTER APPLY (

		SELECT TOP 1 tco.IdClasse 
		FROM sys.schemas scs
	
			LEFT JOIN dbdatastore.dbo.tabClasseObjeto tco WITH(NOLOCK)
				ON scs.[name] COLLATE DATABASE_DEFAULT = tco.[DescricaoClasse] COLLATE DATABASE_DEFAULT
		
		WHERE obj.codigoSchema = scs.schema_id
	
	) sc

----------------- populando permissoes ----------------------
INSERT INTO dbdatastore.dbo.tabPermissao 
(
	descricaoPermissao,
	classePermissao

)
SELECT DISTINCT fnp.[permission_name],
				fnp.class_desc
FROM sys.fn_builtin_permissions('OBJECT') fnp


INSERT INTO dbdatastore.dbo.tabStatusDocumentos
(DescricaoStatus, indAtivo)
VALUES
('ABERTO', 1), 
('ENVIADO', 1),
('EM AVALIACAO', 1),
('AVALIADO', 1),
('FECHADO', 1),
('CANCELADO', 1)