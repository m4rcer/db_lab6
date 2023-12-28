CREATE PROCEDURE CalculateAverageBrigadesPerCall
AS
BEGIN
    -- �������� ��������� ������� ��� �������� ���������� ������ �� �����
    CREATE TABLE #BrigadeCounts (
        CallID INT,
        BrigadeCount INT
    )

    -- ������� ����������� ������� �� ��������� �������
    INSERT INTO #BrigadeCounts (CallID, BrigadeCount)
    SELECT 
        Call_ID,
        COUNT(*) AS BrigadeCount
    FROM 
        Calls_brigades
    GROUP BY 
        Call_ID

    -- ���������� �������� ���������� ������ �� �����
    DECLARE @AverageBrigadesPerCall FLOAT
    SELECT @AverageBrigadesPerCall = AVG(CAST(BrigadeCount AS FLOAT))
    FROM #BrigadeCounts

    -- ����� ����������
    SELECT @AverageBrigadesPerCall AS AverageBrigadesPerCall

    -- �������� ��������� �������
    DROP TABLE #BrigadeCounts
END
Go

EXEC CalculateAverageBrigadesPerCall
