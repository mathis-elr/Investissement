namespace Investissement
{
    public class SyntheseDetentionActif
    {
        public string nomActif { get; set; }
        public string symboleActif { get; set; }
        public string typeActif { get; set; }
        public double quantiteTotaleDetenue { get; set; }

        public SyntheseDetentionActif(string nom, string symbole, string type, double quantiteTotaleDetenue)
        {
            this.nomActif = nom;
            this.typeActif = type;
            this.symboleActif = symbole;
            this.quantiteTotaleDetenue = quantiteTotaleDetenue;
        }
    }
}
