﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Domain.Exceptions;
using Resturant.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Resturants.Commands.ResturantUpdate
{
    public class ResturantUpdateCommandHandler(IMapper mapper,
        ILogger<ResturantUpdateCommandHandler> logger, IResturantRepository resturantRepository)
        : IRequestHandler<ResturantUpdateCommand>
    {
        public async Task Handle(ResturantUpdateCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating restaurant with ID {request.Id} in the repository.");
            var existingResturant = await resturantRepository.GetByIdAsync(request.Id);
            if (existingResturant == null)
            {
                logger.LogWarning($"Restaurant with ID {request.Id} not found.");
                throw new NotFoundException(nameof(Resturant),request.Id);
            }
            mapper.Map(request, existingResturant);
            await resturantRepository.UpdateAsync(existingResturant);
        }
    }
}
