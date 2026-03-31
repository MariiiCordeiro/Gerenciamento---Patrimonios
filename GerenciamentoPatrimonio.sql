CREATE DATABASE GerenciamentoPatrimonios;

USE GerenciamentoPatrimonios;

-------------------------
-- Criação das tabelas --
-------------------------

-- Criação da tabela de área/blocos
CREATE TABLE Area(
AreaID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeArea VARCHAR(50) UNIQUE NOT NULL
);

-- Criação da tabela de cargo para usuario
CREATE TABLE Cargo(
CargoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeCargo VARCHAR(50) UNIQUE NOT NULL
);

-- Criação da tabela de tipo usuario
CREATE TABLE TipoUsuario(
TipoUsuarioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeTipo VARCHAR(50)  UNIQUE NOT NULL
);

-- Criação da tabela tipo patrimonio
CREATE TABLE TipoPatrimonio(
TipoPatrimonioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeTipo VARCHAR(100) UNIQUE NOT NULL
);

-- Criação da tabela de categorização de alteração
CREATE TABLE TipoAlteracao(
TipoAlteracaoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
Tipo VARCHAR(50) UNIQUE NOT NULL
);

-- Criação de condição do patrimonio
CREATE TABLE StatusPatrimonio(
StatusPatrimonioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
[Status] VARCHAR(50) UNIQUE NOT NULL
);

-- Criação de condição de tansferência
CREATE TABLE StatusTranferencia(
StatusTransferenciaID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
[Status] VARCHAR(50) UNIQUE NOT NULL
);
	
--Criação da tabela cidade
CREATE TABLE Cidade(
CidadeID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeCidade VARCHAR(50) NOT NULL,
Estado VARCHAR(50) NOT NULL 
);

-- Criação da tabela local/ambiente
CREATE TABLE [Local](
LocalID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeLocal VARCHAR(50) NOT NULL,
LocalSAP INT,
DescricaoSAP VARCHAR(100),
Ativo BIT DEFAULT 1,
AreaID UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Local_Area FOREIGN KEY (AreaID) REFERENCES Area(AreaID)
);

--Criação da tabela bairro
CREATE TABLE Bairro(
BairroID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NomeBairro VARCHAR(50) NOT NULL,
CidadeID UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Cidade_Bairro FOREIGN KEY (CidadeID) REFERENCES Cidade(CidadeID)
	ON DELETE CASCADE 
);

-- Criação da tabela Endereço
CREATE TABLE Endereco(
EnderecoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
Longradouro VARCHAR(50) NOT NULL,
Numero INT,
Complemento VARCHAR(20),
CEP VARCHAR (10), -- Adicionar NOT NULL
BairroID UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Endereco_Bairro FOREIGN KEY (BairroID) REFERENCES Bairro(BairroID)
);


-- Criação da tabela usuário
CREATE TABLE Usuario(
UsuarioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
NIF VARCHAR(7) UNIQUE NOT NULL,
NomeUsuario VARCHAR(50) NOT NULL,
RG VARCHAR(15) UNIQUE,
CPF VARCHAR(11) UNIQUE NOT NULL,
CarteiraTrabalho VARCHAR (14) UNIQUE NOT NULL,
Senha VARBINARY(32) NOT NULL,
Email VARCHAR(150) UNIQUE NOT NULL,
EnderecoID UNIQUEIDENTIFIER NOT NULL,
CargoID UNIQUEIDENTIFIER NOT NULL,
TipoUsuarioID UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT FK_Usuario_Endereco FOREIGN KEY (EnderecoID) REFERENCES Endereco(EnderecoID),

CONSTRAINT FK_Usuario_Cargo FOREIGN KEY (CargoID) REFERENCES Cargo(CargoID),

CONSTRAINT FK_Usuario_TipoUsuario FOREIGN KEY (TipoUsuarioID) REFERENCES TipoUsuario(TipoUsuarioID)
);

--Criação da tabela patrimônio
CREATE TABLE Patrimonio(
PatrimonioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
Denominacao VARCHAR(MAX) NOT NULL,
NumeroPatrimonio VARCHAR(30) NOT NULL,
Valor DECIMAL(10,2),
Imagem VARCHAR(MAX),
LocalID UNIQUEIDENTIFIER NOT NULL,
TipoPatrimonioID  UNIQUEIDENTIFIER NOT NULL,
StatusPatrimonioID  UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT FK_Patrimonio_Local FOREIGN KEY (LocalID) REFERENCES [Local](LocalID),
CONSTRAINT FK_Patrimonio_TipoPatrimonio FOREIGN KEY (TipoPatrimonioID) REFERENCES TipoPatrimonio(TipoPatrimonioID),
CONSTRAINT FK_Patrimonio_StatusPatrimonio FOREIGN KEY (StatusPatrimonioID) REFERENCES StatusPatrimonio(StatusPatrimonioID)
);

--Criação da tabela log patrimonio
CREATE TABLE LogPatrimonio(
LogPatrimonio UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
DataTransferencia DATETIME2(0) NOT NULL,
TipoAlteracaoID  UNIQUEIDENTIFIER NOT NULL,
StatusPatrimonioID UNIQUEIDENTIFIER NOT NULL,
PatrimonioID UNIQUEIDENTIFIER NOT NULL,
UsuarioID UNIQUEIDENTIFIER NOT NULL,
LocalID UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT FK_LogPatrimonio_TipoAlteracao FOREIGN KEY (TipoAlteracaoID) REFERENCES TipoAlteracao(TipoAlteracaoID),
CONSTRAINT FK_LogPatrimonio_StatusPatrimonio FOREIGN KEY (StatusPatrimonioID) REFERENCES StatusPatrimonio(StatusPatrimonioID),
CONSTRAINT FK_LogPatrimonio_Patrimonio FOREIGN KEY (PatrimonioID) REFERENCES Patrimonio(PatrimonioID),
CONSTRAINT FK_LogPatrimonio_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
CONSTRAINT FK_LogPatrimonio_Local FOREIGN KEY (LocalID) REFERENCES [Local](LocalID),
);

--Criação da tabela transferência

CREATE TABLE SoliciacaoTranferencia(
TransferenciaID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
DataCriacaoSolicitante DATETIME2(0) NOT NULL,
DataResposta DATETIME2(0) NOT NULL,
Justificativa VARCHAR(MAX) NOT NULL,
StatusTranferenciaID UNIQUEIDENTIFIER NOT NULL,
UsuarioIDSolicitante UNIQUEIDENTIFIER NOT NULL,
UsuarioIDAprovacao UNIQUEIDENTIFIER NOT NULL,
PatrimonioID  UNIQUEIDENTIFIER NOT NULL,
LocalID  UNIQUEIDENTIFIER NOT NULL,

CONSTRAINT FK_SolicitacaoTranferencia_StatusTranferencia FOREIGN KEY (StatusTranferenciaID) REFERENCES StatusTranferencia(StatusTransferenciaID),
CONSTRAINT FK_SolicitacaoTranferencia_UsuarioSolicitacao FOREIGN KEY (UsuarioIDSolicitante) REFERENCES Usuario(UsuarioID),
CONSTRAINT FK_SolicitacaoTranferencia_UsuarioAprovacao FOREIGN KEY (UsuarioIDAprovacao) REFERENCES Usuario(UsuarioID),
CONSTRAINT FK_SolicitacaoTranferencia_Patrimonio FOREIGN KEY (PatrimonioID) REFERENCES Patrimonio(PatrimonioID),
CONSTRAINT FK_SolicitacaoTranferencia_LocalID FOREIGN KEY (LocalID) REFERENCES [Local](LocalID),
);

-- Criação tabela localUsuario
CREATE TABLE LocalUsuario(
LocalID UNIQUEIDENTIFIER,
UsuarioID UNIQUEIDENTIFIER,

CONSTRAINT PK_LocalUsuario PRIMARY KEY(LocalID, UsuarioID),

CONSTRAINT FK_LocalUsuario_Local  FOREIGN KEY (LocalID) REFERENCES [Local](LocalID),

CONSTRAINT FK_LocalUsuario_Usuario  FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
);

----------------------------------
-- Criação das Triggers
---------------------
CREATE TRIGGER trg_UsuarioSoftDelete
ON Usuario
INSTEAD OF DELETE
AS 
BEGIN
	UPDATE Usuario
	SET Ativo= 0
	WHERE UsuarioID INT (SELECT UsuarioID FROM deleted);
END

--- LOCAL
CREATE TRIGGER trg_UsuarioSoftDelete
ON [Local]
INSTEAD OF DELETE
AS 
BEGIN
	UPDATE [Local]
	SET Ativo= 0
	WHERE LocalID INT (SELECT LocalID FROM deleted);
END

-- Patrimonio
CREATE TRIGGER trg_LocaL_SoftDelete
ON Patrimonio
INSTEAD OF DELETE
AS 
BEGIN
	UPDATE Patrimonio
	SET StatusPatrimonioID=
		(SELECT StatusPatrimonioID
			FROM StatusPatrimonio
			WHERE [Status] = 'Inativo')
	WHERE PatrimonioID IN(SELECT PatrimonioID FROM deleted);
END


--------------------------
-- Inserção dos Valores -- 
--------------------------

-- Área
INSERT INTO Area(NomeArea) VALUES
('Bloco A - Térreo'),
('Bloco B - 1° Andar')

--TipoUsuario
INSERT INTO TipoUsuario(NomeTipo) VALUES
('Responsável'),
('Coordenador')

-- Cargo
INSERT INTO Cargo(NomeCargo) VALUES
('Diretor'),
('Instrutor de Formação Profissional II')

--TipoUsuario
INSERT INTO TipoPatrimonio(NomeTipo) VALUES
('Mesa'),
('Notebook')

-- StatusPatrimonio
-- Inativo, Ativo, Transferido , Manutenção Externa
INSERT INTO StatusPatrimonio([Status]) VALUES
('Inativo'),
('Ativo'),
('Transferido'),
('Em manutenção')

-- StatusTranferencia
-- Pendente de aporvação aprovado e recusado
INSERT INTO StatusTranferencia([Status]) VALUES
('Pendente de aprovação'),
('Aprovado'),
('Recusado')

-- TipoAlteração
-- Modificação e transferência
INSERT INTO TipoAlteracao(Tipo) VALUES
('Modificação'),
('Tranferência')

-- Cidade
INSERT INTO Cidade(NomeCidade, Estado) VALUES
('São Caetano do Sul', 'São Paulo'),
('Diadema', 'São Paulo')

-- Local
INSERT INTO [Local](LocalSAP,DescricaoSAP, NomeLocal, AreaID) VALUES
('', '', 'Manutenção', (SELECT AreaID FROM Area WHERE NomeArea = 'Bloco A - Térreo'))

-- Bairro 
INSERT INTO Bairro(NomeBairro, CidadeID) VALUES
('Centro', (SELECT CidadeID FROM Cidade WHERE NomeCidade = 'São Caetano do Sul'))


select * from [Local]







