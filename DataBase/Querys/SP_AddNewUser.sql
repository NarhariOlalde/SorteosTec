DELIMITER //

CREATE PROCEDURE AddNewUser(
    IN _nombre TEXT,
    IN _apellido TEXT,
    IN _correo TEXT,
    IN _datos_bancarios TEXT,
    IN _sexo TEXT,
    IN _edad TEXT,
    IN _localizacion TEXT,
    IN _administrador boolean
)
BEGIN
    INSERT INTO Usuario (nombre, apellido, correo, datos_bancarios, genero, sexo, edad, localizacion, administrador) 
    VALUES (_nombre, _apellido, _correo, _datos_bancarios, _sexo, _edad, _localizacion, _administrador);
END //

DELIMITER ;