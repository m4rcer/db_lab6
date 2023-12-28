CREATE OR ALTER PROCEDURE CalculateAverageTravelTime
AS
BEGIN
    -- Создание временной таблицы для хранения разницы во времени
    CREATE TABLE #TravelTime (
        TimeDifference INT
    )

    -- Вставка результатов запроса во временную таблицу
    INSERT INTO #TravelTime (TimeDifference)
    SELECT 
        DATEDIFF(MINUTE, BRIGADE_DISPATCH_TIME, BRIGADE_ARRIVAL_TIME) AS TimeDifference
    FROM 
        Calls
    WHERE 
        BRIGADE_DISPATCH_TIME IS NOT NULL AND BRIGADE_ARRIVAL_TIME IS NOT NULL

    -- Вычисление среднего значения времени в пути
    DECLARE @AverageTime FLOAT
    SELECT @AverageTime = AVG(CAST(TimeDifference AS FLOAT))
    FROM #TravelTime

    -- Вывод результата
    SELECT @AverageTime AS AverageTravelTimeInMinutes

    -- Удаление временной таблицы
    DROP TABLE #TravelTime
END
Go

EXEC CalculateAverageTravelTime
