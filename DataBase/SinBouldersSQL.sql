CREATE TABLE `Usuario` (
  `id_usuario` integer PRIMARY KEY AUTO_INCREMENT,
  `nombre` text,
  `apellido` text,
  `correo` text,
  `datos_bancarios` text,
  `genero` text,
  `sexo` text,
  `edad` int,
  `localizacion` text,
  `administrador` boolean
);

CREATE TABLE `UserName` (
  `id_usuario` int,
  `nombre` text,
  `password` text
);

CREATE TABLE `UserGame` (
  `id_usuario` int,
  `puntuacion_maxima` int,
  `tiempo_jugado` int,
  `inventario` text
);

CREATE TABLE `Referrals` (
  `id_usuario` int,
  `amigos_invitados` int
);

CREATE TABLE `Microtransaccion` (
  `id_usuario` int,
  `id_transaccion` int PRIMARY KEY AUTO_INCREMENT,
  `id_producto` int,
  `costo` int
);

CREATE TABLE `Productos` (
  `id_producto` int PRIMARY KEY AUTO_INCREMENT,
  `descripcion` text
);

ALTER TABLE `UserName` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `UserGame` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Referrals` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Microtransaccion` ADD FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`);

ALTER TABLE `Microtransaccion` ADD FOREIGN KEY (`id_producto`) REFERENCES `Productos` (`id_producto`);
