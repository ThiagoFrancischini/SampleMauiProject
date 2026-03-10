using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class TravelEntry : BaseEntity
    {
        private Guid _id;
        private string _title;
        private string _description;
        private DateTime _date = DateTime.Now;
        private double _rating = 5.0;
        private string _category;
        private string _locationName;
        private double _latitude;
        private double _longitude;
        private string _imagePath;
        private bool _isFavorite;

        public Guid Id { get => _id; set => SetProperty(ref _id, value); }
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }
        public double Rating { get => _rating; set => SetProperty(ref _rating, value); }
        public string Category { get => _category; set => SetProperty(ref _category, value); }
        public string LocationName { get => _locationName; set => SetProperty(ref _locationName, value); }
        public double Latitude { get => _latitude; set => SetProperty(ref _latitude, value); }
        public double Longitude { get => _longitude; set => SetProperty(ref _longitude, value); }
        public string ImagePath { get => _imagePath; set => SetProperty(ref _imagePath, value); }
        public bool IsFavorite { get => _isFavorite; set => SetProperty(ref _isFavorite, value); }
    }
}
