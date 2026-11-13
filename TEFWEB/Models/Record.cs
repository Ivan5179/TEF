namespace TEFWEB.Models; 

public record TodasPessoas(Guid Id, string Nome, string Senha, string Tipo);

public record PessoaEspecifica(Guid Id, string Nome, string Senha, string Tipo);
