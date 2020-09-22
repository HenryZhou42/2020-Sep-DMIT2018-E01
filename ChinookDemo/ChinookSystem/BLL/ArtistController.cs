
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
using System.ComponentModel;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    //expose library class for config of ODS
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SelectionList> Artists_List()
        {

            //due to entities will be internal
            //you will not be able to use the entity definitions
            //as return datatypes


            //instead, we will create views within the ViewModel class that will
            // contain the data definitions for your return datatypes

            // to fill these view model classes, we will be using linq queries
            //linq queries return their data as IEnumerable or IQueryable datasets
            //you can use var when declairing your query receiving variables
            //the receiving variables can then be converted to a List<T>
            //this Linq query below uses the query syntax method
            using (var context = new ChinookSystemContext())
            {
                //Linq to Entity queries
                //where is the access to the application library system entities
                //they are in your context class ChinookSystemContext - > context
                //the entities are access by your DbSet<T> ->Artist
                //x represents any occurance (instance) in DbSet<T>
                var results = from x in context.Artists
                              select new SelectionList
                              {
                                  ValueId = x.ArtistId,
                                  DisplayText = x.Name
                              };
                return results.OrderBy(x =>x.DisplayText).ToList();

                //return context.Artists.ToList();   //in CPSC 1517 ENTITIES were public
            }
        }
    }
}
