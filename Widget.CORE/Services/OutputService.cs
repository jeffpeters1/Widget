using System;
using System.Collections.Generic;
using Widget.CORE.Entities;
using Widget.CORE.Enums;
using Widget.CORE.Exceptions;
using Widget.CORE.Helpers;
using Widget.CORE.Interfaces;
using Widget.CORE.Widgets;

namespace Widget.CORE.Services
{
    public class OutputService : IOutputService
    {
        //private readonly List<WidgetSpec> HARDCODED_WIDGET_SPEC_LIST = new List<WidgetSpec>()
        //{
        //    new WidgetSpec(){ ShapeType=ShapeType.Rectangle, PositionX=10, PositionY=10, Width=30, Height=40 },
        //    new WidgetSpec(){ ShapeType=ShapeType.Square, PositionX=15, PositionY=30, Width=35 },
        //    new WidgetSpec(){ ShapeType=ShapeType.Ellipse, PositionX=100, PositionY=150, HorizontalDiameter=300, VerticalDiameter=200},
        //    new WidgetSpec(){ ShapeType=ShapeType.Circle ,PositionX=1, PositionY=1, Diameter=300 },
        //    new WidgetSpec(){ ShapeType=ShapeType.Textbox, PositionX=5, PositionY=5, Width=200, Height=100, Text="The obligatory Hello World!!" }
        //};

        private readonly IBillFactoryService _billFactoryService;
        private readonly IRepository _repository;
        private readonly IAppLogger<OutputService> _logger;

        public OutputService(IBillFactoryService billFactoryService, IRepository repository,
                             IAppLogger<OutputService> logger)
        {
            _billFactoryService = billFactoryService;
            _repository = repository;
            _logger = logger;
        }

        public List<string> GetBillOfMaterials(BuilderType builderType)
        {
            string bill;
            var bills = new List<string>();

            // Get bill formatter depending on builder type
            IBillGenerator billGenerator = _billFactoryService.Create(builderType);

            try
            {
                foreach (var spec in _repository.ListAll())
                {
                    switch (spec.ShapeType)
                    {
                        case ShapeType.Rectangle:
                            bill = billGenerator.ProcessRectangle(new Rectangle(spec.PositionX, spec.PositionY, spec.Width, spec.Height));
                            bills.Add(bill);
                            break;
                        case ShapeType.Square:
                            bill = billGenerator.ProcessSquare(new Square(spec.PositionX, spec.PositionY, spec.Width));
                            bills.Add(bill);
                            break;
                        case ShapeType.Ellipse:
                            bill = billGenerator.ProcessEllipse(new Ellipse(spec.PositionX, spec.PositionY, spec.VerticalDiameter, spec.HorizontalDiameter));
                            bills.Add(bill);
                            break;
                        case ShapeType.Circle:
                            bill = billGenerator.ProcessCircle(new Circle(spec.PositionX, spec.PositionY, spec.Diameter));
                            bills.Add(bill);
                            break;
                        case ShapeType.Textbox:
                            bill = billGenerator.ProcessTextbox(new Textbox(spec.PositionX, spec.PositionY, spec.Width, spec.Height, spec.Text));
                            bills.Add(bill);
                            break;
                        default:
                            throw new UnknownShapeException();
                    }
                }
            }
            catch (InvalidMeasurementException ex)
            {
                bills.Add(Messages.Abort);
                _logger.LogWarning($"Error in GetBillOfMaterials : {ex.Message}");
            }
            catch (Exception)
            {
                throw;
            }

            return bills;
        }
    }
}
