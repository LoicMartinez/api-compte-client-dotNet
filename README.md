# api-compte-client-dotNet
Script sql server

CREATE TABLE client (
	id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	address VARCHAR(255) NOT NULL
)

CREATE TABLE compte (
	id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	libelle VARCHAR(50) NOT NULL
)

CREATE TABLE client_compte (
	client_id INTEGER NOT NULL,
	compte_id INTEGER NOT NULL,
	FOREIGN KEY(client_id) REFERENCES client(id),
	FOREIGN KEY(compte_id) REFERENCES compte(id),
)

CREATE TABLE type (
	id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	type VARCHAR(50) NOT NULL,
)

CREATE TABLE transac (
	id INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
	type_id INTEGER NOT NULL,
	compte_id INTEGER NOT NULL,
	FOREIGN KEY(compte_id) REFERENCES compte(id),
	FOREIGN KEY(type_id) REFERENCES type(id),
)

