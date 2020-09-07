-- PROCEDIMENTO
	/* 
		O QUE FAZ: SEGUIR O CANAL OFICIAL DA TWITCH
		RECEBE UM USUARIO COMO PARAMETRO
	*/
    
DELIMITER $$
CREATE PROCEDURE seguir_canal_oficial (IN cod_streamer int)
	BEGIN
		INSERT INTO Seguir VALUES(4, cod_streamer);
        -- primeiro digito é o canal, o segundo é o seguidor
        
	END $$
DELIMITER 

/* COMO CHAMAR O PROCEDIMENTO?
	CALL seguir_canal_oficial(2);
*/



-- --------------------------------------------------------

/*
GATILHO
	É DISPARADO SEMPRE QUE UM STREAMER É ADICIONADO NA PLATAFORMA.
    O QUE FAZ? CHAMA A PROCEDURE QUE ADICIONA O CANAL OFICIAL NA LISTA
    DE CANAIS SEGUIDOS PELO STREAMER
    
*/
DELIMITER $$
		CREATE TRIGGER novo_streamer AFTER INSERT
		ON canalstreamer
		FOR EACH ROW
		BEGIN
		CALL seguir_canal_oficial(NEW.cod_usuario);
	END $$
DELIMITER 

/* Segundo Gatilho */

-- --------------------------------------------------------

/*
GATILHO
	É DISPARADO SEMPRE QUE UMA CONTA PRIME É ADICIONADO NA PLATAFORMA.
    O QUE FAZ? CHAMA A PROCEDURE QUE ADICIONA UMA RECOMPENSA
    
*/
DELIMITER $$
		CREATE TRIGGER bonus_prime AFTER INSERT
		ON prime
		FOR EACH ROW
		BEGIN
		CALL recompensa_prime(NEW.cod_amazon);
	END $$
DELIMITER 

-- PROCEDIMENTO
	/* 
		O QUE FAZ: ADICIONA AO NOVO PRIME O ÚLTIMO ITEM CADASTRADO
	*/
    
DELIMITER $$
CREATE PROCEDURE recompensa_prime (IN cod_amazon INT)
	BEGIN
		INSERT INTO Recompensa VALUES(
          (SELECT  cod_item FROM items ORDER BY cod_item DESC LIMIT 1),cod_amazon,TRUE);

	END $$
DELIMITER 

/* COMO CHAMAR O PROCEDIMENTO?
	CALL recompensa_prime(cod_prime);
*/