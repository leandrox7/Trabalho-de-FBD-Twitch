-- Item2.a) Definir uma visão útil a seu universo de discurso, envolvendo no mínimo 3 tabelas.

	-- juncao de usuario, transacao e inscritos (para saber quantos meses de inscricao, etc)
create view InscritosDoCanal as (
select cod_canal, cod_usuario as cod_inscrito, nome as nome_inscrito, nome_streamer, valor, tipo, meses, data_inicio, data_fim, total_meses
from canalstreamer
natural join transacao
natural join inscritos
join 
	(select cod_usuario as cod_canal, nome as nome_streamer
	 from canalstreamer) as streamer 
using (cod_canal)
);

-- Item2.b) 10 consultas mínimo 3 tabelas.

-- a. duas group by. Uma delas deve incluir Having.

	-- mostrar quem ainda não tem nenhuma recompensa reivindicada
select nome, sum(recebido) as itens_reivindicados  from canalstreamer
natural join prime
natural join recompensa
group by cod_usuario
having sum(recebido) < 1;

    -- contar quantos inscritos tem em cada canal
select nome_streamer, count(cod_inscrito) as total_inscritos
from inscritosdocanal
group by nome_streamer;
    
    
-- b. duas com subconsulta (isto é, não existe formulação equivalente simplesmente usando joins);

	-- checar quais canais o usuario NAO assistiu dos canais que lhe foram recomendados
    -- (para checar se as recomendações estão sendo efetivas)
select nome_streamer,nome as nome_espectador 
from canalstreamer
natural join recomendacoes
join (select nome as nome_streamer, cod_usuario as cod_canal
	  from canalstreamer) as streamer
using (cod_canal)
where (cod_canal,cod_usuario) not in
	(select cod_streamer,cod_usuario 
     from gravacao
	 natural join participacao);
     
	-- seleciona os streamers que fizeram lives na categoria CSGO e tiveram mais de 20000 no total de visualizacoes
select nome as nome_streamer, total_visualizacoes
from gravacao
natural join categorizados
join canalstreamer on (cod_streamer = cod_usuario)
where total_visualizacoes > 20000 and
	cod_categoria in (select cod_categoria
					  from categorias
                      where nome = 'CSGO');
    
-- c. uma delas (diferente das consultas acima) NOT EXISTS para questões TODOS ou NENHUM que <referencia> 
-- (isto é, não existe formulação equivalente usando simplemente joins ou subconsultas com (NOT) IN ou operadores relacionais)

	-- ver quem segue todos os canais (ou mais) que o usuario 2 (cod_usuario = 2) segue
select distinct nome
from canalstreamer 
join seguir as SEG 
on (cod_usuario = cod_seguidor)
where cod_seguidor <> 3 and
not exists (select cod_canal
			from seguir
            where cod_seguidor = 3 and
            cod_canal not in
						(select distinct cod_canal
                         from seguir
                         where cod_seguidor = SEG.cod_seguidor));
    
-- d. duas delas com visão 

	-- checar quantos meses de inscricao nos canais inscritos
select nome_inscrito, nome_streamer, total_meses
from inscritosdocanal;

    -- checar quantos inscritos sao do tipo prime
select nome_streamer, count(tipo) as total_prime
from inscritosdocanal
where tipo = 1
group by nome_streamer;

-- restantes

	-- checar quais usuarios moderaram as streams de um outro usuario
select A.nome as nome_streamer, C.nome as nome_moderador
from canalstreamer as A
join 
(select distinct cod_streamer, cod_usuario as cod_moderador
from gravacao
join participacao 
using (cod_gravacao)
where moderador = true) as B
on (a.cod_usuario = cod_streamer)
join canalstreamer as C
on (c.cod_usuario = cod_moderador);

	-- listar qual usuario mandou cada mensagem de uma gravacao
select nome as nome_espectador, conteudo, nome_streamer
from mensagem
natural join canalstreamer
join (select cod_gravacao,nome as nome_streamer
	  from canalstreamer
      join gravacao on (cod_usuario = cod_streamer)) as B
      on (mensagem.cod_gravacao = b.cod_gravacao)
where mensagem.cod_gravacao = 1;

	-- listar os canais (que tem inscritos), o total de seguidores e quantos deles sao inscritos
select nome_streamer, count(distinct cod_seguidor) as total_seguidores, count(distinct cod_inscrito) as total_inscritos
from seguir
natural join inscritosdocanal
group by (nome_streamer);