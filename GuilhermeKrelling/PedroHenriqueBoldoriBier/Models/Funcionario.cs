using System.Text.Json.Serialization;

namespace PedroHenriqueBoldoriBier.Models;

public class Funcionario
{
    public int FuncionarioId { get; set; }

    public string? Nome { get ; set;}

    public string? Cpf { get ; set;}

    public ICollection<Folha> Folhas { get; set; } = new List<Folha>();

    // [JsonIgnore]
    // public Folha? folha {get; set; }

}
