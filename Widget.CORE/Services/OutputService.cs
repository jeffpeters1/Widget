﻿using System;
using System.Collections.Generic;
using Widget.CORE.Entities;
using Widget.CORE.Enums;
using Widget.CORE.Exceptions;
using Widget.CORE.Helpers;
using Widget.CORE.Interfaces;

namespace Widget.CORE.Services
{
    public class OutputService : IOutputService
    {
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

            // Note : Use of Factory pattern prefered to inheritance/interface implementation
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
