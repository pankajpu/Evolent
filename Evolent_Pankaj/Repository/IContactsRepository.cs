using Evolent_Pankaj.Models;
using System.Collections.Generic;

namespace Evolent_Pankaj.Repository
{

    public interface IContactsRepository
    {
        List<tblContact> GetAll();
        tblContact Details(int? id);
        void Create(tblContact tblContact);
        tblContact Edit(int? id);
        tblContact Edit(tblContact tblContact);
        void Delete(int id);
        tblContact Find(int id);
    }
}