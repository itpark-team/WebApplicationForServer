using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationForServer.Models;

namespace WebApplicationForServer.Controllers
{
    public class MyMathController : ApiController
    {
        public List<string> Get()
        {
            return new List<string>() { "1", "2" };
        }

        public int Post([FromBody]OperandsPair operandsPair)
        {
            int result;

            switch (operandsPair.ArithmeticOperator)
            {
                case "+":
                    result = operandsPair.A + operandsPair.B;
                    break;


                case "-":
                    result = operandsPair.A - operandsPair.B;
                    break;


                default:
                    result = 0;
                    break; 
            }

            return result;
        }
    }
}
