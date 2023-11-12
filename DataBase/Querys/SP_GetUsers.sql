use sorteosTec

DELIMITER //

CREATE PROCEDURE sp_get_users()
BEGIN
    SELECT * FROM Usuario;
END //
DELIMITER ;
