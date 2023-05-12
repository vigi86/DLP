using System.ComponentModel;

namespace DLP_Win
{
    /// <summary>
    /// Die Ruleset-Klasse definiert ein Ruleset-Objekt.
    /// </summary>
    class Ruleset
    {
        /// <summary>
        /// Index der Rule
        /// </summary>
        [DisplayName("Index")]
        public uint Index { get; set; }

        /// <summary>
        /// Falls: "Aktueller User", "Datei-Inhalt", "Datei-Name", "Inhalt", "Klassifizierung"
        /// </summary>
        [DisplayName("Falls ...")]
        public string If { get; set; }

        /// <summary>
        /// Auswahl für "==", "!=", "REGEX", "enthält", "enthält nicht"
        /// </summary>
        [DisplayName("Selektion")]
        public string Contains { get; set; }

        /// <summary>
        /// Textfeld-Eingabe für Bedingung
        /// </summary>
        [DisplayName("Bedingung")]
        public string Condition { get; set; }

        /// <summary>
        /// Dann: "Blockieren", "Notifizieren", "In Quarantäne verschieben", "Monitoren und Loggen"
        /// </summary>
        [DisplayName("dann ...")]
        public string Then { get; set; }
    }

}
