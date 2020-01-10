using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    class GestaoDeEscritoresViewModel
    {
        ObservableCollection<Escritor> _escritores;
        Escritor _escritor;

        public Escritor SelectedEscritor
        {
            get
            {
                return _escritor;
            }
            set
            {
                _escritor = value;
            }
        }
        public GestaoDeEscritoresViewModel()
        {
            List<Escritor> lista = Escritor.ReadAll();
            if (lista == null)
            {
                Escritor.CreateTable();
                Filme_escritor.CreateTable();
                _escritores = new ObservableCollection<Escritor>();
            }
            else
            {
                _escritores = new ObservableCollection<Escritor>(lista);
            }
        }
        public ObservableCollection<Escritor> Escritores
        {
            get
            {
                return _escritores;

            }
            set
            {
                _escritores = value;
            }

        }

        public bool CreateEscritor(Escritor e)
        {
            if (e.Create() == 1)
            {
                Escritores.Add(e);
                return true;
            }
            return false;
        }
        public bool UpdateEscritor()
        {
            if (SelectedEscritor.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public int DeleteEscritor()
        {
            int ret = SelectedEscritor.Delete();
            if (ret == 1)
            {
                if (SelectedEscritor.Idescritor == Escritores.Count)
                {
                    Escritores.Remove(SelectedEscritor);
                    Escritor.ReSeed(Escritores.Count);
                }
                else
                {

                    foreach (Escritor e in Escritores)
                    {
                        if (e.Idescritor > SelectedEscritor.Idescritor)
                            e.Idescritor -= 1;
                    }
                    Escritores.Remove(SelectedEscritor);
                    Escritor.CreateFromObservableCollection(Escritores);
                }
            }
            return ret;
        }

        public bool Add_Linha()
        {
            Escritor e = new Escritor();
            e.Idescritor = Escritores.Count + 1;
            return CreateEscritor(e);
        }
    }
}
