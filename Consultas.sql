-- Item2.b) 10 consultas mínimo 3 tabelas.

-- a. duas group by. Uma delas deve incluir Having.

	-- mostrar quem ainda não tem nenhuma recompensa reivindicada
select nome, count(recebido) as itens_reivindicados  from canalstreamer
natural join prime
natural join recompensa
group by cod_usuario
having count(recebido) = 0;

    -- contar quantos inscritos tem em cada canal
select nome_streamer, count(cod_inscrito) as total_inscritos
from inscritosdocanal
group by nome_streamer;
    
    
-- b. duas com subconsulta (isto é, não existe formulação equivalente simplesmente usando joins);

	-- checar quais transmissoes o usuario NAO assistiu de um canal que lhe foi recomendado 
    -- (para checar se as recomendações estão funcionando)
select nome_streamer,nome as nome_espectador 
from canalstreamer
natural join recomendacoes
join (select nome as nome_streamer, cod_usuario as cod_canal
	  from canalstreamer) as streamer
using(cod_canal)
where (cod_canal,cod_usuario) not in
	(select cod_streamer,cod_usuario 
     from gravacao
	 join participacao 
     on (cod_transmissao = cod_gravacao));
     
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
join seguir as SEG on (cod_usuario = cod_seguidor)
where cod_seguidor <> 2 and
not exists (select cod_canal
			from seguir
            where cod_seguidor = 2 and
            cod_canal not in
						(select distinct cod_canal
                         from seguir
                         where cod_seguidor = SEG.cod_seguidor));
    
-- d. duas delas com visão 

	-- checar quantos meses de inscricao nos canais inscritos
select nome_inscrito, nome_streamer, total_meses
from inscritosdocanal;

    -- checar quantos inscritos sao prime e quantos sao normais
select nome_streamer, count(tipo)
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
join participacao on (cod_transmissao = cod_gravacao)
where moderador = true) as B
on (a.cod_usuario = cod_streamer)
join canalstreamer as C
on (c.cod_usuario = cod_moderador);