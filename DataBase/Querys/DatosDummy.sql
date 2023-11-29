-- Inserting dummy data into `Usuario`
INSERT INTO Usuario (nombre, apellido, correo, datos_bancarios, sexo, edad, localizacion, administrador) VALUES
('John', 'Doe', 'john.doe@example.com', 'BankAccount1', 'Male', 30, 'Location1', FALSE),
('Jane', 'Smith', 'jane.smith@example.com', 'BankAccount2', 'Female', 25, 'Location2', TRUE),
('Alice', 'Johnson', 'alice.johnson@example.com', 'BankAccount3', 'Female', 28, 'Location3', FALSE),
('Bob', 'Brown', 'bob.brown@example.com', 'BankAccount4',  'Male', 35, 'Location4', FALSE),
('Emma', 'Williams', 'emma.williams@example.com', 'BankAccount5', 'Female', 22, 'Location5', TRUE);

-- Inserting dummy data into `UserName`
INSERT INTO UserName (id_usuario, nombre, password) VALUES
(1, 'john_d', 'password123'),
(2, 'jane_s', 'pass456'),
(3, 'alice_j', 'alicepass'),
(4, 'bob_b', 'bobbrown'),
(5, 'emma_w', 'emmawill');

-- Inserting dummy data into `UserGame`
INSERT INTO UserGame (id_usuario, puntuacion_maxima, tiempo_jugado, inventario) VALUES
(1, 1000, 120, 'Item1, Item2'),
(2, 1500, 300, 'Item3, Item4'),
(3, 800, 200, 'Item5'),
(4, 1100, 400, 'Item6, Item7'),
(5, 1300, 150, 'Item8, Item9');

-- Inserting dummy data into `Referrals`
INSERT INTO Referrals (id_usuario, amigos_invitados) VALUES
(1, 3),
(2, 5),
(3, 2),
(4, 4),
(5, 1);

-- Inserting dummy data into `Productos`
INSERT INTO Productos (descripcion) VALUES
('Producto1'),
('Producto2'),
('Producto3'),
('Producto4'),
('Producto5');

-- Inserting dummy data into `Microtransaccion`
INSERT INTO Microtransaccion (id_usuario, id_producto, costo) VALUES
(1, 1, 100),
(2, 2, 200),
(3, 3, 300),
(4, 4, 400),
(5, 5, 500);
