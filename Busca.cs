namespace TrabalhoBusca
{
    public class Busca
    {
        public List<Sala> BuscaEmLargura(Sala inicio, Sala objetivo)
        {
            Queue<Sala> fila = new Queue<Sala>();
            Dictionary<Sala, Sala> anterior = new Dictionary<Sala, Sala>();
            fila.Enqueue(inicio);
            anterior[inicio] = null;

            while (fila.Count > 0)
            {
                Sala atual = fila.Dequeue();

                if (atual == objetivo)
                    return ReconstruirCaminho(anterior, objetivo);

                foreach (var vizinho in atual.Vizinhos.Keys)
                {
                    if (!anterior.ContainsKey(vizinho))
                    {
                        anterior[vizinho] = atual;
                        fila.Enqueue(vizinho);
                    }
                }
            }

            return null;
        }

        public List<Sala> BuscaEmProfundidade(Sala inicio, Sala objetivo)
        {
            Stack<Sala> pilha = new Stack<Sala>();
            Dictionary<Sala, Sala> anterior = new Dictionary<Sala, Sala>();
            pilha.Push(inicio);
            anterior[inicio] = null;

            while (pilha.Count > 0)
            {
                Sala atual = pilha.Pop();

                if (atual == objetivo)
                    return ReconstruirCaminho(anterior, objetivo);

                foreach (var vizinho in atual.Vizinhos.Keys)
                {
                    if (!anterior.ContainsKey(vizinho))
                    {
                        anterior[vizinho] = atual;
                        pilha.Push(vizinho);
                    }
                }
            }

            return null;
        }

        public List<Sala> BuscaGulosa(Sala inicio, Sala objetivo, Ambiente ambiente)
        {
            PriorityQueue<Sala, int> fila = new PriorityQueue<Sala, int>();
            Dictionary<Sala, Sala> anterior = new Dictionary<Sala, Sala>();
            fila.Enqueue(inicio, ambiente.DistanciaManhattan(inicio, objetivo));
            anterior[inicio] = null;

            while (fila.Count > 0)
            {
                Sala atual = fila.Dequeue();

                if (atual == objetivo)
                    return ReconstruirCaminho(anterior, objetivo);

                foreach (var vizinho in atual.Vizinhos.Keys)
                {
                    if (!anterior.ContainsKey(vizinho))
                    {
                        anterior[vizinho] = atual;
                        fila.Enqueue(vizinho, ambiente.DistanciaManhattan(vizinho, objetivo));
                    }
                }
            }

            return null;
        }

        public List<Sala> BuscaAEstrela(Sala inicio, Sala objetivo, Ambiente ambiente)
        {
            PriorityQueue<Sala, int> fila = new PriorityQueue<Sala, int>();
            Dictionary<Sala, Sala> anterior = new Dictionary<Sala, Sala>();
            Dictionary<Sala, int> custoAcumulado = new Dictionary<Sala, int>();

            fila.Enqueue(inicio, 0);
            anterior[inicio] = null;
            custoAcumulado[inicio] = 0;

            while (fila.Count > 0)
            {
                Sala atual = fila.Dequeue();

                if (atual == objetivo)
                    return ReconstruirCaminho(anterior, objetivo);

                foreach (var vizinho in atual.Vizinhos.Keys)
                {
                    int calculaCustoAcumulado = custoAcumulado[atual] + atual.Vizinhos[vizinho];

                    if (!custoAcumulado.ContainsKey(vizinho) || calculaCustoAcumulado < custoAcumulado[vizinho])
                    {
                        anterior[vizinho] = atual;
                        custoAcumulado[vizinho] = calculaCustoAcumulado;
                        int custoTotalEstimado = calculaCustoAcumulado + ambiente.DistanciaManhattan(vizinho, objetivo);
                        fila.Enqueue(vizinho, custoTotalEstimado);
                    }
                }
            }

            return null;
        }

        private List<Sala> ReconstruirCaminho(Dictionary<Sala, Sala> anterior, Sala objetivo)
        {
            List<Sala> caminho = new List<Sala>();
            for (Sala atual = objetivo; atual != null; atual = anterior[atual])
            {
                caminho.Add(atual);
            }
            caminho.Reverse();
            return caminho;
        }
    }
}
