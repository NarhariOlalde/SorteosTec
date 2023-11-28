DELIMITER //

CREATE PROCEDURE GetUserMaxScore(
    IN _id_usuario INT,
    OUT _puntuacion_maxima INT
)
BEGIN
    SELECT puntuacion_maxima INTO _puntuacion_maxima
    FROM UserGame
    WHERE id_usuario = _id_usuario;
END //

DELIMITER ;
