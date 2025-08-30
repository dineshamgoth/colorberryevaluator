using BerryTestProject1.Interfaces;
using BerryTestProject1.ViewModels;

namespace BerryTestProject1.Services
{
    public class RelationshipService:IRelationshipService
    {
        public void AddPersonAsync(PersonDetailsVM data)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
