CREATE PROCEDURE CalculateAverageBrigadesPerCall
AS
BEGIN
    -- Создание временной таблицы для хранения количества бригад на вызов
    CREATE TABLE #BrigadeCounts (
        CallID INT,
        BrigadeCount INT
    )

    -- Вставка результатов запроса во временную таблицу
    INSERT INTO #BrigadeCounts (CallID, BrigadeCount)
    SELECT 
        Call_ID,
        COUNT(*) AS BrigadeCount
    FROM 
        Calls_brigades
    GROUP BY 
        Call_ID

    -- Вычисление среднего количества бригад на вызов
    DECLARE @AverageBrigadesPerCall FLOAT
    SELECT @AverageBrigadesPerCall = AVG(CAST(BrigadeCount AS FLOAT))
    FROM #BrigadeCounts

    -- Вывод результата
    SELECT @AverageBrigadesPerCall AS AverageBrigadesPerCall

    -- Удаление временной таблицы
    DROP TABLE #BrigadeCounts
END
Go

EXEC CalculateAverageBrigadesPerCall
