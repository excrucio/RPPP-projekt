using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaMedia
{
    class Proces
    {
        private int IDProcesa;
        private int Br;
        private string Ime;
        private string Clasa;
        private string Oznk;
        private string Optuznic;
        private string Court;

        public string Naziv
        {
            get { return Ime; }
            set { Ime = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }

        public int Broj
        {
            get { return Br; }
            set { Br = value; }
        }

        public string Klasa
        {
            get { return Clasa; }
            set { Clasa = value; }
        }

        public string Oznaka
        {
            get { return Oznk; }
            set { Oznk = value; }
        }

        public string Optuznica
        {
            get { return Optuznic; }
            set { Optuznic = value; }
        }

        public string Sud
        {
            get { return Court; }
            set { Court = value; }
        }
    }
    class Osoba
    {
        private int IDOsobe;
        private string OIBroj;
        private string UlicaIKBr;
        private int PBr;

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public string OIB
        {
            get { return OIBroj; }
            set { OIBroj = value; }
        }

        public string UlicaIKucniBroj
        {
            get { return UlicaIKBr; }
            set { UlicaIKBr = value; }
        }

        public int PostanskiBroj
        {
            get { return PBr; }
            set { PBr = value; }
        }
    }

    class Mjesto
    {
        private int PBr;
        private string Ime;

        public int PostanskiBroj
        {
            get { return PBr; }
            set { PBr = value; }
        }

        public string Naziv
        {
            get { return Ime; }
            set { Ime = value; }
        }
    }

    class FizickaOsoba
    {
        private int IDOsobe;
        private string Name;
        private string Surname;
        private string ImeOca;
        private DateTime Date;
        private string JMBGBroj;
        private string Poslodavac;

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public string Ime
        {
            get { return Name; }
            set { Name = value; }
        }

        public string Prezime
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public string ImeOtac
        {
            get { return ImeOca; }
            set { ImeOca = value; }
        }

        public DateTime Datum
        {
            get { return Date; }
            set { Date = value; }
        }

        public string JMBG
        {
            get { return JMBGBroj; }
            set { JMBGBroj = value; }
        }
    }

    class PravnaOsoba
    {
        private int IDOsobe;
        private string Name;
        private string MBroj;

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public string Ime
        {
            get { return Name; }
            set { Name = value; }
        }

        public string MaticniBroj
        {
            get { return MBroj; }
            set { MBroj = value; }
        }
    }

    class SudskoVijece
    {
        private int IDSudskogVijeca;
        private int IDOsobe;
        private int IDProcesa;
        private bool Predsjedavatelj;

        public int IDSudskoVijece
        {
            get { return IDSudskogVijeca; }
            set { IDSudskogVijeca = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }

        public bool PredsjedavateljZastavica
        {
            get { return Predsjedavatelj; }
            set { Predsjedavatelj = value; }
        }
    }

    class Tuzitelj
    {
        private int IDTuzitelja;
        private int IDOsobe;
        private int IDProcesa;

        public int IDTuzitelj
        {
            get { return IDTuzitelja; }
            set { IDTuzitelja = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }
    }

    class Svjedok
    {
        private int IDSvjedoka;
        private int IDOsobe;
        private int IDProcesa;

        public int IDSvjedok
        {
            get { return IDSvjedoka; }
            set { IDSvjedoka = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }
    }

    class Branitelj
    {
        private int IDBranitelja;
        private int IDOsobe;
        private int IDOptuzenika;

        public int IDBranitelj
        {
            get { return IDBranitelja; }
            set { IDBranitelja = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDOptuzenik
        {
            get { return IDOptuzenika; }
            set { IDOptuzenika = value; }
        }
    }

    class Optuzenik
    {
        private int IDOptuzenika;
        private int IDOsobe;
        private int IDProcesa;

        public int IDOptuzenik
        {
            get { return IDOptuzenika; }
            set { IDOptuzenika = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }
    }

    class Ostecenik
    {
        private int IDOstecenika;
        private int IDOsobe;
        private int IDProcesa;

        public int IDOptuzenik
        {
            get { return IDOstecenika; }
            set { IDOstecenika = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }
    }

    class Rociste
    {
        private int IDRocista;
        private int IDProcesa;
        private DateTime Date;
        private DateTime Trajanj;
        private string Predstavnik;

        public int IDRociste
        {
            get { return IDRocista; }
            set { IDRocista = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }

        public DateTime Datum
        {
            get { return Date; }
            set { Date = value; }
        }

        public DateTime Trajanje
        {
            get { return Trajanj; }
            set { Trajanj = value; }
        }

        public string Predsjedavatelj
        {
            get { return Predstavnik; }
            set { Predstavnik = value; }
        }
    }

    class Sudionik
    {
        private int IDSudionika;
        private int IDOsobe;
        private int IDRocista;
        private string Role;

        public int IDSudionik
        {
            get { return IDSudionika; }
            set { IDSudionika = value; }
        }

        public int IDOsoba
        {
            get { return IDOsobe; }
            set { IDOsobe = value; }
        }

        public int IDRociste
        {
            get { return IDRocista; }
            set { IDRocista = value; }
        }

        public string Uloga
        {
            get { return Role; }
            set { Role = value; }
        }
    }

    class UlogaSudionika
    {
        private int SifraUloge;
        private string NazivUloga;

        public int SifraUloga
        {
            get { return SifraUloge; }
            set { SifraUloge = value; }
        }

        public string NazivUloge
        {
            get { return NazivUloga; }
            set { NazivUloga = value; }
        }
    }

    class VrstaSpisa
    {
        private int SifraVrst;
        private string Naziv;

        public int SifraVrste
        {
            get { return SifraVrst; }
            set { SifraVrst = value; }
        }
    }

    class StavkaSpisa
    {
        private int IDStavak;
        private string NazivStavka;
        private string VrstaSpis;
        private int IDProcesa;
        private DateTime DatumUnosa;
        private Blob Dokument;

        public int IDStavke
        {
            get { return IDStavak; }
            set { IDStavak = value; }
        }

        public string NazivStavak
        {
            get { return NazivStavka; }
            set { NazivStavka = value; }
        }

        public string VrstaSpisa
        {
            get { return VrstaSpis; }
            set { VrstaSpis = value; }
        }

        public int IDProces
        {
            get { return IDProcesa; }
            set { IDProcesa = value; }
        }

        public DateTime DatumUnos
        {
            get { return DatumUnosa; }
            set { DatumUnosa = value; }
        }

        public void ImeDatotekeUnos(string a)
        {
            Dokument.ImeDatoteke = a;
        }

        public void PodaciDatotekeUnos(byte[] Data)
        {
            Dokument.Podaci = Data;
        }

        public string DajImeDatoteke()
        {
            return Dokument.ImeDatoteke;
        }

        public byte[] DajPodatkeDatoteke()
        {
            return Dokument.Podaci;
        }
    }

    class Presuda
    {
        private int IDStavka;
        private Blob Dokument;
        private string TipPresuda;

        public int IDStavke
        {
            get { return IDStavka; }
            set { IDStavka = value; }
        }

        public string TipPresude
        {
            get { return TipPresuda; }
            set { TipPresuda = value; }
        }

        public void ImeDatotekeUnos(string a)
        {
            Dokument.ImeDatoteke = a;
        }

        public void PodaciDatotekeUnos(byte[] Data)
        {
            Dokument.Podaci = Data;
        }

        public string DajImeDatoteke()
        {
            return Dokument.ImeDatoteke;
        }

        public byte[] DajPodatkeDatoteke()
        {
            return Dokument.Podaci;
        }
    }

    class Kazna
    {
        private int IDKazna;
        private int IDPresuda;
        private int IDOsoba;
        private string Tip;
        private decimal Cifra;
        private string Description;

        public int IDKazne
        {
            get { return IDKazna; }
            set { IDKazna = value; }
        }

        public int IDPresude
        {
            get { return IDPresuda; }
            set { IDPresuda = value; }
        }

        public int IDOsobe
        {
            get { return IDOsoba; }
            set { IDOsoba = value; }
        }

        public string Vrsta
        {
            get { return Tip; }
            set { Tip = value; }
        }

        public decimal Iznos
        {
            get { return Cifra; }
            set { Cifra = value; }
        }

        public string Opis
        {
            get { return Description; }
            set { Description = value; }
        }
    }

    class VrstaKazne
    {
        private int SifraKazna;
        private string NazivVrsta;

        public int SifraKazne
        {
            get { return SifraKazna; }
            set { SifraKazna = value; }
        }

        public string NazivVrste
        {
            get { return NazivVrsta; }
            set { NazivVrsta = value; }
        }
    }

    class Blob
    {
        private string ImeDat;
        private byte[] Data;
        public string ImeDatoteke
        {
            get { return ImeDat; }
            set { ImeDat = value; }
        }
        public byte[] Podaci
        {
            get { return Data; }
            set { Data = value; }
        }
    }

     class Zakon
    {
        private int IDZakon;
        private string Naziv;
        private string Razina;
        private int IDNadredjeni;
        Blob Dokument;
        public int IDZakona
        {
            get { return IDZakon; }
            set { IDZakon = value; }
        }
        public string NazivZakona
        {
            get { return Naziv; }
            set { Naziv = value; }
        }
        public string RazinaZakona
        {
            get { return Razina; }
            set { Razina = value; }
        }
        public int IDNadredjenog
        {
            get { return IDNadredjeni; }
            set { IDNadredjeni = value; }
        }
        public void ImeDatotekeUnos(string a)
        {
            Dokument.ImeDatoteke = a;
        }

        public void PodaciDatotekeUnos(byte[] Data)
        {
            Dokument.Podaci = Data;
        }

        public string DajImeDatoteke()
        {
            return Dokument.ImeDatoteke;
        }

        public byte[] DajPodatkeDatoteke()
        {
            return Dokument.Podaci;
        }
    }

    class Sud
    {
        private int IDSud;
        private string Ime;
        private string UlicaIKBr;
        private int Pbr;
        private string Category;
        private string Nadredjeni;

        public int IDSuda
        {
            get { return IDSud; }
            set { IDSud = value; }
        }

        public string Naziv
        {
            get { return Ime; }
            set { Ime = value; }
        }

        public string UlicaIKucniBroj
        {
            get { return UlicaIKBr; }
            set { UlicaIKBr = value; }
        }

        public int PostanskiBroj
        {
            get { return Pbr; }
            set { Pbr = value; }
        }

        public string Kategorija
        {
            get { return Category; }
            set { Category = value; }
        }

        public string Nadredeni
        {
            get { return Nadredjeni; }
            set { Nadredjeni = value; }
        }
    }

    class KategorijaSuda
    {
        private int Sifra;
        private string NazivKategorija;

        public int SifraKategorijeSuda
        {
            get { return Sifra; }
            set { Sifra = value; }
        }

        public string NazivKategorijeSuda
        {
            get { return NazivKategorija; }
            set { NazivKategorija = value; }
        }
    }

    class TipPresude
    {
        private int Sifra;
        private string Naziv;

        public int SifraTipa
        {
            get { return Sifra; }
            set { Sifra = value; }
        }

        public string NazivTipa
        {
            get { return Naziv; }
            set { Naziv = value; }
        }
    }

    class OsnovaProcesa
    {
        private int IDProces;
        private int IDZakon;

        public int IDProcesa
        {
            get { return IDProces; }
            set { IDProces = value; }
        }

        public int IDZakona
        {
            get { return IDZakon; }
            set { IDZakon = value; }
        }
    }

    class Optuzba
    {
        private int IDOptuzba;
        private int IDOptuzenik;
        private int IDZakon;
        private int IDPresuda;

        public int IDOptuzbe
        {
            get { return IDOptuzba; }
            set { IDOptuzba = value; }
        }

        public int IDOptuzenika
        {
            get { return IDOptuzenik; }
            set { IDOptuzenik = value; }
        }

        public int IDZakona
        {
            get { return IDZakon; }
            set { IDZakon = value; }
        }

        public int IDPresude
        {
            get { return IDPresuda; }
            set { IDPresuda = value; }
        }
    }

}