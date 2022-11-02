using Microsoft.AspNetCore.Mvc;

namespace WebApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
       
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("calc/{primeiroNumero}/{segundoNumero}/{operacao}")]
        public IActionResult Get(string primeiroNumero, string segundoNumero, string operacao)
        {

            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                switch (operacao)
                {
                    case "adi":
                        var soma = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);
                        return Ok(soma.ToString());
                        break;

                    case "sub":
                        var subtracao = ConvertToDecimal(primeiroNumero) - ConvertToDecimal(segundoNumero);
                        return Ok(subtracao.ToString());
                        break;

                    case "mul":
                        var multiplicacao = ConvertToDecimal(primeiroNumero) * ConvertToDecimal(segundoNumero);
                        return Ok(multiplicacao.ToString());
                        break;

                    case "div":
                        var divisao = ConvertToDecimal(primeiroNumero) / ConvertToDecimal(segundoNumero);
                        return Ok(divisao.ToString());
                        break;
                }
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumero)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumero, out decimalValue))
            {
                return decimalValue;
            }
               
            return 0;

        }

        private bool IsNumeric(string strNumero)
        {
            double number;
            bool isNumber = double.TryParse(strNumero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}