namespace WebApplication1.Uslugi
{
    public interface IPoczta
    {
        Task WyślijAsynchronicznie(Kontakt nadawca, Kontakt odbiorca, string temat, string treśćListu);
    }
}
