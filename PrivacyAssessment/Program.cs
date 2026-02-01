namespace PrivacyAssessment
{
    /// <summary>
    /// A GPT-based Assessment of Privacy Legal Frameworks under ISO/IEC 27701:2025: A Latin American Case Study
    /// This research is part of the project "PRIVIA: Identificación Automatizada de Brechas de Privacidad en Ecuador usando Inteligencia Artificial Generativa y LLMs" conducted by Escuela Politécnica Nacional.
    /// Quito, Ecuador
    /// 2026
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStart());
            Application.Run(new FrmMain());
        }
    }
}