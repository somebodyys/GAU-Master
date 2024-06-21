using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using library.Data;
using library.Models;

namespace library.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly LibraryDbContext _dbContext;

        public MainWindowViewModel()
        {
            _dbContext = App.DbContext;
            LoadAuthors();

            AddAuthorCommand = ReactiveCommand.Create(AddAuthor);
            DeleteAuthorCommand = ReactiveCommand.Create<Author>(DeleteAuthor);
            UpdateAuthorCommand = ReactiveCommand.Create<Author>(UpdateAuthor);
        }

        private ObservableCollection<Author> _authors;
        public ObservableCollection<Author> Authors
        {
            get => _authors;
            set => this.RaiseAndSetIfChanged(ref _authors, value);
        }

        private string _newAuthorName;
        public string NewAuthorName
        {
            get => _newAuthorName;
            set => this.RaiseAndSetIfChanged(ref _newAuthorName, value);
        }

        private string _newAuthorNationality;
        public string NewAuthorNationality
        {
            get => _newAuthorNationality;
            set => this.RaiseAndSetIfChanged(ref _newAuthorNationality, value);
        }

        public ReactiveCommand<Unit, Unit> AddAuthorCommand { get; }
        public ReactiveCommand<Author, Unit> DeleteAuthorCommand { get; }
        public ReactiveCommand<Author, Unit> UpdateAuthorCommand { get; }

        private void LoadAuthors()
        {
            Authors = new ObservableCollection<Author>(_dbContext.Authors.OrderByDescending(a => a.author_id).ToList());
        }

        private void AddAuthor()
        {
            var newAuthor = new Author
            {
                name = NewAuthorName,
                nationality = NewAuthorNationality
            };

            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();

            LoadAuthors();

            NewAuthorName = "";
            NewAuthorNationality = "";
        }

        private void DeleteAuthor(Author author)
        {
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
                LoadAuthors();
            }
        }

        private void UpdateAuthor(Author author)
        {
            if (author != null)
            {
                author.name += " Updated";
                author.nationality += " Updated";

                _dbContext.SaveChanges();
                LoadAuthors();
            }
        }
    }
}
