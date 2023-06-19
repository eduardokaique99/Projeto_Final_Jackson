namespace Model
  {
  public class Turno
    {
        public int Id {get ; set;}
        public string Periodo {get; set;}
        private int Escala {get; set;}
        public int IdEstacionamento {get; set;}

        public Turno(string Nome, int CPF, int PIS)
        {
            Periodo = periodo;
            Escala = escala;
            IdEstacionamento = idEstacionamento;
        }

        public Turno()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Período: {Periodo}, Escala: {Escala}, IdEstacionamento: {IdEstacionamento}";
        }

        public override bool Equals (object obj)
        {
            Turno turno = (Turno)obj;
            return Id == turno.Id;
        }

        public static Model.Turno CriarTurno(
            string Periodo,
            int Escala,
            int IdEstacionamento
        ){
            return new Model.Turno(
                periodo,
                escala,
                idEstacionamento
            );
        }

        public static Model.Turno AlterarTurno(
            int id,
            string periodo,
            int escala,
            int idEstacionamento
        )
        {
            Turno turno = BuscarTurno(
                id
            );

            turno.Periodo = periodo;
            turno.Escala = escala;

            Repository.Context context = new Repository.Context();
            context.Turnos.Update(turno);
            contexto.SaveChanges();

            return turno;
        }

        public static Turno ExcluirTurno(
            int id
        )
        {
            Turno turno = BuscarTurno(
                id
            );

            Repository.Context context = new Repository.Context();
            context.Turnos.Remove(turno);
            context.SaveChanges();

            return turno;
        }

        public static Turno BuscarTurno(
            int id
        )
        {
            Repository.Context context = new Repository.Context();
            return (
                from a in context.Turnos
                where a.Id == id
                select a
            ).First();
        }

        public static IEnumerable<Turno> BuscarTodos()
        {
            Repository.Context context = new Repository.Context();
            return (
                from a in context.Turnos
                select a
            );
        } 
    }
}