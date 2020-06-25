-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: studmysql01.fhict.local
-- Generation Time: Jun 25, 2020 at 04:12 PM
-- Server version: 5.7.26-log
-- PHP Version: 7.3.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbi437493`
--
CREATE DATABASE IF NOT EXISTS `dbi437493` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `dbi437493`;

-- --------------------------------------------------------

--
-- Table structure for table `available_emp_shifts`
--

CREATE TABLE `available_emp_shifts` (
  `Id` int(11) NOT NULL,
  `Available_Date` date NOT NULL,
  `StartTime` time NOT NULL,
  `EndTime` time NOT NULL,
  `PersonID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `available_emp_shifts`
--

INSERT INTO `available_emp_shifts` (`Id`, `Available_Date`, `StartTime`, `EndTime`, `PersonID`) VALUES
(1, '2020-06-08', '00:00:00', '00:00:00', 20),
(2, '2020-06-10', '00:00:00', '00:00:00', 20),
(3, '2020-06-12', '00:00:00', '00:00:00', 20),
(4, '2020-06-09', '00:00:00', '00:00:00', 14),
(5, '2020-06-11', '00:00:00', '00:00:00', 14),
(6, '2020-06-15', '00:00:00', '00:00:00', 20),
(7, '2020-06-13', '00:00:00', '00:00:00', 20),
(8, '2020-06-16', '00:00:00', '00:00:00', 20),
(9, '2020-06-17', '00:00:00', '00:00:00', 20),
(10, '2020-06-18', '00:00:00', '00:00:00', 20),
(11, '2020-06-22', '17:00:00', '21:00:00', 20),
(12, '2020-06-23', '08:00:00', '11:00:00', 20),
(13, '2020-06-25', '17:00:00', '21:00:00', 20),
(14, '2020-07-02', '17:00:00', '21:00:00', 20),
(19, '2020-07-01', '08:00:00', '11:00:00', 42);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Id`, `Name`, `Description`) VALUES
(1, 'Hardware', 'A hardware store traditionally sells household hardware such as fasteners, keys, locks, hinges, wire, chains, plumbing supplies, tools, cutlery and machine parts.'),
(2, 'Outdoor', 'Gear from top brands for all of your outdoor adventures. Find the right clothing and product for camping & hiking, cycling, skates, skateboards & scooters, water sports and winter sports.'),
(3, 'Sports', 'To enjoy your favourite sports, exercises, outdoor and indoor activities, you need to have the right kind of equipment. At Media Bazaar we offer you a range of sports and fitness equipment, indoor and outdoor accessories.'),
(4, 'Automotive', 'The automotive industry comprises a wide range of companies and organizations involved in the design, development, manufacturing, marketing, and selling of motor vehicles.[1] It is one of the world\'s largest economic sectors by revenue.'),
(5, 'Games & Consoles', 'Gaming refers to playing electronic games, whether through consoles, computers, mobile phones or another medium altogether. Gaming is a nuanced term that suggests regular gameplay, possibly as a hobby.'),
(6, 'Beauty & Health', 'Kantoor & School'),
(7, 'edddd', 'Kantoor & School');

-- --------------------------------------------------------

--
-- Table structure for table `contract`
--

CREATE TABLE `contract` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contract`
--

INSERT INTO `contract` (`Id`, `Name`) VALUES
(1, 'FullTime'),
(2, 'PartTime');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `OrganizationID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`Id`, `Name`, `OrganizationID`) VALUES
(1, 'Hardware', 1),
(2, 'Marketing', 1);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `Id` int(11) NOT NULL,
  `UnitsInStock` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`Id`, `UnitsInStock`, `ProductID`) VALUES
(1, 1977, 1),
(2, 810, 2),
(3, 150, 3),
(4, 110, 4),
(5, 175, 5),
(6, 75, 6),
(7, 800, 7),
(8, 300, 8),
(9, 250, 9),
(10, 3250, 10),
(11, 500, 11),
(12, 200, 12),
(13, 0, 13),
(14, 0, 14),
(15, 0, 15),
(16, 500, 16),
(17, 500, 17);

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `Id` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `OrderDate` date NOT NULL,
  `DepartmentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`Id`, `UserID`, `OrderDate`, `DepartmentID`) VALUES
(1, 1, '2020-04-21', 1),
(2, 1, '2020-04-17', 1),
(15, 1, '2020-04-28', 2),
(16, 1, '2020-04-22', 2),
(17, 1, '2020-04-22', 1),
(18, 1, '2020-04-04', 1),
(19, 1, '2020-04-25', 2),
(20, 1, '2020-04-01', 1),
(21, 1, '2020-04-30', 1),
(22, 1, '2020-04-14', 1),
(23, 1, '2020-04-08', 1),
(24, 1, '2020-04-11', 2),
(25, 1, '2020-04-25', 2),
(26, 1, '2020-04-25', 1),
(27, 1, '2020-04-25', 2),
(28, 1, '2020-04-25', 2),
(29, 1, '2020-04-25', 2),
(30, 1, '2020-04-25', 2),
(31, 1, '2020-05-05', 1),
(32, 1, '2020-05-05', 1),
(33, 1, '2020-05-12', 1),
(34, 1, '2020-05-13', 2),
(35, 1, '2020-05-13', 1),
(36, 1, '2020-05-13', 1),
(37, 1, '2020-05-14', 1),
(38, 1, '2020-05-14', 1),
(39, 1, '2020-05-14', 1),
(40, 1, '2020-05-14', 1),
(41, 1, '2020-06-01', 2),
(42, 1, '2020-06-01', 1),
(44, 1, '2020-06-01', 1),
(45, 1, '2020-06-01', 1),
(46, 1, '2020-06-01', 1),
(47, 1, '2020-06-01', 2),
(48, 1, '2020-06-01', 2),
(49, 1, '2020-06-01', 2),
(50, 1, '2020-06-25', 2),
(51, 1, '2020-06-25', 1);

-- --------------------------------------------------------

--
-- Table structure for table `organization`
--

CREATE TABLE `organization` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `organization`
--

INSERT INTO `organization` (`Id`, `Name`) VALUES
(1, 'MediaBazaar');

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `Id` int(11) NOT NULL,
  `Firstname` varchar(100) DEFAULT NULL,
  `Lastname` varchar(100) DEFAULT NULL,
  `Age` date DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `Salary` decimal(15,4) DEFAULT NULL,
  `HoursWorked` int(11) DEFAULT NULL,
  `HoursAvailable` int(11) DEFAULT NULL,
  `IsAvailable` varchar(50) DEFAULT NULL,
  `Passcode` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `DepartmentID` int(11) DEFAULT NULL,
  `ContractID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`Id`, `Firstname`, `Lastname`, `Age`, `Address`, `Email`, `Password`, `Salary`, `HoursWorked`, `HoursAvailable`, `IsAvailable`, `Passcode`, `RoleID`, `DepartmentID`, `ContractID`) VALUES
(1, 'Louis', 'Dutch', '1995-10-11', 'Tilburg', 'media_bazaar_nl@hotmail.com', 'mld6THoihsZRpBJDRdZfDw==', '1800.0000', 15, 40, 'Yes', 1234, 3, 2, 2),
(2, 'Daniel', 'Krakovsky', '1995-10-11', 'Tilburg', 'd.krak@gmail.com', 'x9tpXXCquY+42rr6eD3k5Q==', '3000.0000', 15, 20, 'Yes', NULL, 2, 1, 1),
(3, 'Draco', 'Malfoy', '1995-10-11', 'd.malf@gmail.com', 'd.malf@gmail.com', 'VZEQ1QmlCGqgWbgssW3+IQ==', '3200.0000', 15, 31, 'Yes', NULL, 2, 1, 1),
(4, 'Li', 'Chen', '1995-10-11', 'Helmond', 'li.chen@gmail.com', 'x9tpXXCquY+42rr6eD3k5Q==', '6500.0000', 15, 23, 'Yes', NULL, 1, 1, 1),
(5, 'Frank', 'van Philips', '1995-10-11', 'Amsterdam', 'f.philip@gmail.com', 'mz5hJYh+f9IimmpcM5JTqw==', '5000.0000', 15, 40, 'Yes', NULL, 2, 1, 2),
(6, 'Danail', 'Crocus', '1995-10-11', 'Eindhoven', 'd.croc@gmail.com', 'mz5hJYh+f9IimmpcM5JTqw==', '2300.0000', 15, 20, 'Yes', NULL, 2, 1, 2),
(7, 'Dev', 'Jose', '1998-11-18', 'Schijndel', 'jdev@gmail.com', 'GRfWEccVuGn0Jg3Akok+Gw==', '30000.0000', 34, 10, 'Yes', NULL, 1, 1, 1),
(8, 'Gabriel', 'Ramirez', '1995-10-11', 'Eindhoven', 'g.ram@gmail.com', 'E5ATaDI4stUsqni4V2COmA==', '2502.0000', 55, 20, 'Yes', NULL, 2, 1, 2),
(9, 'Louis', 'Kareem', '1975-10-11', 'Amsterdam Street', 'ceo@hotmail.com', 'mld6THoihsZRpBJDRdZfDw==', '6500.0000', 350, 25, 'Yes', NULL, 1, 2, 1),
(14, 'Shawn', 'Carter', '1995-10-11', 'Vlijmen', 'biggy@hotmail.com', 'mld6THoihsZRpBJDRdZfDw==', '450.0000', 22, 5, 'Yes', NULL, 2, 2, 2),
(20, 'Kobe', 'Bryant', '1995-10-11', 'Dordrecht', 'kobe@hotmail.com', 'mld6THoihsZRpBJDRdZfDw==', '5789.0000', 75, 40, 'Yes', NULL, 2, 2, 2),
(22, 'Foresty', 'Gumbs', '1995-10-11', 'Haarlem', 'gumbs@gmail.com', 'mld6THoihsZRpBJDRdZfDw==', '3400.0000', 0, 43, 'Yes', NULL, 2, 2, 2),
(30, 'Tom', 'Cruise', '1992-10-11', 'cruise@gmail.com', 'cruise@gmail.com', 'mld6THoihsZRpBJDRdZfDw==', '700.0000', 0, 15, 'Yes', NULL, 2, 2, 2),
(31, 'Will', 'Smith', '1995-10-11', 'Den Bosch', 'smith@gmail.com', 'mld6THoihsZRpBJDRdZfDw==', '6000.0000', 0, 35, 'Yes', NULL, 1, 2, 1),
(32, 'Jimmy', 'Kimmel', '1995-10-11', 'Arnhem', 'kimmel@gmail.com', 'mld6THoihsZRpBJDRdZfDw==', '690.0000', 0, 32, 'Yes', NULL, 2, 2, 2),
(33, 'Bronny', 'James', '1995-10-11', 'Bijlmer', 'lebron@gmail.com', 'E5ATaDI4stUsqni4V2COmA==', '1500.0000', 0, 25, 'Yes', NULL, 2, 2, 2),
(34, 'Shaq', 'Oneal', '1995-10-11', 'Vlissingen', 'shaq@gmail.com', 'E5ATaDI4stUsqni4V2COmA==', '2500.0000', 0, 25, 'Yes', NULL, 1, 2, 1),
(35, 'Holly', 'Brand', '1975-11-10', 'Den Haag', 'bond@gmail.com', 'E5ATaDI4stUsqni4V2COmA==', '1200.0000', 0, 11, 'Yes', NULL, 2, 2, 2),
(36, 'Kendrick', 'Lamar', '1975-11-10', 'Gelderland', 'kenny@hotmail.com', 'E5ATaDI4stUsqni4V2COmA==', '6500.0000', 0, 42, 'Yes', NULL, 1, 2, 1),
(37, 'Kanye', 'West', '1945-05-02', 'Den Hoorn', 'kanye@hotmail.com', 'mld6THoihsZRpBJDRdZfDw==', '2480.0000', 0, 32, 'Yes', NULL, 2, 2, 1),
(42, 'Emp', 'Jose', '1997-11-18', 'Eindhoven', 'jemp@gmail.com', 'GRfWEccVuGn0Jg3Akok+Gw==', '2000.0000', 0, 20, 'Yes', NULL, 2, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(10000) DEFAULT NULL,
  `Price` double(6,2) DEFAULT NULL,
  `CategoryID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Id`, `Name`, `Description`, `Price`, `CategoryID`) VALUES
(1, 'Powerplus POWESET1 Accuboormachine - 18V Li-ion', 'Deze 18V accuboormachine uit het One Fits All assortiment wordt geleverd in een handige koffer. In de koffer zitten naast 2 accu\'s en een oplader ook 9 boren, 43 bits, een bithouder en pluggen. ', 49.90, 1),
(2, 'Bosch PSB 1800 LI-2 Accu klopboormachine', 'Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui.', 279.00, 1),
(3, 'Makita DDF453SFE Accuboormachine - 18V Li-ion', 'Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum.', 295.00, 1),
(4, 'Bosch PBH 2100 RE Boorhamer - 550 Watt - 1.7 J', NULL, 119.00, 1),
(5, 'Powerplus POWX0069LI Accuboormachine - 18V Li-ion', NULL, 49.99, 1),
(6, 'Kärcher K 2 Home Hogedrukreiniger', NULL, 129.00, 2),
(7, 'GARDENA Classic snoeischaar', NULL, 14.99, 2),
(8, 'Ferm Elektrische Grasmaaier', NULL, 44.95, 2),
(9, 'Kärcher K 5 Premium Full Control Plus Hogedrukreiniger', NULL, 449.00, 2),
(10, 'Hyundai hogedrukreiniger / hogedrukspuit', NULL, 59.99, 2),
(11, 'Crosstrainer Focus Fitness Fox 3 - incl. hartslagfunctie', 'De Focus Fitness Fox 3 is de ideale crosstrainer voor de thuissporter. De Fox 3 is niet alleen stabiel en sterk maar ook nog eens geruisloos. De crosstrainer is zo ontworpen dat de voetpedalen in drie standen te verstellen zijn.', 465.00, 3),
(12, 'Avento Fitnessmat - 160 cm x 60 cm x 0,7 cm - Roze', 'De Avento Fitness Mat heeft de volgende eigenschappen: Deze Avento fitnessmat is een handige foam mat voor het doen van fitnessoefeningen op de sportschool of thuis. Curabitur ligula sapien, tincidunt non, euismod vitae, posuere imperdiet, leo. Maecenas malesuada.', 21.00, 3),
(13, 'Polar Vantage M - Hardloophorloge - GPS - Zwart - Medium/Large', 'Zo compleet en geavanceerd als de Polar Vantage M zie je ze niet vaak in deze prijscategorie. Dit alles-in-Ã©Ã©n multisportsporthorloge meet sportprestaties op geavanceerde wijze en heeft een ultra lange batterijduur van 30 uur in trainingsmodus.', 279.00, 3),
(14, 'Optimum nutrition GOLD STANDARD 100% WHEY PROTEIN - 908 gram - vanilla ice', 'Optimum Nutrition Gold Standard Whey Proteïne bevat Optimum Nutrition\'s exclusieve Whey Blend. Miljoenen en miljoenen klanten wereldwijd kunnen geen ongelijk hebben!', 29.00, 3),
(15, 'The Last of Us Part II: Day One Edition - PS4', 'Vijf jaar na een gevaarlijke reis door de post-pandemische Verenigde Staten wonen Ellie en Joel in Jackson, Wyoming. In een bloeiende gemeenschap van overlevenden leiden ze een leven vol vrede en stabiliteit, ondanks de constante bedreiging van geïnfecteerde mensen en andere, meer wanhopige overlevenden.', 69.99, 5),
(16, 'Cyberpunk 2077 - Day One Edition - PS4', 'Cyberpunk 2077 is action-adventure game die zich afspeelt in een open wereld genaamd Night City, een megalopolis geobsedeerd door kracht, glamour en lichaamsmodificaties. ', 59.99, 5),
(17, 'ssss', 'hi php', 48.90, 7);

-- --------------------------------------------------------

--
-- Table structure for table `product_order`
--

CREATE TABLE `product_order` (
  `Id` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TotalPrice` double(15,6) NOT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_order`
--

INSERT INTO `product_order` (`Id`, `Quantity`, `TotalPrice`, `ProductID`, `OrderID`) VALUES
(1, 5, 1000.000000, 4, 1),
(2, 10, 2000.000000, 2, 2),
(9, 500, 7495.000000, 7, 15),
(10, 200, 9980.000000, 1, 16),
(11, 100, 4990.000000, 1, 17),
(12, 100, 4990.000000, 1, 18),
(13, 200, 9998.000000, 5, 19),
(14, 300, 17997.000000, 10, 20),
(15, 200, 55800.000000, 2, 21),
(16, 100, 27900.000000, 2, 22),
(17, 100, 44900.000000, 9, 24),
(18, 100, 11900.000000, 4, 25),
(19, 100, 29500.000000, 3, 26),
(20, 300, 17997.000000, 10, 27),
(21, 300, 38700.000000, 6, 28),
(22, 100, 4990.000000, 1, 29),
(23, 300, 13485.000000, 8, 30),
(24, 200, 2998.000000, 7, 31),
(25, 100, 27900.000000, 2, 32),
(26, 100, 29500.000000, 3, 33),
(27, 100, 44900.000000, 9, 34),
(28, 100, 11900.000000, 4, 35),
(29, 100, 4999.000000, 5, 36),
(30, 100, 27900.000000, 2, 37),
(31, 200, 55800.000000, 2, 39),
(32, 500, 139500.000000, 2, 40),
(33, 500, 232500.000000, 11, 41),
(34, 100, 4990.000000, 1, 42),
(36, 100, 2100.000000, 12, 44),
(37, 100, 4990.000000, 1, 45),
(38, 100, 4990.000000, 1, 46),
(39, 100, 2100.000000, 12, 47),
(40, 100, 44900.000000, 9, 48),
(41, 100, 44900.000000, 9, 49),
(42, 500, 29995.000000, 16, 50),
(43, 500, 24450.000000, 17, 51);

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`Id`, `Name`) VALUES
(1, 'Manager'),
(2, 'Employee'),
(3, 'Stock Manager');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `Id` int(11) NOT NULL,
  `StartTime` time(6) DEFAULT NULL,
  `EndTime` time(6) DEFAULT NULL,
  `WorkDate` date DEFAULT NULL,
  `PersonID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`Id`, `StartTime`, `EndTime`, `WorkDate`, `PersonID`) VALUES
(1, '08:00:00.000000', '11:00:00.000000', '2020-03-03', 1),
(2, '08:00:00.000000', '11:00:00.000000', '2020-03-10', 2),
(3, '12:00:00.000000', '16:00:00.000000', '2020-03-03', 3),
(4, '12:00:00.000000', '16:00:00.000000', '2020-03-10', 4),
(5, '08:00:00.000000', '11:00:00.000000', '2020-03-17', 5),
(6, '08:00:00.000000', '11:00:00.000000', '2020-03-05', 6),
(7, '12:00:00.000000', '16:00:00.000000', '2020-03-12', 7),
(8, '08:00:00.000000', '11:00:00.000000', '2020-03-13', 9),
(9, '17:00:00.000000', '21:00:00.000000', '2020-03-16', 1),
(10, '12:00:00.000000', '16:00:00.000000', '2020-03-17', 1),
(11, '12:00:00.000000', '16:00:00.000000', '2020-03-20', 2),
(12, '08:00:00.000000', '11:00:00.000000', '2020-06-10', 20),
(13, '12:00:00.000000', '16:00:00.000000', '2020-03-18', 4),
(14, '08:00:00.000000', '11:00:00.000000', '2020-03-19', 5),
(15, '17:00:00.000000', '21:00:00.000000', '2020-03-19', 6),
(16, '17:00:00.000000', '21:00:00.000000', '2020-05-04', 7),
(17, '08:00:00.000000', '11:00:00.000000', '2020-03-19', 9),
(18, '17:00:00.000000', '21:00:00.000000', '2020-03-20', 1),
(19, '17:00:00.000000', '21:00:00.000000', '2020-03-18', 1),
(20, '10:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(21, '08:00:00.000000', '11:00:00.000000', '2020-06-13', 20),
(22, '12:00:00.000000', '16:00:00.000000', '2020-03-19', 4),
(23, '08:00:00.000000', '11:00:00.000000', '2020-03-18', 5),
(24, '08:00:00.000000', '11:00:00.000000', '2020-03-24', 6),
(25, '17:00:00.000000', '21:00:00.000000', '2020-04-14', 7),
(26, '12:00:00.000000', '16:00:00.000000', '2020-05-20', 9),
(27, '12:00:00.000000', '16:00:00.000000', '2020-03-21', 1),
(28, '12:00:00.000000', '16:00:00.000000', '2020-03-19', 1),
(29, '08:00:00.000000', '11:00:00.000000', '2020-06-30', 2),
(30, '12:00:00.000000', '16:00:00.000000', '2020-03-20', 3),
(31, '12:00:00.000000', '16:00:00.000000', '2020-03-20', 4),
(32, '08:00:00.000000', '11:00:00.000000', '2020-03-20', 5),
(33, '12:00:00.000000', '16:00:00.000000', '2020-03-20', 6),
(34, '17:00:00.000000', '21:00:00.000000', '2020-03-19', 7),
(35, '09:00:00.000000', '18:00:00.000000', '2020-03-27', 9),
(36, '12:00:00.000000', '16:00:00.000000', '2020-03-23', 1),
(37, '12:00:00.000000', '16:00:00.000000', '2020-03-18', 6),
(38, '08:00:00.000000', '11:00:00.000000', '2020-03-18', 7),
(39, '17:00:00.000000', '21:00:00.000000', '2020-03-09', 9),
(41, '17:00:00.000000', '21:00:00.000000', '2020-03-22', 20),
(42, '17:00:00.000000', '21:00:00.000000', '2020-06-09', 14),
(43, '17:00:00.000000', '21:00:00.000000', '2020-03-22', 14),
(44, '12:00:00.000000', '16:00:00.000000', '2020-05-06', 14),
(46, '12:00:00.000000', '16:00:00.000000', '2020-03-29', 22),
(50, '08:00:00.000000', '11:00:00.000000', '2020-03-28', 22),
(51, '17:00:00.000000', '21:00:00.000000', '2020-03-27', 22),
(52, '12:00:00.000000', '16:00:00.000000', '2020-03-26', 22),
(55, '08:00:00.000000', '11:00:00.000000', '2020-03-27', 30),
(56, '00:00:00.000000', '00:00:00.000000', '2020-03-27', 31),
(57, '12:00:00.000000', '16:00:00.000000', '2020-03-27', 32),
(58, '00:00:00.000000', '00:00:00.000000', '2020-05-19', 33),
(59, '00:00:00.000000', '00:00:00.000000', '2020-05-19', 34),
(60, '17:00:00.000000', '21:00:00.000000', '2020-05-19', 35),
(61, '00:00:00.000000', '00:00:00.000000', '2020-05-19', 36),
(62, '12:00:00.000000', '16:00:00.000000', '2020-06-25', 37),
(63, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 20),
(64, '17:00:00.000000', '21:00:00.000000', '2020-06-22', 20),
(65, '08:00:00.000000', '11:00:00.000000', '2020-06-23', 20),
(66, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 14),
(67, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 30),
(68, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 22),
(69, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 37),
(70, '08:00:00.000000', '11:00:00.000000', '2020-06-16', 35),
(71, '17:00:00.000000', '21:00:00.000000', '2020-06-25', 20),
(101, '08:00:00.000000', '11:00:00.000000', '2020-06-08', 20),
(102, '12:00:00.000000', '16:00:00.000000', '2020-06-12', 20),
(104, '12:00:00.000000', '16:00:00.000000', '2020-06-18', 20),
(106, '12:00:00.000000', '16:00:00.000000', '2020-06-11', 14),
(107, '08:00:00.000000', '11:00:00.000000', '2020-06-25', 22),
(108, '08:00:00.000000', '11:00:00.000000', '2020-06-28', 33),
(109, '09:00:00.000000', '11:00:00.000000', '2020-06-24', 3),
(110, '09:00:00.000000', '10:00:00.000000', '2020-06-24', 4),
(111, '17:00:00.000000', '21:00:00.000000', '2020-06-30', 33),
(113, '08:00:00.000000', '14:00:00.000000', '2020-06-26', 4),
(116, '08:00:00.000000', '12:00:00.000000', '2020-06-26', 2),
(117, '08:00:00.000000', '23:00:00.000000', '2020-06-28', 3),
(120, '08:00:00.000000', '15:00:00.000000', '2020-06-30', 5),
(121, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(122, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(123, '08:00:00.000000', '11:00:00.000000', '2020-06-29', 35),
(124, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(125, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(126, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(127, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(128, '09:00:00.000000', '11:00:00.000000', '2020-06-27', 3),
(130, '08:00:00.000000', '11:00:00.000000', '2020-06-26', 2),
(131, '08:00:00.000000', '14:00:00.000000', '2020-06-25', 2),
(132, '00:00:00.000000', '00:00:00.000000', '2020-06-25', 42);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `available_emp_shifts`
--
ALTER TABLE `available_emp_shifts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_User_AvailableShifts` (`PersonID`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Department_Organization` (`OrganizationID`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `FK_Inventory_Product` (`ProductID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Order_Department` (`DepartmentID`),
  ADD KEY `FK_Order_Person` (`UserID`);

--
-- Indexes for table `organization`
--
ALTER TABLE `organization`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_User_Role` (`RoleID`),
  ADD KEY `FK_User_Department` (`DepartmentID`),
  ADD KEY `FK_User_Contract` (`ContractID`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Product_Category` (`CategoryID`);

--
-- Indexes for table `product_order`
--
ALTER TABLE `product_order`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_ProductOrder_Order` (`OrderID`),
  ADD KEY `FK_ProductOrder_Product` (`ProductID`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_Schedule_User` (`PersonID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `available_emp_shifts`
--
ALTER TABLE `available_emp_shifts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `contract`
--
ALTER TABLE `contract`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `organization`
--
ALTER TABLE `organization`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `product_order`
--
ALTER TABLE `product_order`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `schedule`
--
ALTER TABLE `schedule`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=133;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `available_emp_shifts`
--
ALTER TABLE `available_emp_shifts`
  ADD CONSTRAINT `FK_User_AvailableShifts` FOREIGN KEY (`PersonID`) REFERENCES `person` (`Id`);

--
-- Constraints for table `department`
--
ALTER TABLE `department`
  ADD CONSTRAINT `FK_Department_Organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organization` (`Id`);

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `FK_Inventory_Product` FOREIGN KEY (`ProductID`) REFERENCES `product` (`Id`);

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `FK_Order_Department	` FOREIGN KEY (`DepartmentID`) REFERENCES `department` (`Id`),
  ADD CONSTRAINT `FK_Order_Person` FOREIGN KEY (`UserID`) REFERENCES `person` (`Id`);

--
-- Constraints for table `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `FK_User_Contract` FOREIGN KEY (`ContractID`) REFERENCES `contract` (`Id`),
  ADD CONSTRAINT `FK_User_Department` FOREIGN KEY (`DepartmentID`) REFERENCES `department` (`Id`),
  ADD CONSTRAINT `FK_User_Role` FOREIGN KEY (`RoleID`) REFERENCES `role` (`Id`);

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `FK_Product_Category	` FOREIGN KEY (`CategoryID`) REFERENCES `category` (`Id`);

--
-- Constraints for table `product_order`
--
ALTER TABLE `product_order`
  ADD CONSTRAINT `FK_ProductOrder_Order` FOREIGN KEY (`OrderID`) REFERENCES `order` (`Id`),
  ADD CONSTRAINT `FK_ProductOrder_Product` FOREIGN KEY (`ProductID`) REFERENCES `product` (`Id`);

--
-- Constraints for table `schedule`
--
ALTER TABLE `schedule`
  ADD CONSTRAINT `FK_Schedule_User` FOREIGN KEY (`PersonID`) REFERENCES `person` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
