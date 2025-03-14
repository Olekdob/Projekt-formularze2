namespace WebApplication1.Uslugi
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Options;
    using MimeKit;

    public class Poczta : IPoczta
    {
        //public OpcjePoczty Opcje { get; }

        /*public Poczta(IOptions<OpcjePoczty> opcje) //
        {
            Opcje = opcje.Value;
        }*/

        public Poczta()
        {
        }

        public async Task WyślijAsynchronicznie(Kontakt nadawca, Kontakt odbiorca, string temat, string treśćListu)
        {
            // rozwiązanie oparte o MailKit MemKit

            var message = new MimeMessage()
            {
                Subject = temat,
                Body = new TextPart("plain") { Text = "Witaj " + odbiorca.Nazwa + ", \n\n " + treśćListu },
            };
            message.From.Add(new MailboxAddress(nadawca.Nazwa, nadawca.Adres));
            message.To.Add(new MailboxAddress(odbiorca.Nazwa, odbiorca.Adres));

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                // znaczenie parametrów poniżej (sender, certificate, certChainType, errors)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //await client.ConnectAsync("poczta.nazwa.pl", 587, false).ConfigureAwait(false);
                await client.ConnectAsync("10.224.12.160", 587, false).ConfigureAwait(false);

                // Note: only needed if the SMTP server requires authentication
                //await client.AuthenticateAsync("osoba@poczta.pl", "hasło").ConfigureAwait(false); 

                // zablokowane  by działać na bramce bez autoryzacji....
                //await client.AuthenticateAsync(Opcje.UżytkownikPoczty, Opcje.KluczPoczty).ConfigureAwait(false);

                await client.SendAsync(message).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
