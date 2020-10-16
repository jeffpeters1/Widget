using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Widget.CORE.Enums;
using Widget.CORE.Exceptions;
using Widget.CORE.Helpers;
using Widget.CORE.Interfaces;
using Widget.WEB.ViewModels;

namespace Widget.WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOutputService _outputService;

        public IndexModel(ILogger<IndexModel> logger, IOutputService outputService)
        {
            _logger = logger;
            _outputService = outputService;
        }

        [BindProperty]
        public IndexVm IndexInfo { get; set; } = new IndexVm() { BillOfMaterials = new List<string>() };

        //========================
        // GET
        //========================
        public void OnGet()
        {
        }

        //========================
        // POST
        //========================
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Enum.TryParse(IndexInfo.BuilderType, out BuilderType builderType);

                    RenderBillOfMaterials(builderType);
                }
                catch(Exception ex)
                {
                    if (ex is UnknownShapeException || 
                        ex is UnknownBuilderException ||
                        ex is InvalidMeasurementException)
                    {
                        _logger.LogWarning($"{ex.Message}");
                    }
                    else
                    {
                        _logger.LogWarning($"Error while running the Bill of Materials generator : {ex.Message}");
                    }

                    Abort();
                }
            }

            return Page();
        }

        private void RenderBillOfMaterials(BuilderType builderType)
        {
            try
            {
                IndexInfo.BillOfMaterials = _outputService.GetBillOfMaterials(builderType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Abort()
        {
            IndexInfo.BillOfMaterials = new List<string>() { Messages.Abort };
        }
    }
}
