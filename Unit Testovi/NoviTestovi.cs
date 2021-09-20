using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            StudentskiDom dom = new StudentskiDom(15);

            Student s = new Student();
            s.Skolovanje = new Skolovanje();
            s.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s, 0);

            IPodaci paviljon = new Paviljon();

            List<Student> studenti = dom.DajStudenteIzPaviljona(paviljon);

            Assert.IsTrue(studenti.Find(student => student.IdentifikacioniBroj == s.IdentifikacioniBroj) != null);
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestPrviCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(1, 1);

            Assert.AreEqual(1800, skolarina);
        }

        [TestMethod]
        public void TestDrugiCiklusStudija()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(2, 2);

            Assert.AreEqual(2000, skolarina);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNeispravniPodaci()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPromjenaGodineStudija3()
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }

        [TestMethod]
        public void TestSoba()
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Mirza", "password123", data, null, school);
            Assert.AreEqual(0, s.Stanari.Count);
            s.DodajStanara(student);
            Assert.AreEqual(1, s.Stanari.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDodajStanara()
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            Student student2 = new Student();
            s.DodajStanara(student1);
            s.DodajStanara(student2);

        }
        [TestMethod]
        public void TestIsprazniSobu()
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();

            s.DodajStanara(student1);
            Assert.AreNotEqual(0, s.Stanari.Count);
            s.IsprazniSobu();
            Assert.AreEqual(0, s.Stanari.Count);

        }

        [TestMethod]
        public void TestIzbaciStudenta()
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            s.DodajStanara(student1);
            Assert.AreNotEqual(0, s.Stanari.Count);
            s.IzbaciStudenta(student1);
            Assert.AreEqual(0, s.Stanari.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIzbaciStudenta2()
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Mirza", "password123", data, null, school);
            s.DodajStanara(student1);

            s.IzbaciStudenta(student);


        }
        [TestMethod]
        public void TestDaLiJeStanar()
        {
            Soba s = new Soba(1, 1);

            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Student", "Password654", data, null, school);
            s.DodajStanara(student);

            Assert.IsTrue(s.DaLiJeStanar(student));


        }
        [TestMethod]
        public void TestPromjenaBrojaSobe()
        {
            Soba s = new Soba(115, 2);
            s.PromjenaBrojaSobe(200);
            Assert.AreEqual(s.BrojSobe, 200);
        }
        [TestMethod]
        public void TestPromjenaBrojaSobe2()
        {
            Soba s = new Soba(100, 2);
            s.PromjenaBrojaSobe(200);
            Assert.AreEqual(s.Kapacitet, 3);
            s.PromjenaBrojaSobe(300);
            Assert.AreEqual(s.Kapacitet, 4);
            s.PromjenaBrojaSobe(150);
            Assert.AreEqual(s.Kapacitet, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPromjenaBrojaSobe3()
        {
            Soba s = new Soba(1, 3);
            Student student2 = new Student();
            Student student3 = new Student();
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Student", "Password654", data, null, school);
            Skolovanje skol = new Skolovanje();
            Assert.IsNotNull(skol.BrojIndeksa);
            s.DodajStanara(student);
            s.DodajStanara(student2);
            s.DodajStanara(student3);
            Assert.AreEqual(3, s.Stanari.Count);
            s.PromjenaBrojaSobe(101);
            Assert.AreEqual(2, s.Stanari.Count);
            s.PromjenaBrojaSobe(505);
        }


        [TestMethod]
        public void TestPRebivaliste()
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            //s.BrojSobe=2;
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            prebivaliste.Add("Zmaj od Bosne bb");

            Student student = new Student("Mirza", "password123", data, prebivaliste, school);
            Assert.AreEqual(1000, student.StanjeRacuna);
            Assert.IsNotNull(student.Podaci);
            Assert.AreEqual("Zmaj od Bosne bb", student.Prebivaliste[0]);
        }

        [TestMethod]
        public void TestStanjeRacuna()
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            //s.BrojSobe=2;
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Imee", "password123", data, null, school);
            Assert.AreEqual(1000, student.StanjeRacuna);

        }
        [TestMethod]
        public void TestAzurirajStanjeRacuna()
        {

            Student student = new Student("Imee", "password123", null, null, null);
            Assert.AreEqual(1000, student.StanjeRacuna);
            student.AzurirajStanjeRacuna(-50);
            Assert.AreEqual(950, student.StanjeRacuna);

        }


        [TestMethod]
        public void TestDajPaviljon()
        {
            Paviljon paviljon = new Paviljon();
            Assert.IsNotNull(paviljon.DajImePaviljona());
            Assert.AreEqual("ETF", paviljon.DajImePaviljona());

        }
        


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPromjenaPassworda2()
        {
            Korisnik student = new Student();
            student.Password = "Pass123";
            student.Username = "user";
            student.PromjenaPassworda("Pass123", " ");


        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPromjenaPassworda3()
        {
            Korisnik student = new Student();
            student.Password = "Pass123";
            student.Username = "user";
            student.PromjenaPassworda("pogresan", "Pass123");

        }

        [TestMethod]
        public void TestRadSaStudentom()
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 0);

            Assert.IsTrue(dom.Studenti.Count == 1);
        }


        [TestMethod]
        public void TestRadSaStudentom2()
        {
            var dom = new StudentskiDom(15);
            var soba = dom.Sobe[0];

            var kapacitet = soba.Kapacitet;

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.UpisUDom(s1, kapacitet, true);
            dom.RadSaStudentom(s1, 1);

            Assert.IsTrue(soba.Stanari.Count == 0);
        }

        [TestMethod]
        public void TestRadSaStudentom3()
        {
            var dom = new StudentskiDom(15);
            var soba = dom.Sobe[0];

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";


            dom.RadSaStudentom(s1, 0);
            dom.RadSaStudentom(s1, 2);

            Assert.IsTrue(dom.Studenti.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException), "Nemoguće dodati postojećeg studenta!")]
        public void TestRadSaStudentom4()
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 0);
            dom.RadSaStudentom(s1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Student nije stanar nijedne sobe!")]
        public void TestRadSaStudentom5()
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "Student nije prijavljen u dom!")]
        public void TestRadSaStudentom6()
        {
            var dom = new StudentskiDom(15);
            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";
            dom.RadSaStudentom(s1, 2);
        }



        [TestMethod]
        public void TestUpisUDom()
        {
            StudentskiDom dom = new StudentskiDom(2);
            Student student1 = new Student();
            Student student2 = new Student();
            dom.UpisUDom(student1, 3, true);
            dom.UpisUDom(student2, 3, true);
            Assert.AreEqual(2, dom.Sobe[0].Stanari.Count);

        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestUpisUDom2()
        {
            StudentskiDom dom = new StudentskiDom(0);
            Student student1 = new Student();
            Student student2 = new Student();

            dom.UpisUDom(student1, 4, true);
            dom.UpisUDom(student2, 4, true);


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestUpisUDom3()
        {
            StudentskiDom dom = new StudentskiDom(0);
            Student student1 = new Student();
            Student student2 = new Student();


            dom.UpisUDom(student1, 4, false);
            dom.UpisUDom(student2, 4, false);


        }

#endregion
    }
}
