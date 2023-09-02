-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: projektni_hci
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrator`
--

DROP TABLE IF EXISTS `administrator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrator` (
  `OSOBA_IdOsobe` int NOT NULL,
  `KorisnickoIme` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Lozinka` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Boja` int NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_ADMINISTRATOR_OSOBA1` FOREIGN KEY (`OSOBA_IdOsobe`) REFERENCES `osoba` (`IdOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrator`
--

LOCK TABLES `administrator` WRITE;
/*!40000 ALTER TABLE `administrator` DISABLE KEYS */;
INSERT INTO `administrator` VALUES (4,'admin','admin',0);
/*!40000 ALTER TABLE `administrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aktivnost`
--

DROP TABLE IF EXISTS `aktivnost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aktivnost` (
  `IdAktivnosti` int NOT NULL AUTO_INCREMENT,
  `NazivAktivnosti` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `OpisAktivnosti` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`IdAktivnosti`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aktivnost`
--

LOCK TABLES `aktivnost` WRITE;
/*!40000 ALTER TABLE `aktivnost` DISABLE KEYS */;
/*!40000 ALTER TABLE `aktivnost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aktivnost_has_grupa`
--

DROP TABLE IF EXISTS `aktivnost_has_grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aktivnost_has_grupa` (
  `AKTIVNOST_IdAktivnosti` int NOT NULL,
  `GRUPA_IdGrupe` int NOT NULL,
  `DatumAktivnosti` date NOT NULL,
  `PeriodAktivnosti` int NOT NULL,
  PRIMARY KEY (`GRUPA_IdGrupe`,`DatumAktivnosti`,`AKTIVNOST_IdAktivnosti`),
  KEY `fk_AKTIVNOST_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe`),
  KEY `fk_AKTIVNOST_has_GRUPA_AKTIVNOST1_idx` (`AKTIVNOST_IdAktivnosti`),
  CONSTRAINT `fk_AKTIVNOST_has_GRUPA_AKTIVNOST1` FOREIGN KEY (`AKTIVNOST_IdAktivnosti`) REFERENCES `aktivnost` (`IdAktivnosti`),
  CONSTRAINT `fk_AKTIVNOST_has_GRUPA_GRUPA1` FOREIGN KEY (`GRUPA_IdGrupe`) REFERENCES `grupa` (`IdGrupe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aktivnost_has_grupa`
--

LOCK TABLES `aktivnost_has_grupa` WRITE;
/*!40000 ALTER TABLE `aktivnost_has_grupa` DISABLE KEYS */;
/*!40000 ALTER TABLE `aktivnost_has_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clanarina`
--

DROP TABLE IF EXISTS `clanarina`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clanarina` (
  `IdClanarine` int NOT NULL AUTO_INCREMENT,
  `TipUsluge` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Iznos` int NOT NULL,
  `Placeno` tinyint NOT NULL,
  `Datum` date NOT NULL,
  `DIJETE_OSOBA_IdOsobe` int NOT NULL,
  `DatumPlacanja` date DEFAULT NULL,
  PRIMARY KEY (`IdClanarine`),
  KEY `fk_CLANARINA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe`),
  CONSTRAINT `fk_CLANARINA_DIJETE1` FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`) REFERENCES `dijete` (`OSOBA_IdOsobe`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clanarina`
--

LOCK TABLES `clanarina` WRITE;
/*!40000 ALTER TABLE `clanarina` DISABLE KEYS */;
INSERT INTO `clanarina` VALUES (1,'Paket 1',250,1,'2022-03-04',2,'2022-12-04'),(3,'Paket 1',250,1,'2022-12-05',26,'2022-12-05'),(4,'Paket 2',300,1,'2023-01-04',26,'2022-12-05'),(5,'Paket 2',300,1,'2022-12-05',11,'2022-12-05'),(10,'Paket 3',500,1,'2023-01-08',27,'2022-12-08'),(13,'Paket 3',350,1,'2022-12-08',31,'2022-12-08'),(14,'Paket 2',300,0,'2023-01-13',2,NULL);
/*!40000 ALTER TABLE `clanarina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dijete`
--

DROP TABLE IF EXISTS `dijete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dijete` (
  `OSOBA_IdOsobe` int NOT NULL,
  `Visina` int NOT NULL,
  `Tezina` int NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  KEY `fk_DIJETE_OSOBA_idx` (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_DIJETE_OSOBA` FOREIGN KEY (`OSOBA_IdOsobe`) REFERENCES `osoba` (`IdOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dijete`
--

LOCK TABLES `dijete` WRITE;
/*!40000 ALTER TABLE `dijete` DISABLE KEYS */;
INSERT INTO `dijete` VALUES (2,112,22),(3,110,20),(11,120,22),(12,130,25),(26,110,20),(27,111,21),(28,112,22),(29,113,23),(30,114,24),(31,115,25),(47,116,26);
/*!40000 ALTER TABLE `dijete` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dijete_has_grupa`
--

DROP TABLE IF EXISTS `dijete_has_grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dijete_has_grupa` (
  `DIJETE_OSOBA_IdOsobe` int NOT NULL,
  `GRUPA_IdGrupe` int NOT NULL,
  PRIMARY KEY (`DIJETE_OSOBA_IdOsobe`),
  KEY `fk_DIJETE_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe`),
  KEY `fk_DIJETE_has_GRUPA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe`),
  CONSTRAINT `fk_DIJETE_has_GRUPA_DIJETE1` FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`) REFERENCES `dijete` (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_DIJETE_has_GRUPA_GRUPA1` FOREIGN KEY (`GRUPA_IdGrupe`) REFERENCES `grupa` (`IdGrupe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dijete_has_grupa`
--

LOCK TABLES `dijete_has_grupa` WRITE;
/*!40000 ALTER TABLE `dijete_has_grupa` DISABLE KEYS */;
INSERT INTO `dijete_has_grupa` VALUES (2,1),(47,1),(31,2),(3,4),(27,4);
/*!40000 ALTER TABLE `dijete_has_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupa`
--

DROP TABLE IF EXISTS `grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupa` (
  `IdGrupe` int NOT NULL AUTO_INCREMENT,
  `NazivGrupe` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `BrojClanova` int NOT NULL,
  PRIMARY KEY (`IdGrupe`),
  UNIQUE KEY `NazivGrupe_UNIQUE` (`NazivGrupe`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupa`
--

LOCK TABLES `grupa` WRITE;
/*!40000 ALTER TABLE `grupa` DISABLE KEYS */;
INSERT INTO `grupa` VALUES (1,'Grupa 1',8),(2,'Grupa 2',4),(3,'Grupa 3',1),(4,'Grupa 4',5),(5,'Grupa 5',0),(6,'Grupa 6',0),(7,'Grupa 7',0),(8,'Grupa 8',0),(9,'Grupa 9',0),(10,'Grupa 10',0),(18,'Grupa 11',0);
/*!40000 ALTER TABLE `grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `osoba`
--

DROP TABLE IF EXISTS `osoba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoba` (
  `IdOsobe` int NOT NULL AUTO_INCREMENT,
  `JMB` char(13) COLLATE utf8_unicode_ci NOT NULL,
  `Ime` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Prezime` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `DatumRodjenja` date NOT NULL,
  `Adresa` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`IdOsobe`),
  UNIQUE KEY `JMB_UNIQUE` (`JMB`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoba`
--

LOCK TABLES `osoba` WRITE;
/*!40000 ALTER TABLE `osoba` DISABLE KEYS */;
INSERT INTO `osoba` VALUES (2,'1357911131517','Slavko','Slavkovic','2019-03-04','Jovana Ducica, Banja Luka, 4'),(3,'1246810121416','Jovan','Jovanovic','2020-05-05','Milosa Obrenovica,  Banja Luka, 22'),(4,'1122334455667','Stefan','Stefanovic','1996-08-14','Cara Lazara, 25, Banja Luka'),(5,'9876543219876','Jovana','Jeftic','1997-09-15','Cara Urosa, Banja Luka, 25'),(7,'9988776655443','Marija','Markovic','1997-11-22','Marija Terzic, Banja Luka, 10'),(8,'7766554433221','Zorana','Zoric','1994-10-13','Jovana Ducica,  Banja Luka, 99'),(9,'6677885599441','Marijana','Marijanovic','1972-05-27','Desanke Maksimovic, Banja Luka, 1'),(10,'1928375676543','Zoran','Zoranovic','2000-02-11','Patre,  Banja Luka, 10'),(11,'1020304958671','Ana','Anic','2019-11-20','Ana,  Banja Luka, 25'),(12,'5091276348613','Anica','Aničić','2019-09-22','Kralja Petra, Banja Luka, 2'),(13,'2305017678912','Ana','Nikolic','2017-05-23','Arsenije Cernojevic,  Banja Luka, 25'),(15,'0308983126116','Ana','Mirkovic','1983-08-03','Ulica 3'),(17,'0607989100027','Danijel','Stojanovic','1989-07-06','Ulica 19'),(18,'0702964105027','Mirjana','Gavric','1964-02-07','Ulica 74'),(19,'1002952100005','Nikola','Mitrovic','1952-02-10','Ulica 63'),(20,'1006949100067','Stanko','Soldat','1949-06-10','Ulica 101'),(21,'1010988101124','Dejan','Babic','1988-10-10','Ulica, Banja Luka, 5'),(22,'1206986101234','Marko','Mirkovic','1986-06-12','Ulica, Banja Luka, 1'),(23,'1210987100018','Petar','Jankovic','1987-10-12','Ulica, Banja Luka, 8'),(26,'1804964163303','Nenad','Savic','1964-04-18','Ulica 26'),(27,'1907951100012','Zoran','Lazic','1951-07-19','Ulica 30'),(28,'2102979163201','Janko','Jankovic','1979-02-21','Ulica 2'),(29,'2108968196769','Milena','Petkovic','1968-08-21','Ulica 84'),(30,'2108988105034','Milijana','Đukic','1988-08-21','Ulica 34'),(31,'2208988105039','Branka','Miljevic','1988-08-22','Ulica 80'),(45,'1503990125037','Jelena','Vaskovic','1990-03-15','Ulica, Banja Luka, 6'),(46,'1234567890124','Marko','Markovic','2000-03-23','Milosa Obilica, Banja Luka, 5'),(47,'2804950103891','Milos','Ninkovic','2015-04-08','Ulica, Banja Luka, 4'),(51,'1312981163309','Mirko','Filipovic','1981-12-13','Ulica, Banja Luka, 35');
/*!40000 ALTER TABLE `osoba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaspitac`
--

DROP TABLE IF EXISTS `vaspitac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaspitac` (
  `OSOBA_IdOsobe` int NOT NULL,
  `Plata` int NOT NULL,
  `KorisnickoIme` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Lozinka` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `boja` int NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_VASPITAC_OSOBA1` FOREIGN KEY (`OSOBA_IdOsobe`) REFERENCES `osoba` (`IdOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaspitac`
--

LOCK TABLES `vaspitac` WRITE;
/*!40000 ALTER TABLE `vaspitac` DISABLE KEYS */;
INSERT INTO `vaspitac` VALUES (5,1300,'jovana','jovana',0),(7,1400,'marija','marija',0),(8,1200,'zorana','zoric',0),(9,1350,'marijana','marijana',0),(10,1500,'zoran','zoran',0),(13,1400,'Ana','AN678912',0),(15,1200,'Ana','AM126116',0),(17,1202,'Danijel','DS100027',0),(18,1203,'Mirjana','MG105027',0),(19,1204,'Nikola','NM100005',0),(20,1205,'Stanko','SS100067',0),(21,1206,'Dejan','DB101124',0),(22,1207,'Marko','MM101234',0),(23,1208,'Petar','PJ100018',0),(45,1210,'Jelena','JV125037',0),(46,1250,'Marko','MM890124',0),(51,1209,'Mirko','MF163309',0);
/*!40000 ALTER TABLE `vaspitac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaspitac_has_grupa`
--

DROP TABLE IF EXISTS `vaspitac_has_grupa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaspitac_has_grupa` (
  `VASPITAC_OSOBA_IdOsobe` int NOT NULL,
  `GRUPA_IdGrupe` int NOT NULL,
  PRIMARY KEY (`VASPITAC_OSOBA_IdOsobe`,`GRUPA_IdGrupe`),
  KEY `fk_VASPITAC_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe`),
  KEY `fk_VASPITAC_has_GRUPA_VASPITAC1_idx` (`VASPITAC_OSOBA_IdOsobe`),
  CONSTRAINT `fk_VASPITAC_has_GRUPA_GRUPA1` FOREIGN KEY (`GRUPA_IdGrupe`) REFERENCES `grupa` (`IdGrupe`),
  CONSTRAINT `fk_VASPITAC_has_GRUPA_VASPITAC1` FOREIGN KEY (`VASPITAC_OSOBA_IdOsobe`) REFERENCES `vaspitac` (`OSOBA_IdOsobe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaspitac_has_grupa`
--

LOCK TABLES `vaspitac_has_grupa` WRITE;
/*!40000 ALTER TABLE `vaspitac_has_grupa` DISABLE KEYS */;
INSERT INTO `vaspitac_has_grupa` VALUES (5,1),(7,1),(8,1),(9,1),(23,1),(46,1),(5,2),(20,2),(46,2),(46,3),(7,4),(8,4),(45,4);
/*!40000 ALTER TABLE `vaspitac_has_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vrijeme_dolaska_i_odlaska`
--

DROP TABLE IF EXISTS `vrijeme_dolaska_i_odlaska`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vrijeme_dolaska_i_odlaska` (
  `IdVremenaDolaskaIOdlaska` int NOT NULL AUTO_INCREMENT,
  `DIJETE_OSOBA_IdOsobe` int NOT NULL,
  `EvidentiranoVrijeme` datetime NOT NULL,
  `Tip` tinyint NOT NULL,
  PRIMARY KEY (`IdVremenaDolaskaIOdlaska`),
  KEY `fk_VRIJEME_DOLASKA_I_ODLASKA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe`),
  CONSTRAINT `fk_VRIJEME_DOLASKA_I_ODLASKA_DIJETE1` FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`) REFERENCES `dijete` (`OSOBA_IdOsobe`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vrijeme_dolaska_i_odlaska`
--

LOCK TABLES `vrijeme_dolaska_i_odlaska` WRITE;
/*!40000 ALTER TABLE `vrijeme_dolaska_i_odlaska` DISABLE KEYS */;
INSERT INTO `vrijeme_dolaska_i_odlaska` VALUES (1,2,'2022-12-02 14:13:25',0),(2,2,'2022-12-02 14:13:30',1),(3,2,'2022-12-02 23:31:50',0),(4,2,'2022-12-02 23:39:02',1),(7,31,'2022-12-04 19:55:01',0),(8,31,'2022-12-04 19:55:09',1),(9,2,'2022-12-04 19:57:31',0),(10,2,'2022-12-04 19:58:12',1),(13,27,'2022-12-08 21:26:57',0),(14,27,'2022-12-08 21:27:00',1),(15,2,'2022-12-03 12:00:00',0),(16,2,'2022-12-03 17:00:00',1),(17,2,'2022-11-30 10:00:12',0),(18,2,'2022-11-30 17:30:45',1),(19,47,'2022-12-13 15:58:42',0),(20,47,'2022-12-13 15:59:01',1);
/*!40000 ALTER TABLE `vrijeme_dolaska_i_odlaska` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-13 16:36:25
