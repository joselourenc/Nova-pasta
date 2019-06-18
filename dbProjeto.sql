CREATE DATABASE dbProjeto;

USE dbProjeto;

CREATE TABLE IF NOT EXISTS User ( 
Username Varchar (18) NOT NULL, 
Pass Varchar (18) NOT NULL,
User_ID INT NOT NULL AUTO_INCREMENT,
Email Varchar (50) NOT NULL,
PRIMARY KEY (User_ID));

CREATE TABLE IF NOT EXISTS Comboio (
Preco decimal(15) NOT NULL,
HoraPartida Time(24) NOT NULL,
HoraChegada Time(24) NOT NULL,
DuracaoViagem Time(24) NOT NULL,
Comboio_ID INT NOT NULL AUTO_INCREMENT,
PRIMARY KEY (Comboio_ID));

CREATE TABLE IF NOT EXISTS Metro (
Preco decimal(15) NOT NULL,
HoraPartida Time(24) NOT NULL,
HoraChegada Time(24) NOT NULL,
DuracaoViagem Time(24) NOT NULL,
Metro_ID INT NOT NULL AUTO_INCREMENT,
PRIMARY KEY (Metro_ID));

CREATE TABLE IF NOT EXISTS Autocarro (
Preco decimal(15) NOT NULL,
HoraPartida Time(24) NOT NULL,
HoraChegada Time(24) NOT NULL,
Autocarro_ID INT NOT NULL AUTO_INCREMENT,
PRIMARY KEY (Autocarro_ID));

CREATE TABLE IF NOT EXISTS Favoritos (



);