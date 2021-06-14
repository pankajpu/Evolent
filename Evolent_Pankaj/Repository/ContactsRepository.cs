using Evolent_Pankaj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;

namespace Evolent_Pankaj.Repository
{
    [Export(typeof(IContactsRepository))]
    public class ContactsRepository : IContactsRepository
    {
        private EvolentHealthEntities db = new EvolentHealthEntities();
        // we can have many logging mechanizm, like log4net, in DB or any, 
        //I have just mentioned in comments but not yet implemented,
        // but it must be there as per scope & specification
        public List<tblContact> GetAll()
        {
            try
            {
                using (var dbcontext = new EvolentHealthEntities())
                {
                    return dbcontext.tblContacts.ToList();
                }
            }
            catch (Exception ex)
            {
                //log error in log with details, 
                return null;
            }
        }

        public tblContact Details(int? id)
        {
            try
            {
                tblContact Contactobj;
                if (id == null)
                {
                    return null;
                }
                using (var dbcontext = new EvolentHealthEntities())
                {
                    Contactobj = db.tblContacts.Find(id);
                }
                if (Contactobj == null)
                {
                    return null;
                }
                return Contactobj;
            }
            catch (Exception ex)
            {
                //log error in log with details, 
                return null;
            }
        }
        public void Create(tblContact Contactobj)
        {
            try
            {
                using (var dbcontext = new EvolentHealthEntities())
                {
                    dbcontext.tblContacts.Add(Contactobj);
                    dbcontext.SaveChanges();
                    //log the new contact is created
                }
            }
            catch (Exception ex)
            {
                //log error in log with details, 
            }
        }
        public tblContact Edit(int? id)
        {
            try
            {
                tblContact Contactobj;
                using (var dbcontext = new EvolentHealthEntities())
                {
                    Contactobj = dbcontext.tblContacts.Find(id);
                }
                return Contactobj;
            }
            catch (Exception ex)
            {
                //log error in log with details, 
                return null;
            }
        }
        public tblContact Edit(tblContact Contactobj)
        {
            using (var dbcontext = new EvolentHealthEntities())
            {
                dbcontext.Entry(Contactobj).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return Contactobj;
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var dbcontext = new EvolentHealthEntities())
                {
                    tblContact Contactobj = dbcontext.tblContacts.Find(id);
                    dbcontext.tblContacts.Remove(Contactobj);
                    dbcontext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                //log error in log with details, 
            }
        }

        public tblContact Find(int id)
        {
            try
            {
                using (var dbcontext = new EvolentHealthEntities())
                {
                    if (dbcontext.tblContacts != null)
                    {
                        tblContact Contactobj = dbcontext.tblContacts.Find(id);
                        return Contactobj;
                    }
                    else
                    {
                        //log that the db table details not found                      
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //log error in log with details, 
                return null;
            }
        }
    }
}