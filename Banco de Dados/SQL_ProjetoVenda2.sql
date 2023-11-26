-- CRIANDO O BANCO DE DADOS
CREATE DATABASE FUNEC2023_DAII;
--@ CHAVE PRIM�RIA
--# CHAVE ESTRANGEIRA

-- SEXO = {@CODSEXO, NOMESEXO}
CREATE TABLE SEXO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(9) NOT NULL UNIQUE
);
CREATE TABLE UF(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	SIGLA CHAR(2) NOT NULL UNIQUE,
);
INSERT INTO UF (NOME,SIGLA) VALUES ('S�O PAULO','SP');
INSERT INTO UF (NOME,SIGLA) VALUES ('RIO DE JANEIRO', 'RJ');
INSERT INTO UF (NOME,SIGLA) VALUES ('MINAS GERAIS', 'MG');
INSERT INTO UF (NOME,SIGLA) VALUES ('RIO GRANDE DO SUL', 'RS');
INSERT INTO UF (NOME,SIGLA) VALUES ('PARAN�', 'PR');

--CIDADE={@CODCIDADE, NOMECIDADE, #CODUF}
CREATE TABLE CIDADE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	CODUF_FK INTEGER REFERENCES UF(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE
);

--RUA={@CODRUA, NOMERUA}
CREATE TABLE RUA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

--BAIRRO={@CODBAIRRO, NOMEBAIRRO}
CREATE TABLE BAIRRO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE TRABALHO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE OPERADORA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE FUNCAO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE LOJA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	CNPJ VARCHAR(80) NOT NULL UNIQUE,
	NOMEFANTASIA VARCHAR(80),
	RAZAOSOCIAL VARCHAR(80)
);
CREATE TABLE ACESSO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE TIPO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
--CEP={@CODCEP,NUMEROCEP}
CREATE TABLE CEP(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NUMERO CHAR(9) NOT NULL UNIQUE
);

--ESTADO={@CODESTADO, NOMESTADO, SIGLA}
CREATE TABLE ESTADO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	SIGLA CHAR(2) NOT NULL UNIQUE
);

--CLIENTE=(@CODCLIENTE, NOMECLIENTE, DATANASC, CPF, CODSEXOFK,
-- CODCIDADE_FK, CODRUA_FK, CODBAIRRO_FK, CODCEP_FK, NUMEROCASA,
-- CODESTADO_FK)
CREATE TABLE CLIENTE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	DATANASC DATE NOT NULL,
	CPF CHAR(14) NOT NULL UNIQUE,
	CODSEXO_FK INTEGER REFERENCES SEXO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCIDADE_FK INTEGER REFERENCES CIDADE(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODRUA_FK INTEGER REFERENCES RUA(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODBAIRRO_FK INTEGER REFERENCES BAIRRO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCEP_FK INTEGER REFERENCES CEP(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODESTADO_FK INTEGER REFERENCES ESTADO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE
);

-- TELEFONE={@CODTELEFONE, NUMEROTELEFONE}
CREATE TABLE TELEFONE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NUMERO VARCHAR(14) NOT NULL UNIQUE
);

--TELEFONECLIENTE={@(CODTELEFONE_FK, CODCLIENTE_FK)}
CREATE TABLE TELEFONECLIENTE(
	CODTELEFONE_FK INTEGER REFERENCES TELEFONE(COD) ON DELETE CASCADE 
	               ON UPDATE CASCADE,
	CODCLIENTE_FK INTEGER REFERENCES CLIENTE(COD) ON DELETE CASCADE
	               ON UPDATE CASCADE,
	PRIMARY KEY(CODTELEFONE_FK, CODCLIENTE_FK)
);

-- VENDA = {@CODVENDA, DATAVENDA, CODCLIENTE_FK}
CREATE TABLE VENDA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATAVENDA DATE NOT NULL,
	CODCLIENTE_FK INTEGER REFERENCES CLIENTE(COD) ON DELETE CASCADE
	              ON UPDATE CASCADE
);

-- MARCA = {@CODMARCA, NOMEMARCA}
CREATE TABLE MARCA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

-- TIPO_PRODUTO={@CODTIPOPRODUTO, NOMETIPOPRODUTO}
CREATE TABLE TIPOPRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

--PRODUTO={@CODPRODUTO, NOMEPRODUTO, QUANT, VALOR, CODMARCA_FK, CODTIPOPRODUTO_FK}
CREATE TABLE PRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	QUANT NUMERIC(10,2) NOT NULL,
	VALOR NUMERIC(10,2) NOT NULL,
	CODMARCA_FK INTEGER REFERENCES MARCA(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	CODTIPOPRODUTO_FK INTEGER REFERENCES TIPOPRODUTO(COD) 
	                  ON DELETE CASCADE ON UPDATE CASCADE
);

-- VENDAPRODUTO={@(CODVENDA_FK, CODPRODUTO_FK), QUANTV, VALORV}
CREATE TABLE VENDAPRODUTO(
	CODVENDA_FK INTEGER REFERENCES VENDA(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	QUANTV NUMERIC(10,2) NOT NULL,
	VALORV NUMERIC(10,2) NOT NULL,
	PRIMARY KEY(CODVENDA_FK, CODPRODUTO_FK)
);

--FOTOPRODUTO={@CODFOTO, DESCRICAO, IMAGEM, CODPRODUTO_FK}
CREATE TABLE FOTOPRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DESCRICAO VARCHAR(255) NOT NULL,
	IMAGEM VARBINARY(MAX) NOT NULL,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD) ON DELETE CASCADE
	              ON UPDATE CASCADE
);

--SITUACAO={CODSITUACAO, NOMESITUACAO}
CREATE TABLE SITUACAO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(40) NOT NULL UNIQUE
);
--PARCELAVENDA={@CODPARCELA, DATAVENCIMENTO, VALORPARCELA, CODSITUACAO_FK
--CODVENDA_FK}
CREATE TABLE PARCELAVENDA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATAVENCIMENTO DATE NOT NULL,
	VALORPARCELA NUMERIC(10,2) NOT NULL,
	CODSITUACAO_FK INTEGER REFERENCES SITUACAO(COD) ON DELETE CASCADE
	               ON UPDATE CASCADE, 
	CODVENDA_FK INTEGER REFERENCES VENDA(COD) ON DELETE CASCADE
	               ON UPDATE CASCADE
);


-- FORNECEDOR = {@CODFORNECEDOR, NOMEFORNECEDOR, CNPJ}
CREATE TABLE FORNECEDOR(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	CNPJ CHAR(18) NOT NULL UNIQUE --XX.XXX.XXX/0001-XX.
);

--COMPRA={@CODCOMPRA, DATACOMPRA, CODFORNECEDOR_FK}
CREATE TABLE COMPRA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATACOMPRA DATE NOT NULL,
	CODFORNECEDOR_FK INTEGER REFERENCES FORNECEDOR (COD) ON DELETE
	                 CASCADE ON UPDATE CASCADE
);

--COMPRAPRODUTO={@(CODCOMPRA_FK,CODPRODUTO_FK), QUANTC, VALORC}
CREATE TABLE COMPRAPRODUTO(
	CODCOMPRA_FK INTEGER REFERENCES COMPRA(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	QUANTC NUMERIC(10,2) NOT NULL,
	VALORC NUMERIC(10,2) NOT NULL,
	PRIMARY KEY(CODCOMPRA_FK, CODPRODUTO_FK)
);

