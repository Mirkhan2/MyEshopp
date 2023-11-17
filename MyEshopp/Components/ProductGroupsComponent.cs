using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEshopp.Data;
using MyEshopp.Data.Repositories;
using MyEshopp.Models;

namespace MyEshopp.Components
{
	public class ProductGroupsComponent : ViewComponent
	{
		private IGroupRepository _groupRepository;
		
		public ProductGroupsComponent(IGroupRepository groupRepository)
		{
			_groupRepository = groupRepository;
		}
		

		
		public async Task<IViewComponentResult> invokeAsync()
		{
			

			return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShow());
		}
	}
}
