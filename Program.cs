
class Labirinto
{
    private const int limit = 15;


    static void mostrarLabirinto(char[,] array, int l, int c)
    {
        for (int i = 0; i < l; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < c; j++)
            {
                Console.Write($" {array[i, j]} ");
            }
        }
        Console.WriteLine();
    }


    static void criaLabirinto(char[,] meuLab)
    {
        Random random = new Random();
        for (int i = 0; i < limit; i++)
        {
            for (int j = 0; j < limit; j++)
            {
                meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
            }
        }


        for (int i = 0; i < limit; i++)
        {
            meuLab[0, i] = '*';
            meuLab[limit - 1, i] = '*';
            meuLab[i, 0] = '*';
            meuLab[i, limit - 1] = '*';
        }


        int x = random.Next(limit);
        int y = random.Next(limit);
        meuLab[x, y] = 'Q';
    }


    static bool buscarQueijo(char[,] meuLab, int i, int j)
    {
        Stack<int[]> minhaPilha = new Stack<int[]>();

        do
        {
            
            if (meuLab[i, j] == 'Q')
            {
                Console.WriteLine("Queijo Encontrado!");
                return true; 
            }

            meuLab[i, j] = 'v'; 
            mostrarLabirinto(meuLab, meuLab.GetLength(0), meuLab.GetLength(1));

            // Verifica se pode mover para direita
            if (j + 1 < limit && (meuLab[i, j + 1] == '.' || meuLab[i, j + 1] == 'Q'))
            {
                minhaPilha.Push(new int[] { i, j }); // Empilha a posição atual
                j++;
            }
            // Verifica se pode mover para baixo
            else if (i + 1 < limit && (meuLab[i + 1, j] == '.' || meuLab[i + 1, j] == 'Q'))
            {
                minhaPilha.Push(new int[] { i, j });
                i++;
            }
            // Verifica se pode mover para esquerda
            else if (j - 1 >= 0 && (meuLab[i, j - 1] == '.' || meuLab[i, j - 1] == 'Q'))
            {
                minhaPilha.Push(new int[] { i, j });
                j--;
            }
            // Verifica se pode mover para cima
            else if (i - 1 >= 0 && (meuLab[i - 1, j] == '.' || meuLab[i - 1, j] == 'Q'))
            {
                minhaPilha.Push(new int[] { i, j });
                i--;
            }
            else if (minhaPilha.Count > 0) // Se a pilha não estiver vazia, retrocede para a última posição empilhada
            {
                int[] posicao = minhaPilha.Pop();
                meuLab[i, j] = 'x';
                i = posicao[0]; 
                j = posicao[1];
            }
            else
            {
                Console.WriteLine("Impossível encontrar o queijo!");
                return false;
            }

            System.Threading.Thread.Sleep(200);
            Console.Clear();
           // mostrarLabirinto(meuLab, limit, limit);


        } while (true); 
    }


    static void Main(String[] args)
    {
        char[,] labirinto = new char[limit, limit];
        criaLabirinto(labirinto);
        mostrarLabirinto(labirinto, limit,limit);

        buscarQueijo(labirinto, 1, 1);
        Console.ReadKey();
       
    }
}
