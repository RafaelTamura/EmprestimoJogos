use EmprestimoJogos;

CREATE TABLE Jogos (
	IdJogo INT IDENTITY(1,1),
	Nome varchar(50) NOT NULL,
	CONSTRAINT PK_Jogo PRIMARY KEY NONCLUSTERED (IdJogo)
);

CREATE TABLE Localidades (
	IdLocalidade INT IDENTITY(1,1),
	Nome varchar(30) NOT NULL,
	CONSTRAINT PK_Localidade PRIMARY KEY NONCLUSTERED (IdLocalidade)
);

CREATE TABLE Amigos (
	IdAmigo INT IDENTITY(1,1),
	Nome varchar(50) NOT NULL,
	IdLocalidade INT,
	CONSTRAINT PK_Amigo PRIMARY KEY NONCLUSTERED (IdAmigo), 
	CONSTRAINT FK_Localidade FOREIGN KEY (IdLocalidade) 
		REFERENCES Localidades (IdLocalidade) 
);

CREATE TABLE Emprestimos (
	IdEmprestimo INT IDENTITY(1,1),
	IdAmigo INT NOT NULL,
	IdJogo INT NOT NULL,
	DataEmprestimo DATE NOT NULL,
	CONSTRAINT PK_Emprestimo PRIMARY KEY NONCLUSTERED (IdEmprestimo), 
	CONSTRAINT FK_Amigo FOREIGN KEY (IdAmigo) 
		REFERENCES Amigos (IdAmigo),
	CONSTRAINT FK_Jogo FOREIGN KEY (IdJogo) 
		REFERENCES Jogos (IdJogo)
);

