namespace TrabalhoBusca
{
    public class Sala
    {
        public string Nome { get; }
        public int Peso { get; set; }
        public Dictionary<Sala, int> Vizinhos { get; }

        public Sala(string nome)
        {
            Nome = nome;
            Vizinhos = new Dictionary<Sala, int>();
        }

        public void AdicionarVizinho(Sala vizinho, int peso)
        {
            Vizinhos[vizinho] = peso;
        }
    }
}
