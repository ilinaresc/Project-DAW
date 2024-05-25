using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismGoDomain.Core.DTO;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Infrastructure.Repositories;

namespace TourismGoDomain.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<ActivityDTOList>> GetAll()
        {
            var activity = await _activityRepository.GetAll();
            var activitiesDTO = new List<ActivityDTOList>();

            foreach (var category in activity)
            {
                var activityDTOList = new ActivityDTOList();
                activityDTOList.Id = category.Id;
                activityDTOList.Description = category.Description;
                activitiesDTO.Add(activityDTOList);
            }
            return activitiesDTO;
        }

        public async Task<ActivityDTOList> GetById(int id)
        {
            var activity = await _activityRepository.GetById(id);
            var activitiesDTO = new ActivityDTOList();
            activitiesDTO.Id = id;
            activitiesDTO.Description = activity.Description;
            return activitiesDTO;
        }
    }
}
