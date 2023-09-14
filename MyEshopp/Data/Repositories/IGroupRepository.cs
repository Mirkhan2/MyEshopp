using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyEshopp.Models;

namespace MyEshopp.Data.Repositories
{
	public interface IGroupRepository
	{
		IEnumerable<Catagory> GetAllCatagories();
		IEnumerable<ShowGroupViewModel> GetGroupForShow();
	}
	public class GroupRepository : IGroupRepository
	{
		private MyEshoppContext _context;
        public GroupRepository(MyEshoppContext context)
        {
            _context = context;
        }

        IEnumerable<Catagory> IGroupRepository.GetAllCatagories()
		{
			return _context.Catagories;
			
			
		}

		IEnumerable<ShowGroupViewModel> IGroupRepository.GetGroupForShow()
		{
			return _context.Catagories
				.Select(c => new ShowGroupViewModel()
				{
					GroupId = c.Id,
					Name = c.Name,
					ProductCount = _context.CatagoryToProducts.Count(g => g.CatagoryId == c.Id)
				}).ToList();
		}
	}
}
