using Microsoft.AspNetCore.Mvc;
using MoodTracker.Model;
using MoodTracker.Model.Data;
using MoodTracker.Model.DTO;

namespace MoodTracker.API.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseController<Activity, ActivityDTO> {

        protected readonly ILogger _logger;

        public ActivitiesController(MoodContext context, ILogger<ActivitiesController> logger) : base(context) {
            this._logger = logger;
        }
    }
}
