CREATE DATABASE nike;
USE nike;
CREATE TABLE rol (
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(50)  NOT NULL,
    PRIMARY KEY (id)
);
CREATE TABLE user (
    id int NOT NULL AUTO_INCREMENT,
    idenNumber varchar(20)  NOT NULL,
    username varchar(50) NOT NULL,
    email varchar(100)  NOT NULL UNIQUE,
    password varchar(255)  NOT NULL,
    PRIMARY KEY (id)
);
CREATE TABLE userRol (
    idUser int NOT NULL,
    idRol int NOT NULL,
	PRIMARY KEY (idUser, idRol),
    FOREIGN KEY (idRol) REFERENCES rol (id) ON DELETE CASCADE,
    FOREIGN KEY (idUser) REFERENCES user (id) ON DELETE CASCADE
);
CREATE TABLE category(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
PRIMARY KEY (id)
);
CREATE TABLE product(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(50) NOT NULL,
idCategory INT NOT NULL,
PRIMARY KEY (id),
FOREIGN KEY (idCategory) REFERENCES category (id)
);

CREATE TABLE client(
id INT NOT NULL AUTO_INCREMENT,
idUser INT NOT NULL,
firstName VARCHAR(50) NOT NULL,
secondName VARCHAR(50),
Surname VARCHAR(50) NOT NULL,
secondSurname VARCHAR(50),
PRIMARY KEY (id),
FOREIGN KEY (idUser) REFERENCES user (id)
);

CREATE TABLE bill(
id INT NOT NULL AUTO_INCREMENT,
idClient INT NOT NULL,
date DATE NOT NULL,
PRIMARY KEY (id),
FOREIGN KEY (idClient) REFERENCES client (id)
);

CREATE TABLE sale(
id INT NOT NULL AUTO_INCREMENT,
idBill INT NOT NULL,
idProduct INT NOT NULL,
quantity INT NOT NULL,
PRIMARY KEY (id),
FOREIGN KEY (idBill) REFERENCES bill (id),
FOREIGN KEY (idProduct) REFERENCES product (id)

);