using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domari;
using System;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class Zadatak3
    {
        #region Skolovanje
        [TestMethod]
        public void SkolovanjeIndeks()
        {
            Skolovanje skolovanje = new Skolovanje();
            skolovanje.BrojIndeksa = "123";
            Assert.AreEqual(skolovanje.BrojIndeksa, "123");
        }
        #endregion

        #region Stanar

        [TestMethod]
        public void BrojSobe()
        {
            Soba soba = new Soba(123, 2);
            Assert.AreEqual(soba.BrojSobe, 123);
        }

        [TestMethod]
        public void DodajStanaraImaMjesta()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            soba.DodajStanara(student1);
            Assert.AreEqual(soba.Stanari.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DodajStanaraNemaMjesta()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            soba.DodajStanara(student1);
            soba.DodajStanara(student2);
            soba.DodajStanara(student3);
        }

        [TestMethod]
        public void DaLiJeStanar()
        {
            Soba soba = new Soba(123, 2);
            Student student1 = new Student();
            Assert.IsFalse(soba.DaLiJeStanar(student1));
        }
        #endregion

        #region LicniPodaci
        [TestMethod]
        public void ProvjeraKadaJeKonstruktorKlaseLicniPodaciPrazan()
        {
            LicniPodaci licniPodaci = new LicniPodaci();
            Assert.AreEqual(licniPodaci.Ime, null);
            Assert.AreEqual(licniPodaci.Spol, Spol.Muško);
        }

        [TestMethod]
        public void ProvjeraKadaJeKonstruktorKlaseLicniPodaciSaParametrima()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
            Assert.AreEqual(licniPodaci.Ime, "Mirza");
            Assert.AreEqual(licniPodaci.Prezime, "Ziko");
            Assert.AreEqual(licniPodaci.MjestoRodjenja, "Konjic");
            Assert.AreEqual(licniPodaci.Email, "mziko2@etf.unsa.ba");
            Assert.AreEqual(licniPodaci.Slika, "postoji");
            Assert.AreEqual(licniPodaci.JMBG, "1505999151963");
            Assert.AreEqual(licniPodaci.Spol, Spol.Muško);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaImena()
        {
            LicniPodaci licniPodaci = new LicniPodaci(" ", "Ziko", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaPrezimena()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "ziKo", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaMjestRodjenja()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", " ", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaEmaila()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", "Konjic", "", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNeuspjesneUnosaJMBGa()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963123", Spol.Muško, DateTime.Parse("18.09.2021."));
        }
        #endregion

        #region StudenskiDom
        [TestMethod]
        public void RadSaStudentomNoviStudent()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            Assert.AreEqual(studentskiDom.Studenti.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void RadSaStudentomIstiStudent()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            studentskiDom.RadSaStudentom(student, 0);
        }

        [TestMethod]
        public void RadSaStudentomIzbaciStanar()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            Soba soba = studentskiDom.Sobe[0];
            soba.Stanari.Add(student);
            Assert.AreEqual(soba.Stanari.Count, 1);
            studentskiDom.RadSaStudentom(student, 1);
            Assert.AreEqual(soba.Stanari.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RadSaStudentomIzbaciNijeStanar()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 1);
        }

        [TestMethod]
        public void RadSaStudentomIzbrisi()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 0);
            Assert.AreEqual(studentskiDom.Studenti.Count, 1);
            studentskiDom.RadSaStudentom(student, 2);
            Assert.AreEqual(studentskiDom.Studenti.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void RadSaStudentomIzbrisiDrugog()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.RadSaStudentom(student, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpisDomNemaSobe()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 5, false);
        }

        [TestMethod]
        public void UpisDomSlobodna()
        {
            StudentskiDom studentskiDom = new StudentskiDom(5);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, false);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
        }

        [TestMethod]
        public void UpisDomZauzeta()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, false);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
            Student student2 = new Student();
            studentskiDom.UpisUDom(student2, 2, false);
            Assert.AreEqual(soba.Stanari.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void UpisDomZauzeteSveSobe()
        {
            StudentskiDom studentskiDom = new StudentskiDom(1);
            Student student = new Student();
            studentskiDom.UpisUDom(student, 2, true);
            Soba soba = studentskiDom.Sobe[0];
            Assert.AreEqual(soba.Stanari.Count, 1);
            Student student2 = new Student();
            studentskiDom.UpisUDom(student2, 2, true);
            Assert.AreEqual(soba.Stanari.Count, 2);
            Student student3 = new Student();
            studentskiDom.UpisUDom(student3, 2, true);
        }
        #endregion

        #region Student
        [TestMethod]
        public void StudentTest()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
            Skolovanje skolovanje = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            Student student = new Student("mziko2", "Mirza123", licniPodaci, prebivaliste, skolovanje);
            Assert.AreEqual(student.Podaci, licniPodaci);
            Assert.AreEqual(student.Prebivaliste, prebivaliste);
            Assert.AreEqual(student.StanjeRacuna, 1000.00);
        }

        [TestMethod]
        public void AzurirajStanje()
        {
            LicniPodaci licniPodaci = new LicniPodaci("Mirza", "Ziko", "Konjic", "mziko2@etf.unsa.ba", "postoji", "1505999151963", Spol.Muško, DateTime.Parse("18.09.2021."));
            Skolovanje skolovanje = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            Student student = new Student("mziko2", "Mirza123", licniPodaci, prebivaliste, skolovanje);
            Assert.AreEqual(student.StanjeRacuna, 1000.00);
            student.AzurirajStanjeRacuna(200.00);
            Assert.AreEqual(student.StanjeRacuna, 1200.00);
        }
        #endregion

        #region Soba
        static IEnumerable<object[]> DataKadaSuPodaciDobri
        {
            get
            {
                return new[]
                {
                new object[] { 1, 2 },
                new object[] { 2, 3 },
                new object[] { 3, 4 }
                };
            }

        }

        [TestMethod]
        [DynamicData("DataKadaSuPodaciDobri")]
        public void DataDrivenTestiranje(int id, int kapacitet)
        {
            Soba soba = new Soba(id, kapacitet);
            Assert.AreEqual(id, soba.BrojSobe);
            Assert.AreEqual(kapacitet, soba.Kapacitet);
        }
        #endregion
    }
}