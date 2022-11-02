using WebApiRest.Model;

namespace WebApiRest.Services.Implementations
{
    public class PessoaServiceImplementation : IPessoaService
    {
        private volatile int count;

        public Pessoa Create(Pessoa pessoa)
        {
            return pessoa;
        }

        public void Delete(long id)
        {
            
        }

        public List<Pessoa> FindAll()
        {   
            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                pessoas.Add(pessoa);
            }
            return pessoas;
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                Id = IncrementAndGet(),
                PrimeiroNome = "Fulano" + i,
                Sobrenome = "de Tal" + i,
                Endereco = "Vitória - ES - BR",
                Genero = "Male"
            };        
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Pessoa FindById(long Id)
        {
            return new Pessoa
            {
                Id = IncrementAndGet(),
                PrimeiroNome = "Fulano",
                Sobrenome = "de Tal",
                Endereco = "Vitória - ES - BR",
                Genero = "Male"
            };

        }

        public Pessoa Update(Pessoa pessoa)
        {
            return pessoa;
        }
    }
}
