﻿namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Controllers.Models.Locations;
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LocationInfoService : ILocationInfoService
    {
        private readonly ApiaryDiaryDbContext db;

        public LocationInfoService(ApiaryDiaryDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreatePartialAsync(int apiryId, string settlement)
        {
            var location = new LocationInfo
            {
                Settlement = settlement,
                ApiaryId = apiryId
            };

            this.db.Locations.Add(location);
            await this.db.SaveChangesAsync();

            return location.Id;
        }

        public async Task<int> CreateDetailedAsync(
            int apiryId, string settlement, int altitude,
            bool hasHoneyPlants, string description)
        {
            var location = new LocationInfo
            {
                ApiaryId = apiryId,
                Settlement = settlement,
                Altitude = altitude,
                HasHoneyPlants = hasHoneyPlants,
                Description = description,
            };

            this.db.Locations.Add(location);
            await this.db.SaveChangesAsync();

            return location.Id;
        }

        public LocationInfo FindById(int locationId)
        {
            return db.Locations
                .Where(l => l.Id == locationId)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<LocationsListingServiceModel>> ViewAll()
        {
            return await this.db
                    .Locations
                    .Where(l => l.IsDeleted == false)
                    .Select(l => new LocationsListingServiceModel
                    {
                        Id = l.Id,
                        ApiaryName = l.Apiary.Name,
                        Settlement = l.Settlement,
                        Altitude = l.Altitude,
                        Description = l.Description,
                    })
                    .ToListAsync();                   
        }
    }
}
