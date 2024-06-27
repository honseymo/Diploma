using Doc_Builder.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc_Builder.ViewModel
{

    class MainViewModel : ObservableObject
    {
        public RelayCommand ChangeViewCommand { get; set; }
        public RelayCommand ReadyDocumnetsViewCommand { get; set; }
        public RelayCommand WordViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public ReadyDocumentsModel ReadyDocumentsVM { get; set; }
        public WordViewModel WordVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
                
                
            }
        }

        void ChangeView(object parameter)
        {
            // Изменяем текущее представление в зависимости от переданного параметра
            if (parameter is string viewName)
            {
                switch (viewName)
                {
                    case "Home":
                        CurrentView = HomeVM;
                        break;
                    case "Discovery":
                        CurrentView = DiscoveryVM;
                        break;
                    case "Word":
                        CurrentView = WordVM;
                        break;
                    case "ReadyDocuments":
                        CurrentView = ReadyDocumentsVM;
                        break;
                }
            }
        }
        public MainViewModel()
        {
            ChangeViewCommand = new RelayCommand(ChangeView);
            DiscoveryVM = new DiscoveryViewModel();
            HomeVM = new HomeViewModel();
            WordVM = new WordViewModel();
            ReadyDocumentsVM = new ReadyDocumentsModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });

            WordViewCommand = new RelayCommand(o =>
            {
                CurrentView = WordVM;
            });

            ReadyDocumnetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReadyDocumentsVM;
            });
        }


        public class Node
        {
            public Node(String name, IEnumerable<Node> children = null)
            {
                Name = name;
                _children = children == null ? new ObservableCollection<Node>() : new ObservableCollection<Node>(children);
            }

            public String Name { get; private set; }

            private ObservableCollection<Node> _children;
            public ObservableCollection<Node> Children
            {
                get { return _children; }
            }
        }
    }
}
