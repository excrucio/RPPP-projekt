using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ManuelaKajkara;

namespace UgovoriKlase
{
    [ServiceContract]
    public interface IFirmaServis
    {
        #region Manuela
        [OperationContract]
        List<UgovoriKlase.Sud> PopisSudova();

        [OperationContract]
        UgovoriKlase.Sud DohvatiJedan(int id);

        [OperationContract]
        List<UgovoriKlase.Kategorija> PopisKategorija();

        [OperationContract]
        List<UgovoriKlase.Mjesto> PopisMjesta();

        [OperationContract]
        void ObrisiSud(int id);

        [OperationContract]
        void DodajNoviSud(int id, string naziv, string adresa, int pbr, int kategorija);

        [OperationContract]
        void UrediSud(int id, string naziv, string adresa, int pbr, int kategorija);

        #endregion

        #region Ivan

        [OperationContract]
        List<ManuelaKajkara.FizOsoba> DajSveFizickeOsobe();
        [OperationContract]
        ManuelaKajkara.FizOsoba DajFizickuOsobu(int ID);
        [OperationContract]
        void UnesiFizickuOsobu(ManuelaKajkara.FizOsoba osoba);
        [OperationContract]
        void PromijeniFizickuOsobu(ManuelaKajkara.FizOsoba osoba);
        [OperationContract]
        void ObrisiFizickuOsobu(int ID);
        #endregion

        #region Josip

        [OperationContract]
        List<ManuelaKajkara.Kazna> DajSveKazne();
        [OperationContract]
        ManuelaKajkara.Kazna DajKaznu(int ID);
        [OperationContract]
        void UnesiKaznu(ManuelaKajkara.Kazna kazna);
        [OperationContract]
        void PromijeniKaznu(ManuelaKajkara.Kazna kazna);
        [OperationContract]
        void ObrisiKaznu(int ID);

        #endregion
    }
}
