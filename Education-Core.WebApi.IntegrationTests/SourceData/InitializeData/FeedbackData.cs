﻿using Domain.Entities.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class FeedbackData
    {
        private const int _length = 10;
        public static List<Feedback> Feedbacks { get; set; }

        static FeedbackData()
        {
            Feedbacks = new List<Feedback>();

            for (int i = 0; i < _length; i++)
            {
                Feedbacks.Add(new Feedback()
                {
                    ID = Guid.NewGuid(),
                    Description = $"Integration test Description feedback{i}",
                    Date = new DateTime(2020,10,10)
                });
            }
        }
    }
}
