using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EricsAwesomeShop.Models {
    public class Car {

        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [MaxLength(500)]
        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }

        public ElectricCar ElectricCar { get; set; }
        public InternalCombustionCar InternalCombustionCar { get; set; }
    }

    public interface ICar {
        Car Base { get; set; }
    }

    public class ElectricCar : ICar {

        public int Id { get; set; }

        [Required]
        public Car Base { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Range { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int ChargeTime { get; set; }
    }

    public class InternalCombustionCar : ICar {

        public int Id { get; set; }

        [Required]
        public Car Base { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int GasMileage { get; set; }
    }
}