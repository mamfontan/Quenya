-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 11-12-2020 a las 11:22:18
-- Versión del servidor: 5.6.35
-- Versión de PHP: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `quenya`
--
CREATE DATABASE IF NOT EXISTS `quenya` DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci;
USE `quenya`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `daily`
--

DROP TABLE IF EXISTS `daily`;
CREATE TABLE IF NOT EXISTS `daily` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `date` timestamp(6) NOT NULL,
  `max` float NOT NULL DEFAULT '0',
  `min` float NOT NULL DEFAULT '0',
  `open` float NOT NULL DEFAULT '0',
  `close` float NOT NULL DEFAULT '0',
  `volume` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`code`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `overview`
--

DROP TABLE IF EXISTS `overview`;
CREATE TABLE IF NOT EXISTS `overview` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `assettype` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `name` varchar(150) COLLATE utf8_spanish_ci DEFAULT NULL,
  `description` varchar(5000) COLLATE utf8_spanish_ci DEFAULT NULL,
  `exchange` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `currency` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `country` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `sector` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `industry` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  `address` varchar(250) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fulltimeemployees` varchar(25) COLLATE utf8_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `price01m`
--

DROP TABLE IF EXISTS `price01m`;
CREATE TABLE IF NOT EXISTS `price01m` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `date` timestamp(6) NOT NULL,
  `max` float NOT NULL DEFAULT '0',
  `min` float NOT NULL DEFAULT '0',
  `open` float NOT NULL DEFAULT '0',
  `close` float NOT NULL DEFAULT '0',
  `volume` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`code`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `price05m`
--

DROP TABLE IF EXISTS `price05m`;
CREATE TABLE IF NOT EXISTS `price05m` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `date` timestamp(6) NOT NULL,
  `max` float NOT NULL DEFAULT '0',
  `min` float NOT NULL DEFAULT '0',
  `open` float NOT NULL DEFAULT '0',
  `close` float NOT NULL DEFAULT '0',
  `volume` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`code`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `price15m`
--

DROP TABLE IF EXISTS `price15m`;
CREATE TABLE IF NOT EXISTS `price15m` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `date` timestamp(6) NOT NULL,
  `max` float NOT NULL DEFAULT '0',
  `min` float NOT NULL DEFAULT '0',
  `open` float NOT NULL DEFAULT '0',
  `close` float NOT NULL DEFAULT '0',
  `volume` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`code`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `price60m`
--

DROP TABLE IF EXISTS `price60m`;
CREATE TABLE IF NOT EXISTS `price60m` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `date` timestamp(6) NOT NULL,
  `max` float NOT NULL DEFAULT '0',
  `min` float NOT NULL DEFAULT '0',
  `open` float NOT NULL DEFAULT '0',
  `close` float NOT NULL DEFAULT '0',
  `volume` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`code`,`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `stocks`
--

DROP TABLE IF EXISTS `stocks`;
CREATE TABLE IF NOT EXISTS `stocks` (
  `code` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `name` varchar(75) COLLATE utf8_spanish_ci NOT NULL,
  `country` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `currency` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
