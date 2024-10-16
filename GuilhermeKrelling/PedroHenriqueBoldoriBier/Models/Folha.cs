﻿using System.Text.Json.Serialization;

namespace PedroHenriqueBoldoriBier.Models;

public class Folha
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    public int Ano { get; set; }

    public int Mes { get; set; }
    public int FuncionarioId {get; set; }

    // [JsonIgnore]
    public Funcionario? funcionario {get; set; }

}
