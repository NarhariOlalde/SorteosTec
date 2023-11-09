CREATE TABLE `Usuario` (
  `id_usuario` integer PRIMARY KEY AUTO_INCREMENT,
  `nombre` text,
  `apellido` text,
  `correo` text,
  `datos_bancarios` text,
  `genero` text,
  `sexo` text,
  `edad` int,
  `localizacion` text
);

CREATE TABLE `UserName` (
  `id_usuario` int,
  `nombre` text,
  `password` text
);

CREATE TABLE `UserGame` (
  `id_usuario` int,
  `puntuacion_juego` int,
  `tiempo_jugado` int,
  `llaves_obtenidas` int,
  `premios` text
);

CREATE TABLE `Puntuacion` (
  `id_usuario` int,
  `puntuacion_juego` int PRIMARY KEY
);

CREATE TABLE `Referrals` (
  `id_usuario` int,
  `amigos_invitados` int
);

CREATE TABLE `Microtransaccion` (
  `id_usuario` int,
  `id_transaccion` int PRIMARY KEY AUTO_INCREMENT,
  `compra` text,
  `costo` int
);

CREATE TABLE `Administrador` (
  `id_admin` integer PRIMARY KEY AUTO_INCREMENT,
  `id_usuario` int,
  `id_transaccion` int
);

ALTER TABLE `UserName` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `UserGame` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `UserGame` ADD FOREIGN KEY (`puntuacion_juego`) REFERENCES `Puntuacion` (`puntuacion_juego`);

ALTER TABLE `Puntuacion` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Referrals` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Microtransaccion` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Administrador` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Administrador` ADD FOREIGN KEY (`id_transaccion`) REFERENCES `Microtransaccion` (`id_transaccion`);
