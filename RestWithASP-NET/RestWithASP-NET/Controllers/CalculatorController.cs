using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{SecondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{SecondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{SecondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{SecondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{SecondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
