CREATE DATABASE Twitch;
USE Twitch;

CREATE TABLE CanalStreamer (
    descricao VARCHAR(200),
    online_ BOOLEAN,
    nome VARCHAR(20) NOT NULL,
    senha VARCHAR(20) NOT NULL,
    cod_usuario INTEGER NOT NULL PRIMARY KEY
);

CREATE TABLE DadosPagamento (
    endereco VARCHAR(50),
    nro_cartao INTEGER,
    telefone INTEGER,
	cod_usuario INTEGER NOT NULL,
    cpf INTEGER NOT NULL PRIMARY KEY,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

CREATE TABLE Categorias (
	cod_categoria INTEGER NOT NULL PRIMARY KEY auto_increment,
    nome VARCHAR(20) NOT NULL
);

CREATE TABLE Recomendacoes (
    cod_usuario INTEGER NOT NULL,
    cod_canal INTEGER NOT NULL,
	
	PRIMARY KEY(cod_usuario, cod_canal),
	FOREIGN KEY(cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY(cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

CREATE TABLE Gravacao (
    total_visualizacoes INTEGER,
    duracao TIME,
    max_espectadores INTEGER,
    cod_gravacao INTEGER NOT NULL PRIMARY KEY, 
	cod_streamer INTEGER NOT NULL,
	
	FOREIGN KEY (cod_streamer) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

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

CREATE TABLE Notificacao (
    mensagem VARCHAR(100),
    id_notificacao INTEGER NOT NULL PRIMARY KEY,
	cod_usuario INTEGER NOT NULL,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

CREATE TABLE Prime (
    login_amazon VARCHAR(20) NOT NULL,
    senha_amazon VARCHAR(20) ,
    cod_amazon INTEGER NOT NULL PRIMARY KEY,
	cod_usuario INTEGER NOT NULL,
	
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario)
);

CREATE TABLE Items (
	cod_item INTEGER NOT NULL PRIMARY KEY auto_increment,
    nome VARCHAR(50) NOT NULL,
    tipo INTEGER NOT NULL
);

CREATE TABLE Mensagem (
    conteudo VARCHAR(200),
    cod_gravacao INTEGER NOT NULL,
	cod_usuario INTEGER NOT NULL,
	id_mensagem INTEGER NOT NULL PRIMARY KEY,

	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_gravacao) ON DELETE CASCADE
);

CREATE TABLE Seguir (
    cod_canal INTEGER NOT NULL,
    cod_seguidor INTEGER NOT NULL,
	
	PRIMARY KEY (cod_canal,cod_seguidor),
	FOREIGN KEY (cod_canal) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_seguidor) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE
);

CREATE TABLE Participacao (
	data_participacao DATE NOT NULL,
	cod_usuario INTEGER NOT NULL,
    cod_gravacao INTEGER NOT NULL,
    moderador BOOLEAN,
	
	PRIMARY KEY (data_participacao,cod_usuario,cod_gravacao),
	FOREIGN KEY (cod_usuario) REFERENCES CanalStreamer (cod_usuario) ON DELETE CASCADE,
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_gravacao) ON DELETE CASCADE
);

CREATE TABLE Categorizados (
    cod_gravacao INTEGER NOT NULL,
    cod_categoria INTEGER NOT NULL,
	
	PRIMARY KEY (cod_gravacao,cod_categoria),
	FOREIGN KEY (cod_gravacao) REFERENCES Gravacao (cod_gravacao) ON DELETE CASCADE,
	FOREIGN KEY (cod_categoria) REFERENCES Categorias (cod_categoria) ON DELETE CASCADE
);

CREATE TABLE Recompensa (
    cod_item INTEGER NOT NULL,
    cod_amazon INTEGER NOT NULL,
    recebido BOOLEAN,
	
	PRIMARY KEY (cod_item,cod_amazon),
	FOREIGN KEY (cod_amazon) REFERENCES Prime (cod_amazon),
    FOREIGN KEY (cod_item) REFERENCES Items (cod_item)
);

select * from CanalStreamer;
select * from Gravacao;
select * from Transacao;
select * from Notificacao;
select * from Participacao;
select * from Recompensa;
select * from Items;
select * from Prime;
select * from mensagem;
select * from dadospagamento;
select * from categorias;
select * from categorizados;
select * from Inscritos;
select * from seguir;



