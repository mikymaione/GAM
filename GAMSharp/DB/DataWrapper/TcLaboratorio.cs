using NUnit.Framework;
using GAMSharp.DB.DataWrapper.Tabelle;

namespace GAMSharp.DB.DataWrapper
{
    [TestFixture]
    public class TcLaboratorio
    {

        private cLaboratorio cLaboratorio = new cLaboratorio();

        [Test]
        public void Caricamento()
        {
            var R = cLaboratorio.Ricerca(new Laboratorio());
            Assert.AreEqual(R.Errore, false, R.Eccezione.Message);

            foreach (var lab1 in R.Risultato)
            {
                var lab2 = cLaboratorio.Carica(lab1.ID);
                Assert.AreSame(lab1, lab2);
            }
        }


    }
}