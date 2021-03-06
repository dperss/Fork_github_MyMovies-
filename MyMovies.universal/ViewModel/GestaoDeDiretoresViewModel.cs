﻿using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    public class GestaoDeDiretoresViewModel
    {
        ObservableCollection<Diretor> _diretores;
        Diretor _diretor;

        public Diretor SelectedDiretor
        {
            get
            {
                return _diretor;
            }
            set
            {
                _diretor = value;
            }
        }
        public GestaoDeDiretoresViewModel()
        {
            List<Diretor> lista = Diretor.ReadAll();
            if (lista == null)
            {
                Diretor.CreateTable();
                Filme_diretor.CreateTable();
                _diretores = new ObservableCollection<Diretor>();
            }
            else
            {
                _diretores = new ObservableCollection<Diretor>(lista);
            }
        }
        public ObservableCollection<Diretor> Diretores
        {
            get
            {
                return _diretores;

            }
            set
            {
                _diretores = value;
            }

        }

        public bool CreateDiretor(Diretor d)
        {
            if (d.Create() == 1)
            {
                Diretores.Add(d);
                return true;
            }
            return false;
        }
        public bool UpdateDiretor()
        {
            if (SelectedDiretor.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public int DeleteDiretor()
        {
            int ret = SelectedDiretor.Delete();
            if (ret == 1)
            {
                if (SelectedDiretor.Iddiretor == Diretores.Count)
                {
                    Diretores.Remove(SelectedDiretor);
                    Diretor.ReSeed(Diretores.Count);
                }
                else
                {

                    foreach (Diretor d in Diretores)
                    {
                        if (d.Iddiretor > SelectedDiretor.Iddiretor)
                            d.Iddiretor -= 1;
                    }
                    Diretores.Remove(SelectedDiretor);
                    Diretor.CreateFromObservableCollection(Diretores);
                }
            }
            return ret;
        }

        public bool Add_Linha()
        {
            Diretor d = new Diretor();
            d.Iddiretor = Diretores.Count + 1;
            return CreateDiretor(d);
        }
    }
}
