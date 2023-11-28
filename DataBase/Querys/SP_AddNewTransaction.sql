DELIMITER //

CREATE PROCEDURE AddNewTransaction(
    IN _id_usuario INT,
    IN _id_producto INT,
    IN _costo INT
)
BEGIN
    INSERT INTO Microtransaccion (id_usuario, id_producto, costo)
    VALUES (_id_usuario, _id_producto, _costo);
END //

DELIMITER ;
