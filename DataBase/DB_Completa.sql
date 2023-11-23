-- MySQL dump 10.13  Distrib 8.0.31, for macos12.6 (x86_64)
--
-- Host: 127.0.0.1    Database: SorteosTec
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `SorteosTec`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `SorteosTec` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `SorteosTec`;

--
-- Table structure for table `Microtransaccion`
--

DROP TABLE IF EXISTS `Microtransaccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Microtransaccion` (
  `id_usuario` int DEFAULT NULL,
  `id_transaccion` int NOT NULL AUTO_INCREMENT,
  `compra` text,
  `costo` int DEFAULT NULL,
  PRIMARY KEY (`id_transaccion`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `microtransaccion_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Microtransaccion`
--

LOCK TABLES `Microtransaccion` WRITE;
/*!40000 ALTER TABLE `Microtransaccion` DISABLE KEYS */;
/*!40000 ALTER TABLE `Microtransaccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Puntuacion`
--

DROP TABLE IF EXISTS `Puntuacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Puntuacion` (
  `id_usuario` int DEFAULT NULL,
  `puntuacion_juego` int NOT NULL,
  PRIMARY KEY (`puntuacion_juego`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `puntuacion_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Puntuacion`
--

LOCK TABLES `Puntuacion` WRITE;
/*!40000 ALTER TABLE `Puntuacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `Puntuacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Referrals`
--

DROP TABLE IF EXISTS `Referrals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Referrals` (
  `id_usuario` int DEFAULT NULL,
  `amigos_invitados` int DEFAULT NULL,
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `referrals_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Referrals`
--

LOCK TABLES `Referrals` WRITE;
/*!40000 ALTER TABLE `Referrals` DISABLE KEYS */;
/*!40000 ALTER TABLE `Referrals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserGame`
--

DROP TABLE IF EXISTS `UserGame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserGame` (
  `id_usuario` int DEFAULT NULL,
  `puntuacion_juego` int DEFAULT NULL,
  `tiempo_jugado` int DEFAULT NULL,
  `llaves_obtenidas` int DEFAULT NULL,
  `premios` text,
  KEY `id_usuario` (`id_usuario`),
  KEY `puntuacion_juego` (`puntuacion_juego`),
  CONSTRAINT `usergame_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`),
  CONSTRAINT `usergame_ibfk_2` FOREIGN KEY (`puntuacion_juego`) REFERENCES `Puntuacion` (`puntuacion_juego`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserGame`
--

LOCK TABLES `UserGame` WRITE;
/*!40000 ALTER TABLE `UserGame` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserGame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserName`
--

DROP TABLE IF EXISTS `UserName`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserName` (
  `id_usuario` int DEFAULT NULL,
  `nombre` text,
  `password` text,
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `username_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `Usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserName`
--

LOCK TABLES `UserName` WRITE;
/*!40000 ALTER TABLE `UserName` DISABLE KEYS */;
INSERT INTO `UserName` VALUES (1,'CarlosDC','1234'),(5,'Luis4321','4321'),(6,'LuisFer','password1234'),(7,'lswq120','pass'),(8,'ad','sad'),(10,'alanp','12123123'),(11,'asd','asd'),(14,'sadsad','213'),(17,'sda','asdsa'),(20,'ASD','ASD'),(21,'dsaas','sad'),(22,'caarloosdc','2134'),(23,'sadsda','asdsa'),(24,'sadas','sadsads'),(27,'SDDAS','ASDASDA'),(28,'312312','13121'),(30,'carlosdc','1234'),(31,'carlosdcdc','asdasdaasasa'),(32,'ADDA','SAADA'),(33,'1231233','2312312'),(34,'luios','ewq123'),(35,'asdsad','asdsaads'),(36,'asd','asd'),(37,'sofiaXD12lol','casdasd'),(38,'1231','2313213'),(39,'luisad','1234'),(40,'CA','12'),(41,'CD','12'),(42,'DF','12'),(43,'sofia1','1234');
/*!40000 ALTER TABLE `UserName` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuario`
--

DROP TABLE IF EXISTS `Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre` text,
  `apellido` text,
  `correo` text,
  `datos_bancarios` text,
  `sexo` text,
  `edad` int DEFAULT NULL,
  `localizacion` text,
  `administrador` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuario`
--

LOCK TABLES `Usuario` WRITE;
/*!40000 ALTER TABLE `Usuario` DISABLE KEYS */;
INSERT INTO `Usuario` VALUES (1,'Carlos','Durán','A00836623@tec.mx','1234567890123456','masculino',21,'COAH',1),(4,'Juan','Saucedp','juan@correo.com','1234567890123456','masculino',26,'CHP',0),(5,'Luis','Daniel','a@a.com','1234567890123456','masculino',20,'COAH',0),(6,'Luis','Fernandez','Correo@email.com','1234123412341234','masculino',28,'JAL',0),(7,'Carlos','D','a@a.com','1234567890123456','masculino',23,'GRO',0),(8,'as','ds','asa@as.c','22132112312334','femenino',25,'MEX',0),(9,'Carlos','Cabello','qw@aw.c','12123213213123','femenino',24,'COL',0),(10,'Alan','Pesina','sdas@sda.com','213231344123412','masculino',29,'ZAC',0),(11,'sadas','asdasda','asdas#@dsas.com','123','femenino',26,'PUE',0),(14,'sdfsdf','fdsa','12312@xfgb','2132132132131321','femenino',24,'COAH',0),(17,'21','21','a@a','212312312','masculino',25,'CHI',0),(20,'AS','SA','SA@S','12345678901234','masculino',20,'CDMX',0),(21,'sadas','asdasd','as@zas','2211232131231231','masculino',24,'CAM',0),(22,'José Carlos','Durán Cabello','email@correo.com','1234123412341234','masculino',21,'GRO',0),(23,'2132','21312','2131231@1212','1222131231231232','masculino',25,'BCS',0),(24,'Jose','Carlos','asd@asd','1232132312312321','masculino',30,'BCS',0),(27,'WQEWQ','WQEWQ','QW@AW','3213123123123123','femenino',25,'BCS',0),(28,'sdasd','sdasd','asdsad@as','2313121232321312','femenino',18,'CHI',0),(30,'José Carlos','Durán Cabello','A@tec.mx','1231233131231231','masculino',24,'COAH',0),(31,'asad sad','as asd','sdas@as','1223123123141231','femenino',22,'CHP',0),(32,'CARLOS','DC','AS@AS','2131212313212323','femenino',22,'ZAC',0),(33,'ASDAS','ASDASD','SAD@AS','2312321312312312','masculino',22,'DUR',0),(34,'Carlos','ASD','asdasd@as','2312131131213131','femenino',19,'PUE',0),(35,'Carlos','Duran','as@assaas','1231212312312312','masculino',22,'COAH',0),(36,'dasd','asdas','as@ass','2112321312312212','femenino',18,'CHI',0),(37,'Sofia','Perez','sofia@correo','1232323213211231','masculino',18,'OAX',0),(38,'Josae','sadas','dsa@a','1231313113123131','masculino',30,'AGS',0),(39,'Luis','Demetrio','asd@asd','1231212331231231','masculino',24,'GRO',0),(40,'QWE','QWE','CASD@A','2379492423710232','femenino',20,'CDMX',0),(41,'ASD','VD','W@2','1234567890123456','masculino',19,'MOR',0),(42,'Luis','DM','AS@ERE','1234567890123456','masculino',18,'CAM',0),(43,'Sofia','Cabello','a@email','1234561234567892','femenino',70,'COAH',1);
/*!40000 ALTER TABLE `Usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-23 14:03:17
