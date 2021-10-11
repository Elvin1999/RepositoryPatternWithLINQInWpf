using Project.Commands;
using Project.DataAccess.SqlServer;
using Project.Domain.Abstraction;
using Project.Domain.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {

        private readonly IRepository<Book> _repo;

        public MainViewModel(IRepository<Book> repo)
        {
            _repo = repo;
            AllBooks = _repo.GetAllData();
            CurrentBook = new Book();

            AddCommand = new RelayCommand((sender) =>
              {
                  //temp id
                  CurrentBook.Id_Author = 1;
                  CurrentBook.Id_Category = 1;
                  CurrentBook.Id_Press = 1;
                  CurrentBook.Id_Themes = 1;
                  _repo.AddData(CurrentBook);
                  AllBooks = _repo.GetAllData();
              });

        }

        public RelayCommand AddCommand { get; set; }


        private Book currentBook;

        public Book CurrentBook
        {
            get { return currentBook; }
            set { currentBook = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Book> allBooks;
        public ObservableCollection<Book> AllBooks
        {
            get { return allBooks; }
            set { allBooks = value; OnPropertyChanged(); }
        }

    }
}
