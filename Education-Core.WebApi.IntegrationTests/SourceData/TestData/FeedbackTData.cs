using Domain.Entities.Feedbacks;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class FeedbackTData
    {
        private static List<Feedback> _feedbacks;
        private const int _countFeedbacks = 1;

        static FeedbackTData()
        {
            _feedbacks = new List<Feedback>();

            for (int i = 0; i < _countFeedbacks; i++)
            {
                _feedbacks.Add(new Feedback()
                {
                    ID = Guid.NewGuid(),
                    Date = DateTime.Today,
                    Description = $"integration test description{i}"
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            yield return new object[]
            {
                _feedbacks,
                UserInitData.UserWithRole,
                _feedbacks
            };
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            foreach (var feedback in _feedbacks)
            {
                yield return new object[]
                {
                    feedback,
                    UserInitData.UserWithRole,
                    feedback
                };
            }
        }

        public static IEnumerable<object[]> DataForDelete()
        {
            foreach (var feedback in _feedbacks)
            {
                yield return new object[]
                {
                    feedback,
                    UserInitData.UserWithRole,
                };
            }
        }
    }
}
