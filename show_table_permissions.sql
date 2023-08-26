
EXECUTE AS USER = 'User';



SELECT T.TABLE_TYPE AS OBJECT_TYPE, 
	   T.TABLE_SCHEMA AS [SCHEMA_NAME], 
	   T.TABLE_NAME AS [OBJECT_NAME], 
	   P.PERMISSION_NAME 
FROM INFORMATION_SCHEMA.TABLES T
	CROSS APPLY fn_my_permissions(T.TABLE_SCHEMA + '.' + T.TABLE_NAME, 'OBJECT') P
WHERE P.subentity_name = ''
UNION
SELECT R.ROUTINE_TYPE AS OBJECT_TYPE, 
	   R.ROUTINE_SCHEMA AS [SCHEMA_NAME], 
	   R.ROUTINE_NAME AS [OBJECT_NAME], 
	   P.PERMISSION_NAME
FROM INFORMATION_SCHEMA.ROUTINES R
	CROSS APPLY fn_my_permissions(R.ROUTINE_SCHEMA + '.' + R.ROUTINE_NAME, 'OBJECT') P
ORDER BY OBJECT_TYPE, [SCHEMA_NAME], [OBJECT_NAME], P.PERMISSION_NAME

REVERT;
GO