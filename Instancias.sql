INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do fulano',FALSE,'fulano','senha123',1);
INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do beltrano',FALSE,'beltrano','senha123',2);
INSERT INTO CanalStreamer VALUES('Seja bem vindo ao canal do ciclano',TRUE,'ciclano','senha123',3);

-- canal principal da Twitch
INSERT INTO CanalStreamer VALUES('Seja bem vindo a Twitch',FALSE,'Twitch','dfADFE#43DFGSI3',4);

INSERT INTO DadosPagamento VALUES('rua de tal',123456,519803214,1,321456789);
INSERT INTO DadosPagamento VALUES('vila de tal',123333,439993214,2,444456789);
INSERT INTO DadosPagamento VALUES('avenida de tal',123321,319883214,3,123456789);

INSERT INTO Categorias (nome) VALUES('League of Legends');
INSERT INTO Categorias (nome) VALUES('Just Chatting');
INSERT INTO Categorias (nome) VALUES('CSGO');

INSERT INTO Recomendacoes VALUES(1,2);
INSERT INTO Recomendacoes VALUES(2,1);
INSERT INTO Recomendacoes VALUES(1,3);

INSERT INTO Gravacao VALUES(10234,'00:42:00',1000,1,1);
INSERT INTO Gravacao VALUES(340233,'01:14:00',5030,2,2);
INSERT INTO Gravacao VALUES(4319037,'03:25:00',14300,3,3);

INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',12,1,2);
INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',5,2,3);
INSERT INTO Inscritos VALUES('2020-07-11','2020-08-11',1,1,3);

INSERT INTO Transacao VALUES(60,0,12,1,2);
INSERT INTO Transacao VALUES(25,0,12,2,3);
INSERT INTO Transacao VALUES(NULL,1,1,1,3);

INSERT INTO Notificacao VALUES('Alanzoka esta online!',1,2);
INSERT INTO Notificacao VALUES('Voce recebeu o drop VALORANT por assistir Riot Games jogando VALORANT',2,2);
INSERT INTO Notificacao VALUES('Voce recebeu uma nova mensagem',3,1);

INSERT INTO Prime VALUES('fulano@gmail.com','senha123',100,1);
INSERT INTO Prime VALUES('beltrano@gmail.com','senha123',200,2);
INSERT INTO Prime VALUES('ciclano@gmail.com','senha123',300,3);

INSERT INTO Items (nome,tipo) VALUES('Fragmento de skin League of Legends',1);
INSERT INTO Items (nome,tipo) VALUES('Jogo de Estrategia',2);
INSERT INTO Items (nome,tipo) VALUES('Jogo de Tiro',2);

INSERT INTO Mensagem VALUES('boa tarde! como vai?',1,1,1);
INSERT INTO Mensagem VALUES('hahahahaha',2,2,2);
INSERT INTO Mensagem VALUES('jogou bem!',3,3,3);

INSERT INTO Seguir VALUES(1,2);
INSERT INTO Seguir VALUES(1,3);
INSERT INTO Seguir VALUES(2,1);
INSERT INTO Seguir VALUES(3,1);
INSERT INTO Seguir VALUES(3,2);

INSERT INTO Participacao VALUES('2020-01-04',1,1,TRUE);
INSERT INTO Participacao VALUES('2020-01-04',2,1,FALSE);
INSERT INTO Participacao VALUES('2020-01-04',3,1,FALSE);

INSERT INTO Participacao VALUES('2020-03-04',1,2,FALSE);
INSERT INTO Participacao VALUES('2020-03-04',2,2,TRUE);
INSERT INTO Participacao VALUES('2020-03-04',3,2,FALSE);

INSERT INTO Participacao VALUES('2020-02-14',1,1,TRUE);
INSERT INTO Participacao VALUES('2020-02-14',2,3,TRUE);
INSERT INTO Participacao VALUES('2020-02-14',3,3,TRUE);

INSERT INTO Categorizados VALUES(1,1);
INSERT INTO Categorizados VALUES(2,2);
INSERT INTO Categorizados VALUES(3,3);

INSERT INTO Recompensa VALUES(3,100,TRUE);
INSERT INTO Recompensa VALUES(3,200,FALSE);
INSERT INTO Recompensa VALUES(1,100,TRUE);
INSERT INTO Recompensa VALUES(2,300,FALSE);

