using System.ComponentModel;

namespace DLP_Win
{
	/// <summary>
	/// Die Ruleset-Klasse definiert ein Ruleset-Objekt.
	/// </summary>
	internal class Ruleset
	{
		/// <summary>
		/// Index der Rule
		/// </summary>
		[DisplayName("Index")]
		public uint Index { get; set; }

		/// <summary>
		/// Falls: "Datei-Inhalt", "Datei-Name"
		/// </summary>
		[DisplayName("Falls ...")]
		public string If { get; set; }

		/// <summary>
		/// Auswahl für "enthält", "enthält nicht", "REGEX"
		/// </summary>
		[DisplayName("Selektion")]
		public string SelectionType { get; set; }

		/// <summary>
		/// Textfeld-Eingabe für Bedingung
		/// </summary>
		[DisplayName("Bedingung")]
		public string Condition { get; set; }

		/// <summary>
		/// Dann: "Notifizieren", "In Quarantäne verschieben", "Loggen"
		/// </summary>
		[DisplayName("dann ...")]
		public string Then { get; set; }
	}

}
