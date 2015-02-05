using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ReactiveUI;

namespace PoC.WpfMediaPlayer
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            Open = ReactiveCommand.Create();
            Open.Subscribe(_ =>
            {
                
            });

            var play = ReactiveCommand.Create();
        }

        string _path;
        ReactiveCommand<object> _open;

        public string Path
        {
            get { return _path; }
            set { this.RaiseAndSetIfChanged(ref _path, value); }
        }

        public ReactiveCommand<object> Open
        {
            get { return _open; }
            set { _open = value; }
        }
    }
}
