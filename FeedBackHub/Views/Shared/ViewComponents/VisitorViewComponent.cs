using FeedBackHub.Context;
using FeedBackHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackHub.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {
        private readonly MyContext _context;
        public VisitorViewComponent(MyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors = _context.Visitors.ToList();

            List<VisitorVM> visitorsVM = new List<VisitorVM>();
            foreach (var item in visitors)
            {
                VisitorVM vvm = new VisitorVM
                {
                    Name = item.Name,
                    Comment = item.Comment,
                    CreatedDate = item.CreatedDate,
                };
                visitorsVM.Add(vvm);
            }
            ViewBag.Visitors = visitorsVM;

            return View();
        }
    }
}
