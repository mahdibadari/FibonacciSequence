using Microsoft.AspNetCore.Mvc;

namespace FibonacciSequence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {

        //[HttpGet(Name = "GetFibonacciForXSequence")]
        [HttpGet(Name = "GetFibonacciSequence")]
        public List<long> GetFibonacciForXSequence(long index)
        {            
            return CalculateFibonacciSequenceUpToX(index);
        }

        private List<long> CalculateFibonacciSequenceUpToX(long index)
        {
            List<long> fibonacciList = new List<long>
            {
                0
            };
            if (index > 1) fibonacciList.Add(1);
            for (int i = 3; i < index+1; i++)
            {
                fibonacciList.Add(fibonacciList[i - 2] + fibonacciList[i - 3]);
            }
            return fibonacciList;
        }

        [HttpGet("indexToGet")]
        public long GetFibonacciSequenceForIndexX(int indexToGet)
        {
            return CalculateFibonacciSequenceUpToX(indexToGet)[indexToGet - 1];
        }
    }
}
