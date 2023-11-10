DELIMITER //

CREATE PROCEDURE AddNewTransaction(
    IN _id_usuario INT,
    IN _compra TEXT,
    IN _costo INT
)
BEGIN
    INSERT INTO Microtransaccion (id_usuario, compra, costo) 
    VALUES (_id_usuario, _compra, _costo);
END //

DELIMITER ;
