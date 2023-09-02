-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema projektni_hci
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema projektni_hci
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `projektni_hci` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `projektni_hci` ;

-- -----------------------------------------------------
-- Table `projektni_hci`.`OSOBA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`OSOBA` (
  `IdOsobe` INT NOT NULL AUTO_INCREMENT,
  `JMB` CHAR(13) NOT NULL,
  `Ime` VARCHAR(50) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `DatumRodjenja` DATE NOT NULL,
  `Adresa` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`IdOsobe`),
  UNIQUE INDEX `JMB_UNIQUE` (`JMB` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`VASPITAC`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`VASPITAC` (
  `OSOBA_IdOsobe` INT NOT NULL,
  `Plata` INT NOT NULL,
  `KorisnickoIme` VARCHAR(45) NOT NULL,
  `Lozinka` VARCHAR(45) NOT NULL,
  `boja` INT NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_VASPITAC_OSOBA1`
    FOREIGN KEY (`OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`OSOBA` (`IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`ADMINISTRATOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`ADMINISTRATOR` (
  `OSOBA_IdOsobe` INT NOT NULL,
  `KorisnickoIme` VARCHAR(45) NOT NULL,
  `Lozinka` VARCHAR(45) NOT NULL,
  `boja` INT NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  CONSTRAINT `fk_ADMINISTRATOR_OSOBA1`
    FOREIGN KEY (`OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`OSOBA` (`IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`DIJETE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`DIJETE` (
  `OSOBA_IdOsobe` INT NOT NULL,
  `Visina` INT NOT NULL,
  `Tezina` INT NOT NULL,
  PRIMARY KEY (`OSOBA_IdOsobe`),
  INDEX `fk_DIJETE_OSOBA_idx` (`OSOBA_IdOsobe` ASC) VISIBLE,
  CONSTRAINT `fk_DIJETE_OSOBA`
    FOREIGN KEY (`OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`OSOBA` (`IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`GRUPA` (
  `IdGrupe` INT NOT NULL AUTO_INCREMENT,
  `NazivGrupe` VARCHAR(50) NOT NULL,
  `BrojClanova` INT NOT NULL,
  PRIMARY KEY (`IdGrupe`),
  UNIQUE INDEX `NazivGrupe_UNIQUE` (`NazivGrupe` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`VRIJEME_DOLASKA_I_ODLASKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`VRIJEME_DOLASKA_I_ODLASKA` (
  `IdVremenaDolaskaIOdlaska` INT NOT NULL AUTO_INCREMENT,
  `DIJETE_OSOBA_IdOsobe` INT NOT NULL,
  `EvidentiranoVrijeme` DATETIME NOT NULL,
  `Tip` TINYINT NOT NULL,
  PRIMARY KEY (`IdVremenaDolaskaIOdlaska`),
  INDEX `fk_VRIJEME_DOLASKA_I_ODLASKA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe` ASC) VISIBLE,
  CONSTRAINT `fk_VRIJEME_DOLASKA_I_ODLASKA_DIJETE1`
    FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`DIJETE` (`OSOBA_IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`DIJETE_has_GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`DIJETE_has_GRUPA` (
  `DIJETE_OSOBA_IdOsobe` INT NOT NULL,
  `GRUPA_IdGrupe` INT NOT NULL,
  PRIMARY KEY (`DIJETE_OSOBA_IdOsobe`),
  INDEX `fk_DIJETE_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe` ASC) VISIBLE,
  INDEX `fk_DIJETE_has_GRUPA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe` ASC) VISIBLE,
  CONSTRAINT `fk_DIJETE_has_GRUPA_DIJETE1`
    FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`DIJETE` (`OSOBA_IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DIJETE_has_GRUPA_GRUPA1`
    FOREIGN KEY (`GRUPA_IdGrupe`)
    REFERENCES `projektni_hci`.`GRUPA` (`IdGrupe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`VASPITAC_has_GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`VASPITAC_has_GRUPA` (
  `VASPITAC_OSOBA_IdOsobe` INT NOT NULL,
  `GRUPA_IdGrupe` INT NOT NULL,
  PRIMARY KEY (`VASPITAC_OSOBA_IdOsobe`, `GRUPA_IdGrupe`),
  INDEX `fk_VASPITAC_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe` ASC) VISIBLE,
  INDEX `fk_VASPITAC_has_GRUPA_VASPITAC1_idx` (`VASPITAC_OSOBA_IdOsobe` ASC) VISIBLE,
  CONSTRAINT `fk_VASPITAC_has_GRUPA_VASPITAC1`
    FOREIGN KEY (`VASPITAC_OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`VASPITAC` (`OSOBA_IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VASPITAC_has_GRUPA_GRUPA1`
    FOREIGN KEY (`GRUPA_IdGrupe`)
    REFERENCES `projektni_hci`.`GRUPA` (`IdGrupe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`AKTIVNOST`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`AKTIVNOST` (
  `IdAktivnosti` INT NOT NULL AUTO_INCREMENT,
  `NazivAktivnosti` VARCHAR(45) NOT NULL,
  `OpisAktivnosti` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`IdAktivnosti`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`AKTIVNOST_has_GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`AKTIVNOST_has_GRUPA` (
  `AKTIVNOST_IdAktivnosti` INT NOT NULL,
  `GRUPA_IdGrupe` INT NOT NULL,
  `DatumAktivnosti` DATE NOT NULL,
  `PeriodAktivnosti` INT NOT NULL,
  PRIMARY KEY (`GRUPA_IdGrupe`, `DatumAktivnosti`, `AKTIVNOST_IdAktivnosti`),
  INDEX `fk_AKTIVNOST_has_GRUPA_GRUPA1_idx` (`GRUPA_IdGrupe` ASC) VISIBLE,
  INDEX `fk_AKTIVNOST_has_GRUPA_AKTIVNOST1_idx` (`AKTIVNOST_IdAktivnosti` ASC) VISIBLE,
  CONSTRAINT `fk_AKTIVNOST_has_GRUPA_AKTIVNOST1`
    FOREIGN KEY (`AKTIVNOST_IdAktivnosti`)
    REFERENCES `projektni_hci`.`AKTIVNOST` (`IdAktivnosti`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AKTIVNOST_has_GRUPA_GRUPA1`
    FOREIGN KEY (`GRUPA_IdGrupe`)
    REFERENCES `projektni_hci`.`GRUPA` (`IdGrupe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `projektni_hci`.`CLANARINA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `projektni_hci`.`CLANARINA` (
  `IdClanarine` INT NOT NULL AUTO_INCREMENT,
  `TipUsluge` VARCHAR(100) NOT NULL,
  `Iznos` INT NOT NULL,
  `Placeno` TINYINT NULL,
  `Datum` DATE NOT NULL,
  `DIJETE_OSOBA_IdOsobe` INT NOT NULL,
  `DatumPlacanja` DATE NULL,
  PRIMARY KEY (`IdClanarine`),
  INDEX `fk_CLANARINA_DIJETE1_idx` (`DIJETE_OSOBA_IdOsobe` ASC) VISIBLE,
  CONSTRAINT `fk_CLANARINA_DIJETE1`
    FOREIGN KEY (`DIJETE_OSOBA_IdOsobe`)
    REFERENCES `projektni_hci`.`DIJETE` (`OSOBA_IdOsobe`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
