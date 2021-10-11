using Project.Domain.Abstraction;
using Project.Domain.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.SqlServer
{
    public class BookRepository : IBookRepository
    {
        public DataClassesDataContext DataContext { get; set; }
        public BookRepository()
        {
            DataContext = new DataClassesDataContext();
        }

        public Book GetData(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Book> GetAllData()
        {
            var books = from b in DataContext.Books
                        select b;
            return ObserverHelper.ToObservableCollection(books);
        }

        public void AddData(Book data)
        {
            DataContext.Books.InsertOnSubmit(data);
            DataContext.SubmitChanges();
        }

        public void UpdateData(Book data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Book data)
        {
            throw new NotImplementedException();
        }
    }
}
