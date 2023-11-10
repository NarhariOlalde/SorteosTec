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

  async addBook(req, res) {
    console.log("Add Book RTQ");
    console.log(req.body);
    if (
      req.body.name != null &&
      req.body.author != null &&
      req.body.cover != null 
    ) {
      let name = req.body.name;
      let author = req.body.author;
      let cover = req.body.cover;
      var sql = `call sp_add_book('${name}', '${author}', '${cover}');`;
      mysql.query(sql, (error, data, fields) => {
        if (error) {
          res.status(500);
          res.send(error.message);
          console.log(error.message);
        } else {
          console.log(data);
          res.json({
            status: 200,
            message: "Books uploaded successfully",
            affectedRows: data.affectedRows,
          });
        }
      });
    } else {
      res.send("Por favor llena todos los datos!");
      console.log("Por favor llena todos los datos!");
    }
  }

  async editBook(req, res) {
    console.log("Edit Book RTQ");
    console.log(req.body);
    if (
      req.params.id != null &&
      req.body.name != null &&
      req.body.author != null &&
      req.body.cover != null 
    ) {
      let bookID = req.params.id;
      let name = req.body.name;
      let author = req.body.author;
      let cover = req.body.cover;
      var sql = `call sp_edit_book('${bookID}','${name}', '${author}', '${cover}');`;
      mysql.query(sql, (error, data, fields) => {
        if (error) {
          res.status(500);
          res.send(error.message);
          console.log(error.message);
        } else {
          console.log(data);
          res.json({
            status: 200,
            message: "Book updated successfully",
            affectedRows: data.affectedRows,
          });
        }
      });
    } else {
      res.send("Por favor llena todos los datos!");
      console.log("Por favor llena todos los datos!");
    }
  }

  async deleteBook(req, res) {
    console.log("Delete Book RTQ");
    console.log(req.params.id);
    if (
      req.params.id != null
    ) {
      let bookID = req.params.id;
      var sql = `call sp_delete_book('${bookID}');`;
      mysql.query(sql, (error, data, fields) => {
        if (error) {
          res.status(500);
          res.send(error.message);
          console.log(error.message);
        } else {
          console.log(data);
          res.json({
            status: 200,
            message: "Book deleted successfully",
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

const bookController = new MainController();
module.exports = bookController;
