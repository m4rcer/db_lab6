CREATE OR ALTER PROCEDURE GET_CALLS 
AS
	SELECT CALLS.CALL_ID, CALLS.VICTIMS_FULL_NAME,CALLS.CALL_TIME,
	CALLS.CALL_TEXT,
	CALLS.REPORT,CALLS.BRIGADE_DISPATCH_TIME,
	CALLS.BRIGADE_ARRIVAL_TIME,CALLS.BRIGADE_RETURN_TIME,
	CALLS.EMPLOYEE_ID,
	EMPLOYEES.EMPLOYEE_NAME,EMPLOYEES.EMPLOYEE_SURNAME,
	EMPLOYEES.EMPLOYEE_FATHERS_NAME
	FROM CALLS
	LEFT JOIN EMPLOYEES
	ON CALLS.EMPLOYEE_ID = EMPLOYEES.EMPLOYEE_ID
	ORDER BY CALLS.CALL_ID DESC
Go

EXEC GET_CALLS
