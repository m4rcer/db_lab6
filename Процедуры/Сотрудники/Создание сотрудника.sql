CREATE OR ALTER PROCEDURE CREATE_EMPLOYEE @EMPLOYEE_NAME as VARCHAR(120), @EMPLOYEE_SURNAME as VARCHAR(120),
@EMPLOYEE_FATHERS_NAME as VARCHAR(120), @EMPLOYEE_PHONE_NUMBER as VARCHAR(120),
@EMPLOYEE_EMAIL as VARCHAR(120),
@EMPLOYEE_PASSWORD as VARCHAR(120), @EMPLOYEE_SPECIALIZATION_ID as smallint,
@BRIGADE_ID as INT
AS
	DECLARE @EMPLOYEE_ID as INT, @EMPLOYEE_SPECIALIZATION_NAME as VARCHAR(120), @BRIGADIR_ID as INT;

	

	SELECT TOP 1 @EMPLOYEE_SPECIALIZATION_NAME = EMPLOYEE_SPECIALIZATIONS.EMPLOYEE_SPECIALIZATION_NAME
	FROM EMPLOYEE_SPECIALIZATIONS 
	WHERE EMPLOYEE_SPECIALIZATIONS.EMPLOYEE_SPECIALIZATION_ID = @EMPLOYEE_SPECIALIZATION_ID;

	SELECT TOP 1 @BRIGADIR_ID = emp.EMPLOYEE_ID
	FROM (EMPLOYEES as emp
	LEFT JOIN EMPLOYEE_SPECIALIZATIONS as spec
	ON emp.EMPLOYEE_SPECIALIZATION_ID = spec.EMPLOYEE_SPECIALIZATION_ID
	LEFT JOIN BRIGADES as br
	ON br.BRIGADE_ID = emp.BRIGADE_ID)
	WHERE spec.EMPLOYEE_SPECIALIZATION_NAME = 'Бригадир' AND emp.BRIGADE_ID = @BRIGADE_ID;

	IF(@BRIGADIR_ID is not null AND @EMPLOYEE_SPECIALIZATION_NAME = 'Бригадир')
	BEGIN
		;THROW 51000, 'В бригаду можно добавить только одного Бригадира', 1; 
	END

	IF ((@EMPLOYEE_SPECIALIZATION_NAME != 'Бригадир' AND @EMPLOYEE_SPECIALIZATION_NAME != 'Сотрудник')
	AND @BRIGADE_ID is not null)
	BEGIN
		;THROW 51000, 'В бригаду можно добавить только Бригадира и Сотрудника', 1; 
	END
	ELSE
	BEGIN
		IF ((@EMPLOYEE_SPECIALIZATION_NAME = 'Бригадир' OR @EMPLOYEE_SPECIALIZATION_NAME = 'Сотрудник')
		AND @BRIGADE_ID is null)
		BEGIN
			;THROW 51000, 'Бригадира и Сотрудника можно добавить только в бригаду', 1; 
		END
		ELSE
		BEGIN
			INSERT INTO EMPLOYEES 
			(EMPLOYEE_NAME,EMPLOYEE_SURNAME,EMPLOYEE_FATHERS_NAME,
			EMPLOYEE_PHONE_NUMBER,EMPLOYEE_EMAIL,EMPLOYEE_PASSWORD,
			EMPLOYEE_SPECIALIZATION_ID,BRIGADE_ID) 
			VALUES 
			(@EMPLOYEE_NAME,@EMPLOYEE_SURNAME,@EMPLOYEE_FATHERS_NAME,
			@EMPLOYEE_PHONE_NUMBER,@EMPLOYEE_EMAIL,@EMPLOYEE_PASSWORD,
			@EMPLOYEE_SPECIALIZATION_ID,@BRIGADE_ID);
		END
	END
Go

EXEC CREATE_EMPLOYEE '2023-11-11', '2023-11-23', 'ee3rg2e2r','232323f2we@feg.ere', 'e232gerg', 'ergergergeg',3,0
