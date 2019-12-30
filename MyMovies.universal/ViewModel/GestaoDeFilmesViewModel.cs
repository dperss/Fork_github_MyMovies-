using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyMovies.universal.ViewModel
{
    public class GestaoDeFilmesViewModel
    {
        ObservableCollection<Filme> _filmes;
        Filme _filme;
        public Filme SelectedFilme
        {
            get
            {
                return _filme;
            }
            set
            {
                _filme = value;
            }
        }
        public GestaoDeFilmesViewModel()
        {
            List<Filme> lista = Filme.ReadAllJoin();
            if(lista == null)
            {
                Filme.CreateTable();
                _filmes = new ObservableCollection<Filme>();
            }
            else
            {
                _filmes = new ObservableCollection<Filme>(lista);
            }
            foreach (Filme f in Filmes)
            {
                f.Atores = f.ReadAllAtores();
                f.Generos = f.ReadAllGeneros();
                
            }
            
           
        }
        public ObservableCollection<Filme> Filmes
        {
            get
            {
                return _filmes;

            }
            set 
            {
                _filmes = value;
            }

        }

        public bool CreateFilme(Filme f)
        {
            if (f.Create() == 1)
            {
                Filmes.Add(f);
                return true;
            }
            return false;
        }
        
        public bool UpdateFilme() 
        {
            if (SelectedFilme.Update() == 1)
            {
                return true;
            }

            return false;
        }

        public bool DeleteFilme()
        {
            if (SelectedFilme.Delete() == 1)
            {
                if (SelectedFilme.Idfilme == Filmes.Count)
                {
                    Filmes.Remove(SelectedFilme);
                    Filme.ReSeed(Filmes.Count);
                }
                else
                {

                    foreach (Filme f in Filmes)
                    {
                        if (f.Idfilme > SelectedFilme.Idfilme)
                            f.Idfilme -= 1;
                    }
                    Filmes.Remove(SelectedFilme);
                    Filme.CreateFromObservableCollection(Filmes);
                }

                return true;
            }
            return false;
        }
        public bool Add_Linha()
        {
            Filme f = new Filme();
            f.Idfilme = Filmes.Count + 1;
            return CreateFilme(f);
        }
        public async static Task<StorageFile> OpenLocalFile(params string[] types)
        {
            var picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            Regex typeReg = new Regex(@"^\.[a-zA-Z0-9]+$");
            foreach (var type in types)
            {
                if (type == "*" || typeReg.IsMatch(type))
                    picker.FileTypeFilter.Add(type);
                else
                    throw new InvalidCastException("File extension is incorrect");
            }
            var file = await picker.PickSingleFileAsync();
            if (file != null)
                return file;
            else
                return null;
        }
        public async Task<bool> UpdateFoto(StorageFile file)
        {
            if (file == null)
                return false;
            SelectedFilme.Foto = (await FileIO.ReadBufferAsync(file)).ToArray();
            if(SelectedFilme.Foto == null)
            {
                return false;
            }
            if (SelectedFilme.UpdateFoto() == 1)
            {
                return true;
            }

            return false;
        }
        public async Task<BitmapImage> ByteArrayToImage(Byte[] byteArrayIn)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(byteArrayIn);
                    await writer.StoreAsync();
                }
                var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                return image;

            }
        }
    }
}
