using System;
using System.Linq;
public class Evento
{
    public string Id;
    public string Titulo;
    public DateTime Data;
    public DateTime HoraIni;
    public DateTime HoraFim;
    public string Descricao;
    public int QuantidadePessoas;
    public string PublicoAlvo;
    public Contato Responsavel;

    public Evento(string titulo, DateTime data, DateTime horaInicial, DateTime horaFinal, string descricao,
                  int quantidadePessoas, string publicoAlvo, Contato contatoResponsavel)
    {
        Titulo = titulo;
        Data = data;
        HoraIni = horaInicial;
        HoraFim = horaFinal;
        Descricao = descricao;
        QuantidadePessoas = quantidadePessoas;
        PublicoAlvo = publicoAlvo;
        Responsavel = contatoResponsavel;

        Id = GerarId();
    }

    private string GerarId()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}