using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Services.RatingCreationService
{
    public class RatingCreationService : IRatingCreationService
    {
        private readonly IRatingServiceViewModel ratingServiceViewModel;

        public RatingCreationService(IRatingServiceViewModel ratingServiceViewModel)
        {
            this.ratingServiceViewModel = ratingServiceViewModel;
        }

        public void ShowWindow()
        {
            var window = new RatingServiceWindow
            {
                DataContext = ratingServiceViewModel
            };
            window.ShowDialog();
        }
    }
}
