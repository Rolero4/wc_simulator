﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.DAL.Repositories;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        #region Variables



        #endregion


        #region Constructor

        public MainViewModel()
        {
            Model = new MainModel();
            NavigationStore = new NavigationStore();

            NavigationStore.CurrentViewModel = new LoginViewModel(Model, NavigationStore);
            NavigationStore.MenuVisibility = Visibility.Hidden;

            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigationStore.MenuVisibilityChanged += OnMenuVisibilityChanged;
        }

        #endregion


        #region Subscribers

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnMenuVisibilityChanged()
        {
            OnPropertyChanged(nameof(MenuVisibility));
        }

        #endregion


        #region Properties

        public BaseViewModel CurrentViewModel
        {
            get { return NavigationStore.CurrentViewModel; }
            set { NavigationStore.CurrentViewModel = value; }
        }

        public Visibility MenuVisibility
        {
            get { return NavigationStore.MenuVisibility; }
            set { NavigationStore.MenuVisibility = value; }
        }

        public ObservableCollection<Tournament> Tournaments
        {
            get { return Model.AllTournaments; }
            set
            {
                Model.AllTournaments = value;
                OnPropertyChanged(nameof(Tournaments));
            }
        }

        #endregion


        #region Commands

        private ICommand _profile = null;

        public ICommand Profile
        {
            get
            {
                if (_profile == null)
                {
                    _profile = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new ProfileViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _profile;
            }
        }

        private ICommand _teams = null;

        public ICommand Teams
        {
            get
            {
                if (_teams == null)
                {
                    _teams = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new TeamsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _teams;
            }
        }

        private ICommand _groups = null;

        public ICommand Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = new RelayCommand(arg =>
                    {
                        if (Model.AllTournaments.Count == 0)
                        {
                            CreateTourneyViewModel create = new CreateTourneyViewModel(Model, NavigationStore);
                            NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, create, Visibility.Visible, "Musisz stworzyć przynajmniej jeden turniej.");
                        }
                        else
                            NavigationStore.CurrentViewModel = new GroupsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _groups;
            }
        }

        private ICommand _knockouts = null;

        public ICommand Knockouts
        {
            get
            {
                if (_knockouts == null)
                {
                    _knockouts = new RelayCommand(arg =>
                    {
                        if (Model.AllTournaments.Count == 0)
                        {
                            CreateTourneyViewModel create = new CreateTourneyViewModel(Model, NavigationStore);
                            NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, create, Visibility.Visible, "Musisz stworzyć przynajmniej jeden turniej.");
                        }
                        else
                            NavigationStore.CurrentViewModel = new KnockoutsViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _knockouts;
            }
        }

        private ICommand _help = null;

        public ICommand Help
        {
            get
            {
                if (_help == null)
                {
                    _help = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new HelpViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _help;
            }
        }

        private ICommand _newTournament = null;

        public ICommand NewTournament
        {
            get
            {
                if (_newTournament == null)
                {
                    _newTournament = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new CreateTourneyViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _newTournament;
            }
        }

        private ICommand _tournamentSelectionChanged = null;

        public ICommand TournamentSelectionChanged
        {
            get
            {
                if (_tournamentSelectionChanged == null)
                {
                    _tournamentSelectionChanged = new RelayCommand(arg =>
                    {
                        if (Model.CurrentTournament != null)
                        {
                            Model.CurrentTournamentGroups = new ObservableCollection<Single_group>(RepositoryGroups.LoadTournamentGroup(Model.CurrentTournament.Id_tournament));
                            Model.CurrentTournamentMatches = new ObservableCollection<Single_match>(RepositoryMatches.LoadTournamentMatch(Model.CurrentTournament));
                            ProfileViewModel profile = new ProfileViewModel(Model, NavigationStore);
                            NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, profile, Visibility.Visible, "Turniej został zmieniony.");
                        }
                    },
                    arg => true);
                }
                return _tournamentSelectionChanged;
            }
        }

        #endregion
    }
}
