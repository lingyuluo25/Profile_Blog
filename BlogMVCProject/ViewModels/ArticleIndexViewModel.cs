using BlogMVCProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace BlogMVCProject.ViewModels
{
    public class ArticleIndexViewModel
    {
        public IPagedList<Article> Articles { get; set; } //IPagedList
        public string Search { get; set; } // ViewBag.Search
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; } // CategoryWithCount
        public string Category { get; set; } 
        public string SortBy { get; set; } // Order

        
        public Dictionary<string, string> Sorts { get; set; } = new Dictionary<string, string>
        {
            { "date_oldest", "Date (Oldest to Newest)" },
            { "date_newest", "Date (Newest to Oldest)" },
            { "title_asc", "Title (A - Z)" },
            { "title_desc", "Title (Z - A)" }
        };

        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
    }
}


public class CategoryWithCount
    {
        public int ArticleCount { get; set; }
        public string CategoryName { get; set; }

        public string CatNameWithCount
        {
            get
            {
                return CategoryName + " (" + ArticleCount.ToString() + ")";
            }
        }
    }

