using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GithubIssueClassifierML.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;

namespace GithubIssueClassifier.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool;

        public IndexModel(ILogger<IndexModel> logger, PredictionEnginePool<ModelInput,ModelOutput> predictionEnginePool)
        {
            _logger = logger;
            this.predictionEnginePool = predictionEnginePool;
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
            var issue = new ModelInput()
            {
                Title = Input.Title,
                Description = Input.Description
            };

            var output = predictionEnginePool.Predict("GithubIssueClassifier", issue);

            PredictedArea = output.Prediction;
            return Page();
        }
    }
}
