-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mer 11 Novembre 2015 à 00:14
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET FOREIGN_KEY_CHECKS=0;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `ckaeyah101694fr24274_mariage`
--
CREATE DATABASE IF NOT EXISTS `ckaeyah101694fr24274_mariage` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `ckaeyah101694fr24274_mariage`;

-- --------------------------------------------------------

--
-- Structure de la table `etape`
--

DROP TABLE IF EXISTS `etape`;
CREATE TABLE IF NOT EXISTS `etape` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(50) NOT NULL,
  `description` text,
  `debut` datetime NOT NULL,
  `fin` datetime DEFAULT NULL,
  `idEtapePrecedente` int(11) DEFAULT NULL,
  `idLieu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `titre` (`titre`),
  KEY `idEtapePrecedente` (`idEtapePrecedente`,`idLieu`),
  KEY `idLieu` (`idLieu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Vider la table avant d'insérer `etape`
--

TRUNCATE TABLE `etape`;
-- --------------------------------------------------------

--
-- Structure de la table `hebergement`
--

DROP TABLE IF EXISTS `hebergement`;
CREATE TABLE IF NOT EXISTS `hebergement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(50) NOT NULL,
  `description` text,
  `idLieu` int(11) NOT NULL,
  `prix` int(11) NOT NULL,
  `estOffert` tinyint(4) NOT NULL,
  `debutOffert` date DEFAULT NULL,
  `finOffert` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `titre` (`titre`),
  KEY `idLieu` (`idLieu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Vider la table avant d'insérer `hebergement`
--

TRUNCATE TABLE `hebergement`;
-- --------------------------------------------------------

--
-- Structure de la table `lieu`
--

DROP TABLE IF EXISTS `lieu`;
CREATE TABLE IF NOT EXISTS `lieu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titre` varchar(50) NOT NULL,
  `description` text,
  `coordonneesMaps` text,
  `rue` text NOT NULL,
  `code postal` char(5) NOT NULL,
  `ville` varchar(50) NOT NULL,
  `pays` varchar(50) NOT NULL,
  `telephone` char(10) DEFAULT NULL,
  `urlPhoto` text,
  `siteWeb` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `titre` (`titre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Vider la table avant d'insérer `lieu`
--

TRUNCATE TABLE `lieu`;
-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

DROP TABLE IF EXISTS `personne`;
CREATE TABLE IF NOT EXISTS `personne` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `idConjoint` int(11) DEFAULT NULL,
  `genre` char(1) NOT NULL,
  `idParent` int(11) DEFAULT NULL,
  `validation` tinyint(4) NOT NULL DEFAULT '0',
  `urlPhoto` text,
  `email` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Vider la table avant d'insérer `personne`
--

TRUNCATE TABLE `personne`;
--
-- Contenu de la table `personne`
--

INSERT INTO `personne` (`id`, `nom`, `prenom`, `idConjoint`, `genre`, `idParent`, `validation`, `urlPhoto`, `email`) VALUES
(1, 'COULOMBEL', 'Mickaël', 0, 'M', NULL, 0, NULL, 'mickael.coulombel@gmail.com');

-- --------------------------------------------------------

--
-- Structure de la table `personnes_etapes`
--

DROP TABLE IF EXISTS `personnes_etapes`;
CREATE TABLE IF NOT EXISTS `personnes_etapes` (
  `idPersonne` int(11) NOT NULL,
  `idEtape` int(11) NOT NULL,
  `fonction` varchar(50) NOT NULL,
  PRIMARY KEY (`idPersonne`,`idEtape`),
  KEY `fk_etapes_etape` (`idEtape`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Vider la table avant d'insérer `personnes_etapes`
--

TRUNCATE TABLE `personnes_etapes`;
-- --------------------------------------------------------

--
-- Structure de la table `personnes_hebergements`
--

DROP TABLE IF EXISTS `personnes_hebergements`;
CREATE TABLE IF NOT EXISTS `personnes_hebergements` (
  `idPersonne` int(11) NOT NULL,
  `idHebergement` int(11) NOT NULL,
  `debut` date NOT NULL,
  `fin` date NOT NULL,
  `numeroReservation` varchar(50) NOT NULL,
  PRIMARY KEY (`idPersonne`,`idHebergement`),
  KEY `FK_HEBERGEMENTS_HEBERGEMENT` (`idHebergement`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Vider la table avant d'insérer `personnes_hebergements`
--

TRUNCATE TABLE `personnes_hebergements`;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `etape`
--
ALTER TABLE `etape`
  ADD CONSTRAINT `fk_etape_etape_precedente` FOREIGN KEY (`idEtapePrecedente`) REFERENCES `etape` (`id`),
  ADD CONSTRAINT `fk_etape_lieu` FOREIGN KEY (`idLieu`) REFERENCES `lieu` (`id`);

--
-- Contraintes pour la table `hebergement`
--
ALTER TABLE `hebergement`
  ADD CONSTRAINT `FK_HEBERGEMENT_LIEU` FOREIGN KEY (`idLieu`) REFERENCES `lieu` (`id`);

--
-- Contraintes pour la table `personnes_etapes`
--
ALTER TABLE `personnes_etapes`
  ADD CONSTRAINT `fk_etapes_etape` FOREIGN KEY (`idEtape`) REFERENCES `etape` (`id`),
  ADD CONSTRAINT `fk_personnes_personne` FOREIGN KEY (`idPersonne`) REFERENCES `personne` (`id`);

--
-- Contraintes pour la table `personnes_hebergements`
--
ALTER TABLE `personnes_hebergements`
  ADD CONSTRAINT `FK_HEBERGEMENTS_HEBERGEMENT` FOREIGN KEY (`idHebergement`) REFERENCES `hebergement` (`id`),
  ADD CONSTRAINT `FK_PERSONNES_PERSONNE_ID` FOREIGN KEY (`idPersonne`) REFERENCES `personne` (`id`);
SET FOREIGN_KEY_CHECKS=1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
