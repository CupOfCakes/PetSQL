--verifica qual raça faz mais check ups e exames de sangue em relação a todas as operações
--ESTRATEGIA: dar desconto em operações basicas para bulldogs
SELECT 
    raca_animal,
    COUNT(CASE WHEN operacao IN ('check up', 'exame de sangue') THEN 1 END) * 100.0 / COUNT(*) AS percentual_basicas
FROM 
    agendamento_detalhado
GROUP BY 
    raca_animal
ORDER BY 
    percentual_basicas DESC;
