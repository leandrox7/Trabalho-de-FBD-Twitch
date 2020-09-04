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
select nome_streamer,nome as nome_espectador from canalstreamer
natural join recomendacoes
join
	(select nome as nome_streamer, cod_usuario as cod_canal
	from canalstreamer) as streamer
using(cod_canal)
where (cod_canal,cod_usuario) not in
	(select cod_streamer,cod_usuario from gravacao
	 join participacao on (cod_transmissao = cod_gravacao));
     
    -- checar quais usuarios moderaram as streams de um outro usuario
    
    
-- c. uma delas (diferente das consultas acima) NOT EXISTS para questões TODOS ou NENHUM que <referencia> 
-- (isto é, não existe formulação equivalente usando simplemente joins ou subconsultas com (NOT) IN ou operadores relacionais)
	-- ver quais seguidores o usuario tem em comum com outro usuario
    
-- d. duas delas com visão 
	-- checar quantos meses de inscricao nos canais inscritos
    
    -- (talvez) checar quantos inscritos sao prime e quantos sao normais