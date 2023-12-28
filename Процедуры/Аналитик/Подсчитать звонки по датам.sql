CREATE OR ALTER PROCEDURE CountCallsPerDay
AS
BEGIN

    DECLARE @StartDate DATE
    DECLARE @EndDate DATE
	
    SET @EndDate = GETDATE()
    SET @StartDate = DATEADD(DAY, -30, @EndDate)

    CREATE TABLE #CallCounts (
        CALL_DATE DATE,
        CallsCount INT
    )

    INSERT INTO #CallCounts (CALL_DATE, CallsCount)
    SELECT 
        CONVERT(DATE, CALL_TIME) AS CALL_DATE,
        COUNT(*) AS CallsCount
    FROM 
        Calls
    WHERE 
        CALL_TIME BETWEEN @StartDate AND @EndDate
    GROUP BY 
        CONVERT(DATE, CALL_TIME)
    ORDER BY 
        CALL_DATE DESC

    SELECT * FROM #CallCounts

    DROP TABLE #CallCounts
END
Go


EXEC CountCallsPerDay

