using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoModeloDDD.Domain.DTOs;
using System;

namespace ProjetoModeloDDD.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        private readonly ResultViewModel<object> _resultViewModel;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
            _resultViewModel = new ResultViewModel<object>();
        }

        [Route("/ErrorProduction")]
        public IActionResult ErrorProduction()
        {
            LogError();
            var objRetorno = _resultViewModel.AddMessage("Erro Inesperado! Consulte o administrador do sistema.");

            return BadRequest(objRetorno);
        }

        [Route("/ErrorDevelopment")]
        public IActionResult ErrorDevelopment()
        {
            var exception = LogError();
            var objRetorno = _resultViewModel.AddMessage(exception.Message);

            return BadRequest(objRetorno);
        }

        private Exception LogError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Exception

            var path = ((Microsoft.AspNetCore.Diagnostics.ExceptionHandlerFeature)context).Path;
            _logger.LogError(exception, $"\nData: {DateTime.Now} \nPath: {path} \nMensagem: {exception.Message}");

            return exception;
        }
    }
}
