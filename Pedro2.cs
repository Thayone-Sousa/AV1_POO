using System;
using System.Collections.Generic;

abstract class Mensagem
{
    public string Texto { get; set; }
    public DateTime DataEnvio { get; set; }

    public Mensagem(string texto)
    {
        Texto = texto;
        DataEnvio = DateTime.Now;
    }

    public abstract void Exibir();
}

class MensagemTexto : Mensagem
{
    public MensagemTexto(string texto) : base(texto) { }

    public override void Exibir()
    {
        Console.WriteLine($"[Texto] {Texto} - Enviado em: {DataEnvio}");
    }
}

class MensagemVideo : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }
    public double Duracao { get; set; }

    public MensagemVideo(string texto, string arquivo, string formato, double duracao)
        : base(texto)
    {
        Arquivo = arquivo;
        Formato = formato;
        Duracao = duracao;
    }

    public override void Exibir()
    {
        Console.WriteLine($"[Vídeo] {Texto} - Arquivo: {Arquivo}, Formato: {Formato}, Duração: {Duracao}s - Enviado em: {DataEnvio}");
    }
}

class MensagemFoto : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }

    public MensagemFoto(string texto, string arquivo, string formato)
        : base(texto)
    {
        Arquivo = arquivo;
        Formato = formato;
    }

    public override void Exibir()
    {
        Console.WriteLine($"[Foto] {Texto} - Arquivo: {Arquivo}, Formato: {Formato} - Enviado em: {DataEnvio}");
    }
}

class MensagemArquivo : Mensagem
{
    public string Arquivo { get; set; }
    public string Formato { get; set; }

    public MensagemArquivo(string texto, string arquivo, string formato)
        : base(texto)
    {
        Arquivo = arquivo;
        Formato = formato;
    }

    public override void Exibir()
    {
        Console.WriteLine($"[Arquivo] {Texto} - Arquivo: {Arquivo}, Formato: {Formato} - Enviado em: {DataEnvio}");
    }
}

abstract class Canal
{
    public string Destinatario { get; set; }

    public Canal(string destinatario)
    {
        Destinatario = destinatario;
    }

    public abstract void Enviar(Mensagem mensagem);
}

class WhatsApp : Canal
{
    public WhatsApp(string numeroTelefone) : base(numeroTelefone) { }

    public override void Enviar(Mensagem mensagem)
    {
        Console.WriteLine($"Enviando via WhatsApp para {Destinatario}");
        mensagem.Exibir();
    }
}

class Telegram : Canal
{
    public Telegram(string contato) : base(contato) { }

    public override void Enviar(Mensagem mensagem)
    {
        Console.WriteLine($"Enviando via Telegram para {Destinatario}");
        mensagem.Exibir();
    }
}

class Facebook : Canal
{
    public Facebook(string usuario) : base(usuario) { }

    public override void Enviar(Mensagem mensagem)
    {
        Console.WriteLine($"Enviando via Facebook para {Destinatario}");
        mensagem.Exibir();
    }
}

class Instagram : Canal
{
    public Instagram(string usuario) : base(usuario) { }

    public override void Enviar(Mensagem mensagem)
    {
        Console.WriteLine($"Enviando via Instagram para {Destinatario}");
        mensagem.Exibir();
    }
}

class Program
{
    static void Main()
    {
        List<Canal> canais = new List<Canal>
        {
            new WhatsApp("+5511999999999"),
            new Telegram("@usuarioTelegram"),
            new Facebook("usuarioFacebook"),
            new Instagram("usuarioInstagram")
        };

        Mensagem msgTexto = new MensagemTexto("Olá, tudo bem?");
        Mensagem msgVideo = new MensagemVideo("Confira esse vídeo!", "video.mp4", "mp4", 120);
        Mensagem msgFoto = new MensagemFoto("Veja essa foto!", "foto.jpg", "jpg");
        Mensagem msgArquivo = new MensagemArquivo("Segue o arquivo.", "documento.pdf", "pdf");

        foreach (var canal in canais)
        {
            canal.Enviar(msgTexto);
            canal.Enviar(msgVideo);
            canal.Enviar(msgFoto);
            canal.Enviar(msgArquivo);
            Console.WriteLine("------------------------------");
        }
    }
}
