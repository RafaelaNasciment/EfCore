using System;
using System.Collections.Generic;

namespace Infraestruture.Scaffold;

public partial class Livro
{
    public int Id { get; set; }

    public string Editora { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
