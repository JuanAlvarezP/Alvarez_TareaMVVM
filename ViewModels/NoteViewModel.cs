using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Alvarez_AppApuntes.ViewModels
{
    internal class NoteViewModel:ObservableObject, IQueryAttributable
    {
        private Models.Note _note;
        public string Text
        {
            get => _note.Texto_Alvarez;
            set
            {
                if (_note.Texto_Alvarez != value)
                {
                    _note.Texto_Alvarez = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime JA_Fecha => _note.Fecha_Alvarez;

        public string JA_Identifier => _note.Filename_Alvarez;

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public NoteViewModel()
        {
            _note = new Models.Note();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        public NoteViewModel(Models.Note note)
        {
            _note = note;
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        private async Task Save()
        {
            _note.Fecha_Alvarez = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?saved={_note.Filename_Alvarez}");
        }

        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_note.Filename_Alvarez}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Models.Note.Load(query["load"].ToString());
                RefreshProperties();
            }
        }

        public void Reload()
        {
            _note = Models.Note.Load(_note.Filename_Alvarez);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(JA_Fecha));
        }
    }
}
