CREATE DATABASE Twitch;
USE Twitch;

CREATE TABLE CanalStreamer (
    descricao VARCHAR(200),
    online_ BOOLEAN,
    nome VARCHAR(20) NOT NULL,
    senha VARCHAR(20) NOT NULL,
    cod_usuario INTEGER NOT NULL PRIMARY KEY
);

INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do fulano',FALSE,'fulano','senha123',1);
INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do beltrano',FALSE,'beltrano','senha123',2);
INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do ciclano',TRUE,'ciclano','senha123',3);

CREATE TABLE DadosPagamento (
    endereco VARCHAR(50),
    nro_cartao INTEGER,
    telefone INTEGER,
	cod_usuario INTEGER NOT NULL,
    cpf INTEGER NOT NULL PRIMARY KEY,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO DadosPagamento VALUES('rua de tal',123456,519803214,1,321456789);
INSERT INTO DadosPagamento VALUES('vila de tal',123333,439993214,2,444456789);
INSERT INTO DadosPagamento VALUES('avenida de tal',123321,319883214,3,123456789);

CREATE TABLE Categorias (
	cod_categoria INTEGER NOT NULL PRIMARY KEY auto_increment,
    nome VARCHAR(20) NOT NULL
);

INSERT INTO Categorias (nome) VALUES('League of Legends');
INSERT INTO Categorias (nome) VALUES('Just Chatting');
INSERT INTO Categorias (nome) VALUES('CSGO');

CREATE TABLE Recomendacoes (
    cod_usuario INTEGER NOT NULL,
    cod_canal INTEGER NOT NULL,
	
	PRIMARY KEY(cod_usuario, cod_canal),
	FOREIGN KEY(cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY(cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Recomendacoes VALUES(1,2);
INSERT INTO Recomendacoes VALUES(2,1);
INSERT INTO Recomendacoes VALUES(1,3);

CREATE TABLE Gravacao (
    total_visualizacoes INTEGER,
    duracao TIME,
    max_espectadores INTEGER,
    cod_transmissao INTEGER NOT NULL PRIMARY KEY, 
	cod_streamer INTEGER NOT NULL,
	
	FOREIGN KEY (cod_streamer) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Gravacao VALUES(10234,'00:42:00',1000,1,1);
INSERT INTO Gravacao VALUES(340233,'01:14:00',5030,2,2);
INSERT INTO Gravacao VALUES(4319037,'03:25:00',14300,3,3);

CREATE TABLE Inscritos (
    data_inicio DATE,
    data_fim DATE,
	total_meses INTEGER,
	cod_usuario INTEGER NOT NULL,
	cod_canal INTEGER NOT NULL,
	
	PRIMARY KEY(cod_usuario, cod_canal),
	FOREIGN KEY(cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY(cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',12,1,2);
INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',5,2,3);
INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',1,1,3);

CREATE TABLE Transacao (
    valor NUMERIC,
    tipo BIT,
    meses INTEGER,
    cod_usuario INTEGER NOT NULL,
	cod_canal INTEGER NOT NULL,
	
	PRIMARY KEY (cod_usuario,cod_canal),
	FOREIGN KEY(cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY(cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Transacao VALUES(60,0,12,1,2);
INSERT INTO Transacao VALUES(25,0,12,2,3);
INSERT INTO Transacao VALUES(NULL,1,1,1,3);

CREATE TABLE Notificacao (
    mensagem VARCHAR(100),
    id_notificacao INTEGER NOT NULL PRIMARY KEY,
	cod_usuario INTEGER NOT NULL,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Notificacao VALUES('Alanzoka esta online!',1,2);
INSERT INTO Notificacao VALUES('Voce recebeu o drop VALORANT por assistir Riot Games jogando VALORANT',2,2);
INSERT INTO Notificacao VALUES('Voce recebeu uma nova mensagem',3,1);

CREATE TABLE Prime (
    login_amazon VARCHAR(20) NOT NULL,
    senha_amazon VARCHAR(20) ,
    cod_amazon INTEGER NOT NULL PRIMARY KEY,
	cod_usuario INTEGER NOT NULL,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario)
);

INSERT INTO Prime VALUES('fulano@gmail.com','senha123',100,1);
INSERT INTO Prime VALUES('beltrano@gmail.com','senha123',200,2);
INSERT INTO Prime VALUES('ciclano@gmail.com','senha123',300,3);

CREATE TABLE Items (
	cod_item INTEGER NOT NULL PRIMARY KEY auto_increment,
    nome VARCHAR(50) NOT NULL,
    tipo INTEGER NOT NULL
);

INSERT INTO Items (nome,tipo) VALUES('Fragmento de skin League of Legends',1);
INSERT INTO Items (nome,tipo) VALUES('Jogo de Estrategia',2);
INSERT INTO Items (nome,tipo) VALUES('Jogo de Tiro',2);

CREATE TABLE Mensagem (
    conteudo VARCHAR(200),
    cod_gravacao INTEGER NOT NULL,
	cod_usuario INTEGER NOT NULL,
	id_mensagem INTEGER NOT NULL PRIMARY KEY,

	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_transmissao) ON DELETE CASCADE
);

INSERT INTO Mensagem VALUES('boa tarde! como vai?',1,1,1);
INSERT INTO Mensagem VALUES('hahahahaha',2,2,2);
INSERT INTO Mensagem VALUES('jogou bem!',3,3,3);

CREATE TABLE Seguir (
    cod_canal INTEGER NOT NULL,
    cod_seguidor INTEGER NOT NULL,
	
	PRIMARY KEY (cod_canal,cod_seguidor),
	FOREIGN KEY (cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_seguidor) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

INSERT INTO Seguir VALUES(1,2);
INSERT INTO Seguir VALUES(2,3);
INSERT INTO Seguir VALUES(1,3);
INSERT INTO Seguir VALUES(2,1);
INSERT INTO Seguir VALUES(3,1);

CREATE TABLE Participacao (
	data_participacao DATE NOT NULL,
	cod_usuario INTEGER NOT NULL,
    cod_gravacao INTEGER NOT NULL,
    moderador BOOLEAN,
	
	PRIMARY KEY (data_participacao,cod_usuario,cod_gravacao),
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_transmissao) ON DELETE CASCADE
);

INSERT INTO Participacao VALUES('2020-01-04',1,1,TRUE);
INSERT INTO Participacao VALUES('2020-01-04',2,1,FALSE);
INSERT INTO Participacao VALUES('2020-01-04',3,1,FALSE);

INSERT INTO Participacao VALUES('2020-03-04',1,2,FALSE);
INSERT INTO Participacao VALUES('2020-03-04',2,2,TRUE);
INSERT INTO Participacao VALUES('2020-03-04',3,2,FALSE);

INSERT INTO Participacao VALUES('2020-02-14',1,1,FALSE);
INSERT INTO Participacao VALUES('2020-02-14',2,3,FALSE);
INSERT INTO Participacao VALUES('2020-02-14',3,3,TRUE);


CREATE TABLE Categorizados (
    cod_gravacao INTEGER NOT NULL,
    cod_categoria INTEGER NOT NULL,
	
	PRIMARY KEY (cod_gravacao,cod_categoria),
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_transmissao) ON DELETE CASCADE,
	FOREIGN KEY (cod_categoria) REFERENCES Categorias (cod_categoria) ON DELETE CASCADE
);

INSERT INTO Categorizados VALUES(1,1);
INSERT INTO Categorizados VALUES(2,2);
INSERT INTO Categorizados VALUES(3,3);

CREATE TABLE Recompensa (
    cod_item INTEGER NOT NULL,
    cod_amazon INTEGER NOT NULL,
    recebido BOOLEAN,
	
	PRIMARY KEY (cod_item,cod_amazon),
	FOREIGN KEY (cod_amazon) REFERENCES Prime (cod_amazon),
    FOREIGN KEY (cod_item) REFERENCES Items (cod_item)
);

INSERT INTO Recompensa VALUES(3,100,TRUE);
INSERT INTO Recompensa VALUES(3,200,FALSE);
INSERT INTO Recompensa VALUES(1,100,TRUE);


select * from CanalStreamer;
select * from Gravacao;
select * from Transacao;
select * from Notificacao;
select * from Participacao;
select * from Recompensa;
select * from Items;
select * from Inscritos;
select * from Prime;
select * from mensagem;
select * from seguir;
select * from dadospagamento;
select * from categorias;
select * from categorizados;



