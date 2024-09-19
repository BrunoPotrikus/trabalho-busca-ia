namespace TrabalhoBusca
{
    public class Ambiente
    {
        public Dictionary<string, Sala> Salas { get; }

        public Ambiente()
        {
            Salas = new Dictionary<string, Sala>();
        }

        public void AdicionarSala(string nome)
        {
            Salas[nome] = new Sala(nome);
        }

        public Sala ObterSala(string nome)
        {
            return Salas[nome];
        }

        public void ConectarSalas(string nome1, string nome2, int peso1, int peso2)
        {
            Sala sala1 = Salas[nome1];
            Sala sala2 = Salas[nome2];
            sala1.AdicionarVizinho(sala2, peso2);
            sala2.AdicionarVizinho(sala1, peso1);
        }

        public int DistanciaManhattan(Sala salaAtual, Sala objetivo)
        {
            return Math.Abs(salaAtual.Peso - objetivo.Peso);
        }
    }
}
