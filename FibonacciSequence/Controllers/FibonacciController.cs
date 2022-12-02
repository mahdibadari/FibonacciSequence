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
            long absoluteIndex = Math.Abs(index);
            List<long> fibonacciList = new List<long>
            {
                0
            };
            if (absoluteIndex > 1) fibonacciList.Add(1);
            for (int i = 3; i < absoluteIndex + 1; i++)
            {
                fibonacciList.Add(fibonacciList[i - 2] + fibonacciList[i - 3]);
            }
            if (index < 0)
            {
                return fibonacciList.Select(x => -x).ToList();
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
