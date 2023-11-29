DELIMITER //

CREATE PROCEDURE RecordUserGameData(
    IN _id_usuario INT,
    IN _puntuacion_maxima INT,
    IN _tiempo_jugado INT,
    IN _inventario TEXT
)
BEGIN
    INSERT INTO UserGame (id_usuario, puntuacion_maxima, tiempo_jugado, inventario)
    VALUES (_id_usuario, _puntuacion_maxima, _tiempo_jugado, _inventario)
    ON DUPLICATE KEY UPDATE 
        puntuacion_maxima = _puntuacion_maxima, 
        tiempo_jugado = _tiempo_jugado, 
        inventario = _inventario;
END //

DELIMITER ;
