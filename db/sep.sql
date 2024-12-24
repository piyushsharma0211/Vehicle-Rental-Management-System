CREATE DATABASE  IF NOT EXISTS `sep` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sep`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: sep
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `car_tbl`
--

DROP TABLE IF EXISTS `car_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `car_tbl` (
  `cid` int NOT NULL AUTO_INCREMENT,
  `regno` varchar(50) NOT NULL,
  `brand` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `price` int NOT NULL,
  `color` varchar(50) NOT NULL,
  `available` varchar(10) NOT NULL,
  `type` varchar(10) NOT NULL,
  PRIMARY KEY (`regno`),
  UNIQUE KEY `cid` (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=123 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car_tbl`
--

LOCK TABLES `car_tbl` WRITE;
/*!40000 ALTER TABLE `car_tbl` DISABLE KEYS */;
INSERT INTO `car_tbl` VALUES (120,'AF23GH2345','Maruti Suzuki','Alto',900,'white','No','HatchBack'),(122,'BR24SS0001','Tata','Sumo',900,'white','No','SUV'),(111,'BR29SA0007','Hyundai','Verna',4000,'white','No','Sedan'),(114,'KA51KK8959','Tata','Altroz',800,'White','No','HatchBack'),(115,'KL04DM8976','Maruti Suzuki','Alto',700,'Grey','No','HatchBack'),(110,'MP66AS0901','Mahindra','XUV 500',1200,'Grey','No','SUV'),(112,'MP66AS6265','Maruti Suzuki','Baleno',850,'white','Yes','HatchBack'),(113,'MP66BU6326','Hyundai','Creata',1200,'Blue','No','SUV'),(116,'MP67AM5678','Mahindra','Scorpio',1500,'Black','Yes','SUV');
/*!40000 ALTER TABLE `car_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rent_tbl`
--

DROP TABLE IF EXISTS `rent_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rent_tbl` (
  `rid` int NOT NULL AUTO_INCREMENT,
  `carReg` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `custname` varchar(50) NOT NULL,
  `rentDate` date NOT NULL,
  `returnDate` date NOT NULL,
  `fees` int NOT NULL,
  PRIMARY KEY (`rid`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rent_tbl`
--

LOCK TABLES `rent_tbl` WRITE;
/*!40000 ALTER TABLE `rent_tbl` DISABLE KEYS */;
INSERT INTO `rent_tbl` VALUES (18,'KA51KK8959','piyush0211','Abhishek','2023-03-23','2023-04-13',16800),(19,'MP66AS6265','piyush0211','piyush','2023-03-27','2023-04-12',13600),(22,'BR29SA0007','piyush0211','Abhishek','2023-03-27','2023-03-31',16000),(23,'MP66AS0901','SHIVA65','SHIVA','2023-06-23','2023-07-01',9600),(25,'KL04DM8976','abhishek@6265','Piyush1234','2023-05-12','2023-05-16',2800),(26,'MP66BU6326','abhishek@6265','saifuuuu@12345678','2023-05-20','2023-06-03',16800),(27,'MP66AS0901','piyush0211','abhi','2023-05-13','2023-05-17',4800),(28,'BR29SA0007','piyush0211','sham','2023-06-02','2024-07-12',1624000);
/*!40000 ALTER TABLE `rent_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_tbl`
--

DROP TABLE IF EXISTS `return_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `return_tbl` (
  `retId` int NOT NULL AUTO_INCREMENT,
  `carReg` varchar(50) NOT NULL,
  `custname` varchar(50) NOT NULL,
  `returnDate` date NOT NULL,
  `delay` int NOT NULL,
  `fine` int NOT NULL,
  PRIMARY KEY (`retId`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_tbl`
--

LOCK TABLES `return_tbl` WRITE;
/*!40000 ALTER TABLE `return_tbl` DISABLE KEYS */;
INSERT INTO `return_tbl` VALUES (9,'MP66AS6265','Abhishek Kushwaha','2023-03-26',0,0),(10,'BR29SA0007','Piyush Sharma','2023-02-15',35,17500),(11,'MP66AS0901','Saif Alam','2023-03-25',0,0),(12,'MP66BU6326','Abhishek','2023-03-28',0,0),(14,'KL04DM8976','Saif Alam','2023-03-25',40,20000),(15,'MP66AS0901','Saif Alam','2023-03-26',0,0),(16,'BR29SA0007','Piyush Kumar','2023-03-25',2,1000),(17,'MP66AS0901','Saif Alam','2023-03-25',2,1000),(20,'MP67AM5678','Abhishek','2023-03-30',36,18000),(21,'MP66BU6326','Abhishek','2023-04-13',0,0),(24,'MP66BU6326','saifu','2023-05-25',0,0);
/*!40000 ALTER TABLE `return_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_accounts`
--

DROP TABLE IF EXISTS `tbl_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_accounts` (
  `fname` varchar(20) DEFAULT NULL,
  `lname` varchar(20) DEFAULT NULL,
  `email` varchar(40) DEFAULT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) DEFAULT NULL,
  `mobno` bigint DEFAULT NULL,
  `dlno` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_accounts`
--

LOCK TABLES `tbl_accounts` WRITE;
/*!40000 ALTER TABLE `tbl_accounts` DISABLE KEYS */;
INSERT INTO `tbl_accounts` VALUES ('Abhishek','Kushwaha','abhishek@gmail.com','abhishek@6265','Abhi123',6265756432,'MP 66 2022302324'),('Abhishek','Kushwaha','abhishek@gmail.com','abhishek6265','guru',6265754236,'MP66GH202311'),('Piyush','Kumar','piyushsharma@gmail.com','piyush0211','guru',7463969258,'BR03PS202311'),('Saif','Alam','saif@gmail.com','saifuu123','saifu11',9809234567,'BR23AD4532'),('shiva','yadav','shiva@gmail.com','shiva12345','shiva123',45678346789,'23456789876543234567'),('shiva','shiva','21bbaa6@jayanti.com','shiva65','123456789',6789012345,'MP 66 2022233024'),('Neha ','Singh ','sneha0402@gmail.com','sneha0204','sneha',8544062122,'82eu382');
/*!40000 ALTER TABLE `tbl_accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `first_name` varchar(20) DEFAULT NULL,
  `last_name` varchar(20) DEFAULT NULL,
  `email` varchar(40) DEFAULT NULL,
  `username` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `mobile_no` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-25  0:49:33
