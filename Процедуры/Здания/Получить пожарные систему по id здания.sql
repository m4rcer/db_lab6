CREATE OR ALTER PROCEDURE GET_BUILDING_FIRE_SYSTEMS @BUILDING_ID INT
AS
	SELECT FIRE_SYSTEM_TYPES.FIRE_SYSTEM_TYPE_ID, FIRE_SYSTEM_TYPES.FIRE_SYSTEM_TYPE_NAME
	FROM FIRE_SYSTEM_TYPES_BUILDINGS
	LEFT JOIN FIRE_SYSTEM_TYPES
	ON FIRE_SYSTEM_TYPES_BUILDINGS.FIRE_SYSTEM_TYPE_ID = FIRE_SYSTEM_TYPES.FIRE_SYSTEM_TYPE_ID
	WHERE FIRE_SYSTEM_TYPES_BUILDINGS.BUILDING_ID = @BUILDING_ID
Go

EXEC GET_BUILDING_FIRE_SYSTEMS 26
