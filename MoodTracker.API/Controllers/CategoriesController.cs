using Microsoft.AspNetCore.Mvc;
using MoodTracker.Model;
using MoodTracker.Model.Data;
using MoodTracker.Model.DTO;

namespace MoodTracker.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<ActivityCategory, ActivityCategoryDTO> {
        public CategoriesController(MoodContext context) : base(context) {

        }
    }
}
