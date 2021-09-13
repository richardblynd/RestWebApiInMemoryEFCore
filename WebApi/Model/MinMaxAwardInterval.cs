using System.Collections.Generic;

namespace WebApi.Model
{
    public class MinMaxAwardInterval
    {
        public List<ProducerAwardInterval> Min { get; set; }

        public List<ProducerAwardInterval> Max { get; set; }
    }
}