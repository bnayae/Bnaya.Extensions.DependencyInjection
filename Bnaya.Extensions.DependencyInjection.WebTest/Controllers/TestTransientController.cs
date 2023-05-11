using Microsoft.AspNetCore.Mvc;

namespace Bnaya.Samples.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class TestTransientController : ControllerBase
    {
        private readonly IKeyed<IFunctionalityTransient> _selector;
        private readonly Component<IFunctionalityTransient> _component;
        private readonly ILogger<TestTransientController> _logger;

        public TestTransientController(
            IKeyed<IFunctionalityTransient> selector,
            Component<IFunctionalityTransient> component,
            ILogger<TestTransientController> logger)
        {
            _selector = selector;
            _component = component;
            _logger = logger;
        }

        [HttpGet("a")]
        public string GetA()
        {
            _logger.LogInformation("a");
            return $"{_selector["A"].Id} / {_component.GetText("A")}";
        }

        [HttpGet("b")]
        public string GetB()
        {
            return $"{_selector["B"].Id} / {_component.GetText("B")}";
        }
    }
}