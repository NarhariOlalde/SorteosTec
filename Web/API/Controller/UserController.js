const mysql = require("../database/db");

class MainController {
  async getUsers(req, res) {
    console.log("Get Users");
    var sql = `call sp_get_users()`;
    mysql.query(sql, (error, data, fields) => {
      if (error) {
        res.status(500);
        res.send(error.message);
      } else {
        console.log(data);
        res.json({
          data,
        });
      }
    });
  }

  async createUser(req, res) {
    console.log("Create User");
    console.log(req.body);

    if (
      req.body.nombre != null &&
      req.body.apellido != null &&
      req.body.correo != null &&
      req.body.datos_bancarios != null &&
      req.body.genero != null &&
      req.body.sexo != null &&
      req.body.edad != null &&
      req.body.localizacion != null &&
      req.body.administrador != null
    ) {
      let nombre = req.body.nombre;
      let apellido = req.body.apellido;
      let correo = req.body.correo;
      let datos_bancarios = req.body.datos_bancarios;
      let genero = req.body.genero;
      let sexo = req.body.sexo;
      let edad = req.body.edad;
      let localizacion = req.body.localizacion;
      let administrador = req.body.administrador;

      var sql = `call addNewUser('${nombre}', '${apellido}', '${correo}', '${datos_bancarios}', '${genero}', '${sexo}', '${edad}', '${localizacion}', '${administrador}');`;
      mysql.query(sql, (error, data, fields) => {
        if (error) {
          res.status(500);
          res.send(error.message);
          console.log(error.message);
        } else {
          console.log(data);
          res.json({
            status: 200,
            message: "User created successfully",
            affectedRows: data.affectedRows,
          });
        }
      });
    } else {
      res.send("Por favor llena todos los datos!");
      console.log("Por favor llena todos los datos!");
    }
  }
}

const userController = new MainController();
module.exports = userController;