use fire_department;

INSERT INTO EMPLOYEE_SPECIALIZATIONS (EMPLOYEE_SPECIALIZATION_NAME) VALUES 
('�������������'),('��������'),('��������'),('���������'),('���������');

INSERT INTO EQUIPMENT_TYPES (EQUIPMENT_TYPE_NAME) VALUES 
('�������� ����������'),('�����'),('������������ ������'),('�����'),('�������� �����')
,('�������� �����'),('�����'),('���'),('������������'),('������');

INSERT INTO BUILDING_TYPES (BUILDING_TYPE_NAME) VALUES 
('�����'),('����������������'),('����������������'),('��������������������');

INSERT INTO FIRE_SYSTEM_TYPES (FIRE_SYSTEM_TYPE_NAME) VALUES 
('�������������� �������� �������'),('������ �������� �������'),('������������ � ����������')
,('��������� ��������� � ������������'),('�������� ������������');

INSERT INTO EMPLOYEES (EMPLOYEE_NAME,EMPLOYEE_SURNAME,EMPLOYEE_FATHERS_NAME,
EMPLOYEE_PHONE_NUMBER,EMPLOYEE_EMAIL,EMPLOYEE_PASSWORD,
EMPLOYEE_SPECIALIZATION_ID) VALUES (
'Admin',
'Admin',
'Admin',
'+79494444444',
'admin@admin.com',
'admin',
1
)