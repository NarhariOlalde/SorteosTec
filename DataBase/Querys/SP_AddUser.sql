DELIMITER //

CREATE PROCEDURE AddNewUser(
    IN _nombre TEXT,
    IN _correo TEXT,
    IN _datos_bancarios TEXT,
    IN _genero TEXT,
    IN _sexo TEXT,
    IN _edad TEXT,
    IN _localizacion TEXT
)
BEGIN
    INSERT INTO Usuario (nombre, correo, datos_bancarios, genero, sexo, edad, localizacion) 
    VALUES (_nombre, _correo, _datos_bancarios, _genero, _sexo, _edad, _localizacion);
END //

DELIMITER ;
