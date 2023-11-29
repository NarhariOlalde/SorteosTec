DELIMITER //

CREATE PROCEDURE UpdateMaxScore(
    IN _id_usuario INT,
    IN _new_puntuacion_maxima INT
)
BEGIN
    DECLARE _current_maxima INT;

    -- Retrieve the current maximum score
    SELECT puntuacion_maxima INTO _current_maxima
    FROM UserGame
    WHERE id_usuario = _id_usuario;

    -- Check if the new score is higher and update if it is
    IF _new_puntuacion_maxima > _current_maxima THEN
        UPDATE UserGame
        SET puntuacion_maxima = _new_puntuacion_maxima
        WHERE id_usuario = _id_usuario;
    END IF;
END //

DELIMITER ;
