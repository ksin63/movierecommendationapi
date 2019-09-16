using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using MovieRecomendationApp.Model;
using MovieRecommender.Models;

namespace MovieRecomendationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Recommendation engine is up and running");
        }

        [HttpPost]
        [Route("Execute")]
        public ActionResult Execute([FromBody]Input input)
        {
            try {
                string outPut = string.Empty;
                if (input?.inputs?.movieSelection?.value == null || input?.inputs?.movieSelection?.value.Split(':').Length != 2)
                {
                    return BadRequest("Input data format error");
                }
                var movieRatingTestInput = new MovieRating
                {
                    userId = Int32.Parse(input?.inputs?.movieSelection?.value.Split(':')[0]),
                    movieId = Int32.Parse(input?.inputs?.movieSelection?.value.Split(':')[1])
                };
                MLContext mLContext = new MLContext();
                DataViewSchema modelSchema;
                ITransformer trainedModel = mLContext.Model.Load(Path.Combine(Environment.CurrentDirectory, "", "MovieRecommenderModel.zip"), out modelSchema);
                var predictionFunction = mLContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(trainedModel);
                var movieRatingPrediction = predictionFunction.Predict(movieRatingTestInput);

                if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
                {
                    outPut = String.Concat(movieRatingTestInput.userId, ":", movieRatingTestInput.movieId, ":", true);
                }
                else
                {
                    outPut = String.Concat(movieRatingTestInput.userId, ":", movieRatingTestInput.movieId, ":", false);
                }

                return Ok(outPut);
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}