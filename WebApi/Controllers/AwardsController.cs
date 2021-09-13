using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwardsController : ControllerBase
    {
        private AwardsDBContext dbContext;

        public AwardsController(AwardsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("min_max_award_interval")]
        public MinMaxAwardInterval GetMinMaxAwardInterval()
        {
            var producerAwardIntervals = new List<ProducerAwardInterval>();

            var producerMovies = new List<ProducerMovie>();

            var andWord = " and ";

            foreach (var movie in dbContext.Movies.Where(x => x.Winner))
            {
                if (movie.Producers.Contains(",") || movie.Producers.Contains(andWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    var producers = new List<string>();
                    if (movie.Producers.Contains(","))
                    {
                        foreach (var producerCommaSplit in movie.Producers.Split(','))
                        {
                            if (producerCommaSplit.Contains(andWord, StringComparison.CurrentCultureIgnoreCase))
                            {
                                foreach (var producerAndSplit in producerCommaSplit.Split(andWord))
                                {
                                    producerMovies.Add(new ProducerMovie
                                    {
                                        Producer = producerAndSplit.Trim(),
                                        Year = movie.Year
                                    });
                                }
                            }
                            else
                            {
                                producerMovies.Add(new ProducerMovie
                                {
                                    Producer = producerCommaSplit.Trim(),
                                    Year = movie.Year
                                });
                            }
                        }
                    }
                    else
                    {
                        foreach (var producerAndSplit in movie.Producers.Split(andWord))
                        {
                            producerMovies.Add(new ProducerMovie
                            {
                                Producer = producerAndSplit.Trim(),
                                Year = movie.Year
                            });
                        }
                    }
                }
                else
                {
                    producerMovies.Add(new ProducerMovie
                    {
                        Producer = movie.Producers.Trim(),
                        Year = movie.Year
                    });
                }
            }

            foreach (var gp in producerMovies.GroupBy(x => x.Producer, StringComparer.CurrentCultureIgnoreCase).Where(y => y.Count() > 1))
            {
                var orderList = gp.OrderBy(x => x.Year).ToList();

                for (var x = 1; x < orderList.Count(); x ++)
                {
                    producerAwardIntervals.Add(new ProducerAwardInterval
                    {
                        Producer = gp.Key,
                        PreviousWin = orderList[x - 1].Year,
                        FollowingWin = orderList[x].Year
                    });
                }
            }

            if (!producerAwardIntervals.Any())
                return new MinMaxAwardInterval();

            var minInterval = producerAwardIntervals.Min(x => x.Interval);
            var maxInterval = producerAwardIntervals.Max(x => x.Interval);

            return new MinMaxAwardInterval
            {
                Min = producerAwardIntervals.Where(x => x.Interval == minInterval).OrderBy(x => x.PreviousWin).ToList(),
                Max = producerAwardIntervals.Where(x => x.Interval == maxInterval).OrderBy(x => x.PreviousWin).ToList()
            };
        }
    }
}
