/*
INSERT INTO PRODUCTOS
(ID,DESCRIPCION,PRECIO,MARCA,CAMPO_1,CAMPO_2, ESTA_ACTIVO, CANTIDAD)
VALUES
(1,'Cable', 200,'Volteck','1.5','0', 1, 2000),
(2,'Cable doble aislacion', 500,'Volteck','6','1',1,1000),
(3,'Resistencia',50,'Backer','100','ohm',1,75),
(4,'Resistencia',50,'Backer','200','ohm',1,30),
(5,'Resistencia',50,'Backer','500','ohm',1,1)

SELECT * from PRODUCTOS

INSERT INTO EMPLEADOS(NOMBRE,APELLIDO,DNI,ADMINISTRADOR, USUARIO,CONTRASENIA, ESTA_ACTIVO)
VALUES
('Agustin','Ramirez',23345678,0,'aramirez','Contra1',1),
('Carla','Fernandez',29159781,2,'cfernandez','Contra2',1),
('Marcos','Baez',33342185,1,'mbaez','Contra3', 1)

SELECT * FROM EMPLEADOS;

INSERT INTO PROVEEDORES(NOMBRE,APELLIDO,DNI,PRODUCTOS, ESTA_ACTIVO)
VALUES
('Alberto', 'Casals', 31323334,'1,2',1),
('Miriam', 'Ferreira', 34433211,'3,4,5',1)

SELECT * FROM PROVEEDORES
*/

DELETE FROM PRODUCTOS