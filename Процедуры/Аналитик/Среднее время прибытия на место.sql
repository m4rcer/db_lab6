CREATE OR ALTER PROCEDURE CalculateAverageTravelTime
AS
BEGIN
    -- �������� ��������� ������� ��� �������� ������� �� �������
    CREATE TABLE #TravelTime (
        TimeDifference INT
    )

    -- ������� ����������� ������� �� ��������� �������
    INSERT INTO #TravelTime (TimeDifference)
    SELECT 
        DATEDIFF(MINUTE, BRIGADE_DISPATCH_TIME, BRIGADE_ARRIVAL_TIME) AS TimeDifference
    FROM 
        Calls
    WHERE 
        BRIGADE_DISPATCH_TIME IS NOT NULL AND BRIGADE_ARRIVAL_TIME IS NOT NULL

    -- ���������� �������� �������� ������� � ����
    DECLARE @AverageTime FLOAT
    SELECT @AverageTime = AVG(CAST(TimeDifference AS FLOAT))
    FROM #TravelTime

    -- ����� ����������
    SELECT @AverageTime AS AverageTravelTimeInMinutes

    -- �������� ��������� �������
    DROP TABLE #TravelTime
END
Go

EXEC CalculateAverageTravelTime
