using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomComboBox
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        string selectedMovie;
        private readonly Task<List<Movie>> moviesTask;
        public MainWindowViewModel(FilmService filmService)
        {
            this.moviesTask = filmService.GetMoviesAsync();

            OnWatchNow = new WatchNowCommand(ShowMovie);
        }

        private void ShowMovie(object parameter)
        {
            if (parameter != null)
            {

                if (parameter is string s)
                    SelectedMovie = s;
                else if (parameter is Movie m)
                    SelectedMovie = m.Title;
            }
        }

        public List<Movie> Movies
        {
            get
            {
                return this.moviesTask.Result;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand OnWatchNow { get; set; }

        public string SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMovie)));
            }
        }
    }

    public class WatchNowCommand : ICommand
    {
        Action<object> _execute;
        public WatchNowCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) =>
            _execute(parameter);

    }
}
