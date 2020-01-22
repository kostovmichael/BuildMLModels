using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;

namespace GithubIssueClassifier.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public class InputForm
        {
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Display(Name = "Description")]
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
        }

        [BindProperty]
        public InputForm Input { get; set; }
        public string PredictedArea { get; set; }

        public IActionResult OnPostAsync()
        {

            return Page();
        }
    }
}
