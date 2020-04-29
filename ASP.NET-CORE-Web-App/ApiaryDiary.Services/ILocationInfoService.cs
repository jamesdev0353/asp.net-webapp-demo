﻿namespace ApiaryDiary.Services
{
    using ApiaryDiary.Controllers.Models.Locations;
    using ApiaryDiary.Data.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationInfoService
    {
        Task<int> CreateDetailedAsync(
            int apiryId, string settlement, int altitude,
            bool hasHoneyPlants, string description);

        Task<int> CreatePartialAsync(int apiryId, string settlement);

        LocationInfo FindById(int locationId);

        Task<IEnumerable<LocationsListingServiceModel>> ViewAll();
    }
}
