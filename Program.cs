using TrabalhoBusca;

public class Program
{
    public static void Main(string[] args)
    {
        Ambiente ambiente = new Ambiente();

        ambiente.AdicionarSala("A");
        ambiente.AdicionarSala("B");
        ambiente.AdicionarSala("C");
        ambiente.AdicionarSala("D");
        ambiente.AdicionarSala("E");
        ambiente.AdicionarSala("F");
        ambiente.AdicionarSala("G");
        ambiente.AdicionarSala("H");
        ambiente.AdicionarSala("I");
        ambiente.AdicionarSala("J");
        ambiente.AdicionarSala("K");
        ambiente.AdicionarSala("L");
        ambiente.AdicionarSala("M");
        ambiente.AdicionarSala("N");
        ambiente.AdicionarSala("O");
        ambiente.AdicionarSala("P");
        ambiente.AdicionarSala("Q");
        ambiente.AdicionarSala("R");
        ambiente.AdicionarSala("S");
        ambiente.AdicionarSala("T");
        ambiente.AdicionarSala("U");
        ambiente.AdicionarSala("V");
        ambiente.AdicionarSala("W");
        ambiente.AdicionarSala("X");
        ambiente.AdicionarSala("Y");
        ambiente.AdicionarSala("Z");

        ambiente.ConectarSalas("A", "C", 2, 1);

        ambiente.ConectarSalas("B", "C", 1, 1);
        ambiente.ConectarSalas("B", "D", 1, 2);

        ambiente.ConectarSalas("C", "A", 1, 2);
        ambiente.ConectarSalas("C", "B", 1, 1);
        ambiente.ConectarSalas("C", "G", 1, 1);

        ambiente.ConectarSalas("D", "B", 2, 1);
        ambiente.ConectarSalas("D", "E", 1, 3);

        ambiente.ConectarSalas("E", "D", 3, 1);
        ambiente.ConectarSalas("E", "F", 3, 2);

        ambiente.ConectarSalas("F", "E", 2, 3);
        ambiente.ConectarSalas("F", "J", 2, 1);

        ambiente.ConectarSalas("G", "C", 1, 1);
        ambiente.ConectarSalas("G", "H", 1, 2);
        ambiente.ConectarSalas("G", "K", 1, 1);

        ambiente.ConectarSalas("H", "G", 2, 1);
        ambiente.ConectarSalas("H", "I", 2, 1);
        ambiente.ConectarSalas("H", "K", 2, 1);
        ambiente.ConectarSalas("H", "L", 2, 3);

        ambiente.ConectarSalas("I", "H", 1, 2);
        ambiente.ConectarSalas("I", "J", 1, 1);

        ambiente.ConectarSalas("J", "F", 1, 2);
        ambiente.ConectarSalas("J", "I", 1, 1);
        ambiente.ConectarSalas("J", "M", 1, 3);

        ambiente.ConectarSalas("K", "G", 1, 1);
        ambiente.ConectarSalas("K", "H", 1, 2);
        ambiente.ConectarSalas("K", "N", 1, 3);

        ambiente.ConectarSalas("L", "H", 3, 2);
        ambiente.ConectarSalas("L", "M", 3, 3);

        ambiente.ConectarSalas("M", "J", 3, 1);
        ambiente.ConectarSalas("M", "L", 3, 3);
        ambiente.ConectarSalas("M", "P", 3, 2);

        ambiente.ConectarSalas("N", "K", 3, 1);
        ambiente.ConectarSalas("N", "O", 3, 2);
        ambiente.ConectarSalas("N", "Q", 3, 3);

        ambiente.ConectarSalas("O", "N", 2, 3);
        ambiente.ConectarSalas("O", "P", 2, 2);

        ambiente.ConectarSalas("P", "M", 2, 3);
        ambiente.ConectarSalas("P", "O", 2, 2);
        ambiente.ConectarSalas("P", "T", 2, 3);


        ambiente.ConectarSalas("Q", "N", 3, 3);
        ambiente.ConectarSalas("Q", "R", 3, 2);

        ambiente.ConectarSalas("R", "Q", 2, 3);
        ambiente.ConectarSalas("R", "S", 2, 2);

        ambiente.ConectarSalas("S", "R", 2, 2);
        ambiente.ConectarSalas("S", "T", 2, 3);

        ambiente.ConectarSalas("T", "P", 3, 2);
        ambiente.ConectarSalas("T", "S", 3, 2);
        ambiente.ConectarSalas("T", "U", 3, 2);

        ambiente.ConectarSalas("U", "T", 2, 3);

        Busca busca = new Busca();
        Sala inicio = ambiente.ObterSala("A");
        Sala objetivo = ambiente.ObterSala("F");

        List<Sala> caminhoBFS = busca.BuscaEmLargura(inicio, objetivo);
        List<Sala> caminhoDFS = busca.BuscaEmProfundidade(inicio, objetivo);
        List<Sala> caminhoGulosa = busca.BuscaGulosa(inicio, objetivo, ambiente);
        List<Sala> caminhoAEstrela = busca.BuscaAEstrela(inicio, objetivo, ambiente);

        Console.WriteLine("Caminho BFS: " + string.Join(" -> ", caminhoBFS.Select(s => s.Nome)));
        Console.WriteLine("Caminho DFS: " + string.Join(" -> ", caminhoDFS.Select(s => s.Nome)));
        Console.WriteLine("Caminho Gulosa: " + string.Join(" -> ", caminhoGulosa.Select(s => s.Nome)));
        Console.WriteLine("Caminho A*: " + string.Join(" -> ", caminhoAEstrela.Select(s => s.Nome)));
    }
}
