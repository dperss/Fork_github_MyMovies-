using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovies.BL;


namespace MyMovies.universal.ViewModel
{
    public class GestaoDeAtoresViewModel
    {
        ObservableCollection<Ator> _atores;
        Ator _ator;

        public Ator SelectedAtor
        {
            get
            {
                return _ator;
            }
            set
            {
                _ator = value;
            }
        }
        public GestaoDeAtoresViewModel()
        {
            List<Ator> lista = Ator.ReadAll();
            if (lista == null)
            {
                Ator.CreateTable();
                _atores = new ObservableCollection<Ator>();
            }
            else
            {
                _atores = new ObservableCollection<Ator>(lista);
            }
        }
        public ObservableCollection<Ator> Atores
        {
            get
            {
                    return _atores;

            }
            set
            {
                _atores = value;
            }

        }

        public bool CreateAtor(Ator a)
        {
            if (a.Create() == 1)
            {
                Atores.Add(a);
                return true;
            }
            return false;
        }
        public bool UpdateAtor()
        {
            if (SelectedAtor.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteAtor()
        {
            if (SelectedAtor.Delete() == 1)
            {
                if (SelectedAtor.Idator == Atores.Count)
                {
                    Atores.Remove(SelectedAtor);
                    Ator.ReSeed(Atores.Count);
                }
                else
                {

                    foreach (Ator u in Atores)
                    {
                        if (u.Idator > SelectedAtor.Idator)
                            u.Idator -= 1;
                    }
                    Atores.Remove(SelectedAtor);
                    Ator.CreateFromObservableCollection(Atores);
                }

                return true;
            }
            return false;
        }

        public bool Add_Linha()
        {
            Ator a = new Ator();
            a.Idator = Atores.Count + 1;
            return CreateAtor(a);
        }
    }
}
