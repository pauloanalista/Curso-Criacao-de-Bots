using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.MegaSena.Json
{
    public class Resultado
    {
        public string proximoConcurso { get; set; }
        public string concursoAnterior { get; set; }
        public object forward { get; set; }
        public List<object> mensagens { get; set; }
        public int concurso { get; set; }
        public long data { get; set; }
        public string resultado { get; set; }
        public int ganhadores { get; set; }
        public int ganhadores_quina { get; set; }
        public int ganhadores_quadra { get; set; }
        public double valor { get; set; }
        public double valor_quina { get; set; }
        public double valor_quadra { get; set; }
        public int acumulado { get; set; }
        public double valor_acumulado { get; set; }
        public long dtinclusao { get; set; }
        public string prox_final_zero { get; set; }
        public double ac_final_zero { get; set; }
        public object proxConcursoFinal { get; set; }
        public object observacao { get; set; }
        public string rowguid { get; set; }
        public string ic_conferido { get; set; }
        public string de_local_sorteio { get; set; }
        public string no_cidade { get; set; }
        public string sg_uf { get; set; }
        public double vr_estimativa { get; set; }
        public long dt_proximo_concurso { get; set; }
        public double vr_acumulado_especial { get; set; }
        public double vr_arrecadado { get; set; }
        public bool ic_concurso_especial { get; set; }
        public bool error { get; set; }
        public bool rateioProcessamento { get; set; }
        public bool sorteioAcumulado { get; set; }
        public string concursoEspecial { get; set; }
        public object ganhadoresPorUf { get; set; }
        public string resultadoOrdenado { get; set; }
        public string dataStr { get; set; }
        public string dt_proximo_concursoStr { get; set; }
    }
}
