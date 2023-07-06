

namespace Models
  {
  public class Veiculo
    {
        public int Id {get ; set;}
        public string Placa {get; set;}
        public int IdMovimentacao {get; set;}
        public int IdTipo {get; set;}
        public int IdCartao {get; set;}

        public Veiculo(string placa, int idmovimentacao, int idtipo, int idcartao)
        {
            Placa = placa;
            IdMovimentacao = idmovimentacao;
            IdTipo = idtipo;
            IdCartao = idcartao;
        }

        public Veiculo()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Placa: {Placa}, Id da Movimentação: {IdMovimentacao}, Id do Tipo: {IdTipo}, Id do Cartão: {IdCartao}";
        }

        public override bool Equals (object obj)
        {
            Veiculo veiculo = (Veiculo)obj;
            return Id == veiculo.Id;
        }

        public static Models.Veiculo CriarVeiculo(
            int Id,
            string Placa,
            int IdMovimentacao,
            int IdTipo,
            int IdCartao
        ){
            return new Models.Veiculo(
              
                Placa,
                IdMovimentacao,
                IdTipo,
                IdCartao
            );
        }

        public static Models.Veiculo AlterarVeiculo(
            int Id,
            string Placa,
            int IdMovimentacao,
            int IdTipo,
            int IdCartao
        )
        {
            Veiculo veiculo = BuscarVeiculo(
                Id
            );

            veiculo.Placa = Placa;

            Repository.Context context = new Repository.Context();
            context.Veiculos.Update(veiculo);
            context.SaveChanges();

            return veiculo;
        }

        public static Veiculo ExcluirVeiculo(
            int id
        )
        {
            Veiculo veiculo = BuscarVeiculo(
                id
            );

            Repository.Context context = new Repository.Context();
            context.Veiculos.Remove(veiculo);
            context.SaveChanges();

            return veiculo;
        }

        public static Veiculo BuscarVeiculo(
            int id
        )
        {
            Repository.Context context = new Repository.Context();
            return (
                from a in context.Veiculos
                where a.Id == id
                select a
            ).First();
        }

        public static IEnumerable<Veiculo> BuscarTodos()
        {
            Repository.Context context = new Repository.Context();
            return (
                from a in context.Veiculos
                select a
            );
        }
         
    }
}