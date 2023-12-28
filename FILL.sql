use fire_department;

INSERT INTO EMPLOYEE_SPECIALIZATIONS (EMPLOYEE_SPECIALIZATION_NAME) VALUES 
('Администратор'),('Аналитик'),('Бригадир'),('Диспетчер'),('Сотрудник');

INSERT INTO EQUIPMENT_TYPES (EQUIPMENT_TYPE_NAME) VALUES 
('Пожарный автомобиль'),('Форма'),('Огнезащитный костюм'),('Каска'),('Пожарный топор')
,('Пожарное ведро'),('Рация'),('Лом'),('Огнетушитель'),('Лопата');

INSERT INTO BUILDING_TYPES (BUILDING_TYPE_NAME) VALUES 
('Жилое'),('Административное'),('Производственное'),('Сельскохозяйственное');

INSERT INTO FIRE_SYSTEM_TYPES (FIRE_SYSTEM_TYPE_NAME) VALUES 
('Автоматическая пожарная система'),('Ручная пожарная система'),('Дымоудаление и вентиляция')
,('Аварийное освещение и сигнализация'),('Пожарная сигнализация');

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